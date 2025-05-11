Imports System.IO
Imports System.Data.SqlClient
Public Class YearEndConversion
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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDatabaseName As System.Windows.Forms.TextBox
    Friend WithEvents grpYEC As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnConvert As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btn_validation As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDatabaseName = New System.Windows.Forms.TextBox
        Me.grpYEC = New System.Windows.Forms.GroupBox
        Me.btnConvert = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.btn_validation = New System.Windows.Forms.Button
        Me.grpYEC.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(88, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(160, 23)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "New Database Name"
        '
        'txtDatabaseName
        '
        Me.txtDatabaseName.Location = New System.Drawing.Point(328, 72)
        Me.txtDatabaseName.Name = "txtDatabaseName"
        Me.txtDatabaseName.Size = New System.Drawing.Size(144, 20)
        Me.txtDatabaseName.TabIndex = 0
        Me.txtDatabaseName.Text = ""
        '
        'grpYEC
        '
        Me.grpYEC.BackColor = System.Drawing.Color.Transparent
        Me.grpYEC.Controls.Add(Me.btn_validation)
        Me.grpYEC.Controls.Add(Me.Label4)
        Me.grpYEC.Controls.Add(Me.txtDatabaseName)
        Me.grpYEC.Controls.Add(Me.btnConvert)
        Me.grpYEC.Controls.Add(Me.btnExit)
        Me.grpYEC.Location = New System.Drawing.Point(240, 120)
        Me.grpYEC.Name = "grpYEC"
        Me.grpYEC.Size = New System.Drawing.Size(512, 208)
        Me.grpYEC.TabIndex = 9
        Me.grpYEC.TabStop = False
        '
        'btnConvert
        '
        Me.btnConvert.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConvert.Location = New System.Drawing.Point(120, 144)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.TabIndex = 2
        Me.btnConvert.Text = "Update"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(360, 144)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkRed
        Me.Label5.Location = New System.Drawing.Point(344, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(304, 23)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Year End Closing Stock Updation"
        '
        'btn_validation
        '
        Me.btn_validation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_validation.Location = New System.Drawing.Point(240, 144)
        Me.btn_validation.Name = "btn_validation"
        Me.btn_validation.TabIndex = 4
        Me.btn_validation.Text = "Validation"
        '
        'YearEndConversion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.ClientSize = New System.Drawing.Size(1028, 694)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.grpYEC)
        Me.Name = "YearEndConversion"
        Me.Text = "YearEndConversion"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grpYEC.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim vconn As New GlobalClass
    Dim strSql, SSql(1) As String
    Dim sqlCmd As New SqlCommand
    Dim sqlCon As New SqlConnection
    Dim gconnection As New GlobalClass
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub btnConvert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConvert.Click
        Try
            boolyec = True
            stryecmsg = Nothing

            'gconnection.openConnection()
            'gcommand = New SqlCommand("YearEndOpeningStockUpdation", gconnection.Myconn)
            'gcommand.CommandType = CommandType.StoredProcedure
            'gcommand.CommandTimeout = 1000000000
            'gcommand.Parameters.Add(New SqlParameter("@Datafile_PrevYear", SqlDbType.VarChar)).Value = gDatabase
            'gcommand.Parameters.Add(New SqlParameter("@Datafile", SqlDbType.DateTime)).Value = Trim(txtDatabaseName.Text)
            'gcommand.Parameters.Add(New SqlParameter("@Startingdate", SqlDbType.DateTime)).Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy")
            'gcommand.Parameters.Add(New SqlParameter("@Endingdate", SqlDbType.DateTime)).Value = Format(CDate("31/03/" & gFinancialyearEnd), "dd/MM/yyyy")
            'gcommand.ExecuteNonQuery()
            'gconnection.closeConnection()

            strSql = "Exec Sp_YearEndConversion_INV '" & gDatabase & "','" & Trim(txtDatabaseName.Text) & "','" & Format(DateValue("01-04-" & gFinancalyearStart), "dd-MMM-yyyy") & "','" & Format(DateValue("31-03-" & gFinancialyearEnd), "dd-MMM-yyyy") & "'"
            vconn.ExcuteStoreProcedure(strSql)
            If boolyec = True Then
                MsgBox("Year End Conversion is Completed Successfully!", MsgBoxStyle.OKOnly, "Congrat!")
            Else
                MsgBox("Sorry!, Year End Conversion is Terminated Abnormally! Bcoz " & stryecmsg, MsgBoxStyle.OKOnly, "Congrats!")
            End If
        Catch ex As Exception
            MsgBox("Sorry!, Year End Conversion is Terminated Abnormally, Bcoz " & ex.Message.ToString(), MsgBoxStyle.OKOnly, "Error!")
        End Try
    End Sub
    Private Sub YearEndConversion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDatabaseName.Focus()
    End Sub

    Private Sub btn_validation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_validation.Click
        System.Diagnostics.Process.Start(AppPath & "/STUDY/CARRYFORWARD.XLS")
    End Sub
End Class