Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class CONSUMPTION
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
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents txt_Docno As System.Windows.Forms.TextBox
    Friend WithEvents cmd_Docnohelp As System.Windows.Forms.Button
    Friend WithEvents dtp_Docdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_Docdate As System.Windows.Forms.Label
    Friend WithEvents lbl_Docno As System.Windows.Forms.Label
    Friend WithEvents txt_Remarks As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Remarks As System.Windows.Forms.Label
    Friend WithEvents ssgrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents txt_Totalqty As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Totalamount As System.Windows.Forms.Label
    Friend WithEvents txt_Totalamount As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Stockinhand As System.Windows.Forms.Label
    Friend WithEvents lbl_Physicalstock As System.Windows.Forms.Label
    Friend WithEvents txt_Physicalstock As System.Windows.Forms.TextBox
    Friend WithEvents cmd_Print As System.Windows.Forms.Button
    Friend WithEvents cmd_export As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelClosingQuantity As System.Windows.Forms.Label
    Friend WithEvents lbl_Storelocation As System.Windows.Forms.Label
    Friend WithEvents cbo_Storelocation As System.Windows.Forms.ComboBox
    Friend WithEvents txt_Storecode As System.Windows.Forms.TextBox
    Friend WithEvents btn_validation As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CONSUMPTION))
        Me.txt_Docno = New System.Windows.Forms.TextBox()
        Me.cmd_Docnohelp = New System.Windows.Forms.Button()
        Me.dtp_Docdate = New System.Windows.Forms.DateTimePicker()
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.lbl_Docdate = New System.Windows.Forms.Label()
        Me.lbl_Docno = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ssgrid = New AxFPSpreadADO.AxfpSpread()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.btn_validation = New System.Windows.Forms.Button()
        Me.cmd_Print = New System.Windows.Forms.Button()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.txt_Remarks = New System.Windows.Forms.TextBox()
        Me.lbl_Remarks = New System.Windows.Forms.Label()
        Me.lbl_Stockinhand = New System.Windows.Forms.Label()
        Me.txt_Totalqty = New System.Windows.Forms.TextBox()
        Me.lbl_Totalamount = New System.Windows.Forms.Label()
        Me.txt_Totalamount = New System.Windows.Forms.TextBox()
        Me.lbl_Physicalstock = New System.Windows.Forms.Label()
        Me.txt_Physicalstock = New System.Windows.Forms.TextBox()
        Me.cmd_export = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.LabelClosingQuantity = New System.Windows.Forms.Label()
        Me.lbl_Storelocation = New System.Windows.Forms.Label()
        Me.cbo_Storelocation = New System.Windows.Forms.ComboBox()
        Me.txt_Storecode = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_Docno
        '
        Me.txt_Docno.BackColor = System.Drawing.Color.Wheat
        Me.txt_Docno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txt_Docno, "txt_Docno")
        Me.txt_Docno.Name = "txt_Docno"
        '
        'cmd_Docnohelp
        '
        resources.ApplyResources(Me.cmd_Docnohelp, "cmd_Docnohelp")
        Me.cmd_Docnohelp.Name = "cmd_Docnohelp"
        '
        'dtp_Docdate
        '
        resources.ApplyResources(Me.dtp_Docdate, "dtp_Docdate")
        Me.dtp_Docdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Docdate.Name = "dtp_Docdate"
        '
        'lbl_Heading
        '
        resources.ApplyResources(Me.lbl_Heading, "lbl_Heading")
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Heading.Name = "lbl_Heading"
        '
        'lbl_Docdate
        '
        resources.ApplyResources(Me.lbl_Docdate, "lbl_Docdate")
        Me.lbl_Docdate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Docdate.Name = "lbl_Docdate"
        '
        'lbl_Docno
        '
        resources.ApplyResources(Me.lbl_Docno, "lbl_Docno")
        Me.lbl_Docno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Docno.Name = "lbl_Docno"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lbl_Storelocation)
        Me.GroupBox1.Controls.Add(Me.cbo_Storelocation)
        Me.GroupBox1.Controls.Add(Me.txt_Storecode)
        Me.GroupBox1.Controls.Add(Me.lbl_Docdate)
        Me.GroupBox1.Controls.Add(Me.txt_Docno)
        Me.GroupBox1.Controls.Add(Me.lbl_Docno)
        Me.GroupBox1.Controls.Add(Me.cmd_Docnohelp)
        Me.GroupBox1.Controls.Add(Me.dtp_Docdate)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'ssgrid
        '
        Me.ssgrid.DataSource = Nothing
        resources.ApplyResources(Me.ssgrid, "ssgrid")
        Me.ssgrid.Name = "ssgrid"
        Me.ssgrid.OcxState = CType(resources.GetObject("ssgrid.OcxState"), System.Windows.Forms.AxHost.State)
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.Cmd_Clear, "Cmd_Clear")
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Clear.Image = Global.Inventory.My.Resources.Resources.Clear
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.Cmd_View, "Cmd_View")
        Me.Cmd_View.ForeColor = System.Drawing.Color.Black
        Me.Cmd_View.Image = Global.Inventory.My.Resources.Resources.view
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.UseVisualStyleBackColor = False
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.Cmd_Freeze, "Cmd_Freeze")
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Freeze.Image = Global.Inventory.My.Resources.Resources.Delete
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.UseVisualStyleBackColor = False
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.Cmd_Add, "Cmd_Add")
        Me.Cmd_Add.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Add.Image = Global.Inventory.My.Resources.Resources.save
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.UseVisualStyleBackColor = False
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.Cmd_Exit, "Cmd_Exit")
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Exit.Image = Global.Inventory.My.Resources.Resources._Exit
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'btn_validation
        '
        Me.btn_validation.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.btn_validation, "btn_validation")
        Me.btn_validation.ForeColor = System.Drawing.Color.Black
        Me.btn_validation.Name = "btn_validation"
        Me.btn_validation.UseVisualStyleBackColor = False
        '
        'cmd_Print
        '
        Me.cmd_Print.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.cmd_Print, "cmd_Print")
        Me.cmd_Print.ForeColor = System.Drawing.Color.Black
        Me.cmd_Print.Image = Global.Inventory.My.Resources.Resources.print
        Me.cmd_Print.Name = "cmd_Print"
        Me.cmd_Print.UseVisualStyleBackColor = False
        '
        'lbl_Freeze
        '
        resources.ApplyResources(Me.lbl_Freeze, "lbl_Freeze")
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Name = "lbl_Freeze"
        '
        'txt_Remarks
        '
        Me.txt_Remarks.BackColor = System.Drawing.Color.White
        Me.txt_Remarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txt_Remarks, "txt_Remarks")
        Me.txt_Remarks.Name = "txt_Remarks"
        '
        'lbl_Remarks
        '
        resources.ApplyResources(Me.lbl_Remarks, "lbl_Remarks")
        Me.lbl_Remarks.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Remarks.Name = "lbl_Remarks"
        '
        'lbl_Stockinhand
        '
        resources.ApplyResources(Me.lbl_Stockinhand, "lbl_Stockinhand")
        Me.lbl_Stockinhand.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Stockinhand.Name = "lbl_Stockinhand"
        '
        'txt_Totalqty
        '
        Me.txt_Totalqty.BackColor = System.Drawing.Color.Wheat
        Me.txt_Totalqty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txt_Totalqty, "txt_Totalqty")
        Me.txt_Totalqty.Name = "txt_Totalqty"
        '
        'lbl_Totalamount
        '
        resources.ApplyResources(Me.lbl_Totalamount, "lbl_Totalamount")
        Me.lbl_Totalamount.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Totalamount.Name = "lbl_Totalamount"
        '
        'txt_Totalamount
        '
        Me.txt_Totalamount.BackColor = System.Drawing.Color.Wheat
        Me.txt_Totalamount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txt_Totalamount, "txt_Totalamount")
        Me.txt_Totalamount.Name = "txt_Totalamount"
        '
        'lbl_Physicalstock
        '
        resources.ApplyResources(Me.lbl_Physicalstock, "lbl_Physicalstock")
        Me.lbl_Physicalstock.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Physicalstock.Name = "lbl_Physicalstock"
        '
        'txt_Physicalstock
        '
        Me.txt_Physicalstock.BackColor = System.Drawing.Color.Wheat
        Me.txt_Physicalstock.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txt_Physicalstock, "txt_Physicalstock")
        Me.txt_Physicalstock.Name = "txt_Physicalstock"
        '
        'cmd_export
        '
        Me.cmd_export.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.cmd_export, "cmd_export")
        Me.cmd_export.ForeColor = System.Drawing.Color.Black
        Me.cmd_export.Name = "cmd_export"
        Me.cmd_export.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.cmd_export)
        Me.GroupBox3.Controls.Add(Me.cmd_Print)
        Me.GroupBox3.Controls.Add(Me.btn_validation)
        Me.GroupBox3.Controls.Add(Me.Cmd_Clear)
        Me.GroupBox3.Controls.Add(Me.Cmd_View)
        Me.GroupBox3.Controls.Add(Me.Cmd_Freeze)
        Me.GroupBox3.Controls.Add(Me.Cmd_Add)
        Me.GroupBox3.Controls.Add(Me.Cmd_Exit)
        resources.ApplyResources(Me.GroupBox3, "GroupBox3")
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.LabelClosingQuantity)
        Me.GroupBox4.Controls.Add(Me.txt_Remarks)
        Me.GroupBox4.Controls.Add(Me.lbl_Remarks)
        resources.ApplyResources(Me.GroupBox4, "GroupBox4")
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.TabStop = False
        '
        'LabelClosingQuantity
        '
        resources.ApplyResources(Me.LabelClosingQuantity, "LabelClosingQuantity")
        Me.LabelClosingQuantity.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelClosingQuantity.Name = "LabelClosingQuantity"
        '
        'lbl_Storelocation
        '
        resources.ApplyResources(Me.lbl_Storelocation, "lbl_Storelocation")
        Me.lbl_Storelocation.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Storelocation.Name = "lbl_Storelocation"
        '
        'cbo_Storelocation
        '
        Me.cbo_Storelocation.BackColor = System.Drawing.Color.Wheat
        Me.cbo_Storelocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cbo_Storelocation, "cbo_Storelocation")
        Me.cbo_Storelocation.Name = "cbo_Storelocation"
        '
        'txt_Storecode
        '
        Me.txt_Storecode.BackColor = System.Drawing.Color.Wheat
        resources.ApplyResources(Me.txt_Storecode, "txt_Storecode")
        Me.txt_Storecode.Name = "txt_Storecode"
        '
        'CONSUMPTION
        '
        resources.ApplyResources(Me, "$this")
        Me.BackgroundImage = Global.Inventory.My.Resources.Resources._111in1024res
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.lbl_Physicalstock)
        Me.Controls.Add(Me.txt_Physicalstock)
        Me.Controls.Add(Me.lbl_Stockinhand)
        Me.Controls.Add(Me.txt_Totalqty)
        Me.Controls.Add(Me.lbl_Totalamount)
        Me.Controls.Add(Me.txt_Totalamount)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.ssgrid)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "CONSUMPTION"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim boolchk As Boolean
    Dim TotalCount As Integer
    Dim gconnection As New GlobalClass
    Dim Dupchk As Boolean
    Dim sqlstring, financalyear As String
    Dim vsearch, vitem, accountcode As String
    Dim docno, transferdocno, doctype, docno1() As String
    Dim clqty, clqty1 As Integer
    Dim currentuom As String


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
                        If Controls(i_i).Name = "GroupBox3" Then
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
                        ElseIf Controls(i_i).Name = "grp_orderby" Then
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
                        ElseIf Controls(i_i).Name = "frmbut" Then
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


    Private Sub CONSUMPTION_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            StockAdjustmentTransbool = True
            Resize_Form()
            Me.DoubleBuffered = True
            GroupBox2.Controls.Add(ssgrid)
            ssgrid.Location = New Point(10, 10)
            ssgrid.Width = GroupBox2.Width - 15
            ssgrid.Height = GroupBox2.Height - 15
            Call FillStore()
            txt_Totalqty.ReadOnly = True
            txt_Storecode.ReadOnly = True
            txt_Totalamount.ReadOnly = True
            txt_Physicalstock.ReadOnly = True
            cbo_Storelocation.Enabled = True
            If gUserCategory <> "S" Then
                Call GetRights()
            End If
            dtp_Docdate.Focus()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Try
            Call clearform(Me)
            Call FillStore() '''-->Fill Store Desc
            Me.lbl_Freeze.Visible = False
            Me.lbl_Freeze.Text = "Record Void  On "
            ssgrid.ClearRange(1, 1, -1, -1, True)
            Me.Cmd_Freeze.Text = "Void [F8]"
            Cmd_Add.Text = "Add [F7]"
            ssgrid.SetActiveCell(1, 1)
            txt_Physicalstock.ReadOnly = True
            cbo_Storelocation.Enabled = True
            txt_Totalamount.ReadOnly = True
            txt_Storecode.ReadOnly = True
            txt_Totalqty.ReadOnly = True
            txt_Docno.ReadOnly = False
            txt_Docno.Enabled = True
            LabelClosingQuantity.Text = ""
            If gUserCategory <> "S" Then
                Call GetRights()
            End If
            dtp_Docdate.Focus()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Try
            Dim Adjustedamt, Stockqty, Physicalstock, dblval, Avgquantity, Avgrate As Double
            Dim Sqlstring, Insert(0) As String
            Dim i As Integer
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            '''*********************************************************** Calculate` TotalQuantity And TotalAmount *******************'''
            Me.txt_Physicalstock.Text = 0
            Me.txt_Totalamount.Text = 0
            Me.txt_Totalqty.Text = 0
            For i = 1 To ssgrid.DataRowCnt
                Me.ssgrid.Col = 4
                Physicalstock = Val(Me.ssgrid.Text)
                Me.txt_Physicalstock.Text = Format(Val(Me.txt_Physicalstock.Text) + Val(Physicalstock), "0.000")
            Next i
            docno1 = Split(Trim(txt_Docno.Text), "/")

            If Cmd_Add.Text = "Add [F7]" Then
                Sqlstring = "INSERT INTO STOCKADJUSTHEADER(Ttype,Docno,Docdetails,Docdate,Storelocationcode,Storelocationdesc, "
                Sqlstring = Sqlstring & " Adjustedstock, Stockinhand, Physicalstock,Remarks,Void,Adduser,Adddate,Updateuser,Updatetime)"
                Sqlstring = Sqlstring & " VALUES ('C','" & CStr(docno1(1)) & "','" & Trim(txt_Docno.Text) & "',"
                Sqlstring = Sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "',"
                Sqlstring = Sqlstring & " '" & Trim(txt_Storecode.Text) & "','" & Trim(cbo_Storelocation.Text) & "', "
                Sqlstring = Sqlstring & " " & Format(Val(txt_Totalamount.Text), "0.00") & " ," & Format(Val(txt_Totalqty.Text), "0.00") & ","
                Sqlstring = Sqlstring & " " & Format(Val(txt_Physicalstock.Text), "0.00") & ",'" & Trim(txt_Remarks.Text) & "' ,"
                Sqlstring = Sqlstring & " 'N','" & Trim(gUsername) & "',getDate(),"
                Sqlstring = Sqlstring & " '',getDate())"
                Insert(0) = Sqlstring
                '''******************************************************** INSERT INTO STOCKADJUSTDETAILS *******************************'''
                For i = 1 To ssgrid.DataRowCnt
                    ssgrid.Row = i
                    ssgrid.Col = 1
                    ' Avgrate = CalAverageRate(Trim(ssgrid.Text))
                    'Avgquantity = CalAverageQuantity(Trim(ssgrid.Text))
                    Sqlstring = "INSERT INTO STOCKADJUSTDETAILS(Ttype,Docno,Docdetails,DocDate,Storelocationcode,Storelocationdesc,"
                    Sqlstring = Sqlstring & " Itemcode,Itemname,Uom,Adjustedstock,Rate,Amount,"
                    Sqlstring = Sqlstring & " Consumercode,Groupcode,Subgroupcode,Void,Adduser,Adddate,Updateuser,Updatetime)"
                    Sqlstring = Sqlstring & " VALUES ('C','" & CStr(docno1(1)) & "','" & Trim(txt_Docno.Text) & "',"
                    Sqlstring = Sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "',"
                    Sqlstring = Sqlstring & " '" & Trim(txt_Storecode.Text) & "','" & Trim(cbo_Storelocation.Text) & "', "
                    ssgrid.Col = 1
                    Sqlstring = Sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 2
                    Sqlstring = Sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 3
                    Sqlstring = Sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 4
                    Sqlstring = Sqlstring & " " & Format(Val(ssgrid.Text) * -1, "0.000") & ","
                    ssgrid.Col = 5
                    Sqlstring = Sqlstring & " " & Format(Val(ssgrid.Text), "0.00") & ","
                    ssgrid.Col = 6
                    Sqlstring = Sqlstring & " " & Format(Val(ssgrid.Text) * -1, "0.00") & ","
                    ssgrid.Col = 7
                    Sqlstring = Sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 8
                    Sqlstring = Sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 9
                    Sqlstring = Sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    Sqlstring = Sqlstring & " 'N',"
                    Sqlstring = Sqlstring & " '" & Trim(gUsername) & "',getDate(),"
                    Sqlstring = Sqlstring & " ' ',getDate())"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = Sqlstring

                    ssgrid.Col = 3
                    ssgrid.Row = i

                    currentuom = Trim(ssgrid.Text)
                    ssgrid.Col = 4
                    ssgrid.Row = i
                    Sqlstring = "UPDATE INVENTORYITEMMASTER SET clstock = (ISNULL(clstock,0) - " & Format(Val(ssgrid.Text), "0.00") & " * B.CONVVALUE)  FROM INVENTORY_TRANSCONVERSION B "
                    ssgrid.Col = 1
                    ssgrid.Row = i
                    Sqlstring = Sqlstring & "WHERE ITEMCODE = '" & Trim(ssgrid.Text) & "' AND STORECODE = '" & Trim(cbo_Storelocation.Text) & "' AND STOCKUOM = B.TRANSUOM AND  '" & Trim(currentuom) & "' = B.BASEUOM"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = Sqlstring


                Next i
                gconnection.MoreTrans(Insert)
                Sqlstring = "update inventoryitemmaster set CLVALUE=(isnull(clstock,0) * ISNULL(PURCHASERATE,0))"
                gconnection.dataOperation1(6, Sqlstring, "inventoryitemmaster")

                Me.Cmd_Clear_Click(sender, e)
                Cmd_Add.Text = "Add [F7]"
                '''****************************************** UPDATE Complete *********************************************
                If MessageBox.Show("Do You Want Print it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                    Call Cmd_View_Click(Cmd_View, e)
                    Call Cmd_Clear_Click(sender, e)
                Else
                    Call Cmd_Clear_Click(sender, e)
                End If
                '''*********************************************************** Case-2 : Update [F7] *******************************************'''
            Else
                '''********************************************************** UPDATE STOCKADJUSTHEADER *********************************************************'''
                If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
                    If Me.lbl_Freeze.Visible = True Then
                        MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                End If
                Sqlstring = "UPDATE STOCKADJUSTHEADER SET Docdate='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "', "
                Sqlstring = Sqlstring & " Storelocationcode='" & Trim(txt_Storecode.Text) & "',"
                Sqlstring = Sqlstring & " Storelocationdesc='" & Trim(cbo_Storelocation.Text) & "',"
                Sqlstring = Sqlstring & " Adjustedstock=" & Format(Val(txt_Totalamount.Text), "0.00") & ","
                Sqlstring = Sqlstring & " Stockinhand=" & Format(Val(txt_Totalqty.Text), "0.00") & ","
                Sqlstring = Sqlstring & " Physicalstock=" & Format(Val(txt_Physicalstock.Text), "0.00") & ","
                Sqlstring = Sqlstring & " Remarks='" & Trim(txt_Remarks.Text) & "' ,"
                Sqlstring = Sqlstring & " Void='N',updateuser='" & Trim(gUsername) & "',"
                Sqlstring = Sqlstring & " Updatetime=getDate()"
                Sqlstring = Sqlstring & " WHERE TTYPE='C' AND Docdetails='" & Trim(txt_Docno.Text) & "' "
                Insert(0) = Sqlstring
                '''********************************************************* DELETE FROM Stockadjustdetails *****************************************************'''
                Sqlstring = "DELETE FROM STOCKADJUSTDETAILS WHERE TTYPE='C' AND Docdetails='" & Trim(txt_Docno.Text) & "' "
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = Sqlstring
                '''******************************************************** INSERT INTO STOCKADJUSTDETAILS *******************************'''
                For i = 1 To ssgrid.DataRowCnt
                    ssgrid.Row = i
                    ssgrid.Col = 1
                    '  Avgrate = CalAverageRate(Trim(ssgrid.Text))
                    ' Avgquantity = CalAverageQuantity(Trim(ssgrid.Text))
                    Sqlstring = "INSERT INTO STOCKADJUSTDETAILS(Ttype,Docno,Docdetails,DocDate,Storelocationcode,Storelocationdesc,"
                    Sqlstring = Sqlstring & " Itemcode,Itemname,Uom,Adjustedstock,Rate,Amount,"
                    Sqlstring = Sqlstring & " Consumercode,Groupcode,Subgroupcode,Void,Adduser,Adddate,Updateuser,Updatetime)"
                    Sqlstring = Sqlstring & " VALUES ('C','" & CStr(docno1(1)) & "','" & Trim(txt_Docno.Text) & "',"
                    Sqlstring = Sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "',"
                    Sqlstring = Sqlstring & " '" & Trim(txt_Storecode.Text) & "','" & Trim(cbo_Storelocation.Text) & "', "
                    ssgrid.Col = 1
                    Sqlstring = Sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 2
                    Sqlstring = Sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 3
                    Sqlstring = Sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 4
                    Sqlstring = Sqlstring & " " & Format(Val(ssgrid.Text) * -1, "0.000") & ","
                    ssgrid.Col = 5
                    Sqlstring = Sqlstring & " " & Format(Val(ssgrid.Text), "0.00") & ","
                    ssgrid.Col = 6
                    Sqlstring = Sqlstring & " " & Format(Val(ssgrid.Text) * -1, "0.00") & ","
                    ssgrid.Col = 7
                    Sqlstring = Sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 8
                    Sqlstring = Sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 9
                    Sqlstring = Sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    Sqlstring = Sqlstring & " 'N',"
                    Sqlstring = Sqlstring & " '" & Trim(gUsername) & "',getDate(),"
                    Sqlstring = Sqlstring & " '" & Trim(gUsername) & "',getDate())"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = Sqlstring

                    clqty = 0
                    clqty1 = 0
                    ssgrid.Col = 1
                    ssgrid.Row = i
                    Sqlstring = "select (Adjustedstock * b.convvalue) as QTY from StockAdjustDetails,INVENTORY_TRANSCONVERSION B,INVENTORYITEMMASTER i WHERE DOCDETAILS ='" & txt_Docno.Text & "' AND i.ITEMCODE ='" & Trim(ssgrid.Text) & "' AND i.STORECODE = '" & Trim(txt_Storecode.Text) & "' AND i.STOCKUOM = B.TRANSUOM AND  uom = B.BASEUOM"
                    gconnection.getDataSet(Sqlstring, "StockAdjustDetails")
                    If gdataset.Tables("StockAdjustDetails").Rows.Count > 0 Then
                        clqty1 = gdataset.Tables("StockAdjustDetails").Rows(0).Item("QTY")
                    End If

                    ssgrid.Col = 3
                    ssgrid.Row = i
                    currentuom = Trim(ssgrid.Text)
                    ssgrid.Col = 4
                    ssgrid.Row = i
                    Sqlstring = " UPDATE INVENTORYITEMMASTER SET clstock = (ISNULL(clstock,0) - " & Format(Val(clqty1), "0.00") & ") - (" & Format(Val(ssgrid.Text), "0.00") & " * B.CONVVALUE)  FROM INVENTORY_TRANSCONVERSION B "
                    ssgrid.Col = 1
                    ssgrid.Row = i
                    Sqlstring = Sqlstring & "WHERE ITEMCODE = '" & Trim(ssgrid.Text) & "' AND STORECODE = '" & Trim(txt_Storecode.Text) & "' AND STOCKUOM = B.TRANSUOM AND  '" & Trim(currentuom) & "' = B.BASEUOM"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = Sqlstring

                Next i
                gconnection.MoreTrans(Insert)
                Sqlstring = "update inventoryitemmaster set CLVALUE=(isnull(clstock,0) * ISNULL(PURCHASERATE,0))"
                gconnection.dataOperation1(6, Sqlstring, "inventoryitemmaster")

                If MessageBox.Show("Do You Want Print it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                    Call Cmd_View_Click(Cmd_View, e)
                    Call Cmd_Clear_Click(sender, e)
                Else
                    Call Cmd_Clear_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Try
            Dim i As Integer
            Dim insert(0) As String
            Call checkValidation() ''-->Check Validation

            sqlstring = "SELECT ISNULL(INVCLOSE,'N') AS INVCLOSE FROM MONTHCLOSE WHERE MONTHNO=" & Month(dtp_Docdate.Value)
            gconnection.getDataSet(sqlstring, "MONTHCLOSE")
            If gdataset.Tables("MONTHCLOSE").Rows.Count > 0 Then
                If gdataset.Tables("MONTHCLOSE").Rows(0).Item("INVCLOSE") = "Y" Then
                    MsgBox("ACCOUNT POSTING ALREADY DONE...........")
                    Exit Sub
                End If
            End If

            If boolchk = False Then Exit Sub
            If Mid(Me.Cmd_Freeze.Text, 1, 1) = "V" Then
                If MsgBox("Are you Sure to Freeze the Record..", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
                    Exit Sub
                End If
                '''***************************************** Void the DOCNO in stockadjustheader **************************'''
                sqlstring = "UPDATE  STOCKADJUSTHEADER "
                sqlstring = sqlstring & " SET Void= 'Y',"
                sqlstring = sqlstring & " Updateuser='" & Trim(gUsername) & " ',"
                sqlstring = sqlstring & " Updatetime =getDate()"
                sqlstring = sqlstring & " WHERE TTYPE='C' and Docdetails = '" & Trim(txt_Docno.Text) & "'"
                insert(0) = sqlstring
                '''***************************************** Void the DOCNO in stockadjustheader Complete **********************************'''
                '''***************************************** Void the DOCNO in stockadjustdetail **************************'''
                For i = 1 To ssgrid.DataRowCnt
                    With ssgrid
                        sqlstring = "UPDATE  STOCKADJUSTDETAILS "
                        sqlstring = sqlstring & " SET Void= 'Y',"
                        sqlstring = sqlstring & " Updateuser='" & Trim(gUsername) & " ',"
                        sqlstring = sqlstring & " Updatetime =getDate()"
                        sqlstring = sqlstring & " WHERE TTYPE='C' and Docdetails = '" & Trim(txt_Docno.Text) & "'"
                        ReDim Preserve insert(insert.Length)
                        insert(insert.Length - 1) = sqlstring

                        ' UPDATING CURRENT STOCK IN INVENTORYITEMMASTER -START  --***VENUJD
                        clqty = 0
                        clqty1 = 0
                        ssgrid.Col = 1
                        ssgrid.Row = i
                        sqlstring = "select (Adjustedstock * b.convvalue) as QTY from StockAdjustDetails,INVENTORY_TRANSCONVERSION B,INVENTORYITEMMASTER i WHERE DOCDETAILS ='" & txt_Docno.Text & "' AND i.ITEMCODE ='" & Trim(ssgrid.Text) & "' AND i.STORECODE = '" & Trim(txt_Storecode.Text) & "' AND i.STOCKUOM = B.TRANSUOM AND  uom = B.BASEUOM"
                        gconnection.getDataSet(sqlstring, "StockAdjustDetails")
                        If gdataset.Tables("StockAdjustDetails").Rows.Count > 0 Then
                            clqty1 = gdataset.Tables("StockAdjustDetails").Rows(0).Item("QTY")
                        End If

                        ssgrid.Col = 3
                        ssgrid.Row = i
                        currentuom = Trim(ssgrid.Text)
                        ssgrid.Col = 4
                        ssgrid.Row = i
                        sqlstring = "UPDATE INVENTORYITEMMASTER SET CLOSINGQTY = (ISNULL(CLOSINGQTY,0) - " & Format(Val(clqty1), "0.00") & ")  "
                        ssgrid.Col = 1
                        ssgrid.Row = i
                        sqlstring = sqlstring & "WHERE ITEMCODE = '" & Trim(ssgrid.Text) & "' AND STORECODE = '" & Trim(txt_Storecode.Text) & "' "
                        ReDim Preserve insert(insert.Length)
                        insert(insert.Length - 1) = sqlstring
                        ' UPDATING CURRENT STOCK IN INVENTORYITEMMASTER -END  --***VENUJD

                    End With
                Next i
                ''''***************************************** Void the DOCNO is stockadjustdetail Complete **********************************'''
                gconnection.MoreTrans(insert)
                Me.Cmd_Clear_Click(sender, e)
                Cmd_Add.Text = "Add [F7]"
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub

    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click
        Try

            ' If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Group Master") = MsgBoxResult.Yes Then
            Dim rViewer As New Viewer
            Dim sqlstring, SSQL, FROMSTORE As String
            Dim r As New Rpt_StkconsBill
            sqlstring = "SELECT ISNULL(DOCDETAILS,'') AS DOCDETAILS,DOCDATE AS DOCDATE,ISNULL(STORELOCATIONCODE,'') AS STORELOCATIONCODE, "
            sqlstring = sqlstring & " ISNULL(STORELOCATIONDESC,'') AS STORELOCATIONDESC,ISNULL(ITEMCODE,'') AS ITEMCODE, ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM, "
            sqlstring = sqlstring & " ISNULL(STOCKINHAND,0) AS STOCKINHAND, ISNULL(PHYSICALSTOCK,0) AS PHYSICALSTOCK, ISNULL(ADJUSTEDSTOCK,0) AS ADJUSTEDSTOCK,ISNULL(RATE,0) AS RATE, "
            sqlstring = sqlstring & " ISNULL(AMOUNT,0) AS AMOUNT,isnull(REMARKS,'') AS REMARKS,ISNULL(consumercode,'') AS consumercode,ISNULL(UPDFOOTER,'') AS UPDFOOTER ,ISNULL(UPDSIGN,'') AS UPDSIGN,ISNULL(REMARKS_DET,'') AS REMARKS_DET, isnull(ADDDATE,'') as ADDDATE  FROM vw_inv_stkconsumebill "
            '  sqlstring = sqlstring & " "
            sqlstring = sqlstring & " WHERE DOCDETAILS='" & Trim(txt_Docno.Text) & "'"
            sqlstring = sqlstring & " ORDER BY DOCDETAILS,DOCDATE"

            gconnection.getDataSet(sqlstring, "vw_inv_stkconsumebill")
            If gdataset.Tables("vw_inv_stkconsumebill").Rows.Count > 0 Then
                'If chk_excel.Checked = True Then
                '    Dim exp As New exportexcel
                '    exp.Show()
                '    Call exp.export(sqlstring, "STOCK ADJUSTMENT ", "")
                '  Else
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "vw_inv_stkconsumebill"
                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text13")
                textobj1.Text = MyCompanyName

                Dim textobj2 As TextObject
                textobj2 = r.ReportDefinition.ReportObjects("Text21")
                textobj2.Text = gUsername
                If MyCompanyName = "THE BENGAL CLUB" Then
                    Dim textobj3 As TextObject
                    textobj3 = r.ReportDefinition.ReportObjects("Text27")
                    textobj3.Text = ""
                End If
                rViewer.Show()
                '  End If
            Else
                MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
            End If

            '''Else
            '''gPrint = False
            '''Dim i As Integer
            '''Dim objStockadjustmentreport As New rptStockadjustmentreport
            '''Call checkValidation() '''--> Check Validation
            '''If boolchk = False Then Exit Sub
            '''Dim sqlstring = "SELECT ISNULL(H.DOCDETAILS,'') AS DOCDETAILS,H.DOCDATE AS DOCDATE,ISNULL(H.STORELOCATIONCODE,'') AS STORELOCATIONCODE, "
            '''sqlstring = sqlstring & " ISNULL(H.STORELOCATIONDESC,'') AS STORELOCATIONDESC,ISNULL(D.ITEMCODE,'') AS ITEMCODE, ISNULL(D.ITEMNAME,'') AS ITEMNAME,ISNULL(D.UOM,'') AS UOM, "
            '''sqlstring = sqlstring & " ISNULL(D.STOCKINHAND,0) AS STOCKINHAND, ISNULL(D.PHYSICALSTOCK,0) AS PHYSICALSTOCK, ISNULL(D.ADJUSTEDSTOCK,0) AS ADJUSTEDSTOCK,ISNULL(D.RATE,0) AS RATE, "
            '''sqlstring = sqlstring & " ISNULL(D.AMOUNT,0) AS AMOUNT,isnull(REMARKS,'') AS REMARKS,ISNULL(H.UPDFOOTER,'') AS UPDFOOTER ,ISNULL(H.UPDSIGN,'') AS UPDSIGN FROM STOCKADJUSTHEADER AS H INNER JOIN "
            '''sqlstring = sqlstring & " STOCKADJUSTDETAILS AS D ON D.DOCDETAILS = H.DOCDETAILS"
            '''sqlstring = sqlstring & " WHERE H.DOCDETAILS='" & Trim(txt_Docno.Text) & "'"
            '''sqlstring = sqlstring & " ORDER BY DOCDETAILS,DOCDATE"
            '''Dim arraystring() As String = {"ITEM CODE", "ITEM NAME", "UOM", "STOCKINHAND", "PHYSICALSTOCK", "ADJUSTEDSTOCK", "RATE", "AMOUNT"}
            '''Dim heading() As String = {"STOCK ADJUSTMENT"}
            '''Dim colsize() As Integer = {15, 30, 12, 16, 16, 16, 10, 10}
            '''objStockadjustmentreport.ReportDetails(sqlstring, heading, arraystring, colsize)
            '''End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Try
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub


    Private Sub cmd_Docnohelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Docnohelp.Click
        Try
            gSQLString = "SELECT ISNULL(DOCDETAILS,'') AS DOCDETAILS,DOCDATE FROM STOCKADJUSTHEADER"
            M_WhereCondition = " WHERE TTYPE='C' "
            Dim vform As New List_Operation
            vform.Field = "DOCDETAILS,DOCDATE"
            vform.vFormatstring1 = "       DOC NO.            |         DOC DATE                             "
            vform.vCaption = "STOCK CONSUMTION HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_Docno.Text = Trim(vform.keyfield & "")
                Call txt_Docno_Validated(txt_Docno, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub CONSUMPTION_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
            ElseIf e.KeyCode = Keys.F9 Then
                Call Cmd_View_Click(Cmd_View, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F10 Then
                Call cmd_Print_Click(cmd_Print, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F2 Then
                txt_Docno.Text = ""
                txt_Docno.Focus()
                Exit Sub
            ElseIf e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
                Call Cmd_Exit_Click(Cmd_Exit, e)
                Exit Sub
            ElseIf e.Alt = True And e.KeyCode = Keys.R Then
                Me.txt_Remarks.Focus()
                Exit Sub
            ElseIf e.Alt = True And e.KeyCode = Keys.G Then
                Me.ssgrid.Focus()
                Me.ssgrid.SetActiveCell(1, 1)
                Exit Sub
            ElseIf e.Alt = True And e.KeyCode = Keys.S Then
                Me.cbo_Storelocation.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub



    Private Sub ssgrid_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssgrid.KeyDownEvent
        Dim sqlstring, Itemcode, Itemdesc As String
        Dim Issuerate, Highratio, Dblamount, conv As Double
        Dim ItemQty, ItemAmount, ItemRate As Double
        Dim Avgrate, Clsquantity As Double
        Dim ICODE, STOCKUOM As String
        Dim PRATE, SALERATE, PURRATE As Double
        Dim focusbool As Boolean
        Dim i, j As Integer
        search = Nothing
        Try
            If e.keyCode = Keys.Enter Then
                i = ssgrid.ActiveRow
                If ssgrid.ActiveCol = 1 Then
                    ssgrid.Col = 1
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Trim(ssgrid.Text) = "" Then
                            Call FillMenu() ''' IT WILL SHOW A POPUP MENU FOR ITEM CODE
                        Else
                            Itemcode = Trim(ssgrid.Text)

                            ssgrid.ClearRange(1, ssgrid.ActiveRow, 10, ssgrid.ActiveRow, True)
                            '''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
                            sqlstring = " SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM,"
                            sqlstring = sqlstring & " ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.PURCHASERATE,0) AS PURCHASERATE,ISNULL(I.SALERATE,0) AS SALERATE,"
                            sqlstring = sqlstring & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I WHERE I.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(I.FREEZE,'') <> 'Y' and isnull(I.Storecode,'')='" & cbo_Storelocation.Text & "'"
                            gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER")
                            If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count > 0 Then
                                Call GridUOM(i) '''---> Fill the UOM feild
                                ssgrid.SetText(1, i, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE")))
                                Call check_Duplicate(Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE")))
                                If Dupchk = True Then
                                    ssgrid.Col = 1
                                    ssgrid.Row = ssgrid.ActiveRow
                                    ssgrid.Text = ""
                                    ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
                                    ssgrid.Focus()
                                    Exit Sub
                                End If

                                '-------------16/NOV/2013-----------------
                                ICODE = Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE"))
                                STOCKUOM = getUOmCode(Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("STOCKUOM")))
                                PRATE = Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("PURCHASERATE"))
                                SALERATE = Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("SALERATE"))
                                '------------------------------

                                ssgrid.SetText(2, i, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMNAME")))
                                '   ssgrid.SetText(3, i, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("STOCKUOM")))
                                ssgrid.Col = 3
                                ssgrid.Row = ssgrid.ActiveRow
                                ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
                                sqlstring = "SELECT ISNULL(Tranuom,'') AS Tranuom  FROM  INVITEM_TRANSUOM_LINK  WHERE Itemcode ='" & Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE")) & "'"
                                gconnection.getDataSet(sqlstring, "InventoryItemUOM")
                                If (gdataset.Tables("InventoryItemUOM").Rows.Count > 0) Then
                                    FillTransUOM(ssgrid.ActiveRow, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE")))

                                Else
                                    ssgrid.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("STOCKUOM"))
                                End If
                                'ssgrid.Col = 3
                                'ssgrid.Row = i
                                'FillTRANSUOM(ssgrid.ActiveRow, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))

                                'ssgrid.TypeComboBoxString = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                'ssgrid.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))

                                Dim transuom As String = ssgrid.Text
                                conv = changerate(transuom, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE")))
                                Dim purchaserate As Double = Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("Purchaserate")), "0.00")
                                purchaserate = purchaserate / conv
                                '  ssgrid.SetText(3, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM")))

                                ssgrid.SetText(5, i, Val(purchaserate))

                                'Avgrate = CalAverageRate(Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE")))
                                'ssgrid.SetText(5, i, Format(Val(Avgrate), "0.00"))

                                ssgrid.SetText(8, i, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("GROUPCODE")))
                                ssgrid.SetText(9, i, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("SUBGROUPCODE")))
                                'If CHK_WAR.Checked = True Then
                                '    Dim Avgrate As Double
                                '    Avgrate = CALWAR(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Indentdate.Value, "dd MMM yyyy"), Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), Trim(TXT_FROMSTORECODE.Text), "Q")
                                '    sqlstring = "SELECT CLSQTY,CLSVAL,CLSRATE FROM STOCKSUMMARY WHERE ITEMCODE='" & Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")) & "'"
                                '    gconnection.getDataSet(sqlstring, "RATE")
                                '    If gdataset.Tables("RATE").Rows.Count > 0 Then
                                '        If Val(gdataset.Tables("RATE").Rows(0).Item("CLSQTY")) > 0 And Val(gdataset.Tables("RATE").Rows(0).Item("CLSVAL")) > 0 Then
                                '            ssgrid.SetText(5, ssgrid.ActiveRow, Format(Val(gdataset.Tables("RATE").Rows(0).Item("CLSRATE"))))
                                '        Else
                                '            ssgrid.SetText(5, ssgrid.ActiveRow, 1)
                                '        End If
                                '        ssgrid.SetText(7, ssgrid.ActiveRow, Format(Val(gdataset.Tables("RATE").Rows(0).Item("CLSQTY")), "0.00"))
                                '    End If
                                'Else
                                'Rate = CalAverageRate_new(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), Format(dtp_Indentdate.Value, "dd/MMM/yyyy"), TXT_FROMSTORECODE.Text)
                                'ssgrid.SetText(5, i, Format(Val(Rate), "0.00"))

                                '----------**commented by ganesh on 17/nov/2013 as function not used
                                'If Trim(txt_Storecode.Text) <> "" Then
                                '    Clsquantity = ClosingQuantity(Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE")), cbo_Storelocation.Text)
                                'Else
                                '    Clsquantity = 0
                                'End If
                                'ssgrid.SetText(13, ssgrid.ActiveRow, Format(Val(Clsquantity), "0.000"))
                                '------------------------------------------------------------------

                                '  Dim Transuom As String
                                ' ssgrid.Col = 3
                                ' Dim SqlQuery As String
                                ' SqlQuery = "SELECT ISNULL(Tranuom,'') AS Tranuom  FROM  INVITEM_TRANSUOM_LINK  WHERE Itemcode ='" & Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE")) & "'  "
                                ' gconnection.getDataSet(SqlQuery, "InventoryItemUOM")
                                ' If gdataset.Tables("InventoryItemUOM").Rows.Count > 1 Then
                                'Call FillTransUOM(Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE")))
                                'ElseIf gdataset.Tables("InventoryItemUOM").Rows.Count = 1 Then
                                '   ssgrid.Row = ssgrid.ActiveRow
                                '  ssgrid.TypeComboBoxString = Trim(gdataset.Tables("InventoryItemUOM").Rows(0).Item("Tranuom"))
                                ' ssgrid.Text = Trim(gdataset.Tables("InventoryItemUOM").Rows(0).Item("Tranuom"))
                                'Else
                                '   ssgrid.Row = ssgrid.ActiveRow
                                '  ssgrid.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("STOCKUOM"))
                                'End If
                                'Transuom = ssgrid.Text

                                Dim TRFDATE As Date
                                TRFDATE = Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy")
                                Dim cls As Double = gconnection.closing(Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy"), Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE")), Trim(txt_Storecode.Text), Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("STOCKUOM")))
                                '  Dim SQL As String = "SELECT ISNULL(SUM(QTY*MF),0) FROM CLOSINGVLAUE('" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "','" & Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE")) & "' ,'" & Trim(txt_Storecode.Text) & "','" & gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("STOCKUOM") & "')"
                                '  Dim cls As Double = gconnection.getvalue(SQL)

                                '                    Clsquantity = ClosingQuantity_Date(Itemcode, Trim(txt_Storecode.Text), Transuom, TRFDATE)
                                'Issuerate = CalAverageRate_new(Itemcode, TRFDATE, Trim(TXT_FROMSTORECODE.Text), Transuom)
                                ssgrid.SetText(10, i, Format(Val(cls), "0.00"))
                                LabelClosingQuantity.Text = "Closing Stock For Item Code " & gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE") & " Is " & Format(Val(cls), "0.00") & " Qty"

                                '                   ssgrid.SetText(13, i, Format(Val(Clsquantity), "0.000"))

                                '-------*added by GANESH on 16/11/2013 to get converted purchaserate according to UOM
                                'If gsalerate = "Y" Then
                                'SALERATE = GetGRNUomSaleRate(ICODE, dtp_Docdate.Value, Transuom)
                                'If SALERATE > 0 Then
                                'ssgrid.SetText(5, i, Trim(SALERATE))
                                ' Else
                                '    SALERATE = GetInvUomSaleRate(ICODE, dtp_Docdate.Value, Transuom, txt_Storecode.Text)
                                '   ssgrid.SetText(5, i, Trim(SALERATE))
                                'End If
                                '------*added to stop entry of such items where UOM convertion factor is not found. 
                                'If boolConv = False Then
                                'Call DelSsGridItem(ssgrid, 11, ssgrid.ActiveRow)
                                'Call Calculate()
                                'Exit Sub
                                'End If

                                'Else
                                'ssgrid.SetText(5, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("PURCHASERATE")))
                                '   PURRATE = GetGRNUomRate(ICODE, dtp_Docdate.Value, Transuom)
                                '  ssgrid.Col = 5
                                ' ssgrid.Row = ssgrid.ActiveRow
                                'If PURRATE > 0 Then
                                'ssgrid.Text = Format(Val(PURRATE), "0.00")
                                'Else'
                                '   PURRATE = GetInvUomRate(ICODE, dtp_Docdate.Value, Transuom, txt_Storecode.Text)
                                '  ssgrid.Text = Format(Val(PURRATE), "0.00")
                                'End If
                                '------*added to stop entry of such items where UOM convertion factor is not found. 
                                'If boolConv = False Then
                                'Call DelSsGridItem(ssgrid, 11, ssgrid.ActiveRow)
                                'Call Calculate()
                                'Exit Sub
                                'End If
                                'End If
                                '--------*----------------------------------------------------------------








                                'Dim STRITEMUOM As String
                                'ssgrid.Col = 3
                                'ssgrid.Row = ssgrid.ActiveRow
                                'STRITEMUOM = ssgrid.Text
                                'ssgrid.SetText(13, i, Clsquantity)
                                'ssgrid.Col = 13
                                'ssgrid.Row = ssgrid.ActiveRow
                                'Dim INDDATE As Date
                                'INDDATE = Format(CDate(dtp_Docdate.Value), "dd-MMM-yyyy")
                                'Clsquantity = ClosingQuantity_Date(Itemcode, Trim(cbo_Storelocation.Text), STRITEMUOM, INDDATE)
                                'ssgrid.SetText(13, ssgrid.ActiveRow, Format(Val(Clsquantity), "0.000"))

                                'If Val(Clsquantity) <= 0 Then
                                'MsgBox("Item Has No Stock", MsgBoxStyle.Information, MyCompanyName)
                                'ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                                'ssgrid.Text = ""
                                'ssgrid.Focus()
                                'Exit Sub
                                '  End If

                                ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                                ssgrid.Focus()

                            Else
                                MessageBox.Show("Specified ITEM CODE not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
                                ssgrid.Text = ""
                                ssgrid.Focus()
                                Exit Sub
                            End If
                        End If
                    Else
                        ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                    End If
                ElseIf ssgrid.ActiveCol = 2 Then
                    ssgrid.Col = 2
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Trim(ssgrid.Text) = "" Then
                            Call FillMenuItem() ''' IT WILL SHOW A POPUP MENU FOR ITEM CODE
                        Else
                            Itemdesc = Trim(ssgrid.Text)
                            ssgrid.ClearRange(1, ssgrid.ActiveRow, 10, ssgrid.ActiveRow, True)
                            '''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
                            sqlstring = " SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM,"
                            sqlstring = sqlstring & " ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.purchaserate,'') AS purchaserate ,"
                            sqlstring = sqlstring & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I WHERE I.ITEMNAME ='" & Trim(Itemcode) & "' AND ISNULL(I.FREEZE,'') <> 'Y'"
                            gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER")
                            If gdataset.Tables("inventoryitemMaster").Rows.Count > 0 Then
                                Call GridUOM(i) '''---> Fill the UOM feild
                                ssgrid.SetText(1, i, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE")))
                                Call check_Duplicate(Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE")))
                                If Dupchk = True Then
                                    ssgrid.Col = 1
                                    ssgrid.Row = ssgrid.ActiveRow
                                    ssgrid.Text = ""
                                    ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
                                    ssgrid.Focus()
                                    Exit Sub
                                End If
                                ssgrid.SetText(2, i, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMNAME")))
                                ssgrid.Col = 3
                                ssgrid.Row = ssgrid.ActiveRow
                                ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
                                sqlstring = "SELECT ISNULL(Tranuom,'') AS Tranuom  FROM  INVITEM_TRANSUOM_LINK  WHERE Itemcode ='" & Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE")) & "'"
                                gconnection.getDataSet(sqlstring, "InventoryItemUOM")
                                If (gdataset.Tables("InventoryItemUOM").Rows.Count > 0) Then
                                    FillTransUOM(ssgrid.ActiveRow, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE")))

                                Else
                                    ssgrid.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("STOCKUOM"))
                                End If
                                'ssgrid.Col = 3
                                'ssgrid.Row = i
                                'FillTRANSUOM(ssgrid.ActiveRow, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))

                                'ssgrid.TypeComboBoxString = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                'ssgrid.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))

                                Dim transuom As String = ssgrid.Text
                                conv = changerate(transuom, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE")))
                                Dim purchaserate As Double = Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("Purchaserate")), "0.00")
                                purchaserate = purchaserate / conv
                                '  ssgrid.SetText(3, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM")))

                                ssgrid.SetText(5, i, Val(purchaserate))

                                ssgrid.SetText(8, i, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("GROUPCODE")))
                                ssgrid.SetText(9, i, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("SUBGROUPCODE")))

                                Dim cls As Double = gconnection.closing(Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy"), Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE")), Trim(txt_Storecode.Text), Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("STOCKUOM")))


                                'Dim SQL As String = "SELECT ISNULL(SUM(QTY*MF),0) FROM CLOSINGVLAUE('" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "','" & Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE")) & "' ,'" & Trim(cbo_Storelocation.Text) & "','" & Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("STOCKUOM")) & "')"
                                'Dim cls As Double = gconnection.getvalue(SQL)
                                LabelClosingQuantity.Text = "Closing Stock For Item Code " & Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE")) & " Is " & Format(Val(cls), "0.00") & " Qty"
                                '                    Clsquantity = ClosingQuantity_Date(Itemcode, Trim(txt_Storecode.Text), Transuom, TRFDATE)
                                'Issuerate = CalAverageRate_new(Itemcode, TRFDATE, Trim(TXT_FROMSTORECODE.Text), Transuom)
                                ssgrid.SetText(10, i, Format(Val(cls), "0.00"))

                                'If Trim(txt_Storecode.Text) <> "" Then
                                '        Clsquantity = ClosingQuantity(Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE")), cbo_Storelocation.Text)
                                'Else
                                'Clsquantity = 0
                                'End If
                                'ssgrid.SetText(13, ssgrid.ActiveRow, Format(Val(Clsquantity), "0.000"))



                                'Dim STRITEMUOM As String
                                'ssgrid.Col = 3
                                'ssgrid.Row = ssgrid.ActiveRow
                                'STRITEMUOM = ssgrid.Text
                                '   ssgrid.SetText(13, i, Clsquantity)
                                'ssgrid.Col = 13
                                'ssgrid.Row = ssgrid.ActiveRow
                                'Dim INDDATE As Date
                                ' INDDATE = Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy")
                                '  Clsquantity = ClosingQuantity_Date(Itemcode, Trim(cbo_Storelocation.Text), STRITEMUOM, INDDATE)
                                '  ssgrid.SetText(13, ssgrid.ActiveRow, Format(Val(Clsquantity), "0.000"))
                                ' If Val(Clsquantity) <= 0 Then
                                'MsgBox("Item Has No Stock", MsgBoxStyle.Information, MyCompanyName)
                                'ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                                'ssgrid.Text = ""
                                'ssgrid.Focus()
                                'Exit Sub
                                '                            End If
                                ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                                ssgrid.Focus()
                            Else
                                MessageBox.Show("Specified ITEM DESCRIPTION not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                                ssgrid.Text = ""
                                ssgrid.Focus()
                                Exit Sub
                            End If
                        End If
                    End If
                ElseIf ssgrid.ActiveCol = 3 Then
                    ssgrid.Col = 3
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Trim(ssgrid.Text) = "" Then
                            ssgrid.SetActiveCell(2, ssgrid.ActiveRow)
                        End If
                    End If
                ElseIf ssgrid.ActiveCol = 4 Then
                    Dim CQty As Integer
                    ssgrid.Col = 10
                    i = ssgrid.ActiveRow
                    ssgrid.Row = i
                    CQty = Val(ssgrid.Text)
                    ssgrid.Col = 4
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Val(ssgrid.Text) = 0 Then
                            ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
                        ElseIf Val(ssgrid.Text) > CQty Then
                            MsgBox("ISSUING QTY CANNOT BE GREATER THAN CLOSING QTY")
                            ssgrid.Text = 0
                            ssgrid.Focus()
                            ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                            Exit Sub
                        Else
                            Call Calculate() '''--> Calculate total amount
                            ssgrid.Row = ssgrid.ActiveRow + 1
                            ssgrid.Col = 1
                            ssgrid.Lock = False
                            ssgrid.Col = 2
                            ssgrid.Lock = False
                            ssgrid.Col = 3
                            ssgrid.Lock = False
                            ssgrid.Col = 4
                            ssgrid.Lock = False
                            ssgrid.Col = 5
                            ssgrid.Lock = False
                            ssgrid.Col = 6
                            ssgrid.Lock = False
                            ssgrid.SetActiveCell(6, ssgrid.ActiveRow)
                        End If
                    End If
                ElseIf ssgrid.ActiveCol = 5 Then
                    ssgrid.Col = 5
                    ssgrid.Row = ssgrid.ActiveRow
                    If ssgrid.Lock = False Then
                        If Trim(ssgrid.Text) = "" Then
                            ssgrid.SetActiveCell(5, ssgrid.ActiveRow)
                        Else
                            ssgrid.SetActiveCell(0, ssgrid.ActiveRow + 1)
                        End If
                    End If
                ElseIf ssgrid.ActiveCol = 6 Then
                    ssgrid.Col = 6
                    ssgrid.Row = ssgrid.ActiveRow
                    If ssgrid.Lock = False Then
                        If Trim(ssgrid.Text) = "" Then
                            ssgrid.SetActiveCell(5, ssgrid.ActiveRow)
                        Else
                            ssgrid.SetActiveCell(0, ssgrid.ActiveRow + 1)
                        End If
                    End If
                ElseIf ssgrid.ActiveCol = 7 Then
                    'ssgrid.Col = 7
                    'ssgrid.Row = ssgrid.ActiveRow
                    'If ssgrid.Lock = False Then
                    '    If Trim(ssgrid.Text) = "" Then
                    '        ssgrid.SetActiveCell(6, ssgrid.ActiveRow)
                    '    Else
                    '        ssgrid.SetActiveCell(0, ssgrid.ActiveRow + 1)
                    '    End If
                    'End If
                    ssgrid.Col = 7
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Trim(ssgrid.Text) = "" Then
                            Call FillCONSUMER() ''' IT WILL SHOW A POPUP MENU FOR ITEM CODE
                        Else
                            Dim consumercode As String = Trim(ssgrid.Text)

                            ' ssgrid.ClearRange(1, ssgrid.ActiveRow, 10, ssgrid.ActiveRow, True)
                            '''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
                            sqlstring = " SELECT DISTINCT ISNULL(I.conno,'') AS consumercode,ISNULL(I.conname,'') AS consumername,ISNULL(I.contype,'') AS consumertype,"
                            ' sqlstring = sqlstring & " ISNULL(I.DOUBLEUOM,'') AS CONVUOM,ISNULL(CONVVALUE,0) AS HIGHRATIO,ISNULL(I.GROUPCODE,'') AS GROUPCODE,"
                            sqlstring = sqlstring & " ISNULL(I.conid,'') AS consumerid FROM consumermaster AS I WHERE I.conno ='" & Trim(consumercode) & "' AND ISNULL(I.FREEZE,'') <> 'Y'"
                            gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER")
                            If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count > 0 Then
                                ' Call GridUOM(i) '''---> Fill the UOM feild
                                ssgrid.SetText(7, i, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("consumercode")))
                                'ssgrid.SetText(2, i, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("consumername")))
                                'ssgrid.SetText(3, i, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("consumertype")))
                                'Avgrate = CalAverageRate(Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE")))
                                'ssgrid.SetText(5, i, Format(Val(Avgrate), "0.00"))
                                'ssgrid.SetText(8, i, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("CONVUOM")))
                                'ssgrid.SetText(9, i, Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("HIGHRATIO")))
                                'ssgrid.SetText(10, i, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("GROUPCODE")))
                                'ssgrid.SetText(11, i, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("SUBGROUPCODE")))
                                ssgrid.Focus()
                                ssgrid.SetActiveCell(1, ssgrid.ActiveRow + 1)

                            Else
                                MessageBox.Show("Specified Consumer CODE not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                ssgrid.SetActiveCell(6, ssgrid.ActiveRow)
                                ssgrid.Text = ""
                                ssgrid.Focus()
                                Exit Sub
                            End If
                        End If
                    Else
                        ssgrid.SetActiveCell(6, ssgrid.ActiveRow)
                    End If

                ElseIf ssgrid.ActiveCol = 8 Then
                    ssgrid.Col = 8
                    ssgrid.Row = ssgrid.ActiveRow
                    If ssgrid.Lock = False Then
                        If Trim(ssgrid.Text) = "" Then
                            ssgrid.SetActiveCell(7, ssgrid.ActiveRow)
                        Else
                            ssgrid.SetActiveCell(0, ssgrid.ActiveRow + 1)
                        End If
                    End If
                ElseIf ssgrid.ActiveCol = 9 Then
                    ssgrid.Col = 9
                    ssgrid.Row = ssgrid.ActiveRow
                    If ssgrid.Lock = False Then
                        If Trim(ssgrid.Text) = "" Then
                            ssgrid.SetActiveCell(8, ssgrid.ActiveRow)
                        Else
                            ssgrid.SetActiveCell(0, ssgrid.ActiveRow + 1)
                        End If
                    End If
                ElseIf ssgrid.ActiveCol = 10 Then
                    ssgrid.Col = 10
                    ssgrid.Row = ssgrid.ActiveRow
                    If ssgrid.Lock = False Then
                        If Trim(ssgrid.Text) = "" Then
                            ssgrid.SetActiveCell(9, ssgrid.ActiveRow)
                        Else
                            ssgrid.SetActiveCell(0, ssgrid.ActiveRow + 1)
                        End If
                    End If
                ElseIf ssgrid.ActiveCol = 11 Then
                    ssgrid.Col = 11
                    ssgrid.Row = ssgrid.ActiveRow
                    If ssgrid.Lock = False Then
                        If Trim(ssgrid.Text) = "" Then
                            ssgrid.SetActiveCell(10, ssgrid.ActiveRow)
                        Else
                            ssgrid.SetActiveCell(0, ssgrid.ActiveRow + 1)
                        End If
                    End If
                End If
            ElseIf e.keyCode = Keys.F4 Then
                If ssgrid.ActiveCol = 1 Then
                    ssgrid.Col = 1
                    ssgrid.Row = ssgrid.ActiveRow
                    If ssgrid.Lock = False Then
                        ssgrid.Col = 1
                        ssgrid.Row = ssgrid.ActiveRow
                        search = Trim(ssgrid.Text)
                        Call FillMenu()
                    End If
                ElseIf ssgrid.ActiveCol = 2 Then
                    ssgrid.Col = 2
                    ssgrid.Row = ssgrid.ActiveRow
                    If ssgrid.Lock = False Then
                        ssgrid.Col = 2
                        ssgrid.Row = ssgrid.ActiveRow
                        search = Trim(ssgrid.Text)
                        Call FillMenuItem()
                    End If
                End If
            ElseIf e.keyCode = Keys.F3 Then
                ssgrid.Col = ssgrid.ActiveCol
                ssgrid.Row = ssgrid.ActiveRow
                If ssgrid.Lock = False Then
                    ssgrid.Row = ssgrid.ActiveRow
                    ssgrid.ClearRange(1, ssgrid.ActiveRow, 9, ssgrid.ActiveRow, True)
                    ssgrid.DeleteRows(ssgrid.ActiveRow, 1)
                    Call Calculate()
                    ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                    ssgrid.Focus()
                    LabelClosingQuantity.Text = ""
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub FillTransUOM(ByVal itemcode As String)
        gSQLString = "SELECT ISNULL(Tranuom,'') AS Tranuom  FROM  INVITEM_TRANSUOM_LINK  WHERE Itemcode ='" & itemcode & "'   "
        If Trim(search) = " " Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = " AND  Tranuom LIKE '" & Trim(search) & "%'"
        End If
        Dim vform1 As New ListOperattion1
        vform1.Field = "TRANUOM"
        vform1.vFormatstring = "     TRANS UOM                                                                                                   "
        vform1.vCaption = " PURCHASE UOMMASTER HELP"
        vform1.KeyPos = 0
        vform1.ShowDialog(Me)
        If Trim(vform1.keyfield & "") <> "" Then
            ssgrid.Col = 3
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.TypeComboBoxString = Trim(vform1.keyfield & "")
            ssgrid.Text = Trim(vform1.keyfield & "")

            ' ssgrid.Text = Trim(vform1.keyfield & "")
            ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
            ssgrid.Focus()
        End If
        vform1.Close()
        vform1 = Nothing
    End Sub

    Private Function check_Duplicate(ByVal Itemcode As String)
        Dim i As Integer

        Dupchk = False
        ssgrid.Col = 1
        For i = 1 To ssgrid.DataRowCnt
            ssgrid.Row = i
            If i <> ssgrid.ActiveRow Then
                If Trim(ssgrid.Text) = Itemcode Then
                    MsgBox("Item Already exists", MsgBoxStyle.Critical, "Duplicate")
                    Dupchk = True
                End If
            End If
        Next
    End Function

    Private Sub FillTRANSUOM(ByVal i As Integer, ByVal itemcode As String)
        Try
            Dim Z As Integer
            sqlstring = "SELECT ISNULL(TranUom,'') AS UOMDESC FROM INVITEM_TRANSUOM_LINK WHERE itemcode='" & itemcode & "'"
            gconnection.getDataSet(sqlstring, "UOMMASTER1")
            If gdataset.Tables("UOMMASTER1").Rows.Count > 0 Then
                For Z = 0 To gdataset.Tables("UOMMASTER1").Rows.Count - 1
                    ssgrid.Col = 3
                    ssgrid.Row = i
                    ssgrid.TypeComboBoxString = Trim(gdataset.Tables("UOMMASTER1").Rows(Z).Item("UOMDESC"))
                    ssgrid.Text = Trim(gdataset.Tables("UOMMASTER1").Rows(Z).Item("UOMDESC"))
                Next Z
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Function changerate(ByVal uomr As String, ByVal itemcode As String) As Double
        Dim conv As Double
        Dim sql As String = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom=(select distinct stockuom from inventoryitemmaster where storecode='" + Trim(txt_Storecode.Text) + "' and itemcode='" + itemcode + "')"
        sql = sql & " and Transuom='" + uomr + "'"
        gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
            conv = Convert.ToDouble(gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue"))
        Else
            conv = 1
        End If
        Return conv
    End Function
    Private Sub FillMenu()
        Try
            Dim vform As New List_Operation
            Dim Clsquantity, Avgrate, conv As Double
            '''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO SSGRID ********** 
            gSQLString = " SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM,"
            gSQLString = gSQLString & " isnull(i.purchaserate,0) as Purchaserate, ISNULL(I.GROUPCODE,'') AS GROUPCODE,"
            gSQLString = gSQLString & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I"
            If Trim(search) = " " Then
                M_WhereCondition = "  WHERE I.STORECODE = '" & Trim(cbo_Storelocation.Text) & "'"
            Else
                M_WhereCondition = " WHERE I.ITEMCODE LIKE '" & Trim(search) & "%' AND ISNULL(I.FREEZE,'')<>'Y' and  I.STORECODE = '" & Trim(cbo_Storelocation.Text) & "'"
            End If
            vform.Field = "ITEMNAME,ITEMCODE"
            vform.vFormatstring1 = "   ITEMCODE |               ITEMNAME            |     STOCKUOM   |  PURCHASERATE   | GROUPCODE | SUBGROUPCODE |"
            vform.vCaption = "INVENTORY ITEM CODE HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.KeyPos2 = 2
            vform.Keypos3 = 3
            vform.keypos4 = 4
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Call GridUOM(ssgrid.ActiveRow)
                ' Dim STRITEMUOM As String
                ssgrid.Col = 1
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Trim(vform.keyfield)
                Call check_Duplicate(vform.keyfield)
                If Dupchk = True Then
                    ssgrid.Col = 1
                    ssgrid.Row = ssgrid.ActiveRow
                    ssgrid.Text = ""
                    ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
                    ssgrid.Focus()
                    Exit Sub
                End If

                'STRITEMUOM = Trim(vform.keyfield)
                ssgrid.Col = 2
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Trim(vform.keyfield1)




                ssgrid.Col = 3
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
                Dim SqlQuery As String = "SELECT ISNULL(Tranuom,'') AS Tranuom  FROM  INVITEM_TRANSUOM_LINK  WHERE Itemcode ='" & Trim(vform.keyfield) & "'"
                gconnection.getDataSet(SqlQuery, "InventoryItemUOM")
                If (gdataset.Tables("InventoryItemUOM").Rows.Count > 0) Then
                    FillTransUOM(ssgrid.ActiveRow, Trim(vform.keyfield))

                Else
                    ssgrid.Text = Trim(vform.keyfield4)
                End If
                Dim transuom As String = ssgrid.Text
                conv = changerate(ssgrid.Text, vform.keyfield)
                Dim purchaserate As Double = Format(Val(vform.keyfield5), "0.00")
                purchaserate = purchaserate / conv

                ssgrid.Col = 5
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.SetText(5, ssgrid.ActiveRow, Format(Val(purchaserate), "0.00"))

                ssgrid.Col = 8
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Trim(vform.keyfield4)
                ssgrid.Col = 9
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Trim(vform.keyfield5)
                '  ssgrid.Col = 10
                ' ssgrid.Row = ssgrid.ActiveRow
                'ssgrid.Text = Trim(vform.keyfield6)
                Dim cls As Double = gconnection.closing(Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy"), vform.keyfield, Trim(txt_Storecode.Text), vform.keyfield2)

                '   Dim SQL As String = "SELECT ISNULL(SUM(QTY*MF),0) FROM CLOSINGVLAUE('" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "','" & Trim(vform.keyfield) & "' ,'" & Trim(txt_Storecode.Text) & "','" & Trim(vform.keyfield2) & "')"
                '  Dim cls As Double = gconnection.getvalue(SQL)
                ssgrid.SetText(10, ssgrid.ActiveRow, cls)
                LabelClosingQuantity.Text = "Closing Stock For Item Code " & vform.keyfield & " Is " & Format(Val(cls), "0.00") & " Qty"

                'ssgrid.Col = 13
                'ssgrid.Row = ssgrid.ActiveRow
                Dim DOCDATE As Date

                DOCDATE = Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy")
                'Clsquantity = ClosingQuantity_Date(Trim(vform.keyfield), Trim(cbo_Storelocation.Text), Transuom, DOCDATE)
                'ssgrid.SetText(13, ssgrid.ActiveRow, Format(Val(Clsquantity), "0.000"))
                'If Val(Clsquantity) <= 0 Then
                'MsgBox("Item Has No Stock", MsgBoxStyle.Information, MyCompanyName)
                'ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                'ssgrid.Text = ""
                'ssgrid.Focus()
                'Exit Sub
                ' End If


                ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                ssgrid.Focus()
            Else
                ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
                ssgrid.Focus()
                Exit Sub
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub FillMenuItem()
        Try
            Dim vform As New List_Operation
            Dim Clsquantity, Avgrate As Double
            '''******************************************************** $ FILL THE ITEMDESC,ITEMCODE INTO SSGRID ********** 
            gSQLString = " SELECT DISTINCT ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.STOCKUOM,'') AS STOCKUOM,"
            gSQLString = gSQLString & " ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.purchaserate,'') AS purchaserate,"
            gSQLString = gSQLString & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I"
            If Trim(search) = " " Then
                M_WhereCondition = ""
            Else
                M_WhereCondition = " WHERE I.ITEMNAME LIKE '" & Trim(search) & "%' AND ISNULL(I.FREEZE,'')<>'Y'"
            End If
            vform.Field = "ITEMNAME,ITEMCODE"
            vform.vFormatstring1 = "                         ITEMNAME                    |  ITEMCODE  |     STOCKUOM   | GROUPCODE |    PURCHASERATE   | SUBGROUPCODE |"
            vform.vCaption = "INVENTORY ITEM CODE HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.KeyPos2 = 2
            vform.Keypos3 = 3
            vform.keypos4 = 4
            vform.Keypos5 = 5
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Call GridUOM(ssgrid.ActiveRow)
                ssgrid.Col = 1
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Trim(vform.keyfield1)


                ssgrid.Col = 2
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Trim(vform.keyfield)
                ssgrid.Col = 3
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Trim(vform.keyfield2)
                Dim STRITEMUOM As String = Trim(vform.keyfield2)
                '   Avgrate = CalAverageRate(Trim(vform.keyfield1))
                ssgrid.Col = 5
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Format(Val(Trim(vform.keyfield4)), "0.00")
                ssgrid.Col = 8
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Trim(vform.keyfield3)
                ssgrid.Col = 9
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Trim(vform.keyfield5)
                Dim SQL As String = "SELECT ISNULL(SUM(QTY*MF),0) FROM CLOSINGVLAUE('" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "','" & Trim(vform.keyfield1) & "' ,'" & Trim(cbo_Storelocation.Text) & "','" & Trim(vform.keyfield2) & "')"
                Dim cls As Double = gconnection.getvalue(SQL)
                ssgrid.SetText(10, ssgrid.ActiveRow, Format(Val(cls), "0.00"))
                LabelClosingQuantity.Text = "Closing Stock For Item " & vform.keyfield & " Is " & Format(Val(cls), "0.00") & " Qty"
                'ssgrid.Col = 11
                'ssgrid.Row = ssgrid.ActiveRow
                'ssgrid.Text = Trim(vform.keyfield6)

                'ssgrid.Col = 13
                'ssgrid.Row = ssgrid.ActiveRow
                'Dim DOCDATE As Date
                'DOCDATE = Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy")
                'Clsquantity = ClosingQuantity_Date(Trim(vform.keyfield1), Trim(cbo_Storelocation.Text), STRITEMUOM, DOCDATE)
                '  ssgrid.SetText(13, ssgrid.ActiveRow, Format(Val(Clsquantity), "0.000"))
                If Val(cls) <= 0 Then
                    MsgBox("Item Has No Stock", MsgBoxStyle.Information, MyCompanyName)
                    ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                    ssgrid.Text = ""
                    ssgrid.Focus()
                    Exit Sub
                End If

                ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                ssgrid.Focus()
            Else
                ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                ssgrid.Focus()
                Exit Sub
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub FillCONSUMER()
        Try
            Dim vform As New List_Operation
            Dim Clsquantity, Avgrate As Double
            '''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO SSGRID ********** 
            gSQLString = " SELECT  ISNULL(I.CONNO,'') AS CONSUMERCODE,ISNULL(I.CONNAME,'') AS CONSUMERNAME,ISNULL(I.CONTYPE,'') AS CONSUMERTYPE,"
            'gSQLString = gSQLString & " ISNULL(I.DOUBLEUOM,'') AS CONVUOM,ISNULL(CONVVALUE,0) AS HIGHRATIO,ISNULL(I.GROUPCODE,'') AS GROUPCODE,"
            gSQLString = gSQLString & " ISNULL(I.CONID,'') AS CONSUMERID FROM CONSUMERMASTER AS I"
            If Trim(search) = " " Then
                M_WhereCondition = ""
            Else
                M_WhereCondition = " WHERE I.CONNO LIKE '" & Trim(search) & "%' AND ISNULL(I.FREEZE,'')<>'Y'"
            End If
            vform.Field = "CONNAME,CONNO"
            vform.vFormatstring1 = "   CONSUMERCODE |                       CONSUMERNAME                    |     CONSUMERTYPE   |   CONSUMERID  "
            vform.vCaption = "CONSUMER HELP"
            vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            'vform.Keypos3 = 3
            'vform.keypos4 = 4
            'vform.Keypos5 = 5
            'vform.Keypos6 = 6
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                ' Call GridUOM(ssgrid.ActiveRow)
                ssgrid.Col = 7
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Trim(vform.keyfield)
                'ssgrid.Col = 2
                'ssgrid.Row = ssgrid.ActiveRow
                'ssgrid.Text = Trim(vform.keyfield1)
                'ssgrid.Col = 3
                'ssgrid.Row = ssgrid.ActiveRow
                'ssgrid.Text = Trim(vform.keyfield2)
                'Avgrate = CalAverageRate(Trim(vform.keyfield))
                'ssgrid.Col = 5
                'ssgrid.Row = ssgrid.ActiveRow
                'ssgrid.Text = Format(Val(Avgrate), "0.00")
                'ssgrid.Col = 8
                'ssgrid.Row = ssgrid.ActiveRow
                'ssgrid.Text = Trim(vform.keyfield3)
                'ssgrid.Col = 9
                'ssgrid.Row = ssgrid.ActiveRow
                'ssgrid.Text = Format(Val(vform.keyfield4), "0.00")
                'ssgrid.Col = 10
                'ssgrid.Row = ssgrid.ActiveRow
                'ssgrid.Text = Trim(vform.keyfield5)
                'ssgrid.Col = 11
                'ssgrid.Row = ssgrid.ActiveRow
                'ssgrid.Text = Trim(vform.keyfield6)
                ssgrid.SetActiveCell(0, ssgrid.ActiveRow + 1)
                ssgrid.Focus()
            Else
                ssgrid.SetActiveCell(7, ssgrid.ActiveRow)
                ssgrid.Focus()
                Exit Sub
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Calculate()
        Try
            Dim ValStockhand, ValPhysicalstock, ValAdjustedstock As Double
            Dim ValHighratio, ValItemamount, ValDblamount, ValRate As Double
            Dim i As Integer
            If ssgrid.ActiveCol = 1 Or ssgrid.ActiveCol = 2 Or ssgrid.ActiveCol = 3 Or ssgrid.ActiveCol = 4 Or ssgrid.ActiveCol = 5 Or ssgrid.ActiveCol = 6 Then
                i = ssgrid.ActiveRow

                ssgrid.Col = 4
                ssgrid.Row = i
                ValPhysicalstock = Val(ssgrid.Text)

                ssgrid.Col = 5
                ssgrid.Row = i
                ValRate = Val(ssgrid.Text)
                ssgrid.Col = 8
                ssgrid.Row = i
                ValHighratio = Val(ssgrid.Text)
                ValAdjustedstock = Val(ValPhysicalstock) - Val(ValStockhand)
                ValItemamount = Format(Val(ValAdjustedstock) * Val(ValRate), "0.00")
                ValDblamount = Format(Val(ValAdjustedstock) * Val(ValHighratio), "0.00")
                If Val(ValItemamount) = 0 Then
                    ssgrid.SetText(6, i, "")
                    '  ssgrid.SetText(8, i, "")
                Else
                    ssgrid.SetText(6, i, Format(Val(ValItemamount), "0.00"))
                    '   ssgrid.SetText(8, i, Format(Val(ValDblamount), "0.00"))
                End If
                ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                Me.txt_Physicalstock.Text = 0
                Me.txt_Totalamount.Text = 0
                Me.txt_Totalqty.Text = 0
                For i = 1 To ssgrid.DataRowCnt
                    ssgrid.Col = 4
                    ValPhysicalstock = Val(ssgrid.Text)
                    Me.txt_Physicalstock.Text = Format(Val(Me.txt_Physicalstock.Text) + Val(ValPhysicalstock), "0.000")
                    Me.txt_Totalqty.Text = Format(Val(Me.txt_Totalqty.Text) + Val(ValPhysicalstock), "0.000")
                Next i
                i = i - 1
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub dtp_Docdate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtp_Docdate.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                cbo_Storelocation.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub cbo_Storelocation_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If e.KeyCode = Keys.Enter Then
                ssgrid.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Remarks_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Remarks.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Cmd_Add.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub FillStore()
        Try
            Dim i As Integer
            'sqlstring = "SELECT DISTINCT ISNULL(STOREDESC,'') AS STOREDESC,ISNULL(STORECODE,'') AS STORECODE FROM STOREMASTER WHERE   ISNULL(FREEZE,'') <> 'Y' ORDER BY STOREDESC ASC"
            sqlstring = "SELECT DISTINCT ISNULL(STOREDESC,'') AS STOREDESC,ISNULL(STORECODE,'') AS STORECODE FROM STOREMASTER ORDER BY STOREDESC ASC"
            gconnection.getDataSet(sqlstring, "STOREMASTER")
            cbo_Storelocation.Items.Clear()
            cbo_Storelocation.Sorted = True
            If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("STOREMASTER").Rows.Count - 1
                    cbo_Storelocation.Items.Add(gdataset.Tables("STOREMASTER").Rows(i).Item("STORECODE"))
                Next i
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub


    Public Sub checkValidation()
        Try
            Dim i, j As Integer
            Dim itemcode As String
            boolchk = False
            Calculate()
            '''********** Check  Store Location Can't be blank *********************'''
            If Trim(cbo_Storelocation.Text) = "" Then
                MessageBox.Show(" Store Location field can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbo_Storelocation.Focus()
                Exit Sub
            End If
            '''********** Check  Total Quantity Can't be blank *********************'''
            'If Val(txt_Totalqty.Text) = 0 Then
            '    MessageBox.Show(" Total Quantity can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    txt_Totalqty.Focus()
            '    Exit Sub
            'End If
            ''''********** Check  Physical Stock Can't be blank *********************'''
            'If Val(txt_Physicalstock.Text) = 0 Then
            '    MessageBox.Show(" Physical Stock can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    txt_Physicalstock.Focus()
            '    Exit Sub
            'End If
            ''''********** Check  Totalamount Can't be blank *********************'''
            'If Val(txt_Totalamount.Text) = 0 Then
            '    MessageBox.Show(" Totalamount can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    txt_Totalamount.Focus()
            '    Exit Sub
            'End If
            '''********** Check  DOC No. Can't be blank *********************'''
            If Trim(txt_Docno.Text) = "" Then
                MessageBox.Show(" DOC No. field can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_Docno.Focus()
                Exit Sub
            End If
            For i = 1 To ssgrid.DataRowCnt
                ssgrid.Row = i
                ssgrid.Col = 1
                If Trim(ssgrid.Text) = "" Then
                    MessageBox.Show("ItemCode can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.SetActiveCell(1, i)
                    Exit Sub
                End If
                ssgrid.Col = 2
                If Trim(ssgrid.Text) = "" Then
                    MessageBox.Show("Itemdesc can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.SetActiveCell(2, i)
                    Exit Sub
                End If
                ssgrid.Col = 3
                If Trim(ssgrid.Text) = "" Then
                    MessageBox.Show("UOM can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.SetActiveCell(3, i)
                    Exit Sub
                End If
                ssgrid.Col = 4
                If Val(ssgrid.Text) = 0 Then
                    MessageBox.Show("Physical stock can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.SetActiveCell(5, i)
                    Exit Sub
                End If

                ssgrid.Col = 5
                If Val(ssgrid.Text) = 0 Then
                    MessageBox.Show("Rate can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.SetActiveCell(7, i)
                    Exit Sub
                End If
                ssgrid.Col = 6
                If Val(ssgrid.Text) = 0 Then
                    MessageBox.Show("Amount can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.SetActiveCell(6, i)
                    Exit Sub
                End If
                ssgrid.Col = 7
                If Trim(ssgrid.Text) = "" Then
                    MessageBox.Show("Consumer can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.SetActiveCell(7, i)
                    Exit Sub
                End If
                ssgrid.Col = 8
                'If Val(ssgrid.Text) = 0 Then
                '    MessageBox.Show("dblamount can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                '    ssgrid.SetActiveCell(8, i)
                '    Exit Sub
                'End If
                'ssgrid.Col = 9
                '   If Val(ssgrid.Text) = 0 Then
                'MessageBox.Show("High Ratio can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                '   ssgrid.SetActiveCell(9, i)
                '    Exit Sub
                '     End If
                ssgrid.Col = 8
                If Trim(ssgrid.Text) = "" Then
                    MessageBox.Show("Group Code can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.SetActiveCell(8, i)
                    Exit Sub
                End If
                ssgrid.Col = 9
                If Trim(ssgrid.Text) = "" Then
                    MessageBox.Show("Sub Group Code can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.SetActiveCell(9, i)
                    Exit Sub
                End If
            Next i
            boolchk = True
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Totalamount_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Totalamount.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                txt_Totalqty.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Totalqty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Totalqty.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                txt_Physicalstock.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Physicalstock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Physicalstock.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                txt_Remarks.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Docno_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Docno.Validated
        Dim vString, sqlstring, Stritemcode As String
        Dim Clsquantity As Double
        Dim dt As New DataTable
        Dim j, i As Integer
        If Trim(txt_Docno.Text) <> "" Then
            Try
                sqlstring = "SELECT ISNULL(DOCNO,'') AS DOCNO,ISNULL(DOCDETAILS,'') AS DOCDETAILS,DOCDATE,ISNULL(STORELOCATIONCODE,'') AS STORELOCATIONCODE, "
                sqlstring = sqlstring & " ISNULL(STORELOCATIONDESC,'') AS STORELOCATIONDESC,ISNULL(ADJUSTEDSTOCK,0) AS ADJUSTEDAMOUNT,ISNULL(STOCKINHAND,0) AS STOCKINHAND,"
                sqlstring = sqlstring & " ISNULL(PHYSICALSTOCK,0) AS PHYSICALSTOCK,ISNULL(REMARKS,'') AS REMARKS,ISNULL(VOID,'') AS VOID,ISNULL(ADDUSER,'') AS ADDUSER,"
                sqlstring = sqlstring & " ADDDATE,ISNULL(UPDATEUSER,'') AS UPDATEUSER,UPDATETIME FROM STOCKADJUSTHEADER "
                sqlstring = sqlstring & " WHERE TTYPE='C' AND (DOCNO='" & Trim(txt_Docno.Text) & "'OR DOCDETAILS='" & Trim(txt_Docno.Text) & "')"
                gconnection.getDataSet(sqlstring, "STOCKADJUSTHEADER")
                '''************************************************* SELECT RECORD FROM STOCKADJUSTHEADER *********************************************''''                
                If gdataset.Tables("STOCKADJUSTHEADER").Rows.Count > 0 Then
                    Cmd_Add.Text = "Update[F7]"
                    Me.txt_Docno.ReadOnly = True
                    txt_Docno.Text = Trim(gdataset.Tables("STOCKADJUSTHEADER").Rows(0).Item("DOCDETAILS"))
                    dtp_Docdate.Value = Format(CDate(gdataset.Tables("STOCKADJUSTHEADER").Rows(0).Item("DOCDATE")), "dd/MMM/yyyy")
                    txt_Storecode.Text = Trim(gdataset.Tables("STOCKADJUSTHEADER").Rows(0).Item("STORELOCATIONCODE"))
                    cbo_Storelocation.DropDownStyle = ComboBoxStyle.DropDown
                    cbo_Storelocation.Enabled = False
                    cbo_Storelocation.Text = Trim(gdataset.Tables("STOCKADJUSTHEADER").Rows(0).Item("STORELOCATIONDESC"))
                    cbo_Storelocation.DropDownStyle = ComboBoxStyle.DropDownList
                    txt_Totalamount.Text = Format(Val(gdataset.Tables("STOCKADJUSTHEADER").Rows(0).Item("ADJUSTEDAMOUNT")), "0.00")
                    txt_Totalqty.Text = Format(Val(gdataset.Tables("STOCKADJUSTHEADER").Rows(0).Item("STOCKINHAND")), "0.000")
                    txt_Physicalstock.Text = Format(Val(gdataset.Tables("STOCKADJUSTHEADER").Rows(0).Item("PHYSICALSTOCK")), "0.000")
                    txt_Remarks.Text = Trim(gdataset.Tables("STOCKADJUSTHEADER").Rows(0).Item("REMARKS") & "")
                    If gdataset.Tables("stockadjustheader").Rows(0).Item("VOID") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = ""
                        Me.lbl_Freeze.Text = "Record Void  On " & Format(CDate(gdataset.Tables("STOCKADJUSTHEADER").Rows(0).Item("UPDATETIME")), "dd/MMM/yyyy")
                        Me.Cmd_Freeze.Enabled = False
                    Else
                        Me.lbl_Freeze.Visible = False
                        Me.Cmd_Freeze.Enabled = True
                        Me.lbl_Freeze.Text = "Record Void  On "
                        Me.Cmd_Freeze.Text = "Void[F8]"
                    End If
                    '''************************************************* SELECT RECORD FROM STOCKADJUSTEDDETAILS *********************************************''''                
                    sqlstring = "SELECT ISNULL(D.DOCDETAILS,'') AS DOCDETAILS,D.DOCDATE AS DOCDATE,ISNULL(D.STORELOCATIONCODE,'') AS STORELOCATIONCODE,  "
                    sqlstring = sqlstring & " ISNULL(D.STORELOCATIONDESC,'') AS STORELOCATIONDESC,ISNULL(D.ITEMCODE,'') AS ITEMCODE,ISNULL(D.ITEMNAME,'') AS ITEMNAME,"
                    sqlstring = sqlstring & " ISNULL(D.UOM,'') AS UOM,ISNULL(D.STOCKINHAND,0) AS STOCKINHAND,ISNULL(D.PHYSICALSTOCK,0) AS PHYSICALSTOCK,"
                    sqlstring = sqlstring & " ISNULL(D.ADJUSTEDSTOCK,0)*-1 AS ADJUSTEDSTOCK,ISNULL(D.RATE,0) AS RATE,ISNULL(D.AMOUNT,0)*-1 AS AMOUNT,"
                    sqlstring = sqlstring & " isnull(d.CONSUMERCODE,'') as consumerCODE,"
                    sqlstring = sqlstring & " ISNULL(D.GROUPCODE,'') AS GROUPCODE,ISNULL(D.SUBGROUPCODE,'') AS SUBGROUPCODE FROM STOCKADJUSTDETAILS AS D WHERE  TTYPE='C' AND ISNULL(D.DOCDETAILS,'')='" & Trim(txt_Docno.Text) & "'"
                    gconnection.getDataSet(sqlstring, "STOCKCONSUMTIONDETAILS")
                    If gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows.Count > 0 Then
                        For i = 1 To gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows.Count
                            Call GridUOM(i)
                            ssgrid.Row = i
                            ssgrid.SetText(1, i, Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(j).Item("ITEMCODE")))
                            Stritemcode = Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(j).Item("ITEMCODE"))
                            ssgrid.SetText(2, i, Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(j).Item("ITEMNAME")))

                            ssgrid.Col = 3
                            ssgrid.Row = i
                            ssgrid.TypeComboBoxString = Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(j).Item("UOM"))
                            ssgrid.Text = Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(j).Item("UOM"))
                            ssgrid.SetText(4, i, Val(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(j).Item("ADJUSTEDSTOCK")))
                            '                            ssgrid.SetText(12, i, Format(Val(gdataset.Tables("STOCKADJUSTDETAILS").Rows(j).Item("STOCKINHAND")), "0.000"))
                            ssgrid.SetText(5, i, Format(Val(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(j).Item("RATE")), "0.00"))
                            ssgrid.SetText(6, i, Format(Val(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(j).Item("AMOUNT")), "0.00"))
                            ssgrid.SetText(7, i, Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(j).Item("consumerCODE")))
                            '   ssgrid.SetText(14, i, Format(Val(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(j).Item("DBLAMOUNT")), "0.00"))
                            '  ssgrid.SetText(8, i, Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(j).Item("DBLCONV")))
                            ' ssgrid.SetText(9, i, Format(Val(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(j).Item("HIGHRATIO")), "0.00"))
                            ssgrid.SetText(8, i, Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(j).Item("GROUPCODE")))
                            ssgrid.SetText(9, i, Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(j).Item("SUBGROUPCODE")))

                            Dim SQL As String = "SELECT ISNULL(SUM(QTY*MF),0) FROM CLOSINGVLAUE('" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "','" & gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(j).Item("ITEMCODE") & "' ,'" & Trim(txt_Storecode.Text) & "','" & Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(j).Item("UOM")) & "')"
                            Dim cls As Double = gconnection.getvalue(SQL)

                            ' Clsquantity = ClosingQuantity(Trim(gdataset.Tables("STOCKADJUSTDETAILS").Rows(j).Item("ITEMCODE")), Trim(txt_Storecode.Text))
                            ssgrid.SetText(10, i, Format(Val(cls), "0.00"))
                            j = j + 1
                        Next i
                    End If
                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If
                    TotalCount = gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows.Count
                    ssgrid.SetActiveCell(1, 1)
                End If
            Catch ex As Exception
                MessageBox.Show("Enter valid DOC No :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If
    End Sub
    Private Sub GridUOM(ByVal i As Integer)
        Try
            Dim j As Integer
            sqlstring = "SELECT UOMdesc FROM UOMMaster WHERE freeze='N'"
            gconnection.getDataSet(sqlstring, "UOMMaster1")
            If gdataset.Tables("UOMMaster1").Rows.Count > 0 Then
                For j = 0 To gdataset.Tables("UOMMaster1").Rows.Count - 1
                    ssgrid.Col = 3
                    ssgrid.Row = i
                    ssgrid.TypeComboBoxString = Trim(gdataset.Tables("UOMMaster1").Rows(j).Item("UOMdesc"))
                    ssgrid.Text = Trim(gdataset.Tables("UOMMaster1").Rows(j).Item("UOMdesc"))
                Next j
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub autogenerate()
        Try
            Dim sqlstring, financalyear As String
            gcommand = New SqlCommand
            financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialyearEnd, 3, 4)
            If cbo_Storelocation.Text = "MAIN STORE" Then
                docno = "MAIN"
            Else
                docno = doctype
            End If
            sqlstring = "SELECT MAX(Cast(SUBSTRING(DOCNO,1,6) As Numeric)) FROM STOCKADJUSTHEADER WHERE TTYPE='C'"
            gconnection.openConnection()
            gcommand.CommandText = sqlstring
            gcommand.CommandType = CommandType.Text
            gcommand.Connection = gconnection.Myconn
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then
                If gdreader(0) Is System.DBNull.Value Then
                    txt_Docno.Text = docno & "/000001/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                Else
                    txt_Docno.Text = docno & "/" & Format(gdreader(0) + 1, "000000") & "/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If
            Else
                txt_Docno.Text = docno & "/000001/" & financalyear
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub cbo_Storelocation_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If Cmd_Add.Text = "Add [F7]" Then
                Dim i As Integer
                '''******************************* Fill Corresponding Storecode *****************************************'''
                sqlstring = "SELECT ISNULL(STORECODE,'') AS STORECODE FROM STOREMASTER WHERE STORECODE ='" & Trim(cbo_Storelocation.Text) & "'"
                gconnection.getDataSet(sqlstring, "STOREMASTER")
                If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
                    txt_Storecode.Text = Trim(gdataset.Tables("STOREMASTER").Rows(i).Item("STORECODE"))
                    txt_Storecode.ReadOnly = True
                End If
                '''******************************* End Store Code *****************************************'''
                If cbo_Storelocation.Text = "MAIN STORE" Then
                    Call autogenerate()
                Else
                    doctype = Trim(txt_Storecode.Text)
                    Call autogenerate()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Docno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Docno.KeyDown
        Try
            If e.KeyCode = Keys.F4 Then
                If cmd_Docnohelp.Enabled = True Then
                    search = Trim(txt_Docno.Text)
                    Call cmd_Docnohelp_Click(cmd_Docnohelp, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Docno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Docno.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                If Trim(txt_Docno.Text) = "" Then
                    Call cmd_Docnohelp_Click(cmd_Docnohelp, e)
                Else
                    txt_Docno_Validated(txt_Docno, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub CONSUMPTION_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Try
            StockAdjustmentTransbool = False
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub ssgrid_LeaveCell(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles ssgrid.LeaveCell
        Dim sqlstring, Itemcode, Itemdesc As String
        Dim Issuerate, Highratio, Dblamount, conv As Double
        Dim ItemQty, ItemAmount, ItemRate As Double
        Dim Avgrate, Clsquantity As Double
        Dim focusbool As Boolean
        Dim i, j As Integer
        search = Nothing
        Try
            i = ssgrid.ActiveRow
            If ssgrid.ActiveCol = 2 Then
                Dim SS, VAR As String
                SS = ssgrid.GetText(1, i, VAR)
                If VAR = "" Then
                    ssgrid.SetActiveCell(1, i)
                End If
            End If
            If ssgrid.ActiveCol = 3 Then
                ssgrid.Col = 1
                Itemcode = ssgrid.Text
                ssgrid.Col = 3
                Dim uomc As String = ssgrid.Text
                Dim cls As Double = gconnection.closing(Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy"), Trim(Itemcode), Trim(txt_Storecode.Text), Trim(uomc))
                ssgrid.SetText(9, ssgrid.ActiveRow, Format(Val(cls), "0.00"))
                LabelClosingQuantity.Text = "Closing Stock For Item " & Trim(Itemcode) & " Is " & Format(Val(cls), "0.00") & " Qty"
                conv = changerate(uomc, Trim(Itemcode))
                Dim purchaserate As Double = Format(Val(ItemRate), "0.00")
                Dim sql1 As String = "select purchaserate from inventoryitemmaster where itemcode='" & Itemcode & "' and storecode='" & txt_Storecode.Text & "' and isnull(Freeze,'')<>'Y'"
                gconnection.getDataSet(sql1, "INVENTORYROL")
                If (gdataset.Tables("INVENTORYROL").Rows.Count > 0) Then
                    purchaserate = Convert.ToDouble(gdataset.Tables("INVENTORYROL").Rows(0).Item("purchaserate"))
                End If


                purchaserate = purchaserate / conv
                ssgrid.SetText(5, i, Val(purchaserate))


            ElseIf ssgrid.ActiveCol = 4 Then

                Dim CQty As Double
                ssgrid.Col = 10
                ssgrid.Row = i
                CQty = Val(ssgrid.Text)

                ssgrid.Col = 4
                ssgrid.Row = i
                If ssgrid.Lock = False Then
                    If Val(ssgrid.Text) = 0 Then
                        ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                    ElseIf Val(ssgrid.Text) > CQty Then
                        ' MsgBox("ISSUING QTY CANNOT BE GREATER THAN CLOSING QTY")
                        ssgrid.Text = 0
                        ssgrid.Focus()
                        ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                        Exit Sub
                    Else
                        Call Calculate() '''--> Calculate total amount
                        ssgrid.Row = ssgrid.ActiveRow + 1
                        ssgrid.Col = 1
                        ssgrid.Lock = False
                        ssgrid.Col = 2
                        ssgrid.Lock = False
                        ssgrid.Col = 3
                        ssgrid.Lock = False
                        ssgrid.Col = 4
                        ssgrid.Lock = False
                        ssgrid.Col = 5
                        ssgrid.Lock = False
                        ssgrid.Col = 6
                        ssgrid.Lock = False

                        ssgrid.SetActiveCell(7, ssgrid.ActiveRow)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub GetRights()
        Try
            Dim i, j, k, x As Integer
            Dim vmain, vsmod, vssmod As Long
            Dim ssql, SQLSTRING As String
            Dim M1 As New MainMenu
            Dim chstr As String
            GmoduleName = "CONSUMPTION"

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
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Print.Click

        gPrint = True
        Try

            ' If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Group Master") = MsgBoxResult.Yes Then
            Dim rViewer As New Viewer
            Dim sqlstring, SSQL, FROMSTORE As String
            Dim r As New Rpt_StkconsBill
            sqlstring = "SELECT ISNULL(DOCDETAILS,'') AS DOCDETAILS,DOCDATE AS DOCDATE,ISNULL(STORELOCATIONCODE,'') AS STORELOCATIONCODE, "
            sqlstring = sqlstring & " ISNULL(STORELOCATIONDESC,'') AS STORELOCATIONDESC,ISNULL(ITEMCODE,'') AS ITEMCODE, ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM, "
            sqlstring = sqlstring & " ISNULL(STOCKINHAND,0) AS STOCKINHAND, ISNULL(PHYSICALSTOCK,0) AS PHYSICALSTOCK, ISNULL(ADJUSTEDSTOCK,0) AS ADJUSTEDSTOCK,ISNULL(RATE,0) AS RATE, "
            sqlstring = sqlstring & " ISNULL(AMOUNT,0) AS AMOUNT,isnull(REMARKS,'') AS REMARKS,ISNULL(consumercode,'') AS consumercode,ISNULL(UPDFOOTER,'') AS UPDFOOTER ,ISNULL(UPDSIGN,'') AS UPDSIGN,ISNULL(REMARKS_DET,'') AS REMARKS_DET, isnull(ADDDATE,'') as ADDDATE  FROM vw_inv_stkconsumebill "
            '  sqlstring = sqlstring & " "
            sqlstring = sqlstring & " WHERE DOCDETAILS='" & Trim(txt_Docno.Text) & "'"
            sqlstring = sqlstring & " ORDER BY DOCDETAILS,DOCDATE"

            gconnection.getDataSet(sqlstring, "vw_inv_stkconsumebill")
            If gdataset.Tables("vw_inv_stkconsumebill").Rows.Count > 0 Then
                'If chk_excel.Checked = True Then
                '    Dim exp As New exportexcel
                '    exp.Show()
                '    Call exp.export(sqlstring, "STOCK ADJUSTMENT ", "")
                '  Else
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "vw_inv_stkconsumebill"
                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text13")
                textobj1.Text = MyCompanyName

                Dim textobj2 As TextObject
                textobj2 = r.ReportDefinition.ReportObjects("Text21")
                textobj2.Text = gUsername

                rViewer.Show()
                '  End If
            Else
                MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
            End If

            '''Else
            '''gPrint = False
            '''Dim i As Integer
            '''Dim objStockadjustmentreport As New rptStockadjustmentreport
            '''Call checkValidation() '''--> Check Validation
            '''If boolchk = False Then Exit Sub
            '''Dim sqlstring = "SELECT ISNULL(H.DOCDETAILS,'') AS DOCDETAILS,H.DOCDATE AS DOCDATE,ISNULL(H.STORELOCATIONCODE,'') AS STORELOCATIONCODE, "
            '''sqlstring = sqlstring & " ISNULL(H.STORELOCATIONDESC,'') AS STORELOCATIONDESC,ISNULL(D.ITEMCODE,'') AS ITEMCODE, ISNULL(D.ITEMNAME,'') AS ITEMNAME,ISNULL(D.UOM,'') AS UOM, "
            '''sqlstring = sqlstring & " ISNULL(D.STOCKINHAND,0) AS STOCKINHAND, ISNULL(D.PHYSICALSTOCK,0) AS PHYSICALSTOCK, ISNULL(D.ADJUSTEDSTOCK,0) AS ADJUSTEDSTOCK,ISNULL(D.RATE,0) AS RATE, "
            '''sqlstring = sqlstring & " ISNULL(D.AMOUNT,0) AS AMOUNT,isnull(REMARKS,'') AS REMARKS,ISNULL(H.UPDFOOTER,'') AS UPDFOOTER ,ISNULL(H.UPDSIGN,'') AS UPDSIGN FROM STOCKADJUSTHEADER AS H INNER JOIN "
            '''sqlstring = sqlstring & " STOCKADJUSTDETAILS AS D ON D.DOCDETAILS = H.DOCDETAILS"
            '''sqlstring = sqlstring & " WHERE H.DOCDETAILS='" & Trim(txt_Docno.Text) & "'"
            '''sqlstring = sqlstring & " ORDER BY DOCDETAILS,DOCDATE"
            '''Dim arraystring() As String = {"ITEM CODE", "ITEM NAME", "UOM", "STOCKINHAND", "PHYSICALSTOCK", "ADJUSTEDSTOCK", "RATE", "AMOUNT"}
            '''Dim heading() As String = {"STOCK ADJUSTMENT"}
            '''Dim colsize() As Integer = {15, 30, 12, 16, 16, 16, 10, 10}
            '''objStockadjustmentreport.ReportDetails(sqlstring, heading, arraystring, colsize)
            '''End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub cmd_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_export.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "vw_inv_stkconsumebill"
        sqlstring = "select * from vw_inv_stkconsumebill"
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub
    End Sub

    Private Sub btn_validation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_validation.Click
        Authocheck("INVENTORY", "CONSUMPTION", gUsername, "STOCKADJUSTHEADER", "DOCDETAILS", Me)

    End Sub

  

    
End Class
