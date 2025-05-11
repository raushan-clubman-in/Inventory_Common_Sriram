
Public Class exportexcel
    Inherits System.Windows.Forms.Form
    Dim vconn As New GlobalClass
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
    Friend WithEvents ssgrid As AxFPSpreadADO.AxfpSpread
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(exportexcel))
        Me.ssgrid = New AxFPSpreadADO.AxfpSpread()
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ssgrid
        '
        Me.ssgrid.DataSource = Nothing
        Me.ssgrid.Location = New System.Drawing.Point(16, 8)
        Me.ssgrid.Name = "ssgrid"
        Me.ssgrid.OcxState = CType(resources.GetObject("ssgrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid.Size = New System.Drawing.Size(984, 432)
        Me.ssgrid.TabIndex = 0
        '
        'exportexcel
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1008, 482)
        Me.Controls.Add(Me.ssgrid)
        Me.Name = "exportexcel"
        Me.Text = "exportexcel"
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub exportexcel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Public Sub export(ByVal sqlstring As String, ByVal heading As String, ByVal orderby As String)
        Dim I, J, K As Integer
        Dim datatype As String
        vconn.getDataSet(sqlstring, "GROUP")
        ssgrid.ClearRange(1, 1, -1, -1, False)
        If gdataset.Tables("GROUP").Rows.Count > 0 Then
            With ssgrid
                .Row = 1
                .Col = 1
                .Text = heading
                For K = 0 To gdataset.Tables("GROUP").Columns.Count - 1
                    .Row = 2
                    .Col = K + 1
                    .Text = gdataset.Tables("GROUP").Columns(K).ColumnName
                Next
                For I = 0 To gdataset.Tables("GROUP").Rows.Count - 1
                    .Row = I + 3
                    For J = 0 To gdataset.Tables("GROUP").Columns.Count - 1
                        .Col = J + 1
                        datatype = UCase(gdataset.Tables("GROUP").Columns(J).DataType.Name)
                        If datatype = "NUMERIC" Or datatype = "NUMBER" Or datatype = "INT" Or datatype = "DECIMAL" Then
                            .Text = gdataset.Tables("GROUP").Rows(I).Item(J)
                            .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                        ElseIf datatype = "DATETIME" Then
                            '.Text = Format(gdataset.Tables("GROUP").Rows(I).Item(J), "dd/MMM/yyyy")
                            .Text = gdataset.Tables("GROUP").Rows(I).Item(J)
                            .CellType = FPSpreadADO.CellTypeConstants.CellTypeDate
                        Else
                            If IsDBNull(gdataset.Tables("GROUP").Rows(I).Item(J)) = False Then
                                .Text = gdataset.Tables("GROUP").Rows(I).Item(J)
                            End If
                            .CellType = FPSpreadADO.CellTypeConstants.CellTypeEdit
                            End If
                    Next
                    .MaxRows = .MaxRows + 1
                Next
            End With
            Me.ssgrid.Visible = True
        End If
        Call ExportTo(ssgrid)
        Me.Close()
    End Sub

    Public Sub export_Con_Issue(ByVal sqlstring As String, ByVal heading As String, ByVal FROMDATE As String, ByVal orderby As String, ByVal MStore As String, ByVal SubStore As String)

        Dim I, J, K As Integer
        Dim datatype, SubStore1() As String
        SubStore1 = Split(SubStore, ",")
        vconn.getDataSet(sqlstring, "GROUP")
        ssgrid.ClearRange(1, 1, -1, -1, False)
        If gdataset.Tables("GROUP").Rows.Count > 0 Then

            With ssgrid

                .Row = 1
                .Col = 1
                .Text = "STORE NAME : "
                .Row = 1
                .Col = 2
                .Text = orderby
                .Row = 2
                .Col = 3
                .Text = "ITEM WISE CONSOLIDATED ISSUE FROM " + orderby + " FROM  " + FROMDATE
                .Row = 3
                .Col = 3
                .Text = "ISSUED TO KITCHENS:" + MStore
                For K = 0 To SubStore1.Length - 1
                    .Row = 4
                    .Col = (4 * K) + 4
                    .Text = SubStore1(K)
             
                Next
                For K = 0 To SubStore1.Length * 2 - 1
                    .Row = 5

                    If K Mod 2 = 0 Then
                        .Col = (2 * K) + 4
                        .Text = Date.Now.Year.ToString()
                        .Col = ((2 * K) + 4) + 1
                        .Text = (Date.Now.Year).ToString()
                    Else
                        If K = 0 Then
                            .Col = (2 * K) + 4
                            .Text = Date.Now.Year.ToString()
                            .Col = ((2 * K) + 4) + 1
                            .Text = (Date.Now.Year).ToString()

                        Else
                            .Col = (2 * K) + 4
                            .Text = (Date.Now.Year) - 1.ToString()
                            .Col = ((2 * K) + 4) + 1
                            .Text = (Date.Now.Year) - 1.ToString()

                        End If

                    End If

                Next


                For K = 0 To gdataset.Tables("GROUP").Columns.Count - 1
                    .Row = 6
                    .Col = K + 1
                    .Text = gdataset.Tables("GROUP").Columns(K).ColumnName
                Next
                For I = 0 To gdataset.Tables("GROUP").Rows.Count - 1
                    .Row = I + 7
                    For J = 0 To gdataset.Tables("GROUP").Columns.Count - 1
                        .Col = J + 1
                        datatype = UCase(gdataset.Tables("GROUP").Columns(J).DataType.Name)
                        If datatype = "NUMERIC" Or datatype = "NUMBER" Or datatype = "INT" Or datatype = "DECIMAL" Then
                            .Text = gdataset.Tables("GROUP").Rows(I).Item(J)
                            .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                        ElseIf datatype = "DATETIME" Then
                            .Text = Format(gdataset.Tables("GROUP").Rows(I).Item(J), "dd/MMM/yyyy")
                            .CellType = FPSpreadADO.CellTypeConstants.CellTypeDate
                        Else
                            If IsDBNull(gdataset.Tables("GROUP").Rows(I).Item(J)) = False Then
                                .Text = gdataset.Tables("GROUP").Rows(I).Item(J)
                            End If
                            .CellType = FPSpreadADO.CellTypeConstants.CellTypeEdit
                        End If
                    Next
                    .MaxRows = .MaxRows + 1
                Next
            End With
            Me.ssgrid.Visible = True
        End If
        Call ExportTo(ssgrid)
        Me.Close()
    End Sub


    Public Sub exportRSI(ByVal sqlstring As String, ByVal heading1 As String, ByVal heading2 As String, ByVal orderby As String, ByVal sqlsTot As String)
        Dim I, J, K, M, N As Integer
        Dim datatype As String
        Dim cloumnName As String
        vconn.getDataSet(sqlstring, "GROUP")
        vconn.getDataSet(sqlsTot, "GRANDTOTAL")
        ssgrid.ClearRange(1, 1, -1, -1, False)
        If gdataset.Tables("GROUP").Rows.Count > 0 Then
            With ssgrid
                .Row = 1
                .Col = 1
                .Text = heading1
                .FontBold = True
                .FontSize = 15
                .Row = 2
                .Col = 1
                .Text = "POSN AS ON"
                .FontBold = True
                .FontSize = 12
                For K = 0 To gdataset.Tables("GROUP").Columns.Count - 1
                    .Row = 3
                    .Col = K + 1
                    .Text = gdataset.Tables("GROUP").Columns(K).ColumnName
                    .FontBold = True
                    .FontSize = 10
                    N = K
                Next
                .Row = 2
                .Col = N
                .Text = heading2
                .FontBold = True
                .FontSize = 12


                For I = 0 To gdataset.Tables("GROUP").Rows.Count - 1
                    .Row = I + 4
                    For J = 0 To gdataset.Tables("GROUP").Columns.Count - 1
                        .Col = J + 1
                        datatype = UCase(gdataset.Tables("GROUP").Columns(J).DataType.Name)
                        If datatype = "NUMERIC" Or datatype = "NUMBER" Or datatype = "INT" Or datatype = "DECIMAL" Then
                            .Text = gdataset.Tables("GROUP").Rows(I).Item(J)
                            .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                        ElseIf datatype = "DATETIME" Then
                            .Text = Format(gdataset.Tables("GROUP").Rows(I).Item(J), "dd/MMM/yyyy")
                            .CellType = FPSpreadADO.CellTypeConstants.CellTypeDate
                        Else
                            If IsDBNull(gdataset.Tables("GROUP").Rows(I).Item(J)) = False Then
                                .Text = gdataset.Tables("GROUP").Rows(I).Item(J)
                            End If
                            .CellType = FPSpreadADO.CellTypeConstants.CellTypeEdit
                        End If
                    Next
                    .MaxRows = .MaxRows + 1
                    M = I
                Next
                For K = 0 To gdataset.Tables("GRANDTOTAL").Columns.Count - 1
                    .Row = M + 5
                    .Col = K + 1
                    cloumnName = gdataset.Tables("GRANDTOTAL").Columns(K).ColumnName
                    .Text = gdataset.Tables("GRANDTOTAL").Rows(0).Item(cloumnName)
                    .FontBold = True
                    .FontSize = 12
                Next

                .Row = M + 8
                .Col = 1
                .Text = "Presiding Officer"
                .FontBold = True
                .FontSize = 10
                .Row = M + 8
                .Col = 3
                .Text = "   _______________"

                .Row = M + 10
                .Col = 1
                .Text = "Members"
                .FontBold = True
                .FontSize = 10
                .Row = M + 10
                .Col = 3
                .Text = "1. _______________"
                .Row = M + 12
                .Col = 3
                .Text = "2. _______________"


            End With
            Me.ssgrid.Visible = True
        End If
        Call ExportTo(ssgrid)
        Me.Close()
    End Sub
End Class
