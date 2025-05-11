<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_mkga_countrymaster_New_UI
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_code = New System.Windows.Forms.TextBox()
        Me.txt_desc = New System.Windows.Forms.TextBox()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.btn_authorize = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.browse = New System.Windows.Forms.Button()
        Me.btn_add = New System.Windows.Forms.Button()
        Me.btn_exit = New System.Windows.Forms.Button()
        Me.btn_freeze = New System.Windows.Forms.Button()
        Me.btn_view = New System.Windows.Forms.Button()
        Me.btn_clear = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Gr2 = New System.Windows.Forms.GroupBox()
        Me.cmd_exit1 = New System.Windows.Forms.Button()
        Me.CMD_WINDOWS = New System.Windows.Forms.Button()
        Me.CMD_DOS = New System.Windows.Forms.Button()
        Me.Btn_help = New System.Windows.Forms.Button()
        Me.LBL_COMPANYNAME = New System.Windows.Forms.Label()
        Me.Label220 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnl_text = New System.Windows.Forms.Panel()
        Me.pnl_main = New System.Windows.Forms.Panel()
        Me.pnl_ctrl = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Gr2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_text.SuspendLayout()
        Me.pnl_main.SuspendLayout()
        Me.pnl_ctrl.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Stencil", 14.25!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(94, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(172, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "COUNTRY MASTER"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(27, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Country Code"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(27, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Country Name"
        '
        'txt_code
        '
        Me.txt_code.BackColor = System.Drawing.Color.LightSteelBlue
        Me.txt_code.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_code.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_code.Location = New System.Drawing.Point(126, 14)
        Me.txt_code.MaxLength = 5
        Me.txt_code.Name = "txt_code"
        Me.txt_code.Size = New System.Drawing.Size(169, 14)
        Me.txt_code.TabIndex = 1
        '
        'txt_desc
        '
        Me.txt_desc.BackColor = System.Drawing.Color.LightSteelBlue
        Me.txt_desc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_desc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_desc.Location = New System.Drawing.Point(126, 52)
        Me.txt_desc.MaxLength = 50
        Me.txt_desc.Name = "txt_desc"
        Me.txt_desc.Size = New System.Drawing.Size(169, 14)
        Me.txt_desc.TabIndex = 3
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(509, 67)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(135, 19)
        Me.lbl_Freeze.TabIndex = 5
        Me.lbl_Freeze.Text = " Record Voided On"
        Me.lbl_Freeze.Visible = False
        '
        'btn_authorize
        '
        Me.btn_authorize.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_authorize.ForeColor = System.Drawing.Color.Black
        Me.btn_authorize.Location = New System.Drawing.Point(-25, 20)
        Me.btn_authorize.Name = "btn_authorize"
        Me.btn_authorize.Size = New System.Drawing.Size(137, 50)
        Me.btn_authorize.TabIndex = 11
        Me.btn_authorize.Text = "Authorize"
        Me.btn_authorize.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_authorize.UseVisualStyleBackColor = True
        Me.btn_authorize.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.browse)
        Me.Panel1.Controls.Add(Me.btn_add)
        Me.Panel1.Controls.Add(Me.btn_exit)
        Me.Panel1.Controls.Add(Me.btn_freeze)
        Me.Panel1.Controls.Add(Me.btn_view)
        Me.Panel1.Controls.Add(Me.btn_clear)
        Me.Panel1.Location = New System.Drawing.Point(1009, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(148, 339)
        Me.Panel1.TabIndex = 23
        Me.Panel1.Visible = False
        '
        'browse
        '
        Me.browse.Font = New System.Drawing.Font("Stencil", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.browse.ForeColor = System.Drawing.Color.Black
        Me.browse.Image = Global.Inventory.My.Resources.Resources.excel
        Me.browse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.browse.Location = New System.Drawing.Point(6, 284)
        Me.browse.Name = "browse"
        Me.browse.Size = New System.Drawing.Size(130, 55)
        Me.browse.TabIndex = 10
        Me.browse.Text = "            Browse [F12]"
        Me.browse.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.browse.UseVisualStyleBackColor = True
        '
        'btn_add
        '
        Me.btn_add.Font = New System.Drawing.Font("Stencil", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_add.ForeColor = System.Drawing.Color.Black
        Me.btn_add.Image = Global.Inventory.My.Resources.Resources.save
        Me.btn_add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_add.Location = New System.Drawing.Point(6, 63)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(130, 55)
        Me.btn_add.TabIndex = 5
        Me.btn_add.Text = "Add [F7]"
        Me.btn_add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_add.UseVisualStyleBackColor = True
        '
        'btn_exit
        '
        Me.btn_exit.Font = New System.Drawing.Font("Stencil", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exit.ForeColor = System.Drawing.Color.Black
        Me.btn_exit.Image = Global.Inventory.My.Resources.Resources._Exit
        Me.btn_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_exit.Location = New System.Drawing.Point(6, 228)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(130, 55)
        Me.btn_exit.TabIndex = 9
        Me.btn_exit.Text = "Exit [F11]"
        Me.btn_exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_exit.UseVisualStyleBackColor = True
        '
        'btn_freeze
        '
        Me.btn_freeze.Font = New System.Drawing.Font("Stencil", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_freeze.ForeColor = System.Drawing.Color.Black
        Me.btn_freeze.Image = Global.Inventory.My.Resources.Resources.Delete
        Me.btn_freeze.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btn_freeze.Location = New System.Drawing.Point(6, 118)
        Me.btn_freeze.Name = "btn_freeze"
        Me.btn_freeze.Size = New System.Drawing.Size(130, 55)
        Me.btn_freeze.TabIndex = 7
        Me.btn_freeze.Text = "Void [F8]"
        Me.btn_freeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_freeze.UseVisualStyleBackColor = True
        '
        'btn_view
        '
        Me.btn_view.Font = New System.Drawing.Font("Stencil", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_view.ForeColor = System.Drawing.Color.Black
        Me.btn_view.Image = Global.Inventory.My.Resources.Resources.view
        Me.btn_view.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btn_view.Location = New System.Drawing.Point(6, 173)
        Me.btn_view.Name = "btn_view"
        Me.btn_view.Size = New System.Drawing.Size(130, 55)
        Me.btn_view.TabIndex = 8
        Me.btn_view.Text = "View [F9]"
        Me.btn_view.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_view.UseVisualStyleBackColor = True
        '
        'btn_clear
        '
        Me.btn_clear.BackColor = System.Drawing.Color.Transparent
        Me.btn_clear.Font = New System.Drawing.Font("Stencil", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_clear.ForeColor = System.Drawing.Color.Black
        Me.btn_clear.Image = Global.Inventory.My.Resources.Resources.Clear
        Me.btn_clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_clear.Location = New System.Drawing.Point(6, 8)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(130, 55)
        Me.btn_clear.TabIndex = 6
        Me.btn_clear.Tag = ""
        Me.btn_clear.Text = "Clear [F6]"
        Me.btn_clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_clear.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(10, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(12, 15)
        Me.Label9.TabIndex = 932
        Me.Label9.Text = "*"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(10, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 15)
        Me.Label6.TabIndex = 933
        Me.Label6.Text = "*"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(639, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 15)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Press [F4] For Help"
        '
        'Gr2
        '
        Me.Gr2.BackColor = System.Drawing.Color.Transparent
        Me.Gr2.Controls.Add(Me.cmd_exit1)
        Me.Gr2.Controls.Add(Me.CMD_WINDOWS)
        Me.Gr2.Controls.Add(Me.CMD_DOS)
        Me.Gr2.Controls.Add(Me.Btn_help)
        Me.Gr2.Location = New System.Drawing.Point(6, 15)
        Me.Gr2.Name = "Gr2"
        Me.Gr2.Size = New System.Drawing.Size(417, 84)
        Me.Gr2.TabIndex = 26
        Me.Gr2.TabStop = False
        Me.Gr2.Visible = False
        '
        'cmd_exit1
        '
        Me.cmd_exit1.Font = New System.Drawing.Font("Stencil", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_exit1.Image = Global.Inventory.My.Resources.Resources._Exit
        Me.cmd_exit1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_exit1.Location = New System.Drawing.Point(281, 26)
        Me.cmd_exit1.Name = "cmd_exit1"
        Me.cmd_exit1.Size = New System.Drawing.Size(130, 55)
        Me.cmd_exit1.TabIndex = 2
        Me.cmd_exit1.Text = "EXIT"
        Me.cmd_exit1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_exit1.UseVisualStyleBackColor = True
        '
        'CMD_WINDOWS
        '
        Me.CMD_WINDOWS.Font = New System.Drawing.Font("Stencil", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_WINDOWS.Image = Global.Inventory.My.Resources.Resources.view
        Me.CMD_WINDOWS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CMD_WINDOWS.Location = New System.Drawing.Point(151, 26)
        Me.CMD_WINDOWS.Name = "CMD_WINDOWS"
        Me.CMD_WINDOWS.Size = New System.Drawing.Size(130, 55)
        Me.CMD_WINDOWS.TabIndex = 1
        Me.CMD_WINDOWS.Text = "WINDOWS"
        Me.CMD_WINDOWS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CMD_WINDOWS.UseVisualStyleBackColor = True
        '
        'CMD_DOS
        '
        Me.CMD_DOS.Font = New System.Drawing.Font("Stencil", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_DOS.Image = Global.Inventory.My.Resources.Resources.view
        Me.CMD_DOS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CMD_DOS.Location = New System.Drawing.Point(21, 26)
        Me.CMD_DOS.Name = "CMD_DOS"
        Me.CMD_DOS.Size = New System.Drawing.Size(130, 55)
        Me.CMD_DOS.TabIndex = 0
        Me.CMD_DOS.Text = "DOS"
        Me.CMD_DOS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CMD_DOS.UseVisualStyleBackColor = True
        '
        'Btn_help
        '
        Me.Btn_help.BackColor = System.Drawing.Color.Transparent
        Me.Btn_help.BackgroundImage = Global.Inventory.My.Resources.Resources.save
        Me.Btn_help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_help.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_help.ForeColor = System.Drawing.Color.Black
        Me.Btn_help.Location = New System.Drawing.Point(7, -15)
        Me.Btn_help.Name = "Btn_help"
        Me.Btn_help.Size = New System.Drawing.Size(29, 24)
        Me.Btn_help.TabIndex = 2
        Me.Btn_help.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_help.UseVisualStyleBackColor = False
        '
        'LBL_COMPANYNAME
        '
        Me.LBL_COMPANYNAME.AutoSize = True
        Me.LBL_COMPANYNAME.BackColor = System.Drawing.Color.DarkGreen
        Me.LBL_COMPANYNAME.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_COMPANYNAME.ForeColor = System.Drawing.Color.Yellow
        Me.LBL_COMPANYNAME.Location = New System.Drawing.Point(-40, 54)
        Me.LBL_COMPANYNAME.Name = "LBL_COMPANYNAME"
        Me.LBL_COMPANYNAME.Size = New System.Drawing.Size(28, 15)
        Me.LBL_COMPANYNAME.TabIndex = 669
        Me.LBL_COMPANYNAME.Text = "REC"
        '
        'Label220
        '
        Me.Label220.AutoSize = True
        Me.Label220.BackColor = System.Drawing.Color.Transparent
        Me.Label220.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label220.ForeColor = System.Drawing.Color.Red
        Me.Label220.Location = New System.Drawing.Point(484, 209)
        Me.Label220.Name = "Label220"
        Me.Label220.Size = New System.Drawing.Size(245, 16)
        Me.Label220.TabIndex = 934
        Me.Label220.Text = "* Fields are mandatory can't be blank"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.btn_authorize)
        Me.GroupBox2.Controls.Add(Me.LBL_COMPANYNAME)
        Me.GroupBox2.Controls.Add(Me.Gr2)
        Me.GroupBox2.Location = New System.Drawing.Point(889, 134)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(88, 20)
        Me.GroupBox2.TabIndex = 935
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Hidden Fields"
        Me.GroupBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.Location = New System.Drawing.Point(24, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 921
        Me.PictureBox1.TabStop = False
        '
        'pnl_text
        '
        Me.pnl_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_text.Controls.Add(Me.Label9)
        Me.pnl_text.Controls.Add(Me.Label2)
        Me.pnl_text.Controls.Add(Me.txt_code)
        Me.pnl_text.Controls.Add(Me.Label6)
        Me.pnl_text.Controls.Add(Me.txt_desc)
        Me.pnl_text.Controls.Add(Me.Label3)
        Me.pnl_text.Location = New System.Drawing.Point(446, 117)
        Me.pnl_text.Name = "pnl_text"
        Me.pnl_text.Size = New System.Drawing.Size(313, 87)
        Me.pnl_text.TabIndex = 961
        '
        'pnl_main
        '
        Me.pnl_main.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl_main.BackColor = System.Drawing.Color.MintCream
        Me.pnl_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_main.Controls.Add(Me.pnl_ctrl)
        Me.pnl_main.Controls.Add(Me.GroupBox2)
        Me.pnl_main.Controls.Add(Me.pnl_text)
        Me.pnl_main.Controls.Add(Me.Panel1)
        Me.pnl_main.Controls.Add(Me.lbl_Freeze)
        Me.pnl_main.Controls.Add(Me.Label4)
        Me.pnl_main.Controls.Add(Me.Label220)
        Me.pnl_main.Location = New System.Drawing.Point(12, 12)
        Me.pnl_main.Name = "pnl_main"
        Me.pnl_main.Size = New System.Drawing.Size(1277, 429)
        Me.pnl_main.TabIndex = 967
        '
        'pnl_ctrl
        '
        Me.pnl_ctrl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl_ctrl.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.pnl_ctrl.Controls.Add(Me.Panel8)
        Me.pnl_ctrl.Location = New System.Drawing.Point(767, 326)
        Me.pnl_ctrl.Name = "pnl_ctrl"
        Me.pnl_ctrl.Size = New System.Drawing.Size(496, 90)
        Me.pnl_ctrl.TabIndex = 964
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.LightCyan
        Me.Panel8.Controls.Add(Me.Panel6)
        Me.Panel8.Controls.Add(Me.Panel4)
        Me.Panel8.Controls.Add(Me.Panel5)
        Me.Panel8.Controls.Add(Me.Panel3)
        Me.Panel8.Controls.Add(Me.Panel7)
        Me.Panel8.Location = New System.Drawing.Point(12, 14)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(474, 66)
        Me.Panel8.TabIndex = 964
        '
        'Panel6
        '
        Me.Panel6.BackgroundImage = Global.Inventory.My.Resources.Resources.exit_web
        Me.Panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel6.Location = New System.Drawing.Point(381, 12)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(79, 40)
        Me.Panel6.TabIndex = 967
        '
        'Panel4
        '
        Me.Panel4.BackgroundImage = Global.Inventory.My.Resources.Resources.clear_web
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel4.Location = New System.Drawing.Point(15, 12)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(91, 37)
        Me.Panel4.TabIndex = 966
        '
        'Panel5
        '
        Me.Panel5.BackgroundImage = Global.Inventory.My.Resources.Resources.void_web
        Me.Panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel5.Location = New System.Drawing.Point(296, 12)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(79, 40)
        Me.Panel5.TabIndex = 966
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = Global.Inventory.My.Resources.Resources.view_web
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel3.Location = New System.Drawing.Point(202, 12)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(88, 40)
        Me.Panel3.TabIndex = 966
        '
        'Panel7
        '
        Me.Panel7.BackgroundImage = Global.Inventory.My.Resources.Resources.save_web
        Me.Panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel7.Location = New System.Drawing.Point(114, 12)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(83, 40)
        Me.Panel7.TabIndex = 966
        '
        'frm_mkga_countrymaster_New_UI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1302, 453)
        Me.Controls.Add(Me.pnl_main)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frm_mkga_countrymaster_New_UI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_mkga_countrymaster"
        Me.Panel1.ResumeLayout(False)
        Me.Gr2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_text.ResumeLayout(False)
        Me.pnl_text.PerformLayout()
        Me.pnl_main.ResumeLayout(False)
        Me.pnl_main.PerformLayout()
        Me.pnl_ctrl.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_code As System.Windows.Forms.TextBox
    Friend WithEvents txt_desc As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents Btn_help As System.Windows.Forms.Button
    Public WithEvents btn_exit As System.Windows.Forms.Button
    Public WithEvents btn_view As System.Windows.Forms.Button
    Public WithEvents btn_clear As System.Windows.Forms.Button
    Public WithEvents btn_freeze As System.Windows.Forms.Button
    Public WithEvents btn_add As System.Windows.Forms.Button
    Public WithEvents btn_authorize As System.Windows.Forms.Button
    Public WithEvents browse As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Gr2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_exit1 As System.Windows.Forms.Button
    Friend WithEvents CMD_WINDOWS As System.Windows.Forms.Button
    Friend WithEvents CMD_DOS As System.Windows.Forms.Button
    Friend WithEvents LBL_COMPANYNAME As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label220 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents pnl_text As Panel
    Friend WithEvents pnl_main As Panel
    Friend WithEvents pnl_ctrl As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel7 As Panel
End Class
