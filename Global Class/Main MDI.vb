'Imports System.Data.SqlClient
Imports System.Drawing.Drawing2D
Imports System.Data.SqlClient
Imports cocoafob
Imports System.Security
'Imports Microsoft.VisualBasic
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Diagnostics
Imports System.IO

Public Class Main_MDI
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
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents submnu_GroupMaster As System.Windows.Forms.MenuItem
    Friend WithEvents submnu_SubGroupMaster As System.Windows.Forms.MenuItem
    Friend WithEvents submnu_ItemMaster As System.Windows.Forms.MenuItem
    Friend WithEvents submnu_GRNCumPurchaseBill As System.Windows.Forms.MenuItem
    Friend WithEvents submnu_StockTransfer As System.Windows.Forms.MenuItem
    Friend WithEvents submnu_StockDamage As System.Windows.Forms.MenuItem
    Friend WithEvents mnu_Masters As System.Windows.Forms.MenuItem
    Friend WithEvents mnu_Transaction As System.Windows.Forms.MenuItem
    Friend WithEvents mnu_Reports As System.Windows.Forms.MenuItem
    Friend WithEvents mnu_Utility As System.Windows.Forms.MenuItem
    Friend WithEvents submnu_Calculator As System.Windows.Forms.MenuItem
    Friend WithEvents submnu_Notepad As System.Windows.Forms.MenuItem
    Friend WithEvents mnu_Window As System.Windows.Forms.MenuItem
    Friend WithEvents submnu_HorizontalTile As System.Windows.Forms.MenuItem
    Friend WithEvents submnu_VerticalTile As System.Windows.Forms.MenuItem
    Friend WithEvents submnu_Cascade As System.Windows.Forms.MenuItem
    Friend WithEvents submnu_IssueRegister As System.Windows.Forms.MenuItem
    Friend WithEvents submnu_IssueDetails As System.Windows.Forms.MenuItem
    Friend WithEvents submnu_StockLedger As System.Windows.Forms.MenuItem
    Friend WithEvents submnu_StockSummary As System.Windows.Forms.MenuItem
    Friend WithEvents submnu_PurchaseRegister As System.Windows.Forms.MenuItem
    Friend WithEvents mnu_Administrator As System.Windows.Forms.MenuItem
    Friend WithEvents submnu_Useradmin As System.Windows.Forms.MenuItem
    Friend WithEvents submnu_StockAdjustment As System.Windows.Forms.MenuItem
    Friend WithEvents Submnu_Stocktransferregister As System.Windows.Forms.MenuItem
    Friend WithEvents Submnu_StockReturnregister As System.Windows.Forms.MenuItem
    Friend WithEvents Submnu_StockAdjustmentregister As System.Windows.Forms.MenuItem
    Friend WithEvents Stock_Summary As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents SubUOM As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem23 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem24 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem27 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem28 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem29 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem31 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem32 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem33 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem20 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem13 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem14 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem15 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem16 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem17 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem18 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem19 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem21 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem22 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem26 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem34 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem35 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem36 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem37 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem38 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem39 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem40 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem41 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem42 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem43 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem44 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem45 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem46 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem47 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem48 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem49 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem50 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem51 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem52 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem53 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem54 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem55 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem56 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem57 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem58 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem59 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem60 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem61 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem62 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem63 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem64 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem65 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem66 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem67 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem68 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem69 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem70 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem72 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem73 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem74 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem75 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem76 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem77 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem78 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem79 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As MenuItem
    Friend WithEvents MenuItem80 As MenuItem
    Friend WithEvents MenuItem25 As MenuItem
    Friend WithEvents MenuItem71 As MenuItem
    Friend WithEvents MenuItem81 As MenuItem
    Friend WithEvents MenuItem82 As MenuItem
    Friend WithEvents MenuItem83 As MenuItem
    Friend WithEvents MenuItem84 As MenuItem
    Friend WithEvents MenuItem85 As MenuItem
    Friend WithEvents MenuItem86 As MenuItem
    Friend WithEvents MenuItem87 As MenuItem
    Friend WithEvents MenuItem88 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem89 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem90 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem91 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem93 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem30 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main_MDI))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.mnu_Masters = New System.Windows.Forms.MenuItem()
        Me.MenuItem10 = New System.Windows.Forms.MenuItem()
        Me.MenuItem34 = New System.Windows.Forms.MenuItem()
        Me.submnu_GroupMaster = New System.Windows.Forms.MenuItem()
        Me.submnu_SubGroupMaster = New System.Windows.Forms.MenuItem()
        Me.MenuItem8 = New System.Windows.Forms.MenuItem()
        Me.MenuItem35 = New System.Windows.Forms.MenuItem()
        Me.MenuItem57 = New System.Windows.Forms.MenuItem()
        Me.MenuItem19 = New System.Windows.Forms.MenuItem()
        Me.SubUOM = New System.Windows.Forms.MenuItem()
        Me.MenuItem33 = New System.Windows.Forms.MenuItem()
        Me.MenuItem26 = New System.Windows.Forms.MenuItem()
        Me.submnu_ItemMaster = New System.Windows.Forms.MenuItem()
        Me.MenuItem30 = New System.Windows.Forms.MenuItem()
        Me.MenuItem43 = New System.Windows.Forms.MenuItem()
        Me.MenuItem16 = New System.Windows.Forms.MenuItem()
        Me.MenuItem15 = New System.Windows.Forms.MenuItem()
        Me.MenuItem58 = New System.Windows.Forms.MenuItem()
        Me.MenuItem21 = New System.Windows.Forms.MenuItem()
        Me.MenuItem42 = New System.Windows.Forms.MenuItem()
        Me.MenuItem89 = New System.Windows.Forms.MenuItem()
        Me.MenuItem44 = New System.Windows.Forms.MenuItem()
        Me.MenuItem56 = New System.Windows.Forms.MenuItem()
        Me.MenuItem60 = New System.Windows.Forms.MenuItem()
        Me.MenuItem61 = New System.Windows.Forms.MenuItem()
        Me.MenuItem69 = New System.Windows.Forms.MenuItem()
        Me.MenuItem71 = New System.Windows.Forms.MenuItem()
        Me.mnu_Transaction = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.MenuItem17 = New System.Windows.Forms.MenuItem()
        Me.MenuItem22 = New System.Windows.Forms.MenuItem()
        Me.submnu_GRNCumPurchaseBill = New System.Windows.Forms.MenuItem()
        Me.MenuItem18 = New System.Windows.Forms.MenuItem()
        Me.MenuItem23 = New System.Windows.Forms.MenuItem()
        Me.submnu_StockTransfer = New System.Windows.Forms.MenuItem()
        Me.submnu_StockAdjustment = New System.Windows.Forms.MenuItem()
        Me.MenuItem24 = New System.Windows.Forms.MenuItem()
        Me.submnu_StockDamage = New System.Windows.Forms.MenuItem()
        Me.MenuItem29 = New System.Windows.Forms.MenuItem()
        Me.MenuItem41 = New System.Windows.Forms.MenuItem()
        Me.MenuItem63 = New System.Windows.Forms.MenuItem()
        Me.MenuItem67 = New System.Windows.Forms.MenuItem()
        Me.MenuItem77 = New System.Windows.Forms.MenuItem()
        Me.MenuItem25 = New System.Windows.Forms.MenuItem()
        Me.MenuItem85 = New System.Windows.Forms.MenuItem()
        Me.mnu_Reports = New System.Windows.Forms.MenuItem()
        Me.submnu_PurchaseRegister = New System.Windows.Forms.MenuItem()
        Me.submnu_IssueRegister = New System.Windows.Forms.MenuItem()
        Me.submnu_IssueDetails = New System.Windows.Forms.MenuItem()
        Me.submnu_StockSummary = New System.Windows.Forms.MenuItem()
        Me.Submnu_Stocktransferregister = New System.Windows.Forms.MenuItem()
        Me.Submnu_StockReturnregister = New System.Windows.Forms.MenuItem()
        Me.Submnu_StockAdjustmentregister = New System.Windows.Forms.MenuItem()
        Me.submnu_StockLedger = New System.Windows.Forms.MenuItem()
        Me.Stock_Summary = New System.Windows.Forms.MenuItem()
        Me.MenuItem53 = New System.Windows.Forms.MenuItem()
        Me.MenuItem54 = New System.Windows.Forms.MenuItem()
        Me.MenuItem73 = New System.Windows.Forms.MenuItem()
        Me.MenuItem20 = New System.Windows.Forms.MenuItem()
        Me.MenuItem27 = New System.Windows.Forms.MenuItem()
        Me.MenuItem28 = New System.Windows.Forms.MenuItem()
        Me.MenuItem31 = New System.Windows.Forms.MenuItem()
        Me.MenuItem11 = New System.Windows.Forms.MenuItem()
        Me.MenuItem12 = New System.Windows.Forms.MenuItem()
        Me.MenuItem13 = New System.Windows.Forms.MenuItem()
        Me.MenuItem14 = New System.Windows.Forms.MenuItem()
        Me.MenuItem36 = New System.Windows.Forms.MenuItem()
        Me.MenuItem37 = New System.Windows.Forms.MenuItem()
        Me.MenuItem38 = New System.Windows.Forms.MenuItem()
        Me.MenuItem39 = New System.Windows.Forms.MenuItem()
        Me.MenuItem40 = New System.Windows.Forms.MenuItem()
        Me.MenuItem45 = New System.Windows.Forms.MenuItem()
        Me.MenuItem47 = New System.Windows.Forms.MenuItem()
        Me.MenuItem48 = New System.Windows.Forms.MenuItem()
        Me.MenuItem50 = New System.Windows.Forms.MenuItem()
        Me.MenuItem51 = New System.Windows.Forms.MenuItem()
        Me.MenuItem52 = New System.Windows.Forms.MenuItem()
        Me.MenuItem55 = New System.Windows.Forms.MenuItem()
        Me.MenuItem59 = New System.Windows.Forms.MenuItem()
        Me.MenuItem62 = New System.Windows.Forms.MenuItem()
        Me.MenuItem64 = New System.Windows.Forms.MenuItem()
        Me.MenuItem65 = New System.Windows.Forms.MenuItem()
        Me.MenuItem68 = New System.Windows.Forms.MenuItem()
        Me.MenuItem70 = New System.Windows.Forms.MenuItem()
        Me.MenuItem72 = New System.Windows.Forms.MenuItem()
        Me.MenuItem75 = New System.Windows.Forms.MenuItem()
        Me.MenuItem78 = New System.Windows.Forms.MenuItem()
        Me.MenuItem79 = New System.Windows.Forms.MenuItem()
        Me.MenuItem80 = New System.Windows.Forms.MenuItem()
        Me.MenuItem82 = New System.Windows.Forms.MenuItem()
        Me.MenuItem83 = New System.Windows.Forms.MenuItem()
        Me.MenuItem84 = New System.Windows.Forms.MenuItem()
        Me.MenuItem87 = New System.Windows.Forms.MenuItem()
        Me.MenuItem90 = New System.Windows.Forms.MenuItem()
        Me.MenuItem91 = New System.Windows.Forms.MenuItem()
        Me.MenuItem93 = New System.Windows.Forms.MenuItem()
        Me.mnu_Utility = New System.Windows.Forms.MenuItem()
        Me.submnu_Calculator = New System.Windows.Forms.MenuItem()
        Me.submnu_Notepad = New System.Windows.Forms.MenuItem()
        Me.mnu_Administrator = New System.Windows.Forms.MenuItem()
        Me.submnu_Useradmin = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.MenuItem7 = New System.Windows.Forms.MenuItem()
        Me.MenuItem9 = New System.Windows.Forms.MenuItem()
        Me.MenuItem32 = New System.Windows.Forms.MenuItem()
        Me.MenuItem46 = New System.Windows.Forms.MenuItem()
        Me.MenuItem49 = New System.Windows.Forms.MenuItem()
        Me.MenuItem74 = New System.Windows.Forms.MenuItem()
        Me.MenuItem76 = New System.Windows.Forms.MenuItem()
        Me.MenuItem81 = New System.Windows.Forms.MenuItem()
        Me.MenuItem86 = New System.Windows.Forms.MenuItem()
        Me.MenuItem88 = New System.Windows.Forms.MenuItem()
        Me.mnu_Window = New System.Windows.Forms.MenuItem()
        Me.submnu_HorizontalTile = New System.Windows.Forms.MenuItem()
        Me.submnu_VerticalTile = New System.Windows.Forms.MenuItem()
        Me.submnu_Cascade = New System.Windows.Forms.MenuItem()
        Me.MenuItem66 = New System.Windows.Forms.MenuItem()
        Me.MenuItem6 = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnu_Masters, Me.mnu_Transaction, Me.mnu_Reports, Me.mnu_Utility, Me.mnu_Administrator, Me.mnu_Window, Me.MenuItem6})
        '
        'mnu_Masters
        '
        Me.mnu_Masters.Index = 0
        Me.mnu_Masters.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem10, Me.MenuItem34, Me.submnu_GroupMaster, Me.submnu_SubGroupMaster, Me.MenuItem8, Me.MenuItem35, Me.MenuItem57, Me.MenuItem19, Me.SubUOM, Me.MenuItem33, Me.MenuItem26, Me.submnu_ItemMaster, Me.MenuItem30, Me.MenuItem43, Me.MenuItem16, Me.MenuItem15, Me.MenuItem58, Me.MenuItem21, Me.MenuItem42, Me.MenuItem89, Me.MenuItem44, Me.MenuItem56, Me.MenuItem60, Me.MenuItem61, Me.MenuItem69, Me.MenuItem71})
        Me.mnu_Masters.Text = "&Masters"
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 0
        Me.MenuItem10.Text = "Inventory Setup"
        '
        'MenuItem34
        '
        Me.MenuItem34.Index = 1
        Me.MenuItem34.Text = "Category Master"
        '
        'submnu_GroupMaster
        '
        Me.submnu_GroupMaster.Index = 2
        Me.submnu_GroupMaster.Shortcut = System.Windows.Forms.Shortcut.CtrlG
        Me.submnu_GroupMaster.Text = "&Group Master"
        '
        'submnu_SubGroupMaster
        '
        Me.submnu_SubGroupMaster.Index = 3
        Me.submnu_SubGroupMaster.Shortcut = System.Windows.Forms.Shortcut.CtrlR
        Me.submnu_SubGroupMaster.Text = "Sub G&roup Master"
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 4
        Me.MenuItem8.Text = "Sub Sub Group Master"
        '
        'MenuItem35
        '
        Me.MenuItem35.Index = 5
        Me.MenuItem35.Text = "Store Master"
        '
        'MenuItem57
        '
        Me.MenuItem57.Index = 6
        Me.MenuItem57.Text = "Delivery Terms Master"
        Me.MenuItem57.Visible = False
        '
        'MenuItem19
        '
        Me.MenuItem19.Index = 7
        Me.MenuItem19.Text = "Tax Master"
        Me.MenuItem19.Visible = False
        '
        'SubUOM
        '
        Me.SubUOM.Index = 8
        Me.SubUOM.Text = "UOM Master"
        '
        'MenuItem33
        '
        Me.MenuItem33.Index = 9
        Me.MenuItem33.Text = "UOM Convertion Entry"
        '
        'MenuItem26
        '
        Me.MenuItem26.Index = 10
        Me.MenuItem26.Text = "Vendor Creation"
        '
        'submnu_ItemMaster
        '
        Me.submnu_ItemMaster.Index = 11
        Me.submnu_ItemMaster.Shortcut = System.Windows.Forms.Shortcut.CtrlM
        Me.submnu_ItemMaster.Text = "&Item Master"
        '
        'MenuItem30
        '
        Me.MenuItem30.Index = 12
        Me.MenuItem30.Text = "Consumer Master"
        Me.MenuItem30.Visible = False
        '
        'MenuItem43
        '
        Me.MenuItem43.Index = 13
        Me.MenuItem43.Text = "Sponsor Master"
        '
        'MenuItem16
        '
        Me.MenuItem16.Index = 14
        Me.MenuItem16.Text = "Item Tax Group Tagging"
        '
        'MenuItem15
        '
        Me.MenuItem15.Index = 15
        Me.MenuItem15.Text = "Tax Account Tagging"
        Me.MenuItem15.Visible = False
        '
        'MenuItem58
        '
        Me.MenuItem58.Index = 16
        Me.MenuItem58.Text = "InputTax Accounts Tagging"
        '
        'MenuItem21
        '
        Me.MenuItem21.Index = 17
        Me.MenuItem21.Text = "Tax Grouping"
        '
        'MenuItem42
        '
        Me.MenuItem42.Index = 18
        Me.MenuItem42.Text = "Accounts Tagging"
        '
        'MenuItem89
        '
        Me.MenuItem89.Index = 19
        Me.MenuItem89.Text = "Bill of Material (BOM)"
        '
        'MenuItem44
        '
        Me.MenuItem44.Index = 20
        Me.MenuItem44.Text = "Sponsor Account Tagging"
        Me.MenuItem44.Visible = False
        '
        'MenuItem56
        '
        Me.MenuItem56.Index = 21
        Me.MenuItem56.Text = "Store Group Master"
        Me.MenuItem56.Visible = False
        '
        'MenuItem60
        '
        Me.MenuItem60.Index = 22
        Me.MenuItem60.Text = "Company Master"
        '
        'MenuItem61
        '
        Me.MenuItem61.Index = 23
        Me.MenuItem61.Text = "Company Item Tagging"
        '
        'MenuItem69
        '
        Me.MenuItem69.Index = 24
        Me.MenuItem69.Text = "Store Cost Center Tagging"
        '
        'MenuItem71
        '
        Me.MenuItem71.Index = 25
        Me.MenuItem71.Text = "Session Master"
        Me.MenuItem71.Visible = False
        '
        'mnu_Transaction
        '
        Me.mnu_Transaction.Index = 1
        Me.mnu_Transaction.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem4, Me.MenuItem17, Me.MenuItem22, Me.submnu_GRNCumPurchaseBill, Me.MenuItem18, Me.MenuItem23, Me.submnu_StockTransfer, Me.submnu_StockAdjustment, Me.MenuItem24, Me.submnu_StockDamage, Me.MenuItem29, Me.MenuItem41, Me.MenuItem63, Me.MenuItem67, Me.MenuItem77, Me.MenuItem25, Me.MenuItem85})
        Me.mnu_Transaction.Text = "&Transactions"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 0
        Me.MenuItem4.Text = "PO Indent"
        Me.MenuItem4.Visible = False
        '
        'MenuItem17
        '
        Me.MenuItem17.Index = 1
        Me.MenuItem17.Text = "Purchase Order"
        '
        'MenuItem22
        '
        Me.MenuItem22.Index = 2
        Me.MenuItem22.Text = "Purchase Order Amendment"
        '
        'submnu_GRNCumPurchaseBill
        '
        Me.submnu_GRNCumPurchaseBill.Index = 3
        Me.submnu_GRNCumPurchaseBill.Shortcut = System.Windows.Forms.Shortcut.CtrlP
        Me.submnu_GRNCumPurchaseBill.Text = "GRN Cum &Purchase Bill"
        '
        'MenuItem18
        '
        Me.MenuItem18.Index = 4
        Me.MenuItem18.Shortcut = System.Windows.Forms.Shortcut.CtrlD
        Me.MenuItem18.Text = "Stock Indent"
        '
        'MenuItem23
        '
        Me.MenuItem23.Index = 5
        Me.MenuItem23.Shortcut = System.Windows.Forms.Shortcut.CtrlO
        Me.MenuItem23.Text = "Stock Issue"
        '
        'submnu_StockTransfer
        '
        Me.submnu_StockTransfer.Index = 6
        Me.submnu_StockTransfer.Shortcut = System.Windows.Forms.Shortcut.CtrlT
        Me.submnu_StockTransfer.Text = "Stock &Transfer/Return"
        '
        'submnu_StockAdjustment
        '
        Me.submnu_StockAdjustment.Index = 7
        Me.submnu_StockAdjustment.Shortcut = System.Windows.Forms.Shortcut.CtrlA
        Me.submnu_StockAdjustment.Text = "Stock &Adjustment"
        '
        'MenuItem24
        '
        Me.MenuItem24.Index = 8
        Me.MenuItem24.Text = "Purchase Return "
        '
        'submnu_StockDamage
        '
        Me.submnu_StockDamage.Index = 9
        Me.submnu_StockDamage.Shortcut = System.Windows.Forms.Shortcut.CtrlG
        Me.submnu_StockDamage.Text = "Stock &Damage"
        '
        'MenuItem29
        '
        Me.MenuItem29.Index = 10
        Me.MenuItem29.Text = "Consumption Entry"
        Me.MenuItem29.Visible = False
        '
        'MenuItem41
        '
        Me.MenuItem41.Index = 11
        Me.MenuItem41.Text = "Stock Consumption"
        '
        'MenuItem63
        '
        Me.MenuItem63.Index = 12
        Me.MenuItem63.Text = "Non Stockable GRN Update Form"
        Me.MenuItem63.Visible = False
        '
        'MenuItem67
        '
        Me.MenuItem67.Index = 13
        Me.MenuItem67.Text = "Item Conversion"
        '
        'MenuItem77
        '
        Me.MenuItem77.Index = 14
        Me.MenuItem77.Text = "Salvage Entry"
        Me.MenuItem77.Visible = False
        '
        'MenuItem25
        '
        Me.MenuItem25.Index = 15
        Me.MenuItem25.Text = "Direct GRN"
        Me.MenuItem25.Visible = False
        '
        'MenuItem85
        '
        Me.MenuItem85.Index = 16
        Me.MenuItem85.Text = "Stock Distribution "
        '
        'mnu_Reports
        '
        Me.mnu_Reports.Index = 2
        Me.mnu_Reports.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.submnu_PurchaseRegister, Me.submnu_IssueRegister, Me.submnu_IssueDetails, Me.submnu_StockSummary, Me.Submnu_Stocktransferregister, Me.Submnu_StockReturnregister, Me.Submnu_StockAdjustmentregister, Me.submnu_StockLedger, Me.Stock_Summary, Me.MenuItem20, Me.MenuItem27, Me.MenuItem28, Me.MenuItem31, Me.MenuItem11, Me.MenuItem12, Me.MenuItem13, Me.MenuItem14, Me.MenuItem36, Me.MenuItem37, Me.MenuItem38, Me.MenuItem39, Me.MenuItem40, Me.MenuItem45, Me.MenuItem47, Me.MenuItem48, Me.MenuItem50, Me.MenuItem51, Me.MenuItem52, Me.MenuItem55, Me.MenuItem59, Me.MenuItem62, Me.MenuItem64, Me.MenuItem65, Me.MenuItem68, Me.MenuItem70, Me.MenuItem72, Me.MenuItem75, Me.MenuItem78, Me.MenuItem79, Me.MenuItem80, Me.MenuItem82, Me.MenuItem83, Me.MenuItem84, Me.MenuItem87, Me.MenuItem90, Me.MenuItem91, Me.MenuItem93})
        Me.mnu_Reports.Text = "Re&ports"
        '
        'submnu_PurchaseRegister
        '
        Me.submnu_PurchaseRegister.Index = 0
        Me.submnu_PurchaseRegister.Text = "&Purchase/Return  Register"
        '
        'submnu_IssueRegister
        '
        Me.submnu_IssueRegister.Index = 1
        Me.submnu_IssueRegister.Text = "Issue By Issue No"
        '
        'submnu_IssueDetails
        '
        Me.submnu_IssueDetails.Index = 2
        Me.submnu_IssueDetails.Text = "Issue &Details"
        Me.submnu_IssueDetails.Visible = False
        '
        'submnu_StockSummary
        '
        Me.submnu_StockSummary.Index = 3
        Me.submnu_StockSummary.Text = "Issue &Summary"
        '
        'Submnu_Stocktransferregister
        '
        Me.Submnu_Stocktransferregister.Index = 4
        Me.Submnu_Stocktransferregister.Text = "Stock &Transfer Register"
        '
        'Submnu_StockReturnregister
        '
        Me.Submnu_StockReturnregister.Index = 5
        Me.Submnu_StockReturnregister.Text = "Stock &Return Register"
        Me.Submnu_StockReturnregister.Visible = False
        '
        'Submnu_StockAdjustmentregister
        '
        Me.Submnu_StockAdjustmentregister.Index = 6
        Me.Submnu_StockAdjustmentregister.Text = "Stock &Adjustment Register"
        '
        'submnu_StockLedger
        '
        Me.submnu_StockLedger.Index = 7
        Me.submnu_StockLedger.Text = "Stock &Ledger"
        '
        'Stock_Summary
        '
        Me.Stock_Summary.Index = 8
        Me.Stock_Summary.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem53, Me.MenuItem54, Me.MenuItem73})
        Me.Stock_Summary.Text = "S&tock Summary"
        '
        'MenuItem53
        '
        Me.MenuItem53.Index = 0
        Me.MenuItem53.Text = "Stock Summary Category Wise"
        '
        'MenuItem54
        '
        Me.MenuItem54.Index = 1
        Me.MenuItem54.Text = "Stock Summary Group Wise"
        '
        'MenuItem73
        '
        Me.MenuItem73.Index = 2
        Me.MenuItem73.Text = "Stock Summary Sub Group Wise"
        '
        'MenuItem20
        '
        Me.MenuItem20.Index = 9
        Me.MenuItem20.Text = "ROL Summary"
        Me.MenuItem20.Visible = False
        '
        'MenuItem27
        '
        Me.MenuItem27.Index = 10
        Me.MenuItem27.Text = "Categorywise Stock Summary"
        Me.MenuItem27.Visible = False
        '
        'MenuItem28
        '
        Me.MenuItem28.Index = 11
        Me.MenuItem28.Text = "Stock Damage Register"
        '
        'MenuItem31
        '
        Me.MenuItem31.Index = 12
        Me.MenuItem31.Text = "Stock Consumption Register"
        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 13
        Me.MenuItem11.Text = "Rate Revision Report"
        Me.MenuItem11.Visible = False
        '
        'MenuItem12
        '
        Me.MenuItem12.Index = 14
        Me.MenuItem12.Text = "Consolidated Stock Summary"
        '
        'MenuItem13
        '
        Me.MenuItem13.Index = 15
        Me.MenuItem13.Text = "Month STB Report"
        Me.MenuItem13.Visible = False
        '
        'MenuItem14
        '
        Me.MenuItem14.Index = 16
        Me.MenuItem14.Text = "RSI Report"
        Me.MenuItem14.Visible = False
        '
        'MenuItem36
        '
        Me.MenuItem36.Index = 17
        Me.MenuItem36.Text = "Issue By Itemwise"
        '
        'MenuItem37
        '
        Me.MenuItem37.Index = 18
        Me.MenuItem37.Text = "Pending PO And PO Wise GRN Report"
        '
        'MenuItem38
        '
        Me.MenuItem38.Index = 19
        Me.MenuItem38.Text = "Item By Vendors Report"
        '
        'MenuItem39
        '
        Me.MenuItem39.Index = 20
        Me.MenuItem39.Text = "Store Wise Consolidated Issue Report"
        Me.MenuItem39.Visible = False
        '
        'MenuItem40
        '
        Me.MenuItem40.Index = 21
        Me.MenuItem40.Text = "Free Stock And Sponsered Stock Report"
        '
        'MenuItem45
        '
        Me.MenuItem45.Index = 22
        Me.MenuItem45.Text = "Audit Trail"
        '
        'MenuItem47
        '
        Me.MenuItem47.Index = 23
        Me.MenuItem47.Text = "Receipt Register"
        '
        'MenuItem48
        '
        Me.MenuItem48.Index = 24
        Me.MenuItem48.Text = "Issue Reciept Consolidated Report Store wise"
        Me.MenuItem48.Visible = False
        '
        'MenuItem50
        '
        Me.MenuItem50.Index = 25
        Me.MenuItem50.Text = "Tax Report"
        '
        'MenuItem51
        '
        Me.MenuItem51.Index = 26
        Me.MenuItem51.Text = "Pending PO Details"
        '
        'MenuItem52
        '
        Me.MenuItem52.Index = 27
        Me.MenuItem52.Text = "Pending Indent Issue Details"
        '
        'MenuItem55
        '
        Me.MenuItem55.Index = 28
        Me.MenuItem55.Text = "Store Wise Closing Stock"
        Me.MenuItem55.Visible = False
        '
        'MenuItem59
        '
        Me.MenuItem59.Index = 29
        Me.MenuItem59.Text = "Print PO"
        '
        'MenuItem62
        '
        Me.MenuItem62.Index = 30
        Me.MenuItem62.Text = "Company Wise Item Offtake Report"
        '
        'MenuItem64
        '
        Me.MenuItem64.Index = 31
        Me.MenuItem64.Text = "Excise Report"
        Me.MenuItem64.Visible = False
        '
        'MenuItem65
        '
        Me.MenuItem65.Index = 32
        Me.MenuItem65.Text = "Yearly Consolidated Issue Report"
        '
        'MenuItem68
        '
        Me.MenuItem68.Index = 33
        Me.MenuItem68.Text = "Vendor Items Link Report"
        '
        'MenuItem70
        '
        Me.MenuItem70.Index = 34
        Me.MenuItem70.Text = "Excise Report"
        Me.MenuItem70.Visible = False
        '
        'MenuItem72
        '
        Me.MenuItem72.Index = 35
        Me.MenuItem72.Text = "Reorder Level Report"
        '
        'MenuItem75
        '
        Me.MenuItem75.Index = 36
        Me.MenuItem75.Text = "Group and SubGroupwise issue Report"
        '
        'MenuItem78
        '
        Me.MenuItem78.Index = 37
        Me.MenuItem78.Text = "Indent/Purchase Order Report"
        Me.MenuItem78.Visible = False
        '
        'MenuItem79
        '
        Me.MenuItem79.Index = 38
        Me.MenuItem79.Text = "Report For Indent/Po"
        Me.MenuItem79.Visible = False
        '
        'MenuItem80
        '
        Me.MenuItem80.Index = 39
        Me.MenuItem80.Text = "Storewise Itemwise Expiry Report"
        Me.MenuItem80.Visible = False
        '
        'MenuItem82
        '
        Me.MenuItem82.Index = 40
        Me.MenuItem82.Text = "Sale Report"
        '
        'MenuItem83
        '
        Me.MenuItem83.Index = 41
        Me.MenuItem83.Text = "Distributed  Stock Issue "
        '
        'MenuItem84
        '
        Me.MenuItem84.Index = 42
        Me.MenuItem84.Text = "PO REPORT SUMMARY AND DETAIL"
        '
        'MenuItem87
        '
        Me.MenuItem87.Index = 43
        Me.MenuItem87.Text = "Stock Summary Costing "
        '
        'MenuItem90
        '
        Me.MenuItem90.Index = 44
        Me.MenuItem90.Text = "Profit Report"
        '
        'MenuItem91
        '
        Me.MenuItem91.Index = 45
        Me.MenuItem91.Text = "Consolidated STB Report"
        '
        'MenuItem93
        '
        Me.MenuItem93.Index = 46
        Me.MenuItem93.Text = "Bar Rate Revision"
        '
        'mnu_Utility
        '
        Me.mnu_Utility.Index = 3
        Me.mnu_Utility.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.submnu_Calculator, Me.submnu_Notepad})
        Me.mnu_Utility.Text = "&Utility"
        '
        'submnu_Calculator
        '
        Me.submnu_Calculator.Index = 0
        Me.submnu_Calculator.Shortcut = System.Windows.Forms.Shortcut.CtrlL
        Me.submnu_Calculator.Text = "Calculator"
        '
        'submnu_Notepad
        '
        Me.submnu_Notepad.Index = 1
        Me.submnu_Notepad.Shortcut = System.Windows.Forms.Shortcut.CtrlN
        Me.submnu_Notepad.Text = "Note Pad"
        '
        'mnu_Administrator
        '
        Me.mnu_Administrator.Index = 4
        Me.mnu_Administrator.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.submnu_Useradmin, Me.MenuItem2, Me.MenuItem3, Me.MenuItem5, Me.MenuItem7, Me.MenuItem9, Me.MenuItem32, Me.MenuItem46, Me.MenuItem49, Me.MenuItem74, Me.MenuItem76, Me.MenuItem81, Me.MenuItem86, Me.MenuItem88})
        Me.mnu_Administrator.Text = "&Administrator"
        '
        'submnu_Useradmin
        '
        Me.submnu_Useradmin.Index = 0
        Me.submnu_Useradmin.Shortcut = System.Windows.Forms.Shortcut.CtrlH
        Me.submnu_Useradmin.Text = "User A&dmin"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.Text = "Select Company"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 2
        Me.MenuItem3.Text = "Inventory Update"
        Me.MenuItem3.Visible = False
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 3
        Me.MenuItem5.Text = "Carry Forward"
        Me.MenuItem5.Visible = False
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 4
        Me.MenuItem7.Text = "Sub Store Consumption - Manual Updation"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 5
        Me.MenuItem9.Text = "Weighted Average"
        Me.MenuItem9.Visible = False
        '
        'MenuItem32
        '
        Me.MenuItem32.Index = 6
        Me.MenuItem32.Text = "Account Posting"
        '
        'MenuItem46
        '
        Me.MenuItem46.Index = 7
        Me.MenuItem46.Text = "Manual Update Stock"
        '
        'MenuItem49
        '
        Me.MenuItem49.Index = 8
        Me.MenuItem49.Text = "Business Date Closing"
        '
        'MenuItem74
        '
        Me.MenuItem74.Index = 9
        Me.MenuItem74.Text = "Weighing Machine Setup"
        '
        'MenuItem76
        '
        Me.MenuItem76.Index = 10
        Me.MenuItem76.Text = "Consumption Posting "
        Me.MenuItem76.Visible = False
        '
        'MenuItem81
        '
        Me.MenuItem81.Index = 11
        Me.MenuItem81.Text = "Month Close"
        '
        'MenuItem86
        '
        Me.MenuItem86.Index = 12
        Me.MenuItem86.Text = "Day Close"
        '
        'MenuItem88
        '
        Me.MenuItem88.Index = 13
        Me.MenuItem88.Text = "Payment Gateway"
        '
        'mnu_Window
        '
        Me.mnu_Window.Index = 5
        Me.mnu_Window.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.submnu_HorizontalTile, Me.submnu_VerticalTile, Me.submnu_Cascade, Me.MenuItem66})
        Me.mnu_Window.Text = "&Window"
        '
        'submnu_HorizontalTile
        '
        Me.submnu_HorizontalTile.Index = 0
        Me.submnu_HorizontalTile.Text = "&Horizontal Tile"
        '
        'submnu_VerticalTile
        '
        Me.submnu_VerticalTile.Index = 1
        Me.submnu_VerticalTile.Text = "&Vertical Tile"
        '
        'submnu_Cascade
        '
        Me.submnu_Cascade.Index = 2
        Me.submnu_Cascade.Text = "&Cascade"
        '
        'MenuItem66
        '
        Me.MenuItem66.Index = 3
        Me.MenuItem66.Text = "Corporate Details"
        Me.MenuItem66.Visible = False
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 6
        Me.MenuItem6.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        Me.MenuItem6.Text = "Exit"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.Text = "Close"
        '
        'Main_MDI
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1008, 599)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.Menu = Me.MainMenu1
        Me.Name = "Main_MDI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INVENTORY"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim gconnection As New GlobalClass
    ' Dim gFUN As New GlobalFunction
    Private Sub Main_MDI_Layout(sender As Object, e As LayoutEventArgs) Handles Me.Layout

    End Sub
    Private Sub Main_MDI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDIParentobj = Me
        AppPath = Application.StartupPath

        If Dir(AppPath & "\Reports", FileAttribute.Directory) = "" Then
            MkDir(AppPath & "\Reports")
        End If

        '' Call updatetable()
        '  Call updation12()
        'Call compname()
        Call FillCompanyinfo()
        Call POLINK()
        Call SYS_DATE_TIME()
        Call nEWuPDATE()
        Call ExpiryCheck()

        '  CHECKUOM()
        '   Call Check_BOM()
        '  Call CHECK_TRANSCONVERSION()
        Call GetAccountcode()
        Call Activateuseradmin()
        Call GetAccountpOSINGType()

        If gAcPostingWise = "ITEM" And gCostcenter = True Then
            MenuItem69.Visible = True
        Else
            MenuItem69.Visible = False
        End If

        Call GetUserAccess()
        Call GetAccountTaggingType()
        If Mid(UCase(gShortname), 1, 3) = "CCL" Or Mid(UCase(gShortname), 1, 3) = "HGA" Then
            MenuItem76.Visible = True
        End If


        If UCase(gShortname) = "HG" Then
            MenuItem75.Visible = True
        Else
            MenuItem75.Visible = False

        End If
        MenuItem12.Visible = True
        If gpocode = "Y" Then
            If UCase(gShortname) = "HGA" Then
                MenuItem17.Visible = False
                MenuItem22.Visible = False
                MenuItem77.Visible = False
                MenuItem41.Visible = True
            Else
                MenuItem17.Visible = True
                MenuItem22.Visible = True
                MenuItem12.Visible = True
            End If
        End If


        If Guseraccess = "C" Then
            MenuItem50.Visible = False
        Else
            MenuItem50.Visible = True
        End If
        If UCase(gShortname) = "CATH" Then
            MenuItem12.Visible = True
        End If


        Call INVSETUP()
        Me.IsMdiContainer = True
        If (GINDENTNO = "YES") Or (GINDENTNO = "Y") Then
            MenuItem18.Visible = True
            MenuItem52.Visible = True
        Else
            MenuItem18.Visible = False
            MenuItem52.Visible = False
        End If
        If (gpocode = "YES") Or (gpocode = "Y") Then
            MenuItem17.Visible = True
            MenuItem22.Visible = True
            MenuItem37.Visible = True
            MenuItem51.Visible = True
            MenuItem57.Visible = True
        Else
            MenuItem17.Visible = False
            MenuItem22.Visible = False
            MenuItem37.Visible = False
            MenuItem51.Visible = False
            MenuItem57.Visible = False
        End If

        MenuItem64.Visible = False
        'If UCase(Mid(Trim(gCompanyname), 1, 8)) = "RAJENDRA" Then
        '    MenuItem13.Visible = True
        'Else
        '    MenuItem14.Visible = False
        '    MenuItem13.Visible = False
        '    MenuItem11.Visible = False
        'End If
        If Trim(UCase(gShortname)) = "CGC" Then
            MenuItem42.Visible = False
            MenuItem43.Visible = False
            MenuItem44.Visible = False
            MenuItem15.Visible = True
            MenuItem40.Visible = False
            MenuItem45.Visible = False
        Else
            MenuItem42.Visible = True
            MenuItem43.Visible = True
            MenuItem44.Visible = True
            'MenuItem15.Visible = True
        End If
        If Trim(UCase(gShortname)) = "HSR" Then
            MenuItem30.Visible = False
            MenuItem43.Visible = False
            MenuItem44.Visible = False
            MenuItem47.Visible = False
            MenuItem29.Visible = False
            MenuItem41.Visible = False
            MenuItem12.Visible = True
            MenuItem50.Visible = False
        End If

        If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
            MenuItem37.Visible = False
            MenuItem55.Visible = True
        End If
        If UCase(gShortname) = "BRC" Then
            MenuItem47.Visible = False
            submnu_IssueRegister.Visible = True
            MenuItem38.Visible = False
            MenuItem39.Visible = False
        End If

        If gUsername = "Admin" Then
            MenuItem67.Visible = True
            MenuItem66.Visible = True
        Else
            MenuItem67.Visible = False
            MenuItem66.Visible = False
        End If
        If UCase(gShortname) = "CCL" Or Mid(UCase(Trim(gShortname)), 1, 3) = "SAT" Then
            MenuItem15.Visible = False
            MenuItem58.Visible = True
            MenuItem59.Visible = True
            MenuItem60.Visible = False
            MenuItem61.Visible = False
            MenuItem62.Visible = False
            MenuItem63.Visible = True
            MenuItem50.Visible = True
            MenuItem48.Visible = True

            MenuItem65.Visible = True
            If Mid(UCase(Trim(gShortname)), 1, 3) = "SAT" Then
                MenuItem12.Visible = True
                MenuItem70.Visible = True
                MenuItem63.Visible = False
                MenuItem48.Visible = False
            End If
        Else
            'MenuItem15.Visible = True
            MenuItem50.Visible = False
            MenuItem58.Visible = True
            MenuItem59.Visible = False
            MenuItem48.Visible = False
            MenuItem65.Visible = False
        End If

        If UCase(gShortname) = "KBA" Then
            MenuItem60.Visible = True
            MenuItem61.Visible = True
            MenuItem62.Visible = True
            ' MenuItem32.Visible = True
            MenuItem30.Visible = False
            MenuItem57.Visible = False
            MenuItem51.Visible = True
            MenuItem37.Visible = False
            MenuItem64.Visible = True
            MenuItem50.Visible = True

        End If
        If Trim(UCase(gShortname)) = "ALU" Then

        End If

        If (GACCPOST.ToUpper() = "Y") Then

            MenuItem32.Visible = True
        Else
            MenuItem32.Visible = False
        End If

        If UCase(gShortname) = "MGC" Or UCase(gShortname) = "NIZAM" Then
            MenuItem67.Visible = True
            ' Call MGC_P()
        Else
            MenuItem67.Visible = False
        End If

        If Mid(UCase(Trim(gShortname)), 1, 3) = "KEA" Or Mid(UCase(Trim(gShortname)), 1, 3) = "RCL" Or Mid(UCase(Trim(gShortname)), 1, 3) = "BRC" Or Mid(UCase(Trim(gShortname)), 1, 3) = "SAT" Then
            MenuItem12.Visible = True
        End If

        If UCase(gShortname) <> "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) <> "JUB" Then

            If gUserCategory = "S" Or gUserCategory = "A" Then
                If gFyear = False Then
                    'Dim thr As New System.Threading.Thread(Sub() Check())
                    'thr.Start()
                End If
            End If

            If UCase(gShortname) = "CFC" Then
                submnu_StockAdjustment.Visible = True
                submnu_StockDamage.Visible = True
                Submnu_StockAdjustmentregister.Visible = True
                MenuItem28.Visible = True
            End If

        End If

        If gShortname = "BBSR" Then
            MenuItem74.Visible = True
        Else
            MenuItem74.Visible = False
        End If
        If gShortname = "KBA" Then
            MenuItem12.Visible = True

        End If
        If gShortname = "KSCA" Then
            MenuItem12.Visible = True

        End If
        If UCase(gShortname) = "DC" Then
            MenuItem12.Visible = True
        End If
        If UCase(gShortname) = "MLRF" Then
            MenuItem53.Visible = False
        End If
        If UCase(gShortname) = "BGC" Or UCase(gShortname) = "MLA" Or UCase(gShortname) = "TMA" Then
            MenuItem12.Visible = True
        End If
        If (GACCPOST.ToUpper() = "Y") Then
            If gUserCategory = "S" Or gUserCategory = "A" Then
                Dim str As String
                str = " SELECT *  FROM UnMatchedVoucher   WHERE VOUCHERTYPE IN ('GRN') "
                gconnection.getDataSet(str, "UnMatchedVoucher")
                If gdataset.Tables("UnMatchedVoucher").Rows.Count > 0 Then
                    MessageBox.Show("Some GRN Vouchers are not posted in Accounts. Plz check in Accounts Posting Screen.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
            End If

        End If
        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            Try

                Call license()

            Catch
                Licensebool = False
            End Try
        End If

        If UCase(gShortname) = "HGA" Then
            MenuItem12.Visible = True
            MenuItem77.Visible = True
            MenuItem4.Visible = True
        End If

        If UCase(gShortname) = "EPGC" Then
            MenuItem42.Visible = False
        End If
        If gpocode = "Y" Then
            If UCase(gShortname) = "KGA" Then
                MenuItem17.Visible = False
                MenuItem22.Visible = False
            End If
        End If
        If UCase(gShortname) = "UC" Then
            MenuItem17.Visible = False
            MenuItem22.Visible = False
            MenuItem18.Visible = False
        End If

        If UCase(gShortname) = "KIC" Then
            MenuItem12.Visible = True
        End If

        If GBATCHNO = "Y" Then
            MenuItem80.Visible = True
        End If
        If UCase(gShortname) = "CPC" Then
            MenuItem12.Visible = True
        End If
        MenuItem25.Visible = False

        If UCase(gShortname) = "FNCC" Then
            MenuItem71.Visible = True
        End If


        If UCase(gShortname) = "RSAOI" Then
            '=========================================IM Policy======================================

            Dim pending As New commonfunction("INVENTORY")
            pending.MdiParent = Me
            pending.Show()

            ''======================================================================================
        End If
        If UCase(gShortname) = "RSAOI" Then
            MenuItem12.Visible = True
            MenuItem37.Visible = False
            MenuItem40.Visible = False
            MenuItem45.Visible = False
            MenuItem47.Visible = False
            MenuItem51.Visible = False
            MenuItem62.Visible = False
            MenuItem72.Visible = False
            MenuItem78.Visible = False
            MenuItem80.Visible = False
        End If

        If UCase(gShortname) = "RSAOI" Then
            Dim curBdate, adjdate As DateTime
            Dim SQLSTRING As String
            SQLSTRING = "select bdate from Businessdate"
            gconnection.getDataSet(SQLSTRING, "Businessdate")
            If (gdataset.Tables("Businessdate").Rows.Count > 0) Then
                curBdate = Format(CDate(gdataset.Tables("Businessdate").Rows(0).Item("bdate")), "dd/MMM/yyyy")
                SQLSTRING = "SELECT CLOSEDATE  FROM ACCTCLOSE"
                gconnection.getDataSet(SQLSTRING, "ACCOUNTSCLOSE")
                If (gdataset.Tables("ACCOUNTSCLOSE").Rows.Count > 0) Then
                    adjdate = Format(CDate(gdataset.Tables("ACCOUNTSCLOSE").Rows(0).Item("CLOSEDATE")), "dd/MMM/yyyy")
                    If adjdate > curBdate Then
                        SQLSTRING = "UPDATE Businessdate SET BDATE='" & Format((adjdate), "dd/MMM/yyyy") & "' "
                        gconnection.getDataSet(SQLSTRING, "UPDATE_BDATE")
                    End If
                End If
            End If
        End If
        Dim ssql As String
        ssql = "SELECT Isnull(NewInvTag,'') as NewInvTag,Isnull(FoodMenuOption,'') as FoodMenuOption,Isnull(AccountsPosting,'N') as AccountsPosting,Isnull(VCCCheck,'NO') as VCCCheck FROM POSSETUP "
        gconnection.getDataSet(ssql, "NewInvTagSetup")
        If gdataset.Tables("NewInvTagSetup").Rows.Count > 0 Then
            NewInvTag = Mid(UCase(Trim(gdataset.Tables("NewInvTagSetup").Rows(0).Item("NewInvTag"))), 1, 1)
           
        Else
            NewInvTag = "N"
           
        End If


        If UCase(gShortname) = "CCC" Then
            MenuItem43.Visible = False
            MenuItem44.Visible = False
            MenuItem60.Visible = False
            MenuItem61.Visible = False
        End If

        If UCase(gShortname) = "HGA" Then
            MenuItem30.Visible = True
            MenuItem29.Visible = True
        End If

        If UCase(gShortname) <> "KORA" Then
            MenuItem82.Visible = False
        End If

        If UCase(gShortname) = "HGA" Then
            MenuItem83.Visible = True
            MenuItem85.Visible = True
        Else
            MenuItem83.Visible = False
            MenuItem85.Visible = False
        End If

        If gShortname = "RSIHYD" Then
            MenuItem13.Visible = True
            MenuItem14.Visible = True
        End If

        MenuItem12.Visible = True

        If gShortname = "GNC" Then
            Call GncMenuItem()
        End If

    End Sub
    Private Sub GncMenuItem()
        MenuItem47.Visible = False
        MenuItem51.Visible = False
        MenuItem52.Visible = False
        MenuItem62.Visible = False
        MenuItem68.Visible = False
        MenuItem84.Visible = False
        MenuItem87.Visible = False
        MenuItem90.Visible = False
        MenuItem91.Visible = False
        MenuItem93.Visible = False
    End Sub
    Private Sub SYS_DATE_TIME()
        Dim sqlstring As String
        Try
            sqlstring = "SELECT SERVERDATE,SERVERTIME FROM VIEW_SERVER_DATETIME "
            gconnection.getDataSet(sqlstring, "SERVERDATE")
            If gdataset.Tables("SERVERDATE").Rows.Count > 0 Then
                serverdate = Format(gdataset.Tables("SERVERDATE").Rows(0).Item("SERVERDATE"), "dd-MMM-yyyy")
                servertime = gdataset.Tables("SERVERDATE").Rows(0).Item("SERVERTIME")
            End If
            sqlstring = "SELECT ISNULL(COMPNAME,'') AS COMPNAME FROM POSSETUP "
            gconnection.getDataSet(sqlstring, "CNAME")
            If gdataset.Tables("CNAME").Rows.Count > 0 Then
                gcompname = Trim(gdataset.Tables("CNAME").Rows(0).Item("COMPNAME"))
            End If


        Catch ex As Exception
            MessageBox.Show("Enter a valid datetime :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Function getResource(ByVal fileName As String) As String
        Dim filePath As String
        '  filePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "\resources", fileName)
        filePath = Application.StartupPath & "\resources\" & fileName
        Return filePath
    End Function
    Private Sub license()
        Dim Sql As String
        Dim licscript As String
        Sql = "select * FROM Master..CLUBLICENSE "
        gconnection.getDataSet(Sql, "FileValidate1")
        If gdataset.Tables("FileValidate1").Rows.Count > 0 Then
            Sql = "select isnull(expirydate,'')as expirydate  FROM Master..clubmaster where datafile= '" & Trim(gDatabase) & "'"
            gconnection.getDataSet(Sql, "FileValidate12")
            If gdataset.Tables("FileValidate12").Rows.Count > 0 Then
                If DateValue(gdataset.Tables("FileValidate12").Rows(0).Item("expirydate")) >= DateValue(Now()) Then
                    Dim lg As cocoafob.LicenseGenerator
                    lg = New cocoafob.LicenseGenerator(getResource("privkey.pem"))
                    Dim LicenseData As cocoafob.LicenseData
                    LicenseData = New cocoafob.LicenseData("CLUBMAN2016", gCompanyname, "raushan@clubman.in", Format(gdataset.Tables("FileValidate12").Rows(0).Item("expirydate"), "dd-MMM-yyyy"))

                    Try
                        Assert.IsTrue(lg.verifyLicense(LicenseData, gdataset.Tables("FileValidate1").Rows(0).Item(0).ToString()))
                        ' MsgBox("key Is Valid")
                        Licensebool = True
                    Catch ex As Exception
                        Licensebool = False
                        MsgBox("License Period Expired")
                    End Try
                Else
                    Licensebool = False
                End If

            Else
                Licensebool = False
            End If

        Else
            Licensebool = False
        End If


    End Sub


    Public Sub updation12()
        Dim str As String

        str = "Create Table SalesStatement("
        str = str & " OpBal numeric(18,3) Null,"
        str = str & " RcvBal numeric(18,3) Null,"
        str = str & " ClsBal numeric(18,3) Null,"
        str = str & " ActualExp numeric(18,3) Null,"
        str = str & " TotalSale numeric(18,3) Null,"
        str = str & " CashSale numeric(18,3) Null,"
        str = str & " MaintSale numeric(18,3) Null,"
        str = str & " NetProfit numeric(18,3) Null,"
        str = str & " ProfitPer numeric(18,3) Null"
        str = str & " )"
        gconnection.dataOperation1(6, str, "item")
        str = "Create Table TempSalesStatement("
        str = str & " OpBal numeric(18,3) Null,"
        str = str & " RcvBal numeric(18,3) Null,"
        str = str & " ClsBal numeric(18,3) Null,"
        str = str & " ActualExp numeric(18,3) Null,"
        str = str & " TotalSale numeric(18,3) Null,"
        str = str & " CashSale numeric(18,3) Null,"
        str = str & " MaintSale numeric(18,3) Null,"
        str = str & " NetProfit numeric(18,3) Null,"
        str = str & " ProfitPer numeric(18,3) Null"
        str = str & " )"
        gconnection.dataOperation1(6, str, "item")





        str = "CREATE VIEW [dbo].[DAY_STOCK_SUM1]         "
        str = str & " AS         "
        str = str & " SELECT  Cast(Convert(varchar(11),docdate,111)as Date) as docdate,Itemcode, Itemname, sum(ISNULL(Qty,0)) AS QTY  "
        str = str & " FROM SUBSTORECONSUMPTIONDETAIL WHERE ISNULL(Void,'')<>'Y'  AND Storelocationcode IN ( 'BAR',  'MNS',  "
        str = str & " 'SBS') group by  Cast(Convert(varchar(11),docdate,111)as Date),Itemcode, Itemname"
        gconnection.dataOperation1(6, str, "DAY_STOCK_SUM1")




        str = "Select * from sysobjects where name='TempMonthSTBrsi' and xtype='U'"
        gconnection.getDataSet(str, "TempMonthSTBrsi")
        If gdataset.Tables("TempMonthSTBrsi").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE TempMonthSTBrsi"
            str = str & " ("
            str = str & " ITEMCODE VARCHAR(30) NULL,"
            str = str & " ITEMNAME VARCHAR(100) NULL,"
            str = str & " STORECODE VARCHAR(30) NULL,"
            str = str & " CLSQTY NUMERIC(18,2) NULL,"
            str = str & " CLSRATE NUMERIC(18,2) NULL,"
            str = str & " )"
        End If

        str = "Select * from sysobjects where name='MonthSTBrsi' and xtype='U'"
        gconnection.getDataSet(str, "MonthSTBrsi")
        If gdataset.Tables("MonthSTBrsi").Rows.Count > 0 Then

        Else
            str = " CREATE TABLE MonthSTBrsi"
            str = str & " ("
            str = str & " ITEMCODE VARCHAR(30) NULL,"
            str = str & " ITEMNAME VARCHAR(100) NULL,"
            str = str & " STORECODE VARCHAR(30) NULL,"
            str = str & " CLSQTY NUMERIC(18,2) NULL,"
            str = str & " CLSRATE NUMERIC(18,2) NULL,"
            str = str & " )"
        End If


        str = "Select * from sysobjects where name='GRN_DETAILS_logtab' and xtype='U'"
        gconnection.getDataSet(str, "kot_det")
        If gdataset.Tables("kot_det").Rows.Count > 0 Then

        Else
            str = "   CREATE TABLE [dbo].[GRN_DETAILS_logtab]("
            str = str & " [Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " [Grnno] [varchar](50) NULL,"
            str = str & " [Grndetails] [varchar](50) NULL,"
            str = str & " [Grndate] [datetime] NULL,"
            str = str & " [POno] [varchar](50) NULL,"
            str = str & " [Suppliercode] [varchar](50) NULL,"
            str = str & " [Suppliername] [varchar](50) NULL,"
            str = str & " [Itemcode] [varchar](50) NULL,"
            str = str & " [Itemname] [varchar](50) NULL,"
            str = str & " [UOM] [varchar](50) NULL,"
            str = str & " [Qty] [numeric](18, 3) NULL,"
            str = str & " [Rate] [numeric](18, 2) NULL,"
            str = str & " [Discount] [numeric](18, 2) NULL,"
            str = str & " [Amount] [numeric](18, 2) NULL,"
            str = str & " [Voiditem] [char](2) NULL,"
            str = str & " [Adduser] [varchar](50) NULL,"
            str = str & " [Adddate] [datetime] NULL,"
            str = str & " [UpdateUser] [varchar](50) NULL,"
            str = str & " [Updatetime] [datetime] NULL,"
            str = str & " [category] [varchar](15) NULL,"
            str = str & " [TAXPERCENTAGE] [numeric](12, 3) NULL,"
            str = str & " [storecode] [varchar](50) NULL,"
            str = str & " [storedesc] [varchar](50) NULL,"
            str = str & " [taxper] [numeric](9, 2) NULL,"
            str = str & " [taxamount] [numeric](9, 2) NULL,"
            str = str & " [grntype] [varchar](50) NULL,"
            str = str & " [OTHCHARGE] [numeric](18, 2) NULL,"
            str = str & " [TransConvQty] [decimal](18, 0) NULL,"
            str = str & " [GRNTransQty] [decimal](18, 2) NULL,"
            str = str & " [GRNStockUom] [varchar](25) NULL,"
            str = str & " [GRNTransValue] [numeric](18, 2) NULL,"
            str = str & " [GRNTRANSRATE] [numeric](18, 2) NULL,"
            str = str & " [Profitper] [numeric](18, 2) NULL,"
            str = str & " [Salerate] [numeric](18, 0) NULL,"
            str = str & " [freeqty] [numeric](9, 0) NULL,"
            str = str & " [PROFITAMT] [numeric](18, 2) NULL,"
            str = str & " [ODISCOUNT] [numeric](18, 2) NULL,"
            str = str & " [SALEAMOUNT] [numeric](18, 2) NULL,"
            str = str & " [CASEQTY] [numeric](18, 0) NULL,"
            str = str & " [CASERATE] [numeric](18, 2) NULL,"
            str = str & " [UOMR] [varchar](50) NULL,"
            str = str & " [INDENTNO] [varchar](10) NULL,"
            str = str & " [GrnTransQtyR] [numeric](18, 2) NULL,"
            str = str & " [GRNTransValueR] [numeric](18, 2) NULL,"
            str = str & " [GRNStockUomR] [varchar](50) NULL,"
            str = str & " [DBLAMOUNT] [numeric](18, 0) NULL"
            str = str & " )"
            gconnection.dataOperation1(6, str, "GRN_DETAILS_logtab")
        End If







        str = "Select * from sysobjects where name='kot_det' and xtype='U'"
        gconnection.getDataSet(str, "kot_det")
        If gdataset.Tables("kot_det").Rows.Count > 0 Then

        Else


            str = "  CREATE TABLE [dbo].[kot_det]( "
            str = str & "	[AUTOID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "		[TTYPE] [varchar](50) NULL,"
            str = str & "	[BOOKNO] [varchar](50) NULL,"
            str = str & "	[CHITNO] [numeric](18, 0) NULL,"
            str = str & "	[KOTNO] [varchar](50) NULL,"
            str = str & "	[KOTDETAILS] [varchar](50) NULL,"
            str = str & "	[KOTDATE] [datetime] NOT NULL,"
            str = str & "	[BILLDETAILS] [varchar](50) NULL,"
            str = str & "	[CATEGORY] [varchar](50) NULL,"
            str = str & "	[ITEMCODE] [varchar](10) NULL,"
            str = str & "	[ITEMDESC] [varchar](100) NULL,"
            str = str & "	[GROUPCODE] [varchar](20) NULL,"
            str = str & "	[ITEMTYPE] [varchar](20) NULL,"
            str = str & "	[POSCODE] [varchar](50) NULL,"
            str = str & "	[UOM] [varchar](50) NULL,"
            str = str & "	[QTY] [decimal](18, 2) NULL,"
            str = str & "	[RATE] [decimal](9, 2) NULL,"
            str = str & "	[AMOUNT] [decimal](9, 2) NULL,"
            str = str & "	[UOM2] [varchar](50) NULL,"
            str = str & "	[QTY2] [decimal](9, 2) NULL,"
            str = str & "	[TAXTYPE] [varchar](10) NULL,"
            str = str & "	[TAXPERC] [decimal](9, 2) NULL,"
            str = str & "	[TAXCODE] [varchar](10) NULL,"
            str = str & "	[TAXAMOUNT] [decimal](9, 2) NULL,"
            str = str & "	[TAXACCOUNTCODE] [varchar](50) NULL,"
            str = str & "	[SALESACCOUNTCODE] [varchar](50) NULL,"
            str = str & "	[KOTSTATUS] [varchar](2) NULL,"
            str = str & "	[MCODE] [varchar](50) NULL,"
            str = str & "	[SCODE] [varchar](50) NULL,"
            str = str & "	[TOTAMT] [decimal](9, 2) NULL,"
            str = str & "	[TAXAMT] [decimal](9, 2) NULL,"
            str = str & "	[BILLAMT] [decimal](9, 2) NULL,"
            str = str & "	[COVERS] [decimal](10, 0) NULL,"
            str = str & "	[TABLENO] [varchar](50) NULL,"
            str = str & "	[KOTTYPE] [varchar](10) NULL,"
            str = str & "	[ALCHOLST] [varchar](50) NULL,"
            str = str & "	[CHKID] [decimal](10, 0) NULL,"
            str = str & "	[PAYMENTMODE] [varchar](20) NULL,"
            str = str & "	[DelFlag] [varchar](1) NULL,"
            str = str & "	[AddUserid] [varchar](50) NULL,"
            str = str & "	[Adddatetime] [datetime] NULL,"
            str = str & "	[UpdUserid] [varchar](50) NULL,"
            str = str & "	[Upddatetime] [datetime] NULL,"
            str = str & "	[PACKAMT] [numeric](18, 0) NULL,"
            str = str & "	[DISCAMT] [numeric](18, 0) NULL,"
            str = str & "	[PACKPERCENT] [numeric](18, 2) NULL,"
            str = str & "	[PACKAMOUNT] [numeric](18, 2) NULL,"
            str = str & "	[OPENFACILITYST] [char](2) NULL,"
            str = str & "	[PACKACCOUNTCODE] [varchar](10) NULL,"
            str = str & "	[PROMOTIONALST] [char](10) NULL,"
            str = str & "	[TRANSNO] [numeric](18, 0) NULL,"
            str = str & "	[salesslcode] [varchar](50) NULL,"
            str = str & "	[SER_CHG] [numeric](18, 2) NULL,"
            str = str & "	[promkotno] [varchar](10) NULL,"
            str = str & "	[PDA_PRINT_FLAG] [nchar](1) NOT NULL,"
            str = str & "	[PDA_DELETE_FLAG] [nchar](1) NOT NULL,"
            str = str & "	[IS_PDA] [nchar](1) NULL,"
            str = str & "	[EDPERC] [numeric](10, 2) NULL,"
            str = str & "	[EDTAXCODE] [varchar](50) NULL,"
            str = str & "	[EDTAXAMOUNT] [numeric](10, 2) NULL,"
            str = str & "	[POSKOTDETAILS] [varchar](50) NULL,"
            str = str & "	[HAPPYSTATUS] [varchar](50) NULL,"
            str = str & "	[BADSTATUS] [varchar](50) NULL,"
            str = str & "	[reason] [varchar](50) NULL,"
            str = str & "	[SUBGroupCode] [varchar](20) NULL,"
            str = str & "	[TipsPer] [numeric](10, 2) NULL,"
            str = str & "	[TipsAmt] [numeric](10, 2) NULL,"
            str = str & "	[AdCgsPer] [numeric](10, 2) NULL,"
            str = str & "	[AdCgsAmt] [numeric](10, 2) NULL,"
            str = str & "	[PartyPer] [numeric](10, 2) NULL,"
            str = str & "	[PartyAmt] [numeric](10, 2) NULL,"
            str = str & "	[RoomPer] [numeric](10, 2) NULL,"
            str = str & "		[RoomAmt] [numeric](10, 2) NULL,"
            str = str & "	[MKOTNO] [varchar](20) NULL,"
            str = str & "	[SLNO] [int] NULL"
            str = str & ") ON [PRIMARY]"
            gconnection.dataOperation1(6, str, "kot_det")

        End If


        str = "Select * from sysobjects where name='Bom_det' and xtype='U'"
        gconnection.getDataSet(str, "BOM_DET")
        If gdataset.Tables("BOM_DET").Rows.Count > 0 Then

        Else
            str = "     CREATE TABLE [dbo].[BOM_DET]("
            str = str & " [Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "[Itemcode] [varchar](50) NULL,"
            str = str & "[Itemname] [varchar](50) NULL,"
            str = str & "[ItemUOM] [varchar](50) NULL,"
            str = str & "[ItemEOQ] [numeric](18, 0) NULL,"
            str = str & "[Itemtype] [varchar](50) NULL,"
            str = str & "[Totalqty] [float] NULL,"
            str = str & "[Totalamt] [float] NULL,"
            str = str & "[gitemcode] [varchar](50) NULL,"
            str = str & "[gitemname] [varchar](50) NULL,"
            str = str & "[gUOM] [varchar](50) NULL,"
            str = str & "[gqty] [float] NULL,"
            str = str & "[grate] [float] NULL,"
            str = str & "[gamount] [float] NULL,"
            str = str & "[gdblamt] [float] NULL,"
            str = str & "[ghighratio] [float] NULL,"
            str = str & "[ggroupcode] [varchar](50) NULL,"
            str = str & "[gsubgroupcode] [varchar](50) NULL,"
            str = str & "[Void] [char](10) NULL,"
            str = str & "[Adduser] [varchar](50) NULL,"
            str = str & "[Adddate] [datetime] NULL,"
            str = str & "[DISPITEM] [varchar](1) NULL,"
            str = str & "[UPDATEUSER] [varchar](15) NULL,"
            str = str & " [UPDATETIME] [datetime] NULL"
            str = str & " ) ON [PRIMARY]"
            gconnection.dataOperation1(6, str, "BOM_DET")


        End If

        str = "Select * from sysobjects where name='POSITEMSTORELINK' and xtype='U'"
        gconnection.getDataSet(str, "POSITEMSTORELINK")
        If gdataset.Tables("POSITEMSTORELINK").Rows.Count > 0 Then

        Else

            str = "  CREATE TABLE [dbo].[POSITEMSTORELINK]("
            str = str & " 	[POS] [varchar](50) NULL, "
            str = str & " 	[ITEMCODE] [varchar](50) NULL,"
            str = str & " 	[STORECODE] [varchar](50) NULL"
            str = str & " ) ON [PRIMARY]"
            gconnection.dataOperation1(6, str, "POSITEMSTORELINK")

        End If
        str = "Select * from sysobjects where name='Pos_setup' and xtype='U'"
        gconnection.getDataSet(str, "Pos_setup")
        If gdataset.Tables("Pos_setup").Rows.Count > 0 Then

        Else

            str = "CREATE TABLE [dbo].[pos_setup]("
            str = str & " [currentdate] Datetime "
            str = str & " )"
            gconnection.dataOperation1(6, str, "pos_setup")


        End If


        str = "select * from sysobjects where name='CP_ISSUESUMMARY' and xtype='P'"
        gconnection.getDataSet(str, "CP_ISSUESUMMARY")
        If gdataset.Tables("CP_ISSUESUMMARY").Rows.Count > 0 Then

        Else





            str = " CREATE               PROCEDURE [dbo].[CP_ISSUESUMMARY] (@STORECODE As Varchar(20),@STARTDATE DATETIME,@ENDDATE  DATETIME)"
            str = str & " AS"
            str = str & "             BEGIN"
            str = str & "  DECLARE @OPQTY numeric(18,3),@GRNQTY numeric(18,3),@ISSUEFROMQTY numeric(18,3),@ISSUETOQTY numeric(18,3),@ISSUETOVAL numeric(18,3),"
            str = str & " 	@TRNASFROMQTY numeric(18,3),@TRNASTOQTY numeric(18,3),@CLSQTY numeric(18,3),@ADJQTY numeric(18,3),@SQL AS VARCHAR(2000),"
            str = str & "   @ITEMCODE VARCHAR(20),@ITEMNAME VARCHAR(50),@STOCKUOM VARCHAR(20)"

            str = str & "  SET @SQL= 'DELETE FROM ISSUESUMMARY'"
            str = str & "  EXEC (@SQL)"

            str = str & "  SET @SQL='INSERT INTO ISSUESUMMARY(ITEMCODE,ITEMDESC,UOM)'"
            str = str & "  SET @SQL= @SQL + ' SELECT DISTINCT I.ITEMCODE,I.ITEMNAME,I.STOCKUOM FROM INVENTORYITEMMASTER AS I WHERE STORECODE=(SELECT STORECODE FROM STOREMASTER WHERE STORESTATUS='+CHAR(39)+'M'+CHAR(39)+') ORDER BY I.ITEMCODE'"
            str = str & "  PRINT @SQL"
            str = str & "  EXEC (@SQL)"
            str = str & "  SET @SQL = ''"
            str = str & "  SET @CLSQTY =0"
            str = str & "  SET @SQL='SELECT ITEMCODE,ITEMDESC,UOM  FROM ISSUESUMMARY'"
            str = str & "  SET @SQL='DECLARE CURPROC1 CURSOR FOR ' + @SQL"
            str = str & "  EXEC (@SQL)"
            str = str & "  OPEN CURPROC1"
            str = str & "  FETCH CURPROC1 INTO @ITEMCODE,@ITEMNAME,@STOCKUOM"
            str = str & " 	WHILE @@fetch_Status=0"
            str = str & "  BEGIN "
            ' str = str & "  Print() 'AVINASH'"

            str = str & " PRINT @ITEMCODE"
            str = str & " 	SET  @ISSUEFROMQTY=(SELECT  ISNULL(SUM(QTY),0) AS QTY FROM STOCKISSUEDETAIL  WHERE ITEMCODE= @ITEMCODE   AND STORELOCATIONCODE =  @STORECODE  AND ISNULL(VOID,'')<>'Y' AND DOCDATE  BETWEEN  @STARTDATE AND  @ENDDATE)"
            str = str & " 	PRINT @ISSUEFROMQTY"

            str = str & " 	SET @ISSUETOQTY =(SELECT ISNULL(SUM(QTY),0) AS QTY FROM STOCKISSUEDETAIL  WHERE ITEMCODE= @ITEMCODE   AND OPSTORELOCATIONCODE = @STORECODE  AND ISNULL(VOID,'')<>'Y' AND DOCDATE  BETWEEN  @STARTDATE AND  @ENDDATE)"
            str = str & " 	PRINT @ISSUETOQTY"

            str = str & " 	SET @ISSUETOVAL =(SELECT ISNULL(SUM(AMOUNT),0) AS AMOUNT FROM STOCKISSUEDETAIL  WHERE ITEMCODE= @ITEMCODE   AND OPSTORELOCATIONCODE = @STORECODE  AND ISNULL(VOID,'')<>'Y' AND DOCDATE  BETWEEN  @STARTDATE AND  @ENDDATE)"
            str = str & " 	PRINT @ISSUETOVAL"

            str = str & " 	SET @TRNASFROMQTY=(SELECT ISNULL(SUM(QTY),0) AS QTY FROM STOCKTRANSFERDETAIL  WHERE ITEMCODE=@ITEMCODE AND FROMSTORECODE =@STORECODE  AND ISNULL(VOID,'')<>'Y'  AND DOCDATE  BETWEEN  @STARTDATE AND  @ENDDATE)"
            str = str & " 	PRINT @TRNASFROMQTY"

            str = str & " 	SET @TRNASTOQTY=(SELECT ISNULL(SUM(QTY),0) AS QTY FROM STOCKTRANSFERDETAIL  WHERE ITEMCODE=@ITEMCODE AND TOSTORECODE =@STORECODE  AND ISNULL(VOID,'')<>'Y'  AND DOCDATE  BETWEEN  @STARTDATE AND  @ENDDATE)"
            str = str & " 	PRINT @TRNASTOQTY"
            '	--SET @CLSQTY= @ISSUETOQTY - @TRNASFROMQTY + @TRNASTOQTY

            str = str & " 	SET @CLSQTY= @ISSUETOQTY "
            '-- @TRNASFROMQTY + @TRNASTOQTY"
            str = str & " 	PRINT @CLSQTY"

            str = str & " 	SET @SQL='UPDATE ISSUESUMMARY SET ISSUEQTY  = ' +  CONVERT(VARCHAR,@CLSQTY) + ''"
            str = str & " 		SET @sql= @SQL + ' WHERE ITEMCODE = ' + Char(39) + @ITEMCODE  + Char(39) + ''"
            str = str & " 		PRINT @SQL"
            str = str & " 		EXEC (@SQL)"

            str = str & " 		SET @SQL='UPDATE ISSUESUMMARY SET ISSUEAMOUNT  = ' +  CONVERT(VARCHAR,@ISSUETOVAL) + ''"
            str = str & " 		SET @sql= @SQL + ' WHERE ITEMCODE = ' + Char(39) + @ITEMCODE  + Char(39) + ''"
            str = str & " 		PRINT @SQL"
            str = str & " 		EXEC (@SQL)"

            str = str & " 		IF @ISSUETOVAL>0 AND @CLSQTY>0 "
            str = str & " BEGIN "
            str = str & " 	SET @SQL='UPDATE ISSUESUMMARY SET ISSUERATE  = ' +  CONVERT(VARCHAR,@ISSUETOVAL/@CLSQTY) + ''"
            str = str & " 	SET @sql= @SQL + ' WHERE ITEMCODE = ' + Char(39) + @ITEMCODE  + Char(39) + ''"
            str = str & " 		PRINT @SQL"
            str = str & " 	EXEC (@SQL)"
            str = str & "      End"

            str = str & " 	FETCH CURPROC1 INTO @ITEMCODE,@ITEMNAME,@STOCKUOM"
            str = str & "            End"

            str = str & "         Close CURPROC1 "
            str = str & "         DEALLOCATE CURPROC1"
            str = str & "         End"

            gconnection.dataOperation1(6, str, "INV_WEIGHTED_VIEW1")

        End If





        str = "select * from sysobjects where name='INV_WEIGHTED_VIEW1' and xtype='V'"
        gconnection.getDataSet(str, "INV_WEIGHTED_VIEW1")
        If gdataset.Tables("INV_WEIGHTED_VIEW1").Rows.Count > 0 Then

        Else


            str = " CREATE    VIEW  INV_WEIGHTED_VIEW1    "
            str = str & "  AS      "

            str = str & "  SELECT GROUPCODE,'31-MAR-2013' AS GRNDATE,ITEMCODE,OPSTOCK AS QTY,OPVALUE AS VALUE,ROUND((ISNULL(OPVALUE,0)/ISNULL(OPSTOCK,0)),2) AS RATE,  "
            str = str & " 0 AS CLSSTOCK,storecode  FROM INVENTORYITEMMASTER   "
            str = str & "       WHERE ISNULL(OPSTOCK, 0) <> 0 And ISNULL(OPVALUE, 0) <> 0"

            str = str & "     UNION ALL"

            str = str & " SELECT B.GROUPCODE,A.GRNDATE,A.ITEMCODE,SUM(A.QTY) AS QTY,     "
            str = str & " ISNULL(SUM(isnull(A.AMOUNT,0)),0)  AS AMOUNT,RATE,0 AS CLSSTOCK, a.storecode      "
            str = str & " FROM GRN_DETAILS A,INVENTORYITEMMASTER B WHERE A.ITEMCODE =B.ITEMCODE AND A.STORECODE=B.STORECODE AND   "
            str = str & " ISNULL(A.VOIDITEM,'')<>'Y' GROUP BY B.GROUPCODE,A.GRNDATE,A.ITEMCODE,B.TAXREBATE, a.storecode, RATE  "
            gconnection.dataOperation1(6, str, "INV_WEIGHTED_VIEW1")

        End If


        str = "select * from sysobjects where name='INV_WEIGHTED_TAB1' and xtype='U'"
        gconnection.getDataSet(str, "INV_WEIGHTED_TAB1")
        If gdataset.Tables("INV_WEIGHTED_TAB1").Rows.Count > 0 Then

        Else


            str = "CREATE TABLE [dbo].[INV_WEIGHTED_TAB1]("
            str = str & " [GROUPCODE] [varchar](50) NULL,"
            str = str & " [GRNDATE] [datetime] NULL,"
            str = str & " [ITEMCODE] [varchar](50) NULL,"
            str = str & " 	[QTY] [float] NULL,"
            str = str & " 	[VALUE] [float] NULL,"
            str = str & " 	[RATE] [float] NULL,"
            str = str & " 	[CLSSTOCK] [int] NOT NULL,"
            str = str & " 	[storecode] [varchar](50) NULL"
            str = str & " )"
            gconnection.dataOperation1(6, str, "INV_WEIGHTED_TAB1")

        End If



        str = "select * from sysobjects where name='INV_WEIGHTED_TAB2' and xtype='U'"
        gconnection.getDataSet(str, "INV_WEIGHTED_TAB2")
        If gdataset.Tables("INV_WEIGHTED_TAB2").Rows.Count > 0 Then


        Else



            str = "    CREATE TABLE [dbo].[INV_WEIGHTED_TAB2]("
            str = str & " [DOCDETAILS] [varchar](50) NULL,"
            str = str & " [ITEMCODE] [varchar](50) NULL,"
            str = str & " [ITEMNAME] [varchar](75) NULL,"
            str = str & " [DOCDATE] [datetime] NULL,"
            str = str & " [QTY] [float] NULL,"
            str = str & "[RATE] [float] NULL,"
            str = str & " [AMOUNT] [float] NULL,"
            str = str & " [CLSSTOCK] [numeric](18, 3) NULL,"
            str = str & " [TYPE] [varchar](50) NULL,"
            str = str & " [storecode] [varchar](50) NULL,"
            str = str & " [CATEGORY] [varchar](30) NULL,"
            str = str & " [LASTSTOCK] [numeric](18, 3) NULL,"
            str = str & " [LASTRATE] [numeric](18, 2) NULL,"
            str = str & " [PRIORITY] [int] NOT NULL,"
            str = str & " [ROWID] [int] IDENTITY(1,1) NOT NULL,"
            str = str & " [WEIGHTED_RATE] [numeric](18, 2) NULL"
            str = str & " )"
            gconnection.dataOperation1(6, str, "INV_WEIGHTED_TAB2")

        End If

        str = "select * from sysobjects where name='INV_WEIGHTED_TAB3' and xtype='U'"
        gconnection.getDataSet(str, "INV_WEIGHTED_TAB3")
        If gdataset.Tables("INV_WEIGHTED_TAb3").Rows.Count > 0 Then

        Else



            str = " CREATE TABLE INV_WEIGHTED_TAB3"
            str = str & " 	("
            str = str & " 	ROW INTEGER "
            str = str & " 	)"
            gconnection.dataOperation1(6, str, "INV_WEIGHTED_TAB3")

        End If




        str = "select * from sysobjects where name='INV_WEIGHTED_VIEW2' and xtype='V'"
        gconnection.getDataSet(str, "INV_WEIGHTED_VIEW2")
        If gdataset.Tables("INV_WEIGHTED_VIEW2").Rows.Count > 0 Then
            str = "alter VIEW INV_WEIGHTED_VIEW2    "
            str = str & " AS    "
            str = str & "  SELECT '' AS DOCDETAILS,ITEMCODE, ITEMNAME, '1-apr-2014' AS DOCDATE, OPSTOCK AS QTY,ROUND((ISNULL(opvalue,0)/ISNULL(OPSTOCK,0)),2) AS RATE,   "
            str = str & " OPVALUE AS AMOUNT,0.000 AS CLSSTOCK, 'OPENING' AS TYPE, storecode,CATEGORY ,(SELECT DISTINCT isnull(RATEFLAG,'') FROM INVENTORYCATEGORYMASTER WHERE INVENTORYITEMMASTER.category=INVENTORYCATEGORYMASTER.CATEGORYCODE) AS RateFlag, CAST(0.000 AS NUMERIC(18,3)) AS LASTSTOCK,  "
            str = str & " CAST(0.00 AS NUMERIC(18,2)) AS LASTRATE, 1 AS PRIORITY  FROM INVENTORYITEMMASTER WHERE ISNULL(FREEZE,'')<>'Y' AND   "
            str = str & " ISNULL(OPSTOCK,0)<>0 OR ISNULL(OPVALUE,0)<>0  AND STORECODE='MNS'    "
            str = str & "         UNION ALL"
            str = str & " SELECT '' AS DOCDETAILS,ITEMCODE, ITEMNAME, '1-apr-2014' AS DOCDATE, OPSTOCK AS QTY,0 AS RATE, 0 AS AMOUNT,CAST(0.000 AS NUMERIC(18,3)) AS   "
            str = str & " CLSSTOCK, 'OPENING' AS TYPE, storecode,CATEGORY ,(SELECT DISTINCT isnull(RATEFLAG,'') FROM INVENTORYCATEGORYMASTER WHERE INVENTORYITEMMASTER.category=INVENTORYCATEGORYMASTER.CATEGORYCODE) AS RateFlag, CAST(0.000 AS NUMERIC(18,3)) AS LASTSTOCK, CAST(0.00 AS NUMERIC(18,2)) AS  "
            str = str & " LASTRATE, 1 AS PRIORITY FROM INVENTORYITEMMASTER WHERE ISNULL(FREEZE,'')<>'Y' AND ISNULL(OPSTOCK,0)=0 AND ISNULL(OPVALUE,0)=0   "
            str = str & " AND STORECODE='MNS'    "
            str = str & "          UNION ALL"
            str = str & " SELECT GRNDETAILS AS DOCDETAILS,ITEMCODE, ITEMNAME, Grndate AS DOCDATE, QTY, ((isnull(Amount,0)+isnull(taxamount,0)-isnull(Discount,0))/ISNULL(Qty,1)) as Rate, AMOUNT,CAST(0.000 AS NUMERIC(18,3)) AS CLSSTOCK, grntype AS TYPE,   "
            str = str & " storecode, CATEGORY,(SELECT DISTINCT isnull(RATEFLAG,'') FROM INVENTORYCATEGORYMASTER WHERE GRN_DETAILS.category=INVENTORYCATEGORYMASTER.CATEGORYCODE) AS RateFlag, CAST(0.000 AS NUMERIC(18,3)) AS LASTSTOCK, CAST(0.00 AS NUMERIC(18,2)) AS LASTRATE, 2 AS PRIORITY FROM   "
            str = str & " GRN_DETAILS WHERE ISNULL(Voiditem,'')<>'Y'  and Qty <> 0 and grntype= 'GRN' "
            str = str & "          UNION ALL"
            str = str & " SELECT GRNDETAILS AS DOCDETAILS,ITEMCODE, ITEMNAME, Grndate AS DOCDATE, QTY*-1, ((isnull(Amount,0)+isnull(taxamount,0)-isnull(Discount,0))/ISNULL(Qty,1)) as Rate, AMOUNT,CAST(0.000 AS NUMERIC(18,3)) AS CLSSTOCK, grntype AS TYPE,   "
            str = str & " storecode, CATEGORY,(SELECT DISTINCT isnull(RATEFLAG,'') FROM INVENTORYCATEGORYMASTER WHERE GRN_DETAILS.category=INVENTORYCATEGORYMASTER.CATEGORYCODE) AS RateFlag, CAST(0.000 AS NUMERIC(18,3)) AS LASTSTOCK, CAST(0.00 AS NUMERIC(18,2)) AS LASTRATE, 2 AS PRIORITY FROM   "
            str = str & " GRN_DETAILS WHERE ISNULL(Voiditem,'')<>'Y'  and Qty <> 0 and grntype<> 'GRN' "
            str = str & "        UNION ALL"
            str = str & " SELECT DOCDETAILS,S.ITEMCODE, S.ITEMNAME, DOCDATE, QTY * -1, RATE, AMOUNT, CAST(0.000 AS NUMERIC(18,3)) AS CLSSTOCK, 'ISSUE' AS TYPE,   "
            str = str & " Storelocationcode AS STORECODE, I.CATEGORY,(SELECT DISTINCT isnull(RATEFLAG,'') FROM INVENTORYCATEGORYMASTER WHERE I.category=INVENTORYCATEGORYMASTER.CATEGORYCODE) AS RateFlag, CAST(0.000 AS NUMERIC(18,3)) AS LASTSTOCK,CAST(0.00 AS NUMERIC(18,2)) AS LASTRATE,   "
            str = str & "  3 AS PRIORITY  FROM STOCKISSUEDETAIL S, INVENTORYITEMMASTER I  WHERE ISNULL(Void,'') <>'Y' AND I.itemcode=S.ITEMCODE AND   "
            str = str & "          I.STORECODE = S.Storelocationcode"
            str = str & "          UNION ALL"
            str = str & "   SELECT DOCDETAILS,S.ITEMCODE, S.ITEMNAME, DOCDATE, ADJUSTEDSTOCK AS QTY , Rate, AMOUNT, CAST(0.000 AS NUMERIC(18,3)) AS CLSSTOCK,  'Adjustment' as type,storecode, CATEGORY,(SELECT DISTINCT isnull(RATEFLAG,'') FROM INVENTORYCATEGORYMASTER WHERE I.category=INVENTORYCATEGORYMASTER.CATEGORYCODE) AS RateFlag, CAST(0.000 AS NUMERIC(18,3)) AS LASTSTOCK, CAST(0.00 AS NUMERIC(18,2)) AS LASTRATE , 3 AS PRIORITY  FROM STOCKADJUSTDETAILS  S, INVENTORYITEMMASTER I    "
            str = str & "  WHERE ISNULL(Void,'') <>'Y' AND ADJUSTEDSTOCK < 0  AND I.itemcode=S.ITEMCODE AND I.STORECODE=S.Storelocationcode     "
            str = str & "   UNION ALL"
            str = str & "   SELECT DOCDETAILS,i.ITEMCODE,s.ITEMNAME, DOCDATE, Qty *-1 , Rate, AMOUNT, CAST(0.000 AS NUMERIC(18,3)) AS CLSSTOCK, 'Transfer' AS TYPE, Fromstorecode AS STORECODE,I.CATEGORY,(SELECT DISTINCT isnull(RATEFLAG,'') FROM INVENTORYCATEGORYMASTER WHERE I.category=INVENTORYCATEGORYMASTER.CATEGORYCODE) AS RateFlag, CAST(0.000 AS NUMERIC(18,3)) AS LASTSTOCK,CAST(0.00 AS NUMERIC(18,2)) AS LASTRATE,     3 AS PRIORITY FROM stocktransferdetail s,INVENTORYITEMMASTER I WHERE ISNULL(Void,'') <>'Y' AND Fromstorecode='MNS' AND I.itemcode=S.ITEMCODE AND I.STORECODE=S.Fromstorecode"
            str = str & "    UNION ALL"
            str = str & " SELECT DOCDETAILS,i.ITEMCODE,s.ITEMNAME, DOCDATE, Qty * 1 , Rate, AMOUNT, CAST(0.000 AS NUMERIC(18,3)) AS CLSSTOCK, 'Transfer' AS TYPE, tostorecode AS STORECODE,I.CATEGORY,(SELECT  DISTINCT isnull(RATEFLAG,'') FROM INVENTORYCATEGORYMASTER WHERE I.category=INVENTORYCATEGORYMASTER.CATEGORYCODE) AS RateFlag, CAST(0.000 AS NUMERIC(18,3)) AS LASTSTOCK,CAST(0.00 AS NUMERIC(18,2)) AS LASTRATE,     3 AS PRIORITY FROM stocktransferdetail s,INVENTORYITEMMASTER I WHERE ISNULL(Void,'') <>'Y' AND tostorecode='MNS' AND I.itemcode=S.ITEMCODE AND I.STORECODE=S.Tostorecode"

            gconnection.dataOperation1(6, str, "INV_WEIGHTED_VIEW2")


        Else


            str = "CREATE VIEW INV_WEIGHTED_VIEW2    "
            str = str & " AS    "
            str = str & "  SELECT '' AS DOCDETAILS,ITEMCODE, ITEMNAME, '1-apr-2014' AS DOCDATE, OPSTOCK AS QTY,ROUND((ISNULL(opvalue,0)/ISNULL(OPSTOCK,0)),2) AS RATE,   "
            str = str & " OPVALUE AS AMOUNT,0.000 AS CLSSTOCK, 'OPENING' AS TYPE, storecode,CATEGORY , CAST(0.000 AS NUMERIC(18,3)) AS LASTSTOCK,  "
            str = str & " CAST(0.00 AS NUMERIC(18,2)) AS LASTRATE, 1 AS PRIORITY  FROM INVENTORYITEMMASTER WHERE ISNULL(FREEZE,'')<>'Y' AND   "
            str = str & " ISNULL(OPSTOCK,0)<>0 OR ISNULL(OPVALUE,0)<>0  AND STORECODE='MNS'    "
            str = str & "         UNION ALL"
            str = str & " SELECT '' AS DOCDETAILS,ITEMCODE, ITEMNAME, '1-apr-2014' AS DOCDATE, OPSTOCK AS QTY,0 AS RATE, 0 AS AMOUNT,CAST(0.000 AS NUMERIC(18,3)) AS   "
            str = str & " CLSSTOCK, 'OPENING' AS TYPE, storecode,CATEGORY , CAST(0.000 AS NUMERIC(18,3)) AS LASTSTOCK, CAST(0.00 AS NUMERIC(18,2)) AS  "
            str = str & " LASTRATE, 1 AS PRIORITY FROM INVENTORYITEMMASTER WHERE ISNULL(FREEZE,'')<>'Y' AND ISNULL(OPSTOCK,0)=0 AND ISNULL(OPVALUE,0)=0   "
            str = str & " AND STORECODE='MNS'    "
            str = str & "          UNION ALL"
            str = str & " SELECT GRNDETAILS AS DOCDETAILS,ITEMCODE, ITEMNAME, Grndate AS DOCDATE, QTY, ((isnull(Amount,0)+isnull(taxamount,0)-isnull(Discount,0))/ISNULL(Qty,1)) as Rate, AMOUNT,CAST(0.000 AS NUMERIC(18,3)) AS CLSSTOCK, grntype AS TYPE,   "
            str = str & " storecode, CATEGORY, CAST(0.000 AS NUMERIC(18,3)) AS LASTSTOCK, CAST(0.00 AS NUMERIC(18,2)) AS LASTRATE, 2 AS PRIORITY FROM   "
            str = str & " GRN_DETAILS WHERE ISNULL(Voiditem,'')<>'Y'  and Qty <> 0  "
            str = str & "        UNION ALL"
            str = str & " SELECT DOCDETAILS,S.ITEMCODE, S.ITEMNAME, DOCDATE, QTY * -1, RATE, AMOUNT, CAST(0.000 AS NUMERIC(18,3)) AS CLSSTOCK, 'ISSUE' AS TYPE,   "
            str = str & " Storelocationcode AS STORECODE, I.CATEGORY, CAST(0.000 AS NUMERIC(18,3)) AS LASTSTOCK,CAST(0.00 AS NUMERIC(18,2)) AS LASTRATE,   "
            str = str & "  3 AS PRIORITY  FROM STOCKISSUEDETAIL S, INVENTORYITEMMASTER I  WHERE ISNULL(Void,'') <>'Y' AND I.itemcode=S.ITEMCODE AND   "
            str = str & "          I.STORECODE = S.Storelocationcode"
            str = str & "          UNION ALL"
            str = str & "   SELECT DOCDETAILS,S.ITEMCODE, S.ITEMNAME, DOCDATE, ADJUSTEDSTOCK AS QTY , Rate, AMOUNT, CAST(0.000 AS NUMERIC(18,3)) AS CLSSTOCK,  'Adjustment' as type,storecode, CATEGORY, CAST(0.000 AS NUMERIC(18,3)) AS LASTSTOCK, CAST(0.00 AS NUMERIC(18,2)) AS LASTRATE , 3 AS PRIORITY  FROM STOCKADJUSTDETAILS  S, INVENTORYITEMMASTER I    "
            str = str & "  WHERE ISNULL(Void,'') <>'Y' AND ADJUSTEDSTOCK < 0  AND I.itemcode=S.ITEMCODE AND I.STORECODE=S.Storelocationcode     "
            str = str & "   UNION ALL"
            str = str & "   SELECT DOCDETAILS,i.ITEMCODE,s.ITEMNAME, DOCDATE, Qty *-1 , Rate, AMOUNT, CAST(0.000 AS NUMERIC(18,3)) AS CLSSTOCK, 'Transfer' AS TYPE, Fromstorecode AS STORECODE,I.CATEGORY, CAST(0.000 AS NUMERIC(18,3)) AS LASTSTOCK,CAST(0.00 AS NUMERIC(18,2)) AS LASTRATE,     3 AS PRIORITY FROM stocktransferdetail s,INVENTORYITEMMASTER I WHERE ISNULL(Void,'') <>'Y' AND Fromstorecode='MNS' AND I.itemcode=S.ITEMCODE AND I.STORECODE=S.Fromstorecode"
            str = str & "    UNION ALL"
            str = str & " SELECT DOCDETAILS,i.ITEMCODE,s.ITEMNAME, DOCDATE, Qty * 1 , Rate, AMOUNT, CAST(0.000 AS NUMERIC(18,3)) AS CLSSTOCK, 'Transfer' AS TYPE, tostorecode AS STORECODE,I.CATEGORY, CAST(0.000 AS NUMERIC(18,3)) AS LASTSTOCK,CAST(0.00 AS NUMERIC(18,2)) AS LASTRATE,     3 AS PRIORITY FROM stocktransferdetail s,INVENTORYITEMMASTER I WHERE ISNULL(Void,'') <>'Y' AND Fromstorecode='MNS' AND I.itemcode=S.ITEMCODE AND I.STORECODE=S.Tostorecode"

            gconnection.dataOperation1(6, str, "INV_WEIGHTED_VIEW2")

        End If


        str = "select * from sysobjects where name='INV_LINKSETUP' and xtype='U'"
        gconnection.getDataSet(str, "INV_LINKSETUP")
        If gdataset.Tables("INV_LINKSETUP").Rows.Count > 0 Then

        Else

            str = " CREATE TABLE [dbo].[INV_LINKSETUP]("
            str = str & "	  [POFLAG] [varchar](1) NULL,"
            str = str & "	[ACCPOSTFLAG] [varchar](1) NULL,"
            str = str & "	[INDENTISSFLAG] [varchar](1) NULL,"
            str = str & "	[DISCaccountcode] [varchar](50) NULL,"
            str = str & "	[OTHACCOUNTCODE] [varchar](50) NULL,"
            str = str & "	[grntype] [varchar](50) NULL,"
            str = str & "	[ADDUSER] [varchar](50) NULL,"
            str = str & "	 [ADDDATETIME] [smalldatetime] NULL"
            str = str & " )"
            gconnection.dataOperation1(6, str, "INV_LINKSETUP")

        End If

        str = "select * from sysobjects where name='ACCOUNTSGLACCOUNTMASTER' and xtype='U'"
        gconnection.getDataSet(str, "ACCOUNTSGLACCOUNTMASTER")
        If gdataset.Tables("ACCOUNTSGLACCOUNTMASTER").Rows.Count > 0 Then

        Else

            str = "CREATE TABLE [dbo].[ACCOUNTSGLACCOUNTMASTER]("
            str = str & "	[accode] [varchar](10) NOT NULL,"
            str = str & "	[acdesc] [varchar](100) NULL,"
            str = str & "	[alias] [varchar](30) NULL,"
            str = str & "	[subledgerflag] [varchar](1) NULL,"
            str = str & "	[groupname] [varchar](100) NULL,"
            str = str & "	[subgroup] [varchar](30) NULL,"
            str = str & "	[actype] [varchar](30) NULL,"
            str = str & "	[budgetflag] [varchar](1) NULL,"
            str = str & "	[bank] [varchar](30) NULL,"
            str = str & "	[bankaddress] [varchar](30) NULL,"
            str = str & "	[opdebits] [numeric](18, 2) NULL,"
            str = str & "	[opcredits] [numeric](18, 2) NULL,"
            str = str & "	[cldebits] [numeric](18, 2) NULL,"
            str = str & "	[clcredits] [numeric](18, 2) NULL,"
            str = str & "		[aprdebits] [numeric](18, 2) NULL,"
            str = str & "	[aprcredits] [numeric](18, 2) NULL,"
            str = str & "	[maydebits] [numeric](18, 2) NULL,"
            str = str & "	[maycredits] [numeric](18, 2) NULL,"
            str = str & "	[jundebits] [numeric](18, 2) NULL,"
            str = str & "	[juncredits] [numeric](18, 2) NULL,"
            str = str & "	[juldebits] [numeric](18, 2) NULL,"
            str = str & "	[julcredits] [numeric](18, 2) NULL,"
            str = str & "	[augdebits] [numeric](18, 2) NULL,"
            str = str & "	[augcredits] [numeric](18, 2) NULL,"
            str = str & "	[sepdebits] [numeric](18, 2) NULL,"
            str = str & "	[sepcredits] [numeric](18, 2) NULL,"
            str = str & "	[octdebits] [numeric](18, 2) NULL,"
            str = str & "	[octcredits] [numeric](18, 2) NULL,"
            str = str & "	[novdebits] [numeric](18, 2) NULL,"
            str = str & "	[novcredits] [numeric](18, 2) NULL,"
            str = str & "	[decdebits] [numeric](18, 2) NULL,"
            str = str & "	[deccredits] [numeric](18, 2) NULL,"
            str = str & "	[jandebits] [numeric](18, 2) NULL,"
            str = str & "	[jancredits] [numeric](18, 2) NULL,"
            str = str & "	[febdebits] [numeric](18, 2) NULL,"
            str = str & "	[febcredits] [numeric](18, 2) NULL,"
            str = str & "	[mardebits] [numeric](18, 2) NULL,"
            str = str & "	[marcredits] [numeric](18, 2) NULL,"
            str = str & "	[actuallastyear] [numeric](18, 2) NULL,"
            str = str & "	[projectedlastyear] [numeric](18, 2) NULL,"
            str = str & "	[actualcurrentyear] [numeric](18, 2) NULL,"
            str = str & "	[projectedcurrentyear] [numeric](18, 2) NULL,"
            str = str & "	[actualnextyear] [numeric](18, 0) NULL,"
            str = str & "	[projectednextyear] [numeric](18, 0) NULL,"
            str = str & "	[adduserid] [varchar](30) NULL,"
            str = str & "	[adddatetime] [datetime] NULL,"
            str = str & "	[updateuserid] [varchar](30) NULL,"
            str = str & "	[updatedatetime] [datetime] NULL,"
            str = str & "	[freezeflag] [varchar](1) NULL,"
            str = str & "	[freezeuserid] [varchar](30) NULL,"
            str = str & "	[freezedatetime] [datetime] NULL,"
            str = str & "	[BSPL] [varchar](1) NULL,"
            str = str & "	[FREZEEFLAG] [varchar](1) NULL,"
            str = str & "		[CATEGORY] [varchar](10) NULL,"
            str = str & "	[DEPPER] [numeric](9, 2) NULL,"
            str = str & "	[SUBSUBGROUP] [varchar](50) NULL,"
            str = str & "	[SLTYPE] [varchar](50) NULL,"
            str = str & "	[COST] [varchar](10) NULL,"
            str = str & "	[COSTMASTER] [varchar](10) NULL"
            str = str & "	 )"
            gconnection.dataOperation1(6, str, "ACCOUNTSGLACCOUNTMASTER")

        End If

        str = "select * from sysobjects where name='AccountsEsiMaster' and xtype='U'"
        gconnection.getDataSet(str, "AccountsEsiMaster")
        If gdataset.Tables("AccountsEsiMaster").Rows.Count > 0 Then

        Else



            str = " CREATE TABLE [dbo].[AccountsEsiMaster]("
            str = str & " [esicode] [varchar](10) NOT NULL,"
            str = str & " [sectiontype] [varchar](50) NULL,"
            str = str & " 	[sectionpercentage] [numeric](18, 2) NULL,"
            str = str & " [glaccountin] [varchar](10) NULL,"
            str = str & " [glaccountdesc] [varchar](50) NULL,"
            str = str & " [SUBLEDGERCODE] [varchar](10) NULL,"
            str = str & " [SUBLEDGERDESC] [varchar](50) NULL,"
            str = str & " [COSTCENTERCODE] [varchar](10) NULL,"
            str = str & " [COSTCENTERDESC] [varchar](50) NULL,"
            str = str & " [adduserid] [varchar](50) NULL,"
            str = str & " [adddatetime] [datetime] NULL,"
            str = str & "[updateuserid] [varchar](50) NULL,"
            str = str & " [updatedatetime] [datetime] NULL,"
            str = str & " [freezeflag] [varchar](1) NULL,"
            str = str & " [freezeuserid] [varchar](50) NULL,"
            str = str & " [freezedatetime] [datetime] NULL"
            str = str & " )"
            gconnection.dataOperation1(6, str, "AccountsEsiMaster")

        End If


        str = "select * from sysobjects where name='AccountsPurchaseTaxMaster' and xtype='U'"
        gconnection.getDataSet(str, "AccountsPurchaseTaxMaster")
        If gdataset.Tables("AccountsPurchaseTaxMaster").Rows.Count > 0 Then

        Else



            str = " CREATE TABLE [dbo].[AccountsPurchaseTaxMaster]("
            str = str & " [purchasecode] [varchar](10) NOT NULL,"
            str = str & "  [sectiontype] [varchar](50) NULL,"
            str = str & " [percentage] [numeric](18, 2) NULL,"
            str = str & "  [glaccountin] [varchar](10) NULL,"
            str = str & "  [glaccountdesc] [varchar](50) NULL,"
            str = str & "  [SUBLEDGERCODE] [varchar](10) NULL,"
            str = str & "  [SUBLEDGERDESC] [varchar](50) NULL,"
            str = str & "  [COSTCENTERCODE] [varchar](10) NULL,"
            str = str & "  [COSTCENTERDESC] [varchar](50) NULL,"
            str = str & " [adduserid] [varchar](50) NULL,"
            str = str & " [adddatetime] [datetime] NULL,"
            str = str & " [updateuserid]  [varchar](50) NULL,"
            str = str & "  [updatedatetim e] [datetime] NULL,"
            str = str & " [freezeflag] [varchar](1) NULL,"
            str = str & " [freezeuserid]  [varchar](50) NULL,"
            str = str & "  [freezedatetime] [datetime] NULL"
            str = str & "  ) "
            gconnection.dataOperation1(6, str, "AccountsPurchaseTaxMaster")

        End If



        str = "select * from sysobjects where name='AccountsPfMaster' and xtype='U'"
        gconnection.getDataSet(str, "AccountsPfMaster")
        If gdataset.Tables("AccountsPfMaster").Rows.Count > 0 Then

        Else



            str = " CREATE TABLE [dbo].[AccountsPfMaster]( "
            str = str & " [pfcode] [varchar](10) NOT NULL, "
            str = str & " [sectiontype] [varchar](50) NULL,"
            str = str & " [pfpercentage] [numeric](18, 2) NULL,"
            str = str & " [glaccountin] [varchar](10) NULL,"
            str = str & " [glaccountdesc] [varchar](50) NULL,"
            str = str & " [SUBLEDGERCODE] [varchar](10) NULL,"
            str = str & " [SUBLEDGERDESC] [varchar](50) NULL,"
            str = str & " [COSTCENTERCODE] [varchar](10) NULL,"
            str = str & " [COSTCENTERDESC] [varchar](50) NULL,"
            str = str & " [adduserid] [varchar](50) NULL,"
            str = str & " [adddatetime] [datetime] NULL,"
            str = str & " [updateuserid] [varchar](50) NULL,"
            str = str & " [updatedatetime] [datetime] NULL,"
            str = str & " [freezeflag] [varchar](1) NULL,"
            str = str & " [freezeuserid] [varchar](50) NULL,"
            str = str & " [freezedatetime] [datetime] NULL"
            str = str & " )"
            gconnection.dataOperation1(6, str, "AccountsPfMaster")

        End If


        str = "select * from sysobjects where name='ACCOUNTSGLACCOUNTMASTER' and xtype='U'"
        gconnection.getDataSet(str, "ACCOUNTSGLACCOUNTMASTER")
        If gdataset.Tables("ACCOUNTSGLACCOUNTMASTER").Rows.Count > 0 Then

        Else


            str = "CREATE TABLE [dbo].[ACCOUNTSGLACCOUNTMASTER]("
            str = str & "[accode] [varchar](10) NOT NULL,"
            str = str & " [acdesc] [varchar](100) NULL,"
            str = str & " [alias] [varchar](30) NULL,"
            str = str & " [subledgerflag] [varchar](1) NULL,"
            str = str & " [groupname] [varchar](100) NULL,"
            str = str & " [subgroup] [varchar](30) NULL,"
            str = str & " [actype] [varchar](30) NULL,"
            str = str & " [budgetflag] [varchar](1) NULL,"
            str = str & " [bank] [varchar](30) NULL,"
            str = str & " [bankaddress] [varchar](30) NULL,"
            str = str & " [opdebits] [numeric](18, 2) NULL,"
            str = str & " [opcredits] [numeric](18, 2) NULL,"
            str = str & " [cldebits] [numeric](18, 2) NULL,"
            str = str & " [clcredits] [numeric](18, 2) NULL,"
            str = str & " [aprdebits] [numeric](18, 2) NULL,"
            str = str & " [aprcredits] [numeric](18, 2) NULL,"
            str = str & " [maydebits] [numeric](18, 2) NULL,"
            str = str & " [maycredits] [numeric](18, 2) NULL,"
            str = str & " [jundebits] [numeric](18, 2) NULL,"
            str = str & " [juncredits] [numeric](18, 2) NULL,"
            str = str & " [juldebits] [numeric](18, 2) NULL,"
            str = str & " [julcredits] [numeric](18, 2) NULL,"
            str = str & " [augdebits] [numeric](18, 2) NULL,"
            str = str & " [augcredits] [numeric](18, 2) NULL,"
            str = str & " [sepdebits] [numeric](18, 2) NULL,"
            str = str & " [sepcredits] [numeric](18, 2) NULL,"
            str = str & " [octdebits] [numeric](18, 2) NULL,"
            str = str & " [octcredits] [numeric](18, 2) NULL,"
            str = str & " [novdebits] [numeric](18, 2) NULL,"
            str = str & " [novcredits] [numeric](18, 2) NULL,"
            str = str & " [decdebits] [numeric](18, 2) NULL,"
            str = str & " [deccredits] [numeric](18, 2) NULL,"
            str = str & " [jandebits] [numeric](18, 2) NULL,"
            str = str & " [jancredits] [numeric](18, 2) NULL,"
            str = str & " [febdebits] [numeric](18, 2) NULL,"
            str = str & " [febcredits] [numeric](18, 2) NULL,"
            str = str & " [mardebits] [numeric](18, 2) NULL,"
            str = str & " [marcredits] [numeric](18, 2) NULL,"
            str = str & " [actuallastyear] [numeric](18, 2) NULL,"
            str = str & " [projectedlastyear] [numeric](18, 2) NULL,"
            str = str & " [actualcurrentyear] [numeric](18, 2) NULL,"
            str = str & " [projectedcurrentyear] [numeric](18, 2) NULL,"
            str = str & " [actualnextyear] [numeric](18, 0) NULL,"
            str = str & " [projectednextyear] [numeric](18, 0) NULL,"
            str = str & " [adduserid] [varchar](30) NULL,"
            str = str & " [adddatetime] [datetime] NULL,"
            str = str & " [updateuserid] [varchar](30) NULL,"
            str = str & " [updatedatetime] [datetime] NULL,"
            str = str & " [freezeflag] [varchar](1) NULL,"
            str = str & " [freezeuserid] [varchar](30) NULL,"
            str = str & " [freezedatetime] [datetime] NULL,"
            str = str & "[BSPL] [varchar](1) NULL,"
            str = str & " [FREZEEFLAG] [varchar](1) NULL,"
            str = str & " [CATEGORY] [varchar](10) NULL,"
            str = str & " [DEPPER] [numeric](9, 2) NULL,"
            str = str & " [SUBSUBGROUP] [varchar](50) NULL,"
            str = str & " [SLTYPE] [varchar](50) NULL,"
            str = str & "[COST] [varchar](10) NULL,"
            str = str & " [COSTMASTER] [ varchar](10) NULL"
            str = str & " )"
            gconnection.dataOperation1(6, str, "item")

        End If
        str = "select * from sysobjects where name='AccountsWorksContractMaster' and xtype='U'"
        gconnection.getDataSet(str, "AccountsWorksContractMaster")
        If gdataset.Tables("AccountsWorksContractMaster").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE [dbo].[AccountsWorksContractMaster]("
            str = str & "[workscontractcode] [varchar](10) NOT NULL,"
            str = str & "[sectiontype] [varchar](50) NULL,"
            str = str & "[percentage] [numeric](18, 2) NULL,"
            str = str & "[glaccountin] [varchar](10) NULL,"
            str = str & "[glaccountdesc] [varchar](50) NULL,"
            str = str & "[SUBLEDGERCODE] [varchar](10) NULL,"
            str = str & "[SUBLEDGERDESC] [varchar](50) NULL,"
            str = str & "[COSTCENTERCODE] [varchar](10) NULL,"
            str = str & "[COSTCENTERDESC] [varchar](50) NULL,"
            str = str & "[adduserid] [varchar](50) NULL,"
            str = str & "[adddatetime] [datetime] NULL,"
            str = str & "[updateuserid] [varchar](50) NULL,"
            str = str & "[updatedatetime] [datetime] NULL,"
            str = str & "[freezeflag] [varchar](1) NULL,"
            str = str & "[freezeuserid] [varchar](50) NULL,"
            str = str & "[freezedatetime] [datetime] NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "item")
        End If

        str = "select * from sysobjects where name='AUTHORIZE' and xtype='U'"
        gconnection.getDataSet(str, "AUTHORIZE")
        If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then


        Else
            str = "CREATE TABLE [dbo].[AUTHORIZE]("
            str = str & "[MODULENAME] [varchar](50) NULL,"
            str = str & "[FORMNAME] [varchar](200) NULL,"
            str = str & "[FORMTYPE] [varchar](20) NULL,"
            str = str & "[AUTHORIZELEVEL] [int] NULL,"
            str = str & "[AUTH1USER1] [varchar](20) NULL,"
            str = str & "[AUTH1USER2] [varchar](20) NULL,"
            str = str & "[AUTH2USER1] [varchar](20) NULL,"
            str = str & "[AUTH2USER2] [varchar](20) NULL,"
            str = str & "[AUTH3USER1] [varchar](20) NULL,"
            str = str & "[AUTH3USER2] [varchar](20) NULL,"
            str = str & "[ADDUSERID] [varchar](20) NULL,"
            str = str & "[ADDDATETIME] [datetime] NULL,"
            str = str & "[UPDATEUSERID] [varchar](20) NULL,"
            str = str & "[UPDATEDATETIME] [datetime] NULL,"
            str = str & "[VOID] [varchar](2) NULL,"
            str = str & "[VOIDUSER] [varchar](20) NULL,"
            str = str & "[VOIDDATETIME] [datetime] NULL"
            str = str & ") "
            gconnection.dataOperation1(6, str, "item")
        End If

        str = "select * from sysobjects where name='AccountsWorksContractMaster' and xtype='U'"
        gconnection.getDataSet(str, "AccountsWorksContractMaster")
        If gdataset.Tables("AccountsWorksContractMaster").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE [dbo].[AccountsWorksContractMaster]("
            str = str & "[workscontractcode] [varchar](10) NOT NULL,"
            str = str & "[sectiontype] [varchar](50) NULL,"
            str = str & "[percentage] [numeric](18, 2) NULL,"
            str = str & "[glaccountin] [varchar](10) NULL,"
            str = str & "[glaccountdesc] [varchar](50) NULL,"
            str = str & "[SUBLEDGERCODE] [varchar](10) NULL,"
            str = str & "[SUBLEDGERDESC] [varchar](50) NULL,"
            str = str & "[COSTCENTERCODE] [varchar](10) NULL,"
            str = str & "[COSTCENTERDESC] [varchar](50) NULL,"
            str = str & "[adduserid] [varchar](50) NULL,"
            str = str & "[adddatetime] [datetime] NULL,"
            str = str & "[updateuserid] [varchar](50) NULL,"
            str = str & "[updatedatetime] [datetime] NULL,"
            str = str & "[freezeflag] [varchar](1) NULL,"
            str = str & "[freezeuserid] [varchar](50) NULL,"
            str = str & "[freezedatetime] [datetime] NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "item")
        End If


        str = "select * from sysobjects where name='accountstdsmaster' and xtype='U'"
        gconnection.getDataSet(str, "accountstdsmaster")
        If gdataset.Tables("accountstdsmaster").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE [dbo].[accountstdsmaster]("
            str = str & "[tdscode] [varchar](10) NOT NULL,"
            str = str & "[sectiontype] [varchar](50) NULL,"
            str = str & "[percentage] [numeric](18, 3) NULL,"
            str = str & "[glaccountin] [varchar](10) NULL,"
            str = str & "[glaccountdesc] [varchar](50) NULL,"
            str = str & "[SUBLEDGERCODE] [varchar](10) NULL,"
            str = str & "[SUBLEDGERDESC] [varchar](50) NULL,"
            str = str & "[COSTCENTERCODE] [varchar](10) NULL,"
            str = str & "[COSTCENTERDESC] [varchar](50) NULL,"
            str = str & "[adduserid] [varchar](50) NULL,"
            str = str & "[adddatetime] [datetime] NULL,"
            str = str & "[updateuserid] [varchar](50) NULL,"
            str = str & "[updatedatetime] [datetime] NULL,"
            str = str & "[freezeflag] [varchar](1) NULL,"
            str = str & "[freezeuserid] [varchar](50) NULL,"
            str = str & "[freezedatetime] [datetime] NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "item")
        End If

        str = "select * from sysobjects where name='ACCOUNTSSUBLEDGERMASTER' and xtype='U'"
        gconnection.getDataSet(str, "ACCOUNTSSUBLEDGERMASTER")
        If gdataset.Tables("ACCOUNTSSUBLEDGERMASTER").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE [dbo].[ACCOUNTSSUBLEDGERMASTER]("
            str = str & "[roll] [nvarchar](255) NULL,"
            str = str & "[accode] [nvarchar](255) NULL,"
            str = str & "[acdesc] [nvarchar](255) NULL,"
            str = str & "[sltype] [nvarchar](255) NULL,"
            str = str & "[slcode] [nvarchar](255) NULL,"
            str = str & "[slname] [nvarchar](255) NULL,"
            str = str & "[sldesc] [nvarchar](255) NULL,"
            str = str & "[contactperson] [nvarchar](255) NULL,"
            str = str & "[address1] [nvarchar](255) NULL,"
            str = str & "[address2] [nvarchar](255) NULL,"
            str = str & "[address3] [nvarchar](255) NULL,"
            str = str & "[city] [nvarchar](255) NULL,"
            str = str & "[state] [nvarchar](255) NULL,"
            str = str & "[pin] [varchar](20) NULL,"
            str = str & "[phoneno] [varchar](50) NULL,"
            str = str & "[cellno] [nvarchar](255) NULL,"
            str = str & "[vatno] [nvarchar](255) NULL,"
            str = str & "[cstno] [nvarchar](255) NULL,"
            str = str & "[tinno] [nvarchar](255) NULL,"
            str = str & "[grnno] [nvarchar](255) NULL,"
            str = str & "[panno] [nvarchar](255) NULL,"
            str = str & "[creditperiod] [nvarchar](255) NULL,"
            str = str & "[opcredits] [numeric](18, 2) NULL,"
            str = str & "[opdebits] [numeric](18, 2) NULL,"
            str = str & "[cldebits] [nvarchar](255) NULL,"
            str = str & "[clcredits] [nvarchar](255) NULL,"
            str = str & "[tdsflag] [nvarchar](255) NULL,"
            str = str & "[tdssection] [nvarchar](255) NULL,"
            str = str & "[tdspercentage] [nvarchar](255) NULL,"
            str = str & "[workscontractflag] [nvarchar](255) NULL,"
            str = str & "[workscontractsection] [nvarchar](255) NULL,"
            str = str & "[workscontractpercentage] [nvarchar](255) NULL,"
            str = str & "[purchaseflag] [nvarchar](255) NULL,"
            str = str & "[purchasesection] [nvarchar](255) NULL,"
            str = str & "[purchasepercentage] [nvarchar](255) NULL,"
            str = str & "[esiflag] [nvarchar](255) NULL,"
            str = str & "[esisection] [nvarchar](255) NULL,"
            str = str & "[esipercentage] [nvarchar](255) NULL,"
            str = str & "[pfflag] [nvarchar](255) NULL,"
            str = str & "[pfsection] [nvarchar](255) NULL,"
            str = str & "[pfpercentage] [nvarchar](255) NULL,"
            str = str & "[aprdebits] [nvarchar](255) NULL,"
            str = str & "[aprcredits] [nvarchar](255) NULL,"
            str = str & "[maydebits] [nvarchar](255) NULL,"
            str = str & "[maycredits] [nvarchar](255) NULL,"
            str = str & "[jundebits] [nvarchar](255) NULL,"
            str = str & "[juncredits] [nvarchar](255) NULL,"
            str = str & "[juldebits] [nvarchar](255) NULL,"
            str = str & "[julcredits] [nvarchar](255) NULL,"
            str = str & "[augdebits] [nvarchar](255) NULL,"
            str = str & "[augcredits] [nvarchar](255) NULL,"
            str = str & "[sepdebits] [nvarchar](255) NULL,"
            str = str & "[sepcredits] [nvarchar](255) NULL,"
            str = str & "[octdebits] [nvarchar](255) NULL,"
            str = str & "[octcredits] [nvarchar](255) NULL,"
            str = str & "[novdebits] [nvarchar](255) NULL,"
            str = str & "[novcredits] [nvarchar](255) NULL,"
            str = str & "[decdebits] [nvarchar](255) NULL,"
            str = str & "[deccredits] [nvarchar](255) NULL,"
            str = str & "[jandebits] [nvarchar](255) NULL,"
            str = str & "[jancredits] [nvarchar](255) NULL,"
            str = str & "[febdebits] [nvarchar](255) NULL,"
            str = str & "[febcredits] [nvarchar](255) NULL,"
            str = str & "[mardebits] [nvarchar](255) NULL,"
            str = str & "[marcredits] [nvarchar](255) NULL,"
            str = str & "[adduserid] [nvarchar](255) NULL,"
            str = str & "[adddatetime] [nvarchar](255) NULL,"
            str = str & "[updateuserid] [nvarchar](255) NULL,"
            str = str & "[updatedatetime] [nvarchar](255) NULL,"
            str = str & "[freezeflag] [nvarchar](255) NULL,"
            str = str & "[freezeuserid] [nvarchar](255) NULL,"
            str = str & "[freezedatetime] [nvarchar](255) NULL,"
            str = str & "[TdsSectionType] [nvarchar](255) NULL,"
            str = str & "[NARRATION] [nvarchar](255) NULL,"
            str = str & "[CHQ_FLG] [nvarchar](255) NULL,"
            str = str & "[CHQ_FLAG] [nvarchar](255) NULL,"
            str = str & "[BILLDATE] [nvarchar](255) NULL,"
            str = str & "[LEDGERNAME] [nvarchar](255) NULL,"
            str = str & "[ADD_USER] [nvarchar](255) NULL,"
            str = str & "[UPD_USER] [nvarchar](255) NULL,"
            str = str & "[VOID] [nvarchar](255) NULL,"
            str = str & "[VOIDUSER] [nvarchar](255) NULL,"
            str = str & "[ADD_DATE] [datetime] NULL,"
            str = str & "[UPD_DATE] [datetime] NULL,"
            str = str & "[VOIDDATE] [datetime] NULL,"
            str = str & "[emailid] [varchar](100) NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "item")
        End If
        str = "select * from sysobjects where name='Inv_VendorMaster' and xtype='U'"
        gconnection.getDataSet(str, "Inv_VendorMaster")
        If gdataset.Tables("Inv_VendorMaster").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE [dbo].[Inv_VendorMaster]("
            str = str & "[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "[Vendorcode] [varchar](50) NOT NULL,"
            str = str & "[Itemcode] [varchar](50) NOT NULL,"
            str = str & "[Freeze] [char](1) NULL,"
            str = str & "[adduser] [varchar](50) NULL,"
            str = str & "[adddate] [datetime] NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "Inv_VendorMaster")

        End If

        str = "select * from sysobjects where name='Inv_VendorMaster' and xtype='U'"
        gconnection.getDataSet(str, "Inv_VendorMaster")
        If gdataset.Tables("Inv_VendorMaster").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE [dbo].[Inv_VendorMaster]("
            str = str & "[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "[Vendorcode] [varchar](50) NOT NULL,"
            str = str & "[Itemcode] [varchar](50) NOT NULL,"
            str = str & "[Freeze] [char](1) NULL,"
            str = str & "[adduser] [varchar](50) NULL,"
            str = str & "[adddate] [datetime] NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "Inv_VendorMaster")

        End If

        str = "select * from sysobjects where name='GRN_HEADER' and xtype='U'"
        gconnection.getDataSet(str, "GRN_HEADER")
        If gdataset.Tables("GRN_HEADER").Rows.Count > 0 Then

        Else

            str = "   CREATE TABLE [dbo].[GRN_HEADER]( "
            str = str & " [Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "[Grnno] [varchar](50) NULL,"
            str = str & " [Grndetails] [varchar](50) NOT NULL,"
            str = str & " [Grndate] [datetime] NULL,"
            str = str & " [POno] [varchar](50) NULL,"
            str = str & " [Supplierinvno] [varchar](50) NULL,"
            str = str & " [Supplierdate] [datetime] NULL,"
            str = str & " [Suppliercode] [varchar](50) NULL,"
            str = str & " [Suppliername] [varchar](50) NULL,"
            str = str & " [Typecode] [varchar](50) NULL,"
            str = str & " [Typedesc] [varchar](50) NULL,"
            str = str & " [Excisepassno] [varchar](50) NULL,"
            str = str & " [Excisedate] [datetime] NULL,"
            str = str & " [Stockindate] [datetime] NULL,"
            str = str & " [Trucknumber] [varchar](50) NULL,"
            str = str & " [Creditdays] [numeric](18, 0) NULL,"
            str = str & " [Glaccountcode] [varchar](50) NULL,"
            str = str & " 	[Glaccountname] [varchar](50) NULL,"
            str = str & " 	[Slcode] [varchar](50) NULL,"
            str = str & " 	[Slname] [varchar](50) NULL,"
            str = str & " 	[Costcentercode] [varchar](50) NULL,"
            str = str & " 	[Costcentername] [varchar](50) NULL,"
            str = str & " 	[Totalamount] [numeric](18, 2) NULL,"
            str = str & " [VATamount] [numeric](18, 2) NULL,"
            str = str & " [Surchargeamt] [numeric](18, 2) NULL,"
            str = str & " 	[OverallDiscount] [numeric](18, 2) NULL,"
            str = str & " 	[Discount] [numeric](18, 2) NULL,"
            str = str & " 	[Billamount] [numeric](18, 2) NULL,"
            str = str & "	[Remarks] [varchar](300) NULL,"
            str = str & " [Void] [char](10) NULL,"
            str = str & " 	[Adduser] [varchar](50) NULL,"
            str = str & "	[Adddate] [datetime] NULL,"
            str = str & "	[Updateuser] [varchar](50) NULL,"
            str = str & "	[Updatetime] [datetime] NULL,"
            str = str & "	[POSTINGFLAG] [varchar](1) NULL,"
            str = str & "	[category] [varchar](15) NULL,"
            str = str & "	[tdssectioncode] [varchar](10) NULL,"
            str = str & "	[TDSFLAG] [varchar](1) NULL,"
            str = str & " 	[TDSPERCENTAGE] [numeric](12, 3) NULL,"
            str = str & " 	[TDSAMOUNT] [numeric](12, 3) NULL,"
            str = str & "	[storecode] [varchar](50) NULL,"
            str = str & "	[storedesc] [varchar](50) NULL,"
            str = str & " [UPDFOOTER] [varchar](100) NULL,"
            str = str & " [UPDNAME] [varchar](100) NULL,"
            str = str & " 	[GRNTYPE] [varchar](50) NULL,"
            str = str & " [PROFITAMT] [numeric](18, 2) NULL,"
            str = str & " [ODISCOUNT] [numeric](18, 2) NULL,"
            str = str & " [TOTSALEAMT] [numeric](18, 2) NULL,"
            str = str & " [TOTPROFITAMT] [numeric](18, 2) NULL,"
            str = str & " [INDENTNO] [varchar](10) NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "Inv_VendorMaster")

        End If


        str = "select * from sysobjects where name='GRN_DETAILS' and xtype='U'"
        gconnection.getDataSet(str, "GRN_DETAILS")
        If gdataset.Tables("GRN_DETAILS").Rows.Count > 0 Then

        Else

            str = "    CREATE TABLE [dbo].[GRN_DETAILS]("
            str = str & "	[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " [Grnno] [varchar](50) NULL,"
            str = str & " [Grndetails] [varchar](50) NULL,"
            str = str & " [Grndate] [datetime] NULL,"
            str = str & " [POno] [varchar](50) NULL,"
            str = str & " [Suppliercode] [varchar](50) NULL,"
            str = str & " [Suppliername] [varchar](50) NULL,"
            str = str & "[Itemcode] [varchar](50) NULL,"
            str = str & " [Itemname] [varchar](50) NULL,"
            str = str & " [UOM] [varchar](50) NULL,"
            str = str & " [Qty] [numeric](18, 3) NULL,"
            str = str & " [Rate] [numeric](18, 2) NULL,"
            str = str & " [Discount] [numeric](18, 2) NULL,"
            str = str & " [Amount] [numeric](18, 2) NULL,"
            str = str & " [Voiditem] [char](2) NULL,"
            str = str & " [Adduser] [varchar](50) NULL,"
            str = str & " [Adddate] [datetime] NULL,"
            str = str & " [UpdateUser] [varchar](50) NULL,"
            str = str & "[Updatetime] [datetime] NULL,"
            str = str & " [category] [varchar](15) NULL,"
            str = str & " [TAXPERCENTAGE] [numeric](12, 3) NULL,"
            str = str & " [storecode] [varchar](50) NULL,"
            str = str & " [storedesc] [varchar](50) NULL,"
            str = str & " [taxper] [numeric](9, 2) NULL,"
            str = str & " [taxamount] [numeric](9, 2) NULL,"
            str = str & " [grntype] [varchar](50) NULL,"
            str = str & " [OTHCHARGE] [numeric](18, 2) NULL,"
            str = str & " [TransConvQty] [decimal](18, 0) NULL,"
            str = str & " [GRNTransQty] [decimal](18, 2) NULL,"
            str = str & " [GRNStockUom] [varchar](25) NULL,"
            str = str & " [GRNTransValue] [numeric](18, 2) NULL,"
            str = str & " [GRNTRANSRATE] [numeric](18, 2) NULL,"
            str = str & " [Profitper] [numeric](18, 2) NULL,"
            str = str & " [Salerate] [numeric](18, 0) NULL,"
            str = str & "[freeqty] [numeric](9, 0) NULL,"
            str = str & " [PROFITAMT] [numeric](18, 2) NULL,"
            str = str & " [ODISCOUNT] [numeric](18, 2) NULL,"
            str = str & " [SALEAMOUNT] [numeric](18, 2) NULL,"
            str = str & " [CASEQTY] [numeric](18, 0) NULL,"
            str = str & " [CASERATE] [numeric](18, 2) NULL,"
            str = str & " [UOMR] [varchar](50) NULL,"
            str = str & " [INDENTNO] [varchar](10) NULL,"
            str = str & " [GrnTransQtyR] [numeric](18, 2) NULL,"
            str = str & " [GRNTransValueR] [numeric](18, 2) NULL,"
            str = str & " [GRNStockUomR] [varchar](50) NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "Inv_VendorMaster")

        End If

        str = "select * from sysobjects where name='invsetup' and xtype='U'"
        gconnection.getDataSet(str, "invsetup")
        If gdataset.Tables("invsetup").Rows.Count > 0 Then

        Else

            str = " CREATE TABLE [dbo].[invsetup]("
            str = str & "	[grntype] [varchar](10) NULL,"
            str = str & "[VENDORLINK] [varchar](1) NULL,"
            str = str & "[GRNRATEONLINE] [varchar](1) NULL,"
            str = str & "[RSILINK] [varchar](1) NULL,"
            str = str & "[CATHOLIC] [varchar](1) NULL,"
            str = str & "[positemstorelink] [varchar](1) NULL,"
            str = str & "[HYDLINK] [varchar](1) NULL,"
            str = str & "[SALERATE] [varchar](1) NULL,"
            str = str & "[AVGRATE] [varchar](1) NULL,"
            str = str & "[GRNGLCODE] [varchar](1) NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "Inv_VendorMaster")
        End If
        str = "select * from sysobjects where name='INVITEM_TRANSUOM_LINK' and xtype='U'"
        gconnection.getDataSet(str, "INVITEM_TRANSUOM_LINK")

        If gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count > 0 Then

        Else

            str = "CREATE TABLE [dbo].[INVITEM_TRANSUOM_LINK]("
            str = str & "	[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "[Itemcode] [varchar](50) NULL,"
            str = str & "[ItemName] [varchar](75) NULL,"
            str = str & "[Tranuom] [varchar](50) NULL,"
            str = str & "[stockuom] [varchar](50) NULL,"
            str = str & "[Storecode] [varchar](50) NULL,"
            str = str & "[Adduser] [varchar](50) NULL,"
            str = str & "[Adddate] [datetime] NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "Inv_VendorMaster")
        End If
        str = "select * from sysobjects where name='InventorySubSubGroupMaster' and xtype='U'"
        gconnection.getDataSet(str, "InventorySubSubGroupMaster")
        If gdataset.Tables("InventorySubSubGroupMaster").Rows.Count > 0 Then

        Else

            str = "  CREATE TABLE [dbo].[InventorySubSubGroupMaster]("
            str = str & "[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "[Subgroupcode] [varchar](50) NULL,"
            str = str & "[Subgroupdesc] [varchar](50) NULL,"
            str = str & "[Freeze] [char](1) NULL,"
            str = str & "[Adduser] [varchar](50) NULL,"
            str = str & "[Adddate] [varchar](50) NULL,"
            str = str & "[subsubgroupcode] [varchar](15) NULL,"
            str = str & "[subsubgroupdesc] [varchar](50) NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "InventorySubSubGroupMaster")
        End If

        str = "select * from sysobjects where name='InventorySubGroupMaster' and xtype='U'"
        gconnection.getDataSet(str, "InventorySubGroupMaster")
        If gdataset.Tables("InventorySubGroupMaster").Rows.Count > 0 Then

        Else


            str = "  CREATE TABLE [dbo].[InventorySubGroupMaster]("
            str = str & " [Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "[Groupcode] [varchar](50) NULL,"
            str = str & "[Groupdesc] [varchar](50) NULL,"
            str = str & "	[Subgroupcode] [varchar](50) NULL,"
            str = str & "	[Subgroupdesc] [varchar](50) NULL,"
            str = str & "	[Freeze] [char](1) NULL,"
            str = str & "	[Adduser] [varchar](50) NULL,"
            str = str & "	[Adddate] [varchar](50) NULL,"
            str = str & "	[updateuser] [varchar](15) NULL,"
            str = str & "	[updatetime] [datetime] NULL,"
            str = str & "[voiduser] [varchar](50) NULL,"
            str = str & "	[voiddate] [datetime] NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "InventorySubGroupMaster")

        End If
        str = "select * from sysobjects where name='Inventoryratehistory' and xtype='U'"
        gconnection.getDataSet(str, "Inventoryratehistory")
        If gdataset.Tables("Inventoryratehistory").Rows.Count > 0 Then

        Else


            str = "   CREATE TABLE [dbo].[Inventoryratehistory]("
            str = str & " [autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "[itemcode] [varchar](50) NOT NULL,"
            str = str & "[itemname] [varchar](50) NOT NULL,"
            str = str & "	[modifydate] [datetime] NULL,"
            str = str & "[purchaserate] [float] NULL,"
            str = str & "[salerate] [float] NULL,"
            str = str & "[adduser] [varchar](50) NULL,"
            str = str & "	[adddate] [datetime] NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "Inventoryratehistory")

        End If
        str = "select * from sysobjects where name='INVENTORYITEMMASTER' and xtype='U'"
        gconnection.getDataSet(str, "INVENTORYITEMMASTER")
        If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count > 0 Then

        Else

            str = "CREATE TABLE [dbo].[INVENTORYITEMMASTER]("
            str = str & "	[Autoid] [numeric](18, 0) NULL,"
            str = str & "[itemcode] [varchar](50) NOT NULL,"
            str = str & "[itemname] [varchar](50) NOT NULL,"
            str = str & "[alias] [varchar](50) NULL,"
            str = str & "[groupcode] [varchar](50) NULL,"
            str = str & "[groupname] [varchar](50) NULL,"
            str = str & "[subgroupcode] [varchar](50) NULL,"
            str = str & "	[subgroupname] [varchar](50) NULL,"
            str = str & "[subsubgroupcode] [varchar](50) NULL,"
            str = str & "[subsubgroupname] [varchar](50) NULL,"
            str = str & "[reorderlevel] [float] NULL,"
            str = str & "	[minqty] [float] NULL,"
            str = str & "	[maxqty] [float] NULL,"
            str = str & "[purchaserate] [float] NULL,"
            str = str & "	[salerate] [float] NULL,"
            str = str & "	[stockuom] [varchar](50) NULL,"
            str = str & "[receiveuom] [varchar](50) NULL,"
            str = str & "[saleuom] [varchar](50) NULL,"
            str = str & "[opstock] [float] NULL,"
            str = str & "[opvalue] [float] NULL,"
            str = str & "[valuation] varchar(50),"
            str = str & "	[Freeze] [char](1) NULL,"
            str = str & "	[Adduser] [varchar](50) NULL,"
            str = str & "	[Adddate] [datetime] NULL,"
            str = str & "	[STORECODE] [varchar](50) NULL,"
            str = str & "[closingqty] [numeric](18, 3) NULL,"
            str = str & "[closingval] [numeric](18, 2) NULL,"
            str = str & "[abc] [char](10) NULL,"
            str = str & "	[category] [varchar](30) NULL,"
            str = str & "	[clstock] [numeric](18, 3) NULL,"
            str = str & "	[clvalue] [numeric](18, 2) NULL,"
            str = str & "	[TAXREBATE] [varchar](10) NULL,"
            str = str & "	[baserate] [numeric](16, 2) NULL,"
            str = str & "	[INVITMTransQty] [decimal](18, 2) NULL,"
            str = str & "	[INVITMTransValue] [numeric](18, 2) NULL,"
            str = str & "[INVITMStockUOM] [varchar](50) NULL,"
            str = str & "[INVITMTRANSRATE] [numeric](18, 2) NULL,"
            str = str & "	[Profitper] [numeric](18, 2) NULL,"
            str = str & "	[FREEQTY] [float] NULL,"
            str = str & "[CASEQTY] [numeric](18, 0) NULL,"
            str = str & "	[updateuser] [varchar](15) NULL,"
            str = str & "[updatetime] [datetime] NULL,"
            str = str & "[taxper] [numeric](18, 2) NULL,"
            str = str & "	[stockuomR] [varchar](50) NULL,"
            str = str & "	[receiveuomR] [varchar](50) NULL,"
            str = str & "	[doubleuomR] [varchar](50) NULL,"
            str = str & "	[saleuomR] [varchar](50) NULL,"
            str = str & "	[voiduser] [varchar](50) NULL,"
            str = str & "[voiddate] [datetime] NULL,"
            str = str & "[InvItmTransValueR] [numeric](18, 2) NULL,"
            str = str & "[InvItmTransQtyR] [numeric](18, 2) NULL,"
            str = str & "[InvItmStockUomR] [varchar](50) NULL,"
            str = str & "	[SALEUOM2] [varchar](50) NULL,"
            str = str & "    [UOMDECIMAL] [varchar](50) NULL,"
            str = str & "    [EOQ] [numeric](18, 2) NULL,"
            str = str & "       [Ledger] [varchar](50) NULL,"
            str = str & "       [INPUTTAX] [varchar](10) NULL,"
            str = str & "         [Selectopt] [varchar](5) NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "Inventoryratehistory")

        End If


        str = "select * from sysobjects where name='InventoryGroupMaster' and xtype='U'"
        gconnection.getDataSet(str, "InventoryGroupMaster")
        If gdataset.Tables("InventoryGroupMaster").Rows.Count > 0 Then

        Else

            str = "  CREATE TABLE [dbo].[InventoryGroupMaster]("
            str = str & " [Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " [Groupcode] [varchar](50) NOT NULL,"
            str = str & "[Groupdesc] [varchar](50) NOT NULL,"
            str = str & "	[Freeze] [char](1) NULL,"
            str = str & "[Adduser] [varchar](50) NULL,"
            str = str & "	[Adddate] [datetime] NULL,"
            str = str & "	[updateuser] [varchar](15) NULL,"
            str = str & "	[updatetime] [datetime] NULL,"
            str = str & "	[voiduser] [varchar](50) NULL,"
            str = str & "	[voiddate] [datetime] NULL"

            str = str & ")"
            gconnection.dataOperation1(6, str, "InventoryGroupMaster")

        End If

        str = "select * from sysobjects where name='INVENTORYCATEGORYMASTER' and xtype='U'"
        gconnection.getDataSet(str, "INVENTORYCATEGORYMASTER")
        If gdataset.Tables("GRN_DETAILS").Rows.Count > 0 Then

        Else

            str = "   CREATE TABLE [dbo].[INVENTORYCATEGORYMASTER]("
            str = str & "[CATEGORYCODE] [varchar](10) NULL,"
            str = str & "[CATEGORYDESC] [varchar](25) NULL,"
            str = str & " [Freeze] [char](1) NULL,"
            str = str & " [Adduser] [varchar](10) NULL,"
            str = str & " [Adddate] [datetime] NULL,"
            str = str & "[USERNAME] [varchar](50) NULL,"
            str = str & "	[UTYPE] [varchar](15) NULL,"
            str = str & "[VOIDUSER] [varchar](30) NULL,"
            str = str & "[voiddate] [datetime] NULL,"
            str = str & "[Rateflag] [varchar](15) NULL"
            str = str & ") "
            gconnection.dataOperation1(6, str, "item")

        End If
        str = "select * from sysobjects where name='INVENTORY_TRANSCONVERSION' and xtype='U'"
        gconnection.getDataSet(str, "INVENTORY_TRANSCONVERSION")
        If gdataset.Tables("GRN_DETAILS").Rows.Count > 0 Then

        Else

            str = " CREATE TABLE [dbo].[INVENTORY_TRANSCONVERSION]("
            str = str & "[BASEUOM] [varchar](25) NULL,"
            str = str & "[TRANSUOM] [varchar](25) NULL,"
            str = str & "[CONVVALUE] [decimal](18, 3) NULL,"
            str = str & "[ADDUSER] [varchar](20) NULL,"
            str = str & " [ADDDATETIME] [datetime] NULL,"
            str = str & "[freeze] [char](1) NULL,"
            str = str & "[VOIDDATETIME] [datetime] NULL,"
            str = str & "	[UPDATEUSER] [varchar](25) NULL,"
            str = str & "	[UPDATEDATETIME] [datetime] NULL,"
            str = str & "	[VOIDUSER] [varchar](25) NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "item")

        End If

        str = "select * from sysobjects where name='INV_WAR' and xtype='U'"
        gconnection.getDataSet(str, "INV_WAR")
        If gdataset.Tables("INV_WAR").Rows.Count > 0 Then

        Else

            str = "    CREATE TABLE [dbo].[INV_WAR]("
            str = str & " [GRNDATE] [datetime] NULL,"
            str = str & " [ITEMCODE] [varchar](50) NULL,"
            str = str & " [QTY] [float] NULL,"
            str = str & " [VALUE] [float] NULL,"
            str = str & " [war] [numeric](18, 2) NULL,"
            str = str & " [GROUPCODE] [varchar](50) NULL,"
            str = str & " [NEXTDATE] [datetime] NULL,"
            str = str & " 	[clsqty] [numeric](18, 2) NULL,"
            str = str & " [clsval] [numeric](18, 2) NULL,"
            str = str & "	[TAXREBATE] [varchar](3) NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "item")

        End If
        str = "select * from sysobjects where name='UoMMaster' and xtype='U'"
        gconnection.getDataSet(str, "UoMMaster")
        If gdataset.Tables("UoMMaster").Rows.Count > 0 Then

        Else

            str = "  CREATE TABLE [dbo].[UoMMaster]("
            str = str & "[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " [AddDatetime] [datetime] NULL,"
            str = str & " [AddUSer] [nvarchar](50) NULL,"
            str = str & " [Freeze] [nvarchar](1) NULL,"
            str = str & " [UOMCode] [varchar](100) NULL,"
            str = str & " [UOMDesc] [varchar](100) NULL,"
            str = str & " [UOMSeqno] [decimal](38, 0) NULL,"
            str = str & " [AUTHORISED] [varchar](2) NULL,"
            str = str & " [UPDATEUSER] [varchar](15) NULL,"
            str = str & " 	[UPDATETIME] [datetime] NULL,"
            str = str & " 	[voiduser] [varchar](50) NULL,"
            str = str & "	[voiddate] [datetime] NULL"
            str = str & " ) "
            gconnection.dataOperation1(6, str, "item")

        End If
        str = "select * from sysobjects where name='tempstocktabe1' and xtype='U'"
        gconnection.getDataSet(str, "tempstocktabe1")
        If gdataset.Tables("tempstocktabe1").Rows.Count > 0 Then

        Else

            str = "  CREATE TABLE [dbo].[tempstocktabe1]("
            str = str & "	   	[CLDATE] [datetime] NULL,"
            str = str & "	[UoM] [varchar](50) NULL,"
            str = str & "	[storecode] [varchar](50) NULL,"
            str = str & "		[ITEMCODE] [varchar](50) NULL,"
            str = str & "	[TRNNO] [varchar](50) NULL,"
            str = str & "		[TUOM] [varchar](1) NOT NULL,"
            str = str & "	[CONVVALUE] [int] NOT NULL,"
            str = str & "	[CLQTY] [int] NOT NULL"
            str = str & " ) "
            gconnection.dataOperation1(6, str, "tempstocktabe1")

        End If
        str = "select * from sysobjects where name='tempstocktabe' and xtype='U'"
        gconnection.getDataSet(str, "tempstocktabe")
        If gdataset.Tables("tempstocktabe1").Rows.Count > 0 Then

        Else

            str = "  CREATE TABLE [dbo].[tempstocktabe]("
            str = str & "	   	[opDATE] [datetime] NULL,"
            str = str & "	[UoM] [varchar](50) NULL,"
            str = str & "	[storecode] [varchar](50) NULL,"
            str = str & "		[ITEMCODE] [varchar](50) NULL,"
            str = str & "	[TRNNO] [varchar](50) NULL,"
            str = str & "		[TUOM] [varchar](1) NOT NULL,"
            str = str & "	[CONVVALUE] [int] NOT NULL,"
            str = str & "	[opQTY] [int] NOT NULL"
            str = str & " ) "
            gconnection.dataOperation1(6, str, "tempstocktabe")

        End If
        str = "select * from sysobjects where name='TEMPSTOCKTRANSFERDETAIL' and xtype='U'"
        gconnection.getDataSet(str, "TEMPSTOCKTRANSFERDETAIL")
        If gdataset.Tables("TEMPSTOCKTRANSFERDETAIL").Rows.Count > 0 Then

        Else


            str = " CREATE TABLE [dbo].[TEMPSTOCKTRANSFERDETAIL]("
            str = str & "[docno] [varchar](50) NULL,"
            str = str & " [Docdetails] [varchar](50) NULL,"
            str = str & "	[docdate] [datetime] NULL,"
            str = str & "	[fromstorecode] [varchar](50) NULL,"
            str = str & "	[fromstoredesc] [varchar](50) NULL,"
            str = str & " [tostorecode] [varchar](50) NULL,"
            str = str & " [tostoredesc] [varchar](50) NULL,"
            str = str & " [itemcode] [varchar](50) NULL,"
            str = str & " [itemname] [varchar](50) NULL,"
            str = str & " [uom] [varchar](50) NULL,"
            str = str & " [qty] [numeric](18, 3) NULL,"
            str = str & " [batchno] [varchar](50) NULL,"
            str = str & " [void] [varchar](50) NULL,"
            str = str & " [rate] [numeric](18, 3) NULL,"
            str = str & " [amount] [numeric](18, 3) NULL,"
            str = str & " [weightedrate] [numeric](18, 3) NULL,"
            str = str & " [batchrate] [numeric](18, 3) NULL,"
            str = str & " [tuom] [varchar](50) NULL,"
            str = str & " [categorycode] [varchar](50) NULL,"
            str = str & " [batchprocess] [varchar](50) NULL,"
            str = str & " [rateflag] [varchar](10) NULL,"
            str = str & " [CONVVALUE] [numeric](18, 3) NULL,"
            str = str & " [rateuom] [varchar](50) NULL,"
            str = str & " [rconvvalue] [numeric](18, 3) NULL"
            str = str & " ) ON [PRIMARY]"
            gconnection.dataOperation1(6, str, "TEMPSTOCKTRANSFERDETAIL")

        End If
        str = "select * from sysobjects where name='StoreMaster' and xtype='U'"
        gconnection.getDataSet(str, "StoreMaster")
        If gdataset.Tables("StoreMaster").Rows.Count > 0 Then

        Else

            str = "    CREATE TABLE [dbo].[StoreMaster]("
            str = str & "[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "[Storecode] [varchar](50) NOT NULL,"
            str = str & "[Storedesc] [varchar](50) NOT NULL,"
            str = str & "[Freeze] [char](1) NULL,"
            str = str & " [adduser] [varchar](50) NULL,"
            str = str & "[adddate] [datetime] NULL,"
            str = str & "	[Storestatus] [varchar](50) NULL,"
            str = str & "	[updateuser] [varchar](15) NULL,"
            str = str & "	[updatetime] [datetime] NULL,"
            str = str & "	[voiduser] [varchar](50) NULL,"
            str = str & "	[voiddate] [datetime] NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "item")

        End If
        str = "select * from sysobjects where name='STOCKTRANSFERHEADER' and xtype='U'"
        gconnection.getDataSet(str, "STOCKTRANSFERHEADER")
        If gdataset.Tables("STOCKTRANSFERHEADER").Rows.Count > 0 Then

        Else

            str = "  CREATE TABLE [dbo].[STOCKTRANSFERHEADER]("
            str = str & " [Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " [Docno] [varchar](50) NULL,"
            str = str & "[Docdetails] [varchar](50) NOT NULL,"
            str = str & "[Docdate] [datetime] NULL,"
            str = str & "[Doctype] [varchar](10) NULL,"
            str = str & "[Transferno] [varchar](50) NULL,"
            str = str & "[Fromstorecode] [varchar](50) NULL,"
            str = str & "	[Fromstoredesc] [varchar](50) NULL,"
            str = str & "	[Tostorecode] [varchar](50) NULL,"
            str = str & "	[Tostoredesc] [varchar](50) NULL,"
            str = str & "	[Challenno] [varchar](50) NULL,"
            str = str & "	[Challendate] [datetime] NULL,"
            str = str & "	[TotalAmt] [numeric](18, 2) NULL,"
            str = str & "	[Remarks] [varchar](100) NULL,"
            str = str & "	[Void] [char](10) NULL,"
            str = str & "[Adduser] [varchar](50) NULL,"
            str = str & "[Adddate] [datetime] NULL,"
            str = str & "	[Updateuser] [varchar](50) NULL,"
            str = str & "	[Updatetime] [datetime] NULL,"
            str = str & "	[UPDFOOTER] [varchar](100) NULL,"
            str = str & "	[UPDSIGN] [varchar](100) NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "item")

        End If
        str = "select * from sysobjects where name='STOCKTRANSFERDETAIL' and xtype='U'"
        gconnection.getDataSet(str, "STOCKTRANSFERDETAIL")
        If gdataset.Tables("STOCKTRANSFERDETAIL").Rows.Count > 0 Then

        Else


            str = "CREATE TABLE [dbo].[STOCKTRANSFERDETAIL]("
            str = str & "	[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "	[Docno] [varchar](50) NULL,"
            str = str & "	[Docdetails] [varchar](50) NULL,"
            str = str & "	[Docdate] [datetime] NULL,"
            str = str & "	[Doctype] [varchar](10) NULL,"
            str = str & "	[Transferno] [varchar](50) NULL,"
            str = str & "	[Fromstorecode] [varchar](50) NULL,"
            str = str & "[Fromstoredesc] [varchar](50) NULL,"
            str = str & "	[Tostorecode] [varchar](50) NULL,"
            str = str & "	[Tostoredesc] [varchar](50) NULL,"
            str = str & " [Challenno] [varchar](50) NULL,"
            str = str & "[Itemcode] [varchar](50) NULL,"
            str = str & "[Itemname] [varchar](50) NULL,"
            str = str & "[Uom] [varchar](50) NULL,"
            str = str & "[Qty] [numeric](18, 3) NULL,"
            str = str & "[Rate] [numeric](18, 2) NULL,"
            str = str & "[Amount] [numeric](18, 2) NULL,"
            str = str & "[Groupcode] [varchar](50) NULL,"
            str = str & "	[Subgroupcode] [varchar](50) NULL,"
            str = str & "[Void] [char](1) NULL,"
            str = str & "[Adduser] [varchar](50) NULL,"
            str = str & "[Adddatetime] [datetime] NULL,"
            str = str & "[Updateuser] [varchar](50) NULL,"
            str = str & "[Updatetime] [datetime] NULL,"
            str = str & "[TRFTransQty] [decimal](18, 2) NULL,"
            str = str & "[TRFStockUom] [varchar](25) NULL,"
            str = str & "[TRFTransValue] [numeric](18, 2) NULL,"
            str = str & "[TRFTRANSRATE] [numeric](18, 2) NULL,"
            str = str & "[UOMR] [varchar](50) NULL,"
            str = str & "[TRFTransQtyR] [numeric](18, 2) NULL,"
            str = str & "[TRFTransValueR] [numeric](18, 2) NULL,"
            str = str & "[TRFStockUomR] [varchar](50) NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "item")

        End If

        str = "select * from sysobjects where name='STOCKISSUEHEADER' and xtype='U'"
        gconnection.getDataSet(str, "STOCKISSUEHEADER")
        If gdataset.Tables("STOCKISSUEHEADER").Rows.Count > 0 Then

        Else

            str = "     CREATE TABLE [dbo].[STOCKISSUEHEADER]("
            str = str & "[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "[Docno] [varchar](50) NOT NULL,"
            str = str & "	[Docdetails] [varchar](50) NOT NULL,"
            str = str & "[Doctype] [varchar](50) NULL,"
            str = str & "[Docdate] [datetime] NULL,"
            str = str & "[IndentNo] [varchar](50) NULL,"
            str = str & "	[IndentDate] [datetime] NULL,"
            str = str & "	[Storelocationcode] [varchar](50) NULL,"
            str = str & "	[Storelocationname] [varchar](50) NULL,"
            str = str & "	[Opstorelocationcode] [varchar](50) NULL,"
            str = str & "[Opstorelocationname] [varchar](50) NULL,"
            str = str & "[Totalamt] [numeric](18, 2) NULL,"
            str = str & "[Remarks] [varchar](100) NULL,"
            str = str & "[Void] [varchar](1) NULL,"
            str = str & "[Voidreason] [varchar](50) NULL,"
            str = str & "	[Adduser] [varchar](50) NULL,"
            str = str & "	[Adddate] [datetime] NULL,"
            str = str & "	[Updateuser] [varchar](50) NULL,"
            str = str & "	[Updatetime] [varchar](50) NULL,"
            str = str & "	[voiduser] [varchar](150) NULL,"
            str = str & "	[voidtime] [datetime] NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "STOCKISSUEHEADER")

        End If

        str = "select * from sysobjects where name='STOCKISSUEDETAIL' and xtype='U'"
        gconnection.getDataSet(str, "STOCKISSUEDETAIL")
        If gdataset.Tables("STOCKISSUEDETAIL").Rows.Count > 0 Then

        Else

            str = "   CREATE TABLE [dbo].[STOCKISSUEDETAIL]("
            str = str & "	[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "	[Docno] [varchar](50) NOT NULL,"
            str = str & "	[Docdetails] [varchar](50) NULL,"
            str = str & "	[Docdate] [datetime] NULL,"
            str = str & "	[IndentNo] [varchar](50) NULL,"
            str = str & "	[IndentDate] [datetime] NULL,"
            str = str & "	[Storelocationcode] [varchar](50) NULL,"
            str = str & "	[Storelocationname] [varchar](50) NULL,"
            str = str & "	[Opstorelocationcode] [varchar](50) NULL,"
            str = str & "	[Opstorelocationname] [varchar](50) NULL,"
            str = str & "	[Itemcode] [varchar](50) NULL,"
            str = str & "	[Itemname] [varchar](75) NULL,"
            str = str & "	[Uom] [varchar](50) NULL,"
            str = str & "	[Qty] [numeric](18, 3) NULL,"
            str = str & "	[Rate] [numeric](18, 2) NULL,"
            str = str & "	[Amount] [numeric](18, 2) NULL,"
            str = str & "	[Void] [char](1) NULL,"
            str = str & " [Adduser] [varchar](50) NULL,"
            str = str & " [Adddatetime] [datetime] NULL,"
            str = str & "	[Updateuser] [varchar](50) NULL,"
            str = str & "	[Updatetime] [datetime] NULL,"
            str = str & "	[CLSQTY] [numeric](16, 2) NULL,"
            str = str & "	[CLSVAL] [numeric](16, 2) NULL,"
            str = str & "	[ind_qty] [numeric](18, 3) NULL,"
            str = str & " [batchno] varchar(50) null,"
            str = str & " [voiduser] [varchar](50) NULL,"
            str = str & " [voidtime] [datetime] NULL "
            str = str & ")"
            gconnection.dataOperation1(6, str, "item")

        End If

        str = "select * from sysobjects where name='STOCKINOUTHEADER' and xtype='U'"
        gconnection.getDataSet(str, "STOCKINOUTHEADER")
        If gdataset.Tables("STOCKINOUTHEADER").Rows.Count > 0 Then

        Else

            str = "    CREATE TABLE [dbo].[STOCKINOUTHEADER]("
            str = str & "	[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "[Docno] [varchar](50) NULL,"
            str = str & "[Docdetails] [varchar](50) NOT NULL,"
            str = str & "[Docdate] [datetime] NULL,"
            str = str & "	[Doctype] [varchar](10) NULL,"
            str = str & "	[Transferno] [varchar](50) NULL,"
            str = str & "	[storecode] [varchar](50) NULL,"
            str = str & "	[storedesc] [varchar](50) NULL,"
            str = str & "	[Fromstorecode] [varchar](50) NULL,"
            str = str & "	[Fromstoredesc] [varchar](50) NULL,"
            str = str & "	[Tostorecode] [varchar](50) NULL,"
            str = str & "[Tostoredesc] [varchar](50) NULL,"
            str = str & "[Challenno] [varchar](50) NULL,"
            str = str & "[Challendate] [datetime] NULL,"
            str = str & "[TotalAmt] [numeric](18, 2) NULL,"
            str = str & "[Remarks] [varchar](100) NULL,"
            str = str & "[Void] [char](10) NULL,"
            str = str & "[Adduser] [varchar](50) NULL,"
            str = str & "[Adddate] [datetime] NULL,"
            str = str & "[Updateuser] [varchar](50) NULL,"
            str = str & "[Updatetime] [datetime] NULL,"
            str = str & "[UPDFOOTER] [varchar](100) NULL,"
            str = str & "[UPDSIGN] [varchar](100) NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "item")

        End If

        str = "select * from sysobjects where name='STOCKINOUTDETAIL' and xtype='U'"
        gconnection.getDataSet(str, "STOCKINOUTDETAIL")
        If gdataset.Tables("STOCKINOUTDETAIL").Rows.Count > 0 Then

        Else

            str = "   CREATE TABLE [dbo].[STOCKINOUTDETAIL]("
            str = str & "[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "[Docno] [varchar](50) NULL,"
            str = str & "[Docdetails] [varchar](50) NULL,"
            str = str & "[Docdate] [datetime] NULL,"
            str = str & "	[Doctype] [varchar](10) NULL,"
            str = str & "	[Transferno] [varchar](50) NULL,"
            str = str & "	[storecode] [varchar](50) NULL,"
            str = str & "	[storedesc] [varchar](50) NULL,"
            str = str & "	[Fromstorecode] [varchar](50) NULL,"
            str = str & "	[Fromstoredesc] [varchar](50) NULL,"
            str = str & "	[Tostorecode] [varchar](50) NULL,"
            str = str & "	[Tostoredesc] [varchar](50) NULL,"
            str = str & "	[Challenno] [varchar](50) NULL,"
            str = str & "	[Itemcode] [varchar](50) NULL,"
            str = str & "	[Itemname] [varchar](50) NULL,"
            str = str & "	[Uom] [varchar](50) NULL,"
            str = str & "	[Qty] [numeric](18, 3) NULL,"
            str = str & "	[Rate] [numeric](18, 2) NULL,"
            str = str & "	[Amount] [numeric](18, 0) NULL,"
            str = str & "	[Dblamt] [numeric](18, 2) NULL,"
            str = str & "	[Dblconv] [varchar](50) NULL,"
            str = str & "	[Highratio] [float] NULL,"
            str = str & "[Groupcode] [varchar](50) NULL,"
            str = str & "[Subgroupcode] [varchar](50) NULL,"
            str = str & "	[Void] [char](1) NULL,"
            str = str & "	[Avgqty] [float] NULL,"
            str = str & "	[Avgrate] [float] NULL,"
            str = str & "	[Adduser] [varchar](50) NULL,"
            str = str & "	[Adddatetime] [datetime] NULL,"
            str = str & "	[Updateuser] [varchar](50) NULL,"
            str = str & "	[Updatetime] [datetime] NULL,"
            str = str & "	[IOTransQty] [decimal](18, 2) NULL,"
            str = str & "[IOStockUom] [varchar](25) NULL,"
            str = str & "	[IOTransValue] [numeric](18, 2) NULL,"
            str = str & "[IOTRANSRATE] [numeric](18, 2) NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "item")

        End If

        str = "select * from sysobjects where name='STOCKDMGHEADER' and xtype='U'"
        gconnection.getDataSet(str, "STOCKDMGHEADER")
        If gdataset.Tables("STOCKDMGHEADER").Rows.Count > 0 Then

        Else

            str = "  CREATE TABLE [dbo].[STOCKDMGHEADER]("
            str = str & " [Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " [Docno] [varchar](50) NULL,"
            str = str & " [Docdetails] [varchar](50) NOT NULL,"
            str = str & " [Docdate] [datetime] NULL,"
            str = str & " [Doctype] [varchar](10) NULL,"
            str = str & " [storecode] [varchar](50) NULL,"
            str = str & "	[storedesc] [varchar](50) NULL,"
            str = str & " [totalqty] [numeric](18, 3) NULL, "
            str = str & " [TotalAmt] [numeric](18, 2) NULL,"
            str = str & " [Remarks] [varchar](100) NULL,"
            str = str & " [Void] [char](10) NULL,"
            str = str & " [Voidreason ] [varchar](100) NULL,"
            str = str & " [Adduser] [varchar](50) NULL,"
            str = str & " [Adddate] [datetime] NULL,"
            str = str & " [Updateuser] [varchar](50) NULL,"
            str = str & " [Updatetime] [datetime] NULL,"
            str = str & " 	[voiduser] [varchar](50) NULL,"
            str = str & "  [voidtime] [datetime] NULL"


            str = str & ")"
            gconnection.dataOperation1(6, str, "STOCKDMGHEADER")

        End If

        str = "select * from sysobjects where name='STOCKDMGDETAIL' and xtype='U'"
        gconnection.getDataSet(str, "STOCKDMGDETAIL")
        If gdataset.Tables("STOCKDMGDETAIL").Rows.Count > 0 Then

        Else

            str = "        CREATE TABLE [dbo].[STOCKDMGDETAIL]("
            str = str & "	[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "	[Docno] [varchar](50) NULL,"
            str = str & "	[Docdetails] [varchar](50) NULL,"
            str = str & "	[Docdate] [datetime] NULL,"
            str = str & "		[Doctype] [varchar](10) NULL,"
            str = str & "	[storecode] [varchar](50) NULL,"
            str = str & "	[storedesc] [varchar](50) NULL,"
            str = str & "	[Itemcode] [varchar](50) NULL,"
            str = str & "		[Itemname] [varchar](50) NULL,"
            str = str & "		[Uom] [varchar](50) NULL,"
            str = str & "		[dmgQty] [numeric](18, 3) NULL,"
            str = str & " [batchno] varchar(50) null,"
            str = str & "		[closingqty] [numeric](18, 3) NULL,"
            str = str & "		[Rate] [numeric](18, 2) NULL,"
            str = str & "		[Amount] [numeric](18, 0) NULL,"
            str = str & "	[Void] [char](1) NULL,"
            str = str & "		[Adduser] [varchar](50) NULL,"
            str = str & "	[Adddate] [datetime] NULL,"
            str = str & "	[Updateuser] [varchar](50) NULL,"
            str = str & "	[Updatetime] [datetime] NULL,"
            str = str & "	[remarks] [varchar](100) NULL,"
            str = str & "	[voiduser] [varchar](50) NULL,"
            str = str & "	[voidtime] [datetime] NULL"
            str = str & "	)"
            gconnection.dataOperation1(6, str, "STOCKDMGDETAIL")

        End If

        str = "select * from sysobjects where name='STOCKADJUSTHEADER' and xtype='U'"
        gconnection.getDataSet(str, "STOCKADJUSTHEADER")
        If gdataset.Tables("STOCKADJUSTHEADER").Rows.Count > 0 Then

        Else

            str = "    CREATE TABLE [dbo].[STOCKADJUSTHEADER]("
            str = str & " [Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " [Docno] [varchar](50) NULL,"
            str = str & " [Docdetails] [varchar](50) NOT NULL,"
            str = str & " [Docdate] [datetime] NULL,"
            str = str & " [Storecode] [varchar](50) NULL,"
            str = str & " [Storedesc] [varchar](50) NULL,"
            str = str & " [Adjustedstock] [numeric](18, 2) NULL,"
            str = str & " [Stockinhand] [numeric](18, 2) NULL,"
            str = str & " [Physicalstock] [numeric](18, 2) NULL,"
            str = str & "   [totalqty] [numeric](18, 3) NULL,"
            str = str & " [Remarks] [varchar](50) NULL,"
            str = str & " [voidreason ] [varchar](150) NULL,"
            str = str & " [Void] [char](1) NULL,"
            str = str & " [AddUser] [varchar](50) NULL,"
            str = str & " [Adddate] [datetime] NULL,"
            str = str & "	[UpdateUser] [varchar](50) NULL,"
            str = str & "	[Updatetime] [datetime] NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "item")

        End If

        str = "select * from sysobjects where name='STOCKADJUSTDETAILS' and xtype='U'"
        gconnection.getDataSet(str, "STOCKADJUSTDETAILS")
        If gdataset.Tables("STOCKADJUSTDETAILS").Rows.Count > 0 Then

        Else

            str = "        CREATE TABLE [dbo].[STOCKADJUSTDETAILS]("
            str = str & "[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " [Docno] [varchar](50) NULL,"
            str = str & "[Docdetails] [varchar](50) NULL,"
            str = str & "[Docdate] [datetime] NULL,"
            str = str & "[Storecode] [varchar](50) NULL,"
            str = str & "[Storedesc] [varchar](50) NULL,"
            str = str & "	[Itemcode] [varchar](50) NULL,"
            str = str & "	[Itemname] [varchar](50) NULL,"
            str = str & "	[Uom] [varchar](50) NULL,"
            str = str & "	[batchno] [varchar](50) NULL,"

            str = str & "	[Stockinhand] [numeric](18, 3) NULL,"
            str = str & "	[Physicalstock] [numeric](18, 3) NULL,"
            str = str & "	[Adjustedstock] [numeric](18, 3) NULL,"
            str = str & "	[Rate] [numeric](18, 2) NULL,"
            str = str & "	[Amount] [numeric](18, 2) NULL,"
            str = str & "	[Void] [char](2) NULL,"
            str = str & "	[Adduser] [varchar](50) NULL,"
            str = str & "	[Adddate] [datetime] NULL,"
            str = str & "	[Updateuser] [varchar](50) NULL,"
            str = str & "	[Updatetime] [datetime] NULL,"
            str = str & "	[Remarks] [varchar](500) NULL,"
            str = str & "		[voiduser] [varchar](50) NULL,"
            str = str & "	 [voidtime] [datetime] NULL "

            str = str & " )"
            gconnection.dataOperation1(6, str, "STOCKADJUSTDETAILS")

        End If

        str = "select * from sysobjects where name='OPENINGSTOCK' and xtype='U'"
        gconnection.getDataSet(str, "OPENINGSTOCK")
        If gdataset.Tables("OPENINGSTOCK").Rows.Count > 0 Then

        Else

            str = "    CREATE TABLE [dbo].[OPENINGSTOCK]("
            str = str & "[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "[Itemcode] [varchar](50) NULL,"
            str = str & "[ItemName] [varchar](50) NULL,"
            str = str & "	[mainOpstock] [float] NULL,"
            str = str & "	[mainclstock] [float] NULL,"
            str = str & "	[bar1opstock] [float] NULL,"
            str = str & "[bar1clstock] [float] NULL,"
            str = str & "[bar2opstock] [float] NULL,"
            str = str & "	[bar2clstock] [float] NULL,"
            str = str & "	[bar3opstock] [float] NULL,"
            str = str & "	[bar3clstock] [float] NULL,"
            str = str & "	[convuom] [varchar](50) NULL,"
            str = str & "	[stockuom] [varchar](50) NULL,"
            str = str & "	[lowratio] [numeric](18, 0) NULL,"
            str = str & "	[highratio] [numeric](18, 0) NULL,"
            str = str & "	[doublevalue] [float] NULL,"
            str = str & "	[bar1doublevalue] [float] NULL,"
            str = str & "	[bar2doublevalue] [float] NULL,"
            str = str & "	[bar3doublevalue] [float] NULL,"
            str = str & "	[avgrate] [float] NULL,"
            str = str & "	[avgvalue] [float] NULL,"
            str = str & "	[Adduser] [varchar](50) NULL,"
            str = str & "	[Adddate] [datetime] NULL"
            str = str & ") "
            gconnection.dataOperation1(6, str, "item")

        End If


        str = "select * from sysobjects where name='MonthClose' and xtype='U'"
        gconnection.getDataSet(str, "MonthClose")
        If gdataset.Tables("MonthClose").Rows.Count > 0 Then

        Else

            str = "   CREATE TABLE [dbo].[MonthClose]("
            str = str & "[Monthno] [numeric](9, 2) NULL,"
            str = str & "[Posclose] [varchar](1) NULL,"
            str = str & "[Globalclose] [varchar](1) NULL,"
            str = str & "[invclose] [varchar](20) NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "item")

        End If

        str = "select * from sysobjects where name='ModuleMaster' and xtype='U'"
        gconnection.getDataSet(str, "ModuleMaster")
        If gdataset.Tables("ModuleMaster").Rows.Count > 0 Then

        Else

            str = "   CREATE TABLE [dbo].[ModuleMaster]("
            str = str & "	[PackageName] [varchar](50) NULL,"
            str = str & "	[Mainmoduleid] [varchar](50) NULL,"
            str = str & "	[MainModulename] [varchar](50) NULL,"
            str = str & "	[SubModuleid] [varchar](50) NULL,"
            str = str & "	[SubModulename] [varchar](100) NULL,"
            str = str & "	[SsubModuleid] [varchar](50) NULL,"
            str = str & "	[rowid] [numeric](16, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "	[SsubModuleName] [varchar](50) NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "item")

        End If

        str = "select * from sysobjects where name='Matching' and xtype='U'"
        gconnection.getDataSet(str, "Matching")
        If gdataset.Tables("Matching").Rows.Count > 0 Then

        Else

            str = "   CREATE TABLE [dbo].[Matching]("
            str = str & " [VoucherNo] [varchar](25) NULL,"
            str = str & "[VoucherType] [varchar](20) NULL,"
            str = str & "[VoucherCategory] [varchar](25) NULL,"
            str = str & "[VoucherDate] [datetime] NULL,"
            str = str & "[AccountCode] [varchar](20) NULL,"
            str = str & "[SlCode] [varchar](20) NULL,"
            str = str & "[Amount] [numeric](10, 0) NULL,"
            str = str & "[AvoucherNo] [varchar](20) NULL,"
            str = str & "	[AvoucherDate] [datetime] NULL,"
            str = str & "	[AvOucherType] [varchar](30) NULL,"
            str = str & "[AdjustedAmount] [numeric](10, 2) NULL,"
            str = str & "[AvoucherCategory] [varchar](20) NULL,"
            str = str & "[OutRowId] [numeric](18, 0) NULL,"
            str = str & "[Ref_No] [varchar](20) NULL,"
            str = str & "[Ref_dt] [datetime] NULL,"
            str = str & "[Ref_amt] [numeric](10, 2) NULL,"
            str = str & "[GridRowNo] [numeric](10, 0) NULL,"
            str = str & "[batchno] [numeric](9, 0) NULL,"
            str = str & "[Flag] [varchar](1) NULL,"
            str = str & "[AvoucherAmt] [numeric](10, 2) NULL,"
            str = str & "	[OnAccVNo] [varchar](25) NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "item")

        End If

        str = "select * from sysobjects where name='Journalentry' and xtype='U'"
        gconnection.getDataSet(str, "Journalentry")
        If gdataset.Tables("Journalentry").Rows.Count > 0 Then

        Else

            str = "    CREATE TABLE [dbo].[Journalentry]("
            str = str & "[Rowid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "[VoucherNo] [varchar](50) NULL,"
            str = str & "	[VoucherDate] [datetime] NULL,"
            str = str & "	[VoucherCategory] [varchar](50) NULL,"
            str = str & "	[VoucherType] [varchar](50) NULL,"
            str = str & "	[CashBank] [varchar](50) NULL,"
            str = str & "	[AccountCode] [varchar](50) NULL,"
            str = str & "	[AccountcodeDesc] [varchar](100) NULL,"
            str = str & "	[SLCode] [varchar](10) NULL,"
            str = str & "	[SLDesc] [varchar](50) NULL,"
            str = str & "	[CostCenterCode] [varchar](50) NULL,"
            str = str & "	[CostCenterDesc] [varchar](50) NULL,"
            str = str & "	[CreditDebit] [varchar](10) NULL,"
            str = str & "	[Amount] [numeric](15, 2) NULL,"
            str = str & "	[Description] [varchar](300) NULL,"
            str = str & "	[InstrumentDate] [datetime] NULL,"
            str = str & "	[InstrumentType] [varchar](20) NULL,"
            str = str & "	[Instrumentno] [varchar](25) NULL,"
            str = str & "	[BankName] [varchar](50) NULL,"
            str = str & "	[BankPlace] [varchar](50) NULL,"
            str = str & "	[OppAccountCode] [varchar](50) NULL,"
            str = str & "	[Void] [varchar](1) NULL,"
            str = str & "	[ReceiptNo] [numeric](18, 0) NULL,"
            str = str & "	[Party_Name] [varchar](100) NULL,"
            str = str & "	[ReceivedFrom] [varchar](50) NULL,"
            str = str & "	[ReceivedDate] [datetime] NULL,"
            str = str & "[Ref_No] [varchar](50) NULL,"
            str = str & "[Ref_Date] [datetime] NULL,"
            str = str & "	[Roomno] [numeric](5, 0) NULL,"
            str = str & "	[SectionCode] [varchar](10) NULL,"
            str = str & "	[TDSPerc] [varchar](20) NULL,"
            str = str & "	[Termination] [varchar](1) NULL,"
            str = str & "	[PartyName] [varchar](50) NULL,"
            str = str & "	[MICR] [varchar](50) NULL,"
            str = str & "	[TaxType] [varchar](20) NULL,"
            str = str & "	[TaxCode] [varchar](20) NULL,"
            str = str & "	[TaxPerc] [numeric](7, 2) NULL,"
            str = str & "	[Batchno] [numeric](10, 0) NULL,"
            str = str & "	[AdduserId] [varchar](50) NULL,"
            str = str & "	[AddDateTime] [datetime] NULL,"
            str = str & "	[FreezeUserId] [varchar](50) NULL,"
            str = str & "[FreezeDateTime] [datetime] NULL,"
            str = str & "[QUATERDATE] [varchar](50) NULL,"
            str = str & "	[RealisedDate] [datetime] NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "item")

        End If

        str = "select * from sysobjects where name='CONSUMERMASTER' and xtype='U'"
        gconnection.getDataSet(str, "CONSUMERMASTER")
        If gdataset.Tables("CONSUMERMASTER").Rows.Count > 0 Then

        Else

            str = "    CREATE TABLE [dbo].[CONSUMERMASTER]("
            str = str & "	[CONNO] [varchar](10) NULL,"
            str = str & "	[CONNAME] [varchar](35) NULL,"
            str = str & "	[CONTYPE] [varchar](15) NULL,"
            str = str & "	[UPDATEUSER] [varchar](20) NULL,"
            str = str & "	[UPDATETIME] [datetime] NULL,"
            str = str & "	[voiduser] [varchar](20) NULL,"
            str = str & "[voiddate] [datetime] NULL,"
            str = str & "[AUTHTHORISEUSER1] [varchar](20) NULL,"
            str = str & "[AUTHTHORISEUSER2] [varchar](20) NULL,"
            str = str & "[AUTHORISED] [varchar](20) NULL,"
            str = str & "[AUTHORISE_LEVEL1] [varchar](20) NULL,"
            str = str & "[AUTHORISE_USER1] [varchar](20) NULL,"
            str = str & "[AUTHORISE_DATE1] [datetime] NULL,"
            str = str & "[AUTHORISE_LEVEL2] [varchar](20) NULL,"
            str = str & "[AUTHORISE_USER2] [varchar](20) NULL,"
            str = str & "[AUTHORISE_DATE2] [datetime] NULL,"
            str = str & "[AUTHORISE_LEVEL3] [varchar](20) NULL,"
            str = str & "	[AUTHORISE_USER3] [varchar](20) NULL,"
            str = str & "	[AUTHORISE_DATE3] [datetime] NULL,"
            str = str & "[AUTHTHORISEUSER3] [varchar](20) NULL,"
            str = str & "[FREEZE] [char](1) NULL,"
            str = str & "[ADDUSER] [varchar](20) NULL,"
            str = str & "[ADDDATE] [datetime] NULL,"
            str = str & "[conid] [varchar](10) NULL"
            str = str & ") "

            gconnection.dataOperation1(6, str, "item")

        End If


        str = "select * from sysobjects where name='CP_inventoryitemmaster_single' and xtype='P'"
        gconnection.getDataSet(str, "CP_inventoryitemmaster_single")
        If gdataset.Tables("CP_inventoryitemmaster_single").Rows.Count > 0 Then

        Else

            str = " CREATE PROCEDURE [dbo].[CP_inventoryitemmaster_single] (@Fromstorecode as Varchar(50),@ToStoreCode as varchar(50))"
            str = str & " As "
            str = str & "      Begin "

            str = str & " insert into inventoryitemmaster (itemcode,itemname,alias,groupcode,groupname,subgroupcode,subgroupname,subsubgroupcode,subsubgroupname,reorderlevel,minqty,maxqty,purchaserate,salerate,stockuom,receiveuom,saleuom,opstock,opvalue,Freeze,Adduser,Adddate,STORECODE,abc,categorY,TAXREBATE,baserate,INVITMTransQty,INVITMTransValue,INVITMStockUOM,INVITMTRANSRATE,Profitper)"
            str = str & "	select "
            str = str & "	itemcode,itemname,alias,groupcode,groupname,subgroupcode,subgroupname,subsubgroupcode,subsubgroupname,reorderlevel,minqty,maxqty,purchaserate,salerate,stockuom,receiveuom,saleuom,0,0,Freeze,Adduser,Adddate,"
            str = str & " @ToStoreCode,abc,category,TAXREBATE,baserate,INVITMTransQty,INVITMTransValue,INVITMStockUOM,INVITMTRANSRATE,Profitper "
            str = str & " from inventoryitemmaster where storecode=@Fromstorecode "
            str = str & "	and @ToStoreCode+itemcode not in (select storecode+itemcode from inventoryitemmaster where storecode+itemcode=@ToStoreCode+itemcode) "



            str = str & "    End"
            gconnection.dataOperation1(6, str, "item")

        End If

        str = "select * from sysobjects where name='CLOSINGVLAUE' and xtype='IF'"
        gconnection.getDataSet(str, "CLOSINGVLAUE")
        If gdataset.Tables("CLOSINGVLAUE").Rows.Count > 0 Then
            str = "   ALTER FUNCTION [dbo].[CLOSINGVLAUE](@TODATE AS DATEtime,@PITEMCODE as VARCHAR(15),@STORECODE as VARCHAR(10),"
            str = str & "  @UOM as VARCHAR(20))    "
            str = str & " RETURNS TABLE "
            str = str & " AS        "
            str = str & "  Return"

            str = str & " select @UOM AS UOM,OPSTOCK*(select Convvalue from INVENTORY_TRANSCONVERSION where TRANSUOM=@UOM and  "
            str = str & " BASEUOM=INVENTORYITEMMASTER.STOCKUOM) AS QTY,opvalue,CONVERT(DATETIME,'01-04-2014',103) AS DATE1,'opening' AS  "
            str = str & " TRANSTYPE,'1' AS MF FROM INVENTORYITEMMASTER WHERE itemcode=@PITEMCODE and STORECODE=@STORECODE  and isnull(freeze,'') <>'Y'"
            str = str & "  UNION ALL "
            str = str & " select @UOM AS UOM,Qty * (select Convvalue from INVENTORY_TRANSCONVERSION where TRANSUOM=@uom and BASEUOM=grn_details.uom)  "
            str = str & " AS QTY , Amount,Grndate AS DATE1,grntype AS TRANSTYPE,'1' AS MF from GRN_DETAILS WHERE itemcode=@PITEMCODE and  "
            str = str & " STORECODE=@STORECODE AND cast(convert(varchar(11),Grndate,106) as datetime)<=cast(convert(varchar(11),@todate,106) as datetime) and grntype='GRN'  and isnull(voiditem,'') <>'Y'"
            str = str & " UNION ALL "
            str = str & " select @UOM AS UOM,Qty * (select Convvalue from INVENTORY_TRANSCONVERSION where TRANSUOM=@uom and BASEUOM=grn_details.uom)   "
            str = str & " AS QTY , Amount,Grndate AS DATE1,grntype AS TRANSTYPE,'-1' AS MF from GRN_DETAILS WHERE itemcode=@PITEMCODE and   "
            str = str & " STORECODE=@STORECODE AND cast(convert(varchar(11),Grndate,106) as datetime)<=cast(convert(varchar(11),@todate,106) as datetime) and grntype='PRN'  and isnull(voiditem,'') <>'Y'  "
            str = str & " UNION ALL "
            str = str & " select @UOM AS UOM,Qty * (select Convvalue from INVENTORY_TRANSCONVERSION where TRANSUOM=@uom and BASEUOM=STOCKDMGDETAIL.uom)   "
            str = str & " AS QTY , Amount,Docdate AS DATE1,'DAMAGE' AS TRANSTYPE,'-1' AS MF from STOCKDMGDETAIL WHERE   itemcode=@PITEMCODE and "
            str = str & " STORECODE=@STORECODE AND cast(convert(varchar(11),Docdate,106) as datetime)<=cast(convert(varchar(11),@todate,106) as datetime)   and isnull(void,'') <>'Y'"
            str = str & " UNION ALL "
            str = str & " select @UOM AS UOM,Qty * (select Convvalue from INVENTORY_TRANSCONVERSION where TRANSUOM=@uom and   BASEUOM=STOCKISSUEDETAIL.uom) "
            str = str & " AS QTY , Amount,DOCDATE AS DATE1,'ISSUE' AS TRANSTYPE,'-1' AS MF from STOCKISSUEDETAIL   "
            str = str & " WHERE itemcode=@PITEMCODE and Storelocationcode=@STORECODE AND  cast(convert(varchar(11),Docdate,106) as datetime)<=cast(convert(varchar(11),@todate,106) as datetime)   and isnull(void,'') <>'Y'  "
            str = str & " UNION ALL "
            str = str & " select @UOM AS UOM,Adjustedstock * (select Convvalue from INVENTORY_TRANSCONVERSION where TRANSUOM=@uom and   "
            str = str & " BASEUOM=STOCKADJUSTDETAILS.uom) AS QTY , Amount,DOCDATE AS DATE1,'aDJUSTMENT' AS TRANSTYPE,'1' AS MF from STOCKADJUSTDETAILS   "
            str = str & " WHERE itemcode=@PITEMCODE and Storelocationcode=@STORECODE AND  "
            str = str & " cast(convert(varchar(11),Docdate,106) as datetime)<=cast(convert(varchar(11),@todate,106) as datetime)   and isnull(void,'') <>'Y'   "
            str = str & " UNION ALL "
            str = str & " select @UOM AS UOM,QTY * (select Convvalue from INVENTORY_TRANSCONVERSION where TRANSUOM=@uom and   "
            str = str & " BASEUOM=STOCKTRANSFERDETAIL.uom) AS QTY , Amount,DOCDATE AS DATE1,'TRANSFER' AS TRANSTYPE,'-1' AS MF from   "
            str = str & " STOCKTRANSFERDETAIL WHERE itemcode=@PITEMCODE and Fromstorecode=@STORECODE AND  "
            str = str & " cast(convert(varchar(11),Docdate,106) as datetime)<=cast(convert(varchar(11),@todate,106) as datetime)    and isnull(void,'') <>'Y'   "
            str = str & " union ALL "
            str = str & " select @UOM AS UOM,Qty * (select Convvalue from INVENTORY_TRANSCONVERSION where TRANSUOM=@uom and   "
            str = str & " BASEUOM=STOCKISSUEDETAIL.uom) AS QTY , Amount,DOCDATE AS DATE1,'RECEIEVE' AS TRANSTYPE,'1' AS MF from   "
            str = str & " STOCKISSUEDETAIL WHERE itemcode=@PITEMCODE and Opstorelocationcode=@STORECODE AND  cast(convert(varchar(11),Docdate,106) as "
            str = str & " datetime)<=cast(convert(varchar(11),@todate,106) as datetime)    and isnull(void,'') <>'Y'"
            str = str & " UNION ALL "
            str = str & " select @UOM AS UOM,QTY * (select Convvalue from INVENTORY_TRANSCONVERSION where "
            str = str & " TRANSUOM=@uom and   BASEUOM=STOCKTRANSFERDETAIL.uom) AS QTY , Amount,DOCDATE AS DATE1,'TRANSFER' AS TRANSTYPE,'1' AS MF   "
            str = str & " from STOCKTRANSFERDETAIL WHERE itemcode=@PITEMCODE and Tostorecode=@STORECODE AND  cast(convert(varchar(11),Docdate,106) as "
            str = str & " datetime)<=cast(convert(varchar(11),@todate,106) as datetime)  and isnull(void,'') <>'Y'  "
            str = str & " UNION ALL "
            str = str & " select @UOM AS UOM,sum(QTY) * (select Convvalue from INVENTORY_TRANSCONVERSION where TRANSUOM=@uom and   "
            str = str & " BASEUOM=SUBSTORECONSUMPTIONDETAIL.uom) AS QTY ,"
            str = str & " sum(Amount) as amount,DOCDATE AS DATE1,'CONSUMPTION' AS TRANSTYPE,'-1' AS MF   "
            str = str & " from SUBSTORECONSUMPTIONDETAIL WHERE itemcode=@PITEMCODE and Storelocationcode=@STORECODE AND  "
            str = str & " cast(convert(varchar(11),Docdate,106) as datetime)<=cast(convert(varchar(11),@todate,106) as datetime) "
            str = str & " and ISNULL(Void,'')<>'Y' group by docdate,SUBSTORECONSUMPTIONDETAIL.uom"
            gconnection.dataOperation1(6, str, "item")

        Else

            str = "  CREATE FUNCTION [dbo].[CLOSINGVLAUE](@TODATE AS DATETIME,@PITEMCODE as VARCHAR(15),@STORECODE as VARCHAR(10),@UOM as VARCHAR(20)) "

            str = str & "  RETURNS TABLE "

            str = str & " AS "
            str = str & "       Return "
            str = str & "select @UOM AS UOM,OPSTOCK*(select Convvalue from INVENTORY_TRANSCONVERSION where TRANSUOM=@UOM and BASEUOM=INVENTORYITEMMASTER.STOCKUOM) AS QTY,opvalue,CONVERT(DATETIME,'01-04-2014',103) AS DATE1,'opening' AS TRANSTYPE,'1' AS MF FROM INVENTORYITEMMASTER WHERE itemcode=@PITEMCODE and STORECODE=@STORECODE"
            str = str & " UNION "
            str = str & " select @UOM AS UOM,Qty * (select Convvalue from INVENTORY_TRANSCONVERSION where TRANSUOM=@uom and BASEUOM=grn_details.uom) AS QTY , Amount,Grndate AS DATE1,grntype AS TRANSTYPE,'1' AS MF from GRN_DETAILS WHERE itemcode=@PITEMCODE and STORECODE=@STORECODE AND Grndate<=@TODATE"
            str = str & " UNION "
            str = str & " select @UOM AS UOM,Qty * (select Convvalue from INVENTORY_TRANSCONVERSION where TRANSUOM=@uom and BASEUOM=STOCKDMGDETAIL.uom) AS QTY , Amount,Docdate AS DATE1,'DAMAGE' AS TRANSTYPE,'-1' AS MF from STOCKDMGDETAIL WHERE itemcode=@PITEMCODE and STORECODE=@STORECODE AND Docdate<=@TODATE"
            str = str & " UNION "
            str = str & " select @UOM AS UOM,Qty * (select Convvalue from INVENTORY_TRANSCONVERSION where TRANSUOM=@uom and BASEUOM=STOCKISSUEDETAIL.uom) AS QTY , Amount,DOCDATE AS DATE1,'ISSUE' AS TRANSTYPE,'-1' AS MF from STOCKISSUEDETAIL WHERE itemcode=@PITEMCODE and Storelocationcode=@STORECODE AND Docdate<=@TODATE"
            str = str & "  UNION "
            str = str & " select @UOM AS UOM,Adjustedstock * (select Convvalue from INVENTORY_TRANSCONVERSION where TRANSUOM=@uom and BASEUOM=STOCKADJUSTDETAILS.uom) AS QTY , Amount,DOCDATE AS DATE1,'aDJUSTMENT' AS TRANSTYPE,'1' AS MF from STOCKADJUSTDETAILS WHERE itemcode=@PITEMCODE and Storelocationcode=@STORECODE AND Docdate<=@TODATE"
            gconnection.dataOperation1(6, str, "item")

        End If

        str = "select * from sysobjects where name='VW_INV_STKINOUTBILL' and xtype='V'"
        gconnection.getDataSet(str, "VW_INV_STKINOUTBILL")
        If gdataset.Tables("VW_INV_STKINOUTBILL").Rows.Count > 0 Then

        Else

            str = "  CREATE  VIEW [dbo].[VW_INV_STKINOUTBILL] AS  SELECT ISNULL(H.DOCDETAILS,'') AS DOCDETAILS,H.DOCDATE,ISNULL(H.FROMSTORECODE,'') AS FROMSTORECODE, ISNULL(H.FROMSTOREDESC,'') AS FROMSTOREDESC,ISNULL(H.TOSTORECODE,'') AS TOSTORECODE, ISNULL(H.TOSTOREDESC,'') AS TOSTOREDESC,ISNULL(H.CHALLENNO,'') AS CHALLENNO,H.CHALLENDATE AS CHALLENDATE, ISNULL(D.ITEMCODE,'') AS ITEMCODE,ISNULL(D.ITEMNAME,'') AS ITEMNAME,ISNULL(D.UOM,'') AS UOM,ISNULL(D.QTY,0) AS QTY, ISNULL(D.RATE,0) AS RATE,ISNULL(D.AMOUNT,0) AS AMOUNT,ISNULL(REMARKS,'') AS REMARKS,ISNULL(H.UPDFOOTER,'')  AS UPDFOOTER ,ISNULL(H.UPDSIGN,'') AS UPDSIGN , (case  ISNULL(h.UPDATETIME,'')  when '' then ISNULL(h.ADDDATE,'') else ISNULL(h.UPDATETIME,'') end) as ADDDATE    FROM STOCKINOUTHEADER AS H INNER JOIN STOCKINOUTDETAIL AS D ON H.DOCDETAILS = D.DOCDETAILS"
            gconnection.dataOperation1(6, str, "item")

        End If
        str = "select * from sysobjects where name='VW_INV_STKDMGBILL' and xtype='V'"
        gconnection.getDataSet(str, "VW_INV_STKDMGBILL")
        If gdataset.Tables("VW_INV_STKDMGBILL").Rows.Count > 0 Then

        Else

            str = "  CREATE  VIEW [dbo].[VW_INV_STKDMGBILL]  AS    SELECT ISNULL(H.DOCDETAILS,'') AS DOCDETAILS,H.DOCDATE,ISNULL(H.FROMSTORECODE,'') AS FROMSTORECODE, ISNULL(H.FROMSTOREDESC,'') AS FROMSTOREDESC,ISNULL(H.TOSTORECODE,'') AS TOSTORECODE, ISNULL(H.TOSTOREDESC,'') AS TOSTOREDESC,ISNULL(H.CHALLENNO,'') AS CHALLENNO,H.CHALLENDATE AS CHALLENDATE, ISNULL(D.ITEMCODE,'') AS ITEMCODE,ISNULL(D.ITEMNAME,'') AS ITEMNAME,ISNULL(D.UOM,'') AS UOM,ISNULL(D.QTY,0) AS QTY, ISNULL(D.RATE,0) AS RATE,ISNULL(D.AMOUNT,0) AS AMOUNT,ISNULL(REMARKS,'') AS REMARKS,ISNULL(H.UPDFOOTER,'')  AS UPDFOOTER ,ISNULL(H.UPDSIGN,'') AS UPDSIGN, (case  ISNULL(h.UPDATETIME,'')  when '' then ISNULL(h.ADDDATE,'') else ISNULL(h.UPDATETIME,'') end) as ADDDATE    FROM STOCKDMGHEADER AS H INNER JOIN STOCKDMGDETAIL AS D ON H.DOCDETAILS = D.DOCDETAILS"
            gconnection.dataOperation1(6, str, "item")

        End If
        str = "select * from sysobjects where name='VIEWSTOCKREGISTER' and xtype='V'"
        gconnection.getDataSet(str, "VIEWSTOCKREGISTER")
        If gdataset.Tables("VIEWSTOCKREGISTER").Rows.Count > 0 Then

        Else

            str = " CREATE  VIEW [dbo].[VIEWSTOCKREGISTER]  "
            str = str & " AS "
            str = str & " SELECT ISNULL(H.FROMSTOREDESC,'') AS FROMSTOREDESC,ISNULL(H.TOSTOREDESC,'') AS TOSTOREDESC,ISNULL(H.DOCTYPE,'') AS DOCTYPE,  "
            str = str & " ISNULL(H.CHALLENNO,'') AS CHALLENNO,H.CHALLENDATE AS CHALLENDATE,ISNULL(H.DOCDETAILS,'') AS DOCDETAILS,  "
            str = str & " H.DOCDATE AS DOCDATE,ISNULL(D.ITEMCODE,'') AS ITEMCODE,ISNULL(D.ITEMNAME,'') AS ITEMNAME,ISNULL(D.UOM,'') AS UOM,  "
            str = str & " ISNULL(SUM(D.QTY),0) AS QTY,ISNULL(D.RATE,0) AS RATE,SUM(D.QTY) * ISNULL(D.RATE,0) AS AMOUNT  "
            str = str & " FROM STOCKTRANSFERHEADER AS H INNER JOIN STOCKTRANSFERDETAIL AS D ON H.DOCDETAILS = D.DOCDETAILS AND  "
            str = str & " H.DOCDATE = D.DOCDATE AND ISNULL(D.VOID,'')<>'Y' "
            ' str = str & " --WHERE ISNULL(H.DOCTYPE,'') <> 'RET'  "
            str = str & " GROUP BY H.DOCDETAILS,H.DOCDATE,D.ITEMNAME,D.ITEMCODE,H.FROMSTOREDESC,H.TOSTOREDESC,H.CHALLENNO,H.CHALLENDATE,D.UOM,D.RATE,H.DOCTYPE  "
            'str = str & "--ORDER BY DOCDETAILS,DOCDATE"

            gconnection.dataOperation1(6, str, "item")
        End If
        str = "select * from sysobjects where name='VIEWSTOCKDMGREGISTER' and xtype='V'"
        gconnection.getDataSet(str, "VIEWSTOCKDMGREGISTER")
        If gdataset.Tables("VIEWSTOCKDMGREGISTER").Rows.Count > 0 Then

        Else

            str = "  CREATE  VIEW [dbo].[VIEWSTOCKDMGREGISTER]"
            str = str & " AS"
            str = str & " SELECT ISNULL(H.STOREDESC,'') AS STOREDESC,ISNULL(H.FROMSTOREDESC,'') AS FROMSTOREDESC,ISNULL(H.TOSTOREDESC,'') AS TOSTOREDESC,ISNULL(H.DOCTYPE,'') AS DOCTYPE,"
            str = str & " ISNULL(H.CHALLENNO,'') AS CHALLENNO,H.CHALLENDATE AS CHALLENDATE,ISNULL(H.DOCDETAILS,'') AS DOCDETAILS,"
            str = str & " H.DOCDATE AS DOCDATE,ISNULL(D.ITEMCODE,'') AS ITEMCODE,ISNULL(D.ITEMNAME,'') AS ITEMNAME,ISNULL(D.UOM,'') AS UOM,"
            str = str & " ISNULL(SUM(D.QTY),0) AS QTY,ISNULL(D.RATE,0) AS RATE,SUM(D.QTY) * ISNULL(D.RATE,0) AS AMOUNT"
            str = str & " FROM STOCKDMGHEADER AS H INNER JOIN STOCKDMGDETAIL AS D ON H.DOCDETAILS = D.DOCDETAILS AND"
            str = str & " H.DOCDATE = D.DOCDATE"
            ' str = str & " "
            str = str & " GROUP BY H.DOCDETAILS,H.DOCDATE,D.ITEMNAME,D.ITEMCODE,H.STOREDESC,H.FROMSTOREDESC,H.TOSTOREDESC,H.CHALLENNO,H.CHALLENDATE,D.UOM,D.RATE,H.DOCTYPE"
            gconnection.dataOperation1(6, str, "item")

        End If
        str = "select * from sysobjects where name='VIEWSTOCKADJUSTMENT' and xtype='v'"
        gconnection.getDataSet(str, "VIEWSTOCKADJUSTMENT")
        If gdataset.Tables("VIEWSTOCKADJUSTMENT").Rows.Count > 0 Then

        Else

            str = "   CREATE       VIEW [dbo].[VIEWSTOCKADJUSTMENT]  "
            str = str & " AS "
            str = str & " SELECT ISNULL(H.STORELOCATIONDESC,'') AS STORELOCATIONDESC,  "
            str = str & " ISNULL(H.DOCDETAILS,'') AS DOCDETAILS,H.DOCDATE AS DOCDATE,  "
            str = str & " ISNULL(D.ITEMCODE,'') AS ITEMCODE,ISNULL(D.ITEMNAME,'') AS ITEMNAME,ISNULL(D.UOM,'') AS UOM,  "
            str = str & " ISNULL(D.STOCKINHAND,0) AS STOCKINHAND,ISNULL(D.PHYSICALSTOCK,0) AS PHYSICALSTOCK,  "
            str = str & " ISNULL(D.STOCKINHAND,0)*ISNULL(D.RATE,0) AS STOCKINHANDAMT,ISNULL(D.PHYSICALSTOCK,0)*ISNULL(D.RATE,0) AS PHYSICALSTOCKAMT,  "
            str = str & " ISNULL(H.VOID,'') AS VOID,  "
            str = str & " ISNULL(D.ADJUSTEDSTOCK,0) AS ADJUSTEDSTOCK,ISNULL(D.RATE,0) AS RATE,ISNULL(D.AMOUNT,0) AS AMOUNT,  "
            str = str & " CASE WHEN ISNULL(D.ADJUSTEDSTOCK,0)>=0 THEN  ISNULL(D.ADJUSTEDSTOCK,0) ELSE 0 END AS PLUSSTOCK,CASE WHEN ISNULL(D.AMOUNT,0)>=0 THEN ISNULL(D.AMOUNT,0) ELSE 0 END AS PLUSAMOUNT,  "
            str = str & " CASE WHEN ISNULL(D.ADJUSTEDSTOCK,0)<0 THEN  ISNULL(D.ADJUSTEDSTOCK,0)*-1 ELSE 0 END AS MINUSSTOCK,CASE WHEN ISNULL(D.AMOUNT,0)<0 THEN ISNULL(D.AMOUNT,0)*-1 ELSE 0 END AS MINUSAMOUNT  "
            str = str & " FROM STOCKADJUSTHEADER AS H INNER JOIN STOCKADJUSTDETAILS AS D ON H.DOCDETAILS = D.DOCDETAILS AND  "
            str = str & " H.DOCDATE = D.DOCDATE  AND H.TTYPE=D.TTYPE WHERE H.TTYPE='A' AND ISNULL(H.VOID,'')<>'Y'  "
            str = str & " GROUP BY H.DOCDETAILS,H.DOCDATE,D.ITEMNAME,D.ITEMCODE,H.STORELOCATIONDESC,D.UOM,D.RATE,D.STOCKINHAND,  "
            str = str & " D.PHYSICALSTOCK, D.ADJUSTEDSTOCK, D.AMOUNT, H.VOID"
            gconnection.dataOperation1(6, str, "item")

        End If


        str = "select * from sysobjects where name='VIEWPURCHASEREGISTERSUMMARY' and xtype='v'"
        gconnection.getDataSet(str, "VIEWPURCHASEREGISTERSUMMARY")
        If gdataset.Tables("VIEWPURCHASEREGISTERSUMMARY").Rows.Count > 0 Then

        Else

            str = "    CREATE  VIEW [dbo].[VIEWPURCHASEREGISTERSUMMARY]  "
            str = str & " AS "
            str = str & " SELECT     ISNULL(H.Grndetails, '') AS GRNDETAILS, H.Grndate, ISNULL(H.Suppliercode, '') AS SUPPLIERCODE, ISNULL(H.Suppliername, '') AS SUPPLIERNAME,   "
            str = str & "                      ISNULL(H.Glaccountcode, '') AS GLACCOUNTCODE, ISNULL(H.Glaccountname, '') AS GLACCOUNTNAME, ISNULL(H.Totalamount, 0) AS TOTALAMOUNT,   "
            str = str & "                     ISNULL(H.VATamount, 0) AS VATAMOUNT, ISNULL(H.Surchargeamt, 0) AS SURCHARGEAMT, ISNULL(H.Discount, 0) AS DISCOUNTAMOUNT,   "
            str = str & "                     ISNULL(H.Billamount, 0) AS BILLAMOUNT, ISNULL(D.Itemcode, '') AS ITEMCODE, ISNULL(D.Itemname, '') AS ITEMNAME, ISNULL(D.UOM, '') AS UOM,   "
            str = str & "                    ISNULL(D.Qty, 0) AS QTY, ISNULL(D.Rate, 0) AS RATE, (ISNULL(D.Discount, 0) + isnull(d.odiscount,0)) AS DISCOUNT, ISNULL(H.storedesc, '') AS STOREDESC,   "
            str = str & "                   ISNULL(D.Amount, 0) AS AMOUNT, D.Adddate, ISNULL(M.AvoucherNo, '') AS AVOUCHERNO, ISNULL(M.AvoucherDate, '') AS AVOUCHERDATE,   "
            str = str & "                   ISNULL(M.AdjustedAmount, 0) AS ADJUSTEDAMOUNT, H.Discount AS Expr1, H.OverallDiscount, H.Surchargeamt AS Expr2, H.VATamount AS Expr3,   "
            str = str & "                   H.Totalamount AS Expr4, D.Discount AS Expr5, D.Amount AS Expr6, D.taxamount,isnull(d.odiscount,0) as ODiscount, D.OTHCHARGE, D.storedesc AS Expr7,   "
            str = str & "                  H.Billamount AS Expr8, H.Supplierinvno, H.Supplierdate, H.POno,H.GRNTYPE  "
            str = str & " FROM         dbo.GRN_HEADER H INNER JOIN  "
            str = str & "                   dbo.GRN_DETAILS D ON D.Grndetails = H.Grndetails LEFT OUTER JOIN  "
            str = str & "                   dbo.Matching M ON H.Grndetails = M.VoucherNo"
            gconnection.dataOperation1(6, str, "item")

        End If

        str = "select * from sysobjects where name='ISSUEREGISTER' and xtype='v'"
        gconnection.getDataSet(str, "ISSUEREGISTER")
        If gdataset.Tables("ISSUEREGISTER").Rows.Count > 0 Then

        Else

            str = "  CREATE VIEW [dbo].[ISSUEREGISTER]  "
            str = str & "AS  "
            str = str & "SELECT     ISNULL(D.Opstorelocationname, '') AS LOCATIONNAME, ISNULL(D.Docdetails, '') AS DOCDETAILS, D.Docdate, ISNULL(G.Groupdesc, '')   "
            str = str & "                    AS GROUPDESC, ISNULL(D.Uom, '') AS UOM, ISNULL(D.Qty, 0) AS QTY, ISNULL(D.Rate, 0) AS RATE, ISNULL(D.Amount, 0) AS AMOUNT,   "
            str = str & "                   ISNULL(D.Itemcode, '') AS ITEMCODE, ISNULL(D.Itemname, '') AS ITEMNAME,"
            str = str & "                    ISNULL(D.Storelocationname, '') AS FROMSTORENAME, D.IndentNo  "
            str = str & " FROM         dbo.STOCKISSUEDETAIL D INNER JOIN  "
            str = str & "                      dbo.InventoryGroupMaster G ON G.Groupcode = D.Groupcode  "
            str = str & " WHERE     (ISNULL(D.Void, '') <> 'Y')"
            gconnection.dataOperation1(6, str, "item")

        End If
        str = "select * from sysobjects where name='ISSUEDETAILS' and xtype='v'"
        gconnection.getDataSet(str, "ISSUEDETAILS")
        If gdataset.Tables("ISSUEDETAILS").Rows.Count > 0 Then

        Else


            str = "   CREATE        VIEW [dbo].[ISSUEDETAILS]  "
            str = str & " AS  "
            str = str & " SELECT  ISNULL(D.ITEMCODE,'') AS ITEMCODE,  "
            str = str & "  ISNULL(D.ITEMNAME,'') AS ITEMNAME,  "
            str = str & "  ISNULL(D.OPSTORELOCATIONNAME,'') AS LOCATIONNAME,  "
            str = str & " ISNULL(D.UOM,'') AS UOM,  "
            str = str & " ISNULL(D.QTY,0) AS QTY,  "
            str = str & " ISNULL(D.RATE,0) AS RATE,  "
            str = str & "ISNULL(D.AMOUNT,0) AS AMOUNT,  "
            str = str & "ISNULL(D.VOID,'') AS VOID,  "
            str = str & " ISNULL(G.GROUPDESC,'') AS GROUPDESC,  "
            str = str & " ISNULL(D.DOCDETAILS,'') AS DOCDETAILS,  "
            str = str & " D.DOCDATE AS DOCDATE ,  "
            str = str & " ISNULL(D.STORELOCATIONNAME,'') AS FROMSTORENAME  "
            str = str & " FROM STOCKISSUEDETAIL AS D   "
            str = str & " INNER JOIN INVENTORYGROUPMASTER AS G ON G.GROUPCODE = D.GROUPCODE  "
            str = str & " WHERE ISNULL(D.VOID,'') <> 'Y'"
            gconnection.dataOperation1(6, str, "item")

        End If
        str = "select * from sysobjects where name='INV_VIEW_WAR_LRATE' and xtype='v'"
        gconnection.getDataSet(str, "INV_VIEW_WAR_LRATE")
        If gdataset.Tables("INV_VIEW_WAR_LRATE").Rows.Count > 0 Then

        Else

            str = "  CREATE    VIEW [dbo].[INV_VIEW_WAR_LRATE]"
            str = str & " AS "

            str = str & " SELECT GROUPCODE,'31-MAR-2014' AS GRNDATE,ITEMCODE,isnull(PURCHASERATE,0) as PURCHASERATE,OPSTOCK AS QTY,OPVALUE AS VALUE,TAXREBATE FROM INVENTORYITEMMASTER WHERE ISNULL(OPSTOCK,0)<>0 OR ISNULL(OPVALUE,0)<>0 "

            str = str & "   UNION ALL"

            str = str & " SELECT B.GROUPCODE,A.GRNDATE,A.ITEMCODE,isnull(A.RATE,0) as PURCHASERATE,SUM(A.QTY) AS QTY,CASE WHEN ISNULL(B.TAXREBATE,'Y')='Y' "
            str = str & " THEN ISNULL(SUM(isnull(A.AMOUNT,0)),0)+ISNULL(SUM(isnull(A.TAXAMOUNT,0)),0)+ISNULL(SUM(isnull(A.OTHCHARGE,0)),0)-ISNULL(SUM(isnull(A.DISCOUNT,0)),0) ELSE ISNULL(SUM(isnull(A.AMOUNT,0)),0)+ISNULL(SUM(isnull(A.OTHCHARGE,0)),0)-ISNULL(SUM(isnull(A.DISCOUNT,0)),0) END AS AMOUNT,B.TAXREBATE"
            str = str & " FROM GRN_DETAILS A,INVENTORYITEMMASTER B WHERE A.ITEMCODE =B.ITEMCODE AND A.STORECODE=B.STORECODE AND ISNULL(A.VOIDITEM,'')<>'Y' "
            str = str & " GROUP BY B.GROUPCODE,A.GRNDATE,A.ITEMCODE,B.TAXREBATE,A.RATE"
            gconnection.dataOperation1(6, str, "item")

        End If

        str = "select * from sysobjects where name='INV_VIEW_WAR' and xtype='v'"
        gconnection.getDataSet(str, "INV_VIEW_WAR")
        If gdataset.Tables("INV_VIEW_WAR").Rows.Count > 0 Then

        Else

            str = " CREATE   VIEW [dbo].[INV_VIEW_WAR]"
            str = str & " AS "

            str = str & " SELECT GROUPCODE,'31-MAR-2014' AS GRNDATE,ITEMCODE,OPSTOCK AS QTY,OPVALUE AS VALUE,TAXREBATE FROM INVENTORYITEMMASTER WHERE ISNULL(OPSTOCK,0)<>0 OR ISNULL(OPVALUE,0)<>0  AND STORECODE='MNS'"
            str = str & " UNION ALL "
            str = str & " SELECT B.GROUPCODE,A.GRNDATE,A.ITEMCODE,SUM(A.QTY) AS QTY,CASE WHEN ISNULL(B.TAXREBATE,'Y')='Y' "
            str = str & "THEN ISNULL(SUM(isnull(A.AMOUNT,0)),0)+ISNULL(SUM(isnull(A.TAXAMOUNT,0)),0)+ISNULL(SUM(isnull(A.OTHCHARGE,0)),0)-ISNULL(SUM(isnull(A.DISCOUNT,0)),0) ELSE ISNULL(SUM(isnull(A.AMOUNT,0)),0)+ISNULL(SUM(isnull(A.OTHCHARGE,0)),0)-ISNULL(SUM(isnull(A.DISCOUNT,0)),0) END AS AMOUNT,B.TAXREBATE"
            str = str & " FROM GRN_DETAILS A,INVENTORYITEMMASTER B WHERE A.ITEMCODE =B.ITEMCODE AND A.STORECODE=B.STORECODE AND ISNULL(A.VOIDITEM,'')<>'Y' AND a.STORECODE='MNS' GROUP BY B.GROUPCODE,A.GRNDATE,A.ITEMCODE,B.TAXREBATE"
            gconnection.dataOperation1(6, str, "item")

        End If

        str = "select * from sysobjects where name='Cp_WeightedAverage_Item' and xtype='P'"
        gconnection.getDataSet(str, "Cp_WeightedAverage_Item")
        If gdataset.Tables("Cp_WeightedAverage_Item").Rows.Count > 0 Then





            str = "            ALTER      PROCEDURE [dbo].[Cp_WeightedAverage_Item](@FROMDATE AS datetime, @TODATE AS datetime ,@PITEMCODE as VARCHAR(15),@STORECODE as VARCHAR(10),@USER as VARCHAR(50) ) "
            str = str & " AS"
            str = str & " Declare @ITEMNAME VARCHAR(100),@Itemcode Varchar(50), @CLSSTK AS NUMERIC(18,2),@CLSVALUE AS NUMERIC(18,2),@SQL AS VARCHAR(1000),@GRNDATE AS DATETIME,@DOCDATE AS datetime,@ssql AS VARCHAR(2000),@OPSTOCK AS NUMERIC(18,2),@OPVALUE AS NUMERIC(18,2)"
            str = str & " Declare @TAXREBATE VARCHAR(1),@ISSUERATE AS NUMERIC(18,2),@PURCHASERATE NUMERIC(18,2),@LASTRATE NUMERIC(18,2)"
            str = str & " Declare @NEXTDATE DATETIME, @opt as varchar(1)"

            str = str & " select @opt=rateflag from INVENTORYCATEGORYMASTER where CATEGORYCODE=(select distinct category from inventoryitemmaster where itemcode=@PITEMCODE)"

            str = str & " IF @OPT='B' OR @OPT='W'"
            str = str & " BEGIN"
            str = str & " TRUNCATE TABLE INV_WAR "
            str = str & "	INSERT INTO INV_WAR (TAXREBATE,GROUPCODE,GRNDATE,ITEMCODE,QTY,VALUE) SELECT TAXREBATE,GROUPCODE,GRNDATE,ITEMCODE,QTY,VALUE FROM INV_VIEW_WAR WHERE ITEMCODE=@PITEMCODE "
            str = str & " UPDATE INV_WAR SET NEXTDATE=(SELECT TOP 1 DATEADD(MINUTE,-1,GRNDATE) FROM INV_WAR B WHERE B.ITEMCODE=INV_WAR.ITEMCODE AND B.GRNDATE>INV_WAR.GRNDATE ORDER BY B.GRNDATE) "

            str = str & " UPDATE INV_WAR SET NEXTDATE=GETDATE() WHERE ISNULL(NEXTDATE,'')=''"

            str = str & " Set @SSQL='SELECT TAXREBATE,ITEMCODE,GRNDATE,NEXTDATE FROM INV_WAR where itemcode=' + char(39) + @PITEMCODE  + char(39)+' ORDER BY ITEMCODE,GRNDATE,NEXTDATE '"

            str = str & " set @SQL='DECLARE CURPROC CURSOR FOR ' + @ssql"
            str = str & " exec (@SQL)"
            str = str & " open CURPROC"
            str = str & " Fetch CURPROC into @TAXREBATE,@ITEMCODE,@DOCDATE,@NEXTDATE"
            str = str & " while @@fetch_Status=0"
            str = str & " Begin"

            str = str & " 		UPDATE STOCKISSUEDETAIL SET RATE=0 WHERE ITEMCODE=@ITEMCODE AND DOCDATE>=@DOCDATE"

            str = str & " UPDATE STOCKISSUEDETAIL SET AMOUNT=0 WHERE ITEMCODE=@ITEMCODE AND DOCDATE>=@DOCDATE"

            str = str & " update STOCKDMGDETAIL set Rate=0 WHERE ITEMCODE=@ITEMCODE AND DOCDATE>=@DOCDATE"

            str = str & " update STOCKDMGDETAIL set AMOUNT=0 WHERE ITEMCODE=@ITEMCODE AND DOCDATE>=@DOCDATE"

            str = str & " update STOCKADJUSTDETAILS set Rate=0 WHERE ITEMCODE=@ITEMCODE AND DOCDATE>=@DOCDATE"

            str = str & " update STOCKADJUSTDETAILS set AMOUNT=0 WHERE ITEMCODE=@ITEMCODE AND DOCDATE>=@DOCDATE"


            str = str & " update STOCKADJUSTDETAILS set Rate=0 WHERE ITEMCODE=@ITEMCODE AND DOCDATE>=@DOCDATE"

            str = str & " update STOCKADJUSTDETAILS set AMOUNT=0 WHERE ITEMCODE=@ITEMCODE AND DOCDATE>=@DOCDATE"

            str = str & " update STOCKTRANSFERDETAIL set Rate=0 WHERE ITEMCODE=@ITEMCODE AND DOCDATE>=@DOCDATE"

            str = str & " update STOCKTRANSFERDETAIL set AMOUNT=0 WHERE ITEMCODE=@ITEMCODE AND DOCDATE>=@DOCDATE"

            str = str & " SET @OPSTOCK = 0"
            str = str & " SET @OPSTOCK = (SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM INV_VIEW_WAR WHERE ITEMCODE=@Itemcode AND GRNDATE<= @DOCDATE)"
            str = str & " 		SET @OPVALUE = (SELECT ISNULL(SUM(ISNULL(VALUE,0)),0) FROM INV_VIEW_WAR WHERE ITEMCODE=@Itemcode AND GRNDATE<=@DOCDATE)"
            str = str & " 		SET @CLSSTK =0"
            str = str & " SET @CLSSTK = (SELECT ISNULL(SUM(ISNULL(OPSTOCK,0)),0) FROM INVENTORYITEMMASTER WHERE ITEMCODE = @ITEMCODE AND STORECODE=@STORECODE)"
            str = str & " SET @CLSSTK = @CLSSTK + (SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM GRN_DETAILS WHERE ITEMCODE=@Itemcode AND ISNULL(VOIDITEM,'') <> 'Y'  and GRNDATE<=@DOCDATE AND GRNTYPE='GRN')"
            str = str & " SET @CLSSTK = @CLSSTK - (SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM GRN_DETAILS WHERE ITEMCODE=@Itemcode AND ISNULL(VOIDITEM,'') <> 'Y'  and GRNDATE<=@DOCDATE AND GRNTYPE<>'GRN')"
            str = str & " SET @CLSSTK = @CLSSTK-(SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM STOCKISSUEDETAIL WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<=@DOCDATE AND ISNULL(RATE,0)>0)"
            str = str & " SET @CLSSTK = @CLSSTK-(SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM stockdmgdetail WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<=@DOCDATE AND ISNULL(RATE,0)>0)"
            str = str & " set @CLSSTK= @CLSSTK-(SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM STOCKTRANSFERDETAIL WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<=@DOCDATE AND ISNULL(RATE,0)>0 and Fromstorecode=@storecode)"
            str = str & " SET @CLSSTK = @CLSSTK + (SELECT ISNULL(SUM(ISNULL(ADJUSTEDSTOCK,0)),0) FROM STOCKADJUSTDETAILS WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<@DOCDATE)"
            str = str & " SET @CLSVALUE = 0"
            str = str & " SET @CLSVALUE = (SELECT ISNULL(SUM(ISNULL(OPVALUE,0)),0) FROM INVENTORYITEMMASTER WHERE ITEMCODE = @ITEMCODE AND STORECODE=@STORECODE)"
            str = str & " SET @CLSVALUE = @CLSVALUE + (SELECT CASE WHEN LTRIM(RTRIM(@TAXREBATE))='Y' THEN ISNULL(SUM(isnull(A.AMOUNT,0)),0)+ISNULL(SUM(isnull(A.OTHCHARGE,0)),0)+ISNULL(SUM(isnull(A.TAXAMOUNT,0)),0)-ISNULL(SUM(isnull(A.DISCOUNT,0)),0) ELSE ISNULL(SUM(isnull(A.AMOUNT,0)),0)+ISNULL(SUM(isnull(A.OTHCHARGE,0)),0)-ISNULL(SUM(isnull(A.DISCOUNT,0)),0) END FROM GRN_DETAILS A, INVENTORYITEMMASTER B WHERE A.ITEMCODE=@Itemcode AND ISNULL(A.VOIDITEM,'') <> 'Y' and A.GRNDATE<=@DOCDATE AND A.ITEMCODE=B.ITEMCODE AND A.storecode=B.storecode  and GRNTYPE='GRN' and A.storecode=@STORECODE)"
            str = str & " SET @CLSVALUE = @CLSVALUE - (SELECT CASE WHEN LTRIM(RTRIM(@TAXREBATE))='Y' THEN ISNULL(SUM(isnull(A.AMOUNT,0)),0)+ISNULL(SUM(isnull(A.OTHCHARGE,0)),0)+ISNULL(SUM(isnull(A.TAXAMOUNT,0)),0)-ISNULL(SUM(isnull(A.DISCOUNT,0)),0) ELSE ISNULL(SUM(isnull(A.AMOUNT,0)),0)+ISNULL(SUM(isnull(A.OTHCHARGE,0)),0)-ISNULL(SUM(isnull(A.DISCOUNT,0)),0) END FROM GRN_DETAILS A, INVENTORYITEMMASTER B WHERE A.ITEMCODE=@Itemcode AND ISNULL(A.VOIDITEM,'') <> 'Y' and A.GRNDATE<=@DOCDATE AND A.ITEMCODE=B.ITEMCODE AND A.storecode=B.storecode  and GRNTYPE<>'GRN' and A.storecode=@STORECODE)"

            str = str & " SET @CLSVALUE = @CLSVALUE - (SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) FROM STOCKISSUEDETAIL WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<@DOCDATE AND ISNULL(RATE,0)>0)"
            str = str & " SET @CLSVALUE = @CLSVALUE + (SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) FROM STOCKADJUSTDETAILS WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<@DOCDATE)"

            str = str & " SET @CLSVALUE = @CLSVALUE-(SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) FROM stockdmgdetail WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<=@DOCDATE AND ISNULL(RATE,0)>0)"
            str = str & " set @CLSVALUE= @CLSVALUE-(SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) FROM STOCKTRANSFERDETAIL WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<=@DOCDATE AND ISNULL(RATE,0)>0 and Fromstorecode=@storecode)"

            str = str & " IF (CAST(@CLSSTK AS NUMERIC)>0 AND CAST(@CLSVALUE AS NUMERIC)>0) "
            str = str & " BEGIN"

            str = str & " UPDATE STOCKISSUEDETAIL SET CLSQTY=@CLSSTK,CLSVAL=@CLSVALUE,RATE=ROUND(@CLSVALUE/@CLSSTK,2) WHERE ITEMCODE=@ITEMCODE AND DOCDATE BETWEEN @DOCDATE AND @NEXTDATE AND ISNULL(RATE,0)=0"
            str = str & " UPDATE STOCKADJUSTDETAILS SET RATE=ROUND(@CLSVALUE/@CLSSTK,2) WHERE ITEMCODE=@ITEMCODE AND DOCDATE BETWEEN @DOCDATE AND @NEXTDATE AND ISNULL(RATE,0)=0"
            str = str & " UPDATE STOCKDMGDETAIL SET RATE=ROUND(@CLSVALUE/@CLSSTK,2) WHERE ITEMCODE=@ITEMCODE AND DOCDATE BETWEEN @DOCDATE AND @NEXTDATE AND ISNULL(RATE,0)=0"

            str = str & " 			UPDATE STOCKTRANSFERDETAIL SET RATE=ROUND(@CLSVALUE/@CLSSTK,2) WHERE ITEMCODE=@ITEMCODE AND DOCDATE BETWEEN @DOCDATE AND @NEXTDATE AND ISNULL(RATE,0)=0"


            str = str & " 	UPDATE INV_WAR SET CLSQTY=@CLSSTK,CLSVAL=@CLSVALUE,WAR=ROUND(@CLSVALUE/@CLSSTK,2) WHERE ITEMCODE=@ITEMCODE AND GRNDATE=@DOCDATE AND ISNULL(WAR,0)=0"
            str = str & " UPDATE STOCKISSUEDETAIL SET AMOUNT=QTY*RATE WHERE ITEMCODE=@ITEMCODE "
            str = str & " UPDATE STOCKADJUSTDETAILS SET AMOUNT=Adjustedstock*RATE WHERE ITEMCODE=@ITEMCODE"
            str = str & " UPDATE STOCKDMGDETAIL SET AMOUNT=ROUND(QTY*RATE,2) WHERE ITEMCODE=@ITEMCODE "

            str = str & " UPDATE STOCKTRANSFERDETAIL SET Amount=ROUND(QTY*RATE,2) WHERE ITEMCODE=@ITEMCODE "

            str = str & " update inventoryitemmaster set clvalue=@Clsvalue, clstock=@CLSSTK where itemcode=@ITEMCODE and STORECODE=@STORECODE"
            str = str & " End"





            str = str & " Fetch CURPROC into @TAXREBATE,@ITEMCODE,@DOCDATE,@NEXTDATE"
            str = str & " End"
            str = str & " Close(CURPROC)"
            str = str & " DEALLOCATE CURPROC"

            str = str & " SET @CLSSTK =0"
            str = str & " SET @CLSSTK = (SELECT ISNULL(SUM(ISNULL(OPSTOCK,0)),0) FROM INVENTORYITEMMASTER WHERE ITEMCODE = @ITEMCODE AND STORECODE=@STORECODE)"
            str = str & " SET @CLSSTK = @CLSSTK + (SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM GRN_DETAILS WHERE ITEMCODE=@Itemcode AND ISNULL(VOIDITEM,'') <> 'Y'  and GRNDATE<=@NEXTDATE AND GRNTYPE='GRN')"
            str = str & " SET @CLSSTK = @CLSSTK - (SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM GRN_DETAILS WHERE ITEMCODE=@Itemcode AND ISNULL(VOIDITEM,'') <> 'Y'  and GRNDATE<=@NEXTDATE AND GRNTYPE<>'GRN')"
            str = str & " SET @CLSSTK = @CLSSTK-(SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM STOCKISSUEDETAIL WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<=@NEXTDATE AND ISNULL(RATE,0)>0)"
            str = str & " SET @CLSSTK = @CLSSTK-(SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM stockdmgdetail WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<=@NEXTDATE AND ISNULL(RATE,0)>0)"
            str = str & " set @CLSSTK= @CLSSTK-(SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM STOCKTRANSFERDETAIL WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<=@NEXTDATE AND ISNULL(RATE,0)>0 and Fromstorecode=@storecode)"
            str = str & " SET @CLSSTK = @CLSSTK + (SELECT ISNULL(SUM(ISNULL(ADJUSTEDSTOCK,0)),0) FROM STOCKADJUSTDETAILS WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<@NEXTDATE)"
            str = str & " SET @CLSVALUE = 0"
            str = str & " SET @CLSVALUE = (SELECT ISNULL(SUM(ISNULL(OPVALUE,0)),0) FROM INVENTORYITEMMASTER WHERE ITEMCODE = @ITEMCODE AND STORECODE=@STORECODE)"
            str = str & " SET @CLSVALUE = @CLSVALUE + (SELECT CASE WHEN LTRIM(RTRIM(@TAXREBATE))='Y' THEN ISNULL(SUM(isnull(A.AMOUNT,0)),0)+ISNULL(SUM(isnull(A.OTHCHARGE,0)),0)+ISNULL(SUM(isnull(A.TAXAMOUNT,0)),0)-ISNULL(SUM(isnull(A.DISCOUNT,0)),0) ELSE ISNULL(SUM(isnull(A.AMOUNT,0)),0)+ISNULL(SUM(isnull(A.OTHCHARGE,0)),0)-ISNULL(SUM(isnull(A.DISCOUNT,0)),0) END FROM GRN_DETAILS A, INVENTORYITEMMASTER B WHERE A.ITEMCODE=@Itemcode AND ISNULL(A.VOIDITEM,'') <> 'Y' and A.GRNDATE<=@NEXTDATE AND A.ITEMCODE=B.ITEMCODE AND A.storecode=B.storecode  and GRNTYPE='GRN' and A.storecode=@STORECODE)"
            str = str & " SET @CLSVALUE = @CLSVALUE - (SELECT CASE WHEN LTRIM(RTRIM(@TAXREBATE))='Y' THEN ISNULL(SUM(isnull(A.AMOUNT,0)),0)+ISNULL(SUM(isnull(A.OTHCHARGE,0)),0)+ISNULL(SUM(isnull(A.TAXAMOUNT,0)),0)-ISNULL(SUM(isnull(A.DISCOUNT,0)),0) ELSE ISNULL(SUM(isnull(A.AMOUNT,0)),0)+ISNULL(SUM(isnull(A.OTHCHARGE,0)),0)-ISNULL(SUM(isnull(A.DISCOUNT,0)),0) END FROM GRN_DETAILS A, INVENTORYITEMMASTER B WHERE A.ITEMCODE=@Itemcode AND ISNULL(A.VOIDITEM,'') <> 'Y' and A.GRNDATE<=@NEXTDATE AND A.ITEMCODE=B.ITEMCODE AND A.storecode=B.storecode  and GRNTYPE<>'GRN' and A.storecode=@STORECODE)"

            str = str & " SET @CLSVALUE = @CLSVALUE - (SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) FROM STOCKISSUEDETAIL WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<@NEXTDATE AND ISNULL(RATE,0)>0)"
            str = str & " SET @CLSVALUE = @CLSVALUE + (SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) FROM STOCKADJUSTDETAILS WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<@NEXTDATE)"

            str = str & " SET @CLSVALUE = @CLSVALUE-(SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) FROM stockdmgdetail WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<=@NEXTDATE AND ISNULL(RATE,0)>0)"
            str = str & " set @CLSVALUE= @CLSVALUE-(SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) FROM STOCKTRANSFERDETAIL WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<=@NEXTDATE AND ISNULL(RATE,0)>0 and Fromstorecode=@storecode)"

            str = str & " update inventoryitemmaster set clvalue=@Clsvalue, clstock=@CLSSTK where itemcode=@ITEMCODE and STORECODE=@STORECODE"






            str = str & "             End"
            str = str & " if @OPT='B' or @OPT='P'"
            str = str & " BEGIN "

            str = str & " TRUNCATE TABLE INV_WAR "
            str = str & " INSERT INTO INV_WAR (TAXREBATE,GROUPCODE,GRNDATE,ITEMCODE,QTY,VALUE) SELECT TAXREBATE,GROUPCODE,GRNDATE,ITEMCODE,QTY,VALUE FROM INV_VIEW_WAR WHERE ITEMCODE=@PITEMCODE "
            str = str & " UPDATE INV_WAR SET NEXTDATE=(SELECT TOP 1 DATEADD(MINUTE,-1,GRNDATE) FROM INV_WAR B WHERE B.ITEMCODE=INV_WAR.ITEMCODE AND B.GRNDATE>INV_WAR.GRNDATE ORDER BY B.GRNDATE) "

            str = str & " UPDATE INV_WAR SET NEXTDATE=(SELECT TOP 1 DOCDATE FROM STOCKISSUEDETAIL B WHERE B.ITEMCODE=INV_WAR.ITEMCODE ORDER BY DOCDATE DESC) WHERE ISNULL(NEXTDATE,'')=''"

            str = str & " UPDATE INV_WAR SET NEXTDATE=CONVERT(VARCHAR(11),GETDATE(),106) WHERE ISNULL(NEXTDATE,'')=''"

            str = str & " 	Set @SSQL='SELECT TAXREBATE,ITEMCODE,GRNDATE,NEXTDATE FROM INV_WAR where itemcode=' + char(39) + @PITEMCODE  + char(39)+' ORDER BY ITEMCODE,GRNDATE,NEXTDATE '"

            str = str & " set @SQL='DECLARE CURPROC CURSOR FOR ' + @ssql"
            str = str & " exec (@SQL)"
            str = str & " open CURPROC"
            str = str & " Fetch CURPROC into @TAXREBATE,@ITEMCODE,@DOCDATE,@NEXTDATE"
            str = str & " while @@fetch_Status=0"
            str = str & " Begin"

            str = str & " UPDATE STOCKISSUEDETAIL SET RATE=0 WHERE ITEMCODE=@ITEMCODE AND DOCDATE>=@DOCDATE"

            str = str & " UPDATE STOCKISSUEDETAIL SET AMOUNT=0 WHERE ITEMCODE=@ITEMCODE AND DOCDATE>=@DOCDATE"

            str = str & " SET @OPSTOCK = 0"
            str = str & " SET @OPSTOCK = (SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM INV_VIEW_WAR WHERE ITEMCODE=@Itemcode AND GRNDATE<= @DOCDATE)"
            str = str & " 		SET @OPVALUE = 0"
            str = str & " SET @OPVALUE = (SELECT ISNULL(SUM(ISNULL(VALUE,0)),0) FROM INV_VIEW_WAR WHERE ITEMCODE=@Itemcode AND GRNDATE<=@DOCDATE)"
            str = str & " 		SET @CLSSTK =0"
            str = str & " SET @CLSSTK = (SELECT ISNULL(SUM(ISNULL(OPSTOCK,0)),0) FROM INVENTORYITEMMASTER WHERE ITEMCODE = @ITEMCODE AND STORECODE=@STORECODE)"
            str = str & " SET @CLSSTK = @CLSSTK + (SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM GRN_DETAILS WHERE ITEMCODE=@Itemcode AND ISNULL(VOIDITEM,'') <> 'Y'  and GRNDATE<=@DOCDATE AND GRNTYPE='GRN')"
            str = str & " SET @CLSSTK = @CLSSTK - (SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM GRN_DETAILS WHERE ITEMCODE=@Itemcode AND ISNULL(VOIDITEM,'') <> 'Y'  and GRNDATE<=@DOCDATE AND GRNTYPE<>'GRN')"
            str = str & " SET @CLSSTK = @CLSSTK - (SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM STOCKISSUEDETAIL WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<@DOCDATE AND ISNULL(RATE,0)>0)"
            str = str & " SET @CLSSTK = @CLSSTK + (SELECT ISNULL(SUM(ISNULL(ADJUSTEDSTOCK,0)),0) FROM STOCKADJUSTDETAILS WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<@DOCDATE)"

            str = str & " 	SET @CLSVALUE = 0"
            str = str & " SET @CLSVALUE = (SELECT ISNULL(SUM(ISNULL(OPVALUE,0)),0) FROM INVENTORYITEMMASTER WHERE ITEMCODE = @ITEMCODE AND STORECODE=@STORECODE)"
            str = str & " SET @CLSVALUE = @CLSVALUE + (SELECT CASE WHEN LTRIM(RTRIM(@TAXREBATE))='Y' THEN ISNULL(SUM(isnull(A.AMOUNT,0)),0)+ISNULL(SUM(isnull(A.OTHCHARGE,0)),0)+ISNULL(SUM(isnull(A.TAXAMOUNT,0)),0)-ISNULL(SUM(isnull(A.DISCOUNT,0)),0) ELSE ISNULL(SUM(isnull(A.AMOUNT,0)),0)+ISNULL(SUM(isnull(A.OTHCHARGE,0)),0)-ISNULL(SUM(isnull(A.DISCOUNT,0)),0) END FROM GRN_DETAILS A, INVENTORYITEMMASTER B WHERE A.ITEMCODE=@Itemcode AND ISNULL(A.VOIDITEM,'') <> 'Y' and A.GRNDATE<=@DOCDATE AND A.ITEMCODE=B.ITEMCODE AND A.storecode=B.storecode  and GRNTYPE='GRN' and A.storecode=@STORECODE)"
            str = str & " SET @CLSVALUE = @CLSVALUE - (SELECT CASE WHEN LTRIM(RTRIM(@TAXREBATE))='Y' THEN ISNULL(SUM(isnull(A.AMOUNT,0)),0)+ISNULL(SUM(isnull(A.OTHCHARGE,0)),0)+ISNULL(SUM(isnull(A.TAXAMOUNT,0)),0)-ISNULL(SUM(isnull(A.DISCOUNT,0)),0) ELSE ISNULL(SUM(isnull(A.AMOUNT,0)),0)+ISNULL(SUM(isnull(A.OTHCHARGE,0)),0)-ISNULL(SUM(isnull(A.DISCOUNT,0)),0) END FROM GRN_DETAILS A, INVENTORYITEMMASTER B WHERE A.ITEMCODE=@Itemcode AND ISNULL(A.VOIDITEM,'') <> 'Y' and A.GRNDATE<=@DOCDATE AND A.ITEMCODE=B.ITEMCODE AND A.storecode=B.storecode  and GRNTYPE<>'GRN' and A.storecode=@STORECODE)"

            str = str & " 		SET @CLSVALUE = @CLSVALUE - (SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) FROM STOCKISSUEDETAIL WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<@DOCDATE AND ISNULL(RATE,0)>0)"
            str = str & " SET @CLSVALUE = @CLSVALUE + (SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) FROM STOCKADJUSTDETAILS WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<@DOCDATE)"

            str = str & " SET @CLSVALUE = @CLSVALUE-(SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) FROM stockdmgdetail WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<=@DOCDATE AND ISNULL(RATE,0)>0)"
            str = str & " set @CLSVALUE= @CLSVALUE-(SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) FROM STOCKTRANSFERDETAIL WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<=@DOCDATE AND ISNULL(RATE,0)>0 and Fromstorecode=@storecode)"

            str = str & " SET @LASTRATE=0 "
            str = str & " SET   @LASTRATE=(SELECT TOP 1 ISNULL(PURCHASERATE,0) AS PURCHASERATE FROM INV_VIEW_WAR_LRATE WHERE ITEMCODE=@ITEMCODE  and GRNDATE<@DOCDATE ORDER BY GRNDATE DESC)"

            str = str & " IF (CAST(@CLSSTK AS NUMERIC)>0 AND CAST(@CLSVALUE AS NUMERIC)>0) "
            str = str & " BEGIN "
            str = str & " UPDATE STOCKISSUEDETAIL SET CLSQTY=@CLSSTK,CLSVAL=@CLSVALUE,RATE=ROUND(@LASTRATE,2) WHERE ITEMCODE=@ITEMCODE AND DOCDATE BETWEEN @DOCDATE AND @NEXTDATE AND ISNULL(RATE,0)=0"
            str = str & " UPDATE STOCKADJUSTDETAILS SET RATE=ROUND(@LASTRATE,2) WHERE ITEMCODE=@ITEMCODE AND DOCDATE BETWEEN @DOCDATE AND @NEXTDATE AND ISNULL(RATE,0)=0"
            str = str & " UPDATE STOCKDMGDETAIL SET RATE=ROUND(@LASTRATE,2) WHERE ITEMCODE=@ITEMCODE AND DOCDATE BETWEEN @DOCDATE AND @NEXTDATE AND ISNULL(RATE,0)=0"

            str = str & " UPDATE STOCKTRANSFERDETAIL SET RATE=ROUND(@LASTRATE,2) WHERE ITEMCODE=@ITEMCODE AND DOCDATE BETWEEN @DOCDATE AND @NEXTDATE AND ISNULL(RATE,0)=0"

            str = str & " UPDATE INV_WAR SET CLSQTY=@CLSSTK,CLSVAL=@CLSVALUE,WAR=ROUND(@LASTRATE,2) WHERE ITEMCODE=@ITEMCODE AND GRNDATE=@DOCDATE AND ISNULL(WAR,0)=0"

            str = str & " UPDATE STOCKISSUEDETAIL SET AMOUNT=QTY*RATE WHERE ITEMCODE=@ITEMCODE "
            str = str & " UPDATE STOCKADJUSTDETAILS SET AMOUNT=Adjustedstock*RATE WHERE ITEMCODE=@ITEMCODE"
            str = str & " UPDATE STOCKDMGDETAIL SET AMOUNT=ROUND(QTY*RATE,2) WHERE ITEMCODE=@ITEMCODE "

            str = str & " UPDATE STOCKTRANSFERDETAIL SET Amount=ROUND(QTY*RATE,2) WHERE ITEMCODE=@ITEMCODE "

            str = str & " update inventoryitemmaster set clvalue=@Clsvalue, clstock=@CLSSTK where itemcode=@ITEMCODE and STORECODE=@STORECODE"

            str = str & " End"

            str = str & " Fetch CURPROC into @TAXREBATE,@ITEMCODE,@DOCDATE,@NEXTDATE"
            str = str & " End"
            str = str & " Close(CURPROC)"
            str = str & " DEALLOCATE CURPROC"
            str = str & " update inventoryitemmaster set purchaserate=@LASTRATE where itemcode=@ITEMCODE and  isnull(clstock,0)>0"

            str = str & " UPDATE STOCKISSUEDETAIL SET RATE=@LASTRATE FROM INV_WAR WHERE INV_WAR.ITEMCODE=STOCKISSUEDETAIL.ITEMCODE AND STOCKISSUEDETAIL.DOCDATE BETWEEN INV_WAR.GRNDATE AND INV_WAR.NEXTDATE  and STOCKISSUEDETAIL.ITEMCODE=@Itemcode --AND ISNULL(INV_WAR.WAR,0)<>0 "
            str = str & " 	UPDATE STOCKADJUSTDETAILS SET RATE=@LASTRATE FROM INV_WAR WHERE INV_WAR.ITEMCODE=STOCKADJUSTDETAILS.ITEMCODE AND STOCKADJUSTDETAILS.DOCDATE BETWEEN INV_WAR.GRNDATE AND getdate() and isnull(RATE,0)=0 and STOCKADJUSTDETAILS.ITEMCODE=@Itemcode"


            str = str & " End"


            str = str & " UPDATE INVENTORYITEMMASTER  SET CLVALUE=0 WHERE CLSTOCK<=0 AND CLVALUE<>0"
            str = str & " UPDATE INVENTORYITEMMASTER SET OPVALUE=0 WHERE OPSTOCK=0 AND OPVALUE<>0"
            gconnection.dataOperation1(6, str, "item")







        Else

            str = "CREATE      PROCEDURE [dbo].[Cp_WeightedAverage_Item](@FROMDATE AS datetime, @TODATE AS datetime ,@PITEMCODE as VARCHAR(15),@STORECODE as VARCHAR(10),@USER as VARCHAR(50) )"
            str = str & "  AS"
            str = str & "  Declare @ITEMNAME VARCHAR(100),@Itemcode Varchar(50), @CLSSTK AS NUMERIC(18,2),@CLSVALUE AS NUMERIC(18,2),@SQL AS VARCHAR(1000),@GRNDATE AS DATETIME,@DOCDATE AS datetime,@ssql AS VARCHAR(2000),@OPSTOCK AS NUMERIC(18,2),@OPVALUE AS NUMERIC(18,2)"
            str = str & " Declare @TAXREBATE VARCHAR(1),@ISSUERATE AS NUMERIC(18,2),@PURCHASERATE NUMERIC(18,2),@LASTRATE NUMERIC(18,2)"
            str = str & "  Declare @NEXTDATE DATETIME, @opt as varchar(1)"

            str = str & "  select @opt=rateflag from INVENTORYCATEGORYMASTER where CATEGORYCODE=(select distinct category from inventoryitemmaster where itemcode=@PITEMCODE)"

            str = str & "  --insert into Inv_WAR_useridentity values(@STORECODE,@PITEMCODE,getdate(),@USER,@OPT)"
            str = str & "  --update inventoryitemmaster set selectopt='Y' WHERE ITEMCODE =@PITEMCODE and STORECODE=@STORECODE "

            str = str & " --update inventoryitemmaster set selectopt='Y' WHERE ITEMCODE IN (SELECT ITEMCODE FROM STOCKISSUEDETAIL WHERE ISNULL(RATE,0)=0 AND STORECODE=@STORECODE)  AND STORECODE=@STORECODE"
            str = str & " --update inventoryitemmaster set selectopt='Y' WHERE ITEMCODE IN (SELECT ITEMCODE FROM inventory_indentdet WHERE ISNULL(RATE,0)=0 AND STORECODE=@STORECODE) AND STORECODE=@STORECODE"
            str = str & " --update inventoryitemmaster set selectopt='Y' WHERE ITEMCODE IN (SELECT ITEMCODE FROM stockadjustdetailS WHERE ISNULL(adjustedstock,0)<>0 AND ISNULL(RATE,0)=0 AND STORECODE=@STORECODE) AND STORECODE=@STORECODE"
            str = str & " IF @OPT='B' OR @OPT='W'"
            str = str & "  BEGIN "
            str = str & "  TRUNCATE TABLE INV_WAR "
            str = str & "  INSERT INTO INV_WAR (TAXREBATE,GROUPCODE,GRNDATE,ITEMCODE,QTY,VALUE) SELECT TAXREBATE,GROUPCODE,GRNDATE,ITEMCODE,QTY,VALUE FROM INV_VIEW_WAR WHERE ITEMCODE=@PITEMCODE "
            '    Print() '1'
            str = str & "  	UPDATE INV_WAR SET NEXTDATE=(SELECT TOP 1 DATEADD(MINUTE,-1,GRNDATE) FROM INV_WAR B WHERE B.ITEMCODE=INV_WAR.ITEMCODE AND B.GRNDATE>INV_WAR.GRNDATE ORDER BY B.GRNDATE) "
            '  Print() '2'

            str = str & "  UPDATE INV_WAR SET NEXTDATE=(SELECT TOP 1 DOCDATE FROM STOCKISSUEDETAIL B WHERE B.ITEMCODE=INV_WAR.ITEMCODE ORDER BY DOCDATE DESC) WHERE ISNULL(NEXTDATE,'')=''"
            '     Print() '3'

            str = str & " 	UPDATE INV_WAR SET NEXTDATE=CONVERT(VARCHAR(11),GETDATE(),106) WHERE ISNULL(NEXTDATE,'')=''"

            str = str & " Set @SSQL='SELECT TAXREBATE,ITEMCODE,GRNDATE,NEXTDATE FROM INV_WAR where itemcode=' + char(39) + @PITEMCODE  + char(39)+' ORDER BY ITEMCODE,GRNDATE,NEXTDATE '"
            str = str & "              -- 'where itemcode= + char(39) + @PITEMCODE  + char(39) "

            str = str & " set @SQL='DECLARE CURPROC CURSOR FOR ' + @ssql"
            str = str & " 	exec (@SQL)"
            str = str & "      open CURPROC"
            str = str & " Fetch CURPROC into @TAXREBATE,@ITEMCODE,@DOCDATE,@NEXTDATE"
            str = str & " while @@fetch_Status=0"
            str = str & "  Begin "
            '--  Print() '4'
            str = str & "  PRINT @DOCDATE"
            str = str & " 		UPDATE STOCKISSUEDETAIL SET RATE=0 WHERE ITEMCODE=@ITEMCODE AND DOCDATE>=@DOCDATE"

            str = str & " 	UPDATE STOCKISSUEDETAIL SET AMOUNT=0 WHERE ITEMCODE=@ITEMCODE AND DOCDATE>=@DOCDATE"

            str = str & " update STOCKDMGDETAIL set Rate=0 WHERE ITEMCODE=@ITEMCODE AND DOCDATE>=@DOCDATE"

            str = str & " update STOCKDMGDETAIL set AMOUNT=0 WHERE ITEMCODE=@ITEMCODE AND DOCDATE>=@DOCDATE"

            str = str & "  update STOCKADJUSTDETAILS set Rate=0 WHERE ITEMCODE=@ITEMCODE AND DOCDATE>=@DOCDATE"

            str = str & "  update STOCKADJUSTDETAILS set AMOUNT=0 WHERE ITEMCODE=@ITEMCODE AND DOCDATE>=@DOCDATE"


            str = str & "  update STOCKADJUSTDETAILS set Rate=0 WHERE ITEMCODE=@ITEMCODE AND DOCDATE>=@DOCDATE"

            str = str & "  update STOCKADJUSTDETAILS set AMOUNT=0 WHERE ITEMCODE=@ITEMCODE AND DOCDATE>=@DOCDATE"

            str = str & " update STOCKTRANSFERDETAIL set Rate=0 WHERE ITEMCODE=@ITEMCODE AND DOCDATE>=@DOCDATE"

            str = str & "  update STOCKTRANSFERDETAIL set AMOUNT=0 WHERE ITEMCODE=@ITEMCODE AND DOCDATE>=@DOCDATE"



            '	--	UPDATE inventory_indentdet SET RATE=0 WHERE ITEMCODE=@ITEMCODE AND INDENT_DATE>=@DOCDATE 

            '--	UPDATE inventory_indentdet SET AMOUNT=0 WHERE ITEMCODE=@ITEMCODE AND INDENT_DATE>=@DOCDATE 

            str = str & " 	SET @OPSTOCK = 0"
            str = str & " 	SET @OPSTOCK = (SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM INV_VIEW_WAR WHERE ITEMCODE=@Itemcode AND GRNDATE<= @DOCDATE)"
            'print @OPSTOCK
            '       Print() '5'
            str = str & " 	SET @OPVALUE = 0"
            str = str & " 	SET @OPVALUE = (SELECT ISNULL(SUM(ISNULL(VALUE,0)),0) FROM INV_VIEW_WAR WHERE ITEMCODE=@Itemcode AND GRNDATE<=@DOCDATE)"
            'print @OPVALUE
            str = str & " 	SET @CLSSTK =0"
            str = str & " 	SET @CLSSTK = @CLSSTK-(SELECT ISNULL(SUM(ISNULL(OPSTOCK,0)),0) FROM INVENTORYITEMMASTER WHERE ITEMCODE = @ITEMCODE AND STORECODE=@STORECODE)"
            str = str & " 	SET @CLSSTK = @CLSSTK + (SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM GRN_DETAILS WHERE ITEMCODE=@Itemcode AND ISNULL(VOIDITEM,'') <> 'Y'  and GRNDATE<=@DOCDATE AND GRNTYPE='GRN')"
            '   Print() '6'

            'print @CLSSTK
            str = str & " 		SET @CLSSTK = @CLSSTK - (SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM GRN_DETAILS WHERE ITEMCODE=@Itemcode AND ISNULL(VOIDITEM,'') <> 'Y'  and GRNDATE<=@DOCDATE AND GRNTYPE<>'GRN')"
            str = str & " 	SET @CLSSTK = @CLSSTK-(SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM STOCKISSUEDETAIL WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<=@DOCDATE AND ISNULL(RATE,0)>0)"
            str = str & " 		SET @CLSSTK = @CLSSTK-(SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM stockdmgdetail WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<=@DOCDATE AND ISNULL(RATE,0)>0)"
            str = str & "     set @CLSSTK= @CLSSTK-(SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM STOCKTRANSFERDETAIL WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<=@DOCDATE AND ISNULL(RATE,0)>0 and Fromstorecode=@storecode)"


            '     Print() 'SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM STOCKISSUEDETAIL WHERE ITEMCODE=' + @Itemcode + ' AND ISNULL(VOID,'') <> '+'Y'+' and DOCDATE<'
            'PRINT  @DOCDATE 
            '   Print() 'AND ISNULL(RATE,0)>0'
            'PRINT @CLSSTK
            str = str & " 	SET @CLSSTK = @CLSSTK + (SELECT ISNULL(SUM(ISNULL(ADJUSTEDSTOCK,0)),0) FROM STOCKADJUSTDETAILS WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<@DOCDATE)"
            str = str & " --	SET @CLSSTK = @CLSSTK - (SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM SUBSTORECONSUMPTIONDETAIL WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<@DOCDATE)"

            '   Print() '7'

            str = str & " 	SET @CLSVALUE = 0"
            str = str & " 		SET @CLSVALUE = (SELECT ISNULL(SUM(ISNULL(OPVALUE,0)),0) FROM INVENTORYITEMMASTER WHERE ITEMCODE = @ITEMCODE AND STORECODE=@STORECODE)"
            str = str & " 		SET @CLSVALUE = @CLSVALUE + (SELECT CASE WHEN LTRIM(RTRIM(@TAXREBATE))='Y' THEN ISNULL(SUM(isnull(A.AMOUNT,0)),0)+ISNULL(SUM(isnull(A.OTHCHARGE,0)),0)+ISNULL(SUM(isnull(A.TAXAMOUNT,0)),0)-ISNULL(SUM(isnull(A.DISCOUNT,0)),0) ELSE ISNULL(SUM(isnull(A.AMOUNT,0)),0)+ISNULL(SUM(isnull(A.OTHCHARGE,0)),0)-ISNULL(SUM(isnull(A.DISCOUNT,0)),0) END FROM GRN_DETAILS A, INVENTORYITEMMASTER B WHERE A.ITEMCODE=@Itemcode AND ISNULL(A.VOIDITEM,'') <> 'Y' and A.GRNDATE<=@DOCDATE AND A.ITEMCODE=B.ITEMCODE AND A.storecode=B.storecode  and GRNTYPE='GRN' and A.storecode=@STORECODE)"
            str = str & " 	SET @CLSVALUE = @CLSVALUE - (SELECT CASE WHEN LTRIM(RTRIM(@TAXREBATE))='Y' THEN ISNULL(SUM(isnull(A.AMOUNT,0)),0)+ISNULL(SUM(isnull(A.OTHCHARGE,0)),0)+ISNULL(SUM(isnull(A.TAXAMOUNT,0)),0)-ISNULL(SUM(isnull(A.DISCOUNT,0)),0) ELSE ISNULL(SUM(isnull(A.AMOUNT,0)),0)+ISNULL(SUM(isnull(A.OTHCHARGE,0)),0)-ISNULL(SUM(isnull(A.DISCOUNT,0)),0) END FROM GRN_DETAILS A, INVENTORYITEMMASTER B WHERE A.ITEMCODE=@Itemcode AND ISNULL(A.VOIDITEM,'') <> 'Y' and A.GRNDATE<=@DOCDATE AND A.ITEMCODE=B.ITEMCODE AND A.storecode=B.storecode  and GRNTYPE<>'GRN' and A.storecode=@STORECODE)"

            str = str & " 	SET @CLSVALUE = @CLSVALUE - (SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) FROM STOCKISSUEDETAIL WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<@DOCDATE AND ISNULL(RATE,0)>0)"
            str = str & " 	SET @CLSVALUE = @CLSVALUE + (SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) FROM STOCKADJUSTDETAILS WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<@DOCDATE)"

            str = str & " 	SET @CLSVALUE = @CLSVALUE-(SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) FROM stockdmgdetail WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<=@DOCDATE AND ISNULL(RATE,0)>0)"
            str = str & "      set @CLSVALUE= @CLSVALUE-(SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) FROM STOCKTRANSFERDETAIL WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<=@DOCDATE AND ISNULL(RATE,0)>0 and Fromstorecode=@storecode)"

            str = str & " 	--	SET @CLSVALUE = @CLSVALUE - (SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) FROM SUBSTORECONSUMPTIONDETAIL WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<@DOCDATE)"
            '      Print() '8'


            str = str & " 	--	SET @ISSUERATE=0 "
            str = str & " 	  --      SET @ISSUERATE=(SELECT TOP 1 ISNULL(RATE,0) AS CLSTK FROM STOCKISSUEDETAIL WHERE ITEMCODE=@ITEMCODE AND ISNULL(VOID,'') <> 'Y' and DOCDATE<@DOCDATE ORDER BY DOCDATE DESC)"

            str = str & " 		--SET @LASTRATE=0 "
            str = str & " 	     --   SET @LASTRATE=(SELECT TOP 1 ISNULL(PURCHASERATE,0) AS PURCHASERATE FROM INV_VIEW_WAR_LRATE WHERE ITEMCODE=@ITEMCODE  and GRNDATE<@DOCDATE ORDER BY GRNDATE DESC)"
            '   --    print @LASTRATE
            str = str & " 		--SET @PURCHASERATE=0 "

            '	--SET @PURCHASERATE = (SELECT TOP 1 CASE WHEN ISNULL(QTY,0)>0 THEN ISNULL(VALUE,0)/ISNULL(QTY,0) ELSE 0 END FROM INV_VIEW_WAR WHERE ISNULL(QTY,0)>0 and ITEMCODE=@Itemcode AND GRNDATE<=@DOCDATE ORDER BY GRNDATE DESC)

            '--IF (CAST(@CLSSTK AS NUMERIC)=0 AND @LASTRATE>0)
            ' --     BEGIN
            '--	UPDATE STOCKISSUEDETAIL SET WARSTATUS='Y',CLSQTY=@OPSTOCK,CLSVAL=@OPVALUE,RATE=@LASTRATE WHERE ITEMCODE=@ITEMCODE AND DOCDATE BETWEEN @DOCDATE AND @NEXTDATE  AND ISNULL(RATE,0)=0 and itemcode=@ITEMCODE
            '--  END		   
            '  Print() '9'
            str = str & " IF (CAST(@CLSSTK AS NUMERIC)>0 AND CAST(@CLSVALUE AS NUMERIC)>0) "
            str = str & " BEGIN "

            str = str & " 	UPDATE STOCKISSUEDETAIL SET CLSQTY=@CLSSTK,CLSVAL=@CLSVALUE,RATE=ROUND(@CLSVALUE/@CLSSTK,2) WHERE ITEMCODE=@ITEMCODE AND DOCDATE BETWEEN @DOCDATE AND @NEXTDATE AND ISNULL(RATE,0)=0"
            '   Print() 'UPDATE STOCKISSUEDETAIL SET CLSQTY=@CLSSTK,CLSVAL=@CLSVALUE,RATE=ROUND(@CLSVALUE/@CLSSTK,2) WHERE ITEMCODE=@ITEMCODE AND DOCDATE BETWEEN @DOCDATE AND @NEXTDATE AND ISNULL(RATE,0)=0'
            '   PRINT @DOCDATE
            '  PRINT @NEXTDATE
            str = str & "        UPDATE STOCKADJUSTDETAILS SET RATE=ROUND(@CLSVALUE/@CLSSTK,2) WHERE ITEMCODE=@ITEMCODE AND DOCDATE BETWEEN @DOCDATE AND @NEXTDATE AND ISNULL(RATE,0)=0"
            str = str & "    UPDATE STOCKDMGDETAIL SET RATE=ROUND(@CLSVALUE/@CLSSTK,2) WHERE ITEMCODE=@ITEMCODE AND DOCDATE BETWEEN @DOCDATE AND @NEXTDATE AND ISNULL(RATE,0)=0"

            str = str & " 		UPDATE STOCKTRANSFERDETAIL SET RATE=ROUND(@CLSVALUE/@CLSSTK,2) WHERE ITEMCODE=@ITEMCODE AND DOCDATE BETWEEN @DOCDATE AND @NEXTDATE AND ISNULL(RATE,0)=0"


            str = str & " 		UPDATE INV_WAR SET CLSQTY=@CLSSTK,CLSVAL=@CLSVALUE,WAR=ROUND(@CLSVALUE/@CLSSTK,2) WHERE ITEMCODE=@ITEMCODE AND GRNDATE=@DOCDATE AND ISNULL(WAR,0)=0"
            str = str & " 	UPDATE STOCKISSUEDETAIL SET AMOUNT=QTY*RATE WHERE ITEMCODE=@ITEMCODE "
            str = str & " 	UPDATE STOCKADJUSTDETAILS SET AMOUNT=Adjustedstock*RATE WHERE ITEMCODE=@ITEMCODE"
            str = str & "    UPDATE STOCKDMGDETAIL SET AMOUNT=ROUND(QTY*RATE,2) WHERE ITEMCODE=@ITEMCODE "

            str = str & " 		UPDATE STOCKTRANSFERDETAIL SET Amount=ROUND(QTY*RATE,2) WHERE ITEMCODE=@ITEMCODE "

            str = str & "        update inventoryitemmaster set clvalue=@Clsvalue, clstock=@CLSSTK where itemcode=@ITEMCODE and STORECODE=@STORECODE"








            str = str & "      End"





            str = str & " 	Fetch CURPROC into @TAXREBATE,@ITEMCODE,@DOCDATE,@NEXTDATE"
            str = str & "      End"
            str = str & "       Close(CURPROC)"
            str = str & "     DEALLOCATE CURPROC"
            str = str & " update inventoryitemmaster set purchaserate=round(isnull(clvalue,0)/isnull(clstock,0),2) where itemcode=@ITEMCODE and  isnull(clstock,0)>0"

            str = str & " 	UPDATE STOCKISSUEDETAIL SET RATE=WAR FROM INV_WAR WHERE INV_WAR.ITEMCODE=STOCKISSUEDETAIL.ITEMCODE AND STOCKISSUEDETAIL.DOCDATE BETWEEN INV_WAR.GRNDATE AND INV_WAR.NEXTDATE  and STOCKISSUEDETAIL.ITEMCODE=@Itemcode --AND ISNULL(INV_WAR.WAR,0)<>0 "
            str = str & " 	UPDATE STOCKADJUSTDETAILS SET RATE=WAR FROM INV_WAR WHERE INV_WAR.ITEMCODE=STOCKADJUSTDETAILS.ITEMCODE AND STOCKADJUSTDETAILS.DOCDATE BETWEEN INV_WAR.GRNDATE AND getdate() and isnull(RATE,0)=0 and STOCKADJUSTDETAILS.ITEMCODE=@Itemcode"


            str = str & "     End"
            str = str & "  if @OPT='B' or @OPT='P'"
            str = str & "  BEGIN "

            str = str & "  TRUNCATE TABLE INV_WAR "
            str = str & "  INSERT INTO INV_WAR (TAXREBATE,GROUPCODE,GRNDATE,ITEMCODE,QTY,VALUE) SELECT TAXREBATE,GROUPCODE,GRNDATE,ITEMCODE,QTY,VALUE FROM INV_VIEW_WAR WHERE ITEMCODE=@PITEMCODE "
            '     Print() '1'
            str = str & " 	UPDATE INV_WAR SET NEXTDATE=(SELECT TOP 1 DATEADD(MINUTE,-1,GRNDATE) FROM INV_WAR B WHERE B.ITEMCODE=INV_WAR.ITEMCODE AND B.GRNDATE>INV_WAR.GRNDATE ORDER BY B.GRNDATE) "
            '      Print() '2'

            str = str & " 	UPDATE INV_WAR SET NEXTDATE=(SELECT TOP 1 DOCDATE FROM STOCKISSUEDETAIL B WHERE B.ITEMCODE=INV_WAR.ITEMCODE ORDER BY DOCDATE DESC) WHERE ISNULL(NEXTDATE,'')=''"
            ' Print() '3'

            str = str & " 	UPDATE INV_WAR SET NEXTDATE=CONVERT(VARCHAR(11),GETDATE(),106) WHERE ISNULL(NEXTDATE,'')=''"

            str = str & " 	Set @SSQL='SELECT TAXREBATE,ITEMCODE,GRNDATE,NEXTDATE FROM INV_WAR where itemcode=' + char(39) + @PITEMCODE  + char(39)+' ORDER BY ITEMCODE,GRNDATE,NEXTDATE '"
            '  -- 'where itemcode= + char(39) + @PITEMCODE  + char(39) 

            str = str & " 	set @SQL='DECLARE CURPROC CURSOR FOR ' + @ssql"
            str = str & " 	exec (@SQL)"
            str = str & "       open CURPROC"
            str = str & "  Fetch CURPROC into @TAXREBATE,@ITEMCODE,@DOCDATE,@NEXTDATE"
            str = str & "  while @@fetch_Status=0"
            str = str & "  Begin "
            '   Print() '4'

            str = str & " 	UPDATE STOCKISSUEDETAIL SET RATE=0 WHERE ITEMCODE=@ITEMCODE AND DOCDATE>=@DOCDATE"

            str = str & " 	UPDATE STOCKISSUEDETAIL SET AMOUNT=0 WHERE ITEMCODE=@ITEMCODE AND DOCDATE>=@DOCDATE"



            str = str & " 	SET @OPSTOCK = 0"
            str = str & " 	SET @OPSTOCK = (SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM INV_VIEW_WAR WHERE ITEMCODE=@Itemcode AND GRNDATE<= @DOCDATE)"
            str = str & " 		SET @OPVALUE = 0"
            str = str & " 	SET @OPVALUE = (SELECT ISNULL(SUM(ISNULL(VALUE,0)),0) FROM INV_VIEW_WAR WHERE ITEMCODE=@Itemcode AND GRNDATE<=@DOCDATE)"
            str = str & " 	SET @CLSSTK =0"
            str = str & " 	SET @CLSSTK = (SELECT ISNULL(SUM(ISNULL(OPSTOCK,0)),0) FROM INVENTORYITEMMASTER WHERE ITEMCODE = @ITEMCODE AND STORECODE=@STORECODE)"
            str = str & " 	SET @CLSSTK = @CLSSTK + (SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM GRN_DETAILS WHERE ITEMCODE=@Itemcode AND ISNULL(VOIDITEM,'') <> 'Y'  and GRNDATE<=@DOCDATE AND GRNTYPE='GRN')"
            str = str & " 	SET @CLSSTK = @CLSSTK - (SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM GRN_DETAILS WHERE ITEMCODE=@Itemcode AND ISNULL(VOIDITEM,'') <> 'Y'  and GRNDATE<=@DOCDATE AND GRNTYPE<>'GRN')"
            str = str & " 	SET @CLSSTK = @CLSSTK - (SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM STOCKISSUEDETAIL WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<@DOCDATE AND ISNULL(RATE,0)>0)"
            str = str & " 	SET @CLSSTK = @CLSSTK + (SELECT ISNULL(SUM(ISNULL(ADJUSTEDSTOCK,0)),0) FROM STOCKADJUSTDETAILS WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<@DOCDATE)"
            '	--	SET @CLSSTK = @CLSSTK - (SELECT ISNULL(SUM(ISNULL(QTY,0)),0) FROM SUBSTORECONSUMPTIONDETAIL WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<@DOCDATE)

            '      Print() '7'

            str = str & " 	SET @CLSVALUE = 0"
            str = str & " 	SET @CLSVALUE = (SELECT ISNULL(SUM(ISNULL(OPVALUE,0)),0) FROM INVENTORYITEMMASTER WHERE ITEMCODE = @ITEMCODE AND STORECODE=@STORECODE)"
            str = str & " 	SET @CLSVALUE = @CLSVALUE + (SELECT CASE WHEN LTRIM(RTRIM(@TAXREBATE))='Y' THEN ISNULL(SUM(isnull(A.AMOUNT,0)),0)+ISNULL(SUM(isnull(A.OTHCHARGE,0)),0)+ISNULL(SUM(isnull(A.TAXAMOUNT,0)),0)-ISNULL(SUM(isnull(A.DISCOUNT,0)),0) ELSE ISNULL(SUM(isnull(A.AMOUNT,0)),0)+ISNULL(SUM(isnull(A.OTHCHARGE,0)),0)-ISNULL(SUM(isnull(A.DISCOUNT,0)),0) END FROM GRN_DETAILS A, INVENTORYITEMMASTER B WHERE A.ITEMCODE=@Itemcode AND ISNULL(A.VOIDITEM,'') <> 'Y' and A.GRNDATE<=@DOCDATE AND A.ITEMCODE=B.ITEMCODE AND A.storecode=B.storecode  and GRNTYPE='GRN' and A.storecode=@STORECODE)"
            str = str & " 	SET @CLSVALUE = @CLSVALUE - (SELECT CASE WHEN LTRIM(RTRIM(@TAXREBATE))='Y' THEN ISNULL(SUM(isnull(A.AMOUNT,0)),0)+ISNULL(SUM(isnull(A.OTHCHARGE,0)),0)+ISNULL(SUM(isnull(A.TAXAMOUNT,0)),0)-ISNULL(SUM(isnull(A.DISCOUNT,0)),0) ELSE ISNULL(SUM(isnull(A.AMOUNT,0)),0)+ISNULL(SUM(isnull(A.OTHCHARGE,0)),0)-ISNULL(SUM(isnull(A.DISCOUNT,0)),0) END FROM GRN_DETAILS A, INVENTORYITEMMASTER B WHERE A.ITEMCODE=@Itemcode AND ISNULL(A.VOIDITEM,'') <> 'Y' and A.GRNDATE<=@DOCDATE AND A.ITEMCODE=B.ITEMCODE AND A.storecode=B.storecode  and GRNTYPE<>'GRN' and A.storecode=@STORECODE)"

            str = str & " 	SET @CLSVALUE = @CLSVALUE - (SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) FROM STOCKISSUEDETAIL WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<@DOCDATE AND ISNULL(RATE,0)>0)"
            str = str & " 	SET @CLSVALUE = @CLSVALUE + (SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) FROM STOCKADJUSTDETAILS WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<@DOCDATE)"

            str = str & " 	SET @CLSVALUE = @CLSVALUE-(SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) FROM stockdmgdetail WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<=@DOCDATE AND ISNULL(RATE,0)>0)"
            str = str & "      set @CLSVALUE= @CLSVALUE-(SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) FROM STOCKTRANSFERDETAIL WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<=@DOCDATE AND ISNULL(RATE,0)>0 and Fromstorecode=@storecode)"

            '	--	SET @CLSVALUE = @CLSVALUE - (SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) FROM SUBSTORECONSUMPTIONDETAIL WHERE ITEMCODE=@Itemcode AND ISNULL(VOID,'') <> 'Y' and DOCDATE<@DOCDATE)
            '    Print() '8'


            '--	SET @ISSUERATE=0 
            ' --      SET @ISSUERATE=(SELECT TOP 1 ISNULL(RATE,0) AS CLSTK FROM STOCKISSUEDETAIL WHERE ITEMCODE=@ITEMCODE AND ISNULL(VOID,'') <> 'Y' and DOCDATE<@DOCDATE ORDER BY DOCDATE DESC)

            str = str & " SET @LASTRATE=0 "
            str = str & "   SET   @LASTRATE=(SELECT TOP 1 ISNULL(PURCHASERATE,0) AS PURCHASERATE FROM INV_VIEW_WAR_LRATE WHERE ITEMCODE=@ITEMCODE  and GRNDATE<@DOCDATE ORDER BY GRNDATE DESC)"
            '     --    print @LASTRATE
            '	--SET @PURCHASERATE=0 

            '--SET @PURCHASERATE = (SELECT TOP 1 CASE WHEN ISNULL(QTY,0)>0 THEN ISNULL(VALUE,0)/ISNULL(QTY,0) ELSE 0 END FROM INV_VIEW_WAR WHERE ISNULL(QTY,0)>0 and ITEMCODE=@Itemcode AND GRNDATE<=@DOCDATE ORDER BY GRNDATE DESC)

            '--IF (CAST(@CLSSTK AS NUMERIC)=0 AND @LASTRATE>0)
            ' --     BEGIN
            '--	UPDATE STOCKISSUEDETAIL SET WARSTATUS='Y',CLSQTY=@OPSTOCK,CLSVAL=@OPVALUE,RATE=@LASTRATE WHERE ITEMCODE=@ITEMCODE AND DOCDATE BETWEEN @DOCDATE AND @NEXTDATE  AND ISNULL(RATE,0)=0 and itemcode=@ITEMCODE
            '--  END		   
            'Print() '9'
            str = str & " IF (CAST(@CLSSTK AS NUMERIC)>0 AND CAST(@CLSVALUE AS NUMERIC)>0) "
            str = str & "  BEGIN "
            str = str & " 	UPDATE STOCKISSUEDETAIL SET CLSQTY=@CLSSTK,CLSVAL=@CLSVALUE,RATE=ROUND(@LASTRATE,2) WHERE ITEMCODE=@ITEMCODE AND DOCDATE BETWEEN @DOCDATE AND @NEXTDATE AND ISNULL(RATE,0)=0"
            str = str & "     UPDATE STOCKADJUSTDETAILS SET RATE=ROUND(@LASTRATE,2) WHERE ITEMCODE=@ITEMCODE AND DOCDATE BETWEEN @DOCDATE AND @NEXTDATE AND ISNULL(RATE,0)=0"
            str = str & "  UPDATE STOCKDMGDETAIL SET RATE=ROUND(@LASTRATE,2) WHERE ITEMCODE=@ITEMCODE AND DOCDATE BETWEEN @DOCDATE AND @NEXTDATE AND ISNULL(RATE,0)=0"

            str = str & " 	UPDATE STOCKTRANSFERDETAIL SET RATE=ROUND(@LASTRATE,2) WHERE ITEMCODE=@ITEMCODE AND DOCDATE BETWEEN @DOCDATE AND @NEXTDATE AND ISNULL(RATE,0)=0"

            str = str & " 	UPDATE INV_WAR SET CLSQTY=@CLSSTK,CLSVAL=@CLSVALUE,WAR=ROUND(@LASTRATE,2) WHERE ITEMCODE=@ITEMCODE AND GRNDATE=@DOCDATE AND ISNULL(WAR,0)=0"

            str = str & " 	UPDATE STOCKISSUEDETAIL SET AMOUNT=QTY*RATE WHERE ITEMCODE=@ITEMCODE "
            str = str & " UPDATE STOCKADJUSTDETAILS SET AMOUNT=Adjustedstock*RATE WHERE ITEMCODE=@ITEMCODE"
            str = str & "   UPDATE STOCKDMGDETAIL SET AMOUNT=ROUND(QTY*RATE,2) WHERE ITEMCODE=@ITEMCODE "

            str = str & " 	UPDATE STOCKTRANSFERDETAIL SET Amount=ROUND(QTY*RATE,2) WHERE ITEMCODE=@ITEMCODE "

            str = str & "      update inventoryitemmaster set clvalue=@Clsvalue, clstock=@CLSSTK where itemcode=@ITEMCODE and STORECODE=@STORECODE"








            str = str & "    End"





            str = str & " 	Fetch CURPROC into @TAXREBATE,@ITEMCODE,@DOCDATE,@NEXTDATE"
            str = str & "    End"
            str = str & "     Close CURPROC "
            str = str & "     DEALLOCATE CURPROC"

            str = str & " update inventoryitemmaster set purchaserate=@LASTRATE where itemcode=@ITEMCODE and  isnull(clstock,0)>0"


            str = str & " 	UPDATE STOCKISSUEDETAIL SET RATE=@LASTRATE FROM INV_WAR WHERE INV_WAR.ITEMCODE=STOCKISSUEDETAIL.ITEMCODE AND STOCKISSUEDETAIL.DOCDATE BETWEEN INV_WAR.GRNDATE AND INV_WAR.NEXTDATE  and STOCKISSUEDETAIL.ITEMCODE=@Itemcode --AND ISNULL(INV_WAR.WAR,0)<>0 "
            str = str & "  UPDATE STOCKADJUSTDETAILS SET RATE=@LASTRATE FROM INV_WAR WHERE INV_WAR.ITEMCODE=STOCKADJUSTDETAILS.ITEMCODE AND STOCKADJUSTDETAILS.DOCDATE BETWEEN INV_WAR.GRNDATE AND getdate() and isnull(RATE,0)=0 and STOCKADJUSTDETAILS.ITEMCODE=@Itemcode"

            str = str & "         End "



            str = str & "  UPDATE INVENTORYITEMMASTER  SET CLVALUE=0 WHERE CLSTOCK<=0 AND CLVALUE<>0"
            str = str & "   UPDATE INVENTORYITEMMASTER SET OPVALUE=0 WHERE OPSTOCK=0 AND OPVALUE<>0"
            gconnection.dataOperation1(6, str, "item")

        End If






        str = "select * from sysobjects where name='InventoryTransUpdate' and xtype='P'"
        gconnection.getDataSet(str, "InventoryTransUpdate")
        If gdataset.Tables("InventoryTransUpdate").Rows.Count > 0 Then
            str = "        alter        PROCEDURE [dbo].[InventoryTransUpdate](@STORECODE As Varchar(20))  "
            str = str & " as "
            str = str & " Update InventoryItemmaster set InvItmTransValue=0,InvItmTransQty=0,InvItmStockUom=''  "
            str = str & " Update Grn_details set GRNTransValue=0,GrnTransQty=0,GrnStockUom=''  "
            str = str & " Update StockIssueDetail set IssTransValue=0,IssTransQty=0,IssStockUom=''  "
            str = str & " Update StockAdjustDetails set AdjTransValue=0,AdjTransQty=0,AdjStockUom=''  "
            str = str & " Update StockTransferDetail set TRFTransValue=0,TRFTransQty=0,TRFStockUom=''  "
            ' str = str & " --Update StockInOutDetail set IOTransValue=0,IOTransQty=0,IOStockUom=''  "
            str = str & " Update SubStoreConsumptionDetail set SSCTransValue=0,SSCTransQty=0,SSCStockUom=''  "
            str = str & "        Update STOCKDMGDETAIL set DMGStockUom='',DMGTransQty=0,DMGTransValue=0"

            '    str = str & " --**************************INVENTORY ITEMMASTER UPDATION BASED ON SELECTED UOM****************************  "

            str = str & " Update InventoryItemmaster set INVITMTransQty=(InventoryItemmaster.Opstock*b.convvalue),INVITMTransValue=((InventoryItemmaster.opstock*b.convvalue)* (Opvalue/(InventoryItemmaster.opstock*b.convvalue))),InvItmTransRate=(Opvalue/(InventoryItemmaster.opstock"
            str = str & " *b.convvalue))     From   "
            str = str & " INVENTORY_TRANSCONVERSION b where b.baseuom=InventoryItemmaster.StockUOM  and B.transUOM=InventoryItemmaster.SaleUOM  and isnull(opstock,0)>0  "
            str = str & " Update InventoryItemmaster set InvItmStockUom=StockUOM,INVITMTRANSQTY=OPSTOCK,INVITMTRANSVALUE=OPVALUE,InvItmTransRate=PurchaseRate  WHERE ISNULL(InvItmStockUom,'')='' OR ISNULL(INVITMTransQty,0)=0 OR ISNULL(INVITMTRANSVALUE,0)=0  "


            'str = str & " --**************************INVENTORY GRN_DETAILS UPDATION BASED ON SELECTED UOM****************************  "

            'str = str & " update grn_details set GRNStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE grn_details.ITEMCODE=B.ITEMCODE and isnull(B.STORECODE,'')<>'MNS'  "
            'str = str & " --update grn_details set GRNStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE grn_details.ITEMCODE=B.ITEMCODE AND B.STORECODE<>'MNS'  "
            'str = str & " --update Grn_details set GRNTransqty=((Grn_details.qty + isnull(Grn_details.freeqty,0))*b.convvalue),GRNTransValue=((Grn_details.qty*b.convvalue)* (Amount/(Grn_details.qty*b.convvalue))),GrnTransRate=(Amount/(Grn_details.qty*b.convvalue))    From   "
            'str = str & " --INVENTORY_TRANSCONVERSION b where b.baseuom=Grn_details.UOM  and B.transUOM=Grn_details.GRNStockUom  AND @STORECODE<>'MNS'  "
            str = str & " update grn_details set GRNStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE grn_details.ITEMCODE=B.ITEMCODE AND B.STORECODE=@storecode  "
            str = str & " update Grn_details set GRNTransqty=((Grn_details.qty + isnull(Grn_details.freeqty,0))*b.convvalue),GRNTransValue=((Grn_details.qty*b.convvalue)* (Amount/(Grn_details.qty*b.convvalue))),GrnTransRate=(Amount/(Grn_details.qty*b.convvalue))    From   "
            str = str & " INVENTORY_TRANSCONVERSION b where b.baseuom=Grn_details.UOM  and B.transUOM=Grn_details.GRNStockUom AND @STORECODE='MNS'  "
            'str = str & " Update GRN_DETAILS set GRNStockUom=UOM,GRNTRANSQTY=QTY,GRNTRANSVALUE=AMOUNT,GrnTransRate=Rate  WHERE ISNULL(GRNStockUom,'')='' OR ISNULL(GRNTransQty,0)=0 OR ISNULL(GRNTRANSVALUE,0)=0  "

            'str = str & " --**************************INVENTORY STOCK ISSUEDETAILS UPDATION BASED ON SELECTED UOM****************************  "

            str = str & " update StockIssueDetail set ISSStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE StockIssueDetail.ITEMCODE=B.ITEMCODE   AND ISNULL(B.STORECODE,'')<>'MNS'  "
            str = str & " update StockIssueDetail set ISSTransqty=(StockIssueDetail.qty*b.convvalue),ISSTransValue=((StockIssueDetail.qty*b.convvalue)* (Amount/(StockIssueDetail.qty*b.convvalue))),IsstransRate=(Amount/(StockIssueDetail.qty*b.convvalue))  From   "
            str = str & " INVENTORY_TRANSCONVERSION b where b.baseuom=StockIssueDetail.UOM  and B.transUOM=StockIssueDetail.ISSStockUom  AND  @STORECODE <> 'MNS'   "
            str = str & " update StockIssueDetail set ISSStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE StockIssueDetail.ITEMCODE=B.ITEMCODE AND B.STORECODE='MNS'  "
            str = str & " update StockIssueDetail set ISSTransqty=(StockIssueDetail.qty*b.convvalue),ISSTransValue=((StockIssueDetail.qty*b.convvalue)* (Amount/(StockIssueDetail.qty*b.convvalue))),IsstransRate=(Amount/(StockIssueDetail.qty*b.convvalue))  From   "
            str = str & " INVENTORY_TRANSCONVERSION b where b.baseuom=StockIssueDetail.UOM  and B.transUOM=StockIssueDetail.ISSStockUom  AND @STORECODE = 'MNS'  "
            str = str & " Update STOCKISSUEDETAIL set ISSStockUom=UOM,ISSTRANSQTY=QTY,ISSTRANSVALUE=AMOUNT,IsstransRate=Rate WHERE ISNULL(ISSStockUom,'')='' OR ISNULL(ISSTransQty,0)=0 OR ISNULL(ISSTRANSVALUE,0)=0  "

            'str = str & " --**************************INVENTORY STOCK ADJUST DETAILS UPDATION BASED ON SELECTED UOM****************************  "

            str = str & " update Stockadjustdetails set ADJStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE Stockadjustdetails.ITEMCODE=B.ITEMCODE AND ISNULL(B.STORECODE,'')<>'MNS'  "
            str = str & " update Stockadjustdetails set ADJTransqty=(Stockadjustdetails.ADJUSTEDSTOCK*b.convvalue),ADJTransValue=((Stockadjustdetails.ADJUSTEDSTOCK*b.convvalue)* (Amount/(Stockadjustdetails.ADJUSTEDSTOCK*b.convvalue))),AdjTransRate=(Amount/(Stockadjustdetails.ADJUSTEDSTOCK*b.convvalue))  From   "
            str = str & " INVENTORY_TRANSCONVERSION b where b.baseuom=Stockadjustdetails.UOM  and B.transUOM=Stockadjustdetails.ADJStockUom  and Stockadjustdetails.storelocationcode <>'MNS'  and Stockadjustdetails.ADJUSTEDSTOCK >0   "
            str = str & " update Stockadjustdetails set ADJStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE Stockadjustdetails.ITEMCODE=B.ITEMCODE AND B.STORECODE='MNS'  "
            str = str & " update Stockadjustdetails set ADJTransqty=(Stockadjustdetails.ADJUSTEDSTOCK*b.convvalue),ADJTransValue=((Stockadjustdetails.ADJUSTEDSTOCK*b.convvalue)* (Amount/(Stockadjustdetails.ADJUSTEDSTOCK*b.convvalue))),AdjTransRate=(Amount/(Stockadjustdetails.ADJUSTEDSTOCK*b.convvalue))  From   "
            str = str & " INVENTORY_TRANSCONVERSION b where b.baseuom=Stockadjustdetails.UOM  and B.transUOM=Stockadjustdetails.ADJStockUom and Stockadjustdetails.storelocationcode ='MNS'  "
            str = str & " Update Stockadjustdetails set ADJStockUom=UOM,ADJTRANSQTY=ADJUSTEDSTOCK,ADJTRANSVALUE=AMOUNT,AdjTransRate=Rate   WHERE ISNULL(ADJStockUom,'')='' OR ISNULL(ADJTransQty,0)=0 OR ISNULL(ADJTRANSVALUE,0)=0  "

            'str = str & " --**************************INVENTORY STOCK TRANSFER DETAILS UPDATION BASED ON SELECTED UOM****************************  "

            str = str & " update  Stocktransferdetail set TRFStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE  stocktransferdetail.ITEMCODE=B.ITEMCODE AND ISNULL(B.STORECODE,'')<>'MNS'  "
            str = str & " update  Stocktransferdetail set TRFTransqty=( stocktransferdetail.qty*b.convvalue),TRFTransValue=(( stocktransferdetail.qty*b.convvalue)* (Amount/(stocktransferdetail.qty*b.convvalue))),TrfTransRate=(Amount/(stocktransferdetail.qty*b.convvalue))  From   "
            str = str & " INVENTORY_TRANSCONVERSION b where b.baseuom= stocktransferdetail.UOM  and B.transUOM= stocktransferdetail.TRFStockUom  and stocktransferdetail.tostorecode <>'MNS'  "
            str = str & " update  Stocktransferdetail set TRFStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE  stocktransferdetail.ITEMCODE=B.ITEMCODE AND B.STORECODE='MNS'  "
            str = str & " update  Stocktransferdetail set TRFTransqty=( stocktransferdetail.qty*b.convvalue),TRFTransValue=(( stocktransferdetail.qty*b.convvalue)* (Amount/(stocktransferdetail.qty*b.convvalue))),TrfTransRate=(Amount/(stocktransferdetail.qty*b.convvalue))  From   "
            str = str & " INVENTORY_TRANSCONVERSION b where b.baseuom= stocktransferdetail.UOM  and B.transUOM= stocktransferdetail.TRFStockUom and stocktransferdetail.tostorecode = 'MNS'  "
            str = str & " Update  stocktransferdetail  set TRFStockUom=UOM,TRFTRANSQTY=QTY,TRFTRANSVALUE=AMOUNT,TrfTransRate=Rate   WHERE ISNULL(TRFStockUom,'')='' OR ISNULL(TRFTransQty,0)=0 OR ISNULL(TRFTRANSVALUE,0)=0  "

            'str = str & " --**************************INVENTORY STOCK IN AND OUT DETAILS UPDATION BASED ON SELECTED UOM****************************  "

            'str = str & " --update Stockinoutdetail set IOStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE  stockinoutdetail.ITEMCODE=B.ITEMCODE AND stockinoutdetail.doctype = 'IN' --AND ISNULL(B.STORECODE,'')<>'MNS'  "
            'str = str & " --update  Stockinoutdetail set IOTransqty=( stockinoutdetail.qty*b.convvalue),IOTransValue=(( stockinoutdetail.qty*b.convvalue)* (Amount/(stockinoutdetail.qty*b.convvalue))),IOTransRate=(Amount/(stockinoutdetail.qty*b.convvalue))  From   "
            'str = str & " --INVENTORY_TRANSCONVERSION b where b.baseuom= stockinoutdetail.UOM  and B.transUOM= stockinoutdetail.IOStockUom  AND stockinoutdetail.doctype = 'IN' --and stockinoutdetail.storecode <>'MNS'  "
            'str = str & " --update  stockinoutdetail set IOStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE  stockinoutdetail.ITEMCODE=B.ITEMCODE AND stockinoutdetail.doctype = 'OUT' --AND B.STORECODE='MNS'  "
            'str = str & " --update  stockinoutdetail set IOTransqty=( stockinoutdetail.qty*b.convvalue),IOTransValue=(( stockinoutdetail.qty*b.convvalue)* (Amount/(stockinoutdetail.qty*b.convvalue))),IOTransRate=(Amount/(stockinoutdetail.qty*b.convvalue))  From   "
            'str = str & " --INVENTORY_TRANSCONVERSION b where b.baseuom= stockinoutdetail.UOM  and B.transUOM= stockinoutdetail.IOStockUom AND stockinoutdetail.doctype = 'OUT' --and stockinoutdetail.storecode = 'MNS'  "
            '   str = str & " --Update  stockinoutdetail  set IOStockUom=UOM,IOTRANSQTY=QTY,IOTRANSVALUE=AMOUNT,IOTransRate=Rate   WHERE ISNULL(IOStockUom,'')='' OR ISNULL(IOTransQty,0)=0 OR ISNULL(IOTRANSVALUE,0)=0  "

            'str = str & " --**************************INVENTORY SUBSTORE CONSUMPTIONDETAILS UPDATION BASED ON SELECTED UOM****************************  "

            str = str & " update Substoreconsumptiondetail set SSCStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE Substoreconsumptiondetail.ITEMCODE=B.ITEMCODE AND ISNULL(B.STORECODE,'')<>'MNS'  "
            str = str & " update Substoreconsumptiondetail set SSCTransqty=(Substoreconsumptiondetail.qty*b.convvalue),SSCTransValue=((Substoreconsumptiondetail.Qty*b.convvalue)* (Amount/(Substoreconsumptiondetail.Qty*b.convvalue))),SSCTransRate=(Amount/(Substoreconsumptiondetail."
            str = str & " Qty*b.convvalue))  From   "
            str = str & " INVENTORY_TRANSCONVERSION b where b.baseuom=Substoreconsumptiondetail.UOM  and B.transUOM=Substoreconsumptiondetail.SSCStockUom and storelocationcode <>'MNS'  "
            str = str & " update Substoreconsumptiondetail set SSCStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE Substoreconsumptiondetail.ITEMCODE=B.ITEMCODE AND B.STORECODE='MNS'  "
            str = str & " update Substoreconsumptiondetail set SSCTransqty=(Substoreconsumptiondetail.qty*b.convvalue),SSCTransValue=((Substoreconsumptiondetail.Qty*b.convvalue)* (Amount/(Substoreconsumptiondetail.Qty*b.convvalue))),SSCTransRate=(Amount/(Substoreconsumptiondetail."
            str = str & " Qty*b.convvalue))  From   "
            str = str & " INVENTORY_TRANSCONVERSION b where b.baseuom=Substoreconsumptiondetail.UOM  and B.transUOM=Substoreconsumptiondetail.SSCStockUom and storelocationcode ='MNS'  "
            str = str & " Update Substoreconsumptiondetail set SSCStockUom=UOM,SSCTRANSQTY=Qty,SSCTRANSVALUE=AMOUNT,SSCTransRate=Rate WHERE ISNULL(SSCStockUom,'')='' OR ISNULL(SSCTransQty,0)=0 OR ISNULL(SSCTRANSVALUE,0)=0"



            str = str & "           update STOCKDMGDETAIL set DMGStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE STOCKDMGDETAIL.ITEMCODE=B.ITEMCODE   AND ISNULL(B.STORECODE,'')<>'MNS'  "
            str = str & "          update STOCKDMGDETAIL set dmgTransqty=(STOCKDMGDETAIL.qty*b.convvalue),dmgTransValue=((STOCKDMGDETAIL.qty*b.convvalue)* (Amount/(STOCKDMGDETAIL.qty*b.convvalue))),dmgtransRate=(Amount/(STOCKDMGDETAIL.qty*b.convvalue))  From    INVENTORY_TRANSCONVERSION b where b.baseuom=STOCKDMGDETAIL.UOM  and B.transUOM=STOCKDMGDETAIL.dmgStockUom  AND  STORECODE <> 'MNS'   "
            str = str & "        update STOCKDMGDETAIL set DMGStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE STOCKDMGDETAIL.ITEMCODE=B.ITEMCODE AND B.STORECODE='MNS' "
            str = str & "             update STOCKDMGDETAIL set dmgTransqty=(STOCKDMGDETAIL.qty*b.convvalue),dmgTransValue=((STOCKDMGDETAIL.qty*b.convvalue)* (Amount/(STOCKDMGDETAIL.qty*b.convvalue))),dmgtransRate=(Amount/(STOCKDMGDETAIL.qty*b.convvalue))  From    INVENTORY_TRANSCONVERSION b where b.baseuom=STOCKDMGDETAIL.UOM  and B.transUOM=STOCKDMGDETAIL.dmgStockUom  AND STORECODE = 'MNS'  "
            str = str & "          Update STOCKDMGDETAIL set DMGStockUom=UOM,dmgTransqty=QTY,dmgTransValue=AMOUNT,dmgtransRate=Rate WHERE ISNULL(DMGStockUom,'')='' OR ISNULL(dmgTransqty,0)=0 OR ISNULL(dmgTransValue,0)=0 "


            gconnection.dataOperation1(6, str, "item")

        Else

            str = "        create        PROCEDURE [dbo].[InventoryTransUpdate](@STORECODE As Varchar(20))  "
            str = str & " as "
            str = str & " Update InventoryItemmaster set InvItmTransValue=0,InvItmTransQty=0,InvItmStockUom=''  "
            str = str & " Update Grn_details set GRNTransValue=0,GrnTransQty=0,GrnStockUom=''  "
            str = str & " Update StockIssueDetail set IssTransValue=0,IssTransQty=0,IssStockUom=''  "
            str = str & " Update StockAdjustDetails set AdjTransValue=0,AdjTransQty=0,AdjStockUom=''  "
            str = str & " Update StockTransferDetail set TRFTransValue=0,TRFTransQty=0,TRFStockUom=''  "
            ' str = str & " --Update StockInOutDetail set IOTransValue=0,IOTransQty=0,IOStockUom=''  "
            str = str & " Update SubStoreConsumptionDetail set SSCTransValue=0,SSCTransQty=0,SSCStockUom=''  "

            '    str = str & " --**************************INVENTORY ITEMMASTER UPDATION BASED ON SELECTED UOM****************************  "

            str = str & " Update InventoryItemmaster set INVITMTransQty=(InventoryItemmaster.Opstock*b.convvalue),INVITMTransValue=((InventoryItemmaster.opstock*b.convvalue)* (Opvalue/(InventoryItemmaster.opstock*b.convvalue))),InvItmTransRate=(Opvalue/(InventoryItemmaster.opstock"
            str = str & " *b.convvalue))     From   "
            str = str & " INVENTORY_TRANSCONVERSION b where b.baseuom=InventoryItemmaster.StockUOM  and B.transUOM=InventoryItemmaster.SaleUOM  and isnull(opstock,0)>0  "
            str = str & " Update InventoryItemmaster set InvItmStockUom=StockUOM,INVITMTRANSQTY=OPSTOCK,INVITMTRANSVALUE=OPVALUE,InvItmTransRate=PurchaseRate  WHERE ISNULL(InvItmStockUom,'')='' OR ISNULL(INVITMTransQty,0)=0 OR ISNULL(INVITMTRANSVALUE,0)=0  "


            'str = str & " --**************************INVENTORY GRN_DETAILS UPDATION BASED ON SELECTED UOM****************************  "

            str = str & " update grn_details set GRNStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE grn_details.ITEMCODE=B.ITEMCODE and isnull(B.STORECODE,'')<>'MNS'  "
            'str = str & " --update grn_details set GRNStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE grn_details.ITEMCODE=B.ITEMCODE AND B.STORECODE<>'MNS'  "
            'str = str & " --update Grn_details set GRNTransqty=((Grn_details.qty + isnull(Grn_details.freeqty,0))*b.convvalue),GRNTransValue=((Grn_details.qty*b.convvalue)* (Amount/(Grn_details.qty*b.convvalue))),GrnTransRate=(Amount/(Grn_details.qty*b.convvalue))    From   "
            'str = str & " --INVENTORY_TRANSCONVERSION b where b.baseuom=Grn_details.UOM  and B.transUOM=Grn_details.GRNStockUom  AND @STORECODE<>'MNS'  "
            str = str & " update grn_details set GRNStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE grn_details.ITEMCODE=B.ITEMCODE AND B.STORECODE='MNS'  "
            str = str & " update Grn_details set GRNTransqty=((Grn_details.qty + isnull(Grn_details.freeqty,0))*b.convvalue),GRNTransValue=((Grn_details.qty*b.convvalue)* (Amount/(Grn_details.qty*b.convvalue))),GrnTransRate=(Amount/(Grn_details.qty*b.convvalue))    From   "
            str = str & " INVENTORY_TRANSCONVERSION b where b.baseuom=Grn_details.UOM  and B.transUOM=Grn_details.GRNStockUom AND @STORECODE='MNS'  "
            str = str & " Update GRN_DETAILS set GRNStockUom=UOM,GRNTRANSQTY=QTY,GRNTRANSVALUE=AMOUNT,GrnTransRate=Rate  WHERE ISNULL(GRNStockUom,'')='' OR ISNULL(GRNTransQty,0)=0 OR ISNULL(GRNTRANSVALUE,0)=0  "

            'str = str & " --**************************INVENTORY STOCK ISSUEDETAILS UPDATION BASED ON SELECTED UOM****************************  "

            str = str & " update StockIssueDetail set ISSStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE StockIssueDetail.ITEMCODE=B.ITEMCODE   AND ISNULL(B.STORECODE,'')<>'MNS'  "
            str = str & " update StockIssueDetail set ISSTransqty=(StockIssueDetail.qty*b.convvalue),ISSTransValue=((StockIssueDetail.qty*b.convvalue)* (Amount/(StockIssueDetail.qty*b.convvalue))),IsstransRate=(Amount/(StockIssueDetail.qty*b.convvalue))  From   "
            str = str & " INVENTORY_TRANSCONVERSION b where b.baseuom=StockIssueDetail.UOM  and B.transUOM=StockIssueDetail.ISSStockUom  AND  @STORECODE <> 'MNS'   "
            str = str & " update StockIssueDetail set ISSStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE StockIssueDetail.ITEMCODE=B.ITEMCODE AND B.STORECODE='MNS'  "
            str = str & " update StockIssueDetail set ISSTransqty=(StockIssueDetail.qty*b.convvalue),ISSTransValue=((StockIssueDetail.qty*b.convvalue)* (Amount/(StockIssueDetail.qty*b.convvalue))),IsstransRate=(Amount/(StockIssueDetail.qty*b.convvalue))  From   "
            str = str & " INVENTORY_TRANSCONVERSION b where b.baseuom=StockIssueDetail.UOM  and B.transUOM=StockIssueDetail.ISSStockUom  AND @STORECODE = 'MNS'  "
            str = str & " Update STOCKISSUEDETAIL set ISSStockUom=UOM,ISSTRANSQTY=QTY,ISSTRANSVALUE=AMOUNT,IsstransRate=Rate WHERE ISNULL(ISSStockUom,'')='' OR ISNULL(ISSTransQty,0)=0 OR ISNULL(ISSTRANSVALUE,0)=0  "

            'str = str & " --**************************INVENTORY STOCK ADJUST DETAILS UPDATION BASED ON SELECTED UOM****************************  "

            str = str & " update Stockadjustdetails set ADJStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE Stockadjustdetails.ITEMCODE=B.ITEMCODE AND ISNULL(B.STORECODE,'')<>'MNS'  "
            str = str & " update Stockadjustdetails set ADJTransqty=(Stockadjustdetails.ADJUSTEDSTOCK*b.convvalue),ADJTransValue=((Stockadjustdetails.ADJUSTEDSTOCK*b.convvalue)* (Amount/(Stockadjustdetails.ADJUSTEDSTOCK*b.convvalue))),AdjTransRate=(Amount/(Stockadjustdetails.ADJUSTEDSTOCK*b.convvalue))  From   "
            str = str & " INVENTORY_TRANSCONVERSION b where b.baseuom=Stockadjustdetails.UOM  and B.transUOM=Stockadjustdetails.ADJStockUom  and Stockadjustdetails.storelocationcode <>'MNS'  "
            str = str & " update Stockadjustdetails set ADJStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE Stockadjustdetails.ITEMCODE=B.ITEMCODE AND B.STORECODE='MNS'  "
            str = str & " update Stockadjustdetails set ADJTransqty=(Stockadjustdetails.ADJUSTEDSTOCK*b.convvalue),ADJTransValue=((Stockadjustdetails.ADJUSTEDSTOCK*b.convvalue)* (Amount/(Stockadjustdetails.ADJUSTEDSTOCK*b.convvalue))),AdjTransRate=(Amount/(Stockadjustdetails.ADJUSTEDSTOCK*b.convvalue))  From   "
            str = str & " INVENTORY_TRANSCONVERSION b where b.baseuom=Stockadjustdetails.UOM  and B.transUOM=Stockadjustdetails.ADJStockUom and Stockadjustdetails.storelocationcode ='MNS'  "
            str = str & " Update Stockadjustdetails set ADJStockUom=UOM,ADJTRANSQTY=ADJUSTEDSTOCK,ADJTRANSVALUE=AMOUNT,AdjTransRate=Rate   WHERE ISNULL(ADJStockUom,'')='' OR ISNULL(ADJTransQty,0)=0 OR ISNULL(ADJTRANSVALUE,0)=0  "

            'str = str & " --**************************INVENTORY STOCK TRANSFER DETAILS UPDATION BASED ON SELECTED UOM****************************  "

            str = str & " update  Stocktransferdetail set TRFStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE  stocktransferdetail.ITEMCODE=B.ITEMCODE AND ISNULL(B.STORECODE,'')<>'MNS'  "
            str = str & " update  Stocktransferdetail set TRFTransqty=( stocktransferdetail.qty*b.convvalue),TRFTransValue=(( stocktransferdetail.qty*b.convvalue)* (Amount/(stocktransferdetail.qty*b.convvalue))),TrfTransRate=(Amount/(stocktransferdetail.qty*b.convvalue))  From   "
            str = str & " INVENTORY_TRANSCONVERSION b where b.baseuom= stocktransferdetail.UOM  and B.transUOM= stocktransferdetail.TRFStockUom  and stocktransferdetail.tostorecode <>'MNS'  "
            str = str & " update  Stocktransferdetail set TRFStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE  stocktransferdetail.ITEMCODE=B.ITEMCODE AND B.STORECODE='MNS'  "
            str = str & " update  Stocktransferdetail set TRFTransqty=( stocktransferdetail.qty*b.convvalue),TRFTransValue=(( stocktransferdetail.qty*b.convvalue)* (Amount/(stocktransferdetail.qty*b.convvalue))),TrfTransRate=(Amount/(stocktransferdetail.qty*b.convvalue))  From   "
            str = str & " INVENTORY_TRANSCONVERSION b where b.baseuom= stocktransferdetail.UOM  and B.transUOM= stocktransferdetail.TRFStockUom and stocktransferdetail.tostorecode = 'MNS'  "
            str = str & " Update  stocktransferdetail  set TRFStockUom=UOM,TRFTRANSQTY=QTY,TRFTRANSVALUE=AMOUNT,TrfTransRate=Rate   WHERE ISNULL(TRFStockUom,'')='' OR ISNULL(TRFTransQty,0)=0 OR ISNULL(TRFTRANSVALUE,0)=0  "

            'str = str & " --**************************INVENTORY STOCK IN AND OUT DETAILS UPDATION BASED ON SELECTED UOM****************************  "

            'str = str & " --update Stockinoutdetail set IOStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE  stockinoutdetail.ITEMCODE=B.ITEMCODE AND stockinoutdetail.doctype = 'IN' --AND ISNULL(B.STORECODE,'')<>'MNS'  "
            'str = str & " --update  Stockinoutdetail set IOTransqty=( stockinoutdetail.qty*b.convvalue),IOTransValue=(( stockinoutdetail.qty*b.convvalue)* (Amount/(stockinoutdetail.qty*b.convvalue))),IOTransRate=(Amount/(stockinoutdetail.qty*b.convvalue))  From   "
            'str = str & " --INVENTORY_TRANSCONVERSION b where b.baseuom= stockinoutdetail.UOM  and B.transUOM= stockinoutdetail.IOStockUom  AND stockinoutdetail.doctype = 'IN' --and stockinoutdetail.storecode <>'MNS'  "
            'str = str & " --update  stockinoutdetail set IOStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE  stockinoutdetail.ITEMCODE=B.ITEMCODE AND stockinoutdetail.doctype = 'OUT' --AND B.STORECODE='MNS'  "
            'str = str & " --update  stockinoutdetail set IOTransqty=( stockinoutdetail.qty*b.convvalue),IOTransValue=(( stockinoutdetail.qty*b.convvalue)* (Amount/(stockinoutdetail.qty*b.convvalue))),IOTransRate=(Amount/(stockinoutdetail.qty*b.convvalue))  From   "
            'str = str & " --INVENTORY_TRANSCONVERSION b where b.baseuom= stockinoutdetail.UOM  and B.transUOM= stockinoutdetail.IOStockUom AND stockinoutdetail.doctype = 'OUT' --and stockinoutdetail.storecode = 'MNS'  "
            '   str = str & " --Update  stockinoutdetail  set IOStockUom=UOM,IOTRANSQTY=QTY,IOTRANSVALUE=AMOUNT,IOTransRate=Rate   WHERE ISNULL(IOStockUom,'')='' OR ISNULL(IOTransQty,0)=0 OR ISNULL(IOTRANSVALUE,0)=0  "

            'str = str & " --**************************INVENTORY SUBSTORE CONSUMPTIONDETAILS UPDATION BASED ON SELECTED UOM****************************  "

            str = str & " update Substoreconsumptiondetail set SSCStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE Substoreconsumptiondetail.ITEMCODE=B.ITEMCODE AND ISNULL(B.STORECODE,'')<>'MNS'  "
            str = str & " update Substoreconsumptiondetail set SSCTransqty=(Substoreconsumptiondetail.qty*b.convvalue),SSCTransValue=((Substoreconsumptiondetail.Qty*b.convvalue)* (Amount/(Substoreconsumptiondetail.Qty*b.convvalue))),SSCTransRate=(Amount/(Substoreconsumptiondetail."
            str = str & " Qty*b.convvalue))  From   "
            str = str & " INVENTORY_TRANSCONVERSION b where b.baseuom=Substoreconsumptiondetail.UOM  and B.transUOM=Substoreconsumptiondetail.SSCStockUom and storelocationcode <>'MNS'  "
            str = str & " update Substoreconsumptiondetail set SSCStockUom=B.SaleUOM FROM INVENTORYITEMMASTER B WHERE Substoreconsumptiondetail.ITEMCODE=B.ITEMCODE AND B.STORECODE='MNS'  "
            str = str & " update Substoreconsumptiondetail set SSCTransqty=(Substoreconsumptiondetail.qty*b.convvalue),SSCTransValue=((Substoreconsumptiondetail.Qty*b.convvalue)* (Amount/(Substoreconsumptiondetail.Qty*b.convvalue))),SSCTransRate=(Amount/(Substoreconsumptiondetail."
            str = str & " Qty*b.convvalue))  From   "
            str = str & " INVENTORY_TRANSCONVERSION b where b.baseuom=Substoreconsumptiondetail.UOM  and B.transUOM=Substoreconsumptiondetail.SSCStockUom and storelocationcode ='MNS'  "
            str = str & " Update Substoreconsumptiondetail set SSCStockUom=UOM,SSCTRANSQTY=Qty,SSCTRANSVALUE=AMOUNT,SSCTransRate=Rate WHERE ISNULL(SSCStockUom,'')='' OR ISNULL(SSCTransQty,0)=0 OR ISNULL(SSCTRANSVALUE,0)=0"
            gconnection.dataOperation1(6, str, "item")

        End If


        'str = "select * from sysobjects where name='Cp_StockSummary3' and xtype='P'"
        'gconnection.getDataSet(str, "Cp_StockSummary3")
        'If gdataset.Tables("Cp_StockSummary3").Rows.Count > 0 Then
        '    'str = "    alter                                        PROCEDURE [dbo].[Cp_StockSummary3](@STORECODE As Varchar(20),@FROMDATE AS datetime, @TODATE AS datetime, @FINYEARSTART AS datetime,@TODAT AS datetime)"
        '    'str = str & " AS"
        '    'str = str & " DECLARE @SSQL Varchar(2000),@SQL Varchar(2000),@ITEMCODE Varchar(500),@ITEMNAME Varchar(11)"
        '    'str = str & " DECLARE @OPSTOCK NUMERIC(18,3),@ISSQTY NUMERIC(18,3),@ISSVAL NUMERIC(18,2),@OPVALUE NUMERIC(18,2),@RCVQTY NUMERIC(18,3),@RCVVAL NUMERIC(18,2),@STOCKUOM AS VARCHAR(15),@OUTFILE Varchar(10)"
        '    'str = str & " declare @pqty numeric(18,6),@ml numeric(18,3),@IQTY numeric(18,3),@PEGS NUMERIC(18,3)"
        '    'str = str & " DECLARE @OPSTK NUMERIC(18,3),@OPVAL NUMERIC(18,2),@SALEUOM VARCHAR(500)"
        '    'str = str & " declare @category varchar(50)"
        '    'str = str & " DECLARE @OPDATE AS datetime"

        '    'str = str & " SET @OPDATE  = @FROMDATE"
        '    'str = str & " PRINT @OPDATE"

        '    'str = str & " SET @SSQL= 'DELETE FROM STOCKSUMMARY'"
        '    'str = str & " EXEC (@SSQL)"

        '    'str = str & " SET @SSQL= 'DELETE FROM STKSUMMARY'"
        '    'str = str & " EXEC (@SSQL)"

        '    ''  str = str & " --SET @SALEUOM ='SELECT SALEUOM FROM INVENTORYITEMMASTER WHERE STORECODE = @STORECODE'"

        '    'str = str & " EXEC INVENTORYTRANSUPDATE @STORECODE"


        '    'str = str & " INSERT INTO STKSUMMARY(ITEMCODE,ITEMNAME,UOM,OPQTY,OPVAL,STORECODE,GROUPCODE,GROUPNAME,SUBGROUPCODE,SUBGROUPNAME) "
        '    'str = str & " SELECT I.ITEMCODE,I.ITEMNAME,I.STOCKUOM,ROUND(ISNULL(I.INVITMTRANSQTY,0),3),ROUND(ISNULL(I.INVITMTRANSVALUE,0),2),"
        '    'str = str & " I.STORECODE,I.GROUPCODE,I.GROUPNAME,I.SUBGROUPCODE,I.SUBGROUPNAME FROM INVENTORYITEMMASTER AS I "
        '    'str = str & " WHERE STORECODE = @STORECODE "

        '    ''str = str & " ---GRN"
        '    'str = str & " INSERT INTO STKSUMMARY(ITEMCODE,OPQTY,OPVAL,STORECODE) "
        '    'str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(GRNTRANSQTY,0)),0),ISNULL(SUM(isnull(GRNTRANSVALUE,0)),0)+ISNULL(SUM(isnull(TAXAMOUNT,0)),0)+ISNULL(SUM(isnull(OTHCHARGE,0)),0)-ISNULL(SUM(isnull(DISCOUNT,0)),0),STORECODE FROM GRN_DETAILS WHERE ISNULL(VOIDITEM,'') <> 'Y'  AND ISNULL(GrnType,'')='GRN' AND GRNDATE BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) AND Storecode=@STORECODE GROUP BY Storecode,ITEMCODE"

        '    ''str = str & " ---PRN"
        '    'str = str & " INSERT INTO STKSUMMARY(ITEMCODE,OPQTY,OPVAL,STORECODE) "
        '    'str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(GRNTRANSQTY,0)),0)*-1,ISNULL(SUM(isnull(GRNTRANSVALUE,0)),0)+ISNULL(SUM(isnull(TAXAMOUNT,0)),0)+ISNULL(SUM(isnull(OTHCHARGE,0)),0)-ISNULL(SUM(isnull(DISCOUNT,0)),0),STORECODE FROM GRN_DETAILS WHERE ISNULL(VOIDITEM,'') <> 'Y' AND ISNULL(GrnType,'')='PRN'  AND GRNDATE BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) AND Storecode=@STORECODE GROUP BY Storecode,ITEMCODE"

        '    'str = str & " INSERT INTO STKSUMMARY(ITEMCODE,OPQTY,OPVAL,STORECODE) "
        '    'str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(ISSTRANSQTY,0)),0)*-1,ISNULL(SUM(isnull(ISSTRANSVALUE,0)),0)*-1,Storelocationcode FROM STOCKISSUEDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) AND Storelocationcode=@STORECODE GROUP BY ITEMCODE,Storelocationcode"

        '    'str = str & " INSERT INTO STKSUMMARY(ITEMCODE,OPQTY,OPVAL,STORECODE) "
        '    'str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(ISSTRANSQTY,0)),0),ISNULL(SUM(isnull(ISSTRANSVALUE,0)),0),OPStorelocationcode"
        '    'str = str & " FROM STOCKISSUEDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) AND OPStorelocationcode=@STORECODE GROUP BY OPStorelocationcode,ITEMCODE"

        '    'str = str & " INSERT INTO  STKSUMMARY(ITEMCODE,OPQTY,OPVAL,STORECODE) "
        '    'str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(TRFTRANSQTY,0)),0),ISNULL(SUM(isnull(TRFTRANSVALUE,0)),0),TOSTORECODE"
        '    'str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) AND TOSTORECODE=@STORECODE GROUP BY TOSTORECODE,ITEMCODE"
        '    ''   str = str & " Print 'venu'"

        '    'str = str & " INSERT INTO STKSUMMARY(ITEMCODE,ISSQTY,ISSVAL,STORECODE) "
        '    'str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(dmgTRANSQTY,0)),0),ISNULL(SUM(isnull(dmgTRANSVALUE,0)),0),storecode"
        '    'str = str & " FROM stockdmgdetail WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) AND storecode=@STORECODE GROUP BY storecode,ITEMCODE"

        '    'str = str & " INSERT INTO STKSUMMARY(ITEMCODE,OPQTY,OPVAL,STORECODE) "
        '    'str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(TRFTRANSQTY,0)),0)*-1,ISNULL(SUM(isnull(TRFTRANSVALUE,0)),0)*-1,FROMSTORECODE"
        '    'str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) AND FROMSTORECODE=@STORECODE GROUP BY FROMSTORECODE,ITEMCODE"

        '    'str = str & " INSERT INTO STKSUMMARY(ITEMCODE,OPQTY,OPVAL,STORECODE) "
        '    'str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(ADJTRANSQTY,0)),0),ISNULL(SUM(isnull(ADJTRANSVALUE,0)),0),STORELOCATIONCODE"
        '    'str = str & " FROM STOCKADJUSTDETAILS WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) AND STORELOCATIONCODE=@STORECODE AND ISNULL(ADJUSTEDSTOCK,0)>0 GROUP BY STORELOCATIONCODE,ITEMCODE"

        '    'str = str & " INSERT INTO STKSUMMARY(ITEMCODE,OPQTY,OPVAL,STORECODE) "
        '    'str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(ADJTRANSQTY,0)),0),ISNULL(SUM(isnull(ADJTRANSVALUE,0)),0),STORELOCATIONCODE"
        '    'str = str & " FROM STOCKADJUSTDETAILS WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) AND STORELOCATIONCODE=@STORECODE AND ISNULL(ADJUSTEDSTOCK,0)<=0 GROUP BY STORELOCATIONCODE,ITEMCODE"


        '    'str = str & " INSERT INTO STKSUMMARY(ITEMCODE,OPQTY,OPVAL,STORECODE) "
        '    'str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(SSCTRANSQTY,0)),0)*-1,ISNULL(SUM(isnull(SSCTRANSVALUE,0)),0)*-1,STORELOCATIONCODE"
        '    'str = str & " FROM SUBSTORECONSUMPTIONDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) AND STORELOCATIONCODE=@STORECODE GROUP BY STORELOCATIONCODE,ITEMCODE"


        '    'str = str & " INSERT INTO STKSUMMARY(ITEMCODE,RCVQTY,RCVVAL,STORECODE) "
        '    'str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(GRNTRANSQTY,0)),0),ISNULL(SUM(isnull(GRNTRANSVALUE,0)),0)+ISNULL(SUM(isnull(TAXAMOUNT,0)),0)+ISNULL(SUM(isnull(OTHCHARGE,0)),0)-ISNULL(SUM(isnull(DISCOUNT,0)),0),STORECODE FROM GRN_DETAILS WHERE ISNULL(VOIDITEM,'') <> 'Y'  and Isnull(GrnType,'')='GRN' AND GRNDATE BETWEEN @FROMDATE AND @TODATE AND Storecode=@STORECODE GROUP BY Storecode,ITEMCODE"

        '    'str = str & " INSERT INTO STKSUMMARY(ITEMCODE,RCVQTY,RCVVAL,STORECODE) "
        '    'str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(ISSTRANSQTY,0)),0),ISNULL(SUM(isnull(ISSTRANSVALUE,0)),0),OPStorelocationcode "
        '    'str = str & " FROM STOCKISSUEDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FROMDATE AND @TODATE AND OPStorelocationcode=@STORECODE GROUP BY OPStorelocationcode,ITEMCODE"

        '    'str = str & " INSERT INTO STKSUMMARY(ITEMCODE,RCVQTY,RCVVAL,STORECODE) "
        '    'str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(TRFTRANSQTY,0)),0),ISNULL(SUM(isnull(TRFTRANSVALUE,0)),0),TOSTORECODE"
        '    'str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FROMDATE AND @TODATE AND TOSTORECODE=@STORECODE GROUP BY TOSTORECODE,ITEMCODE"
        '    ''     str = str & " Print 'venu1'"

        '    'str = str & " INSERT INTO STKSUMMARY(ITEMCODE,RCVQTY,RCVVAL,STORECODE) "
        '    'str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(ADJTRANSQTY,0)),0),ISNULL(SUM(isnull(ADJTRANSVALUE,0)),0),STORELOCATIONCODE"
        '    'str = str & " FROM STOCKADJUSTDETAILS WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FROMDATE AND @TODATE AND STORELOCATIONCODE=@STORECODE AND ISNULL(ADJUSTEDSTOCK,0)>0 GROUP BY STORELOCATIONCODE,ITEMCODE"


        '    ''str = str & " ---PRN"
        '    'str = str & " INSERT INTO STKSUMMARY(ITEMCODE,ISSQTY,ISSVAL,STORECODE)  "
        '    'str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(GRNTRANSQTY,0)),0),ISNULL(SUM(isnull(GRNTRANSVALUE,0)),0)+ISNULL(SUM(isnull(TAXAMOUNT,0)),0)+ISNULL(SUM(isnull(OTHCHARGE,0)),0)-ISNULL(SUM(isnull(DISCOUNT,0)),0),STORECODE FROM GRN_DETAILS WHERE ISNULL(VOIDITEM,'') <> 'Y' AND ISNULL(GrnType,'')='PRN'  AND GRNDATE BETWEEN @FROMDATE AND @TODATE  AND Storecode=@STORECODE GROUP BY Storecode,ITEMCODE"

        '    'str = str & " INSERT INTO STKSUMMARY(ITEMCODE,ISSQTY,ISSVAL,STORECODE) "
        '    'str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(ISSTRANSQTY,0)),0),ISNULL(SUM(isnull(ISSTRANSVALUE,0)),0),Storelocationcode"
        '    'str = str & " FROM STOCKISSUEDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FROMDATE AND @TODATE AND Storelocationcode=@STORECODE GROUP BY Storelocationcode,ITEMCODE"

        '    'str = str & " INSERT INTO STKSUMMARY(ITEMCODE,ISSQTY,ISSVAL,STORECODE) "
        '    'str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(TRFTRANSQTY,0)),0),ISNULL(SUM(isnull(TRFTRANSVALUE,0)),0),FROMSTORECODE"
        '    'str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FROMDATE AND @TODATE AND FROMSTORECODE=@STORECODE GROUP BY FROMSTORECODE,ITEMCODE"

        '    'str = str & " INSERT INTO STKSUMMARY(ITEMCODE,ISSQTY,ISSVAL,STORECODE) "
        '    'str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(ADJTRANSQTY,0)),0)*-1,ISNULL(SUM(isnull(ADJTRANSVALUE,0)),0)*-1,STORELOCATIONCODE"
        '    'str = str & " FROM STOCKADJUSTDETAILS WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FROMDATE AND @TODATE AND STORELOCATIONCODE=@STORECODE "
        '    'str = str & " AND ISNULL(ADJUSTEDSTOCK,0)<=0 GROUP BY STORELOCATIONCODE,ITEMCODE"

        '    'str = str & " INSERT INTO STKSUMMARY(ITEMCODE,ISSQTY,ISSVAL,STORECODE) "
        '    'str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(SSCTRANSQTY,0)),0),ISNULL(SUM(isnull(SSCTRANSVALUE,0)),0),STORELOCATIONCODE"
        '    'str = str & " FROM SUBSTORECONSUMPTIONDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FROMDATE AND @TODATE AND STORELOCATIONCODE=@STORECODE GROUP BY STORELOCATIONCODE,ITEMCODE"


        '    'str = str & " INSERT INTO STKSUMMARY(ITEMCODE,ISSQTY,ISSVAL,STORECODE) "
        '    'str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(dmgTRANSQTY,0)),0),ISNULL(SUM(isnull(dmgTRANSVALUE,0)),0),storecode"
        '    'str = str & " FROM stockdmgdetail WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FROMDATE AND @TODATE AND storecode=@STORECODE GROUP BY storecode,ITEMCODE"


        '    ''str = str & " --Adjustment"
        '    ''str = str & " --ALTER TABLE STOCKSUMMARY DROP COLUMN ADLQTY NUMERIC(18,3)"

        '    'str = str & " INSERT INTO STKSUMMARY(ITEMCODE,ADJQTY,ADJVAL,STORECODE) "
        '    'str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(ADJTRANSQTY,0)),0),ISNULL(SUM(isnull(ADJTRANSVALUE,0)),0),STORELOCATIONCODE"
        '    'str = str & " FROM STOCKADJUSTDETAILS WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FROMDATE AND @TODATE AND STORELOCATIONCODE=@STORECODE "
        '    'str = str & " GROUP BY STORELOCATIONCODE,ITEMCODE"

        '    'str = str & " INSERT INTO STOCKSUMMARY (STORECODE,Itemcode,Opqty,Opval,Rcvqty,Rcvval,Issqty,Issval,adjqty,adjval) "
        '    'str = str & " (SELECT STORECODE,Itemcode,SUM(Opqty),SUM(Opval),SUM(Rcvqty),SUM(Rcvval),SUM(Issqty),SUM(Issval),SUM(Adjqty),SUM(Adjval) FROM STKSUMMARY "
        '    'str = str & " GROUP BY STORECODE,Itemcode)"


        '    'str = str & " UPDATE STOCKSUMMARY SET Itemname=B.itemNAME FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=STOCKSUMMARY.ITEMCODE AND STOCKSUMMARY.STORECODE=B.STORECODE"
        '    'str = str & " UPDATE STOCKSUMMARY SET UOM=STOCKUOM FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=STOCKSUMMARY.ITEMCODE AND STOCKSUMMARY.STORECODE=B.STORECODE"
        '    'str = str & " UPDATE STOCKSUMMARY SET GROUPCODE=B.GROUPCODE FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=STOCKSUMMARY.ITEMCODE AND STOCKSUMMARY.STORECODE=B.STORECODE"
        '    'str = str & " UPDATE STOCKSUMMARY SET GROUPNAME=B.GROUPNAME FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=STOCKSUMMARY.ITEMCODE AND STOCKSUMMARY.STORECODE=B.STORECODE"
        '    'str = str & " UPDATE STOCKSUMMARY SET SUBGROUPCODE=B.SUBGROUPCODE FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=STOCKSUMMARY.ITEMCODE AND STOCKSUMMARY.STORECODE=B.STORECODE"
        '    'str = str & " UPDATE STOCKSUMMARY SET SUBGROUPNAME=B.SUBGROUPNAME FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=STOCKSUMMARY.ITEMCODE AND STOCKSUMMARY.STORECODE=B.STORECODE"
        '    'str = str & " UPDATE STOCKSUMMARY SET CATEGORY =B.CATEGORY FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=STOCKSUMMARY.ITEMCODE AND STOCKSUMMARY.STORECODE=B.STORECODE"

        '    ''str = str & " --alter table stksummary add CATEGORY varchar(50)"
        '    ''str = str & " --alter table stocksummary add CATEGORY varchar(50)"

        '    'str = str & " UPDATE STOCKSUMMARY SET Opqty=ISNULL(Opqty,0)"
        '    'str = str & " UPDATE STOCKSUMMARY SET Oprate=ISNULL(Oprate,0)"
        '    'str = str & " UPDATE STOCKSUMMARY SET Opval=ISNULL(Opval,0)"
        '    'str = str & " UPDATE STOCKSUMMARY SET Rcvqty=ISNULL(Rcvqty,0)"
        '    'str = str & " UPDATE STOCKSUMMARY SET Rcvrate=ISNULL(Rcvrate,0)"
        '    'str = str & " UPDATE STOCKSUMMARY SET Rcvval=ISNULL(Rcvval,0)"
        '    'str = str & " UPDATE STOCKSUMMARY SET Issqty=ISNULL(Issqty,0)"
        '    'str = str & " UPDATE STOCKSUMMARY SET Issrate=ISNULL(Issrate,0)"
        '    'str = str & " UPDATE STOCKSUMMARY SET Issval=ISNULL(Issval,0)"
        '    'str = str & " UPDATE STOCKSUMMARY SET Clsqty=ISNULL(Clsqty,0)"
        '    'str = str & " UPDATE STOCKSUMMARY SET Clsrate=ISNULL(Clsrate,0)"
        '    'str = str & " UPDATE STOCKSUMMARY SET Clsval=ISNULL(Clsval,0)"

        '    'str = str & " UPDATE STOCKSUMMARY SET Clsqty=OPQTY+RCVQTY-ISSQTY"
        '    'str = str & " UPDATE STOCKSUMMARY SET ClsVAL=OPVAL+RCVVAL-ISSVAL"

        '    'str = str & " update inventoryitemmaster set closingqty = Clsqty, closingval = clsval from STOCKSUMMARY s where s.itemcode = inventoryitemmaster.itemcode and inventoryitemmaster.STORECODE = s.STORECODE  and inventoryitemmaster.STORECODE = @STORECODE "

        '    'str = str & " drop table stkpurchaserate"


        '    ''str = str & " --create table stkpurchaserate (grndate datetime,itemcode varchar(50),rate numeric(18,2))"
        '    ''str = str & " --insert into stkpurchaserate (grndate,itemcode,rate) (select max(grndate) as grndate,itemcode,(sum(amount+taxamount))/sum(qty) as rate from grn_details where grndate<=@TODAT group by itemcode)"
        '    ''str = str & " --insert into stkpurchaserate (grndate,itemcode,rate) (select getdate(),itemcode,purchaserate from inventoryitemmaster where itemcode not in (select itemcode from grn_details where grndate<=@TODAT))"
        '    ''str = str & " --update stkpurchaserate set rate=(select sum(amount+taxamount)/sum(qty) from grn_details b where b.grndate=stkpurchaserate.grndate and b.itemcode=stkpurchaserate.itemcode)"

        '    ''str = str & " --create table stkpurchaserate (grndate datetime,itemcode varchar(50),rate numeric(18,2),uom varchar(50))"
        '    'str = str & " create table stkpurchaserate (grndate datetime,OPdate datetime,itemcode varchar(50),rate numeric(18,2),uom varchar(50),oprate numeric(18,2))"

        '    'str = str & " insert into stkpurchaserate (grndate,itemcode,rate) (select max(grndate) as grndate,itemcode,(sum(amount+taxamount))/sum(qty) as rate from grn_details where grndate<=@TODAT group by itemcode)"
        '    'str = str & " insert into stkpurchaserate (grndate,itemcode,rate,uom) (select getdate(),itemcode,purchaserate,stockuom from inventoryitemmaster where itemcode not in (select itemcode from grn_details where grndate<=@TODAT) and storecode =@storecode)"

        '    'str = str & " UPDATE stkpurchaserate SET OPdate = (select max(grndate) as OPdate from grn_details where grndate<@OPDATE  AND stkpurchaserate.itemcode =grn_details.itemcode  group by itemcode)"
        '    'str = str & " update stkpurchaserate set rate=(select sum(amount+taxamount)/sum(qty) from grn_details b where b.grndate=stkpurchaserate.grndate and b.itemcode=stkpurchaserate.itemcode)"
        '    'str = str & " update stkpurchaserate set oprate = (select (sum(amount+taxamount))/sum(qty) as rate from grn_details b where b.grndate=stkpurchaserate.OPdate and  b.itemcode =stkpurchaserate.itemcode)"

        '    ''  str = str & " --update stkpurchaserate set rate =i.purchaserate from inventoryitemmaster i where i.itemcode = stkpurchaserate.itemcode and stkpurchaserate.itemcode not in (select itemcode from grn_details where grndate<=@TODAT)"
        '    'str = str & " update stkpurchaserate set rate= i.purchaserate, oprate= i.purchaserate from inventoryitemmaster i where  i.itemcode=stkpurchaserate.itemcode and i.itemcode not in (select itemcode from grn_details where grndate<=@TODAT) and storecode =@storecode"
        '    'str = str & " update stkpurchaserate set uom = b.uom from grn_details b where stkpurchaserate.grndate=b.grndate and stkpurchaserate.itemcode=b.itemcode"
        '    'str = str & " update stkpurchaserate set rate = rate * c.convvalue from inventory_transconversion c, inventoryitemmaster i where c.baseuom =i.stockuom and c.transuom =stkpurchaserate.uom and stkpurchaserate.itemcode = i.itemcode"
        '    'str = str & " update stkpurchaserate set oprate= oprate*c.convvalue from inventory_transconversion c,inventoryitemmaster i where c.baseuom = i.stockuom and c.transuom = stkpurchaserate.uom and stkpurchaserate.itemcode = i.itemcode"


        '    'str = str & " update stocksummary set Oprate=isnull(b.oprate,0) from stkpurchaserate b where b.itemcode=stocksummary.itemcode "
        '    ''str = str & " --update stocksummary set Oprate=rate from stkpurchaserate b where b.itemcode=stocksummary.itemcode "
        '    'str = str & " update stocksummary set RCVrate=rate from stkpurchaserate b where b.itemcode=stocksummary.itemcode"
        '    'str = str & " update stocksummary set ISSrate=rate from stkpurchaserate b where b.itemcode=stocksummary.itemcode"
        '    'str = str & " update stocksummary set CLSrate=rate from stkpurchaserate b where b.itemcode=stocksummary.itemcode"

        '    'str = str & " UPDATE STOCKSUMMARY SET Oprate=OPVAL/OPQTY WHERE OPQTY<>0"
        '    'str = str & " UPDATE STOCKSUMMARY SET RCVrate=RCVVAL/RCVQTY  WHERE RCVQTY<>0"
        '    'str = str & " UPDATE STOCKSUMMARY SET ISSrate=ISSVAL/ISSQTY  WHERE ISSQTY<>0"
        '    'str = str & "  UPDATE STOCKSUMMARY SET CLSrate=CLSVAL/CLSQTY  WHERE CLSQTY<>0"

        '    ''str = str & " --UPDATE STOCKSUMMARY SET CLSRATE=CLSRATE*-1 WHERE CLSRATE LIKE '%-%'"

        '    '' str = str & " update stocksummary set pegs=b.pegs  from stocksummary a,inventoryitemmaster b where a.itemcode=b.itemcode and b.storecode='MNS'"
        '    'str = str & " update stocksummary set opqty=0,opval=0 where opqty=0.001"
        '    'str = str & " update stocksummary set clsqty=0,clsval=0 where clsqty=0.001"

        '    'str = str & " update STOCKSUMMARY set Opval=Oprate * Opqty "

        '    'str = str & " update STOCKSUMMARY SET DISPQTY=0 "
        '    'str = str & " UPDATE STOCKSUMMARY SET DISPQTY=CLSQTY-FLOOR(CLSQTY) WHERE FLOOR(CLSQTY)-CLSQTY<0 "
        '    'str = str & " UPDATE STOCKSUMMARY SET DISPQTY=DISPQTY/(SELECT TOP 1 GQTY FROM BOM_DET B WHERE B.GITEMCODE=STOCKSUMMARY.ITEMCODE ) WHERE DISPQTY>0 "
        '    'str = str & " UPDATE STOCKSUMMARY SET DISPQTY=FLOOR(CLSQTY)+(DISPQTY/100) "
        '    'str = str & " UPDATE STOCKSUMMARY SET DISPQTY=ROUND(DISPQTY,2) "
        '    'str = str & " UPDATE STOCKSUMMARY SET DISPQTY=round(DISPQTY,0,1)  WHERE DISPQTY <0 "

        '    'str = str & " UPDATE STOCKSUMMARY SET DISPQTY=CLSQTY  WHERE FLOOR(CLSQTY)-CLSQTY=0"

        '    'str = str & " update STOCKSUMMARY SET OPDISPQTY=0 "
        '    'str = str & " UPDATE STOCKSUMMARY SET OPDISPQTY=OPQTY-FLOOR(OPQTY) WHERE FLOOR(OPQTY)-OPQTY<0 "
        '    'str = str & " UPDATE STOCKSUMMARY SET OPDISPQTY=OPDISPQTY/(SELECT TOP 1 GQTY FROM BOM_DET B WHERE B.GITEMCODE=STOCKSUMMARY.ITEMCODE ) WHERE OPDISPQTY>0 "
        '    'str = str & " UPDATE STOCKSUMMARY SET OPDISPQTY=FLOOR(OPQTY)+(OPDISPQTY/100) "
        '    'str = str & " UPDATE STOCKSUMMARY SET OPDISPQTY=ROUND(OPDISPQTY,2) "
        '    'str = str & " UPDATE STOCKSUMMARY SET OPDISPQTY=OPQTY WHERE FLOOR(OPQTY)-OPQTY=0 "
        '    'str = str & " UPDATE STOCKSUMMARY SET OPDISPQTY=round(OPDISPQTY,0,1)  WHERE OPDISPQTY <0 "

        '    'str = str & " update STOCKSUMMARY SET ISDISPQTY=0 "
        '    'str = str & " UPDATE STOCKSUMMARY SET ISDISPQTY=ISSQTY-FLOOR(ISSQTY) WHERE FLOOR(ISSQTY)-ISSQTY<0 "
        '    'str = str & " UPDATE STOCKSUMMARY SET ISDISPQTY=ISDISPQTY/(SELECT TOP 1 GQTY FROM BOM_DET B WHERE B.GITEMCODE=STOCKSUMMARY.ITEMCODE) WHERE ISDISPQTY>0 "
        '    'str = str & " UPDATE STOCKSUMMARY SET ISDISPQTY=FLOOR(ISSQTY)+(ISDISPQTY/100) "
        '    'str = str & " UPDATE STOCKSUMMARY SET ISDISPQTY=ROUND(ISDISPQTY,2) "
        '    'str = str & " UPDATE STOCKSUMMARY SET ISDISPQTY=ISSQTY WHERE FLOOR(ISSQTY)-ISSQTY=0 "

        '    ''str = str & " --UPDATE STOCKSUMMARY SET DISPQTY = CLSQTY"
        '    ''str = str & " --UPDATE STOCKSUMMARY SET OPDISPQTY = OPQTY"
        '    ''str = str & "--UPDATE STOCKSUMMARY SET ISDISPQTY = ISSQTY"


        '    ''str = str & " --update "
        '    'str = str & " DELETE FROM STOCKSUMMARY WHERE ITEMCODE IN (SELECT ITEMCODE FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=STOCKSUMMARY.ITEMCODE AND ISNULL(B.SELECTOPT,'N')<>'Y')"
        '    'str = str & " print 'tarun'  "


        '    str = " alter PROCEDURE [dbo].[Cp_StockSummary3](@STORECODE As Varchar(20),@FROMDATE AS VARCHAR(11), @TODATE AS VARCHAR(11), @FINYEARSTART AS VARCHAR(11),@TODAT AS VARCHAR(11)) AS "

        '    str = str & " DECLARE @SSQL Varchar(2000),@SQL Varchar(2000),@ITEMCODE Varchar(500),@ITEMNAME Varchar(11) "
        '    str = str & " DECLARE @OPSTOCK NUMERIC(18,3),@ISSQTY NUMERIC(18,3),@ISSVAL NUMERIC(18,2),@OPVALUE NUMERIC(18,2),@RCVQTY NUMERIC(18,3),@RCVVAL NUMERIC(18,2),@STOCKUOM AS VARCHAR(15),@OUTFILE Varchar(10) "
        '    str = str & " declare @pqty numeric(18,6),@ml numeric(18,3),@IQTY numeric(18,3),@PEGS NUMERIC(18,3) "
        '    str = str & "  DECLARE @OPSTK NUMERIC(18,3),@OPVAL NUMERIC(18,2),@SALEUOM VARCHAR(500) "
        '    str = str & "   declare @category varchar(50) "
        '    str = str & "   DECLARE @OPDATE AS VARCHAR(11) "
        '    str = str & "  SET @OPDATE  = convert(varchar(11),@FROMDATE,101) "
        '    str = str & " PRINT @OPDATE "
        '    str = str & " SET @SSQL= 'DELETE FROM STOCKSUMMARY' "
        '    str = str & " EXEC (@SSQL) "
        '    str = str & " SET @SSQL= 'DELETE FROM STKSUMMARY'"
        '    str = str & " EXEC (@SSQL) "
        '    str = str & " EXEC INVENTORYTRANSUPDATE @STORECODE "

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,ITEMNAME,UOM,OPQTY,OPVAL,STORECODE,GROUPCODE,GROUPNAME,SUBGROUPCODE,SUBGROUPNAME)  "
        '    str = str & " SELECT I.ITEMCODE,I.ITEMNAME,I.STOCKUOM,ROUND(ISNULL(I.INVITMTRANSQTY,0),3),ROUND(ISNULL(I.INVITMTRANSVALUE,0),2), I.STORECODE,I.GROUPCODE,I.GROUPNAME,I.SUBGROUPCODE,I.SUBGROUPNAME FROM INVENTORYITEMMASTER AS I  WHERE STORECODE = @STORECODE  "

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,OPQTY,OPVAL,STORECODE)  "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(GRNTRANSQTY,0)),0),ISNULL(SUM(isnull(GRNTRANSVALUE,0)),0)+ISNULL(SUM(isnull(TAXAMOUNT,0)),0)+ISNULL(SUM(isnull(OTHCHARGE,0)),0)-ISNULL(SUM(isnull(DISCOUNT,0)),0),"
        '    str = str & " STORECODE FROM GRN_DETAILS WHERE ISNULL(VOIDITEM,'') <> 'Y'  AND ISNULL(GrnType,'')='GRN' AND cast(convert(varchar(11),GRNDATE,106)as datetime) BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) AND Storecode=@STORECODE GROUP BY Storecode,ITEMCODE "

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,OPQTY,OPVAL,STORECODE)  "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(GRNTRANSQTY,0)),0)*-1,ISNULL(SUM(isnull(GRNTRANSVALUE,0)),0)+ISNULL(SUM(isnull(TAXAMOUNT,0)),0)+ISNULL(SUM(isnull(OTHCHARGE,0)),0)-ISNULL(SUM(isnull(DISCOUNT,0)),0),"
        '    str = str & " STORECODE FROM GRN_DETAILS WHERE ISNULL(VOIDITEM,'') <> 'Y' AND ISNULL(GrnType,'')='PRN'  AND cast(convert(varchar(11),GRNDATE,106)as datetime) BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) AND Storecode=@STORECODE GROUP BY Storecode,ITEMCODE "

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,OPQTY,OPVAL,STORECODE)  "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(ISSTRANSQTY,0)),0)*-1,ISNULL(SUM(isnull(ISSTRANSVALUE,0)),0)*-1,Storelocationcode "
        '    str = str & " FROM STOCKISSUEDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND cast(convert(varchar(11),Docdate,106)as datetime) BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) AND Storelocationcode=@STORECODE GROUP BY ITEMCODE,Storelocationcode "

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,OPQTY,OPVAL,STORECODE)  "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(ISSTRANSQTY,0)),0),ISNULL(SUM(isnull(ISSTRANSVALUE,0)),0),OPStorelocationcode "
        '    str = str & " FROM STOCKISSUEDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND cast(convert(varchar(11),Docdate,106)as datetime) BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) AND OPStorelocationcode=@STORECODE GROUP BY OPStorelocationcode,ITEMCODE "

        '    str = str & " INSERT INTO  STKSUMMARY(ITEMCODE,OPQTY,OPVAL,STORECODE)  "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(TRFTRANSQTY,0)),0),ISNULL(SUM(isnull(TRFTRANSVALUE,0)),0),TOSTORECODE FROM STOCKTRANSFERDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND cast(convert(varchar(11),Docdate,106)as datetime) BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) AND TOSTORECODE=@STORECODE "
        '    str = str & " GROUP BY TOSTORECODE,ITEMCODE "

        '    str = str & " Print() 'venu' "

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,OPQTY,OPVAL,STORECODE) "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(TRFTRANSQTY,0)),0)*-1,ISNULL(SUM(isnull(TRFTRANSVALUE,0)),0)*-1,FROMSTORECODE "
        '    str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND cast(convert(varchar(11),Docdate,106)as datetime) BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) "
        '    str = str & " AND FROMSTORECODE=@STORECODE GROUP BY FROMSTORECODE,ITEMCODE "

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,OPQTY,OPVAL,STORECODE)  "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(ADJTRANSQTY,0)),0),ISNULL(SUM(isnull(ADJTRANSVALUE,0)),0),STORELOCATIONCODE "
        '    str = str & " FROM STOCKADJUSTDETAILS WHERE ISNULL(VOID,'') <> 'Y' AND cast(convert(varchar(11),Docdate,106)as datetime) BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) AND STORELOCATIONCODE=@STORECODE AND ISNULL(ADJUSTEDSTOCK,0)>0 GROUP BY STORELOCATIONCODE,ITEMCODE "

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,OPQTY,OPVAL,STORECODE)  "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(ADJTRANSQTY,0)),0),ISNULL(SUM(isnull(ADJTRANSVALUE,0)),0),STORELOCATIONCODE "
        '    str = str & " FROM STOCKADJUSTDETAILS WHERE ISNULL(VOID,'') <> 'Y' AND cast(convert(varchar(11),Docdate,106)as datetime) BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) "
        '    str = str & " AND STORELOCATIONCODE=@STORECODE AND ISNULL(ADJUSTEDSTOCK,0)<=0 GROUP BY STORELOCATIONCODE,ITEMCODE "

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,OPQTY,OPVAL,STORECODE)  "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(SSCTRANSQTY,0)),0)*-1,ISNULL(SUM(isnull(SSCTRANSVALUE,0)),0)*-1,STORELOCATIONCODE "
        '    str = str & " FROM SUBSTORECONSUMPTIONDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND cast(convert(varchar(11),Docdate,106)as datetime) BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) "
        '    str = str & " AND STORELOCATIONCODE=@STORECODE GROUP BY STORELOCATIONCODE,ITEMCODE "

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,RCVQTY,RCVVAL,STORECODE)  "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(GRNTRANSQTY,0)),0),ISNULL(SUM(isnull(GRNTRANSVALUE,0)),0)+ISNULL(SUM(isnull(TAXAMOUNT,0)),0)+ISNULL(SUM(isnull(OTHCHARGE,0)),0)-ISNULL(SUM(isnull(DISCOUNT,0)),0),STORECODE "
        '    str = str & " FROM GRN_DETAILS WHERE ISNULL(VOIDITEM,'') <> 'Y'  and Isnull(GrnType,'')='GRN' AND cast(convert(varchar(11),Grndate,106)as datetime) BETWEEN @FROMDATE AND @TODATE AND Storecode=@STORECODE GROUP BY Storecode,ITEMCODE "

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,RCVQTY,RCVVAL,STORECODE)  "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(ISSTRANSQTY,0)),0),ISNULL(SUM(isnull(ISSTRANSVALUE,0)),0),OPStorelocationcode  FROM"
        '    str = str & " STOCKISSUEDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND cast(convert(varchar(11),Docdate,106)as datetime) BETWEEN @FROMDATE AND @TODATE AND OPStorelocationcode=@STORECODE GROUP BY OPStorelocationcode,ITEMCODE "

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,RCVQTY,RCVVAL,STORECODE)  "
        '    str = str & "  SELECT ITEMCODE,ISNULL(SUM(ISNULL(TRFTRANSQTY,0)),0),ISNULL(SUM(isnull(TRFTRANSVALUE,0)),0),TOSTORECODE FROM STOCKTRANSFERDETAIL "
        '    str = str & " WHERE ISNULL(VOID,'') <> 'Y' AND cast(convert(varchar(11),Docdate,106)as datetime) BETWEEN @FROMDATE AND @TODATE AND TOSTORECODE=@STORECODE "
        '    str = str & " GROUP BY TOSTORECODE,ITEMCODE "
        '    str = str & "           Print() 'venu1' "

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,RCVQTY,RCVVAL,STORECODE)  "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(ADJTRANSQTY,0)),0),ISNULL(SUM(isnull(ADJTRANSVALUE,0)),0),STORELOCATIONCODE FROM "
        '    str = str & "  STOCKADJUSTDETAILS WHERE ISNULL(VOID,'') <> 'Y' AND cast(convert(varchar(11),Docdate,106)as datetime) BETWEEN @FROMDATE AND @TODATE AND STORELOCATIONCODE=@STORECODE AND ISNULL(ADJUSTEDSTOCK,0)>0 GROUP BY STORELOCATIONCODE,ITEMCODE "

        '    str = str & "  INSERT INTO STKSUMMARY(ITEMCODE,ISSQTY,ISSVAL,STORECODE)   "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(GRNTRANSQTY,0)),0),ISNULL(SUM(isnull(GRNTRANSVALUE,0)),0)+ISNULL(SUM(isnull(TAXAMOUNT,0)),0)+ISNULL(SUM(isnull(OTHCHARGE,0)),0)-ISNULL(SUM(isnull(DISCOUNT,0)),0),STORECODE "
        '    str = str & "  FROM GRN_DETAILS WHERE ISNULL(VOIDITEM,'') <> 'Y' AND ISNULL(GrnType,'')='PRN'  AND cast(convert(varchar(11),Grndate,106)as datetime) BETWEEN @FROMDATE AND @TODATE  "
        '    str = str & "  AND Storecode=@STORECODE GROUP BY Storecode,ITEMCODE "

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,ISSQTY,ISSVAL,STORECODE)  "
        '    str = str & "  SELECT ITEMCODE,ISNULL(SUM(ISNULL(ISSTRANSQTY,0)),0),ISNULL(SUM(isnull(ISSTRANSVALUE,0)),0),Storelocationcode "
        '    str = str & " FROM STOCKISSUEDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND cast(convert(varchar(11),Docdate,106)as datetime) BETWEEN @FROMDATE AND @TODATE AND Storelocationcode=@STORECODE "
        '    str = str & "  GROUP BY Storelocationcode,ITEMCODE "

        '    str = str & "  INSERT INTO STKSUMMARY(ITEMCODE,ISSQTY,ISSVAL,STORECODE)  "
        '    str = str & "  SELECT ITEMCODE,ISNULL(SUM(ISNULL(TRFTRANSQTY,0)),0),ISNULL(SUM(isnull(TRFTRANSVALUE,0)),0),FROMSTORECODE FROM STOCKTRANSFERDETAIL "
        '    str = str & "  WHERE ISNULL(VOID,'') <> 'Y' AND cast(convert(varchar(11),Docdate,106)as datetime) BETWEEN @FROMDATE AND @TODATE AND FROMSTORECODE=@STORECODE "
        '    str = str & "  GROUP BY FROMSTORECODE,ITEMCODE "

        '    str = str & "  INSERT INTO STKSUMMARY(ITEMCODE,ISSQTY,ISSVAL,STORECODE)  "
        '    str = str & "  SELECT ITEMCODE,ISNULL(SUM(ISNULL(ADJTRANSQTY,0)),0)*-1,ISNULL(SUM(isnull(ADJTRANSVALUE,0)),0)*-1,STORELOCATIONCODE FROM "
        '    str = str & "  STOCKADJUSTDETAILS WHERE ISNULL(VOID,'') <> 'Y' AND cast(convert(varchar(11),Docdate,106)as datetime) BETWEEN @FROMDATE AND @TODATE AND STORELOCATIONCODE=@STORECODE  "
        '    str = str & "  AND ISNULL(ADJUSTEDSTOCK,0)<=0 GROUP BY STORELOCATIONCODE,ITEMCODE "

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,ISSQTY,ISSVAL,STORECODE)  "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(SSCTRANSQTY,0)),0),ISNULL(SUM(isnull(SSCTRANSVALUE,0)),0),STORELOCATIONCODE FROM "
        '    str = str & " SUBSTORECONSUMPTIONDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND cast(convert(varchar(11),Docdate,106)as datetime) BETWEEN @FROMDATE AND @TODATE AND STORELOCATIONCODE=@STORECODE "
        '    str = str & " GROUP BY STORELOCATIONCODE,ITEMCODE "

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,ADJQTY,ADJVAL,STORECODE)  "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(ADJTRANSQTY,0)),0),ISNULL(SUM(isnull(ADJTRANSVALUE,0)),0),STORELOCATIONCODE FROM "
        '    str = str & " STOCKADJUSTDETAILS WHERE ISNULL(VOID,'') <> 'Y' AND cast(convert(varchar(11),Docdate,106)as datetime) BETWEEN @FROMDATE AND @TODATE AND STORELOCATIONCODE=@STORECODE  "
        '    str = str & " GROUP BY STORELOCATIONCODE,ITEMCODE "

        '    str = str & " INSERT INTO STOCKSUMMARY (STORECODE,Itemcode,Opqty,Opval,Rcvqty,Rcvval,Issqty,Issval,adjqty,adjval)  "
        '    str = str & " (SELECT STORECODE,Itemcode,SUM(Opqty),SUM(Opval),SUM(Rcvqty),SUM(Rcvval),SUM(Issqty),SUM(Issval),SUM(Adjqty),SUM(Adjval) "
        '    str = str & " FROM STKSUMMARY  GROUP BY STORECODE,Itemcode) "

        '    str = str & " UPDATE STOCKSUMMARY SET Itemname=B.itemNAME FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=STOCKSUMMARY.ITEMCODE AND "
        '    str = str & " STOCKSUMMARY.STORECODE = B.STORECODE"

        '    str = str & " UPDATE STOCKSUMMARY SET UOM=STOCKUOM FROM INVENTORYITEMMASTER B WHERE "
        '    str = str & " B.ITEMCODE = STOCKSUMMARY.ITEMCODE And STOCKSUMMARY.STORECODE = B.STORECODE"

        '    str = str & " UPDATE STOCKSUMMARY SET "
        '    str = str & " GROUPCODE=B.GROUPCODE FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=STOCKSUMMARY.ITEMCODE AND STOCKSUMMARY.STORECODE=B.STORECODE "

        '    str = str & " UPDATE STOCKSUMMARY SET GROUPNAME=B.GROUPNAME FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=STOCKSUMMARY.ITEMCODE AND "
        '    str = str & "  STOCKSUMMARY.STORECODE = B.STORECODE"

        '    str = str & " UPDATE STOCKSUMMARY SET SUBGROUPCODE=B.SUBGROUPCODE FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=STOCKSUMMARY.ITEMCODE AND STOCKSUMMARY.STORECODE=B.STORECODE "
        '    str = str & " UPDATE STOCKSUMMARY SET SUBGROUPNAME=B.SUBGROUPNAME FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=STOCKSUMMARY.ITEMCODE AND STOCKSUMMARY.STORECODE=B.STORECODE "

        '    str = str & " UPDATE STOCKSUMMARY SET CATEGORY =B.CATEGORY FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=STOCKSUMMARY.ITEMCODE AND STOCKSUMMARY.STORECODE=B.STORECODE "
        '    str = str & " UPDATE STOCKSUMMARY SET Opqty=ISNULL(Opqty,0) "
        '    str = str & " UPDATE STOCKSUMMARY SET Oprate=ISNULL(Oprate,0) "
        '    str = str & " UPDATE STOCKSUMMARY SET Opval=ISNULL(Opval,0) "
        '    str = str & " UPDATE STOCKSUMMARY SET Rcvqty=ISNULL(Rcvqty,0) "
        '    str = str & " UPDATE STOCKSUMMARY SET Rcvrate=ISNULL(Rcvrate,0) "
        '    str = str & " UPDATE STOCKSUMMARY SET Rcvval=ISNULL(Rcvval,0) "
        '    str = str & " UPDATE STOCKSUMMARY SET Issqty=ISNULL(Issqty,0) "
        '    str = str & " UPDATE STOCKSUMMARY SET Issrate=ISNULL(Issrate,0) "
        '    str = str & " UPDATE STOCKSUMMARY SET Issval=ISNULL(Issval,0) "
        '    str = str & " UPDATE STOCKSUMMARY SET Clsqty=ISNULL(Clsqty,0) "
        '    str = str & " UPDATE STOCKSUMMARY SET Clsrate=ISNULL(Clsrate,0) "
        '    str = str & " UPDATE STOCKSUMMARY SET Clsval=ISNULL(Clsval,0) "
        '    str = str & " UPDATE STOCKSUMMARY SET Clsqty=OPQTY+RCVQTY-ISSQTY "
        '    str = str & " UPDATE STOCKSUMMARY SET ClsVAL=OPVAL+RCVVAL-ISSVAL "
        '    str = str & " update inventoryitemmaster set closingqty = Clsqty, closingval = clsval from STOCKSUMMARY s where s.itemcode = inventoryitemmaster.itemcode and inventoryitemmaster.STORECODE = s.STORECODE  and inventoryitemmaster.STORECODE = @STORECODE  "
        '    str = str & " drop table stkpurchaserate "
        '    str = str & " create table stkpurchaserate (grndate datetime,OPdate datetime,itemcode varchar(50),rate numeric(18,2),uom varchar(50),oprate numeric(18,2)) "
        '    str = str & " insert into stkpurchaserate (grndate,itemcode,rate) (select max(grndate) as grndate,itemcode,(sum(amount+taxamount))/sum(qty) as rate from grn_details where grndate<=@TODAT group by itemcode) "
        '    str = str & " insert into stkpurchaserate (grndate,itemcode,rate,uom) (select getdate(),itemcode,purchaserate,stockuom from inventoryitemmaster where itemcode not in (select itemcode from grn_details where grndate<=@TODAT) and storecode =@storecode) "
        '    str = str & " UPDATE stkpurchaserate SET OPdate = (select max(grndate) as OPdate from grn_details where grndate<@OPDATE  AND stkpurchaserate.itemcode =grn_details.itemcode  group by itemcode) "
        '    str = str & " update stkpurchaserate set rate=(select sum(amount+taxamount)/sum(qty) from grn_details b where b.grndate=stkpurchaserate.grndate and b.itemcode=stkpurchaserate.itemcode) "
        '    str = str & " update stkpurchaserate set oprate = (select (sum(amount+taxamount))/sum(qty) as rate from grn_details b where b.grndate=stkpurchaserate.OPdate and  b.itemcode =stkpurchaserate.itemcode) "
        '    str = str & " update stkpurchaserate set rate= i.purchaserate, oprate= i.purchaserate from inventoryitemmaster i where  i.itemcode=stkpurchaserate.itemcode and i.itemcode not in (select itemcode from grn_details where grndate<=@TODAT) and storecode =@storecode "
        '    str = str & " update stkpurchaserate set uom = b.uom from grn_details b where stkpurchaserate.grndate=b.grndate and stkpurchaserate.itemcode=b.itemcode "
        '    str = str & " update stkpurchaserate set rate = rate * c.convvalue from inventory_transconversion c, inventoryitemmaster i where c.baseuom =i.stockuom and c.transuom =stkpurchaserate.uom and stkpurchaserate.itemcode = i.itemcode "
        '    str = str & " update stkpurchaserate set oprate= oprate*c.convvalue from inventory_transconversion c,inventoryitemmaster i where c.baseuom = i.stockuom and c.transuom = stkpurchaserate.uom and stkpurchaserate.itemcode = i.itemcode "
        '    str = str & " update stocksummary set Oprate=isnull(b.oprate,0) from stkpurchaserate b where b.itemcode=stocksummary.itemcode  "
        '    str = str & " update stocksummary set RCVrate=rate from stkpurchaserate b where b.itemcode=stocksummary.itemcode "
        '    str = str & " update stocksummary set ISSrate=rate from stkpurchaserate b where b.itemcode=stocksummary.itemcode "
        '    str = str & " update stocksummary set CLSrate=rate from stkpurchaserate b where b.itemcode=stocksummary.itemcode "
        '    str = str & " UPDATE STOCKSUMMARY SET Oprate=OPVAL/OPQTY WHERE OPQTY<>0 "
        '    str = str & " UPDATE STOCKSUMMARY SET RCVrate=RCVVAL/RCVQTY  WHERE RCVQTY<>0 "
        '    str = str & " UPDATE STOCKSUMMARY SET ISSrate=ISSVAL/ISSQTY  WHERE ISSQTY<>0  "
        '    str = str & " UPDATE STOCKSUMMARY SET CLSrate=CLSVAL/CLSQTY  WHERE CLSQTY<>0 "
        '    str = str & " update stocksummary set opqty=0,opval=0 where opqty=0.001 "
        '    str = str & " update stocksummary set clsqty=0,clsval=0 where clsqty=0.001 "
        '    str = str & " update STOCKSUMMARY set Opval=Oprate * Opqty  update STOCKSUMMARY SET DISPQTY=0   "
        '    str = str & " UPDATE STOCKSUMMARY SET DISPQTY=CLSQTY-FLOOR(CLSQTY) WHERE FLOOR(CLSQTY)-CLSQTY<0  "
        '    str = str & " UPDATE STOCKSUMMARY SET DISPQTY=DISPQTY/("
        '    str = str & " SELECT TOP 1 GQTY FROM BOM_DET B WHERE B.GITEMCODE=STOCKSUMMARY.ITEMCODE  and b.itemuom='sml') WHERE DISPQTY>0  "
        '    str = str & " UPDATE STOCKSUMMARY SET DISPQTY=FLOOR(CLSQTY)+(DISPQTY/100)  "
        '    str = str & " UPDATE STOCKSUMMARY SET DISPQTY=ROUND(DISPQTY,2)  "
        '    str = str & " UPDATE STOCKSUMMARY SET DISPQTY=round(DISPQTY,0,1)  WHERE DISPQTY <0  "
        '    str = str & " UPDATE STOCKSUMMARY SET DISPQTY=CLSQTY  WHERE FLOOR(CLSQTY)-CLSQTY=0 "
        '    str = str & " update STOCKSUMMARY SET OPDISPQTY=0  "
        '    str = str & " UPDATE STOCKSUMMARY SET OPDISPQTY=OPQTY-FLOOR(OPQTY) WHERE FLOOR(OPQTY)-OPQTY<0  "
        '    str = str & " UPDATE STOCKSUMMARY SET OPDISPQTY=OPDISPQTY/(SELECT TOP 1 GQTY FROM BOM_DET B WHERE B.GITEMCODE=STOCKSUMMARY.ITEMCODE  and b.itemuom='sml') WHERE OPDISPQTY>0  "
        '    str = str & " UPDATE STOCKSUMMARY SET OPDISPQTY=FLOOR(OPQTY)+(OPDISPQTY/100)  "
        '    str = str & " UPDATE STOCKSUMMARY SET OPDISPQTY=ROUND(OPDISPQTY,2) "
        '    str = str & " UPDATE STOCKSUMMARY SET OPDISPQTY=OPQTY WHERE FLOOR(OPQTY)-OPQTY=0  "
        '    str = str & " UPDATE STOCKSUMMARY SET OPDISPQTY=round(OPDISPQTY,0,1)  WHERE OPDISPQTY <0  "
        '    str = str & " update STOCKSUMMARY SET ISDISPQTY=0  UPDATE STOCKSUMMARY SET ISDISPQTY=ISSQTY-FLOOR(ISSQTY) WHERE FLOOR(ISSQTY)-ISSQTY<0  "
        '    str = str & " UPDATE STOCKSUMMARY SET ISDISPQTY=ISDISPQTY/(SELECT TOP 1 GQTY FROM BOM_DET B WHERE B.GITEMCODE=STOCKSUMMARY.ITEMCODE  and b.itemuom='sml') WHERE ISDISPQTY>0  "
        '    str = str & " UPDATE STOCKSUMMARY SET ISDISPQTY=FLOOR(ISSQTY)+(ISDISPQTY/100)  "
        '    str = str & " UPDATE STOCKSUMMARY SET ISDISPQTY=ROUND(ISDISPQTY,2)  "
        '    str = str & " UPDATE STOCKSUMMARY SET ISDISPQTY=ISSQTY WHERE FLOOR(ISSQTY)-ISSQTY=0  "
        '    str = str & " DELETE FROM STOCKSUMMARY WHERE ITEMCODE IN (SELECT ITEMCODE FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=STOCKSUMMARY.ITEMCODE AND ISNULL(B.SELECTOPT,'N')<>'Y') print 'tarun' "
        '    gconnection.dataOperation1(6, str, "item")

        'Else
        '    str = "    create                                        PROCEDURE [dbo].[Cp_StockSummary3](@STORECODE As Varchar(20),@FROMDATE AS VARCHAR(11), @TODATE AS VARCHAR(11), @FINYEARSTART AS VARCHAR(11),@TODAT AS VARCHAR(11))"
        '    str = str & " AS"
        '    str = str & " DECLARE @SSQL Varchar(2000),@SQL Varchar(2000),@ITEMCODE Varchar(500),@ITEMNAME Varchar(11)"
        '    str = str & " DECLARE @OPSTOCK NUMERIC(18,3),@ISSQTY NUMERIC(18,3),@ISSVAL NUMERIC(18,2),@OPVALUE NUMERIC(18,2),@RCVQTY NUMERIC(18,3),@RCVVAL NUMERIC(18,2),@STOCKUOM AS VARCHAR(15),@OUTFILE Varchar(10)"
        '    str = str & " declare @pqty numeric(18,6),@ml numeric(18,3),@IQTY numeric(18,3),@PEGS NUMERIC(18,3)"
        '    str = str & " DECLARE @OPSTK NUMERIC(18,3),@OPVAL NUMERIC(18,2),@SALEUOM VARCHAR(500)"
        '    str = str & " declare @category varchar(50)"
        '    str = str & " DECLARE @OPDATE AS VARCHAR(11)"

        '    str = str & " SET @OPDATE  = convert(varchar(11),@FROMDATE,101)"
        '    str = str & " PRINT @OPDATE"

        '    str = str & " SET @SSQL= 'DELETE FROM STOCKSUMMARY'"
        '    str = str & " EXEC (@SSQL)"

        '    str = str & " SET @SSQL= 'DELETE FROM STKSUMMARY'"
        '    str = str & " EXEC (@SSQL)"

        '    '  str = str & " --SET @SALEUOM ='SELECT SALEUOM FROM INVENTORYITEMMASTER WHERE STORECODE = @STORECODE'"

        '    str = str & " EXEC INVENTORYTRANSUPDATE @STORECODE"


        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,ITEMNAME,UOM,OPQTY,OPVAL,STORECODE,GROUPCODE,GROUPNAME,SUBGROUPCODE,SUBGROUPNAME) "
        '    str = str & " SELECT I.ITEMCODE,I.ITEMNAME,I.STOCKUOM,ROUND(ISNULL(I.INVITMTRANSQTY,0),3),ROUND(ISNULL(I.INVITMTRANSVALUE,0),2),"
        '    str = str & " I.STORECODE,I.GROUPCODE,I.GROUPNAME,I.SUBGROUPCODE,I.SUBGROUPNAME FROM INVENTORYITEMMASTER AS I "
        '    str = str & " WHERE STORECODE = @STORECODE "

        '    'str = str & " ---GRN"
        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,OPQTY,OPVAL,STORECODE) "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(GRNTRANSQTY,0)),0),ISNULL(SUM(isnull(GRNTRANSVALUE,0)),0)+ISNULL(SUM(isnull(TAXAMOUNT,0)),0)+ISNULL(SUM(isnull(OTHCHARGE,0)),0)-ISNULL(SUM(isnull(DISCOUNT,0)),0),STORECODE FROM GRN_DETAILS WHERE ISNULL(VOIDITEM,'') <> 'Y'  AND ISNULL(GrnType,'')='GRN' AND GRNDATE BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) AND Storecode=@STORECODE GROUP BY Storecode,ITEMCODE"

        '    'str = str & " ---PRN"
        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,OPQTY,OPVAL,STORECODE) "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(GRNTRANSQTY,0)),0)*-1,ISNULL(SUM(isnull(GRNTRANSVALUE,0)),0)+ISNULL(SUM(isnull(TAXAMOUNT,0)),0)+ISNULL(SUM(isnull(OTHCHARGE,0)),0)-ISNULL(SUM(isnull(DISCOUNT,0)),0),STORECODE FROM GRN_DETAILS WHERE ISNULL(VOIDITEM,'') <> 'Y' AND ISNULL(GrnType,'')='PRN'  AND GRNDATE BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) AND Storecode=@STORECODE GROUP BY Storecode,ITEMCODE"

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,OPQTY,OPVAL,STORECODE) "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(ISSTRANSQTY,0)),0)*-1,ISNULL(SUM(isnull(ISSTRANSVALUE,0)),0)*-1,Storelocationcode FROM STOCKISSUEDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) AND Storelocationcode=@STORECODE GROUP BY ITEMCODE,Storelocationcode"

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,OPQTY,OPVAL,STORECODE) "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(ISSTRANSQTY,0)),0),ISNULL(SUM(isnull(ISSTRANSVALUE,0)),0),OPStorelocationcode"
        '    str = str & " FROM STOCKISSUEDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) AND OPStorelocationcode=@STORECODE GROUP BY OPStorelocationcode,ITEMCODE"

        '    str = str & " INSERT INTO  STKSUMMARY(ITEMCODE,OPQTY,OPVAL,STORECODE) "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(TRFTRANSQTY,0)),0),ISNULL(SUM(isnull(TRFTRANSVALUE,0)),0),TOSTORECODE"
        '    str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) AND TOSTORECODE=@STORECODE GROUP BY TOSTORECODE,ITEMCODE"
        '    str = str & " Print 'venu'"

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,OPQTY,OPVAL,STORECODE) "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(TRFTRANSQTY,0)),0)*-1,ISNULL(SUM(isnull(TRFTRANSVALUE,0)),0)*-1,FROMSTORECODE"
        '    str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) AND FROMSTORECODE=@STORECODE GROUP BY FROMSTORECODE,ITEMCODE"

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,OPQTY,OPVAL,STORECODE) "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(ADJTRANSQTY,0)),0),ISNULL(SUM(isnull(ADJTRANSVALUE,0)),0),STORELOCATIONCODE"
        '    str = str & " FROM STOCKADJUSTDETAILS WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) AND STORELOCATIONCODE=@STORECODE AND ISNULL(ADJUSTEDSTOCK,0)>0 GROUP BY STORELOCATIONCODE,ITEMCODE"

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,OPQTY,OPVAL,STORECODE) "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(ADJTRANSQTY,0)),0),ISNULL(SUM(isnull(ADJTRANSVALUE,0)),0),STORELOCATIONCODE"
        '    str = str & " FROM STOCKADJUSTDETAILS WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) AND STORELOCATIONCODE=@STORECODE AND ISNULL(ADJUSTEDSTOCK,0)<=0 GROUP BY STORELOCATIONCODE,ITEMCODE"


        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,OPQTY,OPVAL,STORECODE) "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(SSCTRANSQTY,0)),0)*-1,ISNULL(SUM(isnull(SSCTRANSVALUE,0)),0)*-1,STORELOCATIONCODE"
        '    str = str & " FROM SUBSTORECONSUMPTIONDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FINYEARSTART AND DateAdd(Day, -1,@FROMDATE) AND STORELOCATIONCODE=@STORECODE GROUP BY STORELOCATIONCODE,ITEMCODE"


        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,RCVQTY,RCVVAL,STORECODE) "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(GRNTRANSQTY,0)),0),ISNULL(SUM(isnull(GRNTRANSVALUE,0)),0)+ISNULL(SUM(isnull(TAXAMOUNT,0)),0)+ISNULL(SUM(isnull(OTHCHARGE,0)),0)-ISNULL(SUM(isnull(DISCOUNT,0)),0),STORECODE FROM GRN_DETAILS WHERE ISNULL(VOIDITEM,'') <> 'Y'  and Isnull(GrnType,'')='GRN' AND GRNDATE BETWEEN @FROMDATE AND @TODATE AND Storecode=@STORECODE GROUP BY Storecode,ITEMCODE"

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,RCVQTY,RCVVAL,STORECODE) "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(ISSTRANSQTY,0)),0),ISNULL(SUM(isnull(ISSTRANSVALUE,0)),0),OPStorelocationcode "
        '    str = str & " FROM STOCKISSUEDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FROMDATE AND @TODATE AND OPStorelocationcode=@STORECODE GROUP BY OPStorelocationcode,ITEMCODE"

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,RCVQTY,RCVVAL,STORECODE) "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(TRFTRANSQTY,0)),0),ISNULL(SUM(isnull(TRFTRANSVALUE,0)),0),TOSTORECODE"
        '    str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FROMDATE AND @TODATE AND TOSTORECODE=@STORECODE GROUP BY TOSTORECODE,ITEMCODE"
        '    str = str & " Print 'venu1'"

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,RCVQTY,RCVVAL,STORECODE) "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(ADJTRANSQTY,0)),0),ISNULL(SUM(isnull(ADJTRANSVALUE,0)),0),STORELOCATIONCODE"
        '    str = str & " FROM STOCKADJUSTDETAILS WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FROMDATE AND @TODATE AND STORELOCATIONCODE=@STORECODE AND ISNULL(ADJUSTEDSTOCK,0)>0 GROUP BY STORELOCATIONCODE,ITEMCODE"


        '    'str = str & " ---PRN"
        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,ISSQTY,ISSVAL,STORECODE)  "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(GRNTRANSQTY,0)),0),ISNULL(SUM(isnull(GRNTRANSVALUE,0)),0)+ISNULL(SUM(isnull(TAXAMOUNT,0)),0)+ISNULL(SUM(isnull(OTHCHARGE,0)),0)-ISNULL(SUM(isnull(DISCOUNT,0)),0),STORECODE FROM GRN_DETAILS WHERE ISNULL(VOIDITEM,'') <> 'Y' AND ISNULL(GrnType,'')='PRN'  AND GRNDATE BETWEEN @FROMDATE AND @TODATE  AND Storecode=@STORECODE GROUP BY Storecode,ITEMCODE"

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,ISSQTY,ISSVAL,STORECODE) "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(ISSTRANSQTY,0)),0),ISNULL(SUM(isnull(ISSTRANSVALUE,0)),0),Storelocationcode"
        '    str = str & " FROM STOCKISSUEDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FROMDATE AND @TODATE AND Storelocationcode=@STORECODE GROUP BY Storelocationcode,ITEMCODE"

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,ISSQTY,ISSVAL,STORECODE) "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(TRFTRANSQTY,0)),0),ISNULL(SUM(isnull(TRFTRANSVALUE,0)),0),FROMSTORECODE"
        '    str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FROMDATE AND @TODATE AND FROMSTORECODE=@STORECODE GROUP BY FROMSTORECODE,ITEMCODE"

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,ISSQTY,ISSVAL,STORECODE) "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(ADJTRANSQTY,0)),0)*-1,ISNULL(SUM(isnull(ADJTRANSVALUE,0)),0)*-1,STORELOCATIONCODE"
        '    str = str & " FROM STOCKADJUSTDETAILS WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FROMDATE AND @TODATE AND STORELOCATIONCODE=@STORECODE "
        '    str = str & " AND ISNULL(ADJUSTEDSTOCK,0)<=0 GROUP BY STORELOCATIONCODE,ITEMCODE"

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,ISSQTY,ISSVAL,STORECODE) "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(SSCTRANSQTY,0)),0),ISNULL(SUM(isnull(SSCTRANSVALUE,0)),0),STORELOCATIONCODE"
        '    str = str & " FROM SUBSTORECONSUMPTIONDETAIL WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FROMDATE AND @TODATE AND STORELOCATIONCODE=@STORECODE GROUP BY STORELOCATIONCODE,ITEMCODE"

        '    'str = str & " --Adjustment"
        '    'str = str & " --ALTER TABLE STOCKSUMMARY DROP COLUMN ADLQTY NUMERIC(18,3)"

        '    str = str & " INSERT INTO STKSUMMARY(ITEMCODE,ADJQTY,ADJVAL,STORECODE) "
        '    str = str & " SELECT ITEMCODE,ISNULL(SUM(ISNULL(ADJTRANSQTY,0)),0),ISNULL(SUM(isnull(ADJTRANSVALUE,0)),0),STORELOCATIONCODE"
        '    str = str & " FROM STOCKADJUSTDETAILS WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN @FROMDATE AND @TODATE AND STORELOCATIONCODE=@STORECODE "
        '    str = str & " GROUP BY STORELOCATIONCODE,ITEMCODE"

        '    str = str & " INSERT INTO STOCKSUMMARY (STORECODE,Itemcode,Opqty,Opval,Rcvqty,Rcvval,Issqty,Issval,adjqty,adjval) "
        '    str = str & " (SELECT STORECODE,Itemcode,SUM(Opqty),SUM(Opval),SUM(Rcvqty),SUM(Rcvval),SUM(Issqty),SUM(Issval),SUM(Adjqty),SUM(Adjval) FROM STKSUMMARY "
        '    str = str & " GROUP BY STORECODE,Itemcode)"


        '    str = str & " UPDATE STOCKSUMMARY SET Itemname=B.itemNAME FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=STOCKSUMMARY.ITEMCODE AND STOCKSUMMARY.STORECODE=B.STORECODE"
        '    str = str & " UPDATE STOCKSUMMARY SET UOM=STOCKUOM FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=STOCKSUMMARY.ITEMCODE AND STOCKSUMMARY.STORECODE=B.STORECODE"
        '    str = str & " UPDATE STOCKSUMMARY SET GROUPCODE=B.GROUPCODE FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=STOCKSUMMARY.ITEMCODE AND STOCKSUMMARY.STORECODE=B.STORECODE"
        '    str = str & " UPDATE STOCKSUMMARY SET GROUPNAME=B.GROUPNAME FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=STOCKSUMMARY.ITEMCODE AND STOCKSUMMARY.STORECODE=B.STORECODE"
        '    str = str & " UPDATE STOCKSUMMARY SET SUBGROUPCODE=B.SUBGROUPCODE FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=STOCKSUMMARY.ITEMCODE AND STOCKSUMMARY.STORECODE=B.STORECODE"
        '    str = str & " UPDATE STOCKSUMMARY SET SUBGROUPNAME=B.SUBGROUPNAME FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=STOCKSUMMARY.ITEMCODE AND STOCKSUMMARY.STORECODE=B.STORECODE"
        '    str = str & " UPDATE STOCKSUMMARY SET CATEGORY =B.CATEGORY FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=STOCKSUMMARY.ITEMCODE AND STOCKSUMMARY.STORECODE=B.STORECODE"

        '    'str = str & " --alter table stksummary add CATEGORY varchar(50)"
        '    'str = str & " --alter table stocksummary add CATEGORY varchar(50)"

        '    str = str & " UPDATE STOCKSUMMARY SET Opqty=ISNULL(Opqty,0)"
        '    str = str & " UPDATE STOCKSUMMARY SET Oprate=ISNULL(Oprate,0)"
        '    str = str & " UPDATE STOCKSUMMARY SET Opval=ISNULL(Opval,0)"
        '    str = str & " UPDATE STOCKSUMMARY SET Rcvqty=ISNULL(Rcvqty,0)"
        '    str = str & " UPDATE STOCKSUMMARY SET Rcvrate=ISNULL(Rcvrate,0)"
        '    str = str & " UPDATE STOCKSUMMARY SET Rcvval=ISNULL(Rcvval,0)"
        '    str = str & " UPDATE STOCKSUMMARY SET Issqty=ISNULL(Issqty,0)"
        '    str = str & " UPDATE STOCKSUMMARY SET Issrate=ISNULL(Issrate,0)"
        '    str = str & " UPDATE STOCKSUMMARY SET Issval=ISNULL(Issval,0)"
        '    str = str & " UPDATE STOCKSUMMARY SET Clsqty=ISNULL(Clsqty,0)"
        '    str = str & " UPDATE STOCKSUMMARY SET Clsrate=ISNULL(Clsrate,0)"
        '    str = str & " UPDATE STOCKSUMMARY SET Clsval=ISNULL(Clsval,0)"

        '    str = str & " UPDATE STOCKSUMMARY SET Clsqty=OPQTY+RCVQTY-ISSQTY"
        '    str = str & " UPDATE STOCKSUMMARY SET ClsVAL=OPVAL+RCVVAL-ISSVAL"

        '    str = str & " update inventoryitemmaster set closingqty = Clsqty, closingval = clsval from STOCKSUMMARY s where s.itemcode = inventoryitemmaster.itemcode and inventoryitemmaster.STORECODE = s.STORECODE  and inventoryitemmaster.STORECODE = @STORECODE "

        '    str = str & " drop table stkpurchaserate"


        '    'str = str & " --create table stkpurchaserate (grndate datetime,itemcode varchar(50),rate numeric(18,2))"
        '    'str = str & " --insert into stkpurchaserate (grndate,itemcode,rate) (select max(grndate) as grndate,itemcode,(sum(amount+taxamount))/sum(qty) as rate from grn_details where grndate<=@TODAT group by itemcode)"
        '    'str = str & " --insert into stkpurchaserate (grndate,itemcode,rate) (select getdate(),itemcode,purchaserate from inventoryitemmaster where itemcode not in (select itemcode from grn_details where grndate<=@TODAT))"
        '    'str = str & " --update stkpurchaserate set rate=(select sum(amount+taxamount)/sum(qty) from grn_details b where b.grndate=stkpurchaserate.grndate and b.itemcode=stkpurchaserate.itemcode)"

        '    'str = str & " --create table stkpurchaserate (grndate datetime,itemcode varchar(50),rate numeric(18,2),uom varchar(50))"
        '    str = str & " create table stkpurchaserate (grndate datetime,OPdate datetime,itemcode varchar(50),rate numeric(18,2),uom varchar(50),oprate numeric(18,2))"

        '    str = str & " insert into stkpurchaserate (grndate,itemcode,rate) (select max(grndate) as grndate,itemcode,(sum(amount+taxamount))/sum(qty) as rate from grn_details where grndate<=@TODAT group by itemcode)"
        '    str = str & " insert into stkpurchaserate (grndate,itemcode,rate,uom) (select getdate(),itemcode,purchaserate,stockuom from inventoryitemmaster where itemcode not in (select itemcode from grn_details where grndate<=@TODAT) and storecode =@storecode)"

        '    str = str & " UPDATE stkpurchaserate SET OPdate = (select max(grndate) as OPdate from grn_details where grndate<@OPDATE  AND stkpurchaserate.itemcode =grn_details.itemcode  group by itemcode)"
        '    str = str & " update stkpurchaserate set rate=(select sum(amount+taxamount)/sum(qty) from grn_details b where b.grndate=stkpurchaserate.grndate and b.itemcode=stkpurchaserate.itemcode)"
        '    str = str & " update stkpurchaserate set oprate = (select (sum(amount+taxamount))/sum(qty) as rate from grn_details b where b.grndate=stkpurchaserate.OPdate and  b.itemcode =stkpurchaserate.itemcode)"

        '    ' str = str & " --update stkpurchaserate set rate =i.purchaserate from inventoryitemmaster i where i.itemcode = stkpurchaserate.itemcode and stkpurchaserate.itemcode not in (select itemcode from grn_details where grndate<=@TODAT)"
        '    str = str & " update stkpurchaserate set rate= i.purchaserate, oprate= i.purchaserate from inventoryitemmaster i where  i.itemcode=stkpurchaserate.itemcode and i.itemcode not in (select itemcode from grn_details where grndate<=@TODAT) and storecode =@storecode"
        '    str = str & " update stkpurchaserate set uom = b.uom from grn_details b where stkpurchaserate.grndate=b.grndate and stkpurchaserate.itemcode=b.itemcode"
        '    str = str & " update stkpurchaserate set rate = rate * c.convvalue from inventory_transconversion c, inventoryitemmaster i where c.baseuom =i.stockuom and c.transuom =stkpurchaserate.uom and stkpurchaserate.itemcode = i.itemcode"
        '    str = str & " update stkpurchaserate set oprate= oprate*c.convvalue from inventory_transconversion c,inventoryitemmaster i where c.baseuom = i.stockuom and c.transuom = stkpurchaserate.uom and stkpurchaserate.itemcode = i.itemcode"


        '    str = str & " update stocksummary set Oprate=isnull(b.oprate,0) from stkpurchaserate b where b.itemcode=stocksummary.itemcode "
        '    'str = str & " --update stocksummary set Oprate=rate from stkpurchaserate b where b.itemcode=stocksummary.itemcode "
        '    str = str & " update stocksummary set RCVrate=rate from stkpurchaserate b where b.itemcode=stocksummary.itemcode"
        '    str = str & " update stocksummary set ISSrate=rate from stkpurchaserate b where b.itemcode=stocksummary.itemcode"
        '    str = str & " update stocksummary set CLSrate=rate from stkpurchaserate b where b.itemcode=stocksummary.itemcode"

        '    str = str & " UPDATE STOCKSUMMARY SET Oprate=OPVAL/OPQTY WHERE OPQTY<>0"
        '    str = str & " UPDATE STOCKSUMMARY SET RCVrate=RCVVAL/RCVQTY  WHERE RCVQTY<>0"
        '    str = str & " UPDATE STOCKSUMMARY SET ISSrate=ISSVAL/ISSQTY  WHERE ISSQTY<>0"
        '    str = str & "  UPDATE STOCKSUMMARY SET CLSrate=CLSVAL/CLSQTY  WHERE CLSQTY<>0"

        '    'str = str & " --UPDATE STOCKSUMMARY SET CLSRATE=CLSRATE*-1 WHERE CLSRATE LIKE '%-%'"

        '    '   str = str & " update stocksummary set pegs=b.pegs  from stocksummary a,inventoryitemmaster b where a.itemcode=b.itemcode and b.storecode='MNS'"
        '    str = str & " update stocksummary set opqty=0,opval=0 where opqty=0.001"
        '    str = str & " update stocksummary set clsqty=0,clsval=0 where clsqty=0.001"

        '    str = str & " update STOCKSUMMARY set Opval=Oprate * Opqty "

        '    str = str & " update STOCKSUMMARY SET DISPQTY=0  "
        '    str = str & " UPDATE STOCKSUMMARY SET DISPQTY=CLSQTY-FLOOR(CLSQTY) WHERE FLOOR(CLSQTY)-CLSQTY<0 "
        '    str = str & " UPDATE STOCKSUMMARY SET DISPQTY=DISPQTY/(SELECT TOP 1 GQTY FROM BOM_DET B WHERE B.GITEMCODE=STOCKSUMMARY.ITEMCODE ) WHERE DISPQTY>0 "
        '    str = str & " UPDATE STOCKSUMMARY SET DISPQTY=FLOOR(CLSQTY)+(DISPQTY/100) "
        '    str = str & " UPDATE STOCKSUMMARY SET DISPQTY=ROUND(DISPQTY,2) "
        '    str = str & " UPDATE STOCKSUMMARY SET DISPQTY=round(DISPQTY,0,1)  WHERE DISPQTY <0 "

        '    str = str & " UPDATE STOCKSUMMARY SET DISPQTY=CLSQTY  WHERE FLOOR(CLSQTY)-CLSQTY=0"

        '    str = str & " update STOCKSUMMARY SET OPDISPQTY=0 "
        '    str = str & " UPDATE STOCKSUMMARY SET OPDISPQTY=OPQTY-FLOOR(OPQTY) WHERE FLOOR(OPQTY)-OPQTY<0 "
        '    str = str & " UPDATE STOCKSUMMARY SET OPDISPQTY=OPDISPQTY/(SELECT TOP 1 GQTY FROM BOM_DET B WHERE B.GITEMCODE=STOCKSUMMARY.ITEMCODE ) WHERE OPDISPQTY>0 "
        '    str = str & " UPDATE STOCKSUMMARY SET OPDISPQTY=FLOOR(OPQTY)+(OPDISPQTY/100) "
        '    str = str & " UPDATE STOCKSUMMARY SET OPDISPQTY=ROUND(OPDISPQTY,2) "
        '    str = str & " UPDATE STOCKSUMMARY SET OPDISPQTY=OPQTY WHERE FLOOR(OPQTY)-OPQTY=0 "
        '    str = str & " UPDATE STOCKSUMMARY SET OPDISPQTY=round(OPDISPQTY,0,1)  WHERE OPDISPQTY <0 "

        '    str = str & " update STOCKSUMMARY SET ISDISPQTY=0 "
        '    str = str & " UPDATE STOCKSUMMARY SET ISDISPQTY=ISSQTY-FLOOR(ISSQTY) WHERE FLOOR(ISSQTY)-ISSQTY<0 "
        '    str = str & " UPDATE STOCKSUMMARY SET ISDISPQTY=ISDISPQTY/(SELECT TOP 1 GQTY FROM BOM_DET B WHERE B.GITEMCODE=STOCKSUMMARY.ITEMCODE) WHERE ISDISPQTY>0 "
        '    str = str & " UPDATE STOCKSUMMARY SET ISDISPQTY=FLOOR(ISSQTY)+(ISDISPQTY/100) "
        '    str = str & " UPDATE STOCKSUMMARY SET ISDISPQTY=ROUND(ISDISPQTY,2) "
        '    str = str & " UPDATE STOCKSUMMARY SET ISDISPQTY=ISSQTY WHERE FLOOR(ISSQTY)-ISSQTY=0 "

        '    'str = str & " --UPDATE STOCKSUMMARY SET DISPQTY = CLSQTY"
        '    'str = str & " --UPDATE STOCKSUMMARY SET OPDISPQTY = OPQTY"
        '    'str = str & "--UPDATE STOCKSUMMARY SET ISDISPQTY = ISSQTY"


        '    'str = str & " --update "
        '    str = str & " DELETE FROM STOCKSUMMARY WHERE ITEMCODE IN (SELECT ITEMCODE FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=STOCKSUMMARY.ITEMCODE AND ISNULL(B.SELECTOPT,'N')<>'Y')"
        '    str = str & " print 'tarun'  "


        '    gconnection.dataOperation1(6, str, "item")

        'End If
        str = "select * from sysobjects where name='STOCKSUMMARY' and xtype='U'"
        gconnection.getDataSet(str, "STOCKSUMMARY")
        If gdataset.Tables("STOCKSUMMARY").Rows.Count > 0 Then

        Else

            str = "     CREATE TABLE [dbo].[STOCKSUMMARY]( "
            str = str & " [Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " 	[Itemcode] [varchar](50) NULL,"
            str = str & "  [Itemname] [varchar](50) NULL,"
            str = str & "  [Uom] [varchar](50) NULL,"
            str = str & "  [Valuation] [varchar](50) NULL,"
            str = str & "  [Opqty] [numeric](18, 3) NULL,"
            str = str & "  [Oprate] [numeric](18, 2) NULL,"
            str = str & "  [Opval] [numeric](18, 2) NULL,"
            str = str & "  [Rcvqty] [numeric](18, 3) NULL,"
            str = str & "  [Rcvrate] [numeric](18, 2) NULL,"
            str = str & "  [Rcvval] [numeric](18, 2) NULL,"
            str = str & "  [Issqty] [numeric](18, 3) NULL,"
            str = str & "  [Issrate] [numeric](18, 2) NULL,"
            str = str & "  [Issval] [numeric](18, 2) NULL,"
            str = str & "  [Clsqty] [numeric](18, 3) NULL,"
            str = str & "  [Clsrate] [numeric](18, 2) NULL,"
            str = str & " [Clsval] [numeric](18, 2) NULL,"
            str = str & "  [STORECODE] [varchar](50) NULL,"
            str = str & "  [GROUPCODE] [varchar](15) NULL,"
            str = str & "  [GROUPNAME] [varchar](50) NULL,"
            str = str & " [SUBGROUPCODE] [varchar](15) NULL,"
            str = str & "  [SUBGROUPNAME ] [varchar](50) NULL,"
            str = str & " [pegsqty] [numeric](12, 3) NULL,"
            str = str & "  [pegs] [numeric](12, 3) NULL,"
            str = str & "  [RCVQTY1] [numeric](18, 3) NULL,"
            str = str & "  [RCVRATE1] [numeric](18, 2) NULL,"
            str = str & "  [RCVVAL1] [numeric](18, 2) NULL,"
            str = str & " [RCVQTY2] [numeric](18, 3) NULL,"
            str = str & " [RCVRATE2] [numeric](18, 2) NULL,"
            str = str & "  [RCVVAL2] [numeric](18, 2) NULL,"
            str = str & "  [RCVQTY3] [numeric](18, 3) NULL,"
            str = str & "  [RCVRATE3] [numeric](18, 2) NULL,"
            str = str & "  [RCVVAL3] [numeric](18, 2) NULL,"
            str = str & "  [ISSQTY1] [numeric](18, 3) NULL,"
            str = str & "  [ISSRATE1] [numeric](18, 2) NULL,"
            str = str & "  [ISSVAL1] [numeric](18, 2) NULL,"
            str = str & "  [ISSQTY2] [numeric](18, 3) NULL,"
            str = str & "  [ISSRATE2] [numeric](18, 2) NULL,"
            str = str & "  [ISSVAL2] [numeric](18, 2) NULL,"
            str = str & " [ISSQTY3] [numeric](18, 3) NULL,"
            str = str & " [ISSRATE3] [numeric](18, 2) NULL,"
            str = str & " [ISSVAL3] [numeric](18, 2) NULL,"
            str = str & " [DISPQTY] [numeric](18, 3) NULL,"
            str = str & " [DISPUOM] [varchar](50) NULL,"
            str = str & " [opdispqty] [numeric](12, 3) NULL,"
            str = str & " [ISDISPQTY] [numeric](12, 3) NULL,"
            str = str & " [category] [varchar](50) NULL,"
            str = str & " [ADJVAL] [numeric](18, 2) NULL,"
            str = str & " [ADJQTY] [numeric](18, 3) NULL,"
            str = str & " [Adjrate] [numeric](18, 3) NULL"
            str = str & " ) "
            gconnection.dataOperation1(6, str, "item")
        End If
        str = "select * from sysobjects where name='STKSUMMARY' and xtype='U'"
        gconnection.getDataSet(str, "STKSUMMARY")
        If gdataset.Tables("STKSUMMARY").Rows.Count > 0 Then

        Else


            str = "   CREATE TABLE [dbo].[STKSUMMARY]("
            str = str & " [Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " [Itemcode] [varchar](50) NULL,"
            str = str & " [Itemname] [varchar](75) NULL,"
            str = str & " [Uom] [varchar](50) NULL,"
            str = str & "[Valuation] [varchar](50) NULL,"
            str = str & " [Opqty] [numeric](18, 3) NULL,"
            str = str & " [Oprate] [numeric](18, 2) NULL,"
            str = str & " [Opval] [numeric](18, 2) NULL,"
            str = str & " [Rcvqty] [numeric](18, 3) NULL,"
            str = str & " [Rcvrate] [numeric](18, 2) NULL,"
            str = str & " [Rcvval] [numeric](18, 2) NULL,"
            str = str & " [Issqty] [numeric](18, 3) NULL,"
            str = str & " [Issrate] [numeric](18, 2) NULL,"
            str = str & " [Issval] [numeric](18, 2) NULL,"
            str = str & " [Clsqty] [numeric](18, 3) NULL,"
            str = str & " [Clsrate] [numeric](18, 2) NULL,"
            str = str & " [Clsval] [numeric](18, 2) NULL,"
            str = str & " [STORECODE] [varchar](50) NULL,"
            str = str & " [GROUPCODE] [varchar](15) NULL,"
            str = str & " [GROUPNAME] [varchar](50) NULL,"
            str = str & " [SUBGROUPCODE] [varchar](15) NULL,"
            str = str & " [SUBGROUPNAME] [varchar](50) NULL,"
            str = str & " [pegsqty] [numeric](12, 3) NULL,"
            str = str & " [pegs] [numeric](12, 3) NULL,"
            str = str & " [RCVQTY1] [numeric](18, 3) NULL,"
            str = str & " [RCVRATE1] [numeric](18, 2) NULL,"
            str = str & " [RCVVAL1] [numeric](18, 2) NULL,"
            str = str & " [RCVQTY2] [numeric](18, 3) NULL,"
            str = str & "[RCVRATE2] [numeric](18, 2) NULL,"
            str = str & " [RCVVAL2] [numeric](18, 2) NULL,"
            str = str & " [RCVQTY3] [numeric](18, 3) NULL,"
            str = str & " [RCVRATE3] [numeric](18, 2) NULL,"
            str = str & " [RCVVAL3] [numeric](18, 2) NULL,"
            str = str & " [ISSQTY1] [numeric](18, 3) NULL,"
            str = str & " [ISSRATE1] [numeric](18, 2) NULL,"
            str = str & " [ISSVAL1] [numeric](18, 2) NULL,"
            str = str & " [ISSQTY2] [numeric](18, 3) NULL,"
            str = str & " [ISSRATE2] [numeric](18, 2) NULL,"
            str = str & " [ISSVAL2] [numeric](18, 2) NULL,"
            str = str & " [ISSQTY3] [numeric](18, 3) NULL,"
            str = str & " [ISSRATE3] [numeric](18, 2) NULL,"
            str = str & " [ISSVAL3] [numeric](18, 2) NULL,"
            str = str & " [DISPQTY] [numeric](18, 3) NULL,"
            str = str & " [DISPUOM] [varchar](50) NULL,"
            str = str & " [opdispqty] [numeric](12, 3) NULL,"
            str = str & " [ISDISPQTY] [numeric](12, 3) NULL,"
            str = str & " [TTYPE] [varchar](10) NULL,"
            str = str & " [category] [varchar](50) NULL,"
            str = str & " [ADJQTY] [numeric](18, 3) NULL,"
            str = str & " 	[ADJVAL] [numeric](18, 2) NULL,"
            str = str & " [Adjrate] [numeric](18, 3) NULL"
            str = str & " )"

            gconnection.dataOperation1(6, str, "item")

        End If

        str = "select * from sysobjects where name='SUBSTORECONSUMPTIONDETAIL' and xtype='U'"
        gconnection.getDataSet(str, "SUBSTORECONSUMPTIONDETAIL")
        If gdataset.Tables("SUBSTORECONSUMPTIONDETAIL").Rows.Count > 0 Then

        Else


            str = "       CREATE TABLE [dbo].[SUBSTORECONSUMPTIONDETAIL]("
            str = str & " [Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " [Docno] [varchar](50) NOT NULL,"
            str = str & " [Docdetails] [varchar](50) NULL,"
            str = str & " [Docdate] [datetime] NULL,"
            str = str & " [Storelocationcode] [varchar](50) NULL,"
            str = str & " [Storelocationname] [varchar](50) NULL,"
            str = str & " [Itemcode] [varchar](50) NULL,"
            str = str & " [Itemname] [varchar](50) NULL,"
            str = str & " [Uom] [varchar](50) NULL,"
            str = str & " [Qty] [numeric](18, 3) NULL,"
            str = str & " [Rate] [numeric](18, 2) NULL,"
            str = str & " [Amount] [numeric](18, 2) NULL,"
            str = str & " [Dblamt] [numeric](18, 2) NULL,"
            str = str & " [Dblconv] [varchar](50) NULL,"
            str = str & " [Highratio] [numeric](18, 2) NULL,"
            str = str & " [Groupcode] [varchar](50) NULL,"
            str = str & " [Subgroupcode] [varchar](50) NULL,"
            str = str & " [Void] [char](1) NULL,"
            str = str & " [Adduser] [varchar](50) NULL,"
            str = str & " [Adddatetime] [datetime] NULL,"
            str = str & " [Updateuser] [varchar](50) NULL,"
            str = str & " [Updatetime] [datetime] NULL,"
            str = str & " [SSCTransQty] [decimal](18, 2) NULL,"
            str = str & " [SSCStockUom] [varchar](25) NULL,"
            str = str & " [SSCTransValue] [numeric](18, 2) NULL,"
            str = str & " [SSCTRANSRATE] [numeric](18, 2) NULL,"
            str = str & " [UOMR] [varchar](50) NULL,"
            str = str & " [SSCStockUomR] [varchar](50) NULL,"
            str = str & " [SSCTransQtyR] [numeric](18, 2) NULL,"
            str = str & " [SSCTransValueR] [numeric](18, 2) NULL"
            str = str & " )"
            gconnection.dataOperation1(6, str, "item")

        End If


        str = "select * from sysobjects where name='ACCOUNTSSETUP' and xtype='U'"
        gconnection.getDataSet(str, "ACCOUNTSSETUP")
        If gdataset.Tables("ACCOUNTSSETUP").Rows.Count > 0 Then

        Else


            str = "CREATE TABLE [dbo].[ACCOUNTSSETUP]( "
            str = str & " [SdrsCode] [varchar](50) NULL,"
            str = str & " 	[SdrsDesc] [varchar](50) NULL,"
            str = str & " [ScrsCode] [varchar](50) NULL,"
            str = str & " [ScrsDesc] [varchar](50) NULL,"
            str = str & " [ManualMatching] [varchar](1) NULL,"
            str = str & " [AutoMatching] [varchar](1) NULL,"
            str = str & " [BothMatching] [varchar](1) NULL,"
            str = str & " [PLCODE] [varchar](100) NULL,"
            str = str & " [PLDESC] [varchar](100) NULL,"
            str = str & " [BSCODE] [varchar](100) NULL,"
            str = str & " [BSDESC] [varchar](100) NULL,"
            str = str & " [Costcenter] [varchar](1) NULL,"
            str = str & " [MATCHING] [varchar](1) NULL,"
            str = str & " [clublogo] [image] NULL,"
            str = str & " [gPosPosting] [varchar](2) NULL,"
            str = str & " [balanceprint] [varchar](1) NULL,"
            str = str & " [posposting] [varchar](1) NULL,"
            str = str & " [subscode] [varchar](10) NULL,"
            str = str & " [AliasPrint] [varchar](20) NULL,"
            str = str & " [ADD_DATE] [datetime] NULL,"
            str = str & " [ADD_USER] [varchar](50) NULL,"
            str = str & " [UPD_USER] [varchar](9) NULL,"
            str = str & " [UPD_DATE] [datetime] NULL,"
            str = str & " [VOID] [varchar](9) NULL,"
            str = str & " [VOIDUSER] [varchar](9) NULL,"
            str = str & " [VOIDDATE] [datetime] NULL,"
            str = str & " [AUTHORISED] [varchar](2) NULL,"
            str = str & " [AUTHORISE_LEVEL1] [varchar](2) NULL,"
            str = str & " [AUTHORISE_USER1] [varchar](20) NULL,"
            str = str & " [AUTHORISE_DATE1] [datetime] NULL,"
            str = str & " [AUTHORISE_LEVEL2] [varchar](2) NULL,"
            str = str & " [AUTHORISE_USER2] [varchar](20) NULL,"
            str = str & " [AUTHORISE_DATE2] [datetime] NULL,"
            str = str & " [AUTHORISE_LEVEL3] [varchar](2) NULL,"
            str = str & " [AUTHORISE_USER3] [varchar](20) NULL,"
            str = str & " [AUTHORISE_DATE3] [datetime] NULL,"
            str = str & " [INVACCPOSTING] [varchar](5) NULL,"
            str = str & " [INVACCPOSTINGMODE] [varchar](5) NULL"
            str = str & "  ) "
            gconnection.dataOperation1(6, str, "item")

        End If
        str = "select * from sysobjects where name='BOM_DET' and xtype='U'"
        gconnection.getDataSet(str, "BOM_DET")
        If gdataset.Tables("BOM_DET").Rows.Count > 0 Then

        Else

            str = "            CREATE TABLE [dbo].[BOM_DET]( "
            str = str & " [Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL, "
            str = str & " [Itemcode] [varchar](50) NULL,"
            str = str & " [Itemname] [varchar](50) NULL, "
            str = str & " [ItemUOM] [varchar](50) NULL,"
            str = str & " [ItemEOQ] [numeric](18, 0) NULL, "
            str = str & " [Itemtype] [varchar](50) NULL,"
            str = str & " [Totalqty] [float] NULL,"
            str = str & " [Totalamt] [float] NULL,"
            str = str & " [gitemcode] [varchar](50) NULL,"
            str = str & " [gitemname] [varchar](50) NULL,"
            str = str & " [gUOM] [varchar](50) NULL,"
            str = str & " [gqty] [float] NULL,"
            str = str & " [grate] [float] NULL,"
            str = str & " [gamount] [float] NULL,"
            str = str & " [gdblamt] [float] NULL,"
            str = str & " [ghighratio] [float] NULL,"
            str = str & " [ggroupcode] [varchar](50) NULL,"
            str = str & " [gsubgroupcode] [varchar](50) NULL,"
            str = str & " [Void] [char](10) NULL,"
            str = str & " [Adduser] [varchar](50) NULL,"
            str = str & " [Adddate] [datetime] NULL,"
            str = str & " [DISPITEM] [varchar](1) NULL,"
            str = str & " [UPDATEUSER] [varchar](15) NULL,"
            str = str & " [UPDATETIME] [datetime] NULL"
            str = str & " )"
            gconnection.dataOperation1(6, str, "item")

        End If

        str = "select * from sysobjects where name='vw_inv_stkconsumebill' and xtype='V'"
        gconnection.getDataSet(str, "vw_inv_stkconsumebill")
        If gdataset.Tables("vw_inv_stkconsumebill").Rows.Count > 0 Then

        Else

            str = "   CREATE   view [dbo].[vw_inv_stkconsumebill] as     "
            str = str & " SELECT ISNULL(H.DOCDETAILS,'') AS DOCDETAILS,H.DOCDATE AS DOCDATE,ISNULL(H.STORELOCATIONCODE,'') AS STORELOCATIONCODE,    "
            str = str & " ISNULL(H.STORELOCATIONDESC,'') AS STORELOCATIONDESC,ISNULL(D.ITEMCODE,'') AS ITEMCODE,   "
            str = str & " ISNULL(D.ITEMNAME,'') AS ITEMNAME,ISNULL(D.consumercode,'') AS consumercode,ISNULL(D.UOM,'') AS UOM,  ISNULL(D.STOCKINHAND,0) AS STOCKINHAND,   "
            str = str & " ISNULL(D.PHYSICALSTOCK,0) AS PHYSICALSTOCK, ISNULL(D.ADJUSTEDSTOCK,0) AS ADJUSTEDSTOCK,ISNULL(D.RATE,0) AS RATE,    "
            str = str & " ISNULL(D.AMOUNT,0) AS AMOUNT,isnull(REMARKS,'') AS REMARKS,ISNULL(H.UPDFOOTER,'') AS UPDFOOTER ,ISNULL(H.UPDSIGN,'') AS UPDSIGN,  "
            str = str & " ISNULL(D.REMARKS_DET,'') AS REMARKS_DET  , (case  ISNULL(h.UPDATETIME,'')  when '' then   "
            str = str & " ISNULL(h.ADDDATE,'') else ISNULL(h.UPDATETIME,'') end) as ADDDATE   FROM STOCKADJUSTHEADER AS H   "
            str = str & " INNER JOIN  STOCKADJUSTDETAILS AS D ON D.DOCDETAILS = H.DOCDETAILS  and D.ttype = H.ttype  "
            str = str & " and isnull(consumercode,'')<>'' and d.ttype='C'"
            gconnection.dataOperation1(6, str, "item")
        End If


        str = "select * from sysobjects where name='VIEWSTOCKLEDGERMAINSTORE' and xtype='V'"
        gconnection.getDataSet(str, "VIEWSTOCKLEDGERMAINSTORE")
        If gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE").Rows.Count > 0 Then

        Else


            str = "    CREATE                   VIEW [dbo].[VIEWSTOCKLEDGERMAINSTORE]  "
            str = str & " AS  "
            str = str & " SELECT '' AS INDENTNO ,H.GRNDATE AS GRNDATE,('A' + ISNULL(H.GRNDETAILS,'')) AS GRNDETAILS,ISNULL(H.SUPPLIERCODE,'') AS SUPPLIERCODE,  "
            str = str & " ISNULL(H.SUPPLIERNAME,'') AS SUPPLIERNAME,  "
            str = str & " round((isnull(D.GRNTRANSVALUE,0)+isnull(D.TAXAMOUNT,0)+isnull(D.OTHCHARGE,0)-isnull(D.DISCOUNT,0))/ISNULL((D.grntransqty),0),2) AS GRNRATE,  "
            str = str & " ISNULL((D.GRNTRANSQTY),0) AS GRNQTY,  "
            str = str & " ISNULL(D.ITEMCODE,'') AS ITEMCODE,ISNULL(D.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM,  "
            str = str & " ISNULL(I.VALUATION,'') AS VALUATION,ISNULL(I.GROUPNAME,'') AS GROUPDESC,H.UPDATETIME AS ADDDATE,  "
            str = str & " '' AS OPSTORELOCATIONNAME  "
            str = str & " FROM GRN_HEADER AS H INNER JOIN GRN_DETAILS AS D ON D.GRNDETAILS = H.GRNDETAILS  "
            str = str & " INNER JOIN INVENTORYITEMMASTER AS I ON I.ITEMCODE = D.ITEMCODE WHERE I.STORECODE=H.STORECODE AND ISNULL(VOIDITEM,'') <> 'Y'  "
            str = str & " AND D.STORECODE LIKE 'MN%' and isnull(H.GRNTYPE,'')='GRN'  "

            str = str & "             UNION ALL"
            str = str & " SELECT '' AS INDENTNO ,H.GRNDATE AS GRNDATE,('R' + ISNULL(H.GRNDETAILS,'')) AS GRNDETAILS,ISNULL(H.SUPPLIERCODE,'') AS SUPPLIERCODE,  "
            str = str & " ISNULL(H.SUPPLIERNAME,'') AS SUPPLIERNAME,  "
            str = str & " round((isnull(D.GRNTRANSVALUE,0)+isnull(D.TAXAMOUNT,0)+isnull(D.OTHCHARGE,0)-isnull(D.DISCOUNT,0))/ISNULL((D.grntransqty),0),2) AS GRNRATE,  "
            str = str & " ISNULL((D.GRNTRANSQTY),0) AS GRNQTY,  "
            str = str & " ISNULL(D.ITEMCODE,'') AS ITEMCODE,ISNULL(D.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM,  "
            str = str & " ISNULL(I.VALUATION,'') AS VALUATION,ISNULL(I.GROUPNAME,'') AS GROUPDESC,H.UPDATETIME AS ADDDATE,  "
            str = str & " '' AS OPSTORELOCATIONNAME  "
            str = str & " FROM GRN_HEADER AS H INNER JOIN GRN_DETAILS AS D ON D.GRNDETAILS = H.GRNDETAILS  "
            str = str & " INNER JOIN INVENTORYITEMMASTER AS I ON I.ITEMCODE = D.ITEMCODE WHERE I.STORECODE=H.STORECODE AND ISNULL(VOIDITEM,'') <> 'Y'  "
            str = str & " AND D.STORECODE LIKE 'MN%' and isnull(H.GRNTYPE,'')='PRN'  "

            str = str & " --SELECT * FROM STOCKISSUEDETAIL  "
            str = str & " --GROUP BY H.GRNDATE,I.GROUPNAME,D.ITEMCODE,D.ITEMNAME,H.GRNDETAILS,  "
            str = str & " --H.SUPPLIERCODE,H.SUPPLIERNAME,D.RATE,I.STOCKUOM,I.VALUATION,H.UPDATETIME  "
            str = str & " UNION ALL"
            str = str & " SELECT D.INDENTNO AS INDENTNO , H.DOCDATE AS GRNDATE,('B' + ISNULL(H.DOCDETAILS,'')) AS GRNDETAILS,'',  "
            str = str & "  '',ISNULL(D.RATE,0) AS GRNRATE,ISNULL((D.ISSTRANSQTY),0) AS GRNQTY,  "
            str = str & " ISNULL(D.ITEMCODE,'') AS ITEMCODE,ISNULL(D.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM,  "
            str = str & " ISNULL(I.VALUATION,'') AS VALUATION,ISNULL(I.GROUPNAME,'') AS GROUPDESC,H.UPDATETIME AS ADDDATE,  "
            str = str & " ISNULL(H.OPSTORELOCATIONNAME,'') AS OPSTORELOCATIONNAME  "
            str = str & " FROM STOCKISSUEHEADER AS H INNER JOIN STOCKISSUEDETAIL AS D ON D.DOCDETAILS = H.DOCDETAILS  "
            str = str & " INNER JOIN INVENTORYITEMMASTER AS I ON I.ITEMCODE = D.ITEMCODE WHERE I.STORECODE=H.STORELOCATIONCODE AND ISNULL(H.VOID,'') <> 'Y'  "
            str = str & " AND D.STORELOCATIONCODE LIKE 'MN%'  "
            str = str & " --GROUP BY H.DOCDATE,I.GROUPNAME,D.ITEMCODE,D.ITEMNAME,H.DOCDETAILS,  "
            str = str & " --D.RATE,I.STOCKUOM,I.VALUATION,H.UPDATETIME  "
            str = str & " UNION ALL"
            str = str & " SELECT '' AS INDENTNO ,H.DOCDATE AS GRNDATE,('C' + ISNULL(H.DOCDETAILS,'')) AS GRNDETAILS,'',  "
            str = str & " '',ISNULL(D.RATE,0) AS GRNRATE,ISNULL((D.TRFTRANSQTY),0) AS GRNQTY,  "
            str = str & " ISNULL(D.ITEMCODE,'') AS ITEMCODE,ISNULL(D.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM,  "
            str = str & " ISNULL(I.VALUATION,'') AS VALUATION,ISNULL(I.GROUPNAME,'') AS GROUPDESC,H.UPDATETIME AS ADDDATE,  "
            str = str & " ISNULL(H.TOSTOREDESC,'') AS OPSTORELOCATIONNAME  "
            str = str & " FROM STOCKTRANSFERHEADER AS H INNER JOIN STOCKTRANSFERDETAIL AS D ON D.DOCDETAILS = H.DOCDETAILS  "
            str = str & " INNER JOIN INVENTORYITEMMASTER AS I ON I.ITEMCODE = D.ITEMCODE  "
            str = str & " where h.tostorecode = I.STORECODE"
            str = str & " AND h.tostorecode LIKE 'MN%'  "
            str = str & " --AND I.STORECODE=H.STORECODE   "
            str = str & " AND ISNULL(H.VOID,'') <>'Y'  "
            str = str & " --GROUP BY H.DOCDATE,I.GROUPNAME,D.ITEMCODE,D.ITEMNAME,H.DOCDETAILS,  "
            str = str & " --D.RATE,I.STOCKUOM,I.VALUATION,H.UPDATETIME  "
            str = str & " union all"
            str = str & " SELECT '''' AS INDENTNO ,H.DOCDATE AS GRNDATE,('Dadj' + ISNULL(H.DOCDETAILS,'')) AS GRNDETAILS,'',  "
            str = str & "             '',ISNULL(D.RATE,0) AS GRNRATE,ISNULL(D.ADJTRANSQTY,0) AS GRNQTY,  "
            str = str & " ISNULL(D.ITEMCODE,'') AS ITEMCODE,ISNULL(D.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM,  "
            str = str & " ISNULL(I.VALUATION,'') AS VALUATION,ISNULL(I.GROUPNAME,'') AS GROUPDESC,H.UPDATETIME AS ADDDATE,  "
            str = str & " ''  AS OPSTORELOCATIONNAME  "
            str = str & " FROM STOCKadjustHEADER AS H INNER JOIN stockadjustdetails AS D ON D.DOCDETAILS = H.DOCDETAILS  "
            str = str & " INNER JOIN INVENTORYITEMMASTER AS I ON I.ITEMCODE = D.ITEMCODE AND ISNULL(D.VOID,'') <>'Y'  "
            str = str & " where I.storecode = H.STORELOCATIONCODE"
            str = str & " AND H.STORELOCATIONCODE  LIKE 'MN%'  "
            str = str & " --AND H.STORELOCATIONCODE=H.STORECODE"
            gconnection.dataOperation1(6, str, "item")

        End If
        str = "drop view VW_INV_GRNBILL"

        str = "select * from sysobjects where name='VW_INV_GRNBILL' and xtype='V'"
        gconnection.getDataSet(str, "VW_INV_GRNBILL")
        If gdataset.Tables("VW_INV_GRNBILL").Rows.Count > 0 Then


        Else

            '     str = "    CREATE     VIEW [dbo].[VW_INV_GRNBILL] AS SELECT ISNULL(D.AUTOID,'') AS AUTOID,ISNULL(G.PONO,'') AS PONO, ISNULL(G.GRNDETAILS,'') AS GRNDETAILS,G.GRNDATE, ISNULL(G.SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(G.SUPPLIERNAME,'') AS SUPPLIERNAME,   ISNULL(G.SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(G.StoreCode,'') AS EXCISEPASSNO,ISNULL(G.GLACCOUNTCODE,'') AS GLACCOUNTCODE,ISNULL(G.GLACCOUNTNAME,'') AS GLACCOUNTNAME,    ISNULL(G.TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(G.SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(D.DISCOUNT,0) AS DISCOUNT,ISNULL(G.BILLAMOUNT,0) AS BILLAMOUNT, ISNULL(D.ITEMCODE,'') AS ITEMCODE, ISNULL(D.ITEMNAME,'') AS ITEMNAME,ISNULL(D.UOM,'') AS UOM, ISNULL(D.QTY,0) AS QTY, ISNULL(D.RATE,0) AS RATE,ISNULL(G.REMARKS,'') AS REMARKS,    ISNULL(D.AMOUNT,0) AS AMOUNT,ISNULL(D.SALERATE,0) AS SALERATE,ISNULL(D.SALEAMOUNT,0) AS SALEAMOUNT,isnull(d.discount,0) as ddiscount,isnull(d.taxper,0) as taxper,isnull(d.taxamount,0) as taxamount, isnull(g.OverallDiscount,0) OverallDiscount,ISNULL(UPDFOOTER,'') AS UPDFOOTER,ISNULL(UPDNAME,'') AS UPDNAME,ISNULL(g.Adddate,'') AS ADDDATE ,ISNULL(g.UPDATETIME,'') AS UPDATETIME,ISNULL(D.TAXCODE,'')AS TAXGROUPCODE,ISNULL(D.VOIDITEM,'')AS VOIDITEM,ISNULL(G.ROUNDUPAMT,0)AS ROUNDUPAMT    FROM GRN_HEADER AS G INNER JOIN GRN_DETAILS AS D ON G.GRNDETAILS = D.GRNDETAILS "
            str = "    CREATE     VIEW [dbo].[VW_INV_GRNBILL] AS SELECT ISNULL(D.AUTOID,'') AS AUTOID,ISNULL(G.PONO,'') AS PONO,  ISNULL(G.GRNDETAILS,'') AS GRNDETAILS,G.GRNDATE, ISNULL(G.SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(G.SUPPLIERNAME,'') AS SUPPLIERNAME, ISNULL(G.SUPPLIERINVNO,'') AS SUPPLIERINVNO,       ISNULL(G.StoreCode,'') AS EXCISEPASSNO, ISNULL(G.TOTALAMOUNT,0) AS TOTALAMOUNT, ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(G.SURCHARGEAMT,0) AS SURCHARGEAMT, ISNULL(D.DISCOUNT,0) AS DISCOUNT,ISNULL(G.BILLAMOUNT,0) AS BILLAMOUNT,  ISNULL(D.ITEMCODE,'') AS ITEMCODE, ISNULL(D.ITEMNAME,'') AS ITEMNAME, ISNULL(D.UOM,'') AS UOM, ISNULL(D.QTY,0) AS QTY, ISNULL(D.RATE,0) AS RATE,ISNULL(G.REMARKS,'') AS REMARKS,    ISNULL(D.AMOUNT,0) AS AMOUNT, isnull(d.discount,0) as ddiscount,isnull(d.taxper,0) as taxper, isnull(d.taxamount,0) as taxamount, isnull(g.OverallDiscount,0) OverallDiscount, ISNULL(g.Adddate,'') AS ADDDATE  ,ISNULL(D.taxcode,'') AS TAXGROUPCODE,ISNULL(G.RoundupAmt,0) AS RoundupAmt,ISNULL(D.IGSTAmt,0) AS IGSTAmt,ISNULL(D.SGSTAmt,0) AS SGSTAmt,ISNULL(D.CGSTAmt,0) AS CGSTAmt,ISNULL(SL.contactperson,'') AS contactperson,ISNULL(SL.address1,'') AS address1,ISNULL(SL.address2,'') AS address2,  ISNULL(SL.city,'') AS city,ISNULL(SL.state,'') AS state,ISNULL(SL.PIN,'') AS pIN , ISNULL(SL.phoneno,'') AS PhONENO, ISNULL(SL.GSTINNO,'') AS GSTINNO ,ISNULL(SL.VENDORTYPE,'') AS VENDORTYPE ,ISNULL(IV.HSNNO,'') AS HSNNO,ISNULL(IV.TAXTYPE,'') AS  TAXTYPE,ISNULL(D.SPLCESS,0) AS SPLCESS,ISNULL(D.CESSAMT,0) AS CESSAMT,ISNULL(D.VOIDITEM,'')AS VOIDITEM FROM GRN_HEADER AS G INNER JOIN GRN_DETAILS AS D ON G.GRNDETAILS = D.GRNDETAILS  INNER JOIN  SUPPLIERDetails SL ON SL.vendorcode=G.Suppliercode INNER JOIN INV_InventoryItemMaster IV ON             IV.itemcode = D.Itemcode            "
            gconnection.dataOperation1(6, str, "item")

        End If

        str = "drop view VW_INV_ISSUEBILL "
        str = "select * from sysobjects where name='VW_INV_ISSUEBILL' and xtype='V'"
        gconnection.getDataSet(str, "VW_INV_ISSUEBILL")
        If gdataset.Tables("VW_INV_ISSUEBILL").Rows.Count > 0 Then


        Else

            str = "           CREATE  VIEW  [dbo].[VW_INV_ISSUEBILL] AS SELECT TOP 100 PERCENT dbo.stockissueheader.docdetails, dbo.stockissueheader.docdate, dbo.stockissueheader.storelocationname, dbo.stockissueheader.opstorelocationname, dbo.stockissuedetail.itemcode, dbo.stockissueheader.storelocationcode,dbo.stockissueheader.opstorelocationcode, dbo.stockissuedetail.itemname, dbo.stockissuedetail.uom,dbo.stockissuedetail.qty, dbo.stockissuedetail.rate, dbo.stockissuedetail.amount ,isnull(dbo.stockissuedetail.clsqty,0) as clsqty , dbo.stockissueheader.indentno ,  dbo.stockissueheader.indentdate,dbo.stockissueheader.remarks, dbo.stockissueheader.UPDFOOTER,dbo.stockissueheader.UPDSIGN, (case  ISNULL(dbo.stockissueheader.UPDATETIME,'')  when '' then ISNULL(dbo.stockissueheader.ADDDATE,'') else ISNULL(dbo.stockissueheader.UPDATETIME,'') end) as ADDDATE,ISNULL(dbo.stockissueheader.partybookingno,'')as partybookingno  FROM dbo.stockissuedetail INNER JOIN dbo.stockissueheader  ON dbo.stockissuedetail.docdetails = dbo.stockissueheader.docdetails"
            gconnection.dataOperation1(6, str, "item")

        End If
        str = "select * from sysobjects where name='VW_INV_STKTRFBILL' and xtype='V'"
        gconnection.getDataSet(str, "VW_INV_STKTRFBILL")
        If gdataset.Tables("VW_INV_STKTRFBILL").Rows.Count > 0 Then


        Else

            str = "    CREATE  VIEW [dbo].[VW_INV_STKTRFBILL] AS  SELECT ISNULL(H.DOCDETAILS,'') AS DOCDETAILS,H.DOCDATE,ISNULL(H.FROMSTORECODE,'') AS FROMSTORECODE, ISNULL(H.FROMSTOREDESC,'') AS FROMSTOREDESC,ISNULL(H.TOSTORECODE,'') AS TOSTORECODE, ISNULL(H.TOSTOREDESC,'') AS TOSTOREDESC,ISNULL(H.CHALLENNO,'') AS CHALLENNO,H.CHALLENDATE AS CHALLENDATE, ISNULL(D.ITEMCODE,'') AS ITEMCODE,ISNULL(D.ITEMNAME,'') AS ITEMNAME,ISNULL(D.UOM,'') AS UOM,ISNULL(D.QTY,0) AS QTY, ISNULL(D.RATE,0) AS RATE,ISNULL(D.AMOUNT,0) AS AMOUNT,ISNULL(REMARKS,'') AS REMARKS,ISNULL(H.UPDFOOTER,'')  AS UPDFOOTER ,ISNULL(H.UPDSIGN,'') AS UPDSIGN , (case  ISNULL(h.UPDATETIME,'')  when '' then ISNULL(h.ADDDATE,'') else ISNULL(h.UPDATETIME,'') end) as ADDDATE   FROM STOCKTRANSFERHEADER AS H INNER JOIN STOCKTRANSFERDETAIL AS D ON H.DOCDETAILS = D.DOCDETAILS"
            gconnection.dataOperation1(6, str, "item")

        End If
        str = "select * from sysobjects where name='vw_inv_stkajdbill' and xtype='V'"
        gconnection.getDataSet(str, "vw_inv_stkajdbill")
        If gdataset.Tables("vw_inv_stkajdbill").Rows.Count > 0 Then


        Else

            str = " CREATE   view [dbo].[vw_inv_stkajdbill] as   SELECT ISNULL(H.DOCDETAILS,'') AS DOCDETAILS,H.DOCDATE AS DOCDATE,ISNULL(H.STORELOCATIONCODE,'') AS STORELOCATIONCODE,  ISNULL(H.STORELOCATIONDESC,'') AS STORELOCATIONDESC,ISNULL(D.ITEMCODE,'') AS ITEMCODE, ISNULL(D.ITEMNAME,'') AS ITEMNAME,ISNULL(D.UOM,'') AS UOM,  ISNULL(D.STOCKINHAND,0) AS STOCKINHAND, ISNULL(D.PHYSICALSTOCK,0) AS PHYSICALSTOCK, ISNULL(D.ADJUSTEDSTOCK,0) AS ADJUSTEDSTOCK,ISNULL(D.RATE,0) AS RATE,  ISNULL(D.AMOUNT,0) AS AMOUNT,isnull(REMARKS,'') AS REMARKS,ISNULL(H.UPDFOOTER,'') AS UPDFOOTER ,ISNULL(H.UPDSIGN,'') AS UPDSIGN,ISNULL(D.REMARKS_DET,'') AS REMARKS_DET  , (case  ISNULL(h.UPDATETIME,'')  when '' then ISNULL(h.ADDDATE,'') else ISNULL(h.UPDATETIME,'') end) as ADDDATE   FROM STOCKADJUSTHEADER AS H INNER JOIN  STOCKADJUSTDETAILS AS D ON D.DOCDETAILS = H.DOCDETAILS "
            gconnection.dataOperation1(6, str, "item")
        End If


        '***************************************************
        str = "Select * from sysobjects where name='MONTH_STB_TEMP' and xtype='U'"
        gconnection.getDataSet(str, "kot_det")
        If gdataset.Tables("kot_det").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE [dbo].[MONTH_STB_TEMP]("
            str = str & " [ITEMCODE] [varchar](10) NULL,"
            str = str & " [ITEMNAME] [varchar](50) NULL,"
            str = str & " [MNS1] [numeric](18, 2) NULL,"
            str = str & " [AMSB] [numeric](18, 2) NULL,"
            str = str & " [BVI] [numeric](18, 2) NULL,"
            str = str & " [TOTAL] [numeric](18, 2) NULL,"
            str = str & " [VI] [numeric](18, 2) NULL,"
            str = str & " [MNA] [numeric](18, 2) NULL,"
            str = str & " [AMSBTOT] [numeric](18, 2) NULL,"
            str = str & " [BVITOT] [numeric](18, 2) NULL,"
            str = str & " [MNS1TOT] [numeric](18, 2) NULL,"
            str = str & " [uom] [varchar](20) NULL,"
            str = str & " [groupcode] [varchar](20) NULL"
            str = str & " ) "
            gconnection.dataOperation1(6, str, "item")
        End If

        str = "select * from sysobjects where name='BAR_STOCKSUMMARY_TEMP' and xtype='U'"
        gconnection.getDataSet(str, "kot_det")
        If gdataset.Tables("kot_det").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE [dbo].[BAR_STOCKSUMMARY_TEMP]("
            str = str & " [ITEMCODE] [varchar](30) NULL,"
            str = str & " [ITEMNAME] [varchar](50) NULL,"
            str = str & " [UOM] [varchar](20) NULL,"
            str = str & " [STORECODE] [varchar](20) NULL,"
            str = str & " [CLSQTY] [numeric](18, 2) NULL,"
            str = str & " [CLSVALUE] [numeric](18, 2) NULL,"
            str = str & " [CLSQTY_TOT] [numeric](18, 2) NULL,"
            str = str & " [groupcode] [varchar](20) NULL"
            str = str & " )"
            gconnection.dataOperation1(6, str, "item")
        End If

        str = "select * from sysobjects where name='TEMP_CONSOLIDATED_STB' and xtype='U'"
        gconnection.getDataSet(str, "kot_det")
        If gdataset.Tables("kot_det").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE [dbo].[TEMP_CONSOLIDATED_STB]("
            str = str & " [ITEMCODE] [varchar](20) NULL,"
            str = str & " [ITEMNAME] [varchar](50) NULL,"
            str = str & " [UOM] [varchar](20) NULL,"
            str = str & " [OPQTY] [numeric](18, 3) NULL,"
            str = str & " [OPRATE] [numeric](18, 2) NULL,"
            str = str & " [OPVALUE] [numeric](18, 2) NULL,"
            str = str & " [RCVQTY] [numeric](18, 2) NULL,"
            str = str & " [RCVRATE] [numeric](18, 2) NULL,"
            str = str & " [RCVVALUE] [numeric](18, 2) NULL,"
            str = str & " [VALUEOFRATEREVISION] [numeric](18, 2) NULL,"
            str = str & " [TOTALSTOCKQTY] [numeric](18, 2) NULL,"
            str = str & " [TOTALATOCKVALUE] [numeric](18, 2) NULL,"
            str = str & " [ISSUEQTY] [numeric](18, 2) NULL,"
            str = str & " [ISSUEVALUE] [numeric](18, 2) NULL,"
            str = str & " [BALQTY] [numeric](18, 2) NULL,"
            str = str & " [BALVALUE] [numeric](18, 2) NULL,"
            str = str & " [LOSSDAMAGEQTY] [numeric](18, 2) NULL,"
            str = str & " [PROFITONSOLDQTY] [numeric](18, 2) NULL,"
            str = str & " [CLSQTY] [numeric](18, 3) NULL,"
            str = str & " [CLSVALUE] [numeric](18, 2) NULL,"
            str = str & " [qtyforraterev] [numeric](18, 2) NULL,"
            str = str & " [ISSUERATE] [numeric](18, 2) NULL,"
            str = str & " [LOSSDAMAGERATE] [numeric](18, 2) NULL,"
            str = str & " [LOSSDAMAGEvalue] [numeric](18, 2) NULL,"
            str = str & " [clsrate] [numeric](18, 2) NULL"
            str = str & " )"
            gconnection.dataOperation1(6, str, "item")
        End If

        str = "select * from sysobjects where name='INV_BAR_FINAL_TAB_DETAILED' and xtype='U'"
        gconnection.getDataSet(str, "kot_det")
        If gdataset.Tables("kot_det").Rows.Count > 0 Then
        Else
            str = "CREATE TABLE [dbo].[INV_BAR_FINAL_TAB_DETAILED]("
            str = str & " [DOCDETAILS] [varchar](50) NULL,"
            str = str & " [ITEMCODE] [varchar](50) NULL,"
            str = str & " [ITEMNAME] [varchar](75) NULL,"
            str = str & " [DOCDATE] [datetime] NULL,"
            str = str & " [QTY] [float] NULL,"
            str = str & " [RATE] [float] NULL,"
            str = str & " [AMOUNT] [float] NULL,"
            str = str & " [CLSSTOCK] [numeric](18, 3) NULL,"
            str = str & " [TYPE] [varchar](50) NULL,"
            str = str & " [storecode] [varchar](50) NULL,"
            str = str & " [CATEGORY] [varchar](30) NULL,"
            str = str & " [LASTSTOCK] [numeric](18, 3) NULL,"
            str = str & " [LASTRATE] [numeric](18, 2) NULL,"
            str = str & " [PRIORITY] [int] NOT NULL,"
            str = str & " [ROWID] [int] IDENTITY(1,1) NOT NULL,"
            str = str & " [WEIGHTED_RATE] [numeric](18, 2) NULL"
            str = str & " )"
            gconnection.dataOperation1(6, str, "item")
        End If

        str = "select * from sysobjects where name='inv_bar_tab2_DETAILED' and xtype='U'"
        gconnection.getDataSet(str, "kot_det")
        If gdataset.Tables("kot_det").Rows.Count > 0 Then
        Else
            str = "CREATE TABLE [dbo].[inv_bar_tab2_DETAILED]("
            str = str & " [DOCDETAILS] [varchar](50) NULL,"
            str = str & " [ITEMCODE] [varchar](50) NULL,"
            str = str & " [ITEMNAME] [varchar](75) NULL,"
            str = str & " [DOCDATE] [datetime] NULL,"
            str = str & " [QTY] [float] NULL,"
            str = str & " [RATE] [float] NULL,"
            str = str & " [AMOUNT] [float] NULL,"
            str = str & " [CLSSTOCK] [numeric](18, 3) NULL,"
            str = str & " [TYPE] [varchar](50) NULL,"
            str = str & " [storecode] [varchar](50) NULL,"
            str = str & " [CATEGORY] [varchar](30) NULL,"
            str = str & " [LASTSTOCK] [numeric](18, 3) NULL,"
            str = str & " [LASTRATE] [numeric](18, 2) NULL,"
            str = str & " [PRIORITY] [int] NOT NULL,"
            str = str & " [ROWID] [int] IDENTITY(1,1) NOT NULL,"
            str = str & " [WEIGHTED_RATE] [numeric](18, 2) NULL"
            str = str & " ) "
            gconnection.dataOperation1(6, str, "item")
        End If


        str = "select * from sysobjects where name='view_consolidated_OLD' and xtype='V'"
        gconnection.getDataSet(str, "kot_det")
        If gdataset.Tables("kot_det").Rows.Count > 0 Then
        Else
            str = "CREATE view view_consolidated_OLD              "
            str = str & " as                   "
            str = str & " select isnull(t.itemcode,'') as itemcode,isnull(i.itemname,'') as itemname,isnull(i.saleuom,'') as stockuom,                 "
            str = str & " SUM(isnull(opqty,0)) as opqty,isnull(OPRATE,0) as oprate, SUM(isnull(t.OPVALUE,0)) as opvalue, SUM(isnull(rcvqty,0)) as rcvqty,                 "
            str = str & " SUM(isnull(rcvvalue,0)) as rcvvalue,                   "
            str = str & "  isnull(rcvrate,0) as rcvrate,SUM(isnull(VALUEOFRATEREVISION,0)) as VALUEOFRATEREVISION,sum(isnull(TOTALSTOCKQTY,0))as TOTALSTOCKQTY,sum(isnull(t.opvalue,0)+ isnull(rcvvalue,0)) as totalstockvalue,SUM(isnull(qtyforraterev,0)) as qtyforraterev,            "
            str = str & "  SUM(isnull(t.ISSUEQTY,0)) * -1 as issueqty, SUM(isnull(ISSUEVALUE,0)) as issuevalue,isnull(issuerate,0) as issuerate,          "
            str = str & "  SUM(isnull(balqty,0)) as BALQTY,                  "
            str = str & " sum(isnull(t.opvalue,0)+ isnull(rcvvalue,0)- ISNULL(issuevalue,0)) as BALVALUE,                  "
            str = str & " (sum(ISNULL(t.ISSUEQTY,0)))* round(((isnull(issuerate,0))-((100/(100+(isnull(i.Profitper,0))))*ISNULL(ISSUERATE,0))),2) as profitamt,      "
            str = str & "  sum(isnull(LOSSDAMAGEQTY,0)) as lossdamageqty,SUM(isnull(t.CLSQTY,0)) as clsqty,                   "
            str = str & " sum(ISNULL(CLSQTY,0) * ISNULL(CLSRATE,0)) as BALVALUE1 ,       "
            str = str & " isnull(i.groupcode,'') as groupcode,              "
            str = str & " ISNULL(i.groupname,'') as groupname      "
            str = str & " ,round(((isnull(issuerate,0))-(100/(100+(isnull(i.Profitper,0)))*isnull(issuerate,0))),2) as m,      "
            str = str & " (100/(100+(isnull(i.Profitper,0)))) as n,(sum(isnull(t.CLSQTY,0)) * isnull(t.clsrate,0)) as clsvalclsrate, t.clsrate    "
            str = str & "  from TEMP_CONSOLIDATED_STB t, inventoryitemmaster i where t.ITEMCODE=i.itemcode AND I.STORECODE IN (SELECT STORECODE FROM StoreMaster WHERE Storestatus = 'M')  "
            str = str & "  group by t.ITEMCODE, RCVRATE,OPRATE,i.itemname, i.saleuom, issuerate, groupcode,groupname ,i.Profitper,t.clsrate "
            gconnection.dataOperation1(6, str, "item")
        End If

        str = "select * from sysobjects where name='view_consolidated' and xtype='V'"
        gconnection.getDataSet(str, "kot_det")
        If gdataset.Tables("kot_det").Rows.Count > 0 Then
        Else
            str = "CREATE view [dbo].[view_consolidated]   "
            str = str & "  as                        "
            str = str & "  select distinct isnull(c.itemcode,'') as itemcode,isnull(c.itemname,'') as itemname,isnull(stockuom,'') as stockuom,                     "
            str = str & "  (FLOOR(opqty) + ((((CAST((opqty) AS NUMERIC(18,3)))) -CAST((FLOOR((opqty)))AS NUMERIC(18,3)))/gqty)/100) as opqty,                  "
            str = str & "  isnull(OPRATE,0) as oprate, isnull(opvalue,0) as opvalue,                "
            str = str & "  (FLOOR(rcvqty) + ((((CAST((rcvqty) AS NUMERIC(18,3)))) -CAST((FLOOR((rcvqty)))AS NUMERIC(18,3)))/gqty)/100) as rcvqty,                    "
            str = str & "  (isnull(rcvvalue,0)) as rcvvalue,                       "
            str = str & "  isnull(rcvrate,0) as rcvrate,(isnull(VALUEOFRATEREVISION,0)) as VALUEOFRATEREVISION,                  "
            str = str & "  (FLOOR(TOTALSTOCKQTY) + ((((CAST((TOTALSTOCKQTY) AS NUMERIC(18,3)))) -CAST((FLOOR((TOTALSTOCKQTY)))AS NUMERIC(18,3)))/gqty)/100) as TOTALSTOCKQTY ,                  "
            str = str & "  (isnull(totalstockvalue,0) + isnull(VALUEOFRATEREVISION,0)) as totalstockvalue,                  "
            str = str & "  (isnull(qtyforraterev,0)) as qtyforraterev,                  "
            str = str & "  (FLOOR(issueqty) + ((((CAST((issueqty) AS NUMERIC(18,3)))) -CAST((FLOOR((issueqty)))AS NUMERIC(18,3)))/gqty)/100) as issueqty,                        "
            str = str & "   (isnull(issuevalue,0)) as issuevalue,                  "
            str = str & "   isnull(issuerate,0) as issuerate,                  "
            str = str & "  (FLOOR(balqty) + ((((CAST((balqty) AS NUMERIC(18,3)))) -CAST((FLOOR((balqty)))AS NUMERIC(18,3)))/gqty)/100) as balqty,                  "
            str = str & "  (isnull(BALVALUE,0) - isnull(profitamt,0)) + isnull(VALUEOFRATEREVISION,0) as BALVALUE,                "
            str = str & "  isnull(profitamt,0) * -1 as profitamt,                "
            str = str & "   (FLOOR(lossdamageqty) + ((((CAST((lossdamageqty) AS NUMERIC(18,3)))) -CAST((FLOOR((lossdamageqty)))AS NUMERIC(18,3)))/gqty)/100) as lossdamageqty,                  "
            str = str & "   (FLOOR(clsqty) + ((((CAST((clsqty) AS NUMERIC(18,3)))) -CAST((FLOOR((clsqty)))AS NUMERIC(18,3)))/gqty)/100) as clsqty,                  "
            str = str & "  ISNULL(BALVALUE1,0)  as BALVALUE1,         "
            str = str & "  isnull(groupcode,'') as groupcode,                  "
            str = str & "  ISNULL(groupname,'') as groupname, (ISNULL(issuevalue,0) - (isnull(profitamt,0) * -1)) as wholesaleamount,      "
            str = str & "  clsvalclsrate,clsrate,clsqty as originalclsqty      "
            str = str & "   from view_consolidated_OLD c,                  "
            str = str & "  bom_Det a where a.gitemcode=c.itemcode and a.guom=c.stockuom               "
            gconnection.dataOperation1(6, str, "item")
        End If

        str = "select * from sysobjects where name = 'VIEW_CONSSTB_OPENING' and xtype='V'"
        gconnection.getDataSet(str, "kot_det")
        If gdataset.Tables("kot_det").Rows.Count > 0 Then
        Else
            str = "CREATE VIEW VIEW_CONSSTB_OPENING  "
            str = str & "  AS  "
            str = str & "  SELECT ITEMCODE, ITEMNAME, SUM(QTY) AS OPQTY, SUM(AMOUNT) AS OPVALUE FROM GRN_DETAILS WHERE "
            str = str & "  CAST(CONVERT(VARCHAR(11),GRNDATE,106) AS DATETIME) BETWEEN '26/Mar/2014' AND DateAdd(Day, -1,'10/Apr/2014') AND "
            str = str & "  ISNULL(Voiditem,'')<>'Y' GROUP BY ITEMCODE, ITEMNAME "
            str = str & "             UNION ALL"
            str = str & "  SELECT ITEMCODE, ITEMNAME, SUM(QTY) * -1 AS OPQTY, SUM(AMOUNT) * -1 AS OPVALUE FROM STOCKDMGDETAIL WHERE "
            str = str & "  CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) BETWEEN '26/Mar/2014' AND DateAdd(Day, -1,'10/Apr/2014') "
            str = str & "  AND ISNULL(Void,'')<>'Y'  GROUP BY ITEMCODE, ITEMNAME "
            str = str & "             UNION ALL"
            str = str & "  SELECT ITEMCODE, ITEMNAME, SUM(QTY) * -1 AS OPQTY, SUM(AMOUNT) * -1 AS OPVALUE FROM SUBSTORECONSUMPTIONDETAIL WHERE "
            str = str & "   CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) BETWEEN '26/Mar/2014' AND DateAdd(Day, -1,'10/Apr/2014') "
            str = str & "   AND ISNULL(Void,'')<>'Y'  GROUP BY ITEMCODE, ITEMNAME "
            str = str & "              UNION ALL"
            str = str & "  SELECT ITEMCODE, ITEMNAME, SUM(Adjustedstock) AS OPQTY, SUM(AMOUNT) AS OPVALUE FROM STOCKADJUSTDETAILS WHERE "
            str = str & "  CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) BETWEEN '26/Mar/2014' AND DateAdd(Day, -1,'10/Apr/2014') AND "
            str = str & "  ISNULL(Void,'')<>'Y'  GROUP BY ITEMCODE, ITEMNAME "
            str = str & "              UNION ALL"
            str = str & "   SELECT ITEMCODE, ITEMNAME, SUM(opstock)  AS OPQTY, SUM(opvalue) AS OPVALUE FROM INVENTORYITEMMASTER WHERE "
            str = str & "  ISNULL(Freeze,'')<>'Y' GROUP BY ITEMCODE, ITEMNAME"
            gconnection.dataOperation1(6, str, "item")
        End If

        str = "select * from sysobjects where name='[UPDATE_barRATE_detailed]' and xtype='P'"
        gconnection.getDataSet(str, "kot_det")
        If gdataset.Tables("kot_det").Rows.Count > 0 Then
        Else
            str = "CREATE PROC [dbo].[UPDATE_barRATE_detailed]              "
            str = str & " AS              "
            str = str & " BEGIN()"
            str = str & " DROP TABLE inv_bar_tab2_DETAILED      "

            str = str & " SELECT * INTO inv_bar_tab2_DETAILED FROM INV_BAR_VIEW2_detailed WHERE 1<0   "

            str = str & " ALTER TABLE inv_bar_tab2_DETAILED ADD ROWID INTEGER IDENTITY(1,1)              "

            str = str & " INSERT INTO inv_bar_tab2_DETAILED (DOCDETAILS,ITEMCODE, ITEMNAME, DOCDATE, QTY, RATE, AMOUNT, CLSSTOCK, TYPE, STORECODE, CATEGORY, LASTSTOCK, LASTRATE, PRIORITY)               "
            str = str & " SELECT DOCDETAILS,ITEMCODE, ITEMNAME, CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) AS DOCDATE, QTY, RATE, AMOUNT, CLSSTOCK,           "
            str = str & " TYPE, STORECODE, CATEGORY, LASTSTOCK, LASTRATE, PRIORITY FROM INV_BAR_VIEW2_detailed  ORDER BY            "
            str = str & " ITEMCODE,CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) , PRIORITY , TYPE             "

            str = str & " ALTER TABLE inv_bar_tab2_DETAILED ADD WEIGHTED_RATE NUMERIC(18,2)              "
            str = str & " UPDATE inv_bar_tab2_DETAILED SET WEIGHTED_RATE =0              "

            str = str & " UPDATE inv_bar_tab2_DETAILED SET CLSSTOCK=(SELECT ISNULL(SUM(QTY),0) FROM inv_bar_tab2_DETAILED A WHERE A.ITEMCODE=inv_bar_tab2_DETAILED.ITEMCODE AND A.ROWID<=inv_bar_tab2_DETAILED.ROWID )              "
            str = str & " UPDATE inv_bar_tab2_DETAILED SET LASTSTOCK=(SELECT ISNULL(SUM(QTY),0) FROM inv_bar_tab2_DETAILED A WHERE A.ITEMCODE=inv_bar_tab2_DETAILED.ITEMCODE AND A.ROWID<inv_bar_tab2_DETAILED.ROWID )              "

            str = str & " UPDATE inv_bar_tab2_DETAILED SET LASTRATE=(SELECT TOP 1 ISNULL(RATE,0) AS RATE FROM inv_bar_tab2_DETAILED A               "
            str = str & " WHERE  A.ITEMCODE=inv_bar_tab2_DETAILED.ITEMCODE AND A.ROWID<inv_bar_tab2_DETAILED.ROWID AND A.TYPE IN ('OPENING','GRN') ORDER BY A.ROWID DESC)               "
            str = str & " WHERE TYPE IN ('OPENING','GRN')               "

            str = str & " UPDATE  inv_bar_tab2_DETAILED SET LASTRATE=RATE WHERE TYPE IN ('OPENING','GRN') AND ISNULL(LASTRATE,0)=0              "
            str = str & " UPDATE inv_bar_tab2_DETAILED SET WEIGHTED_RATE = RATE WHERE TYPE='OPENING'              "

            str = str & " DECLARE @ITEMCODE AS VARCHAR(100)              "
            str = str & " DECLARE @ITEMCODE2 AS VARCHAR(100)              "
            str = str & " DECLARE @RATE As NUMERIC(18,2)              "
            str = str & " DECLARE @RATE1 As NUMERIC(18,2)              "
            str = str & " DECLARE @QTY As NUMERIC(18,2)              "
            str = str & " DECLARE @QTY1 As NUMERIC(18,2)              "
            str = str & " DECLARE @CLSSTOCK As NUMERIC(18,2)              "
            str = str & " DECLARE @LSSTOCK As NUMERIC(18,2)              "
            str = str & "  DECLARE @TYPE AS VARCHAR(20)              "
            str = str & "  DECLARE @ROWID AS INTEGER              "
            str = str & "  SET @QTY = 0              "
            str = str & " SET        @RATE = 0              "
            str = str & "  DECLARE VCUR CURSOR  for Select ITEMCODE,RATE,QTY,CLSSTOCK,LASTSTOCK,TYPE,ROWID FROM inv_bar_tab2_DETAILED WHERE STORECODE IN('MNS1','BAR','BVI') ORDER BY ROWID              "
            str = str & "  Open vCur"
            str = str & "  Fetch vCur into @ITEMCODE2,@RATE1,@QTY1,@CLSSTOCK,@LSSTOCK,@TYPE,@ROWID              "
            str = str & "  While @@Fetch_Status=0              "
            str = str & " Begin()"

            str = str & "  If @ITEMCODE <> @ITEMCODE2               "
            str = str & " BEGIN()"
            str = str & "   SET @QTY = 0              "
            str = str & "    SET @RATE = 0              "
            str = str & "  SET @ITEMCODE = @ITEMCODE2              "

            str = str & "   SET @QTY = @QTY+ @QTY1              "
            str = str & "   If @TYPE = 'OPENING' OR @TYPE = 'GRN'               "
            str = str & " BEGIN()"
            str = str & "   SET @RATE = @RATE1            "
            str = str & " UPDATE    inv_bar_tab2_DETAILED SET WEIGHTED_RATE = @RATE WHERE ROWID=@ROWID                           "
            str = str & " End"
            str = str & "  End"
            str = str & "  BEGIN                                  SET @QTY = @QTY+ @QTY1              "
            str = str & "   If @TYPE = 'OPENING' OR @TYPE = 'GRN'               "
            str = str & " BEGIN()"
            str = str & "  SET @RATE = @RATE1            "
            str = str & "   UPDATE    inv_bar_tab2_DETAILED SET WEIGHTED_RATE = @RATE WHERE ROWID=@ROWID                           "
            str = str & "  End"
            str = str & " End"
            str = str & "   Fetch vCur into @ITEMCODE2,@RATE1,@QTY1,@CLSSTOCK,@LSSTOCK,@TYPE,@ROWID              "
            str = str & "  End"
            str = str & " Close(vCur)"
            str = str & "  Deallocate vCur"
            str = str & "  End"

            str = str & " DELETE FROM INV_BAR_FINAL_TAB_DETAILED         "

            str = str & " INSERT INTO INV_BAR_FINAL_TAB_DETAILED (DOCDETAILS,ITEMCODE,ITEMNAME,DOCDATE,QTY,RATE,AMOUNT,CLSSTOCK,TYPE,STORECODE,CATEGORY,          "
            str = str & "  LASTSTOCK,LASTRATE,WEIGHTED_RATE, PRIORITY)            "
            str = str & "  SELECT DOCDETAILS,ITEMCODE,ITEMNAME,DOCDATE,QTY,RATE,AMOUNT,CLSSTOCK,TYPE,STORECODE,CATEGORY,          "
            str = str & " LASTSTOCK,LASTRATE,WEIGHTED_RATE, PRIORITY FROM inv_bar_tab2_DETAILED "
            gconnection.dataOperation1(6, str, "item")
        End If

        str = "select * from sysobjects where name='inv_bar_tab2' and xtype='U'"
        gconnection.getDataSet(str, "kot_det")
        If gdataset.Tables("kot_Det").Rows.Count > 0 Then
        Else
            str = "CREATE TABLE [dbo].[inv_bar_tab2]("
            str = str & " [DOCDETAILS] [varchar](50) NULL,"
            str = str & " [ITEMCODE] [varchar](50) NULL,"
            str = str & " [ITEMNAME] [varchar](50) NULL,"
            str = str & " [DOCDATE] [datetime] NULL,"
            str = str & " [QTY] [float] NULL,"
            str = str & " [RATE] [float] NULL,"
            str = str & " [AMOUNT] [float] NULL,"
            str = str & " [CLSSTOCK] [numeric](18, 3) NULL,"
            str = str & " [TYPE] [varchar](50) NULL,"
            str = str & " [storecode] [varchar](50) NULL,"
            str = str & " [CATEGORY] [varchar](30) NULL,"
            str = str & " [LASTSTOCK] [numeric](18, 3) NULL,"
            str = str & " [LASTRATE] [numeric](18, 2) NULL,"
            str = str & " [PRIORITY] [int] NOT NULL,"
            str = str & " [ROWID] [int] IDENTITY(1,1) NOT NULL,"
            str = str & " [WEIGHTED_RATE] [numeric](18, 2) NULL"
            str = str & " )"
            gconnection.dataOperation1(6, str, "item")
        End If

        str = "select * from sysobjects  where xtype='V' and name='INV_BAR_VIEW2'"
        gconnection.getDataSet(str, "kot_det")
        If gdataset.Tables("kot_Det").Rows.Count > 0 Then
        Else
            str = "CREATE VIEW [dbo].[INV_BAR_VIEW2]              "
            str = str & " AS              "
            str = str & " SELECT '' AS DOCDETAILS,ITEMCODE, ITEMNAME, '26-MAR-2014' AS DOCDATE, OPSTOCK AS QTY,ROUND((ISNULL(opvalue,0)/ISNULL(OPSTOCK,0)),2) AS RATE,             "
            str = str & " OPVALUE AS AMOUNT,0.000 AS CLSSTOCK, 'OPENING' AS TYPE, storecode,CATEGORY , CAST(0.000 AS NUMERIC(18,3)) AS LASTSTOCK,            "
            str = str & " CAST(0.00 AS NUMERIC(18,2)) AS LASTRATE, 1 AS PRIORITY  FROM INVENTORYITEMMASTER WHERE ISNULL(FREEZE,'')<>'Y' AND             "
            str = str & " ISNULL(OPSTOCK,0)<>0 OR ISNULL(OPVALUE,0)<>0    "
            str = str & "             UNION ALL"
            str = str & " SELECT '' AS DOCDETAILS,ITEMCODE, ITEMNAME, '26-MAR-2014' AS DOCDATE, OPSTOCK AS QTY,0 AS RATE, 0 AS AMOUNT,CAST(0.000 AS NUMERIC(18,3)) AS             "
            str = str & " CLSSTOCK, 'OPENING' AS TYPE, storecode,CATEGORY , CAST(0.000 AS NUMERIC(18,3)) AS LASTSTOCK, CAST(0.00 AS NUMERIC(18,2)) AS            "
            str = str & " LASTRATE, 1 AS PRIORITY FROM INVENTORYITEMMASTER WHERE ISNULL(FREEZE,'')<>'Y' AND ISNULL(OPSTOCK,0)=0 AND ISNULL(OPVALUE,0)=0             "

            str = str & " UNION ALL"
            str = str & " SELECT GRNDETAILS AS DOCDETAILS,ITEMCODE, ITEMNAME, Grndate AS DOCDATE, QTY, RATE, AMOUNT,CAST(0.000 AS NUMERIC(18,3)) AS CLSSTOCK, grntype AS TYPE,             "
            str = str & " storecode, CATEGORY, CAST(0.000 AS NUMERIC(18,3)) AS LASTSTOCK, CAST(0.00 AS NUMERIC(18,2)) AS LASTRATE, 2 AS PRIORITY FROM             "
            str = str & " GRN_DETAILS WHERE ISNULL(Voiditem,'')<>'Y'   "

            str = str & "             UNION ALL"
            str = str & " SELECT DOCDETAILS,S.ITEMCODE, S.ITEMNAME, DOCDATE, Qty * -1 AS QTY,Rate, AMOUNT, CAST(0.000 AS NUMERIC(18,3)) AS CLSSTOCK,             "
            str = str & "                 'CONSUMPTION' AS TYPE, Storelocationcode AS STORECODE, CATEGORY, CAST(0.000 AS NUMERIC(18,3)) AS LASTSTOCK, CAST(0.00 AS             "
            str = str & " NUMERIC(18,2)) AS LASTRATE , 3 AS PRIORITY FROM SUBSTORECONSUMPTIONDETAIL S, INVENTORYITEMMASTER I   WHERE ISNULL(VOID,'')<>'Y'              "
            str = str & " AND I.itemcode=S.ITEMCODE AND I.STORECODE=S.Storelocationcode   "
            str = str & "             UNION ALL"
            str = str & " SELECT DOCDETAILS,S.ITEMCODE, S.ITEMNAME, DOCDATE, ADJUSTEDSTOCK AS QTY , Rate, AMOUNT, CAST(0.000 AS NUMERIC(18,3)) AS CLSSTOCK,             "
            str = str & " 'ADJUSTMENT' AS TYPE, STORELOCATIONCODE AS STORECODE , CATEGORY, CAST(0.000 AS NUMERIC(18,3)) AS LASTSTOCK,             "
            str = str & " CAST(0.00 AS NUMERIC(18,2)) AS LASTRATE , 3 AS PRIORITY  FROM STOCKADJUSTDETAILS  S, INVENTORYITEMMASTER I             "
            str = str & "  WHERE ISNULL(Void,'') <>'Y' AND ADJUSTEDSTOCK < 0  AND I.itemcode=S.ITEMCODE AND I.STORECODE=S.Storelocationcode   "
            str = str & "             UNION ALL"
            str = str & " SELECT DOCDETAILS,S.ITEMCODE, S.ITEMCODE, DOCDATE, QTY * -1, Rate, AMOUNT , CAST(0.000 AS NUMERIC(18,3)) AS CLSSTOCK,             "
            str = str & " 'DAMAGE'  AS TYPE, S.STORECODE , CATEGORY, CAST(0.000 AS NUMERIC(18,3)) AS LASTSTOCK, CAST(0.00 AS NUMERIC(18,2)) AS LASTRATE,             "
            str = str & " 3 AS PRIORITY   FROM STOCKDMGDETAIL  S, INVENTORYITEMMASTER I  WHERE ISNULL(Void,'')<>'Y'  AND I.itemcode=S.ITEMCODE             "
            str = str & " AND I.STORECODE=S.storecode "
            gconnection.dataOperation1(6, str, "item")
        End If

        str = "select * from sysobjects where name='UPDATE_barRATE' and xtype='P'"
        gconnection.getDataSet(str, "kot_det")
        If gdataset.Tables("kot_det").Rows.Count > 0 Then
        Else
            str = "CREATE PROC [dbo].[UPDATE_barRATE]                "
            str = str & " AS                "
            str = str & "   BEGIN()"
            str = str & " DROP TABLE inv_bar_tab2                "

            str = str & " SELECT * INTO inv_bar_tab2 FROM inv_bar_view2 WHERE 1<0   "

            str = str & " ALTER TABLE inv_bar_tab2 ADD ROWID INTEGER IDENTITY(1,1)                "

            str = str & " INSERT INTO inv_bar_tab2 (DOCDETAILS,ITEMCODE, ITEMNAME, DOCDATE, QTY, RATE, AMOUNT, CLSSTOCK, TYPE, STORECODE, CATEGORY, LASTSTOCK, LASTRATE, PRIORITY)                 "
            str = str & " SELECT DOCDETAILS,ITEMCODE, ITEMNAME, CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) AS DOCDATE, QTY, RATE, AMOUNT, CLSSTOCK,             "
            str = str & " TYPE, STORECODE, CATEGORY, LASTSTOCK, LASTRATE, PRIORITY FROM inv_bar_view2  ORDER BY              "
            str = str & "  ITEMCODE,CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) , PRIORITY                "

            str = str & " ALTER TABLE inv_bar_tab2 ADD WEIGHTED_RATE NUMERIC(18,2)                "
            str = str & " UPDATE inv_bar_tab2 SET WEIGHTED_RATE =0                "

            str = str & "  UPDATE inv_bar_tab2 SET CLSSTOCK=(SELECT SUM(QTY) FROM inv_bar_tab2 A WHERE A.ITEMCODE=inv_bar_tab2.ITEMCODE AND A.ROWID<=inv_bar_tab2.ROWID )                "
            str = str & " UPDATE inv_bar_tab2 SET LASTSTOCK=(SELECT ISNULL(SUM(QTY),0) FROM inv_bar_tab2 A WHERE A.ITEMCODE=inv_bar_tab2.ITEMCODE AND A.ROWID<inv_bar_tab2.ROWID )                "

            str = str & " UPDATE inv_bar_tab2 SET LASTRATE=(SELECT TOP 1 ISNULL(RATE,0) AS RATE FROM inv_bar_tab2 A                 "
            str = str & "  WHERE  A.ITEMCODE=inv_bar_tab2.ITEMCODE AND A.ROWID<inv_bar_tab2.ROWID AND A.TYPE IN ('OPENING','GRN') ORDER BY A.ROWID DESC)                 "
            str = str & "  WHERE TYPE IN ('OPENING','GRN')                 "

            str = str & " UPDATE  inv_bar_tab2 SET LASTRATE=RATE WHERE TYPE IN ('OPENING','GRN') AND ISNULL(LASTRATE,0)=0                "
            str = str & " UPDATE inv_bar_tab2 SET WEIGHTED_RATE = RATE WHERE TYPE='OPENING'                "
            str = str & "  DECLARE @ITEMCODE AS VARCHAR(100)                "
            str = str & "  DECLARE @ITEMCODE2 AS VARCHAR(100)                "
            str = str & "  DECLARE @RATE As NUMERIC(18,2)                "
            str = str & "  DECLARE @RATE1 As NUMERIC(18,2)                "
            str = str & "  DECLARE @QTY As NUMERIC(18,2)                "
            str = str & "  DECLARE @QTY1 As NUMERIC(18,2)                "
            str = str & "  DECLARE @CLSSTOCK As NUMERIC(18,2)                "
            str = str & "  DECLARE @LSSTOCK As NUMERIC(18,2)                "
            str = str & "   DECLARE @TYPE AS VARCHAR(20)                "
            str = str & "   DECLARE @ROWID AS INTEGER                "
            str = str & "   SET @QTY = 0                "
            str = str & " SET        @RATE = 0                "
            str = str & "  DECLARE VCUR CURSOR  for Select ITEMCODE,RATE,QTY,CLSSTOCK,LASTSTOCK,TYPE,ROWID FROM inv_bar_tab2 WHERE STORECODE IN('MNS1','BAR','BVI') ORDER BY ROWID                "
            str = str & "   Open vCur"
            str = str & "   Fetch vCur into @ITEMCODE2,@RATE1,@QTY1,@CLSSTOCK,@LSSTOCK,@TYPE,@ROWID                "
            str = str & "  While @@Fetch_Status=0                "
            str = str & " Begin()"
            str = str & "  If @ITEMCODE <> @ITEMCODE2                 "
            str = str & "  BEGIN()"
            str = str & "                SET @QTY = 0                "
            str = str & "                 SET @RATE = 0                "
            str = str & "               SET @ITEMCODE = @ITEMCODE2                "

            str = str & "               SET @QTY = @QTY+ @QTY1                "
            str = str & "                If @TYPE = 'OPENING' OR @TYPE = 'GRN'                 "
            str = str & " BEGIN()"
            str = str & "                        SET @RATE = @RATE1              "
            str = str & "                         UPDATE    inv_bar_tab2 SET WEIGHTED_RATE = @RATE WHERE ROWID=@ROWID                             "
            str = str & " End"

            str = str & "  End"
            str = str & "  BEGIN()"
            str = str & "                 SET @QTY = @QTY+ @QTY1                "
            str = str & "                 If @TYPE = 'OPENING' OR @TYPE = 'GRN'                 "
            str = str & " BEGIN()"
            str = str & "                   SET @RATE = @RATE1              "
            str = str & "                      UPDATE    inv_bar_tab2 SET WEIGHTED_RATE = @RATE WHERE ROWID=@ROWID                             "
            str = str & "  End"
            str = str & "  End"
            str = str & "                 Fetch vCur into @ITEMCODE2,@RATE1,@QTY1,@CLSSTOCK,@LSSTOCK,@TYPE,@ROWID                "
            str = str & "  End"
            str = str & "  Close(vCur)"
            str = str & "  Deallocate vCur"
            str = str & "  End"
            str = str & " DELETE FROM INV_BAR_FINAL_TAB            "

            str = str & " INSERT INTO INV_BAR_FINAL_TAB (DOCDETAILS,ITEMCODE,ITEMNAME,DOCDATE,QTY,RATE,AMOUNT,CLSSTOCK,TYPE,STORECODE,CATEGORY,            "
            str = str & " LASTSTOCK,LASTRATE,WEIGHTED_RATE)              "
            str = str & " SELECT DOCDETAILS,ITEMCODE,ITEMNAME,DOCDATE,QTY,RATE,AMOUNT,CLSSTOCK,TYPE,STORECODE,CATEGORY,            "
            str = str & " LASTSTOCK,LASTRATE,WEIGHTED_RATE FROM inv_bar_tab2            "
            gconnection.dataOperation1(6, str, "item")

            str = "alter table TempMonthSTBrsi add GroupCode varchar(20) null"
            gconnection.dataOperation1(6, str, "item")

            str = "alter table TempMonthSTBrsi add GroupName varchar(20) null"
            gconnection.dataOperation1(6, str, "item")

            str = "alter table MonthSTBrsi add GroupCode varchar(20) null"
            gconnection.dataOperation1(6, str, "item")
            str = "alter table MonthSTBrsi add GroupName varchar(20) null"
            gconnection.dataOperation1(6, str, "item")

        End If
        str = "SELECT * FROM SYSOBJECTS WHERE name='View_DayWiseOpening' AND XTYPE='V'"
        gconnection.getDataSet(str, "View_DayWiseOpening")
        If gdataset.Tables("View_DayWiseOpening").Rows.Count > 0 Then

        Else
            str = " CREATE VIEW [dbo].[View_DayWiseOpening]  "
            str = str & " AS  "
            '--INVENTORY OPENING BALANCE
            str = str & " SELECT ITEMCODE, ITEMNAME,SUM(ISNULL(opstock,0)) AS OPSTOCK,SUM(ISNULL(OPVALUE,0)) AS OPVALUE,'OPENING' AS TYPE  "
            str = str & " FROM INVENTORYITEMMASTER WHERE ISNULL(Freeze,'')<>'Y' AND STORECODE IN ('') GROUP BY itemcode, itemname "
            str = str & " UNION ALL"
            '--GRN
            str = str & " SELECT ITEMCODE, ITEMNAME, SUM(ISNULL(Qty,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT,'OPENING' AS TYPE FROM "
            str = str & " GRN_DETAILS WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) "
            str = str & "   BETWEEN '01/04/2014' AND DateAdd(Day, -1, '04/01/2014') AND ISNULL(grntype,'')='GRN' "
            str = str & " AND STORECODE IN ('') GROUP BY itemcode, itemname "
            str = str & "   UNION ALL"
            '--PRN
            str = str & " SELECT ITEMCODE, ITEMNAME, (SUM(ISNULL(Qty,0))  * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT,'OPENING' AS TYPE "
            str = str & " FROM GRN_DETAILS WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) "
            str = str & "   BETWEEN '01/04/2014' AND DateAdd(Day, -1, '04/01/2014') AND ISNULL(grntype,'')='PRN' "
            str = str & " AND STORECODE IN ('') GROUP BY itemcode, itemname "
            str = str & "   UNION ALL"
            '--ADJUSTMENT
            str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(ADJUSTEDSTOCK,0)) * -1) AS ADJUSTEDSTOCK, (SUM(ISNULL(Amount,0)) * -1) AS AMOUNT,"
            str = str & " 'OPENING' AS TYPE FROM STOCKADJUSTDETAILS WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & " BETWEEN '01/04/2014' AND DateAdd(Day, -1, '04/01/2014') AND Storelocationcode IN ('')"
            str = str & " GROUP BY itemcode, itemname "
            str = str & "   UNION ALL"
            '--DAMAGE
            str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(QTY,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT,'OPENING' AS TYPE "
            str = str & " FROM STOCKDMGDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN "
            str = str & "   '01/04/2014' AND DateAdd(Day, -1, '04/01/2014')  AND FROMStorecode IN ('') "
            str = str & " GROUP BY itemcode, itemname "
            str = str & "   UNION ALL"
            '--POS CONSUMPTION
            str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(QTY,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT,'OPENING' AS TYPE "
            str = str & " FROM SUBSTORECONSUMPTIONDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & " BETWEEN '01/04/2014' AND DateAdd(Day, -1, '04/01/2014') GROUP BY itemcode, itemname"
            str = str & " UNION ALL"
            '--STOCK ISSUE(-)
            str = str & " SELECT Itemcode, Itemname,(SUM(ISNULL(QTY,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT, 'OPENING' AS TYPE "
            str = str & "  FROM STOCKISSUEDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & "   BETWEEN '01/04/2014' AND DateAdd(Day, -1, '04/01/2014') AND Storelocationcode IN ('') GROUP BY itemcode, itemname"
            str = str & " UNION ALL"
            '--STOCK ISSUE(+)
            str = str & " SELECT Itemcode, Itemname,SUM(ISNULL(QTY,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT, 'OPENING' AS TYPE "
            str = str & " FROM STOCKISSUEDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & "  BETWEEN '01/04/2014' AND DateAdd(Day, -1, '04/01/2014') AND Opstorelocationcode IN ('') GROUP BY itemcode, itemname"
            str = str & " UNION ALL"
            '--STOCK TRANSFER (-)
            str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(Qty,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT, 'OPENING' AS TYPE"
            str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & " BETWEEN '01/04/2014' AND DateAdd(Day, -1, '04/01/2014') AND Fromstorecode IN ('') GROUP BY itemcode, itemname"
            str = str & " UNION ALL"
            '--STOCK TRANSFER (+)
            str = str & " SELECT Itemcode, Itemname, SUM(ISNULL(Qty,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT, 'OPENING' AS TYPE"
            str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & " BETWEEN '01/04/2014' AND DateAdd(Day, -1, '04/01/2014') AND Fromstorecode IN ('') GROUP BY itemcode, itemname"
            gconnection.dataOperation1(6, str, "item")
        End If
        str = "SELECT * FROM SYSOBJECTS WHERE name='View_DayWiseReceive' AND XTYPE='V'"
        gconnection.getDataSet(str, "View_DayWiseReceive")
        If gdataset.Tables("View_DayWiseReceive").Rows.Count > 0 Then

        Else
            str = " CREATE VIEW View_DayWiseReceive"
            str = str & " as"
            str = str & " SELECT Itemcode, Itemname, SUM(ISNULL(QTY,0)) AS QTY, SUM(ISNULL(Amount,0)) AS AMOUNT FROM GRN_DETAILS"
            str = str & " WHERE ISNULL(Voiditem,'')<>'Y' AND storecode IN ('') AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) "
            str = str & " BETWEEN '' AND '' GROUP BY Itemcode, Itemname"
            str = str & " UNION ALL"
            str = str & " SELECT Itemcode, Itemname, SUM(ISNULL(QTY,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT FROM STOCKISSUEDETAIL"
            str = str & " WHERE ISNULL(Void,'')<>'Y' AND Opstorelocationcode IN ('') AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & " BETWEEN '' AND '' GROUP BY Itemcode, Itemname"
            str = str & " UNION ALL"
            str = str & " SELECT Itemcode, Itemname, SUM(ISNULL(QTY,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT FROM STOCKTRANSFERDETAIL"
            str = str & " WHERE ISNULL(Void,'')<>'Y' AND Tostorecode IN ('') AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & " BETWEEN '' AND '' GROUP BY Itemcode, Itemname"
            gconnection.dataOperation1(6, str, "item")
        End If
        str = "SELECT * FROM SYSOBJECTS WHERE name='DAY_STOCK_SUM' AND XTYPE='V'"
        gconnection.getDataSet(str, "View_DayWiseReceive")
        If gdataset.Tables("View_DayWiseReceive").Rows.Count > 0 Then

        Else
            str = "CREATE VIEW [dbo].[DAY_STOCK_SUM]        "
            str = str & " AS        "
            str = str & " SELECT docdetails, docdate, Itemcode, Itemname, ISNULL(Qty,0) AS QTY, ISNULL(Rate,0) AS RATE, ISNULL(Amount,0) AS AMOUNT "
            str = str & " FROM SUBSTORECONSUMPTIONDETAIL WHERE ISNULL(Void,'')<>'Y' "
            gconnection.dataOperation1(6, str, "item")
        End If


        str = "SELECT * FROM SYSOBJECTS WHERE name = 'DAYWISE_STOCK_SUMMARY' AND XTYPE='U'"
        gconnection.getDataSet(str, "DAYWISE_STOCK_SUMMARY")
        If gdataset.Tables("DAYWISE_STOCK_SUMMARY").Rows.Count > 0 Then
        Else

            str = "CREATE TABLE [dbo].[DAYWISE_STOCK_SUMMARY]("
            str = str & " [SNO] [int] IDENTITY(1,1) NOT NULL,"
            str = str & " [ITEMCODE] [varchar](30) NULL,"
            str = str & " [ITEMNAME] [varchar](50) NULL,"
            str = str & " [DAY1] [numeric](6, 2) NULL,"
            str = str & " [DAY2] [numeric](6, 2) NULL,"
            str = str & " [DAY3] [numeric](6, 2) NULL,"
            str = str & " [DAY4] [numeric](6, 2) NULL,"
            str = str & " [DAY5] [numeric](6, 2) NULL,"
            str = str & " [DAY6] [numeric](6, 2) NULL,"
            str = str & " [DAY7] [numeric](6, 2) NULL,"
            str = str & " [DAY8] [numeric](6, 2) NULL,"
            str = str & " [DAY9] [numeric](6, 2) NULL,"
            str = str & " [DAY10] [numeric](6, 2) NULL,"
            str = str & " [DAY11] [numeric](6, 2) NULL,"
            str = str & " [DAY12] [numeric](6, 2) NULL,"
            str = str & " [DAY13] [numeric](6, 2) NULL,"
            str = str & " [DAY14] [numeric](6, 2) NULL,"
            str = str & " [DAY15] [numeric](6, 2) NULL,"
            str = str & " [DAY16] [numeric](6, 2) NULL,"
            str = str & " [DAY17] [numeric](6, 2) NULL,"
            str = str & " [DAY18] [numeric](6, 2) NULL,"
            str = str & " [DAY19] [numeric](6, 2) NULL,"
            str = str & " [DAY20] [numeric](6, 2) NULL,"
            str = str & " [DAY21] [numeric](6, 2) NULL,"
            str = str & " [DAY22] [numeric](6, 2) NULL,"
            str = str & " [DAY23] [numeric](6, 2) NULL,"
            str = str & " [DAY24] [numeric](6, 2) NULL,"
            str = str & " [DAY25] [numeric](6, 2) NULL,"
            str = str & " [DAY26] [numeric](6, 2) NULL,"
            str = str & " [DAY27] [numeric](6, 2) NULL,"
            str = str & " [DAY28] [numeric](6, 2) NULL,"
            str = str & " [DAY29] [numeric](6, 2) NULL,"
            str = str & " [DAY30] [numeric](6, 2) NULL,"
            str = str & " [DAY31] [numeric](6, 2) NULL,"
            str = str & " [DAYTOTAL] [numeric](10, 2) NULL,"
            str = str & " [RATE] [numeric](6, 2) NULL,"
            str = str & " [AMOUNT] [numeric](16, 2) NULL,"
            str = str & " [OPSTOCK] [numeric](6, 2) NULL,"
            str = str & " [STOCKISSUE] [numeric](6, 2) NULL,"
            str = str & " [STOCKTFR] [numeric](6, 2) NULL,"
            str = str & " [STOCKTOTAL] [numeric](6, 2) NULL,"
            str = str & " [STOCKBAL] [numeric](6, 2) NULL"
            str = str & " )"
            gconnection.dataOperation1(6, str, "item")

        End If
        str = "SELECT * FROM SYSOBJECTS WHERE name = 'daywise_stock' AND XTYPE='P'"
        gconnection.getDataSet(str, "daywise_stock")
        If gdataset.Tables("daywise_stock").Rows.Count > 0 Then
            str = " alter procedure [dbo].[daywise_stock] (@FROMDATE AS datetime, @TODATE AS datetime) "
            str = str & " as              "
            str = str & " begin"
            str = str & "  DECLARE @SQLSTATE VARCHAR(2000) "
            str = str & " declare @itemcode varchar(30);"
            str = str & " declare @dt date "
            str = str & " truncate table daywise_stock_summary"
            str = str & " Print 'trunc'              "
            str = str & " insert into daywise_stock_summary(Itemcode,ItemName)              "
            str = str & " select distinct itemcode,itemname  from INVENTORYITEMMASTER WHERE ISNULL(Freeze,'')<>'Y' order by itemcode          "
            str = str & " Print 'insert'"
            str = str & " declare @count integer=(select COUNT(*) from daywise_stock_summary)             "
            str = str & " declare @j integer=1  "
            str = str & "  Print '@count'  "

            str = str & " declare @k as integer=1"

            str = str & " set @dt=@fromdate             "
            str = str & " while(@dt<=@todate)             "
            str = str & " begin set @k=Day(@dt)         "
            str = str & " "
            str = str & " declare @var varchar(50)='Day'+convert(varchar(2),@k)             "
            str = str & " print @var             "
            str = str & " set @sqlstate ='update daywise_stock_summary set '+ @var +' = d.qty from daywise_stock_summary, DAY_STOCK_SUM1 D where  cast(convert(varchar(11),D.docdate,106) as datetime) = '''+ Convert(varchar(11),@dt)+''' and daywise_stock_summary.ITEMCODE = D.ITEMCODE'"
            str = str & " print @sqlstate             "
            str = str & " exec(@sqlstate)             "
            str = str & " set @dt=Dateadd(DD,1,@dt)                       "
            str = str & " End set @j=@j+1                        "
            str = str & " End"
            str = str & " "
            gconnection.dataOperation1(6, str, "item")
        Else
            str = " CREATE procedure [dbo].[daywise_stock] (@FROMDATE AS datetime, @TODATE AS datetime)"
            str = str & " as            "
            str = str & "  begin"

            str = str & " Delete  from daywise_stock_summary            "
            str = str & "  insert into daywise_stock_summary(Itemcode,ItemName)            "
            str = str & "  select distinct itemcode,itemname   from INVENTORYITEMMASTER WHERE ISNULL(Freeze,'')<>'Y' order by itemcode         "
            str = str & " declare @count integer=(select COUNT(*) from daywise_stock_summary)            "
            str = str & " declare @j integer=1  "
            str = str & " while(@j < @count+1)            "
            str = str & " begin"
            str = str & " declare @k integer=0            "
            str = str & " declare @dt date            "
            str = str & " set @dt=@fromdate            "
            str = str & " while(@dt<=@todate)            "

            str = str & " begin"
            str = str & " set @k=Day(@dt)            "
            str = str & " declare @itemcode varchar(50);            "
            str = str & " with abc as            "
            str = str & " (            "
            str = str & " select itemCode,(ROW_NUMBER() over (order by ItemCode )) As rn from daywise_stock_summary             "
            str = str & "  )            "
            str = str & "  select @itemcode= abc.itemCode from abc where rn=@j            "
            str = str & " print @itemcode            "
            str = str & " declare @var varchar(5)='Day'+convert(varchar(2),@k)            "
            str = str & " print @var            "
            str = str & " declare @opbal1 numeric(18,2)=0            "
            str = str & " declare @opbal2 numeric(18,2)=0            "
            str = str & " declare @total numeric(18,2)=0            "

            str = str & " select @opbal2=Isnull(SUM(Qty),0) from DAY_STOCK_SUM where ITEMCODE=@itemcode "
            str = str & " group by CAST(docdate AS DATE) having  CAST(docdate AS DATE)=@dt            "
            str = str & "  print @opbal2            "
            str = str & " declare @sqlstate  varchar(2000)            "

            str = str & " set @total = @opbal2    "
            str = str & " print @total            "
            str = str & " set @sqlstate =' update daywise_stock_summary set '+ @var + '=' + Convert(varchar(50),@total)+ ' where ItemCode=' + char(39)+@itemcode+CHAR(39)            "
            str = str & " print @sqlstate            "
            str = str & " exec(@sqlstate)            "
            str = str & " set @dt=Dateadd(DD,1,@dt)            "

            str = str & "           End"
            str = str & " set @j=@j+1            "
            str = str & "            End"
            str = str & "            End"
            gconnection.dataOperation1(6, str, "item")
        End If
        str = "SELECT * FROM SYSOBJECTS WHERE name = 'TempTblDayWiseStock' AND XTYPE='U'"
        gconnection.getDataSet(str, "daywise_stock")
        If gdataset.Tables("daywise_stock").Rows.Count > 0 Then

        Else
            str = "create table TempTblDayWiseStock "
            str = str & "( "
            str = str & "itemcode varchar(20) null,"
            str = str & "itemname varchar(50) null,"
            str = str & " opqty numeric(18,2) null,"
            str = str & "opvalue numeric(18,2) null, "
            str = str & "rcvqty numeric(18,2) null,"
            str = str & "rcvvalue numeric(18,2) null"
            str = str & ")"
            gconnection.dataOperation1(6, str, "item")
        End If

        str = "SELECT * FROM SYSOBJECTS WHERE name = 'VIEW_DAYWISE_STOCK' AND XTYPE='V'"
        gconnection.getDataSet(str, "daywise_stock")
        If gdataset.Tables("daywise_stock").Rows.Count > 0 Then

        Else
            str = "CREATE VIEW [dbo].[VIEW_DAYWISE_STOCK]            "
            str = str & " AS            "
            str = str & " SELECT T.ITEMCODE, T.ITEMNAME, T.OPQTY, T.OPVALUE,T.RCVQTY, T.RCVVALUE, "
            str = str & " ISNULL(D.DAY1,0) AS D1, ISNULL(D.DAY2,0) AS D2, ISNULL(D.DAY3,0) AS D3, ISNULL(D.DAY4,0) AS D4, ISNULL(D.DAY5,0) AS D5, "
            str = str & " ISNULL(D.DAY6,0) AS D6, ISNULL(D.DAY7,0) AS D7,ISNULL(D.DAY8,0) AS D8, ISNULL(D.DAY9,0) AS D9, ISNULL(D.DAY10,0) AS D10, "
            str = str & " ISNULL(D.DAY11,0) AS D11, ISNULL(D.DAY12,0) AS D12, ISNULL(D.DAY13,0) AS D13, ISNULL(D.DAY14,0) AS D14, ISNULL(D.DAY15,0) AS D15,"
            str = str & " ISNULL(D.DAY16,0) AS D16, ISNULL(D.DAY17,0) AS D17, ISNULL(D.DAY18,0) AS D18, ISNULL(D.DAY19,0) AS D19, ISNULL(D.DAY20,0) AS D20,"
            str = str & " ISNULL(D.DAY21,0) AS D21, ISNULL(D.DAY22,0) AS D22, ISNULL(D.DAY23,0) AS D23, ISNULL(D.DAY24,0) AS D24, ISNULL(D.DAY25,0) AS D25,"
            str = str & " ISNULL(D.DAY26,0) AS D26, ISNULL(D.DAY27,0) AS D27, ISNULL(D.DAY28,0) AS D28,ISNULL(D.DAY29,0) AS D29, ISNULL(D.DAY30,0) AS D30, ISNULL(D.DAY31,0) AS D31,"
            '--TOTALSTOCK
            str = str & " (ISNULL(D.DAY1,0)+ ISNULL(D.DAY2,0)+ ISNULL(D.DAY3,0)+ ISNULL(D.DAY4,0) + ISNULL(D.DAY5,0)+"
            str = str & " ISNULL(D.DAY6,0) + ISNULL(D.DAY7,0) + ISNULL(D.DAY8,0) + ISNULL(D.DAY9,0) + ISNULL(D.DAY10,0) + "
            str = str & " ISNULL(D.DAY11,0) + ISNULL(D.DAY12,0) + ISNULL(D.DAY13,0) + ISNULL(D.DAY14,0) + ISNULL(D.DAY15,0) +"
            str = str & " ISNULL(D.DAY16,0) + ISNULL(D.DAY17,0) + ISNULL(D.DAY18,0) + ISNULL(D.DAY19,0) + ISNULL(D.DAY20,0) +"
            str = str & " ISNULL(D.DAY21,0) + ISNULL(D.DAY22,0) + ISNULL(D.DAY23,0) + ISNULL(D.DAY24,0) + ISNULL(D.DAY25,0) +"
            str = str & " ISNULL(D.DAY26,0) + ISNULL(D.DAY27,0) + ISNULL(D.DAY28,0) + ISNULL(D.DAY29,0)+ ISNULL(D.DAY30,0) + ISNULL(D.DAY31,0) ) AS TOTALSTOCK,"
            '--BALANCE
            str = str & " ((T.OPQTY + T.RCVQTY)-( ISNULL(D.DAY1,0)+ ISNULL(D.DAY2,0)+ ISNULL(D.DAY3,0)+ ISNULL(D.DAY4,0) + ISNULL(D.DAY5,0)+"
            str = str & " ISNULL(D.DAY6,0) + ISNULL(D.DAY7,0) + ISNULL(D.DAY8,0) + ISNULL(D.DAY9,0) + ISNULL(D.DAY10,0) + "
            str = str & " ISNULL(D.DAY11,0) + ISNULL(D.DAY12,0) + ISNULL(D.DAY13,0) + ISNULL(D.DAY14,0) + ISNULL(D.DAY15,0) +"
            str = str & " ISNULL(D.DAY16,0) + ISNULL(D.DAY17,0) + ISNULL(D.DAY18,0) + ISNULL(D.DAY19,0) + ISNULL(D.DAY20,0) +"
            str = str & " ISNULL(D.DAY21,0) + ISNULL(D.DAY22,0) + ISNULL(D.DAY23,0) + ISNULL(D.DAY24,0) + ISNULL(D.DAY25,0) +"
            str = str & " ISNULL(D.DAY26,0) + ISNULL(D.DAY27,0) + ISNULL(D.DAY28,0) + ISNULL(D.DAY29,0)+ ISNULL(D.DAY30,0) + ISNULL(D.DAY31,0))) AS BALANCE"
            str = str & " FROM TempTblDayWiseStock T, daywise_stock_summary D WHERE T.ITEMCODE=D.ITEMCODE AND T.ITEMNAME=D.ITEMNAME"
            gconnection.dataOperation1(6, str, "item")
        End If

        str = "SELECT * FROM SYSOBJECTS WHERE name = 'TblTempProfitandLossReport' AND XTYPE='U'"
        gconnection.getDataSet(str, "TblTempProfitandLossReport")
        If gdataset.Tables("TblTempProfitandLossReport").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE TblTempProfitandLossReport"
            str = str & " ("
            str = str & " ItemCode varchar(20) null,"
            str = str & " ItemName varchar(50) null,"
            str = str & " OpQty numeric(18,2) null,"
            str = str & " OpRate numeric(18,2) null,"
            str = str & " OpValue numeric(18,2) null,"
            str = str & " RcvQty numeric(18,2) null,"
            str = str & " RcvRate numeric(18,2) null,"
            str = str & " RcvValue numeric(18,2) null,"
            str = str & " IssQty numeric(18,2) null,"
            str = str & " IssRate numeric(18,2) null,"
            str = str & " IssValue numeric(18,2) null,"
            str = str & " ClsQty numeric(18,2) null,"
            str = str & " ClsRate numeric(18,2) null,"
            str = str & " ClsValue numeric(18,2) null"
            str = str & " )"
            gconnection.dataOperation1(6, str, "item")
        End If

        str = "SELECT * FROM SYSOBJECTS WHERE name = 'TblProfitandLossReport' AND XTYPE='U'"
        gconnection.getDataSet(str, "TblProfitandLossReport")
        If gdataset.Tables("TblProfitandLossReport").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE [dbo].[TblProfitandLossReport]("
            str = str & " [ItemCode] [varchar](20) NULL,"
            str = str & " [ItemName] [varchar](50) NULL,"
            str = str & " [OpQty] [numeric](18, 2) NULL,"
            str = str & " [OpRate] [numeric](18, 2) NULL,"
            str = str & " [OpValue] [numeric](18, 2) NULL,"
            str = str & " [RcvQty] [numeric](18, 2) NULL,"
            str = str & " [RcvRate] [numeric](18, 2) NULL,"
            str = str & " [RcvValue] [numeric](18, 2) NULL,"
            str = str & " [TotOpRcvQty] [numeric](18, 2) NULL,"
            str = str & " [TotOpRcvRate] [numeric](18, 2) NULL,"
            str = str & " [TotOpRcvValue] [numeric](18, 2) NULL,"
            str = str & " [IssQty] [numeric](18, 2) NULL,"
            str = str & " [IssRate] [numeric](18, 2) NULL,"
            str = str & " [IssValue] [numeric](18, 2) NULL,"
            str = str & " [ClsQty] [numeric](18, 2) NULL,"
            str = str & " [ClsRate] [numeric](18, 2) NULL,"
            str = str & " [ClsValue] [numeric](18, 2) NULL,"
            str = str & " [TempClsQty] [numeric](18, 2) NULL,"
            str = str & " [TempClsRate] [numeric](18, 2) NULL,"
            str = str & " [TempClsValue] [numeric](18, 2) NULL,"
            str = str & " [Profit] [numeric](18,2) NULL"
            str = str & " ) "
            gconnection.dataOperation1(6, str, "item")



        End If
    End Sub

    Public Sub possetup()
        Dim str, SQLSTRING As String
        Dim crdate As Date
        Dim ins As String
        Dim POSLOCATION As String
        Dim POSITEMCODE, POSITEMUOM, INSERT(0) As String
        Dim AVGRATE, AVGQUANTITY, dblCalqty As Double
        str = "select max(currentdate) as currentdate from pos_setup "
        gconnection.getDataSet(str, "pos_setup")
        If gdataset.Tables("pos_setup").Rows.Count > 0 Then
            crdate = Format(CDate(gdataset.Tables("pos_setup").Rows(0).Item("currentdate")), "dd/MMM/yyyy")

        End If
        If crdate = Format(CDate(currendate), "dd/MMM/yyyy") Then
            SQLSTRING = "DELETE FROM SUBSTORECONSUMPTIONDETAIL WHERE DOCDATE >='" & Format(crdate, "dd/MMM/yyyy") & "'"
            '= (SELECT MAX(CAST(CONVERT(VARCHAR(20),Docdate,6) AS DATETIME)) FROM SUBSTORECONSUMPTIONDETAIL) "
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = SQLSTRING

            SQLSTRING = " Insert  Into  SUBSTORECONSUMPTIONDETAIL (Docno,Docdetails,Docdate,Itemcode,Itemname,Storelocationcode ,Uom ,Qty ,Rate ,Amount)  "

            SQLSTRING = SQLSTRING & " SELECT K.KOTNO,K.KOTDETAILS,K.KOTDATE,B.GITEMCODE,B.gitemname,P.STORECODE,B.GUOM,QTY*GQTY AS QTY,I.PURCHASERATE ,QTY*GQTY *I.PURCHASERATE AS AMOUNT   FROM KOT_DET K ,BOM_DET B, "
            SQLSTRING = SQLSTRING & " INVENTORYITEMMASTER I , POSITEMSTORELINK P WHERE K.ITEMCODE = B.Itemcode  AND K.UOM = B.ItemUOM AND K.POSCODE = P.POS AND k.ITEMCODE =P.ITEMCODE "
            SQLSTRING = SQLSTRING & " AND I.STORECODE =P.STORECODE  AND I.itemcode = B.gitemcode AND I.STOCKUOM = B.gUOM  AND ISNULL(DelFlag,'') <>'y' AND ISNULL(KOTSTATUS,'') <>'y' "
            SQLSTRING = SQLSTRING & " and CAST(CONVERT(VARCHAR(20),K.KOTDATE,6) AS DATE) = '" & Format(crdate, "dd-MMM-yyyy") & "'  "
            'between() '" & Format(crdate, "dd-MMM-yyyy") & "' and '" & Format(Date.Now, "dd-MMM-yyyy") & "'"
            '=(select MAX(CAST(CONVERT(VARCHAR(20),KOTDATE,6) AS DATE)) FROM KOT_DET)"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = SQLSTRING

        Else
            ' SQLSTRING = ""

            SQLSTRING = "DELETE FROM SUBSTORECONSUMPTIONDETAIL WHERE DOCDATE >='" & Format(crdate, "dd/MMM/yyyy") & "'"
            '= (SELECT MAX(CAST(CONVERT(VARCHAR(20),Docdate,6) AS DATETIME)) FROM SUBSTORECONSUMPTIONDETAIL) "
            '   gconnection.dataOperation(6, SQLSTRING, "SUBSTORECONSUMPTIONDETAIL1")
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = SQLSTRING

            SQLSTRING = " Insert  Into  SUBSTORECONSUMPTIONDETAIL (Docno,Docdetails,Docdate,Itemcode,Itemname,Storelocationcode ,Uom ,Qty ,Rate ,Amount)  "

            SQLSTRING = SQLSTRING & " SELECT K.KOTNO,K.KOTDETAILS,K.KOTDATE,B.GITEMCODE,B.gitemname,P.STORECODE,B.GUOM,QTY*GQTY AS QTY,I.PURCHASERATE ,QTY*GQTY *I.PURCHASERATE AS AMOUNT   FROM KOT_DET K ,BOM_DET B, "
            SQLSTRING = SQLSTRING & " INVENTORYITEMMASTER I , POSITEMSTORELINK P WHERE K.ITEMCODE = B.Itemcode  AND K.UOM = B.ItemUOM AND K.POSCODE = P.POS AND k.ITEMCODE =P.ITEMCODE "
            SQLSTRING = SQLSTRING & " AND I.STORECODE =P.STORECODE  AND I.itemcode = B.gitemcode AND I.STOCKUOM = B.gUOM  AND ISNULL(DelFlag,'') <>'y' AND ISNULL(KOTSTATUS,'') <>'y' "
            SQLSTRING = SQLSTRING & " and CAST(CONVERT(VARCHAR(20),K.KOTDATE,6) AS DATE) between '" & Format(crdate, "dd-MMM-yyyy") & "' and '" & Format(currendate, "dd-MMM-yyyy") & "' "

            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = SQLSTRING

            'Next i

            ins = "insert into pos_setup (currentdate) values ('" & Format(currendate, "dd-MMM-yyyy") & "') "
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = ins
            'gconnection.dataOperation(6, ins, "pos_setup")


        End If
        'End If
        gconnection.MoreTrans(INSERT)


    End Sub

    Public Sub nEWuPDATE()
        Dim str As String

        str = " update  po_hdr set poquotdate=podate where poquotdate is null "
        gconnection.dataOperation1(6, str, "PO_HDRR")

        If gShortname = "VFNCC" Then
            str = "alter VIEW  [dbo].[VW_INV_ISSUEBILL] AS SELECT TOP 100 PERCENT dbo.stockissueheader.docdetails,   dbo.stockissueheader.docdate, dbo.stockissueheader.storelocationname, dbo.stockissueheader.opstorelocationname,   dbo.stockissuedetail.itemcode, dbo.stockissueheader.storelocationcode,dbo.stockissueheader.opstorelocationcode,   dbo.stockissuedetail.itemname, dbo.stockissuedetail.uom,dbo.stockissuedetail.qty , dbo.stockissuedetail.rate,    dbo.stockissuedetail.amount , dbo.stockissueheader.indentno ,  dbo.stockissueheader.indentdate,   dbo.stockissueheader.remarks,isnull(dbo.stockissueheader.partybookingno,'') as partybookingno,Groupdesc FROM dbo.stockissuedetail INNER JOIN dbo.stockissueheader     ON dbo.stockissuedetail.docdetails = dbo.stockissueheader.docdetails INNER JOIN dbo.INV_InventoryItemMaster ON dbo.stockissuedetail.ITEMCODE=dbo.INV_InventoryItemMaster.ITEMCODE INNER JOIN dbo.InventoryGroupMaster ON dbo.InventoryGroupMaster.Groupcode=dbo.INV_InventoryItemMaster.Groupcode"
            gconnection.dataOperation1(6, str, "VW_INV_ISSUEBILL")
        End If

        '-------------------------------------TAXREBATE/ITEMTYPE-------------------------

        If gShortname = "RSAOI" Then

            str = " ALTER    VIEW [dbo].[VW_INV_GRNBILL] AS "

            str = str & " SELECT ISNULL(D.AUTOID,'') AS AUTOID,ISNULL(G.PONO,'') AS PONO,  ISNULL(G.GRNDETAILS,'') AS GRNDETAILS,G.GRNDATE, "
            str = str & "ISNULL(G.SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(G.SUPPLIERNAME,'') AS SUPPLIERNAME, "
            str = str & "ISNULL(G.SUPPLIERINVNO,'') AS SUPPLIERINVNO,       ISNULL(G.StoreCode,'') AS EXCISEPASSNO, ISNULL(G.TOTALAMOUNT,0) AS TOTALAMOUNT, "
            str = str & "ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(G.SURCHARGEAMT,0) AS SURCHARGEAMT, ISNULL(D.DISCOUNT,0) AS DISCOUNT,ISNULL(G.BILLAMOUNT,0) AS BILLAMOUNT,  "
            str = str & "ISNULL(D.ITEMCODE,'') AS ITEMCODE, ISNULL(D.ITEMNAME,'') AS ITEMNAME, ISNULL(D.UOM,'') AS UOM, ISNULL(D.QTY,0) AS QTY, ISNULL(D.RATE,0) AS RATE,"
            str = str & "ISNULL(G.REMARKS,'') AS REMARKS,    ISNULL(D.AMOUNT,0) AS AMOUNT, isnull(d.discount,0) as ddiscount,isnull(d.taxper,0) as taxper, "
            str = str & "isnull(d.taxamount,0) as taxamount, isnull(g.OverallDiscount,0) OverallDiscount, ISNULL(g.Adddate,'') AS ADDDATE  ,ISNULL(D.taxcode,'') AS TAXGROUPCODE,ISNULL(G.RoundupAmt,0) AS RoundupAmt,ISNULL(D.IGSTAmt,0) AS IGSTAmt,ISNULL(D.SGSTAmt,0) AS SGSTAmt,ISNULL(D.CGSTAmt,0) AS CGSTAmt,"
            str = str & "ISNULL(SL.contactperson,'') AS contactperson,ISNULL(SL.address1,'') AS address1,ISNULL(SL.address2,'') AS address2,  ISNULL(SL.city,'') AS city,ISNULL(SL.state,'') AS state,ISNULL(SL.PIN,'') AS pIN , ISNULL(SL.phoneno,'') AS PhONENO, ISNULL(SL.GSTINNO,'') AS GSTINNO ,ISNULL(SL.VENDORTYPE,'') AS VENDORTYPE "
            str = str & ",ISNULL(IV.HSNNO,'') AS HSNNO,ISNULL(IV.TAXTYPE,'') AS  TAXTYPE,ISNULL(D.SPLCESS,0) AS SPLCESS,isnull(d.Voiditem,'N') AS Voiditem"
            str = str & " FROM GRN_HEADER AS G INNER JOIN GRN_DETAILS AS D ON G.GRNDETAILS = D.GRNDETAILS  INNER JOIN  "
            str = str & "SUPPLIERDetails SL ON SL.vendorcode=G.Suppliercode INNER JOIN INV_InventoryItemMaster IV ON "
            str = str & "  IV.itemcode = D.Itemcode"
            gconnection.dataOperation1(6, str, "STOCKADJUSTDETAILS")
        End If

        str = "Select * from sysobjects where name='vw_kga_purchase' and xtype='V'"
        gconnection.getDataSet(str, "vw_kga_purchase")
        If gdataset.Tables("vw_kga_purchase").Rows.Count > 0 Then

        Else
            str = "CREATE view [dbo].[vw_kga_purchase] as select G.itemcode,G.itemname,uom,qty as qty,rate,baseamount as amount,taxamount as gst,baseamount+taxamount+OTHCHARGE-DISCOUNT as total,discount as discount,othcharge as othercharge,I.groupcode,o.Groupdesc,G.Suppliercode,G.Suppliername,G.STORECODE,G.GRNDATE from grn_details G ,INV_INVENTORYITEMMASTER I,InventoryGroupMaster o WHERE I.ITEMCODE=G.ITEMCODE and o.groupcode=i.groupcode AND ISNULL(G.VOIDITEM,'')<>'Y' group by G.itemcode,G.itemname,uom,rate,i.groupcode,o.Groupdesc,G.Suppliercode,G.Suppliername,G.STORECODE,G.GRNDATE,QTY,baseamount,taxamount,Discount,OTHCHARGE"
            gconnection.dataOperation1(6, str, "INVENTORY_TRANSCONVERSION")
        End If

        str = "Select * from sysobjects where name='VIEW_EXPIRYREPORT' and xtype='V'"
        gconnection.getDataSet(str, "VIEW_EXPIRYREPORT")
        If gdataset.Tables("VIEW_EXPIRYREPORT").Rows.Count > 0 Then

        Else
            str = "CREATE VIEW VIEW_EXPIRYREPORT AS SELECT ITEMCODE,ITEMNAME,UOM,grndetails,Qty,ExpiryDate FROM Grn_details Where ExpiryDate<DATEADD(DAY,30,cast(floor(cast(getdate() as float)) as datetime))"
            gconnection.dataOperation1(6, str, "INVENTORY_TRANSCONVERSION")
        End If

        str = "Select * from sysobjects where name='VW_MRPRATE' and xtype='V'"
        gconnection.getDataSet(str, "VW_MRPRATE")
        If gdataset.Tables("VW_MRPRATE").Rows.Count > 0 Then

        Else
            str = "CREATE VIEW VW_MRPRATE AS SELECT r.ITEMCODE,i.itemdesc as itemname,uom as stockuom,itemrate as mrprate,purcahserate,category FROM ratemaster r,itemmaster i where i.itemcode=r.itemcode and r.endingdate is null"
            gconnection.dataOperation1(6, str, "INVENTORY_TRANSCONVERSION")
        End If


        str = "Select * from sysobjects where name='vw_inv_inventoryitemmaster_manualupdate' and xtype='V'"
        gconnection.getDataSet(str, "vw_inv_inventoryitemmaster_manualupdate")
        If gdataset.Tables("vw_inv_inventoryitemmaster_manualupdate").Rows.Count > 0 Then

        Else
            str = "CREATE view [dbo].vw_inv_inventoryitemmaster_manualupdate as  SELECT * FROM INV_INVENTORYITEMMASTER"
            gconnection.dataOperation1(6, str, "INVENTORY_TRANSCONVERSION")
        End If

        str = "Select * from sysobjects where name='INV_WEIGHTED_final_tabNEW' and xtype='U'"
        gconnection.getDataSet(str, "INV_WEIGHTED_final_tabNEW")
        If gdataset.Tables("INV_WEIGHTED_final_tabNEW").Rows.Count > 0 Then

        Else
            str = " CREATE TABLE [dbo].[INV_WEIGHTED_final_tabNEW]("
            str = str & " [DOCDETAILS] [varchar](50) NULL,"
            str = str & " [ITEMCODE] [varchar](50) NULL,"
            str = str & " [ITEMname] [varchar](200) NULL,"
            str = str & " [docdate] [datetime] NULL,"
            str = str & " [UOM] [varchar](50) NULL,"
            str = str & " [qty] [numeric](18, 6) NULL,"
            str = str & " [RATE] [numeric](18, 6) NULL,"
            str = str & " [clsstock] [numeric](18, 6) NULL,"
            str = str & " [type] [varchar](50) NULL,"
            str = str & " [storecode] [varchar](50) NULL,"
            str = str & " [CATEGORY] [varchar](30) NULL,"
            str = str & " [RATEFLAG] [varchar](10) NULL,"
            str = str & " [LASTSTOCK] [numeric](18, 6) NULL,"
            str = str & " [LASTRATE] [numeric](18, 6) NULL,"
            str = str & " [PRIORITY] [int]  NULL"
            str = str & "  [rowid] [Int] NULL"
            str = str & "   [WEIGHTED_RATE] [numeric](18, 6) NULL"
            str = str & " ) ON [PRIMARY]"
            gconnection.dataOperation1(6, str, "INVENTORY_TRANSCONVERSION")
        End If

        ' For log table by Sriram
        str = "Select * from sysobjects where name='INVENTORY_INDENTHDRLOG' and xtype='U'"
        gconnection.getDataSet(str, "INVENTORY_INDENTHDRLOG")
        If gdataset.Tables("INVENTORY_INDENTHDRLOG").Rows.Count > 0 Then

        Else
            str = " CREATE TABLE [dbo].[INVENTORY_INDENTHDRLOG](    [AUTOID] [numeric](18, 0) IDENTITY(1, 1) Not NULL,	[INDENT_NO] [varchar](50) Not NULL,    [INDENT_DATE] [DateTime] NULL,    [fromStoreCode] [varchar](15) NULL,    [STORELOCATIONCODE] [varchar](10) NULL,    [STORELOCATIONNAME] [varchar](50) NULL,    [PRODUCT_TYPE] [varchar](25) NULL,    [REMARKS] [varchar](100) NULL,    [Void] [varchar](1) NULL,    [ADDUSER] [varchar](30) NULL,    [ADDDATETIME] [DateTime] NULL,    [UPDATEUSER] [varchar](30) NULL,    [UPDATETIME] [DateTime] NULL,    [UPDFOOTER] [varchar](150) NULL,    [UPDSIGN] [varchar](150) NULL,    [DOCNO] [nvarchar](50) NULL,    [ind_qty] [numeric](18, 0) NULL) ON [PRIMARY]"

            gconnection.dataOperation1(6, str, "INVENTORY_TRANSCONVERSION")
        End If

        str = "Select * from sysobjects where name='tempstocktable' and xtype='U'"
        gconnection.getDataSet(str, "tempstocktable")
        If gdataset.Tables("tempstocktable").Rows.Count > 0 Then

        Else
            str = "create table tempstocktable (qty numeric(18,3),itemcode varchar(100),storecode varchar(50),val numeric(18,6),username varchar(100),machinename varchar(100)) "
            gconnection.dataOperation1(6, str, "tempstocktable")
        End If


        str = "Select * from sysobjects where name='INVENTORY_INDENTDETLOG' and xtype='U'"
        gconnection.getDataSet(str, "INVENTORY_INDENTDETLOG")
        If gdataset.Tables("INVENTORY_INDENTDETLOG").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE [dbo].[INVENTORY_INDENTDETLOG](	[AUTOID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,	[INDENT_NO] [varchar](50) NULL,	[INDENT_DATE] [datetime] NULL,	[ITEMCODE] [varchar](10) NULL,	[ITEMNAME] [varchar](75) NULL,	[UOM] [varchar](15) NULL,	[QTY] [numeric](9, 3) NULL,	[RATE] [numeric](9, 2) NULL,	[AMOUNT] [numeric](9, 2) NULL,	[CLSQTY] [numeric](9, 2) NULL,	[VOID] [varchar](1) NULL,	[ADDUSER] [varchar](30) NULL,	[ADDDATETIME] [datetime] NULL,	[UPDATEUSER] [varchar](30) NULL,	[UPDATETIME] [datetime] NULL,	[FREEZEUSER] [varchar](30) NULL,	[FREEZEDATETIME] [datetime] NULL,	[ind_qty] [numeric](18, 0) NULL,	[DOCNO] [numeric](18, 0) NULL) ON [PRIMARY]"
            gconnection.dataOperation1(6, str, "INVENTORY_TRANSCONVERSION")
        End If

        str = "Select * from sysobjects where name='STOCKISSUEHEADER_LOG' and xtype='U'"
        gconnection.getDataSet(str, "STOCKISSUEHEADER_LOG")
        If gdataset.Tables("STOCKISSUEHEADER_LOG").Rows.Count > 0 Then

        Else
            str = " CREATE TABLE [dbo].[STOCKISSUEHEADER_LOG]("
            str = " [Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = " [docno] [varchar](50) NULL,"
            str = " [Docdetails] [varchar](50) NULL,"
            str = " [doctype] [varchar](50) NULL,"
            str = " [docdate] [datetime] NULL,"
            str = " [IndentNo] [varchar](50) NULL,"
            str = " [IndentDate] [datetime] NULL,"
            str = " [Storelocationcode] [varchar](50) NULL,"
            str = " [Storelocationname] [varchar](50) NULL,"
            str = " [Opstorelocationcode] [varchar](50) NULL,"
            str = " [Opstorelocationname] [varchar](50) NULL,"
            str = " [totalamt] [numeric](18, 3) NULL,"
            str = " [Remarks] [varchar](200) NULL,"
            str = " [void] [varchar](1) NULL,"
            str = " [voidreason] [varchar](200) NULL,"
            str = " [AddDate] [datetime] NULL,"
            str = " [addUSER] [varchar](50) NULL,"
            str = " [UPDATEUSER] [varchar](15) NULL,"
            str = " [UPDATEtime] [datetime] NULL,"
            str = " [voiduser] [varchar](50) NULL,"
            str = " [voidtime] [datetime] NULL,"
            str = " [partybookingno] [varchar](20) NULL"
            str = " ) ON [PRIMARY]"
            gconnection.dataOperation1(6, str, "INVENTORY_TRANSCONVERSION")
        End If

        str = "Select * from sysobjects where name='STOCKISSUEDETAIL_LOG' and xtype='U'"
        gconnection.getDataSet(str, "STOCKISSUEDETAIL_LOG")
        If gdataset.Tables("STOCKISSUEDETAIL_LOG").Rows.Count > 0 Then

        Else
            str = " CREATE TABLE [dbo].[STOCKISSUEDETAIL_LOG]("
            str = " [AUTOID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = " [Docno] [varchar](50) NULL,"
            str = " [Docdetails] [varchar](50) NULL,"
            str = " [Docdate] [datetime] NULL,"
            str = " [IndentNo] [varchar](50) NULL,"
            str = " [indentdate] [datetime] NULL,"
            str = " [storelocationcode] [varchar](50) NULL,"
            str = " [storelocationname] [varchar](50) NULL,"
            str = " [opstorelocationcode] [varchar](50) NULL,"
            str = " [opstorelocationname] [varchar](50) NULL,"
            str = " [Itemcode] [varchar](50) NULL,"
            str = " [Itemname] [varchar](50) NULL,"
            str = " [uom] [varchar](50) NULL,"
            str = " [ind_qty] [numeric](18, 3) NULL,"
            str = " [qty] [numeric](18, 2) NULL,"
            str = " [batchno] [varchar](50) NULL,"
            str = " [rate] [numeric](18, 2) NULL,"
            str = " [amount] [numeric](18, 2) NULL,"
            str = " [void] [varchar](10) NULL,"
            str = " [adduser] [varchar](50) NULL,"
            str = " [adddatetime] [datetime] NULL,"
            str = " [updateuser] [varchar](50) NULL,"
            str = " [updatetime] [datetime] NULL,"
            str = " [voiduser] [varchar](50) NULL,"
            str = " [voidtime] [datetime] NULL,"
            str = " [TRNS_SEQ] [numeric](9, 0) NULL,"
            str = " [IssTransValueR] [numeric](18, 2) NULL,"
            str = " [IssTransQtyR] [numeric](18, 2) NULL"
            str = " ) ON [PRIMARY]"

            gconnection.dataOperation1(6, str, "INVENTORY_TRANSCONVERSION")
        End If

        str = "Select * from sysobjects where name='STOCKTRANSFERDETAIL_LOG' and xtype='U'"
        gconnection.getDataSet(str, "STOCKTRANSFERDETAIL_LOG")
        If gdataset.Tables("STOCKTRANSFERDETAIL_LOG").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE [dbo].[STOCKTRANSFERDETAIL_LOG](	[docno] [varchar](50) NULL,	[Docdetails] [varchar](50) NULL,	[docdate] [datetime] NULL,	[doctype] [varchar](50) NULL,	[transferno] [varchar](50) NULL,	[fromstorecode] [varchar](50) NULL,	[fromstoredesc] [varchar](50) NULL,	[tostorecode] [varchar](50) NULL,	[tostoredesc] [varchar](50) NULL,	[itemcode] [varchar](50) NULL,	[itemname] [varchar](50) NULL,	[uom] [varchar](50) NULL,	[qty] [numeric](18, 3) NULL,	[batchno] [varchar](50) NULL,	[closingqty] [numeric](18, 3) NULL,	[void] [varchar](50) NULL,	[adduser] [varchar](50) NULL,	[adddatetime] [datetime] NULL,	[updateuser] [varchar](50) NULL,	[updatedate] [datetime] NULL,	[voiduser] [varchar](50) NULL,	[voiddate] [datetime] NULL,	[RATE] [numeric](18, 2) NULL,	[amount] [numeric](18, 2) NULL,	[TRNS_SEQ] [numeric](9, 0) NULL,	[TRFTransQtyR] [numeric](18, 2) NULL,	[TRFTransValueR] [numeric](18, 2) NULL) ON [PRIMARY]"
            gconnection.dataOperation1(6, str, "INVENTORY_TRANSCONVERSION")
        End If

        str = "Select * from sysobjects where name='STOCKTRANSFERHEADER_LOG' and xtype='U'"
        gconnection.getDataSet(str, "STOCKTRANSFERHEADER_LOG")
        If gdataset.Tables("STOCKTRANSFERHEADER_LOG").Rows.Count > 0 Then
        Else
            str = "CREATE TABLE [dbo].[STOCKTRANSFERHEADER_LOG](	[docno] [varchar](50) NULL,	[docdetails] [varchar](50) NULL,	[docdate] [datetime] NULL,	[doctype] [varchar](50) NULL,	[transferno] [varchar](50) NULL,	[fromstorecode] [varchar](50) NULL,	[fromstoredesc] [varchar](50) NULL,	[tostorecode] [varchar](50) NULL,	[tostoredesc] [varchar](50) NULL,	[remarks] [varchar](200) NULL,	[void] [varchar](5) NULL,	[adduser] [varchar](50) NULL,	[adddate] [datetime] NULL,	[updateuser] [varchar](50) NULL,	[updatedate] [datetime] NULL,	[voiduser] [varchar](50) NULL,	[voiddate] [datetime] NULL) ON [PRIMARY]"
            gconnection.dataOperation1(6, str, "INVENTORY_TRANSCONVERSION")
        End If

        str = "Select * from sysobjects where name='STOCKADJUSTHEADER_LOG' and xtype='U'"
        gconnection.getDataSet(str, "STOCKADJUSTHEADER_LOG")
        If gdataset.Tables("STOCKADJUSTHEADER_LOG").Rows.Count > 0 Then
        Else
            str = "CREATE TABLE [dbo].[STOCKADJUSTHEADER_LOG](	[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,	[docno] [varchar](50) NULL,	[Docdetails] [varchar](50) NULL,	[docdate] [datetime] NULL,	[Storecode] [varchar](50) NULL,	[StoreDESC] [varchar](50) NULL,	[Adjustedstock] [numeric](18, 3) NULL,	[stockinhand] [numeric](18, 3) NULL,	[Physicalstock] [numeric](18, 3) NULL,	[totalqty] [numeric](18, 3) NULL,	[Remarks] [varchar](200) NULL,	[void] [varchar](1) NULL,	[voidreason] [varchar](200) NULL,	[AddDate] [datetime] NULL,	[addUSER] [varchar](50) NULL,	[UPDATEUSER] [varchar](15) NULL,	[UPDATEtime] [datetime] NULL,	[voiduser] [varchar](50) NULL,	[voidtime] [datetime] NULL) ON [PRIMARY]"
            gconnection.dataOperation1(6, str, "INVENTORY_TRANSCONVERSION")
        End If

        str = "Select * from sysobjects where name='STOCKADJUSTDETAILS_LOG' and xtype='U'"
        gconnection.getDataSet(str, "STOCKADJUSTDETAILS_LOG")
        If gdataset.Tables("STOCKADJUSTDETAILS_LOG").Rows.Count > 0 Then
        Else
            str = "CREATE TABLE [dbo].[STOCKADJUSTDETAILS_LOG](	[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,	[docno] [varchar](50) NULL,	[Docdetails] [varchar](50) NULL,	[docdate] [datetime] NULL,	[Storecode] [varchar](50) NULL,	[StoreDESC] [varchar](50) NULL,	[iTEMCODE] [varchar](50) NULL,	[iTEMnAME] [varchar](50) NULL,	[uom] [varchar](50) NULL,	[BATCHNO] [varchar](50) NULL,	[stockinhand] [numeric](18, 3) NULL,	[Adjustedstock] [numeric](18, 3) NULL,	[Physicalstock] [numeric](18, 3) NULL,	[Remarks] [varchar](200) NULL,	[void] [varchar](1) NULL,	[AddDate] [datetime] NULL,	[addUSER] [varchar](50) NULL,	[UPDATEUSER] [varchar](15) NULL,	[UPDATEtime] [datetime] NULL,	[voiduser] [varchar](50) NULL,	[voidtime] [datetime] NULL,	[RATE] [numeric](18, 2) NULL,	[amount] [numeric](18, 2) NULL,	[TRNS_SEQ] [numeric](9, 0) NULL,	[STORELOCATIONCODE] [varchar](50) NULL,	[AdjTransQtyR] [numeric](18, 2) NULL,	[AdjTransValueR] [numeric](18, 2) NULL,	[Remarks_det] [varchar](500) NULL,	[REMARKS2] [varchar](100) NULL) ON [PRIMARY]"
            gconnection.dataOperation1(6, str, "INVENTORY_TRANSCONVERSION")
        End If
        str = "Select * from sysobjects where name='STOCKDMGHEADER_LOG' and xtype='U'"
        gconnection.getDataSet(str, "STOCKDMGHEADER_LOG")
        If gdataset.Tables("STOCKDMGHEADER_LOG").Rows.Count > 0 Then
        Else
            str = "CREATE TABLE [dbo].[STOCKDMGHEADER_LOG](	[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,	[docno] [varchar](50) NULL,	[Docdetails] [varchar](50) NULL,	[doctype] [varchar](50) NULL,	[docdate] [datetime] NULL,	[Storecode] [varchar](50) NULL,	[StoreDESC] [varchar](50) NULL,	[totalqty] [numeric](18, 3) NULL,	[Remarks] [varchar](200) NULL,	[void] [varchar](1) NULL,	[voidreason] [varchar](200) NULL,	[AddDate] [datetime] NULL,	[addUSER] [varchar](50) NULL,	[UPDATEUSER] [varchar](15) NULL,	[UPDATEtime] [datetime] NULL,	[voiduser] [varchar](50) NULL,	[voidtime] [datetime] NULL) ON [PRIMARY]"
            gconnection.dataOperation1(6, str, "INVENTORY_TRANSCONVERSION")
        End If

        str = "Select * from sysobjects where name='STOCKDMGDETAIL_LOG' and xtype='U'"
        gconnection.getDataSet(str, "STOCKDMGDETAIL_LOG")
        If gdataset.Tables("STOCKDMGDETAIL_LOG").Rows.Count > 0 Then
        Else
            str = "CREATE TABLE [dbo].[STOCKDMGDETAIL_LOG](	[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,	[docno] [varchar](50) NULL,	[Docdetails] [varchar](50) NULL,	[DocTYPE] [varchar](50) NULL,	[docdate] [datetime] NULL,	[Storecode] [varchar](50) NULL,	[StoreDESC] [varchar](50) NULL,	[itemcode] [varchar](50) NULL,	[itemname] [varchar](50) NULL,	[uom] [varchar](50) NULL,	[dmgqty] [numeric](18, 3) NULL,	[batchno] [varchar](50) NULL,	[closingqty] [numeric](18, 3) NULL,	[Remarks] [varchar](200) NULL,	[void] [varchar](1) NULL,	[voidreason] [varchar](200) NULL,	[AddDate] [datetime] NULL,	[addUSER] [varchar](50) NULL,	[UPDATEUSER] [varchar](15) NULL,	[UPDATEtime] [datetime] NULL,	[voiduser] [varchar](50) NULL,	[voidtime] [datetime] NULL,	[RATE] [numeric](18, 2) NULL,	[amount] [numeric](18, 2) NULL,	[TRNS_SEQ] [numeric](9, 0) NULL,	[FROMSTORECODE] [varchar](50) NULL,	[qty] [numeric](18, 2) NULL,	[DMGTRANSQTYR] [numeric](18, 2) NULL,	[DMGTRANSVALUER] [numeric](18, 2) NULL) ON [PRIMARY]"
            gconnection.dataOperation1(6, str, "INVENTORY_TRANSCONVERSION")
        End If

        str = "Select * from sysobjects where name='stockConsumption_1LOG' and xtype='U'"
        gconnection.getDataSet(str, "stockConsumption_1LOG")
        If gdataset.Tables("stockConsumption_1LOG").Rows.Count > 0 Then
        Else
            str = "CREATE TABLE [dbo].[stockConsumption_1LOG](	[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,	[doctype] [varchar](50) NOT NULL,	[docno] [varchar](50) NOT NULL,	[itemcode] [varchar](50) NOT NULL,	[itemname] [varchar](50) NOT NULL,	[uom] [varchar](50) NOT NULL,	[storecode] [varchar](50) NOT NULL,	[storedesc] [varchar](50) NULL,	[docdate] [datetime] NOT NULL,	[stockinhand] [numeric](18, 3) NOT NULL,	[physicalstock] [numeric](18, 3) NULL,	[rate] [numeric](18, 2) NULL,	[amount] [numeric](18, 2) NULL,	[remarks] [varchar](100) NULL,	[void] [char](1) NULL,	[TRNS_SEQ] [numeric](15, 0) NULL,	[oldqty] [numeric](18, 3) NULL,	[consumption] [numeric](18, 3) NULL,	[ADDDATE] [datetime] NULL,	[MCA] [varchar](5) NULL,	[Authorised] [varchar](5) NULL,	[COMMENT] [varchar](200) NULL,	[AuthorisID] [varchar](50) NULL,	[CheckerID] [varchar](50) NULL,	[AuthorisDate] [datetime] NULL,	[CheckerDate] [datetime] NULL,	[adduser] [varchar](100) NULL,	[Batchno] [varchar](5) NULL) ON [PRIMARY]"
            gconnection.dataOperation1(6, str, "INVENTORY_TRANSCONVERSION")
        End If

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'STOREMASTER' AND  COLUMN_NAME = 'lock') Begin alter table STOREMASTER add  lock varchar(10) End"
        gconnection.dataOperation(6, str, "AddC")



        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PO_HDR' AND  COLUMN_NAME = 'poquotdate') Begin alter table PO_HDR add  poquotdate datetime End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'inventorysubsubgroupmaster' AND  COLUMN_NAME = 'TAXPER') Begin alter table inventorysubsubgroupmaster add  TAXPER Numeric(18,2) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_DETAILS' AND  COLUMN_NAME = 'MRPRATE') Begin alter table GRN_DETAILS add  MRPRATE Numeric(18,2) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'inv_inventoryitemmaster' AND  COLUMN_NAME = 'MRPRATE') Begin alter table inv_inventoryitemmaster add  MRPRATE numeric(18,2) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'inv_inventoryitemmaster' AND  COLUMN_NAME = 'Batchno') Begin alter table inv_inventoryitemmaster add  Batchno varchar(10) End"
        gconnection.dataOperation(6, str, "AddC")


        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'inv_inventoryitemmaster' AND  COLUMN_NAME = 'ExpiryDate') Begin alter table inv_inventoryitemmaster add  ExpiryDate varchar(10) End"
        gconnection.dataOperation(6, str, "AddC")


        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'grn_details' AND  COLUMN_NAME = 'ExpiryDate') Begin alter table grn_details add  ExpiryDate date End"
        gconnection.dataOperation(6, str, "AddC")


        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'grn_details' AND  COLUMN_NAME = 'VoidUser') Begin alter table grn_details add  VoidUser Varchar(50) End"
        gconnection.dataOperation(6, str, "AddC")


        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'grn_details' AND  COLUMN_NAME = 'VoidDate') Begin alter table grn_details add  VoidDate datetime End"
        gconnection.dataOperation(6, str, "AddC")



        If gShortname = "HGA" Then
            str = "exec  passinvntoryunmatchedentries"
            gconnection.ExcuteStoreProcedure(str)
        End If

        If gShortname <> "HGA" Then
            str = " Select * from information_schema.routines where routine_type = 'PROCEDURE' AND SPECIFIC_NAME='TAXREBATE_CONVERSION' "
            gconnection.getDataSet(str, "INFORMATION_SCHEMA")
            If gdataset.Tables("INFORMATION_SCHEMA").Rows.Count = 0 Then
                str = " ALTER TABLE INV_InventoryItemMaster ADD CON VARCHAR (1) "
                gconnection.getDataSet(str, "INFORMATION_SCHEMA")
                str = "  CREATE PROCEDURE TAXREBATE_CONVERSION  AS  BEGIN  "
                str = str & " Select * INTO INV_InventoryItemMaster_TAXREBATE FROM INV_InventoryItemMaster"
                str = str & " Select * INTO Grn_details_TAXREBATE FROM Grn_details"
                str = str & " UPDATE INV_InventoryItemMaster Set TaxRebate='NO',CON='Y' WHERE TaxRebate='YES' AND ISNULL(CON,'N')='N'"
                str = str & " UPDATE INV_InventoryItemMaster SET TaxRebate='YES',CON='Y' WHERE TaxRebate='NO' AND ISNULL(CON,'N')='N'"
                str = str & " UPDATE Grn_details set ITEM_TYPE='YES' WHERE ITEMCODE IN (SELECT ITEMCODE FROM INV_InventoryItemMaster WHERE ISNULL(TaxRebate,'NO')='YES' AND ISNULL(CON,'N')='Y')"
                str = str & " UPDATE Grn_details set ITEM_TYPE='NO' WHERE ITEMCODE IN (SELECT ITEMCODE FROM INV_InventoryItemMaster WHERE ISNULL(TaxRebate,'NO')='NO'  AND ISNULL(CON,'N')='Y' )"
                str = str & " End"
                gconnection.dataOperation(6, str, "AddC")
                str = " EXEC TAXREBATE_CONVERSION"
                gconnection.dataOperation(6, str, "AddC")
            End If
        End If

        str = " select * from information_schema.routines where routine_type = 'PROCEDURE' AND SPECIFIC_NAME='proc_closingqtyone' "
        gconnection.getDataSet(str, "INFORMATION_SCHEMA")
        If gdataset.Tables("INFORMATION_SCHEMA").Rows.Count = 0 Then
            str = " CREATE PROCEDURE proc_closingqtyone  AS  BEGIN  "
            str = str & " Declare @batch varchar(100)   "
            str = str & "Set @batch=(Select  max(isnull(batchno,0))+1 As batchno from closingqty_one) "
            str = str & " End"
            gconnection.dataOperation(6, str, "AddC")
        End If




        str = "If Not EXISTS( Select * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_InventoryItemMaster' AND  COLUMN_NAME = 'PRATE') Begin ALTER TABLE INV_InventoryItemMaster ADD PRATE NUMERIC (18,2) DEFAULT 0 End"
        gconnection.dataOperation(6, str, "AddC")


        '-------------------------------------------END----------------------------------
        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'storemaster' AND  COLUMN_NAME = 'buffet') Begin alter table storemaster add  buffet varchar(10) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'storemaster' AND  COLUMN_NAME = 'banquet') Begin alter table storemaster add  banquet varchar(10) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'STOCKISSUEHEADER' AND  COLUMN_NAME = 'buffetmenu') Begin alter table STOCKISSUEHEADER add  buffetmenu varchar(50) End"
        gconnection.dataOperation(6, str, "AddC")


        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'STOCKTRANSFERHEADER' AND  COLUMN_NAME = 'buffetmenu') Begin alter table STOCKTRANSFERHEADER add  buffetmenu varchar(50) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'STOCKTRANSFERHEADER' AND  COLUMN_NAME = 'partybookingno') Begin alter table STOCKTRANSFERHEADER add  partybookingno varchar(50) End"
        gconnection.dataOperation(6, str, "AddC")


        str = " SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'STOCKISSUEHEADER' AND  COLUMN_NAME = 'partybookingno' "
        gconnection.getDataSet(str, "INFORMATION_SCHEMA")
        If gdataset.Tables("INFORMATION_SCHEMA").Rows.Count = 0 Then


            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PO_HDR' AND  COLUMN_NAME = 'TotGSTAmt') Begin alter table PO_HDR add  TotGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PO_HDR' AND  COLUMN_NAME = 'TotSGSTAmt') Begin alter table PO_HDR add  TotSGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PO_HDR' AND  COLUMN_NAME = 'TotCGSTAmt') Begin alter table PO_HDR add  TotCGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PO_HDR' AND  COLUMN_NAME = 'TotIGSTAmt') Begin alter table PO_HDR add  TotIGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")

            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PO_IMAGEHDR' AND  COLUMN_NAME = 'TotGSTAmt') Begin alter table PO_IMAGEHDR add  TotGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PO_IMAGEHDR' AND  COLUMN_NAME = 'TotSGSTAmt') Begin alter table PO_IMAGEHDR add  TotSGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PO_IMAGEHDR' AND  COLUMN_NAME = 'TotCGSTAmt') Begin alter table PO_IMAGEHDR add  TotCGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PO_IMAGEHDR' AND  COLUMN_NAME = 'TotIGSTAmt') Begin alter table PO_IMAGEHDR add  TotIGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")

            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PO_ITEMDETAILS' AND  COLUMN_NAME = 'GSTAmt') Begin alter table PO_ITEMDETAILS add  GSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PO_ITEMDETAILS' AND  COLUMN_NAME = 'SGSTAmt') Begin alter table PO_ITEMDETAILS add  SGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PO_ITEMDETAILS' AND  COLUMN_NAME = 'CGSTAmt') Begin alter table PO_ITEMDETAILS add  CGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PO_ITEMDETAILS' AND  COLUMN_NAME = 'IGSTAmt') Begin alter table PO_ITEMDETAILS add  IGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PO_ITEMDETAILS' AND  COLUMN_NAME = 'SPLCESS') Begin alter table PO_ITEMDETAILS add  SPLCESS numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")


            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PO_ITEMDETAILS_LOG' AND  COLUMN_NAME = 'GSTAmt') Begin alter table PO_ITEMDETAILS_LOG add  GSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PO_ITEMDETAILS_LOG' AND  COLUMN_NAME = 'SGSTAmt') Begin alter table PO_ITEMDETAILS_LOG add  SGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PO_ITEMDETAILS_LOG' AND  COLUMN_NAME = 'CGSTAmt') Begin alter table PO_ITEMDETAILS_LOG add  CGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PO_ITEMDETAILS_LOG' AND  COLUMN_NAME = 'IGSTAmt') Begin alter table PO_ITEMDETAILS_LOG add  IGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PO_ITEMDETAILS_LOG' AND  COLUMN_NAME = 'SPLCESS') Begin alter table PO_ITEMDETAILS_LOG add  SPLCESS numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''





            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_HEADER' AND  COLUMN_NAME = 'roffamount') Begin alter table grn_header add roffamount as round((isnull(totalamount,0)+isnull(vatamount,0)+isnull(surchargeamt,0)-isnull(OverallDiscount,0)),0)-round((isnull(totalamount,0)+isnull(vatamount,0)+isnull(surchargeamt,0)-isnull(OverallDiscount,0)),2) End"
            gconnection.dataOperation(6, str, "AddC")

            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_HEADERLOG' AND  COLUMN_NAME = 'TotGSTAmt') Begin alter table GRN_HEADERLOG add  TotGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_HEADERLOG' AND  COLUMN_NAME = 'TotSGSTAmt') Begin alter table GRN_HEADERLOG add  TotSGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_HEADERLOG' AND  COLUMN_NAME = 'TotCGSTAmt') Begin alter table GRN_HEADERLOG add  TotCGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_HEADERLOG' AND  COLUMN_NAME = 'TotIGSTAmt') Begin alter table GRN_HEADERLOG add  TotIGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")

            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Grn_header' AND  COLUMN_NAME = 'TotGSTAmt') Begin alter table Grn_header add  TotGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Grn_header' AND  COLUMN_NAME = 'TotSGSTAmt') Begin alter table Grn_header add  TotSGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Grn_header' AND  COLUMN_NAME = 'TotCGSTAmt') Begin alter table Grn_header add  TotCGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Grn_header' AND  COLUMN_NAME = 'TotIGSTAmt') Begin alter table Grn_header add  TotIGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")

            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_DETAILSLOG' AND  COLUMN_NAME = 'GSTAmt') Begin alter table GRN_DETAILSLOG add  GSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_DETAILSLOG' AND  COLUMN_NAME = 'SGSTAmt') Begin alter table GRN_DETAILSLOG add  SGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_DETAILSLOG' AND  COLUMN_NAME = 'CGSTAmt') Begin alter table GRN_DETAILSLOG add  CGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_DETAILSLOG' AND  COLUMN_NAME = 'IGSTAmt') Begin alter table GRN_DETAILSLOG add  IGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_DETAILSLOG' AND  COLUMN_NAME = 'SPLCESS') Begin alter table GRN_DETAILSLOG add  SPLCESS numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")

            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Grn_details' AND  COLUMN_NAME = 'GSTAmt') Begin alter table Grn_details add  GSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Grn_details' AND  COLUMN_NAME = 'SGSTAmt') Begin alter table Grn_details add  SGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Grn_details' AND  COLUMN_NAME = 'CGSTAmt') Begin alter table Grn_details add  CGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Grn_details' AND  COLUMN_NAME = 'IGSTAmt') Begin alter table Grn_details add  IGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Grn_details' AND  COLUMN_NAME = 'SPLCESS') Begin alter table Grn_details add  SPLCESS numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRN_HEADERLOG' AND  COLUMN_NAME = 'TotGSTAmt') Begin alter table PRN_HEADERLOG add  TotGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRN_HEADERLOG' AND  COLUMN_NAME = 'TotSGSTAmt') Begin alter table PRN_HEADERLOG add  TotSGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRN_HEADERLOG' AND  COLUMN_NAME = 'TotCGSTAmt') Begin alter table PRN_HEADERLOG add  TotCGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRN_HEADERLOG' AND  COLUMN_NAME = 'TotIGSTAmt') Begin alter table PRN_HEADERLOG add  TotIGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")

            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Prn_header' AND  COLUMN_NAME = 'TotGSTAmt') Begin alter table Prn_header add  TotGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Prn_header' AND  COLUMN_NAME = 'TotSGSTAmt') Begin alter table Prn_header add  TotSGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Prn_header' AND  COLUMN_NAME = 'TotCGSTAmt') Begin alter table Prn_header add  TotCGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Prn_header' AND  COLUMN_NAME = 'TotIGSTAmt') Begin alter table Prn_header add  TotIGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")

            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRN_DETAILSLOG' AND  COLUMN_NAME = 'GSTAmt') Begin alter table PRN_DETAILSLOG add  GSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRN_DETAILSLOG' AND  COLUMN_NAME = 'SGSTAmt') Begin alter table PRN_DETAILSLOG add  SGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRN_DETAILSLOG' AND  COLUMN_NAME = 'CGSTAmt') Begin alter table PRN_DETAILSLOG add  CGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRN_DETAILSLOG' AND  COLUMN_NAME = 'IGSTAmt') Begin alter table PRN_DETAILSLOG add  IGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRN_DETAILSLOG' AND  COLUMN_NAME = 'SPLCESS') Begin alter table PRN_DETAILSLOG add  SPLCESS numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")

            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Prn_details' AND  COLUMN_NAME = 'GSTAmt') Begin alter table Prn_details add  GSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Prn_details' AND  COLUMN_NAME = 'SGSTAmt') Begin alter table Prn_details add  SGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Prn_details' AND  COLUMN_NAME = 'CGSTAmt') Begin alter table Prn_details add  CGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Prn_details' AND  COLUMN_NAME = 'IGSTAmt') Begin alter table Prn_details add  IGSTAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Prn_details' AND  COLUMN_NAME = 'SPLCESS') Begin alter table Prn_details add  SPLCESS numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            '-------------------------------------------------------------------------------------------------------------------------------


            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_LINKSETUP' AND  COLUMN_NAME = 'ROUNDUPYESNO') Begin alter table INV_LINKSETUP add ROUNDUPYESNO VARCHAR(5) End"
            gconnection.dataOperation(6, str, "AddC")

            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_LINKSETUP' AND  COLUMN_NAME = 'BatchnoReq') Begin alter table INV_LINKSETUP add BatchnoReq VARCHAR(5) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_LINKSETUP' AND  COLUMN_NAME = 'ExpiryReq') Begin alter table INV_LINKSETUP add ExpiryReq VARCHAR(5) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_LINKSETUP' AND  COLUMN_NAME = 'ShelvingReq') Begin alter table INV_LINKSETUP add ShelvingReq VARCHAR(5) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_LINKSETUP' AND  COLUMN_NAME = 'POAPPROVAL') Begin alter table INV_LINKSETUP add POAPPROVAL VARCHAR(5) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_LINKSETUP' AND  COLUMN_NAME = 'INDENTAPPROVAL') Begin alter table INV_LINKSETUP add INDENTAPPROVAL VARCHAR(5) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_LINKSETUP' AND  COLUMN_NAME = 'PO_PASSWORD') Begin alter table INV_LINKSETUP add PO_PASSWORD VARCHAR(50) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_LINKSETUP' AND  COLUMN_NAME = 'PO_ALTPASSWORD') Begin alter table INV_LINKSETUP add PO_ALTPASSWORD VARCHAR(50) End"
            gconnection.dataOperation(6, str, "AddC")

            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_LINKSETUP' AND  COLUMN_NAME = 'INDENT_PASSWORD') Begin alter table INV_LINKSETUP add INDENT_PASSWORD VARCHAR(50) End"
            gconnection.dataOperation(6, str, "AddC")


            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_LINKSETUP' AND  COLUMN_NAME = 'INDENT_ALTPASSWORD') Begin alter table INV_LINKSETUP add INDENT_ALTPASSWORD VARCHAR(50) End"
            gconnection.dataOperation(6, str, "AddC")

            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_HEADER' AND  COLUMN_NAME = 'postingAmt') Begin alter table GRN_HEADER add  postingAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_HEADER' AND  COLUMN_NAME = 'RoundupAmt') Begin alter table GRN_HEADER add  RoundupAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_HEADERLOG' AND  COLUMN_NAME = 'RoundupAmt') Begin alter table GRN_HEADERLOG add  RoundupAmt numeric(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_HEADER' AND  COLUMN_NAME = 'TOTALQTY') Begin ALTER TABLE GRN_HEADER ADD  TOTALQTY NUMERIC(18,3) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Invitem_VendorMaster' AND  COLUMN_NAME = 'fromDate') Begin ALTER TABLE Invitem_VendorMaster ADD  fromDate date End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Invitem_VendorMaster' AND  COLUMN_NAME = 'toDate') Begin ALTER TABLE Invitem_VendorMaster ADD  toDate date End"
            gconnection.dataOperation(6, str, "AddC")

            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Invitem_VendorMaster_Log' AND  COLUMN_NAME = 'fromDate') Begin ALTER TABLE Invitem_VendorMaster_Log ADD  fromDate date End"
            gconnection.dataOperation(6, str, "AddC")
            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Invitem_VendorMaster_Log' AND  COLUMN_NAME = 'toDate') Begin ALTER TABLE Invitem_VendorMaster_Log ADD  toDate date End"
            gconnection.dataOperation(6, str, "AddC")

            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Invitem_VendorMaster' AND  COLUMN_NAME = 'Autoid') Begin alter table Invitem_VendorMaster add   [Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL End"
            gconnection.dataOperation(6, str, "AddC")

            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Invitem_VendorMaster_Log' AND  COLUMN_NAME = 'Autoid') Begin alter table Invitem_VendorMaster_Log add   [Autoid] [numeric](18, 0) End"
            gconnection.dataOperation(6, str, "AddC")

            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_INVENTORYITEMMASTER' AND  COLUMN_NAME = 'SPLCESS') Begin alter table INV_INVENTORYITEMMASTER add   [SPLCESS] [numeric](18, 2) End"
            gconnection.dataOperation(6, str, "AddC")

            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_INVENTORYITEMMASTER' AND  COLUMN_NAME = 'SALEITEM') Begin alter table INV_INVENTORYITEMMASTER add   [SALEITEM] VARCHAR(10) End"
            gconnection.dataOperation(6, str, "AddC")
            str = "update INV_InventoryItemMaster set SALEITEM='NO' where ISNULL(SALEITEM,'')<>'YES' "
            gconnection.dataOperation(6, str, "AddC")

            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'invtaxgroupmasterdetail' AND  COLUMN_NAME = 'Taxtype') Begin alter table invtaxgroupmasterdetail add   [Taxtype] varchar(50) End"
            gconnection.dataOperation(6, str, "AddC")

            str = "update INV_InventoryItemMaster set batchprocess='NO' where batchprocess='YES'"
            gconnection.dataOperation(6, str, "AddC")

            str = "update invtaxgroupmasterdetail set Taxtype =typeoftax from invtaxgroupmasterdetail i inner join accountstaxmaster a on i.tax=a.taxcode"
            gconnection.dataOperation(6, str, "AddC")



            str = "update Invitem_VendorMaster set fromDate = '01/apr/" + gFinancalyearStart + "' where fromDate is null"
            gconnection.dataOperation(6, str, "AddC")

            str = "update Invitem_VendorMaster set toDate = '31/mar/" + gFinancialyearEnd + "' where toDate is null"
            gconnection.dataOperation(6, str, "AddC")

            str = "update inv_InventoryOpenningstock set fyear='01 apr " + gFinancalyearStart + "'"
            gconnection.dataOperation(6, str, "AddC")

            str = " DELETE FROM  Invitem_VendorMaster WHERE ISNULL(vendorcode,'')=''"

            gconnection.dataOperation(6, str, "AddC")

            str = " DELETE FROM  InvVendor_categorymaster WHERE ISNULL(vendorcode,'')=''"
            gconnection.dataOperation(6, str, "AddC")

            str = "IF Object_ID('Inv_UserStoreLink') IS NOT NULL    DROP VIEW Inv_UserStoreLink   "
            gconnection.dataOperation(6, str, "AddC")

            str = "create View Inv_UserStoreLink as select distinct storecode,a.categorycode,b.usercode from Invstore_CategoryMaster a inner join Categoryuserdetail b on a.categorycode=b.categorycode where isnull(Freeze,'N')<>'Y' and isnull(void,'N')<>'Y'"
            gconnection.dataOperation(6, str, "AddC")

            str = "ALTER view  [dbo].[SUPPLIERDetails] as    SELECT DISTINCT isnull(slcode,'') AS vendorcode, isnull(slname,'') AS vendorNAME,ISNULL(contactperson,'') AS contactperson,ISNULL(address1,'') AS address1,ISNULL(address2,'') AS address2,ISNULL(city,'') AS city,ISNULL(state,'') AS state,ISNULL(PIN,0) AS pIN , ISNULL(phoneno,0) AS PhONENO  ,ISNULL(GSTINNO,'') AS GSTINNO ,ISNULL(VENDORTYPE,'') AS VENDORTYPE FROM ACCOUNTSSUBLEDGERMASTER A INNER JOIN ACCOUNTSSETUP B ON A.accode=B.ScrsCode  WHERE sltype='SUPPLIER'  and isnull(freezeflag,'N')<>'Y' "
            gconnection.dataOperation(6, str, "AddC")


            If gpocode.ToUpper() = "Y" Then

                str = "IF Object_ID('VwPendingPO_HDR') IS NOT NULL    DROP VIEW VwPendingPO_HDR  "
                gconnection.dataOperation(6, str, "AddC")

                str = "CREATE view VwPendingPO_HDR as  select * from PO_HDR  WHERE ISNULL(FREEZE,'N')<>'Y' AND  postatus ='RELEASED' AND (CAST(GETDATE() AS DATE) BETWEEN CAST(POVALIDFROM AS dATE) AND CAST(POVALIDUPTO AS DATE))"
                gconnection.dataOperation(6, str, "AddC")

                str = "IF Object_ID('ViewPendingPO') IS NOT NULL    DROP VIEW ViewPendingPO "
                gconnection.dataOperation(6, str, "AddC")

                str = "CREATE view ViewPendingPO as SELECT ISNULL(pono,'') AS PONO,ISNULL(podate,'')AS PODATE,ISNULL(podepartment,'') AS PODEPARTMENT FROM VwPendingPO_HDR where PONO NOT IN (SELECT PONO FROM GRN_HEADER where isnull(Void,'N')<>'Y') union all SELECT ISNULL(pono,'') AS PONO,ISNULL(podate,'')AS PODATE,ISNULL(podepartment,'') AS PODEPARTMENT FROM VwPendingPO_HDR WHERE PONO  IN (select pono from PO_ITEMDETAILS  a where ITEMCODE not in  (select itemcode from Grn_details c where a.pono=c.pono  )) union all SELECT ISNULL(pono,'') AS PONO,ISNULL(podate,'')AS PODATE,ISNULL(podepartment,'') AS PODEPARTMENT FROM VwPendingPO_HDR WHERE PONO  IN (select pono from PO_ITEMDETAILS a where  receivedqty<Quantity)"
                gconnection.dataOperation(6, str, "AddC")
                If gShortname <> "BGC" Or gShortname <> "BRC" Then
                    str = " ALTER VIEW [dbo].[VW_POBILL] AS      SELECT      dbo.PO_HDR.pono, dbo.PO_HDR.doctype, dbo.PO_HDR.storecode, dbo.PO_HDR.podate, dbo.PO_HDR.poquotno, dbo.PO_HDR.povendorcode,   dbo.PO_HDR.podepartment, dbo.PO_HDR.potype, dbo.PO_HDR.povalidfrom, dbo.PO_HDR.povalidupto, dbo.PO_ITEMDETAILS.ITEMCODE, dbo.PO_ITEMDETAILS.ITEMNAME, dbo.PO_ITEMDETAILS.UOM, dbo.PO_ITEMDETAILS.QUANTITY, dbo.PO_ITEMDETAILS.baseamount,  dbo.PO_ITEMDETAILS.Rate,    dbo.PO_ITEMDETAILS.discper, dbo.PO_ITEMDETAILS.taxper, dbo.PO_ITEMDETAILS.discamt,  dbo.PO_ITEMDETAILS.vatamt, dbo.PO_ITEMDETAILS.TOTALamount,    dbo.PO_ITEMDETAILS.taxcode,dbo.PO_ITEMDETAILS.amountafterdiscount,  dbo.PO_ITEMDETAILS.othchg, dbo.PO_HDR.versionno, dbo.PO_HDR.POOVERALLDISC,dbo.PO_HDR.pobalance, dbo.PO_HDR.poadvance,   dbo.PO_HDR.pototaldiscount, dbo.PO_HDR.pototaltax, dbo.PO_HDR.pototalvat, dbo.PO_HDR.povalue,    dbo.PO_HDR.pootherchgplus,   dbo.PO_HDR.pootherchgmin, dbo.PO_HDR.POtransport, dbo.PO_HDR.postatus,iv.vendorNAME AS vendorNAME, ISNULL(IV.contactperson,'') AS contactperson,ISNULL(IV.address1,'') AS address1,ISNULL(IV.address2,'') AS address2,  ISNULL(IV.city,'') AS city,ISNULL(IV.state,'') AS state,ISNULL(IV.PIN,'') AS pIN , ISNULL(IV.phoneno,'') AS PhONENO, ISNULL(GSTINNO,'') AS GSTINNO ,ISNULL(VENDORTYPE,'') AS VENDORTYPE , isnull(dbo.PO_HDR.podelivery,'') as podelivery,dbo.PO_HDR.poremarks as remarks,isnull((SELECT ISNULL(PAYMENTTERMDESC,'') AS PAYMENTTERMDESC FROM PO_PAYMENTTERMS where PAYMENTTERMCODE=poterms),'') as poterms,ISNULL(CGSTAmt,0) AS CGSTAmt,ISNULL(SGSTAmt,0) AS SGSTAmt,ISNULL(IGSTAmt,0 )AS IGSTAmt , ISNULL(GSTAmt,0 )AS GSTAmt ,ISNULL(I.HSNNO,'') AS HSNNO,ISNULL(I.TAXTYPE,'') AS  TAXTYPE  ,ISNULL(dbo.PO_ITEMDETAILS .SPLCESS,0) AS SPLCESS  FROM         dbo.PO_HDR  INNER JOIN dbo.PO_ITEMDETAILS ON dbo.PO_HDR.pono = dbo.PO_ITEMDETAILS.pono   INNER JOIN SUPPLIERDetails iv on PO_HDR.povendorcode=iv.vendorcode  INNER JOIN INV_InventoryItemMaster I ON I.itemcode=dbo.PO_ITEMDETAILS.Itemcode  WHERE ISNULL(postatus,'') <>'AMENDED'"
                    gconnection.dataOperation(6, str, "AddC")
                End If
            End If

            'str = "ALTER VIEW [dbo].[VW_PURCHASEREGISTERNew]     "

            'str = str & "AS       "

            'str = str & "SELECT       "

            'str = str & "dbo.Grn_details.grnno, dbo.Grn_details.grndetails,     "

            'str = str & "dbo.Grn_details.grndate, dbo.Grn_details.pono, isnull(dbo.GRN_HEADER.Supplierinvno,'') as Supplierinvno, dbo.Grn_details.Suppliercode,    "
            'str = str & "dbo.Grn_details.Suppliername,    "
            'str = str & "dbo.Grn_details.Itemcode, dbo.Grn_details.Itemname, dbo.Grn_details.uom, Grn_details.qty, dbo.Grn_details.rate,    "
            'str = str & "dbo.Grn_details.baseamount, dbo.Grn_details.discper, dbo.Grn_details.taxper, dbo.Grn_details.Discount, dbo.Grn_details.taxamount, Grn_details.amount,     "
            'str = str & "dbo.Grn_details.taxcode, dbo.Grn_details.batchno, dbo.Grn_details.othcharge, dbo.Grn_details.Voiditem, dbo.Grn_details.category,     "
            'str = str & "dbo.Grn_details.storecode,dbo.Grn_details.storedesc, dbo.Grn_details.versionno, dbo.Grn_details.grntype,dbo.Grn_details.amount as amountafterdiscount,     "
            'str = str & "dbo.Grn_header.Totalamount, dbo.Grn_header.VATamount, dbo.Grn_header.Surchargeamt, dbo.Grn_header.OverallDiscount, dbo.Grn_header.Discount AS totdiscount,    "
            'str = str & "dbo.Grn_header.Billamount,  dbo.Grn_header.Remarks, dbo.Grn_header.Void, dbo.Grn_header.updateuser, dbo.Grn_header.updatedate, dbo.Grn_header.voiduser,     "
            'str = str & "dbo.Grn_header.voiddate  ,'' as opstorelocationcode,'' as opstorelocationname  ,  "
            'str = str & "isnull(dbo.Grn_header.Supplierdate,'') as Supplierdate  ,ISNULL(dbo.Grn_details.SPONSORCODE,'') AS SPONSORCODE "

            'str = str & "FROM  dbo.Grn_details INNER JOIN      dbo.Grn_header ON dbo.Grn_details.grndetails = dbo.Grn_header.grndetails     "
            'str = str & "where dbo.Grn_details.grndetails not in (select BATCHNO from STOCKISSUEDETAIL where  STOCKISSUEDETAIL.Itemcode=dbo.Grn_details.Itemcode AND ISNULL(STOCKISSUEDETAIL.VOID,'')<>'Y')  "

            'str = str & "  union all "

            'str = str & "SELECT    dbo.Grn_details.grnno, dbo.Grn_details.grndetails,         "
            'str = str & "dbo.Grn_details.grndate, dbo.Grn_details.pono, isnull(dbo.GRN_HEADER.Supplierinvno,'') as Supplierinvno, dbo.Grn_details.Suppliercode,    "
            'str = str & "dbo.Grn_details.Suppliername,    "
            'str = str & "dbo.Grn_details.Itemcode, dbo.Grn_details.Itemname, dbo.Grn_details.uom, t.qty, dbo.Grn_details.rate,    "
            'str = str & "(dbo.Grn_details.rate*t.qty) as baseamount, dbo.Grn_details.discper, dbo.Grn_details.taxper, (dbo.Grn_details.Discount/Grn_details.qty)* t.qty as Discount, "
            'str = str & "(dbo.Grn_details.taxamount/Grn_details.qty)* t.qty  as taxamount,"
            'str = str & "((dbo.Grn_details.baseamount/Grn_details.qty)* t.qty)-((dbo.Grn_details.Discount/Grn_details.qty)* t.qty)+ ((dbo.Grn_details.taxamount/Grn_details.qty)* t.qty) as amount,     "
            'str = str & "dbo.Grn_details.taxcode, dbo.Grn_details.batchno, dbo.Grn_details.othcharge, dbo.Grn_details.Voiditem, dbo.Grn_details.category,     "
            'str = str & "dbo.Grn_details.storecode,dbo.Grn_details.storedesc, dbo.Grn_details.versionno, dbo.Grn_details.grntype,(dbo.Grn_details.amount/Grn_details.qty)* t.qty as amountafterdiscount,     "
            'str = str & "dbo.Grn_header.Totalamount, dbo.Grn_header.VATamount, dbo.Grn_header.Surchargeamt, dbo.Grn_header.OverallDiscount, dbo.Grn_header.Discount AS totdiscount,    "
            'str = str & "dbo.Grn_header.Billamount,  dbo.Grn_header.Remarks, dbo.Grn_header.Void, dbo.Grn_header.updateuser, dbo.Grn_header.updatedate, dbo.Grn_header.voiduser,     "
            'str = str & "dbo.Grn_header.voiddate  ,t.opstorelocationcode as opstorelocationcode,t.opstorelocationname as opstorelocationname  ,  "
            'str = str & "isnull(dbo.Grn_header.Supplierdate,'') as Supplierdate,ISNULL(dbo.Grn_details.SPONSORCODE,'') AS SPONSORCODE "

            'str = str & "FROM  dbo.Grn_details INNER JOIN      dbo.Grn_header ON dbo.Grn_details.grndetails = dbo.Grn_header.grndetails      "
            'str = str & "inner JOIN STOCKISSUEDETAIL t on t.Itemcode=dbo.Grn_details.Itemcode   AND t.BATCHNO=dbo.Grn_details.grndetails AND ISNULL(T.VOID,'')<>'Y'      "
            'gconnection.dataOperation(6, str, "AddC")

            str = "Select * from sysobjects where name='INV_TMPVW1' and xtype='U'"
            gconnection.getDataSet(str, "INV_TMPVW1")
            If gdataset.Tables("INV_TMPVW1").Rows.Count > 0 Then

            Else
                str = " CREATE TABLE [dbo].[INV_TMPVW1]("

                str = str & "[AUTOID] [INT] IDENTITY(1,1),"
                str = str & " [DOCDETAILS] [varchar](50) NULL,"
                str = str & " [ITEMCODE] [varchar](50) NULL,"
                str = str & " [ITEMname] [varchar](75) NULL,"
                str = str & " [docdate] [datetime] NULL,"
                str = str & " [UOM] [varchar](50) NULL,"
                str = str & " [qty] [numeric](38, 10) NULL,"
                str = str & " [RATE] [numeric](19, 3) NULL,"
                str = str & " [AMOUNT] [numeric](37, 6) NULL,"
                str = str & " [clsstock] [numeric](18, 3) NULL,"
                str = str & " [type] [varchar](50) NULL,"
                str = str & " [storecode] [varchar](50) NULL,"
                str = str & " [tostorecode] [varchar](50) NULL,"
                str = str & " [location] [varchar](50) NULL,"
                str = str & " [CATEGORY] [varchar](30) NULL,"
                str = str & " [RATEFLAG] [varchar](10) NULL,"
                str = str & " [LASTSTOCK] [numeric](18, 3) NULL,"
                str = str & " [LASTRATE] [numeric](19, 3) NULL,"
                str = str & " [PRIORITY] [int] NOT NULL"

                str = str & " ) ON [PRIMARY]"
                gconnection.dataOperation1(6, str, "INVENTORY_TRANSCONVERSION")

            End If

            str = "Select * from sysobjects where name='INV_WEIGHTED_final_tabNEW' and xtype='U'"
            gconnection.getDataSet(str, "INV_WEIGHTED_final_tabNEW")
            If gdataset.Tables("INV_WEIGHTED_final_tabNEW").Rows.Count > 0 Then

            Else
                str = " CREATE TABLE [dbo].[INV_WEIGHTED_final_tabNEW]("
                str = str & " [DOCDETAILS] [varchar](50) NULL,"
                str = str & " [ITEMCODE] [varchar](50) NULL,"
                str = str & " [ITEMname] [varchar](200) NULL,"
                str = str & " [docdate] [datetime] NULL,"
                str = str & " [UOM] [varchar](50) NULL,"
                str = str & " [qty] [numeric](18, 6) NULL,"
                str = str & " [RATE] [numeric](18, 6) NULL,"
                str = str & " [clsstock] [numeric](18, 6) NULL,"
                str = str & " [type] [varchar](50) NULL,"
                str = str & " [storecode] [varchar](50) NULL,"
                str = str & " [CATEGORY] [varchar](30) NULL,"
                str = str & " [RATEFLAG] [varchar](10) NULL,"
                str = str & " [LASTSTOCK] [numeric](18, 6) NULL,"
                str = str & " [LASTRATE] [numeric](18, 6) NULL,"
                str = str & " [PRIORITY] [int]  NULL"
                str = str & "  [rowid] [Int] NULL"
                str = str & "   [WEIGHTED_RATE] [numeric](18, 6) NULL"
                str = str & " ) ON [PRIMARY]"
                gconnection.dataOperation1(6, str, "INVENTORY_TRANSCONVERSION")
            End If

            str = "Select * from sysobjects where name='SPI_INV_WEIGHTED_VIEW1' and xtype='P'"
            gconnection.getDataSet(str, "SPI_INV_WEIGHTED_VIEW1")
            If gdataset.Tables("SPI_INV_WEIGHTED_VIEW1").Rows.Count > 0 Then

            Else


                str = " create procedure SPI_INV_WEIGHTED_VIEW1"
                str = " ("
                str = "  @items TpItems Readonly,"
                str = " @TransDate Date,"
                str = " @TmpNm varchar(50),"
                str = " @location VARCHAR(10)"

                str = " )as"
                str = "    begin"

                str = " declare @sqlstr nvarchar(2000)"

                str = " TRUNCATE TABLE INV_TMPVW1"

                str = " IF @location='M'"

                str = " INSERT INTO INV_TMPVW1 (DOCDETAILS,ITEMCODE, ITEMNAME, DOCDATE,UOM, QTY, RATE, AMOUNT, CLSSTOCK, TYPE, STORECODE,location, CATEGORY, "
                str = " LASTSTOCK, LASTRATE, PRIORITY,RATEFLAG )"
                str = " SELECT DOCDETAILS,ITEMCODE, ITEMNAME, DOCDATE AS DOCDATE,UOM, QTY, ISNULL(RATE,0) AS rATE, AMOUNT, CLSSTOCK, TYPE, STORECODE,location, CATEGORY, LASTSTOCK, "
                str = " LASTRATE, PRIORITY ,ISNULL(RATEFLAG,'P')AS RATEFLAG FROM dbo.UDF_INV_WEIGHTED_VIEW1(@TransDate,@items)  WHERE  location='M'  "
                str = " ORDER BY STORECODE, ITEMCODE,CAST(DOCDATE AS DATE), PRIORITY,ADDDATE"

                str = " ELSE   "
                str = "    INSERT INTO INV_TMPVW1 (DOCDETAILS,ITEMCODE, ITEMNAME, DOCDATE,UOM, QTY, RATE, AMOUNT, CLSSTOCK, TYPE, STORECODE,location, CATEGORY, "
                str = " LASTSTOCK, LASTRATE, PRIORITY,RATEFLAG )"
                str = " SELECT DOCDETAILS,ITEMCODE, ITEMNAME, DOCDATE AS DOCDATE,UOM, QTY, ISNULL(RATE,0) AS rATE, AMOUNT, CLSSTOCK, TYPE, STORECODE,location, CATEGORY, LASTSTOCK, "
                str = " LASTRATE, PRIORITY ,ISNULL(RATEFLAG,'P')AS RATEFLAG FROM dbo.UDF_INV_WEIGHTED_VIEW1(@TransDate,@items)  WHERE  location='S'  "
                str = " ORDER BY STORECODE, ITEMCODE,CAST(DOCDATE AS DATE), PRIORITY,ADDDATE"


                str = " set @sqlstr = 'INSERT INTO ' + @TmpNm + ' (DOCDETAILS,ITEMCODE, ITEMNAME, DOCDATE,UOM, QTY, RATE, AMOUNT, CLSSTOCK, TYPE, STORECODE,location, CATEGORY, "
                str = " LASTSTOCK, LASTRATE, PRIORITY,RATEFLAG )  "
                str = " SELECT DOCDETAILS,ITEMCODE, ITEMNAME, DOCDATE AS DOCDATE,UOM, QTY, ISNULL(RATE,0) AS rATE, AMOUNT, CLSSTOCK, TYPE, STORECODE,location, CATEGORY, LASTSTOCK, "
                str = " LASTRATE, PRIORITY ,ISNULL(RATEFLAG,''P'')AS RATEFLAG FROM INV_TMPVW1 ORDER BY AUTOID'"


                str = " exec sp_executesql  @sqlstr"

                str = "          End"


                gconnection.dataOperation1(6, str, "cp_stockdamage")


            End If
            If gShortname <> "BGC" Or gShortname <> "BRC" Then
                str = " ALTER VIEW [dbo].[VW_POBILL] AS      SELECT      dbo.PO_HDR.pono, dbo.PO_HDR.doctype, dbo.PO_HDR.storecode, dbo.PO_HDR.podate, dbo.PO_HDR.poquotno, dbo.PO_HDR.povendorcode,   dbo.PO_HDR.podepartment, dbo.PO_HDR.potype, dbo.PO_HDR.povalidfrom, dbo.PO_HDR.povalidupto, dbo.PO_ITEMDETAILS.ITEMCODE, dbo.PO_ITEMDETAILS.ITEMNAME, dbo.PO_ITEMDETAILS.UOM, dbo.PO_ITEMDETAILS.QUANTITY, dbo.PO_ITEMDETAILS.baseamount,  dbo.PO_ITEMDETAILS.Rate,    dbo.PO_ITEMDETAILS.discper, dbo.PO_ITEMDETAILS.taxper, dbo.PO_ITEMDETAILS.discamt,  dbo.PO_ITEMDETAILS.vatamt, dbo.PO_ITEMDETAILS.TOTALamount,    dbo.PO_ITEMDETAILS.taxcode,dbo.PO_ITEMDETAILS.amountafterdiscount,  dbo.PO_ITEMDETAILS.othchg, dbo.PO_HDR.versionno, dbo.PO_HDR.POOVERALLDISC,dbo.PO_HDR.pobalance, dbo.PO_HDR.poadvance,   dbo.PO_HDR.pototaldiscount, dbo.PO_HDR.pototaltax, dbo.PO_HDR.pototalvat, dbo.PO_HDR.povalue,    dbo.PO_HDR.pootherchgplus,   dbo.PO_HDR.pootherchgmin, dbo.PO_HDR.POtransport, dbo.PO_HDR.postatus,iv.vendorNAME AS vendorNAME, ISNULL(IV.contactperson,'') AS contactperson,ISNULL(IV.address1,'') AS address1,ISNULL(IV.address2,'') AS address2,  ISNULL(IV.city,'') AS city,ISNULL(IV.state,'') AS state,ISNULL(IV.PIN,'') AS pIN , ISNULL(IV.phoneno,'') AS PhONENO, ISNULL(GSTINNO,'') AS GSTINNO ,ISNULL(VENDORTYPE,'') AS VENDORTYPE , isnull(dbo.PO_HDR.podelivery,'') as podelivery,dbo.PO_HDR.poremarks as remarks,isnull((SELECT ISNULL(PAYMENTTERMDESC,'') AS PAYMENTTERMDESC FROM PO_PAYMENTTERMS where PAYMENTTERMCODE=poterms),'') as poterms,ISNULL(CGSTAmt,0) AS CGSTAmt,ISNULL(SGSTAmt,0) AS SGSTAmt,ISNULL(IGSTAmt,0 )AS IGSTAmt , ISNULL(GSTAmt,0 )AS GSTAmt ,ISNULL(I.HSNNO,'') AS HSNNO,ISNULL(I.TAXTYPE,'') AS  TAXTYPE  ,ISNULL(dbo.PO_ITEMDETAILS .SPLCESS,0) AS SPLCESS  FROM         dbo.PO_HDR  INNER JOIN dbo.PO_ITEMDETAILS ON dbo.PO_HDR.pono = dbo.PO_ITEMDETAILS.pono   INNER JOIN SUPPLIERDetails iv on PO_HDR.povendorcode=iv.vendorcode  INNER JOIN INV_InventoryItemMaster I ON I.itemcode=dbo.PO_ITEMDETAILS.Itemcode  WHERE ISNULL(postatus,'') <>'AMENDED'"
                gconnection.dataOperation(6, str, "AddC")


            End If
            str = "ALTER VIEW [dbo].[VW_INV_IDENTBILL] As     SELECT  ISNULL(HDR.INDENT_NO,'') INDENT_NO, ISNULL(HDR.INDENT_DATE,'')  INDENT_DATE, ISNULL(HDR.FROMSTORECODE,'') FROMSTORECODE , ISNULL(HDR.STORELOCATIONCODE,'') STORELOCATIONCODE,  ISNULL(HDR.STORELOCATIONNAME,'') STORELOCATIONNAME,  ISNULL(HDR.REMARKS,'') REMARKS,  ISNULL(ITEMCODE,'') ITEMCODE, ISNULL(ITEMNAME,'') ITEMNAME, ISNULL(UOM,'') UOM,  ISNULL(QTY,0) QTY , ISNULL(DET.ADDDATEtime,'') ADDDATE  ,  ISNULL(hdr.ADDUSER,'') ADDUSER,ISNULL((select top 1 rate from closingqty where itemcode=DET.ITEMCODE and storecode=hdr.fromStoreCode and Trndate<=HDR.INDENT_DATE ORDER BY Autoid DESC),0) as RATE    ,QTY*ISNULL((select top 1 rate from closingqty where itemcode=DET.ITEMCODE and storecode=hdr.fromStoreCode and Trndate<=HDR.INDENT_DATE ORDER BY Autoid DESC),0) as AMOUNT,isnull(hdr.adduser,'')as adduser , ISNULL(CLSQTY,0) CLSQTY      FROM INVENTORY_INDENTHDR HDR            INNER JOIN INVENTORY_INDENTDET AS DET ON HDR.INDENT_NO = DET.INDENT_NO "
            gconnection.dataOperation(6, str, "AddC")

            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Grn_details' AND  COLUMN_NAME = 'VENDOR_TYPE')  Begin alter table Grn_details add  VENDOR_TYPE VARCHAR(50) End"
            gconnection.dataOperation(6, str, "AddC")

            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Grn_details' AND  COLUMN_NAME = 'TAX_TYPE')  Begin alter table Grn_details add  TAX_TYPE VARCHAR(50) End"
            gconnection.dataOperation(6, str, "AddC")

            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Grn_details' AND  COLUMN_NAME = 'ITEM_TYPE')  Begin alter table Grn_details add  ITEM_TYPE VARCHAR(50) End"
            gconnection.dataOperation(6, str, "AddC")

            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PO_deliveryterms' AND  COLUMN_NAME = 'deliverytermdesc')  Begin alter table PO_deliveryterms add  deliverytermdesc VARCHAR(500) End"
            gconnection.dataOperation(6, str, "AddC")

            str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PO_DELIVERYTERMS_DET' )  Begin CREATE TABLE PO_DELIVERYTERMS_DET (  AUTOID INT IDENTITY (1,1),  PONO VARCHAR(100),  SNO INT,  PODELIVERYTERMS VARCHAR(50),  PODELIVERY VARCHAR(500) ) End"
            gconnection.dataOperation(6, str, "AddC")

            If gShortname <> "KGA" Or gShortname <> "FNCC" Or gShortname <> "VFNCC" Then
                str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'STOCKISSUEHEADER' AND  COLUMN_NAME = 'partybookingno')  Begin alter table STOCKISSUEHEADER add  partybookingno VARCHAR(20) End"
                gconnection.dataOperation(6, str, "AddC")
                str = " alter VIEW  [dbo].[VW_INV_ISSUEBILL] AS SELECT TOP 100 PERCENT dbo.stockissueheader.docdetails,   dbo.stockissueheader.docdate, dbo.stockissueheader.storelocationname, dbo.stockissueheader.opstorelocationname,   dbo.stockissuedetail.itemcode, dbo.stockissueheader.storelocationcode,dbo.stockissueheader.opstorelocationcode,   dbo.stockissuedetail.itemname, dbo.stockissuedetail.uom,dbo.stockissuedetail.qty , dbo.stockissuedetail.rate,    dbo.stockissuedetail.amount , dbo.stockissueheader.indentno ,  dbo.stockissueheader.indentdate,   dbo.stockissueheader.remarks,isnull(dbo.stockissueheader.partybookingno,'') as partybookingno FROM dbo.stockissuedetail INNER JOIN dbo.stockissueheader     ON dbo.stockissuedetail.docdetails = dbo.stockissueheader.docdetails "
                gconnection.dataOperation(6, str, "AddC")
            End If


        End If

        str = "update inv_InventoryOpenningstock set fyear='01 apr " + gFinancalyearStart + "'"
        gconnection.dataOperation(6, str, "AddC")


        str = "delete from  stockConsumption_1  where consumption<=0 and ISNULL(void,'N')='N'"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'pRN_HEADER' AND  COLUMN_NAME = 'postingAmt') Begin alter table PRN_HEADER add  postingAmt numeric(18,3) End"
        gconnection.dataOperation(6, str, "AddC")
        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRN_HEADER' AND  COLUMN_NAME = 'RoundupAmt') Begin alter table PRN_HEADER add  RoundupAmt numeric(18,3) End"
        gconnection.dataOperation(6, str, "AddC")
        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRN_HEADERLOG' AND  COLUMN_NAME = 'RoundupAmt') Begin alter table PRN_HEADERLOG add  RoundupAmt numeric(18,3) End"
        gconnection.dataOperation(6, str, "AddC")
        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRN_HEADER' AND  COLUMN_NAME = 'TOTALQTY') Begin ALTER TABLE pRN_HEADER ADD  TOTALQTY NUMERIC(18,3) End"
        gconnection.dataOperation(6, str, "AddC")
        str = "IF NOT EXISTS( SELECT * FROM master. INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'CLUBMASTER' AND  COLUMN_NAME = 'HISTORY') Begin ALTER TABLE master..CLUBMASTER ADD  HISTORY VARCHAR(20) End"
        gconnection.dataOperation(6, str, "AddC")



        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Prn_details' AND  COLUMN_NAME = 'VENDOR_TYPE')  Begin alter table Prn_details add  VENDOR_TYPE VARCHAR(50) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Prn_details' AND  COLUMN_NAME = 'TAX_TYPE')  Begin alter table Prn_details add  TAX_TYPE VARCHAR(50) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Prn_details' AND  COLUMN_NAME = 'ITEM_TYPE')  Begin alter table Prn_details add  ITEM_TYPE VARCHAR(50) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRN_HEADER' AND  COLUMN_NAME = 'LoadingCharge')  Begin alter table PRN_HEADER add  LoadingCharge numeric(18,3) End"
        gconnection.dataOperation(6, str, "AddC")
        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRN_DETAILS' AND  COLUMN_NAME = 'LoadingChg')  Begin alter table Prn_details add  LoadingChg numeric(18,8) End"
        gconnection.dataOperation(6, str, "AddC")


        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Prn_details' AND  COLUMN_NAME = 'SPONSORCODE')  Begin alter table Prn_details add  SPONSORCODE VARCHAR(50) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Prn_details' AND  COLUMN_NAME = 'COMPANYcode')  Begin alter table Prn_details add  COMPANYcode VARCHAR(50) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRN_DETAILS' AND  COLUMN_NAME = 'CESSAMT') Begin alter table PRN_DETAILS add  CESSAMT numeric(18,3) End "
        gconnection.dataOperation(6, str, "AddC")



        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRN_DETAILSLOG' AND  COLUMN_NAME = 'VENDOR_TYPE')  Begin alter table PRN_DETAILSLOG add  VENDOR_TYPE VARCHAR(50) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRN_DETAILSLOG' AND  COLUMN_NAME = 'TAX_TYPE')  Begin alter table PRN_DETAILSLOG add  TAX_TYPE VARCHAR(50) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRN_DETAILSLOG' AND  COLUMN_NAME = 'ITEM_TYPE')  Begin alter table PRN_DETAILSLOG add  ITEM_TYPE VARCHAR(50) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRN_DETAILSLOG' AND  COLUMN_NAME = 'LoadingChg')  Begin alter table PRN_DETAILSLOG add  LoadingChg numeric(18,8) End"
        gconnection.dataOperation(6, str, "AddC")


        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRN_DETAILSLOG' AND  COLUMN_NAME = 'SPONSORCODE')  Begin alter table PRN_DETAILSLOG add  SPONSORCODE VARCHAR(50) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRN_DETAILSLOG' AND  COLUMN_NAME = 'COMPANYcode')  Begin alter table PRN_DETAILSLOG add  COMPANYcode VARCHAR(50) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRN_DETAILSLOG' AND  COLUMN_NAME = 'CESSAMT') Begin alter table PRN_DETAILSLOG add  CESSAMT numeric(18,3) End "
        gconnection.dataOperation(6, str, "AddC")


        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRN_HEADER' AND  COLUMN_NAME = 'TOTCESSAMT') Begin alter table PRN_HEADER add  TOTCESSAMT numeric(18,3) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRN_HEADER' AND  COLUMN_NAME = 'TOTSPLCESS') Begin alter table PRN_HEADER add  TOTSPLCESS numeric(18,3) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRN_HEADERLOG' AND  COLUMN_NAME = 'TOTSPLCESS') Begin alter table PRN_HEADERLOG add  TOTCESSAMT numeric(18,3) alter table PRN_HEADERLOG add  TOTSPLCESS numeric(18,3) End "
        gconnection.dataOperation(6, str, "AddC")
        If gShortname <> "BGC" Or gShortname <> "BRC" Then
            str = " ALTER VIEW [dbo].[VW_POBILL] AS      SELECT      dbo.PO_HDR.pono, dbo.PO_HDR.doctype, dbo.PO_HDR.storecode, dbo.PO_HDR.podate, dbo.PO_HDR.poquotno, dbo.PO_HDR.povendorcode,   dbo.PO_HDR.podepartment, dbo.PO_HDR.poquotdate as POtYpE, dbo.PO_HDR.povalidfrom, dbo.PO_HDR.povalidupto, dbo.PO_ITEMDETAILS.ITEMCODE, dbo.PO_ITEMDETAILS.ITEMNAME, dbo.PO_ITEMDETAILS.UOM, dbo.PO_ITEMDETAILS.QUANTITY, dbo.PO_ITEMDETAILS.baseamount,  dbo.PO_ITEMDETAILS.Rate,    dbo.PO_ITEMDETAILS.discper, dbo.PO_ITEMDETAILS.taxper, dbo.PO_ITEMDETAILS.discamt,  dbo.PO_ITEMDETAILS.vatamt, dbo.PO_ITEMDETAILS.TOTALamount,    dbo.PO_ITEMDETAILS.taxcode,dbo.PO_ITEMDETAILS.amountafterdiscount,  dbo.PO_ITEMDETAILS.othchg, dbo.PO_HDR.versionno, dbo.PO_HDR.POOVERALLDISC,dbo.PO_HDR.pobalance, dbo.PO_HDR.poadvance,   dbo.PO_HDR.pototaldiscount, dbo.PO_HDR.pototaltax, dbo.PO_HDR.pototalvat, dbo.PO_HDR.povalue,    dbo.PO_HDR.pootherchgplus,   dbo.PO_HDR.pootherchgmin, dbo.PO_HDR.POtransport, dbo.PO_HDR.postatus,iv.vendorNAME AS vendorNAME, ISNULL(IV.contactperson,'') AS contactperson,ISNULL(IV.address1,'') AS address1,ISNULL(IV.address2,'') AS address2,  ISNULL(IV.city,'') AS city,ISNULL(IV.state,'') AS state,ISNULL(IV.PIN,'') AS pIN , ISNULL(IV.phoneno,'') AS PhONENO, ISNULL(GSTINNO,'') AS GSTINNO ,ISNULL(VENDORTYPE,'') AS VENDORTYPE , isnull(dbo.PO_HDR.podelivery,'') as podelivery,dbo.PO_HDR.poremarks as remarks,isnull((SELECT ISNULL(PAYMENTTERMDESC,'') AS PAYMENTTERMDESC FROM PO_PAYMENTTERMS where PAYMENTTERMCODE=poterms),'') as poterms,ISNULL(CGSTAmt,0) AS CGSTAmt,ISNULL(SGSTAmt,0) AS SGSTAmt,ISNULL(IGSTAmt,0 )AS IGSTAmt , ISNULL(GSTAmt,0 )AS GSTAmt ,ISNULL(I.HSNNO,'') AS HSNNO,ISNULL(I.TAXTYPE,'') AS  TAXTYPE  ,ISNULL(dbo.PO_ITEMDETAILS .SPLCESS,0) AS SPLCESS  FROM         dbo.PO_HDR  INNER JOIN dbo.PO_ITEMDETAILS ON dbo.PO_HDR.pono = dbo.PO_ITEMDETAILS.pono   INNER JOIN SUPPLIERDetails iv on PO_HDR.povendorcode=iv.vendorcode  INNER JOIN INV_InventoryItemMaster I ON I.itemcode=dbo.PO_ITEMDETAILS.Itemcode  WHERE ISNULL(postatus,'') <>'AMENDED'"
            gconnection.dataOperation(6, str, "AddC")

        End If

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_HEADER' AND  COLUMN_NAME = 'LoadingCharge')  Begin alter table GRN_HEADER add  LoadingCharge numeric(18,3) End"
        gconnection.dataOperation(6, str, "AddC")
        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_DETAILS' AND  COLUMN_NAME = 'LoadingChg')  Begin alter table Grn_details add  LoadingChg numeric(18,8) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_HEADER' AND  COLUMN_NAME = 'TotSPLCess')  Begin alter table GRN_HEADER add  TotSPLCess numeric(18,3) End"
        gconnection.dataOperation(6, str, "AddC")


        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'stockConsumption_1' AND  COLUMN_NAME = 'adduser') Begin alter table stockConsumption_1 add  adduser varchar(100) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_INVENTORYITEMMASTER' AND  COLUMN_NAME = 'WM_YN') Begin alter table INV_INVENTORYITEMMASTER add  WM_YN varchar(1) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_LINKSETUP' AND  COLUMN_NAME = 'trans_itemcode') Begin alter table INV_LINKSETUP add trans_itemcode varchar (20) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'grn_details' AND  COLUMN_NAME = 'TRANS_AMOUNT') Begin alter table grn_details  ADD TRANS_AMOUNT NUMERIC (18,2) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'grn_detailsLOG' AND  COLUMN_NAME = 'TRANS_AMOUNT') Begin alter table grn_detailsLOG  ADD TRANS_AMOUNT NUMERIC (18,2) End"
        gconnection.dataOperation(6, str, "AddC")
        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_LINKSETUP' AND  COLUMN_NAME = 'BatchnoReq') Begin alter table INV_LINKSETUP add BatchnoReq VARCHAR(5) End"
        gconnection.dataOperation(6, str, "AddC")
        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_LINKSETUP' AND  COLUMN_NAME = 'ExpiryReq') Begin alter table INV_LINKSETUP add ExpiryReq VARCHAR(5) End"
        gconnection.dataOperation(6, str, "AddC")
        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_LINKSETUP' AND  COLUMN_NAME = 'ShelvingReq') Begin alter table INV_LINKSETUP add ShelvingReq VARCHAR(5) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_LINKSETUP' AND  COLUMN_NAME = 'POAPPROVAL') Begin alter table INV_LINKSETUP add POAPPROVAL VARCHAR(5) End"
        gconnection.dataOperation(6, str, "AddC")
        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_LINKSETUP' AND  COLUMN_NAME = 'INDENTAPPROVAL') Begin alter table INV_LINKSETUP add INDENTAPPROVAL VARCHAR(5) End"
        gconnection.dataOperation(6, str, "AddC")
        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_LINKSETUP' AND  COLUMN_NAME = 'PO_PASSWORD') Begin alter table INV_LINKSETUP add PO_PASSWORD VARCHAR(50) End"
        gconnection.dataOperation(6, str, "AddC")
        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_LINKSETUP' AND  COLUMN_NAME = 'PO_ALTPASSWORD') Begin alter table INV_LINKSETUP add PO_ALTPASSWORD VARCHAR(50) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_LINKSETUP' AND  COLUMN_NAME = 'INDENT_PASSWORD') Begin alter table INV_LINKSETUP add INDENT_PASSWORD VARCHAR(50) End"
        gconnection.dataOperation(6, str, "AddC")


        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_LINKSETUP' AND  COLUMN_NAME = 'INDENT_ALTPASSWORD') Begin alter table INV_LINKSETUP add INDENT_ALTPASSWORD VARCHAR(50) End"
        gconnection.dataOperation(6, str, "AddC")




        If GACCPOST.ToUpper() = "Y" Then
            str = "Select * from sysobjects where name='UnMatchedVoucher' and xtype='V'"
            gconnection.getDataSet(str, "INV_TMPVW1")
            If gdataset.Tables("INV_TMPVW1").Rows.Count > 0 Then

            Else
                str = "CREATE  VIEW [dbo].[UnMatchedVoucher] AS  SELECT voucherno,VOUCHERTYPE,SUM(CREDIT) AS ACCAMOUNT,SUM(DEBIT) AS INVAMOUNT FROM   "

                str = str & "(select sum(amount) as CREDIT ,0 AS DEBIT, voucherno,VOUCHERTYPE from journalentry   WHERE  CREDITDEBIT='DEBIT' AND  "
                str = str & " VoucherType IN ('ISSUE','DAMAGE','STOCK TRANSFER','CONSUMPTION','ADJUSTMENT','GRN') AND ISNULL(Void,'')<>'Y' group by voucherno,CREDITDEBIT,VOUCHERTYPE  "
                str = str & "  UNION ALL "
                str = str & " select 0 as CREDIT ,sum(amount) AS DEBIT, Docdetails as  voucherno,'ISSUE' as VOUCHERTYPE from STOCKISSUEDETAIL   WHERE   ISNULL(Void,'')<>'Y' group by Docdetails "
                str = str & "  UNION ALL "
                str = str & " select 0 as CREDIT ,sum(BILLAMOUNT) AS DEBIT, Grndetails as  voucherno,'GRN' as VOUCHERTYPE from GRN_HEADER   WHERE   ISNULL(Void,'')<>'Y' group by Grndetails "
                str = str & "  UNION ALL "
                str = str & " select 0 as CREDIT ,sum(amount) AS DEBIT, Docdetails as  voucherno,'DAMAGE' as VOUCHERTYPE from STOCKDMGDETAIL   WHERE   ISNULL(Void,'')<>'Y' group by Docdetails  "
                str = str & "  UNION ALL "
                str = str & " select 0 as CREDIT ,sum(amount) AS DEBIT, Docdetails as  voucherno,'STOCK TRANSFER' as VOUCHERTYPE from STOCKTRANSFERDETAIL   WHERE   ISNULL(Void,'')<>'Y' group by Docdetails  "
                str = str & "  UNION ALL "
                str = str & " select 0 as CREDIT ,sum(amount) AS DEBIT, docno as  voucherno,'CONSUMPTION' as VOUCHERTYPE from stockConsumption_1   WHERE   ISNULL(Void,'')<>'Y' group by docno "
                str = str & "  UNION ALL "
                str = str & " select 0 as CREDIT ,sum(amount) AS DEBIT, Docdetails as  voucherno,'ADJUSTMENT' as VOUCHERTYPE from STOCKADJUSTDETAILS   WHERE   ISNULL(Void,'')<>'Y' group by Docdetails HAVING SUM(Amount)>0 "
                str = str & "  UNION ALL "
                str = str & " select 0 as CREDIT ,sum(amount)*-1 AS DEBIT, Docdetails as  voucherno,'ADJUSTMENT' as VOUCHERTYPE from STOCKADJUSTDETAILS   WHERE   ISNULL(Void,'')<>'Y' group by Docdetails HAVING SUM(Amount)<0 "
                str = str & " ) T group by voucherno,VOUCHERTYPE HAVING ABS( SUM(CAST(CREDIT AS NUMERIC(18,2)) )-SUM(CAST(DEBIT AS NUMERIC(18,2))))>1 "

                gconnection.dataOperation1(6, str, "INVENTORY_TRANSCONVERSION")




            End If
        End If


        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'STOCKADJUSTDETAILS' AND  COLUMN_NAME = 'REMARKS2') Begin alter table STOCKADJUSTDETAILS add  REMARKS2 VARCHAR(100) End"
        gconnection.dataOperation(6, str, "AddC")


        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_HEADER' AND  COLUMN_NAME = 'GLACCCODE') Begin alter table GRN_HEADER add  GLACCCODE VARCHAR(50) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_HEADER' AND  COLUMN_NAME = 'GLACCDESC') Begin alter table GRN_HEADER add  GLACCDESC VARCHAR(50) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_HEADER' AND  COLUMN_NAME = 'slcode') Begin alter table GRN_HEADER add  slcode VARCHAR(50) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_HEADER' AND  COLUMN_NAME = 'sldesc') Begin alter table GRN_HEADER add  sldesc VARCHAR(50) End"
        gconnection.dataOperation(6, str, "AddC")

        'str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_HEADER' AND  COLUMN_NAME = 'costcentercode') Begin alter table GRN_HEADER add  costcentercode VARCHAR(50) End"
        'gconnection.dataOperation(6, str, "AddC")

        'str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_HEADER' AND  COLUMN_NAME = 'costcenterdesc') Begin alter table GRN_HEADER add  costcenterdesc VARCHAR(50) End"
        'gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_HEADERLOG' AND  COLUMN_NAME = 'GLACCCODE') Begin alter table GRN_HEADERLOG add  GLACCCODE VARCHAR(50) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_HEADERLOG' AND  COLUMN_NAME = 'GLACCDESC') Begin alter table GRN_HEADERLOG add  GLACCDESC VARCHAR(50) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_HEADERLOG' AND  COLUMN_NAME = 'slcode') Begin alter table GRN_HEADERLOG add  slcode VARCHAR(50) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_HEADERLOG' AND  COLUMN_NAME = 'sldesc') Begin alter table GRN_HEADERLOG add  sldesc VARCHAR(50) End"
        gconnection.dataOperation(6, str, "AddC")

        'str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GRN_HEADERLOG' AND  COLUMN_NAME = 'costcentercode') Begin alter table GRN_HEADERLOG add  costcentercode VARCHAR(50) End"
        'gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'tempclosingqty' AND  COLUMN_NAME = 'opstorelocationname') Begin alter table tempclosingqty add  opstorelocationname VARCHAR(50) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'STOCKISSUEHEADER' AND  COLUMN_NAME = 'partybookingno')  Begin alter table STOCKISSUEHEADER add  partybookingno VARCHAR(20) End"
        gconnection.dataOperation(6, str, "AddC")

        'If gShortname <> "KGA" Or gShortname = "FNCC" Or gShortname <> "VFNCC" Then
        '    str = " alter VIEW  [dbo].[VW_INV_ISSUEBILL] AS SELECT TOP 100 PERCENT dbo.stockissueheader.docdetails,   dbo.stockissueheader.docdate, dbo.stockissueheader.storelocationname, dbo.stockissueheader.opstorelocationname,   dbo.stockissuedetail.itemcode, dbo.stockissueheader.storelocationcode,dbo.stockissueheader.opstorelocationcode,   dbo.stockissuedetail.itemname, dbo.stockissuedetail.uom,dbo.stockissuedetail.qty , dbo.stockissuedetail.rate,    dbo.stockissuedetail.amount , dbo.stockissueheader.indentno ,  dbo.stockissueheader.indentdate,   dbo.stockissueheader.remarks,isnull(dbo.stockissueheader.partybookingno,'') as partybookingno FROM dbo.stockissuedetail INNER JOIN dbo.stockissueheader     ON dbo.stockissuedetail.docdetails = dbo.stockissueheader.docdetails "
        '    gconnection.dataOperation(6, str, "AddC")
        'End If


        str = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'STOCKSUMMARY' AND  COLUMN_NAME = 'Receiveamt') Begin alter table STOCKSUMMARY add  Receiveamt numeric(18,2) End"
        gconnection.dataOperation(6, str, "AddC")

    End Sub


    Public Sub updatetable()
        Dim str As String

        str = "If Not EXISTS( Select * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'stocksummary' AND  COLUMN_NAME = 'receiveAmt') Begin alter table stocksummary add receiveAmt numeric(18,3) End"
        gconnection.dataOperation(6, str, "AddC")

        str = "Select * from sysobjects where name='Inv_JOURNALENTRY' and xtype='U'"
        gconnection.getDataSet(str, "Journalentry")
        If gdataset.Tables("Journalentry").Rows.Count > 0 Then

        Else
            str = "  select VoucherNo,VoucherDate,AccountCode,AccountcodeDesc,SLCode,SLDesc,CostCenterCode,CostCenterDesc,CreditDebit, Amount,0 as DRAmt,0 as CRAmt into Inv_JOURNALENTRY from JOURNALENTRY where 1<0"
            gconnection.dataOperation1(6, str, "Journalentry")
        End If


        str = "Select * from sysobjects where name='Journalentry' and xtype='U'"
        gconnection.getDataSet(str, "Journalentry")
        If gdataset.Tables("Journalentry").Rows.Count > 0 Then

        Else



            str = "  CREATE TABLE [dbo].[Journalentry]("
            str = str & " 	[Rowid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "  [VoucherNo] [varchar](50) NULL,"
            str = str & "  [VoucherDate] [datetime] NULL,"
            str = str & "  [VoucherCategory] [varchar](50) NULL,"
            str = str & "  [VoucherType] [varchar](50) NULL,"
            str = str & "  [CashBank] [varchar](50) NULL,"
            str = str & "  [AccountCode] [varchar](50) NULL,"
            str = str & "  [AccountcodeDesc] [varchar](100) NULL,"
            str = str & " [SLCode] [varchar](50) NULL,"
            str = str & " [SLDesc] [varchar](50) NULL,"
            str = str & " [CostCenterCode] [varchar](50) NULL,"
            str = str & " 	[CostCenterDesc] [varchar](50) NULL,"
            str = str & " 	[CreditDebit] [varchar](10) NULL,"
            str = str & " 	[Amount] [numeric](15, 2) NULL,"
            str = str & " [Description] [varchar](300) NULL,"
            str = str & " [InstrumentDate] [datetime] NULL,"
            str = str & " [InstrumentType] [varchar](20) NULL,"
            str = str & " [Instrumentno] [varchar](25) NULL,"
            str = str & " [BankName] [varchar](50) NULL,"
            str = str & " [BankPlace] [varchar](50) NULL,"
            str = str & " [OppAccountCode] [varchar](50) NULL,"
            str = str & " [Void] [varchar](1) NULL,"
            str = str & " [ReceiptNo] [numeric](18, 0) NULL,"
            str = str & " 	[Party_Name] [varchar](100) NULL,"
            str = str & " [ReceivedFrom] [varchar](50) NULL,"
            str = str & " [ReceivedDate] [datetime] NULL,"
            str = str & " [Ref_No] [varchar](50) NULL,"
            str = str & " [Ref_Date] [datetime] NULL,"
            str = str & " 	[Roomno] [numeric](5, 0) NULL,"
            str = str & " [SectionCode] [varchar](10) NULL,"
            str = str & " [TDSPerc] [varchar](20) NULL,"
            str = str & " [Termination] [varchar](1) NULL,"
            str = str & " [PartyName] [varchar](50) NULL,"
            str = str & " [MICR] [varchar](50) NULL,"
            str = str & " [TaxType] [varchar](20) NULL,"
            str = str & " [TaxCode] [varchar](20) NULL,"
            str = str & " [TaxPerc] [numeric](7, 2) NULL,"
            str = str & " [Batchno] [numeric](10, 0) NULL,"
            str = str & " [AdduserId] [varchar](50) NULL,"
            str = str & " [AddDateTime] [datetime] NULL,"
            str = str & " [FreezeUserId] [varchar](50) NULL,"
            str = str & " [FreezeDateTime] [datetime] NULL,"
            str = str & " [QUATERDATE] [varchar](50) NULL,"
            str = str & " [RealisedDate] [datetime] NULL"
            str = str & "  ) ON [PRIMARY]"

            gconnection.dataOperation1(6, str, "Journalentry")

        End If


        str = "Select * from sysobjects where name='INVENTORY_TRANSCONVERSION' and xtype='U'"
        gconnection.getDataSet(str, "INVENTORY_TRANSCONVERSION")
        If gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0 Then

        Else

            str = " CREATE TABLE [dbo].[INVENTORY_TRANSCONVERSION]("
            str = str & " [BASEUOM] [varchar](50) NULL,"
            str = str & " [TRANSUOM] [varchar](50) NULL,"
            str = str & " 	[CONVVALUE] [numeric](18, 6) NULL,"
            str = str & " [FREEZE] [varchar](10) NULL,"
            str = str & " [ADDUSER] [varchar](50) NULL,"
            str = str & " [ADDDATETIME] [datetime] NULL,"
            str = str & " [UPDATEUSER] [varchar](50) NULL,"
            str = str & " [UPDATEDATETIME] [datetime] NULL,"
            str = str & " [VOIDUSER] [varchar](50) NULL,"
            str = str & " [VOIDDATETIME] [datetime] NULL"
            str = str & " ) ON [PRIMARY]"
            gconnection.dataOperation1(6, str, "INVENTORY_TRANSCONVERSION")

        End If


        str = "Select * from sysobjects where name='closingqty' and xtype='U'"
        gconnection.getDataSet(str, "closingqty")
        If gdataset.Tables("closingqty").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE closingqty"
            str = str & " ("
            str = str & " Trnno VARCHAR(50) NULL,"
            str = str & " itemcode VARCHAR(50) NULL,"
            str = str & " uom VARCHAR(50) NULL,"
            str = str & " storecode  VARCHAR(50) NULL,"
            str = str & " Trndate  DATETIME NULL,"
            str = str & " openningstock NUMERIC(18,3) NULL ,"
            str = str & " openningvalue   NUMERIC(18,3) NULL,"
            str = str & " qty  NUMERIC(18,3) NULL,"
            str = str & " closingstock  NUMERIC(18,3) NULL,"
            str = str & " closingvalue  NUMERIC(18,3) NULL,"
            str = str & " batchyn varchar(2) NULL ,"
            str = str & " ttype  VARCHAR(50) NULL,"
            str = str & " batchno VARCHAR(50) NULL"

            str = str & " )"
            gconnection.dataOperation1(6, str, "closingqty")
        End If
        str = "Select * from sysobjects where name='INV_LINKSETUP' and xtype='U'"
        gconnection.getDataSet(str, "INV_LINKSETUP")
        If gdataset.Tables("INV_LINKSETUP").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE INV_LINKSETUP"
            str = str & " ("
            str = str & " POFLAG VARCHAR(1) NULL,"
            str = str & " ACCPOSTFLAG VARCHAR(1) NULL,"
            str = str & " INDENTISSFLAG VARCHAR(1) NULL,"
            str = str & " DISCaccountcode  VARCHAR(50) NULL,"
            str = str & " OTHACCOUNTCODE  VARCHAR(50) NULL,"
            str = str & " grntype varchar(50) NULL ,"
            str = str & " ADDUSER  VARCHAR(50) NULL,"
            str = str & " ADDDATETIME smalldatetime NULL,"
            str = str & " )"
            gconnection.dataOperation1(6, str, "INV_LINKSETUP")
        End If
        str = "select * from sysobjects where name='ACCOUNTSSETUP' and xtype='U'"
        gconnection.getDataSet(str, "ACCOUNTSSETUP")
        If gdataset.Tables("ACCOUNTSSETUP").Rows.Count > 0 Then

        Else


            str = "CREATE TABLE [dbo].[ACCOUNTSSETUP]( "
            str = str & " [SdrsCode] [varchar](50) NULL,"
            str = str & " 	[SdrsDesc] [varchar](50) NULL,"
            str = str & " [ScrsCode] [varchar](50) NULL,"
            str = str & " [ScrsDesc] [varchar](50) NULL,"
            str = str & " [ManualMatching] [varchar](1) NULL,"
            str = str & " [AutoMatching] [varchar](1) NULL,"
            str = str & " [BothMatching] [varchar](1) NULL,"
            str = str & " [PLCODE] [varchar](100) NULL,"
            str = str & " [PLDESC] [varchar](100) NULL,"
            str = str & " [BSCODE] [varchar](100) NULL,"
            str = str & " [BSDESC] [varchar](100) NULL,"
            str = str & " [Costcenter] [varchar](1) NULL,"
            str = str & " [MATCHING] [varchar](1) NULL,"
            str = str & " [clublogo] [image] NULL,"
            str = str & " [gPosPosting] [varchar](2) NULL,"
            str = str & " [balanceprint] [varchar](1) NULL,"
            str = str & " [posposting] [varchar](1) NULL,"
            str = str & " [subscode] [varchar](10) NULL,"
            str = str & " [AliasPrint] [varchar](20) NULL,"
            str = str & " [ADD_DATE] [datetime] NULL,"
            str = str & " [ADD_USER] [varchar](50) NULL,"
            str = str & " [UPD_USER] [varchar](9) NULL,"
            str = str & " [UPD_DATE] [datetime] NULL,"
            str = str & " [VOID] [varchar](9) NULL,"
            str = str & " [VOIDUSER] [varchar](9) NULL,"
            str = str & " [VOIDDATE] [datetime] NULL,"
            str = str & " [AUTHORISED] [varchar](2) NULL,"
            str = str & " [AUTHORISE_LEVEL1] [varchar](2) NULL,"
            str = str & " [AUTHORISE_USER1] [varchar](20) NULL,"
            str = str & " [AUTHORISE_DATE1] [datetime] NULL,"
            str = str & " [AUTHORISE_LEVEL2] [varchar](2) NULL,"
            str = str & " [AUTHORISE_USER2] [varchar](20) NULL,"
            str = str & " [AUTHORISE_DATE2] [datetime] NULL,"
            str = str & " [AUTHORISE_LEVEL3] [varchar](2) NULL,"
            str = str & " [AUTHORISE_USER3] [varchar](20) NULL,"
            str = str & " [AUTHORISE_DATE3] [datetime] NULL,"
            str = str & " [INVACCPOSTING] [varchar](5) NULL,"
            str = str & " [INVACCPOSTINGMODE] [varchar](5) NULL"
            str = str & "  ) "
            gconnection.dataOperation1(6, str, "ACCOUNTSSETUP")

        End If


        str = "select * from sysobjects where name='ModuleMaster' and xtype='U'"
        gconnection.getDataSet(str, "ModuleMaster")
        If gdataset.Tables("ModuleMaster").Rows.Count > 0 Then

        Else

            str = "   CREATE TABLE [dbo].[ModuleMaster]("
            str = str & "	[PackageName] [varchar](50) NULL,"
            str = str & "	[Mainmoduleid] [varchar](50) NULL,"
            str = str & "	[MainModulename] [varchar](50) NULL,"
            str = str & "	[SubModuleid] [varchar](50) NULL,"
            str = str & "	[SubModulename] [varchar](100) NULL,"
            str = str & "	[SsubModuleid] [varchar](50) NULL,"
            str = str & "	[rowid] [numeric](16, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "	[SsubModuleName] [varchar](50) NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "ModuleMaster")

        End If
        str = "select * from sysobjects where name='InventoryGroupMaster' and xtype='U'"
        gconnection.getDataSet(str, "InventoryGroupMaster")
        If gdataset.Tables("InventoryGroupMaster").Rows.Count > 0 Then

        Else

            str = "  CREATE TABLE [dbo].[InventoryGroupMaster]("
            str = str & " [Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " [Groupcode] [varchar](30) NOT NULL,"
            str = str & "[Groupdesc] [varchar](50) NOT NULL,"
            str = str & "	[Freeze] [char](1) NULL,"
            str = str & "[Adduser] [varchar](50) NULL,"
            str = str & "	[Adddate] [datetime] NULL,"
            str = str & "	[updateuser] [varchar](15) NULL,"
            str = str & "	[updatetime] [datetime] NULL,"
            str = str & "	[voiduser] [varchar](50) NULL,"
            str = str & "	[voiddate] [datetime] NULL"

            str = str & ")"
            gconnection.dataOperation1(6, str, "InventoryGroupMaster")

        End If
        str = "select * from sysobjects where name='InventorySubGroupMaster' and xtype='U'"
        gconnection.getDataSet(str, "InventorySubGroupMaster")
        If gdataset.Tables("InventorySubGroupMaster").Rows.Count > 0 Then

        Else


            str = "  CREATE TABLE [dbo].[InventorySubGroupMaster]("
            str = str & " [Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "[Groupcode] [varchar](30) NULL,"
            str = str & "	[Subgroupcode] [varchar](30) NULL,"
            str = str & "	[Subgroupdesc] [varchar](50) NULL,"
            str = str & "	[Freeze] [char](1) NULL,"
            str = str & "	[Adduser] [varchar](50) NULL,"
            str = str & "	[Adddate] [datetime] NULL,"
            str = str & "	[updateuser] [varchar](15) NULL,"
            str = str & "	[updatetime] [datetime] NULL,"
            str = str & "[voiduser] [varchar](50) NULL,"
            str = str & "	[voiddate] [datetime] NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "InventorySubGroupMaster")

        End If
        str = "select * from sysobjects where name='InventorySubSubGroupMaster' and xtype='U'"
        gconnection.getDataSet(str, "InventorySubSubGroupMaster")
        If gdataset.Tables("InventorySubSubGroupMaster").Rows.Count > 0 Then

        Else

            str = "  CREATE TABLE [dbo].[InventorySubSubGroupMaster]("
            str = str & "[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "[Subgroupcode] [varchar](30) NULL,"
            str = str & "[Freeze] [char](1) NULL,"
            str = str & "[Adduser] [varchar](50) NULL,"
            str = str & "[Adddate] [datetime] NULL,"
            str = str & "[updateuser] [varchar](50) NULL,"
            str = str & "[updatedate] [datetime] NULL,"
            str = str & "[voiduser] [varchar](50) NULL,"
            str = str & "[voiddate] [datetime] NULL,"
            str = str & "[subsubgroupcode] [varchar](30) NULL,"
            str = str & "[subsubgroupdesc] [varchar](50) NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "InventorySubSubGroupMaster")
        End If
        str = "select * from sysobjects where name='INVENTORYCATEGORYMASTER' and xtype='U'"
        gconnection.getDataSet(str, "INVENTORYCATEGORYMASTER")
        If gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0 Then

        Else

            str = "   CREATE TABLE [dbo].[INVENTORYCATEGORYMASTER]("
            str = str & "[CATEGORYCODE] [varchar](30) NULL,"
            str = str & "[CATEGORYDESC] [varchar](50) NULL,"
            str = str & " [Freeze] [char](1) NULL,"
            str = str & " [Adduser] [varchar](10) NULL,"
            str = str & " [Adddate] [datetime] NULL,"
            str = str & " [updateuser] [varchar](10) NULL,"
            str = str & " [updatedate] [datetime] NULL,"
            str = str & "[VOIDUSER] [varchar](30) NULL,"
            str = str & "[voiddate] [datetime] NULL,"
            str = str & "[Rateflag] [varchar](10) NULL"
            str = str & ") "
            gconnection.dataOperation1(6, str, "INVENTORYCATEGORYMASTER")

        End If
        str = "select * from sysobjects where name='StoreMaster' and xtype='U'"
        gconnection.getDataSet(str, "StoreMaster")
        If gdataset.Tables("StoreMaster").Rows.Count > 0 Then

        Else

            str = "    CREATE TABLE [dbo].[StoreMaster]("
            str = str & "[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "[Storecode] [varchar](30) NOT NULL,"
            str = str & "[Storedesc] [varchar](50) NOT NULL,"
            str = str & "[Freeze] [char](1) NULL,"
            str = str & " [adduser] [varchar](50) NULL,"
            str = str & "[adddate] [datetime] NULL,"
            str = str & "	[Storestatus] [varchar](10) NULL,"
            str = str & "	[updateuser] [varchar](50) NULL,"
            str = str & "	[updatetime] [datetime] NULL,"
            str = str & "	[voiduser] [varchar](50) NULL,"
            str = str & "	[voiddate] [datetime] NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "StoreMaster")

        End If
        str = "select * from sysobjects where name='UoMMaster' and xtype='U'"
        gconnection.getDataSet(str, "UoMMaster")
        If gdataset.Tables("UoMMaster").Rows.Count > 0 Then

        Else

            str = "  CREATE TABLE [dbo].[UoMMaster]("
            str = str & "[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"


            str = str & " [UOMCode] [varchar](30) NULL,"
            str = str & " [UOMDesc] [varchar](50) NULL,"
            str = str & " [UOMSeqno] [decimal](38, 0) NULL,"
            str = str & " [Freeze] [varchar](1) NULL,"
            str = str & " [AddDatetime] [datetime] NULL,"
            str = str & " [AddUSer] [varchar](50) NULL,"
            str = str & " [UPDATEUSER] [varchar](50) NULL,"
            str = str & " 	[UPDATETIME] [datetime] NULL,"
            str = str & " 	[voiduser] [varchar](50) NULL,"
            str = str & "	[voiddate] [datetime] NULL"
            str = str & " ) "
            gconnection.dataOperation1(6, str, "UoMMaster")

        End If
        str = "select * from sysobjects where name='INV_InventoryItemMaster' and xtype='U'"
        gconnection.getDataSet(str, "INV_InventoryItemMaster")
        If gdataset.Tables("INV_InventoryItemMaster").Rows.Count > 0 Then

        Else

            str = "  CREATE TABLE [dbo].[INV_InventoryItemMaster]("
            str = str & "[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"

            str = str & " [itemcode] [varchar](30) NULL,"
            str = str & " [itemname] [varchar](50) NULL,"
            str = str & " [groupcode] [varchar](30) NULL,"
            str = str & " [subGroupcode] [varchar](30) NULL,"
            str = str & " [subsubgroupcode] [varchar](30) NULL,"
            str = str & " [category] [varchar](30) NULL,"
            str = str & " [abccategory] [varchar](10) NULL,"
            str = str & " [TaxRebate] [varchar](10) NULL,"
            str = str & " [batchprocess] [varchar](10) NULL,"
            str = str & " [Profitper] [numeric](8,2) NULL,"
            str = str & " [void] [varchar](1) NULL,"
            str = str & " [AddDate] [datetime] NULL,"
            str = str & " [addUSER] [varchar](50) NULL,"
            str = str & " [UPDATEUSER] [varchar](15) NULL,"
            str = str & " 	[UPDATEdate] [datetime] NULL,"
            str = str & " 	[voiduser] [varchar](50) NULL,"
            str = str & "	[voiddate] [datetime] NULL,"
            str = str & "	[stockuom] [varchar](50) NULL"
            str = str & " ) "
            gconnection.dataOperation1(6, str, "INV_InventoryItemMaster")

        End If
        str = "select * from sysobjects where name='inv_InventoryOpenningstock' and xtype='U'"
        gconnection.getDataSet(str, "INV_InventoryItemMaster")
        If gdataset.Tables("INV_InventoryItemMaster").Rows.Count > 0 Then

        Else

            str = "  CREATE TABLE [dbo].[inv_InventoryOpenningstock]("
            str = str & "[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"

            str = str & " [itemcode] [varchar](30) NULL,"
            str = str & " [storecode] [varchar](30) NULL,"
            str = str & " [uom] [varchar](30) NULL,"
            str = str & " [minqty][numeric](18,2) NULL,"
            str = str & " [maxqty][numeric](18,2) NULL,"
            str = str & " [reorder][numeric](18,2) NULL,"
            str = str & " [openningqty ][numeric](18,2) NULL,"
            str = str & " [openningvalue][numeric](18,2) NULL,"
            str = str & " [closingqty ][numeric](18,2) NULL,"
            str = str & " [closingvalue][numeric](18,2) NULL,"
            str = str & " [void] [varchar](1) NULL,"
            str = str & " [AddDate] [datetime] NULL,"
            str = str & " [addUSER] [varchar](50) NULL,"
            str = str & " [UPDATEUSER] [varchar](15) NULL,"
            str = str & " 	[UPDATEdate] [datetime] NULL,"
            str = str & " 	[voiduser] [varchar](50) NULL,"
            str = str & "	[voiddate] [datetime] NULL"
            str = str & " ) "
            gconnection.dataOperation1(6, str, "inv_InventoryOpenningstock")

        End If

        str = "select * from sysobjects where name='inv_Inventoryuomstorelink' and xtype='U'"
        gconnection.getDataSet(str, "INV_InventoryItemMaster")
        If gdataset.Tables("INV_InventoryItemMaster").Rows.Count > 0 Then

        Else

            str = "  CREATE TABLE [dbo].[inv_Inventoryuomstorelink]("
            str = str & "[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"

            str = str & " [itemcode] [varchar](30) NULL,"
            str = str & " [storecode] [varchar](30) NULL,"
            str = str & " [reportUOM] [varchar](30) NULL,"
            str = str & " [reportdecimaluom][varchar](30) NULL,"
            str = str & " [void] [varchar](1) NULL,"
            str = str & " [AddDate] [datetime] NULL,"
            str = str & " [addUSER] [varchar](50) NULL,"
            str = str & " [UPDATEUSER] [varchar](15) NULL,"
            str = str & " [UPDATEdate] [datetime] NULL,"
            str = str & " [voiduser] [varchar](50) NULL,"
            str = str & " [voiddate] [datetime] NULL"
            str = str & " ) "
            gconnection.dataOperation1(6, str, "inv_Inventoryuomstorelink")

        End If

        str = "select * from sysobjects where name='INVITEM_TRANSUOM_LINK' and xtype='U'"
        gconnection.getDataSet(str, "INVITEM_TRANSUOM_LINK")
        If gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count > 0 Then

        Else



            str = " CREATE TABLE [dbo].[INVITEM_TRANSUOM_LINK]("
            str = str & " [ITEMCODE] [varchar](50) NULL,"
            str = str & " [TRANUOM] [varchar](50) NULL,"
            str = str & " [STOCKUOM] [varchar](50) NULL,"
            str = str & " [ADDUSER] [varchar](50) NULL,"
            str = str & " [ADDDATETIME] [datetime] NULL"
            str = str & "  ) ON [PRIMARY]"
            gconnection.dataOperation1(6, str, "INVITEM_TRANSUOM_LINK")

        End If

        str = "select * from sysobjects where name='Categoryuserdetail' and xtype='U'"
        gconnection.getDataSet(str, "Categoryuserdetail")
        If gdataset.Tables("Categoryuserdetail").Rows.Count > 0 Then

        Else

            str = "  CREATE TABLE [dbo].[Categoryuserdetail]("


            str = str & " [categorycode] [varchar](30) NULL,"
            str = str & " [usercode] [varchar](50) NULL,"
            str = str & " [void] [varchar](1) NULL,"
            str = str & " [AddDate] [datetime] NULL,"
            str = str & " [addUSER] [varchar](50) NULL,"
            str = str & " [UPDATEUSER] [varchar](50) NULL,"
            str = str & " 	[UPDATEdate] [datetime] NULL,"
            str = str & " 	[voiduser] [varchar](50) NULL,"
            str = str & "	[voiddate] [datetime] NULL"
            str = str & " ) "
            gconnection.dataOperation1(6, str, "Categoryuserdetail")

        End If
        str = "select * from sysobjects where name='UserAdmin' and xtype='U'"
        gconnection.getDataSet(str, "UserAdmin")
        If gdataset.Tables("UserAdmin").Rows.Count > 0 Then

        Else

            str = "  CREATE TABLE [dbo].[UserAdmin]("
            str = str & " [userName] [varchar](50) NULL,"
            str = str & " [category] [varchar](50) NULL,"
            str = str & " [userpassword] [varchar](50) NULL,"
            str = str & " [mainindex] [numeric](2,0) NULL,"
            str = str & " [moduleid] [varchar](25) NULL,"
            str = str & " [moduleindex] [numeric](3,0) NULL,"
            str = str & " [mainmenu] [varchar](50) NULL,"
            str = str & " [rights]  [varchar](15)NULL,"
            str = str & " [modulename] [varchar](50) NULL,"
            str = str & " [maingroup] [varchar](20) NULL,"
            str = str & " 	[mainmoduleid] [varchar](10) NULL,"
            str = str & " 	[submoduleid]  [varchar](10) NULL,"
            str = str & "	[ssubmoduleid]  [varchar](10) NULL"
            str = str & " ) "
            gconnection.dataOperation1(6, str, "UserAdmin")

        End If
        str = "select * from sysobjects where name='ACCOUNTSSUBLEDGERMASTER' and xtype='U'"
        gconnection.getDataSet(str, "ACCOUNTSSUBLEDGERMASTER")
        If gdataset.Tables("ACCOUNTSSUBLEDGERMASTER").Rows.Count > 0 Then

        Else
            str = "       CREATE TABLE [dbo].[ACCOUNTSSUBLEDGERMASTER]("
            str = str & "	[roll] [nvarchar](255) NULL,"
            str = str & "[accode] [nvarchar](255) NULL,"
            str = str & "[acdesc] [nvarchar](255) NULL,"
            str = str & "[sltype] [nvarchar](255) NULL,"
            str = str & "[slcode] [nvarchar](255) NULL,"
            str = str & "[slname] [nvarchar](255) NULL,"
            str = str & "[sldesc] [nvarchar](255) NULL,"
            str = str & "[contactperson] [nvarchar](255) NULL,"
            str = str & "[address1] [nvarchar](255) NULL,"
            str = str & "[address2] [nvarchar](255) NULL,"
            str = str & "[address3] [nvarchar](255) NULL,"
            str = str & "[city] [nvarchar](255) NULL,"
            str = str & "[state] [nvarchar](255) NULL,"
            str = str & "[pin] [varchar](20) NULL,"
            str = str & "[phoneno] [varchar](50) NULL,"
            str = str & "[cellno] [nvarchar](255) NULL,"
            str = str & "[vatno] [nvarchar](255) NULL,"
            str = str & "[cstno] [nvarchar](255) NULL,"
            str = str & "[tinno] [nvarchar](255) NULL,"
            str = str & "[grnno] [nvarchar](255) NULL,"
            str = str & "[panno] [nvarchar](255) NULL,"
            str = str & "[creditperiod] [nvarchar](255) NULL,"
            str = str & "[opcredits] [numeric](18, 2) NULL,"
            str = str & "[opdebits] [numeric](18, 2) NULL,"
            str = str & "[cldebits] [nvarchar](255) NULL,"
            str = str & "[clcredits] [nvarchar](255) NULL,"
            str = str & "[tdsflag] [nvarchar](255) NULL,"
            str = str & "[tdssection] [nvarchar](255) NULL,"
            str = str & "[tdspercentage] [nvarchar](255) NULL,"
            str = str & "[workscontractflag] [nvarchar](255) NULL,"
            str = str & "[workscontractsection] [nvarchar](255) NULL,"
            str = str & "[workscontractpercentage] [nvarchar](255) NULL,"
            str = str & "[purchaseflag] [nvarchar](255) NULL,"
            str = str & "[purchasesection] [nvarchar](255) NULL,"
            str = str & "[purchasepercentage] [nvarchar](255) NULL,"
            str = str & "[esiflag] [nvarchar](255) NULL,"
            str = str & "[esisection] [nvarchar](255) NULL,"
            str = str & "[esipercentage] [nvarchar](255) NULL,"
            str = str & "[pfflag] [nvarchar](255) NULL,"
            str = str & "[pfsection] [nvarchar](255) NULL,"
            str = str & "[pfpercentage] [nvarchar](255) NULL,"
            str = str & "[aprdebits] [nvarchar](255) NULL,"
            str = str & "[aprcredits] [nvarchar](255) NULL,"
            str = str & "[maydebits] [nvarchar](255) NULL,"
            str = str & "[maycredits] [nvarchar](255) NULL,"
            str = str & "[jundebits] [nvarchar](255) NULL,"
            str = str & "[juncredits] [nvarchar](255) NULL,"
            str = str & "[juldebits] [nvarchar](255) NULL,"
            str = str & "[julcredits] [nvarchar](255) NULL,"
            str = str & "[augdebits] [nvarchar](255) NULL,"
            str = str & "[augcredits] [nvarchar](255) NULL,"
            str = str & "[sepdebits] [nvarchar](255) NULL,"
            str = str & "[sepcredits] [nvarchar](255) NULL,"
            str = str & "[octdebits] [nvarchar](255) NULL,"
            str = str & "[octcredits] [nvarchar](255) NULL,"
            str = str & "[novdebits] [nvarchar](255) NULL,"
            str = str & "[novcredits] [nvarchar](255) NULL,"
            str = str & "[decdebits] [nvarchar](255) NULL,"
            str = str & "[deccredits] [nvarchar](255) NULL,"
            str = str & "[jandebits] [nvarchar](255) NULL,"
            str = str & "[jancredits] [nvarchar](255) NULL,"
            str = str & "[febdebits] [nvarchar](255) NULL,"
            str = str & "[febcredits] [nvarchar](255) NULL,"
            str = str & "[mardebits] [nvarchar](255) NULL,"
            str = str & "[marcredits] [nvarchar](255) NULL,"
            str = str & "[adduserid] [nvarchar](255) NULL,"
            str = str & "[adddatetime] [nvarchar](255) NULL,"
            str = str & "[updateuserid] [nvarchar](255) NULL,"
            str = str & "[updatedatetime] [nvarchar](255) NULL,"
            str = str & "[freezeflag] [nvarchar](255) NULL,"
            str = str & "[freezeuserid] [nvarchar](255) NULL,"
            str = str & "[freezedatetime] [nvarchar](255) NULL,"
            str = str & "[TdsSectionType] [nvarchar](255) NULL,"
            str = str & "[NARRATION] [nvarchar](255) NULL,"
            str = str & "[CHQ_FLG] [nvarchar](255) NULL,"
            str = str & "[CHQ_FLAG] [nvarchar](255) NULL,"
            str = str & "[BILLDATE] [nvarchar](255) NULL,"
            str = str & "[LEDGERNAME] [nvarchar](255) NULL,"
            str = str & "[ADD_USER] [nvarchar](255) NULL,"
            str = str & "[UPD_USER] [nvarchar](255) NULL,"
            str = str & "[VOID] [nvarchar](255) NULL,"
            str = str & "[VOIDUSER] [nvarchar](255) NULL,"
            str = str & "[ADD_DATE] [datetime] NULL,"
            str = str & "[UPD_DATE] [datetime] NULL,"
            str = str & "[VOIDDATE] [datetime] NULL,"
            str = str & "[emailid] [varchar](100) NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "ACCOUNTSSUBLEDGERMASTER")
        End If
        str = "select * from sysobjects where name='accountstdsmaster' and xtype='U'"
        gconnection.getDataSet(str, "accountstdsmaster")
        If gdataset.Tables("accountstdsmaster").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE [dbo].[accountstdsmaster]("
            str = str & "[tdscode] [varchar](10) NOT NULL,"
            str = str & "[sectiontype] [varchar](50) NULL,"
            str = str & "[percentage] [numeric](18, 3) NULL,"
            str = str & "[glaccountin] [varchar](10) NULL,"
            str = str & "[glaccountdesc] [varchar](50) NULL,"
            str = str & "[SUBLEDGERCODE] [varchar](10) NULL,"
            str = str & "[SUBLEDGERDESC] [varchar](50) NULL,"
            str = str & "[COSTCENTERCODE] [varchar](10) NULL,"
            str = str & "[COSTCENTERDESC] [varchar](50) NULL,"
            str = str & "[adduserid] [varchar](50) NULL,"
            str = str & "[adddatetime] [datetime] NULL,"
            str = str & "[updateuserid] [varchar](50) NULL,"
            str = str & "[updatedatetime] [datetime] NULL,"
            str = str & "[freezeflag] [varchar](1) NULL,"
            str = str & "[freezeuserid] [varchar](50) NULL,"
            str = str & "[freezedatetime] [datetime] NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "accountstdsmaster")
        End If

        str = "select * from sysobjects where name='AccountsPurchaseTaxMaster' and xtype='U'"
        gconnection.getDataSet(str, "AccountsPurchaseTaxMaster")
        If gdataset.Tables("AccountsPurchaseTaxMaster").Rows.Count > 0 Then

        Else



            str = " CREATE TABLE [dbo].[AccountsPurchaseTaxMaster]("
            str = str & " [purchasecode] [varchar](10) NOT NULL,"
            str = str & "  [sectiontype] [varchar](50) NULL,"
            str = str & " [percentage] [numeric](18, 2) NULL,"
            str = str & "  [glaccountin] [varchar](10) NULL,"
            str = str & "  [glaccountdesc] [varchar](50) NULL,"
            str = str & "  [SUBLEDGERCODE] [varchar](10) NULL,"
            str = str & "  [SUBLEDGERDESC] [varchar](50) NULL,"
            str = str & "  [COSTCENTERCODE] [varchar](10) NULL,"
            str = str & "  [COSTCENTERDESC] [varchar](50) NULL,"
            str = str & " [adduserid] [varchar](50) NULL,"
            str = str & " [adddatetime] [datetime] NULL,"
            str = str & " [updateuserid]  [varchar](50) NULL,"
            str = str & "  [updatedatetim e] [datetime] NULL,"
            str = str & " [freezeflag] [varchar](1) NULL,"
            str = str & " [freezeuserid]  [varchar](50) NULL,"
            str = str & "  [freezedatetime] [datetime] NULL"
            str = str & "  ) "
            gconnection.dataOperation1(6, str, "AccountsPurchaseTaxMaster")

        End If



        str = "select * from sysobjects where name='AccountsPfMaster' and xtype='U'"
        gconnection.getDataSet(str, "AccountsPfMaster")
        If gdataset.Tables("AccountsPfMaster").Rows.Count > 0 Then

        Else



            str = " CREATE TABLE [dbo].[AccountsPfMaster]( "
            str = str & " [pfcode] [varchar](10) NOT NULL, "
            str = str & " [sectiontype] [varchar](50) NULL,"
            str = str & " [pfpercentage] [numeric](18, 2) NULL,"
            str = str & " [glaccountin] [varchar](10) NULL,"
            str = str & " [glaccountdesc] [varchar](50) NULL,"
            str = str & " [SUBLEDGERCODE] [varchar](10) NULL,"
            str = str & " [SUBLEDGERDESC] [varchar](50) NULL,"
            str = str & " [COSTCENTERCODE] [varchar](10) NULL,"
            str = str & " [COSTCENTERDESC] [varchar](50) NULL,"
            str = str & " [adduserid] [varchar](50) NULL,"
            str = str & " [adddatetime] [datetime] NULL,"
            str = str & " [updateuserid] [varchar](50) NULL,"
            str = str & " [updatedatetime] [datetime] NULL,"
            str = str & " [freezeflag] [varchar](1) NULL,"
            str = str & " [freezeuserid] [varchar](50) NULL,"
            str = str & " [freezedatetime] [datetime] NULL"
            str = str & " )"
            gconnection.dataOperation1(6, str, "AccountsPfMaster")

        End If

        str = "select * from sysobjects where name='AccountsEsiMaster' and xtype='U'"
        gconnection.getDataSet(str, "AccountsEsiMaster")
        If gdataset.Tables("AccountsEsiMaster").Rows.Count > 0 Then

        Else



            str = " CREATE TABLE [dbo].[AccountsEsiMaster]("
            str = str & " [esicode] [varchar](10) NOT NULL,"
            str = str & " [sectiontype] [varchar](50) NULL,"
            str = str & " 	[sectionpercentage] [numeric](18, 2) NULL,"
            str = str & " [glaccountin] [varchar](10) NULL,"
            str = str & " [glaccountdesc] [varchar](50) NULL,"
            str = str & " [SUBLEDGERCODE] [varchar](10) NULL,"
            str = str & " [SUBLEDGERDESC] [varchar](50) NULL,"
            str = str & " [COSTCENTERCODE] [varchar](10) NULL,"
            str = str & " [COSTCENTERDESC] [varchar](50) NULL,"
            str = str & " [adduserid] [varchar](50) NULL,"
            str = str & " [adddatetime] [datetime] NULL,"
            str = str & "[updateuserid] [varchar](50) NULL,"
            str = str & " [updatedatetime] [datetime] NULL,"
            str = str & " [freezeflag] [varchar](1) NULL,"
            str = str & " [freezeuserid] [varchar](50) NULL,"
            str = str & " [freezedatetime] [datetime] NULL"
            str = str & " )"
            gconnection.dataOperation1(6, str, "AccountsEsiMaster")

        End If

        str = "select * from sysobjects where name='AccountsWorksContractMaster' and xtype='U'"
        gconnection.getDataSet(str, "AccountsWorksContractMaster")
        If gdataset.Tables("AccountsWorksContractMaster").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE [dbo].[AccountsWorksContractMaster]("
            str = str & "[workscontractcode] [varchar](10) NOT NULL,"
            str = str & "[sectiontype] [varchar](50) NULL,"
            str = str & "[percentage] [numeric](18, 2) NULL,"
            str = str & "[glaccountin] [varchar](10) NULL,"
            str = str & "[glaccountdesc] [varchar](50) NULL,"
            str = str & "[SUBLEDGERCODE] [varchar](10) NULL,"
            str = str & "[SUBLEDGERDESC] [varchar](50) NULL,"
            str = str & "[COSTCENTERCODE] [varchar](10) NULL,"
            str = str & "[COSTCENTERDESC] [varchar](50) NULL,"
            str = str & "[adduserid] [varchar](50) NULL,"
            str = str & "[adddatetime] [datetime] NULL,"
            str = str & "[updateuserid] [varchar](50) NULL,"
            str = str & "[updatedatetime] [datetime] NULL,"
            str = str & "[freezeflag] [varchar](1) NULL,"
            str = str & "[freezeuserid] [varchar](50) NULL,"
            str = str & "[freezedatetime] [datetime] NULL"
            str = str & ")"
            gconnection.dataOperation1(6, str, "AccountsWorksContractMaster")
        End If

        str = "select * from sysobjects where name='CONSUMERMASTER' and xtype='U'"
        gconnection.getDataSet(str, "CONSUMERMASTER")
        If gdataset.Tables("CONSUMERMASTER").Rows.Count > 0 Then

        Else

            str = "    CREATE TABLE [dbo].[CONSUMERMASTER]("
            str = str & "	[CONNO] [varchar](10) NULL,"
            str = str & "	[CONNAME] [varchar](35) NULL,"
            str = str & "	[CONTYPE] [varchar](15) NULL,"
            str = str & "	[UPDATEUSER] [varchar](20) NULL,"
            str = str & "	[UPDATETIME] [datetime] NULL,"
            str = str & "	[voiduser] [varchar](20) NULL,"
            str = str & "[voiddate] [datetime] NULL,"
            str = str & "[FREEZE] [char](1) NULL,"
            str = str & "[ADDUSER] [varchar](20) NULL,"
            str = str & "[ADDDATE] [datetime] NULL,"
            str = str & "[conid] [varchar](10) NULL"
            str = str & ") "

            gconnection.dataOperation1(6, str, "CONSUMERMASTER")

        End If
        str = "select * from sysobjects where name='consolidatestocksummary' and xtype='U'"
        gconnection.getDataSet(str, "consolidatestocksummary")
        If gdataset.Tables("consolidatestocksummary").Rows.Count > 0 Then

        Else

            str = "    CREATE TABLE [dbo].[consolidatestocksummary]("
            str = str & "   [autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " [itemcode] [varchar](50) NULL,"
            str = str & " [itemname] [varchar](50) NULL,"
            str = str & " [opqty] [numeric](18, 3) NULL,"
            str = str & " [clqty] [numeric](18, 3) NULL,"
            str = str & " [uom] [varchar](50) NULL"
            str = str & ") "

            gconnection.dataOperation1(6, str, "consolidatestocksummary")

        End If
        str = "select * from sysobjects where name='ACCOUNTSGLACCOUNTMASTER' and xtype='U'"
        gconnection.getDataSet(str, "ACCOUNTSGLACCOUNTMASTER")
        If gdataset.Tables("ACCOUNTSGLACCOUNTMASTER").Rows.Count > 0 Then

        Else

            str = "CREATE TABLE [dbo].[ACCOUNTSGLACCOUNTMASTER]("
            str = str & "	[accode] [varchar](10) NOT NULL,"
            str = str & "	[acdesc] [varchar](100) NULL,"
            str = str & "	[alias] [varchar](30) NULL,"
            str = str & "	[subledgerflag] [varchar](1) NULL,"
            str = str & "	[groupname] [varchar](100) NULL,"
            str = str & "	[subgroup] [varchar](30) NULL,"
            str = str & "	[actype] [varchar](30) NULL,"
            str = str & "	[budgetflag] [varchar](1) NULL,"
            str = str & "	[bank] [varchar](30) NULL,"
            str = str & "	[bankaddress] [varchar](30) NULL,"
            str = str & "	[opdebits] [numeric](18, 2) NULL,"
            str = str & "	[opcredits] [numeric](18, 2) NULL,"
            str = str & "	[cldebits] [numeric](18, 2) NULL,"
            str = str & "	[clcredits] [numeric](18, 2) NULL,"
            str = str & "		[aprdebits] [numeric](18, 2) NULL,"
            str = str & "	[aprcredits] [numeric](18, 2) NULL,"
            str = str & "	[maydebits] [numeric](18, 2) NULL,"
            str = str & "	[maycredits] [numeric](18, 2) NULL,"
            str = str & "	[jundebits] [numeric](18, 2) NULL,"
            str = str & "	[juncredits] [numeric](18, 2) NULL,"
            str = str & "	[juldebits] [numeric](18, 2) NULL,"
            str = str & "	[julcredits] [numeric](18, 2) NULL,"
            str = str & "	[augdebits] [numeric](18, 2) NULL,"
            str = str & "	[augcredits] [numeric](18, 2) NULL,"
            str = str & "	[sepdebits] [numeric](18, 2) NULL,"
            str = str & "	[sepcredits] [numeric](18, 2) NULL,"
            str = str & "	[octdebits] [numeric](18, 2) NULL,"
            str = str & "	[octcredits] [numeric](18, 2) NULL,"
            str = str & "	[novdebits] [numeric](18, 2) NULL,"
            str = str & "	[novcredits] [numeric](18, 2) NULL,"
            str = str & "	[decdebits] [numeric](18, 2) NULL,"
            str = str & "	[deccredits] [numeric](18, 2) NULL,"
            str = str & "	[jandebits] [numeric](18, 2) NULL,"
            str = str & "	[jancredits] [numeric](18, 2) NULL,"
            str = str & "	[febdebits] [numeric](18, 2) NULL,"
            str = str & "	[febcredits] [numeric](18, 2) NULL,"
            str = str & "	[mardebits] [numeric](18, 2) NULL,"
            str = str & "	[marcredits] [numeric](18, 2) NULL,"
            str = str & "	[actuallastyear] [numeric](18, 2) NULL,"
            str = str & "	[projectedlastyear] [numeric](18, 2) NULL,"
            str = str & "	[actualcurrentyear] [numeric](18, 2) NULL,"
            str = str & "	[projectedcurrentyear] [numeric](18, 2) NULL,"
            str = str & "	[actualnextyear] [numeric](18, 0) NULL,"
            str = str & "	[projectednextyear] [numeric](18, 0) NULL,"
            str = str & "	[adduserid] [varchar](30) NULL,"
            str = str & "	[adddatetime] [datetime] NULL,"
            str = str & "	[updateuserid] [varchar](30) NULL,"
            str = str & "	[updatedatetime] [datetime] NULL,"
            str = str & "	[freezeflag] [varchar](1) NULL,"
            str = str & "	[freezeuserid] [varchar](30) NULL,"
            str = str & "	[freezedatetime] [datetime] NULL,"
            str = str & "	[BSPL] [varchar](1) NULL,"
            str = str & "	[FREZEEFLAG] [varchar](1) NULL,"
            str = str & "		[CATEGORY] [varchar](10) NULL,"
            str = str & "	[DEPPER] [numeric](9, 2) NULL,"
            str = str & "	[SUBSUBGROUP] [varchar](50) NULL,"
            str = str & "	[SLTYPE] [varchar](50) NULL,"
            str = str & "	[COST] [varchar](10) NULL,"
            str = str & "	[COSTMASTER] [varchar](10) NULL"
            str = str & "	 )"
            gconnection.dataOperation1(6, str, "ACCOUNTSGLACCOUNTMASTER")

        End If
        str = "Select * from sysobjects where name='AccountsCostCenterMaster' and xtype='U'"
        gconnection.getDataSet(str, "AccountsCostCenterMaster")
        If gdataset.Tables("AccountsCostCenterMaster").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE AccountsCostCenterMaster"
            str = str & " ("
            str = str & " [costcentercode] [varchar](10) NOT NULL,"
            str = str & "[costcenterdesc] [varchar](50) NULL,"
            str = str & "[primarygroupcode] [varchar](10) NULL,"
            str = str & "[primarygroupdesc] [varchar](50) NULL,"
            str = str & "[secondarygroupcode] [varchar](10) NULL,"
            str = str & "	[secondarygroupdesc] [varchar](50) NULL,"
            str = str & "[adduserid] [varchar](50) NULL,"
            str = str & "[adddatetime] [datetime] NULL,"
            str = str & "[updateuserid] [varchar](50) NULL,"
            str = str & "[updatedatetime] [datetime] NULL,"
            str = str & "[freezeflag] [varchar](1) NULL,"
            str = str & "[freezeuserid] [varchar](50) NULL,"
            str = str & "[freezedatetime] [datetime] NULL,"
            str = str & "[OPDEBITS] [numeric](13, 2) NULL,"
            str = str & "[OPCREDITS] [numeric](13, 2) NULL,"
            str = str & "[CLDEBITS] [numeric](13, 2) NULL,"
            str = str & "[CLCREDITS] [numeric](13, 2) NULL,"
            str = str & "[APRDEBITS] [numeric](13, 2) NULL,"
            str = str & "[APRCREDITS] [numeric](13, 2) NULL,"
            str = str & "[MAYDEBITS] [numeric](13, 2) NULL,"
            str = str & "[MAYCREDITS] [numeric](13, 2) NULL,"
            str = str & "[JUNDEBITS] [numeric](13, 2) NULL,"
            str = str & "[JUNCREDITS] [numeric](13, 2) NULL,"
            str = str & "[JULDEBITS] [numeric](13, 2) NULL,"
            str = str & "[JULCREDITS] [numeric](13, 2) NULL,"
            str = str & "[AUGDEBITS] [numeric](13, 2) NULL,"
            str = str & "[AUGCREDITS] [numeric](13, 2) NULL,"
            str = str & "[SEPDEBITS] [numeric](13, 2) NULL,"
            str = str & "[SEPCREDITS] [numeric](13, 2) NULL,"
            str = str & "	[OCTDEBITS] [numeric](13, 2) NULL,"
            str = str & "[OCTCREDITS] [numeric](13, 2) NULL,"
            str = str & "[NOVDEBITS] [numeric](13, 2) NULL,"
            str = str & "[NOVCREDITS] [numeric](13, 2) NULL,"
            str = str & "[DECDEBITS] [numeric](13, 2) NULL,"
            str = str & "[DECCREDITS] [numeric](13, 2) NULL,"
            str = str & "[JANDEBITS] [numeric](13, 2) NULL,"
            str = str & "[JANCREDITS] [numeric](13, 2) NULL,"
            str = str & "[FEBDEBITS] [numeric](13, 2) NULL,"
            str = str & "[FEBCREDITS] [numeric](13, 2) NULL,"
            str = str & "[MARDEBITS] [numeric](13, 2) NULL,"
            str = str & "[MARCREDITS] [numeric](13, 2) NULL"
            str = str & " )"
            gconnection.dataOperation1(6, str, "AccountsCostCenterMaster")
        End If
        str = "Select * from sysobjects where name='Accountstagging' and xtype='U'"
        gconnection.getDataSet(str, "Accountstagging")
        If gdataset.Tables("Accountstagging").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE Accountstagging"
            str = str & " ("
            str = str & " [Code] [varchar](30) NOT NULL,"
            str = str & "[description] [varchar](50) NULL,"
            str = str & "[accountcode] [varchar](50) NULL,"
            str = str & "[accountdesc] [varchar](100) NULL,"
            str = str & "[slcode] [varchar](50) NULL,"
            str = str & "	[sldesc] [varchar](100) NULL,"
            str = str & "[costcentercode] [varchar](50) NULL,"
            str = str & "	[costcenterdesc] [varchar](100) NULL,"
            str = str & "[void] [varchar](10) NULL,"
            str = str & "[tablename]  [varchar](50) NULL,"
            str = str & "[colname] [varchar](50) NULL"
            str = str & " )"
            gconnection.dataOperation1(6, str, "Accountstagging")
        End If

        str = "Select * from sysobjects where name='Itemtaxtagging' and xtype='U'"
        gconnection.getDataSet(str, "Itemtaxtagging")
        If gdataset.Tables("Itemtaxtagging").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE Itemtaxtagging"
            str = str & " ("
            str = str & " [ItemCode] [varchar](30) NOT NULL,"
            str = str & "[ItemName] [varchar](50) NULL,"
            str = str & " [TaxCode] [varchar](30)  NULL,"
            str = str & "[TaxDesc] [varchar](50) NULL,"
            str = str & "[Taxperc] [numeric](8,2) NULL,"
            str = str & "[glaccountin] [varchar](50) NULL,"
            str = str & "[void] [varchar](50) NULL"

            str = str & " )"
            gconnection.dataOperation1(6, str, "Itemtaxtagging")
        End If
        str = "Select * from sysobjects where name='AccountsTaxMaster' and xtype='U'"
        gconnection.getDataSet(str, "AccountsTaxMaster")
        If gdataset.Tables("AccountsTaxMaster").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE AccountsTaxMaster"
            str = str & " ("
            str = str & " [taxcode] [varchar](10) NOT NULL,"
            str = str & " [taxdesc] [varchar](50) NULL,"
            str = str & " [taxpercentage] [numeric](18, 2) NULL,"
            str = str & " [typeoftax] [varchar](20) NULL,"
            str = str & " [glaccountin] [varchar](10) NULL,"
            str = str & " 	[glaccountdesc] [varchar](50) NULL,"
            str = str & " [subledgercode] [varchar](10) NULL,"
            str = str & " [subledgerdesc] [varchar](50) NULL,"
            str = str & " [costcentercode] [varchar](10) NULL,"
            str = str & " [costcenterdesc] [varchar](50) NULL,"
            str = str & " [adduserid] [varchar](50) NULL,"
            str = str & " [adddatetime] [datetime] NULL,"
            str = str & " [updateuserid] [varchar](50) NULL,"
            str = str & " [updatedatetime] [datetime] NULL,"
            str = str & " [freezeflag] [varchar](1) NULL,"
            str = str & " [freezeuserid] [varchar](50) NULL,"
            str = str & " [freezedatetime] [datetime] NULL"
            str = str & " )"
            gconnection.dataOperation1(6, str, "AccountsTaxMaster")
        End If
        str = "Select * from sysobjects where name='PO_AMENDMENT' and xtype='U'"
        gconnection.getDataSet(str, "PO_AMENDMENT")
        If gdataset.Tables("PO_AMENDMENT").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE PO_AMENDMENT"
            str = str & " ("
            str = str & " [autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "[pono] [varchar](25) NULL,"
            str = str & "[poamendmentno] [varchar](12) NULL,"
            str = str & "[poamendmentdate] [datetime] NULL,"
            str = str & "[poamendmentdesc] [varchar](172) NULL"
            str = str & " )"
            gconnection.dataOperation1(6, str, "PO_AMENDMENT")
        End If
        str = "Select * from sysobjects where name='PO_DELIVERYTERMS' and xtype='U'"
        gconnection.getDataSet(str, "PO_DELIVERYTERMS")
        If gdataset.Tables("PO_DELIVERYTERMS").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE [PO_DELIVERYTERMS] "
            str = str & " ("
            str = str & "[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "[deliverytermcode] [varchar](50) NULL,"
            str = str & "	[deliverytermdesc] [varchar](50) NULL,"
            str = str & "[freeze] [varchar](1) NULL,"
            str = str & "[adduser] [varchar](50) NULL,"
            str = str & "[adddatetime] [datetime] NULL,"
            str = str & "[updateuser] [varchar](50) NULL,"
            str = str & "[updatedatetime] [datetime] NULL,"
            str = str & "[freezeuser] [varchar](50) NULL,"
            str = str & "[freezedatetime] [datetime] NULL"
            str = str & ") "


            gconnection.dataOperation1(6, str, "PO_DELIVERYTERMS")
        End If
        str = "Select * from sysobjects where name='PO_FOLLOWUP' and xtype='U'"
        gconnection.getDataSet(str, "PO_FOLLOWUP")
        If gdataset.Tables("PO_FOLLOWUP").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE [PO_FOLLOWUP] "
            str = str & " ("
            str = str & "[autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "[pono] [varchar](25) NULL,"
            str = str & "[pofollowupno] [varchar](12) NULL,"
            str = str & "[pofollowupdate] [datetime] NULL,"
            str = str & "[pofollowupdesc] [varchar](172) NULL"
            str = str & ") "


            gconnection.dataOperation1(6, str, "PO_FOLLOWUP")
        End If
        str = "Select * from sysobjects where name='PO_ITEMDETAILS' and xtype='U'"
        gconnection.getDataSet(str, "PO_ITEMDETAILS")
        If gdataset.Tables("PO_ITEMDETAILS").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE [PO_ITEMDETAILS] "
            str = str & " ("
            str = str & " [autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " [pono] [varchar](25) NULL,"
            str = str & " [ITEMCODE] [varchar](30) NULL,"
            str = str & "	[ITEMNAME] [varchar](50) NULL,"
            str = str & " [UOM] [varchar](50) NULL,"
            str = str & " [QUANTITY] [numeric](18, 2) NULL,"
            str = str & " [baseamount] [numeric](18, 2) NULL,"
            str = str & " [Rate] [numeric](18, 2) NULL,"

            str = str & " [discper] [numeric](18, 2) NULL,"
            str = str & " [taxper] [numeric](18, 2) NULL,"
            str = str & " [discamt] [numeric](18, 2) NULL,"
            str = str & " [vatamt] [numeric](18, 2) NULL,"
            str = str & " [TOTALamount] [numeric](18, 2) NULL,"
            str = str & " [taxcode] [varchar](50) NULL,"
            str = str & " [freeze] [varchar](1) NULL,"
            str = str & " [qtystatus] [varchar] (50) NULL,"
            str = str & " [receivedqty] [numeric] (18,2) NULL,"
            str = str & " [amountafterdiscount] [numeric] (18,2) NULL,"
            str = str & " [othchg] [numeric] (18,2) NULL,"
            str = str & " [raterange] [varchar] (10) NULL,"
            str = str & " [qtyrange] [varchar] (10) NULL,"
            str = str & " [adduser] [varchar](25) NULL,"
            str = str & " [adddatetime] [datetime] NULL,"
            str = str & " [updateuser] [varchar](25) NULL,"
            str = str & " [updatedatetime] [datetime] NULL,"
            str = str & " [voiduser] [varchar](25) NULL,"
            str = str & " [voiddatetime] [datetime] NULL,"
            str = str & " [versionno] [varchar](50) NULL"

            str = str & ") "


            gconnection.dataOperation1(6, str, "PO_ITEMDETAILS")
        End If

        str = "Select * from sysobjects where name='PO_ITEMDETAILS_log' and xtype='U'"
        gconnection.getDataSet(str, "PO_ITEMDETAILS_log")
        If gdataset.Tables("PO_ITEMDETAILS_log").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE [PO_ITEMDETAILS_log] "
            str = str & " ("
            str = str & " [autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " [pono] [varchar](25) NULL,"
            str = str & " [ITEMCODE] [varchar](30) NULL,"
            str = str & "	[ITEMNAME] [varchar](50) NULL,"
            str = str & " [UOM] [varchar](50) NULL,"
            str = str & " [QUANTITY] [numeric](18, 2) NULL,"
            str = str & " [baseamount] [numeric](18, 2) NULL,"
            str = str & " [Rate] [numeric](18, 2) NULL,"

            str = str & " [discper] [numeric](18, 2) NULL,"
            str = str & " [taxper] [numeric](18, 2) NULL,"
            str = str & " [discamt] [numeric](18, 2) NULL,"
            str = str & " [vatamt] [numeric](18, 2) NULL,"
            str = str & " [TOTALamount] [numeric](18, 2) NULL,"
            str = str & " [taxcode] [varchar](50) NULL,"
            str = str & " [freeze] [varchar](1) NULL,"
            str = str & " [qtystatus] [varchar] (50) NULL,"
            str = str & " [receivedqty] [numeric] (18,2) NULL,"
            str = str & " [amountafterdiscount] [numeric] (18,2) NULL,"
            str = str & " [othchg] [numeric] (18,2) NULL,"
            str = str & " [raterange] [varchar] (10) NULL,"
            str = str & " [qtyrange] [varchar] (10) NULL,"
            str = str & " [adduser] [varchar](25) NULL,"
            str = str & " [adddatetime] [datetime] NULL,"
            str = str & " [updateuser] [varchar](25) NULL,"
            str = str & " [updatedatetime] [datetime] NULL,"
            str = str & " [voiduser] [varchar](25) NULL,"
            str = str & " [voiddatetime] [datetime] NULL,"
            str = str & " [versionno] [varchar](50) NULL"


            str = str & ") "


            gconnection.dataOperation1(6, str, "PO_ITEMDETAILS_log")
        End If

        str = "Select * from sysobjects where name='PO_HDR' and xtype='U'"
        gconnection.getDataSet(str, "PO_HDR")
        If gdataset.Tables("PO_HDR").Rows.Count > 0 Then

        Else
            str = "           CREATE TABLE [dbo].[PO_HDR]("
            str = str & "	[autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " [PO_NO] VARCHAR(50) NULL ,"
            str = str & "	[pono] [varchar](50) NULL,"
            str = str & "	[doctype] [varchar](50) NULL,"
            str = str & "	[storecode] [varchar](50) NULL,"
            str = str & "	[podate] [datetime] NULL,"
            str = str & "	[poquotno] [varchar](10) NULL,"
            str = str & "	[povendorcode] [varchar](10) NULL,"
            str = str & "	[podepartment] [varchar](40) NULL,"
            str = str & "	[poapprovedby] [varchar](25) NULL,"
            str = str & "	[postatus] [varchar](25) NULL,"
            str = str & "	[potype] [varchar](50) NULL,"
            str = str & "	[povalidfrom] [datetime] NULL,"
            str = str & "	[povalidupto] [datetime] NULL,"
            str = str & "		[povalue] [numeric](18, 2) NULL,"
            str = str & "	[pototalvat] [numeric](18, 2) NULL,"
            str = str & "	[pototaltax] [numeric](18, 2) NULL,"
            str = str & "	[pototaldiscount] [numeric](18, 2) NULL,"
            str = str & "	[poadvance] [numeric](18, 2) NULL,"
            str = str & "	[pobalance] [numeric](18, 2) NULL,"
            str = str & "	[poterms] [varchar](25) NULL,"
            str = str & "	[pootherchgplus] [numeric](18, 2) NULL,"
            str = str & "	[pootherchgmin] [numeric](18, 2) NULL,"
            str = str & "	[podeliveryterms] [varchar](25) NULL,"
            str = str & "	[pomcpo] [varchar](4) NULL,"
            str = str & "	[poremarks] [varchar](100) NULL,"
            str = str & "	[poclosure] [varchar](4) NULL,"
            str = str & "		[freeze] [varchar](2) NULL,"
            str = str & "	[adduser] [varchar](25) NULL,"
            str = str & "		[adddatetime] [datetime] NULL,"
            str = str & "	[POOVERALLDISC] [numeric](18, 2) NULL,"
            str = str & "	[POcf] [numeric](18, 2) NULL,"
            str = str & "		[POtransport] [numeric](18, 2) NULL,"
            str = str & "		[PODELIVERYAMT] [numeric](18, 2) NULL,"
            str = str & "		[POSALET] [varchar](100) NULL,"
            str = str & "		[PODESPMODE] [varchar](100) NULL,"
            str = str & "	[PODOCSTHROUGH] [varchar](100) NULL,"
            str = str & "	[totqty] [numeric](18, 3) NULL,"
            str = str & "		[versionno] [varchar](50) null,"
            str = str & "	[updateuser] [varchar](25) NULL,"
            str = str & "	[updatedatetime] [datetime] NULL,"
            str = str & "	[freezeuser] [varchar](25) NULL,"
            str = str & "		[freezedatetime] [datetime] NULL "

            str = str & "	 ) ON [PRIMARY] "


            gconnection.dataOperation1(6, str, "PO_HDR")
        End If
        str = "Select * from sysobjects where name='PO_IMAGEHDR' and xtype='U'"
        gconnection.getDataSet(str, "PO_IMAGEHDR")
        If gdataset.Tables("PO_IMAGEHDR").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE [PO_IMAGEHDR] "
            str = str & " ("
            str = str & "	[autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " [PO_NO] VARCHAR(50) NULL ,"

            str = str & "	[pono] [varchar](50) NULL,"
            str = str & "	[doctype] [varchar](50) NULL,"
            str = str & "	[storecode] [varchar](50) NULL,"
            str = str & "	[podate] [datetime] NULL,"
            str = str & "	[poquotno] [varchar](10) NULL,"
            str = str & "	[povendorcode] [varchar](10) NULL,"
            str = str & "	[podepartment] [varchar](40) NULL,"
            str = str & "	[poapprovedby] [varchar](25) NULL,"
            str = str & "	[postatus] [varchar](25) NULL,"
            str = str & "	[potype] [varchar](50) NULL,"
            str = str & "	[povalidfrom] [datetime] NULL,"
            str = str & "	[povalidupto] [datetime] NULL,"
            str = str & "		[povalue] [numeric](18, 2) NULL,"
            str = str & "	[pototalvat] [numeric](18, 2) NULL,"
            str = str & "	[pototaltax] [numeric](18, 2) NULL,"
            str = str & "	[pototaldiscount] [numeric](18, 2) NULL,"
            str = str & "	[poadvance] [numeric](18, 2) NULL,"
            str = str & "	[pobalance] [numeric](18, 2) NULL,"
            str = str & "	[poterms] [varchar](25) NULL,"
            str = str & "	[pootherchgplus] [numeric](18, 2) NULL,"
            str = str & "	[pootherchgmin] [numeric](18, 2) NULL,"
            str = str & "	[podeliveryterms] [varchar](25) NULL,"
            str = str & "	[pomcpo] [varchar](4) NULL,"
            str = str & "	[poremarks] [varchar](100) NULL,"
            str = str & "	[poclosure] [varchar](4) NULL,"
            str = str & "		[freeze] [varchar](2) NULL,"
            str = str & "	[adduser] [varchar](25) NULL,"
            str = str & "		[adddatetime] [datetime] NULL,"
            str = str & "	[POOVERALLDISC] [numeric](18, 2) NULL,"
            str = str & "	[POcf] [numeric](18, 2) NULL,"
            str = str & "		[POtransport] [numeric](18, 2) NULL,"
            str = str & "		[PODELIVERYAMT] [numeric](18, 2) NULL,"
            str = str & "		[POSALET] [varchar](100) NULL,"
            str = str & "		[PODESPMODE] [varchar](100) NULL,"
            str = str & "	[PODOCSTHROUGH] [varchar](100) NULL,"
            str = str & "	[totqty] [numeric](18, 3) NULL,"
            str = str & "		[versionno] [varchar](50) null,"
            str = str & "	[updateuser] [varchar](25) NULL,"
            str = str & "	[updatedatetime] [datetime] NULL,"
            str = str & "	[freezeuser] [varchar](25) NULL,"
            str = str & "		[freezedatetime] [datetime] NULL "
            str = str & ") "


            gconnection.dataOperation1(6, str, "PO_IMAGEHDR")
        End If


        str = "Select * from sysobjects where name='INVENTORY_INDENTHDR' and xtype='U'"
        gconnection.getDataSet(str, "INVENTORY_INDENTHDR")

        If gdataset.Tables("INVENTORY_INDENTHDR").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE [INVENTORY_INDENTHDR] "
            str = str & " ("
            str = str & " [AUTOID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " [INDENT_NO] [varchar](50) NOT NULL,"
            str = str & " [INDENT_DATE] [datetime] NULL,"
            str = str & " [fromStoreCode] [varchar](15) NULL,"
            str = str & " [STORELOCATIONCODE] [varchar](10) NULL,"
            str = str & " [STORELOCATIONNAME] [varchar](50) NULL,"

            str = str & " [REMARKS] [varchar](100) NULL,"
            str = str & " [VOID] [varchar](1) NULL,"
            str = str & " [ADDUSER] [varchar](30) NULL,"
            str = str & " [ADDDATETIME] [datetime] NULL,"
            str = str & " [Updateuser] [varchar](30) NULL,"
            str = str & "	[UPDATETIME] [datetime] NULL,"
            str = str & " [DOCNO] [nvarchar](50) NULL,"
            str = str & " [voiduser] [varchar](30) NULL,"
            str = str & "	[voidDATETIME] [datetime] NULL"
            str = str & ") "


            gconnection.dataOperation1(6, str, "INVENTORY_INDENTHDR")
        End If
        str = "Select * from sysobjects where name='INVENTORY_INDENTDET' and xtype='U'"
        gconnection.getDataSet(str, "INVENTORY_INDENTDET")
        If gdataset.Tables("INVENTORY_INDENTDET").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE [INVENTORY_INDENTDET] "
            str = str & " ("
            str = str & " [AUTOID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " [INDENT_NO] [varchar](50) NOT NULL,"
            str = str & " [INDENT_DATE] [datetime] NULL,"
            str = str & " [ITEMCODE] [varchar](30) NULL,"
            str = str & "	[ITEMNAME] [varchar](50) NULL,"
            str = str & "[UOM] [varchar](50) NULL,"
            str = str & "[QTY] [numeric](18, 2) NULL,"
            str = str & " [REMARKS] [varchar](100) NULL,"
            str = str & " [VOID] [varchar](1) NULL,"
            str = str & " [ADDUSER] [varchar](50) NULL,"
            str = str & " [ADDDATETIME] [datetime] NULL,"
            str = str & " [Updateuser] [varchar](50) NULL,"
            str = str & "	[UPDATETIME] [datetime] NULL,"
            str = str & " [voiduser] [varchar](50) NULL,"
            str = str & "	[voidDATETIME] [datetime] NULL"
            str = str & ") "


            gconnection.dataOperation1(6, str, "INVENTORY_INDENTDET")
        End If
        str = "drop view VW_INV_IDENTBILL "
        str = "Select * from sysobjects where name='VW_INV_IDENTBILL' and xtype='V'"
        gconnection.getDataSet(str, "VW_INV_IDENTBILL")
        If gdataset.Tables("VW_INV_IDENTBILL").Rows.Count > 0 Then

        Else
            str = "CREATE VIEW [dbo].[VW_INV_IDENTBILL] As  "
            str = str & "  SELECT 	ISNULL(HDR.INDENT_NO,'') INDENT_NO, ISNULL(HDR.INDENT_DATE,'')  INDENT_DATE,"
            str = str & " ISNULL(HDR.FROMSTORECODE,'') FROMSTORECODE , ISNULL(HDR.STORELOCATIONCODE,'') STORELOCATIONCODE, "
            str = str & " ISNULL(HDR.STORELOCATIONNAME,'') STORELOCATIONNAME, "
            str = str & " ISNULL(HDR.REMARKS,'') REMARKS, "
            str = str & " ISNULL(ITEMCODE,'') ITEMCODE, ISNULL(ITEMNAME,'') ITEMNAME, ISNULL(UOM,'') UOM, "
            str = str & " ISNULL(QTY,0) QTY , ISNULL(DET.ADDDATEtime,'') ADDDATE,isnull(hdr.adduser,'')as adduser"
            str = str & "             FROM INVENTORY_INDENTHDR HDR "
            str = str & "           INNER JOIN INVENTORY_INDENTDET AS DET ON HDR.INDENT_NO = DET.INDENT_NO "



            gconnection.dataOperation1(6, str, "VW_INV_IDENTBILL")
        End If
        str = "Select * from sysobjects where name='PO_VENDORMASTER' and xtype='U'"
        gconnection.getDataSet(str, "PO_VENDORMASTER")
        If gdataset.Tables("PO_VENDORMASTER").Rows.Count > 0 Then

        Else
            str = "   CREATE          TABLE  [dbo].[PO_VENDORMASTER] ("
            str = str & " [AUTOID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " [VENDORCODE] [varchar](10) NOT NULL,"
            str = str & " [VENDORTYPE] [varchar](15) NULL,"
            str = str & " [VENDORNAME] [varchar](50) NULL,"
            str = str & "	[SHORTNAME] [varchar](15) NULL,"
            str = str & " [PANNO] [varchar](15) NULL,"
            str = str & " [CASTNO] [varchar](15) NULL,"
            str = str & " [LSTNO] [varchar](15) NULL,"
            str = str & " [RATINGS] [varchar](15) NULL,"
            str = str & " [LICENCENO] [varchar](15) NULL,"
            str = str & " [LICENCEDATE] [datetime] NULL,"
            str = str & " [ADDRESS] [varchar](20) NULL,"
            str = str & "	[CITY] [varchar](20) NULL,"
            str = str & " [STATE] [varchar](20) NULL,"
            str = str & "	[COUNTRY] [varchar](20) NULL,"
            str = str & " [PINCODE] [NUMERIC](18,0) NULL,"
            str = str & "	[PHONE1] [varchar](15) NULL,"
            str = str & "	[PHONE2] [varchar](15) NULL,"
            str = str & "	[FAX] [varchar](15) NULL,"
            str = str & " [EMAIL] [varchar](50) NULL,"
            str = str & " [CONTACTPERSON] [varchar](25) NULL,"
            str = str & " [REMARKS] [varchar](50) NULL,"
            str = str & " [FREEZE] [CHAR](1) NULL,"
            str = str & " [FREEZEUSER] [varchar](10) NULL,"
            str = str & " [FREEZEDATETIME] [DATETIME] NULL,"
            str = str & " [ADDUSER] [varchar](10) NULL,"
            str = str & " [ADDDATETIME] [DATETIME] NULL,"
            str = str & " [UPDATEUSER] [varchar](10) NULL,"
            str = str & " [UPDATEDATETIME] [DATETIME] NULL,"
            str = str & " [ADDRESS1] [varchar](100) NULL,"
            str = str & " [ADDRESS2] [varchar](100) NULL,"
            str = str & " [ADDRESS3] [varchar](100) NULL,"
            str = str & " [CATEGORY] [varchar](30) NULL,"
            str = str & " [TINNO] [varchar](50) NULL"
            str = str & "	)"


            gconnection.dataOperation1(6, str, "PO_VENDORMASTER")
        End If
        str = "Select * from sysobjects where name='INV_SPWeightedRateCalculation' and xtype='P'"
        gconnection.getDataSet(str, "INV_SPWeightedRateCalculation")
        If gdataset.Tables("INV_SPWeightedRateCalculation").Rows.Count > 0 Then

        Else
            str = "   CREATE procedure [dbo].[INV_SPWeightedRateCalculation]  "
            str = str & " (  "
            str = str & "  @ttodate as datetime,  "
            str = str & "   @tpitemcode as varchar(50),  "
            str = str & "  @tstorecode as varchar(50),  "
            str = str & " @tuom as varchar(50),  "
            str = str & "  @currentgrnqty as float,  "
            str = str & "  @currentPurchaseRate as float,  "
            str = str & "   @WeightedRate float OUTPUT,  "
            str = str & "  @lastweightedrate float output"
            str = str & "  )"
            str = str & " as  "
            str = str & "    Begin "

            str = str & " declare @closingqty float   "
            str = str & " declare @totqty float,@totvalue float  "

            '--exec dbo.[Inv_SPClosingQuantityCalculation] @todate =@ttodate,@pitemcode =@tpitemcode,@storecode=@tstorecode,@uom =@tuom  
            str = str & " select TOP 1  @closingqty= closingstock from closingqty where itemcode=@tpitemcode "
            str = str & " and storecode=@tstorecode and trndate<@ttodate order by trndate desc"
            '--select @closingqty= sum(qty * MF) from ClosingTable  
            str = str & " if exists(select * from ratelist where ItemCode=@tpitemcode and Uom=@tuom and storecode=@tstorecode and grndate<@ttodate)  "
            str = str & "  Begin "
            str = str & "  select top 1 @lastweightedrate=weightedrate from  ratelist where ItemCode=@tpitemcode and Uom=@tuom and storecode=@tstorecode and grndate<@ttodate"
            str = str & "  order by Grndate Desc  "
            str = str & "    End"
            str = str & " else  "
            str = str & "    Begin "
            str = str & " SELECT @lastweightedrate=ROUND((ISNULL(B.openningvalue,0)/ISNULL(B.openningqty ,0)),2)  FROM  INV_InventoryItemMaster A INNER JOIN   "
            str = str & " inv_InventoryOpenningstock B ON A.ITEMCODE=B.ITEMCODE and B.STORECODE=@tstorecode and B.Uom=@tuom and b.[openningqty ]<>0  "
            str = str & "    End"

            str = str & " if (@lastweightedrate=null)  "
            str = str & " Begin"
            str = str & "   set @lastweightedrate = @currentPurchaseRate  "
            str = str & "      End"

            str = str & " set @totqty = @closingqty + @currentgrnqty  "
            str = str & " set @totvalue = (@lastweightedrate * @closingqty) + (@currentgrnqty * @currentPurchaseRate)  "

            str = str & "   if(@totqty<>0)"
            str = str & "  begin "
            str = str & "   set @WeightedRate= (@totvalue/@totqty)"
            str = str & "    End"
            str = str & "      Else"
            str = str & "      begin "
            str = str & "   set @WeightedRate= (@totvalue/@totqty)"
            str = str & "       End"

            str = str & "      set @lastweightedrate=@lastweightedrate  "
            str = str & "     End "

            gconnection.dataOperation1(6, str, "INV_SPWeightedRateCalculation")
        End If

        str = "Select * from sysobjects where name='PO_VIEW_VENDORMASTER' and xtype='V'"
        gconnection.getDataSet(str, "PO_VIEW_VENDORMASTER")
        If gdataset.Tables("PO_VIEW_VENDORMASTER").Rows.Count > 0 Then

        Else
            str = "   CREATE          view [dbo].[PO_VIEW_VENDORMASTER] "
            str = str & " as         "
            str = str & " select isnull(slcode,'') as vendorcode,isnull(slname,'') as vendorname, "
            str = str & "  isnull(ADDRESS1,'')AS ADDRESS1, isnull(ADDRESS2,'') as address2, isnull(address3,'') AS ADDRESS3, isnull(city,'') AS CITY,   isnull(pin,'') + ' ' + isnull(state,'') as state,ISNULL(SLTYPE,'') AS SLTYPE, "
            str = str & "  '' AS PINCODE,'' AS PHONE ,ISNULL(CELLNO,'') AS MOBILE,'' AS FAX,'' AS EMAIL,contactperson AS CONTACTPERSON ,ISNULL(VATNO,'')AS VATNO,ISNULL(CSTNO ,'') AS CSTNO,ISNULL(TINNO,'')AS TINNO,ISNULL(PANNO,'')AS PANNO "
            str = str & " from accountssubledgermaster where SLTYPE ='SUPPLIER' and isnull(freezeflag,'')<>'y' "
            str = str & "   union "
            str = str & " select isnull(vendorcode,'') as vendorcode,isnull(vendorname,'') as vendorname,                      "
            str = str & " isnull(ADDRESS,'')ADDRESS1,isnull(ADDRESS2,'') AS ADDRESS2, isnull(address3,'')as address3, isnull(CITY,'') as city, isnull(state,'') as state, "
            str = str & "   '' AS SLTYPE,ISNULL(cast(PINCODE as varchar(20)),'') AS PINCODE,ISNULL(cast(PHONE1 as varchar(35)),'') AS PHONE,ISNULL(cast(PHONE2 as varchar(35)),'') AS MOBILE,   "
            str = str & " ISNULL(cast(FAX as varchar(20)),'') AS FAX,ISNULL(EMAIL,'') AS EMAIL,ISNULL(CONTACTPERSON,'') AS CONTACTPERSON  ,''AS VATNO,ISNULL(CASTNO ,'') AS CSTNO,ISNULL(LSTNO,'')AS TINNO,ISNULL(PANNO,'')AS PANNO  "
            str = str & " from po_vendormaster where isnull(freeze,'')<>'y'  "
            gconnection.dataOperation1(6, str, "PO_VIEW_VENDORMASTER")
        End If

        str = "Select * from sysobjects where name='Grn_header' and xtype='U'"
        gconnection.getDataSet(str, "Grn_header")
        If gdataset.Tables("Grn_header").Rows.Count > 0 Then

        Else
            str = "   CREATE          TABLE  [dbo].[Grn_header] ("
            str = str & " [AUTOID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " [category] [varchar](50) NOT NULL,"
            str = str & " [grnno] [varchar](50) NULL,"
            str = str & " [grndetails] [varchar](50) NULL,"
            str = str & " [grndate] [datetime] NULL,"
            str = str & " [pono] [varchar](50) NULL,"
            str = str & " [Supplierinvno] [varchar](10) NULL,"
            str = str & " [Supplierdate] [datetime] NULL,"
            str = str & " [Suppliercode] [varchar](50) NULL,"
            str = str & " [Suppliername] [varchar](50) NULL,"

            str = str & " [Totalamount] [numeric](18, 2) NULL,"
            str = str & " [VATamount] [numeric](18, 2) NULL,"
            str = str & " [Surchargeamt] [numeric](18, 2) NULL,"
            str = str & " [OverallDiscount] [numeric](18, 2) NULL,"
            str = str & " [Discount] [numeric](18, 2) NULL,"
            str = str & " [Billamount] [numeric](18, 2) NULL,"
            str = str & " [Remarks] [varchar](200) NULL,"
            str = str & " [Void] [varchar](5) NULL,"
            str = str & " [adduser] [varchar](50) NULL,"
            str = str & " [adddate] [datetime] NULL,"
            str = str & " [storecode] [varchar](50) NULL,"
            str = str & " [storedesc] [varchar](200) NULL,"
            str = str & " [grntype] [varchar](20) NULL,"
            str = str & " [updateuser] [varchar](50) NULL,"
            str = str & " [updatedate] [datetime] NULL,"
            str = str & " [voiduser] [varchar](50) NULL,"
            str = str & " [versionno] [varchar](50) Null , "
            str = str & " [voiddate] [datetime] NULL )"
            gconnection.dataOperation1(6, str, "Grn_header")
        End If
        str = "Select * from sysobjects where name='GRN_HEADERLOG' and xtype='U'"
        gconnection.getDataSet(str, "GRN_HEADERLOG")
        If gdataset.Tables("GRN_HEADERLOG").Rows.Count > 0 Then

        Else
            str = "   CREATE          TABLE  [dbo].[GRN_HEADERLOG] ("
            str = str & " [AUTOID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " [category] [varchar](50) NOT NULL,"
            str = str & " [grnno] [varchar](50) NULL,"
            str = str & " [grndetails] [varchar](50) NULL,"
            str = str & " [grndate] [datetime] NULL,"
            str = str & " [pono] [varchar](50) NULL,"
            str = str & " [Supplierinvno] [varchar](10) NULL,"
            str = str & " [Supplierdate] [datetime] NULL,"
            str = str & " [Suppliercode] [varchar](50) NULL,"
            str = str & " [Suppliername] [varchar](50) NULL,"

            str = str & " [Totalamount] [numeric](18, 2) NULL,"
            str = str & " [VATamount] [numeric](18, 2) NULL,"
            str = str & " [Surchargeamt] [numeric](18, 2) NULL,"
            str = str & " [OverallDiscount] [numeric](18, 2) NULL,"
            str = str & " [Discount] [numeric](18, 2) NULL,"
            str = str & " [Billamount] [numeric](18, 2) NULL,"
            str = str & " [Remarks] [varchar](200) NULL,"
            str = str & " [Void] [varchar](5) NULL,"
            str = str & " [adduser] [varchar](50) NULL,"
            str = str & " [adddate] [datetime] NULL,"
            str = str & " [storecode] [varchar](50) NULL,"
            str = str & " [storedesc] [varchar](200) NULL,"
            str = str & " [grntype] [varchar](20) NULL,"
            str = str & " [updateuser] [varchar](50) NULL,"
            str = str & " [updatedate] [datetime] NULL,"
            str = str & " [voiduser] [varchar](50) NULL,"
            str = str & " [versionno] [varchar](50) Null , "
            str = str & " [voiddate] [datetime] NULL )"
            gconnection.dataOperation1(6, str, "GRN_HEADERLOG")
        End If

        str = "Select * from sysobjects where name='Grn_details' and xtype='U'"
        gconnection.getDataSet(str, "Grn_details")
        If gdataset.Tables("Grn_details").Rows.Count > 0 Then

        Else
            str = "   CREATE          TABLE  [dbo].[Grn_details] ("
            str = str & " [AUTOID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " [grnno] [varchar](50) NULL,"
            str = str & " [grndetails] [varchar](50) NULL,"
            str = str & " [grndate] [datetime] NULL,"
            str = str & " [pono] [varchar](50) NULL,"
            str = str & " [Supplierinvno] [varchar](10) NULL,"
            str = str & " [amountafterdiscount] [numeric](18,2) NULL,"
            str = str & " [Suppliercode] [varchar](50) NULL,"
            str = str & " [Suppliername] [varchar](50) NULL,"
            str = str & " [Itemcode] [varchar](50) NULL,"
            str = str & " [Itemname] [varchar](50) NULL,"
            str = str & " [uom] [varchar](50) NULL,"
            str = str & " [qty] [numeric](18, 2) NULL,"
            str = str & " [rate] [numeric](18, 2) NULL,"
            str = str & " [baseamount] [numeric](18, 2) NULL,"
            str = str & " [discper] [numeric](18, 2) NULL,"
            str = str & " [taxper] [numeric](18, 2) NULL,"
            str = str & " [Discount] [numeric](18, 2) NULL,"
            str = str & " [taxamount] [numeric](18, 2) NULL,"
            str = str & " [amount] [numeric](18, 2) NULL,"
            str = str & " [taxcode] [varchar](50) NULL,"
            str = str & " [batchno] [varchar](50) NULL,"
            str = str & " [othcharge] [numeric](18, 2) NULL,"
            str = str & " [Voiditem] [varchar](5) NULL,"
            str = str & " [category] [varchar](50) NULL,"
            str = str & " [adduser] [varchar](50) NULL,"
            str = str & " [adddate] [datetime] NULL,"
            str = str & " [storecode] [varchar](50) NULL,"
            str = str & " [storedesc] [varchar](200) NULL,"
            str = str & " [versionno] [varchar] (50) NULL ,"
            str = str & " [grntype] [varchar](20) NULL )"
            gconnection.dataOperation1(6, str, "Grn_details")
        End If
        str = "Select * from sysobjects where name='GRN_DETAILSLOG' and xtype='U'"
        gconnection.getDataSet(str, "GRN_DETAILSLOG")
        If gdataset.Tables("GRN_DETAILSLOG").Rows.Count > 0 Then

        Else
            str = "   CREATE          TABLE  [dbo].[GRN_DETAILSLOG] ("
            str = str & " [AUTOID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " [grnno] [varchar](50) NULL,"
            str = str & " [grndetails] [varchar](50) NULL,"
            str = str & " [grndate] [datetime] NULL,"
            str = str & " [pono] [varchar](50) NULL,"
            str = str & " [Supplierinvno] [varchar](10) NULL,"
            str = str & " [amountafterdiscount] [numeric](18,2) NULL,"
            str = str & " [Suppliercode] [varchar](50) NULL,"
            str = str & " [Suppliername] [varchar](50) NULL,"
            str = str & " [Itemcode] [varchar](50) NULL,"
            str = str & " [Itemname] [varchar](50) NULL,"
            str = str & " [uom] [varchar](50) NULL,"
            str = str & " [qty] [numeric](18, 2) NULL,"
            str = str & " [rate] [numeric](18, 2) NULL,"
            str = str & " [baseamount] [numeric](18, 2) NULL,"
            str = str & " [discper] [numeric](18, 2) NULL,"
            str = str & " [taxper] [numeric](18, 2) NULL,"
            str = str & " [Discount] [numeric](18, 2) NULL,"
            str = str & " [taxamount] [numeric](18, 2) NULL,"
            str = str & " [amount] [numeric](18, 2) NULL,"
            str = str & " [taxcode] [varchar](50) NULL,"
            str = str & " [batchno] [varchar](50) NULL,"
            str = str & " [othcharge] [numeric](18, 2) NULL,"
            str = str & " [Voiditem] [varchar](5) NULL,"
            str = str & " [category] [varchar](50) NULL,"
            str = str & " [adduser] [varchar](50) NULL,"
            str = str & " [adddate] [datetime] NULL,"
            str = str & " [storecode] [varchar](50) NULL,"
            str = str & " [storedesc] [varchar](200) NULL,"
            str = str & " [versionno] [varchar] (50) NULL ,"
            str = str & " [grntype] [varchar](20) NULL )"
            gconnection.dataOperation1(6, str, "GRN_DETAILSLOG")
        End If

        str = "Select * from sysobjects where name='PO_PAYMENTTERMS' and xtype='U'"
        gconnection.getDataSet(str, "PO_PAYMENTTERMS")
        If gdataset.Tables("PO_PAYMENTTERMS").Rows.Count > 0 Then

        Else

            str = "   CREATE TABLE [dbo].[PO_PAYMENTTERMS]("
            str = str & " [Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "  [paymenttermcode] [varchar](50) NULL,"
            str = str & "  [paymenttermdesc] [varchar](100) NULL,"
            str = str & "  [freeze] [varchar](1) NULL,"
            str = str & "  [adduser] [varchar](50) NULL,"
            str = str & "  [adddatetime] [datetime] NULL,"
            str = str & "  [updateuser] [varchar](50) NULL,"
            str = str & "  [updatedatetime] [datetime] NULL,"
            str = str & "  [freezeuser] [varchar](50) NULL,"
            str = str & "  [freezedatetime] [datetime] NULL"
            str = str & "  ) "
            gconnection.dataOperation1(6, str, "Grn_details")
        End If
        str = "Select * from sysobjects where name='PO_DELIVERYTERMS' and xtype='U'"
        gconnection.getDataSet(str, "PO_DELIVERYTERMS")
        If gdataset.Tables("PO_DELIVERYTERMS").Rows.Count > 0 Then

        Else

            str = "   CREATE TABLE [dbo].[PO_DELIVERYTERMS]("
            str = str & " [Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"

            str = str & " [deliverytermcode] [varchar](50) NULL,"
            str = str & " [deliverytermdesc] [varchar](50) NULL,"
            str = str & " [freeze] [varchar](1) NULL,"
            str = str & " [adduser] [varchar](50) NULL,"
            str = str & " [adddatetime] [datetime] NULL,"
            str = str & " [updateuser] [varchar](50) NULL,"
            str = str & " [updatedatetime] [datetime] NULL,"
            str = str & " [freezeuser] [varchar](50) NULL,"
            str = str & " [freezedatetime] [datetime] NULL"
            str = str & "  ) "
            gconnection.dataOperation1(6, str, "PO_DELIVERYTERMS")
        End If
        str = "Select * from sysobjects where name='ratelist' and xtype='U'"
        gconnection.getDataSet(str, "ratelist")
        If gdataset.Tables("ratelist").Rows.Count > 0 Then

        Else

            str = "   CREATE TABLE [dbo].[ratelist]("
            str = str & " [Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " [grnno] [varchar](50) NULL,"
            str = str & " [batchno] [varchar](50) NULL,"
            str = str & " [Itemcode] [varchar](50) NULL,"
            str = str & " [uom] [varchar](50) NULL,"
            str = str & " [batchrate] [numeric](18, 2) NULL,"
            str = str & "  [weightedrate][numeric](18,2) null,"
            str = str & " [lastweightedrate][numeric](18,2) null,"
            str = str & " [storecode][varchar](50) null,"
            str = str & " [adddate] [datetime] NULL,"
            str = str & " [adduser] [varchar](50) NULL,"
            str = str & " [grndate] [datetime] NULL,"
            str = str & " [freezeuser] [varchar](50) NULL,"
            str = str & " [freezedatetime] [datetime] NULL,"
            str = str & " [VOID] [VARCHAR](10) NULL"

            str = str & "  ) "
            gconnection.dataOperation1(6, str, "ratelist")
        End If
        str = "Select * from sysobjects where name='inv_taxmaster' and xtype='U'"
        gconnection.getDataSet(str, "inv_taxmaster")
        If gdataset.Tables("inv_taxmaster").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE inv_taxmaster"
            str = str & " ("
            str = str & " taxcode VARCHAR(30) NULL,"
            str = str & " taxname VARCHAR(100) NULL,"
            str = str & " taxper numeric(18,2) NULL,"
            str = str & " taxtype  VARCHAR(50) NULL,"
            str = str & " void  VARCHAR(1) NULL,"
            str = str & " adduser varchar(50) NULL ,"
            str = str & " updateUSER  VARCHAR(50) NULL,"
            str = str & " voiduser varchar(50) NULL ,"
            str = str & " ADDDATETIME smalldatetime NULL,"
            str = str & " updateDATETIME smalldatetime NULL,"
            str = str & " voidDATETIME smalldatetime NULL,"
            str = str & " )"
            gconnection.dataOperation1(6, str, "inv_taxmaster")
        End If
        str = "Select * from sysobjects where name='inv_taxmaster_log' and xtype='U'"
        gconnection.getDataSet(str, "inv_taxmaster_log")
        If gdataset.Tables("inv_taxmaster_log").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE inv_taxmaster_log"
            str = str & " ("
            str = str & " taxcode VARCHAR(30) NULL,"
            str = str & " taxname VARCHAR(100) NULL,"
            str = str & " taxper numeric(18,2) NULL,"
            str = str & " taxtype  VARCHAR(50) NULL,"
            str = str & " void  VARCHAR(1) NULL,"
            str = str & " adduser varchar(50) NULL ,"
            str = str & " updateUSER  VARCHAR(50) NULL,"
            str = str & " voiduser varchar(50) NULL ,"
            str = str & " ADDDATETIME smalldatetime NULL,"
            str = str & " updateDATETIME smalldatetime NULL,"
            str = str & " voidDATETIME smalldatetime NULL,"
            str = str & " )"
            gconnection.dataOperation1(6, str, "inv_taxmaster_log")
        End If


        str = "Select * from sysobjects where name='invtaxgroupmaster' and xtype='U'"
        gconnection.getDataSet(str, "invtaxgroupmaster")
        If gdataset.Tables("invtaxgroupmaster").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE invtaxgroupmaster"
            str = str & " ("
            str = str & " Autoid [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " taxgroupcode VARCHAR(50) NULL,"
            str = str & " taxper NUMERIC(18,2) NULL,"
            str = str & " void  VARCHAR(50) NULL,"
            str = str & " updateuser  VARCHAR(50) NULL,"
            str = str & " updatedate smalldatetime NULL ,"
            str = str & " voiddate smalldatetime NULL,"
            str = str & " ADDDATE smalldatetime NULL,"
            str = str & " ADDUSER  VARCHAR(50) NULL,"
            str = str & " ADDDATEtime smalldatetime NULL"
            str = str & " )"
            gconnection.dataOperation1(6, str, "invtaxgroupmaster")
        End If
        str = "Select * from sysobjects where name='invtaxgroupmaster_log' and xtype='U'"
        gconnection.getDataSet(str, "invtaxgroupmaster_log")
        If gdataset.Tables("invtaxgroupmaster_log").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE invtaxgroupmaster_log"
            str = str & " ("
            str = str & " Autoid [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " taxgroupcode VARCHAR(50) NULL,"
            str = str & " taxper NUMERIC(18,2) NULL,"
            str = str & " void  VARCHAR(50) NULL,"
            str = str & " updateuser  VARCHAR(50) NULL,"
            str = str & " updatedate smalldatetime NULL ,"
            str = str & " voiddate smalldatetime NULL,"
            str = str & " ADDDATE smalldatetime NULL,"
            str = str & " ADDUSER  VARCHAR(50) NULL "

            str = str & " )"
            gconnection.dataOperation1(6, str, "invtaxgroupmaster_log")
        End If
        str = "Select * from sysobjects where name='invtaxgroupmasterdetail' and xtype='U'"
        gconnection.getDataSet(str, "invtaxgroupmasterdetail")
        If gdataset.Tables("invtaxgroupmasterdetail").Rows.Count > 0 Then

        Else
            str = "CREATE TABLE invtaxgroupmasterdetail"
            str = str & " ("
            str = str & " Autoid [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " taxgroupcode VARCHAR(50) NULL,"
            str = str & " TAX VARCHAR(50) NULL,"
            str = str & " taxon VARCHAR(200) NULL,"

            str = str & " taxper NUMERIC(18,2) NULL,"
            str = str & " void  VARCHAR(50) NULL,"
            str = str & " updateuser  VARCHAR(50) NULL,"
            str = str & " updatedate datetime NULL ,"
            str = str & " voiddate datetime NULL,"
            str = str & " voidUSER  VARCHAR(50) NULL,"
            str = str & " ADDUSER  VARCHAR(50) NULL,"
            str = str & " ADDDATE  datetime NULL"
            str = str & " )"
            gconnection.dataOperation1(6, str, "invtaxgroupmaster_log")
        End If

        str = "Select * from sysobjects where name='STOCKISSUEHEADER' and xtype='U'"
        gconnection.getDataSet(str, "STOCKISSUEHEADER")
        If gdataset.Tables("STOCKISSUEHEADER").Rows.Count > 0 Then

        Else

            str = " CREATE TABLE [dbo].[STOCKISSUEHEADER]("
            str = str & "	[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " [docno] [varchar](50) null,"
            str = str & " [Docdetails] [varchar](50) null,"
            str = str & " [doctype][varchar](50) null,"
            str = str & " [docdate] [datetime] NULL,"
            str = str & " [IndentNo][varchar](50) null,"
            str = str & " [IndentDate] [datetime] NULL,"
            str = str & " [Storelocationcode][varchar](50) NULL,"
            str = str & " 	[Storelocationname][varchar](50) NULL,"
            str = str & "  [Opstorelocationcode][varchar](50) NULL,"
            str = str & "  [Opstorelocationname][varchar](50) NULL,"
            str = str & "  [totalamt][numeric](18,3) null,"
            str = str & "  [Remarks][varchar](200) NULL,"
            str = str & " [void] [varchar](1) NULL,"
            str = str & " [voidreason] [varchar](200) NULL,"
            str = str & "	[AddDate] [datetime] NULL,"
            str = str & " [addUSER] [varchar](50) NULL,"
            str = str & " [UPDATEUSER] [varchar](15) NULL,"
            str = str & " [UPDATEtime] [datetime] NULL,"
            str = str & " [voiduser] [varchar](50) null,"
            str = str & " [voidtime] [datetime] null "

            str = str & " ) ON [PRIMARY] "

            gconnection.dataOperation1(6, str, "STOCKISSUEHEADER")


        End If






        str = "Select * from sysobjects where name='STOCKISSUEDETAIL' and xtype='U'"
        gconnection.getDataSet(str, "STOCKISSUEDETAIL")
        If gdataset.Tables("STOCKISSUEDETAIL").Rows.Count > 0 Then

        Else



            str = " CREATE TABLE [dbo].STOCKISSUEDETAIL("
            str = str & "	[AUTOID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "	[Docno] [varchar](50) NULL,"
            str = str & "	[Docdetails] [varchar](50) NULL,"
            str = str & "	[Docdate] [datetime] NULL,"
            str = str & "	[IndentNo] [varchar](50) NULL,"
            str = str & "	[indentdate][datetime] null,"
            str = str & "	[storelocationcode][varchar](50) null,"
            str = str & "	[storelocationname][varchar](50) null,"
            str = str & "	[opstorelocationcode][varchar](50)null,"
            str = str & "	[opstorelocationname][varchar](50)null,"
            str = str & "	[Itemcode] [varchar](50) NULL,"
            str = str & "	[Itemname] [varchar](50) NULL,"
            str = str & "	[uom] [varchar](50) NULL,"
            str = str & "	[ind_qty][numeric](18,3) null,"
            str = str & "	[qty] [numeric](18, 2) NULL,"
            str = str & "	[batchno][varchar](50) null,"
            str = str & "	[rate] [numeric](18, 2) NULL,"
            str = str & "	[amount] [numeric](18, 2) NULL,"
            str = str & "	[void][varchar](10)null,"
            str = str & "	[adduser] [varchar](50) NULL,"
            str = str & "	[adddatetime] [datetime] NULL,"
            str = str & "	[updateuser][varchar](50) null,"
            str = str & "	[updatetime][datetime] null, "
            str = str & " [voiduser] [varchar](50) null,"
            str = str & " [voidtime] [datetime] "
            str = str & " ) ON [PRIMARY]"

            gconnection.dataOperation1(6, str, "STOCKISSUEDETAIL")

        End If

        str = "Select * from sysobjects where name='Vw_Ratelist' and xtype='V'"
        gconnection.getDataSet(str, "Vw_Ratelist")
        If gdataset.Tables("Vw_Ratelist").Rows.Count > 0 Then

        Else

            str = " create VIEW [dbo].[Vw_Ratelist] "
            str = str & " AS"
            str = str & " select grnno,batchno,Itemcode,uom,cast(batchrate as numeric(18,2)) as batchrate,grndate,cast(weightedrate as numeric(18,2)) as weightedrate,cast(lastweightedrate as numeric(18,2)) as lastweightedrate,storecode from ratelist"
            str = str & " union all"
            str = str & " select 'Openning','Openning',itemcode,UoM,cast((openningvalue/[openningqty ]) as numeric(18,2))as batchrate,"
            str = str & "  '30/mar/2015',cast((openningvalue/[openningqty ]) as numeric(18,2)) as weightedrate,cast((openningvalue/[openningqty ]) as numeric(18,2)) as lastweightedrate"
            str = str & " ,storecode   from inv_InventoryOpenningstock where [openningqty ]<>0 AND STORECODE IN (SELECT storecode FROM StoreMaster WHERE Storestatus='M' AND ISNULL(Freeze,'')<>'Y')"


            gconnection.dataOperation1(6, str, "Vw_Ratelist")

        End If
        str = "Select * from sysobjects where name='INV_BREAK_ISSUE' and xtype='V'"
        gconnection.getDataSet(str, "INV_BREAK_ISSUE")
        If gdataset.Tables("INV_BREAK_ISSUE").Rows.Count > 0 Then

        Else


            str = " CREATE    VIEW  [dbo].[INV_BREAK_ISSUE] "
            str = str & " AS "

            str = str & " SELECT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM,"
            str = str & " indentno,SUM(qty)AS issqty,ISNULL(RATE,0) AS RATE ,"
            str = str & " (SUM(qty) * RATE ) AS AMOUNT "
            str = str & "  FROM STOCKISSUEDETAIL where isnull(void,'')<>'Y' "
            str = str & " GROUP BY itemcode,itemname,UOM,RATE,INDENTNO"

            gconnection.dataOperation1(6, str, "INV_BREAK_ISSUE")

        End If
        str = "Select * from sysobjects where name='INV_BREAK_INDENT' and xtype='V'"
        gconnection.getDataSet(str, "INV_BREAK_INDENT")
        If gdataset.Tables("INV_BREAK_INDENT").Rows.Count > 0 Then

        Else

            str = " CREATE     VIEW  [dbo].[INV_BREAK_INDENT] "
            str = str & " AS "
            str = str & " SELECT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM, "
            str = str & " A.indent_no AS indentno ,SUM(qty)AS issqty ,A.INDENT_DATE,FROMSTORECODE,STORELOCATIONCODE "
            str = str & "   FROM INVENTORY_INDENTDET A,INVENTORY_INDENTHDR B  WHERE A.INDENT_NO=B.INDENT_NO  and isnull(A.void,'')<>'Y' "
            str = str & " GROUP BY itemcode,itemname,UOM,A.INDENT_NO,A.INDENT_DATE,FROMSTORECODE,STORELOCATIONCODE "
            gconnection.dataOperation1(6, str, "INV_BREAK_INDENT")

        End If
        str = "drop view VW_INV_ISSUEBILL"
        str = "Select * from sysobjects where name='VW_INV_ISSUEBILL' and xtype='V'"
        gconnection.getDataSet(str, "VW_INV_ISSUEBILL")
        If gdataset.Tables("VW_INV_ISSUEBILL").Rows.Count > 0 Then

        Else


            str = " CREATE VIEW  [dbo].[VW_INV_ISSUEBILL]"
            str = str & " AS"

            str = str & " SELECT TOP 100 PERCENT dbo.stockissueheader.docdetails, dbo.stockissueheader.docdate,"
            str = str & " dbo.stockissueheader.storelocationname, dbo.stockissueheader.opstorelocationname, dbo.stockissuedetail.itemcode,"
            str = str & " dbo.stockissueheader.storelocationcode,dbo.stockissueheader.opstorelocationcode, dbo.stockissuedetail.itemname,"
            str = str & " dbo.stockissuedetail.uom,dbo.stockissuedetail.qty , dbo.stockissuedetail.rate, dbo.stockissuedetail.amount ,"
            str = str & " dbo.stockissueheader.indentno ,  dbo.stockissueheader.indentdate,dbo.stockissueheader.remarks,ISNULL(dbo.stockissueheader.partybookingno,'')as partybookingno "
            str = str & "  FROM dbo.stockissuedetail INNER JOIN dbo.stockissueheader "
            str = str & " ON dbo.stockissuedetail.docdetails = dbo.stockissueheader.docdetails"
            gconnection.dataOperation1(6, str, "VW_INV_ISSUEBILL")


        End If
        str = "Select * from sysobjects where name='STOCKDMGHEADER' and xtype='U'"
        gconnection.getDataSet(str, "STOCKDMGHEADER")
        If gdataset.Tables("STOCKDMGHEADER").Rows.Count > 0 Then

        Else

            str = " CREATE TABLE [dbo].[STOCKDMGHEADER]("
            str = str & "	[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "	[docno] [varchar](50) NULL,"
            str = str & " [Docdetails] [varchar](50) NULL,"
            str = str & "	[doctype] [varchar](50) NULL,"
            str = str & " [docdate] [datetime] NULL,"
            str = str & " [Storecode] [varchar](50) NULL,"
            str = str & " [StoreDESC] [varchar](50) NULL,"
            str = str & "	[totalqty] [numeric](18, 3) NULL,"
            str = str & " [Remarks] [varchar](200) NULL,"
            str = str & " [void] [varchar](1) NULL,"
            str = str & " [voidreason] [varchar](200) NULL,"
            str = str & " [AddDate] [datetime] NULL,"
            str = str & " [addUSER] [varchar](50) NULL,"
            str = str & " [UPDATEUSER] [varchar](15) NULL,"
            str = str & " [UPDATEtime] [datetime] NULL,"
            str = str & "	[voiduser] [varchar](50) NULL,"
            str = str & "	[voidtime] [datetime] NULL"
            str = str & " ) ON [PRIMARY]"
            gconnection.dataOperation1(6, str, "STOCKDMGHEADER")

        End If
        str = "Select * from sysobjects where name='STOCKDMGDETAIL' and xtype='U'"
        gconnection.getDataSet(str, "STOCKDMGDETAIL")
        If gdataset.Tables("STOCKDMGDETAIL").Rows.Count > 0 Then

        Else

            str = " CREATE TABLE [dbo].[STOCKDMGDETAIL]("
            str = str & "	[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "	[docno] [varchar](50) NULL,"
            str = str & " [Docdetails] [varchar](50) NULL,"
            str = str & " [DocTYPE] [varchar](50) NULL,"

            str = str & " [docdate] [datetime] NULL,"
            str = str & " [Storecode] [varchar](50) NULL,"
            str = str & " [StoreDESC] [varchar](50) NULL,"
            str = str & " [itemcode] [varchar](50) NULL,"
            str = str & " [itemname] [varchar](50) NULL,"
            str = str & " [uom] [varchar](50) NULL,"
            str = str & "	[dmgqty] [numeric](18, 3) NULL,"
            str = str & " [batchno] [varchar](50) NULL,"
            str = str & "	[closingqty] [numeric](18, 3) NULL,"
            str = str & " [Remarks] [varchar](200) NULL,"
            str = str & " [void] [varchar](1) NULL,"
            str = str & " [voidreason] [varchar](200) NULL,"
            str = str & " [AddDate] [datetime] NULL,"
            str = str & " [addUSER] [varchar](50) NULL,"
            str = str & " [UPDATEUSER] [varchar](15) NULL,"
            str = str & " [UPDATEtime] [datetime] NULL,"
            str = str & "	[voiduser] [varchar](50) NULL,"
            str = str & "	[voidtime] [datetime] NULL"
            str = str & " ) ON [PRIMARY]"
            gconnection.dataOperation1(6, str, "STOCKDMGDETAIL")

        End If
        str = "Select * from sysobjects where name='STOCKADJUSTHEADER' and xtype='U'"
        gconnection.getDataSet(str, "STOCKADJUSTHEADER")
        If gdataset.Tables("STOCKADJUSTHEADER").Rows.Count > 0 Then

        Else

            str = " CREATE TABLE [dbo].[STOCKADJUSTHEADER]("
            str = str & "	[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "	[docno] [varchar](50) NULL,"
            str = str & "	[Docdetails] [varchar](50) NULL,"
            str = str & "	[docdate] [datetime] NULL,"
            str = str & "	[Storecode] [varchar](50) NULL,"
            str = str & "	[StoreDESC] [varchar](50) NULL,"
            str = str & " [Adjustedstock][numeric](18,3) null,"
            str = str & " [stockinhand][numeric](18,3) null,"
            str = str & " [Physicalstock] [numeric](18,3) null,"
            str = str & " [totalqty] [numeric](18, 3) NULL,"
            str = str & " [Remarks] [varchar](200) NULL,"
            str = str & " [void] [varchar](1) NULL,"
            str = str & " [voidreason] [varchar](200) NULL,"
            str = str & "	[AddDate] [datetime] NULL,"
            str = str & "	[addUSER] [varchar](50) NULL,"
            str = str & " [UPDATEUSER] [varchar](15) NULL,"
            str = str & " [UPDATEtime] [datetime] NULL,"
            str = str & " [voiduser] [varchar](50) NULL,"
            str = str & " [voidtime] [datetime] NULL"
            str = str & " ) ON [PRIMARY]"
            gconnection.dataOperation1(6, str, "STOCKADJUSTHEADER")

        End If
        str = "Select * from sysobjects where name='STOCKADJUSTDETAILS' and xtype='U'"
        gconnection.getDataSet(str, "STOCKADJUSTDETAILS")
        If gdataset.Tables("STOCKADJUSTDETAILS").Rows.Count > 0 Then

        Else

            str = " CREATE TABLE [dbo].[STOCKADJUSTDETAILS]("
            str = str & "	[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "	[docno] [varchar](50) NULL,"
            str = str & "	[Docdetails] [varchar](50) NULL,"
            str = str & "	[docdate] [datetime] NULL,"
            str = str & "	[Storecode] [varchar](50) NULL,"
            str = str & "	[StoreDESC] [varchar](50) NULL,"
            str = str & "	[iTEMCODE] [varchar](50) NULL,"
            str = str & "	[iTEMnAME] [varchar](50) NULL,"
            str = str & "	[uom] [varchar](50) NULL,"
            str = str & "	[BATCHNO] [varchar](50) NULL,"
            str = str & " [stockinhand][numeric](18,3) null,"


            str = str & " [Adjustedstock][numeric](18,3) null,"
            str = str & " [Physicalstock] [numeric](18,3) null,"
            str = str & " [Remarks] [varchar](200) NULL,"
            str = str & " [void] [varchar](1) NULL,"
            str = str & "	[AddDate] [datetime] NULL,"
            str = str & "	[addUSER] [varchar](50) NULL,"
            str = str & " [UPDATEUSER] [varchar](15) NULL,"
            str = str & " [UPDATEtime] [datetime] NULL,"
            str = str & " [voiduser] [varchar](50) NULL,"
            str = str & " [voidtime] [datetime] NULL"
            str = str & " ) ON [PRIMARY]"
            gconnection.dataOperation1(6, str, "STOCKADJUSTDETAILS")

        End If
        str = "DROP VIEW VW_INV_GRNBILL"
        str = "Select * from sysobjects where name='VW_INV_GRNBILL' and xtype='V'"
        gconnection.getDataSet(str, "VW_INV_GRNBILL")
        If gdataset.Tables("VW_INV_GRNBILL").Rows.Count > 0 Then

        Else

            '    'str = " create    VIEW [dbo].[VW_INV_GRNBILL] AS"
            '    'str = str & " SELECT ISNULL(D.AUTOID,'') AS AUTOID,ISNULL(G.PONO,'') AS PONO, "
            '    'str = str & " ISNULL(G.GRNDETAILS,'') AS GRNDETAILS,G.GRNDATE, ISNULL(G.SUPPLIERCODE,'') AS SUPPLIERCODE,"
            '    'str = str & " ISNULL(G.SUPPLIERNAME,'') AS SUPPLIERNAME,   ISNULL(G.SUPPLIERINVNO,'') AS SUPPLIERINVNO,"
            '    'str = str & "       ISNULL(G.StoreCode,'') AS EXCISEPASSNO,"
            '    'str = str & " ISNULL(G.TOTALAMOUNT,0) AS TOTALAMOUNT,"
            '    'str = str & "   ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(G.SURCHARGEAMT,0) AS SURCHARGEAMT,"
            '    'str = str & " ISNULL(D.DISCOUNT,0) AS DISCOUNT,ISNULL(G.BILLAMOUNT,0) AS BILLAMOUNT, "
            '    'str = str & " ISNULL(D.ITEMCODE,'') AS ITEMCODE, ISNULL(D.ITEMNAME,'') AS ITEMNAME,"
            '    'str = str & " ISNULL(D.UOM,'') AS UOM, ISNULL(D.QTY,0) AS QTY, ISNULL(D.RATE,0) AS RATE,"
            '    'str = str & " ISNULL(G.REMARKS,'') AS REMARKS,    ISNULL(D.AMOUNT,0) AS AMOUNT,"

            '    'str = str & " isnull(d.discount,0) as ddiscount,isnull(d.taxper,0) as taxper,"
            '    'str = str & " isnull(d.taxamount,0) as taxamount, isnull(g.OverallDiscount,0) OverallDiscount,"

            '    'str = str & " ISNULL(g.Adddate,'') AS ADDDATE,ISNULL(D.TAXCODE,'')AS TAXGROUPCODE,ISNULL(D.VOIDITEM,'')AS VOIDITEM,ISNULL(G.ROUNDUPAMT,0)AS ROUNDUPAMT   "
            '    'str = str & " FROM GRN_HEADER AS G INNER JOIN GRN_DETAILS AS D ON G.GRNDETAILS = D.GRNDETAILS "
            '    str = "    CREATE     VIEW [dbo].[VW_INV_GRNBILL] AS SELECT ISNULL(D.AUTOID,'') AS AUTOID,ISNULL(G.PONO,'') AS PONO,  ISNULL(G.GRNDETAILS,'') AS GRNDETAILS,G.GRNDATE, ISNULL(G.SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(G.SUPPLIERNAME,'') AS SUPPLIERNAME, ISNULL(G.SUPPLIERINVNO,'') AS SUPPLIERINVNO,       ISNULL(G.StoreCode,'') AS EXCISEPASSNO, ISNULL(G.TOTALAMOUNT,0) AS TOTALAMOUNT, ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(G.SURCHARGEAMT,0) AS SURCHARGEAMT, ISNULL(D.DISCOUNT,0) AS DISCOUNT,ISNULL(G.BILLAMOUNT,0) AS BILLAMOUNT,  ISNULL(D.ITEMCODE,'') AS ITEMCODE, ISNULL(D.ITEMNAME,'') AS ITEMNAME, ISNULL(D.UOM,'') AS UOM, ISNULL(D.QTY,0) AS QTY, ISNULL(D.RATE,0) AS RATE,ISNULL(G.REMARKS,'') AS REMARKS,    ISNULL(D.AMOUNT,0) AS AMOUNT, isnull(d.discount,0) as ddiscount,isnull(d.taxper,0) as taxper, isnull(d.taxamount,0) as taxamount, isnull(g.OverallDiscount,0) OverallDiscount, ISNULL(g.Adddate,'') AS ADDDATE  ,ISNULL(D.taxcode,'') AS TAXGROUPCODE,ISNULL(G.RoundupAmt,0) AS RoundupAmt,ISNULL(D.IGSTAmt,0) AS IGSTAmt,ISNULL(D.SGSTAmt,0) AS SGSTAmt,ISNULL(D.CGSTAmt,0) AS CGSTAmt,ISNULL(SL.contactperson,'') AS contactperson,ISNULL(SL.address1,'') AS address1,ISNULL(SL.address2,'') AS address2,  ISNULL(SL.city,'') AS city,ISNULL(SL.state,'') AS state,ISNULL(SL.PIN,'') AS pIN , ISNULL(SL.phoneno,'') AS PhONENO, ISNULL(SL.GSTINNO,'') AS GSTINNO ,ISNULL(SL.VENDORTYPE,'') AS VENDORTYPE ,ISNULL(IV.HSNNO,'') AS HSNNO,ISNULL(IV.TAXTYPE,'') AS  TAXTYPE,ISNULL(D.SPLCESS,0) AS SPLCESS,ISNULL(D.CESSAMT,0) AS CESSAMT,ISNULL(D.VOIDITEM,'')AS VOIDITEM FROM GRN_HEADER AS G INNER JOIN GRN_DETAILS AS D ON G.GRNDETAILS = D.GRNDETAILS  INNER JOIN  SUPPLIERDetails SL ON SL.vendorcode=G.Suppliercode INNER JOIN INV_InventoryItemMaster IV ON             IV.itemcode = D.Itemcode            "

            '    gconnection.dataOperation1(6, str, "STOCKADJUSTDETAILS")



            str = " CREATE    VIEW [dbo].[VW_INV_GRNBILL] AS "

            str = str & " SELECT ISNULL(D.AUTOID,'') AS AUTOID,ISNULL(G.PONO,'') AS PONO,  ISNULL(G.GRNDETAILS,'') AS GRNDETAILS,G.GRNDATE, "
            str = str & "ISNULL(G.SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(G.SUPPLIERNAME,'') AS SUPPLIERNAME, "
            str = str & "ISNULL(G.SUPPLIERINVNO,'') AS SUPPLIERINVNO,       ISNULL(G.StoreCode,'') AS EXCISEPASSNO, ISNULL(G.TOTALAMOUNT,0) AS TOTALAMOUNT, "
            str = str & "ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(G.SURCHARGEAMT,0) AS SURCHARGEAMT, ISNULL(D.DISCOUNT,0) AS DISCOUNT,ISNULL(G.BILLAMOUNT,0) AS BILLAMOUNT,  "
            str = str & "ISNULL(D.ITEMCODE,'') AS ITEMCODE, ISNULL(D.ITEMNAME,'') AS ITEMNAME, ISNULL(D.UOM,'') AS UOM, ISNULL(D.QTY,0) AS QTY, ISNULL(D.RATE,0) AS RATE,"
            str = str & "ISNULL(G.REMARKS,'') AS REMARKS,    ISNULL(D.AMOUNT,0) AS AMOUNT, isnull(d.discount,0) as ddiscount,isnull(d.taxper,0) as taxper, "
            str = str & "isnull(d.taxamount,0) as taxamount, isnull(g.OverallDiscount,0) OverallDiscount, ISNULL(g.Adddate,'') AS ADDDATE  ,ISNULL(D.taxcode,'') AS TAXGROUPCODE,ISNULL(G.RoundupAmt,0) AS RoundupAmt,ISNULL(D.IGSTAmt,0) AS IGSTAmt,ISNULL(D.SGSTAmt,0) AS SGSTAmt,ISNULL(D.CGSTAmt,0) AS CGSTAmt,"
            str = str & "ISNULL(SL.contactperson,'') AS contactperson,ISNULL(SL.address1,'') AS address1,ISNULL(SL.address2,'') AS address2,  ISNULL(SL.city,'') AS city,ISNULL(SL.state,'') AS state,ISNULL(SL.PIN,'') AS pIN , ISNULL(SL.phoneno,'') AS PhONENO, ISNULL(SL.GSTINNO,'') AS GSTINNO ,ISNULL(SL.VENDORTYPE,'') AS VENDORTYPE "
            str = str & ",ISNULL(IV.HSNNO,'') AS HSNNO,ISNULL(IV.TAXTYPE,'') AS  TAXTYPE,ISNULL(D.SPLCESS,0) AS SPLCESS,isnull(d.Voiditem,'N') AS Voiditem"
            str = str & "FROM GRN_HEADER AS G INNER JOIN GRN_DETAILS AS D ON G.GRNDETAILS = D.GRNDETAILS  INNER JOIN  "
            str = str & "SUPPLIERDetails SL ON SL.vendorcode=G.Suppliercode INNER JOIN INV_InventoryItemMaster IV ON "
            str = str & "  IV.itemcode = D.Itemcode"
            gconnection.dataOperation1(6, str, "STOCKADJUSTDETAILS")
        End If
        str = "Select * from sysobjects where name='TEMPSTOCKISSUEDETAIL' and xtype='U'"
        gconnection.getDataSet(str, "TEMPSTOCKISSUEDETAIL")
        If gdataset.Tables("TEMPSTOCKISSUEDETAIL").Rows.Count > 0 Then

        Else

            str = "CREATE TABLE [dbo].[TEMPSTOCKISSUEDETAIL]("
            str = str & "     	[Docno] [varchar](50) NULL,"
            str = str & "  [Docdetails] [varchar](50) NULL,"
            str = str & "  [Docdate] [datetime] NULL,"
            str = str & "  [IndentNo] [varchar](50) NULL,"
            str = str & "  	[indentdate] [datetime] NULL,"
            str = str & "  [storelocationcode] [varchar](50) NULL,"
            str = str & "  [storelocationname] [varchar](50) NULL,"
            str = str & "  [opstorelocationname] [varchar](50) NULL,"
            str = str & "  [opstorelocationcode] [varchar](50) NULL,"
            str = str & "  [Itemcode] [varchar](50) NULL,"
            str = str & "  [Itemname] [varchar](50) NULL,"
            str = str & "  [UoM] [varchar](50) NULL,"
            str = str & "  [ind_qty] [numeric](18, 3) NULL,"
            str = str & "  [qty] [numeric](18, 2) NULL,"
            str = str & "  [BATCHNO] [varchar](50) NULL,"
            str = str & "  [rate] [numeric](18, 2) NULL,"
            str = str & "  [AMOUNT] [numeric](18, 2) NULL,"
            str = str & "  	[VOID] [varchar](10) NULL,"
            str = str & "  [WEIGHTEDRATE] [numeric](18, 2) NULL,"
            str = str & "  [BATCHRATE] [numeric](18, 2) NULL,"
            str = str & "  [TUOM] [varchar](50) NULL,"
            str = str & "  [convvalue] [numeric](18, 2) NULL,"
            str = str & "  	[RATEFLAG] [varchar](5) NULL,"
            str = str & "  [CATEGORYCODE] [varchar](30) NULL,"
            str = str & "  [BATCHPROCESS] [varchar](30) NULL"
            str = str & "  ) ON [PRIMARY]"
            gconnection.dataOperation1(6, str, "TEMPSTOCKISSUEDETAIL")

        End If

        str = "Select * from sysobjects where name='vw_purchaseregister' and xtype='V'"
        gconnection.getDataSet(str, "vw_purchaseregister")
        If gdataset.Tables("vw_purchaseregister").Rows.Count > 0 Then

        Else


            str = " CREATE VIEW [dbo].[vw_purchaseregister]"
            str = str & " AS"
            str = str & "   SELECT     dbo.Grn_details.grnno, dbo.Grn_details.grndetails, dbo.Grn_details.grndate, dbo.Grn_details.pono, dbo.Grn_details.Supplierinvno, dbo.Grn_details.Suppliercode, "
            str = str & "         dbo.Grn_details.Suppliername, dbo.Grn_details.Itemcode, dbo.Grn_details.Itemname, dbo.Grn_details.uom, dbo.Grn_details.qty, dbo.Grn_details.rate, "
            str = str & "       dbo.Grn_details.baseamount, dbo.Grn_details.discper, dbo.Grn_details.taxper, dbo.Grn_details.Discount, dbo.Grn_details.taxamount, dbo.Grn_details.amount, "
            str = str & "        dbo.Grn_details.taxcode, dbo.Grn_details.batchno, dbo.Grn_details.othcharge, dbo.Grn_details.Voiditem, dbo.Grn_details.category, dbo.Grn_details.storecode, "
            str = str & "        dbo.Grn_details.storedesc, dbo.Grn_details.versionno, dbo.Grn_details.grntype, dbo.Grn_details.amountafterdiscount, dbo.Grn_header.Totalamount, "
            str = str & "         dbo.Grn_header.VATamount, dbo.Grn_header.Surchargeamt, dbo.Grn_header.OverallDiscount, dbo.Grn_header.Discount AS totdiscount, dbo.Grn_header.Billamount, "
            str = str & " dbo.Grn_header.Remarks, dbo.Grn_header.Void, dbo.Grn_header.updateuser, dbo.Grn_header.updatedate, dbo.Grn_header.voiduser, dbo.Grn_header.voiddate"
            str = str & "  FROM         dbo.Grn_details INNER JOIN"
            str = str & "      dbo.Grn_header ON dbo.Grn_details.grndetails = dbo.Grn_header.grndetails"
            gconnection.dataOperation1(6, str, "vw_purchaseregister")

        End If

        str = "Select * from sysobjects where name='vw_pobill' and xtype='V'"
        gconnection.getDataSet(str, "vw_pobill")
        If gdataset.Tables("vw_pobill").Rows.Count > 0 Then

        Else

            If gShortname <> "BGC" Or gShortname <> "BRC" Then
                str = " CREATE VIEW [dbo].[vw_pobill]"
                str = str & " AS"
                str = str & "     SELECT     dbo.PO_HDR.pono, dbo.PO_HDR.doctype, dbo.PO_HDR.storecode, dbo.PO_HDR.podate, dbo.PO_HDR.poquotno, dbo.PO_HDR.povendorcode, "
                str = str & " dbo.PO_HDR.podepartment, dbo.PO_HDR.potype, dbo.PO_HDR.povalidfrom, dbo.PO_HDR.povalidupto, dbo.PO_ITEMDETAILS.ITEMCODE,"
                str = str & "      dbo.PO_ITEMDETAILS.ITEMNAME, dbo.PO_ITEMDETAILS.UOM, dbo.PO_ITEMDETAILS.QUANTITY, dbo.PO_ITEMDETAILS.baseamount, dbo.PO_ITEMDETAILS.Rate,"
                str = str & "    dbo.PO_ITEMDETAILS.discper, dbo.PO_ITEMDETAILS.taxper, dbo.PO_ITEMDETAILS.discamt, dbo.PO_ITEMDETAILS.vatamt, dbo.PO_ITEMDETAILS.TOTALamount,"
                str = str & "    dbo.PO_ITEMDETAILS.taxcode, dbo.PO_ITEMDETAILS.amountafterdiscount, dbo.PO_ITEMDETAILS.othchg, dbo.PO_HDR.versionno, dbo.PO_HDR.POOVERALLDISC,"
                str = str & "     dbo.PO_HDR.pobalance, dbo.PO_HDR.poadvance, dbo.PO_HDR.pototaldiscount, dbo.PO_HDR.pototaltax, dbo.PO_HDR.pototalvat, dbo.PO_HDR.povalue,"
                str = str & "    dbo.PO_HDR.pootherchgplus, dbo.PO_HDR.pootherchgmin, dbo.PO_HDR.POtransport, dbo.PO_HDR.postatus"
                str = str & " FROM         dbo.PO_HDR INNER JOIN"
                str = str & "              dbo.PO_ITEMDETAILS ON dbo.PO_HDR.pono = dbo.PO_ITEMDETAILS.pono AND dbo.PO_HDR.versionno = dbo.PO_ITEMDETAILS.versionno"
                gconnection.dataOperation1(6, str, "vw_pobill")
            End If

        End If
        str = "Select * from sysobjects where name='tempclosingqty' and xtype='U'"
        gconnection.getDataSet(str, "tempclosingqty")
        If gdataset.Tables("tempclosingqty").Rows.Count > 0 Then

        Else
            str = " CREATE TABLE [dbo].[tempclosingqty]("
            str = str & "    [Trnno] [varchar](50) NULL,"
            str = str & " [itemcode] [varchar](50) NULL,"
            str = str & " 	[UoM] [varchar](50) NULL,"
            str = str & " [storecode] [varchar](50) NULL,"
            str = str & " 	[Trndate] [datetime] NULL,"
            str = str & " [openningstock] [numeric](18, 3) NULL,"
            str = str & " [openningvalue] [numeric](18, 3) NULL,"
            str = str & " [qty] [numeric](18, 3) NULL,"
            str = str & " [closingstock] [numeric](18, 3) NULL,"
            str = str & " [batchno] [varchar](50) NULL,"
            str = str & "  	[TTYPE] [varchar](50) NULL"
            str = str & " ) ON [PRIMARY] "
            gconnection.dataOperation1(6, str, "tempclosingqty")

        End If

        str = "Select * from sysobjects where name='TEMPSTOCKDMGDETAIL' and xtype='U'"
        gconnection.getDataSet(str, "TEMPSTOCKDMGDETAIL")
        If gdataset.Tables("TEMPSTOCKDMGDETAIL").Rows.Count > 0 Then

        Else
            str = " CREATE TABLE [dbo].[TEMPSTOCKDMGDETAIL]("
            str = str & " [Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " [docno] [varchar](50) NULL,"
            str = str & " 	[Docdetails] [varchar](50) NULL,"
            str = str & " 	[docdate] [datetime] NULL,"
            str = str & " 	[Storecode] [varchar](50) NULL,"
            str = str & " 	[StoreDESC] [varchar](50) NULL,"
            str = str & " 	[itemcode] [varchar](50) NULL,"
            str = str & " 	[itemname] [varchar](50) NULL,"
            str = str & " [uom] [varchar](50) NULL,"
            str = str & " [qty] [numeric](18, 3) NULL,"
            str = str & " [batchno] [varchar](50) NULL,"
            str = str & " [rate] [numeric](18, 3) NULL,"
            str = str & " [amount] [numeric](18, 3) NULL,"
            str = str & " [weightedrate] [numeric](18, 3) NULL,"
            str = str & " [batchrate] [numeric](18, 3) NULL,"
            str = str & " [CONVVALUE] [numeric](18, 3) NULL,"
            str = str & " [closingqty] [numeric](18, 3) NULL,"
            str = str & " [tuom] [varchar](50) NULL,"
            str = str & " [void] [varchar](1) NULL,"
            str = str & " [CATEGORYCODE] [varchar](30) NULL,"
            str = str & " [BATCHPROCESS] [varchar](30) NULL,"
            str = str & " [RATEFLAG] [varchar](10) NULL"

            str = str & " ) ON [PRIMARY] "
            gconnection.dataOperation1(6, str, "TEMPSTOCKDMGDETAIL")

        End If
        str = "Select * from sysobjects where name='TEMPSTOCKADJDETAIL' and xtype='U'"
        gconnection.getDataSet(str, "TEMPSTOCKADJDETAIL")
        If gdataset.Tables("TEMPSTOCKADJDETAIL").Rows.Count > 0 Then

        Else
            str = " CREATE TABLE [dbo].[TEMPSTOCKADJDETAIL]("
            str = str & "    [Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " [docno] [varchar](50) NULL,"
            str = str & " [Docdetails] [varchar](50) NULL,"
            str = str & " 	[docdate] [datetime] NULL,"
            str = str & " [Storecode] [varchar](50) NULL,"
            str = str & " 	[StoreDESC] [varchar](50) NULL,"
            str = str & " 	[itemcode] [varchar](50) NULL,"
            str = str & " 	[itemname] [varchar](50) NULL,"
            str = str & " 	[uom] [varchar](50) NULL,"
            str = str & " 	[STOCKINHAND] [numeric](18, 3) NULL,"
            str = str & " 	[ADJUSTEDSTOCK] [numeric](18, 3) NULL,"
            str = str & " 	[PHYSICALSTOCK] [numeric](18, 3) NULL,"
            str = str & " [CONVVALUE] [numeric](18, 3) NULL,"
            str = str & " 	[batchno] [varchar](50) NULL,"
            str = str & " [rate] [numeric](18, 3) NULL,"
            str = str & " 	[amount] [numeric](18, 3) NULL,"
            str = str & " 	[weightedrate] [numeric](18, 3) NULL,"
            str = str & " 	[batchrate] [numeric](18, 3) NULL,"
            str = str & " 	[closingqty] [numeric](18, 3) NULL,"
            str = str & " 	[tuom] [varchar](50) NULL,"
            str = str & " [void] [varchar](1) NULL,"
            str = str & " 	[CATEGORYCODE] [varchar](30) NULL,"
            str = str & " [BATCHPROCESS] [varchar](30) NULL,"
            str = str & "  [RATEFLAG] [varchar](10) NULL"

            str = str & " ) ON [PRIMARY] "
            gconnection.dataOperation1(6, str, "TEMPSTOCKADJDETAIL")

        End If
        str = "Select * from sysobjects where name='TEMPSTOCKCONSUMPTIONDETAIL' and xtype='U'"
        gconnection.getDataSet(str, "TEMPSTOCKCONSUMPTIONDETAIL")
        If gdataset.Tables("TEMPSTOCKCONSUMPTIONDETAIL").Rows.Count > 0 Then

        Else
            str = " CREATE TABLE [dbo].[TEMPSTOCKCONSUMPTIONDETAIL]("
            str = str & "     [Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "  [docno] [varchar](50) NULL,"
            str = str & "  [Docdetails] [varchar](50) NULL,"
            str = str & "  [docdate] [datetime] NULL,"
            str = str & "  [Storecode] [varchar](50) NULL,"
            str = str & "  	[StoreDESC] [varchar](50) NULL,"
            str = str & "  [itemcode] [varchar](50) NULL,"
            str = str & "  	[itemname] [varchar](50) NULL,"
            str = str & "  [uom] [varchar](50) NULL,"
            str = str & "  	[qty] [numeric](18, 3) NULL,"
            str = str & "  	[batchno] [varchar](50) NULL,"
            str = str & "  	[rate] [numeric](18, 3) NULL,"
            str = str & "  	[amount] [numeric](18, 3) NULL,"
            str = str & "  	[weightedrate] [numeric](18, 3) NULL,"
            str = str & "  [batchrate] [numeric](18, 3) NULL,"
            str = str & "  	[CONVVALUE] [numeric](18, 3) NULL,"
            str = str & "  	[closingqty] [numeric](18, 3) NULL,"
            str = str & "  	[tuom] [varchar](50) NULL,"
            str = str & "  [void] [varchar](1) NULL,"
            str = str & "  [CATEGORYCODE] [varchar](30) NULL,"
            str = str & "  [BATCHPROCESS] [varchar](30) NULL,"
            str = str & "  	[RATEFLAG] [varchar](10) NULL,"
            str = str & "  	[CONSUMER] [varchar](50) NULL"

            str = str & " ) ON [PRIMARY] "
            gconnection.dataOperation1(6, str, "TEMPSTOCKCONSUMPTIONDETAIL")

        End If


        str = "Select * from sysobjects where name='cp_stockadjustment' and xtype='P'"
        gconnection.getDataSet(str, "cp_stockadjustment")
        If gdataset.Tables("cp_stockadjustment").Rows.Count > 0 Then

        Else

            str = " CREATE PROCEDURE [dbo].[cp_stockadjustment]"

            str = str & " AS "
            str = str & "    BEGIN "
            str = str & "	DECLARE @itemcode varchar(50), @docdate datetime,@tuom varchar(50),@storecode varchar(50)"
            str = str & " declare @weightedrate numeric(18,2),@batchrate numeric(18,2)"
            str = str & " DELETE FROM TEMPSTOCKadjDETAIL"
            str = str & " insert into TEMPSTOCKadjDETAIL(Docno,Docdetails,Docdate,storecode,storedesc,Itemcode,Itemname,UoM,stockinhand,adjustedstock,physicalstock,BATCHNO,VOID) "
            str = str & " SELECT Docno,Docdetails,Docdate,storecode,storedesc,Itemcode,Itemname,UoM,stockinhand,adjustedstock,physicalstock,BATCHNO,VOID   FROM STOCKadjustDETAILs "


            str = str & " DECLARE cursorName CURSOR "

            str = str & " LOCAL SCROLL STATIC"

            str = str & " FOR"
            str = str & " select itemcode,docdate,storecode from TEMPSTOCKadjDETAIL"
            str = str & " OPEN cursorName "

            str = str & " FETCH NEXT FROM cursorName"

            str = str & " INTO @itemcode, @docdate,@storecode"
            str = str & " set @weightedrate=0"
            str = str & " set @batchrate=0"
            str = str & " set @tuom=''"

            str = str & " select TOP 1 @weightedrate=weightedrate,@batchrate=batchrate, @tuom=uom from vw_ratelist where grndate<@docdate and Itemcode=@itemcode"
            str = str & "  and storecode=@storecode"
            str = str & " print @weightedrate"
            str = str & " print @batchrate"
            str = str & " print @tuom"
            str = str & " PRINT @itemcode + ' '  "
            str = str & " print @docdate"
            str = str & " update TEMPSTOCKadjDETAIL set weightedrate=@weightedrate,BATCHRATE=@batchrate,TUOM=@tuom"
            str = str & " where Docdate=@docdate and Itemcode=@itemcode  "

            str = str & " WHILE @@FETCH_STATUS = 0"

            str = str & " BEGIN "

            str = str & "  FETCH NEXT FROM cursorName"

            str = str & "    INTO @itemcode, @docdate,@storecode"
            str = str & "   set @weightedrate=0"
            str = str & " set @batchrate=0"
            str = str & " set @tuom=''"
            str = str & " select TOP 1 @weightedrate=weightedrate,@batchrate=batchrate, @tuom=uom from vw_ratelist where grndate<@docdate and Itemcode=@itemcode"
            str = str & " and storecode=@storecode  and storecode=@storecode  "
            str = str & " order by grndate desc"
            str = str & " update TEMPSTOCKadjDETAIL set weightedrate=@weightedrate,BATCHRATE=@batchrate,TUOM=@tuom"
            str = str & "  where Docdate=@docdate and Itemcode=@itemcode"
            str = str & " print @weightedrate"
            str = str & " print @batchrate"
            str = str & " print @tuom"

            str = str & " PRINT @itemcode  "
            str = str & " print @docdate"
            str = str & " End"

            str = str & " CLOSE cursorName "

            str = str & " DEALLOCATE cursorName"
            str = str & " update TEMPSTOCKadjDETAIL set  convvalue=INVENTORY_TRANSCONVERSION.CONVVALUE from TEMPSTOCKadjDETAIL inner join INVENTORY_TRANSCONVERSION on INVENTORY_TRANSCONVERSION.BASEUOM=TEMPSTOCKadjDETAIL.TUOM"
            str = str & " and INVENTORY_TRANSCONVERSION.TRANSUOM=TEMPSTOCKadjDETAIL.uom"



            str = str & " UPDATE TEMPSTOCKadjDETAIL SET CATEGORYCODE=I.CATEGORY ,BATCHPROCESS=I.BATCHPROCESS  FROM INV_InventoryItemMaster I INNER JOIN TEMPSTOCKadjDETAIL T"
            str = str & " ON I.itemcode=T.ITEMCODE "
            str = str & " UPDATE TEMPSTOCKadjDETAIL SET RATEFLAG=I.RATEFLAG FROM TEMPSTOCKadjDETAIL T INNER JOIN INVENTORYCATEGORYMASTER I"
            str = str & " ON T.CATEGORYCODE=I.CATEGORYCODE"

            str = str & " UPDATE TEMPSTOCKadjDETAIL SET rate=WEIGHTEDRATE WHERE RATEFLAG='W'"
            str = str & " UPDATE TEMPSTOCKadjDETAIL SET rate=BATCHRATE WHERE RATEFLAG='P'"
            str = str & " UPDATE TEMPSTOCKadjDETAIL SET rate=R.BATCHRATE FROM TEMPSTOCKadjDETAIL T INNER JOIN vw_ratelist R ON"
            str = str & " R.batchno = t.BATCHNO And r.Itemcode = t.Itemcode"

            str = str & " UPDATE TEMPSTOCKadjDETAIL SET adjustedstock=adjustedstock/CONVVALUE WHERE ISNULL(CONVVALUE,0)<>0"
            str = str & " update TEMPSTOCKadjDETAIL set AMOUNT=rate*adjustedstock"
            str = str & " end "

            gconnection.dataOperation1(6, str, "cp_stockadjustment")


        End If

        str = "Select * from sysobjects where name='cp_stockdamage' and xtype='P'"
        gconnection.getDataSet(str, "cp_stockdamage")
        If gdataset.Tables("cp_stockdamage").Rows.Count > 0 Then

        Else


            str = " CREATE PROCEDURE [dbo].[cp_stockdamage]"

            str = str & " AS"
            str = str & " BEGIN "
            str = str & "  DECLARE @itemcode varchar(50), @docdate datetime,@tuom varchar(50),@storecode varchar(50)"
            str = str & "  declare @weightedrate numeric(18,2),@batchrate numeric(18,2)"
            str = str & "  DELETE FROM TEMPSTOCKdmgDETAIL"
            str = str & "   insert into TEMPSTOCKdmgDETAIL(Docno,Docdetails,Docdate,storecode,storedesc,Itemcode,Itemname,UoM,qty,BATCHNO,VOID) "
            str = str & " SELECT Docno,Docdetails,Docdate,storecode,storedesc,Itemcode,Itemname,UoM,dmgqty,BATCHNO,VOID   FROM STOCKdmgDETAIL "


            str = str & "  DECLARE cursorName CURSOR "

            str = str & "  LOCAL SCROLL STATIC"

            str = str & "  FOR"
            str = str & "  select itemcode,docdate,storecode from TEMPSTOCKdmgDETAIL"
            str = str & "  OPEN cursorName "

            str = str & "  FETCH NEXT FROM cursorName"

            str = str & "  INTO @itemcode, @docdate,@storecode"
            str = str & "  set @weightedrate=0"
            str = str & " set @batchrate=0"
            str = str & " set @tuom=''"

            str = str & " select TOP 1 @weightedrate=weightedrate,@batchrate=batchrate, @tuom=uom from vw_ratelist where grndate<@docdate and Itemcode=@itemcode"
            str = str & " and storecode=@storecode"
            str = str & " print @weightedrate"
            str = str & " print @batchrate"
            str = str & " print @tuom"
            str = str & " PRINT @itemcode + ' ' "
            str = str & " print @docdate"
            str = str & " update TEMPSTOCKdmgDETAIL set weightedrate=@weightedrate,BATCHRATE=@batchrate,TUOM=@tuom"
            str = str & " where Docdate=@docdate and Itemcode=@itemcode  "

            str = str & " WHILE @@FETCH_STATUS = 0"

            str = str & " BEGIN "

            str = str & " FETCH NEXT FROM cursorName"

            str = str & " INTO @itemcode, @docdate,@storecode"
            str = str & " set @weightedrate=0"
            str = str & " set @batchrate=0"
            str = str & " set @tuom=''"
            str = str & " select TOP 1 @weightedrate=weightedrate,@batchrate=batchrate, @tuom=uom from vw_ratelist where grndate<@docdate and Itemcode=@itemcode"
            str = str & " and storecode=@storecode  and storecode=@storecode  "
            str = str & " order by grndate desc"
            str = str & " update TEMPSTOCKdmgDETAIL set weightedrate=@weightedrate,BATCHRATE=@batchrate,TUOM=@tuom"
            str = str & " where Docdate=@docdate and Itemcode=@itemcode"
            str = str & " print @weightedrate"
            str = str & " print @batchrate"
            str = str & " print @tuom"

            str = str & " PRINT @itemcode "
            str = str & " print @docdate"
            str = str & " End"

            str = str & "  CLOSE cursorName "

            str = str & "  DEALLOCATE cursorName"
            str = str & " update TEMPSTOCKDMGDETAIL set  convvalue=INVENTORY_TRANSCONVERSION.CONVVALUE from TEMPSTOCKDMGDETAIL inner join INVENTORY_TRANSCONVERSION on INVENTORY_TRANSCONVERSION.BASEUOM=TEMPSTOCKDMGDETAIL.TUOM"
            str = str & " and INVENTORY_TRANSCONVERSION.TRANSUOM=TEMPSTOCKDMGDETAIL.uom"


            str = str & " UPDATE TEMPSTOCKDMGDETAIL SET CATEGORYCODE=I.CATEGORY ,BATCHPROCESS=I.BATCHPROCESS  FROM INV_InventoryItemMaster I INNER JOIN TEMPSTOCKDMGDETAIL T"
            str = str & " ON I.itemcode=T.ITEMCODE "
            str = str & " UPDATE TEMPSTOCKDMGDETAIL SET RATEFLAG=I.RATEFLAG FROM TEMPSTOCKadjDETAIL T INNER JOIN INVENTORYCATEGORYMASTER I"
            str = str & " ON T.CATEGORYCODE=I.CATEGORYCODE"

            str = str & " UPDATE TEMPSTOCKDMGDETAIL SET rate=WEIGHTEDRATE WHERE RATEFLAG='W'"
            str = str & " UPDATE TEMPSTOCKDMGDETAIL SET rate=BATCHRATE WHERE RATEFLAG='P'"
            str = str & " UPDATE TEMPSTOCKDMGDETAIL SET rate=R.BATCHRATE FROM TEMPSTOCKDMGDETAIL T INNER JOIN vw_ratelist R ON"
            str = str & " R.batchno = t.BATCHNO And r.Itemcode = t.Itemcode"

            str = str & " UPDATE TEMPSTOCKDMGDETAIL SET QTY=QTY/CONVVALUE WHERE ISNULL(CONVVALUE,0)<>0"
            str = str & " update TEMPSTOCKDMGDETAIL set AMOUNT=rate*QTY"

            str = str & " END "
            gconnection.dataOperation1(6, str, "cp_stockdamage")


        End If
        str = "Select * from sysobjects where name='cp_stockissue' and xtype='P'"
        gconnection.getDataSet(str, "cp_stockissue")
        If gdataset.Tables("cp_stockissue").Rows.Count > 0 Then

        Else



            str = " CREATE PROCEDURE [dbo].[cp_stockissue]"

            str = str & " AS"
            str = str & " BEGIN "
            str = str & " DECLARE @itemcode varchar(50), @docdate datetime,@tuom varchar(50),@storecode varchar(50)"
            str = str & " declare @weightedrate numeric(18,2),@batchrate numeric(18,2)"
            str = str & " DELETE FROM TEMPSTOCKISSUEDETAIL"
            str = str & " insert into TEMPSTOCKISSUEDETAIL(Docno,Docdetails,Docdate,IndentNo,indentdate,storelocationcode,storelocationname,opstorelocationname,opstorelocationcode,Itemcode,Itemname,UoM,ind_qty,qty,BATCHNO,rate,AMOUNT,VOID) "
            str = str & " SELECT Docno,Docdetails,Docdate,IndentNo,indentdate,storelocationcode,storelocationname,opstorelocationname,opstorelocationcode,Itemcode,Itemname,UoM,ind_qty,qty,BATCHNO,rate,AMOUNT,VOID   FROM STOCKISSUEDETAIL "


            str = str & " DECLARE cursorName CURSOR "

            str = str & " LOCAL SCROLL STATIC"

            str = str & " FOR "
            str = str & " select itemcode,docdate,storelocationcode from TEMPSTOCKISSUEDETAIL"
            str = str & " OPEN cursorName "

            str = str & " FETCH NEXT FROM cursorName "

            str = str & "    INTO @itemcode, @docdate,@storecode "
            str = str & " set @weightedrate=0 "
            str = str & " set @batchrate=0 "
            str = str & " set @tuom=''"

            str = str & "  select TOP 1 @weightedrate=weightedrate,@batchrate=batchrate, @tuom=uom from vw_ratelist where grndate<@docdate and Itemcode=@itemcode"
            str = str & " and storecode=@storecode"
            str = str & " print @weightedrate"
            str = str & " print @batchrate"
            str = str & " print @tuom"
            str = str & " PRINT @itemcode + ' ' "
            str = str & " print @docdate"
            str = str & " update TEMPSTOCKISSUEDETAIL set weightedrate=@weightedrate,BATCHRATE=@batchrate,TUOM=@tuom"
            str = str & " where Docdate=@docdate and Itemcode=@itemcode  "

            str = str & " WHILE @@FETCH_STATUS = 0"

            str = str & " BEGIN"

            str = str & "  FETCH NEXT FROM cursorName"

            str = str & "  INTO @itemcode, @docdate,@storecode"
            str = str & "  set @weightedrate=0"
            str = str & " set @batchrate=0"
            str = str & " set @tuom=''"
            str = str & " select TOP 1 @weightedrate=weightedrate,@batchrate=batchrate, @tuom=uom from vw_ratelist where grndate<@docdate and Itemcode=@itemcode"
            str = str & " and storecode=@storecode  and storecode=@storecode  "
            str = str & "  order by grndate desc"
            str = str & "  update TEMPSTOCKISSUEDETAIL set weightedrate=@weightedrate,BATCHRATE=@batchrate,TUOM=@tuom"
            str = str & "  where Docdate=@docdate and Itemcode=@itemcode"
            str = str & "  print @weightedrate"
            str = str & "  print @batchrate"
            str = str & "  print @tuom"

            str = str & "   PRINT @itemcode "
            str = str & "  print @docdate"
            str = str & "    End"

            str = str & "  CLOSE cursorName "

            str = str & "           DEALLOCATE cursorName"
            str = str & "  update TEMPSTOCKISSUEDETAIL set  convvalue=INVENTORY_TRANSCONVERSION.CONVVALUE from TEMPSTOCKISSUEDETAIL inner join INVENTORY_TRANSCONVERSION on INVENTORY_TRANSCONVERSION.BASEUOM=TEMPSTOCKISSUEDETAIL.TUOM"
            str = str & "  and INVENTORY_TRANSCONVERSION.TRANSUOM=TEMPSTOCKISSUEDETAIL.uom"

            str = str & "  UPDATE TEMPSTOCKISSUEDETAIL SET CATEGORYCODE=I.CATEGORY ,BATCHPROCESS=I.BATCHPROCESS  FROM INV_InventoryItemMaster I INNER JOIN TEMPSTOCKISSUEDETAIL T"
            str = str & "  ON I.itemcode=T.ITEMCODE "
            str = str & "  UPDATE TEMPSTOCKISSUEDETAIL SET RATEFLAG=I.RATEFLAG FROM TEMPSTOCKISSUEDETAIL T INNER JOIN INVENTORYCATEGORYMASTER I"
            str = str & "  ON T.CATEGORYCODE=I.CATEGORYCODE"

            str = str & "  UPDATE TEMPSTOCKISSUEDETAIL SET rate=WEIGHTEDRATE WHERE RATEFLAG='W'"
            str = str & "  UPDATE TEMPSTOCKISSUEDETAIL SET rate=BATCHRATE WHERE RATEFLAG='P'"
            str = str & "  UPDATE TEMPSTOCKISSUEDETAIL SET rate=R.BATCHRATE FROM TEMPSTOCKISSUEDETAIL T INNER JOIN vw_ratelist R ON"
            str = str & "  R.batchno = t.BATCHNO And r.Itemcode = t.Itemcode"

            str = str & "  UPDATE TEMPSTOCKISSUEDETAIL SET qty=qty/CONVVALUE WHERE ISNULL(CONVVALUE,0)<>0"
            str = str & "  update TEMPSTOCKISSUEDETAIL set AMOUNT=rate*qty"
            str = str & "  END "
            gconnection.dataOperation1(6, str, "cp_stockissue")


        End If
        str = "Select * from sysobjects where name='stocksummary' and xtype='u'"
        gconnection.getDataSet(str, "stocksummary")
        If gdataset.Tables("stocksummary").Rows.Count > 0 Then

        Else

            str = " CREATE TABLE [dbo].[stocksummary]("
            str = str & "   [autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & "  	[itemcode] [varchar](50) NULL,"
            str = str & "  	[itemname] [varchar](50) NULL,"
            str = str & "  	[storecode] [varchar](50) NULL,"
            str = str & "  [opstk] [numeric](18, 3) NULL,"
            str = str & "  [opqty] [numeric](18, 3) NULL,"
            str = str & "  	[issqty] [numeric](18, 3) NULL,"
            str = str & "  [dmgqty] [numeric](18, 3) NULL,"
            str = str & "  [adjqty] [numeric](18, 3) NULL,"
            str = str & "  [saleqty] [numeric](18, 3) NULL,"
            str = str & "  	[receiveqty] [numeric](18, 3) NULL,"
            str = str & "  	[uom] [varchar](50) NULL,"
            str = str & "  	[closingqty] [numeric](18, 3) NULL,"
            str = str & "  [Openningqty] [numeric](18, 3) NULL,"
            str = str & "   [ruom] [varchar](50) NULL,"
            str = str & "  [rconvvalue] [numeric](18, 3) NULL,"
            str = str & "  [opweightedrate] [numeric](18, 3) NULL,"
            str = str & "  [oplprate] [numeric](18, 3) NULL,"
            str = str & "   [oprate] [numeric](18, 3) NULL,"
            str = str & "   [opvalue] [numeric](18, 3) NULL,"
            str = str & " [clweightedrate] [numeric](18, 3) NULL,"
            str = str & " [cllprate] [numeric](18, 3) NULL,"
            str = str & " [clrate] [numeric](18, 3) NULL,"
            str = str & " [clvalue] [numeric](18, 3) NULL,"
            str = str & " [CATEGORYCODE] [varchar](50) NULL,"
            str = str & " [BATCHPROCESS] [varchar](50) NULL,"
            str = str & "  [RATEFLAG] [varchar](10) NULL"
            str = str & "   ) ON [PRIMARY]"
            gconnection.dataOperation1(6, str, "stocksummary")

        End If
        str = "Select * from sysobjects where name='CP_stocksummary' and xtype='P'"
        gconnection.getDataSet(str, "stocksummary")
        If gdataset.Tables("stocksummary").Rows.Count > 0 Then

        Else

            str = " create PROCEDURE [dbo].[CP_stocksummary] @financialyear datetime, @FROMDATE datetime,@todate datetime,@storecode varchar(50) "

            str = str & " AS"
            str = str & "  BEGIN "



            str = str & "    DECLARE @itemcode varchar(50),@tuom varchar(50)"
            str = str & "  declare @weightedrate numeric(18,2),@batchrate numeric(18,2)"

            str = str & "  select isnull(SUM(isnull(qty,0)),0) as qty ,itemcode,storecode into "
            str = str & "  tempstocktable from closingqty where trndate between DATEADD(dd,1,@financialyear) "
            str = str & "  and @FROMDATE and storecode=@storecode group by itemcode,storecode"

            str = str & "  update stocksummary set opqty=isnull(t.qty,0) from tempstocktable T inner join stocksummary  S on "
            str = str & "  s.itemcode = t.itemcode And s.storecode = t.storecode"

            str = str & "   drop table tempstocktable"
            str = str & "  select isnull(SUM(isnull(qty,0)),0) as qty ,itemcode,storecode into tempstocktable from closingqty where trndate between @fromdate and @todate "
            str = str & "   and storecode=@storecode and ttype='ISSUE' group by itemcode,storecode"

            str = str & "   update stocksummary set issqty=isnull(t.qty,0) from tempstocktable T inner join stocksummary  S on "
            str = str & "       s.itemcode = t.itemcode And s.storecode = t.storecode"

            str = str & "   drop table tempstocktable"


            str = str & "   select isnull(SUM(isnull(qty,0)),0) as qty ,itemcode,storecode into tempstocktable from closingqty where trndate between @fromdate and @todate "
            str = str & "  and storecode=@storecode and ttype='DAMAGE' group by itemcode,storecode"

            str = str & "  update stocksummary set dmgqty=isnull(t.qty,0) from tempstocktable T inner join stocksummary  S on "
            str = str & "  s.itemcode = t.itemcode And s.storecode = t.storecode"

            str = str & "  drop table tempstocktable"


            str = str & "  select isnull(SUM(isnull(qty,0)),0) as qty ,itemcode,storecode into tempstocktable from closingqty where trndate between @fromdate and @todate "
            str = str & "  and storecode=@storecode and ttype='ADJUSTMENT' group by itemcode,storecode"

            str = str & "  update stocksummary set adjqty=isnull(t.qty,0) from tempstocktable T inner join stocksummary  S on "
            str = str & "  s.itemcode = t.itemcode And s.storecode = t.storecode"

            str = str & "  drop table tempstocktable"

            str = str & "  select isnull(SUM(isnull(qty,0)),0) as qty ,itemcode,storecode into tempstocktable from closingqty where trndate between @fromdate and @todate "
            str = str & "  and storecode=@storecode and ttype in ('GRN','RECEIEVE') group by itemcode,storecode"

            str = str & "  update stocksummary set receiveqty=isnull(t.qty,0) from tempstocktable T inner join stocksummary  S on "
            str = str & "  s.itemcode = t.itemcode And s.storecode = t.storecode"

            str = str & "  UPDATE stocksummary SET receiveqty='0' WHERE receiveqty IS NULL"
            str = str & "  UPDATE stocksummary SET adjqty='0' WHERE adjqty IS NULL "
            str = str & "  UPDATE stocksummary SET dmgqty='0' WHERE dmgqty IS NULL "
            str = str & "  UPDATE stocksummary SET issqty='0' WHERE issqty IS NULL "
            str = str & "  UPDATE stocksummary SET opqty='0' WHERE opqty IS NULL "
            str = str & "  UPDATE stocksummary SET SALEQTY='0' WHERE SALEQTY IS NULL "

            str = str & "  UPDATE stocksummary SET Openningqty=opqty+opstk "
            str = str & "  drop table tempstocktable"

            str = str & "  UPDATE stocksummary SET closingqty=Openningqty+receiveqty+issqty+dmgqty+adjqty+saleqty"

            str = str & "  UPDATE stocksummary SET CATEGORYCODE=I.CATEGORY ,BATCHPROCESS=I.BATCHPROCESS  FROM INV_InventoryItemMaster I INNER JOIN stocksummary T"
            str = str & "  ON I.itemcode=T.ITEMCODE "
            str = str & "  UPDATE stocksummary SET RATEFLAG=I.RATEFLAG FROM stocksummary T INNER JOIN INVENTORYCATEGORYMASTER I"
            str = str & "  ON T.CATEGORYCODE=I.CATEGORYCODE"

            str = str & "  DECLARE cursorName CURSOR "

            str = str & "  LOCAL SCROLL STATIC"

            str = str & "  FOR"
            str = str & "  select itemcode from stocksummary"
            str = str & "  OPEN cursorName "

            str = str & "  FETCH NEXT FROM cursorName"

            str = str & "  INTO @itemcode"
            str = str & "  set @weightedrate=0"
            str = str & "  set @batchrate=0"
            str = str & "  set @tuom=''"

            str = str & "  select TOP 1 @weightedrate=weightedrate,@batchrate=batchrate, @tuom=uom from vw_ratelist where grndate<=@fromdate and Itemcode=@itemcode"
            str = str & "  print @weightedrate"
            str = str & "  print @batchrate"
            str = str & "  print @tuom"
            str = str & "  PRINT @itemcode + ' '"

            str = str & "  update stocksummary set opweightedrate=@weightedrate,oplprate=@batchrate,ruom=@tuom"
            str = str & "  where  Itemcode=@itemcode  "
            str = str & "  set @weightedrate=0"
            str = str & "  set @batchrate=0"
            str = str & "  set @tuom=''"
            str = str & "  select TOP 1 @weightedrate=weightedrate,@batchrate=batchrate, @tuom=uom from vw_ratelist where grndate<=@TOdate and Itemcode=@itemcode order by grndate desc"
            str = str & "  update stocksummary set CLweightedrate=@weightedrate,CLlprate=@batchrate"
            str = str & "  where  Itemcode=@itemcode  "
            str = str & "  WHILE @@FETCH_STATUS = 0"

            str = str & "              BEGIN"

            str = str & "  FETCH NEXT FROM cursorName"


            str = str & "     INTO @itemcode"
            str = str & "  set @weightedrate=0"
            str = str & "  set @batchrate=0"
            str = str & "  set @tuom=''"

            str = str & "  select TOP 1 @weightedrate=weightedrate,@batchrate=batchrate, @tuom=uom from vw_ratelist where grndate<=@fromdate and Itemcode=@itemcode order by grndate desc"

            str = str & "  print @weightedrate"
            str = str & "  print @batchrate"
            str = str & "  print @tuom"
            str = str & "  PRINT @itemcode + ' '  "

            str = str & "  update stocksummary set opweightedrate=@weightedrate,oplprate=@batchrate,ruom=@tuom"
            str = str & "  where  Itemcode=@itemcode  "
            str = str & "  set @weightedrate=0"
            str = str & "  set @batchrate=0"
            str = str & "  set @tuom=''"
            str = str & "  select TOP 1 @weightedrate=weightedrate,@batchrate=batchrate, @tuom=uom from vw_ratelist where grndate<=@TOdate and Itemcode=@itemcode"
            str = str & "  update stocksummary set CLweightedrate=@weightedrate,CLlprate=@batchrate"
            str = str & "  where  Itemcode=@itemcode  "
            str = str & "  End"

            str = str & "  CLOSE cursorName "

            str = str & "  DEALLOCATE cursorName"

            str = str & "  UPDATE stocksummary SET OPrate=opweightedrate WHERE RATEFLAG='W'"
            str = str & "  UPDATE stocksummary SET OPrate=oplprate WHERE RATEFLAG='P'"
            str = str & "  UPDATE stocksummary SET CLrate=CLweightedrate WHERE RATEFLAG='W'"
            str = str & "  UPDATE stocksummary SET CLrate=CLlprate WHERE RATEFLAG='P'"

            str = str & "  update stocksummary set  rconvvalue=INVENTORY_TRANSCONVERSION.CONVVALUE from stocksummary inner join INVENTORY_TRANSCONVERSION on INVENTORY_TRANSCONVERSION.BASEUOM=stocksummary.uom"
            str = str & "  and INVENTORY_TRANSCONVERSION.TRANSUOM=stocksummary.Ruom"
            str = str & "  update stocksummary set OPrate=OPrate*rconvvalue,clrate=clrate*rconvvalue WHERE ISNULL(rCONVVALUE,0)<>0"
            str = str & "  UPDATE stocksummary SET clvalue=clrate*closingqty"
            str = str & "  UPDATE stocksummary SET opvalue=oprate*Openningqty"
            str = str & "  End"
            gconnection.dataOperation1(6, str, "stocksummary")

        End If
        str = "Select * from sysobjects where name='StockConsumption_detail' and xtype='u'"
        gconnection.getDataSet(str, "StockConsumption_detail")
        If gdataset.Tables("StockConsumption_detail").Rows.Count > 0 Then

        Else
            str = " CREATE TABLE [dbo].[StockConsumption_detail]("
            str = str & "  [Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " 	[docno] [varchar](50) NULL,"
            str = str & " [Docdetails] [varchar](50) NULL,"
            str = str & " [docdate] [datetime] NULL,"
            str = str & " [doctype] [varchar](50) NULL,"
            str = str & " [Storecode] [varchar](50) NULL,"
            str = str & " [StoreDESC] [varchar](50) NULL,"
            str = str & " [itemcode] [varchar](50) NULL,"
            str = str & " [itemname] [varchar](50) NULL,"
            str = str & " [uom] [varchar](50) NULL,"
            str = str & " [qty] [numeric](18, 3) NULL,"
            str = str & " [batchno] [varchar](50) NULL,"
            str = str & " [consumer] [varchar](50) NULL,"
            str = str & " [closingqty] [numeric](18, 3) NULL,"
            str = str & " [Remarks] [varchar](200) NULL,"
            str = str & " [void] [varchar](1) NULL,"
            str = str & " [AddDate] [datetime] NULL,"
            str = str & " [addUSER] [varchar](50) NULL,"
            str = str & " [UPDATEUSER] [varchar](15) NULL,"
            str = str & " [UPDATEtime] [datetime] NULL,"
            str = str & " [voiduser] [varchar](50) NULL,"
            str = str & " 	[voidtime] [datetime] NULL"
            str = str & " ) ON [PRIMARY]"
            gconnection.dataOperation1(6, str, "StockConsumption_detail")

        End If

        str = "Select * from sysobjects where name='StockConsumption_header' and xtype='u'"
        gconnection.getDataSet(str, "StockConsumption_header")
        If gdataset.Tables("StockConsumption_header").Rows.Count > 0 Then

        Else



            str = "  CREATE TABLE [dbo].[StockConsumption_header]("
            str = str & " 	[Autoid] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
            str = str & " 	[docno] [varchar](50) NULL,"
            str = str & " 	[Docdetails] [varchar](50) NULL,"
            str = str & " 	[doctype] [varchar](50) NULL,"
            str = str & " 	[docdate] [datetime] NULL,"
            str = str & " [Storecode] [varchar](50) NULL,"
            str = str & " 	[StoreDESC] [varchar](50) NULL,"
            str = str & " 	[totalqty] [numeric](18, 3) NULL,"
            str = str & " [Remarks] [varchar](200) NULL,"
            str = str & " [void] [varchar](1) NULL,"
            str = str & " 	[voidreason] [varchar](200) NULL,"
            str = str & " 	[AddDate] [datetime] NULL,"
            str = str & " 	[addUSER] [varchar](50) NULL,"
            str = str & " 	[UPDATEUSER] [varchar](15) NULL,"
            str = str & " 	[UPDATEtime] [datetime] NULL,"
            str = str & " 	[voiduser] [varchar](50) NULL,"
            str = str & " 	[voidtime] [datetime] NULL"
            str = str & "  ) ON [PRIMARY]"

            gconnection.dataOperation1(6, str, "StockConsumption_header")

        End If

        str = "Select * from sysobjects where name='STOCKTRANSFERDETAIL' and xtype='u'"
        gconnection.getDataSet(str, "STOCKTRANSFERDETAIL")
        If gdataset.Tables("STOCKTRANSFERDETAIL").Rows.Count > 0 Then

        Else



            str = " CREATE TABLE [dbo].[STOCKTRANSFERDETAIL]("
            str = str & "  [docno] [varchar](50) NULL,"
            str = str & " [Docdetails] [varchar](50) NULL,"
            str = str & "  [docdate] [datetime]  nULL,"
            str = str & " 	[doctype] [varchar](50) NULL,"
            str = str & " 	[transferno] [varchar](50) NULL,"
            str = str & " 	[fromstorecode] [varchar](50) NULL,"
            str = str & " 	[fromstoredesc] [varchar](50) NULL,"
            str = str & " 	[tostorecode] [varchar](50) NULL,"
            str = str & " 	[tostoredesc] [varchar](50) NULL,"
            str = str & " 	[itemcode] [varchar](50) NULL,"
            str = str & " 	[itemname] [varchar](50) NULL,"
            str = str & " 	[uom] [varchar](50) NULL,"
            str = str & " 	[qty] [numeric](18, 3) NULL,"
            str = str & " 	[batchno] [varchar](50) NULL,"
            str = str & " 	[closingqty] [numeric](18, 3) NULL,"
            str = str & " 	[void] [varchar](50) NULL,"
            str = str & " 	[adduser] [varchar](50) NULL,"
            str = str & " 	[adddatetime] [datetime] NULL,"
            str = str & " 	[updateuser] [varchar](50) NULL,"
            str = str & " 	[updatedate] [datetime] NULL,"
            str = str & " 	[voiduser] [varchar](50) NULL,"
            str = str & " 	[voiddate] [datetime] NULL"
            str = str & "  ) ON [PRIMARY]"
            gconnection.dataOperation1(6, str, "STOCKTRANSFERDETAIL")

        End If

        str = "Select * from sysobjects where name='STOCKTRANSFERHEADER' and xtype='U'"
        gconnection.getDataSet(str, "STOCKTRANSFERHEADER")
        If gdataset.Tables("STOCKTRANSFERHEADER").Rows.Count > 0 Then

        Else

            str = " CREATE TABLE [dbo].[STOCKTRANSFERHEADER]("
            str = str & " 		[docno] [varchar](50) NULL,"
            str = str & " 		[docdetails] [varchar](50) NULL,"
            str = str & " 		[docdate] [datetime] NULL,"
            str = str & " 		[doctype] [varchar](50) NULL,"
            str = str & " 		[transferno] [varchar](50) NULL,"
            str = str & " 		[fromstorecode] [varchar](50) NULL,"
            str = str & " 		[fromstoredesc] [varchar](50) NULL,"
            str = str & " 		[tostorecode] [varchar](50) NULL,"
            str = str & " 		[tostoredesc] [varchar](50) NULL,"
            str = str & " 		[remarks] [varchar](200) NULL,"
            str = str & " 		[void] [varchar](5) NULL,"
            str = str & " 		[adduser] [varchar](50) NULL,"
            str = str & " 		[adddate] [datetime] NULL,"
            str = str & " 	[updateuser] [varchar](50) NULL,"
            str = str & " 		[updatedate] [datetime] NULL,"
            str = str & " 		[voiduser] [varchar](50) NULL,"
            str = str & " 		[voiddate] [datetime] NULL"
            str = str & " 	 ) ON [PRIMARY]"

            gconnection.dataOperation1(6, str, "STOCKTRANSFERHEADER")

        End If
        str = "Select * from sysobjects where name='cp_stocktransfer' and xtype='P'"
        gconnection.getDataSet(str, "cp_stocktransfer")
        If gdataset.Tables("cp_stocktransfer").Rows.Count > 0 Then
        Else

            str = "  CREATE PROCEDURE [dbo].[cp_stocktransfer]"

            str = str & " AS"
            str = str & "  BEGIN "
            str = str & "  	DECLARE @itemcode varchar(50), @docdate datetime,@tuom varchar(50),@storecode varchar(50)"
            str = str & "  declare @weightedrate numeric(18,2),@batchrate numeric(18,2)"
            str = str & "  DELETE FROM TEMPSTOCKTRANSFERDETAIL"
            str = str & "  insert into TEMPSTOCKTRANSFERDETAIL(Docno,Docdetails,Docdate,fromstorecode,fromstoredesc,tostorecode,tostoredesc,Itemcode,Itemname,UoM,qty,BATCHNO,VOID) "
            str = str & "  SELECT Docno,Docdetails,Docdate,fromstorecode,fromstoredesc,tostorecode,tostoredesc,Itemcode,Itemname,UoM,qty,BATCHNO,VOID   FROM STOCKTRANSFERDETAIL "


            str = str & "  DECLARE cursorName CURSOR"

            str = str & "  LOCAL SCROLL STATIC"

            str = str & " FOR"
            str = str & " select itemcode,docdate,FROMstorecode from TEMPSTOCKTRANSFERDETAIL"
            str = str & " OPEN cursorName "

            str = str & " FETCH NEXT FROM cursorName"

            str = str & "    INTO @itemcode, @docdate,@storecode"
            str = str & " set @weightedrate=0"
            str = str & " set @batchrate=0"
            str = str & " set @tuom=''"

            str = str & " select TOP 1 @weightedrate=weightedrate,@batchrate=batchrate, @tuom=uom from vw_ratelist where grndate<@docdate and Itemcode=@itemcode"
            str = str & " and storecode=@storecode"
            str = str & " print @weightedrate"
            str = str & " print @batchrate"
            str = str & " print @tuom"
            str = str & " PRINT @itemcode + ' '  "
            str = str & " print @docdate"
            str = str & " update TEMPSTOCKTRANSFERDETAIL set weightedrate=@weightedrate,BATCHRATE=@batchrate,TUOM=@tuom"
            str = str & " where Docdate=@docdate and Itemcode=@itemcode  "

            str = str & " WHILE @@FETCH_STATUS = 0"

            str = str & " BEGIN "

            str = str & " FETCH NEXT FROM cursorName"

            str = str & "    INTO @itemcode, @docdate,@storecode"
            str = str & " set @weightedrate=0"
            str = str & " set @batchrate=0"
            str = str & " set @tuom=''"
            str = str & " select TOP 1 @weightedrate=weightedrate,@batchrate=batchrate, @tuom=uom from vw_ratelist where grndate<@docdate and Itemcode=@itemcode"
            str = str & " and storecode=@storecode  and storecode=@storecode  "
            str = str & " order by grndate desc"
            str = str & " update TEMPSTOCKTRANSFERDETAIL set weightedrate=@weightedrate,BATCHRATE=@batchrate,TUOM=@tuom"
            str = str & " where Docdate=@docdate and Itemcode=@itemcode"
            str = str & " print @weightedrate"
            str = str & " print @batchrate"
            str = str & " print @tuom"

            str = str & " PRINT @itemcode  "
            str = str & " print @docdate"
            str = str & " End"

            str = str & " CLOSE cursorName "

            str = str & "   DEALLOCATE cursorName"
            str = str & " update TEMPSTOCKTRANSFERDETAIL set  convvalue=INVENTORY_TRANSCONVERSION.CONVVALUE from TEMPSTOCKTRANSFERDETAIL inner join INVENTORY_TRANSCONVERSION on INVENTORY_TRANSCONVERSION.BASEUOM=TEMPSTOCKTRANSFERDETAIL.TUOM"
            str = str & " and INVENTORY_TRANSCONVERSION.TRANSUOM=TEMPSTOCKTRANSFERDETAIL.uom"


            str = str & " UPDATE TEMPSTOCKTRANSFERDETAIL SET CATEGORYCODE=I.CATEGORY ,BATCHPROCESS=I.BATCHPROCESS  FROM INV_InventoryItemMaster I INNER JOIN TEMPSTOCKTRANSFERDETAIL T"
            str = str & " ON I.itemcode=T.ITEMCODE "
            str = str & " UPDATE TEMPSTOCKTRANSFERDETAIL SET RATEFLAG=I.RATEFLAG FROM TEMPSTOCKTRANSFERDETAIL T INNER JOIN INVENTORYCATEGORYMASTER I"
            str = str & " ON T.CATEGORYCODE=I.CATEGORYCODE"

            str = str & " UPDATE TEMPSTOCKTRANSFERDETAIL SET rate=WEIGHTEDRATE WHERE RATEFLAG='W'"
            str = str & " UPDATE TEMPSTOCKTRANSFERDETAIL SET rate=BATCHRATE WHERE RATEFLAG='P'"
            str = str & " UPDATE TEMPSTOCKTRANSFERDETAIL SET rate=R.BATCHRATE,rateuom=r.uom FROM TEMPSTOCKTRANSFERDETAIL T INNER JOIN vw_ratelist R ON"
            str = str & " R.batchno = t.BATCHNO And r.Itemcode = t.Itemcode"

            str = str & " UPDATE TEMPSTOCKTRANSFERDETAIL SET QTY=QTY/CONVVALUE WHERE ISNULL(CONVVALUE,0)<>0"
            str = str & " update TEMPSTOCKTRANSFERDETAIL set  rconvvalue=INVENTORY_TRANSCONVERSION.CONVVALUE from TEMPSTOCKTRANSFERDETAIL inner join INVENTORY_TRANSCONVERSION on INVENTORY_TRANSCONVERSION.BASEUOM=TEMPSTOCKTRANSFERDETAIL.tuom"
            str = str & " and INVENTORY_TRANSCONVERSION.TRANSUOM=TEMPSTOCKTRANSFERDETAIL.rateuom"

            str = str & " update TEMPSTOCKTRANSFERDETAIL set rate=rate*rconvvalue WHERE ISNULL(rCONVVALUE,0)<>0"

            str = str & " update TEMPSTOCKTRANSFERDETAIL set AMOUNT=rate*QTY"

            str = str & " End "
            gconnection.dataOperation1(6, str, "cp_stocktransfer")

        End If


        str = "Select * from sysobjects where name='issueregister' and xtype='P'"
        gconnection.getDataSet(str, "issueregister")
        If gdataset.Tables("issueregister").Rows.Count > 0 Then

        Else

            str = " CREATE PROCEDURE [dbo].[issueregister] (@FROMDATE AS varchar(15), @TODATE AS varchar(15), @FINYEARSTART AS VARCHAR(11)) "

            str = str & " AS"

            str = str & " DECLARE @SSQL Varchar(2000),@SQL Varchar(2000),@batchrate numeric(18,2),@weightedrate NUMERIC(18,2),@UOM VARCHAR(50)"
            str = str & " DECLARE @docdate datetime,@itemcode varchar(50)"

            str = str & " delete  from TEMPSTOCKISSUEDETAIL"
            str = str & " set @SQL='insert into TEMPSTOCKISSUEDETAIL(Docno,Docdetails,Docdate,IndentNo,indentdate,storelocationcode,storelocationname,opstorelocationname,opstorelocationcode,Itemcode,Itemname,UoM,ind_qty,qty,BATCHNO,rate,AMOUNT,VOID)'"
            str = str & " set @SQL= @sql +' SELECT Docno,Docdetails,Docdate,IndentNo,indentdate,storelocationcode,storelocationname,opstorelocationname,opstorelocationcode,Itemcode,Itemname,UoM,ind_qty,qty,BATCHNO,rate,AMOUNT,VOID '"
            str = str & " Set @SQL= @SQL + '  FROM STOCKISSUEDETAIL '"
            str = str & " exec @SQL"
            str = str & " set @SQL=''"
            str = str & " Set @SQL='SELECT docdate,ITEMCODE  FROM TEMPSTOCKISSUEDETAIL'"

            str = str & " set @SQL='DECLARE CURPROC CURSOR FOR ' + @ssql"
            str = str & " exec @SQL"
            str = str & " open CURPROC"
            str = str & " Fetch CURPROC into @docdate,@ITEMCODE"
            str = str & " while @@fetch_Status=0"
            str = str & "             Begin"
            str = str & " set @SQL='select top 1 ' + @batchrate +'= batchrate,'+@weightedrate +'= weightedrate,'+ @UOM+'=UOM from ratelist where grndate<'+ @docdate +' and itemcode='+ @itemcode"
            str = str & " exec @sql "
            str = str & " UPDATE TEMPSTOCKISSUEDETAIL SET BATCHRATE=@BATCHRATE,WEIGHTEDRATE=@WEIGHTEDRATE ,"
            str = str & " TUOM=@UOM WHERE Itemcode=@ITEMCODE AND Docdate=@DOCDATE"

            str = str & " Fetch CURPROC into @docdate,@ITEMCODE"

            str = str & " End"

            str = str & " Close CURPROC"
            str = str & " DEALLOCATE CURPROC"
            gconnection.dataOperation1(6, str, "cp_stocktransfer")


        End If

        str = "Select * from sysobjects where name='issueregister' and xtype='P'"
        gconnection.getDataSet(str, "issueregister")
        If gdataset.Tables("issueregister").Rows.Count > 0 Then
        Else

            str = "  CREATE PROCEDURE [dbo].[cp_stockissue]"

            str = str & " AS"
            str = str & "             BEGIN"
            str = str & " DECLARE @itemcode varchar(50), @docdate datetime,@tuom varchar(50),@storecode varchar(50)"
            str = str & " declare @weightedrate numeric(18,2),@batchrate numeric(18,2)"
            str = str & " DELETE FROM TEMPSTOCKISSUEDETAIL"
            str = str & " insert into TEMPSTOCKISSUEDETAIL(Docno,Docdetails,Docdate,IndentNo,indentdate,storelocationcode,storelocationname,opstorelocationname,opstorelocationcode,Itemcode,Itemname,UoM,ind_qty,qty,BATCHNO,rate,AMOUNT,VOID) "
            str = str & " SELECT Docno,Docdetails,Docdate,IndentNo,indentdate,storelocationcode,storelocationname,opstorelocationname,opstorelocationcode,Itemcode,Itemname,UoM,ind_qty,qty,BATCHNO,rate,AMOUNT,VOID   FROM STOCKISSUEDETAIL "


            str = str & " DECLARE cursorName CURSOR "

            str = str & " LOCAL SCROLL STATIC"

            str = str & " FOR"
            str = str & " select itemcode,docdate,storelocationcode from TEMPSTOCKISSUEDETAIL"
            str = str & " OPEN cursorName "

            str = str & " FETCH NEXT FROM cursorName"

            str = str & "    INTO @itemcode, @docdate,@storecode"
            str = str & " set @weightedrate=0"
            str = str & " set @batchrate=0"
            str = str & " set @tuom=''"

            str = str & " select TOP 1 @weightedrate=weightedrate,@batchrate=batchrate, @tuom=uom from vw_ratelist where grndate<@docdate and Itemcode=@itemcode"
            str = str & " and storecode=@storecode"
            str = str & " print @weightedrate"
            str = str & " print @batchrate"
            str = str & " print @tuom"
            str = str & " PRINT @itemcode + ' '  "
            str = str & " print @docdate"
            str = str & " update TEMPSTOCKISSUEDETAIL set weightedrate=@weightedrate,BATCHRATE=@batchrate,TUOM=@tuom"
            str = str & " where Docdate=@docdate and Itemcode=@itemcode  "

            str = str & " WHILE @@FETCH_STATUS = 0"

            str = str & "             BEGIN"

            str = str & " FETCH NEXT FROM cursorName"

            str = str & " INTO @itemcode, @docdate,@storecode"
            str = str & " set @weightedrate=0"
            str = str & " set @batchrate=0"
            str = str & " set @tuom=''"
            str = str & " select TOP 1 @weightedrate=weightedrate,@batchrate=batchrate, @tuom=uom from vw_ratelist where grndate<@docdate and Itemcode=@itemcode"
            str = str & " and storecode=@storecode  and storecode=@storecode  "
            str = str & " order by grndate desc"
            str = str & " update TEMPSTOCKISSUEDETAIL set weightedrate=@weightedrate,BATCHRATE=@batchrate,TUOM=@tuom"
            str = str & " where Docdate=@docdate and Itemcode=@itemcode"
            str = str & " print @weightedrate"
            str = str & " print @batchrate"
            str = str & " print @tuom"

            str = str & "    PRINT @itemcode  "
            str = str & " print @docdate"
            str = str & "  End"

            str = str & " CLOSE cursorName "

            str = str & " DEALLOCATE cursorName"
            str = str & " update TEMPSTOCKISSUEDETAIL set  convvalue=INVENTORY_TRANSCONVERSION.CONVVALUE from TEMPSTOCKISSUEDETAIL inner join INVENTORY_TRANSCONVERSION on INVENTORY_TRANSCONVERSION.BASEUOM=TEMPSTOCKISSUEDETAIL.TUOM"
            str = str & " and INVENTORY_TRANSCONVERSION.TRANSUOM=TEMPSTOCKISSUEDETAIL.uom"

            str = str & " UPDATE TEMPSTOCKISSUEDETAIL SET CATEGORYCODE=I.CATEGORY ,BATCHPROCESS=I.BATCHPROCESS  FROM INV_InventoryItemMaster I INNER JOIN TEMPSTOCKISSUEDETAIL T"
            str = str & " ON I.itemcode=T.ITEMCODE "
            str = str & " UPDATE TEMPSTOCKISSUEDETAIL SET RATEFLAG=I.RATEFLAG FROM TEMPSTOCKISSUEDETAIL T INNER JOIN INVENTORYCATEGORYMASTER I"
            str = str & " ON T.CATEGORYCODE=I.CATEGORYCODE"

            str = str & " UPDATE TEMPSTOCKISSUEDETAIL SET rate=WEIGHTEDRATE WHERE RATEFLAG='W'"
            str = str & " UPDATE TEMPSTOCKISSUEDETAIL SET rate=BATCHRATE WHERE RATEFLAG='P'"
            str = str & " UPDATE TEMPSTOCKISSUEDETAIL SET rate=R.BATCHRATE FROM TEMPSTOCKISSUEDETAIL T INNER JOIN vw_ratelist R ON"
            str = str & "             R.batchno = t.BATCHNO And r.Itemcode = t.Itemcode"

            str = str & " UPDATE TEMPSTOCKISSUEDETAIL SET qty=qty/CONVVALUE WHERE ISNULL(CONVVALUE,0)<>0"
            str = str & " update TEMPSTOCKISSUEDETAIL set AMOUNT=rate*qty"
            str = str & " End"
            gconnection.dataOperation1(6, str, "cp_stockISSUE")

        End If
        str = "Select * from sysobjects where name='cp_stockdamage' and xtype='P'"
        gconnection.getDataSet(str, "cp_stockdamage")
        If gdataset.Tables("cp_stockdamage").Rows.Count > 0 Then
        Else


            str = "   CREATE PROCEDURE [dbo].[cp_stockdamage]"

            str = str & " AS"
            str = str & " BEGIN "
            str = str & " DECLARE @itemcode varchar(50), @docdate datetime,@tuom varchar(50),@storecode varchar(50)"
            str = str & " declare @weightedrate numeric(18,2),@batchrate numeric(18,2)"
            str = str & " DELETE FROM TEMPSTOCKdmgDETAIL"
            str = str & " insert into TEMPSTOCKdmgDETAIL(Docno,Docdetails,Docdate,storecode,storedesc,Itemcode,Itemname,UoM,qty,BATCHNO,VOID) "
            str = str & " SELECT Docno,Docdetails,Docdate,storecode,storedesc,Itemcode,Itemname,UoM,dmgqty,BATCHNO,VOID   FROM STOCKdmgDETAIL "


            str = str & " DECLARE cursorName CURSOR"

            str = str & " LOCAL SCROLL STATIC"

            str = str & " FOR"
            str = str & " select itemcode,docdate,storecode from TEMPSTOCKdmgDETAIL"
            str = str & " OPEN cursorName "

            str = str & " FETCH NEXT FROM cursorName"

            str = str & " INTO @itemcode, @docdate,@storecode"
            str = str & " set @weightedrate=0"
            str = str & " set @batchrate=0"
            str = str & " set @tuom=''"

            str = str & "  select TOP 1 @weightedrate=weightedrate,@batchrate=batchrate, @tuom=uom from vw_ratelist where grndate<@docdate and Itemcode=@itemcode"
            str = str & " and storecode=@storecode"
            str = str & " print @weightedrate"
            str = str & " print @batchrate"
            str = str & " print @tuom"
            str = str & " PRINT @itemcode + ' '  "
            str = str & " print @docdate"
            str = str & " update TEMPSTOCKdmgDETAIL set weightedrate=@weightedrate,BATCHRATE=@batchrate,TUOM=@tuom"
            str = str & " where Docdate=@docdate and Itemcode=@itemcode  "

            str = str & " WHILE @@FETCH_STATUS = 0"

            str = str & " BEGIN"

            str = str & " FETCH NEXT FROM cursorName"

            str = str & " INTO @itemcode, @docdate,@storecode"
            str = str & " set @weightedrate=0"
            str = str & " set @batchrate=0"
            str = str & " set @tuom=''"
            str = str & " select TOP 1 @weightedrate=weightedrate,@batchrate=batchrate, @tuom=uom from vw_ratelist where grndate<@docdate and Itemcode=@itemcode"
            str = str & " and storecode=@storecode  and storecode=@storecode  "
            str = str & " order by grndate desc"
            str = str & " update TEMPSTOCKdmgDETAIL set weightedrate=@weightedrate,BATCHRATE=@batchrate,TUOM=@tuom"
            str = str & " where Docdate=@docdate and Itemcode=@itemcode"
            str = str & " print @weightedrate"
            str = str & " print @batchrate"
            str = str & " print @tuom"

            str = str & "    PRINT @itemcode  "
            str = str & " print @docdate"
            str = str & " End"

            str = str & " CLOSE cursorName "

            str = str & " DEALLOCATE cursorName"
            str = str & " update TEMPSTOCKDMGDETAIL set  convvalue=INVENTORY_TRANSCONVERSION.CONVVALUE from TEMPSTOCKDMGDETAIL inner join INVENTORY_TRANSCONVERSION on INVENTORY_TRANSCONVERSION.BASEUOM=TEMPSTOCKDMGDETAIL.TUOM"
            str = str & " and INVENTORY_TRANSCONVERSION.TRANSUOM=TEMPSTOCKDMGDETAIL.uom"


            str = str & " UPDATE TEMPSTOCKDMGDETAIL SET CATEGORYCODE=I.CATEGORY ,BATCHPROCESS=I.BATCHPROCESS  FROM INV_InventoryItemMaster I INNER JOIN TEMPSTOCKDMGDETAIL T"
            str = str & " ON I.itemcode=T.ITEMCODE "
            str = str & " UPDATE TEMPSTOCKDMGDETAIL SET RATEFLAG=I.RATEFLAG FROM TEMPSTOCKDMGDETAIL T INNER JOIN INVENTORYCATEGORYMASTER I"
            str = str & " ON T.CATEGORYCODE=I.CATEGORYCODE"

            str = str & " UPDATE TEMPSTOCKDMGDETAIL SET rate=WEIGHTEDRATE WHERE RATEFLAG='W'"
            str = str & " UPDATE TEMPSTOCKDMGDETAIL SET rate=BATCHRATE WHERE RATEFLAG='P'"
            str = str & " UPDATE TEMPSTOCKDMGDETAIL SET rate=R.BATCHRATE FROM TEMPSTOCKDMGDETAIL T INNER JOIN vw_ratelist R ON"
            str = str & " R.batchno = t.BATCHNO And r.Itemcode = t.Itemcode"

            str = str & " UPDATE TEMPSTOCKDMGDETAIL SET QTY=QTY/CONVVALUE WHERE ISNULL(CONVVALUE,0)<>0"
            str = str & " update TEMPSTOCKDMGDETAIL set AMOUNT=rate*QTY"

            str = str & " End"
            gconnection.dataOperation1(6, str, "cp_stockDAMAGE")

        End If

        str = "Select * from sysobjects where name='cp_stockconsumption' and xtype='P'"
        gconnection.getDataSet(str, "cp_stockconsumption")
        If gdataset.Tables("cp_stockconsumption").Rows.Count > 0 Then
        Else


            str = "    create PROCEDURE [dbo].[cp_stockconsumption]"

            str = str & " AS"
            str = str & " BEGIN "
            str = str & " 	DECLARE @itemcode varchar(50), @docdate datetime,@tuom varchar(50),@storecode varchar(50)"
            str = str & " declare @weightedrate numeric(18,2),@batchrate numeric(18,2)"
            str = str & " DELETE FROM TEMPSTOCKCONSUMPTIONDETAIL"
            str = str & " insert into TEMPSTOCKCONSUMPTIONDETAIL(Docno,Docdetails,Docdate,storecode,storedesc,Itemcode,Itemname,UoM,qty,BATCHNO,VOID,consumer) "
            str = str & " SELECT Docno,Docdetails,Docdate,storecode,storedesc,Itemcode,Itemname,UoM,qty,BATCHNO,VOID,consumer   FROM StockConsumption_detail "


            str = str & " DECLARE cursorName CURSOR "

            str = str & " LOCAL SCROLL STATIC"

            str = str & " FOR"
            str = str & " select itemcode,docdate,storecode from TEMPSTOCKCONSUMPTIONDETAIL"
            str = str & " OPEN cursorName "

            str = str & " FETCH NEXT FROM cursorName"

            str = str & "  INTO @itemcode, @docdate,@storecode"
            str = str & " set @weightedrate=0"
            str = str & " set @batchrate=0"
            str = str & " set @tuom=''"

            str = str & "  select TOP 1 @weightedrate=weightedrate,@batchrate=batchrate, @tuom=uom from vw_ratelist where grndate<@docdate and Itemcode=@itemcode"
            str = str & " and storecode=@storecode"
            str = str & " print @weightedrate"
            str = str & " print @batchrate"
            str = str & " print @tuom"
            str = str & " PRINT @itemcode + ' '  "
            str = str & " print @docdate"
            str = str & " update TEMPSTOCKCONSUMPTIONDETAIL set weightedrate=@weightedrate,BATCHRATE=@batchrate,TUOM=@tuom"
            str = str & " where Docdate=@docdate and Itemcode=@itemcode  "

            str = str & " WHILE @@FETCH_STATUS = 0"

            str = str & " BEGIN "

            str = str & " FETCH NEXT FROM cursorName"

            str = str & " INTO @itemcode, @docdate,@storecode"
            str = str & " set @weightedrate=0"
            str = str & " set @batchrate=0"
            str = str & " set @tuom=''"
            str = str & " select TOP 1 @weightedrate=weightedrate,@batchrate=batchrate, @tuom=uom from vw_ratelist where grndate<@docdate and Itemcode=@itemcode"
            str = str & " and storecode=@storecode  and storecode=@storecode  "
            str = str & " order by grndate desc"
            str = str & " update TEMPSTOCKCONSUMPTIONDETAIL set weightedrate=@weightedrate,BATCHRATE=@batchrate,TUOM=@tuom"
            str = str & " where Docdate=@docdate and Itemcode=@itemcode"
            str = str & " print @weightedrate"
            str = str & " print @batchrate"
            str = str & " print @tuom"

            str = str & " PRINT @itemcode  "
            str = str & " print @docdate"
            str = str & " End"

            str = str & " CLOSE cursorName "

            str = str & " DEALLOCATE cursorName"
            str = str & " update TEMPSTOCKCONSUMPTIONDETAIL set  convvalue=INVENTORY_TRANSCONVERSION.CONVVALUE from TEMPSTOCKCONSUMPTIONDETAIL inner join INVENTORY_TRANSCONVERSION on INVENTORY_TRANSCONVERSION.BASEUOM=TEMPSTOCKCONSUMPTIONDETAIL.TUOM"
            str = str & " and INVENTORY_TRANSCONVERSION.TRANSUOM=TEMPSTOCKCONSUMPTIONDETAIL.uom"


            str = str & " UPDATE TEMPSTOCKCONSUMPTIONDETAIL SET CATEGORYCODE=I.CATEGORY ,BATCHPROCESS=I.BATCHPROCESS  FROM INV_InventoryItemMaster I INNER JOIN TEMPSTOCKCONSUMPTIONDETAIL T"
            str = str & " ON I.itemcode=T.ITEMCODE "
            str = str & " UPDATE TEMPSTOCKCONSUMPTIONDETAIL SET RATEFLAG=I.RATEFLAG FROM TEMPSTOCKCONSUMPTIONDETAIL T INNER JOIN INVENTORYCATEGORYMASTER I"
            str = str & " ON T.CATEGORYCODE=I.CATEGORYCODE"

            str = str & " UPDATE TEMPSTOCKCONSUMPTIONDETAIL SET rate=WEIGHTEDRATE WHERE RATEFLAG='W'"
            str = str & " UPDATE TEMPSTOCKCONSUMPTIONDETAIL SET rate=BATCHRATE WHERE RATEFLAG='P'"
            str = str & " UPDATE TEMPSTOCKCONSUMPTIONDETAIL SET rate=R.BATCHRATE FROM TEMPSTOCKCONSUMPTIONDETAIL T INNER JOIN vw_ratelist R ON"
            str = str & " R.batchno = t.BATCHNO And r.Itemcode = t.Itemcode"

            str = str & " UPDATE TEMPSTOCKCONSUMPTIONDETAIL SET QTY=QTY/CONVVALUE WHERE ISNULL(CONVVALUE,0)<>0"
            str = str & " update TEMPSTOCKCONSUMPTIONDETAIL set AMOUNT=rate*QTY"

            str = str & " End"
            gconnection.dataOperation1(6, str, "cp_stockCONSUMPTION")

        End If
        str = "Select * from sysobjects where name='CP_stockconsolidatesummary' and xtype='P'"
        gconnection.getDataSet(str, "CP_stockconsolidatesummary")
        If gdataset.Tables("CP_stockconsolidatesummary").Rows.Count > 0 Then
        Else



            str = " CREATE PROCEDURE [dbo].[CP_stockconsolidatesummary] @financialyear datetime, @FROMDATE datetime,@todate datetime "

            str = str & " AS"
            str = str & "  BEGIN "
            str = str & " SELECT MAX(TRNDATE) AS OPDATE,UoM,storecode,ITEMCODE,TRNNO,'           ' AS TUOM,0 AS CONVVALUE,0 AS OPQTY "
            str = str & " into tempstocktabLe FROM CLOSINGQTY  "
            str = str & " WHERE"
            str = str & " Trndate<@fromdate and itemcode in (select itemcode from consolidatestocksummary)"
            str = str & " GROUP BY UoM,storecode,ITEMCODE ,TRNNO"

            str = str & " SELECT MAX(TRNDATE) AS CLDATE,UoM,storecode,ITEMCODE,TRNNO,'          ' AS TUOM,0 AS CONVVALUE,0 AS CLQTY"
            str = str & " into tempstocktabLe1 FROM CLOSINGQTY  "
            str = str & " WHERE"
            str = str & " Trndate<@TODATE and itemcode in (select itemcode from consolidatestocksummary)"
            str = str & " GROUP BY UoM,storecode,ITEMCODE ,TRNNO"
            str = str & " update consolidatestocksummary set consolidatestocksummary.uom=Vw_Ratelist.UoM from Vw_Ratelist inner join consolidatestocksummary"
            str = str & " on consolidatestocksummary.itemcode=Vw_Ratelist.itemcode"



            str = str & " UPDATE TEMPSTOCKTABLE SET TUOM=consolidatestocksummary.UOM  FROM TEMPSTOCKTABLE INNER JOIN consolidatestocksummary"
            str = str & " ON TEMPSTOCKTABLE.ITEMCODE=consolidatestocksummary.ITEMCODE "

            str = str & " UPDATE TEMPSTOCKTABLE1 SET TUOM=consolidatestocksummary.UOM  FROM TEMPSTOCKTABLE1 INNER JOIN consolidatestocksummary"
            str = str & " ON TEMPSTOCKTABLE1.ITEMCODE=consolidatestocksummary.ITEMCODE"

            str = str & " update tempstocktable set  convvalue=INVENTORY_TRANSCONVERSION.CONVVALUE from tempstocktable "
            str = str & " inner join INVENTORY_TRANSCONVERSION on INVENTORY_TRANSCONVERSION.BASEUOM=tempstocktable.Tuom"
            str = str & " and INVENTORY_TRANSCONVERSION.TRANSUOM=tempstocktable.uom"




            str = str & " update tempstocktable1 set  convvalue=INVENTORY_TRANSCONVERSION.CONVVALUE from tempstocktable1 "
            str = str & " inner join INVENTORY_TRANSCONVERSION on INVENTORY_TRANSCONVERSION.BASEUOM=tempstocktable1.Tuom"
            str = str & " and INVENTORY_TRANSCONVERSION.TRANSUOM=tempstocktable1.uom"



            str = str & " UPDATE TEMPSTOCKTABLE SET OPQTY=CLOSINGSTOCK       FROM TEMPSTOCKTABLE INNER JOIN  CLOSINGQTY "
            str = str & " ON  TEMPSTOCKTABLE.TRNNO=CLOSINGQTY.TRNNO AND TEMPSTOCKTABLE.ITEMCODE=CLOSINGQTY.ITEMCODE and "
            str = str & " TEMPSTOCKTABLE.OPDATE = CLOSINGQTY.TRNDATE"



            str = str & " UPDATE TEMPSTOCKTABLE1 SET CLQTY=CLOSINGSTOCK       FROM TEMPSTOCKTABLE1 INNER JOIN  CLOSINGQTY "
            str = str & " ON  TEMPSTOCKTABLE1.TRNNO=CLOSINGQTY.TRNNO AND TEMPSTOCKTABLE1.ITEMCODE=CLOSINGQTY.ITEMCODE"
            str = str & " and TEMPSTOCKTABLE1.CLDATE=CLOSINGQTY.TRNDATE"


            str = str & " UPDATE TEMPSTOCKTABLE SET OPQTY=OPQTY*CONVVALUE "
            str = str & " UPDATE TEMPSTOCKTABLE1 SET CLQTY=CLQTY*CONVVALUE "

            str = str & " SELECT SUM(OPQTY) AS OPSTOCK,ITEMCODE INTO OPTEMP FROM TEMPSTOCKTABLE  GROUP BY ITEMCODE"
            str = str & " SELECT SUM(CLQTY) AS CLSTOCK,ITEMCODE INTO CLTEMP FROM TEMPSTOCKTABLE1  GROUP BY ITEMCODE"

            str = str & " UPDATE consolidatestocksummary SET OPQTY=OPSTOCK FROM  OPTEMP INNER JOIN consolidatestocksummary"
            str = str & " ON consolidatestocksummary.ITEMCODE=OPTEMP.ITEMCODE"

            str = str & " UPDATE consolidatestocksummary SET CLQTY=CLSTOCK FROM  CLTEMP INNER JOIN consolidatestocksummary"
            str = str & " ON consolidatestocksummary.ITEMCODE=CLTEMP.ITEMCODE"
            str = str & " DROP TABLE TEMPSTOCKTABLE"
            str = str & " DROP TABLE TEMPSTOCKTABLE1"
            str = str & " DROP TABLE OPTEMP"
            str = str & " DROP TABLE  CLTEMP"

            str = str & "   End"
            gconnection.dataOperation1(6, str, "consolidatestocksummary")

        End If
        str = "Select * from sysobjects where name='cp_stockadjustment' and xtype='P'"
        gconnection.getDataSet(str, "cp_stockadjustment")
        If gdataset.Tables("cp_stockadjustment").Rows.Count > 0 Then
        Else


            str = "        CREATE PROCEDURE [dbo].[cp_stockadjustment]"

            str = str & "  AS"
            str = str & "  BEGIN "
            str = str & "  DECLARE @itemcode varchar(50), @docdate datetime,@tuom varchar(50),@storecode varchar(50)"
            str = str & "  declare @weightedrate numeric(18,2),@batchrate numeric(18,2)"
            str = str & "  DELETE FROM TEMPSTOCKadjDETAIL"
            str = str & "  insert into TEMPSTOCKadjDETAIL(Docno,Docdetails,Docdate,storecode,storedesc,Itemcode,Itemname,UoM,stockinhand,adjustedstock,physicalstock,BATCHNO,VOID) "
            str = str & "  SELECT Docno,Docdetails,Docdate,storecode,storedesc,Itemcode,Itemname,UoM,stockinhand,adjustedstock,physicalstock,BATCHNO,VOID   FROM STOCKadjustDETAILs "


            str = str & "  DECLARE cursorName CURSOR "

            str = str & "  LOCAL SCROLL STATIC"

            str = str & "  FOR"
            str = str & "  select itemcode,docdate,storecode from TEMPSTOCKadjDETAIL"
            str = str & "  OPEN cursorName "

            str = str & "  FETCH NEXT FROM cursorName"

            str = str & "  INTO @itemcode, @docdate,@storecode"
            str = str & "  set @weightedrate=0"
            str = str & "  set @batchrate=0"
            str = str & "  set @tuom=''"

            str = str & "   select TOP 1 @weightedrate=weightedrate,@batchrate=batchrate, @tuom=uom from vw_ratelist where grndate<@docdate and Itemcode=@itemcode"
            str = str & "  and storecode=@storecode"
            str = str & "  print @weightedrate"
            str = str & "  print @batchrate"
            str = str & "  print @tuom"
            str = str & "  PRINT @itemcode + ' ' "
            str = str & "  print @docdate"
            str = str & "  update TEMPSTOCKadjDETAIL set weightedrate=@weightedrate,BATCHRATE=@batchrate,TUOM=@tuom"
            str = str & "  where Docdate=@docdate and Itemcode=@itemcode  "

            str = str & "  WHILE @@FETCH_STATUS = 0"

            str = str & "          BEGIN "

            str = str & "  FETCH NEXT FROM cursorName"

            str = str & "     INTO @itemcode, @docdate,@storecode"
            str = str & "  set @weightedrate=0"
            str = str & "  set @batchrate=0"
            str = str & "  set @tuom=''"
            str = str & "  select TOP 1 @weightedrate=weightedrate,@batchrate=batchrate, @tuom=uom from vw_ratelist where grndate<@docdate and Itemcode=@itemcode"
            str = str & "  and storecode=@storecode  and storecode=@storecode  "
            str = str & "  order by grndate desc"
            str = str & "  update TEMPSTOCKadjDETAIL set weightedrate=@weightedrate,BATCHRATE=@batchrate,TUOM=@tuom"
            str = str & "  where Docdate=@docdate and Itemcode=@itemcode"
            str = str & "  print @weightedrate"
            str = str & "  print @batchrate"
            str = str & "  print @tuom"

            str = str & "     PRINT @itemcode "
            str = str & "  print @docdate"
            str = str & "  End"

            str = str & "  CLOSE cursorName "

            str = str & "DEALLOCATE cursorName"
            str = str & "  update TEMPSTOCKadjDETAIL set  convvalue=INVENTORY_TRANSCONVERSION.CONVVALUE from TEMPSTOCKadjDETAIL inner join INVENTORY_TRANSCONVERSION on INVENTORY_TRANSCONVERSION.BASEUOM=TEMPSTOCKadjDETAIL.TUOM"
            str = str & "  and INVENTORY_TRANSCONVERSION.TRANSUOM=TEMPSTOCKadjDETAIL.uom"



            str = str & "  UPDATE TEMPSTOCKadjDETAIL SET CATEGORYCODE=I.CATEGORY ,BATCHPROCESS=I.BATCHPROCESS  FROM INV_InventoryItemMaster I INNER JOIN TEMPSTOCKadjDETAIL T"
            str = str & "  ON I.itemcode=T.ITEMCODE "
            str = str & "  UPDATE TEMPSTOCKadjDETAIL SET RATEFLAG=I.RATEFLAG FROM TEMPSTOCKadjDETAIL T INNER JOIN INVENTORYCATEGORYMASTER I"
            str = str & "  ON T.CATEGORYCODE=I.CATEGORYCODE"

            str = str & "  UPDATE TEMPSTOCKadjDETAIL SET rate=WEIGHTEDRATE WHERE RATEFLAG='W'"
            str = str & "  UPDATE TEMPSTOCKadjDETAIL SET rate=BATCHRATE WHERE RATEFLAG='P'"
            str = str & "  UPDATE TEMPSTOCKadjDETAIL SET rate=R.BATCHRATE FROM TEMPSTOCKadjDETAIL T INNER JOIN vw_ratelist R ON"
            str = str & "  R.batchno = t.BATCHNO And r.Itemcode = t.Itemcode"

            str = str & "  UPDATE TEMPSTOCKadjDETAIL SET adjustedstock=adjustedstock/CONVVALUE WHERE ISNULL(CONVVALUE,0)<>0"
            str = str & "  update TEMPSTOCKadjDETAIL set AMOUNT=rate*adjustedstock"

            str = str & "          End "
            gconnection.dataOperation1(6, str, "cp_stockadjustment")

        End If

        If gShortname = "BRC" Then
            str = " ALTER VIEW [dbo].[VW_POBILL] AS      SELECT      dbo.PO_HDR.pono, dbo.PO_HDR.doctype, dbo.PO_HDR.storecode, dbo.PO_HDR.podate, dbo.PO_HDR.poquotno, dbo.PO_HDR.povendorcode,   dbo.PO_HDR.podepartment, dbo.PO_HDR.poquotdate as POtYpE, dbo.PO_HDR.povalidfrom, dbo.PO_HDR.povalidupto, dbo.PO_ITEMDETAILS.ITEMCODE, dbo.PO_ITEMDETAILS.ITEMNAME, dbo.PO_ITEMDETAILS.UOM, dbo.PO_ITEMDETAILS.QUANTITY, dbo.PO_ITEMDETAILS.baseamount,  dbo.PO_ITEMDETAILS.Rate,    dbo.PO_ITEMDETAILS.discper, dbo.PO_ITEMDETAILS.taxper, dbo.PO_ITEMDETAILS.discamt,  dbo.PO_ITEMDETAILS.vatamt, dbo.PO_ITEMDETAILS.TOTALamount,    dbo.PO_ITEMDETAILS.taxcode,dbo.PO_ITEMDETAILS.amountafterdiscount,  dbo.PO_ITEMDETAILS.othchg, dbo.PO_HDR.versionno, dbo.PO_HDR.POOVERALLDISC,dbo.PO_HDR.pobalance, dbo.PO_HDR.poadvance,   dbo.PO_HDR.pototaldiscount, dbo.PO_HDR.pototaltax, dbo.PO_HDR.pototalvat, dbo.PO_HDR.povalue,    dbo.PO_HDR.pootherchgplus,   dbo.PO_HDR.pootherchgmin, dbo.PO_HDR.POtransport, dbo.PO_HDR.postatus,iv.vendorNAME AS vendorNAME, ISNULL(IV.contactperson,'') AS contactperson,ISNULL(IV.address1,'') AS address1,ISNULL(IV.address2,'') AS address2,  ISNULL(IV.city,'') AS city,ISNULL(IV.state,'') AS state,ISNULL(IV.PIN,'') AS pIN , ISNULL(IV.phoneno,'') AS PhONENO, ISNULL(GSTINNO,'') AS GSTINNO ,ISNULL(VENDORTYPE,'') AS VENDORTYPE , isnull(dbo.PO_HDR.podelivery,'') as podelivery,dbo.PO_HDR.poremarks as remarks,isnull((SELECT ISNULL(PAYMENTTERMDESC,'') AS PAYMENTTERMDESC FROM PO_PAYMENTTERMS where PAYMENTTERMCODE=poterms),'') as poterms,ISNULL(CGSTAmt,0) AS CGSTAmt,ISNULL(SGSTAmt,0) AS SGSTAmt,ISNULL(IGSTAmt,0 )AS IGSTAmt , ISNULL(GSTAmt,0 )AS GSTAmt ,ISNULL(I.HSNNO,'') AS HSNNO,ISNULL(I.TAXTYPE,'') AS  TAXTYPE  ,ISNULL(dbo.PO_ITEMDETAILS .SPLCESS,0) AS SPLCESS  FROM         dbo.PO_HDR  INNER JOIN dbo.PO_ITEMDETAILS ON dbo.PO_HDR.pono = dbo.PO_ITEMDETAILS.pono   INNER JOIN SUPPLIERDetails iv on PO_HDR.povendorcode=iv.vendorcode  INNER JOIN INV_InventoryItemMaster I ON I.itemcode=dbo.PO_ITEMDETAILS.Itemcode  WHERE ISNULL(postatus,'') <>'AMENDED'"
            gconnection.dataOperation(6, str, "AddC")

        End If


    End Sub


    Public Sub POLINK()
        Dim sqlstring As String
        sqlstring = "SELECT ISNULL(POFLAG,'') AS POFLAG,ISNULL(INDENTISSFLAG,'N') AS INDENTNO ,ISNULL(ACCPOSTFLAG,'N') AS ACCPOSTFLAG,isnull(Dirissue,'N') as Dirissue  FROM INV_LINKSETUP "
        gconnection.getDataSet(sqlstring, "INV_LINKSETUP")
        If gdataset.Tables("INV_LINKSETUP").Rows.Count > 0 Then
            gpocode = Trim(UCase(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("POFLAG")))

            GINDENTNO = Trim(UCase(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("INDENTNO")))
            GACCPOST = Trim(UCase(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("ACCPOSTFLAG")))
            gdirissue = Trim(UCase(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("Dirissue")))
        Else
            gpocode = ""
            GINDENTNO = "N"
            GACCPOST = "N"
            gdirissue = "N"
        End If
    End Sub
    Public Sub ExpiryCheck()
        Dim sqlstring As String
        sqlstring = "SELECT ISNULL(batchnoreq,'N') AS batchnoreq ,ISNULL(expiryreq,'N') AS expiryreq,isnull(shelvingreq,'N') as shelvingreq  FROM INV_LINKSETUP "
        gconnection.getDataSet(sqlstring, "EXPIRYCHECK")
        If gdataset.Tables("EXPIRYCHECK").Rows.Count > 0 Then
            GBATCHNO = Trim(UCase(gdataset.Tables("EXPIRYCHECK").Rows(0).Item("batchnoreq")))
            GEXPIRY = Trim(UCase(gdataset.Tables("EXPIRYCHECK").Rows(0).Item("expiryreq")))
            GSHELVING = Trim(UCase(gdataset.Tables("EXPIRYCHECK").Rows(0).Item("shelvingreq")))
        Else
            GBATCHNO = "N"
            GEXPIRY = "N"
            GSHELVING = "N"
        End If
    End Sub
    Public Sub INVSETUP()
        Dim sqlstring As String
        sqlstring = "SELECT ISNULL(RSILINK,'N') AS RSILINK,ISNULL(HYDLINK,'N') AS HYDLINK,ISNULL(CATHOLIC,'N') AS CATHOLIC ,ISNULL(positemstorelink,'N') AS positemstorelink,ISNULL(salerate,'N') AS salerate,ISNULL(vendorlink,'N') AS vendorlink,ISNULL(AVGRATE,'N') AS AVGRATE,ISNULL(GRNGLCODE,'N') AS GRNGLCODE  FROM INVSETUP "
        gconnection.getDataSet(sqlstring, "INVSETUP")
        'gRSILINK, gHYDLINK, gCATHOLIC, gpositemstorelink, gsalerate, gvendorlink
        If gdataset.Tables("INVSETUP").Rows.Count > 0 Then
            gRSILINK = Trim(UCase(gdataset.Tables("INVSETUP").Rows(0).Item("RSILINK")))
            gHYDLINK = Trim(UCase(gdataset.Tables("INVSETUP").Rows(0).Item("HYDLINK")))
            gCATHOLIC = Trim(UCase(gdataset.Tables("INVSETUP").Rows(0).Item("CATHOLIC")))
            gpositemstorelink = Trim(UCase(gdataset.Tables("INVSETUP").Rows(0).Item("positemstorelink")))
            gsalerate = Trim(UCase(gdataset.Tables("INVSETUP").Rows(0).Item("salerate")))
            gvendorlink = Trim(UCase(gdataset.Tables("INVSETUP").Rows(0).Item("vendorlink")))
            gavgrate = Trim(UCase(gdataset.Tables("INVSETUP").Rows(0).Item("avgrate")))
            gGRNGLCODE = Trim(UCase(gdataset.Tables("INVSETUP").Rows(0).Item("GRNGLCODE")))
        Else
            gRSILINK = "N"
            gHYDLINK = "N"
            gCATHOLIC = "N"
            gpositemstorelink = "N"
            gsalerate = "N"
            gvendorlink = "N"
            gavgrate = "N"
            gGRNGLCODE = "N"
        End If
    End Sub

    Public Sub Clearfiles()
        AppPath = Application.StartupPath
        Shell("CLEAR.BAT", AppWinStyle.Hide)
    End Sub
    Private Sub Activateuseradmin()
        Dim sqlstring As String
        Try
            Me.Text = "INVENTORY" & Space(20) & Trim(gCompanyname) & Space(50) & "[" & gFinancalyearStart & "-" & gFinancialyearEnd & " ]" & Space(30) & "User Name:" & gUsername
            'e.Text = Trim(gCompanyname) & "  " & gFinancalyearStart & "-" & gFinancialyearEnd & " ] Last Updated " & Format(dtCreationDate, "dd/MMM/yyyy") & " Size " & CStr(FileSize) & "User Name:" & gUsername
            AppPath = Application.StartupPath
            GetAccountcode()
            'mdi.ActiveForm.BackgroundImage=
            MDIParentobj = Me
            Dim totmenu As Integer
            totmenu = 0
            Call menublock()
            Dim i, j, k, ckhmn, ckhmn1 As Integer
            For i = 0 To MainMenu1.MenuItems.Count - 2
                ckhmn1 = MainMenu1.MenuItems(i).MenuItems.Count()
                If ckhmn1 <> 0 Then
                    For j = 0 To MainMenu1.MenuItems(i).MenuItems.Count() - 1
                        ckhmn = MainMenu1.MenuItems(i).MenuItems(j).MenuItems.Count()
                        If ckhmn <> 0 Then
                            For k = 0 To MainMenu1.MenuItems(i).MenuItems(j).MenuItems.Count() - 1
                                totmenu = totmenu + 1
                            Next
                        Else
                            totmenu = totmenu + 1
                        End If
                    Next
                Else
                    totmenu = totmenu + 1
                End If
            Next
            gconnection.getDataSet("select count(*) from modulemaster Where PackageName='INVENTORY'", "chk")
            If gdataset.Tables("chk").Rows.Count <> totmenu Then
                'gconnection.ExcuteStoreProcedure("delete from modulemaster Where PackageName='INVENTORY'")

                sqlstring = "delete from modulemaster Where PackageName='INVENTORY'"
                gconnection.getDataSet(sqlstring, "modulemaster")
                Call checkmenulist()
            End If
            If gUserCategory = "S" Or gUserCategory = "A" Then
                Call menuclear()
            Else
                Call relemenu()
            End If
        Catch ex As Exception
            MsgBox("Error Found While Loading! Bcoz " & ex.Message.ToString, MsgBoxStyle.Critical, "Error!")
        End Try
    End Sub
    Sub menuclear()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        vmain = MainMenu1.MenuItems.Count
        For i = 0 To vmain - 2
            vsmod = MainMenu1.MenuItems(i).MenuItems.Count
            If vsmod <> 0 Then
                For j = 0 To vsmod - 1
                    vssmod = MainMenu1.MenuItems(i).MenuItems(j).MenuItems.Count
                    If vssmod <> 0 Then
                        For k = 0 To vssmod - 1
                            MainMenu1.MenuItems(i).MenuItems(j).MenuItems(k).Enabled = True
                        Next
                    Else
                        MainMenu1.MenuItems(i).MenuItems(j).Enabled = True
                    End If
                Next
            Else
                MainMenu1.MenuItems(i).Enabled = True
            End If
        Next
    End Sub
    Sub menublock()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        vmain = MainMenu1.MenuItems.Count
        For i = 0 To vmain - 2
            vsmod = MainMenu1.MenuItems(i).MenuItems.Count
            If vsmod <> 0 Then
                For j = 0 To vsmod - 1
                    vssmod = MainMenu1.MenuItems(i).MenuItems(j).MenuItems.Count
                    If vssmod <> 0 Then
                        For k = 0 To vssmod - 1
                            MainMenu1.MenuItems(i).MenuItems(j).MenuItems(k).Enabled = False
                        Next
                    Else
                        MainMenu1.MenuItems(i).MenuItems(j).Enabled = False
                    End If
                Next
            Else
                MainMenu1.MenuItems(i).Enabled = False
            End If
        Next
    End Sub
    Sub relemenu()

        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql As String
        Dim ds As New DataSet
        Dim chstr As String
        Dim a As Integer
        Dim b As Integer
        Dim c As Integer
        gconnection.getDataSet("SELECT * FROM USERADMIN WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='INVENTORY'", "user")
        If gdataset.Tables("user").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("user").Rows.Count - 1
                With gdataset.Tables("user").Rows(i)
                    If Trim(.Item("mainmoduleid") & "") <> "" And Trim(.Item("submoduleid") & "") <> "" And Trim(.Item("ssubmoduleid") & "") <> "" Then
                        a = .Item("mainmoduleid")
                        b = Val(.Item("submoduleid"))
                        c = Val(.Item("ssubmoduleid"))
                        Menu.MenuItems(a).MenuItems(b).MenuItems(c).Enabled = True
                        chstr = abcdMINUS(.Item("rights"))
                    ElseIf Trim(.Item("mainmoduleid") & "") <> "" And Trim(.Item("submoduleid") & "") <> "" Then
                        a = gdataset.Tables("user").Rows(i).Item("mainmoduleid")
                        b = Val(gdataset.Tables("user").Rows(i).Item("submoduleid"))
                        Menu.MenuItems(a).MenuItems(b).Enabled = True
                        chstr = abcdMINUS(.Item("rights"))
                    ElseIf Trim(.Item("mainmoduleid") & "") <> "" Then
                        Menu.MenuItems((.Item("mainmoduleid"))).Enabled = True
                        chstr = abcdMINUS(.Item("rights"))
                    End If
                End With
            Next
        End If
    End Sub
    Sub checkmenulist()
        Dim i, j, k, x As Integer
        Dim vsql() As String
        Dim vmain, vsmod, vssmod As Long
        x = 0
        ReDim vsql(x)
        vmain = MainMenu1.MenuItems.Count
        If vmain <> 0 Then
            For i = 0 To vmain - 2
                vsmod = MainMenu1.MenuItems(i).MenuItems.Count
                If vsmod <> 0 Then
                    For j = 0 To vsmod - 1
                        vssmod = MainMenu1.MenuItems(i).MenuItems(j).MenuItems.Count
                        If vssmod <> 0 Then
                            For k = 0 To vssmod - 1
                                vsql(vsql.Length - 1) = "insert into Modulemaster(Mainmoduleid,MainModulename,SubModuleid,SubModulename,SsubModuleid,SsubModuleName,PackageName) values "
                                vsql(vsql.Length - 1) = vsql(vsql.Length - 1) & " ('" & i & "','" & Trim(MainMenu1.MenuItems(i).Text.Replace("&", "") & "") & "',"
                                vsql(vsql.Length - 1) = vsql(vsql.Length - 1) & "'" & j & "','" & Trim(MainMenu1.MenuItems(i).MenuItems(j).Text.Replace("&", "") & "") & "',"
                                vsql(vsql.Length - 1) = vsql(vsql.Length - 1) & "'" & k & "','" & Trim(MainMenu1.MenuItems(i).MenuItems(j).MenuItems(k).Text.Replace("&", "") & "") & "','INVENTORY')"
                                ReDim Preserve vsql(vsql.Length)
                            Next
                        Else
                            vsql(vsql.Length - 1) = "insert into Modulemaster(Mainmoduleid,MainModulename,SubModuleid,SubModulename,SsubModuleid,SsubModuleName,PackageName ) values "
                            vsql(vsql.Length - 1) = vsql(vsql.Length - 1) & " ('" & i & "','" & Trim(MainMenu1.MenuItems(i).Text.Replace("&", "") & "") & "',"
                            vsql(vsql.Length - 1) = vsql(vsql.Length - 1) & "'" & j & "','" & Trim(MainMenu1.MenuItems(i).MenuItems(j).Text.Replace("&", "") & "") & "',"
                            vsql(vsql.Length - 1) = vsql(vsql.Length - 1) & "'','','INVENTORY')"
                            ReDim Preserve vsql(vsql.Length)
                        End If
                    Next
                Else
                    vsql(vsql.Length - 1) = "insert into Modulemaster(Mainmoduleid,MainModulename,SubModuleid,SubModulename,SsubModuleid,SsubModuleName,PackageName) values "
                    vsql(vsql.Length - 1) = vsql(vsql.Length - 1) & " ('" & i & "','" & Trim(MainMenu1.MenuItems(i).Text.Replace("&", "") & "") & "',"
                    vsql(vsql.Length - 1) = vsql(vsql.Length - 1) & "'','',"
                    vsql(vsql.Length - 1) = vsql(vsql.Length - 1) & "'','','INVENTORY')"
                    ReDim Preserve vsql(vsql.Length)
                End If
            Next
            ReDim Preserve vsql(vsql.Length - 2)
            gconnection.MoreTrans_womsg(vsql)
        End If
    End Sub
    Private Sub GetAccountcode()
        Dim sqlstring As String
        sqlstring = "SELECT ISNULL(SDRSCODE,'') AS SDRSCODE,ISNULL(SCRSCODE,'') AS SCRSCODE FROM ACCOUNTSSETUP "
        gconnection.getDataSet(sqlstring, "ACCOUNTSSETUP")
        If gdataset.Tables("ACCOUNTSSETUP").Rows.Count > 0 Then
            gDebitors = Trim(UCase(gdataset.Tables("ACCOUNTSSETUP").Rows(0).Item("SDRSCODE")))
            gCreditors = Trim(UCase(gdataset.Tables("ACCOUNTSSETUP").Rows(0).Item("SCRSCODE")))
        Else
            gDebitors = ""
            gCreditors = "SCRS"
        End If
        gInventoryVersion = "N"
    End Sub
    Private Sub GetUserAccess()
        Dim sqlstring As String
        sqlstring = "select isnull(useraccess,'C') as useraccess FROM INV_LINKSETUP "
        gconnection.getDataSet(sqlstring, "useraccess")
        If gdataset.Tables("useraccess").Rows.Count > 0 Then
            Guseraccess = Trim(UCase(gdataset.Tables("useraccess").Rows(0).Item("useraccess")))
        Else
            Guseraccess = "C"
        End If
    End Sub
    Private Sub GetAccountTaggingType()
        Dim sqlstring As String
        sqlstring = "select isnull(accounttaggingtype,'IW') as accounttaggingtype FROM INV_LINKSETUP "
        gconnection.getDataSet(sqlstring, "useraccess")
        If gdataset.Tables("useraccess").Rows.Count > 0 Then
            gAcTaggingType = Trim(UCase(gdataset.Tables("useraccess").Rows(0).Item("accounttaggingtype")))
        Else
            gAcTaggingType = "IW"
        End If
    End Sub
    Private Sub GetAccountpOSINGType()
        Dim sqlstring As String
        sqlstring = "select isnull(accountpostingWise,'STORE') as accountpostingWise,ISNULL(CONSUMPTIONALLOW,'SUB STORE') AS CONSUMPTIONALLOW FROM INV_LINKSETUP "
        gconnection.getDataSet(sqlstring, "accountpostingWise")
        If gdataset.Tables("accountpostingWise").Rows.Count > 0 Then
            gAcPostingWise = Trim(UCase(gdataset.Tables("accountpostingWise").Rows(0).Item("accountpostingWise")))
            ' gConsumpTionAllow = Trim(UCase(gdataset.Tables("accountpostingWise").Rows(0).Item("CONSUMPTIONALLOW")))
            If Trim(UCase(gdataset.Tables("accountpostingWise").Rows(0).Item("CONSUMPTIONALLOW"))) = "BOTH" Then
                gConsumpTionAllow = "B"
            ElseIf Trim(UCase(gdataset.Tables("accountpostingWise").Rows(0).Item("CONSUMPTIONALLOW"))) = "MAIN STORE" Then
                gConsumpTionAllow = "M"
            Else
                gConsumpTionAllow = "S"
                MenuItem32.Visible = True

            End If
        Else
            MenuItem32.Visible = True


            gAcPostingWise = "STORE"
            gConsumpTionAllow = "S"
        End If

        Dim sql As String = "Select count(*) as cn from Accountssetup where isnull(costcenter,'')<>'N'"
        gconnection.getDataSet(sql, "Accountssetup")
        If gdataset.Tables("Accountssetup").Rows(0).Item("cn") = 1 Then
            gCostcenter = True
            '  lockssgrid()
        Else
            gCostcenter = False

        End If

    End Sub

    'Public Sub compname()

    '    Dim sqlstring As String
    '    sqlstring = " select isnull(compname,'')as compname from possetup"

    '    gconnection.getDataSet(sqlstring, "possetup")
    '    If gdataset.Tables("possetup").Rows.Count > 0 Then
    '        gcompname = gdataset.Tables("possetup").Rows(0).Item("compname")
    '    End If

    'End Sub
    Public Sub FillCompanyinfo()
        Dim sqlstring As String
        Try
            If Trim(gDatabase) <> "" Then
                sqlstring = " SELECT ISNULL(CompanyName,'') AS CompanyName,ISNULL(Fromdate,getdate()) AS Fromdate,ISNULL(Todate,getdate()) AS Todate,ISNULL(Add1,'') AS Add1,ISNULL(Add2,'') AS Add2,"
                sqlstring = sqlstring & " ISNULL(City,'') AS City,ISNULL(State,'') AS State,ISNULL(Pincode,'') AS Pincode,ISNULL(Datafile,'') AS Datafile,isnull(shortname,'') as shortname,isnull(PHONE1,'') as PHONE1,isnull(PHONE2,'') as PHONE2,isnull(FAX,'') as FAX,isnull(EMAIL,'') as EMAIL,ISNULL(INDATE,'01 JUL 2017') AS INDATE,ISNULL(GSTINNO,'') AS GSTINNO,ISNULL(TINNO,'') AS TINNO,ISNULL(SERVICETAX,'') AS SERVICETAX,isnull(HISTORY,'') as HISTORY FROM ClubMaster WHERE DATAFILE = '" & Trim(gDatabase) & "'"
            Else
                sqlstring = " SELECT ISNULL(CompanyName,'') AS CompanyName,ISNULL(Fromdate,getdate()) AS Fromdate,ISNULL(Todate,getdate()) AS Todate,ISNULL(Add1,'') AS Add1,ISNULL(Add2,'') AS Add2,"   'PHONE1	PHONE2	FAX	EMAIL

                sqlstring = sqlstring & " ISNULL(City,'') AS City,ISNULL(State,'') AS State,ISNULL(Pincode,'') AS Pincode,ISNULL(Datafile,'') AS Datafile,isnull(shortname,'') as shortname,isnull(PHONE1,'') as PHONE1,isnull(PHONE2,'') as PHONE2,isnull(FAX,'') as FAX,isnull(EMAIL,'') as EMAIL,ISNULL(INDATE,'01 JUL 2017') AS INDATE,ISNULL(GSTINNO,'') AS GSTINNO,ISNULL(TINNO,'') AS TINNO,ISNULL(SERVICETAX,'') AS SERVICETAX,isnull(HISTORY,'') as HISTORY FROM ClubMaster "
            End If
            gconnection.getCompanyinfo(sqlstring, "ClubMaster")
            If gdataset.Tables("ClubMaster").Rows.Count > 0 Then
                MyCompanyName = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("CompanyName")))
                Address1 = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Add1")))
                Address2 = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Add2")))
                gCompanyAddress(0) = Address1
                gCompanyAddress(1) = Address2
                gCity = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("City")))
                gState = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("State")))
                gPincode = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Pincode")))
                'PHONE1	PHONE2	FAX	EMAIL
                gPhone1 = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("PHONE1")))
                gPhone2 = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("PHONE2")))
                gFax = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("FAX")))
                gEMail = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("EMAIL")))
                TINNO = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("TINNO")))
                SERVICETAX = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("SERVICETAX")))
                gGSTINNO = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("GSTINNO")))
                History = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("HISTORY")))

                gDatabase = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Datafile")))

                GSTSTARTdATE = Trim(CDate(gdataset.Tables("ClubMaster").Rows(0).Item("INDATE")))

                gFinancialyearStart = Trim(CDate(gdataset.Tables("ClubMaster").Rows(0).Item("Fromdate")))
                gFinancialyearEnding = Trim(CDate(gdataset.Tables("ClubMaster").Rows(0).Item("Todate")))
                gstartingdate = Trim(CDate(gdataset.Tables("ClubMaster").Rows(0).Item("Fromdate")))
                gFinancalyearStart = Year(gFinancialyearStart)
                gFinancialyearEnd = Year(gFinancialyearEnding)
                gShortname = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("shortname")))
                'gcompname = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("shortname")))
                Me.Text = MyCompanyName & " [" & "INVENTORY" & " ]"
                If Mid(MyCompanyName, 1, 3) = "HIN" Then
                    PrintTaxheading1 = "C.F"
                    PrintTaxheading2 = "CHARGES"
                Else
                    PrintTaxheading1 = "SALES"
                    PrintTaxheading2 = "TAX"
                End If
            Else
                MessageBox.Show("Plz. Contact to your Computer Administrator ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub submnu_HorizontalTile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submnu_HorizontalTile.Click
        GmoduleName = "Horizontal Tile"
        Me.LayoutMdi(MdiLayout.TileHorizontal)
        submnu_HorizontalTile.Checked = True
        submnu_VerticalTile.Checked = False
        submnu_Cascade.Checked = False
    End Sub

    Private Sub submnu_VerticalTile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submnu_VerticalTile.Click
        GmoduleName = "Vertical Tile"
        Me.LayoutMdi(MdiLayout.TileVertical)
        submnu_HorizontalTile.Checked = False
        submnu_VerticalTile.Checked = True
        submnu_Cascade.Checked = False
    End Sub

    Private Sub submnu_Cascade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submnu_Cascade.Click
        GmoduleName = "Cascade"
        Me.LayoutMdi(MdiLayout.Cascade)
        submnu_HorizontalTile.Checked = False
        submnu_VerticalTile.Checked = False
        submnu_Cascade.Checked = True
    End Sub

    Private Sub submnu_Calculator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submnu_Calculator.Click
        GmoduleName = "Calculator"
        Shell(Environment.SystemDirectory & "\calc.exe", AppWinStyle.NormalFocus)
        submnu_Calculator.Checked = True
        submnu_Notepad.Checked = False
    End Sub

    Private Sub submnu_Notepad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submnu_Notepad.Click
        GmoduleName = "Note Pad"
        Shell(Environment.SystemDirectory & "\notepad.exe", AppWinStyle.NormalFocus)
        submnu_Calculator.Checked = False
        submnu_Notepad.Checked = True
    End Sub

    Private Sub submnu_GroupMaster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submnu_GroupMaster.Click
        Dim objGroupmaster As New Group_Master
        GmoduleName = "Group Master"
        If GroupMasterbool = False And submnu_GroupMaster.Checked = True Then
            ' objGroupmaster.FormBorderStyle = FormBorderStyle.FixedDialog
            objGroupmaster.MdiParent = Me
            objGroupmaster.Show()
            submnu_GroupMaster.Checked = True
        End If
        If submnu_GroupMaster.Checked = True Then
            Exit Sub
        End If
        ' objGroupmaster.FormBorderStyle = FormBorderStyle.FixedDialog
        objGroupmaster.MdiParent = Me
        objGroupmaster.Show()
        submnu_GroupMaster.Checked = True
    End Sub
    Private Sub submnu_SubGroupMaster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submnu_SubGroupMaster.Click
        Dim objSubGroupmaster As New Sub_Group_Master
        GmoduleName = "Sub Group Master"
        If SubGroupMasterbool = False And submnu_SubGroupMaster.Checked = True Then
            ' objSubGroupmaster.FormBorderStyle = FormBorderStyle.FixedDialog
            objSubGroupmaster.MdiParent = Me
            objSubGroupmaster.Show()
            submnu_SubGroupMaster.Checked = True
        End If
        If submnu_SubGroupMaster.Checked = True Then
            Exit Sub
        End If
        ' objSubGroupmaster.FormBorderStyle = FormBorderStyle.FixedDialog
        objSubGroupmaster.MdiParent = Me
        objSubGroupmaster.Show()
        submnu_SubGroupMaster.Checked = True
    End Sub
    Private Sub submnu_StoreMaster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objStoreMaster As New Store_Master
        GmoduleName = "Store Master"
        'If StoreMasterbool = False And submnu_StoreMaster.Checked = True Then
        '    objStoreMaster.FormBorderStyle = FormBorderStyle.FixedDialog
        '    objStoreMaster.MdiParent = Me
        '    objStoreMaster.Show()
        '    submnu_StoreMaster.Checked = True
        'End If
        'If submnu_StoreMaster.Checked = True Then
        '    Exit Sub
        'End If
        'objStoreMaster.FormBorderStyle = FormBorderStyle.FixedDialog
        objStoreMaster.MdiParent = Me
        objStoreMaster.Show()
        ' submnu_StoreMaster.Checked = True
    End Sub
    Private Sub submnu_ItemMaster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submnu_ItemMaster.Click
        Dim objItemMaster As New Frm_InventoryItemmastervb
        GmoduleName = "Item Master"
        If ItemMasterbool = False And submnu_ItemMaster.Checked = True Then
            ' objItemMaster.FormBorderStyle = FormBorderStyle.FixedDialog
            objItemMaster.MdiParent = Me
            objItemMaster.Show()
            submnu_ItemMaster.Checked = True
        End If
        If submnu_ItemMaster.Checked = True Then
            Exit Sub
        End If
        ' objItemMaster.FormBorderStyle = FormBorderStyle.FixedDialog
        objItemMaster.MdiParent = Me



        'Call objItemMaster.Resize_Form()
        objItemMaster.Show()
        submnu_ItemMaster.Checked = True

    End Sub

    Private Sub submnu_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Application.Exit()
    End Sub
    Private Sub submnu_GRNCumPurchaseBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submnu_GRNCumPurchaseBill.Click
        If (UCase(gState) = "TAMILNADU") Then
            Dim objGRNCumPurchaseBill As New Frm_GRNTAMIL
            GmoduleName = "GRN Cum Purchase Bill"
            '   If GRNCumPurchaseBillTransbool = False And submnu_GRNCumPurchaseBill.Checked = True Then
            '  objGRNCumPurchaseBill.FormBorderStyle = FormBorderStyle.FixedDialog
            objGRNCumPurchaseBill.MdiParent = Me
            objGRNCumPurchaseBill.Show()
            submnu_GRNCumPurchaseBill.Checked = True
        Else

            Dim objGRNCumPurchaseBill As New Frm_GRN
            GmoduleName = "GRN Cum Purchase Bill"
            '   If GRNCumPurchaseBillTransbool = False And submnu_GRNCumPurchaseBill.Checked = True Then
            ' objGRNCumPurchaseBill.FormBorderStyle = FormBorderStyle.FixedDialog
            objGRNCumPurchaseBill.MdiParent = Me
            objGRNCumPurchaseBill.Show()
            submnu_GRNCumPurchaseBill.Checked = True

        End If

        '   End If

    End Sub
    Private Sub submnu_StockTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submnu_StockTransfer.Click
        Dim objStockTransfer As New Frm_StockTransfer
        GmoduleName = "Stock Transfer/Return"
        If StockTransferTransbool = False And submnu_StockTransfer.Checked = True Then
            '  objStockTransfer.FormBorderStyle = FormBorderStyle.FixedDialog
            objStockTransfer.MdiParent = Me
            objStockTransfer.Show()
            submnu_StockTransfer.Checked = True
        End If
        If submnu_StockTransfer.Checked = True Then
            Exit Sub
        End If
        ' objStockTransfer.FormBorderStyle = FormBorderStyle.FixedDialog
        objStockTransfer.MdiParent = Me
        objStockTransfer.Show()
        submnu_StockTransfer.Checked = True
    End Sub
    Private Sub submnu_StockDamage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submnu_StockDamage.Click
        Dim objStockDamage As New FRM_STOCKDMG
        GmoduleName = "Stock Damage"
        If StockDamageTransbool = False And submnu_StockDamage.Checked = True Then
            'objStockDamage.FormBorderStyle = FormBorderStyle.FixedDialog
            objStockDamage.MdiParent = Me
            objStockDamage.Show()
            submnu_StockDamage.Checked = True
        End If
        If submnu_StockDamage.Checked = True Then
            Exit Sub
        End If
        '  objStockDamage.FormBorderStyle = FormBorderStyle.FixedDialog
        objStockDamage.MdiParent = Me
        objStockDamage.Show()
        submnu_StockDamage.Checked = True
    End Sub
    Private Sub mnu_Masters_Select(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnu_Masters.Select
        If GroupMasterbool = False Then
            submnu_GroupMaster.Checked = False
        End If
        If SubGroupMasterbool = False Then
            submnu_SubGroupMaster.Checked = False
        End If
        If StoreMasterbool = False Then
            'submnu_StoreMaster.Checked = False
        End If
        If ItemMasterbool = False Then
            submnu_ItemMaster.Checked = False
        End If
        If BillingMaterialbool = False Then
            'submnu_Billmaterial.Checked = False
        End If
    End Sub

    Private Sub mnu_Transaction_Select(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnu_Transaction.Select
        If GRNCumPurchaseBillTransbool = False Then
            submnu_GRNCumPurchaseBill.Checked = False
        End If
        If StockIssueTransbool = False Then
            'submnu_StockIssue.Checked = False
        End If
        If CockTailRatioTransbool = False Then
            'submnu_Billmaterial.Checked = False
        End If
        If StockTransferTransbool = False Then
            submnu_StockTransfer.Checked = False
        End If
        If StockAdjustmentTransbool = False Then
            submnu_StockAdjustment.Checked = False
        End If
        If StockDamageTransbool = False Then
            submnu_StockDamage.Checked = False
        End If
        If CockTailRatioTransbool = False Then
            'submnu_Billofmaterial.Checked = False
        End If
    End Sub

    Private Sub submnu_IssueRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submnu_IssueRegister.Click
        GmoduleName = "Issue By Issue No"
        Dim objIssueregister As New InvIssueRegister
        objIssueregister.MdiParent = Me
        objIssueregister.Show()
    End Sub

    Private Sub submnu_IssueDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submnu_IssueDetails.Click
        GmoduleName = "Issue Details"
        Dim objIssuedetails As New Itemwise_Issue_details
        objIssuedetails.MdiParent = Me
        objIssuedetails.Show()
    End Sub

    Private Sub submnu_RatioChart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "Ratio Chart"
        Dim objRatiochart As New frmCocktailratiochart
        objRatiochart.MdiParent = Me
        objRatiochart.Show()
    End Sub

    Private Sub submnu_StockLedger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submnu_StockLedger.Click
        GmoduleName = "Stock Ledger"
        Dim objStockledgermainstock As New FrmStockLedger
        objStockledgermainstock.MdiParent = Me
        objStockledgermainstock.Show()
    End Sub

    Private Sub submnu_StockOfBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "Stock Of Bar"
        Dim objBarstockposition As New frmBarstockposition
        objBarstockposition.MdiParent = Me
        objBarstockposition.Show()
    End Sub

    Private Sub submnu_StockSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submnu_StockSummary.Click
        GmoduleName = "Issue Summary"
        Dim objmainstockposition As New frmmainstockposition
        objmainstockposition.MdiParent = Me
        objmainstockposition.Show()
    End Sub
    Public Sub GetServer()
        Dim ServerConn As New OleDb.OleDbConnection
        Dim servercmd As New OleDb.OleDbDataAdapter
        Dim getserver As New DataSet
        Dim sql, ssql As String
        sql = "Provider=Microsoft.Jet.OLEDB.4.0;Data source="
        sql = sql & AppPath & "DBS_KEY.MDB"
        ServerConn.ConnectionString = sql
        Try
            ServerConn.Open()
            ssql = "SELECT SERVER,database FROM DBSKEY"
            servercmd = New OleDb.OleDbDataAdapter(ssql, ServerConn)
            servercmd.Fill(getserver)
            If getserver.Tables(0).Rows.Count > 0 Then
                gserver = getserver.Tables(0).Rows(0).Item(0)
                gDatabase = getserver.Tables(0).Rows(0).Item(1)
            Else
                MessageBox.Show("Failed to connect to data source")
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Failed to connect to data source")
            MsgBox(ex.Message)
        Finally
            ServerConn.Close()
        End Try
    End Sub

    Private Sub submnu_PurchaseRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submnu_PurchaseRegister.Click
        GmoduleName = "Purchase/Return  Register"
        Dim objpurchaseregister As New InvPurchaseregister
        objpurchaseregister.MdiParent = Me
        objpurchaseregister.Show()
    End Sub

    Private Sub submnu_MainStorePosition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "Main Store Position"
        Dim objMainstockposition As New frmmainstockposition
        objMainstockposition.MdiParent = Me
        objMainstockposition.Show()
    End Sub



    Private Sub submnu_Useradmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submnu_Useradmin.Click
        Dim Uadmin As New UserAdmin
        If Me.DuplicateForm(Uadmin.Name) = False Then
            submnu_Useradmin.Checked = True
            Uadmin.MdiParent = Me
            Uadmin.Show()
        End If
    End Sub
    Private Function DuplicateForm(ByVal FormName As String) As Boolean
        DuplicateForm = False
        Dim i As Integer
        If Me.MdiChildren Is Nothing Then
            Exit Function
        End If
        For i = 0 To Me.MdiChildren.Length - 1
            If Me.MdiChildren(i).Name = FormName Then
                GmoduleName = FormName
                DuplicateForm = True
                Exit Function
            End If
        Next i
    End Function

    Private Sub submnu_StockAdjustment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submnu_StockAdjustment.Click
        Dim objStockAdjustment As New Frm_Adjustment
        GmoduleName = "Stock Adjustment"
        If StockAdjustmentTransbool = False And submnu_StockAdjustment.Checked = True Then
            ' objStockAdjustment.FormBorderStyle = FormBorderStyle.FixedDialog
            objStockAdjustment.MdiParent = Me
            objStockAdjustment.Show()
            submnu_StockAdjustment.Checked = True
        End If
        If submnu_StockAdjustment.Checked = True Then
            Exit Sub
        End If
        ' objStockAdjustment.FormBorderStyle = FormBorderStyle.FixedDialog
        objStockAdjustment.MdiParent = Me
        objStockAdjustment.Show()
        submnu_StockAdjustment.Checked = True
    End Sub




    Private Sub mnu_Administrator_Select(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnu_Administrator.Select
        If UserAdminbool = False Then
            submnu_Useradmin.Checked = False
        End If
    End Sub

    Private Sub Submnu_Stocktransferregister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Submnu_Stocktransferregister.Click
        GmoduleName = "Stock Transfer Register"
        Dim objStocktransferreport As New InvStockTransfer
        objStocktransferreport.MdiParent = Me
        objStocktransferreport.Show()
    End Sub

    Private Sub Submnu_StockReturnregister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Submnu_StockReturnregister.Click
        GmoduleName = "Stock Return Register"
        Dim objStockreturnreport As New frmStockreturnreport
        objStockreturnreport.MdiParent = Me
        objStockreturnreport.Show()
    End Sub

    Private Sub Submnu_StockAdjustmentregister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Submnu_StockAdjustmentregister.Click
        GmoduleName = "Stock Adjustment Register"
        Dim objStockadjustmentreport As New InvAdjustmentReport
        objStockadjustmentreport.MdiParent = Me
        objStockadjustmentreport.Show()
    End Sub

    Private Sub Stock_Summary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Stock_Summary.Click
        GmoduleName = "Stock Summary"
        Dim objStockSummary As New InvStockSummary
        objStockSummary.MdiParent = Me
        objStockSummary.Show()
    End Sub


    Private Sub mnu_Exception_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "Exception Report"
        Dim objStockSummary As New frmStockSummary_excep
        objStockSummary.MdiParent = Me
        objStockSummary.Show()
    End Sub

    Private Sub MnuAccPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        GmoduleName = "Account Posting Inventory"
        Dim sqlvendor As String
        sqlvendor = "select isnull(RSILINK,'N') as RSILINK from invsetup"
        gconnection.getDataSet(sqlvendor, "invsetup")
        If gdataset.Tables("invsetup").Rows.Count > 0 Then
            RSILINK = gdataset.Tables("invsetup").Rows(0).Item("RSILINK")
        End If
        If RSILINK = "Y" Then
            Dim obj_accPost As New JournalRegister
            obj_accPost.MdiParent = Me
            obj_accPost.Show()
        Else
            Dim obj_accPost As New JournalRegister
            obj_accPost.MdiParent = Me
            obj_accPost.Show()
        End If
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click

        If MsgBox("Do you want to Quit from Inventory?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton1, Me.Text) = MsgBoxResult.Ok Then
            Application.Exit()
        End If
    End Sub
    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objStoreMaster As New sub_Sub_Group_Master
        GmoduleName = "Sub Sub Group Master"
        'If StoreMasterbool = False And submnu_StoreMaster.Checked = True Then
        '    objStoreMaster.FormBorderStyle = FormBorderStyle.FixedDialog
        '    objStoreMaster.MdiParent = Me
        '    objStoreMaster.Show()
        '    submnu_StoreMaster.Checked = True
        'End If
        'If submnu_StoreMaster.Checked = True Then
        '    Exit Sub
        'End If
        ' objStoreMaster.FormBorderStyle = FormBorderStyle.FixedDialog
        objStoreMaster.MdiParent = Me
        objStoreMaster.Show()
        '  submnu_StoreMaster.Checked = True
    End Sub
    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        Main_MDI.ActiveForm.Close()
        Dim cmp As New CompanyList1
        cmp.Show()
    End Sub
    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        If MsgBox("DO U Want to Update......", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, "Stock Update") = MsgBoxResult.Ok Then
            Me.Cursor = Cursors.WaitCursor
            Dim strsql As String
            strsql = "Exec CP_StockUpdate"
            gconnection.ExcuteStoreProcedure(strsql)
            Me.Cursor = Cursors.Default
        Else
            MsgBox("Update Cancelled Try Again......", MsgBoxStyle.OkOnly, "Stock Update")
        End If
    End Sub
    Private Sub MenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem5.Click
        GmoduleName = "Carry Forward"
        Dim objYrclsupdation As New YearEndConversion
        objYrclsupdation.MdiParent = Me
        objYrclsupdation.Show()
    End Sub
    Private Sub MenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem7.Click
        GmoduleName = "Sub Store Consumption - Manual Updation"
        Dim sqlvendor As String
        sqlvendor = "select isnull(RSILINK,'N') as RSILINK,isnull(positemstorelink,'N') as positemstorelink from invsetup"
        gconnection.getDataSet(sqlvendor, "invsetup")
        If gdataset.Tables("invsetup").Rows.Count > 0 Then
            RSILINK = gdataset.Tables("invsetup").Rows(0).Item("RSILINK")
            positemstorelink = gdataset.Tables("invsetup").Rows(0).Item("positemstorelink")
        End If
        If RSILINK = "Y" Then
            Dim objfrmMANUALUPDATION As New frmMANUALUPDATION_RSI
            objfrmMANUALUPDATION.MdiParent = Me
            objfrmMANUALUPDATION.Show()

        ElseIf positemstorelink = "Y" Then
            Dim objfrmMANUALUPDATION As New frmMANUALUPDATION_RSI
            objfrmMANUALUPDATION.MdiParent = Me
            objfrmMANUALUPDATION.Show()

        Else
            Dim objfrmMANUALUPDATION As New frmMANUALUPDATION
            objfrmMANUALUPDATION.MdiParent = Me
            objfrmMANUALUPDATION.Show()

        End If
    End Sub
    Private Sub MenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "VAT Input Tax Report"
        Dim objYrclsupdation As New InputTax
        objYrclsupdation.MdiParent = Me
        objYrclsupdation.Show()
    End Sub
    Private Sub MenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem9.Click
        GmoduleName = "Weighted Average"
        Dim objfrmMANUALUPDATION As New frmstockissuerate
        objfrmMANUALUPDATION.MdiParent = Me
        objfrmMANUALUPDATION.Show()
    End Sub
    Private Sub MenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "Purchase Register Recon"
        Dim objpurchaseregister As New frmPurchaseregister_Recon
        objpurchaseregister.MdiParent = Me
        objpurchaseregister.Show()
    End Sub

    Private Sub MenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "Stock Indent"
        Dim objindentfrm As New StockIndent
        objindentfrm.MdiParent = Me
        objindentfrm.Show()
    End Sub

    Private Sub MenuItem12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "Pending Register Report"
        Dim objPendingIndentReport As New PendingIndent
        objPendingIndentReport.MdiParent = Me
        objPendingIndentReport.Show()
    End Sub

    Private Sub MenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "Indentwise Report"
        Dim objIndentwiseReport As New Indent_Register
        objIndentwiseReport.MdiParent = Me
        objIndentwiseReport.Show()
    End Sub

    Private Sub Main_MDI_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Dim vAns As Double
        vAns = MsgBox("Do you want to Quit from Inventory?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton1, Me.Text)
        If vAns = MsgBoxResult.Ok Then
            Application.Exit()
        End If
    End Sub

    Private Sub MenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "Consolidated Summary"
        Dim objConsolidatedSummary As New frmConsolidatedLiquorSummary
        objConsolidatedSummary.MdiParent = Me
        objConsolidatedSummary.Show()
        'End If
    End Sub
    Private Sub MenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "Account Posting Party"
        Dim obj_accPost As New SJV_JournalRegister
        obj_accPost.MdiParent = Me
        obj_accPost.Show()
    End Sub

    Private Sub MenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "Account Posting Transit Quarters"
        Dim obj_accPostG As New GJV_JournalRegister
        obj_accPostG.MdiParent = Me
        obj_accPostG.Show()
    End Sub
    Private Sub MenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "Month Bill Posting"
        Dim obj_accPost As New MJV_JournalRegister
        obj_accPost.MdiParent = Me
        obj_accPost.Show()
    End Sub
    Private Sub MenuItem19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "ABC Report Analysis"
        Dim obj_accPost As New ABC_Summary
        obj_accPost.MdiParent = Me
        obj_accPost.Show()
    End Sub

    Private Sub MenuItem20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem20.Click
        GmoduleName = "Rol Summary"
        Dim obj_accPost As New frmrol_Summary
        obj_accPost.MdiParent = Me
        obj_accPost.Show()
    End Sub
    Private Sub MenuItem22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "Link Set Up"
        Dim obj_accPost As New LinkSetup
        obj_accPost.MdiParent = Me
        obj_accPost.Show()
    End Sub
    Private Sub tot_stock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "Total Stock Summary"
        Dim objStockSummary1 As New frmStockSummary_tot
        objStockSummary1.MdiParent = Me
        objStockSummary1.Show()
    End Sub


    Private Sub SubBOM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "BOM"
        Dim objStockSummary1 As New BOM
        objStockSummary1.MdiParent = Me
        objStockSummary1.Show()
    End Sub

    Private Sub SubItemMaster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "SUBSTORE_Item_Master"
        Dim objStockSummary1 As New SUBSTORE_Item_Master
        objStockSummary1.MdiParent = Me
        objStockSummary1.Show()

    End Sub

    Private Sub SubUOM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubUOM.Click
        GmoduleName = "UOMMaster"
        Dim objStockSummary1 As New UOMMaster
        objStockSummary1.MdiParent = Me
        objStockSummary1.Show()
    End Sub

    Private Sub MenuItem16_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "Stock Summary_old"
        Dim objStockadjustmentreport As New frmStockSummary_old
        objStockadjustmentreport.MdiParent = Me
        objStockadjustmentreport.Show()

    End Sub

    Private Sub MenuItem17_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "Purchase Register_old"
        Dim objpurchase As New FRM_PURCHASE
        objpurchase.MdiParent = Me
        objpurchase.Show()

    End Sub

    Private Sub MenuItem18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "Input Tax Report_old"
        Dim objStocktransferreport As New InputTax
        objStocktransferreport.MdiParent = Me
        objStocktransferreport.Show()
    End Sub

    Private Sub MenuItem23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem23.Click
        GmoduleName = "Stock Issue"
        Dim objStocktransferreport As New Frm_StockIssue
        objStocktransferreport.MdiParent = Me
        objStocktransferreport.Show()
    End Sub

    Private Sub MenuItem24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem24.Click
        Dim objGRNCumPurchaseBill As New Frm_PRNNew
        GmoduleName = "Purchase Return Bill"
        If GRNCumPurchaseBillTransbool = False And submnu_GRNCumPurchaseBill.Checked = True Then
            ' objGRNCumPurchaseBill.FormBorderStyle = FormBorderStyle.FixedDialog
            objGRNCumPurchaseBill.MdiParent = Me
            objGRNCumPurchaseBill.Show()
            submnu_GRNCumPurchaseBill.Checked = True
        End If
        If submnu_GRNCumPurchaseBill.Checked = True Then
            Exit Sub
        End If
        ' objGRNCumPurchaseBill.FormBorderStyle = FormBorderStyle.FixedDialog
        objGRNCumPurchaseBill.MdiParent = Me
        objGRNCumPurchaseBill.Show()
        submnu_GRNCumPurchaseBill.Checked = True
    End Sub

    Private Sub SubMnu_rtnRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "Purchase Return Register"
        Dim objpurchaseregister As New InvPurchaseregister
        objpurchaseregister.MdiParent = Me
        objpurchaseregister.Show()
    End Sub



    Private Sub StockInDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "Stock In Details"
        Dim objStockInDetails As New frmStockInreport
        objStockInDetails.MdiParent = Me
        objStockInDetails.Show()
    End Sub

    Private Sub StockOutDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "Stock Out Details"
        Dim objStockOutDetails As New frmStockOutreport
        objStockOutDetails.MdiParent = Me
        objStockOutDetails.Show()
    End Sub
    Private Sub StockOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "Stock Out"
        Dim objStockOut As New Stock_Out
        objStockOut.MdiParent = Me
        objStockOut.Show()
    End Sub

    Private Sub StockIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "Stock In"
        Dim objStockIn As New Stock_In
        objStockIn.MdiParent = Me
        objStockIn.Show()
    End Sub
    Private Sub MenuItem25_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objSubledgermaster As New SUBLEDGERMASTER
        objSubledgermaster.MdiParent = Me
        objSubledgermaster.Show()
    End Sub
    Private Sub MenuItem26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "ACCOUNTSITEMTAGGING"
        Dim ACCOUNTSITEMTAGGING As New ACCOUNTSITEMTAGGING
        ACCOUNTSITEMTAGGING.Show()
    End Sub

    Private Sub MenuItem27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem27.Click
        GmoduleName = "CategoryWise Stock Summary"
        Dim objCATStockSummary As New frmCATStockSummary
        objCATStockSummary.MdiParent = Me
        objCATStockSummary.Show()
    End Sub

    Private Sub MenuItem28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem28.Click
        GmoduleName = "Stock Damage Details"
        Dim objStockDMGDetails As New InvDamageReport
        objStockDMGDetails.MdiParent = Me
        objStockDMGDetails.Show()
    End Sub


    Private Sub MenuItem29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem29.Click
        GmoduleName = "CONSUMPTION"
        Dim CONSUMP As New Frm_stockConsumption
        CONSUMP.MdiParent = Me
        CONSUMP.Show()
    End Sub

    Private Sub MenuItem30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem30.Click
        GmoduleName = "CONSUMERMASTER"
        Dim CONSUMM As New CONSUMERMASTER
        CONSUMM.MdiParent = Me
        CONSUMM.Show()
    End Sub

    Private Sub MenuItem31_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MenuItem31.Click
        GmoduleName = "Stock Consumption Details"
        Dim objStockDMGDetails As New InvStockConsumption
        objStockDMGDetails.MdiParent = Me
        objStockDMGDetails.Show()
    End Sub

    Private Sub MenuItem32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem32.Click

        GmoduleName = "ACCOUNTS POSTING"
        Dim CONSUMM As New Inv_AcPosting
        CONSUMM.MdiParent = Me
        CONSUMM.Show()

        'If MsgBox("DO U Want to Repost Accounts......", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, "Stock Update") = MsgBoxResult.Ok Then
        '    Me.Cursor = Cursors.WaitCursor

        '    NewAccountPosting()

        '    MsgBox("Account Posting Completed....")
        '    Me.Cursor = Cursors.Default
        'Else
        '    MsgBox("Update Cancelled Try Again......", MsgBoxStyle.OkOnly, "Stock Update")
        'End If
    End Sub

    Private Sub MenuItem33_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MenuItem33.Click
        GmoduleName = "Uom Convertion Entry"
        Dim uomr As New FrmUOMRelation
        uomr.MdiParent = Me
        uomr.Show()
    End Sub

    Private Sub MenuItem34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "Liq Item Consolidated Summary"
        Dim objConsolidatedSummary As New frmConsolidatedLiquorSummary_LIQ
        objConsolidatedSummary.MdiParent = Me
        objConsolidatedSummary.Show()
    End Sub

    Private Sub MenuItem4_Click_1(sender As Object, e As EventArgs)
        GmoduleName = "Category Master"
        Dim cat_master As New Category_Master
        cat_master.MdiParent = Me
        cat_master.Show()
    End Sub

    Private Sub MenuItem8_Click_1(sender As Object, e As EventArgs) Handles MenuItem8.Click
        GmoduleName = "SubSubGroup Master"
        Dim SubSubGroup As New sub_Sub_Group_Master
        SubSubGroup.MdiParent = Me
        SubSubGroup.Show()
    End Sub

    Private Sub MenuItem10_Click_1(sender As Object, e As EventArgs) Handles MenuItem10.Click
        GmoduleName = "LinkSetup"
        Dim LS As New LinkSetup
        LS.MdiParent = Me
        LS.Show()
    End Sub

    Private Sub MenuItem11_Click_1(sender As Object, e As EventArgs) Handles MenuItem11.Click
        GmoduleName = "Bar Rate Revision"
        Dim barraterevision_obj As New RateRevisionReport
        barraterevision_obj.MdiParent = Me
        barraterevision_obj.Show()
    End Sub


    Public Sub Check_BOM()
        Dim obj1 As New BOM_CHECK
        Dim sql1 As String
        sql1 = "select distinct R.itemcode, I.itemDESC from RATEMASTER R, ITEMMASTER I where I.ITEMCODE=R.ITEMCODE AND R.UOM +  R.itemcode not in "
        sql1 = sql1 & " (select ITEMUOM + itemcode from BOM_DET) and ISNULL(I.Freeze,'')<>'Y' AND GETDATE() BETWEEN R.STARTINGDATE AND"
        sql1 = sql1 & "  ISNULL(R.ENDINGDATE,GETDATE()) AND CATEGORY='BAR' AND R.ITEMCODE IN "
        sql1 = sql1 & " (SELECT DISTINCT ITEMCODE FROM KOT_DET)"
        gconnection.getDataSet(sql1, "bomdet")
        If gdataset.Tables("bomdet").Rows.Count > 0 Then
            obj1.LOADGRID(gdataset.Tables("bomdet"))
            obj1.Show()
        End If
    End Sub

    Private Sub MenuItem13_Click_1(sender As Object, e As EventArgs) Handles MenuItem13.Click
        GmoduleName = "Month STB Report"
        'Dim objMonthSTB As New mceme_stocksummary
        Dim objMonthSTB As New frmMonthSTBReport
        objMonthSTB.MdiParent = Me
        objMonthSTB.Show()
    End Sub

    Private Sub CHECKUOM()
        Dim SQL1 As String
        Dim baseuom As String
        Dim dt As New DataTable
        Dim obj2 As New TRANSCONV_CHECK


        dt.Columns.Add("BaseUom", GetType(String))
        dt.Columns.Add("TransUom", GetType(String))
        dt.Columns.Add("ConvValue", GetType(Double))
        SQL1 = "SELECT DISTINCT  ITEMCODE FROM VW_UOMCON "
        gconnection.getDataSet(SQL1, "ITEMLIST")
        If gdataset.Tables("ITEMLIST").Rows.Count > 0 Then
            For it As Integer = 0 To gdataset.Tables("ITEMLIST").Rows.Count - 1
                SQL1 = "sELECT ITEMCODE,TRANUOM FROM VW_UOMCON where itemcode='" + gdataset.Tables("ITEMLIST").Rows(it).Item("ITEMCODE") + "'"
                gconnection.getDataSet(SQL1, "vw_uomcon")
                If gdataset.Tables("vw_uomcon").Rows.Count > 0 Then
                    For k As Integer = 0 To gdataset.Tables("vw_uomcon").Rows.Count - 1
                        baseuom = gdataset.Tables("vw_uomcon").Rows(k).Item("TRANUOM")
                        For m As Integer = k To gdataset.Tables("vw_uomcon").Rows.Count - 1
                            SQL1 = "select baseuom,transuom,convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + baseuom + "' and transuom='" + gdataset.Tables("vw_uomcon").Rows(m).Item("TRANUOM") + "'"
                            gconnection.getDataSet(SQL1, "INVENTORY_TRANSCONVERSION")
                            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                            Else
                                dt.Rows.Add(baseuom, gdataset.Tables("vw_uomcon").Rows(m).Item("TRANUOM"), 0)
                            End If
                        Next


                    Next

                End If
            Next
        End If

        Dim dView As New DataView(dt)
        Dim arrColumns As String() = {"BaseUom", "TransUom", "ConvValue"}
        dt = dView.ToTable(True, arrColumns)


        If dt.Rows.Count > 0 Then
            obj2.LOADGRID(dt)
            obj2.Show()

        End If

    End Sub

    Private Sub CHECK_TRANSCONVERSION()
        Dim SQL1 As String
        Dim obj2 As New TRANSCONV_CHECK
        SQL1 = "SELECT DISTINCT ITEMCODE, STOCKUOM FROM INVENTORYITEMMASTER WHERE ITEMCODE IN (select itemcode from INVENTORYITEMMASTER "
        SQL1 = SQL1 & " where ISNULL(stockuom,'') NOT IN (select isnull(baseuom,'') from INVENTORY_TRANSCONVERSION "
        SQL1 = SQL1 & " WHERE ISNULL(TRANSUOM,'') IN (select DISTINCT isnull(STOCKUOM,'') from INVENTORYITEMMASTER))  and isnull(freeze,'')<>'Y' )"
        gconnection.getDataSet(SQL1, "TRANSCONVERSION")
        If gdataset.Tables("TRANSCONVERSION").Rows.Count > 0 Then
            obj2.LOADGRID(gdataset.Tables("TRANSCONVERSION"))
            obj2.Show()
        End If
    End Sub

    Private Sub MenuItem14_Click_1(sender As Object, e As EventArgs) Handles MenuItem14.Click
        GmoduleName = "RSI Report"
        Dim objRSIReport As New frmRSIDayWiseAndProfitLossReport
        objRSIReport.MdiParent = Me
        objRSIReport.Show()
    End Sub

    Private Sub Main_MDI_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub MenuItem15_Click_1(sender As Object, e As EventArgs) Handles MenuItem15.Click
        GmoduleName = "TAX ACCOUNT TAGGING"
        Dim Accounttag As New AccountsTagging


        Accounttag.MdiParent = Me
        Accounttag.tabname = "accountstaxmaster"
        Accounttag.CodeField = "TAXCODE"
        Accounttag.Codedesc = "TAXDESC"
        Accounttag.header = "TAX ACCOUNT TAGGING"
        Accounttag.colname1 = "TAXCODE"
        Accounttag.colname2 = "TAXDESC"

        Accounttag.MdiParent = Me
        Accounttag.Show()
    End Sub

    Private Sub MenuItem16_Click_2(sender As Object, e As EventArgs) Handles MenuItem16.Click
        GmoduleName = "TAX TAGGING"
        Dim Accounttag As New ItemTaxTagging


        Accounttag.MdiParent = Me


        Accounttag.MdiParent = Me
        Accounttag.Show()
    End Sub

    Private Sub MenuItem17_Click_2(sender As Object, e As EventArgs) Handles MenuItem17.Click
        GmoduleName = "Purchase Order"
        Dim Accounttag As New Frm_PurchaseOrder
        Accounttag.MdiParent = Me
        Accounttag.MdiParent = Me
        Accounttag.Show()
    End Sub

    Private Sub MenuItem18_Click_1(sender As Object, e As EventArgs) Handles MenuItem18.Click
        GmoduleName = "Stock Indent"
        Dim Accounttag As New Frm_STOCKINDENT
        Accounttag.MdiParent = Me
        Accounttag.MdiParent = Me
        Accounttag.Show()
    End Sub

    Private Sub MenuItem19_Click_1(sender As Object, e As EventArgs) Handles MenuItem19.Click
        GmoduleName = "Tax Master"
        Dim Accounttag As New Inv_Taxmaster
        Accounttag.MdiParent = Me
        Accounttag.MdiParent = Me
        Accounttag.Show()
    End Sub

    Private Sub MenuItem21_Click(sender As Object, e As EventArgs) Handles MenuItem21.Click
        GmoduleName = "Tax Grouping"
        Dim Accounttag As New InvTAXCOMBINATION
        Accounttag.MdiParent = Me
        Accounttag.MdiParent = Me
        Accounttag.Show()

    End Sub

    Private Sub MenuItem22_Click_1(sender As Object, e As EventArgs) Handles MenuItem22.Click
        GmoduleName = "Purchase Order Amnendment"
        Dim Accounttag As New Frm_PurchaseOrder_amendment
        Accounttag.MdiParent = Me
        Accounttag.MdiParent = Me
        Accounttag.Show()

    End Sub

    Private Sub MenuItem26_Click_1(sender As Object, e As EventArgs) Handles MenuItem26.Click
        GmoduleName = "Item Vendor Tagging"
        Dim Accounttag As New FrmItemVendorTagging
        Accounttag.MdiParent = Me
        Accounttag.MdiParent = Me
        Accounttag.Show()
    End Sub

    Private Sub MenuItem34_Click_1(sender As Object, e As EventArgs) Handles MenuItem34.Click
        GmoduleName = "Vendor Category Tagging"
        Dim Accounttag As New FrmVendorCategory
        Accounttag.MdiParent = Me
        Accounttag.MdiParent = Me
        Accounttag.Show()
    End Sub

    Private Sub MenuItem35_Click(sender As Object, e As EventArgs) Handles MenuItem35.Click
        GmoduleName = "Store Master"
        Dim Accounttag As New Inv_StoreCategoryLink
        Accounttag.MdiParent = Me
        Accounttag.MdiParent = Me
        Accounttag.Show()

    End Sub

    Private Sub MenuItem36_Click(sender As Object, e As EventArgs) Handles MenuItem36.Click
        GmoduleName = "Issue By Itemwise"
        Dim Accounttag As New Frm_IssueByItemwise
        Accounttag.MdiParent = Me
        Accounttag.MdiParent = Me
        Accounttag.Show()
    End Sub

    Private Sub MenuItem37_Click(sender As Object, e As EventArgs) Handles MenuItem37.Click
        GmoduleName = "Pending PO And PO Wise GRN Report"
        Dim Accounttag As New Frm_REPORTS
        Accounttag.MdiParent = Me
        Accounttag.MdiParent = Me
        Accounttag.Show()
    End Sub

    Private Sub MenuItem38_Click(sender As Object, e As EventArgs) Handles MenuItem38.Click
        GmoduleName = "Item By Vendors Report"
        Dim Accounttag As New Frm_Vendors
        Accounttag.MdiParent = Me
        Accounttag.MdiParent = Me
        Accounttag.Show()
    End Sub

    Private Sub MenuItem39_Click(sender As Object, e As EventArgs) Handles MenuItem39.Click
        GmoduleName = "Store wise Consolidated Issue Report"
        Dim Accounttag As New StoreWise_Consolodated_Issue_Report
        Accounttag.MdiParent = Me
        Accounttag.MdiParent = Me
        Accounttag.Show()
    End Sub

    Private Sub MenuItem40_Click(sender As Object, e As EventArgs) Handles MenuItem40.Click
        GmoduleName = " Free Stock And Sponsered Stock Report"
        Dim Accounttag As New Frm_Freestock
        Accounttag.MdiParent = Me
        Accounttag.MdiParent = Me
        Accounttag.Show()
    End Sub

    Private Sub MenuItem41_Click(sender As Object, e As EventArgs) Handles MenuItem41.Click
        GmoduleName = "Stock Consumption"
        Dim Accounttag As New Frm_stockConsumptionNew
        Accounttag.MdiParent = Me
        Accounttag.MdiParent = Me
        Accounttag.Show()
    End Sub

    Private Sub MenuItem42_Click(sender As Object, e As EventArgs) Handles MenuItem42.Click
        GmoduleName = "ACCOUNT TAGGING"
        Dim Accounttag As New AccountsTaggingNew


        Accounttag.MdiParent = Me
        If gAcPostingWise = "ITEM" Then
            Accounttag.tabname = "INV_INVENTORYITEMMASTER"
            Accounttag.CodeField = "ITEMCODE"
            Accounttag.Codedesc = "ITEMNAME"
            Accounttag.header = "ITEM ACCOUNT TAGGING FOR POSTING"
            Accounttag.colname1 = "ITEMCODE"
            Accounttag.colname2 = "ITEMNAME"
        ElseIf gAcPostingWise = "CATEGORY" Then

            Accounttag.tabname = "INVENTORYCATEGORYMASTER"
            Accounttag.CodeField = "CATEGORYCODE"
            Accounttag.Codedesc = "CATEGORYDESC"
            Accounttag.header = "CATEGORY ACCOUNT TAGGING FOR POSTING"
            Accounttag.colname1 = "CATEGORYCODE"
            Accounttag.colname2 = "CATEGORYDESC"
        Else
            Accounttag.tabname = "STOREMASTER"
            Accounttag.CodeField = "STORECODE"
            Accounttag.Codedesc = "STOREDESC"
            Accounttag.header = "STORE ACCOUNT TAGGING"
            Accounttag.colname1 = "STORECODE"
            Accounttag.colname2 = "STOREDESC"
        End If


        Accounttag.MdiParent = Me
        Accounttag.Show()
    End Sub

    Private Sub MenuItem43_Click(sender As Object, e As EventArgs) Handles MenuItem43.Click
        Dim objSponsormaster As New Sponsor_Master
        GmoduleName = "Sponsor Master"
        If SponsorMasterbool = False And MenuItem43.Checked = True Then
            objSponsormaster.FormBorderStyle = FormBorderStyle.FixedDialog
            objSponsormaster.MdiParent = Me
            objSponsormaster.Show()
            MenuItem43.Checked = True
        End If
        If MenuItem43.Checked = True Then
            Exit Sub
        End If

        objSponsormaster.FormBorderStyle = FormBorderStyle.FixedDialog
        objSponsormaster.MdiParent = Me
        objSponsormaster.Show()
        '  MenuItem43.Checked = True
    End Sub

    Private Sub MenuItem44_Click(sender As Object, e As EventArgs) Handles MenuItem44.Click
        GmoduleName = "SPONSOR ACCOUNT TAGGING"
        Dim Accounttag As New SponsorAccountsTagging


        Accounttag.MdiParent = Me
        Accounttag.tabname = "INV_SPONSORMASTER"
        Accounttag.CodeField = "SPONSORCODE"
        Accounttag.Codedesc = "SPONSORDESC"
        Accounttag.header = "SPONSOR ACCOUNT TAGGING"
        Accounttag.colname1 = "SPONSORCODE"
        Accounttag.colname2 = "SPONSORDESC"

        Accounttag.MdiParent = Me
        Accounttag.Show()

    End Sub

    Private Sub MenuItem45_Click(sender As Object, e As EventArgs) Handles MenuItem45.Click
        GmoduleName = " Audit Trail Report"
        Dim Audit As New AuditTrail
        Audit.MdiParent = Me
        Audit.MdiParent = Me
        Audit.Show()
    End Sub
    Public Sub ManualUpdate()
        'Dim cuDate, nDate As DateTime
        'Dim cuDate1, nDate1, day As String
        'Dim Tdate() As String
        'Dim trns_seq, Nexttrns_seq, sqlstring As String
        'Dim seq As Integer = 0
        'Dim INSERT(0) As String
        'Dim a As Double
        ''mydt.ToString("dd MMM yy tt")
        ''insert(0) = sqlstring
        'sqlstring = "select * from closingqty  order by Trndate , Autoid "
        'gconnection.getDataSet(sqlstring, "closingqtyT")
        'If (gdataset.Tables("closingqtyT").Rows.Count > 0) Then
        '    For i As Integer = 0 To gdataset.Tables("closingqtyT").Rows.Count - 1

        '        cuDate = Format(gdataset.Tables("closingqtyT").Rows(i).Item("trndate"), "dd/MMM/yyyy")
        '        cuDate1 = cuDate.ToString("dd/MM/yy")
        '        nDate1 = cuDate1
        '        seq = 1
        '        Do While cuDate1 = nDate1 And gdataset.Tables("closingqtyT").Rows.Count > i


        '            Tdate = Split(Trim(cuDate1), "/")
        '            Nexttrns_seq = Mid(Tdate(2), 1, 2) & Mid(Tdate(1), 1, 2) & Mid(Tdate(0), 1, 2)
        '            Nexttrns_seq = Nexttrns_seq & Format(seq, "00000")


        '            sqlstring = "update closingqty set trns_seq=" & Val(Nexttrns_seq) & " where autoid=" & Val(gdataset.Tables("closingqtyT").Rows(i).Item("autoid")) & ""
        '            ReDim Preserve INSERT(INSERT.Length)
        '            INSERT(INSERT.Length - 1) = sqlstring
        '            seq = seq + 1
        '            i = i + 1
        '            If gdataset.Tables("closingqtyT").Rows.Count > i Then
        '                nDate = Format(gdataset.Tables("closingqtyT").Rows(i).Item("trndate"), "dd/MMM/yyyy")
        '                nDate1 = nDate.ToString("dd/MM/yy")
        '            End If

        '        Loop
        '        i = i - 1

        '    Next

        'End If
        'gconnection.MoreTrans1(INSERT)

        'sqlstring = "update Grn_details set TRNS_SEQ=CLOSINGQTY.TRNS_SEQ from Grn_details g inner join CLOSINGQTY on grndetails=CLOSINGQTY.trnno where G.Itemcode=CLOSINGQTY.itemcode AND G.grndate=CLOSINGQTY.Trndate"
        'ReDim Preserve INSERT(INSERT.Length)
        'INSERT(INSERT.Length - 1) = sqlstring
        'sqlstring = "update STOCKISSUEdetail  set TRNS_SEQ=CLOSINGQTY.TRNS_SEQ from STOCKISSUEdetail  S inner join CLOSINGQTY on Docdetails=CLOSINGQTY.trnno where S.Itemcode=CLOSINGQTY.itemcode AND S.Docdate=CLOSINGQTY.Trndate"
        'ReDim Preserve INSERT(INSERT.Length)
        'INSERT(INSERT.Length - 1) = sqlstring
        'sqlstring = "update STOCKADJUSTDETAILs   set TRNS_SEQ=CLOSINGQTY.TRNS_SEQ from STOCKADJUSTDETAILs   S inner join CLOSINGQTY on Docdetails=CLOSINGQTY.trnno where S.Itemcode=CLOSINGQTY.itemcode AND S.Docdate=CLOSINGQTY.Trndate"
        'ReDim Preserve INSERT(INSERT.Length)
        'INSERT(INSERT.Length - 1) = sqlstring
        'sqlstring = "update StockConsumption_detail   set TRNS_SEQ=CLOSINGQTY.TRNS_SEQ from StockConsumption_detail   S inner join CLOSINGQTY on Docdetails=CLOSINGQTY.trnno where S.Itemcode=CLOSINGQTY.itemcode AND S.Docdate=CLOSINGQTY.Trndate"
        'ReDim Preserve INSERT(INSERT.Length)
        'INSERT(INSERT.Length - 1) = sqlstring
        'sqlstring = "update stockConsumption_1    set TRNS_SEQ=CLOSINGQTY.TRNS_SEQ from stockConsumption_1    S inner join CLOSINGQTY on docno=CLOSINGQTY.trnno where S.Itemcode=CLOSINGQTY.itemcode AND S.Docdate=CLOSINGQTY.Trndate"
        'ReDim Preserve INSERT(INSERT.Length)
        'INSERT(INSERT.Length - 1) = sqlstring
        'sqlstring = "update STOCKDMGdetail    set TRNS_SEQ=CLOSINGQTY.TRNS_SEQ from STOCKDMGdetail    S inner join CLOSINGQTY on Docdetails=CLOSINGQTY.trnno where S.Itemcode=CLOSINGQTY.itemcode AND S.Docdate=CLOSINGQTY.Trndate"
        'ReDim Preserve INSERT(INSERT.Length)
        'INSERT(INSERT.Length - 1) = sqlstring
        'sqlstring = "update STOCKTRANSFERdetail     set TRNS_SEQ=CLOSINGQTY.TRNS_SEQ from STOCKTRANSFERdetail     S inner join CLOSINGQTY on Docdetails=CLOSINGQTY.trnno where S.Itemcode=CLOSINGQTY.itemcode AND S.Docdate=CLOSINGQTY.Trndate"
        'ReDim Preserve INSERT(INSERT.Length)
        'INSERT(INSERT.Length - 1) = sqlstring

        'gconnection.MoreTrans1(INSERT)

        'Dim curDate As DateTime
        'sqlstring = "Select getdate()"
        'curDate = Format(gconnection.getvalue(sqlstring), "dd/MMM/yyyy")
        'sqlstring = "Select * Into CLOSINGQTY" & curDate & " From closingqty"
        'gconnection.dataOperation(6, sqlstring, )

        'sqlstring = "DROP TABLE closingqty"
        'gconnection.dataOperation(6, sqlstring, )
        'sqlstring = "Select * Into closingqty From CLOSINGQTY" & curDate & " ORDER BY TRNS_SEQ"
        'gconnection.dataOperation(6, sqlstring, )

        'Dim closingqty As Double
        'Dim closingvalue As Double
        'Dim openningstock As Double
        'Dim openningvalue As Double
        'Dim TRNrate As Double
        'Dim TRNQTY As Double
        'Dim WRATE As Double
        'Dim itemcode As String
        'Dim storecode As String
        'Dim RateFleg As String



        'sqlstring = "select * from CLOSINGQTY"
        'gconnection.getDataSet(sqlstring, "closingqty")
        'For i As Integer = 0 To gdataset.Tables("closingqty").Rows.Count - 1

        '    itemcode = gdataset.Tables("closingqty").Rows(i).Item("ITEMCODE")
        '    storecode = gdataset.Tables("closingqty").Rows(i).Item("STORECODE")

        '    Dim sql1 As String = " select rateflag from INVENTORYCATEGORYMASTER inner join INV_InventoryItemMaster"
        '    sql1 = sql1 & " on INVENTORYCATEGORYMASTER.CATEGORYCODE=INV_InventoryItemMaster.category and itemcode='" & itemcode & "'  "
        '    gconnection.getDataSet(sql1, "ratelist2")
        '    If (gdataset.Tables("ratelist2").Rows.Count > 0) Then
        '        If (gdataset.Tables("ratelist2").Rows(0).Item("rateflag") = "W") Then
        '            RateFleg = "W"
        '        Else
        '            RateFleg = "P"
        '        End If
        '    Else
        '        MsgBox("Fill properly detail of itemcode= " & itemcode & "  in ItemMaster")
        '    End If

        '    ' If gdataset.Tables("closingqty").Rows(i).Item("ttype") = "GRN" Then

        '    sqlstring = "select Storestatus from StoreMaster WHERE STORECODE='" & storecode & "' and isnull(Freeze,'')<>'Y' "
        '    gconnection.getDataSet(sqlstring, "STOREMASTER")

        '    If gdataset.Tables("STOREMASTER").Rows(0).Item("Storestatus") = "M" And gdataset.Tables("closingqty").Rows(i).Item("ttype") = "GRN" Then


        '        If RateFleg = "W" Then

        '            sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,ISNULL(openningstock,0) AS openningstock,OPENNingvalue from closingqty where itemcode='" & itemcode & "' AND  storecode='" & storecode & "'and trndate<'" & Format(gdataset.Tables("closingqty").Rows(i).Item("trndate"), "dd/MMM/yyyy") & "' order by trndate desc,AUTOID desc"
        '            gconnection.getDataSet(sqlstring, "closingqty1")

        '            If (gdataset.Tables("closingqty1").Rows.Count > 0) Then

        '                closingqty = gdataset.Tables("closingqty1").Rows(0).Item("closingstock")
        '                closingvalue = gdataset.Tables("closingqty1").Rows(0).Item("closingvalue")
        '                openningstock = gdataset.Tables("closingqty1").Rows(0).Item("openningstock")
        '                openningvalue = gdataset.Tables("closingqty1").Rows(0).Item("openningvalue")
        '            End If

        '            sqlstring = "SELECT * FROM Grn_details WHERE grndetails='" & gdataset.Tables("closingqty").Rows(i).Item("TRNNO") & "' and itemcode='" & itemcode & "'"
        '            gconnection.getDataSet(sqlstring, "Grn_details")
        '            If (gdataset.Tables("Grn_details").Rows.Count > 0) Then

        '                'closingqty = gdataset.Tables("Grn_details").Rows(0).Item("amountafterdiscount")
        '                TRNQTY = Val(gdataset.Tables("Grn_details").Rows(0).Item("qty"))
        '                TRNrate = Val(gdataset.Tables("Grn_details").Rows(0).Item("amountafterdiscount") / gdataset.Tables("Grn_details").Rows(0).Item("qty"))
        '                Dim OLDRATE As Double
        '                'Dim TRNRATE As Double

        '                If openningstock <= 0 Then
        '                    OLDRATE = 0
        '                Else
        '                    OLDRATE = openningvalue / openningstock
        '                End If
        '                Dim OVal As Double = closingqty * OLDRATE
        '                Dim TVal As Double = TRNrate * TRNQTY
        '                Dim CQty As Double = closingqty + TRNQTY
        '                WRATE = (OVal + TVal) / CQty
        '                sqlstring = "update CLOSINGQTY set openningvalue=openningstock*" & Format(Val(WRATE), "0.000") & ",closingvalue=closingstock*" & Format(Val(WRATE), "0.000") & " where trnno='" & gdataset.Tables("closingqty").Rows(i).Item("trnno") & "' and itemcode='" & itemcode & "' and storecode='" & storecode & "'"
        '                gconnection.dataOperation(6, sqlstring, )

        '                sqlstring = "update CLOSINGQTY set openningvalue=openningstock*" & Val(WRATE) & ",closingvalue=closingstock*" & Format(Val(WRATE), "0.000") & " where  itemcode='" & itemcode & "' and trns_seq>'" & gdataset.Tables("closingqty").Rows(i).Item("trns_seq") & "' and ttype<>'GRN'"
        '                gconnection.dataOperation(6, sqlstring, )
        '            End If
        '        Else

        '            sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue from closingqty where itemcode='" & itemcode & "' AND  storecode='" & gdataset.Tables("closingqty").Rows(i).Item("STORECODE") & "'and trndate<='" & Format(gdataset.Tables("closingqty").Rows(i).Item("trndate"), "dd/MMM/yyyy") & "' order by trndate desc,AUTOID desc"
        '            gconnection.getDataSet(sqlstring, "closingqty1")
        '            If (gdataset.Tables("closingqty1").Rows.Count > 0) Then

        '                closingqty = gdataset.Tables("closingqty1").Rows(0).Item("closingstock")
        '                closingvalue = gdataset.Tables("closingqty1").Rows(0).Item("closingvalue")
        '            End If
        '            sqlstring = "SELECT * FROM Grn_details WHERE grndetails='" & gdataset.Tables("closingqty").Rows(i).Item("TRNNO") & "' and itemcode='" & itemcode & "'"
        '            If (gdataset.Tables("Grn_details").Rows.Count > 0) Then
        '                TRNrate = Val(gdataset.Tables("Grn_details").Rows(0).Item("amountafterdiscount") / gdataset.Tables("Grn_details").Rows(0).Item("qty"))

        '            End If

        '            sqlstring = "update CLOSINGQTY set openningvalue=openningvalue*" & TRNrate & ",closingvalue=" & TRNrate & "*closingstock where trnno='" & gdataset.Tables("closingqty").Rows(i).Item("trnno") & "' and itemcode='" & itemcode & "' and storecode='" & storecode & "'"
        '            gconnection.dataOperation(6, sqlstring, )
        '            sqlstring = "update CLOSINGQTY set openningvalue=" & Val(TRNrate) & ",closingvalue=" & TRNrate & "*closingstock where  itemcode='" & itemcode & "' and trns_seq>'" & gdataset.Tables("closingqty").Rows(i).Item("trns_seq") & "' and ttype<>'GRN'"
        '            gconnection.dataOperation(6, sqlstring, )
        '        End If

        '        ' End If
        '    ElseIf gdataset.Tables("STOREMASTER").Rows(0).Item("Storestatus") = "M" And gdataset.Tables("closingqty").Rows(i).Item("ttype") = "Openning" Then

        '        sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,ISNULL(openningstock,0) AS openningstock,OPENNingvalue from closingqty where itemcode='" & itemcode & "' AND  storecode='" & storecode & "'and trndate<='" & Format(gdataset.Tables("closingqty").Rows(i).Item("trndate"), "dd/MMM/yyyy") & "' order by trndate desc,AUTOID desc"
        '        gconnection.getDataSet(sqlstring, "closingqty1")

        '        If (gdataset.Tables("closingqty1").Rows.Count > 0) Then

        '            closingqty = Val(gdataset.Tables("closingqty1").Rows(0).Item("closingstock"))
        '            closingvalue = Val(gdataset.Tables("closingqty1").Rows(0).Item("closingvalue"))
        '            ' openningstock = gdataset.Tables("closingqty1").Rows(0).Item("openningstock")
        '            'openningvalue = gdataset.Tables("closingqty1").Rows(0).Item("openningvalue")
        '            If closingqty < 1 Then
        '                TRNrate = 1
        '            Else
        '                TRNrate = Val(closingvalue \ closingqty)
        '            End If

        '        End If


        '        sqlstring = "update CLOSINGQTY set openningvalue=0,openningstock=0,closingvalue=" & Val(TRNrate) & "*closingstock where trnno='" & gdataset.Tables("closingqty").Rows(i).Item("trnno") & "' and itemcode='" & itemcode & "' and storecode='" & storecode & "'"
        '        gconnection.dataOperation(6, sqlstring, )
        '        sqlstring = "update CLOSINGQTY set openningvalue=openningstock*" & Val(TRNrate) & ",closingvalue=" & TRNrate & "*closingstock where  itemcode='" & itemcode & "' and trns_seq>" & gdataset.Tables("closingqty").Rows(i).Item("trns_seq") & " and ttype<>'GRN'"
        '        gconnection.dataOperation(6, sqlstring, )

        '    End If
        'Next

    End Sub


    Private Sub MenuItem46_Click(sender As Object, e As EventArgs) Handles MenuItem46.Click
        If MsgBox("DO U Want to Manual Update Stock......", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, "Stock Update") = MsgBoxResult.Ok Then
            Me.Cursor = Cursors.WaitCursor
            If Mid(UCase(gShortname), 1, 5) = "RSAOI" Or Mid(UCase(gShortname), 1, 3) = "MLA" Or Mid(UCase(gShortname), 1, 3) = "CTC" Or
                Mid(UCase(gShortname), 1, 4) = "JHIC" Then
                CALC_WEIGHTEDRSI()
            Else
                CALC_WEIGHTED()
                'CALC_WEIGHTEDRSI()
            End If
            If gShortname = "HGA" Then
                Dim sqlstring As String
                sqlstring = "  exec passinvntoryunmatchedentries "
                gconnection.ExcuteStoreProcedure(sqlstring)
            End If
            MsgBox("Stock Manual Updation Completed....")
            Me.Cursor = Cursors.Default
        Else
            MsgBox("Update Cancelled Try Again......", MsgBoxStyle.OkOnly, "Stock Update")
        End If
    End Sub

    Private Sub Main_MDI_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            'If e.KeyCode = Keys.U Then
            '    If MsgBox("DO U Want to Manual Update Stock......", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, "Stock Update") = MsgBoxResult.Ok Then
            '        Me.Cursor = Cursors.WaitCursor
            '        gconnection.ManualUpdateNew()
            '        Me.Cursor = Cursors.Default
            '    Else
            '        MsgBox("Update Cancelled Try Again......", MsgBoxStyle.OkOnly, "Stock Update")
            '    End If
            'ElseIf e.KeyCode = Keys.R Then
            '    If MsgBox("DO U Want to Manual Update Rate......", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, "Stock Update") = MsgBoxResult.Ok Then
            '        Me.Cursor = Cursors.WaitCursor
            '        gconnection.valuation()
            '        Me.Cursor = Cursors.Default
            '    Else
            '        MsgBox("Update Cancelled Try Again......", MsgBoxStyle.OkOnly, "Stock Update")
            '    End If
            'End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : GRN_Cum_Purchase_Bill_COMMON_KeyDown " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub MenuItem47_Click(sender As Object, e As EventArgs) Handles MenuItem47.Click


        GmoduleName = " Reciept Register"
        Dim Audit As New InvRecieptregister
        Audit.MdiParent = Me
        Audit.MdiParent = Me
        Audit.Show()
    End Sub

    Private Sub MenuItem48_Click(sender As Object, e As EventArgs) Handles MenuItem48.Click
        GmoduleName = " Issue Reciept Consolodated Store Wise Report"
        Dim Audit As New StoreWise_Consolodated_Report
        Audit.MdiParent = Me
        Audit.MdiParent = Me
        Audit.Show()
    End Sub

    Private Sub MenuItem49_Click(sender As Object, e As EventArgs) Handles MenuItem49.Click
        GmoduleName = " Business Date Closing "
        Dim Audit As New FrmClosingDate

        Audit.ShowDialog()
    End Sub

    Private Sub mnu_Administrator_Click(sender As Object, e As EventArgs) Handles mnu_Administrator.Click

    End Sub

    Private Sub MenuItem50_Click(sender As Object, e As EventArgs) Handles MenuItem50.Click
        GmoduleName = " Tax Report"
        Dim tax As New InvTaxReport
        tax.MdiParent = Me
        tax.MdiParent = Me
        tax.Show()
    End Sub

    Private Sub MenuItem51_Click(sender As Object, e As EventArgs) Handles MenuItem51.Click
        GmoduleName = " Pending PO GRN Report"
        Dim tax As New InvRecieptregister1
        tax.MdiParent = Me
        tax.MdiParent = Me
        tax.Show()
    End Sub

    Private Sub MenuItem52_Click(sender As Object, e As EventArgs) Handles MenuItem52.Click
        GmoduleName = " Pending Indent Issue Report"
        Dim tax As New InvPenIndentIssue
        tax.MdiParent = Me
        tax.MdiParent = Me
        tax.Show()
    End Sub

    Private Sub MenuItem54_Click(sender As Object, e As EventArgs) Handles MenuItem54.Click
        GmoduleName = "Stock Summary"
        Dim objStockSummary As New InvStockSummaryGroup
        objStockSummary.MdiParent = Me
        objStockSummary.Show()
    End Sub

    Private Sub MenuItem53_Click(sender As Object, e As EventArgs) Handles MenuItem53.Click
        GmoduleName = "Stock Summary"
        Dim objStockSummary As New InvStockSummary
        objStockSummary.MdiParent = Me
        objStockSummary.Show()
    End Sub



    Private Sub MenuItem55_Click(sender As Object, e As EventArgs) Handles MenuItem55.Click
        GmoduleName = "Store Wise Closing Stock Report"
        Dim objStockSummary As New InvStoreClosingStockReport
        objStockSummary.MdiParent = Me
        objStockSummary.Show()
    End Sub

    Private Sub MenuItem56_Click(sender As Object, e As EventArgs) Handles MenuItem56.Click
        GmoduleName = "Store Group Master"
        Dim StoreGroup As New Store_group_master
        StoreGroup.MdiParent = Me
        StoreGroup.MdiParent = Me
        StoreGroup.Show()
    End Sub

    Private Sub MenuItem57_Click(sender As Object, e As EventArgs) Handles MenuItem57.Click
        GmoduleName = "Delivery Terms Master"
        Dim StoreGroup As New deliveryterms
        StoreGroup.MdiParent = Me
        StoreGroup.MdiParent = Me
        StoreGroup.Show()
    End Sub

    Private Sub MenuItem58_Click(sender As Object, e As EventArgs) Handles MenuItem58.Click
        GmoduleName = "INPUT TAX ACCOUNT TAGGING"
        Dim Accounttag As New AccountsTaggingInputTax

        Accounttag.MdiParent = Me
        Accounttag.header = "INPUTTAX ACCOUNTS TAGGING"
        Accounttag.MdiParent = Me
        Accounttag.Show()
    End Sub

    Private Sub mnu_Transaction_Click(sender As Object, e As EventArgs) Handles mnu_Transaction.Click
        Call Check()
    End Sub

    Private Sub MenuItem59_Click(sender As Object, e As EventArgs) Handles MenuItem59.Click
        GmoduleName = "PRINT PO"
        Dim PO As New PrintPO
        PO.MdiParent = Me
        PO.Show()

    End Sub

    Private Sub MenuItem60_Click(sender As Object, e As EventArgs) Handles MenuItem60.Click
        GmoduleName = "COMPANY MASTER"
        Dim CM As New Company_master
        CM.MdiParent = Me
        CM.Show()
    End Sub

    Private Sub MenuItem61_Click(sender As Object, e As EventArgs) Handles MenuItem61.Click
        GmoduleName = "Company Item Tagging"
        Dim CM As New Inv_CompanyItemLink
        CM.MdiParent = Me
        CM.Show()
    End Sub

    Private Sub MenuItem62_Click(sender As Object, e As EventArgs) Handles MenuItem62.Click
        GmoduleName = "Company Wise Item Offtake Report"
        Dim CM As New InvCompanyItem
        CM.MdiParent = Me
        CM.Show()
    End Sub

    Private Sub MenuItem63_Click(sender As Object, e As EventArgs) Handles MenuItem63.Click

        Dim objGRNCumPurchaseBill As New Frm_GRNNonStockableUpdate
        GmoduleName = "GRN Cum Purchase Bill"
        '   If GRNCumPurchaseBillTransbool = False And submnu_GRNCumPurchaseBill.Checked = True Then
        objGRNCumPurchaseBill.FormBorderStyle = FormBorderStyle.FixedDialog
        objGRNCumPurchaseBill.MdiParent = Me
        objGRNCumPurchaseBill.Show()
        submnu_GRNCumPurchaseBill.Checked = True

    End Sub

    Private Sub MenuItem64_Click(sender As Object, e As EventArgs) Handles MenuItem64.Click
        GmoduleName = "Excise Report"
        Dim CM As New InvKBA_ExciseReport
        CM.MdiParent = Me
        CM.Show()
    End Sub

    Private Sub MenuItem65_Click(sender As Object, e As EventArgs) Handles MenuItem65.Click
        GmoduleName = "Yearly Consolidated Issue Report"
        Dim CM As New InvCon_Issue
        CM.MdiParent = Me
        CM.Show()
    End Sub

    Private Sub MenuItem66_Click(sender As Object, e As EventArgs) Handles MenuItem66.Click
        GmoduleName = "CORPORATE NOMINEE DETAILS"
        Dim CM As New CoporateDet
        CM.MdiParent = Me
        CM.Show()
    End Sub

    Private Sub MenuItem67_Click(sender As Object, e As EventArgs) Handles MenuItem67.Click
        GmoduleName = "Item Conversion"
        Dim CM
        If Mid(UCase(gShortname), 1, 3) = "MGC" Then
            CM = New FrmProductConversion
        Else
            CM = New FrmProductConversion_All
        End If
        CM.MdiParent = Me
        CM.Show()
    End Sub

    Private Sub MenuItem68_Click(sender As Object, e As EventArgs) Handles MenuItem68.Click
        GmoduleName = "VENDOR ITEMS LINK"
        Dim CM As New InvVendorItemTagging
        CM.MdiParent = Me
        CM.Show()
    End Sub

    Private Sub MenuItem69_Click(sender As Object, e As EventArgs) Handles MenuItem69.Click
        GmoduleName = "STORECCTAGGING"
        Dim Accounttag As New StoreCCTagging


        Accounttag.MdiParent = Me
        Accounttag.tabname = "STOREMASTER"
        Accounttag.CodeField = "STORECODE"
        Accounttag.Codedesc = "STOREDESC"
        Accounttag.header = "STORE COST CENTER TAGGING"
        Accounttag.colname1 = "STORECODE"
        Accounttag.colname2 = "STOREDESC"

        Accounttag.MdiParent = Me
        Accounttag.Show()
    End Sub

    Private Sub MenuItem70_Click(sender As Object, e As EventArgs) Handles MenuItem70.Click
        GmoduleName = "Excise Report"
        Dim CM As New InvSATC_ExciseReport
        CM.MdiParent = Me
        CM.Show()
    End Sub

    'Private Sub MenuItem71_Click(sender As Object, e As EventArgs) Handles MenuItem71.Click
    '    GmoduleName = "Tax Report"
    '    Dim objpurchaseregister As New FrmTaxReport
    '    objpurchaseregister.MdiParent = Me
    '    objpurchaseregister.Show()

    'End Sub

    Private Sub mnu_Utility_Click(sender As Object, e As EventArgs) Handles mnu_Utility.Click

    End Sub

    Private Sub MenuItem72_Click(sender As Object, e As EventArgs) Handles MenuItem72.Click
        GmoduleName = "Reorder Level Report"
        Dim CM As New ReorderLevel
        CM.MdiParent = Me
        CM.Show()
    End Sub

    Private Sub MenuItem73_Click(sender As Object, e As EventArgs) Handles MenuItem73.Click
        GmoduleName = "Stock Summary"
        Dim objStockSummary As New InvStockSummarySubGroup
        objStockSummary.MdiParent = Me
        objStockSummary.Show()
    End Sub

    Private Sub MenuItem74_Click(sender As Object, e As EventArgs) Handles MenuItem74.Click
        GmoduleName = "Weighing Machine Setup"
        Dim objitemwisesale As New weighingmachinesetup
        objitemwisesale.MdiParent = Me

        objitemwisesale.Show()
    End Sub

    Private Sub MenuItem75_Click(sender As Object, e As EventArgs) Handles MenuItem75.Click

        GmoduleName = "Group and SubGroupwise issue Report"
        Dim GSWID As New GROUPORSUBGORUPWISEISSUE
        GSWID.MdiParent = Me
        GSWID.Show()


    End Sub


    Private Sub MenuItem12_Click(sender As Object, e As EventArgs) Handles MenuItem12.Click

        GmoduleName = "Bar Rate Revision"
        Dim barraterevision_obj As New FrmConsolidate
        barraterevision_obj.MdiParent = Me
        barraterevision_obj.Show()
    End Sub

    Private Sub MenuItem76_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub mnu_Masters_Click(sender As Object, e As EventArgs) Handles mnu_Masters.Click

    End Sub


    Private Sub MenuItem76_Click_1(sender As Object, e As EventArgs) Handles MenuItem76.Click
        GmoduleName = "Consumption Posting"
        Dim GSWID As New inv_Posting
        GSWID.MdiParent = Me
        GSWID.Show()
    End Sub

    Private Sub MenuItem77_Click(sender As Object, e As EventArgs) Handles MenuItem77.Click
        GmoduleName = "Salvage Entry"
        Dim GSWID As New Frm_Salvage
        GSWID.MdiParent = Me
        GSWID.Show()
    End Sub



    Private Sub MenuItem78_Click(sender As Object, e As EventArgs) Handles MenuItem78.Click
        GmoduleName = "Indent/Purchase Order Report"
        Dim GSWID As New PucReport
        GSWID.MdiParent = Me
        GSWID.Show()
    End Sub

    Private Sub MenuItem79_Click(sender As Object, e As EventArgs) Handles MenuItem79.Click
        GmoduleName = "Report For Indent/Po "
        Dim GSWID As New Popup
        GSWID.MdiParent = Me
        GSWID.Show()
    End Sub

    Private Sub MenuItem80_Click(sender As Object, e As EventArgs)
        Dim objStoreMaster As New Store_Master
        GmoduleName = "Store Master"
        'If StoreMasterbool = False And submnu_StoreMaster.Checked = True Then
        '  objStoreMaster.FormBorderStyle = FormBorderStyle.FixedDialog
        objStoreMaster.MdiParent = Me
        objStoreMaster.Show()
        'submnu_StoreMaster.Checked = True
        'End If
        'If submnu_StoreMaster.Checked = True Then
        '    Exit Sub
        'End If
        'objStoreMaster.FormBorderStyle = FormBorderStyle.FixedDialog
        'objStoreMaster.MdiParent = Me
        'objStoreMaster.Show()
        'submnu_StoreMaster.Checked = True
    End Sub

    Private Sub MenuItem4_Click_2(sender As Object, e As EventArgs) Handles MenuItem4.Click
        GmoduleName = "PO Indent"
        Dim GSWID As New PO_StockIndent
        GSWID.MdiParent = Me
        GSWID.Show()
    End Sub

    Private Sub MenuItem25_Click(sender As Object, e As EventArgs)
        GmoduleName = "Location Master"
        Dim GSWID As New Inv_LocationMaster
        GSWID.MdiParent = Me
        GSWID.Show()
    End Sub

    Private Sub MenuItem71_Click(sender As Object, e As EventArgs)
        GmoduleName = "Shelf Master"
        Dim GSWID As New Inv_ShelfMaster
        GSWID.MdiParent = Me
        GSWID.Show()
    End Sub

    Private Sub MenuItem80_Click_1(sender As Object, e As EventArgs) Handles MenuItem80.Click
        GmoduleName = "Storewise Itemwise Expiry Report"
        Dim GSWID As New FrmStoreWiseExpiry
        GSWID.MdiParent = Me
        GSWID.Show()
    End Sub

    Private Sub MenuItem71_Click_1(sender As Object, e As EventArgs) Handles MenuItem71.Click
        GmoduleName = "Session Master"
        Dim GSWID As New Inv_SessionMaster
        GSWID.MdiParent = Me
        GSWID.Show()
    End Sub

    Private Sub MenuItem81_Click(sender As Object, e As EventArgs) Handles MenuItem81.Click
        GmoduleName = "Month Close"
        Dim GSWID As New Dayend
        GSWID.MdiParent = Me
        GSWID.Show()
    End Sub

    Private Sub MenuItem82_Click(sender As Object, e As EventArgs) Handles MenuItem82.Click
        GmoduleName = "Sale Report"
        Dim GSWID As New SaleReport
        GSWID.MdiParent = Me
        GSWID.Show()
    End Sub

    Private Sub MenuItem83_Click(sender As Object, e As EventArgs) Handles MenuItem83.Click
        GmoduleName = "Stationary Stock Issue"
        Dim GSWID As New FRM_STATIONARY_HGA
        GSWID.MdiParent = Me
        GSWID.Show()
    End Sub

    Private Sub MenuItem84_Click(sender As Object, e As EventArgs) Handles MenuItem84.Click
        GmoduleName = "PO REPORT SUMMARY AND DETAIL"
        Dim GSWID As New FRM_PURCHASES
        GSWID.MdiParent = Me
        GSWID.Show()
    End Sub

    Private Sub MenuItem85_Click(sender As Object, e As EventArgs) Handles MenuItem85.Click
        GmoduleName = "DISTRIBUTION"
        Dim GSWID As New Employeewise
        GSWID.MdiParent = Me
        GSWID.Show()
    End Sub
    Private Sub MenuItem86_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MenuItem86_Click_1(sender As Object, e As EventArgs) Handles MenuItem86.Click
        GmoduleName = "Day Close"
        Dim GSWID As New DayCloseForm
        GSWID.MdiParent = Me
        GSWID.Show()

    End Sub

    Private Sub MenuItem87_Click(sender As Object, e As EventArgs) Handles MenuItem87.Click
        GmoduleName = "Stock Summary Costing"
        Dim objStockSummary As New InvStockSummaryGroupCosting
        objStockSummary.MdiParent = Me
        objStockSummary.Show()
    End Sub

    Private Sub MenuItem88_Click(sender As Object, e As EventArgs) Handles MenuItem88.Click
        GmoduleName = "Payment Gateway"
        Dim objStockSummary As New PaymentGateway
        objStockSummary.MdiParent = Me
        objStockSummary.Show()
    End Sub

    Private Sub MenuItem89_Click(sender As Object, e As EventArgs) Handles MenuItem89.Click
        GmoduleName = "Bill Of Material (BOM)"
        Dim objStockSummary As New FRM_MKGA_BOM
        objStockSummary.MdiParent = Me
        objStockSummary.Show()
    End Sub

    Private Sub MenuItem90_Click(sender As Object, e As EventArgs) Handles MenuItem90.Click
        GmoduleName = "Profit Report"
        Dim objStockSummary As New Profit_Reports
        objStockSummary.MdiParent = Me
        objStockSummary.Show()
    End Sub

    Private Sub MenuItem91_Click(sender As Object, e As EventArgs) Handles MenuItem91.Click
        GmoduleName = "Month STB(BAR)"
        Dim objStockSummary As New ConsolidatedSTBReport
        objStockSummary.MdiParent = Me
        objStockSummary.Show()
    End Sub

    Private Sub MenuItem92_Click(sender As Object, e As EventArgs) 
        GmoduleName = "Messing Summary"
        Dim objStockSummary As New Messing_Summary
        objStockSummary.MdiParent = Me
        objStockSummary.Show()
    End Sub

    Private Sub MenuItem93_Click(sender As Object, e As EventArgs) Handles MenuItem93.Click
        GmoduleName = "BAR RATE REVISION"
        Dim objStockSummary As New bar_raterevision
        objStockSummary.MdiParent = Me
        objStockSummary.Show()
    End Sub
End Class
