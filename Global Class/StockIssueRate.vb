Imports System.IO
Imports System.Data.SqlClient
Public Class frmstockissuerate
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
    Friend WithEvents PBAR As System.Windows.Forms.ProgressBar
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents chk_issue As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_TFR As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_ADJ As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_POS As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmstockissuerate))
        Me.dtp_FROMdate = New System.Windows.Forms.DateTimePicker()
        Me.dtp_TOdate = New System.Windows.Forms.DateTimePicker()
        Me.lbl_KOTdate = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cmd_UPDATE = New System.Windows.Forms.Button()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.PBAR = New System.Windows.Forms.ProgressBar()
        Me.chk_issue = New System.Windows.Forms.CheckBox()
        Me.CHK_TFR = New System.Windows.Forms.CheckBox()
        Me.CHK_ADJ = New System.Windows.Forms.CheckBox()
        Me.CHK_POS = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'dtp_FROMdate
        '
        Me.dtp_FROMdate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_FROMdate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_FROMdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_FROMdate.Location = New System.Drawing.Point(200, 16)
        Me.dtp_FROMdate.Name = "dtp_FROMdate"
        Me.dtp_FROMdate.Size = New System.Drawing.Size(136, 26)
        Me.dtp_FROMdate.TabIndex = 5
        '
        'dtp_TOdate
        '
        Me.dtp_TOdate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_TOdate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_TOdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_TOdate.Location = New System.Drawing.Point(200, 56)
        Me.dtp_TOdate.Name = "dtp_TOdate"
        Me.dtp_TOdate.Size = New System.Drawing.Size(136, 26)
        Me.dtp_TOdate.TabIndex = 6
        '
        'lbl_KOTdate
        '
        Me.lbl_KOTdate.AutoSize = True
        Me.lbl_KOTdate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_KOTdate.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_KOTdate.Location = New System.Drawing.Point(16, 16)
        Me.lbl_KOTdate.Name = "lbl_KOTdate"
        Me.lbl_KOTdate.Size = New System.Drawing.Size(153, 21)
        Me.lbl_KOTdate.TabIndex = 41
        Me.lbl_KOTdate.Text = "FROM DATE   :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 21)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "TO DATE     :"
        '
        'Cmd_UPDATE
        '
        Me.Cmd_UPDATE.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_UPDATE.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_UPDATE.ForeColor = System.Drawing.Color.Black
        Me.Cmd_UPDATE.Location = New System.Drawing.Point(72, 184)
        Me.Cmd_UPDATE.Name = "Cmd_UPDATE"
        Me.Cmd_UPDATE.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_UPDATE.TabIndex = 8
        Me.Cmd_UPDATE.Text = "UPDATE"
        Me.Cmd_UPDATE.UseVisualStyleBackColor = False
        '
        'cmd_exit
        '
        Me.cmd_exit.BackColor = System.Drawing.Color.Transparent
        Me.cmd_exit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_exit.ForeColor = System.Drawing.Color.Black
        Me.cmd_exit.Location = New System.Drawing.Point(200, 184)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(104, 32)
        Me.cmd_exit.TabIndex = 9
        Me.cmd_exit.Text = "EXIT"
        Me.cmd_exit.UseVisualStyleBackColor = False
        '
        'PBAR
        '
        Me.PBAR.Location = New System.Drawing.Point(16, 144)
        Me.PBAR.Name = "PBAR"
        Me.PBAR.Size = New System.Drawing.Size(344, 24)
        Me.PBAR.Step = 1
        Me.PBAR.TabIndex = 358
        '
        'chk_issue
        '
        Me.chk_issue.BackColor = System.Drawing.Color.Transparent
        Me.chk_issue.Location = New System.Drawing.Point(24, 104)
        Me.chk_issue.Name = "chk_issue"
        Me.chk_issue.Size = New System.Drawing.Size(64, 24)
        Me.chk_issue.TabIndex = 359
        Me.chk_issue.Text = "ISSUE"
        Me.chk_issue.UseVisualStyleBackColor = False
        Me.chk_issue.Visible = False
        '
        'CHK_TFR
        '
        Me.CHK_TFR.BackColor = System.Drawing.Color.Transparent
        Me.CHK_TFR.Location = New System.Drawing.Point(112, 104)
        Me.CHK_TFR.Name = "CHK_TFR"
        Me.CHK_TFR.Size = New System.Drawing.Size(64, 24)
        Me.CHK_TFR.TabIndex = 360
        Me.CHK_TFR.Text = "TFR"
        Me.CHK_TFR.UseVisualStyleBackColor = False
        Me.CHK_TFR.Visible = False
        '
        'CHK_ADJ
        '
        Me.CHK_ADJ.BackColor = System.Drawing.Color.Transparent
        Me.CHK_ADJ.Location = New System.Drawing.Point(224, 104)
        Me.CHK_ADJ.Name = "CHK_ADJ"
        Me.CHK_ADJ.Size = New System.Drawing.Size(64, 24)
        Me.CHK_ADJ.TabIndex = 361
        Me.CHK_ADJ.Text = "ADJ"
        Me.CHK_ADJ.UseVisualStyleBackColor = False
        Me.CHK_ADJ.Visible = False
        '
        'CHK_POS
        '
        Me.CHK_POS.BackColor = System.Drawing.Color.Transparent
        Me.CHK_POS.Location = New System.Drawing.Point(296, 104)
        Me.CHK_POS.Name = "CHK_POS"
        Me.CHK_POS.Size = New System.Drawing.Size(64, 24)
        Me.CHK_POS.TabIndex = 362
        Me.CHK_POS.Text = "POS"
        Me.CHK_POS.UseVisualStyleBackColor = False
        Me.CHK_POS.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(8, 240)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(392, 80)
        Me.Label2.TabIndex = 363
        Me.Label2.Text = "Kindly Don't Run the Weighted Average Without Proper Confirmation From your Senio" &
    "r Manager,Because Valuation Issue if Multiple UOM for Same Itemcode"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmstockissuerate
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(410, 330)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CHK_POS)
        Me.Controls.Add(Me.CHK_ADJ)
        Me.Controls.Add(Me.CHK_TFR)
        Me.Controls.Add(Me.chk_issue)
        Me.Controls.Add(Me.PBAR)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbl_KOTdate)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.Cmd_UPDATE)
        Me.Controls.Add(Me.dtp_TOdate)
        Me.Controls.Add(Me.dtp_FROMdate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmstockissuerate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WEIGHTED AVERAGE"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim gconnection As New GlobalClass
    Private Sub Cmd_UPDATE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UPDATE.Click
        Dim Opquantity, Opamount, Grnquantity, Grnamount As Double
        Dim Calquantity, Issuequantity, Issueamount, PURCHASERATE As Double
        Dim transferqty, transferamount As Double
        Dim adjustqty, adjustamount As Double
        Dim Calrate, Clsquantity As Double
        Dim sqlstring As String
        Dim INSERT(0) As String
        Dim opRate, grnRate, IssRate As Double

        Me.Cursor = Cursors.WaitCursor

        'Please Confirm the Procedure  Cp_WeightedAverage before enabling this below Line'
        'If the is single UOM for particular Item Then Ok,If Maintaining Multiple UOM[i.e Peg & Bottle] For Particular Item Plz  Confirm with Project Manager before Executing the procedure....

        'sqlstring = "exec Cp_WeightedAverage '" & Format(dtp_FROMdate.Value, "dd-MMM-yyyy") & "','" & Format(dtp_TOdate.Value, "dd-MMM-yyyy") & "'"
        'gconnection.getDataSet(sqlstring, "Cp_WeightedAverage")

        Me.Cursor = Cursors.Default

        Dim mm As Integer = 1
        If mm = 0 Then
            Dim i As Integer
            Dim dr As DataRow
            If chk_issue.Checked = True Then
                sqlstring = "SELECT * FROM STOCKISSUEDETAIL WHERE ISNULL(VOID,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),DOCDATE,6) AS DATETIME) BETWEEN '" & Format(dtp_FROMdate.Value, "dd-MMM-yyyy") & "' AND '" & Format(dtp_TOdate.Value, "dd-MMM-yyyy") & "' ORDER BY AUTOID"
                gconnection.getDataSet(sqlstring, "ISSUE")
                If gdataset.Tables.Contains("ISSUE") Then
                    If gdataset.Tables("ISSUE").Rows.Count > 0 Then
                        PBAR.Maximum = gdataset.Tables("ISSUE").Rows.Count
                        PBAR.Value = 0
                        For Each dr In gdataset.Tables("ISSUE").Rows
                            sqlstring = "SELECT ISNULL(PURCHASERATE,0) AS PURCHASERATE,ISNULL(OPSTOCK,0) AS OPSTOCK,ISNULL(OPVALUE,0) AS OPVALUE FROM INVENTORYITEMMASTER WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND STORECODE='MNS'"
                            gconnection.getDataSet(sqlstring, "INVENTORYITEM")
                            If gdataset.Tables("INVENTORYITEM").Rows.Count > 0 Then
                                Opquantity = Format(Val(gdataset.Tables("INVENTORYITEM").Rows(0).Item("OPSTOCK")), "0.000")
                                Opamount = Format(Val(gdataset.Tables("INVENTORYITEM").Rows(0).Item("OPVALUE")), "0.00")
                                PURCHASERATE = Format(Val(gdataset.Tables("INVENTORYITEM").Rows(0).Item("PURCHASERATE")), "0.00")
                            Else
                                Opquantity = 0
                                Opamount = 0
                                PURCHASERATE = 0
                            End If

                            sqlstring = "SELECT ISNULL(SUM(QTY),0) AS QTY ,ISNULL(SUM(AMOUNT),0) AS AMOUNT FROM GRN_DETAILS WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND ISNULL(VOIDITEM,'') <>'Y' AND CAST(CONVERT(VARCHAR(11),GRNDATE,6) AS DATETIME)<='" & Format(dr("DOCDATE"), "dd-MMM-yyyy") & "'"
                            gconnection.getDataSet(sqlstring, "GRN_DETAILS")
                            If gdataset.Tables("GRN_DETAILS").Rows.Count > 0 Then
                                Grnquantity = Format(Val(gdataset.Tables("GRN_DETAILS").Rows(0).Item("QTY")), "0.000")
                                Grnamount = Format(Val(gdataset.Tables("GRN_DETAILS").Rows(0).Item("AMOUNT")), "0.00")
                            Else
                                Grnquantity = 0
                                Grnamount = 0
                            End If

                            sqlstring = "SELECT ISNULL(SUM(QTY),0) AS QTY ,ISNULL(SUM(AMOUNT),0) AS AMOUNT FROM STOCKISSUEDETAIL WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND ISNULL(VOID,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),DOCDATE,6) AS DATETIME)<'" & Format(dr("DOCDATE"), "dd-MMM-yyyy") & "'"
                            gconnection.getDataSet(sqlstring, "STOCKISSUEDETAIL")
                            If gdataset.Tables("STOCKISSUEDETAIL").Rows.Count > 0 Then
                                Issuequantity = Format(Val(gdataset.Tables("STOCKISSUEDETAIL").Rows(0).Item("Qty")), "0.000")
                                Issueamount = Format(Val(gdataset.Tables("STOCKISSUEDETAIL").Rows(0).Item("AMOUNT")), "0.00")
                            Else
                                Issuequantity = 0
                                Issueamount = 0
                            End If

                            sqlstring = "SELECT ISNULL(SUM(ADJUSTEDSTOCK),0) AS QTY ,ISNULL(SUM(AMOUNT),0) AS AMOUNT FROM STOCKADJUSTDETAILS WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND ISNULL(VOID,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),DOCDATE,6) AS DATETIME)<'" & Format(dr("DOCDATE"), "dd-MMM-yyyy") & "'"
                            gconnection.getDataSet(sqlstring, "STOCKADJUSTDETAILS")
                            If gdataset.Tables("STOCKADJUSTDETAILS").Rows.Count > 0 Then
                                adjustqty = Format(Val(gdataset.Tables("STOCKADJUSTDETAILS").Rows(0).Item("Qty")), "0.000")
                                adjustamount = Format(Val(gdataset.Tables("STOCKADJUSTDETAILS").Rows(0).Item("AMOUNT")), "0.00")
                            Else
                                adjustqty = 0
                                adjustamount = 0
                            End If

                            sqlstring = "SELECT ISNULL(SUM(QTY),0) AS QTY ,ISNULL(SUM(AMOUNT),0) AS AMOUNT FROM STOCKtransferDETAIL WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND ISNULL(VOID,'')<>'Y' and doctype='RET' AND CAST(CONVERT(VARCHAR(11),DOCDATE,6) AS DATETIME)<'" & Format(dr("DOCDATE"), "dd-MMM-yyyy") & "'"
                            gconnection.getDataSet(sqlstring, "STOCKtransferDETAIL")
                            If gdataset.Tables("STOCKISSUEDETAIL").Rows.Count > 0 Then
                                transferqty = Format(Val(gdataset.Tables("STOCKtransferDETAIL").Rows(0).Item("Qty")), "0.000")
                                transferamount = Format(Val(gdataset.Tables("STOCKtransferDETAIL").Rows(0).Item("AMOUNT")), "0.00")
                            Else
                                transferqty = 0
                                transferamount = 0
                            End If
                            '                    Clsquantity = (Val(Opquantity) + Val(Grnquantity) + Val(adjustqty) - Val(Issuequantity) + Val(transferqty))

                            Clsquantity = (Val(Opquantity) + Val(Grnquantity))

                            If Clsquantity <= 0 Then
                                If Grnquantity <> 0 Then
                                    Calrate = Val(Grnamount) / Val(Grnquantity)
                                ElseIf Issuequantity <> 0 Then
                                    sqlstring = "SELECT TOP 1 ISNULL(RATE,0) RATE FROM STOCKISSUEDETAIL WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND ISNULL(VOID,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),DOCDATE,6) AS DATETIME)<'" & Format(dr("DOCDATE"), "dd-MMM-yyyy") & "'"
                                    gconnection.getDataSet(sqlstring, "STOCKISSUEDETAIL")
                                    If gdataset.Tables("STOCKISSUEDETAIL").Rows.Count > 0 Then
                                        Calrate = Format(Val(gdataset.Tables("STOCKISSUEDETAIL").Rows(0).Item("RATE")), "0.00")
                                    End If
                                Else
                                    sqlstring = "SELECT ISNULL(PURCHASERATE,0) PURCHASERATE FROM INVENTORYITEMMASTER WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND STORECODE='MNS'"
                                    gconnection.getDataSet(sqlstring, "INVENTORYITEM")
                                    If gdataset.Tables("INVENTORYITEM").Rows.Count > 0 Then
                                        Calrate = Format(Val(gdataset.Tables("INVENTORYITEM").Rows(0).Item("PURCHASERATE")), "0.00")
                                        If Calrate <= 0 Then
                                            Calrate = (Val(Opamount) + Val(Grnamount)) / (Val(Clsquantity))
                                        End If
                                    End If
                                End If
                            Else
                                Calrate = (Val(Opamount) + Val(Grnamount)) / (Val(Clsquantity))
                            End If


                            sqlstring = "UPDATE STOCKISSUEDETAIL SET RATE=" & Calrate & " WHERE AUTOID=" & dr("AUTOID")
                            ReDim Preserve INSERT(INSERT.Length)
                            INSERT(INSERT.Length - 1) = sqlstring
                            PBAR.Value = PBAR.Value + 1
                        Next
                        sqlstring = "UPDATE STOCKISSUEDETAIL SET AMOUNT=QTY*RATE WHERE CAST(CONVERT(VARCHAR(11),DOCDATE,6) AS DATETIME) BETWEEN '" & Format(dtp_FROMdate.Value, "dd-MMM-yyyy") & "' AND '" & Format(dtp_TOdate.Value, "dd-MMM-yyyy") & "'"
                        ReDim Preserve INSERT(INSERT.Length)
                        INSERT(INSERT.Length - 1) = sqlstring
                    End If
                End If
                PBAR.Value = 0
            End If

            If CHK_TFR.Checked = True Then
                sqlstring = "SELECT * FROM STOCKTRANSFERDETAIL WHERE ISNULL(VOID,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),DOCDATE,6) AS DATETIME) BETWEEN '" & Format(dtp_FROMdate.Value, "dd-MMM-yyyy") & "' AND '" & Format(dtp_TOdate.Value, "dd-MMM-yyyy") & "' ORDER BY AUTOID"
                gconnection.getDataSet(sqlstring, "transfer")
                If gdataset.Tables.Contains("transfer") Then
                    If gdataset.Tables("transfer").Rows.Count > 0 Then
                        PBAR.Maximum = gdataset.Tables("transfer").Rows.Count
                        PBAR.Value = 0
                        For Each dr In gdataset.Tables("transfer").Rows
                            sqlstring = "SELECT ISNULL(PURCHASERATE,0) AS PURCHASERATE,ISNULL(OPSTOCK,0) AS OPSTOCK,ISNULL(OPVALUE,0) AS OPVALUE FROM INVENTORYITEMMASTER WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND STORECODE='MNS'"
                            gconnection.getDataSet(sqlstring, "INVENTORYITEM")
                            If gdataset.Tables("INVENTORYITEM").Rows.Count > 0 Then
                                Opquantity = Format(Val(gdataset.Tables("INVENTORYITEM").Rows(0).Item("OPSTOCK")), "0.000")
                                Opamount = Format(Val(gdataset.Tables("INVENTORYITEM").Rows(0).Item("OPVALUE")), "0.00")
                                PURCHASERATE = Format(Val(gdataset.Tables("INVENTORYITEM").Rows(0).Item("PURCHASERATE")), "0.00")
                            Else
                                Opquantity = 0
                                Opamount = 0
                                PURCHASERATE = 0
                            End If
                            sqlstring = "SELECT ISNULL(SUM(QTY),0) AS QTY ,ISNULL(SUM(AMOUNT),0) AS AMOUNT FROM GRN_DETAILS WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND ISNULL(VOIDITEM,'') <>'Y' AND CAST(CONVERT(VARCHAR(11),GRNDATE,6) AS DATETIME)<='" & Format(dr("DOCDATE"), "dd-MMM-yyyy") & "'"
                            gconnection.getDataSet(sqlstring, "GRN_DETAILS")
                            If gdataset.Tables("GRN_DETAILS").Rows.Count > 0 Then
                                Grnquantity = Format(Val(gdataset.Tables("GRN_DETAILS").Rows(0).Item("QTY")), "0.000")
                                Grnamount = Format(Val(gdataset.Tables("GRN_DETAILS").Rows(0).Item("AMOUNT")), "0.00")
                            Else
                                Grnquantity = 0
                                Grnamount = 0
                            End If

                            sqlstring = "SELECT ISNULL(SUM(QTY),0) AS QTY ,ISNULL(SUM(AMOUNT),0) AS AMOUNT FROM STOCKISSUEDETAIL WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND ISNULL(VOID,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),DOCDATE,6) AS DATETIME)<'" & Format(dr("DOCDATE"), "dd-MMM-yyyy") & "'"
                            gconnection.getDataSet(sqlstring, "STOCKISSUEDETAIL")
                            If gdataset.Tables("STOCKISSUEDETAIL").Rows.Count > 0 Then
                                Issuequantity = Format(Val(gdataset.Tables("STOCKISSUEDETAIL").Rows(0).Item("Qty")), "0.000")
                                Issueamount = Format(Val(gdataset.Tables("STOCKISSUEDETAIL").Rows(0).Item("AMOUNT")), "0.00")
                            Else
                                Issuequantity = 0
                                Issueamount = 0
                            End If

                            sqlstring = "SELECT ISNULL(SUM(ADJUSTEDSTOCK),0) AS QTY ,ISNULL(SUM(AMOUNT),0) AS AMOUNT FROM STOCKADJUSTDETAILS WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND ISNULL(VOID,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),DOCDATE,6) AS DATETIME)<'" & Format(dr("DOCDATE"), "dd-MMM-yyyy") & "'"
                            gconnection.getDataSet(sqlstring, "STOCKADJUSTDETAILS")
                            If gdataset.Tables("STOCKADJUSTDETAILS").Rows.Count > 0 Then
                                adjustqty = Format(Val(gdataset.Tables("STOCKADJUSTDETAILS").Rows(0).Item("Qty")), "0.000")
                                adjustamount = Format(Val(gdataset.Tables("STOCKADJUSTDETAILS").Rows(0).Item("AMOUNT")), "0.00")
                            Else
                                adjustqty = 0
                                adjustamount = 0
                            End If

                            sqlstring = "SELECT ISNULL(SUM(QTY),0) AS QTY ,ISNULL(SUM(AMOUNT),0) AS AMOUNT FROM STOCKtransferDETAIL WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND ISNULL(VOID,'')<>'Y' AND AUTOID<" & dr("AUTOID") & ""
                            gconnection.getDataSet(sqlstring, "STOCKtransferDETAIL")
                            If gdataset.Tables("STOCKISSUEDETAIL").Rows.Count > 0 Then
                                transferqty = Format(Val(gdataset.Tables("STOCKtransferDETAIL").Rows(0).Item("Qty")), "0.000")
                                transferamount = Format(Val(gdataset.Tables("STOCKtransferDETAIL").Rows(0).Item("AMOUNT")), "0.00")
                            Else
                                transferqty = 0
                                transferamount = 0
                            End If
                            '                    Clsquantity = (Val(Opquantity) + Val(Grnquantity) + Val(adjustqty) - Val(Issuequantity) + Val(transferqty))

                            Clsquantity = (Val(Opquantity) + Val(Grnquantity))

                            If Clsquantity = 0 Then
                                If Grnquantity <> 0 Then
                                    Calrate = Val(Grnamount) / Val(Grnquantity)
                                ElseIf Issuequantity <> 0 Then
                                    sqlstring = "SELECT TOP 1 ISNULL(RATE,0) RATE FROM STOCKISSUEDETAIL WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND ISNULL(VOID,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),DOCDATE,6) AS DATETIME)<'" & Format(dr("DOCDATE"), "dd-MMM-yyyy") & "'"
                                    gconnection.getDataSet(sqlstring, "STOCKISSUEDETAIL")
                                    If gdataset.Tables("STOCKISSUEDETAIL").Rows.Count > 0 Then
                                        Calrate = Format(Val(gdataset.Tables("STOCKISSUEDETAIL").Rows(0).Item("RATE")), "0.00")
                                    End If
                                Else
                                    sqlstring = "SELECT ISNULL(PURCHASERATE,0) PURCHASERATE FROM INVENTORYITEMMASTER WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND STORECODE='MNS'"
                                    gconnection.getDataSet(sqlstring, "INVENTORYITEM")
                                    If gdataset.Tables("INVENTORYITEM").Rows.Count > 0 Then
                                        Calrate = Format(Val(gdataset.Tables("INVENTORYITEM").Rows(0).Item("PURCHASERATE")), "0.00")

                                    End If
                                End If
                            Else
                                Calrate = (Val(Opamount) + Val(Grnamount)) / (Val(Clsquantity))
                            End If

                            sqlstring = "UPDATE STOCKTRANSFERDETAIL SET RATE=" & Calrate & " WHERE AUTOID=" & dr("AUTOID")
                            ReDim Preserve INSERT(INSERT.Length)
                            INSERT(INSERT.Length - 1) = sqlstring
                            PBAR.Value = PBAR.Value + 1
                        Next
                        sqlstring = "UPDATE STOCKTRANSFERDETAIL SET AMOUNT=QTY*RATE WHERE CAST(CONVERT(VARCHAR(11),DOCDATE,6) AS DATETIME) BETWEEN '" & Format(dtp_FROMdate.Value, "dd-MMM-yyyy") & "' AND '" & Format(dtp_TOdate.Value, "dd-MMM-yyyy") & "'"
                        ReDim Preserve INSERT(INSERT.Length)
                        INSERT(INSERT.Length - 1) = sqlstring
                    End If
                End If
                PBAR.Value = 0
            End If

            If CHK_ADJ.Checked = True Then
                sqlstring = "SELECT * FROM STOCKADJUSTDETAILS WHERE ISNULL(VOID,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),DOCDATE,6) AS DATETIME) BETWEEN '" & Format(dtp_FROMdate.Value, "dd-MMM-yyyy") & "' AND '" & Format(dtp_TOdate.Value, "dd-MMM-yyyy") & "' ORDER BY AUTOID"
                gconnection.getDataSet(sqlstring, "adjust")
                If gdataset.Tables.Contains("adjust") Then
                    If gdataset.Tables("adjust").Rows.Count > 0 Then
                        PBAR.Maximum = gdataset.Tables("adjust").Rows.Count
                        PBAR.Value = 0
                        For Each dr In gdataset.Tables("adjust").Rows
                            sqlstring = "SELECT ISNULL(PURCHASERATE,0) AS PURCHASERATE,ISNULL(OPSTOCK,0) AS OPSTOCK,ISNULL(OPVALUE,0) AS OPVALUE FROM INVENTORYITEMMASTER WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND STORECODE='MNS'"
                            gconnection.getDataSet(sqlstring, "INVENTORYITEM")
                            If gdataset.Tables("INVENTORYITEM").Rows.Count > 0 Then
                                Opquantity = Format(Val(gdataset.Tables("INVENTORYITEM").Rows(0).Item("OPSTOCK")), "0.000")
                                Opamount = Format(Val(gdataset.Tables("INVENTORYITEM").Rows(0).Item("OPVALUE")), "0.00")
                                PURCHASERATE = Format(Val(gdataset.Tables("INVENTORYITEM").Rows(0).Item("PURCHASERATE")), "0.00")
                            Else
                                Opquantity = 0
                                Opamount = 0
                                PURCHASERATE = 0
                            End If
                            sqlstring = "SELECT ISNULL(SUM(QTY),0) AS QTY ,ISNULL(SUM(AMOUNT),0) AS AMOUNT FROM GRN_DETAILS WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND ISNULL(VOIDITEM,'') <>'Y' AND CAST(CONVERT(VARCHAR(11),GRNDATE,6) AS DATETIME)<='" & Format(dr("DOCDATE"), "dd-MMM-yyyy") & "'"
                            gconnection.getDataSet(sqlstring, "GRN_DETAILS")
                            If gdataset.Tables("GRN_DETAILS").Rows.Count > 0 Then
                                Grnquantity = Format(Val(gdataset.Tables("GRN_DETAILS").Rows(0).Item("QTY")), "0.000")
                                Grnamount = Format(Val(gdataset.Tables("GRN_DETAILS").Rows(0).Item("AMOUNT")), "0.00")
                            Else
                                Grnquantity = 0
                                Grnamount = 0
                            End If

                            sqlstring = "SELECT ISNULL(SUM(QTY),0) AS QTY ,ISNULL(SUM(AMOUNT),0) AS AMOUNT FROM STOCKISSUEDETAIL WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND ISNULL(VOID,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),DOCDATE,6) AS DATETIME)<'" & Format(dr("DOCDATE"), "dd-MMM-yyyy") & "'"
                            gconnection.getDataSet(sqlstring, "STOCKISSUEDETAIL")
                            If gdataset.Tables("STOCKISSUEDETAIL").Rows.Count > 0 Then
                                Issuequantity = Format(Val(gdataset.Tables("STOCKISSUEDETAIL").Rows(0).Item("Qty")), "0.000")
                                Issueamount = Format(Val(gdataset.Tables("STOCKISSUEDETAIL").Rows(0).Item("AMOUNT")), "0.00")
                            Else
                                Issuequantity = 0
                                Issueamount = 0
                            End If

                            sqlstring = "SELECT ISNULL(SUM(ADJUSTEDSTOCK),0) AS QTY ,ISNULL(SUM(AMOUNT),0) AS AMOUNT FROM STOCKADJUSTDETAILS WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND ISNULL(VOID,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),DOCDATE,6) AS DATETIME)<'" & Format(dr("DOCDATE"), "dd-MMM-yyyy") & "'"
                            gconnection.getDataSet(sqlstring, "STOCKADJUSTDETAILS")
                            If gdataset.Tables("STOCKADJUSTDETAILS").Rows.Count > 0 Then
                                adjustqty = Format(Val(gdataset.Tables("STOCKADJUSTDETAILS").Rows(0).Item("Qty")), "0.000")
                                adjustamount = Format(Val(gdataset.Tables("STOCKADJUSTDETAILS").Rows(0).Item("AMOUNT")), "0.00")
                            Else
                                adjustqty = 0
                                adjustamount = 0
                            End If

                            sqlstring = "SELECT ISNULL(SUM(QTY),0) AS QTY ,ISNULL(SUM(AMOUNT),0) AS AMOUNT FROM STOCKtransferDETAIL WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND ISNULL(VOID,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),DOCDATE,6) AS DATETIME)<'" & Format(dr("DOCDATE"), "dd-MMM-yyyy") & "'"
                            gconnection.getDataSet(sqlstring, "STOCKtransferDETAIL")
                            If gdataset.Tables("STOCKISSUEDETAIL").Rows.Count > 0 Then
                                transferqty = Format(Val(gdataset.Tables("STOCKtransferDETAIL").Rows(0).Item("Qty")), "0.000")
                                transferamount = Format(Val(gdataset.Tables("STOCKtransferDETAIL").Rows(0).Item("AMOUNT")), "0.00")
                            Else
                                transferqty = 0
                                transferamount = 0
                            End If
                            '                    Clsquantity = (Val(Opquantity) + Val(Grnquantity) + Val(adjustqty) - Val(Issuequantity) + Val(transferqty))
                            Clsquantity = (Val(Opquantity) + Val(Grnquantity))

                            If Clsquantity <= 0 Then
                                If Grnquantity <> 0 Then
                                    Calrate = Val(Grnamount) / Val(Grnquantity)
                                ElseIf Issuequantity <> 0 Then
                                    sqlstring = "SELECT TOP 1 ISNULL(RATE,0) RATE FROM STOCKISSUEDETAIL WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND ISNULL(VOID,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),DOCDATE,6) AS DATETIME)<'" & Format(dr("DOCDATE"), "dd-MMM-yyyy") & "'"
                                    gconnection.getDataSet(sqlstring, "STOCKISSUEDETAIL")
                                    If gdataset.Tables("STOCKISSUEDETAIL").Rows.Count > 0 Then
                                        Calrate = Format(Val(gdataset.Tables("STOCKISSUEDETAIL").Rows(0).Item("RATE")), "0.00")
                                    End If
                                Else
                                    sqlstring = "SELECT ISNULL(PURCHASERATE,0) PURCHASERATE FROM INVENTORYITEMMASTER WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND STORECODE='MNS'"
                                    gconnection.getDataSet(sqlstring, "INVENTORYITEM")
                                    If gdataset.Tables("INVENTORYITEM").Rows.Count > 0 Then
                                        Calrate = Format(Val(gdataset.Tables("INVENTORYITEM").Rows(0).Item("PURCHASERATE")), "0.00")
                                    End If
                                End If
                            Else
                                Calrate = (Val(Opamount) + Val(Grnamount)) / (Val(Clsquantity))
                            End If

                            sqlstring = "UPDATE STOCKADJUSTDETAILS SET RATE=" & Calrate & " WHERE AUTOID=" & dr("AUTOID")
                            ReDim Preserve INSERT(INSERT.Length)
                            INSERT(INSERT.Length - 1) = sqlstring
                            PBAR.Value = PBAR.Value + 1
                        Next
                        sqlstring = "UPDATE STOCKADJUSTDETAILS SET AMOUNT=ADJUSTEDSTOCK*RATE WHERE CAST(CONVERT(VARCHAR(11),DOCDATE,6) AS DATETIME) BETWEEN '" & Format(dtp_FROMdate.Value, "dd-MMM-yyyy") & "' AND '" & Format(dtp_TOdate.Value, "dd-MMM-yyyy") & "'"
                        ReDim Preserve INSERT(INSERT.Length)
                        INSERT(INSERT.Length - 1) = sqlstring
                    End If
                End If
                PBAR.Value = 0
            End If

            If CHK_POS.Checked = True Then
                sqlstring = "SELECT * FROM substoreconsumptiondetail WHERE ISNULL(VOID,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),DOCDATE,6) AS DATETIME) BETWEEN '" & Format(dtp_FROMdate.Value, "dd-MMM-yyyy") & "' AND '" & Format(dtp_TOdate.Value, "dd-MMM-yyyy") & "' ORDER BY AUTOID"
                gconnection.getDataSet(sqlstring, "adjust")
                If gdataset.Tables.Contains("adjust") Then
                    If gdataset.Tables("adjust").Rows.Count > 0 Then
                        PBAR.Maximum = gdataset.Tables("adjust").Rows.Count
                        PBAR.Value = 0
                        For Each dr In gdataset.Tables("adjust").Rows
                            sqlstring = "SELECT ISNULL(PURCHASERATE,0) AS PURCHASERATE,ISNULL(OPSTOCK,0) AS OPSTOCK,ISNULL(OPVALUE,0) AS OPVALUE FROM INVENTORYITEMMASTER WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND STORECODE='MNS'"
                            gconnection.getDataSet(sqlstring, "INVENTORYITEM")
                            If gdataset.Tables("INVENTORYITEM").Rows.Count > 0 Then
                                Opquantity = Format(Val(gdataset.Tables("INVENTORYITEM").Rows(0).Item("OPSTOCK")), "0.000")
                                Opamount = Format(Val(gdataset.Tables("INVENTORYITEM").Rows(0).Item("OPVALUE")), "0.00")
                                PURCHASERATE = Format(Val(gdataset.Tables("INVENTORYITEM").Rows(0).Item("PURCHASERATE")), "0.00")
                            Else
                                Opquantity = 0
                                Opamount = 0
                                PURCHASERATE = 0
                            End If
                            sqlstring = "SELECT ISNULL(SUM(QTY),0) AS QTY ,ISNULL(SUM(AMOUNT),0) AS AMOUNT FROM GRN_DETAILS WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND ISNULL(VOIDITEM,'') <>'Y' AND CAST(CONVERT(VARCHAR(11),GRNDATE,6) AS DATETIME)<='" & Format(dr("DOCDATE"), "dd-MMM-yyyy") & "'"
                            gconnection.getDataSet(sqlstring, "GRN_DETAILS")
                            If gdataset.Tables("GRN_DETAILS").Rows.Count > 0 Then
                                Grnquantity = Format(Val(gdataset.Tables("GRN_DETAILS").Rows(0).Item("QTY")), "0.000")
                                Grnamount = Format(Val(gdataset.Tables("GRN_DETAILS").Rows(0).Item("AMOUNT")), "0.00")
                            Else
                                Grnquantity = 0
                                Grnamount = 0
                            End If

                            sqlstring = "SELECT ISNULL(SUM(QTY),0) AS QTY ,ISNULL(SUM(AMOUNT),0) AS AMOUNT FROM STOCKISSUEDETAIL WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND ISNULL(VOID,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),DOCDATE,6) AS DATETIME)<'" & Format(dr("DOCDATE"), "dd-MMM-yyyy") & "'"
                            gconnection.getDataSet(sqlstring, "STOCKISSUEDETAIL")
                            If gdataset.Tables("STOCKISSUEDETAIL").Rows.Count > 0 Then
                                Issuequantity = Format(Val(gdataset.Tables("STOCKISSUEDETAIL").Rows(0).Item("Qty")), "0.000")
                                Issueamount = Format(Val(gdataset.Tables("STOCKISSUEDETAIL").Rows(0).Item("AMOUNT")), "0.00")
                            Else
                                Issuequantity = 0
                                Issueamount = 0
                            End If

                            sqlstring = "SELECT ISNULL(SUM(ADJUSTEDSTOCK),0) AS QTY ,ISNULL(SUM(AMOUNT),0) AS AMOUNT FROM STOCKADJUSTDETAILS WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND ISNULL(VOID,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),DOCDATE,6) AS DATETIME)<'" & Format(dr("DOCDATE"), "dd-MMM-yyyy") & "'"
                            gconnection.getDataSet(sqlstring, "STOCKADJUSTDETAILS")
                            If gdataset.Tables("STOCKADJUSTDETAILS").Rows.Count > 0 Then
                                adjustqty = Format(Val(gdataset.Tables("STOCKADJUSTDETAILS").Rows(0).Item("Qty")), "0.000")
                                adjustamount = Format(Val(gdataset.Tables("STOCKADJUSTDETAILS").Rows(0).Item("AMOUNT")), "0.00")
                            Else
                                adjustqty = 0
                                adjustamount = 0
                            End If

                            sqlstring = "SELECT ISNULL(SUM(QTY),0) AS QTY ,ISNULL(SUM(AMOUNT),0) AS AMOUNT FROM STOCKtransferDETAIL WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND ISNULL(VOID,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),DOCDATE,6) AS DATETIME)<'" & Format(dr("DOCDATE"), "dd-MMM-yyyy") & "'"
                            gconnection.getDataSet(sqlstring, "STOCKtransferDETAIL")
                            If gdataset.Tables("STOCKISSUEDETAIL").Rows.Count > 0 Then
                                transferqty = Format(Val(gdataset.Tables("STOCKtransferDETAIL").Rows(0).Item("Qty")), "0.000")
                                transferamount = Format(Val(gdataset.Tables("STOCKtransferDETAIL").Rows(0).Item("AMOUNT")), "0.00")
                            Else
                                transferqty = 0
                                transferamount = 0
                            End If
                            '                    Clsquantity = (Val(Opquantity) + Val(Grnquantity) + Val(adjustqty) - Val(Issuequantity) + Val(transferqty))
                            Clsquantity = (Val(Opquantity) + Val(Grnquantity))

                            If Clsquantity <= 0 Then
                                If Grnquantity <> 0 Then
                                    Calrate = Val(Grnamount) / Val(Grnquantity)
                                ElseIf Issuequantity <> 0 Then
                                    sqlstring = "SELECT TOP 1 ISNULL(RATE,0) RATE FROM STOCKISSUEDETAIL WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND ISNULL(VOID,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),DOCDATE,6) AS DATETIME)<'" & Format(dr("DOCDATE"), "dd-MMM-yyyy") & "'"
                                    gconnection.getDataSet(sqlstring, "STOCKISSUEDETAIL")
                                    If gdataset.Tables("STOCKISSUEDETAIL").Rows.Count > 0 Then
                                        Calrate = Format(Val(gdataset.Tables("STOCKISSUEDETAIL").Rows(0).Item("RATE")), "0.00")
                                    End If
                                Else
                                    sqlstring = "SELECT ISNULL(PURCHASERATE,0) PURCHASERATE FROM INVENTORYITEMMASTER WHERE ITEMCODE='" & dr("ITEMCODE") & "' AND STORECODE='MNS'"
                                    gconnection.getDataSet(sqlstring, "INVENTORYITEM")
                                    If gdataset.Tables("INVENTORYITEM").Rows.Count > 0 Then
                                        Calrate = Format(Val(gdataset.Tables("INVENTORYITEM").Rows(0).Item("PURCHASERATE")), "0.00")
                                    End If
                                End If
                            Else
                                Calrate = (Val(Opamount) + Val(Grnamount)) / (Val(Clsquantity))
                            End If

                            sqlstring = "UPDATE substoreconsumptiondetail SET RATE=" & Calrate & " WHERE AUTOID=" & dr("AUTOID")
                            ReDim Preserve INSERT(INSERT.Length)
                            INSERT(INSERT.Length - 1) = sqlstring
                            PBAR.Value = PBAR.Value + 1
                        Next
                        sqlstring = "UPDATE substoreconsumptiondetail SET AMOUNT=QTY*RATE WHERE CAST(CONVERT(VARCHAR(11),DOCDATE,6) AS DATETIME) BETWEEN '" & Format(dtp_FROMdate.Value, "dd-MMM-yyyy") & "' AND '" & Format(dtp_TOdate.Value, "dd-MMM-yyyy") & "'"
                        ReDim Preserve INSERT(INSERT.Length)
                        INSERT(INSERT.Length - 1) = sqlstring
                    End If
                End If
                PBAR.Value = 0
            End If

            gconnection.MoreTrans(INSERT)
        End If

        MsgBox("Weighted Average Completed...", MsgBoxStyle.OKOnly, "Weighted Average")
        cmd_exit_Click(sender, e)
    End Sub
    Private Sub cmd_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Me.Close()
    End Sub
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

    Private Sub frmstockissuerate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtp_FROMdate.Value = CDate("01/04/" & Trim(gFinancalyearStart))
        dtp_TOdate.Value = CDate("31/03/" & Trim(gFinancialyearEnd))
    End Sub
End Class
