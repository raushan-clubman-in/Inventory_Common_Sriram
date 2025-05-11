Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class InvPurchaseregister
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkItemCode As System.Windows.Forms.CheckBox
    Friend WithEvents ChkCategory As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSupplier As System.Windows.Forms.CheckBox
    Friend WithEvents CheckedListBox3 As System.Windows.Forms.CheckedListBox
    Friend WithEvents CheckedListBox2 As System.Windows.Forms.CheckedListBox
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dtptodate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfromdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_mainstorecode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmd_storecode As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Print As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents txt_mainstore As System.Windows.Forms.TextBox
    Friend WithEvents chkdetail As System.Windows.Forms.CheckBox
    Friend WithEvents chksummary As System.Windows.Forms.CheckBox
    Friend WithEvents ButExport As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbl_Itemlist As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cb_dateWise As System.Windows.Forms.CheckBox
    Friend WithEvents ChkLPR As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents chk_purchasereturn As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents chk_ven_sum As CheckBox
    Friend WithEvents chk_ven_det As CheckBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InvPurchaseregister))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cb_dateWise = New System.Windows.Forms.CheckBox()
        Me.ButExport = New System.Windows.Forms.Button()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmd_Print = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.chkdetail = New System.Windows.Forms.CheckBox()
        Me.chksummary = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl_Itemlist = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ChkItemCode = New System.Windows.Forms.CheckBox()
        Me.ChkCategory = New System.Windows.Forms.CheckBox()
        Me.ChkSupplier = New System.Windows.Forms.CheckBox()
        Me.CheckedListBox3 = New System.Windows.Forms.CheckedListBox()
        Me.CheckedListBox2 = New System.Windows.Forms.CheckedListBox()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ChkLPR = New System.Windows.Forms.CheckBox()
        Me.txt_mainstore = New System.Windows.Forms.TextBox()
        Me.cmd_storecode = New System.Windows.Forms.Button()
        Me.txt_mainstorecode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtptodate = New System.Windows.Forms.DateTimePicker()
        Me.dtpfromdate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.chk_purchasereturn = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.chk_ven_sum = New System.Windows.Forms.CheckBox()
        Me.chk_ven_det = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.cb_dateWise)
        Me.GroupBox1.Controls.Add(Me.ButExport)
        Me.GroupBox1.Controls.Add(Me.Cmd_Exit)
        Me.GroupBox1.Controls.Add(Me.Cmd_Print)
        Me.GroupBox1.Controls.Add(Me.Cmd_View)
        Me.GroupBox1.Controls.Add(Me.Cmd_Clear)
        Me.GroupBox1.Location = New System.Drawing.Point(680, 135)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(158, 296)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'cb_dateWise
        '
        Me.cb_dateWise.AutoSize = True
        Me.cb_dateWise.BackColor = System.Drawing.Color.Gray
        Me.cb_dateWise.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_dateWise.Location = New System.Drawing.Point(7, 268)
        Me.cb_dateWise.Name = "cb_dateWise"
        Me.cb_dateWise.Size = New System.Drawing.Size(136, 17)
        Me.cb_dateWise.TabIndex = 494
        Me.cb_dateWise.Text = "Order by GRN Date"
        Me.cb_dateWise.UseVisualStyleBackColor = False
        '
        'ButExport
        '
        Me.ButExport.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButExport.BackgroundImage = CType(resources.GetObject("ButExport.BackgroundImage"), System.Drawing.Image)
        Me.ButExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButExport.FlatAppearance.BorderSize = 0
        Me.ButExport.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.ButExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.ButExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.ButExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButExport.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButExport.ForeColor = System.Drawing.Color.Black
        Me.ButExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButExport.Location = New System.Drawing.Point(7, 158)
        Me.ButExport.Name = "ButExport"
        Me.ButExport.Size = New System.Drawing.Size(144, 46)
        Me.ButExport.TabIndex = 493
        Me.ButExport.Text = " Export[F12]"
        Me.ButExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButExport.UseVisualStyleBackColor = False
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Exit.BackgroundImage = CType(resources.GetObject("Cmd_Exit.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Exit.FlatAppearance.BorderSize = 0
        Me.Cmd_Exit.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(7, 207)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(144, 46)
        Me.Cmd_Exit.TabIndex = 490
        Me.Cmd_Exit.Text = "Exit[F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'Cmd_Print
        '
        Me.Cmd_Print.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Print.BackgroundImage = CType(resources.GetObject("Cmd_Print.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Print.FlatAppearance.BorderSize = 0
        Me.Cmd_Print.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Print.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Print.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Print.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Print.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Print.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Print.Location = New System.Drawing.Point(7, 109)
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(144, 46)
        Me.Cmd_Print.TabIndex = 489
        Me.Cmd_Print.Text = " Print [F10]"
        Me.Cmd_Print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Print.UseVisualStyleBackColor = False
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_View.BackgroundImage = CType(resources.GetObject("Cmd_View.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_View.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_View.FlatAppearance.BorderSize = 0
        Me.Cmd_View.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_View.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.Black
        Me.Cmd_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_View.Location = New System.Drawing.Point(7, 60)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(144, 46)
        Me.Cmd_View.TabIndex = 488
        Me.Cmd_View.Text = " View[F9]"
        Me.Cmd_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_View.UseVisualStyleBackColor = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Clear.BackgroundImage = CType(resources.GetObject("Cmd_Clear.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Clear.FlatAppearance.BorderSize = 0
        Me.Cmd_Clear.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(7, 11)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(144, 46)
        Me.Cmd_Clear.TabIndex = 487
        Me.Cmd_Clear.Text = "Clear[F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'chkdetail
        '
        Me.chkdetail.AutoSize = True
        Me.chkdetail.BackColor = System.Drawing.Color.Gray
        Me.chkdetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdetail.Location = New System.Drawing.Point(195, 87)
        Me.chkdetail.Name = "chkdetail"
        Me.chkdetail.Size = New System.Drawing.Size(70, 17)
        Me.chkdetail.TabIndex = 492
        Me.chkdetail.Text = "DETAIL"
        Me.chkdetail.UseVisualStyleBackColor = False
        '
        'chksummary
        '
        Me.chksummary.AutoSize = True
        Me.chksummary.BackColor = System.Drawing.Color.Gray
        Me.chksummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chksummary.Location = New System.Drawing.Point(105, 87)
        Me.chksummary.Name = "chksummary"
        Me.chksummary.Size = New System.Drawing.Size(88, 17)
        Me.chksummary.TabIndex = 491
        Me.chksummary.Text = "SUMMARY"
        Me.chksummary.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.PictureBox4)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.PictureBox3)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.lbl_Itemlist)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.ChkItemCode)
        Me.GroupBox2.Controls.Add(Me.ChkCategory)
        Me.GroupBox2.Controls.Add(Me.ChkSupplier)
        Me.GroupBox2.Controls.Add(Me.CheckedListBox3)
        Me.GroupBox2.Controls.Add(Me.CheckedListBox2)
        Me.GroupBox2.Controls.Add(Me.CheckedListBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(28, 119)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(642, 351)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Maroon
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(606, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 24)
        Me.Label10.TabIndex = 485
        Me.Label10.Text = "F1"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Maroon
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(580, 32)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox4.TabIndex = 484
        Me.PictureBox4.TabStop = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Maroon
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(380, 33)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 24)
        Me.Label9.TabIndex = 483
        Me.Label9.Text = "F2"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Maroon
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(359, 33)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox3.TabIndex = 482
        Me.PictureBox3.TabStop = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Maroon
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(176, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 24)
        Me.Label8.TabIndex = 481
        Me.Label8.Text = "F3"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Maroon
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(142, 34)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.TabIndex = 480
        Me.PictureBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Maroon
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(6, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(199, 24)
        Me.Label4.TabIndex = 479
        Me.Label4.Text = "SELECT SUPPLIER CODE :  "
        '
        'lbl_Itemlist
        '
        Me.lbl_Itemlist.BackColor = System.Drawing.Color.Maroon
        Me.lbl_Itemlist.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Itemlist.ForeColor = System.Drawing.Color.White
        Me.lbl_Itemlist.Location = New System.Drawing.Point(418, 32)
        Me.lbl_Itemlist.Name = "lbl_Itemlist"
        Me.lbl_Itemlist.Size = New System.Drawing.Size(200, 24)
        Me.lbl_Itemlist.TabIndex = 477
        Me.lbl_Itemlist.Text = "SELECT  ITEMCODE :"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Maroon
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(212, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(194, 24)
        Me.Label6.TabIndex = 478
        Me.Label6.Text = "SELECT GROUP CODE :"
        '
        'ChkItemCode
        '
        Me.ChkItemCode.AutoSize = True
        Me.ChkItemCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkItemCode.Location = New System.Drawing.Point(418, 16)
        Me.ChkItemCode.Name = "ChkItemCode"
        Me.ChkItemCode.Size = New System.Drawing.Size(90, 17)
        Me.ChkItemCode.TabIndex = 5
        Me.ChkItemCode.Text = "ITEMCODE"
        Me.ChkItemCode.UseVisualStyleBackColor = True
        '
        'ChkCategory
        '
        Me.ChkCategory.AutoSize = True
        Me.ChkCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkCategory.Location = New System.Drawing.Point(212, 16)
        Me.ChkCategory.Name = "ChkCategory"
        Me.ChkCategory.Size = New System.Drawing.Size(93, 17)
        Me.ChkCategory.TabIndex = 4
        Me.ChkCategory.Text = "CATEGORY"
        Me.ChkCategory.UseVisualStyleBackColor = True
        '
        'ChkSupplier
        '
        Me.ChkSupplier.AutoSize = True
        Me.ChkSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkSupplier.Location = New System.Drawing.Point(6, 16)
        Me.ChkSupplier.Name = "ChkSupplier"
        Me.ChkSupplier.Size = New System.Drawing.Size(126, 17)
        Me.ChkSupplier.TabIndex = 3
        Me.ChkSupplier.Text = "SUPPLIER NAME"
        Me.ChkSupplier.UseVisualStyleBackColor = True
        '
        'CheckedListBox3
        '
        Me.CheckedListBox3.CheckOnClick = True
        Me.CheckedListBox3.FormattingEnabled = True
        Me.CheckedListBox3.Location = New System.Drawing.Point(418, 62)
        Me.CheckedListBox3.Name = "CheckedListBox3"
        Me.CheckedListBox3.Size = New System.Drawing.Size(200, 274)
        Me.CheckedListBox3.TabIndex = 2
        '
        'CheckedListBox2
        '
        Me.CheckedListBox2.CheckOnClick = True
        Me.CheckedListBox2.FormattingEnabled = True
        Me.CheckedListBox2.Location = New System.Drawing.Point(212, 62)
        Me.CheckedListBox2.Name = "CheckedListBox2"
        Me.CheckedListBox2.Size = New System.Drawing.Size(200, 274)
        Me.CheckedListBox2.TabIndex = 1
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.CheckOnClick = True
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(6, 62)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(200, 274)
        Me.CheckedListBox1.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.CheckBox1)
        Me.GroupBox3.Controls.Add(Me.ChkLPR)
        Me.GroupBox3.Controls.Add(Me.txt_mainstore)
        Me.GroupBox3.Controls.Add(Me.chkdetail)
        Me.GroupBox3.Controls.Add(Me.cmd_storecode)
        Me.GroupBox3.Controls.Add(Me.chksummary)
        Me.GroupBox3.Controls.Add(Me.txt_mainstorecode)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.dtptodate)
        Me.GroupBox3.Controls.Add(Me.dtpfromdate)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(27, 476)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(643, 131)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.Gray
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(439, 87)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(92, 17)
        Me.CheckBox1.TabIndex = 494
        Me.CheckBox1.Text = "ITEM WISE"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'ChkLPR
        '
        Me.ChkLPR.AutoSize = True
        Me.ChkLPR.BackColor = System.Drawing.Color.Gray
        Me.ChkLPR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkLPR.Location = New System.Drawing.Point(269, 87)
        Me.ChkLPR.Name = "ChkLPR"
        Me.ChkLPR.Size = New System.Drawing.Size(165, 17)
        Me.ChkLPR.TabIndex = 493
        Me.ChkLPR.Text = "LAST PURCHASE RATE"
        Me.ChkLPR.UseVisualStyleBackColor = False
        '
        'txt_mainstore
        '
        Me.txt_mainstore.Location = New System.Drawing.Point(254, 14)
        Me.txt_mainstore.Name = "txt_mainstore"
        Me.txt_mainstore.Size = New System.Drawing.Size(159, 20)
        Me.txt_mainstore.TabIndex = 487
        '
        'cmd_storecode
        '
        Me.cmd_storecode.FlatAppearance.BorderSize = 0
        Me.cmd_storecode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmd_storecode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmd_storecode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_storecode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_storecode.Image = CType(resources.GetObject("cmd_storecode.Image"), System.Drawing.Image)
        Me.cmd_storecode.Location = New System.Drawing.Point(211, 12)
        Me.cmd_storecode.Name = "cmd_storecode"
        Me.cmd_storecode.Size = New System.Drawing.Size(24, 26)
        Me.cmd_storecode.TabIndex = 486
        '
        'txt_mainstorecode
        '
        Me.txt_mainstorecode.Location = New System.Drawing.Point(91, 15)
        Me.txt_mainstorecode.Name = "txt_mainstorecode"
        Me.txt_mainstorecode.Size = New System.Drawing.Size(117, 20)
        Me.txt_mainstorecode.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "STORE"
        '
        'dtptodate
        '
        Me.dtptodate.Location = New System.Drawing.Point(358, 43)
        Me.dtptodate.Name = "dtptodate"
        Me.dtptodate.Size = New System.Drawing.Size(200, 20)
        Me.dtptodate.TabIndex = 3
        '
        'dtpfromdate
        '
        Me.dtpfromdate.Location = New System.Drawing.Point(89, 43)
        Me.dtpfromdate.Name = "dtpfromdate"
        Me.dtpfromdate.Size = New System.Drawing.Size(200, 20)
        Me.dtpfromdate.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(295, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "TODATE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "FROM DATE"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(254, 21)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(241, 23)
        Me.Label16.TabIndex = 491
        Me.Label16.Text = "PURCHASE REGISTER"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chk_purchasereturn
        '
        Me.chk_purchasereturn.AutoSize = True
        Me.chk_purchasereturn.BackColor = System.Drawing.Color.Gray
        Me.chk_purchasereturn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_purchasereturn.Location = New System.Drawing.Point(687, 437)
        Me.chk_purchasereturn.Name = "chk_purchasereturn"
        Me.chk_purchasereturn.Size = New System.Drawing.Size(149, 17)
        Me.chk_purchasereturn.TabIndex = 495
        Me.chk_purchasereturn.Text = "PURCHASE RETURN"
        Me.chk_purchasereturn.UseVisualStyleBackColor = False
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.BackColor = System.Drawing.Color.Gray
        Me.CheckBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(687, 497)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(90, 17)
        Me.CheckBox2.TabIndex = 495
        Me.CheckBox2.Text = "MRP RATE"
        Me.CheckBox2.UseVisualStyleBackColor = False
        Me.CheckBox2.Visible = False
        '
        'chk_ven_sum
        '
        Me.chk_ven_sum.AutoSize = True
        Me.chk_ven_sum.BackColor = System.Drawing.Color.Gray
        Me.chk_ven_sum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_ven_sum.Location = New System.Drawing.Point(687, 468)
        Me.chk_ven_sum.Name = "chk_ven_sum"
        Me.chk_ven_sum.Size = New System.Drawing.Size(144, 17)
        Me.chk_ven_sum.TabIndex = 496
        Me.chk_ven_sum.Text = "VENDOR SUMMARY"
        Me.chk_ven_sum.UseVisualStyleBackColor = False
        '
        'chk_ven_det
        '
        Me.chk_ven_det.AutoSize = True
        Me.chk_ven_det.BackColor = System.Drawing.Color.Gray
        Me.chk_ven_det.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_ven_det.Location = New System.Drawing.Point(687, 524)
        Me.chk_ven_det.Name = "chk_ven_det"
        Me.chk_ven_det.Size = New System.Drawing.Size(134, 17)
        Me.chk_ven_det.TabIndex = 497
        Me.chk_ven_det.Text = "VENDOR DETAILS"
        Me.chk_ven_det.UseVisualStyleBackColor = False
        '
        'InvPurchaseregister
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(849, 614)
        Me.Controls.Add(Me.chk_ven_det)
        Me.Controls.Add(Me.chk_ven_sum)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.chk_purchasereturn)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "InvPurchaseregister"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORT [ PURCHASE REGISTER ]"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim gconnection As New GlobalClass
    Dim sqlstring As String
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
                        If Controls(i_i).Name = "GroupBox1" Then
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

    Private Sub Fillsuppliername()
        Dim i As Integer
        CheckedListBox1.Items.Clear()

        If UCase(gShortname) = "KGA" Then
            sqlstring = "SELECT DISTINCT ISNULL(VENDORCODE,'') AS SLCODE,ISNULL(VENDORNAME,'') AS SLNAME FROM PO_VIEW_VENDORMASTER  WHERE  VENDORCODE IN(select distinct suppliercode from grn_header where isnull(void,'')<>'Y') ORDER BY SLCODE"
        Else
            sqlstring = "SELECT DISTINCT ISNULL(SLCODE,'') AS SLCODE,ISNULL(SLNAME,'') AS SLNAME FROM ACCOUNTSSUBLEDGERMASTER  WHERE SLTYPE='SUPPLIER' and SLCODE IN(select distinct suppliercode from grn_header where isnull(void,'')<>'Y') ORDER BY SLCODE"
        End If


        gconnection.getDataSet(sqlstring, "SUBLEDGERMASTER")
        If gdataset.Tables("SUBLEDGERMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("SUBLEDGERMASTER").Rows.Count - 1
                With gdataset.Tables("SUBLEDGERMASTER").Rows(i)
                    CheckedListBox1.Items.Add(Trim(.Item("SLCODE")) & "-->" & Trim(.Item("SLNAME")))
                End With
            Next i
        End If
    End Sub
    Private Sub FillItemdetails()
        Dim i As Integer
        Dim sqlstring As String
        CheckedListBox3.Items.Clear()
        sqlstring = "SELECT DISTINCT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME FROM INV_InventoryItemMaster  ORDER BY ITEMCODE "
        gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER")
        If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("INVENTORYITEMMASTER").Rows.Count - 1
                With gdataset.Tables("INVENTORYITEMMASTER").Rows(i)
                    CheckedListBox3.Items.Add(Trim(CStr(.Item("ITEMCODE"))) & "-->" & Trim(CStr(.Item("ITEMNAME"))))
                End With
            Next
        End If
    End Sub
    Private Sub FillGroupdetails()
        Dim i As Integer
        Dim sqlstring As String
        CheckedListBox2.Items.Clear()
        sqlstring = "SELECT ISNULL(CATEGORYCODE,'') AS CATEGORYCODE,ISNULL(CATEGORYDESC,'') AS CATEGORYDESC FROM INVENTORYCATEGORYMASTER  where CATEGORYCODE in (select CATEGORYCODE from INV_INVENTORYITEMMASTER) ORDER BY CATEGORYCODE "
        gconnection.getDataSet(sqlstring, "INVENTORYGROUPMASTER")
        If gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1
                With gdataset.Tables("INVENTORYGROUPMASTER").Rows(i)
                    CheckedListBox2.Items.Add(Trim(CStr(.Item("CATEGORYCODE"))))
                End With
            Next
        End If
    End Sub

    Private Sub InvPurchaseregister_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.F6) Then
            clearoperation()
        ElseIf (e.KeyCode = Keys.F9) Then
            Cmd_View_Click(sender, e)
        ElseIf (e.KeyCode = Keys.F10) Then
            Cmd_Print_Click(sender, e)
        ElseIf (e.KeyCode = Keys.F11) Then
            Cmd_Exit_Click(sender, e)
        ElseIf (e.KeyCode = Keys.F12) Then
            ButExport_Click(sender, e)
        End If
    End Sub


    Private Sub InvPurchaseregister_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Fillsuppliername()
        FillItemdetails()
        FillGroupdetails()
        If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
            dtpfromdate.Value = Format(CDate("01/Jan/2016"), "dd/MMM/yyyy")
        ElseIf UCase(gShortname) = "RSAOI" Then
            dtpfromdate.Value = Format(CDate("01/Jan/" & gFinancalyearStart), "dd/MMM/yyyy")
        Else
            dtpfromdate.Value = Format(CDate("01/apr/" & gFinancalyearStart), "dd/MMM/yyyy")
        End If
        'dtpfromdate.Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MMM/yyyy")
        dtptodate.Value = Format(Now, "dd/MMM/yyyy")
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        '    If UCase(gShortname) = "KSCA" Then
        CheckBox2.Visible = True
        '    End If

        If gShortname = "SKYYE" Then
            chk_ven_sum.Visible = True
            chk_ven_det.Visible = True
        Else
            chk_ven_sum.Visible = False
            chk_ven_det.Visible = False
        End If

        If gShortname = "CCCR" Or gShortname = "JSCA" Then
            chk_ven_sum.Visible = True
            chk_ven_det.Visible = True

        End If


    End Sub

    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
    Sub clearoperation()
        ChkSupplier.Checked = False
        ChkItemCode.Checked = False
        ChkCategory.Checked = False
        txt_mainstore.Text = ""
        txt_mainstorecode.Text = ""
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        GmoduleName = "Purchase/Return  Register"
        Dim chstr As String
        GmoduleName = "Stock Summary"
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
        Me.Cmd_Print.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_View.Enabled = True
                    Me.Cmd_Print.Enabled = True
                    Exit Sub
                End If
                If Right(x) = "V" Then
                    Me.Cmd_View.Enabled = True
                End If
                If Right(x) = "P" Then
                    Me.Cmd_Print.Enabled = True
                End If
            Next
        End If
    End Sub


    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click


        clearoperation()
    End Sub

    Private Sub ChkCategory_CheckedChanged(sender As Object, e As EventArgs) Handles ChkCategory.CheckedChanged
        Dim i As Integer = 0

        If (ChkCategory.Checked = True) Then
            For i = 0 To CheckedListBox2.Items.Count - 1
                CheckedListBox2.SetItemChecked(i, True)
            Next

        Else
            For i = 0 To CheckedListBox2.Items.Count - 1
                CheckedListBox2.SetItemChecked(i, False)
            Next

        End If
        CheckedListBox2_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub ChkItemCode_CheckedChanged(sender As Object, e As EventArgs) Handles ChkItemCode.CheckedChanged
        Dim i As Integer = 0
        If (ChkItemCode.Checked = True) Then
            For i = 0 To CheckedListBox3.Items.Count - 1
                CheckedListBox3.SetItemChecked(i, True)
            Next

        Else
            For i = 0 To CheckedListBox3.Items.Count - 1
                CheckedListBox3.SetItemChecked(i, False)
            Next

        End If

    End Sub

    Private Sub ChkSupplier_CheckedChanged(sender As Object, e As EventArgs) Handles ChkSupplier.CheckedChanged
        Dim i As Integer = 0
        If (ChkSupplier.Checked = True) Then
            For i = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemChecked(i, True)
            Next

        Else
            For i = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemChecked(i, False)
            Next

        End If

    End Sub

    Private Sub cmd_storecode_Click(sender As Object, e As EventArgs) Handles cmd_storecode.Click
        gSQLString = "SELECT DISTINCT(storecode),storedesc FROM storemaster  "
        M_WhereCondition = " where freeze <> 'Y' and  storestatus='M' "
        Dim vform As New ListOperattion1

        vform.Field = "STOREDESC,STORECODE"
        vform.vFormatstring = "             STORE CODE                   |                   STORE DESCRIPTION                             "
        vform.vCaption = "INVENTORY STORE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_mainstorecode.Text = Trim(vform.keyfield & "")
            txt_mainstore.Text = Trim(vform.keyfield1 & "")
            dtpfromdate.Focus()
        End If
        vform.Close()
        vform = Nothing

    End Sub

    Private Sub txt_mainstorecode_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_mainstorecode.KeyDown
        If e.KeyCode = Keys.F4 Then
            Call cmd_storecode_Click(cmd_storecode, e)
        End If

    End Sub

    Private Sub txt_mainstorecode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_mainstorecode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_mainstorecode.Text) = "" Then
                Call cmd_storecode_Click(cmd_storecode, e)
            Else
                Call txt_mainstorecode_Validated(sender, e)
                dtpfromdate.Focus()
            End If
        End If

    End Sub

    Private Sub txt_mainstorecode_Validated(sender As Object, e As EventArgs) Handles txt_mainstorecode.Validated
        Try
            If Trim(txt_mainstorecode.Text) <> "" Then
                sqlstring = "SELECT * FROM storemaster WHERE storecode='" & Trim(txt_mainstorecode.Text) & "'"
                gconnection.getDataSet(sqlstring, "storemaster")
                If gdataset.Tables("storemaster").Rows.Count > 0 Then
                    txt_mainstorecode.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storecode"))
                    txt_mainstore.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storedesc"))
                    dtpfromdate.Focus()
                End If
            End If
        Catch
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
    Private Sub ViewLastPurchaseRate()
        Try
            Dim sqlstring, SUPPLIERNAME(), ITEMNAME() As String
            Dim i As Integer
            Dim r As New Rpt_LastPurchaseRate
            Dim rViewer As New Viewer

            Me.Cursor = Cursors.WaitCursor

            If txt_mainstorecode.Text <> "" Then

            Else
                MessageBox.Show("Select the Store code", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            sqlstring = " select   v.ITEMCODE, I.ITEMNAME,CAST(RATE*T.CONVVALUE AS NUMERIC(18,2)) AS RATE,GRNDATE,I.STOCKUOM AS UOM,i.void as voiditem,V.category from vw_purchaseregisterNew V  INNER JOIN INV_INVENTORYITEMMASTER I ON I.ITEMCODE=V.ITEMCODE INNER JOIN INVENTORY_TRANSCONVERSION T ON T.BASEUOM=I.STOCKUOM AND T.TRANSUOM= V.UOM  "
            If CheckedListBox1.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " where grnno+I.itemcode in (select max(grnno)+itemcode from vw_purchaseregisterNew where  CAST(CONVERT(VARCHAR(11),GRNDATE ,106) AS DATETIME) <='" & Format(dtptodate.Value, "dd/MMM/yyyy") & "' group by itemcode) and  isnull(V.void,'N')<>'Y'  and  isnull(voiditem,'N')<>'Y'  and  SUPPLIERCODE IN ("
                For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                    SUPPLIERNAME = Split(CheckedListBox1.CheckedItems(i), "-->")
                    sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If CheckedListBox3.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " AND v.ITEMCODE IN ("
                For i = 0 To CheckedListBox3.CheckedItems.Count - 1
                    ITEMNAME = Split(CheckedListBox3.CheckedItems(i), "-->")
                    sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            sqlstring = sqlstring & " AND storecode = '" & Trim(txt_mainstorecode.Text) & "' AND ISNULL(GRNTYPE,'') = 'GRN' "
            sqlstring = sqlstring & " AND CAST(CONVERT(VARCHAR(11),GRNDATE ,106) AS DATETIME) BETWEEN"
            sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'  group by v.itemcode, I.itemname,rate,grndate,uom ,T.CONVVALUE,STOCKUOM,i.void,V.category    "
            If cb_dateWise.Checked = True Then
                sqlstring = sqlstring & " order by v.itemcode"
            Else
                sqlstring = sqlstring & " order by v.itemcode"
            End If
            Me.Cursor = Cursors.WaitCursor
            gconnection.getDataSet(sqlstring, "vw_purchaseregisterNew")
            If gdataset.Tables("vw_purchaseregisterNew").Rows.Count > 0 Then
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "vw_purchaseregisterNew"

                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text13")
                'COMPANY NAME
                textobj1.Text = MyCompanyName
                rViewer.Show()
            Else
                MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub ViewMRPRate()
        Try
            Dim sqlstring, SUPPLIERNAME(), ITEMNAME() As String
            Dim i As Integer
            Dim r As New Rpt_MRPRATE
            Dim rViewer As New Viewer

            Me.Cursor = Cursors.WaitCursor

            'If txt_mainstorecode.Text <> "" Then

            'Else
            '    MessageBox.Show("Select the Store code", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Exit Sub
            'End If
            sqlstring = " SELECT distinct ITEMCODE,ITEMNAME,STOCKUOM,MRPRATE,purcahserate,category,HHRate FROM VW_MRPRATE WHERE MRPRATE>0  "

            sqlstring = sqlstring & " AND CAST(CONVERT(VARCHAR(11),GRNDATE ,106) AS DATETIME) BETWEEN"
            sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'"


            'If CheckedListBox1.CheckedItems.Count <> 0 Then
            '    sqlstring = sqlstring & " where grnno+I.itemcode In (Select max(grnno)+itemcode from vw_purchaseregisterNew where  CAST(CONVERT(VARCHAR(11),GRNDATE ,106) As DATETIME) <='" & Format(dtptodate.Value, "dd/MMM/yyyy") & "' group by itemcode) and  isnull(V.void,'N')<>'Y'  and  isnull(voiditem,'N')<>'Y'  and  SUPPLIERCODE IN ("
            '    For i = 0 To CheckedListBox1.CheckedItems.Count - 1
            '        SUPPLIERNAME = Split(CheckedListBox1.CheckedItems(i), "-->")
            '        sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
            '    Next
            '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            '    sqlstring = sqlstring & ")"
            'Else
            '    MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Exit Sub
            'End If
            If CheckedListBox3.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " AND ITEMCODE IN ("
                For i = 0 To CheckedListBox3.CheckedItems.Count - 1
                    ITEMNAME = Split(CheckedListBox3.CheckedItems(i), "-->")
                    sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If


            '

            If cb_dateWise.Checked = True Then
                sqlstring = sqlstring & " order by itemcode"
            Else
                sqlstring = sqlstring & " order by itemcode"
            End If
            Me.Cursor = Cursors.WaitCursor
            gconnection.getDataSet(sqlstring, "VW_MRPRATE")
            If gdataset.Tables("VW_MRPRATE").Rows.Count > 0 Then
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "VW_MRPRATE"

                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text13")
                'COMPANY NAME
                textobj1.Text = MyCompanyName
                rViewer.Show()
            Else
                MsgBox("NO RECORDS To DISPLAY", MsgBoxStyle.OkOnly)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub Cmd_View_Click(sender As Object, e As EventArgs) Handles Cmd_View.Click
        If (chksummary.Checked = True) Or (chkdetail.Checked = True) Or (ChkLPR.Checked = True) Or (CheckBox1.Checked = True) Or (chk_purchasereturn.Checked = True) Or (CheckBox2.Checked = True) Or (chk_ven_sum.Checked = True) Or (chk_ven_det.Checked = True) Then
            Checkdaterangevalidate(Format(dtpfromdate.Value, "dd/MM/yyyy"), Format(dtptodate.Value, "dd/MMM/yyyy"))
            If chkdatevalidate = False Then Exit Sub
            Dim str As String
            'If gShortname <> "SKYYE" Or gShortname <> "BBSR" Then
            '    str = "ALTER VIEW [dbo].[VW_PURCHASEREGISTERNew] as SELECT       dbo.Grn_details.grnno, dbo.Grn_details.grndetails,     dbo.Grn_details.grndate, dbo.Grn_details.pono, isnull(dbo.GRN_HEADER.Supplierinvno,'') as Supplierinvno, dbo.Grn_details.Suppliercode,    dbo.Grn_details.Suppliername,    dbo.Grn_details.Itemcode, dbo.Grn_details.Itemname, dbo.Grn_details.uom, Grn_details.qty, dbo.Grn_details.rate,    dbo.Grn_details.baseamount, dbo.Grn_details.discper, dbo.Grn_details.taxper, dbo.Grn_details.Discount, dbo.Grn_details.taxamount, Grn_details.amount,     dbo.Grn_details.taxcode, dbo.Grn_details.batchno, dbo.Grn_details.othcharge, dbo.Grn_details.Voiditem, dbo.Grn_details.category,     dbo.Grn_details.storecode,dbo.Grn_details.storedesc, dbo.Grn_details.versionno, dbo.Grn_details.grntype,dbo.Grn_details.amount as amountafterdiscount,     dbo.Grn_header.Totalamount, dbo.GRN_DETAILS.taxamount as VATamount,GRN_header.Surchargeamt  as Surchargeamt, dbo.Grn_header.OverallDiscount, dbo.GRN_DETAILS.Discount AS totdiscount,    dbo.Grn_header.Billamount,  dbo.Grn_header.Remarks, dbo.Grn_header.Void, dbo.Grn_header.updateuser, dbo.Grn_header.updatedate, dbo.Grn_header.voiduser,     dbo.Grn_header.voiddate  ,'' as opstorelocationcode,'' as opstorelocationname  ,  isnull(dbo.Grn_header.Supplierdate,'') as Supplierdate  ,ISNULL(dbo.Grn_details.SPONSORCODE,'') AS SPONSORCODE FROM  dbo.Grn_details INNER JOIN      dbo.Grn_header ON dbo.Grn_details.grndetails = dbo.Grn_header.grndetails   "
            '    gconnection.dataOperation(6, str, "AddC")
            'End If
            


            If ChkLPR.Checked = True Then
                ViewLastPurchaseRate()
            ElseIf chk_ven_sum.Checked = True Then
                vendorsummary()

            ElseIf CheckBox1.Checked = True Then
                ViewPurchaseRegisterGST_KGA()
            ElseIf CheckBox2.Checked = True Then
                ViewMRPRate()
            ElseIf chk_purchasereturn.Checked = True Then
                ViewPurchasereturn()
            Else

                If GSTSTARTdATE <= dtpfromdate.Value Then
                    ViewPurchaseRegisterGST()
                Else
                    ViewPurchaseRegister()
                End If

            End If


        Else
            MessageBox.Show("Select Any Option", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub

        End If

    End Sub

    Private Sub CheckedListBox2_Click(sender As Object, e As EventArgs) Handles CheckedListBox2.Click
        Dim i, J As Integer
        Dim sqlstring, ssql As String
        ssql = ""
        sqlstring = "Select DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INV_INVENTORYITEMMASTER AS I "
        sqlstring = sqlstring & " WHERE isnull(VOID,'') <> 'Y' and I.CATEGORY IN ("

        For J = 0 To CheckedListBox2.CheckedItems.Count - 1
            If J = CheckedListBox2.CheckedItems.Count - 1 Then
                ssql = ssql & " '" & CheckedListBox2.CheckedItems(J) & "' "
            Else
                ssql = ssql & " '" & CheckedListBox2.CheckedItems(J) & "', "
            End If
        Next
        If CheckedListBox2.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & ") ORDER BY ITEMCODE "
            gconnection.getDataSet(sqlstring, "INVENTORYSUBGROUPMASTER")
            If gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count > 0 Then
                CheckedListBox3.Items.Clear()
                For i = 0 To gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count - 1
                    With gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows(i)
                        CheckedListBox3.Items.Add(Trim(.Item("ITEMCODE") & "-->" & .Item("ITEMNAME")))
                    End With
                Next i
            End If
        End If

    End Sub

    Private Sub CheckedListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox2.SelectedIndexChanged
        Dim i, J As Integer
        Dim sqlstring, ssql As String
        ssql = ""
        sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INV_INVENTORYITEMMASTER AS I "
        sqlstring = sqlstring & " WHERE isnull(VOID,'') <> 'Y' and I.CATEGORY IN ("

        For J = 0 To CheckedListBox2.CheckedItems.Count - 1
            If J = CheckedListBox2.CheckedItems.Count - 1 Then
                ssql = ssql & " '" & CheckedListBox2.CheckedItems(J) & "' "
            Else
                ssql = ssql & " '" & CheckedListBox2.CheckedItems(J) & "', "
            End If
        Next
        If CheckedListBox2.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & ") ORDER BY ITEMCODE "
            gconnection.getDataSet(sqlstring, "INVENTORYSUBGROUPMASTER")
            If gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count > 0 Then
                CheckedListBox3.Items.Clear()
                For i = 0 To gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count - 1
                    With gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows(i)
                        CheckedListBox3.Items.Add(Trim(.Item("ITEMCODE") & "-->" & .Item("ITEMNAME")))
                    End With
                Next i
            End If
        Else
            CheckedListBox3.Items.Clear()

        End If

    End Sub
    Private Sub vendorsummary()
        Dim sqlstring, SUPPLIERNAME(), ITEMNAME() As String
        Dim i As Integer
        Dim r As New CryVendorSummary
        Dim rViewer As New Viewer

        Me.Cursor = Cursors.WaitCursor

        If txt_mainstorecode.Text <> "" Then

        Else
            MessageBox.Show("Select the Store code", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        If chk_ven_sum.Checked = True Then

            sqlstring = " select suppliercode,suppliername,sum(baseamount)as baseamount,sum(vatamount)as vatamount,sum(surchargeamt)as surchargeamt,sum(overalldiscount)as overalldiscount,sum(billamount)as billamount from vendorsummary  where isnull(void,'')<>'Y'  "

            If CheckedListBox1.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & "  and SUPPLIERCODE IN ("
                For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                    SUPPLIERNAME = Split(CheckedListBox1.CheckedItems(i), "-->")
                    sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            sqlstring = sqlstring & " AND storecode = '" & Trim(txt_mainstorecode.Text) & "' AND ISNULL(GRNTYPE,'') = 'GRN' "
            sqlstring = sqlstring & " AND CAST(CONVERT(VARCHAR(11),GRNDATE ,106) AS DATETIME) BETWEEN"
            sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "'  group by Suppliercode,Suppliername  "
            If cb_dateWise.Checked = True Then
                sqlstring = sqlstring & " order by grndate"
            Else
                sqlstring = sqlstring & " order by Suppliername"
            End If
            Me.Cursor = Cursors.WaitCursor
            gconnection.getDataSet(sqlstring, "vendorsummary")
            If gdataset.Tables("vendorsummary").Rows.Count > 0 Then
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "vendorsummary"
                'COMPANY NAME
                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text12")
                textobj1.Text = MyCompanyName
                ' ADDRESS
                Dim textobj5 As TextObject
                textobj5 = r.ReportDefinition.ReportObjects("Text15")
                textobj5.Text = UCase(Address1)
                Dim textobj6 As TextObject
                textobj6 = r.ReportDefinition.ReportObjects("Text16")
                textobj6.Text = UCase(Address2)
                'STORENAME
                Dim textobj2 As TextObject
                textobj2 = r.ReportDefinition.ReportObjects("Text13")
                textobj2.Text = Trim(txt_mainstore.Text)
                Dim textobj16 As TextObject
                textobj16 = r.ReportDefinition.ReportObjects("Text6")
                textobj16.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                Dim TXTOBJ3 As TextObject
                TXTOBJ3 = r.ReportDefinition.ReportObjects("Text20")
                TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MMM/yyyy") & "  To " & " " & Format(dtptodate.Value, "dd/MMM/yyyy") & ""

                rViewer.Show()
                Me.Cursor = Cursors.Default

            Else
                MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
            End If

        End If

    End Sub
    Private Sub ViewPurchaseRegister()
        Try
            Dim sqlstring, SUPPLIERNAME(), ITEMNAME() As String
            Dim i As Integer
            Dim r As New CryPurchaseregister
            Dim rViewer As New Viewer

            Me.Cursor = Cursors.WaitCursor

            If txt_mainstorecode.Text <> "" Then

            Else
                MessageBox.Show("Select the Store code", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If


            If chksummary.Checked = True Then
                ' If gShortname = "MBC" Then
                sqlstring = " select distinct  grndetails , grndate,pono ,Supplierinvno, suppliercode , suppliername , sum(baseamount) as totalamount  , sum(vatamount) as vatamount ,sum(surchargeamt) as surchargeamt  , sum(totdiscount) as totdiscount  , billamount, OVERALLDISCOUNT  from vw_purchaseregisterNew "
                    'Else
                    '    sqlstring = " select distinct  grndetails , grndate,pono ,Supplierinvno, suppliercode , suppliername , sum(baseamount) as totalamount  , sum(vatamount) as vatamount , surchargeamt , totdiscount , billamount,OVERALLDISCOUNT  from vw_purchaseregisterNew "
                    'End If

                    If CheckedListBox1.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " WHERE isnull(void,'N')<>'Y'  and SUPPLIERCODE IN ("
                    For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                        SUPPLIERNAME = Split(CheckedListBox1.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If CheckedListBox3.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " AND ITEMCODE IN ("
                    For i = 0 To CheckedListBox3.CheckedItems.Count - 1
                        ITEMNAME = Split(CheckedListBox3.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                sqlstring = sqlstring & " AND storecode = '" & Trim(txt_mainstorecode.Text) & "' AND ISNULL(GRNTYPE,'') = 'GRN' "
                sqlstring = sqlstring & " AND CAST(CONVERT(VARCHAR(11),GRNDATE ,106) AS DATETIME) BETWEEN"

                ' If gShortname = "MBC" Then
                sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "' group by grndetails , grndate,pono ,Supplierinvno, suppliercode , suppliername , billamount,OVERALLDISCOUNT "
                'Else
                '    sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "' group by grndetails , grndate,pono ,Supplierinvno, suppliercode , suppliername ,  vatamount , surchargeamt , totdiscount , billamount,OVERALLDISCOUNT "
                '  End If

                If cb_dateWise.Checked = True Then
                    sqlstring = sqlstring & " order by grndate"
                Else
                    sqlstring = sqlstring & " order by grndetails"
                End If
                Me.Cursor = Cursors.WaitCursor
                gconnection.getDataSet(sqlstring, "viewpurchaseregistersummary")
                If gdataset.Tables("viewpurchaseregistersummary").Rows.Count > 0 Then
                    rViewer.ssql = sqlstring
                    rViewer.Report = r
                    rViewer.TableName = "PURCHASEREGISTER"
                    'COMPANY NAME
                    Dim textobj1 As TextObject
                    textobj1 = r.ReportDefinition.ReportObjects("Text12")
                    textobj1.Text = MyCompanyName
                    ' ADDRESS
                    Dim textobj5 As TextObject
                    textobj5 = r.ReportDefinition.ReportObjects("Text15")
                    textobj5.Text = UCase(Address1)
                    Dim textobj6 As TextObject
                    textobj6 = r.ReportDefinition.ReportObjects("Text16")
                    textobj6.Text = UCase(Address2)
                    'STORENAME
                    Dim textobj2 As TextObject
                    textobj2 = r.ReportDefinition.ReportObjects("Text13")
                    textobj2.Text = Trim(txt_mainstore.Text)
                    Dim textobj16 As TextObject
                    textobj16 = r.ReportDefinition.ReportObjects("Text6")
                    textobj16.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                    Dim TXTOBJ3 As TextObject
                    TXTOBJ3 = r.ReportDefinition.ReportObjects("Text20")
                    TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MMM/yyyy") & "  To " & " " & Format(dtptodate.Value, "dd/MMM/yyyy") & ""

                    rViewer.Show()
                    Me.Cursor = Cursors.Default

                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                End If



            ElseIf chkdetail.Checked = True Then
                Dim s As New CryPurchaseRegisterDetail
                Dim sViewer As New Viewer

                sqlstring = " select grndetails,grndate,pono,Supplierinvno,Suppliercode,Suppliername,Itemcode,Itemname,uom ,sum(qty) as qty,rate,sum(baseamount) as baseamount,"
                sqlstring = sqlstring & "discper,taxper,SUM(Discount) as Discount,sum(taxamount) as taxamount,sum(amount) as amount,taxcode,batchno,sum(othcharge) as othcharge, isnull(voiditem,'N') as voiditem"
                sqlstring = sqlstring & " ,category,storecode,storedesc,versionno,grntype,sum(amountafterdiscount) as amountafterdiscount,Totalamount,VATamount,Surchargeamt,OverallDiscount,"
                sqlstring = sqlstring & " totdiscount,Billamount,Void,Supplierdate  from vw_purchaseregisterNew "
                If CheckedListBox1.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " WHERE isnull(void,'N')<>'Y'  and  SUPPLIERCODE IN ("
                    For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                        SUPPLIERNAME = Split(CheckedListBox1.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                If CheckedListBox3.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " AND ITEMCODE IN ("
                    For i = 0 To CheckedListBox3.CheckedItems.Count - 1
                        ITEMNAME = Split(CheckedListBox3.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                sqlstring = sqlstring & " AND storecode = '" & Trim(txt_mainstorecode.Text) & "' AND ISNULL(GRNTYPE,'') = 'GRN' "
                sqlstring = sqlstring & " AND CAST(CONVERT(VARCHAR(11),GRNDATE ,106) AS DATETIME) BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "' group by "

                sqlstring = sqlstring & " grndetails,grndate,pono,Supplierinvno,Suppliercode,Suppliername,Itemcode,Itemname,uom ,rate,"
                sqlstring = sqlstring & " discper,taxper,taxcode,batchno, voiditem ,category,storecode,storedesc,versionno,grntype,Totalamount,VATamount,Surchargeamt,OverallDiscount,"
                sqlstring = sqlstring & " totdiscount,Billamount,Void,Supplierdate  "
                If cb_dateWise.Checked = True Then
                    sqlstring = sqlstring & " order by grndate,grndetails"
                Else
                    sqlstring = sqlstring & " order by grndetails,grndate"
                End If
                Me.Cursor = Cursors.WaitCursor
                gconnection.getDataSet(sqlstring, "vw_purchaseregister")
                If gdataset.Tables("vw_purchaseregister").Rows.Count > 0 Then
                    sViewer.ssql = sqlstring
                    sViewer.Report = s
                    sViewer.TableName = "vw_purchaseregister"
                    'COMPANY NAME
                    Dim textobj1 As TextObject
                    textobj1 = s.ReportDefinition.ReportObjects("Text12")
                    textobj1.Text = MyCompanyName
                    ' ADDRESS
                    'Dim textobj5 As TextObject
                    'textobj5 = r.ReportDefinition.ReportObjects("Text15")
                    'textobj5.Text = UCase(gCompanyAddress(0))
                    Dim textobj6 As TextObject
                    textobj6 = s.ReportDefinition.ReportObjects("Text16")
                    textobj6.Text = UCase(Address1)
                    'STORENAME
                    Dim textobj2 As TextObject
                    textobj2 = s.ReportDefinition.ReportObjects("Text23")
                    textobj2.Text = Trim(txt_mainstore.Text)
                    'financial year
                    Dim txt As TextObject
                    txt = s.ReportDefinition.ReportObjects("Text28")
                    txt.Text = gFinancalyearStart + " to " + gFinancialyearEnd
                    'period
                    Dim TXTOBJ3 As TextObject
                    TXTOBJ3 = s.ReportDefinition.ReportObjects("Text23")
                    TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""

                    sViewer.Show()
                    Me.Cursor = Cursors.Default

                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                    Me.Cursor = Cursors.Default
                End If



            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub ViewPurchasereturn()
        Try
            Dim sqlstring, SUPPLIERNAME(), ITEMNAME() As String
            Dim i As Integer
            Dim r As New CryPurchaseRETURN
            Dim rViewer As New Viewer
            Me.Cursor = Cursors.WaitCursor
            If txt_mainstorecode.Text <> "" Then
            Else
                MessageBox.Show("Select the Store code", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If chk_purchasereturn.Checked = True Then
                sqlstring = " select GRNDETAILS,prndetails,PRNDATE,pono,Supplierinvno,Suppliercode,Suppliername,Itemcode,Itemname,uom ,sum(qty) as qty,rate,sum(baseamount) as baseamount,"
                sqlstring = sqlstring & "discper,taxper,SUM(Discount) as Discount,sum(taxamount) as taxamount,sum(amount) as amount,taxcode,batchno,sum(othcharge) as othcharge, isnull(voiditem,'N') as voiditem"
                sqlstring = sqlstring & " ,category,storecode,storedesc,versionno,grntype,sum(amountafterdiscount) as amountafterdiscount,Totalamount,VATamount,Surchargeamt,OverallDiscount,"
                sqlstring = sqlstring & " totdiscount,Billamount,Void,Supplierdate  from VW_PURCHASERETURN "
                If CheckedListBox1.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " WHERE isnull(void,'N')<>'Y' and  isnull(voiditem,'N')<>'Y'  and  SUPPLIERCODE IN ("
                    For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                        SUPPLIERNAME = Split(CheckedListBox1.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                If CheckedListBox3.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " AND ITEMCODE IN ("
                    For i = 0 To CheckedListBox3.CheckedItems.Count - 1
                        ITEMNAME = Split(CheckedListBox3.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                sqlstring = sqlstring & " AND storecode = '" & Trim(txt_mainstorecode.Text) & "' AND ISNULL(GRNTYPE,'') = 'PRN' "
                sqlstring = sqlstring & " AND CAST(CONVERT(VARCHAR(11),PRNDATE ,106) AS DATETIME) BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "' group by "

                sqlstring = sqlstring & " GRNDETAILS,PRNDETAILS,PRNDATE,pono,Supplierinvno,Suppliercode,Suppliername,Itemcode,Itemname,uom ,rate,"
                sqlstring = sqlstring & " discper,taxper,taxcode,batchno, voiditem ,category,storecode,storedesc,versionno,grntype,Totalamount,VATamount,Surchargeamt,OverallDiscount,"
                sqlstring = sqlstring & " totdiscount,Billamount,Void,Supplierdate "
                If cb_dateWise.Checked = True Then
                    sqlstring = sqlstring & " order by PRNDATE"
                Else
                    sqlstring = sqlstring & " order by ITEMCODE"
                End If
                Me.Cursor = Cursors.WaitCursor
                gconnection.getDataSet(sqlstring, "PURCHASERETURN")
                If gdataset.Tables("PURCHASERETURN").Rows.Count > 0 Then
                    rViewer.ssql = sqlstring
                    rViewer.Report = r
                    'Call Viewer.GetDetails1(sqlstring, "kot_hdr", r)
                    'Viewer.TableName = "kot_hdr"
                    rViewer.TableName = "PURCHASERETURN"
                    'COMPANY NAME
                    Dim textobj1 As TextObject
                    textobj1 = r.ReportDefinition.ReportObjects("Text12")
                    textobj1.Text = MyCompanyName
                    ' ADDRESS
                    Dim textobj5 As TextObject
                    textobj5 = r.ReportDefinition.ReportObjects("Text15")
                    textobj5.Text = UCase(Address1)
                    Dim textobj6 As TextObject
                    textobj6 = r.ReportDefinition.ReportObjects("Text16")
                    textobj6.Text = UCase(Address2)
                    'STORENAME
                    'Dim textobj2 As TextObject
                    'textobj2 = r.ReportDefinition.ReportObjects("Text19")
                    'textobj2.Text = Trim(txt_mainstore.Text)
                    Dim textobj16 As TextObject
                    textobj16 = r.ReportDefinition.ReportObjects("Text28")
                    textobj16.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                    Dim TXTOBJ3 As TextObject
                    TXTOBJ3 = r.ReportDefinition.ReportObjects("Text23")
                    TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MMM/yyyy") & "  To " & " " & Format(dtptodate.Value, "dd/MMM/yyyy") & ""

                    rViewer.Show()
                    Me.Cursor = Cursors.Default

                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub ViewPurchaseRegisterGST_KGA()
        Try
            Dim sqlstring, SUPPLIERNAME(), ITEMNAME() As String
            Dim i As Integer
            Dim r As New CryPurchaseRegisterDetailGST_KGA
            Dim rViewer As New Viewer
            Me.Cursor = Cursors.WaitCursor
            If txt_mainstorecode.Text <> "" Then
            Else
                MessageBox.Show("Select the Store code", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If



            If CheckBox1.Checked = True Then

                sqlstring = " SELECT ITEMCODE,ITEMNAME,UOM,SUM(QTY) AS QTY,RATE,SUM(AMOUNT) AS AMOUNT,SUM(GST) AS GST,SUM(TOTAL)AS TOTAL,SUM(DISCOUNT)AS DISCOUNT,SUM(othercharge) AS othercharge,Groupdesc FROM vw_kga_purchase "
                If CheckedListBox1.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " WHERE   SUPPLIERCODE IN ("
                    For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                        SUPPLIERNAME = Split(CheckedListBox1.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If CheckedListBox3.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " AND ITEMCODE IN ("
                    For i = 0 To CheckedListBox3.CheckedItems.Count - 1
                        ITEMNAME = Split(CheckedListBox3.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                sqlstring = sqlstring & " AND storecode = '" & Trim(txt_mainstorecode.Text) & "' "
                sqlstring = sqlstring & " AND CAST(CONVERT(VARCHAR(11),GRNDATE ,106) AS DATETIME) BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "' GROUP  BY   ITEMCODE,ITEMNAME,UOM,Groupdesc,RATE "
                'If cb_dateWise.Checked = True Then
                '    sqlstring = sqlstring & " order by grndate"
                'Else
                '    sqlstring = sqlstring & " order by ITEMCODE"
                'End If
                Me.Cursor = Cursors.WaitCursor
                gconnection.getDataSet(sqlstring, "vw_kga_purchase")
                If gdataset.Tables("vw_kga_purchase").Rows.Count > 0 Then
                    rViewer.ssql = sqlstring
                    rViewer.Report = r
                    'Call Viewer.GetDetails1(sqlstring, "kot_hdr", r)
                    'Viewer.TableName = "kot_hdr"
                    rViewer.TableName = "vw_kga_purchase"
                    'COMPANY NAME
                    Dim textobj1 As TextObject
                    textobj1 = r.ReportDefinition.ReportObjects("Text12")
                    textobj1.Text = MyCompanyName
                    ' ADDRESS
                    Dim textobj5 As TextObject
                    textobj5 = r.ReportDefinition.ReportObjects("Text15")
                    textobj5.Text = UCase(Address1)
                    Dim textobj6 As TextObject
                    textobj6 = r.ReportDefinition.ReportObjects("Text16")
                    textobj6.Text = UCase(Address2)
                    'STORENAME
                    Dim textobj2 As TextObject
                    textobj2 = r.ReportDefinition.ReportObjects("Text19")
                    textobj2.Text = Trim(txt_mainstore.Text)
                    Dim textobj16 As TextObject
                    textobj16 = r.ReportDefinition.ReportObjects("Text28")
                    textobj16.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                    Dim TXTOBJ3 As TextObject
                    TXTOBJ3 = r.ReportDefinition.ReportObjects("Text23")
                    TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MMM/yyyy") & "  To " & " " & Format(dtptodate.Value, "dd/MMM/yyyy") & ""

                    rViewer.Show()
                    Me.Cursor = Cursors.Default

                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub ViewPurchaseRegisterGST()
        Try
            Dim sqlstring, SUPPLIERNAME(), ITEMNAME() As String
            Dim i As Integer
            Dim r As New CryPurchaseregisterGST
            Dim rViewer As New Viewer

            Me.Cursor = Cursors.WaitCursor

            If txt_mainstorecode.Text <> "" Then

            Else
                MessageBox.Show("Select the Store code", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If



            If chksummary.Checked = True Then
                'If gShortname = "MBC" Then
                sqlstring = " select distinct  grndetails , grndate,pono ,Supplierinvno, suppliercode , suppliername , sum(baseamount) as totalamount  , sum(vatamount) as vatamount , surchargeamt as surchargeamt  , sum(totdiscount) as totdiscount  , billamount,OVERALLDISCOUNT   from vw_purchaseregisterNew "
                    'Else
                    '    sqlstring = " select distinct  grndetails , grndate,pono ,Supplierinvno, suppliercode , suppliername , sum(baseamount) as totalamount  , sum(vatamount) as vatamount , surchargeamt , totdiscount , billamount,OVERALLDISCOUNT  from vw_purchaseregisterNew "
                    'End If

                    If CheckedListBox1.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " WHERE isnull(void,'N')<>'Y'  and  isnull(voiditem,'N')<>'Y'  and  SUPPLIERCODE IN ("
                        For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                            SUPPLIERNAME = Split(CheckedListBox1.CheckedItems(i), "-->")
                            sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                    If CheckedListBox3.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " AND ITEMCODE IN ("
                        For i = 0 To CheckedListBox3.CheckedItems.Count - 1
                            ITEMNAME = Split(CheckedListBox3.CheckedItems(i), "-->")
                            sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                    sqlstring = sqlstring & " AND storecode = '" & Trim(txt_mainstorecode.Text) & "' AND ISNULL(GRNTYPE,'') = 'GRN' "
                sqlstring = sqlstring & " AND CAST(CONVERT(VARCHAR(11),GRNDATE ,106) AS DATETIME) BETWEEN"

                '  If gShortname = "MBC" Then
                sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "' group by grndetails , grndate,pono ,Supplierinvno, suppliercode , suppliername , billamount,OVERALLDISCOUNT,surchargeamt "
                    'Else
                    '    sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "' group by grndetails , grndate,pono ,Supplierinvno, suppliercode , suppliername ,  vatamount , surchargeamt , totdiscount , billamount,OVERALLDISCOUNT "
                    'End If

                    If cb_dateWise.Checked = True Then
                        sqlstring = sqlstring & " order by grndate"
                    Else
                        sqlstring = sqlstring & " order by grndetails"
                    End If
                    Me.Cursor = Cursors.WaitCursor
                    gconnection.getDataSet(sqlstring, "viewpurchaseregistersummary")
                    If gdataset.Tables("viewpurchaseregistersummary").Rows.Count > 0 Then
                        rViewer.ssql = sqlstring
                        rViewer.Report = r
                        rViewer.TableName = "PURCHASEREGISTER"
                        'COMPANY NAME
                        Dim textobj1 As TextObject
                        textobj1 = r.ReportDefinition.ReportObjects("Text12")
                        textobj1.Text = MyCompanyName
                        ' ADDRESS
                        Dim textobj5 As TextObject
                        textobj5 = r.ReportDefinition.ReportObjects("Text15")
                        textobj5.Text = UCase(Address1)
                        Dim textobj6 As TextObject
                        textobj6 = r.ReportDefinition.ReportObjects("Text16")
                        textobj6.Text = UCase(Address2)
                        'STORENAME
                        Dim textobj2 As TextObject
                        textobj2 = r.ReportDefinition.ReportObjects("Text13")
                        textobj2.Text = Trim(txt_mainstore.Text)
                        Dim textobj16 As TextObject
                        textobj16 = r.ReportDefinition.ReportObjects("Text6")
                        textobj16.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                        Dim TXTOBJ3 As TextObject
                        TXTOBJ3 = r.ReportDefinition.ReportObjects("Text20")
                        TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MMM/yyyy") & "  To " & " " & Format(dtptodate.Value, "dd/MMM/yyyy") & ""

                        rViewer.Show()
                        Me.Cursor = Cursors.Default

                    Else
                        MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                    End If



                ElseIf chkdetail.Checked = True Then
                    Dim s As New CryPurchaseRegisterDetailGST
                Dim sViewer As New Viewer

                sqlstring = " select grndetails,grndate,pono,Supplierinvno,Suppliercode,Suppliername,Itemcode,Itemname,uom ,sum(qty) as qty,rate,sum(baseamount) as baseamount,"
                sqlstring = sqlstring & "discper,taxper,SUM(Discount) as Discount,sum(taxamount) as taxamount,sum(amount) as amount,taxcode,batchno,sum(othcharge) as othcharge, isnull(voiditem,'N') as voiditem"
                sqlstring = sqlstring & " ,category,storecode,storedesc,versionno,grntype,sum(amountafterdiscount) as amountafterdiscount,Totalamount,VATamount,Surchargeamt,OverallDiscount,"
                sqlstring = sqlstring & " totdiscount,Billamount,Void,Supplierdate  from vw_purchaseregisterNew "
                If CheckedListBox1.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " WHERE isnull(void,'N')<>'Y' and  isnull(voiditem,'N')<>'Y'  and  SUPPLIERCODE IN ("
                    For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                        SUPPLIERNAME = Split(CheckedListBox1.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                If CheckedListBox3.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " AND ITEMCODE IN ("
                    For i = 0 To CheckedListBox3.CheckedItems.Count - 1
                        ITEMNAME = Split(CheckedListBox3.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                sqlstring = sqlstring & " AND storecode = '" & Trim(txt_mainstorecode.Text) & "' AND ISNULL(GRNTYPE,'') = 'GRN' "
                sqlstring = sqlstring & " AND CAST(CONVERT(VARCHAR(11),GRNDATE ,106) AS DATETIME) BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "' group by "

                sqlstring = sqlstring & " grndetails,grndate,pono,Supplierinvno,Suppliercode,Suppliername,Itemcode,Itemname,uom ,rate,"
                sqlstring = sqlstring & " discper,taxper,taxcode,batchno, voiditem ,category,storecode,storedesc,versionno,grntype,Totalamount,VATamount,Surchargeamt,OverallDiscount,"
                sqlstring = sqlstring & " totdiscount,Billamount,Void,Supplierdate "
                If cb_dateWise.Checked = True Then
                    sqlstring = sqlstring & "  order by grndate,grndetails "
                Else
                    sqlstring = sqlstring & "  order by grndetails,grndate "
                End If
                Me.Cursor = Cursors.WaitCursor
                gconnection.getDataSet(sqlstring, "vw_purchaseregister")
                If gdataset.Tables("vw_purchaseregister").Rows.Count > 0 Then
                    sViewer.ssql = sqlstring
                    sViewer.Report = s
                    sViewer.TableName = "vw_purchaseregister"
                    'COMPANY NAME
                    Dim textobj1 As TextObject
                    textobj1 = s.ReportDefinition.ReportObjects("Text12")
                    textobj1.Text = MyCompanyName
                    ' ADDRESS
                    'Dim textobj5 As TextObject
                    'textobj5 = r.ReportDefinition.ReportObjects("Text15")
                    'textobj5.Text = UCase(gCompanyAddress(0))
                    Dim textobj6 As TextObject
                    textobj6 = s.ReportDefinition.ReportObjects("Text16")
                    textobj6.Text = UCase(Address1)
                    'STORENAME
                    Dim textobj2 As TextObject
                    textobj2 = s.ReportDefinition.ReportObjects("Text23")
                    textobj2.Text = Trim(txt_mainstore.Text)
                    'financial year
                    Dim txt As TextObject
                    txt = s.ReportDefinition.ReportObjects("Text28")
                    txt.Text = gFinancalyearStart + " to " + gFinancialyearEnd
                    'period
                    Dim TXTOBJ3 As TextObject
                    TXTOBJ3 = s.ReportDefinition.ReportObjects("Text23")
                    TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""

                    sViewer.Show()
                    Me.Cursor = Cursors.Default

                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                    Me.Cursor = Cursors.Default
                End If



            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub chksummary_CheckedChanged(sender As Object, e As EventArgs) Handles chksummary.CheckedChanged
        If (chksummary.Checked = True) Then
            chkdetail.Checked = False
            ChkLPR.Checked = False
            CheckBox1.Checked = False
        End If
    End Sub

    Private Sub chkdetail_CheckedChanged(sender As Object, e As EventArgs) Handles chkdetail.CheckedChanged
        If (chkdetail.Checked = True) Then
            chksummary.Checked = False
            ChkLPR.Checked = False
            CheckBox1.Checked = False
        End If
    End Sub

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        If (chksummary.Checked = True) Or (chkdetail.Checked = True) Then
            Checkdaterangevalidate(Format(dtpfromdate.Value, "dd/MM/yyyy"), Format(dtptodate.Value, "dd/MMM/yyyy"))
            If chkdatevalidate = False Then Exit Sub
            ViewPurchaseRegister()
        Else
            MessageBox.Show("Select Purchase Summary or Detail Option", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
    End Sub

    Private Sub ButExport_Click(sender As Object, e As EventArgs) Handles ButExport.Click
        Dim sqlstring, SUPPLIERNAME(), ITEMNAME() As String
        Dim i As Integer

        If txt_mainstorecode.Text <> "" Then

        Else
            MessageBox.Show("Select the Store code", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Try
            If Trim(UCase(gShortname)) = "HG" Then
                If chkdetail.Checked = True Then
                    sqlstring = " select DISTINCT grndetails,grndate,pono,Supplierinvno,Suppliercode,Suppliername,Itemcode,Itemname,uom ,sum(qty) as qty,rate,sum(baseamount) as baseamount,"
                    sqlstring = sqlstring & "discper,taxper,SUM(Discount) as Discount,sum(taxamount) as taxamount,sum(amount) as amount"
                    sqlstring = sqlstring & "  from vw_purchaseregisterNew "
                    If CheckedListBox1.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " WHERE isnull(void,'N')<>'Y'  and  SUPPLIERCODE IN ("
                        For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                            SUPPLIERNAME = Split(CheckedListBox1.CheckedItems(i), "-->")
                            sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    If CheckedListBox3.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " AND ITEMCODE IN ("
                        For i = 0 To CheckedListBox3.CheckedItems.Count - 1
                            ITEMNAME = Split(CheckedListBox3.CheckedItems(i), "-->")
                            sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    sqlstring = sqlstring & " AND storecode = '" & Trim(txt_mainstorecode.Text) & "' AND ISNULL(GRNTYPE,'') = 'GRN' "
                    sqlstring = sqlstring & " AND CAST(CONVERT(VARCHAR(11),GRNDATE ,106) AS DATETIME) BETWEEN"
                    sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "' group by "

                    sqlstring = sqlstring & " grndetails,grndate,pono,Supplierinvno,Suppliercode,Suppliername,Itemcode,Itemname,uom ,rate,"
                    sqlstring = sqlstring & " discper,taxper,taxcode,batchno, voiditem ,category,storecode,storedesc,versionno,grntype,Totalamount,VATamount,Surchargeamt,OverallDiscount,"
                    sqlstring = sqlstring & " totdiscount,Billamount,Void,Supplierdate"
                    Me.Cursor = Cursors.WaitCursor
                    gconnection.getDataSet(sqlstring, "vw_purchaseregisterNew")
                    If gdataset.Tables("vw_purchaseregisterNew").Rows.Count > 0 Then
                        Me.Cursor = Cursors.Default
                        Dim exp As New exportexcel
                        exp.Show()
                        Call exp.export(sqlstring, "Purchase Summary " & Format(dtpfromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtptodate.Value, "dd-MMM-yyyy"), "")

                    Else
                        MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                        Me.Cursor = Cursors.Default
                    End If



                End If
            End If


            If chksummary.Checked = True Then

                sqlstring = " select distinct  grndetails , grndate,pono ,Supplierinvno, suppliercode , suppliername , sum(baseamount) as totalamount  , vatamount , surchargeamt , totdiscount , billamount,OVERALLDISCOUNT  from vw_purchaseregisterNew "
                If CheckedListBox1.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " WHERE isnull(void,'N')<>'Y'  and SUPPLIERCODE IN ("
                    For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                        SUPPLIERNAME = Split(CheckedListBox1.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If CheckedListBox3.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " AND ITEMCODE IN ("
                    For i = 0 To CheckedListBox3.CheckedItems.Count - 1
                        ITEMNAME = Split(CheckedListBox3.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                sqlstring = sqlstring & " AND storecode = '" & Trim(txt_mainstorecode.Text) & "' AND ISNULL(GRNTYPE,'') = 'GRN' "
                sqlstring = sqlstring & " AND CAST(CONVERT(VARCHAR(11),GRNDATE ,106) AS DATETIME) BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "' group by grndetails , grndate,pono ,Supplierinvno, suppliercode , suppliername ,  vatamount , surchargeamt , totdiscount , billamount,OVERALLDISCOUNT "
                Me.Cursor = Cursors.WaitCursor
                gconnection.getDataSet(sqlstring, "viewpurchaseregistersummary")
                If gdataset.Tables("viewpurchaseregistersummary").Rows.Count > 0 Then
                    Me.Cursor = Cursors.Default
                    Dim exp As New exportexcel
                    exp.Show()
                    Call exp.export(sqlstring, "Purchase Summary " & Format(dtpfromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtptodate.Value, "dd-MMM-yyyy"), "")

                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                End If
            ElseIf CheckBox1.Checked = True Then
                sqlstring = " SELECT ITEMCODE,ITEMNAME,UOM,SUM(QTY) AS QTY,RATE,SUM(AMOUNT) AS AMOUNT,SUM(GST) AS GST,SUM(TOTAL)AS TOTAL,SUM(DISCOUNT)AS DISCOUNT,SUM(othercharge) AS othercharge,Groupdesc FROM vw_kga_purchase "
                If CheckedListBox1.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " WHERE   SUPPLIERCODE IN ("
                    For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                        SUPPLIERNAME = Split(CheckedListBox1.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If CheckedListBox3.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " AND ITEMCODE IN ("
                    For i = 0 To CheckedListBox3.CheckedItems.Count - 1
                        ITEMNAME = Split(CheckedListBox3.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                sqlstring = sqlstring & " AND storecode = '" & Trim(txt_mainstorecode.Text) & "' "
                sqlstring = sqlstring & " AND CAST(CONVERT(VARCHAR(11),GRNDATE ,106) AS DATETIME) BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "' GROUP  BY   ITEMCODE,ITEMNAME,UOM,Groupdesc,RATE "
                'If cb_dateWise.Checked = True Then
                '    sqlstring = sqlstring & " order by grndate"
                'Else
                '    sqlstring = sqlstring & " order by ITEMCODE"
                'End If
                Me.Cursor = Cursors.WaitCursor
                gconnection.getDataSet(sqlstring, "vw_kga_purchase")
                If gdataset.Tables("vw_kga_purchase").Rows.Count > 0 Then
                    Me.Cursor = Cursors.Default
                    Dim exp As New exportexcel
                    exp.Show()
                    Call exp.export(sqlstring, "Item Wise Purchase Summary " & Format(dtpfromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtptodate.Value, "dd-MMM-yyyy"), "")

                    Me.Cursor = Cursors.Default

                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                End If



            ElseIf chk_ven_det.Checked = True Then

                Dim Str As String = "If EXISTS( Select * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'invWITHDETAILS') Begin DROP TABLE invWITHDETAILS End"
                gconnection.dataOperation(6, Str, "AddC")

                sqlstring = " exec TAXDETAILS_INVENTORY '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "'"
                gconnection.ExcuteStoreProcedure(sqlstring)

                If gShortname = "SKYYE" Then
                    sqlstring = "SELECT BILLDATE,INVOICENO,BILLNO,VENDORNAME,BILLVALUE,PURCHASE,[CGST 2.5%],[SGST 2.5%],[CGST @ 6 %],[SGST @ 6 %],[CGST @ 9 %],[SGST @ 9 %],[CGST @ 14 %],[SGST @ 14 %],[CESS @ 12 %],[CESS@36%],SPLCESS,[TCS @ 1%],ROUNDOFF,TOTAL FROM invwithdetails "
                ElseIf gShortname = "JSCA" Or gShortname = "CCCR" Then
                    sqlstring = "SELECT BILLDATE,INVOICENO,BILLNO,VENDORNAME,BILLVALUE,PURCHASE,[INPUT TAX SGST @ 9 %],[INPUT TAX CGST @ 9 %],[INPUT TAX SGST @ 6 %],[INPUT TAX CGST @ 6 %],[INPUT TAX SGST @ 2.5 %],[INPUT TAX CGST @ 2.5 %],[TCS@1%],ROUNDOFF,TOTAL FROM invwithdetails "
                Else
                    sqlstring = "SELECT BILLDATE,INVOICENO,BILLNO,VENDORNAME,BILLVALUE,PURCHASE,[PREVILAGE TAX 25.5],[IGST18],[VAT 14.5],[INPUT TAX CGST @ 14%],[INPUT TAX SGST @ 14%],[INPUT TAX CGST @ 9%],[INPUT TAX SGST @ 9%],[INPUT TAX CGST @ 6%],[INPUT TAX SGST @ 6%],[INPUT TAX CGST @ 2.5],[INPUT TAX SGST @ 2.5],SPLCESS,ROUNDOFF,TOTAL FROM invwithdetails "
                End If


                If CheckedListBox1.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " WHERE   SUPPLIERCODE IN ("
                    For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                        SUPPLIERNAME = Split(CheckedListBox1.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                sqlstring = sqlstring & " AND storecode = '" & Trim(txt_mainstorecode.Text) & "' "
                sqlstring = sqlstring & " AND CAST(CONVERT(VARCHAR(11),billdate ,106) AS DATETIME) BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "' "
                Me.Cursor = Cursors.WaitCursor
                gconnection.getDataSet(sqlstring, "vendordetail")
                If gdataset.Tables("vendordetail").Rows.Count > 0 Then
                    Me.Cursor = Cursors.Default
                    Dim exp As New exportexcel
                    exp.Show()
                    Call exp.export(sqlstring, "VENDOR DETAILS " & Format(dtpfromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtptodate.Value, "dd-MMM-yyyy"), "")

                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                    Me.Cursor = Cursors.Default
                End If

            ElseIf chkdetail.Checked = True Then
                sqlstring = " select grndetails,grndate,pono,Supplierinvno,Suppliercode,Suppliername,Itemcode,Itemname,uom ,sum(qty) as qty,rate,sum(baseamount) as baseamount,"
                sqlstring = sqlstring & "discper,taxper,SUM(Discount) as Discount,sum(taxamount) as taxamount,sum(amount) as amount,taxcode,batchno,sum(othcharge) as othcharge, isnull(voiditem,'N') as voiditem"
                sqlstring = sqlstring & " ,category,storecode,storedesc,versionno,grntype,sum(amountafterdiscount) as amountafterdiscount,Totalamount,VATamount,Surchargeamt,OverallDiscount,"
                sqlstring = sqlstring & " totdiscount,Billamount,Void,Supplierdate  from vw_purchaseregisterNew "
                If CheckedListBox1.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " WHERE isnull(void,'N')<>'Y'  and  SUPPLIERCODE IN ("
                    For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                        SUPPLIERNAME = Split(CheckedListBox1.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                If CheckedListBox3.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " AND ITEMCODE IN ("
                    For i = 0 To CheckedListBox3.CheckedItems.Count - 1
                        ITEMNAME = Split(CheckedListBox3.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                sqlstring = sqlstring & " AND storecode = '" & Trim(txt_mainstorecode.Text) & "' AND ISNULL(GRNTYPE,'') = 'GRN' "
                sqlstring = sqlstring & " AND CAST(CONVERT(VARCHAR(11),GRNDATE ,106) AS DATETIME) BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "' group by "

                sqlstring = sqlstring & " grndetails,grndate,pono,Supplierinvno,Suppliercode,Suppliername,Itemcode,Itemname,uom ,rate,"
                sqlstring = sqlstring & " discper,taxper,taxcode,batchno, voiditem ,category,storecode,storedesc,versionno,grntype,Totalamount,VATamount,Surchargeamt,OverallDiscount,"
                sqlstring = sqlstring & " totdiscount,Billamount,Void,Supplierdate"
                Me.Cursor = Cursors.WaitCursor
                gconnection.getDataSet(sqlstring, "vw_purchaseregisterNew")
                If gdataset.Tables("vw_purchaseregisterNew").Rows.Count > 0 Then
                    Me.Cursor = Cursors.Default
                    Dim exp As New exportexcel
                    exp.Show()
                    Call exp.export(sqlstring, "Purchase Summary " & Format(dtpfromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtptodate.Value, "dd-MMM-yyyy"), "")

                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                    Me.Cursor = Cursors.Default
                End If



            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try

    End Sub

    Private Sub CheckedListBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckedListBox3.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim Advsearch As New frmListSearch
            Advsearch.listbox = CheckedListBox3
            Advsearch.Text = "Item Search"
            Advsearch.ShowDialog(Me)
        End If
    End Sub

    Private Sub CheckedListBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckedListBox1.KeyDown
        If e.KeyCode = Keys.F3 Then
            Dim Advsearch As New frmListSearch
            Advsearch.listbox = CheckedListBox1
            Advsearch.Text = "Supplier Code Search"
            Advsearch.ShowDialog(Me)
        End If
    End Sub

    Private Sub CheckedListBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckedListBox2.KeyDown
        If e.KeyCode = Keys.F2 Then
            Dim search As New frmListSearch
            search.listbox = CheckedListBox2
            search.Text = "Category Search"
            search.ShowDialog(Me)
        End If
    End Sub
    Private Sub ChkLPR_CheckedChanged(sender As Object, e As EventArgs) Handles ChkLPR.CheckedChanged
        If (ChkLPR.Checked = True) Then
            chksummary.Checked = False
            chkdetail.Checked = False
            CheckBox1.Checked = False
        End If
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If (CheckBox1.Checked = True) Then
            ChkLPR.Checked = False
            chkdetail.Checked = False
            chksummary.Checked = False
        End If
    End Sub


End Class
