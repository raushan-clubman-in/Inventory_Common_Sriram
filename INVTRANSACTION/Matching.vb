Imports System.Data.SqlClient
Public Class Matching
    Inherits System.Windows.Forms.Form
    Dim gconnection As New GlobalClass
    Dim I, J As Long
    Dim Vsql As String
    Public STORECODE, STORECOD2, ITEMCODE, TType, docno, uom As String
    Public TotalQTY, BalQTY As Double
    Public docdate As Date
    Dim strSQL As String
    Dim vAccounttype As String
    Dim RowId As Double
    Friend WithEvents LBL_ITEMCODE As Label
    Friend WithEvents lbl_itemname As Label
    Dim gUpdate As Boolean
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
    Friend WithEvents CmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents SSMatching As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Label2 As System.Windows.Forms.Label

    Friend WithEvents Txt_QTY As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Matching))
        Me.SSMatching = New AxFPSpreadADO.AxfpSpread()
        Me.frmbut = New System.Windows.Forms.GroupBox()
        Me.CmdOk = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_QTY = New System.Windows.Forms.TextBox()
        Me.LBL_ITEMCODE = New System.Windows.Forms.Label()
        Me.lbl_itemname = New System.Windows.Forms.Label()
        CType(Me.SSMatching, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmbut.SuspendLayout()
        Me.SuspendLayout()
        '
        'SSMatching
        '
        Me.SSMatching.DataSource = Nothing
        Me.SSMatching.Location = New System.Drawing.Point(13, 172)
        Me.SSMatching.Name = "SSMatching"
        Me.SSMatching.OcxState = CType(resources.GetObject("SSMatching.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSMatching.Size = New System.Drawing.Size(811, 278)
        Me.SSMatching.TabIndex = 126
        '
        'frmbut
        '
        Me.frmbut.BackColor = System.Drawing.Color.Transparent
        Me.frmbut.Controls.Add(Me.CmdOk)
        Me.frmbut.Controls.Add(Me.cmdexit)
        Me.frmbut.Location = New System.Drawing.Point(104, 515)
        Me.frmbut.Name = "frmbut"
        Me.frmbut.Size = New System.Drawing.Size(683, 96)
        Me.frmbut.TabIndex = 127
        Me.frmbut.TabStop = False
        '
        'CmdOk
        '
        Me.CmdOk.BackColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(154, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.CmdOk.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdOk.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CmdOk.Location = New System.Drawing.Point(216, 32)
        Me.CmdOk.Name = "CmdOk"
        Me.CmdOk.Size = New System.Drawing.Size(110, 48)
        Me.CmdOk.TabIndex = 0
        Me.CmdOk.Text = "Ok [F2]"
        Me.CmdOk.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(154, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.cmdexit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdexit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmdexit.Location = New System.Drawing.Point(339, 32)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(109, 48)
        Me.cmdexit.TabIndex = 4
        Me.cmdexit.Text = "Exit [F11]"
        Me.cmdexit.UseVisualStyleBackColor = False
        Me.cmdexit.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label10.Location = New System.Drawing.Point(255, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(378, 36)
        Me.Label10.TabIndex = 128
        Me.Label10.Text = "BATCH NO. MATCHING"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label2.Location = New System.Drawing.Point(407, 463)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(212, 26)
        Me.Label2.TabIndex = 130
        Me.Label2.Text = "Qty To Be Adjusted"
        '
        'Txt_QTY
        '
        Me.Txt_QTY.Location = New System.Drawing.Point(630, 455)
        Me.Txt_QTY.Name = "Txt_QTY"
        Me.Txt_QTY.ReadOnly = True
        Me.Txt_QTY.Size = New System.Drawing.Size(190, 40)
        Me.Txt_QTY.TabIndex = 131
        '
        'LBL_ITEMCODE
        '
        Me.LBL_ITEMCODE.AutoSize = True
        Me.LBL_ITEMCODE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_ITEMCODE.ForeColor = System.Drawing.Color.Red
        Me.LBL_ITEMCODE.Location = New System.Drawing.Point(49, 75)
        Me.LBL_ITEMCODE.Name = "LBL_ITEMCODE"
        Me.LBL_ITEMCODE.Size = New System.Drawing.Size(155, 29)
        Me.LBL_ITEMCODE.TabIndex = 132
        Me.LBL_ITEMCODE.Text = "ITEM CODE"
        '
        'lbl_itemname
        '
        Me.lbl_itemname.AutoSize = True
        Me.lbl_itemname.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_itemname.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lbl_itemname.Location = New System.Drawing.Point(49, 126)
        Me.lbl_itemname.Name = "lbl_itemname"
        Me.lbl_itemname.Size = New System.Drawing.Size(155, 29)
        Me.lbl_itemname.TabIndex = 133
        Me.lbl_itemname.Text = "ITEM NAME"
        '
        'Matching
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(14, 33)
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(848, 695)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbl_itemname)
        Me.Controls.Add(Me.LBL_ITEMCODE)
        Me.Controls.Add(Me.Txt_QTY)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.frmbut)
        Me.Controls.Add(Me.SSMatching)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Matching"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BATCH NO MATCHING"
        CType(Me.SSMatching, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmbut.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private Sub SSMatching_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles SSMatching.KeyDownEvent
        Dim actualqty, enteredqty As Double
        SSMatching.Row = SSMatching.ActiveRow
        If SSMatching.ActiveCol = 4 Then
            SSMatching.Col = 3
            actualqty = SSMatching.Text
            SSMatching.Col = 4
            enteredqty = SSMatching.Text
            If (enteredqty > actualqty) Then
                MsgBox("Entered quantity cannot be greater then Batch quantity")
                SSMatching.Text = "0.000"
                SSMatching.Focus()
                Exit Sub
            End If
            ' CheckQty()
        End If
    End Sub

#End Region
    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Call subExit()
    End Sub
    Private Sub CmdOk_Click(sender As Object, e As EventArgs) Handles CmdOk.Click
        Dim sqls As String
        If (CheckQty()) Then
            For i As Integer = 1 To SSMatching.DataRowCnt
                SSMatching.Row = i
                SSMatching.Col = 3
                If SSMatching.Text > 0 Then
                    If TType = "ISSUE" Or TType = "TRANSFER" Then
                        'For From Store
                        strSQL = "insert into temp_batchdetails(trnno,itemcode,itemname,uom,storecode,trndate,ttype,QTY,RATE,EXPIRYDATE,batchno)"
                        strSQL = strSQL & "VALUES ('" & docno & "','" & LBL_ITEMCODE.Text & "','" & lbl_itemname.Text & "','" & uom & "','" & STORECODE & "','" & Format(CDate(docdate), "dd/MMM/yyyy") & "','" & TType & "',"
                        SSMatching.Row = i
                        SSMatching.Col = 4
                        strSQL = strSQL & "'" & Trim(SSMatching.Text) & "',"
                        SSMatching.Row = i
                        SSMatching.Col = 5
                        strSQL = strSQL & "'" & Trim(SSMatching.Text) & "',"
                        SSMatching.Row = i
                        SSMatching.Col = 2
                        strSQL = strSQL & "'" & Format(CDate(SSMatching.Text), "dd/MMM/yyyy") & "',"
                        SSMatching.Row = i
                        SSMatching.Col = 1
                        strSQL = strSQL & "'" & Trim(SSMatching.Text) & "')"
                        gconnection.getDataSet(strSQL, "temp_batchdetails")
                        ' For To Store
                        strSQL = "insert into temp_batchdetails(trnno,itemcode,itemname,uom,storecode,trndate,ttype,QTY,RATE,EXPIRYDATE,batchno)"
                        strSQL = strSQL & "VALUES ('" & docno & "','" & LBL_ITEMCODE.Text & "','" & lbl_itemname.Text & "','" & uom & "','" & STORECOD2 & "','" & Format(CDate(docdate), "dd/MMM/yyyy") & "','" & TType & "',"
                        SSMatching.Row = i
                        SSMatching.Col = 4
                        strSQL = strSQL & "'" & Trim(SSMatching.Text) & "',"
                        SSMatching.Row = i
                        SSMatching.Col = 5
                        strSQL = strSQL & "'" & Trim(SSMatching.Text) & "',"
                        SSMatching.Row = i
                        SSMatching.Col = 2
                        strSQL = strSQL & "'" & Format(CDate(SSMatching.Text), "dd/MMM/yyyy") & "',"
                        SSMatching.Row = i
                        SSMatching.Col = 1
                        strSQL = strSQL & "'" & Trim(SSMatching.Text) & "')"
                        gconnection.getDataSet(strSQL, "temp_batchdetails")
                    Else
                        strSQL = "insert into temp_batchdetails(trnno,itemcode,itemname,uom,storecode,trndate,ttype,QTY,RATE,EXPIRYDATE,batchno)"
                        strSQL = strSQL & "VALUES ('" & docno & "','" & LBL_ITEMCODE.Text & "','" & lbl_itemname.Text & "','" & uom & "','" & STORECODE & "','" & Format(CDate(docdate), "dd/MMM/yyyy") & "','" & TType & "',"
                        SSMatching.Row = i
                        SSMatching.Col = 4
                        strSQL = strSQL & "'" & Trim(SSMatching.Text) & "',"
                        SSMatching.Row = i
                        SSMatching.Col = 5
                        strSQL = strSQL & "'" & Trim(SSMatching.Text) & "',"
                        SSMatching.Row = i
                        SSMatching.Col = 2
                        strSQL = strSQL & "'" & Format(CDate(SSMatching.Text), "dd/MMM/yyyy") & "',"
                        SSMatching.Row = i
                        SSMatching.Col = 1
                        strSQL = strSQL & "'" & Trim(SSMatching.Text) & "')"
                        gconnection.getDataSet(strSQL, "temp_batchdetails")
                    End If
                End If
            Next
            Call subExit()
        End If

    End Sub
    Private Function CheckQty() As Boolean
        Dim qty As Double
        For I = 1 To SSMatching.DataRowCnt
            SSMatching.Row = I
            SSMatching.Col = 4
            qty = qty + Convert.ToDouble(SSMatching.Text)
            If (qty > TotalQTY) Then
                MsgBox("Entered total quantity cannot be greater then total quantity")
                Return False
            End If
            'If (qty < TotalQTY) Then
            '    MsgBox("Entered total quantity cannot be lesser then total quantity")
            '    Return False
            'End If
        Next
        Return True
    End Function
    Private Sub Matching_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SQLSTRING As String
        Txt_QTY.Text = TotalQTY
        Dim qty As Double = TotalQTY
        SQLSTRING = " Select ISNULL(batchno,'')AS batchno ,ISNULL(EXPIRYDATE,'')AS EXPIRYDATE,sum(qty)as QTY,ISNULL(RATE,0)AS RATE from inv_Batchdetails  where itemcode='" & LBL_ITEMCODE.Text & "' and storecode='" & STORECODE & "'  group by batchno,EXPIRYDATE,RATE having  sum(qty)<>0 order by EXPIRYDATE "
        gconnection.getDataSet(SQLSTRING, "BATCHNO_MATCHING")
        If gdataset.Tables("BATCHNO_MATCHING").Rows.Count > 0 Then
            For I = 1 To gdataset.Tables("BATCHNO_MATCHING").Rows.Count
                J = I - 1
                SSMatching.SetText(1, I, gdataset.Tables("BATCHNO_MATCHING").Rows(J).Item("BATCHNO"))
                SSMatching.SetText(2, I, gdataset.Tables("BATCHNO_MATCHING").Rows(J).Item("EXPIRYDATE"))
                SSMatching.SetText(5, I, gdataset.Tables("BATCHNO_MATCHING").Rows(J).Item("RATE").ToString())
                SSMatching.SetText(3, I, gdataset.Tables("BATCHNO_MATCHING").Rows(J).Item("QTY").ToString())
                If (qty > gdataset.Tables("BATCHNO_MATCHING").Rows(J).Item("QTY")) Then
                    SSMatching.SetText(4, I, gdataset.Tables("BATCHNO_MATCHING").Rows(J).Item("QTY").ToString())
                    qty = qty - gdataset.Tables("BATCHNO_MATCHING").Rows(J).Item("QTY")
                Else
                    SSMatching.SetText(4, I, qty.ToString())
                    qty = qty - qty
                End If
            Next
        End If

    End Sub
    Private Sub subExit()
        Me.Visible = False
    End Sub
End Class