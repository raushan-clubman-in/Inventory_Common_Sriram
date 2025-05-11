<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InvStockSummaryGroupCosting
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InvStockSummaryGroupCosting))
        Me.ChkItemCode = New System.Windows.Forms.CheckBox()
        Me.ChkCategory = New System.Windows.Forms.CheckBox()
        Me.CheckedListBox3 = New System.Windows.Forms.CheckedListBox()
        Me.CheckedListBox2 = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lbl_GroupList = New System.Windows.Forms.Label()
        Me.Chk_SelectAllGroup = New System.Windows.Forms.CheckBox()
        Me.Chklist_Groupdesc = New System.Windows.Forms.CheckedListBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbl_Itemlist = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CHKEXPORT = New System.Windows.Forms.CheckBox()
        Me.ClosingOnly = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.DTPaSondATE = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.txt_mainstore = New System.Windows.Forms.TextBox()
        Me.cmd_storecode = New System.Windows.Forms.Button()
        Me.txt_mainstorecode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtptodate = New System.Windows.Forms.DateTimePicker()
        Me.dtpfromdate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ButExport = New System.Windows.Forms.Button()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmd_Print = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.ChBZero = New System.Windows.Forms.CheckBox()
        Me.CHK_SUM = New System.Windows.Forms.CheckBox()
        Me.CkExices = New System.Windows.Forms.CheckBox()
        Me.chkdetail = New System.Windows.Forms.CheckBox()
        Me.chksummary = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ChK_WITHOUTVALUE = New System.Windows.Forms.CheckBox()
        Me.CHK_EXCISE_SUMM = New System.Windows.Forms.CheckBox()
        Me.chk_overall = New System.Windows.Forms.CheckBox()
        Me.CHK_WITHOUT_ZERO = New System.Windows.Forms.CheckBox()
        Me.Chk_Ledger = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ChkItemCode
        '
        Me.ChkItemCode.AutoSize = True
        Me.ChkItemCode.Location = New System.Drawing.Point(644, 18)
        Me.ChkItemCode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ChkItemCode.Name = "ChkItemCode"
        Me.ChkItemCode.Size = New System.Drawing.Size(119, 24)
        Me.ChkItemCode.TabIndex = 10
        Me.ChkItemCode.Text = "ITEMCODE"
        Me.ChkItemCode.UseVisualStyleBackColor = True
        '
        'ChkCategory
        '
        Me.ChkCategory.AutoSize = True
        Me.ChkCategory.Location = New System.Drawing.Point(14, 18)
        Me.ChkCategory.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ChkCategory.Name = "ChkCategory"
        Me.ChkCategory.Size = New System.Drawing.Size(125, 24)
        Me.ChkCategory.TabIndex = 9
        Me.ChkCategory.Text = "CATEGORY"
        Me.ChkCategory.UseVisualStyleBackColor = True
        '
        'CheckedListBox3
        '
        Me.CheckedListBox3.CheckOnClick = True
        Me.CheckedListBox3.FormattingEnabled = True
        Me.CheckedListBox3.Location = New System.Drawing.Point(644, 86)
        Me.CheckedListBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckedListBox3.Name = "CheckedListBox3"
        Me.CheckedListBox3.Size = New System.Drawing.Size(298, 403)
        Me.CheckedListBox3.TabIndex = 8
        '
        'CheckedListBox2
        '
        Me.CheckedListBox2.CheckOnClick = True
        Me.CheckedListBox2.FormattingEnabled = True
        Me.CheckedListBox2.Location = New System.Drawing.Point(14, 86)
        Me.CheckedListBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckedListBox2.Name = "CheckedListBox2"
        Me.CheckedListBox2.Size = New System.Drawing.Size(298, 403)
        Me.CheckedListBox2.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.lbl_GroupList)
        Me.GroupBox1.Controls.Add(Me.Chk_SelectAllGroup)
        Me.GroupBox1.Controls.Add(Me.Chklist_Groupdesc)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.PictureBox4)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.PictureBox3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lbl_Itemlist)
        Me.GroupBox1.Controls.Add(Me.ChkItemCode)
        Me.GroupBox1.Controls.Add(Me.ChkCategory)
        Me.GroupBox1.Controls.Add(Me.CheckedListBox3)
        Me.GroupBox1.Controls.Add(Me.CheckedListBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(63, 186)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(963, 540)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Maroon
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(570, 48)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 37)
        Me.Label4.TabIndex = 516
        Me.Label4.Text = "F3"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Maroon
        Me.PictureBox1.Location = New System.Drawing.Point(525, 46)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(36, 37)
        Me.PictureBox1.TabIndex = 515
        Me.PictureBox1.TabStop = False
        '
        'lbl_GroupList
        '
        Me.lbl_GroupList.BackColor = System.Drawing.Color.Maroon
        Me.lbl_GroupList.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_GroupList.ForeColor = System.Drawing.Color.White
        Me.lbl_GroupList.Location = New System.Drawing.Point(326, 46)
        Me.lbl_GroupList.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_GroupList.Name = "lbl_GroupList"
        Me.lbl_GroupList.Size = New System.Drawing.Size(296, 37)
        Me.lbl_GroupList.TabIndex = 514
        Me.lbl_GroupList.Text = "SELECT GROUPCODE :"
        '
        'Chk_SelectAllGroup
        '
        Me.Chk_SelectAllGroup.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllGroup.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllGroup.Location = New System.Drawing.Point(328, 12)
        Me.Chk_SelectAllGroup.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Chk_SelectAllGroup.Name = "Chk_SelectAllGroup"
        Me.Chk_SelectAllGroup.Size = New System.Drawing.Size(252, 37)
        Me.Chk_SelectAllGroup.TabIndex = 512
        Me.Chk_SelectAllGroup.Text = "GROUP"
        Me.Chk_SelectAllGroup.UseVisualStyleBackColor = False
        '
        'Chklist_Groupdesc
        '
        Me.Chklist_Groupdesc.CheckOnClick = True
        Me.Chklist_Groupdesc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chklist_Groupdesc.Location = New System.Drawing.Point(326, 83)
        Me.Chklist_Groupdesc.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Chklist_Groupdesc.Name = "Chklist_Groupdesc"
        Me.Chklist_Groupdesc.Size = New System.Drawing.Size(292, 403)
        Me.Chklist_Groupdesc.TabIndex = 513
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Maroon
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(891, 51)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 38)
        Me.Label10.TabIndex = 511
        Me.Label10.Text = "F1"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Maroon
        Me.PictureBox4.Location = New System.Drawing.Point(858, 51)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(36, 37)
        Me.PictureBox4.TabIndex = 510
        Me.PictureBox4.TabStop = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Maroon
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(261, 49)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 37)
        Me.Label9.TabIndex = 509
        Me.Label9.Text = "F2"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Maroon
        Me.PictureBox3.Location = New System.Drawing.Point(225, 49)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(36, 37)
        Me.PictureBox3.TabIndex = 508
        Me.PictureBox3.TabStop = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Maroon
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(12, 51)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(297, 37)
        Me.Label6.TabIndex = 504
        Me.Label6.Text = "SELECT CATEGORY :"
        '
        'lbl_Itemlist
        '
        Me.lbl_Itemlist.BackColor = System.Drawing.Color.Maroon
        Me.lbl_Itemlist.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Itemlist.ForeColor = System.Drawing.Color.White
        Me.lbl_Itemlist.Location = New System.Drawing.Point(644, 49)
        Me.lbl_Itemlist.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Itemlist.Name = "lbl_Itemlist"
        Me.lbl_Itemlist.Size = New System.Drawing.Size(300, 37)
        Me.lbl_Itemlist.TabIndex = 503
        Me.lbl_Itemlist.Text = "SELECT  ITEMCODE :"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.CHKEXPORT)
        Me.GroupBox3.Controls.Add(Me.ClosingOnly)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.CheckBox1)
        Me.GroupBox3.Controls.Add(Me.txt_mainstore)
        Me.GroupBox3.Controls.Add(Me.cmd_storecode)
        Me.GroupBox3.Controls.Add(Me.txt_mainstorecode)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.dtptodate)
        Me.GroupBox3.Controls.Add(Me.dtpfromdate)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(63, 735)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Size = New System.Drawing.Size(939, 171)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        '
        'CHKEXPORT
        '
        Me.CHKEXPORT.AutoSize = True
        Me.CHKEXPORT.Location = New System.Drawing.Point(736, 58)
        Me.CHKEXPORT.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CHKEXPORT.Name = "CHKEXPORT"
        Me.CHKEXPORT.Size = New System.Drawing.Size(141, 24)
        Me.CHKEXPORT.TabIndex = 496
        Me.CHKEXPORT.Text = "TO DAY ONLY"
        Me.CHKEXPORT.UseVisualStyleBackColor = True
        '
        'ClosingOnly
        '
        Me.ClosingOnly.AutoSize = True
        Me.ClosingOnly.Location = New System.Drawing.Point(736, 25)
        Me.ClosingOnly.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ClosingOnly.Name = "ClosingOnly"
        Me.ClosingOnly.Size = New System.Drawing.Size(154, 24)
        Me.ClosingOnly.TabIndex = 494
        Me.ClosingOnly.Text = "ONLY CLOSING"
        Me.ClosingOnly.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.DTPaSondATE)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Location = New System.Drawing.Point(4, 88)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox4.Size = New System.Drawing.Size(939, 83)
        Me.GroupBox4.TabIndex = 496
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Visible = False
        '
        'DTPaSondATE
        '
        Me.DTPaSondATE.CustomFormat = "dd/MMM/yyyy"
        Me.DTPaSondATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPaSondATE.Location = New System.Drawing.Point(368, 28)
        Me.DTPaSondATE.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DTPaSondATE.Name = "DTPaSondATE"
        Me.DTPaSondATE.Size = New System.Drawing.Size(298, 26)
        Me.DTPaSondATE.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(273, 34)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 20)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "DATE"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(14, 66)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(131, 24)
        Me.CheckBox1.TabIndex = 495
        Me.CheckBox1.Text = "AS ON DATE"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'txt_mainstore
        '
        Me.txt_mainstore.Location = New System.Drawing.Point(344, 22)
        Me.txt_mainstore.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txt_mainstore.Name = "txt_mainstore"
        Me.txt_mainstore.Size = New System.Drawing.Size(193, 26)
        Me.txt_mainstore.TabIndex = 487
        '
        'cmd_storecode
        '
        Me.cmd_storecode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_storecode.Image = CType(resources.GetObject("cmd_storecode.Image"), System.Drawing.Image)
        Me.cmd_storecode.Location = New System.Drawing.Point(306, 17)
        Me.cmd_storecode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmd_storecode.Name = "cmd_storecode"
        Me.cmd_storecode.Size = New System.Drawing.Size(36, 40)
        Me.cmd_storecode.TabIndex = 486
        '
        'txt_mainstorecode
        '
        Me.txt_mainstorecode.Location = New System.Drawing.Point(136, 23)
        Me.txt_mainstorecode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txt_mainstorecode.Name = "txt_mainstorecode"
        Me.txt_mainstorecode.Size = New System.Drawing.Size(174, 26)
        Me.txt_mainstorecode.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 26)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "STORE"
        '
        'dtptodate
        '
        Me.dtptodate.CustomFormat = "dd/MM/yyyy"
        Me.dtptodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtptodate.Location = New System.Drawing.Point(537, 94)
        Me.dtptodate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtptodate.Name = "dtptodate"
        Me.dtptodate.Size = New System.Drawing.Size(298, 26)
        Me.dtptodate.TabIndex = 3
        '
        'dtpfromdate
        '
        Me.dtpfromdate.CustomFormat = "dd/MM/yyyy"
        Me.dtpfromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpfromdate.Location = New System.Drawing.Point(134, 94)
        Me.dtpfromdate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtpfromdate.Name = "dtpfromdate"
        Me.dtpfromdate.Size = New System.Drawing.Size(298, 26)
        Me.dtpfromdate.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(442, 100)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "TODATE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 100)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "FROM DATE"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.ButExport)
        Me.GroupBox2.Controls.Add(Me.Cmd_Exit)
        Me.GroupBox2.Controls.Add(Me.Cmd_Print)
        Me.GroupBox2.Controls.Add(Me.Cmd_View)
        Me.GroupBox2.Controls.Add(Me.Cmd_Clear)
        Me.GroupBox2.Location = New System.Drawing.Point(1053, 186)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(231, 412)
        Me.GroupBox2.TabIndex = 488
        Me.GroupBox2.TabStop = False
        '
        'ButExport
        '
        Me.ButExport.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButExport.FlatAppearance.BorderSize = 0
        Me.ButExport.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.ButExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.ButExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.ButExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButExport.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButExport.ForeColor = System.Drawing.Color.Black
        Me.ButExport.Image = CType(resources.GetObject("ButExport.Image"), System.Drawing.Image)
        Me.ButExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButExport.Location = New System.Drawing.Point(9, 246)
        Me.ButExport.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ButExport.Name = "ButExport"
        Me.ButExport.Size = New System.Drawing.Size(216, 71)
        Me.ButExport.TabIndex = 493
        Me.ButExport.Text = "Export[F12]"
        Me.ButExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButExport.UseVisualStyleBackColor = False
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Exit.FlatAppearance.BorderSize = 0
        Me.Cmd_Exit.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(9, 322)
        Me.Cmd_Exit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(216, 71)
        Me.Cmd_Exit.TabIndex = 490
        Me.Cmd_Exit.Text = "Exit[F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'Cmd_Print
        '
        Me.Cmd_Print.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Print.FlatAppearance.BorderSize = 0
        Me.Cmd_Print.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Print.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Print.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Print.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Print.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Print.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Print.Image = CType(resources.GetObject("Cmd_Print.Image"), System.Drawing.Image)
        Me.Cmd_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Print.Location = New System.Drawing.Point(9, 171)
        Me.Cmd_Print.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(216, 71)
        Me.Cmd_Print.TabIndex = 489
        Me.Cmd_Print.Text = " Print [F10]"
        Me.Cmd_Print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Print.UseVisualStyleBackColor = False
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_View.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_View.FlatAppearance.BorderSize = 0
        Me.Cmd_View.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_View.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.Black
        Me.Cmd_View.Image = CType(resources.GetObject("Cmd_View.Image"), System.Drawing.Image)
        Me.Cmd_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_View.Location = New System.Drawing.Point(9, 95)
        Me.Cmd_View.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(216, 71)
        Me.Cmd_View.TabIndex = 488
        Me.Cmd_View.Text = " View[F9]"
        Me.Cmd_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_View.UseVisualStyleBackColor = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Clear.FlatAppearance.BorderSize = 0
        Me.Cmd_Clear.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(9, 20)
        Me.Cmd_Clear.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(216, 71)
        Me.Cmd_Clear.TabIndex = 487
        Me.Cmd_Clear.Text = "Clear[F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'ChBZero
        '
        Me.ChBZero.AutoSize = True
        Me.ChBZero.Location = New System.Drawing.Point(1054, 754)
        Me.ChBZero.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ChBZero.Name = "ChBZero"
        Me.ChBZero.Size = New System.Drawing.Size(165, 24)
        Me.ChBZero.TabIndex = 495
        Me.ChBZero.Text = "WITH ZERO QTY."
        Me.ChBZero.UseVisualStyleBackColor = True
        '
        'CHK_SUM
        '
        Me.CHK_SUM.AutoSize = True
        Me.CHK_SUM.Location = New System.Drawing.Point(1054, 722)
        Me.CHK_SUM.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CHK_SUM.Name = "CHK_SUM"
        Me.CHK_SUM.Size = New System.Drawing.Size(188, 24)
        Me.CHK_SUM.TabIndex = 494
        Me.CHK_SUM.Text = "SUMMARY REPORT"
        Me.CHK_SUM.UseVisualStyleBackColor = True
        '
        'CkExices
        '
        Me.CkExices.AutoSize = True
        Me.CkExices.Location = New System.Drawing.Point(1053, 691)
        Me.CkExices.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CkExices.Name = "CkExices"
        Me.CkExices.Size = New System.Drawing.Size(165, 24)
        Me.CkExices.TabIndex = 494
        Me.CkExices.Text = "EXICES REPORT"
        Me.CkExices.UseVisualStyleBackColor = True
        Me.CkExices.Visible = False
        '
        'chkdetail
        '
        Me.chkdetail.AutoSize = True
        Me.chkdetail.Location = New System.Drawing.Point(1053, 658)
        Me.chkdetail.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkdetail.Name = "chkdetail"
        Me.chkdetail.Size = New System.Drawing.Size(92, 24)
        Me.chkdetail.TabIndex = 492
        Me.chkdetail.Text = "DETAIL"
        Me.chkdetail.UseVisualStyleBackColor = True
        Me.chkdetail.Visible = False
        '
        'chksummary
        '
        Me.chksummary.AutoSize = True
        Me.chksummary.Checked = True
        Me.chksummary.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chksummary.Location = New System.Drawing.Point(1053, 626)
        Me.chksummary.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chksummary.Name = "chksummary"
        Me.chksummary.Size = New System.Drawing.Size(164, 24)
        Me.chksummary.TabIndex = 491
        Me.chksummary.Text = "WITH OPENNING"
        Me.chksummary.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(309, 25)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(507, 38)
        Me.Label16.TabIndex = 491
        Me.Label16.Text = "STOCK SUMMARY COSTING"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ChK_WITHOUTVALUE
        '
        Me.ChK_WITHOUTVALUE.AutoSize = True
        Me.ChK_WITHOUTVALUE.Location = New System.Drawing.Point(1056, 802)
        Me.ChK_WITHOUTVALUE.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ChK_WITHOUTVALUE.Name = "ChK_WITHOUTVALUE"
        Me.ChK_WITHOUTVALUE.Size = New System.Drawing.Size(167, 24)
        Me.ChK_WITHOUTVALUE.TabIndex = 496
        Me.ChK_WITHOUTVALUE.Text = "WITHOUT VALUE"
        Me.ChK_WITHOUTVALUE.UseVisualStyleBackColor = True
        Me.ChK_WITHOUTVALUE.Visible = False
        '
        'CHK_EXCISE_SUMM
        '
        Me.CHK_EXCISE_SUMM.AutoSize = True
        Me.CHK_EXCISE_SUMM.Location = New System.Drawing.Point(1056, 837)
        Me.CHK_EXCISE_SUMM.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CHK_EXCISE_SUMM.Name = "CHK_EXCISE_SUMM"
        Me.CHK_EXCISE_SUMM.Size = New System.Drawing.Size(252, 24)
        Me.CHK_EXCISE_SUMM.TabIndex = 497
        Me.CHK_EXCISE_SUMM.Text = "EXICES REPORT SUMMARY"
        Me.CHK_EXCISE_SUMM.UseVisualStyleBackColor = True
        Me.CHK_EXCISE_SUMM.Visible = False
        '
        'chk_overall
        '
        Me.chk_overall.AutoSize = True
        Me.chk_overall.Location = New System.Drawing.Point(1056, 878)
        Me.chk_overall.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chk_overall.Name = "chk_overall"
        Me.chk_overall.Size = New System.Drawing.Size(237, 24)
        Me.chk_overall.TabIndex = 498
        Me.chk_overall.Text = "OVERALL STOCK REPORT"
        Me.chk_overall.UseVisualStyleBackColor = True
        '
        'CHK_WITHOUT_ZERO
        '
        Me.CHK_WITHOUT_ZERO.AutoSize = True
        Me.CHK_WITHOUT_ZERO.Location = New System.Drawing.Point(1056, 912)
        Me.CHK_WITHOUT_ZERO.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CHK_WITHOUT_ZERO.Name = "CHK_WITHOUT_ZERO"
        Me.CHK_WITHOUT_ZERO.Size = New System.Drawing.Size(266, 24)
        Me.CHK_WITHOUT_ZERO.TabIndex = 497
        Me.CHK_WITHOUT_ZERO.Text = "WITHOUT ZERO CLOSINGQTY"
        Me.CHK_WITHOUT_ZERO.UseVisualStyleBackColor = True
        '
        'Chk_Ledger
        '
        Me.Chk_Ledger.AutoSize = True
        Me.Chk_Ledger.Location = New System.Drawing.Point(1152, 658)
        Me.Chk_Ledger.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Chk_Ledger.Name = "Chk_Ledger"
        Me.Chk_Ledger.Size = New System.Drawing.Size(149, 24)
        Me.Chk_Ledger.TabIndex = 499
        Me.Chk_Ledger.Text = "LEDGER WISE"
        Me.Chk_Ledger.UseVisualStyleBackColor = True
        '
        'InvStockSummaryGroupCosting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1365, 957)
        Me.Controls.Add(Me.Chk_Ledger)
        Me.Controls.Add(Me.CHK_WITHOUT_ZERO)
        Me.Controls.Add(Me.chk_overall)
        Me.Controls.Add(Me.CHK_EXCISE_SUMM)
        Me.Controls.Add(Me.ChK_WITHOUTVALUE)
        Me.Controls.Add(Me.ChBZero)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.CHK_SUM)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CkExices)
        Me.Controls.Add(Me.chksummary)
        Me.Controls.Add(Me.chkdetail)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "InvStockSummaryGroupCosting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ChkItemCode As System.Windows.Forms.CheckBox
    Friend WithEvents ChkCategory As System.Windows.Forms.CheckBox
    Friend WithEvents CheckedListBox3 As System.Windows.Forms.CheckedListBox
    Friend WithEvents CheckedListBox2 As System.Windows.Forms.CheckedListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_mainstore As System.Windows.Forms.TextBox
    Friend WithEvents cmd_storecode As System.Windows.Forms.Button
    Friend WithEvents txt_mainstorecode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtptodate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfromdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkdetail As System.Windows.Forms.CheckBox
    Friend WithEvents chksummary As System.Windows.Forms.CheckBox
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmd_Print As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents ButExport As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbl_Itemlist As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_GroupList As System.Windows.Forms.Label
    Friend WithEvents Chk_SelectAllGroup As System.Windows.Forms.CheckBox
    Friend WithEvents Chklist_Groupdesc As System.Windows.Forms.CheckedListBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents DTPaSondATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ClosingOnly As System.Windows.Forms.CheckBox
    Friend WithEvents CkExices As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_SUM As System.Windows.Forms.CheckBox
    Friend WithEvents ChBZero As System.Windows.Forms.CheckBox
    Friend WithEvents CHKEXPORT As System.Windows.Forms.CheckBox
    Friend WithEvents ChK_WITHOUTVALUE As CheckBox
    Friend WithEvents CHK_EXCISE_SUMM As CheckBox
    Friend WithEvents chk_overall As CheckBox
    Friend WithEvents CHK_WITHOUT_ZERO As CheckBox
    Friend WithEvents Chk_Ledger As System.Windows.Forms.CheckBox
End Class
