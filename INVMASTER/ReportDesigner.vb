Imports System.Data.SqlClient
Imports System.IO
Public Class ReportDesigner
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
    Friend WithEvents lbl_Heading As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SsGridReport As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Print As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents lbl_caption As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportDesigner))
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SsGridReport = New AxFPSpreadADO.AxfpSpread()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Print = New System.Windows.Forms.Button()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.lbl_caption = New System.Windows.Forms.Label()
        CType(Me.SsGridReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.Color.White
        Me.lbl_Heading.Location = New System.Drawing.Point(264, 8)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(210, 24)
        Me.lbl_Heading.TabIndex = 4
        Me.lbl_Heading.Text = "REPORT DESIGNER"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.BackgroundImage = CType(resources.GetObject("GroupBox1.BackgroundImage"), System.Drawing.Image)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 335)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(13, 26)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'SsGridReport
        '
        Me.SsGridReport.DataSource = Nothing
        Me.SsGridReport.Location = New System.Drawing.Point(48, 48)
        Me.SsGridReport.Name = "SsGridReport"
        Me.SsGridReport.OcxState = CType(resources.GetObject("SsGridReport.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SsGridReport.Size = New System.Drawing.Size(672, 264)
        Me.SsGridReport.TabIndex = 3
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_View.Location = New System.Drawing.Point(133, 351)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(165, 37)
        Me.Cmd_View.TabIndex = 0
        Me.Cmd_View.Text = "&View[F10]"
        Me.Cmd_View.UseVisualStyleBackColor = False
        '
        'Cmd_Print
        '
        Me.Cmd_Print.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Print.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Print.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Print.Location = New System.Drawing.Point(310, 351)
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(165, 37)
        Me.Cmd_Print.TabIndex = 1
        Me.Cmd_Print.Text = "&Print[F11]"
        Me.Cmd_Print.UseVisualStyleBackColor = False
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Exit.Location = New System.Drawing.Point(480, 351)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(165, 37)
        Me.Cmd_Exit.TabIndex = 2
        Me.Cmd_Exit.Text = "&Exit[F12]"
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'lbl_caption
        '
        Me.lbl_caption.AutoSize = True
        Me.lbl_caption.BackColor = System.Drawing.Color.Transparent
        Me.lbl_caption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_caption.Location = New System.Drawing.Point(48, 318)
        Me.lbl_caption.Name = "lbl_caption"
        Me.lbl_caption.Size = New System.Drawing.Size(309, 15)
        Me.lbl_caption.TabIndex = 6
        Me.lbl_caption.Text = "Note : Press F2 for Select All / Press F3 to Deselect all"
        '
        'ReportDesigner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(774, 395)
        Me.Controls.Add(Me.Cmd_View)
        Me.Controls.Add(Me.Cmd_Print)
        Me.Controls.Add(Me.lbl_caption)
        Me.Controls.Add(Me.Cmd_Exit)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.SsGridReport)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.Name = "ReportDesigner"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MASTER [ CHECKLIST ]"
        CType(Me.SsGridReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Public pageno, pagesize, intDataRowCount As Integer
    Dim gconnection As New GlobalClass
    Dim Colomns As String

    'For Report Class 
    'MkKannan
    'Begin
    Dim strColumnsLen, strColumns, strCaption, strType As String
    'End

    Dim checkbool As Boolean
    Dim sizes As String
    Dim dr As DataRow
    Public Sub checkvalidation()
        Dim i, j As Integer
        Dim boolOrder As Boolean
        Dim getcheck, GETCHECK1, GETCHECK2 As Object
        Dim vaildOrderby As String
        checkbool = True : boolOrder = False
        For i = 1 To Me.SsGridReport.DataRowCnt
            SsGridReport.Col = 1
            SsGridReport.Row = i
            getcheck = Trim(SsGridReport.Text)
            If Val(getcheck) = 1 Then
                SsGridReport.Col = 5
                SsGridReport.Row = i
                If Trim(SsGridReport.Text) = "" Then
                    checkbool = True
                    Exit Sub
                End If
            End If
        Next i
        For i = 1 To Me.SsGridReport.DataRowCnt
            SsGridReport.Col = 1
            SsGridReport.Row = i
            getcheck = Trim(SsGridReport.Text)
            If Val(getcheck) = 1 Then
                SsGridReport.Col = 5
                SsGridReport.Row = i
                If Trim(SsGridReport.Text) <> "" Then
                    vaildOrderby = Trim(SsGridReport.Text)
                    For j = 1 To Me.SsGridReport.DataRowCnt
                        SsGridReport.Col = 1
                        SsGridReport.Row = j
                        GETCHECK1 = Trim(SsGridReport.Text)
                        If Val(GETCHECK1) = 1 Then
                            SsGridReport.Col = 2
                            SsGridReport.Row = j
                            If Trim(SsGridReport.Text) = vaildOrderby Then
                                boolOrder = True
                                Exit For
                            Else
                                boolOrder = False
                            End If
                        End If
                    Next j
                End If
            End If
        Next i
        If boolOrder = False Then
            MessageBox.Show("Plz Enter a valid column", gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            SsGridReport.ClearRange(5, 1, 5, -1, True)
            SsGridReport.SetActiveCell(5, SsGridReport.ActiveRow)
            SsGridReport.Focus()
            checkbool = False
            Exit Sub
        End If
        checkbool = True
    End Sub
    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click
        gPrint = False
        Call subReport()
    End Sub
    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click
        'Dim chk As Boolean
        'Dim getcheck As Object
        'Dim i, j, cnt, totsize As Integer
        'Dim Col, tab, ssql, Size, Caption, Order As String
        'i = 1 : j = 1 : cnt = 0
        'Call checkvalidation()
        'If checkbool = False Then Exit Sub
        'For i = 1 To Me.SsGridReport.DataRowCnt
        '    SsGridReport.Col = 1
        '    SsGridReport.Row = i
        '    getcheck = Trim(SsGridReport.Text)
        '    If Val(getcheck) = 1 Then
        '        If Colomns = "" Then
        '            SsGridReport.Col = 2
        '            SsGridReport.Row = i
        '            Col = Trim(SsGridReport.Text)
        '            SsGridReport.Col = 3
        '            SsGridReport.Row = i
        '            Size = Val(SsGridReport.Text)
        '            totsize = totsize + Val(SsGridReport.Text)
        '            Colomns = Col
        '            Col = ""
        '            cnt = cnt + 1
        '        Else
        '            SsGridReport.Col = 2
        '            SsGridReport.Row = i
        '            Col = Trim(SsGridReport.Text)
        '            Colomns = Colomns & "," & Col
        '            SsGridReport.Col = 3
        '            SsGridReport.Row = i
        '            totsize = totsize + Val(SsGridReport.Text) + 1
        '            Size = Size & "," & Trim(SsGridReport.Text)
        '            Col = ""
        '            cnt = cnt + 1
        '        End If
        '    End If
        '    getcheck = ""
        'Next i
        'If Colomns = "" Then
        '    MessageBox.Show("No Fields Has Been Selected", gCompanyname, MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        '    Exit Sub
        'End If
        'If tables = "" Then
        '    MessageBox.Show("Table Name not found", gCompanyname, MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        '    Exit Sub
        'End If
        'For i = 1 To Me.SsGridReport.DataRowCnt
        '    SsGridReport.Col = 1
        '    SsGridReport.Row = i
        '    getcheck = Trim(SsGridReport.Text)
        '    If Val(getcheck) = 1 Then
        '        SsGridReport.Col = 4
        '        SsGridReport.Row = i
        '        If Trim(SsGridReport.Text) = "" Then
        '            SsGridReport.Col = 2
        '            SsGridReport.Row = i
        '            Caption = Caption & "," & Trim(SsGridReport.Text)
        '        Else
        '            SsGridReport.Col = 4
        '            SsGridReport.Row = i
        '            Caption = Caption & "," & Trim(SsGridReport.Text)
        '        End If
        '    End If
        'Next i
        'For i = 1 To Me.SsGridReport.DataRowCnt
        '    SsGridReport.Col = 1
        '    SsGridReport.Row = i
        '    getcheck = Trim(SsGridReport.Text)
        '    If Val(getcheck) = 1 Then
        '        SsGridReport.Col = 5
        '        SsGridReport.Row = i
        '        If Trim(SsGridReport.Text) <> "" Then
        '            SsGridReport.Col = 5
        '            SsGridReport.Row = i
        '            Order = Order & "," & Trim(SsGridReport.Text)
        '        End If
        '    End If
        'Next i
        'If Mid(Order, 1, 1) = "," Then
        '    Order = Mid(Order, 2, Len(Order))
        'End If
        'If Order = "" Then
        '    For i = 1 To Me.SsGridReport.DataRowCnt
        '        SsGridReport.Col = 1
        '        SsGridReport.Row = i
        '        getcheck = Trim(SsGridReport.Text)
        '        If Val(getcheck) = 1 Then
        '            SsGridReport.Col = 2
        '            SsGridReport.Row = i
        '            If Trim(SsGridReport.Text) <> "" Then
        '                SsGridReport.Col = 2
        '                SsGridReport.Row = i
        '                Order = Order & "," & Trim(SsGridReport.Text)
        '            End If
        '        End If
        '    Next i
        'End If
        'If Mid(Order, 1, 1) = "," Then
        '    Order = Mid(Order, 2, Len(Order))
        'End If
        'If Mid(Caption, 1, 1) = "," Then
        '    Caption = Mid(Caption, 2, Len(Caption))
        'End If
        'ssql = " SELECT " & Colomns & tables & " ORDER BY " & Order
        'Colomns = ""
        gPrint = True
        Call subReport()
        'Call PrintOperation(ssql, Size, Caption, totsize, cnt, Order)
    End Sub
    Sub PrintOperation(ByVal sql As String, ByVal size As String, ByVal caption As String, ByVal totsize As Integer, ByVal cnt As Integer, ByVal Order As String)
        Dim Fsize(), Forder(), vFilepath, Itemcode, Array() As String
        Dim rowj, Loopindex, i, count, CountItem, Fo As Integer
        Dim ssql, vCaption, vPath, str As String
        Dim vOutfile, vheader, vline As String
        Dim ds As New DataSet
        Dim Filewrite As StreamWriter
        Dim vpagenumber, Vrowcount As Long
        Try
            pagesize = 0
            pageno = 1
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            vFilepath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(vFilepath)
            printfile = vFilepath
            If Trim(Order) <> "" Then
                Forder = Order.Split(",")
                Forder.Sort(Forder)
                Order = ""
            End If
            gconnection.getDataSet(sql, "REPORTTABLE")
            If gdataset.Tables("REPORTTABLE").Rows.Count > 0 Then
                Filewrite.Write(Chr(15))
                Filewrite.WriteLine("{0,60}{1,15}{2,10}", Chr(14) & Chr(15) & " ", "PRINTED ON : ", Format(Now, "dd/MMM/yyyy"))
                pagesize = pagesize + 1
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(gCompanyname, 1, 30), " ", "ACCOUNTING PERIOD")
                pagesize = pagesize + 1
                Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}{3,-25}{4,-24}", Mid(gCompanyAddress(0), 1, 30), " ", Mid(Trim(Gheader & " " & "[ DETAILS ]"), 1, 30), " ", "01-04-" & gFinancalyearStart & " TO 31-03-" & gFinancialyearEnd)
                pagesize = pagesize + 1
                Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}", Mid(gCompanyAddress(1), 1, 30), " ", Mid(StrDup(Len(Trim(Gheader & " " & "[ DETAILS ]")), "-"), 1, 30))
                pagesize = pagesize + 1
                Filewrite.WriteLine("{0,64}{1,-10}", " ", "SUMMARY")
                pagesize = pagesize + 1
                Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE : " & pageno)
                pagesize = pagesize + 1
                Filewrite.WriteLine("{0,-30}{1,87}{2,16}", Format(Now, "MMM dd,yyyy") & " " & "To" & " " & Format(Now, "MMM dd,yyyy"), " ", "ACCOUNT MASTER")
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(135, "-"))
                pagesize = pagesize + 1
                Array = caption.Split(",")
                Fsize = size.Split(",")
                For count = 0 To Array.Length - 1
                    ssql = ssql & Mid(Trim(Array(count) & ""), 1, Val(Fsize(count))) & Space(Val(Fsize(count) + 1) - Len(Mid(Trim(Array(count) & ""), 1, Val(Fsize(count)))))
                Next
                Filewrite.WriteLine(ssql)
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(135, "-"))
                pagesize = pagesize + 1
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                For rowj = 0 To gdataset.Tables("REPORTTABLE").Rows.Count - 1
                    If pagesize > 58 Then
                        Filewrite.Write(StrDup(135, "-"))
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        pagesize = 0
                        Filewrite.WriteLine("{0,60}{1,15}{2,10}", Chr(14) & Chr(15) & " ", "PRINTED ON : ", Format(Now, "dd/MMM/yyyy"))
                        pagesize = pagesize + 1
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                        Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(gCompanyname, 1, 30), " ", "ACCOUNTING PERIOD")
                        pagesize = pagesize + 1
                        Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}{3,-25}{4,-24}", Mid(gCompanyAddress(0), 1, 30), " ", Mid(Trim(Gheader & " " & "[ DETAILS ]"), 1, 30), " ", "01-04-" & gFinancalyearStart & " TO 31-03-" & gFinancialyearEnd)
                        pagesize = pagesize + 1
                        Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}", Mid(gCompanyAddress(1), 1, 30), " ", Mid(StrDup(Len(Trim(Gheader & " " & "[ DETAILS ]")), "-"), 1, 30))
                        pagesize = pagesize + 1
                        Filewrite.WriteLine("{0,64}{1,-10}", " ", "SUMMARY")
                        pagesize = pagesize + 1
                        Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE : " & pageno)
                        pagesize = pagesize + 1
                        Filewrite.WriteLine("{0,-30}{1,87}{2,16}", Format(Now, "MMM dd,yyyy") & " " & "To" & " " & Format(Now, "MMM dd,yyyy"), " ", "AMOUNT IN RUPEES")
                        pagesize = pagesize + 1
                        Filewrite.WriteLine(StrDup(135, "-"))
                        pagesize = pagesize + 1
                        Array = caption.Split(",")
                        Fsize = size.Split(",")
                        For count = 0 To Array.Length - 1
                            ssql = ssql & Mid(Trim(Array(count) & ""), 1, Val(Fsize(count))) & Space(Val(Fsize(count) + 1) - Len(Mid(Trim(Array(count) & ""), 1, Val(Fsize(count)))))
                        Next
                        Filewrite.WriteLine(ssql)
                        pagesize = pagesize + 1
                        Filewrite.WriteLine(StrDup(135, "-"))
                        pagesize = pagesize + 1
                    End If
                    With gdataset.Tables("REPORTTABLE").Rows(rowj)
                        ssql = ""
                        While CountItem <= cnt - 1
                            ssql = ssql & Mid(Trim(.Item(CountItem) & ""), 1, Val(Fsize(CountItem))) & Space(Val(Fsize(CountItem) + 1) - Len(Mid(Trim(.Item(CountItem) & ""), 1, Val(Fsize(CountItem)))))
                            CountItem = CountItem + 1
                        End While
                        Filewrite.WriteLine(ssql)
                        pagesize = pagesize + 1
                        ssql = ""
                        CountItem = 0
                    End With
                Next rowj

                Filewrite.WriteLine(StrDup(135, "="))
                pagesize = pagesize + 1
                Filewrite.WriteLine("The Software Is Designed And Developed By DATABASE SOFTWARE,Chennai")
                Filewrite.WriteLine("To Know Abt DBS Pls Mail at :- info@databasesoftware.in")
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(135, "="))
                pagesize = pagesize + 1
            Else
                MessageBox.Show("There is No Records to display", gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Sub
            End If
            Filewrite.Write(Chr(12))
            Filewrite.Close()
            If gPrint = False Then
                OpenTextFile(vOutfile)
            Else
                PrintTextFile1(vFilepath)
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.Source & ex.ToString)
            Exit Sub
        End Try
    End Sub
    Private Sub ReportDesigner_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim I As Integer
        If e.KeyCode = Keys.F10 Then
            Call Cmd_View_Click(Cmd_View, e)
        ElseIf e.KeyCode = Keys.F11 Then
            Call Cmd_Print_Click(Cmd_Print, e)
        ElseIf e.KeyCode = Keys.F2 Then
            For I = 1 To SsGridReport.DataRowCnt - 1
                SsGridReport.Col = 2
                SsGridReport.Row = I
                If Trim(SsGridReport.Text) <> "" Then
                    SsGridReport.SetText(1, I, 1)
                End If
            Next I
        ElseIf e.KeyCode = Keys.F3 Then
            For I = 1 To SsGridReport.DataRowCnt - 1
                SsGridReport.Col = 2
                SsGridReport.Row = I
                If Trim(SsGridReport.Text) <> "" Then
                    SsGridReport.SetText(1, I, 0)
                End If
            Next I
        ElseIf (e.KeyCode = Keys.F12 Or e.KeyCode = Keys.Escape) And Cmd_Exit.Visible Then
            Call Cmd_Exit_Click(Cmd_Exit, e)
        End If
    End Sub
    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        'If MsgBox("Close this form", MsgBoxStyle.OKCancel + MsgBoxStyle.Question, Me.Text) = MsgBoxResult.OK Then
        Me.Close()
        'End If
    End Sub

    Private Sub SsGridReport_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles SsGridReport.KeyDownEvent
        SsGridReport.CellType = FPSpreadADO.CellTypeConstants.CellTypeEdit
        If SsGridReport.Col = 2 Then
            SsGridReport.CellType = FPSpreadADO.CellTypeConstants.CellTypeStaticText
        Else
            SsGridReport.CellType = FPSpreadADO.CellTypeConstants.CellTypeEdit
        End If
    End Sub
    Private Sub subReport()
        Dim chk, boolValidation As Boolean
        Dim getcheck As Object
        Dim i, j, k, cnt, totsize As Integer
        Dim Col, tab, ssql, Size, Caption, Order As String
        i = 1 : j = 1 : cnt = 0
        Call checkvalidation()
        If checkbool = False Then Exit Sub
        'For i = 1 To Me.SsGridReport.DataRowCnt
        '    SsGridReport.Col = 1
        '    SsGridReport.Row = i
        '    getcheck = Trim(SsGridReport.Text)
        '    If Val(getcheck) = 1 Then
        '        If Colomns = "" Then
        '            SsGridReport.Col = 2
        '            SsGridReport.Row = i
        '            Col = Trim(SsGridReport.Text)
        '            SsGridReport.Col = 3
        '            SsGridReport.Row = i
        '            Size = Val(SsGridReport.Text)
        '            totsize = totsize + Val(SsGridReport.Text)
        '            Colomns = Col
        '            Col = ""
        '            cnt = cnt + 1
        '        Else
        '            SsGridReport.Col = 2
        '            SsGridReport.Row = i
        '            Col = Trim(SsGridReport.Text)
        '            Colomns = Colomns & "," & Col
        '            SsGridReport.Col = 3
        '            SsGridReport.Row = i
        '            totsize = totsize + Val(SsGridReport.Text) + 1
        '            Size = Size & "," & Trim(SsGridReport.Text)
        '            Col = ""
        '            cnt = cnt + 1
        '        End If
        '    End If
        '    getcheck = ""
        'Next i
        boolValidation = True
        strColumns = Nothing
        strColumnsLen = Nothing
        intDataRowCount = 0
        For i = 1 To Me.SsGridReport.DataRowCnt
            With SsGridReport
                .Col = 1
                .Row = i
                If Val(Trim(SsGridReport.Text)) = 1 Then
                    intDataRowCount = intDataRowCount + 1
                End If
            End With
        Next
        k = 1
        For i = 1 To Me.SsGridReport.DataRowCnt
            SsGridReport.Col = 1
            SsGridReport.Row = i
            getcheck = Trim(SsGridReport.Text)
            If Val(getcheck) = 1 Then
                'If Colomns = "" Then
                'Getting Type of the Column
                SsGridReport.Col = 8
                SsGridReport.Row = i
                strType = Nothing
                If Trim(SsGridReport.Text) <> "" Then
                    If Trim(SsGridReport.Text) = "S" Then
                        strType = "''"
                    ElseIf Trim(SsGridReport.Text) = "N" Then
                        strType = "0"
                    End If
                Else
                    boolValidation = False
                End If

                'Getting Length of the Column
                SsGridReport.Col = 3
                SsGridReport.Row = i
                If Trim(SsGridReport.Text) <> "" Then
                    If k = intDataRowCount Then
                        'strColumnsLen = strColumnsLen & " Max(Len(Isnull(" & Trim(SsGridReport.Text) & "," & strType & ")))"
                        strColumnsLen = strColumnsLen & Trim(SsGridReport.Text)
                    Else
                        'strColumnsLen = strColumnsLen & " Max(Len(Isnull(" & Trim(SsGridReport.Text) & "," & strType & ")))" & ", "
                        strColumnsLen = strColumnsLen & Trim(SsGridReport.Text) & ", "
                    End If
                Else
                    boolValidation = False
                End If

                'Getting Captio of the Column
                SsGridReport.Col = 4
                SsGridReport.Row = i
                strCaption = Nothing
                If Trim(SsGridReport.Text) <> "" Then
                    strCaption = Trim(SsGridReport.Text)
                Else
                    boolValidation = False
                End If

                'Getting Column
                SsGridReport.Col = 2
                SsGridReport.Row = i
                If Trim(SsGridReport.Text) <> "" And boolValidation = True Then
                    If k = intDataRowCount Then
                        strColumns = strColumns & " Isnull(" & Trim(SsGridReport.Text) & "," & strType & ") As " & strCaption
                    Else
                        strColumns = strColumns & " Isnull(" & Trim(SsGridReport.Text) & "," & strType & ") As " & strCaption & ","
                    End If
                Else
                    MessageBox.Show("Invalid Input! Caption or Size Might be InCorrect....", gCompanyname, MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                    Exit Sub
                End If
                'Col = Trim(SsGridReport.Text)
                'Size = Val(SsGridReport.Text)
                'totsize = totsize + Val(SsGridReport.Text)
                'Colomns = Col
                'Col = ""
                'cnt = cnt + 1
                'Else
                'SsGridReport.Col = 2
                'SsGridReport.Row = i
                'Col = Trim(SsGridReport.Text)
                'Colomns = Colomns & "," & Col
                'SsGridReport.Col = 3
                'SsGridReport.Row = i
                'totsize = totsize + Val(SsGridReport.Text) + 1
                'Size = Size & "," & Trim(SsGridReport.Text)
                'Col = ""
                'cnt = cnt + 1
                'End If
                k = k + 1
            End If
            'getcheck = ""
            getcheck = Nothing
        Next i
        If strColumns = "" Then
            MessageBox.Show("No Fields Has Been Selected", gCompanyname, MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
            Exit Sub
        End If
        'If Colomns = "" Then
        '    MessageBox.Show("No Fields Has Been Selected", gCompanyname, MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        '    Exit Sub
        'End If
        If tables = "" Then
            MessageBox.Show("Table Name not found", gCompanyname, MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
            Exit Sub
        End If
        For i = 1 To Me.SsGridReport.DataRowCnt
            SsGridReport.Col = 1
            SsGridReport.Row = i
            getcheck = Trim(SsGridReport.Text)
            If Val(getcheck) = 1 Then
                SsGridReport.Col = 4
                SsGridReport.Row = i
                If Trim(SsGridReport.Text) = "" Then
                    SsGridReport.Col = 2
                    SsGridReport.Row = i
                    Caption = Caption & "," & Trim(SsGridReport.Text)
                Else
                    SsGridReport.Col = 4
                    SsGridReport.Row = i
                    Caption = Caption & "," & Trim(SsGridReport.Text)
                End If
            End If
        Next i
        For i = 1 To Me.SsGridReport.DataRowCnt
            SsGridReport.Col = 1
            SsGridReport.Row = i
            getcheck = Trim(SsGridReport.Text)
            If Val(getcheck) = 1 Then
                SsGridReport.Col = 5
                SsGridReport.Row = i
                If Trim(SsGridReport.Text) <> "" Then
                    SsGridReport.Col = 5
                    SsGridReport.Row = i
                    Order = Order & "," & Trim(SsGridReport.Text)
                End If
            End If
        Next i
        If Mid(Order, 1, 1) = "," Then
            Order = Mid(Order, 2, Len(Order))
        End If
        If Order = "" Then
            For i = 1 To Me.SsGridReport.DataRowCnt
                SsGridReport.Col = 1
                SsGridReport.Row = i
                getcheck = Trim(SsGridReport.Text)
                If Val(getcheck) = 1 Then
                    SsGridReport.Col = 2
                    SsGridReport.Row = i
                    If Trim(SsGridReport.Text) <> "" Then
                        SsGridReport.Col = 2
                        SsGridReport.Row = i
                        Order = Order & "," & Trim(SsGridReport.Text)
                    End If
                End If
            Next i
        End If
        If Mid(Order, 1, 1) = "," Then
            Order = Mid(Order, 2, Len(Order))
        End If
        If Mid(Caption, 1, 1) = "," Then
            Caption = Mid(Caption, 2, Len(Caption))
        End If
        ssql = " SELECT " & Colomns & tables & " ORDER BY " & Order
        Colomns = ""
        'Call PrintOperation(ssql, Size, Caption, totsize, cnt, Order)

        AppPath = Application.StartupPath
        vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
        VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"

        fdataset.Clear()
        gconnection.FillDataSet("Select " & strColumnsLen & tables, "tblReportLen")
        gconnection.FillDataSet("Select " & strColumns & tables & " ORDER BY " & Order, "tblReport")

        strOutFile = clsReport.fnReportGeneration(strGCompanyDetails, "THE " & Gheader.Trim.ToUpper, CStr(Format(DateValue(strFinancialYearStart), "dd/MMM/yyyy")) & " - " & CStr(Format(DateValue(strFinancialYearEnd), "dd/MMM/yyyy")), "", "SNo", gUsername, fdataset, VFilePath)
        If strOutFile <> VFilePath Then
            MsgBox(strOutFile, MsgBoxStyle.OKOnly + MsgBoxStyle.Information, Me.Text)
        Else
            If gPrint = False Then
                OpenTextFile(vOutfile)
            Else
                PrintTextFile1(VFilePath)
            End If
        End If
    End Sub
End Class
