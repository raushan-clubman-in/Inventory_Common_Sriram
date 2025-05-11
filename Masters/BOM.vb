Imports System.Data.SqlClient
Public Class BOM
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
    Friend WithEvents frmbut As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Heading As System.Windows.Forms.Label
    Friend WithEvents grp_Cocktail As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents ssgrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents AxfpSpread1 As AxFPSpreadADO.AxfpSpread
    Friend WithEvents lbl_Menuitemcode As System.Windows.Forms.Label
    Friend WithEvents lbl_Itemuom As System.Windows.Forms.Label
    Friend WithEvents lbl_Salerate As System.Windows.Forms.Label
    Friend WithEvents txt_Menucode As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_Menucodehelp As System.Windows.Forms.Button
    Friend WithEvents lbl_menuname As System.Windows.Forms.Label
    Friend WithEvents txt_Salerate As System.Windows.Forms.TextBox
    Friend WithEvents txt_Menuname As System.Windows.Forms.TextBox
    Friend WithEvents Cbo_Itemuom As System.Windows.Forms.ComboBox
    Friend WithEvents SSGRID2 As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(BOM))
        Me.frmbut = New System.Windows.Forms.GroupBox
        Me.lbl_Heading = New System.Windows.Forms.Label
        Me.lbl_Freeze = New System.Windows.Forms.Label
        Me.grp_Cocktail = New System.Windows.Forms.GroupBox
        Me.Cmd_Clear = New System.Windows.Forms.Button
        Me.Cmd_Freeze = New System.Windows.Forms.Button
        Me.Cmd_Add = New System.Windows.Forms.Button
        Me.Cmd_Exit = New System.Windows.Forms.Button
        Me.ssgrid = New AxFPSpreadADO.AxfpSpread
        Me.lbl_Menuitemcode = New System.Windows.Forms.Label
        Me.lbl_Itemuom = New System.Windows.Forms.Label
        Me.lbl_Salerate = New System.Windows.Forms.Label
        Me.txt_Menucode = New System.Windows.Forms.TextBox
        Me.Cmd_Menucodehelp = New System.Windows.Forms.Button
        Me.lbl_menuname = New System.Windows.Forms.Label
        Me.txt_Salerate = New System.Windows.Forms.TextBox
        Me.AxfpSpread1 = New AxFPSpreadADO.AxfpSpread
        Me.SSGRID2 = New AxFPSpreadADO.AxfpSpread
        Me.txt_Menuname = New System.Windows.Forms.TextBox
        Me.Cbo_Itemuom = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Cmd_View = New System.Windows.Forms.Button
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxfpSpread1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SSGRID2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'frmbut
        '
        Me.frmbut.BackColor = System.Drawing.Color.Transparent
        Me.frmbut.Location = New System.Drawing.Point(184, 448)
        Me.frmbut.Name = "frmbut"
        Me.frmbut.Size = New System.Drawing.Size(520, 56)
        Me.frmbut.TabIndex = 36
        Me.frmbut.TabStop = False
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Heading.Location = New System.Drawing.Point(248, 16)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(332, 31)
        Me.lbl_Heading.TabIndex = 19
        Me.lbl_Heading.Text = "BILL OF MATERIAL [BOM]"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(168, 416)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(328, 25)
        Me.lbl_Freeze.TabIndex = 35
        Me.lbl_Freeze.Text = "Record Void  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'grp_Cocktail
        '
        Me.grp_Cocktail.BackgroundImage = CType(resources.GetObject("grp_Cocktail.BackgroundImage"), System.Drawing.Image)
        Me.grp_Cocktail.Location = New System.Drawing.Point(40, 56)
        Me.grp_Cocktail.Name = "grp_Cocktail"
        Me.grp_Cocktail.Size = New System.Drawing.Size(792, 88)
        Me.grp_Cocktail.TabIndex = 20
        Me.grp_Cocktail.TabStop = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.White
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.Location = New System.Drawing.Point(200, 464)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Clear.TabIndex = 13
        Me.Cmd_Clear.Text = "Clear[F6]"
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Freeze.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.White
        Me.Cmd_Freeze.Image = CType(resources.GetObject("Cmd_Freeze.Image"), System.Drawing.Image)
        Me.Cmd_Freeze.Location = New System.Drawing.Point(456, 464)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Freeze.TabIndex = 10
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Add.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.Color.White
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.Location = New System.Drawing.Point(328, 464)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Add.TabIndex = 9
        Me.Cmd_Add.Text = "Add [F7]"
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Exit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.White
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.Location = New System.Drawing.Point(584, 464)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Exit.TabIndex = 12
        Me.Cmd_Exit.Text = "Exit[F11]"
        '
        'ssgrid
        '
        Me.ssgrid.ContainingControl = Me
        Me.ssgrid.DataSource = Nothing
        Me.ssgrid.Location = New System.Drawing.Point(136, 268)
        Me.ssgrid.Name = "ssgrid"
        Me.ssgrid.OcxState = CType(resources.GetObject("ssgrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid.Size = New System.Drawing.Size(792, 272)
        Me.ssgrid.TabIndex = 369
        '
        'lbl_Menuitemcode
        '
        Me.lbl_Menuitemcode.AutoSize = True
        Me.lbl_Menuitemcode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Menuitemcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Menuitemcode.Location = New System.Drawing.Point(48, 80)
        Me.lbl_Menuitemcode.Name = "lbl_Menuitemcode"
        Me.lbl_Menuitemcode.Size = New System.Drawing.Size(97, 18)
        Me.lbl_Menuitemcode.TabIndex = 21
        Me.lbl_Menuitemcode.Text = "MENU CODE :"
        '
        'lbl_Itemuom
        '
        Me.lbl_Itemuom.AutoSize = True
        Me.lbl_Itemuom.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Itemuom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Itemuom.Location = New System.Drawing.Point(48, 112)
        Me.lbl_Itemuom.Name = "lbl_Itemuom"
        Me.lbl_Itemuom.Size = New System.Drawing.Size(82, 18)
        Me.lbl_Itemuom.TabIndex = 24
        Me.lbl_Itemuom.Text = "ITEM UOM :"
        '
        'lbl_Salerate
        '
        Me.lbl_Salerate.AutoSize = True
        Me.lbl_Salerate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Salerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Salerate.Location = New System.Drawing.Point(424, 112)
        Me.lbl_Salerate.Name = "lbl_Salerate"
        Me.lbl_Salerate.Size = New System.Drawing.Size(88, 18)
        Me.lbl_Salerate.TabIndex = 25
        Me.lbl_Salerate.Text = "SALE RATE :"
        Me.lbl_Salerate.Visible = False
        '
        'txt_Menucode
        '
        Me.txt_Menucode.BackColor = System.Drawing.Color.Wheat
        Me.txt_Menucode.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Menucode.Location = New System.Drawing.Point(176, 72)
        Me.txt_Menucode.MaxLength = 50
        Me.txt_Menucode.Name = "txt_Menucode"
        Me.txt_Menucode.Size = New System.Drawing.Size(144, 26)
        Me.txt_Menucode.TabIndex = 0
        Me.txt_Menucode.Text = ""
        '
        'Cmd_Menucodehelp
        '
        Me.Cmd_Menucodehelp.Image = CType(resources.GetObject("Cmd_Menucodehelp.Image"), System.Drawing.Image)
        Me.Cmd_Menucodehelp.Location = New System.Drawing.Point(320, 72)
        Me.Cmd_Menucodehelp.Name = "Cmd_Menucodehelp"
        Me.Cmd_Menucodehelp.Size = New System.Drawing.Size(23, 26)
        Me.Cmd_Menucodehelp.TabIndex = 22
        '
        'lbl_menuname
        '
        Me.lbl_menuname.AutoSize = True
        Me.lbl_menuname.BackColor = System.Drawing.Color.Transparent
        Me.lbl_menuname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_menuname.Location = New System.Drawing.Point(424, 80)
        Me.lbl_menuname.Name = "lbl_menuname"
        Me.lbl_menuname.Size = New System.Drawing.Size(97, 18)
        Me.lbl_menuname.TabIndex = 23
        Me.lbl_menuname.Text = "MENU NAME :"
        '
        'txt_Salerate
        '
        Me.txt_Salerate.BackColor = System.Drawing.Color.Wheat
        Me.txt_Salerate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Salerate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Salerate.Location = New System.Drawing.Point(552, 112)
        Me.txt_Salerate.MaxLength = 15
        Me.txt_Salerate.Name = "txt_Salerate"
        Me.txt_Salerate.ReadOnly = True
        Me.txt_Salerate.Size = New System.Drawing.Size(144, 26)
        Me.txt_Salerate.TabIndex = 2
        Me.txt_Salerate.Text = ""
        Me.txt_Salerate.Visible = False
        '
        'AxfpSpread1
        '
        Me.AxfpSpread1.ContainingControl = Me
        Me.AxfpSpread1.DataSource = Nothing
        Me.AxfpSpread1.Location = New System.Drawing.Point(544, 448)
        Me.AxfpSpread1.Name = "AxfpSpread1"
        Me.AxfpSpread1.OcxState = CType(resources.GetObject("AxfpSpread1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxfpSpread1.Size = New System.Drawing.Size(386, 163)
        Me.AxfpSpread1.TabIndex = 380
        '
        'SSGRID2
        '
        Me.SSGRID2.DataSource = Nothing
        Me.SSGRID2.Location = New System.Drawing.Point(40, 200)
        Me.SSGRID2.Name = "SSGRID2"
        Me.SSGRID2.OcxState = CType(resources.GetObject("SSGRID2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSGRID2.Size = New System.Drawing.Size(792, 208)
        Me.SSGRID2.TabIndex = 3
        '
        'txt_Menuname
        '
        Me.txt_Menuname.BackColor = System.Drawing.Color.Wheat
        Me.txt_Menuname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Menuname.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Menuname.Location = New System.Drawing.Point(552, 72)
        Me.txt_Menuname.MaxLength = 15
        Me.txt_Menuname.Name = "txt_Menuname"
        Me.txt_Menuname.Size = New System.Drawing.Size(256, 26)
        Me.txt_Menuname.TabIndex = 18
        Me.txt_Menuname.Text = ""
        '
        'Cbo_Itemuom
        '
        Me.Cbo_Itemuom.BackColor = System.Drawing.Color.Wheat
        Me.Cbo_Itemuom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo_Itemuom.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_Itemuom.Location = New System.Drawing.Point(176, 112)
        Me.Cbo_Itemuom.Name = "Cbo_Itemuom"
        Me.Cbo_Itemuom.Size = New System.Drawing.Size(168, 27)
        Me.Cbo_Itemuom.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(128, 512)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(632, 18)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "Press F4 for HELP/Press F3 for DELETE item in grid/Press ENTER key to navigate"
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_View.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.White
        Me.Cmd_View.Image = CType(resources.GetObject("Cmd_View.Image"), System.Drawing.Image)
        Me.Cmd_View.Location = New System.Drawing.Point(752, 464)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_View.TabIndex = 51
        Me.Cmd_View.Text = " View[F9]"
        Me.Cmd_View.Visible = False
        '
        'BOM
        '
        Me.AutoScale = False
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(870, 556)
        Me.Controls.Add(Me.Cmd_View)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_Menuname)
        Me.Controls.Add(Me.txt_Salerate)
        Me.Controls.Add(Me.lbl_menuname)
        Me.Controls.Add(Me.txt_Menucode)
        Me.Controls.Add(Me.lbl_Salerate)
        Me.Controls.Add(Me.lbl_Itemuom)
        Me.Controls.Add(Me.lbl_Menuitemcode)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.Cbo_Itemuom)
        Me.Controls.Add(Me.SSGRID2)
        Me.Controls.Add(Me.Cmd_Menucodehelp)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.Cmd_Freeze)
        Me.Controls.Add(Me.Cmd_Add)
        Me.Controls.Add(Me.Cmd_Exit)
        Me.Controls.Add(Me.frmbut)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.grp_Cocktail)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "BOM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BILL OF MATERIAL (BOM)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxfpSpread1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SSGRID2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim i As Integer
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim gconnection As New GlobalClass
    Dim vsearch, vitem, accountcode As String

    Private Sub Cock_Tail_Ratio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            CockTailRatioTransbool = True
            txt_Menucode.Enabled = True
            txt_Menucode.ReadOnly = False
            txt_Menuname.ReadOnly = False
            CockTailRatioTransbool = True
            SSGRID2.SetActiveCell(1, 1)
            Call FILLUOM()
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub FILLUOM()
        Try
            Dim i As Integer
            sqlstring = "SELECT UOMdesc FROM UOMMaster WHERE freeze='N'"
            gconnection.getDataSet(sqlstring, "UOMMaster1")
            Cbo_Itemuom.Items.Clear()
            Cbo_Itemuom.Sorted = True
            If gdataset.Tables("UOMMaster1").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("UOMMaster1").Rows.Count - 1
                    Cbo_Itemuom.Items.Add(gdataset.Tables("UOMMaster1").Rows(i).Item("UOMDESC"))
                Next i
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Try
            Call clearform(Me)
            Call FILLUOM()
            Me.lbl_Freeze.Visible = False
            Me.lbl_Freeze.Text = "Record Void  On "
            SSGRID2.ClearRange(1, 1, -1, -1, True)
            Me.Cmd_Freeze.Text = "Void [F8]"
            Cmd_Add.Text = "Add [F7]"
            SSGRID2.SetActiveCell(1, 1)
            txt_Menucode.Enabled = True
            txt_Menucode.ReadOnly = False
            txt_Menuname.ReadOnly = False
            txt_Menucode.Focus()
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Try
            Dim totalamt, totalqty As Double
            Dim sqlstring As String
            Dim Insert(0) As String
            Dim i As Integer
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            '''*********************************************************** Calculate TotalQuantity And TotalAmount *******************'''
            'With SSGRID2
            '    Me.txt_Totalamount.Text = 0
            '    Me.txt_Totalqty.Text = 0
            '    For i = 1 To .DataRowCnt
            '        .Row = i
            '        .Col = 4
            '        totalqty = Val(.Text)
            '        Me.txt_Totalqty.Text = Format(Val(Me.txt_Totalqty.Text) + Val(totalqty), "0.000")
            '        .Col = 6
            '        totalamt = Val(.Text)
            '        Me.txt_Totalamount.Text = Format(Val(Me.txt_Totalamount.Text) + Val(totalamt), "0.00")
            '    Next i
            'End With
            '''*********************************************************** Calculate TotalQuantity And TotalAmount *******************'''
            '''*********************************************************** Case-1 : Add [F7] *******************************************'''
            If Cmd_Add.Text = "Add [F7]" Then
                sqlstring = "INSERT INTO BOM_hdr(Itemcode,Itemname,ItemUOM,Void,Adduser,Adddate)"
                sqlstring = sqlstring & " VALUES ('" & Trim(txt_Menucode.Text) & "',"
                sqlstring = sqlstring & "'" & Replace(Trim(txt_Menuname.Text), "'", "") & "',"
                sqlstring = sqlstring & "'" & Trim(Cbo_Itemuom.Text) & "',"
                sqlstring = sqlstring & "'N','" & Trim(gUsername) & "',getDate())"
                Insert(0) = sqlstring
                '''******************************************************** Insert into Grn_details **********************************'''
                For i = 1 To SSGRID2.DataRowCnt
                    With SSGRID2
                        sqlstring = "INSERT INTO BOM_det(Itemcode,Itemname,ItemUOM,gitemcode,"
                        sqlstring = sqlstring & " gitemname,gUOM,gqty,grate,gamount,gdblamt,ghighratio,ggroupcode,gsubgroupcode,Void,Adduser,Adddate)"
                        sqlstring = sqlstring & " VALUES('" & Trim(txt_Menucode.Text) & "','" & Replace(Trim(txt_Menuname.Text), "'", "") & "',"
                        sqlstring = sqlstring & "'" & Trim(Cbo_Itemuom.Text) & "',"
                        .Row = i
                        .Col = 1
                        sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                        .Col = 2
                        sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                        .Col = 3
                        sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                        .Col = 4
                        sqlstring = sqlstring & "" & Format(Val(.Text), "0.000") & ","
                        .Col = 5
                        sqlstring = sqlstring & "" & Format(Val(.Text), "0.00") & ","
                        .Col = 6
                        sqlstring = sqlstring & "" & Format(Val(.Text), "0.00") & ","
                        .Col = 7
                        sqlstring = sqlstring & "" & Format(Val(.Text), "0.000") & ","
                        .Col = 9
                        sqlstring = sqlstring & "" & Format(Val(.Text), "0.00") & ","
                        .Col = 10
                        sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                        .Col = 11
                        sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                        sqlstring = sqlstring & "'N','" & Trim(gUsername) & "',getDate())"
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
                    End With
                Next i
                '''****************************************** UPDATE Opening Stock ***************************************
                'For i = 1 To SSGRID2.DataRowCnt
                '    With SSGRID2
                '        .Row = i
                '        sqlstring = "UPDATE OpeningStock SET "
                '        .Col = 4
                '        sqlstring = sqlstring & " mainclstock = mainclstock + " & Format(Val(.Text), "0") & ","
                '        .Col = 8
                '        sqlstring = sqlstring & " doublevalue= doublevalue + " & Format(Val(.Text), "0.00") & ","
                '        sqlstring = sqlstring & "Adduser='" & Trim(gUsername) & "',Adddate='" & Format(Now, "dd-MMM-yyyy") & "'"
                '        .Col = 1
                '        sqlstring = sqlstring & " WHERE Itemcode='" & Trim(.Text) & "' "
                '        ReDim Preserve Insert(Insert.Length)
                '        Insert(Insert.Length - 1) = sqlstring
                '    End With
                'Next i
                '''****************************************** UPDATE Completed ********************************************
                gconnection.MoreTrans(Insert)
                'If MessageBox.Show("Do You Want Print it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                '    Call Cmd_View_Click(Cmd_View, e)
                '    Call Cmd_Clear_Click(sender, e)
                'Else
                Call Cmd_Clear_Click(sender, e)
                'End If
                '''*********************************************************** Case-2 : Update [F7] *******************************************'''
                'APRIL 25
            Else
                If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
                    If Me.lbl_Freeze.Visible = True Then
                        MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        boolchk = False
                        Exit Sub
                    End If
                End If
                '''********************************************************** UPDATE GRN_HEADER *********************************************************'''
                'sqlstring = " UPDATE cocktailratio_hdr SET Itemname='" & Replace(Trim(txt_Menuname.Text), "'", "") & "',"
                'sqlstring = sqlstring & " ItemUOM='" & Trim(Cbo_Itemuom.Text) & "',ItemEOQ='" & Format(Val(txt_Eoq.Text), "0.000") & "',"
                'sqlstring = sqlstring & " Itemtype='" & Trim(cbo_Type.Text) & "',totalqty='" & Format(Val(txt_Totalqty.Text), "0.000") & "',"
                'sqlstring = sqlstring & " totalamt='" & Format(Val(txt_Totalamount.Text), "0.00") & "',Void='N',"
                'sqlstring = sqlstring & " Adduser='" & Trim(gUsername) & "',Adddate='" & Format(Now, "dd-MMM-yyyy") & "' "
                'sqlstring = sqlstring & " WHERE itemcode='" & Trim(txt_ItemCode.Text) & "' "
                sqlstring = " UPDATE bom_hdr SET Itemname='" & Replace(Trim(txt_Menuname.Text), "'", "") & "',"
                sqlstring = sqlstring & " ItemUOM='" & Trim(Cbo_Itemuom.Text) & "',"
                sqlstring = sqlstring & " Void='N',"
                sqlstring = sqlstring & " Adduser='" & Trim(gUsername) & "',Adddate=getDate() "
                sqlstring = sqlstring & " WHERE itemcode='" & Trim(txt_Menucode.Text) & "' and itemuom='" & Trim(Cbo_Itemuom.Text) & "'"
                Insert(0) = sqlstring
                '''********************************************************* DELETE FROM GRN_DETAILS *****************************************************'''
                sqlstring = "DELETE FROM BOM_det WHERE itemcode='" & Trim(txt_Menucode.Text) & "' and itemuom='" & Trim(Cbo_Itemuom.Text) & "'"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring
                '''******************************************************** INSERT INTO GRN_DETAILS ******************************************************'''
                For i = 1 To SSGRID2.DataRowCnt
                    With SSGRID2
                        sqlstring = "INSERT INTO BOM_det(Itemcode,Itemname,ItemUOM,gitemcode,"
                        sqlstring = sqlstring & " gitemname,gUOM,gqty,grate,gamount,gdblamt,ghighratio,ggroupcode,gsubgroupcode,Void,Adduser,Adddate)"
                        sqlstring = sqlstring & " VALUES('" & Trim(txt_Menucode.Text) & "','" & Replace(Trim(txt_Menuname.Text), "'", "") & "',"
                        sqlstring = sqlstring & "'" & Trim(Cbo_Itemuom.Text) & "',"
                        .Row = i
                        .Col = 1
                        sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                        .Col = 2
                        sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                        .Col = 3
                        sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                        .Col = 4
                        sqlstring = sqlstring & "" & Format(Val(.Text), "0.000") & ","
                        .Col = 5
                        sqlstring = sqlstring & "" & Format(Val(.Text), "0.00") & ","
                        .Col = 6
                        sqlstring = sqlstring & "" & Format(Val(.Text), "0.00") & ","
                        .Col = 7
                        sqlstring = sqlstring & "" & Format(Val(.Text), "0.000") & ","
                        .Col = 9
                        sqlstring = sqlstring & "" & Format(Val(.Text), "0.00") & ","
                        .Col = 10
                        sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                        .Col = 11
                        sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                        sqlstring = sqlstring & "'N','" & Trim(gUsername) & "',getDate())"
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
                    End With
                Next i
                '''****************************************** UPDATE Opening Stock ***************************************
                'For i = 1 To SSGRID2.DataRowCnt
                '    With SSGRID2
                '        .Row = i
                '        sqlstring = "UPDATE OpeningStock SET "
                '        .Col = 4
                '        sqlstring = sqlstring & " mainclstock = mainclstock + " & Format(Val(.Text), "0") & ","
                '        .Col = 8
                '        sqlstring = sqlstring & " doublevalue= doublevalue + " & Format(Val(.Text), "0.00") & ","
                '        sqlstring = sqlstring & "Adduser='" & Trim(gUsername) & "',Adddate='" & Format(Now, "dd-MMM-yyyy") & "'"
                '        .Col = 1
                '        sqlstring = sqlstring & " WHERE Itemcode='" & Trim(.Text) & "' "
                '        ReDim Preserve Insert(Insert.Length)
                '        Insert(Insert.Length - 1) = sqlstring
                '    End With
                'Next i
                '''****************************************** UPDATE Completed ********************************************
                gconnection.MoreTrans(Insert)
                'If MessageBox.Show("Do You Want Print it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                'Call Cmd_View_Click(Cmd_View, e)
                'Call Cmd_Clear_Click(sender, e)
                'Else
                Call Cmd_Clear_Click(sender, e)
                'End If
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Try
            Call checkValidation() ''-->Check Validation
            Dim i As Integer
            Dim insert(0) As String
            Call checkValidation() ''-->Check Validation
            If boolchk = False Then Exit Sub
            If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then
                '''***************************************** Void the DOCNO in BOMheader **************************'''
                sqlstring = "UPDATE  BOM_hdr "
                sqlstring = sqlstring & " SET Void= 'Y',Adduser='" & gUsername & " ', Adddate=getDate()"
                sqlstring = sqlstring & " WHERE itemcode = '" & Trim(txt_Menucode.Text) & "'"
                gconnection.dataOperation(3, sqlstring, "BOM_hdr")
                insert(0) = sqlstring
                '''***************************************** Void the DOCNO in Complete **********************************'''
                '''***************************************** Void the DOCNO in BOMdetails **************************'''
                For i = 1 To SSGRID2.DataRowCnt
                    With SSGRID2
                        sqlstring = "UPDATE  BOM_det "
                        sqlstring = sqlstring & " SET Void= 'Y',"
                        sqlstring = sqlstring & " Adduser='" & gUsername & " ',"
                        sqlstring = sqlstring & " Adddate =getDate()"
                        sqlstring = sqlstring & " WHERE itemcode = '" & Trim(txt_Menucode.Text) & "'"
                        ReDim Preserve insert(insert.Length)
                        insert(insert.Length - 1) = sqlstring
                    End With
                Next i
                '''***************************************** Void the DOCNO is Complete **********************************'''
                '''****************************************** UPDATE Opening Stock ***************************************
                'For i = 1 To SSGRID2.DataRowCnt
                '    With SSGRID2
                '        .Row = i
                '        sqlstring = "UPDATE OpeningStock SET "
                '        .Col = 4
                '        sqlstring = sqlstring & " mainclstock = mainclstock - " & Format(Val(.Text), "0") & ","
                '        .Col = 8
                '        sqlstring = sqlstring & " doublevalue= doublevalue - " & Format(Val(.Text), "0.00") & ","
                '        sqlstring = sqlstring & "Adduser='" & Trim(gUsername) & "',Adddate='" & Format(Now, "dd-MMM-yyyy") & "'"
                '        .Col = 1
                '        sqlstring = sqlstring & " WHERE Itemcode='" & Trim(.Text) & "' "
                '        ReDim Preserve insert(insert.Length)
                '        insert(insert.Length - 1) = sqlstring
                '    End With
                'Next i
                '''****************************************** UPDATE Completed ********************************************
                gconnection.MoreTrans(insert)
                Me.Cmd_Clear_Click(sender, e)
                Cmd_Add.Text = "Add [F7]"
            Else
                sqlstring = "UPDATE  BOM_hdr "
                sqlstring = sqlstring & " SET Void= 'N',Adduser='" & gUsername & " ', Adddate=getDate()"
                sqlstring = sqlstring & " WHERE itemcode = '" & Trim(txt_Menucode.Text) & "'"
                gconnection.dataOperation(4, sqlstring, "BOM_hdr")
                insert(0) = sqlstring
                '''***************************************** Void the DOCNO in Complete **********************************'''
                '''***************************************** Void the DOCNO in BOMdetails **************************'''
                For i = 1 To SSGRID2.DataRowCnt
                    With SSGRID2
                        sqlstring = "UPDATE  BOM_det "
                        sqlstring = sqlstring & " SET Void= 'N',"
                        sqlstring = sqlstring & " Adduser='" & gUsername & " ',"
                        sqlstring = sqlstring & " Adddate =getDate()"
                        sqlstring = sqlstring & " WHERE itemcode = '" & Trim(txt_Menucode.Text) & "'"
                        ReDim Preserve insert(insert.Length)
                        insert(insert.Length - 1) = sqlstring
                    End With
                    gconnection.MoreTrans(insert)
                    Me.Cmd_Clear_Click(sender, e)
                    Cmd_Add.Text = "Add [F7]"
                Next i
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Dim objCocktailratio As New frmCocktailratiochart
            'objCocktailratio.Show()
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Try
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Cock_Tail_Ratio_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Try
            CockTailRatioTransbool = False
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Public Sub checkValidation()
        Try
            boolchk = False
            '''********** Check  Item Code Can't be blank *********************'''
            If Trim(txt_Menucode.Text) = "" Then
                MessageBox.Show(" Item Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_Menucode.Focus()
                Exit Sub
            End If
            '''********** Check  Item desc Can't be blank *********************'''
            'If Trim(txt_ItemDesc.Text) = "" Then
            '    MessageBox.Show(" Item Desc can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    txt_ItemDesc.Focus()
            '    Exit Sub
            'End If
            '''********** Check  EOQ Can't be blank *********************'''
            'If Val(txt_Eoq.Text) = 0 Then
            '    MessageBox.Show(" EOQ can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    txt_Eoq.Focus()
            '    Exit Sub
            'End If
            '''********** Check  UOM Can't be blank *********************'''
            If Trim(Cbo_Itemuom.Text) = "" Then
                MessageBox.Show(" UOM can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Cbo_Itemuom.Focus()
                Exit Sub
            End If
            ''' ********** Check ItemCode,ItemDesc,UOM,Rate can't be blank ***********'''
            For i = 1 To SSGRID2.DataRowCnt
                SSGRID2.Row = i
                SSGRID2.Col = 1
                If Trim(SSGRID2.Text) = "" Then
                    MessageBox.Show("ItemCode can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    SSGRID2.SetActiveCell(1, SSGRID2.ActiveRow)
                    SSGRID2.Focus()
                    Exit Sub
                End If
                SSGRID2.Col = 2
                If Trim(SSGRID2.Text) = "" Then
                    MessageBox.Show("Itemdesc can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    SSGRID2.SetActiveCell(2, SSGRID2.ActiveRow)
                    SSGRID2.Focus()
                    Exit Sub
                End If
                SSGRID2.Col = 3
                If Trim(SSGRID2.Text) = "" Then
                    MessageBox.Show("UOM can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    SSGRID2.SetActiveCell(3, SSGRID2.ActiveRow)
                    SSGRID2.Focus()
                    Exit Sub
                End If
                SSGRID2.Col = 4
                If Val(SSGRID2.Text) = 0 Then
                    MessageBox.Show("Quantity can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    SSGRID2.SetActiveCell(4, SSGRID2.ActiveRow)
                    SSGRID2.Focus()
                    Exit Sub
                End If
                SSGRID2.Col = 5
                If Val(SSGRID2.Text) = 0 Then
                    MessageBox.Show("Rate can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    SSGRID2.SetActiveCell(5, SSGRID2.ActiveRow)
                    SSGRID2.Focus()
                    Exit Sub
                End If
                SSGRID2.Col = 6
                If Val(SSGRID2.Text) = 0 Then
                    MessageBox.Show("Amount can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    SSGRID2.SetActiveCell(6, SSGRID2.ActiveRow)
                    SSGRID2.Focus()
                    Exit Sub
                End If
                SSGRID2.Col = 7
                If Val(SSGRID2.Text) = 0 Then
                    MessageBox.Show("dblamount can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    SSGRID2.SetActiveCell(7, SSGRID2.ActiveRow)
                    SSGRID2.Focus()
                    Exit Sub
                End If
                SSGRID2.Col = 9
                If Val(SSGRID2.Text) = 0 Then
                    MessageBox.Show("High Ratio can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    SSGRID2.SetActiveCell(8, SSGRID2.ActiveRow)
                    SSGRID2.Focus()
                    Exit Sub
                End If
                SSGRID2.Col = 10
                If Trim(SSGRID2.Text) = "" Then
                    MessageBox.Show("Group Code can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    SSGRID2.SetActiveCell(9, SSGRID2.ActiveRow)
                    SSGRID2.Focus()
                    Exit Sub
                End If
                SSGRID2.Col = 11
                If Trim(SSGRID2.Text) = "" Then
                    MessageBox.Show("Sub Group Code can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    SSGRID2.SetActiveCell(10, SSGRID2.ActiveRow)
                    SSGRID2.Focus()
                    Exit Sub
                End If
            Next i
            boolchk = True
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Cock_Tail_Ratio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.F6 Then
                Call Cmd_Clear_Click(Cmd_Clear, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F8 Then
                Call Cmd_Freeze_Click(Cmd_Freeze, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F7 Then
                Call Cmd_Add_Click(Cmd_Add, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F2 Then
                'txt_ItemCode.Text = ""
                'txt_ItemCode.Focus()
                Exit Sub
            ElseIf e.KeyCode = Keys.F9 Then
                Call Cmd_View_Click(Cmd_View, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
                Call Cmd_Exit_Click(Cmd_Exit, e)
                Exit Sub
            ElseIf e.Alt = True And e.KeyCode = Keys.R Then
                'Me.txt_Remarks.Focus()
                Exit Sub
            ElseIf e.Alt = True And e.KeyCode = Keys.G Then
                Me.SSGRID2.Focus()
                Me.SSGRID2.SetActiveCell(1, 1)
                Exit Sub
            ElseIf e.Alt = True And e.KeyCode = Keys.U Then
                'Me.cbo_Uom.Focus()
                Exit Sub
            ElseIf e.Alt = True And e.KeyCode = Keys.T Then
                'Me.cbo_Type.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_ItemDesc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            If Asc(e.KeyChar) = 13 Then
                Cbo_Itemuom.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub cbo_Uom_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            If Asc(e.KeyChar) = 13 Then
                SSGRID2.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub cbo_ITEMUom_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            If Asc(e.KeyChar) = 13 Then
                SSGRID2.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Eoq_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            If Asc(e.KeyChar) = 13 Then
                SSGRID2.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub FillMenu()
        Try
            Dim Avgrate, clsquantity As Double
            Dim K As Integer
            Dim vform As New List_Operation
            '''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO SSGRID2 ********** 
            gSQLString = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, ISNULL(I.PURCHASERATE,0) AS AVGRATE, "
            gSQLString = gSQLString & " ISNULL(O.CONVUOM,'') AS CONVUOM,ISNULL(O.HIGHRATIO,0) AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I  "
            gSQLString = gSQLString & " INNER JOIN OPENINGSTOCK AS O ON O.ITEMCODE = I.ITEMCODE "
            If Trim(vsearch) = " " Then
                M_WhereCondition = " "
            Else
                M_WhereCondition = " WHERE I.ITEMCODE LIKE '" & Trim(vsearch) & "%' AND ISNULL(I.FREEZE,'') <> 'Y' "
            End If
            vform.Field = "I.ITEMCODE,I.ITEMNAME"
            vform.vFormatstring1 = "   ITEMCODE    |                      ITEMNAME              | STOCKUOM | AVGRATE | CONVUOM | HIGHRATIO |"
            vform.vCaption = "INVENTORY ITEM CODE HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.KeyPos2 = 2
            vform.Keypos3 = 3
            vform.keypos4 = 4
            vform.Keypos5 = 5
            vform.Keypos6 = 6
            vform.Keypos7 = 7
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Call GridUOM(SSGRID2.ActiveRow) '''---> Fill the UOM feild
                SSGRID2.Col = 1
                SSGRID2.Row = SSGRID2.ActiveRow
                SSGRID2.Text = Trim(vform.keyfield)
                'For K = 1 To SSGRID2.DataRowCnt
                '    SSGRID2.Row = K
                '    SSGRID2.Col = 1
                '    If Itemvalidate(SSGRID2, Trim(vform.keyfield), 1) = True Then
                '        SSGRID2.SetActiveCell(0, SSGRID2.ActiveRow)
                '        SSGRID2.Focus()
                '        Exit Sub
                '    End If
                'Next
                SSGRID2.Col = 2
                SSGRID2.Row = SSGRID2.ActiveRow
                SSGRID2.Text = Trim(vform.keyfield1)
                SSGRID2.Col = 3
                SSGRID2.Row = SSGRID2.ActiveRow
                SSGRID2.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
                SSGRID2.TypeComboBoxString = vform.keyfield2
                SSGRID2.Text = Trim(vform.keyfield2)
                SSGRID2.Col = 5
                SSGRID2.Row = SSGRID2.ActiveRow
                Avgrate = CalAverageRate(Trim(vform.keyfield))
                'SSGRID2.Text = Format(Val(Avgrate), "0.00")
                SSGRID2.Text = Format(Val(vform.keyfield3), "0.00")
                SSGRID2.Col = 8
                SSGRID2.Row = SSGRID2.ActiveRow
                SSGRID2.Text = Trim(vform.keyfield4)
                SSGRID2.Col = 9
                SSGRID2.Row = SSGRID2.ActiveRow
                SSGRID2.Text = Format(Val(vform.keyfield5), "0.00")
                SSGRID2.Col = 10
                SSGRID2.Row = SSGRID2.ActiveRow
                SSGRID2.Text = Trim(vform.keyfield6)
                SSGRID2.Col = 11
                SSGRID2.Row = SSGRID2.ActiveRow
                SSGRID2.Text = Trim(vform.keyfield7)
                'clsquantity = ClosingQuantity(Trim(vform.keyfield), "MNS")
                clsquantity = ClosingQuantity(Trim(vform.keyfield), GetMainStore())
                SSGRID2.SetActiveCell(3, SSGRID2.ActiveRow)
                SSGRID2.Focus()
            Else
                SSGRID2.SetActiveCell(0, SSGRID2.ActiveRow)
                Exit Sub
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub FillMenuItem()
        Try
            Dim Avgrate, clsquantity As Double
            Dim K As Integer
            Dim vform As New List_Operation
            Dim ssql As String
            '''******************************************************** $ FILL THE ITEMDESC,ITEMCODE INTO SSGRID2 ********** 
            gSQLString = " SELECT DISTINCT  ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.STOCKUOM,'') AS STOCKUOM, ISNULL(O.AVGRATE,0) AS AVGRATE, "
            gSQLString = gSQLString & " ISNULL(O.CONVUOM,'') AS CONVUOM,ISNULL(O.HIGHRATIO,0) AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I  "
            gSQLString = gSQLString & " INNER JOIN OPENINGSTOCK AS O ON O.ITEMCODE = I.ITEMCODE "
            If Trim(vsearch) = " " Then
                M_WhereCondition = " "
            Else
                M_WhereCondition = " WHERE I.ITEMNAME like '" & Trim(vsearch) & "%' AND ISNULL(I.FREEZE,'') <> 'Y' "
            End If
            vform.Field = "I.ITEMNAME,I.ITEMCODE"
            vform.vFormatstring1 = "             ITEMNAME               |  ITEMCODE    | STOCKUOM | AVGRATE | CONVUOM | HIGHRATIO |"
            vform.vCaption = "INVENTORY ITEM CODE HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.KeyPos2 = 2
            vform.Keypos3 = 3
            vform.keypos4 = 4
            vform.Keypos5 = 5
            vform.Keypos6 = 6
            vform.Keypos7 = 7
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                SSGRID2.Col = 1
                SSGRID2.Row = SSGRID2.ActiveRow
                SSGRID2.Text = Trim(vform.keyfield1)
                'For K = 1 To SSGRID2.DataRowCnt
                '    SSGRID2.Row = K
                '    SSGRID2.Col = 1
                '    If Itemvalidate(SSGRID2, Trim(vform.keyfield1), 1) = True Then
                '        SSGRID2.SetActiveCell(1, SSGRID2.ActiveRow)
                '        SSGRID2.Focus()
                '        Exit Sub
                '    End If
                'Next
                SSGRID2.Col = 2
                SSGRID2.Row = SSGRID2.ActiveRow
                SSGRID2.Text = Trim(vform.keyfield)
                SSGRID2.Col = 3
                SSGRID2.Row = SSGRID2.ActiveRow
                SSGRID2.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
                SSGRID2.TypeComboBoxString = vform.keyfield2
                SSGRID2.Text = Trim(vform.keyfield2)
                SSGRID2.Col = 5
                SSGRID2.Row = SSGRID2.ActiveRow
                Avgrate = CalAverageRate(Trim(vform.keyfield))
                SSGRID2.Text = Format(Val(Avgrate), "0.00")
                SSGRID2.Col = 8
                SSGRID2.Row = SSGRID2.ActiveRow
                SSGRID2.Text = Trim(vform.keyfield4)
                SSGRID2.Col = 9
                SSGRID2.Row = SSGRID2.ActiveRow
                SSGRID2.Text = Format(Val(vform.keyfield5), "0.00")
                SSGRID2.Col = 10
                SSGRID2.Row = SSGRID2.ActiveRow
                SSGRID2.Text = Trim(vform.keyfield6)
                SSGRID2.Col = 11
                SSGRID2.Row = SSGRID2.ActiveRow
                SSGRID2.Text = Trim(vform.keyfield7)
                'clsquantity = ClosingQuantity(Trim(vform.keyfield1), "MNS")
                clsquantity = ClosingQuantity(Trim(vform.keyfield1), GetMainStore())
                SSGRID2.SetActiveCell(3, SSGRID2.ActiveRow)
                SSGRID2.Focus()
            Else
                SSGRID2.SetActiveCell(1, SSGRID2.ActiveRow)
                Exit Sub
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Calculate()
        Try
            Dim ValQty, ValRate, ValDiscount, VarTotal, clsquantiy As Double
            Dim ValHighratio, ValItemamount, ValDblamount, Calqty As Double
            Dim Itemcode As String
            Dim i, j As Integer
            If SSGRID2.ActiveCol = 1 Or SSGRID2.ActiveCol = 2 Or SSGRID2.ActiveCol = 3 Or SSGRID2.ActiveCol = 4 Or SSGRID2.ActiveCol = 5 Or SSGRID2.ActiveCol = 6 Then
                i = SSGRID2.ActiveRow
                SSGRID2.Col = 4
                SSGRID2.Row = i
                ValQty = Val(SSGRID2.Text)
                SSGRID2.Col = 5
                SSGRID2.Row = i
                ValRate = Val(SSGRID2.Text)
                SSGRID2.Col = 9
                SSGRID2.Row = i
                ValHighratio = Val(SSGRID2.Text())
                ValItemamount = Format(Val(ValQty) * Val(ValRate), "0.00")
                ValDblamount = Format(Val(ValQty) * Val(ValHighratio), "0.000")
                If Val(ValItemamount) = 0 Then
                    SSGRID2.SetText(6, i, "")
                    SSGRID2.SetText(7, i, "")
                Else
                    SSGRID2.SetText(6, i, Val(ValItemamount))
                    SSGRID2.SetText(7, i, Val(ValDblamount))
                End If
                SSGRID2.Col = 1
                SSGRID2.Row = SSGRID2.ActiveRow
                Itemcode = Trim(SSGRID2.Text)
                For j = 1 To SSGRID2.DataRowCnt
                    SSGRID2.Col = 1
                    SSGRID2.Row = j
                    If Trim(Itemcode) = Trim(SSGRID2.Text) Then
                        SSGRID2.Col = 4
                        SSGRID2.Row = j
                        Calqty = Calqty + Val(SSGRID2.Text)
                    End If
                Next
                i = i - 1
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub GridUOM(ByVal i As Integer)
        Try
            Dim j As Integer
            sqlstring = "SELECT UOMdesc FROM UOMMaster WHERE freeze='N'"
            gconnection.getDataSet(sqlstring, "UOMMaster1")
            If gdataset.Tables("UOMMaster1").Rows.Count > 0 Then
                For j = 0 To gdataset.Tables("UOMMaster1").Rows.Count - 1
                    SSGRID2.Col = 3
                    SSGRID2.Row = i
                    SSGRID2.TypeComboBoxString = Trim(gdataset.Tables("UOMMaster1").Rows(j).Item("UOMdesc"))
                    SSGRID2.Text = Trim(gdataset.Tables("UOMMaster1").Rows(j).Item("UOMdesc"))
                Next j
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub cbo_Type_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            If Asc(e.KeyChar) = 13 Then
                'txt_Eoq.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    'Private Sub SSGRID2_KeyDownEvent1(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles SSGRID2.KeyDownEvent
    '    Dim Issuerate, Highratio, Dblamount, clsquantity As Double
    '    Dim ItemQty, ItemAmount, ItemRate As Double
    '    Dim sqlstring, Itemcode, Itemdesc As String
    '    Dim focusbool As Boolean
    '    Dim i, j, K As Integer
    '    search = Nothing
    '    Try
    '        If e.keyCode = Keys.Enter Then
    '            i = SSGRID2.ActiveRow
    '            If SSGRID2.ActiveCol = 1 Then
    '                SSGRID2.Col = 1
    '                SSGRID2.Row = i
    '                If SSGRID2.Lock = False Then
    '                    If Trim(SSGRID2.Text) = "" Then
    '                        Call FillMenu() ''' IT WILL SHOW A POPUP MENU FOR ITEM CODE
    '                    Else
    '                        Itemcode = Trim(SSGRID2.Text)
    '                        SSGRID2.ClearRange(1, SSGRID2.ActiveRow, 10, SSGRID2.ActiveRow, True)
    '                        '''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
    '                        sqlstring = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, "
    '                        sqlstring = sqlstring & " ISNULL(O.CONVUOM,'') AS CONVUOM,ISNULL(O.HIGHRATIO,0) AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, "
    '                        sqlstring = sqlstring & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I INNER JOIN OPENINGSTOCK AS O ON O.ITEMCODE = I.ITEMCODE "
    '                        sqlstring = sqlstring & " WHERE I.ITEMCODE ='" & Trim(Itemcode) & "'  AND ISNULL(I.FREEZE,'') <> 'Y'"
    '                        gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER1")
    '                        If gdataset.Tables("INVENTORYITEMMASTER1").Rows.Count > 0 Then
    '                            Call GridUOM(i) '''---> Fill the UOM feild
    '                            SSGRID2.SetText(1, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
    '                            'For K = 1 To SSGRID2.DataRowCnt
    '                            '    SSGRID2.Row = K
    '                            '    SSGRID2.Col = 1
    '                            '    If Itemvalidate(SSGRID2, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), 1) = True Then
    '                            '        SSGRID2.SetActiveCell(0, SSGRID2.ActiveRow)
    '                            '        SSGRID2.Focus()
    '                            '        Exit Sub
    '                            '    End If
    '                            'Next
    '                            SSGRID2.SetText(2, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME")))
    '                            SSGRID2.Col = 3
    '                            SSGRID2.Row = i
    '                            SSGRID2.TypeComboBoxString = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
    '                            SSGRID2.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
    '                            Issuerate = CalAverageRate(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
    '                            SSGRID2.SetText(5, i, Format(Val(Issuerate), "0.00"))
    '                            SSGRID2.SetText(8, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("CONVUOM")))
    '                            SSGRID2.SetText(9, i, Val(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("HIGHRATIO")))
    '                            SSGRID2.SetText(10, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("GROUPCODE")))
    '                            SSGRID2.SetText(11, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("SUBGROUPCODE")))
    ''                            clsquantity = ClosingQuantity(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), "MNS")
    '                            clsquantity = ClosingQuantity(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), GETMAINSTORE())
    '                            'lbl_closingqty.Text = UCase(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME"))) & " CLOSING QTY : " & Format(Val(clsquantity), "0.000")
    '                            SSGRID2.SetActiveCell(3, SSGRID2.ActiveRow)
    '                            SSGRID2.Focus()
    '                        Else
    '                            MessageBox.Show("Specified ITEM CODE not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                            SSGRID2.SetActiveCell(0, SSGRID2.ActiveRow)
    '                            SSGRID2.Text = ""
    '                            SSGRID2.Focus()
    '                            Exit Sub
    '                        End If
    '                    End If
    '                Else
    '                    SSGRID2.SetActiveCell(1, SSGRID2.ActiveRow)
    '                End If
    '            ElseIf SSGRID2.ActiveCol = 2 Then
    '                SSGRID2.Col = 2
    '                i = SSGRID2.ActiveRow
    '                SSGRID2.Row = i
    '                If SSGRID2.Lock = False Then
    '                    If Trim(SSGRID2.Text) = "" Then
    '                        Call FillMenuItem() ''' IT WILL SHOW A POPUP MENU FOR ITEM CODE
    '                    Else
    '                        Itemdesc = Trim(SSGRID2.Text)
    '                        SSGRID2.ClearRange(1, SSGRID2.ActiveRow, 10, SSGRID2.ActiveRow, True)
    '                        '''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
    '                        sqlstring = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, "
    '                        sqlstring = sqlstring & " ISNULL(O.CONVUOM,'') AS CONVUOM,ISNULL(O.HIGHRATIO,0) AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, "
    '                        sqlstring = sqlstring & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I INNER JOIN OPENINGSTOCK AS O ON O.ITEMCODE = I.ITEMCODE "
    '                        sqlstring = sqlstring & " WHERE I.ITEMNAME ='" & Trim(Itemdesc) & "'  AND ISNULL(I.FREEZE,'') <> 'Y'"
    '                        gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER1")
    '                        If gdataset.Tables("INVENTORYITEMMASTER1").Rows.Count > 0 Then
    '                            Call GridUOM(i) '''---> Fill the UOM feild
    '                            SSGRID2.SetText(1, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
    '                            'For K = 1 To SSGRID2.DataRowCnt
    '                            '    SSGRID2.Row = K
    '                            '    SSGRID2.Col = 1
    '                            '    If Itemvalidate(SSGRID2, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), 1) = True Then
    '                            '        SSGRID2.SetActiveCell(1, SSGRID2.ActiveRow)
    '                            '        SSGRID2.Focus()
    '                            '        Exit Sub
    '                            '    End If
    '                            'Next
    '                            SSGRID2.SetText(2, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME")))
    '                            SSGRID2.Col = 3
    '                            SSGRID2.Row = i
    '                            SSGRID2.TypeComboBoxString = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
    '                            SSGRID2.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
    '                            Issuerate = CalAverageRate(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
    '                            SSGRID2.SetText(5, i, Format(Val(Issuerate), "0.00"))
    '                            SSGRID2.SetText(8, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("CONVUOM")))
    '                            SSGRID2.SetText(9, i, Val(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("HIGHRATIO")))
    '                            SSGRID2.SetText(10, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("GROUPCODE")))
    '                            SSGRID2.SetText(11, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("SUBGROUPCODE")))
    ''                           clsquantity = ClosingQuantity(Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE"))), "MNS")
    '                            clsquantity = ClosingQuantity(Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE"))), GETMAINSTORE())
    '                            'lbl_closingqty.Text = UCase(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME"))) & " CLOSING QTY : " & Format(Val(clsquantity), "0.000")
    '                            SSGRID2.SetActiveCell(3, SSGRID2.ActiveRow)
    '                        Else
    '                            MessageBox.Show("Specified ITEM DESCRIPTION not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                            SSGRID2.SetActiveCell(1, SSGRID2.ActiveRow)
    '                            SSGRID2.Text = ""
    '                            SSGRID2.Focus()
    '                            Exit Sub
    '                        End If
    '                    End If
    '                End If
    '            ElseIf SSGRID2.ActiveCol = 3 Then
    '                SSGRID2.Col = 3
    '                i = SSGRID2.ActiveRow
    '                SSGRID2.Row = i
    '                If SSGRID2.Lock = False Then
    '                    If Trim(SSGRID2.Text) = "" Then
    '                        SSGRID2.SetActiveCell(2, SSGRID2.ActiveRow)
    '                    End If
    '                End If
    '            ElseIf SSGRID2.ActiveCol = 4 Then
    '                SSGRID2.Col = 4
    '                i = SSGRID2.ActiveRow
    '                SSGRID2.Row = i
    '                If SSGRID2.Lock = False Then
    '                    If Val(SSGRID2.Text) = 0 Then
    '                        SSGRID2.SetActiveCell(3, SSGRID2.ActiveRow)
    '                    Else
    '                        Call Calculate() '''--> Calculate total amount
    '                        SSGRID2.Row = SSGRID2.ActiveRow + 1
    '                        SSGRID2.Col = 1
    '                        SSGRID2.Lock = False
    '                        SSGRID2.Col = 2
    '                        SSGRID2.Lock = False
    '                        SSGRID2.Col = 3
    '                        SSGRID2.Lock = False
    '                        SSGRID2.Col = 4
    '                        SSGRID2.Lock = False
    '                        SSGRID2.Col = 5
    '                        SSGRID2.Lock = False
    '                        SSGRID2.Col = 6
    '                        SSGRID2.Lock = False
    '                        SSGRID2.SetActiveCell(0, SSGRID2.ActiveRow + 1)
    '                    End If
    '                End If
    '            ElseIf SSGRID2.ActiveCol = 5 Then
    '                SSGRID2.Col = 5
    '                i = SSGRID2.ActiveRow
    '                SSGRID2.Row = i
    '                If SSGRID2.Lock = False Then
    '                    If Val(SSGRID2.Text) = 0 Then
    '                        SSGRID2.SetActiveCell(4, SSGRID2.ActiveRow)
    '                    Else
    '                        Call Calculate() '''--> Calculate total amount
    '                        SSGRID2.Row = SSGRID2.ActiveRow + 1
    '                        SSGRID2.Col = 1
    '                        SSGRID2.Lock = False
    '                        SSGRID2.Col = 2
    '                        SSGRID2.Lock = False
    '                        SSGRID2.Col = 3
    '                        SSGRID2.Lock = False
    '                        SSGRID2.Col = 4
    '                        SSGRID2.Lock = False
    '                        SSGRID2.Col = 5
    '                        SSGRID2.Lock = False
    '                        SSGRID2.Col = 6
    '                        SSGRID2.Lock = False
    '                        SSGRID2.SetActiveCell(0, SSGRID2.ActiveRow + 1)
    '                    End If
    '                End If
    '            ElseIf SSGRID2.ActiveCol = 6 Then
    '                SSGRID2.Col = 6
    '                i = SSGRID2.ActiveRow
    '                SSGRID2.Row = i
    '                If SSGRID2.Lock = False Then
    '                    If Val(SSGRID2.Text) = 0 Then
    '                        SSGRID2.SetActiveCell(5, SSGRID2.ActiveRow)
    '                    Else
    '                        SSGRID2.SetActiveCell(0, SSGRID2.ActiveRow + 1)
    '                    End If
    '                Else
    '                    SSGRID2.SetActiveCell(6, SSGRID2.ActiveRow)
    '                End If
    '            ElseIf SSGRID2.ActiveCol = 7 Then
    '                SSGRID2.Col = 7
    '                i = SSGRID2.ActiveRow
    '                SSGRID2.Row = i
    '                If SSGRID2.Lock = False Then
    '                    If Trim(SSGRID2.Text) = "" Then
    '                        SSGRID2.SetActiveCell(6, SSGRID2.ActiveRow)
    '                    Else
    '                        SSGRID2.SetActiveCell(0, SSGRID2.ActiveRow + 1)
    '                    End If
    '                End If
    '            ElseIf SSGRID2.ActiveCol = 8 Then
    '                SSGRID2.Col = 8
    '                i = SSGRID2.ActiveRow
    '                SSGRID2.Row = i
    '                If SSGRID2.Lock = False Then
    '                    If Trim(SSGRID2.Text) = "" Then
    '                        SSGRID2.SetActiveCell(7, SSGRID2.ActiveRow)
    '                    Else
    '                        SSGRID2.SetActiveCell(0, SSGRID2.ActiveRow + 1)
    '                    End If
    '                End If
    '            ElseIf SSGRID2.ActiveCol = 9 Then
    '                SSGRID2.Col = 9
    '                i = SSGRID2.ActiveRow
    '                SSGRID2.Row = i
    '                If SSGRID2.Lock = False Then
    '                    If Trim(SSGRID2.Text) = "" Then
    '                        SSGRID2.SetActiveCell(8, SSGRID2.ActiveRow)
    '                    Else
    '                        SSGRID2.SetActiveCell(0, SSGRID2.ActiveRow + 1)
    '                    End If
    '                End If
    '            End If
    '        ElseIf e.keyCode = Keys.F4 Then
    '            If SSGRID2.ActiveCol = 1 Then
    '                SSGRID2.Col = 1
    '                SSGRID2.Row = i
    '                If SSGRID2.Lock = False Then
    '                    SSGRID2.Col = 1
    '                    SSGRID2.Row = SSGRID2.ActiveRow
    '                    search = Trim(SSGRID2.Text)
    '                    Call FillMenu()
    '                End If
    '            ElseIf SSGRID2.ActiveCol = 2 Then
    '                SSGRID2.Col = 2
    '                SSGRID2.Row = i
    '                If SSGRID2.Lock = False Then
    '                    SSGRID2.Col = 2
    '                    SSGRID2.Row = SSGRID2.ActiveRow
    '                    search = Trim(SSGRID2.Text)
    '                    Call FillMenuItem()
    '                End If
    '            End If
    '        ElseIf e.keyCode = Keys.F3 Then
    '            SSGRID2.Col = SSGRID2.ActiveCol
    '            i = SSGRID2.ActiveRow
    '            SSGRID2.Row = i
    '            If SSGRID2.Lock = False Then
    '                With SSGRID2
    '                    .Row = .ActiveRow
    '                    .ClearRange(1, .ActiveRow, 11, .ActiveRow, True)
    '                    .DeleteRows(.ActiveRow, 1)
    '                    Call Calculate()
    '                    .SetActiveCell(1, SSGRID2.ActiveRow)
    '                    .Focus()
    '                End With
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
    '        Exit Sub
    '    End Try
    'End Sub
    Private Sub Cmd_Menucodehelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Menucodehelp.Click
        Try
            gSQLString = "SELECT  distinct ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMDESC,'') FROM ITEMMASTER "
            If Trim(search) = " " Then
                M_WhereCondition = " "
            Else
                M_WhereCondition = " "
            End If
            Dim vform As New List_Operation
            vform.Field = "ITEMCODE,ITEMDESC"
            vform.vFormatstring1 = "  ITEM CODE         |                               ITEM DESCRIPTION                             "
            vform.vCaption = " ITEM MASTER HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_Menucode.Text = Trim(vform.keyfield & "")
                Call txt_Menucode_Validated(txt_Menucode, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub Cbo_Itemuom_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_Itemuom.Validated
        Try
            Dim J, K As Integer
            If Trim(txt_Menucode.Text) <> "" And Trim(Cbo_Itemuom.Text) <> "" Then
                Try
                    sqlstring = "SELECT ISNULL(H.ITEMCODE,'') AS ITEMCODE,ISNULL(H.ITEMNAME,'') AS ITEMDESC,ISNULL(H.ITEMUOM,'') AS ITEMUOM,"
                    sqlstring = sqlstring & " ISNULL(H.VOID,'') AS VOID,ADDDATE FROM BOM_HDR AS H WHERE ISNULL(H.ITEMCODE,'')  ='" & Trim(txt_Menucode.Text) & "' AND ISNULL(H.ITEMUOM,'') = '" & Trim(Cbo_Itemuom.Text) & "'"
                    gconnection.getDataSet(sqlstring, "BOM_HDR")
                    If gdataset.Tables("BOM_HDR").Rows.Count > 0 Then
                        txt_Menucode.Text = Trim(gdataset.Tables("BOM_HDR").Rows(0).Item("ITEMCODE"))
                        txt_Menuname.Text = Trim(gdataset.Tables("BOM_HDR").Rows(0).Item("ITEMDESC"))
                        Cbo_Itemuom.DropDownStyle = ComboBoxStyle.DropDown
                        Cbo_Itemuom.Text = Trim(gdataset.Tables("BOM_HDR").Rows(0).Item("ITEMUOM"))
                        Cbo_Itemuom.DropDownStyle = ComboBoxStyle.DropDownList
                        '------------------------------------- SELECT RECORDS FROM BOM_DET -------------
                        sqlstring = "SELECT ISNULL(D.GITEMCODE,'') AS GITEMCODE,ISNULL(D.GITEMNAME,'') AS GITEMNAME,ISNULL(D.GUOM,'') AS UOM,"
                        sqlstring = sqlstring & " ISNULL(D.GQTY,0) AS QTY,ISNULL(D.GRATE,0) AS RATE,ISNULL(D.GAMOUNT,0) AS AMOUNT,ISNULL(D.GDBLAMT,0) AS DBLAMT,"
                        sqlstring = sqlstring & " ISNULL(D.GHIGHRATIO,0) AS HIGHRATIO,ISNULL(D.GGROUPCODE,'') AS GROUPCODE,ISNULL(D.GSUBGROUPCODE,'') AS SUBGROUPCODE,"
                        sqlstring = sqlstring & " ISNULL(D.VOID,'') AS VOID FROM BOM_DET AS D WHERE ISNULL(D.ITEMCODE,'')  ='" & Trim(txt_Menucode.Text) & "' AND ISNULL(D.ITEMUOM,'') = '" & Trim(Cbo_Itemuom.Text) & "'"
                        gconnection.getDataSet(sqlstring, "BOM_DET")
                        If gdataset.Tables("BOM_DET").Rows.Count > 0 Then
                            For i = 1 To gdataset.Tables("BOM_DET").Rows.Count
                                SSGRID2.SetText(1, i, Trim(gdataset.Tables("BOM_DET").Rows(J).Item("GITEMCODE")))
                                SSGRID2.SetText(2, i, Trim(gdataset.Tables("BOM_DET").Rows(J).Item("GITEMNAME")))
                                SSGRID2.Col = 3
                                SSGRID2.Row = i
                                SSGRID2.TypeComboBoxString = Trim(gdataset.Tables("BOM_DET").Rows(J).Item("UOM"))
                                SSGRID2.Text = Trim(gdataset.Tables("BOM_DET").Rows(J).Item("UOM"))
                                SSGRID2.SetText(4, i, Format(Val(gdataset.Tables("BOM_DET").Rows(J).Item("QTY")), "0.000"))
                                SSGRID2.SetText(5, i, Format(Val(gdataset.Tables("BOM_DET").Rows(J).Item("RATE")), "0.00"))
                                SSGRID2.SetText(6, i, Format(Val(gdataset.Tables("BOM_DET").Rows(J).Item("AMOUNT")), "0.00"))
                                SSGRID2.SetText(7, i, Format(Val(gdataset.Tables("BOM_DET").Rows(J).Item("DBLAMT")), "0.000"))
                                SSGRID2.SetText(9, i, Format(Val(gdataset.Tables("BOM_DET").Rows(J).Item("HIGHRATIO")), "0.00"))
                                SSGRID2.SetText(10, i, Trim(gdataset.Tables("BOM_DET").Rows(J).Item("GROUPCODE")))
                                SSGRID2.SetText(11, i, Trim(gdataset.Tables("BOM_DET").Rows(J).Item("SUBGROUPCODE")))
                                J = J + 1
                            Next
                            'Cbo_Itemuom.SelectedIndex = 0
                            'Cbo_Itemuom.Focus()
                        End If
                        If gdataset.Tables("BOM_HDR").Rows(0).Item("VOID") = "Y" Then
                            Me.lbl_Freeze.Visible = True
                            Me.lbl_Freeze.Text = Me.lbl_Freeze.Text & Format(CDate(gdataset.Tables("BOM_HDR").Rows(0).Item("AddDate")), "dd/MMM/yyyy")
                            Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                        Else
                            Me.lbl_Freeze.Visible = False
                            Me.lbl_Freeze.Text = "Record Freezed  On "
                            Me.Cmd_Freeze.Text = "Freeze[F8]"
                        End If
                        Me.Cmd_Add.Text = "Update[F7]"

                        txt_Menucode.ReadOnly = True
                        txt_Menuname.ReadOnly = True
                        Me.Cmd_Add.Text = "Update[F7]"
                    Else
                        ssgrid.Focus()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Enter a valid ITEM CODE ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    'Private Sub Cbo_Itemuom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_Itemuom.SelectedIndexChanged
    '    Dim sqlstring As String
    '    If Trim(Cbo_Itemuom.Text) <> "" Then
    '        sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMDESC,'') AS ITEMDESC,ISNULL(R.UOM,'') AS UOM,ISNULL(R.ITEMRATE,0) AS ITEMRATE"
    '        sqlstring = sqlstring & " FROM ITEMMASTER AS I  INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE"
    '        sqlstring = sqlstring & " WHERE ISNULL(I.ITEMCODE,'') = '" & Trim(txt_Menucode.Text) & "' AND ISNULL(R.UOM,'') = '" & Trim(Cbo_Itemuom.Text) & "' AND ISNULL(I.FREEZE,'') <> 'Y' AND I.POS IN (SELECT STORECODE FROM STOREMASTER)"
    '        gconnection.getDataSet(sqlstring, "ITEMMASTERSELECTION")
    '        If gdataset.Tables("ITEMMASTERSELECTION").Rows.Count > 0 Then
    '            txt_Salerate.Text = Format(Val(gdataset.Tables("ITEMMASTERSELECTION").Rows(0).Item("ITEMRATE")), "0.00")
    '            SSGRID2.Focus()
    '        Else
    '            txt_Salerate.Text = ""
    '        End If
    '    Else
    '        Cbo_Itemuom.Focus()
    '    End If
    'End Sub

    Private Sub txt_Menucode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Menucode.KeyDown
        Try
            If e.KeyCode = Keys.F4 Then
                If Cmd_Menucodehelp.Enabled = True Then
                    search = Trim(txt_Menucode.Text)
                    Call Cmd_Menucodehelp_Click(Cmd_Menucodehelp, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Menucode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Menucode.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                If Trim(txt_Menucode.Text) = "" Then
                    Call Cmd_Menucodehelp_Click(Cmd_Menucodehelp, e)
                Else
                    txt_Menucode_Validated(txt_Menucode, e)
                    'Cbo_Itemuom.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub SSGRID2_LeaveCell(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles SSGRID2.LeaveCell
        Try
            Dim Issuerate, Highratio, Dblamount, ItemQty, ItemAmount, ItemRate, clsquantity As Double
            Dim sqlstring, Itemcode, Itemdesc As String
            Dim focusbool As Boolean
            Dim i, j, K As Integer
            search = Nothing
            If SSGRID2.ActiveCol = 1 Or SSGRID2.ActiveCol = 2 Then
                Call Calculate()
            End If
            i = SSGRID2.ActiveRow
            If SSGRID2.ActiveCol = 4 Then
                SSGRID2.Col = 4
                i = SSGRID2.ActiveRow
                SSGRID2.Row = i
                If SSGRID2.Lock = False Then
                    If Val(SSGRID2.Text) = 0 Then
                        SSGRID2.SetActiveCell(4, SSGRID2.ActiveRow)
                    Else
                        Call Calculate() '''--> Calculate total amount
                        SSGRID2.Row = SSGRID2.ActiveRow + 1
                        SSGRID2.Col = 1
                        SSGRID2.Lock = False
                        SSGRID2.Col = 2
                        SSGRID2.Lock = False
                        SSGRID2.Col = 3
                        SSGRID2.Lock = False
                        SSGRID2.Col = 4
                        SSGRID2.Lock = False
                        SSGRID2.Col = 5
                        SSGRID2.Lock = False
                        SSGRID2.Col = 6
                        SSGRID2.Lock = False
                        SSGRID2.SetActiveCell(1, SSGRID2.ActiveRow + 1)
                    End If
                End If
            ElseIf SSGRID2.ActiveCol = 5 Then
                SSGRID2.Col = 5
                i = SSGRID2.ActiveRow
                SSGRID2.Row = i
                If SSGRID2.Lock = False Then
                    If Val(SSGRID2.Text) = 0 Then
                        SSGRID2.SetActiveCell(5, SSGRID2.ActiveRow)
                    Else
                        Call Calculate() '''--> Calculate total amount
                        SSGRID2.Row = SSGRID2.ActiveRow + 1
                        SSGRID2.Col = 1
                        SSGRID2.Lock = False
                        SSGRID2.Col = 2
                        SSGRID2.Lock = False
                        SSGRID2.Col = 3
                        SSGRID2.Lock = False
                        SSGRID2.Col = 4
                        SSGRID2.Lock = False
                        SSGRID2.Col = 5
                        SSGRID2.Lock = False
                        SSGRID2.Col = 6
                        SSGRID2.Lock = False
                        SSGRID2.SetActiveCell(1, SSGRID2.ActiveRow + 1)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Cbo_Itemuom_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_Itemuom.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                SSGRID2.Focus()
                SSGRID2.SetActiveCell(1, 1)
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub SSGRID2_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles SSGRID2.KeyDownEvent
        Try
            Dim Issuerate, Highratio, Dblamount, clsquantity As Double
            Dim ItemQty, ItemAmount, ItemRate As Double
            Dim sqlstring, Itemcode, Itemdesc As String
            Dim focusbool As Boolean
            Dim i, j, K As Integer
            search = Nothing
            If e.keyCode = Keys.Enter Then
                i = SSGRID2.ActiveRow
                If SSGRID2.ActiveCol = 1 Then
                    SSGRID2.Col = 1
                    SSGRID2.Row = i
                    If SSGRID2.Lock = False Then
                        If Trim(SSGRID2.Text) = "" Then
                            Call FillMenu() ''' IT WILL SHOW A POPUP MENU FOR ITEM CODE
                        Else
                            Itemcode = Trim(SSGRID2.Text)
                            SSGRID2.ClearRange(1, SSGRID2.ActiveRow, 10, SSGRID2.ActiveRow, True)
                            '''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
                            sqlstring = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, ISNULL(I.PURCHASERATE,0.00) AS PURCHASERATE,"
                            sqlstring = sqlstring & " ISNULL(O.CONVUOM,'') AS CONVUOM,ISNULL(O.HIGHRATIO,0) AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, "
                            sqlstring = sqlstring & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I INNER JOIN OPENINGSTOCK AS O ON O.ITEMCODE = I.ITEMCODE "
                            sqlstring = sqlstring & " WHERE I.ITEMCODE ='" & Trim(Itemcode) & "'  AND ISNULL(I.FREEZE,'') <> 'Y'"
                            gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER1")
                            If gdataset.Tables("INVENTORYITEMMASTER1").Rows.Count > 0 Then
                                Call GridUOM(i) '''---> Fill the UOM feild
                                SSGRID2.SetText(1, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                'For K = 1 To SSGRID2.DataRowCnt
                                '    SSGRID2.Row = K
                                '    SSGRID2.Col = 1
                                '    If Itemvalidate(SSGRID2, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), 1) = True Then
                                '        SSGRID2.SetActiveCell(0, SSGRID2.ActiveRow)
                                '        SSGRID2.Focus()
                                '        Exit Sub
                                '    End If
                                'Next
                                SSGRID2.SetText(2, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME")))
                                SSGRID2.Col = 3
                                SSGRID2.Row = i
                                SSGRID2.TypeComboBoxString = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                SSGRID2.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                Issuerate = CalAverageRate(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                'SSGRID2.SetText(5, i, Format(Val(Issuerate), "0.00"))
                                SSGRID2.SetText(5, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("PURCHASERATE")))
                                SSGRID2.SetText(8, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("CONVUOM")))
                                SSGRID2.SetText(9, i, Val(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("HIGHRATIO")))
                                SSGRID2.SetText(10, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("GROUPCODE")))
                                SSGRID2.SetText(11, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("SUBGROUPCODE")))
                                'clsquantity = ClosingQuantity(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), "MNS")
                                clsquantity = ClosingQuantity(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), GetMainStore())
                                'lbl_closingqty.Text = UCase(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME"))) & " CLOSING QTY : " & Format(Val(clsquantity), "0.000")
                                SSGRID2.SetActiveCell(3, SSGRID2.ActiveRow)
                                SSGRID2.Focus()
                            Else
                                MessageBox.Show("Specified ITEM CODE not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                SSGRID2.SetActiveCell(0, SSGRID2.ActiveRow)
                                SSGRID2.Text = ""
                                SSGRID2.Focus()
                                Exit Sub
                            End If
                        End If
                    Else
                        SSGRID2.SetActiveCell(1, SSGRID2.ActiveRow)
                    End If
                ElseIf SSGRID2.ActiveCol = 2 Then
                    SSGRID2.Col = 2
                    i = SSGRID2.ActiveRow
                    SSGRID2.Row = i
                    If SSGRID2.Lock = False Then
                        If Trim(SSGRID2.Text) = "" Then
                            Call FillMenuItem() ''' IT WILL SHOW A POPUP MENU FOR ITEM CODE
                        Else
                            Itemdesc = Trim(SSGRID2.Text)
                            SSGRID2.ClearRange(1, SSGRID2.ActiveRow, 10, SSGRID2.ActiveRow, True)
                            '''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
                            sqlstring = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, "
                            sqlstring = sqlstring & " ISNULL(O.CONVUOM,'') AS CONVUOM,ISNULL(O.HIGHRATIO,0) AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, "
                            sqlstring = sqlstring & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I INNER JOIN OPENINGSTOCK AS O ON O.ITEMCODE = I.ITEMCODE "
                            sqlstring = sqlstring & " WHERE I.ITEMNAME ='" & Trim(Itemdesc) & "'  AND ISNULL(I.FREEZE,'') <> 'Y'"
                            gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER1")
                            If gdataset.Tables("INVENTORYITEMMASTER1").Rows.Count > 0 Then
                                Call GridUOM(i) '''---> Fill the UOM feild
                                SSGRID2.SetText(1, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                'For K = 1 To SSGRID2.DataRowCnt
                                '    SSGRID2.Row = K
                                '    SSGRID2.Col = 1
                                '    If Itemvalidate(SSGRID2, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), 1) = True Then
                                '        SSGRID2.SetActiveCell(1, SSGRID2.ActiveRow)
                                '        SSGRID2.Focus()
                                '        Exit Sub
                                '    End If
                                'Next
                                SSGRID2.SetText(2, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME")))
                                SSGRID2.Col = 3
                                SSGRID2.Row = i
                                SSGRID2.TypeComboBoxString = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                SSGRID2.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                Issuerate = CalAverageRate(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                SSGRID2.SetText(5, i, Format(Val(Issuerate), "0.00"))
                                SSGRID2.SetText(8, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("CONVUOM")))
                                SSGRID2.SetText(9, i, Val(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("HIGHRATIO")))
                                SSGRID2.SetText(10, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("GROUPCODE")))
                                SSGRID2.SetText(11, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("SUBGROUPCODE")))
                                'clsquantity = ClosingQuantity(Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE"))), "MNS")
                                clsquantity = ClosingQuantity(Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE"))), GetMainStore())
                                'lbl_closingqty.Text = UCase(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME"))) & " CLOSING QTY : " & Format(Val(clsquantity), "0.000")
                                SSGRID2.SetActiveCell(3, SSGRID2.ActiveRow)
                            Else
                                MessageBox.Show("Specified ITEM DESCRIPTION not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                SSGRID2.SetActiveCell(1, SSGRID2.ActiveRow)
                                SSGRID2.Text = ""
                                SSGRID2.Focus()
                                Exit Sub
                            End If
                        End If
                    End If
                ElseIf SSGRID2.ActiveCol = 3 Then
                    SSGRID2.Col = 3
                    i = SSGRID2.ActiveRow
                    SSGRID2.Row = i
                    If SSGRID2.Lock = False Then
                        If Trim(SSGRID2.Text) = "" Then
                            SSGRID2.SetActiveCell(2, SSGRID2.ActiveRow)
                        End If
                    End If
                ElseIf SSGRID2.ActiveCol = 4 Then
                    SSGRID2.Col = 4
                    i = SSGRID2.ActiveRow
                    SSGRID2.Row = i
                    If SSGRID2.Lock = False Then
                        If Val(SSGRID2.Text) = 0 Then
                            SSGRID2.SetActiveCell(3, SSGRID2.ActiveRow)
                        Else
                            Call Calculate() '''--> Calculate total amount
                            SSGRID2.Row = SSGRID2.ActiveRow + 1
                            SSGRID2.Col = 1
                            SSGRID2.Lock = False
                            SSGRID2.Col = 2
                            SSGRID2.Lock = False
                            SSGRID2.Col = 3
                            SSGRID2.Lock = False
                            SSGRID2.Col = 4
                            SSGRID2.Lock = False
                            SSGRID2.Col = 5
                            SSGRID2.Lock = False
                            SSGRID2.Col = 6
                            SSGRID2.Lock = False
                            SSGRID2.SetActiveCell(0, SSGRID2.ActiveRow + 1)
                        End If
                    End If
                ElseIf SSGRID2.ActiveCol = 5 Then
                    SSGRID2.Col = 5
                    i = SSGRID2.ActiveRow
                    SSGRID2.Row = i
                    If SSGRID2.Lock = False Then
                        If Val(SSGRID2.Text) = 0 Then
                            SSGRID2.SetActiveCell(4, SSGRID2.ActiveRow)
                        Else
                            Call Calculate() '''--> Calculate total amount
                            SSGRID2.Row = SSGRID2.ActiveRow + 1
                            SSGRID2.Col = 1
                            SSGRID2.Lock = False
                            SSGRID2.Col = 2
                            SSGRID2.Lock = False
                            SSGRID2.Col = 3
                            SSGRID2.Lock = False
                            SSGRID2.Col = 4
                            SSGRID2.Lock = False
                            SSGRID2.Col = 5
                            SSGRID2.Lock = False
                            SSGRID2.Col = 6
                            SSGRID2.Lock = False
                            SSGRID2.SetActiveCell(0, SSGRID2.ActiveRow + 1)
                        End If
                    End If
                ElseIf SSGRID2.ActiveCol = 6 Then
                    SSGRID2.Col = 6
                    i = SSGRID2.ActiveRow
                    SSGRID2.Row = i
                    If SSGRID2.Lock = False Then
                        If Val(SSGRID2.Text) = 0 Then
                            SSGRID2.SetActiveCell(5, SSGRID2.ActiveRow)
                        Else
                            SSGRID2.SetActiveCell(0, SSGRID2.ActiveRow + 1)
                        End If
                    Else
                        SSGRID2.SetActiveCell(6, SSGRID2.ActiveRow)
                    End If
                ElseIf SSGRID2.ActiveCol = 7 Then
                    SSGRID2.Col = 7
                    i = SSGRID2.ActiveRow
                    SSGRID2.Row = i
                    If SSGRID2.Lock = False Then
                        If Trim(SSGRID2.Text) = "" Then
                            SSGRID2.SetActiveCell(6, SSGRID2.ActiveRow)
                        Else
                            SSGRID2.SetActiveCell(0, SSGRID2.ActiveRow + 1)
                        End If
                    End If
                ElseIf SSGRID2.ActiveCol = 8 Then
                    SSGRID2.Col = 8
                    i = SSGRID2.ActiveRow
                    SSGRID2.Row = i
                    If SSGRID2.Lock = False Then
                        If Trim(SSGRID2.Text) = "" Then
                            SSGRID2.SetActiveCell(7, SSGRID2.ActiveRow)
                        Else
                            SSGRID2.SetActiveCell(0, SSGRID2.ActiveRow + 1)
                        End If
                    End If
                ElseIf SSGRID2.ActiveCol = 9 Then
                    SSGRID2.Col = 9
                    i = SSGRID2.ActiveRow
                    SSGRID2.Row = i
                    If SSGRID2.Lock = False Then
                        If Trim(SSGRID2.Text) = "" Then
                            SSGRID2.SetActiveCell(8, SSGRID2.ActiveRow)
                        Else
                            SSGRID2.SetActiveCell(0, SSGRID2.ActiveRow + 1)
                        End If
                    End If
                End If
            ElseIf e.keyCode = Keys.F4 Then
                If SSGRID2.ActiveCol = 1 Then
                    SSGRID2.Col = 1
                    SSGRID2.Row = i
                    If SSGRID2.Lock = False Then
                        SSGRID2.Col = 1
                        SSGRID2.Row = SSGRID2.ActiveRow
                        search = Trim(SSGRID2.Text)
                        Call FillMenu()
                    End If
                ElseIf SSGRID2.ActiveCol = 2 Then
                    SSGRID2.Col = 2
                    SSGRID2.Row = i
                    If SSGRID2.Lock = False Then
                        SSGRID2.Col = 2
                        SSGRID2.Row = SSGRID2.ActiveRow
                        search = Trim(SSGRID2.Text)
                        Call FillMenuItem()
                    End If
                End If
            ElseIf e.keyCode = Keys.F3 Then
                SSGRID2.Col = SSGRID2.ActiveCol
                i = SSGRID2.ActiveRow
                SSGRID2.Row = i
                If SSGRID2.Lock = False Then
                    With SSGRID2
                        .Row = .ActiveRow
                        .ClearRange(1, .ActiveRow, 11, .ActiveRow, True)
                        .DeleteRows(.ActiveRow, 1)
                        Call Calculate()
                        .SetActiveCell(1, SSGRID2.ActiveRow)
                        .Focus()
                    End With
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Menucode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Menucode.Validated
        Try
            If Trim(txt_Menucode.Text & "") <> "" Then
                sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMDESC,'') AS ITEMDESC,ISNULL(R.UOM,'') AS UOM"
                sqlstring = sqlstring & " FROM ITEMMASTER AS I  INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE"
                sqlstring = sqlstring & " WHERE ISNULL(I.ITEMCODE,'') = '" & Trim(txt_Menucode.Text) & "' AND ISNULL(I.FREEZE,'') <> 'Y'    "
                'sqlstring = sqlstring & " AND GROUPCODE='BAR'"
                gconnection.getDataSet(sqlstring, "ITEMMASTER")
                If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                    txt_Menucode.Text = Trim(gdataset.Tables("ITEMMASTER").Rows(0).Item("ITEMCODE"))
                    txt_Menuname.Text = Trim(gdataset.Tables("ITEMMASTER").Rows(0).Item("ITEMDESC"))
                    'For K = 0 To gdataset.Tables("ITEMMASTER").Rows.Count - 1 Step 1
                    'Cbo_Itemuom.Items.Add(Trim(gdataset.Tables("ITEMMASTER").Rows(K).Item("UOM")))
                    'Next K
                    'Cbo_Itemuom.DropDownStyle = ComboBoxStyle.DropDownList
                    Cbo_Itemuom.SelectedIndex = 0
                    txt_Menucode.ReadOnly = True
                    txt_Menuname.ReadOnly = True
                    Cbo_Itemuom.Focus()
                Else
                    Me.Cmd_Add.Text = "Add [F7]"
                    txt_Menucode.ReadOnly = False
                    txt_Menucode.Text = ""
                    txt_Menucode.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
End Class
