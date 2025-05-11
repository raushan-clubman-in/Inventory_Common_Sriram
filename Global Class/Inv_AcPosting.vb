Public Class Inv_AcPosting
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
    Friend WithEvents lbl_KOTdate As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtp_FROMdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_TOdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Cmd_UPDATE As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_POS As System.Windows.Forms.TextBox
    Friend WithEvents PBAR As System.Windows.Forms.ProgressBar
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BTN_REVERSE As System.Windows.Forms.Button
    Friend WithEvents btn_validation As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dtp_FROMdate = New System.Windows.Forms.DateTimePicker()
        Me.dtp_TOdate = New System.Windows.Forms.DateTimePicker()
        Me.lbl_KOTdate = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cmd_UPDATE = New System.Windows.Forms.Button()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_POS = New System.Windows.Forms.TextBox()
        Me.PBAR = New System.Windows.Forms.ProgressBar()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_validation = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BTN_REVERSE = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtp_FROMdate
        '
        Me.dtp_FROMdate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_FROMdate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_FROMdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_FROMdate.Location = New System.Drawing.Point(346, 23)
        Me.dtp_FROMdate.Name = "dtp_FROMdate"
        Me.dtp_FROMdate.Size = New System.Drawing.Size(217, 35)
        Me.dtp_FROMdate.TabIndex = 5
        '
        'dtp_TOdate
        '
        Me.dtp_TOdate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_TOdate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_TOdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_TOdate.Location = New System.Drawing.Point(346, 82)
        Me.dtp_TOdate.Name = "dtp_TOdate"
        Me.dtp_TOdate.Size = New System.Drawing.Size(217, 35)
        Me.dtp_TOdate.TabIndex = 6
        '
        'lbl_KOTdate
        '
        Me.lbl_KOTdate.AutoSize = True
        Me.lbl_KOTdate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_KOTdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_KOTdate.Location = New System.Drawing.Point(115, 23)
        Me.lbl_KOTdate.Name = "lbl_KOTdate"
        Me.lbl_KOTdate.Size = New System.Drawing.Size(166, 29)
        Me.lbl_KOTdate.TabIndex = 41
        Me.lbl_KOTdate.Text = "FROM DATE :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(154, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 29)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "TO DATE :"
        '
        'Cmd_UPDATE
        '
        Me.Cmd_UPDATE.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_UPDATE.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_UPDATE.ForeColor = System.Drawing.Color.Black
        Me.Cmd_UPDATE.Location = New System.Drawing.Point(46, 12)
        Me.Cmd_UPDATE.Name = "Cmd_UPDATE"
        Me.Cmd_UPDATE.Size = New System.Drawing.Size(167, 46)
        Me.Cmd_UPDATE.TabIndex = 8
        Me.Cmd_UPDATE.Text = "POST"
        Me.Cmd_UPDATE.UseVisualStyleBackColor = False
        '
        'cmd_exit
        '
        Me.cmd_exit.BackColor = System.Drawing.Color.Transparent
        Me.cmd_exit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_exit.ForeColor = System.Drawing.Color.Black
        Me.cmd_exit.Location = New System.Drawing.Point(597, 12)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(166, 46)
        Me.cmd_exit.TabIndex = 9
        Me.cmd_exit.Text = "EXIT"
        Me.cmd_exit.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(154, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 29)
        Me.Label2.TabIndex = 353
        Me.Label2.Text = "POS CODE:"
        Me.Label2.Visible = False
        '
        'txt_POS
        '
        Me.txt_POS.BackColor = System.Drawing.Color.White
        Me.txt_POS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_POS.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_POS.Location = New System.Drawing.Point(346, 140)
        Me.txt_POS.MaxLength = 50
        Me.txt_POS.Name = "txt_POS"
        Me.txt_POS.Size = New System.Drawing.Size(217, 40)
        Me.txt_POS.TabIndex = 7
        Me.txt_POS.Visible = False
        '
        'PBAR
        '
        Me.PBAR.Location = New System.Drawing.Point(618, 514)
        Me.PBAR.Name = "PBAR"
        Me.PBAR.Size = New System.Drawing.Size(742, 36)
        Me.PBAR.Step = 1
        Me.PBAR.TabIndex = 358
        Me.PBAR.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btn_validation)
        Me.Panel1.Controls.Add(Me.Cmd_UPDATE)
        Me.Panel1.Controls.Add(Me.cmd_exit)
        Me.Panel1.Location = New System.Drawing.Point(579, 585)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(807, 70)
        Me.Panel1.TabIndex = 359
        '
        'btn_validation
        '
        Me.btn_validation.BackColor = System.Drawing.Color.Transparent
        Me.btn_validation.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_validation.ForeColor = System.Drawing.Color.Black
        Me.btn_validation.Location = New System.Drawing.Point(254, 10)
        Me.btn_validation.Name = "btn_validation"
        Me.btn_validation.Size = New System.Drawing.Size(312, 47)
        Me.btn_validation.TabIndex = 10
        Me.btn_validation.Text = "UNMATCHED VOUCHER"
        Me.btn_validation.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dtp_FROMdate)
        Me.GroupBox1.Controls.Add(Me.dtp_TOdate)
        Me.GroupBox1.Controls.Add(Me.txt_POS)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lbl_KOTdate)
        Me.GroupBox1.Location = New System.Drawing.Point(579, 269)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(807, 210)
        Me.GroupBox1.TabIndex = 360
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(592, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(781, 34)
        Me.Label4.TabIndex = 502
        Me.Label4.Text = "INVENTORY ACCOUNTS POSTING "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BTN_REVERSE)
        Me.GroupBox2.Location = New System.Drawing.Point(1134, 674)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(252, 102)
        Me.GroupBox2.TabIndex = 503
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Visible = False
        '
        'BTN_REVERSE
        '
        Me.BTN_REVERSE.BackColor = System.Drawing.Color.Transparent
        Me.BTN_REVERSE.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_REVERSE.ForeColor = System.Drawing.Color.Black
        Me.BTN_REVERSE.Location = New System.Drawing.Point(21, 15)
        Me.BTN_REVERSE.Name = "BTN_REVERSE"
        Me.BTN_REVERSE.Size = New System.Drawing.Size(208, 73)
        Me.BTN_REVERSE.TabIndex = 9
        Me.BTN_REVERSE.Text = "   REVERSE" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "CONSUMPTION"
        Me.BTN_REVERSE.UseVisualStyleBackColor = False
        Me.BTN_REVERSE.Visible = False
        '
        'Inv_AcPosting
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.BackColor = System.Drawing.Color.CadetBlue
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1699, 693)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PBAR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Inv_AcPosting"
        Me.Text = "MANUAL STOCK UPDATION FROM POS"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim gconnection As New GlobalClass
    Private Sub Cmd_UPDATE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UPDATE.Click

        Me.Cursor = Cursors.WaitCursor

        Dim bdate As Date
        bdate = gconnection.getvalue("SELECT bdate As bdate FROM Businessdate")

        If Format(dtp_FROMdate.Value, "dd/MMM/yyyy") > Format(bdate, "dd/MMM/yyyy") Then
            MessageBox.Show("Date cannot be less than Last Business Date (" + CStr(bdate) + ")", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '            Exit Sub
        End If

        Call NewAccountPostingDATEWISE(Format(CDate(dtp_FROMdate.Value), "dd/MMM/yyyy"), Format(CDate(dtp_TOdate.Value), "dd/MMM/yyyy"))

        MsgBox("Account Posting Completed....")
        Me.Cursor = Cursors.Default


    End Sub
    Private Sub cmd_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Me.Close()
    End Sub
    Public Function STORELOCATION(ByVal STORECODE As String) As String
        Dim sqlstring, STRLOCATION As String
        'sqlstring = "SELECT STOREDESC FROM STOREMASTER WHERE STORECODE='" & STORECODE & "' AND ISNULL(FREEZE,'') <> 'Y'"
        'gconnection.getDataSet(sqlstring, "STOREMASTER")
        'If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
        '    STRLOCATION = (gdataset.Tables("STOREMASTER").Rows(0).Item("STOREDESC") & "")
        'End If
        Return ""
    End Function

    Private Sub dtp_FROMdate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtp_FROMdate.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                dtp_TOdate.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Grn Date Keypress " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub dtp_TOdate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtp_TOdate.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                Cmd_UPDATE.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Grn Date Keypress " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub btn_validation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_validation.Click
        ' System.Diagnostics.Process.Start(AppPath & "/STUDY/SUBSTORECONSUMPTION_MANUALUPADTION.XLS")

        Dim frmUpPost As New UnMatchedVoucherPosting
        frmUpPost.ShowDialog()

    End Sub

    Private Sub BTN_REVERSE_Click(sender As Object, e As EventArgs) Handles BTN_REVERSE.Click
        Dim SQLSTRING As String

        SQLSTRING = "SELECT * FROM journalentry WHERE ISNULL(VOID,'N')<>'Y' AND vouchercategory ='CONSUMPTION' AND   VoucherNo in  (select 'C-'+docdetails from SUBSTORECONSUMPTIONDETAIL where cast(docdate as date) BETWEEN  '" & Format(CDate(dtp_FROMdate.Value), "dd/MMM/yyyy") & "' AND '" & Format(CDate(dtp_TOdate.Value), "dd/MMM/yyyy") & "' ) AND cast(voucherdate as date)  BETWEEN  '" & Format(CDate(dtp_FROMdate.Value), "dd/MMM/yyyy") & "' AND '" & Format(CDate(dtp_TOdate.Value), "dd/MMM/yyyy") & "'"
        gconnection.getDataSet(SQLSTRING, "POSTED")
        If gdataset.Tables("POSTED").Rows.Count > 0 Then
            SQLSTRING = "delete from  journalentry WHERE vouchercategory ='CONSUMPTION' AND VoucherNo in "
            SQLSTRING = SQLSTRING & " (select docdetails from SUBSTORECONSUMPTIONDETAIL where cast(docdate as date) BETWEEN  '" & Format(CDate(dtp_FROMdate.Value), "dd/MMM/yyyy") & "' AND '" & Format(CDate(dtp_TOdate.Value), "dd/MMM/yyyy") & "' ) AND  cast(voucherdate as date)  BETWEEN  '" & Format(CDate(dtp_FROMdate.Value), "dd/MMM/yyyy") & "' AND '" & Format(CDate(dtp_TOdate.Value), "dd/MMM/yyyy") & "'"
            gconnection.ExcuteStoreProcedure(SQLSTRING)
            MsgBox("Consumption Posting Revresed in date between" & Format(CDate(dtp_FROMdate.Value), "dd/MMM/yyyy") & " AND " & Format(CDate(dtp_TOdate.Value), "dd/MMM/yyyy"), MsgBoxStyle.OkOnly, gCompanyname)
        Else
            MsgBox("No Any Data Posted In between selected dates")
            Exit Sub
        End If
    End Sub

    Private Sub Inv_AcPosting_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Mid(UCase(gShortname), 1, 3) = "CCL" Or Mid(UCase(gShortname), 1, 3) = "HGA" Then
            BTN_REVERSE.Visible = True
            GroupBox2.Visible = True
        End If
        Dim SQLSTRING As String

        SQLSTRING = "delete from  journalentry WHERE vouchertype+VoucherNo in ( "
        SQLSTRING = SQLSTRING & " select VOUCHERTYPE+voucherno from UNMATCHEDVOUCHER where ACCAMOUNT<>0 and INVAMOUNT=0 )"
        gconnection.ExcuteStoreProcedure(SQLSTRING)


        


    End Sub
End Class
