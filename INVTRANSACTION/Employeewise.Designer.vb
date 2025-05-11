<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Employeewise
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Employeewise))
        Me.AxfpSpread1 = New AxFPSpreadADO.AxfpSpread()
        Me.lbl_itemname = New System.Windows.Forms.Label()
        Me.LBL_ITEMCODE = New System.Windows.Forms.Label()
        Me.Txt_QTY = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmdOk = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cmd_Docnohelp = New System.Windows.Forms.Button()
        Me.txt_Docno = New System.Windows.Forms.TextBox()
        Me.btn_update = New System.Windows.Forms.Button()
        Me.dtp_Docdate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmd_clear = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BTN_DIS_DOCNO = New System.Windows.Forms.Button()
        Me.TXT_DIS_DOCNO = New System.Windows.Forms.TextBox()
        Me.cmd_view = New System.Windows.Forms.Button()
        Me.btn_delete = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.AxfpSpread1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'AxfpSpread1
        '
        Me.AxfpSpread1.DataSource = Nothing
        Me.AxfpSpread1.Location = New System.Drawing.Point(28, 158)
        Me.AxfpSpread1.Name = "AxfpSpread1"
        Me.AxfpSpread1.OcxState = CType(resources.GetObject("AxfpSpread1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxfpSpread1.Size = New System.Drawing.Size(1041, 237)
        Me.AxfpSpread1.TabIndex = 13
        '
        'lbl_itemname
        '
        Me.lbl_itemname.AutoSize = True
        Me.lbl_itemname.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_itemname.ForeColor = System.Drawing.Color.Yellow
        Me.lbl_itemname.Location = New System.Drawing.Point(21, 73)
        Me.lbl_itemname.Name = "lbl_itemname"
        Me.lbl_itemname.Size = New System.Drawing.Size(92, 17)
        Me.lbl_itemname.TabIndex = 2
        Me.lbl_itemname.Text = "ITEM NAME"
        '
        'LBL_ITEMCODE
        '
        Me.LBL_ITEMCODE.AutoSize = True
        Me.LBL_ITEMCODE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_ITEMCODE.ForeColor = System.Drawing.Color.DarkMagenta
        Me.LBL_ITEMCODE.Location = New System.Drawing.Point(22, 47)
        Me.LBL_ITEMCODE.Name = "LBL_ITEMCODE"
        Me.LBL_ITEMCODE.Size = New System.Drawing.Size(92, 17)
        Me.LBL_ITEMCODE.TabIndex = 1
        Me.LBL_ITEMCODE.Text = "ITEM CODE"
        '
        'Txt_QTY
        '
        Me.Txt_QTY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_QTY.Location = New System.Drawing.Point(952, 76)
        Me.Txt_QTY.Name = "Txt_QTY"
        Me.Txt_QTY.ReadOnly = True
        Me.Txt_QTY.Size = New System.Drawing.Size(109, 21)
        Me.Txt_QTY.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label2.Location = New System.Drawing.Point(848, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 19)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Issue Qty"
        '
        'CmdOk
        '
        Me.CmdOk.BackColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(154, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.CmdOk.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdOk.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CmdOk.Location = New System.Drawing.Point(12, 18)
        Me.CmdOk.Name = "CmdOk"
        Me.CmdOk.Size = New System.Drawing.Size(79, 32)
        Me.CmdOk.TabIndex = 0
        Me.CmdOk.Text = "Add"
        Me.CmdOk.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(154, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.cmdexit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdexit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmdexit.Location = New System.Drawing.Point(348, 18)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(78, 32)
        Me.cmdexit.TabIndex = 18
        Me.cmdexit.Text = "Exit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label10.Location = New System.Drawing.Point(414, 13)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(238, 24)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "STOCK DISTRIBUTION"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(849, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "ISSUE DOC NO"
        '
        'Cmd_Docnohelp
        '
        Me.Cmd_Docnohelp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Docnohelp.Image = CType(resources.GetObject("Cmd_Docnohelp.Image"), System.Drawing.Image)
        Me.Cmd_Docnohelp.Location = New System.Drawing.Point(1086, 14)
        Me.Cmd_Docnohelp.Name = "Cmd_Docnohelp"
        Me.Cmd_Docnohelp.Size = New System.Drawing.Size(23, 26)
        Me.Cmd_Docnohelp.TabIndex = 5
        '
        'txt_Docno
        '
        Me.txt_Docno.BackColor = System.Drawing.Color.Wheat
        Me.txt_Docno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Docno.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Docno.Location = New System.Drawing.Point(952, 16)
        Me.txt_Docno.MaxLength = 15
        Me.txt_Docno.Name = "txt_Docno"
        Me.txt_Docno.ReadOnly = True
        Me.txt_Docno.Size = New System.Drawing.Size(132, 21)
        Me.txt_Docno.TabIndex = 4
        '
        'btn_update
        '
        Me.btn_update.BackColor = System.Drawing.Color.Gray
        Me.btn_update.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_update.Location = New System.Drawing.Point(13, 19)
        Me.btn_update.Name = "btn_update"
        Me.btn_update.Size = New System.Drawing.Size(77, 32)
        Me.btn_update.TabIndex = 17
        Me.btn_update.Text = "Update"
        Me.btn_update.UseVisualStyleBackColor = False
        Me.btn_update.Visible = False
        '
        'dtp_Docdate
        '
        Me.dtp_Docdate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_Docdate.Enabled = False
        Me.dtp_Docdate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Docdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Docdate.Location = New System.Drawing.Point(952, 43)
        Me.dtp_Docdate.Name = "dtp_Docdate"
        Me.dtp_Docdate.Size = New System.Drawing.Size(109, 21)
        Me.dtp_Docdate.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(849, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "ISSUE DATE"
        '
        'cmd_clear
        '
        Me.cmd_clear.BackColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(154, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.cmd_clear.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmd_clear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_clear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmd_clear.Location = New System.Drawing.Point(264, 18)
        Me.cmd_clear.Name = "cmd_clear"
        Me.cmd_clear.Size = New System.Drawing.Size(78, 32)
        Me.cmd_clear.TabIndex = 14
        Me.cmd_clear.Text = "Clear"
        Me.cmd_clear.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(849, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 15)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "DISTN. DOC NO"
        '
        'BTN_DIS_DOCNO
        '
        Me.BTN_DIS_DOCNO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_DIS_DOCNO.Image = CType(resources.GetObject("BTN_DIS_DOCNO.Image"), System.Drawing.Image)
        Me.BTN_DIS_DOCNO.Location = New System.Drawing.Point(1086, 105)
        Me.BTN_DIS_DOCNO.Name = "BTN_DIS_DOCNO"
        Me.BTN_DIS_DOCNO.Size = New System.Drawing.Size(23, 26)
        Me.BTN_DIS_DOCNO.TabIndex = 12
        '
        'TXT_DIS_DOCNO
        '
        Me.TXT_DIS_DOCNO.BackColor = System.Drawing.Color.Wheat
        Me.TXT_DIS_DOCNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_DIS_DOCNO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_DIS_DOCNO.Location = New System.Drawing.Point(952, 107)
        Me.TXT_DIS_DOCNO.MaxLength = 15
        Me.TXT_DIS_DOCNO.Name = "TXT_DIS_DOCNO"
        Me.TXT_DIS_DOCNO.ReadOnly = True
        Me.TXT_DIS_DOCNO.Size = New System.Drawing.Size(132, 21)
        Me.TXT_DIS_DOCNO.TabIndex = 11
        '
        'cmd_view
        '
        Me.cmd_view.BackColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(154, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.cmd_view.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmd_view.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_view.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmd_view.Location = New System.Drawing.Point(96, 19)
        Me.cmd_view.Name = "cmd_view"
        Me.cmd_view.Size = New System.Drawing.Size(78, 32)
        Me.cmd_view.TabIndex = 16
        Me.cmd_view.Text = "View"
        Me.cmd_view.UseVisualStyleBackColor = False
        '
        'btn_delete
        '
        Me.btn_delete.BackColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(154, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.btn_delete.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_delete.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_delete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btn_delete.Location = New System.Drawing.Point(180, 19)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(78, 32)
        Me.btn_delete.TabIndex = 15
        Me.btn_delete.Text = "Delete"
        Me.btn_delete.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_update)
        Me.GroupBox1.Controls.Add(Me.btn_delete)
        Me.GroupBox1.Controls.Add(Me.CmdOk)
        Me.GroupBox1.Controls.Add(Me.cmd_view)
        Me.GroupBox1.Controls.Add(Me.cmdexit)
        Me.GroupBox1.Controls.Add(Me.cmd_clear)
        Me.GroupBox1.Location = New System.Drawing.Point(294, 413)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(446, 67)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        '
        'Employeewise
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.RosyBrown
        Me.ClientSize = New System.Drawing.Size(1124, 493)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BTN_DIS_DOCNO)
        Me.Controls.Add(Me.TXT_DIS_DOCNO)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtp_Docdate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cmd_Docnohelp)
        Me.Controls.Add(Me.txt_Docno)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Txt_QTY)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbl_itemname)
        Me.Controls.Add(Me.LBL_ITEMCODE)
        Me.Controls.Add(Me.AxfpSpread1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Employeewise"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Employeewise"
        CType(Me.AxfpSpread1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents AxfpSpread1 As AxFPSpreadADO.AxfpSpread
    Friend WithEvents lbl_itemname As Label
    Friend WithEvents LBL_ITEMCODE As Label
    Friend WithEvents Txt_QTY As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CmdOk As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Cmd_Docnohelp As Button
    Friend WithEvents txt_Docno As TextBox
    Friend WithEvents btn_update As Button
    Friend WithEvents dtp_Docdate As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents cmd_clear As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents BTN_DIS_DOCNO As Button
    Friend WithEvents TXT_DIS_DOCNO As TextBox
    Friend WithEvents cmd_view As Button
    Friend WithEvents btn_delete As Button
    Friend WithEvents GroupBox1 As GroupBox
End Class
