Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Text.RegularExpressions
Imports System.IO

Public Class SUBLEDGERMASTER
    Inherits System.Windows.Forms.Form
    Dim gconnection As New GlobalClass
    Friend WithEvents lbl_ac As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TxtGSTINNO As System.Windows.Forms.TextBox
    Dim sqlstring As String
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Cmb_SLType As System.Windows.Forms.ComboBox
    Friend WithEvents Txt_SLCode As System.Windows.Forms.TextBox
    Friend WithEvents Txt_SLName As System.Windows.Forms.TextBox
    Friend WithEvents Txt_ContactPerson As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Address1 As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Address2 As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Address3 As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Pin As System.Windows.Forms.TextBox
    Friend WithEvents Txt_PhoneNo As System.Windows.Forms.TextBox
    Friend WithEvents Txt_CellNo As System.Windows.Forms.TextBox
    Friend WithEvents Txt_GLAcCode As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Txt_GLAcDesc As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_GLAcCodeHelp As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CmdView As System.Windows.Forms.Button
    Friend WithEvents CmdDelete As System.Windows.Forms.Button
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents Txt_State As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_City As System.Windows.Forms.TextBox
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    Friend WithEvents cmdcrystal As System.Windows.Forms.Button
    Friend WithEvents chk_excel As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents Rdo_BalanceAsOnDebit As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo_BalanceAsOnCredit As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents Rdo_OpeningBalanceDebit As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo_OpeningBalanceCredit As System.Windows.Forms.RadioButton
    Friend WithEvents Txt_BalanceAsOn As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Txt_OpeningBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Txt_CreditPeriod As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents Rdo_PFNo As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo_PFYes As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents Rdo_ESINo As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo_ESIYes As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Rdo_PurchaseTaxNo As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo_PurchaseTaxYes As System.Windows.Forms.RadioButton
    Friend WithEvents Lbl_PurchaseTaxSection As System.Windows.Forms.Label
    Friend WithEvents Lbl_WorksContractSection As System.Windows.Forms.Label
    Friend WithEvents Lbl_WorksContractp As System.Windows.Forms.Label
    Friend WithEvents Lbl_PurchaseTaxp As System.Windows.Forms.Label
    Friend WithEvents Lbl_esip As System.Windows.Forms.Label
    Friend WithEvents Lbl_PfSection As System.Windows.Forms.Label
    Friend WithEvents Lbl_Pfp As System.Windows.Forms.Label
    Friend WithEvents Lbl_EsiSection As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Rdo_WorksContractNo As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo_WorksContractYes As System.Windows.Forms.RadioButton
    Friend WithEvents Txt_PfPercentage As System.Windows.Forms.TextBox
    Friend WithEvents Cbo_PfSection As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Txt_EsiPercentage As System.Windows.Forms.TextBox
    Friend WithEvents Cbo_EsiSection As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Cbo_PurchaseTaxSection As System.Windows.Forms.ComboBox
    Friend WithEvents Txt_PurchaseTaxPercentage As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Txt_WorksContractPercentage As System.Windows.Forms.TextBox
    Friend WithEvents Cbo_WorksContractSection As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Txt_TDSPercentage As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_tdsp As System.Windows.Forms.Label
    Friend WithEvents CBO_TDSECTION As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_TdSection As System.Windows.Forms.Label
    Friend WithEvents Cbo_TDSSection As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_TDSSection As System.Windows.Forms.Label
    Friend WithEvents Lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Rdo_TDSYes As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo_TDSNo As System.Windows.Forms.RadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Txt_PANNo As System.Windows.Forms.TextBox
    Friend WithEvents Txt_GRNNo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Txt_TINNo As System.Windows.Forms.TextBox
    Friend WithEvents Txt_CSTNo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_auth As System.Windows.Forms.Button
    Friend WithEvents cmd_export As System.Windows.Forms.Button
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txt_email As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Last As System.Windows.Forms.Label
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents frmbut As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_SLCodeHelp As System.Windows.Forms.Button
    Friend WithEvents Txt_VATNo As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SUBLEDGERMASTER))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cmb_SLType = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt_SLCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Txt_SLName = New System.Windows.Forms.TextBox()
        Me.Txt_ContactPerson = New System.Windows.Forms.TextBox()
        Me.Txt_Address1 = New System.Windows.Forms.TextBox()
        Me.Txt_Address2 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Txt_Address3 = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Txt_Pin = New System.Windows.Forms.TextBox()
        Me.Txt_PhoneNo = New System.Windows.Forms.TextBox()
        Me.Txt_CellNo = New System.Windows.Forms.TextBox()
        Me.Txt_GLAcCode = New System.Windows.Forms.TextBox()
        Me.Cmd_GLAcCodeHelp = New System.Windows.Forms.Button()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Txt_GLAcDesc = New System.Windows.Forms.TextBox()
        Me.chk_excel = New System.Windows.Forms.CheckBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.CmdAdd = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.cmdcrystal = New System.Windows.Forms.Button()
        Me.CmdView = New System.Windows.Forms.Button()
        Me.cmdexport = New System.Windows.Forms.Button()
        Me.CmdDelete = New System.Windows.Forms.Button()
        Me.Txt_State = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txt_email = New System.Windows.Forms.TextBox()
        Me.txt_City = New System.Windows.Forms.TextBox()
        Me.CBO_TDSECTION = New System.Windows.Forms.ComboBox()
        Me.Txt_TINNo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Cbo_WorksContractSection = New System.Windows.Forms.ComboBox()
        Me.Txt_WorksContractPercentage = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Txt_PurchaseTaxPercentage = New System.Windows.Forms.TextBox()
        Me.Cbo_PurchaseTaxSection = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Cbo_EsiSection = New System.Windows.Forms.ComboBox()
        Me.Txt_EsiPercentage = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Cbo_PfSection = New System.Windows.Forms.ComboBox()
        Me.Txt_PfPercentage = New System.Windows.Forms.TextBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Rdo_WorksContractNo = New System.Windows.Forms.RadioButton()
        Me.Rdo_WorksContractYes = New System.Windows.Forms.RadioButton()
        Me.Lbl_EsiSection = New System.Windows.Forms.Label()
        Me.Lbl_Pfp = New System.Windows.Forms.Label()
        Me.Lbl_PfSection = New System.Windows.Forms.Label()
        Me.Lbl_esip = New System.Windows.Forms.Label()
        Me.Lbl_PurchaseTaxp = New System.Windows.Forms.Label()
        Me.Lbl_WorksContractp = New System.Windows.Forms.Label()
        Me.Lbl_WorksContractSection = New System.Windows.Forms.Label()
        Me.Lbl_PurchaseTaxSection = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Rdo_PurchaseTaxNo = New System.Windows.Forms.RadioButton()
        Me.Rdo_PurchaseTaxYes = New System.Windows.Forms.RadioButton()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.Rdo_ESINo = New System.Windows.Forms.RadioButton()
        Me.Rdo_ESIYes = New System.Windows.Forms.RadioButton()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.Rdo_PFNo = New System.Windows.Forms.RadioButton()
        Me.Rdo_PFYes = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Cmd_SLCodeHelp = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Rdo_TDSYes = New System.Windows.Forms.RadioButton()
        Me.Rdo_TDSNo = New System.Windows.Forms.RadioButton()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.Rdo_BalanceAsOnDebit = New System.Windows.Forms.RadioButton()
        Me.Rdo_BalanceAsOnCredit = New System.Windows.Forms.RadioButton()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.Rdo_OpeningBalanceDebit = New System.Windows.Forms.RadioButton()
        Me.Rdo_OpeningBalanceCredit = New System.Windows.Forms.RadioButton()
        Me.Txt_OpeningBalance = New System.Windows.Forms.TextBox()
        Me.Txt_BalanceAsOn = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Txt_CreditPeriod = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Txt_TDSPercentage = New System.Windows.Forms.TextBox()
        Me.Lbl_tdsp = New System.Windows.Forms.Label()
        Me.lbl_TdSection = New System.Windows.Forms.Label()
        Me.Cbo_TDSSection = New System.Windows.Forms.ComboBox()
        Me.lbl_TDSSection = New System.Windows.Forms.Label()
        Me.Lbl_Freeze = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Txt_PANNo = New System.Windows.Forms.TextBox()
        Me.Txt_GRNNo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Txt_CSTNo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TxtGSTINNO = New System.Windows.Forms.TextBox()
        Me.Txt_VATNo = New System.Windows.Forms.TextBox()
        Me.cmd_auth = New System.Windows.Forms.Button()
        Me.cmd_export = New System.Windows.Forms.Button()
        Me.Lbl_Last = New System.Windows.Forms.Label()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.frmbut = New System.Windows.Forms.GroupBox()
        Me.lbl_ac = New System.Windows.Forms.Label()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.frmbut.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(224, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(281, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "VENDOR CREATION MASTER"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "A/C CODE"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "SL TYPE"
        '
        'Cmb_SLType
        '
        Me.Cmb_SLType.BackColor = System.Drawing.Color.Wheat
        Me.Cmb_SLType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_SLType.Items.AddRange(New Object() {"SUPPLIER"})
        Me.Cmb_SLType.Location = New System.Drawing.Point(72, 16)
        Me.Cmb_SLType.Name = "Cmb_SLType"
        Me.Cmb_SLType.Size = New System.Drawing.Size(160, 23)
        Me.Cmb_SLType.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "SLCODE"
        '
        'Txt_SLCode
        '
        Me.Txt_SLCode.BackColor = System.Drawing.Color.Wheat
        Me.Txt_SLCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_SLCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_SLCode.Location = New System.Drawing.Point(72, 48)
        Me.Txt_SLCode.MaxLength = 10
        Me.Txt_SLCode.Name = "Txt_SLCode"
        Me.Txt_SLCode.Size = New System.Drawing.Size(160, 21)
        Me.Txt_SLCode.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "SL NAME"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(23, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 15)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "CONTACT PERSON"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(23, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 15)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "ADDRESS 1"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(23, 67)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 15)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "ADDRESS 2"
        '
        'Txt_SLName
        '
        Me.Txt_SLName.BackColor = System.Drawing.Color.Wheat
        Me.Txt_SLName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_SLName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_SLName.Location = New System.Drawing.Point(72, 82)
        Me.Txt_SLName.MaxLength = 100
        Me.Txt_SLName.Name = "Txt_SLName"
        Me.Txt_SLName.Size = New System.Drawing.Size(186, 21)
        Me.Txt_SLName.TabIndex = 1
        '
        'Txt_ContactPerson
        '
        Me.Txt_ContactPerson.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ContactPerson.Location = New System.Drawing.Point(159, 16)
        Me.Txt_ContactPerson.MaxLength = 50
        Me.Txt_ContactPerson.Name = "Txt_ContactPerson"
        Me.Txt_ContactPerson.Size = New System.Drawing.Size(276, 21)
        Me.Txt_ContactPerson.TabIndex = 10
        '
        'Txt_Address1
        '
        Me.Txt_Address1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Address1.Location = New System.Drawing.Point(159, 42)
        Me.Txt_Address1.MaxLength = 50
        Me.Txt_Address1.Name = "Txt_Address1"
        Me.Txt_Address1.Size = New System.Drawing.Size(276, 21)
        Me.Txt_Address1.TabIndex = 11
        '
        'Txt_Address2
        '
        Me.Txt_Address2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Address2.Location = New System.Drawing.Point(159, 67)
        Me.Txt_Address2.MaxLength = 50
        Me.Txt_Address2.Name = "Txt_Address2"
        Me.Txt_Address2.Size = New System.Drawing.Size(276, 21)
        Me.Txt_Address2.TabIndex = 12
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(23, 91)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 15)
        Me.Label22.TabIndex = 51
        Me.Label22.Text = "ADDRESS 3"
        '
        'Txt_Address3
        '
        Me.Txt_Address3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Address3.Location = New System.Drawing.Point(159, 91)
        Me.Txt_Address3.MaxLength = 50
        Me.Txt_Address3.Name = "Txt_Address3"
        Me.Txt_Address3.Size = New System.Drawing.Size(276, 21)
        Me.Txt_Address3.TabIndex = 13
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(23, 116)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(32, 15)
        Me.Label24.TabIndex = 55
        Me.Label24.Text = "CITY"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(23, 144)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(42, 15)
        Me.Label25.TabIndex = 56
        Me.Label25.Text = "STATE"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(23, 174)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(26, 15)
        Me.Label26.TabIndex = 57
        Me.Label26.Text = "PIN"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(23, 232)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(56, 15)
        Me.Label27.TabIndex = 58
        Me.Label27.Text = "CELL NO"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(23, 203)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(67, 15)
        Me.Label28.TabIndex = 59
        Me.Label28.Text = "PHONE NO"
        '
        'Txt_Pin
        '
        Me.Txt_Pin.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Pin.Location = New System.Drawing.Point(159, 174)
        Me.Txt_Pin.MaxLength = 6
        Me.Txt_Pin.Name = "Txt_Pin"
        Me.Txt_Pin.Size = New System.Drawing.Size(119, 21)
        Me.Txt_Pin.TabIndex = 16
        '
        'Txt_PhoneNo
        '
        Me.Txt_PhoneNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_PhoneNo.Location = New System.Drawing.Point(159, 203)
        Me.Txt_PhoneNo.MaxLength = 10
        Me.Txt_PhoneNo.Name = "Txt_PhoneNo"
        Me.Txt_PhoneNo.Size = New System.Drawing.Size(119, 21)
        Me.Txt_PhoneNo.TabIndex = 17
        '
        'Txt_CellNo
        '
        Me.Txt_CellNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_CellNo.Location = New System.Drawing.Point(159, 232)
        Me.Txt_CellNo.MaxLength = 10
        Me.Txt_CellNo.Name = "Txt_CellNo"
        Me.Txt_CellNo.Size = New System.Drawing.Size(119, 21)
        Me.Txt_CellNo.TabIndex = 18
        '
        'Txt_GLAcCode
        '
        Me.Txt_GLAcCode.BackColor = System.Drawing.Color.Wheat
        Me.Txt_GLAcCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_GLAcCode.Enabled = False
        Me.Txt_GLAcCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_GLAcCode.Location = New System.Drawing.Point(125, 14)
        Me.Txt_GLAcCode.MaxLength = 10
        Me.Txt_GLAcCode.Name = "Txt_GLAcCode"
        Me.Txt_GLAcCode.Size = New System.Drawing.Size(134, 21)
        Me.Txt_GLAcCode.TabIndex = 0
        '
        'Cmd_GLAcCodeHelp
        '
        Me.Cmd_GLAcCodeHelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cmd_GLAcCodeHelp.Location = New System.Drawing.Point(261, 14)
        Me.Cmd_GLAcCodeHelp.Name = "Cmd_GLAcCodeHelp"
        Me.Cmd_GLAcCodeHelp.Size = New System.Drawing.Size(23, 21)
        Me.Cmd_GLAcCodeHelp.TabIndex = 82
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(10, 48)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(106, 15)
        Me.Label41.TabIndex = 101
        Me.Label41.Text = "A/C DESCRIPTION"
        '
        'Txt_GLAcDesc
        '
        Me.Txt_GLAcDesc.BackColor = System.Drawing.Color.Wheat
        Me.Txt_GLAcDesc.Enabled = False
        Me.Txt_GLAcDesc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_GLAcDesc.Location = New System.Drawing.Point(125, 48)
        Me.Txt_GLAcDesc.MaxLength = 30
        Me.Txt_GLAcDesc.Name = "Txt_GLAcDesc"
        Me.Txt_GLAcDesc.ReadOnly = True
        Me.Txt_GLAcDesc.Size = New System.Drawing.Size(162, 21)
        Me.Txt_GLAcDesc.TabIndex = 102
        '
        'chk_excel
        '
        Me.chk_excel.BackColor = System.Drawing.Color.Transparent
        Me.chk_excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.chk_excel.Location = New System.Drawing.Point(833, 540)
        Me.chk_excel.Name = "chk_excel"
        Me.chk_excel.Size = New System.Drawing.Size(72, 24)
        Me.chk_excel.TabIndex = 466
        Me.chk_excel.Text = "Excel"
        Me.chk_excel.UseVisualStyleBackColor = False
        Me.chk_excel.Visible = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdexit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Image = CType(resources.GetObject("cmdexit.Image"), System.Drawing.Image)
        Me.cmdexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdexit.Location = New System.Drawing.Point(2, 252)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(124, 46)
        Me.cmdexit.TabIndex = 21
        Me.cmdexit.Text = "&Exit [F11]"
        Me.cmdexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'CmdAdd
        '
        Me.CmdAdd.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CmdAdd.FlatAppearance.BorderSize = 0
        Me.CmdAdd.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.CmdAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.CmdAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.CmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdAdd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAdd.ForeColor = System.Drawing.Color.Black
        Me.CmdAdd.Image = CType(resources.GetObject("CmdAdd.Image"), System.Drawing.Image)
        Me.CmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAdd.Location = New System.Drawing.Point(3, 60)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(124, 46)
        Me.CmdAdd.TabIndex = 17
        Me.CmdAdd.Text = "&Add [F7]"
        Me.CmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAdd.UseVisualStyleBackColor = False
        '
        'CmdClear
        '
        Me.CmdClear.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CmdClear.FlatAppearance.BorderSize = 0
        Me.CmdClear.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.CmdClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.CmdClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.CmdClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdClear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.Color.Black
        Me.CmdClear.Image = CType(resources.GetObject("CmdClear.Image"), System.Drawing.Image)
        Me.CmdClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdClear.Location = New System.Drawing.Point(3, 12)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(124, 46)
        Me.CmdClear.TabIndex = 18
        Me.CmdClear.Text = "&Clear [F6]"
        Me.CmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdClear.UseVisualStyleBackColor = False
        '
        'cmdcrystal
        '
        Me.cmdcrystal.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdcrystal.BackgroundImage = CType(resources.GetObject("cmdcrystal.BackgroundImage"), System.Drawing.Image)
        Me.cmdcrystal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdcrystal.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdcrystal.FlatAppearance.BorderSize = 0
        Me.cmdcrystal.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.cmdcrystal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmdcrystal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmdcrystal.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdcrystal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcrystal.ForeColor = System.Drawing.Color.Black
        Me.cmdcrystal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdcrystal.Location = New System.Drawing.Point(2, 156)
        Me.cmdcrystal.Name = "cmdcrystal"
        Me.cmdcrystal.Size = New System.Drawing.Size(124, 46)
        Me.cmdcrystal.TabIndex = 25
        Me.cmdcrystal.Text = "Report[F1]"
        Me.cmdcrystal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdcrystal.UseVisualStyleBackColor = False
        '
        'CmdView
        '
        Me.CmdView.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CmdView.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdView.FlatAppearance.BorderSize = 0
        Me.CmdView.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.CmdView.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.CmdView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.CmdView.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdView.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.Color.Black
        Me.CmdView.Image = CType(resources.GetObject("CmdView.Image"), System.Drawing.Image)
        Me.CmdView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdView.Location = New System.Drawing.Point(2, 108)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(124, 46)
        Me.CmdView.TabIndex = 20
        Me.CmdView.Text = "&View[F9]"
        Me.CmdView.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdView.UseVisualStyleBackColor = False
        '
        'cmdexport
        '
        Me.cmdexport.BackColor = System.Drawing.Color.Transparent
        Me.cmdexport.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdexport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdexport.ForeColor = System.Drawing.Color.Black
        Me.cmdexport.Location = New System.Drawing.Point(748, 535)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(79, 32)
        Me.cmdexport.TabIndex = 22
        Me.cmdexport.Text = "&Export[F10]"
        Me.cmdexport.UseVisualStyleBackColor = False
        Me.cmdexport.Visible = False
        '
        'CmdDelete
        '
        Me.CmdDelete.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CmdDelete.FlatAppearance.BorderSize = 0
        Me.CmdDelete.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.CmdDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.CmdDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.CmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CmdDelete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CmdDelete.Image = CType(resources.GetObject("CmdDelete.Image"), System.Drawing.Image)
        Me.CmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdDelete.Location = New System.Drawing.Point(763, 481)
        Me.CmdDelete.Name = "CmdDelete"
        Me.CmdDelete.Size = New System.Drawing.Size(124, 46)
        Me.CmdDelete.TabIndex = 19
        Me.CmdDelete.Text = "&Freeze[F8]"
        Me.CmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdDelete.UseVisualStyleBackColor = False
        Me.CmdDelete.Visible = False
        '
        'Txt_State
        '
        Me.Txt_State.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_State.Location = New System.Drawing.Point(159, 144)
        Me.Txt_State.MaxLength = 30
        Me.Txt_State.Name = "Txt_State"
        Me.Txt_State.Size = New System.Drawing.Size(119, 21)
        Me.Txt_State.TabIndex = 15
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.Label29)
        Me.GroupBox4.Controls.Add(Me.txt_email)
        Me.GroupBox4.Controls.Add(Me.txt_City)
        Me.GroupBox4.Controls.Add(Me.Txt_State)
        Me.GroupBox4.Controls.Add(Me.Label25)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Txt_ContactPerson)
        Me.GroupBox4.Controls.Add(Me.Txt_Address1)
        Me.GroupBox4.Controls.Add(Me.Txt_Address2)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Controls.Add(Me.Txt_Address3)
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Controls.Add(Me.Label26)
        Me.GroupBox4.Controls.Add(Me.Label27)
        Me.GroupBox4.Controls.Add(Me.CBO_TDSECTION)
        Me.GroupBox4.Controls.Add(Me.Label28)
        Me.GroupBox4.Controls.Add(Me.Txt_Pin)
        Me.GroupBox4.Controls.Add(Me.Txt_CellNo)
        Me.GroupBox4.Controls.Add(Me.Txt_PhoneNo)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox4.Location = New System.Drawing.Point(279, 262)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(463, 305)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(23, 261)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(56, 15)
        Me.Label29.TabIndex = 61
        Me.Label29.Text = "EMAIL ID"
        '
        'txt_email
        '
        Me.txt_email.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_email.Location = New System.Drawing.Point(158, 260)
        Me.txt_email.MaxLength = 50
        Me.txt_email.Name = "txt_email"
        Me.txt_email.Size = New System.Drawing.Size(119, 21)
        Me.txt_email.TabIndex = 19
        '
        'txt_City
        '
        Me.txt_City.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_City.Location = New System.Drawing.Point(159, 116)
        Me.txt_City.MaxLength = 50
        Me.txt_City.Name = "txt_City"
        Me.txt_City.Size = New System.Drawing.Size(276, 21)
        Me.txt_City.TabIndex = 14
        '
        'CBO_TDSECTION
        '
        Me.CBO_TDSECTION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBO_TDSECTION.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CBO_TDSECTION.ItemHeight = 13
        Me.CBO_TDSECTION.Location = New System.Drawing.Point(390, 146)
        Me.CBO_TDSECTION.Name = "CBO_TDSECTION"
        Me.CBO_TDSECTION.Size = New System.Drawing.Size(64, 21)
        Me.CBO_TDSECTION.TabIndex = 3
        Me.CBO_TDSECTION.Visible = False
        '
        'Txt_TINNo
        '
        Me.Txt_TINNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Txt_TINNo.Location = New System.Drawing.Point(72, 77)
        Me.Txt_TINNo.MaxLength = 15
        Me.Txt_TINNo.Name = "Txt_TINNo"
        Me.Txt_TINNo.Size = New System.Drawing.Size(112, 20)
        Me.Txt_TINNo.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(4, 80)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(45, 15)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "TIN NO"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label32)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Cbo_WorksContractSection)
        Me.GroupBox1.Controls.Add(Me.Txt_WorksContractPercentage)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Txt_PurchaseTaxPercentage)
        Me.GroupBox1.Controls.Add(Me.Cbo_PurchaseTaxSection)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Cbo_EsiSection)
        Me.GroupBox1.Controls.Add(Me.Txt_EsiPercentage)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Cbo_PfSection)
        Me.GroupBox1.Controls.Add(Me.Txt_PfPercentage)
        Me.GroupBox1.Controls.Add(Me.GroupBox7)
        Me.GroupBox1.Controls.Add(Me.Lbl_EsiSection)
        Me.GroupBox1.Controls.Add(Me.Lbl_Pfp)
        Me.GroupBox1.Controls.Add(Me.Lbl_PfSection)
        Me.GroupBox1.Controls.Add(Me.Lbl_esip)
        Me.GroupBox1.Controls.Add(Me.Lbl_PurchaseTaxp)
        Me.GroupBox1.Controls.Add(Me.Lbl_WorksContractp)
        Me.GroupBox1.Controls.Add(Me.Lbl_WorksContractSection)
        Me.GroupBox1.Controls.Add(Me.Lbl_PurchaseTaxSection)
        Me.GroupBox1.Controls.Add(Me.GroupBox8)
        Me.GroupBox1.Controls.Add(Me.GroupBox9)
        Me.GroupBox1.Controls.Add(Me.GroupBox10)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.Location = New System.Drawing.Point(35, 523)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(159, 114)
        Me.GroupBox1.TabIndex = 49
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label31.Location = New System.Drawing.Point(584, 232)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(16, 13)
        Me.Label31.TabIndex = 6
        Me.Label31.Text = "%"
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ComboBox1.ItemHeight = 13
        Me.ComboBox1.Location = New System.Drawing.Point(-10, -105)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 0
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label32.Location = New System.Drawing.Point(-74, -102)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(69, 13)
        Me.Label32.TabIndex = 3
        Me.Label32.Text = "SECTION :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(8, 80)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(132, 13)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "WORKS CONTRACT :"
        '
        'Cbo_WorksContractSection
        '
        Me.Cbo_WorksContractSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo_WorksContractSection.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cbo_WorksContractSection.ItemHeight = 13
        Me.Cbo_WorksContractSection.Location = New System.Drawing.Point(393, 80)
        Me.Cbo_WorksContractSection.Name = "Cbo_WorksContractSection"
        Me.Cbo_WorksContractSection.Size = New System.Drawing.Size(121, 21)
        Me.Cbo_WorksContractSection.TabIndex = 86
        '
        'Txt_WorksContractPercentage
        '
        Me.Txt_WorksContractPercentage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Txt_WorksContractPercentage.Location = New System.Drawing.Point(472, 80)
        Me.Txt_WorksContractPercentage.MaxLength = 6
        Me.Txt_WorksContractPercentage.Name = "Txt_WorksContractPercentage"
        Me.Txt_WorksContractPercentage.ReadOnly = True
        Me.Txt_WorksContractPercentage.Size = New System.Drawing.Size(48, 20)
        Me.Txt_WorksContractPercentage.TabIndex = 87
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label16.Location = New System.Drawing.Point(9, 112)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(110, 13)
        Me.Label16.TabIndex = 23
        Me.Label16.Text = "PURCHASE TAX :"
        '
        'Txt_PurchaseTaxPercentage
        '
        Me.Txt_PurchaseTaxPercentage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Txt_PurchaseTaxPercentage.Location = New System.Drawing.Point(472, 112)
        Me.Txt_PurchaseTaxPercentage.MaxLength = 6
        Me.Txt_PurchaseTaxPercentage.Name = "Txt_PurchaseTaxPercentage"
        Me.Txt_PurchaseTaxPercentage.ReadOnly = True
        Me.Txt_PurchaseTaxPercentage.Size = New System.Drawing.Size(48, 20)
        Me.Txt_PurchaseTaxPercentage.TabIndex = 92
        '
        'Cbo_PurchaseTaxSection
        '
        Me.Cbo_PurchaseTaxSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo_PurchaseTaxSection.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cbo_PurchaseTaxSection.ItemHeight = 13
        Me.Cbo_PurchaseTaxSection.Location = New System.Drawing.Point(328, 112)
        Me.Cbo_PurchaseTaxSection.Name = "Cbo_PurchaseTaxSection"
        Me.Cbo_PurchaseTaxSection.Size = New System.Drawing.Size(121, 21)
        Me.Cbo_PurchaseTaxSection.TabIndex = 90
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label17.Location = New System.Drawing.Point(9, 144)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(35, 13)
        Me.Label17.TabIndex = 26
        Me.Label17.Text = "ESI :"
        '
        'Cbo_EsiSection
        '
        Me.Cbo_EsiSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo_EsiSection.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cbo_EsiSection.ItemHeight = 13
        Me.Cbo_EsiSection.Location = New System.Drawing.Point(328, 144)
        Me.Cbo_EsiSection.Name = "Cbo_EsiSection"
        Me.Cbo_EsiSection.Size = New System.Drawing.Size(121, 21)
        Me.Cbo_EsiSection.TabIndex = 94
        '
        'Txt_EsiPercentage
        '
        Me.Txt_EsiPercentage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Txt_EsiPercentage.Location = New System.Drawing.Point(472, 144)
        Me.Txt_EsiPercentage.MaxLength = 6
        Me.Txt_EsiPercentage.Name = "Txt_EsiPercentage"
        Me.Txt_EsiPercentage.ReadOnly = True
        Me.Txt_EsiPercentage.Size = New System.Drawing.Size(48, 20)
        Me.Txt_EsiPercentage.TabIndex = 95
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label18.Location = New System.Drawing.Point(9, 176)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(30, 13)
        Me.Label18.TabIndex = 29
        Me.Label18.Text = "PF :"
        '
        'Cbo_PfSection
        '
        Me.Cbo_PfSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo_PfSection.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cbo_PfSection.ItemHeight = 13
        Me.Cbo_PfSection.Location = New System.Drawing.Point(328, 176)
        Me.Cbo_PfSection.Name = "Cbo_PfSection"
        Me.Cbo_PfSection.Size = New System.Drawing.Size(121, 21)
        Me.Cbo_PfSection.TabIndex = 98
        '
        'Txt_PfPercentage
        '
        Me.Txt_PfPercentage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Txt_PfPercentage.Location = New System.Drawing.Point(472, 176)
        Me.Txt_PfPercentage.MaxLength = 6
        Me.Txt_PfPercentage.Name = "Txt_PfPercentage"
        Me.Txt_PfPercentage.ReadOnly = True
        Me.Txt_PfPercentage.Size = New System.Drawing.Size(48, 20)
        Me.Txt_PfPercentage.TabIndex = 99
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox7.Controls.Add(Me.Rdo_WorksContractNo)
        Me.GroupBox7.Controls.Add(Me.Rdo_WorksContractYes)
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox7.Location = New System.Drawing.Point(144, 72)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(112, 32)
        Me.GroupBox7.TabIndex = 101
        Me.GroupBox7.TabStop = False
        '
        'Rdo_WorksContractNo
        '
        Me.Rdo_WorksContractNo.BackColor = System.Drawing.Color.Transparent
        Me.Rdo_WorksContractNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Rdo_WorksContractNo.Location = New System.Drawing.Point(129, 8)
        Me.Rdo_WorksContractNo.Name = "Rdo_WorksContractNo"
        Me.Rdo_WorksContractNo.Size = New System.Drawing.Size(48, 24)
        Me.Rdo_WorksContractNo.TabIndex = 22
        Me.Rdo_WorksContractNo.Text = "NO"
        Me.Rdo_WorksContractNo.UseVisualStyleBackColor = False
        '
        'Rdo_WorksContractYes
        '
        Me.Rdo_WorksContractYes.BackColor = System.Drawing.Color.Transparent
        Me.Rdo_WorksContractYes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Rdo_WorksContractYes.Location = New System.Drawing.Point(73, 8)
        Me.Rdo_WorksContractYes.Name = "Rdo_WorksContractYes"
        Me.Rdo_WorksContractYes.Size = New System.Drawing.Size(56, 24)
        Me.Rdo_WorksContractYes.TabIndex = 21
        Me.Rdo_WorksContractYes.Text = "YES"
        Me.Rdo_WorksContractYes.UseVisualStyleBackColor = False
        '
        'Lbl_EsiSection
        '
        Me.Lbl_EsiSection.AutoSize = True
        Me.Lbl_EsiSection.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_EsiSection.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_EsiSection.Location = New System.Drawing.Point(264, 144)
        Me.Lbl_EsiSection.Name = "Lbl_EsiSection"
        Me.Lbl_EsiSection.Size = New System.Drawing.Size(73, 13)
        Me.Lbl_EsiSection.TabIndex = 93
        Me.Lbl_EsiSection.Text = "ESI CODE :"
        '
        'Lbl_Pfp
        '
        Me.Lbl_Pfp.AutoSize = True
        Me.Lbl_Pfp.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Pfp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Pfp.Location = New System.Drawing.Point(448, 176)
        Me.Lbl_Pfp.Name = "Lbl_Pfp"
        Me.Lbl_Pfp.Size = New System.Drawing.Size(16, 13)
        Me.Lbl_Pfp.TabIndex = 100
        Me.Lbl_Pfp.Text = "%"
        '
        'Lbl_PfSection
        '
        Me.Lbl_PfSection.AutoSize = True
        Me.Lbl_PfSection.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_PfSection.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_PfSection.Location = New System.Drawing.Point(264, 176)
        Me.Lbl_PfSection.Name = "Lbl_PfSection"
        Me.Lbl_PfSection.Size = New System.Drawing.Size(68, 13)
        Me.Lbl_PfSection.TabIndex = 97
        Me.Lbl_PfSection.Text = "PF CODE :"
        '
        'Lbl_esip
        '
        Me.Lbl_esip.AutoSize = True
        Me.Lbl_esip.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_esip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_esip.Location = New System.Drawing.Point(448, 144)
        Me.Lbl_esip.Name = "Lbl_esip"
        Me.Lbl_esip.Size = New System.Drawing.Size(16, 13)
        Me.Lbl_esip.TabIndex = 96
        Me.Lbl_esip.Text = "%"
        '
        'Lbl_PurchaseTaxp
        '
        Me.Lbl_PurchaseTaxp.AutoSize = True
        Me.Lbl_PurchaseTaxp.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_PurchaseTaxp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_PurchaseTaxp.Location = New System.Drawing.Point(448, 112)
        Me.Lbl_PurchaseTaxp.Name = "Lbl_PurchaseTaxp"
        Me.Lbl_PurchaseTaxp.Size = New System.Drawing.Size(16, 13)
        Me.Lbl_PurchaseTaxp.TabIndex = 91
        Me.Lbl_PurchaseTaxp.Text = "%"
        '
        'Lbl_WorksContractp
        '
        Me.Lbl_WorksContractp.AutoSize = True
        Me.Lbl_WorksContractp.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_WorksContractp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_WorksContractp.Location = New System.Drawing.Point(448, 80)
        Me.Lbl_WorksContractp.Name = "Lbl_WorksContractp"
        Me.Lbl_WorksContractp.Size = New System.Drawing.Size(16, 13)
        Me.Lbl_WorksContractp.TabIndex = 88
        Me.Lbl_WorksContractp.Text = "%"
        '
        'Lbl_WorksContractSection
        '
        Me.Lbl_WorksContractSection.AutoSize = True
        Me.Lbl_WorksContractSection.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_WorksContractSection.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_WorksContractSection.Location = New System.Drawing.Point(264, 80)
        Me.Lbl_WorksContractSection.Name = "Lbl_WorksContractSection"
        Me.Lbl_WorksContractSection.Size = New System.Drawing.Size(65, 13)
        Me.Lbl_WorksContractSection.TabIndex = 85
        Me.Lbl_WorksContractSection.Text = "W.CODE :"
        '
        'Lbl_PurchaseTaxSection
        '
        Me.Lbl_PurchaseTaxSection.AutoSize = True
        Me.Lbl_PurchaseTaxSection.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_PurchaseTaxSection.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_PurchaseTaxSection.Location = New System.Drawing.Point(264, 112)
        Me.Lbl_PurchaseTaxSection.Name = "Lbl_PurchaseTaxSection"
        Me.Lbl_PurchaseTaxSection.Size = New System.Drawing.Size(61, 13)
        Me.Lbl_PurchaseTaxSection.TabIndex = 89
        Me.Lbl_PurchaseTaxSection.Text = "T.CODE :"
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox8.Controls.Add(Me.Rdo_PurchaseTaxNo)
        Me.GroupBox8.Controls.Add(Me.Rdo_PurchaseTaxYes)
        Me.GroupBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox8.Location = New System.Drawing.Point(144, 104)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(112, 32)
        Me.GroupBox8.TabIndex = 102
        Me.GroupBox8.TabStop = False
        '
        'Rdo_PurchaseTaxNo
        '
        Me.Rdo_PurchaseTaxNo.BackColor = System.Drawing.Color.Transparent
        Me.Rdo_PurchaseTaxNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Rdo_PurchaseTaxNo.Location = New System.Drawing.Point(64, 8)
        Me.Rdo_PurchaseTaxNo.Name = "Rdo_PurchaseTaxNo"
        Me.Rdo_PurchaseTaxNo.Size = New System.Drawing.Size(48, 24)
        Me.Rdo_PurchaseTaxNo.TabIndex = 25
        Me.Rdo_PurchaseTaxNo.Text = "NO"
        Me.Rdo_PurchaseTaxNo.UseVisualStyleBackColor = False
        '
        'Rdo_PurchaseTaxYes
        '
        Me.Rdo_PurchaseTaxYes.BackColor = System.Drawing.Color.Transparent
        Me.Rdo_PurchaseTaxYes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Rdo_PurchaseTaxYes.Location = New System.Drawing.Point(8, 8)
        Me.Rdo_PurchaseTaxYes.Name = "Rdo_PurchaseTaxYes"
        Me.Rdo_PurchaseTaxYes.Size = New System.Drawing.Size(56, 24)
        Me.Rdo_PurchaseTaxYes.TabIndex = 24
        Me.Rdo_PurchaseTaxYes.Text = "YES"
        Me.Rdo_PurchaseTaxYes.UseVisualStyleBackColor = False
        '
        'GroupBox9
        '
        Me.GroupBox9.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox9.Controls.Add(Me.Rdo_ESINo)
        Me.GroupBox9.Controls.Add(Me.Rdo_ESIYes)
        Me.GroupBox9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox9.Location = New System.Drawing.Point(144, 136)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(112, 32)
        Me.GroupBox9.TabIndex = 103
        Me.GroupBox9.TabStop = False
        '
        'Rdo_ESINo
        '
        Me.Rdo_ESINo.BackColor = System.Drawing.Color.Transparent
        Me.Rdo_ESINo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Rdo_ESINo.Location = New System.Drawing.Point(64, 8)
        Me.Rdo_ESINo.Name = "Rdo_ESINo"
        Me.Rdo_ESINo.Size = New System.Drawing.Size(48, 24)
        Me.Rdo_ESINo.TabIndex = 28
        Me.Rdo_ESINo.Text = "NO"
        Me.Rdo_ESINo.UseVisualStyleBackColor = False
        '
        'Rdo_ESIYes
        '
        Me.Rdo_ESIYes.BackColor = System.Drawing.Color.Transparent
        Me.Rdo_ESIYes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Rdo_ESIYes.Location = New System.Drawing.Point(8, 8)
        Me.Rdo_ESIYes.Name = "Rdo_ESIYes"
        Me.Rdo_ESIYes.Size = New System.Drawing.Size(56, 24)
        Me.Rdo_ESIYes.TabIndex = 27
        Me.Rdo_ESIYes.Text = "YES"
        Me.Rdo_ESIYes.UseVisualStyleBackColor = False
        '
        'GroupBox10
        '
        Me.GroupBox10.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox10.Controls.Add(Me.Rdo_PFNo)
        Me.GroupBox10.Controls.Add(Me.Rdo_PFYes)
        Me.GroupBox10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox10.Location = New System.Drawing.Point(144, 168)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(112, 32)
        Me.GroupBox10.TabIndex = 104
        Me.GroupBox10.TabStop = False
        '
        'Rdo_PFNo
        '
        Me.Rdo_PFNo.BackColor = System.Drawing.Color.Transparent
        Me.Rdo_PFNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Rdo_PFNo.Location = New System.Drawing.Point(64, 8)
        Me.Rdo_PFNo.Name = "Rdo_PFNo"
        Me.Rdo_PFNo.Size = New System.Drawing.Size(40, 24)
        Me.Rdo_PFNo.TabIndex = 31
        Me.Rdo_PFNo.Text = "NO"
        Me.Rdo_PFNo.UseVisualStyleBackColor = False
        '
        'Rdo_PFYes
        '
        Me.Rdo_PFYes.BackColor = System.Drawing.Color.Transparent
        Me.Rdo_PFYes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Rdo_PFYes.Location = New System.Drawing.Point(8, 8)
        Me.Rdo_PFYes.Name = "Rdo_PFYes"
        Me.Rdo_PFYes.Size = New System.Drawing.Size(48, 24)
        Me.Rdo_PFYes.TabIndex = 30
        Me.Rdo_PFYes.Text = "YES"
        Me.Rdo_PFYes.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Cmd_SLCodeHelp)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Cmb_SLType)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Txt_SLCode)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Txt_SLName)
        Me.GroupBox3.Controls.Add(Me.GroupBox6)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.Location = New System.Drawing.Point(66, 118)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(342, 138)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'Cmd_SLCodeHelp
        '
        Me.Cmd_SLCodeHelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_SLCodeHelp.Image = CType(resources.GetObject("Cmd_SLCodeHelp.Image"), System.Drawing.Image)
        Me.Cmd_SLCodeHelp.Location = New System.Drawing.Point(237, 46)
        Me.Cmd_SLCodeHelp.Name = "Cmd_SLCodeHelp"
        Me.Cmd_SLCodeHelp.Size = New System.Drawing.Size(23, 26)
        Me.Cmd_SLCodeHelp.TabIndex = 2
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.Rdo_TDSYes)
        Me.GroupBox6.Controls.Add(Me.Rdo_TDSNo)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox6.Location = New System.Drawing.Point(72, 100)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(112, 32)
        Me.GroupBox6.TabIndex = 100
        Me.GroupBox6.TabStop = False
        '
        'Rdo_TDSYes
        '
        Me.Rdo_TDSYes.BackColor = System.Drawing.Color.Transparent
        Me.Rdo_TDSYes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Rdo_TDSYes.Location = New System.Drawing.Point(6, 8)
        Me.Rdo_TDSYes.Name = "Rdo_TDSYes"
        Me.Rdo_TDSYes.Size = New System.Drawing.Size(50, 24)
        Me.Rdo_TDSYes.TabIndex = 0
        Me.Rdo_TDSYes.Text = "YES"
        Me.Rdo_TDSYes.UseVisualStyleBackColor = False
        '
        'Rdo_TDSNo
        '
        Me.Rdo_TDSNo.BackColor = System.Drawing.Color.Transparent
        Me.Rdo_TDSNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Rdo_TDSNo.Location = New System.Drawing.Point(62, 8)
        Me.Rdo_TDSNo.Name = "Rdo_TDSNo"
        Me.Rdo_TDSNo.Size = New System.Drawing.Size(50, 24)
        Me.Rdo_TDSNo.TabIndex = 1
        Me.Rdo_TDSNo.Text = "NO"
        Me.Rdo_TDSNo.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(10, 114)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 13)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "TDS :"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.GroupBox11)
        Me.GroupBox5.Controls.Add(Me.GroupBox12)
        Me.GroupBox5.Controls.Add(Me.Txt_OpeningBalance)
        Me.GroupBox5.Controls.Add(Me.Txt_BalanceAsOn)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox5.Location = New System.Drawing.Point(40, 408)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(92, 96)
        Me.GroupBox5.TabIndex = 81
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Visible = False
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.Rdo_BalanceAsOnDebit)
        Me.GroupBox11.Controls.Add(Me.Rdo_BalanceAsOnCredit)
        Me.GroupBox11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox11.Location = New System.Drawing.Point(224, 56)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(136, 32)
        Me.GroupBox11.TabIndex = 43
        Me.GroupBox11.TabStop = False
        '
        'Rdo_BalanceAsOnDebit
        '
        Me.Rdo_BalanceAsOnDebit.BackColor = System.Drawing.Color.Transparent
        Me.Rdo_BalanceAsOnDebit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Rdo_BalanceAsOnDebit.Location = New System.Drawing.Point(8, 8)
        Me.Rdo_BalanceAsOnDebit.Name = "Rdo_BalanceAsOnDebit"
        Me.Rdo_BalanceAsOnDebit.Size = New System.Drawing.Size(64, 24)
        Me.Rdo_BalanceAsOnDebit.TabIndex = 0
        Me.Rdo_BalanceAsOnDebit.Text = "DEBIT"
        Me.Rdo_BalanceAsOnDebit.UseVisualStyleBackColor = False
        '
        'Rdo_BalanceAsOnCredit
        '
        Me.Rdo_BalanceAsOnCredit.BackColor = System.Drawing.Color.Transparent
        Me.Rdo_BalanceAsOnCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Rdo_BalanceAsOnCredit.Location = New System.Drawing.Point(72, 8)
        Me.Rdo_BalanceAsOnCredit.Name = "Rdo_BalanceAsOnCredit"
        Me.Rdo_BalanceAsOnCredit.Size = New System.Drawing.Size(72, 24)
        Me.Rdo_BalanceAsOnCredit.TabIndex = 33
        Me.Rdo_BalanceAsOnCredit.Text = "CREDIT"
        Me.Rdo_BalanceAsOnCredit.UseVisualStyleBackColor = False
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.Rdo_OpeningBalanceDebit)
        Me.GroupBox12.Controls.Add(Me.Rdo_OpeningBalanceCredit)
        Me.GroupBox12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox12.Location = New System.Drawing.Point(224, 16)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(136, 32)
        Me.GroupBox12.TabIndex = 42
        Me.GroupBox12.TabStop = False
        '
        'Rdo_OpeningBalanceDebit
        '
        Me.Rdo_OpeningBalanceDebit.BackColor = System.Drawing.Color.Transparent
        Me.Rdo_OpeningBalanceDebit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Rdo_OpeningBalanceDebit.Location = New System.Drawing.Point(8, 8)
        Me.Rdo_OpeningBalanceDebit.Name = "Rdo_OpeningBalanceDebit"
        Me.Rdo_OpeningBalanceDebit.Size = New System.Drawing.Size(64, 24)
        Me.Rdo_OpeningBalanceDebit.TabIndex = 0
        Me.Rdo_OpeningBalanceDebit.Text = "DEBIT"
        Me.Rdo_OpeningBalanceDebit.UseVisualStyleBackColor = False
        '
        'Rdo_OpeningBalanceCredit
        '
        Me.Rdo_OpeningBalanceCredit.BackColor = System.Drawing.Color.Transparent
        Me.Rdo_OpeningBalanceCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Rdo_OpeningBalanceCredit.Location = New System.Drawing.Point(72, 8)
        Me.Rdo_OpeningBalanceCredit.Name = "Rdo_OpeningBalanceCredit"
        Me.Rdo_OpeningBalanceCredit.Size = New System.Drawing.Size(72, 24)
        Me.Rdo_OpeningBalanceCredit.TabIndex = 30
        Me.Rdo_OpeningBalanceCredit.Text = "CREDIT"
        Me.Rdo_OpeningBalanceCredit.UseVisualStyleBackColor = False
        '
        'Txt_OpeningBalance
        '
        Me.Txt_OpeningBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Txt_OpeningBalance.Location = New System.Drawing.Point(20, 19)
        Me.Txt_OpeningBalance.MaxLength = 8
        Me.Txt_OpeningBalance.Name = "Txt_OpeningBalance"
        Me.Txt_OpeningBalance.Size = New System.Drawing.Size(80, 20)
        Me.Txt_OpeningBalance.TabIndex = 11
        Me.Txt_OpeningBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt_OpeningBalance.Visible = False
        '
        'Txt_BalanceAsOn
        '
        Me.Txt_BalanceAsOn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Txt_BalanceAsOn.Location = New System.Drawing.Point(20, 59)
        Me.Txt_BalanceAsOn.MaxLength = 8
        Me.Txt_BalanceAsOn.Name = "Txt_BalanceAsOn"
        Me.Txt_BalanceAsOn.ReadOnly = True
        Me.Txt_BalanceAsOn.Size = New System.Drawing.Size(80, 20)
        Me.Txt_BalanceAsOn.TabIndex = 76
        Me.Txt_BalanceAsOn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt_BalanceAsOn.Visible = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label20.Location = New System.Drawing.Point(33, 472)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(117, 13)
        Me.Label20.TabIndex = 74
        Me.Label20.Text = "BALANCE AS ON  :"
        Me.Label20.Visible = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label21.Location = New System.Drawing.Point(32, 432)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(131, 13)
        Me.Label21.TabIndex = 73
        Me.Label21.Text = "OPENING BALANCE :"
        Me.Label21.Visible = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label23.Location = New System.Drawing.Point(50, 384)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(82, 13)
        Me.Label23.TabIndex = 84
        Me.Label23.Text = "NO OF DAYS"
        Me.Label23.Visible = False
        '
        'Txt_CreditPeriod
        '
        Me.Txt_CreditPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Txt_CreditPeriod.Location = New System.Drawing.Point(88, 363)
        Me.Txt_CreditPeriod.MaxLength = 3
        Me.Txt_CreditPeriod.Name = "Txt_CreditPeriod"
        Me.Txt_CreditPeriod.Size = New System.Drawing.Size(64, 20)
        Me.Txt_CreditPeriod.TabIndex = 10
        Me.Txt_CreditPeriod.Text = "0"
        Me.Txt_CreditPeriod.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label19.Location = New System.Drawing.Point(34, 384)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(120, 13)
        Me.Label19.TabIndex = 32
        Me.Label19.Text = "CREDIT PERIODS :"
        Me.Label19.Visible = False
        '
        'Txt_TDSPercentage
        '
        Me.Txt_TDSPercentage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Txt_TDSPercentage.Location = New System.Drawing.Point(79, 112)
        Me.Txt_TDSPercentage.MaxLength = 6
        Me.Txt_TDSPercentage.Name = "Txt_TDSPercentage"
        Me.Txt_TDSPercentage.ReadOnly = True
        Me.Txt_TDSPercentage.Size = New System.Drawing.Size(48, 20)
        Me.Txt_TDSPercentage.TabIndex = 2
        Me.Txt_TDSPercentage.Visible = False
        '
        'Lbl_tdsp
        '
        Me.Lbl_tdsp.AutoSize = True
        Me.Lbl_tdsp.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_tdsp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_tdsp.Location = New System.Drawing.Point(127, 114)
        Me.Lbl_tdsp.Name = "Lbl_tdsp"
        Me.Lbl_tdsp.Size = New System.Drawing.Size(16, 13)
        Me.Lbl_tdsp.TabIndex = 2
        Me.Lbl_tdsp.Text = "%"
        Me.Lbl_tdsp.Visible = False
        '
        'lbl_TdSection
        '
        Me.lbl_TdSection.AutoSize = True
        Me.lbl_TdSection.BackColor = System.Drawing.Color.Transparent
        Me.lbl_TdSection.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbl_TdSection.Location = New System.Drawing.Point(10, 114)
        Me.lbl_TdSection.Name = "lbl_TdSection"
        Me.lbl_TdSection.Size = New System.Drawing.Size(69, 13)
        Me.lbl_TdSection.TabIndex = 3
        Me.lbl_TdSection.Text = "SECTION :"
        Me.lbl_TdSection.Visible = False
        '
        'Cbo_TDSSection
        '
        Me.Cbo_TDSSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo_TDSSection.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cbo_TDSSection.ItemHeight = 13
        Me.Cbo_TDSSection.Location = New System.Drawing.Point(125, 82)
        Me.Cbo_TDSSection.Name = "Cbo_TDSSection"
        Me.Cbo_TDSSection.Size = New System.Drawing.Size(72, 21)
        Me.Cbo_TDSSection.TabIndex = 1
        Me.Cbo_TDSSection.Visible = False
        '
        'lbl_TDSSection
        '
        Me.lbl_TDSSection.AutoSize = True
        Me.lbl_TDSSection.BackColor = System.Drawing.Color.Transparent
        Me.lbl_TDSSection.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbl_TDSSection.Location = New System.Drawing.Point(10, 82)
        Me.lbl_TDSSection.Name = "lbl_TDSSection"
        Me.lbl_TDSSection.Size = New System.Drawing.Size(78, 13)
        Me.lbl_TDSSection.TabIndex = 0
        Me.lbl_TDSSection.Text = "TDS CODE :"
        Me.lbl_TDSSection.Visible = False
        '
        'Lbl_Freeze
        '
        Me.Lbl_Freeze.AutoSize = True
        Me.Lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Freeze.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Freeze.Location = New System.Drawing.Point(714, 76)
        Me.Lbl_Freeze.Name = "Lbl_Freeze"
        Me.Lbl_Freeze.Size = New System.Drawing.Size(120, 13)
        Me.Lbl_Freeze.TabIndex = 104
        Me.Lbl_Freeze.Text = "RECORD FREEZED"
        Me.Lbl_Freeze.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(4, 144)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 15)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "PAN NO"
        '
        'Txt_PANNo
        '
        Me.Txt_PANNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Txt_PANNo.Location = New System.Drawing.Point(72, 142)
        Me.Txt_PANNo.MaxLength = 15
        Me.Txt_PANNo.Name = "Txt_PANNo"
        Me.Txt_PANNo.Size = New System.Drawing.Size(112, 20)
        Me.Txt_PANNo.TabIndex = 9
        '
        'Txt_GRNNo
        '
        Me.Txt_GRNNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Txt_GRNNo.Location = New System.Drawing.Point(72, 111)
        Me.Txt_GRNNo.MaxLength = 15
        Me.Txt_GRNNo.Name = "Txt_GRNNo"
        Me.Txt_GRNNo.Size = New System.Drawing.Size(112, 20)
        Me.Txt_GRNNo.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(4, 112)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 15)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "GRN NO"
        '
        'Txt_CSTNo
        '
        Me.Txt_CSTNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Txt_CSTNo.Location = New System.Drawing.Point(72, 47)
        Me.Txt_CSTNo.MaxLength = 15
        Me.Txt_CSTNo.Name = "Txt_CSTNo"
        Me.Txt_CSTNo.Size = New System.Drawing.Size(112, 20)
        Me.Txt_CSTNo.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(4, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 15)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "CST NO"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(4, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 15)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "VAT NO"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Controls.Add(Me.TxtGSTINNO)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Txt_VATNo)
        Me.GroupBox2.Controls.Add(Me.Txt_CSTNo)
        Me.GroupBox2.Controls.Add(Me.Txt_GRNNo)
        Me.GroupBox2.Controls.Add(Me.Txt_PANNo)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Txt_TINNo)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.Location = New System.Drawing.Point(66, 262)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(190, 250)
        Me.GroupBox2.TabIndex = 50
        Me.GroupBox2.TabStop = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(5, 177)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(61, 15)
        Me.Label30.TabIndex = 18
        Me.Label30.Text = "GSTIN NO"
        '
        'TxtGSTINNO
        '
        Me.TxtGSTINNO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TxtGSTINNO.Location = New System.Drawing.Point(73, 175)
        Me.TxtGSTINNO.MaxLength = 15
        Me.TxtGSTINNO.Name = "TxtGSTINNO"
        Me.TxtGSTINNO.Size = New System.Drawing.Size(112, 20)
        Me.TxtGSTINNO.TabIndex = 17
        '
        'Txt_VATNo
        '
        Me.Txt_VATNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Txt_VATNo.Location = New System.Drawing.Point(72, 13)
        Me.Txt_VATNo.MaxLength = 15
        Me.Txt_VATNo.Name = "Txt_VATNo"
        Me.Txt_VATNo.Size = New System.Drawing.Size(112, 20)
        Me.Txt_VATNo.TabIndex = 5
        '
        'cmd_auth
        '
        Me.cmd_auth.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmd_auth.FlatAppearance.BorderSize = 0
        Me.cmd_auth.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.cmd_auth.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmd_auth.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmd_auth.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_auth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cmd_auth.ForeColor = System.Drawing.Color.Black
        Me.cmd_auth.Image = CType(resources.GetObject("cmd_auth.Image"), System.Drawing.Image)
        Me.cmd_auth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_auth.Location = New System.Drawing.Point(763, 432)
        Me.cmd_auth.Name = "cmd_auth"
        Me.cmd_auth.Size = New System.Drawing.Size(124, 46)
        Me.cmd_auth.TabIndex = 467
        Me.cmd_auth.Text = "Authorize"
        Me.cmd_auth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_auth.UseVisualStyleBackColor = False
        Me.cmd_auth.Visible = False
        '
        'cmd_export
        '
        Me.cmd_export.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmd_export.FlatAppearance.BorderSize = 0
        Me.cmd_export.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.cmd_export.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmd_export.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmd_export.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_export.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_export.ForeColor = System.Drawing.Color.Black
        Me.cmd_export.Image = CType(resources.GetObject("cmd_export.Image"), System.Drawing.Image)
        Me.cmd_export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_export.Location = New System.Drawing.Point(2, 204)
        Me.cmd_export.Name = "cmd_export"
        Me.cmd_export.Size = New System.Drawing.Size(124, 46)
        Me.cmd_export.TabIndex = 468
        Me.cmd_export.Text = "Export[F12]"
        Me.cmd_export.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_export.UseVisualStyleBackColor = False
        '
        'Lbl_Last
        '
        Me.Lbl_Last.AutoSize = True
        Me.Lbl_Last.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Last.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Last.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Last.Location = New System.Drawing.Point(76, 80)
        Me.Lbl_Last.Name = "Lbl_Last"
        Me.Lbl_Last.Size = New System.Drawing.Size(63, 15)
        Me.Lbl_Last.TabIndex = 586
        Me.Lbl_Last.Text = "LAST NO :"
        Me.Lbl_Last.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox13
        '
        Me.GroupBox13.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox13.Controls.Add(Me.Label2)
        Me.GroupBox13.Controls.Add(Me.Cmd_GLAcCodeHelp)
        Me.GroupBox13.Controls.Add(Me.Txt_GLAcCode)
        Me.GroupBox13.Controls.Add(Me.Label41)
        Me.GroupBox13.Controls.Add(Me.Txt_GLAcDesc)
        Me.GroupBox13.Controls.Add(Me.Cbo_TDSSection)
        Me.GroupBox13.Controls.Add(Me.lbl_TDSSection)
        Me.GroupBox13.Controls.Add(Me.lbl_TdSection)
        Me.GroupBox13.Controls.Add(Me.Lbl_tdsp)
        Me.GroupBox13.Controls.Add(Me.Txt_TDSPercentage)
        Me.GroupBox13.Location = New System.Drawing.Point(425, 118)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(317, 138)
        Me.GroupBox13.TabIndex = 587
        Me.GroupBox13.TabStop = False
        '
        'frmbut
        '
        Me.frmbut.BackColor = System.Drawing.Color.Transparent
        Me.frmbut.Controls.Add(Me.CmdClear)
        Me.frmbut.Controls.Add(Me.cmdexit)
        Me.frmbut.Controls.Add(Me.CmdView)
        Me.frmbut.Controls.Add(Me.cmd_export)
        Me.frmbut.Controls.Add(Me.CmdAdd)
        Me.frmbut.Controls.Add(Me.cmdcrystal)
        Me.frmbut.Location = New System.Drawing.Point(760, 118)
        Me.frmbut.Name = "frmbut"
        Me.frmbut.Size = New System.Drawing.Size(131, 311)
        Me.frmbut.TabIndex = 588
        Me.frmbut.TabStop = False
        '
        'lbl_ac
        '
        Me.lbl_ac.AutoSize = True
        Me.lbl_ac.BackColor = System.Drawing.Color.Transparent
        Me.lbl_ac.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ac.Location = New System.Drawing.Point(733, 80)
        Me.lbl_ac.Name = "lbl_ac"
        Me.lbl_ac.Size = New System.Drawing.Size(0, 15)
        Me.lbl_ac.TabIndex = 589
        '
        'SUBLEDGERMASTER
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(913, 669)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbl_ac)
        Me.Controls.Add(Me.frmbut)
        Me.Controls.Add(Me.cmd_auth)
        Me.Controls.Add(Me.Lbl_Last)
        Me.Controls.Add(Me.Lbl_Freeze)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CmdDelete)
        Me.Controls.Add(Me.chk_excel)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Txt_CreditPeriod)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.cmdexport)
        Me.Controls.Add(Me.GroupBox13)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "SUBLEDGERMASTER"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SUB LEDGER MASTER"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        Me.frmbut.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim vconn As New GlobalClass
    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        'If MsgBox("Close this form", MsgBoxStyle.OKCancel + MsgBoxStyle.Question, Me.Text) = MsgBoxResult.OK Then
        Me.Close()
        'Else
        'Txt_GLAcCode.Focus()
        'End If
    End Sub
    Private Sub GetLastNo()
        Dim SQLSTRING As String
        Dim DR As DataRow
        SQLSTRING = "SELECT Isnull(Max(SLCODE),0)as SLCODE FROM accountssubledgermaster where accode='" + Txt_GLAcCode.Text + "'"
        gconnection.getDataSet(SQLSTRING, "membermaster")
        If gdataset.Tables("membermaster").Rows.Count > 0 Then
            Me.Lbl_Last.Text = "Last No IS : " & " " & gdataset.Tables("membermaster").Rows(0).Item(0)
        Else
            Me.Lbl_Last.Text = "Last No" & " " & 0
        End If

    End Sub
    Private Sub Resize_Form()
        Dim cControl As Control
        Dim i_i As Integer
        Dim J, K, L, M, n, o, P, Q, R, S, T, U As Integer
        'If (Screen.PrimaryScreen.Bounds.Height = 768) And (Screen.PrimaryScreen.Bounds.Width = 1366) Then
        '    Exit Sub
        'End If
        J = 780
        K = 1044
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
                        If Controls(i_i).Name = "frmbut" Then
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
    Private Sub SUBLEDGERMASTER_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Call Resize_Form()
        'Me.DoubleBuffered = True
        'Cmb_SLType.SelectedIndex = 0
        Rdo_ESINo.Checked = True
        Rdo_OpeningBalanceDebit.Checked = True
        Rdo_BalanceAsOnDebit.Checked = True
        Rdo_WorksContractNo.Checked = True
        Rdo_PurchaseTaxNo.Checked = True
        Rdo_TDSNo.Checked = True
        Rdo_PFNo.Checked = True
        'Refer Mk Kannan
        'Modified as on 19 Jul 07
        'Begin
        'Rdo_TaxNo.Checked = True
        'End
        If gShortname = "CCFC" Then
            Lbl_Last.Visible = False
        End If
        Call GetLastNo()
        Txt_CreditPeriod.Text = 0
        Txt_OpeningBalance.Text = 0
        Txt_BalanceAsOn.Text = 0
        Me.Cmb_SLType.SelectedIndex = 0
        Me.CmdDelete.Enabled = False
        Cmb_SLType.Focus()
        sqlstring = "  Select isnull(MSupplier,'N') as MSupplier  from inv_linksetup"
        gconnection.getDataSet(sqlstring, "inv_linksetup")

        If (gdataset.Tables("inv_linksetup").Rows.Count > 0) Then
            If (gdataset.Tables("inv_linksetup").Rows(0).Item("MSupplier").ToString() = "Y") Then
                Txt_GLAcCode.Text = ""
                Txt_GLAcDesc.Text = ""
                Txt_GLAcCode.ReadOnly = False
                Txt_GLAcDesc.ReadOnly = False
                Cmd_GLAcCodeHelp.Enabled = True
                Cmd_GLAcCodeHelp.Visible = True
            Else
                sqlstring = "  select isnull( ScrsCode,'SCRS') as 	ScrsCode , isnull(ScrsDesc,'SUNDRY CREDITORS') as ScrsDesc from AccountsSetup"
                gconnection.getDataSet(sqlstring, "AccountsSetup")
                If (gdataset.Tables("AccountsSetup").Rows.Count > 0) Then
                    Txt_GLAcCode.Text = gdataset.Tables("AccountsSetup").Rows(0).Item("ScrsCode")
                    Txt_GLAcDesc.Text = gdataset.Tables("AccountsSetup").Rows(0).Item("ScrsDesc")
                Else
                    Txt_GLAcCode.Text = "SCRS"
                    Txt_GLAcDesc.Text = "SUNDRY CREDITORS"
                End If
                'Txt_GLAcCode.Text = "SCRS"
                'Txt_GLAcDesc.Text = "SUNDRY CREDITORS"
                Txt_GLAcCode.ReadOnly = True
                Txt_GLAcDesc.ReadOnly = True
                Cmd_GLAcCodeHelp.Enabled = False


            End If

        End If
        Call FillTdsCode()
        Call FillPfCode()
        Call FillPurchaseCode()
        Call FillEsiCode()
        Call FillWorksCode()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            If Licensebool = False Then
                gconnection.FocusSetting(Me)
                Me.CmdClear.Visible = True
                Me.cmdexit.Visible = True
            End If
        End If
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        GmoduleName = "VENDOR CREATION"

        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='INVENTORY' AND MODULENAME LIKE '%" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
        gconnection.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.CmdAdd.Enabled = False
        ' Me.CmdFreeze.Enabled = False
        Me.CmdView.Enabled = False
        Me.cmd_auth.Enabled = False
        Me.cmdcrystal.Enabled = False
        Me.cmd_export.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.CmdAdd.Enabled = True
                    'Me.CmdFreeze.Enabled = True
                    Me.CmdView.Enabled = True
                    Me.cmd_auth.Enabled = True
                    Me.cmdcrystal.Enabled = True
                    Me.cmd_export.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.CmdAdd.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.CmdAdd.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.CmdAdd.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    'Me.CmdFreeze.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.CmdView.Enabled = True
                    Me.cmdcrystal.Enabled = True
                    Me.cmd_export.Enabled = True
                End If
                If Right(x) = "U" Then
                    Me.cmd_auth.Enabled = True
                End If
            Next
        End If
    End Sub
    Private Sub Txt_GLAcCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_GLAcCode.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If (Trim(Txt_GLAcCode.Text)) <> "" Then
                Txt_GLAcCode_Validated(Txt_GLAcCode, e)
            Else
                Call Me.Cmd_GLAcCodeHelp_Click(sender, e)
            End If
            Cmb_SLType.Focus()
        End If
    End Sub

    Private Sub Cmb_SLType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cmb_SLType.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_SLCode.Focus()
        End If
    End Sub
    Private Sub Txt_SLCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_SLCode.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(Me.Txt_SLCode.Text) <> "" Then
                Txt_SLCode_Validated(sender, e)
            Else
                Call Cmd_SLCodeHelp_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub Txt_SLName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_SLName.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(Me.Txt_SLName.Text) = "" Then
                Call Cmd_SLCodeHelp_Click(sender, e)
            Else
                Txt_VATNo.Focus()
                'CmdAdd.Focus()
                ' Txt_ContactPerson.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_VATNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_VATNo.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_CSTNo.Focus()
        End If
    End Sub

    Private Sub Txt_CSTNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_CSTNo.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_TINNo.Focus()
        End If
    End Sub

    Private Sub Txt_TINNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_TINNo.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_GRNNo.Focus()
        End If
        'getAlphanumeric(e)
        'If Asc(e.KeyChar) = 13 Then
        '    'Rdo_TDSYes.Focus()
        '    CmdAdd.Focus()
        'End If
    End Sub

    Private Sub Txt_GRNNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_GRNNo.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_PANNo.Focus()
        End If
    End Sub

    Private Sub Txt_PANNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_PANNo.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            'Txt_CreditPeriod.Focus()
            Txt_ContactPerson.Focus()
        End If
    End Sub

    Private Sub Txt_CreditPeriod_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_CreditPeriod.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_OpeningBalance.Focus()
        End If
    End Sub

    Private Sub Txt_OpeningBalance_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_OpeningBalance.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            'Rdo_OpeningBalanceDebit.Focus()
            Me.Txt_ContactPerson.Focus()
        End If
    End Sub

    Private Sub Rdo_OpeningBalanceDebit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_OpeningBalanceDebit.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_BalanceAsOn.Focus()
        End If
    End Sub

    Private Sub Rdo_OpeningBalanceCredit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_OpeningBalanceCredit.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_BalanceAsOn.Focus()
        End If
    End Sub

    Private Sub Txt_BalanceAsOn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_BalanceAsOn.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Rdo_BalanceAsOnDebit.Focus()
        End If
    End Sub

    Private Sub Rdo_BalanceAsOnDebit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_BalanceAsOnDebit.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_ContactPerson.Focus()
        End If
    End Sub

    Private Sub Rdo_BalanceAsOnCredit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_BalanceAsOnCredit.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_ContactPerson.Focus()
        End If
    End Sub

    Private Sub Txt_ContactPerson_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ContactPerson.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_Address1.Focus()
        End If
    End Sub

    Private Sub Txt_Address1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Address1.KeyPress
        'getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_Address2.Focus()
        End If
    End Sub

    Private Sub Txt_Address2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Address2.KeyPress
        'getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_Address3.Focus()
        End If
    End Sub

    Private Sub Txt_Address3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Address3.KeyPress
        'getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            txt_City.Focus()
        End If
    End Sub

    Private Sub Txt_City_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_State.Focus()
        End If
    End Sub

    Private Sub Txt_State_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_State.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_Pin.Focus()
        End If
    End Sub

    Private Sub Txt_Pin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Pin.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_PhoneNo.Focus()
        End If
    End Sub

    Private Sub Txt_PhoneNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_PhoneNo.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_CellNo.Focus()
        End If
    End Sub

    Private Sub Txt_CellNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_CellNo.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            'Rdo_TDSYes.Focus()
            txt_email.Focus()
        End If
    End Sub

    Private Sub Rdo_TDSYes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_TDSYes.KeyPress
        If Asc(e.KeyChar) = 13 Then
            CBO_TDSECTION.Focus()
        End If
    End Sub

    Private Sub Rdo_TDSNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_TDSNo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Rdo_WorksContractNo.Focus()
        End If
    End Sub
    Private Sub Rdo_TDSNo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rdo_TDSNo.CheckedChanged
        Cbo_TDSSection.Visible = False
        Txt_TDSPercentage.Visible = False
        Lbl_tdsp.Visible = False
        lbl_TDSSection.Visible = False
        CBO_TDSECTION.Visible = False
        lbl_TdSection.Visible = False
    End Sub

    Private Sub Rdo_TDSYes_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rdo_TDSYes.CheckedChanged
        CBO_TDSECTION.Visible = True
        lbl_TdSection.Visible = True
        Cbo_TDSSection.Visible = True
        Txt_TDSPercentage.Visible = True
        Lbl_tdsp.Visible = True
        lbl_TDSSection.Visible = True
        Cbo_TDSSection.Focus()
        If Cbo_TDSSection.Items.Count > 0 Then
            Cbo_TDSSection.SelectedIndex = -1
        End If
    End Sub
    Private Sub FillTdsCode()
        Dim ssql As String
        ssql = "Select TdsCode,Percentage from  accountstdsmaster"
        vconn.getDataSet(ssql, "TDS")
        Dim i As Integer
        If gdataset.Tables("TDS").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("TDS").Rows.Count - 1
                Me.Cbo_TDSSection.Items.Add(gdataset.Tables("TDS").Rows(i).Item("TdsCode"))
            Next i
        End If
    End Sub
    Private Sub FillWorksCode()
        Dim ssql As String
        ssql = "select WorksContractCode,percentage from  accountsworkscontractmaster"
        vconn.getDataSet(ssql, "WORKS")
        Dim i As Integer
        If gdataset.Tables("WORKS").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("WORKS").Rows.Count - 1
                Me.Cbo_WorksContractSection.Items.Add(gdataset.Tables("WORKS").Rows(i).Item("WorksContractCode"))
            Next i
        End If
    End Sub
    Private Sub FillEsiCode()
        Dim ssql As String
        ssql = "select EsiCode,SectionPercentage from  AccountsEsiMAster"
        vconn.getDataSet(ssql, "ESI")
        Dim i As Integer
        If gdataset.Tables("ESI").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("ESI").Rows.Count - 1
                Me.Cbo_EsiSection.Items.Add(gdataset.Tables("ESI").Rows(i).Item("EsiCode"))
            Next i
        End If
    End Sub
    Private Sub FillPfCode()
        Dim ssql As String
        ssql = "select PfCode,PfPercentage from  accountspfmaster"
        vconn.getDataSet(ssql, "PF")
        Dim i As Integer
        If gdataset.Tables("PF").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("WCM").Rows.Count - 1
                Me.Cbo_EsiSection.Items.Add(gdataset.Tables("PF").Rows(i).Item("PfCode"))
            Next i
        End If
    End Sub
    Private Sub FillPurchaseCode()
        Dim ssql As String
        ssql = "select Purchasecode,percentage from  accountspurchasetaxmaster"
        vconn.getDataSet(ssql, "PUR")
        Dim i As Integer
        If gdataset.Tables("PUR").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("PUR").Rows.Count - 1
                Me.Cbo_EsiSection.Items.Add(gdataset.Tables("PUR").Rows(i).Item("Purchasecode"))
            Next i
        End If
    End Sub
    Private Sub Cbo_TDSSection_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_TDSSection.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Dim i As Integer
            Dim ssql As String
            ssql = "Select SectionType from  accountstdsmaster where tdscode = '" & Trim(Cbo_TDSSection.Text & "") & "'"
            vconn.getDataSet(ssql, "TDSection")
            Me.CBO_TDSECTION.Items.Clear()
            If gdataset.Tables("TDSection").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("TDSection").Rows.Count - 1
                    Me.CBO_TDSECTION.Items.Add(gdataset.Tables("TDSection").Rows(i).Item("SectionType"))
                Next i
            End If
            CBO_TDSECTION.Focus()
        End If
    End Sub

    Private Sub Txt_TDSPercentage_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_TDSPercentage.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Rdo_WorksContractYes.Focus()
        End If
    End Sub

    Private Sub Rdo_WorksContractYes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_WorksContractYes.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Cbo_WorksContractSection.Focus()
        End If
    End Sub

    Private Sub Rdo_WorksContractNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_WorksContractNo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Rdo_PurchaseTaxNo.Focus()
        End If
    End Sub
    Private Sub Rdo_WorksContractYes_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rdo_WorksContractYes.CheckedChanged
        Cbo_WorksContractSection.Visible = True
        Txt_WorksContractPercentage.Visible = True
        Lbl_WorksContractp.Visible = True
        Lbl_WorksContractSection.Visible = True
        If Cbo_WorksContractSection.Items.Count > 0 Then
            Cbo_WorksContractSection.SelectedIndex = -1
        End If
    End Sub

    Private Sub Rdo_WorksContractNo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rdo_WorksContractNo.CheckedChanged
        Cbo_WorksContractSection.Visible = False
        Txt_WorksContractPercentage.Visible = False
        Lbl_WorksContractp.Visible = False
        Lbl_WorksContractSection.Visible = False
    End Sub
    Private Sub Cbo_WorksContractSection_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_WorksContractSection.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_WorksContractPercentage.Focus()
        End If
    End Sub
    Private Sub Txt_WorksContractPercentage_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_WorksContractPercentage.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Rdo_PurchaseTaxYes.Focus()
        End If
    End Sub

    Private Sub Rdo_PurchaseTaxYes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_PurchaseTaxYes.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Cbo_PurchaseTaxSection.Focus()
        End If
    End Sub

    Private Sub Rdo_PurchaseTaxNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_PurchaseTaxNo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Rdo_ESINo.Focus()
        End If
    End Sub

    Private Sub Rdo_PurchaseTaxNo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rdo_PurchaseTaxNo.CheckedChanged
        Cbo_PurchaseTaxSection.Visible = False
        Txt_PurchaseTaxPercentage.Visible = False
        Lbl_PurchaseTaxp.Visible = False
        Lbl_PurchaseTaxSection.Visible = False
    End Sub

    Private Sub Rdo_PurchaseTaxYes_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rdo_PurchaseTaxYes.CheckedChanged
        Cbo_PurchaseTaxSection.Visible = True
        Txt_PurchaseTaxPercentage.Visible = True
        Lbl_PurchaseTaxp.Visible = True
        Lbl_PurchaseTaxSection.Visible = True
        If Cbo_PurchaseTaxSection.Items.Count > 0 Then
            Cbo_PurchaseTaxSection.SelectedIndex = -1
        End If
    End Sub

    Private Sub Cbo_PurchaseTaxSection_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_PurchaseTaxSection.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_PurchaseTaxPercentage.Focus()
        End If
    End Sub

    Private Sub Txt_PurchaseTaxPercentage_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_PurchaseTaxPercentage.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Rdo_ESIYes.Focus()
        End If
    End Sub

    Private Sub Rdo_ESIYes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_ESIYes.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Cbo_EsiSection.Focus()
        End If
    End Sub

    Private Sub Rdo_ESINo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_ESINo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Rdo_PFNo.Focus()
        End If
    End Sub

    Private Sub Rdo_ESIYes_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rdo_ESIYes.CheckedChanged
        Cbo_EsiSection.Visible = True
        Txt_EsiPercentage.Visible = True
        Lbl_esip.Visible = True
        Lbl_EsiSection.Visible = True
        If Me.Cbo_EsiSection.Items.Count > 0 Then
            Cbo_EsiSection.SelectedIndex = -1
        End If
    End Sub

    Private Sub Rdo_ESINo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rdo_ESINo.CheckedChanged
        Cbo_EsiSection.Visible = False
        Txt_EsiPercentage.Visible = False
        Lbl_esip.Visible = False
        Lbl_EsiSection.Visible = False
    End Sub
    Private Sub Cbo_EsiSection_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_EsiSection.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_EsiPercentage.Focus()
        End If
    End Sub
    Private Sub Txt_EsiPercentage_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_EsiPercentage.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Rdo_PFYes.Focus()
        End If
    End Sub

    Private Sub Rdo_PFYes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_PFYes.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Cbo_PfSection.Focus()
        End If
    End Sub

    Private Sub Rdo_PFNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_PFNo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            'Refer Mk Kannan
            'Modified as on 19 Jul 07
            'Begin
            'Rdo_TaxNo.Focus()
            'End
        End If
    End Sub
    Private Sub Rdo_PFYes_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rdo_PFYes.CheckedChanged
        Cbo_PfSection.Visible = True
        Txt_PfPercentage.Visible = True
        Lbl_Pfp.Visible = True
        Lbl_PfSection.Visible = True
        If Me.Cbo_PfSection.Items.Count > 0 Then
            Cbo_PfSection.SelectedIndex = -1
        End If
    End Sub

    Private Sub Rdo_PFNo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rdo_PFNo.CheckedChanged
        Cbo_PfSection.Visible = False
        Txt_PfPercentage.Visible = False
        Lbl_Pfp.Visible = False
        Lbl_PfSection.Visible = False
    End Sub

    Private Sub Cbo_PfSection_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_PfSection.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_PfPercentage.Focus()
        End If
    End Sub
    Private Sub Txt_PfPercentage_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_PfPercentage.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            'Refer Mk Kannan
            'Modified as on 19 Jul 07
            'Begin
            'Rdo_TaxNo.Focus()
            CmdAdd.Focus()
            'End
        End If
    End Sub

    Private Sub Rdo_TaxYes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            'Refer Mk Kannan
            'Modified as on 19 Jul 07
            'Begin
            'Cbo_TaxSection.Focus()
            'End
        End If
    End Sub

    Private Sub Rdo_TaxNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            CmdAdd.Focus()
        End If
    End Sub

    Private Sub Rdo_TaxYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Refer Mk Kannan
        'Modified as on 19 Jul 07
        'Begin
        'Cbo_TaxSection.Visible = True
        'Txt_TaxPercentage.Visible = True
        'Lbl_Taxp.Visible = True
        'Lbl_TaxSection.Visible = True
        'Cbo_TaxSection.SelectedIndex = 0
        'End
    End Sub

    Private Sub Rdo_TaxNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Refer Mk Kannan
        'Modified as on 19 Jul 07
        'Begin
        'Cbo_TaxSection.Visible = False
        'Txt_TaxPercentage.Visible = False
        'Lbl_Taxp.Visible = False
        'Lbl_TaxSection.Visible = False
        'End
    End Sub

    Private Sub Cbo_TaxSection_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            'Refer Mk Kannan
            'Modified as on 19 Jul 07
            'Begin
            'Txt_TaxPercentage.Focus()
            'End
        End If
    End Sub

    Private Sub Txt_TaxPercentage_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            CmdAdd.Focus()
        End If
    End Sub

    Private Sub Txt_GLAcCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_GLAcCode.Validated
        Dim sqlstring As String
        sqlstring = "select * from accountsglaccountmaster where accode = '" & Trim(Txt_GLAcCode.Text) & "' and subledgerflag = 'Y' AND ISNULL(FREEZEFLAG,'N') <> 'Y'"
        vconn.getDataSet(sqlstring, "accountsglaccountmaster")
        If gdataset.Tables("accountsglaccountmaster").Rows.Count > 0 Then
            Txt_GLAcDesc.Text = Trim(UCase(gdataset.Tables("accountsglaccountmaster").Rows(0).Item("acdesc")))
        Else
            Me.Txt_GLAcCode.Text = ""
        End If
        If UCase(Me.Txt_GLAcCode.Text) = gCreditors Then
            Me.Cmb_SLType.Text = "SUPPLIER"
            Me.Cmb_SLType.Enabled = False
            Me.Txt_SLCode.Focus()
        Else
            Cmb_SLType.Focus()
        End If
    End Sub
    Private Sub Txt_SLCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_SLCode.Validated
        Dim sqlstring As String
        sqlstring = "select isnull(accode,'') as accode,isnull(acdesc,'') as acdesc,isnull(slname,'') as slname,isnull(vatno,'') as vatno,isnull(cstno,'') as cstno,isnull(emailid,'') as emailid,isnull(tinno,'') as tinno,isnull(grnno,'') as grnno,isnull(panno,'') as panno,isnull(creditperiod,0) as creditperiod,isnull(opdebits,0) as opdebits,isnull(opcredits,0) as opcredits,isnull(cldebits,0) as cldebits,isnull(clcredits,0) as clcredits,isnull(Sltype,'') as Sltype,isnull(contactperson,'') as contactperson,isnull(address1,'') as address1,isnull(address2,'') as address2,isnull(address3,'') as address3,isnull(city,'') as city,isnull(state,'') as state,isnull(pin,'') as pin,isnull(phoneno,'') as phoneno,isnull(cellno,'') as cellno,isnull(tdsflag,'') as tdsflag,isnull(tdssection,'') as tdssection,isnull(tdspercentage,0) as tdspercentage,isnull(workscontractflag,'') as workscontractflag,isnull(workscontractsection,'') as workscontractsection,isnull(workscontractpercentage,0) as workscontractpercentage,isnull(purchaseflag,'') as purchaseflag,isnull(purchasesection,'') as purchasesection,isnull(purchasepercentage,0) as purchasepercentage,isnull(esiflag,'') as esiflag,isnull(esisection,'') as esisection,isnull(esipercentage,0) as esipercentage,isnull(pfflag,'') as pfflag,isnull(pfsection,'') as pfsection,isnull(pfpercentage,0) as pfpercentage,isnull(freezeflag,'') as freezeflag"
        '        sqlstring = sqlstring & " from accountssubledgermaster where slcode = '" & Trim(Txt_SLCode.Text) & "' and accode = '" & Trim(Txt_GLAcCode.Text) & "'"
        sqlstring = sqlstring & " ,isnull(GSTINNO,'') as GSTINNO from accountssubledgermaster where slcode = '" & Trim(Txt_SLCode.Text) & "' and sltype = '" & Trim(Cmb_SLType.Text) & "'  order by roll "
        vconn.getDataSet(sqlstring, "accountssubledgermaster")
        If gdataset.Tables("accountssubledgermaster").Rows.Count > 0 Then
            Txt_GLAcCode.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("accode")))
            lbl_ac.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("accode")))
            Txt_GLAcDesc.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("acdesc")))

            Txt_SLName.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("slname")))
            txt_email.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("emailid")))
            Txt_VATNo.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("vatno")))
            Txt_CSTNo.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("cstno")))
            Txt_TINNo.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("tinno")))
            Txt_GRNNo.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("grnno")))
            Txt_PANNo.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("panno")))
            Txt_CreditPeriod.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("creditperiod")))

            If gdataset.Tables("accountssubledgermaster").Rows(0).Item("opdebits") <> 0 Then
                Txt_OpeningBalance.Text = gdataset.Tables("accountssubledgermaster").Rows(0).Item("opdebits")
                Rdo_OpeningBalanceDebit.Checked = True
            Else
                Txt_OpeningBalance.Text = gdataset.Tables("accountssubledgermaster").Rows(0).Item("opcredits")
                Rdo_OpeningBalanceCredit.Checked = True
            End If

            If gdataset.Tables("accountssubledgermaster").Rows(0).Item("cldebits") & "" <> 0 Then
                Txt_BalanceAsOn.Text = gdataset.Tables("accountssubledgermaster").Rows(0).Item("cldebits") & ""
                Rdo_BalanceAsOnDebit.Checked = True
            Else
                Txt_BalanceAsOn.Text = gdataset.Tables("accountssubledgermaster").Rows(0).Item("clcredits") & ""
                Rdo_BalanceAsOnCredit.Checked = True
            End If
            Me.Cmb_SLType.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("Sltype")))
            Txt_ContactPerson.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("contactperson")))
            Txt_Address1.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("address1")))
            Txt_Address2.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("address2")))
            Txt_Address3.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("address3")))
            txt_City.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("city")))
            Txt_State.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("state")))
            Txt_Pin.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("pin")))
            Txt_PhoneNo.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("phoneno")))
            Txt_CellNo.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("cellno")))
            TxtGSTINNO.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("GSTINNO")))

            If gdataset.Tables("accountssubledgermaster").Rows(0).Item("tdsflag") = "Y" Then
                Rdo_TDSYes.Checked = True
                Cbo_TDSSection.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("tdssection")))
                Txt_TDSPercentage.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("tdspercentage")))
            Else
                Rdo_TDSNo.Checked = True
            End If


            If gdataset.Tables("accountssubledgermaster").Rows(0).Item("workscontractflag") = "Y" Then
                Rdo_WorksContractYes.Checked = True
                Cbo_WorksContractSection.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("workscontractsection")))
                Txt_WorksContractPercentage.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("workscontractpercentage")))
            Else
                Rdo_WorksContractNo.Checked = True
            End If


            If gdataset.Tables("accountssubledgermaster").Rows(0).Item("purchaseflag") = "Y" Then
                Rdo_PurchaseTaxYes.Checked = True
                Cbo_PurchaseTaxSection.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("purchasesection")))
                Txt_PurchaseTaxPercentage.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("purchasepercentage")))
            Else
                Rdo_PurchaseTaxNo.Checked = True
            End If


            If gdataset.Tables("accountssubledgermaster").Rows(0).Item("esiflag") = "Y" Then
                Rdo_ESIYes.Checked = True
                Cbo_EsiSection.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("esisection")))
                Txt_EsiPercentage.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("esipercentage")))
            Else
                Rdo_ESINo.Checked = True
            End If

            If gdataset.Tables("accountssubledgermaster").Rows(0).Item("pfflag") = "Y" Then
                Rdo_PFYes.Checked = True
                Cbo_PfSection.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("pfsection")))
                Txt_PfPercentage.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("pfpercentage")))
            Else
                Rdo_PFNo.Checked = True
            End If

            If gdataset.Tables("accountssubledgermaster").Rows(0).Item("freezeflag") = "Y" Then
                Lbl_Freeze.Visible = True
                CmdDelete.Text = "&freeze[F8]"
                Me.CmdAdd.Enabled = False
                Me.CmdDelete.Enabled = True
            Else
                Lbl_Freeze.Visible = False
                CmdDelete.Text = "&Freeze[F8]"
                Me.CmdAdd.Enabled = True
                Me.CmdDelete.Enabled = True
            End If
            Txt_GLAcCode.Enabled = False
            Txt_SLCode.Enabled = False
            Cmb_SLType.Focus()
            If UCase(Me.Txt_GLAcCode.Text) = gDebitors Then
                Me.CmdAdd.Enabled = False
                Me.CmdDelete.Enabled = False
            End If
            CmdAdd.Text = "&Update[F7]"
        Else
            Me.Txt_SLName.Focus()
        End If
    End Sub
    Private Sub CmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAdd.Click
        Dim sqlstring As String
        Dim tdsflag, workscontractflag, purchaseflag, esiflag, pfflag As String
        Dim tdssection, workscontractsection, purchasesection, esisection, pfsection As String
        Dim tdspercentage, workscontractpercentage, purchasepercentage, esipercentage, pfpercentage As Double
        Dim opdebits, opcredits As Double
        Dim cldebits, clcredits As Double
        If Mevalidate() = False Then Exit Sub

        If Rdo_TDSYes.Checked = True Then
            If Trim(Cbo_TDSSection.Text) <> "" Then
                tdsflag = "Y"
                tdssection = Trim(Cbo_TDSSection.Text)
                tdspercentage = Trim(Txt_TDSPercentage.Text)
            End If
        Else
            tdsflag = "N"
            tdssection = ""
            tdspercentage = 0
        End If
        If Rdo_WorksContractYes.Checked = True Then
            If Trim(Cbo_WorksContractSection.Text) <> "" Then
                workscontractflag = "Y"
                workscontractsection = Trim(Cbo_WorksContractSection.Text)
                workscontractpercentage = Trim(Txt_WorksContractPercentage.Text)
            End If
        Else
            workscontractflag = "N"
            workscontractsection = ""
            workscontractpercentage = 0
        End If
        If Rdo_PurchaseTaxYes.Checked = True Then
            If Trim(Cbo_PurchaseTaxSection.Text) <> "" Then
                purchaseflag = "Y"
                purchasesection = Trim(Cbo_PurchaseTaxSection.Text)
                purchasepercentage = Trim(Txt_PurchaseTaxPercentage.Text)
            End If
        Else
            purchaseflag = "N"
            purchasesection = ""
            purchasepercentage = 0
        End If
        If Rdo_ESIYes.Checked = True Then
            If Trim(Cbo_EsiSection.Text) <> "" Then
                esiflag = "Y"
                esisection = Trim(Cbo_EsiSection.Text)
                esipercentage = Trim(Txt_EsiPercentage.Text)
            End If
        Else
            esiflag = "N"
            esisection = ""
            esipercentage = 0
        End If
        If Rdo_PFYes.Checked = True Then
            If Trim(Cbo_PfSection.Text) <> "" Then
                pfflag = "Y"
                pfsection = Trim(Cbo_PfSection.Text)
                pfpercentage = Trim(Txt_PfPercentage.Text)
            End If
        Else
            pfflag = "N"
            pfsection = ""
            pfpercentage = 0
        End If

        If Rdo_OpeningBalanceDebit.Checked = True Then
            opdebits = Format(Val(Txt_OpeningBalance.Text), "0.00")
            opcredits = 0.0
        Else
            opcredits = Format(Val(Txt_OpeningBalance.Text), "0.00")
            opdebits = 0.0
        End If
        If Rdo_BalanceAsOnDebit.Checked = True Then
            cldebits = Format(Val(Txt_BalanceAsOn.Text), "0.00")
            clcredits = 0.0
        Else
            clcredits = Format(Val(Txt_BalanceAsOn.Text), "0.00")
            cldebits = 0.0
        End If

        If CmdAdd.Text = "&Add [F7]" Then
            sqlstring = "INSERT INTO accountssubledgermaster(accode, acdesc, sltype, slcode,slname,Sldesc,contactperson, address1, address2, address3, city, state, pin, phoneno, cellno,emailid, vatno,cstno,tinno,grnno,panno, "
            sqlstring = sqlstring & " creditperiod, opdebits, opcredits, cldebits, clcredits, tdsflag, tdssection,tdspercentage, workscontractflag,workscontractsection, workscontractpercentage,purchaseflag, purchasesection,purchasepercentage,esiflag, esisection, esipercentage,pfflag, pfsection,pfpercentage,"
            sqlstring = sqlstring & " adduserid, adddatetime, updateuserid, updatedatetime, "
            sqlstring = sqlstring & " freezeflag, "
            sqlstring = sqlstring & " freezeuserid, freezedatetime ,GSTINNO) "
            sqlstring = sqlstring & " values ('" & Trim(Txt_GLAcCode.Text) & "' , '" & Trim(Txt_GLAcDesc.Text) & "' , '" & Trim(Cmb_SLType.Text) & "' , '"
            sqlstring = sqlstring & Trim(Txt_SLCode.Text) & "' , '" & Trim(Txt_SLName.Text) & "' , '" & Trim(Txt_SLName.Text) & "' , '" & Trim(Txt_ContactPerson.Text) & "' , '"
            sqlstring = sqlstring & Trim(Txt_Address1.Text) & "' , '" & Trim(Txt_Address2.Text) & "' , '" & Trim(Txt_Address3.Text) & "' , '"
            sqlstring = sqlstring & Trim(txt_City.Text) & "' , '" & Trim(Txt_State.Text) & "' , " & Val(Txt_Pin.Text) & ", "

            sqlstring = sqlstring & Val(Txt_PhoneNo.Text) & "," & Val(Txt_CellNo.Text) & ", '" & Trim(txt_email.Text) & "' , '" & Trim(Txt_VATNo.Text) & "' , '"
            sqlstring = sqlstring & Trim(Txt_CSTNo.Text) & "' , '" & Trim(Txt_TINNo.Text) & "' , '" & Trim(Txt_GRNNo.Text) & "' , '"
            sqlstring = sqlstring & Trim(Txt_PANNo.Text) & "' ,"
            sqlstring = sqlstring & Trim(Txt_CreditPeriod.Text) & " , "

            sqlstring = sqlstring & opdebits & " , " & opcredits & " , " & cldebits & " , " & clcredits & " , '"

            sqlstring = sqlstring & tdsflag & "' , '" & tdssection & "' , " & tdspercentage & " , '"
            sqlstring = sqlstring & workscontractflag & "' , '" & workscontractsection & "' ," & workscontractpercentage & ", '"
            sqlstring = sqlstring & purchaseflag & "' , '" & purchasesection & "' ," & purchasepercentage & ", '"
            sqlstring = sqlstring & esiflag & "' , '" & esisection & "' ," & esipercentage & ", '"
            sqlstring = sqlstring & pfflag & "' , '" & pfsection & "' ," & pfpercentage & ", '"
            sqlstring = sqlstring & gUsername & "' , '" & Format(DateValue(Now), "dd/MMM/yyyy") & "' , '' , '', "
            sqlstring = sqlstring & "'N' , '' , '','" & Trim(TxtGSTINNO.Text) & "' )"
            vconn.dataOperation(1, sqlstring)
        Else
            sqlstring = "update accountssubledgermaster set "
            sqlstring = sqlstring & " slname='" & Trim(Txt_SLName.Text) & "',sldesc='" & Trim(Txt_SLName.Text) & "',"
            sqlstring = sqlstring & " vatno= '" & Trim(Txt_VATNo.Text) & "', cstno='" & Trim(Txt_CSTNo.Text) & "', emailid='" & Trim(txt_email.Text) & "', tinno='" & Trim(Txt_TINNo.Text) & "',"
            sqlstring = sqlstring & " grnno= '" & Trim(Txt_GRNNo.Text) & "', panno='" & Trim(Txt_PANNo.Text) & "',"
            sqlstring = sqlstring & " creditperiod= " & Trim(Txt_CreditPeriod.Text) & ","

            sqlstring = sqlstring & "opdebits = " & opdebits & ", opcredits= " & opcredits & ","

            sqlstring = sqlstring & " contactperson= '" & Trim(Txt_ContactPerson.Text) & "', address1='" & Trim(Txt_Address1.Text) & "', address2='" & Trim(Txt_Address2.Text) & "',"
            sqlstring = sqlstring & " address3= '" & Trim(Txt_Address3.Text) & "', city='" & Trim(txt_City.Text) & "', state='" & Trim(Txt_State.Text) & "',"
            sqlstring = sqlstring & " pin= " & Val(Txt_Pin.Text) & ", phoneno=" & Val(Txt_PhoneNo.Text) & ", cellno=" & Val(Txt_CellNo.Text) & ","

            sqlstring = sqlstring & "tdsflag = '" & tdsflag & "', tdssection = '" & tdssection & "', tdspercentage = " & tdspercentage & ","
            sqlstring = sqlstring & "workscontractflag = '" & workscontractflag & "', workscontractsection = '" & workscontractsection & "', workscontractpercentage = " & workscontractpercentage & ","
            sqlstring = sqlstring & "purchaseflag = '" & purchaseflag & "', purchasesection = '" & purchasesection & "', purchasepercentage = " & purchasepercentage & ","
            sqlstring = sqlstring & "esiflag = '" & esiflag & "', esisection = '" & esisection & "', esipercentage = " & esipercentage & ","
            sqlstring = sqlstring & "pfflag = '" & pfflag & "', pfsection = '" & pfsection & "', pfpercentage = " & pfpercentage & ","

            sqlstring = sqlstring & "adduserid ='',adddatetime ='', updateuserid ='" & gUsername & "', updatedatetime = '" & Format(DateValue(Now), "dd/MMM/yyyy") & "'"
            sqlstring = sqlstring & ", freezeflag = 'N', freezeuserid = '', freezedatetime = '', accode='" & Trim(Txt_GLAcCode.Text) & "', acdesc='" & Trim(Txt_GLAcDesc.Text) & "',GSTINNO='" & Trim(TxtGSTINNO.Text) & "' "
            sqlstring = sqlstring & " where  Slcode='" & Trim(Txt_SLCode.Text) & "' and accode='" & Trim(Txt_GLAcCode.Text) & "'"
            vconn.dataOperation(2, sqlstring)
        End If
        Call CmdClear_Click(sender, e)
        Txt_GLAcCode.Enabled = True
        Txt_GLAcCode.Focus()
    End Sub
    Private Function Mevalidate() As Boolean
        Dim strMessage As String = ""
        Dim regex As Regex = New Regex("([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\." +
                                       ")|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})",
                                       RegexOptions.IgnoreCase _
                                       Or RegexOptions.CultureInvariant _
                                       Or RegexOptions.IgnorePatternWhitespace _
                                       Or RegexOptions.Compiled
                                       )
        Dim IsMatch As Boolean = regex.IsMatch(txt_email.Text)
        If IsMatch Then
            If txt_email.Text.Equals(regex.Match(txt_email.Text).ToString) Then
                strMessage = "Valid email address"
            Else
                strMessage = "There's an email address in there somewhere.  But not exactly"
            End If
        Else
            strMessage = "Sorry.  Invalid email address format."
        End If
        MessageBox.Show(strMessage)
        Mevalidate = True

        If gShortname = "CCFC" Then
            If Trim(Txt_GLAcCode.Text) = "" Then
                Mevalidate = False
                MsgBox("accode cannot be blank", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Txt_GLAcCode.Focus()
                Exit Function
            End If
        End If
       
        If CmdAdd.Text = "&Add [F7]" Then

            sqlstring = "select * from accountssubledgermaster where SLNAME='" & Trim(Txt_SLName.Text) & "' and isnull(freezeflag,'N')<>'Y'"
            gconnection.getDataSet(sqlstring, "inv1")
            If gdataset.Tables("inv1").Rows.Count > 0 Then
                MessageBox.Show(" Supplier name already used .", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_SLName.Text = ""
                Txt_SLName.Focus()
                Exit Function
            End If

        End If
        

        If Trim(Txt_SLCode.Text) = "" Then
            Mevalidate = False
            MsgBox("Sl Code cannot be blank", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Txt_SLCode.Focus()
            Exit Function
        End If
        If Trim(Txt_SLName.Text) = "" Then
            Mevalidate = False
            MsgBox("Sl Name cannot be blank", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Txt_SLName.Focus()
            Exit Function
        End If

        If UCase(Me.Txt_GLAcCode.Text) = gDebitors Then
            Mevalidate = False
            MsgBox("Sundry Debtors Can Not Be Added Through Sub Ledger,Pls Make Through MemberMaster", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Function
        End If
        If Trim(txt_email.Text) <> "" Then
            getEmail(txt_email)
            If boolexp1 = False Then
                Mevalidate = False
                Exit Function
            End If

        End If

        If CmdAdd.Text = "&Add [F7]" Then

        Else
            'sqlstring = "select isnull(Suppliercode,'') as Suppliercode from GRN_HEADER where Suppliercode='" & Trim(Txt_SLCode.Text) & "' and isnull(void,'N')<>'Y'"
            'gconnection.getDataSet(sqlstring, "inv1")
            'If gdataset.Tables("inv1").Rows.Count > 0 Then
            '    MessageBox.Show(" Supplier already used in transaction u can't be update ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Txt_SLCode.Text = ""
            '    Txt_SLCode.Focus()
            '    Exit Function
            'End If
        End If



    End Function

    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        sqlstring = "  Select isnull(MSupplier,'N') as MSupplier from inv_linksetup"
        gconnection.getDataSet(sqlstring, "inv_linksetup")

        If (gdataset.Tables("inv_linksetup").Rows.Count > 0) Then
            If (gdataset.Tables("inv_linksetup").Rows(0).Item("MSupplier").ToString() = "Y") Then
                Txt_GLAcCode.Text = ""
                Txt_GLAcDesc.Text = ""
                Txt_GLAcCode.ReadOnly = False
                Txt_GLAcDesc.ReadOnly = False
                Cmd_GLAcCodeHelp.Enabled = True
            Else
                Txt_GLAcCode.Text = "SCRS"
                Txt_GLAcDesc.Text = "SUNDRY CREDITORS"
                Txt_GLAcCode.ReadOnly = True
                Txt_GLAcDesc.ReadOnly = True
                Cmd_GLAcCodeHelp.Enabled = False


            End If

        End If
        Call GetLastNo()
        'Cmb_SLType.SelectedIndex = 0
        Txt_SLCode.Text = ""
        Txt_SLName.Text = ""
        Txt_VATNo.Text = ""
        Txt_CSTNo.Text = ""
        Txt_TINNo.Text = ""
        Txt_GRNNo.Text = ""
        Txt_PANNo.Text = ""
        txt_email.Text = ""
        Txt_CreditPeriod.Text = 0
        Txt_OpeningBalance.Text = 0
        Txt_BalanceAsOn.Text = 0
        Rdo_OpeningBalanceDebit.Checked = True
        Rdo_BalanceAsOnDebit.Checked = True
        Txt_ContactPerson.Text = ""
        Txt_Address1.Text = ""
        Txt_Address2.Text = ""
        Txt_Address3.Text = ""
        txt_City.Text = ""
        Txt_State.Text = ""
        Txt_Pin.Text = ""
        Txt_PhoneNo.Text = ""
        Txt_CellNo.Text = ""
        Rdo_TDSNo.Checked = True
        Txt_TDSPercentage.Text = ""
        Rdo_WorksContractNo.Checked = True
        Txt_WorksContractPercentage.Text = ""
        Rdo_PurchaseTaxNo.Checked = True
        Txt_PurchaseTaxPercentage.Text = ""
        Rdo_ESINo.Checked = True
        Txt_EsiPercentage.Text = ""
        Rdo_PFNo.Checked = True
        Txt_PfPercentage.Text = ""
        Lbl_Freeze.Visible = False
        'Txt_GLAcCode.Enabled = True
        Me.Txt_SLCode.Enabled = True
        'Txt_GLAcCode.Focus()
        Me.Cmb_SLType.Enabled = True
        Me.CmdAdd.Text = "&Add [F7]"
        Me.CmdDelete.Enabled = False
        Me.CmdAdd.Enabled = True
        Cmb_SLType.Focus()
        If gValidity = False Then
            Me.CmdAdd.Enabled = False
            Me.cmd_auth.Enabled = False
            Me.CmdDelete.Enabled = False
        End If
    End Sub

    Private Sub CmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDelete.Click
        Dim status As Integer
        Dim sqlstring As String
        If CmdDelete.Text = "&Freeze[F8]" Then
            If UCase(Me.Txt_GLAcCode.Text) = gDebitors Then
                MsgBox("Sundry Debtors Can Not Be Added Through Sub Ledger", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If
            status = MsgBox("ARE U SURE U WANT TO FREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            If status = 1 Then
                sqlstring = "update accountssubledgermaster set freezeflag = 'Y',FreezeUserId='" & gUsername & "',FreezeDateTime='" & Format(DateValue(Now), "dd/MMM/yyyy") & "' where accode = '" & Trim(Txt_GLAcCode.Text) & "' And Slcode='" & Trim(Me.Txt_SLCode.Text) & "'"
                vconn.dataOperation(2, sqlstring)
                Lbl_Freeze.Text = "RECORD FREEZED"
                Lbl_Freeze.Visible = True
                CmdDelete.Text = "&Unfreeze[F8]"
                CmdAdd.Enabled = False
            Else
                Exit Sub
            End If
        Else
            status = MsgBox("ARE U SURE U WANT TO UNFREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            If status = 1 Then
                sqlstring = "update accountssubledgermaster set freezeflag = 'N',FreezeUserId='',FreezeDateTime='' where accode = '" & Trim(Txt_GLAcCode.Text) & "' And Slcode='" & Trim(Me.Txt_SLCode.Text) & "'"
                vconn.dataOperation(2, sqlstring)
                Lbl_Freeze.Text = "RECORD UNFREEZED"
                Lbl_Freeze.Visible = False
                CmdDelete.Text = "&Freeze[F8]"
            Else
                Exit Sub
            End If
        End If

    End Sub

    Private Sub CmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView.Click
        Dim FRM As New ReportDesigner
        If Txt_SLCode.Text.Length > 0 Then
            tables = " FROM accountssubledgermaster WHERE slcode ='" & Txt_SLCode.Text & "' AND ACCODE='" + Txt_GLAcCode.Text + "'"
        Else
            tables = "FROM accountssubledgermaster WHERE ACCODE='" + Txt_GLAcCode.Text + "'"
        End If
        Gheader = "SUBLEDGER DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"accode", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"acdesc", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"slcode", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"sldesc", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"sldesc", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"VOID", "4"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"adduserid", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"adddatetime", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"updateuserid", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"updatedatetime", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        Dim CHK As New DataGridViewCheckBoxColumn()
        FRM.DataGridView1.Columns.Insert(0, CHK)
        CHK.HeaderText = "CHECK"
        CHK.Name = "CHK"
        FRM.ShowDialog(Me)

    End Sub

    Private Sub Cmd_GLAcCodeHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_GLAcCodeHelp.Click
        Dim vform As New ListOperattion1
        gSQLString = "SELECT accode,acdesc FROM accountsglaccountmaster"
        M_WhereCondition = " where subledgerflag= 'Y' AND ISNULL(FREEZEFLAG,'N') <> 'Y' "
        vform.Field = "accode,acdesc"
        vform.vFormatstring = "  GENERAL LEDGER CODE  | GENERAL LEDGER DESCRIPTION                                        "
        vform.vCaption = "GENERAL LEDGER MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Txt_GLAcCode.Text = Trim(vform.keyfield & "")
            Txt_GLAcDesc.Text = Trim(vform.keyfield1 & "")
            Cmb_SLType.Focus()
            If UCase(Me.Txt_GLAcCode.Text) = gCreditors Then
                Me.Cmb_SLType.Text = "SUPPLIER"
                Me.Cmb_SLType.Enabled = False
            End If
        Else
            Me.Txt_GLAcCode.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub

      Private Sub Txt_GLAcCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_GLAcCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            Call Cmd_GLAcCodeHelp_Click(Txt_GLAcCode, e)
            Exit Sub
        End If
    End Sub

    Private Sub Txt_SLCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_SLCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            Call Cmd_SLCodeHelp_Click(Txt_SLCode, e)
            Exit Sub
        End If
    End Sub

    Private Sub SUBLEDGERMASTER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 And CmdClear.Visible Then
            Call Me.CmdClear_Click(sender, e)
        End If
        If e.KeyCode = Keys.F7 And CmdAdd.Visible And CmdAdd.Visible = True Then
            Call Me.CmdAdd_Click(sender, e)
        End If
        If e.KeyCode = Keys.F1 And cmdcrystal.Visible And cmdcrystal.Visible = True Then
            Call Me.cmdcrystal_Click(sender, e)
        End If
        If e.KeyCode = Keys.F12 And cmdexport.Visible And cmdexport.Visible = True Then
            Call Me.cmdexport_Click(sender, e)
        End If
        If (e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape) And cmdexit.Visible Then
            Call Me.cmdexit_Click(sender, e)
        End If
        If e.KeyCode = Keys.F9 And CmdView.Visible And CmdView.Visible = True Then
            Call Me.CmdView_Click(sender, e)
        End If
        If e.KeyCode = Keys.F8 And CmdDelete.Visible And CmdDelete.Visible = True Then
            Call Me.CmdDelete_Click(sender, e)
        End If
    End Sub
    Private Sub Cbo_TDSSection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_TDSSection.SelectedIndexChanged
        Dim i As Integer
        Dim ssql As String
        ssql = "Select SectionType from  accountstdsmaster where tdscode = '" & Trim(Cbo_TDSSection.Text & "") & "'"
        vconn.getDataSet(ssql, "TDSection")
        Me.CBO_TDSECTION.Items.Clear()
        If gdataset.Tables("TDSection").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("TDSection").Rows.Count - 1
                Me.CBO_TDSECTION.Items.Add(gdataset.Tables("TDSection").Rows(i).Item("SectionType"))
            Next i
        End If
        CBO_TDSECTION.Focus()

    End Sub

    Private Sub Cbo_WorksContractSection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_WorksContractSection.SelectedIndexChanged
        Dim ssql As String
        If Trim(Me.Cbo_WorksContractSection.Text) <> "" Then
            ssql = "select WorksContractCode,Percentage from AccountsWorksContractMaster Where WorksContractCode='" & Me.Cbo_WorksContractSection.Text & "'"
            vconn.getDataSet(ssql, "WORKS")
            If gdataset.Tables("WORKS").Rows.Count > 0 Then
                Me.Txt_WorksContractPercentage.Text = Format(gdataset.Tables("WORKS").Rows(0).Item(1), "0.000")
            End If
        End If
    End Sub

    Private Sub Cbo_PurchaseTaxSection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_PurchaseTaxSection.SelectedIndexChanged
        Dim ssql As String
        If Trim(Me.Cbo_PurchaseTaxSection.Text) <> "" Then
            ssql = "select purchasecode,Percentage from Accountspurchasetaxmaster Where purchasecode='" & Me.Cbo_PurchaseTaxSection.Text & "'"
            vconn.getDataSet(ssql, "PUR")
            If gdataset.Tables("PUR").Rows.Count > 0 Then
                Me.Txt_PurchaseTaxPercentage.Text = Format(gdataset.Tables("PUR").Rows(0).Item(1), "0.000")
            End If
        End If
    End Sub

    Private Sub Cbo_EsiSection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_EsiSection.SelectedIndexChanged
        Dim ssql As String
        If Trim(Me.Cbo_EsiSection.Text) <> "" Then
            ssql = "select esicode,sectionPercentage from Accountsesimaster Where esicode='" & Me.Cbo_EsiSection.Text & "'"
            vconn.getDataSet(ssql, "ESI")
            If gdataset.Tables("ESI").Rows.Count > 0 Then
                Me.Txt_EsiPercentage.Text = Format(gdataset.Tables("ESI").Rows(0).Item(1), "0.000")
            End If
        End If
    End Sub

    Private Sub Cbo_PfSection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_PfSection.SelectedIndexChanged
        Dim ssql As String
        If Trim(Me.Cbo_PfSection.Text) <> "" Then
            ssql = "select esicode,sectionPercentage from Accountsesimaster Where esicode='" & Me.Cbo_EsiSection.Text & "'"
            vconn.getDataSet(ssql, "ESI")
            If gdataset.Tables("ESI").Rows.Count > 0 Then
                Me.Txt_EsiPercentage.Text = Format(gdataset.Tables("ESI").Rows(0).Item(1), "0.000")
            End If
        End If
    End Sub

    Private Sub CBO_TDSECTION_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBO_TDSECTION.SelectedIndexChanged
        Dim ssql As String
        If Trim(Me.Cbo_TDSSection.Text) <> "" Then
            ssql = "Select TdsCode,Percentage from accountsTdsMAster Where TdsCode='" & Me.Cbo_TDSSection.Text & "' and sectiontype = '" & CBO_TDSECTION.Text & "'"
            vconn.getDataSet(ssql, "TDS")
            If gdataset.Tables("TDS").Rows.Count > 0 Then
                Me.Txt_TDSPercentage.Text = Format(gdataset.Tables("TDS").Rows(0).Item(1), "0.000")
            End If
        End If
    End Sub

    Private Sub CBO_TDSECTION_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBO_TDSECTION.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_TDSPercentage.Focus()
        End If
    End Sub

    Private Sub txt_City_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_City.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_State.Focus()
        End If
    End Sub

    Private Sub Txt_SLCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_SLCode.TextChanged

    End Sub

    Private Sub Cmb_SLType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_SLType.SelectedIndexChanged
        'If Cmb_SLType.Text <> "SUPPLIER" Then
        '    Label19.Visible = False
        '    Txt_CreditPeriod.Visible = False
        '    Label23.Visible = False
        '    Label14.Visible = False
        '    GroupBox6.Visible = False
        '    lbl_TdSection.Visible = False
        '    CBO_TDSECTION.Visible = False
        '    Cbo_TDSSection.Visible = False
        '    lbl_TDSSection.Visible = False
        '    Lbl_tdsp.Visible = False
        '    Txt_TDSPercentage.Visible = False
        'Else
        '    Label19.Visible = True
        '    Txt_CreditPeriod.Visible = True
        '    Label23.Visible = True
        '    Label14.Visible = True
        '    GroupBox6.Visible = True
        '    lbl_TdSection.Visible = True
        '    CBO_TDSECTION.Visible = True

        '    Cbo_TDSSection.Visible = True
        '    lbl_TDSSection.Visible = True
        '    Lbl_tdsp.Visible = True
        '    Txt_TDSPercentage.Visible = True

        'End If
    End Sub

    Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
        Try
            Dim sqlstring As String
            Dim _export As New EXPORT
            _export.TABLENAME = "AccountssubledgerMaster"
            sqlstring = "SELECT * FROM AccountssubledgerMaster order by Accode,slcode"
            Call _export.export_excel(sqlstring)
            _export.Show()
            Exit Sub
        Catch ex As Exception
            MsgBox("Sorry!, Export to Excel is Terminated Abnormally, Bcoz " & ex.Message.ToString(), MsgBoxStyle.OKOnly, "Error!")
        End Try

    End Sub
    Private Sub print_windows()
        Dim str As String
        Dim Viewer As New Viewer
        Dim r As New Rpt_AccountsSubLedgerMaster

        str = "SELECT * FROM ACCOUNTSSUBLEDGERMASTER WHERE sltype ='supplier'  order by sldesc  "
        If chk_excel.Checked = True Then
            Dim exp As New exportexcel
            exp.Show()
            Call exp.export(str, "VENDOR MASTER ", "")
        Else
            Viewer.ssql = str
            Viewer.Report = r
            Viewer.TableName = "ACCOUNTSSUBLEDGERMASTER"

            Dim TXTOBJ11 As TextObject
            TXTOBJ11 = r.ReportDefinition.ReportObjects("TEXT11")
            TXTOBJ11.Text = gCompanyname

            Dim TXTOBJ16 As TextObject
            TXTOBJ16 = r.ReportDefinition.ReportObjects("TEXT16")
            TXTOBJ16.Text = "User Name : " & gUsername

            'Dim TXTOBJ14 As TextObject
            'TXTOBJ14 = r.ReportDefinition.ReportObjects("TEXT14")
            'TXTOBJ14.Text = "Accounting Period : " & Format(gFinancialyearStart, "dd-MM-yyyy") & " - " & Format(gFinancialyearEnding, "dd-MM-yyyy")
            'Dim t1 As TextObject
            't1 = r.ReportDefinition.ReportObjects("Text17")
            't1.Text = gCompanyAddress(0)
            'Dim t2 As TextObject
            't2 = r.ReportDefinition.ReportObjects("Text18")
            't2.Text = gCompanyAddress(1)
            Viewer.Show()
        End If

    End Sub


    Private Sub cmdcrystal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcrystal.Click
        print_windows()
    End Sub

    Private Sub Txt_SLName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_SLName.TextChanged

    End Sub

    Private Sub Txt_CellNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_CellNo.TextChanged

    End Sub

    Private Sub Txt_Address1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Address1.TextChanged

    End Sub

    Private Sub Txt_ContactPerson_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_ContactPerson.TextChanged

    End Sub

    Private Sub btn_validation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        System.Diagnostics.Process.Start(AppPath & "/STUDY/VENDORCREATION.XLS")
    End Sub

    Private Sub Label27_Click(sender As Object, e As EventArgs) Handles Label27.Click

    End Sub

    Private Sub Label28_Click(sender As Object, e As EventArgs) Handles Label28.Click

    End Sub

    Private Sub Txt_PhoneNo_TextChanged(sender As Object, e As EventArgs) Handles Txt_PhoneNo.TextChanged

    End Sub

    Private Sub Txt_Pin_TextChanged(sender As Object, e As EventArgs) Handles Txt_Pin.TextChanged

    End Sub

    Private Sub Label26_Click(sender As Object, e As EventArgs) Handles Label26.Click

    End Sub

    Private Sub Label25_Click(sender As Object, e As EventArgs) Handles Label25.Click

    End Sub

    Private Sub Txt_State_TextChanged(sender As Object, e As EventArgs) Handles Txt_State.TextChanged

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label24_Click(sender As Object, e As EventArgs) Handles Label24.Click

    End Sub

    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click

    End Sub

    Private Sub Txt_Address3_TextChanged(sender As Object, e As EventArgs) Handles Txt_Address3.TextChanged

    End Sub

    Private Sub Txt_Address2_TextChanged(sender As Object, e As EventArgs) Handles Txt_Address2.TextChanged

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub txt_City_TextChanged(sender As Object, e As EventArgs) Handles txt_City.TextChanged

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub Txt_OpeningBalance_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_OpeningBalance.TextChanged

    End Sub

    Private Sub cmd_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_export.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "Accountssubledgermaster"
        sqlstring = "select ISNULL(accode,'') AS accode ,ISNULL(acdesc,'') AS acdesc,	ISNULL(slcode,'') AS slcode,	ISNULL(slname,'') AS slname,	ISNULL(sldesc,'') AS SLDESC	,ISNULL(contactperson,'') AS 	contactperson,ISNULL(address1,'') AS ADDRESS1,	ISNULL(address2,'') AS ADDRESS2,	ISNULL(address3,'') AS ADDRESS3,	ISNULL(city,'') AS CITY,	ISNULL(state,'')AS STATE,	ISNULL(pin,'') AS PIN,	ISNULL(phoneno,'') AS PHONENO,	ISNULL(cellno,'') AS CELLNO	,ISNULL(vatno,'') AS VATNO,	ISNULL(cstno,'')AS cstno,	ISNULL(tinno,'') AS TINNO,isnull(freezeflag,'')as freezeflag from accountssubledgermaster where accode IN (SELECT ScrsCode FROM ACCOUNTSSETUP)"
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub
    End Sub

    Private Sub cmd_auth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_auth.Click
        Authocheck("INVENTORY", "VENDOR CREATION", gUsername, "accountssubledgermaster", "SLCODE", Me)

    End Sub

    Private Sub txt_email_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_email.KeyPress
        '  getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            getEmail(txt_email)
            'Rdo_TDSYes.Focus()
            'Txt_TINNo.Focus()
            CmdAdd.Focus()
        End If
    End Sub

    Private Sub txt_email_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txt_email_Validated(sender As Object, e As EventArgs) Handles txt_email.Validated
        'getEmail(txt_email)
    End Sub

    Private Sub GroupBox13_Enter(sender As Object, e As EventArgs) Handles GroupBox13.Enter

    End Sub

   


    Private Sub Cmd_SLCodeHelp_Click(sender As Object, e As EventArgs) Handles Cmd_SLCodeHelp.Click
        Dim vform As New ListOperattion1
        gSQLString = "SELECT distinct slcode,Slname FROM accountssubledgermaster "
        'M_WhereCondition = " Where Accode='" & Trim(Me.Txt_GLAcCode.Text) & "'"
        M_WhereCondition = " Where sltype='" & Trim(Me.Cmb_SLType.Text) & "'"
        vform.Field = "slcode,slname"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.vFormatstring = "  SUB LEDGER CODE       |SUB LEDGER NAME                                            |"
        vform.vCaption = "SUB LEDGER MASTER HELP"
        vform.KeyPos = 0
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Txt_SLCode.Text = Trim(vform.keyfield & "")
            Call Txt_SLCode_Validated(sender, e)
            Txt_SLName.Focus()
        Else
            Me.Txt_SLCode.Focus()
        End If
        vform.Close()
        vform = Nothing

    End Sub
End Class
