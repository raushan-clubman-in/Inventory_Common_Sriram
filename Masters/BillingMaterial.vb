Imports System.Data.SqlClient
Imports System.IO
Public Class frm_BillingMaterial
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
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents frmbut As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_Typecode As System.Windows.Forms.TextBox
    Friend WithEvents txt_Typedescription As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_TypecodeHelp As System.Windows.Forms.Button
    Friend WithEvents ssgrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents cmd_View As System.Windows.Forms.Button
    Friend WithEvents cmd_Print As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frm_BillingMaterial))
        Me.ssgrid = New AxFPSpreadADO.AxfpSpread
        Me.Cmd_Clear = New System.Windows.Forms.Button
        Me.Cmd_Freeze = New System.Windows.Forms.Button
        Me.Cmd_Add = New System.Windows.Forms.Button
        Me.Cmd_Exit = New System.Windows.Forms.Button
        Me.frmbut = New System.Windows.Forms.GroupBox
        Me.cmd_View = New System.Windows.Forms.Button
        Me.cmd_Print = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_Typecode = New System.Windows.Forms.TextBox
        Me.txt_Typedescription = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Cmd_TypecodeHelp = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.lbl_Freeze = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmbut.SuspendLayout()
        Me.SuspendLayout()
        '
        'ssgrid
        '
        Me.ssgrid.DataSource = Nothing
        Me.ssgrid.Location = New System.Drawing.Point(72, 160)
        Me.ssgrid.Name = "ssgrid"
        Me.ssgrid.OcxState = CType(resources.GetObject("ssgrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid.Size = New System.Drawing.Size(880, 272)
        Me.ssgrid.TabIndex = 1
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Clear.Location = New System.Drawing.Point(160, 488)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Clear.TabIndex = 3
        Me.Cmd_Clear.Text = "Clear[F6]"
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Freeze.Location = New System.Drawing.Point(416, 488)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Freeze.TabIndex = 4
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Add.Location = New System.Drawing.Point(296, 488)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Add.TabIndex = 2
        Me.Cmd_Add.Text = "Add [F7]"
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Exit.Location = New System.Drawing.Point(792, 488)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Exit.TabIndex = 5
        Me.Cmd_Exit.Text = "Exit[F11]"
        '
        'frmbut
        '
        Me.frmbut.BackColor = System.Drawing.Color.Transparent
        Me.frmbut.Controls.Add(Me.cmd_View)
        Me.frmbut.Controls.Add(Me.cmd_Print)
        Me.frmbut.Location = New System.Drawing.Point(144, 472)
        Me.frmbut.Name = "frmbut"
        Me.frmbut.Size = New System.Drawing.Size(776, 56)
        Me.frmbut.TabIndex = 13
        Me.frmbut.TabStop = False
        '
        'cmd_View
        '
        Me.cmd_View.BackColor = System.Drawing.Color.Transparent
        Me.cmd_View.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_View.ForeColor = System.Drawing.Color.Black
        Me.cmd_View.Location = New System.Drawing.Point(400, 16)
        Me.cmd_View.Name = "cmd_View"
        Me.cmd_View.Size = New System.Drawing.Size(104, 32)
        Me.cmd_View.TabIndex = 15
        Me.cmd_View.Text = " View[F9]"
        '
        'cmd_Print
        '
        Me.cmd_Print.BackColor = System.Drawing.Color.Transparent
        Me.cmd_Print.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Print.ForeColor = System.Drawing.Color.Black
        Me.cmd_Print.Location = New System.Drawing.Point(528, 16)
        Me.cmd_Print.Name = "cmd_Print"
        Me.cmd_Print.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Print.TabIndex = 14
        Me.cmd_Print.Text = "Print[F10]"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(656, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 18)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "TYPE CODE :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(600, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(142, 18)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "TYPE DESCRIPTION :"
        '
        'txt_Typecode
        '
        Me.txt_Typecode.BackColor = System.Drawing.Color.Wheat
        Me.txt_Typecode.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Typecode.Location = New System.Drawing.Point(752, 72)
        Me.txt_Typecode.MaxLength = 10
        Me.txt_Typecode.Name = "txt_Typecode"
        Me.txt_Typecode.Size = New System.Drawing.Size(72, 26)
        Me.txt_Typecode.TabIndex = 7
        Me.txt_Typecode.Text = ""
        '
        'txt_Typedescription
        '
        Me.txt_Typedescription.BackColor = System.Drawing.Color.Wheat
        Me.txt_Typedescription.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Typedescription.Location = New System.Drawing.Point(752, 112)
        Me.txt_Typedescription.MaxLength = 50
        Me.txt_Typedescription.Name = "txt_Typedescription"
        Me.txt_Typedescription.Size = New System.Drawing.Size(184, 26)
        Me.txt_Typedescription.TabIndex = 0
        Me.txt_Typedescription.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Location = New System.Drawing.Point(584, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(368, 96)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'Cmd_TypecodeHelp
        '
        Me.Cmd_TypecodeHelp.Image = CType(resources.GetObject("Cmd_TypecodeHelp.Image"), System.Drawing.Image)
        Me.Cmd_TypecodeHelp.Location = New System.Drawing.Point(824, 72)
        Me.Cmd_TypecodeHelp.Name = "Cmd_TypecodeHelp"
        Me.Cmd_TypecodeHelp.Size = New System.Drawing.Size(23, 25)
        Me.Cmd_TypecodeHelp.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(296, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(339, 29)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "PURCHASE BILLING TERMS"
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(80, 128)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(173, 25)
        Me.lbl_Freeze.TabIndex = 12
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(72, 440)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(208, 23)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "[F3 DELETE A ROW IN GRID]"
        '
        'frm_BillingMaterial
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.ClientSize = New System.Drawing.Size(982, 548)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Cmd_TypecodeHelp)
        Me.Controls.Add(Me.txt_Typedescription)
        Me.Controls.Add(Me.txt_Typecode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.Cmd_Freeze)
        Me.Controls.Add(Me.Cmd_Add)
        Me.Controls.Add(Me.Cmd_Exit)
        Me.Controls.Add(Me.frmbut)
        Me.Controls.Add(Me.ssgrid)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "frm_BillingMaterial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BILLING TERMS"
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmbut.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim gconnection As New GlobalClass
    Dim boolchk, entrybool As Boolean
    Dim sqlstring As String
    Dim i As Integer = 1
    Dim PAGESIZE, PAGENO As Integer
    Dim DR As DataRow

    Private Sub BillingMaterial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BillingMaterialbool = True
        Call Autogenerate()
        ssgrid.SetActiveCell(1, 1)
        txt_Typecode.Enabled = True
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        txt_Typecode.Focus()
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call clearform(Me)
        Call Autogenerate()
        ssgrid.ClearRange(1, 1, -1, -1, True)
        txt_Typecode.Enabled = True
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        ssgrid.SetActiveCell(1, 1)
    End Sub

    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='INVENTORY' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
        gconnection.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.Cmd_Add.Enabled = False
        Me.Cmd_Freeze.Enabled = False
        Me.Cmd_View.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_Add.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                    Me.Cmd_View.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.Cmd_Add.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.Cmd_Add.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.Cmd_Add.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    Me.Cmd_Freeze.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.Cmd_View.Enabled = True
                End If
                If Right(x) = "P" Then
                    Me.cmd_Print.Enabled = True
                End If
            Next
        End If
    End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim strSQL As String
        Dim varpurchrate, varsalerate, avgrate As Double
        Dim Insert(0), Update(0), account() As String
        If Cmd_Add.Text = "Add [F7]" Then
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            '''************************************* For Purchase Bill Terms **********************************''''
            entrybool = False
            For i = 1 To ssgrid.DataRowCnt
                ssgrid.Col = 1
                ssgrid.Row = i
                If Trim(ssgrid.Text) <> "" Then
                    strSQL = "INSERT INTO Purchasebillterms (Typecode,Typedesc,Slno,Billdescription,Tax,Accode,Acdesc,"
                    strSQL = strSQL & " Signs,Formula,Freeze,Userid,Adddatetime)"
                    strSQL = strSQL & " VALUES('" & Trim(txt_Typecode.Text) & "','" & Replace(Trim(txt_Typedescription.Text), "'", "") & "' ,"
                    ssgrid.Col = 1
                    strSQL = strSQL & " " & Val(i) & ",'" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 2
                    strSQL = strSQL & " '" & Trim(ssgrid.Text) & "',"
                    If Trim(ssgrid.Text) = "N" Then
                        ssgrid.Col = 3
                        account = Split(Trim(ssgrid.Text), "-->>")
                        strSQL = strSQL & " '" & Trim(account(0)) & "','" & Trim(account(1)) & "',"
                    Else
                        strSQL = strSQL & " '','',"
                    End If
                    ssgrid.Col = 4
                    strSQL = strSQL & " '" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 5
                    If Trim(ssgrid.Text) = "" Then
                        strSQL = strSQL & " 'B',"
                    Else
                        strSQL = strSQL & " '" & Trim(ssgrid.Text) & "',"
                    End If

                    strSQL = strSQL & " 'N','" & Trim(gUsername) & "',getDate())"
                    If entrybool = False Then
                        Insert(0) = strSQL
                        entrybool = True
                    Else
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = strSQL
                    End If
                End If
            Next i
            gconnection.MoreTrans(Insert)
            Me.Cmd_Clear_Click(sender, e)
        ElseIf Cmd_Add.Text = "Update[F7]" Then
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    boolchk = False
                End If
            End If
        End If
    End Sub
    Public Sub checkValidation()
        boolchk = False
        '''****************************************************** Check  Typecode Can't be blank *********************'''
        If Val(txt_Typecode.Text) = 0 Then
            MessageBox.Show(" Type Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_Typecode.Focus()
            Exit Sub
        End If
        '''***************************************************** Check  Type description Can't be blank *********************'''
        If Trim(txt_Typedescription.Text) = "" Then
            MessageBox.Show(" Type description can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_Typedescription.Focus()
            Exit Sub
        End If
        ''' **************************************************** Check Description,Tax,GlaccountCode,Sign and Formaula can't be blank ***********'''
        For i = 1 To ssgrid.DataRowCnt
            ssgrid.Row = i
            ssgrid.Col = 1
            If Trim(ssgrid.Text) = "" Then
                MessageBox.Show("Description Feild's can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                ssgrid.Focus()
                Exit Sub
            End If
            ssgrid.Col = 2
            If Trim(ssgrid.Text) <> "Y" Then
                ssgrid.Col = 3
                If Trim(ssgrid.Text) = "" Then
                    MessageBox.Show("Plz Specify Account code for that particular description", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.Col = 2
                    ssgrid.Row = ssgrid.ActiveRow
                    ssgrid.Text = "N"
                    ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
                    ssgrid.Focus()
                    Exit Sub
                End If
            End If
            ssgrid.Col = 4
            If Trim(ssgrid.Text) = "" Then
                MessageBox.Show("Sign can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                ssgrid.Focus()
                Exit Sub
            End If
        Next i
        boolchk = True
    End Sub

    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Call checkValidation() ''-->Check Validation
        If boolchk = False Then Exit Sub
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then
            sqlstring = "UPDATE  PurchaseBillterms "
            sqlstring = sqlstring & " SET Freeze= 'Y',Userid='" & gUsername & " ', Adddatetime=getDate()"
            sqlstring = sqlstring & " WHERE Typecode = '" & Trim(txt_Typecode.Text) & "'"
            gconnection.dataOperation(3, sqlstring, "PurchaseBillterms")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
        Else
            sqlstring = "UPDATE  PurchaseBillterms "
            sqlstring = sqlstring & " SET Freeze= 'Y',Userid='" & gUsername & " ', Adddatetime=getDate()"
            sqlstring = sqlstring & " WHERE Typecode = '" & Trim(txt_Typecode.Text) & "'"
            gconnection.dataOperation(4, sqlstring, "PurchaseBillterms")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
        End If
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub txt_Typecode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Typecode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_Typecode.Text) = "" Then
                Call Cmd_TypecodeHelp_Click(Cmd_TypecodeHelp, e)
            Else
                txt_Typecode_Validated(txt_Typecode, e)
            End If
        End If
    End Sub

    Private Sub txt_Typedescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Typedescription.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            ssgrid.Focus()
        End If
    End Sub

    Private Sub ssgrid_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssgrid.KeyDownEvent
        Dim GLCODE(), ACHEAD, Sqlstring As String
        If e.keyCode = Keys.Enter Then
            If ssgrid.ActiveCol = 1 Then
                ssgrid.Col = 1
                ssgrid.Row = ssgrid.ActiveRow
                If Trim(ssgrid.Text) = "" Then
                    ssgrid.ClearRange(1, ssgrid.ActiveRow, 5, ssgrid.ActiveRow, True)
                    ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
                Else
                    ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                End If
            ElseIf ssgrid.ActiveCol = 2 Then
                ssgrid.Col = 2
                ssgrid.Row = ssgrid.ActiveRow
                If Trim(ssgrid.Text) = "" Or Trim(ssgrid.Text) = "N" Then
                    ssgrid.Text = "N"
                    ssgrid.Col = 3
                    ssgrid.Row = ssgrid.ActiveRow
                    ssgrid.Lock = False
                    ssgrid.SetActiveCell(2, ssgrid.ActiveRow)
                Else
                    ssgrid.Text = "Y"
                    ssgrid.Col = 3
                    ssgrid.Row = ssgrid.ActiveRow
                    ssgrid.Text = ""
                    ssgrid.Lock = True
                    ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
                End If
            ElseIf ssgrid.ActiveCol = 3 Then
                ssgrid.Col = 3
                ssgrid.Row = ssgrid.ActiveRow
                If Trim(ssgrid.Text) = "" Then
                    Call Fillaccountdetails()
                    Exit Sub
                Else
                    ACHEAD = Trim(ssgrid.Text)
                    GLCODE = ACHEAD.Split("-->>")
                    Sqlstring = "SELECT ACCODE, ACDESC FROM ACCOUNTSGLACCOUNTMASTER WHERE ACCODE = '" & Trim(GLCODE(0)) & "' AND ISNULL(FREEZEFLAG,'N') <> 'Y' "
                    gconnection.getDataSet(Sqlstring, "ACCOUNTSGLACCOUNTMASTER")
                    If gdataset.Tables("ACCOUNTSGLACCOUNTMASTER").Rows.Count = 0 Then
                        Sqlstring = "SELECT ACCODE, ACDESC FROM ACCOUNTSGLACCOUNTMASTER WHERE ACDESC = '" & Trim(GLCODE(0)) & "' AND ISNULL(FREEZEFLAG,'N') <> 'Y' "
                        gconnection.getDataSet(Sqlstring, "ACCOUNTSGLACCOUNTMASTER")
                    End If
                    If gdataset.Tables("ACCOUNTSGLACCOUNTMASTER").Rows.Count > 0 Then
                        ssgrid.Col = 3
                        ssgrid.Row = ssgrid.ActiveRow
                        ssgrid.Text = Trim(gdataset.Tables("ACCOUNTSGLACCOUNTMASTER").Rows(0).Item("ACCODE")) & "-->>" & Trim(gdataset.Tables("ACCOUNTSGLACCOUNTMASTER").Rows(0).Item("ACDESC"))
                        gdataset.Tables("ACCOUNTSGLACCOUNTMASTER").Dispose()
                    Else
                        Call Fillaccountdetails()
                    End If
                End If
            ElseIf ssgrid.ActiveCol = 4 Then
                ssgrid.Col = 4
                ssgrid.Row = ssgrid.ActiveRow
                If Trim(ssgrid.Text) = "" Or Trim(ssgrid.Text) = "-" Then
                    ssgrid.Text = "-"
                    ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                Else
                    ssgrid.Text = "+"
                    ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                End If
            ElseIf ssgrid.ActiveCol = 5 Then
                ssgrid.Col = 5
                ssgrid.Row = ssgrid.ActiveRow
                If ssgrid.ActiveCol = 5 And ssgrid.ActiveRow = 1 Then
                    ssgrid.Lock = True
                    ssgrid.SetActiveCell(0, ssgrid.ActiveRow + 1)
                ElseIf Trim(ssgrid.Text) = "" Then
                    ssgrid.SetActiveCell(0, ssgrid.ActiveRow + 1)
                End If
            End If
        End If
        If e.keyCode = Keys.F4 Then
            If ssgrid.ActiveCol = 3 Then
                If ssgrid.Lock = False Then
                    search = Nothing
                    ssgrid.GetText(2, ssgrid.ActiveRow, search)
                    Dim vform As New List_Operation
                    gSQLString = "SELECT ACCODE AS GLCODE,ACDESC AS GLDESCRIPTION  FROM ACCOUNTSGLACCOUNTMASTER"
                    M_WhereCondition = " WHERE  ISNULL(FREEZEFLAG,'N') <> 'Y'"
                    vform.Field = "ACDESC,ACCODE"
                    vform.keyfield = "ACDESC"
                    vform.vFormatstring1 = "                  GL CODE                    |                GL DESCRIPTION           "
                    vform.vCaption = "GENERAL LEDGER HEAD HELP"
                    vform.KeyPos = 0
                    vform.KeyPos1 = 1
                    vform.ShowDialog(Me)
                    If Trim(vform.keyfield & "") <> "" Then
                        ssgrid.SetText(ssgrid.ActiveCol, ssgrid.ActiveRow, Trim(vform.keyfield & "") & "-->>" & Trim(vform.keyfield1 & ""))
                        ACHEAD = Trim(vform.keyfield & "")
                    Else
                        ssgrid.SetActiveCell(ssgrid.ActiveCol, ssgrid.ActiveRow)
                        ssgrid.SetText(ssgrid.ActiveCol, ssgrid.ActiveRow, "")
                    End If
                    vform.Close()
                    vform = Nothing
                End If
            End If
        End If
    End Sub
    Private Sub Fillaccountdetails()
        Dim ACHEAD, SUBLEDGER, COSTCENTER, SQLSTRING, GR As String
        search = Nothing
        ssgrid.GetText(2, ssgrid.ActiveRow, search)
        Dim vform As New List_Operation
        gSQLString = "SELECT ACCODE AS GLCODE,ACDESC AS GLDESCRIPTION  FROM ACCOUNTSGLACCOUNTMASTER"
        M_WhereCondition = " WHERE  ISNULL(FREEZEFLAG,'N') <> 'Y'"
        vform.Field = "ACDESC,ACCODE"
        vform.vFormatstring1 = "                    GL CODE                      |                          GL DESCRIPTION           "
        vform.vCaption = "GENERAL LEDGER HEAD HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            ssgrid.SetText(ssgrid.ActiveCol, ssgrid.ActiveRow, Trim(vform.keyfield & "") & "-->>" & Trim(vform.keyfield1 & ""))
            ACHEAD = Trim(vform.keyfield & "")
        Else
            ssgrid.SetActiveCell(ssgrid.ActiveCol, ssgrid.ActiveRow)
            ssgrid.SetText(ssgrid.ActiveCol, ssgrid.ActiveRow, "")
            ACHEAD = ""
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Public Sub Autogenerate()
        Dim Sqlstring As String
        gcommand = New SqlCommand
        Sqlstring = "SELECT MAX(SUBSTRING(Typecode,1,6)) FROM PurchaseBillterms"
        gconnection.openConnection()
        gcommand.CommandText = Sqlstring
        gcommand.CommandType = CommandType.Text
        gcommand.Connection = gconnection.Myconn
        gdreader = gcommand.ExecuteReader
        If gdreader.Read Then
            If gdreader(0) Is System.DBNull.Value Then
                txt_Typecode.Text = 1
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            Else
                txt_Typecode.Text = Format(gdreader(0) + 1, "0")
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            End If
        Else
            txt_Typecode.Text = 1
            gdreader.Close()
            gcommand.Dispose()
            gconnection.closeConnection()
        End If
    End Sub

    Private Sub Cmd_TypecodeHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_TypecodeHelp.Click
        gSQLString = "SELECT DISTINCT ISNULL(TYPECODE,'') AS TYPECODE ,ISNULL(TYPEDESC,'') AS TYPEDESC FROM PURCHASEBILLTERMS"
        M_WhereCondition = " WHERE freeze='N' "
        Dim vform As New ListOperattion1
        vform.Field = "TYPEDESC,TYPECODE"
        vform.vFormatstring = "                TYPE CODE            |            TYPE DESCRIPTION                             "
        vform.vCaption = "BILLING TERMS HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_Typecode.Text = Trim(vform.keyfield & "")
            Call txt_Typecode_Validated(txt_Typecode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub txt_Typecode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Typecode.Validated
        Dim j, i As Integer
        Dim sqlstring As String
        If Trim(txt_Typecode.Text) <> "" Then
            Try
                sqlstring = "SELECT * FROM PURCHASEBILLTERMS WHERE TYPECODE='" & Trim(txt_Typecode.Text) & "'"
                gconnection.getDataSet(sqlstring, "PURCHASEBILLTERMS")
                '''************************************************* SELECT record from Grn_header *********************************************''''                
                If gdataset.Tables("PURCHASEBILLTERMS").Rows.Count > 0 Then
                    Cmd_Add.Text = "Update[F7]"
                    Me.txt_Typecode.ReadOnly = True
                    txt_Typecode.Text = Trim(gdataset.Tables("PURCHASEBILLTERMS").Rows(0).Item("Typecode") & "")
                    txt_Typedescription.Text = Trim(gdataset.Tables("PURCHASEBILLTERMS").Rows(0).Item("Typedesc") & "")
                    '''************************************************* SELECT record from Grn_details *********************************************''''                
                    With ssgrid
                        If gdataset.Tables("PURCHASEBILLTERMS").Rows.Count > 0 Then
                            For i = 1 To gdataset.Tables("PURCHASEBILLTERMS").Rows.Count
                                .SetText(1, i, Trim(gdataset.Tables("PURCHASEBILLTERMS").Rows(j).Item("Billdescription")) & "")
                                .SetText(2, i, Trim(gdataset.Tables("PURCHASEBILLTERMS").Rows(j).Item("Tax")) & "")
                                If Trim(gdataset.Tables("PURCHASEBILLTERMS").Rows(j).Item("Tax")) <> "Y" Then
                                    .SetText(3, i, Trim(gdataset.Tables("PURCHASEBILLTERMS").Rows(j).Item("Accode")) & "-->" & Trim(gdataset.Tables("PURCHASEBILLTERMS").Rows(j).Item("Acdesc")))
                                Else
                                    .SetText(3, i, "")
                                End If
                                .SetText(4, i, Trim(gdataset.Tables("PURCHASEBILLTERMS").Rows(j).Item("Signs")))
                                .SetText(5, i, Trim(gdataset.Tables("PURCHASEBILLTERMS").Rows(j).Item("Formula")))
                                j = j + 1
                            Next
                        End If
                    End With
                    ssgrid.SetActiveCell(1, 1)
                End If
            Catch ex As Exception
                MessageBox.Show("Enter valid Type Code :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub frm_BillingMaterial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(Cmd_Clear, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F8 Then
            Call Cmd_Freeze_Click(Cmd_Freeze, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F7 Then
            Call Cmd_Add_Click(Cmd_Add, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call Cmd_Exit_Click(Cmd_Exit, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F10 Then
            Call cmd_Print_Click(cmd_Print, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call Cmd_Exit_Click(Cmd_Exit, e)
            Exit Sub
        End If
    End Sub

    Private Sub txt_Typecode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Typecode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If Cmd_TypecodeHelp.Enabled = True Then
                search = Trim(txt_Typecode.Text)
                Call Cmd_TypecodeHelp_Click(Cmd_TypecodeHelp, e)
            End If
        End If
    End Sub

    Private Sub frm_BillingMaterial_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        BillingMaterialbool = False
    End Sub

    Private Sub cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_View.Click
        gPrint = False
        PRINTOPERATION()
    End Sub

    Private Sub cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Print.Click
        gPrint = True
        PRINTOPERATION()
    End Sub

    Private Sub PRINTOPERATION()
        Dim x, docno, printline As String
        Dim I As Integer
        Dim booldocno As Boolean
        Dim total(10) As Double
        Dim GROUPCODE As String
        Dim vsubheader() As String = {"DOC NO. : ", "DOC DATE : ", "MAIN STORE CODE : ", "MAIN STORE NAME : ", "TO STORE CODE  : ", "TO STORE NAME :"}
        Dim PAGEHEADING() As String = {"BILLING TERMS FOR " & UCase(txt_Typedescription.Text)}
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            PAGENO = 1
            sqlstring = "SELECT ISNULL(SLNO,0) SLNO,ISNULL(BILLDESCRIPTION,'') BILLDESCRIPTION,ISNULL(USERINPUT,'') USERINPUT,ISNULL(TAX,'') TAX,ISNULL(ACCODE,'') ACCODE,ISNULL(ACDESC,'') ACDESC,ISNULL(SIGNS,'') SIGNS,ISNULL(FORMULA,'') FORMULA FROM PURCHASEBILLTERMS WHERE TYPECODE='" & Trim(txt_Typecode.Text) & "' "
            gconnection.getDataSet(sqlstring, "BILLINGTERMS")
            If gdataset.Tables("BILLINGTERMS").Rows.Count <= 0 Then
                MsgBox("DATA NOT AVAILABLE")
                Exit Sub
            End If
            Call Print_Headers(PAGEHEADING)
            For Each DR In gdataset.Tables("BILLINGTERMS").Rows
                Filewrite.WriteLine("|{0,-5}|{1,-35}|{2,-5}|{3,-5}|{4,-10}|{5,-35}|{6,-5}|{7,-10}|", Mid(DR.Item("SLNO"), 1, 5), Mid(DR.Item("BILLDESCRIPTION"), 1, 35), Mid(DR.Item("USERINPUT"), 1, 5), Mid(DR.Item("TAX"), 1, 5), Mid(DR.Item("ACCODE"), 1, 10), Mid(DR.Item("ACDESC"), 1, 35), Mid(DR.Item("SIGNS"), 1, 5), Mid(DR.Item("FORMULA"), 1, 10))
                If PAGESIZE > 58 Then
                    Filewrite.Write(StrDup(120, "-"))
                    Filewrite.Write(Chr(12))
                    PAGENO = PAGENO + 1
                    Call Print_Headers(PAGEHEADING)
                    Filewrite.WriteLine()
                    PAGESIZE = PAGESIZE + 1
                End If
            Next DR
            Filewrite.WriteLine(StrDup(120, "-"))
            Filewrite.Write(Chr(12))
            Filewrite.Close()
            If gPrint = False Then
                OpenTextFile(vOutfile)
            Else
                PrintTextFile(VFilePath)
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.Source & ex.ToString)
            Exit Sub
        End Try
    End Sub

    Private Function Print_Headers(ByVal pageheading() As String)
        Dim I As Integer
        PAGESIZE = 0
        '''*********************************************** PRINT REPORTS HEADING  *********************************'''
        Try
            Filewrite.WriteLine(Chr(18))
            Filewrite.WriteLine("{0,55}{1,15}{2,10}", Chr(14) & Chr(15) & " ", "PRINTED ON : ", Format(Now, "dd/MMM/yyyy"))
            PAGESIZE = PAGESIZE + 1
            Filewrite.WriteLine()
            PAGESIZE = PAGESIZE + 1
            'Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", " ")
            'pagesize = pagesize + 1
            'Filewrite.WriteLine("{0,-30}{1,1}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(pageheading(0)), 1, 30), " ", " ")
            'pagesize = pagesize + 1
            'Filewrite.WriteLine("{0,-30}{1,-1}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(pageheading(0))), "-"), 1, 30))
            'pagesize = pagesize + 1
            'Filewrite.WriteLine("{0,70}{1,-10}", " ", "PAGE : " & pageno)
            Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", " ")
            PAGESIZE = PAGESIZE + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(pageheading(0)), 1, 30), " ", " ")
            PAGESIZE = PAGESIZE + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(pageheading(0))), "-"), 1, 30))
            PAGESIZE = PAGESIZE + 1
            Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE : " & PAGENO)
            PAGESIZE = PAGESIZE + 1
            Filewrite.WriteLine(StrDup(120, "-"))
            PAGESIZE = PAGESIZE + 1
            Filewrite.WriteLine("|{0,-5}|{1,-35}|{2,-5}|{3,-5}|{4,-10}|{5,-35}|{6,-5}|{7,-10}|", "SLNO", "DESCRIPTION", "INPUT", "TAX", "ACCODE", "ACCOUNT DESC", "SIGN", "FORMULA")
            PAGESIZE = PAGESIZE + 1
            Filewrite.WriteLine(StrDup(120, "-"))
            PAGESIZE = PAGESIZE + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function

End Class
