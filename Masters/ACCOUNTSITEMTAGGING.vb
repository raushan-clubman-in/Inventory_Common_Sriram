
Public Class ACCOUNTSITEMTAGGING

    Inherits System.Windows.Forms.Form
    Dim Vconn As New GlobalClass
    Friend WithEvents SSMatching As AxFPSpreadADO.AxfpSpread
    Dim SQLSTRING, str, str1 As String
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ssgrid1 As AxFPSpreadADO.AxfpSpread
    Friend WithEvents cmd_update As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_validation As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ACCOUNTSITEMTAGGING))
        Me.ssgrid1 = New AxFPSpreadADO.AxfpSpread()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cmd_update = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_validation = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.ssgrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ssgrid1
        '
        Me.ssgrid1.DataSource = Nothing
        Me.ssgrid1.Location = New System.Drawing.Point(190, 175)
        Me.ssgrid1.Name = "ssgrid1"
        Me.ssgrid1.OcxState = CType(resources.GetObject("ssgrid1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid1.Size = New System.Drawing.Size(646, 537)
        Me.ssgrid1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Image = Global.Inventory.My.Resources.Resources.Clear
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(9, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(134, 56)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Clear"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(856, 568)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 40)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "View"
        Me.Button2.Visible = False
        '
        'cmd_update
        '
        Me.cmd_update.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_update.ForeColor = System.Drawing.Color.Black
        Me.cmd_update.Image = Global.Inventory.My.Resources.Resources.save
        Me.cmd_update.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_update.Location = New System.Drawing.Point(9, 106)
        Me.cmd_update.Name = "cmd_update"
        Me.cmd_update.Size = New System.Drawing.Size(134, 56)
        Me.cmd_update.TabIndex = 1
        Me.cmd_update.Text = "Update"
        Me.cmd_update.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Black
        Me.Button4.Image = Global.Inventory.My.Resources.Resources._Exit
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(7, 195)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(134, 56)
        Me.Button4.TabIndex = 1
        Me.Button4.Text = "Exit"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.cmd_update)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Location = New System.Drawing.Point(859, 241)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(148, 299)
        Me.Panel1.TabIndex = 2
        '
        'btn_validation
        '
        Me.btn_validation.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_validation.ForeColor = System.Drawing.Color.Black
        Me.btn_validation.Location = New System.Drawing.Point(848, 617)
        Me.btn_validation.Name = "btn_validation"
        Me.btn_validation.Size = New System.Drawing.Size(88, 40)
        Me.btn_validation.TabIndex = 2
        Me.btn_validation.Text = "Validation"
        Me.btn_validation.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(182, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(336, 25)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "ACCOUNTS ITEM TAGGING"
        '
        'ACCOUNTSITEMTAGGING
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.BackgroundImage = Global.Inventory.My.Resources.Resources._111in1024res
        Me.ClientSize = New System.Drawing.Size(1016, 734)
        Me.Controls.Add(Me.btn_validation)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ssgrid1)
        Me.Controls.Add(Me.Button2)
        Me.Name = "ACCOUNTSITEMTAGGING"
        Me.Text = "ACCOUNTSITEMTAGGING"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ssgrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ACCOUNTSITEMTAGGING_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i, j As Integer

        str1 = "alter table inventoryitemmaster add Ledger varchar(50)"
        Vconn.dataOperation1(6, str1, "item")

        SQLSTRING = "select a.itemcode,a.itemname ,isnull(a.groupcode,'') as groupcode,isnull(a.groupname,'') as groupname,isnull(a.Ledger,'') as Ledger from inventoryitemmaster a left outer join accountsglaccountmaster b on a.ledger=b.accode where isnull(a.freeze,'')<>'Y' and isnull(b.freezeflag,'')<>'Y' and a.storecode IN ('MNS','MNS1') order by b.acdesc,a.itemcode "
        Vconn.getDataSet(SQLSTRING, "acctag")
        If gdataset.Tables("acctag").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("acctag").Rows.Count - 1
                j = i + 1
                With ssgrid1
                    .Row = j
                    .Col = 1
                    .Text = gdataset.Tables("acctag").Rows(i).Item("itemcode")
                    .Col = 2
                    .Text = gdataset.Tables("acctag").Rows(i).Item("itemname")
                    .Col = 3
                    .Text = gdataset.Tables("acctag").Rows(i).Item("groupcode")
                    .Col = 4
                    .Text = gdataset.Tables("acctag").Rows(i).Item("groupname")
                    .Col = 5
                    .Text = gdataset.Tables("acctag").Rows(i).Item("Ledger")
                End With
                ssgrid1.MaxRows = ssgrid1.MaxRows + 1
            Next
        End If
    End Sub
    Private Sub SSMatching_DblClick(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_DblClickEvent) Handles SSMatching.DblClick



    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub ssgrid1_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles ssgrid1.Advance

    End Sub

    'Private Sub ssgrid1_DblClick(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_DblClickEvent) Handles ssgrid1.DblClick
    '    Dim ssql As String
    '    Dim itemcode, itemdesc As String

    '    With ssgrid1
    '        .Col = 1
    '        .Row = .ActiveRow
    '        itemcode = .Text
    '        .Col = 2
    '        .Row = .ActiveRow
    '        itemdesc = .Text
    '    End With
    '    SQLSTRING = "select a.itemcode,a.itemdesc ,isnull(a.salesacctin,'') as accode,isnull(b.acdesc,'') as acdesc  from itemmaster a left outer join accountsglaccountmaster b on a.salesacctin=b.accode where isnull(a.freeze,'')<>'Y' and isnull(b.freezeflag,'')<>'Y' order by b.acdesc,a.itemcode "
    '    Vconn.getDataSet(SQLSTRING, "acctag")

    '    If gdataset.Tables("acctag").Rows.Count = 0 Then
    '        Exit Sub
    '    End If
    '    If gdataset.Tables("acctag").Rows.Count > 1 Then
    '        Exit Sub
    '    End If
    'End Sub

    Private Sub ssgrid1_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssgrid1.KeyDownEvent
        With ssgrid1
            If .ActiveCol = 3 Then
                .Row = .ActiveRow
                If .Text = "" Then
                    Call FillMenu()
                End If
            End If
            If .Col = 4 Then
                .Row = .ActiveRow
                If .Text = "" Then
                    Call FillMenu()
                End If
            End If
        End With
    End Sub
    Private Sub FillMenu()
        Dim vform As New ListOperattion1
        Dim ssql As String
        '''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO SSGRID ********** 
        gSQLString = "select accode,acdesc from accountsglaccountmaster "

        'gSQLString = "SELECT DISTINCT I.ITEMCODE,I.ITEMDESC,I.BASERATESTD,I.ITEMTYPECODE,TL.TAXCODE,TL.TAXPERCENTAGE, ISNULL(TL.ACCOUNTCODE,'') "
        'gSQLString = gSQLString & " AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.OPENFACILITY,'') AS OPENFACILITY,ISNULL(I.SALESACCTIN,'') AS SALESACCTIN FROM VIEW_ITEMMASTER AS I INNER "
        'gSQLString = gSQLString & " JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE "
        If Trim(search) = " " Then
            M_WhereCondition = "WHERE   category in ('I') and ISNULL(FREEZEFLAG,'') <>'Y'"
        Else
            M_WhereCondition = " WHERE (accode LIKE '%" & search & "%' OR acdesc LIKE '%" & search & "%') AND category in ('I') and  ISNULL(FREEZEFLAG,'') <>'Y' "
        End If
        vform.Field = "ACDESC,ACCODE"
        vform.vFormatstring = "ACCODE     |ACDESC                        "
        vform.vCaption = "ITEM CODE HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1

        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With ssgrid1
                .Col = 3
                .Row = .ActiveRow
                .Text = vform.keyfield
                .Col = 4
                .Row = .ActiveRow
                .Text = vform.keyfield1

            End With
        Else
            ssgrid1.SetActiveCell(0, ssgrid1.ActiveRow)
            Exit Sub
        End If
    End Sub


    Private Sub cmd_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_update.Click
        Dim i As Integer
        Dim itemcd, acccd, ssql As String
        If ssgrid1.DataRowCnt <= 1 Then
            MsgBox("NO RECORD TO SAVE")
            Exit Sub
        End If
        With ssgrid1
            For i = 0 To ssgrid1.DataRowCnt - 1
                .Row = i + 1
                .Col = 1
                itemcd = .Text
                .Col = 5
                acccd = .Text
                ssql = "update inventoryitemmaster set Ledger='" & acccd & "' where itemcode='" & itemcd & "'"
                Vconn.dataOperation(6, ssql, "item")

            Next
        End With
        MessageBox.Show("Record Saved Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ssgrid1.ClearRange(1, 1, ssgrid1.DataColCnt, ssgrid1.DataRowCnt, False)
        Call ACCOUNTSITEMTAGGING_Load(sender, e)
    End Sub

    Private Sub btn_validation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_validation.Click
        System.Diagnostics.Process.Start(AppPath & "/STUDY/ACCOUNTSITEMTAGGING.XLS")
    End Sub
End Class
