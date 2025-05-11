Imports System.Drawing
Imports System.Drawing.Drawing2D
Public Class Welcome
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents lbl_Companyname As System.Windows.Forms.Label
    Friend WithEvents lbl_CompanyAddress1 As System.Windows.Forms.Label
    Friend WithEvents lbl_CompanyAddress2 As System.Windows.Forms.Label
    Friend WithEvents lbl_State As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_Username As System.Windows.Forms.Label
    Friend WithEvents lbl_Loding As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Welcome))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_Username = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.lbl_Loding = New System.Windows.Forms.Label()
        Me.lbl_Companyname = New System.Windows.Forms.Label()
        Me.lbl_CompanyAddress1 = New System.Windows.Forms.Label()
        Me.lbl_CompanyAddress2 = New System.Windows.Forms.Label()
        Me.lbl_State = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(320, 40)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CLUBMAN INVENTORY "
        '
        'lbl_Username
        '
        Me.lbl_Username.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Username.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Username.ForeColor = System.Drawing.Color.White
        Me.lbl_Username.Location = New System.Drawing.Point(600, 328)
        Me.lbl_Username.Name = "lbl_Username"
        Me.lbl_Username.Size = New System.Drawing.Size(264, 32)
        Me.lbl_Username.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(528, 315)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(525, 312)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(54, 54)
        Me.Panel1.TabIndex = 4
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10
        '
        'Timer2
        '
        Me.Timer2.Interval = 500
        '
        'lbl_Loding
        '
        Me.lbl_Loding.AutoSize = True
        Me.lbl_Loding.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Loding.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Loding.ForeColor = System.Drawing.Color.Black
        Me.lbl_Loding.Location = New System.Drawing.Point(472, 424)
        Me.lbl_Loding.Name = "lbl_Loding"
        Me.lbl_Loding.Size = New System.Drawing.Size(203, 13)
        Me.lbl_Loding.TabIndex = 5
        Me.lbl_Loding.Text = "Loading Your Personal  Rights ....."
        Me.lbl_Loding.Visible = False
        '
        'lbl_Companyname
        '
        Me.lbl_Companyname.AutoSize = True
        Me.lbl_Companyname.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Companyname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Companyname.ForeColor = System.Drawing.Color.Black
        Me.lbl_Companyname.Location = New System.Drawing.Point(80, 99)
        Me.lbl_Companyname.Name = "lbl_Companyname"
        Me.lbl_Companyname.Size = New System.Drawing.Size(62, 16)
        Me.lbl_Companyname.TabIndex = 6
        Me.lbl_Companyname.Text = "LABLE1"
        '
        'lbl_CompanyAddress1
        '
        Me.lbl_CompanyAddress1.AutoSize = True
        Me.lbl_CompanyAddress1.BackColor = System.Drawing.Color.Transparent
        Me.lbl_CompanyAddress1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CompanyAddress1.ForeColor = System.Drawing.Color.Black
        Me.lbl_CompanyAddress1.Location = New System.Drawing.Point(80, 123)
        Me.lbl_CompanyAddress1.Name = "lbl_CompanyAddress1"
        Me.lbl_CompanyAddress1.Size = New System.Drawing.Size(62, 16)
        Me.lbl_CompanyAddress1.TabIndex = 7
        Me.lbl_CompanyAddress1.Text = "LABLE2"
        '
        'lbl_CompanyAddress2
        '
        Me.lbl_CompanyAddress2.AutoSize = True
        Me.lbl_CompanyAddress2.BackColor = System.Drawing.Color.Transparent
        Me.lbl_CompanyAddress2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CompanyAddress2.ForeColor = System.Drawing.Color.Black
        Me.lbl_CompanyAddress2.Location = New System.Drawing.Point(80, 147)
        Me.lbl_CompanyAddress2.Name = "lbl_CompanyAddress2"
        Me.lbl_CompanyAddress2.Size = New System.Drawing.Size(62, 16)
        Me.lbl_CompanyAddress2.TabIndex = 8
        Me.lbl_CompanyAddress2.Text = "LABLE3"
        '
        'lbl_State
        '
        Me.lbl_State.AutoSize = True
        Me.lbl_State.BackColor = System.Drawing.Color.Transparent
        Me.lbl_State.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_State.ForeColor = System.Drawing.Color.Black
        Me.lbl_State.Location = New System.Drawing.Point(80, 171)
        Me.lbl_State.Name = "lbl_State"
        Me.lbl_State.Size = New System.Drawing.Size(62, 16)
        Me.lbl_State.TabIndex = 9
        Me.lbl_State.Text = "LABLE4"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(16, 67)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(49, 48)
        Me.PictureBox2.TabIndex = 10
        Me.PictureBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(80, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(157, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "COMPANY DETAILS :"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.lbl_State)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lbl_CompanyAddress2)
        Me.GroupBox1.Controls.Add(Me.lbl_CompanyAddress1)
        Me.GroupBox1.Controls.Add(Me.lbl_Companyname)
        Me.GroupBox1.Location = New System.Drawing.Point(1, 402)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(327, 207)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'Welcome
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1030, 755)
        Me.Controls.Add(Me.lbl_Loding)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lbl_Username)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Welcome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Welcome"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim gconnection As New GlobalClass
 
    Private Sub Welcome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim login As New Form1
        Me.DoubleBuffered = True
        Call Resize_Form()
        Call FillCompanyinfo()
        Me.DoubleBuffered = True
        lbl_Username.Text = gUsername
        Me.lbl_Loding.Visible = False
    End Sub
    Public Sub FillCompanyinfo()
        Dim sqlstring As String
        Try
            sqlstring = " SELECT ISNULL(CompanyName,'') AS CompanyName,ISNULL(Fromdate,getdate()) AS Fromdate,ISNULL(Todate,getdate()) AS Todate,ISNULL(Add1,'') AS Add1,ISNULL(Add2,'') AS Add2,"
            sqlstring = sqlstring & " ISNULL(City,'') AS City,ISNULL(State,'') AS State,ISNULL(Pincode,'') AS Pincode,ISNULL(Datafile,'') AS Datafile,ISNULL(INDATE,'01 JUL 2017') AS INDATE FROM ClubMaster "
            If Len(gDatabase) > 0 Then
                sqlstring = sqlstring & " where isnull(datafile,'')='" & gDatabase & "'"
            End If
            gconnection.getCompanyinfo(sqlstring, "ClubMaster")
            If gdataset.Tables("ClubMaster").Rows.Count > 0 Then
                MyCompanyName = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("CompanyName")))
                Me.lbl_Companyname.Text = MyCompanyName
                Address1 = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Add1")))
                Me.lbl_CompanyAddress1.Text = Address1
                Address2 = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Add2")))
                Me.lbl_CompanyAddress2.Text = Address2
                gCity = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("City")))
                gState = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("State")))
                Me.lbl_State.Text = "STATE :" & gState
                gPincode = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Pincode")))
                gDatabase = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Datafile")))
                gstartingdateNew = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Fromdate")))
                Me.Text = MyCompanyName & " [" & "INVENTORY" & " ]"
            Else
                MessageBox.Show("Plz. Contact to your System Administrator ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If PictureBox1.Top < 367 Then
            PictureBox1.Top = PictureBox1.Top + 5
            lbl_Username.Top = lbl_Username.Top + 5
            Panel1.Top = Panel1.Top + 5
        Else
            Timer1.Enabled = False
            Timer2.Enabled = True
            Me.lbl_Loding.Visible = True
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Dim sqlstring, gFinancialyearStart, gFinancialyearEnding, vCompanyname As String
        Dim CH As Boolean = False
        gFinancialyearStart = ""
        gFinancialyearEnding = ""

        Dim ObjCompanyList As New CompanyList1
        Me.Hide()
        If ShowCompany = True Then
            ObjCompanyList.Show()
        Else

            Dim LoopIndex As Integer
            
            SQLSTRING = "SELECT ISNULL(COMPANYNAME,'') AS COMPANYNAME,ISNULL(FROMDATE,GETDATE()) AS FROMDATE,ISNULL(TODATE,GETDATE()) AS TODATE,ISNULL(SHORTNAME,'') AS SHORTNAME,ISNULL(DATAFILE,'') AS DATAFILE, "
            sqlstring = sqlstring & " ISNULL(ADD1,'') AS ADD1,ISNULL(ADD2,'') AS ADD2,ISNULL(CITY,'') AS CITY,ISNULL(STATE,'') AS STATE,ISNULL(PINCODE,'') AS PINCODE,ISNULL(PHONE1,'') AS PHONE1,ISNULL(FAX,'') AS FAX,ISNULL(INDATE,'01 JUL 2017') AS INDATE FROM CLUBMASTER WHERE DATAFILE = '" & gDatabase & "' AND ISNULL(ACTIVE,'')='Y' ORDER BY SNO"
            gconnection.getCompanyinfo(SQLSTRING, "CLUBMASTER")
            If gdataset.Tables("CLUBMASTER").Rows.Count > 0 Then
                For LoopIndex = 0 To gdataset.Tables("CLUBMASTER").Rows.Count - 1
                    With gdataset.Tables("CLUBMASTER").Rows(LoopIndex)
                        gCompanyname = Trim(.Item("COMPANYNAME"))
                        gFinancialyearStart = Format(CDate(.Item("FROMDATE")), "dd/MMM/yyyy")
                        gFinancialyearEnding = Format(CDate(.Item("TODATE")), "dd/MMM/yyyy")
                        gstartingdateNew = Format(CDate(.Item("FROMDATE")), "dd/MMM/yyyy")
                        GSTSTARTdATE = Format(CDate(.Item("INDATE")), "dd/MMM/yyyy")
                        gFinancalyearStart = Year(gFinancialyearStart)
                        gFinancialyearEnd = Year(gFinancialyearEnding)
                        gFinancialyearEnd = Year(gFinancialyearEnding)
                        gDatabase = Trim(CStr(.Item("DATAFILE")))
                    End With
                Next LoopIndex

            End If

            
            CH = True

            'Dim mdiacc As New Main_MDI
            'mdiacc.Show()
            ' Dim cmplist As New CompanyList1
            ' cmplist.Show()
        End If
        Timer2.Enabled = False
        Me.lbl_Loding.Visible = False

        If CH Then
            sqlstring = " select * from master..clubmaster where cast(GETDATE() as Date) between '" + Format(CDate(gFinancialyearStart), "dd/MMM/yyyy") + "' and '" + Format(CDate(gFinancialyearEnding), "dd/MMM/yyyy") + "' AND  DATAFILE = '" & gDatabase & "' "
            gconnection.getCompanyinfo(sqlstring, "CLUBMASTER")
            If gdataset.Tables("CLUBMASTER").Rows.Count > 0 Then
                Dim mdiacc As New Main_MDI
                mdiacc.Show()

            Else

                If MsgBox(" ENTRY IS GOING TO BE IN PREVIOUNS YEAR DATABASE ! DO YOU WANT TO PROCEED ", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                    gFyear = True
                    Dim mdiacc As New Main_MDI

                    mdiacc.Show()
                Else
                    Application.Exit()
                    End
                End If

            End If


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
                        ElseIf Controls(i_i).Name = "grp_order1by" Then
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

End Class
