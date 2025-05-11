Public Class frmSearch_Advanced
    Inherits System.Windows.Forms.Form
    Public chklistbox As CheckedListBox
    Public boolSearchResult As Boolean
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
    Friend WithEvents grp_search As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_clear As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmd_okay As System.Windows.Forms.Button
    Friend WithEvents cmd_cancel As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lst_SelectItems As System.Windows.Forms.ListBox
    Friend WithEvents lst_items As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grp_search = New System.Windows.Forms.GroupBox
        Me.cmd_clear = New System.Windows.Forms.Button
        Me.cmd_okay = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmd_cancel = New System.Windows.Forms.Button
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.lst_SelectItems = New System.Windows.Forms.ListBox
        Me.lst_items = New System.Windows.Forms.ListBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'grp_search
        '
        Me.grp_search.BackColor = System.Drawing.Color.Transparent
        Me.grp_search.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_search.Location = New System.Drawing.Point(16, 24)
        Me.grp_search.Name = "grp_search"
        Me.grp_search.Size = New System.Drawing.Size(776, 256)
        Me.grp_search.TabIndex = 470
        Me.grp_search.TabStop = False
        '
        'cmd_clear
        '
        Me.cmd_clear.BackColor = System.Drawing.Color.Transparent
        Me.cmd_clear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_clear.ForeColor = System.Drawing.Color.Black
        Me.cmd_clear.Location = New System.Drawing.Point(200, 296)
        Me.cmd_clear.Name = "cmd_clear"
        Me.cmd_clear.Size = New System.Drawing.Size(112, 32)
        Me.cmd_clear.TabIndex = 471
        Me.cmd_clear.Text = "Refresh [F6]"
        '
        'cmd_okay
        '
        Me.cmd_okay.BackColor = System.Drawing.Color.Transparent
        Me.cmd_okay.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_okay.ForeColor = System.Drawing.Color.Black
        Me.cmd_okay.Location = New System.Drawing.Point(344, 296)
        Me.cmd_okay.Name = "cmd_okay"
        Me.cmd_okay.Size = New System.Drawing.Size(112, 32)
        Me.cmd_okay.TabIndex = 472
        Me.cmd_okay.Text = "OKAY [F7]"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label2.Location = New System.Drawing.Point(8, 330)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(792, 16)
        Me.Label2.TabIndex = 473
        Me.Label2.Text = "Press 'Delete' to Remove Items /  Press 'Enter' to Choose Items"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd_cancel
        '
        Me.cmd_cancel.BackColor = System.Drawing.Color.Transparent
        Me.cmd_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmd_cancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_cancel.ForeColor = System.Drawing.Color.Black
        Me.cmd_cancel.Location = New System.Drawing.Point(480, 296)
        Me.cmd_cancel.Name = "cmd_cancel"
        Me.cmd_cancel.Size = New System.Drawing.Size(112, 32)
        Me.cmd_cancel.TabIndex = 474
        Me.cmd_cancel.Text = "Cancel"
        '
        'txtSearch
        '
        Me.txtSearch.BackColor = System.Drawing.SystemColors.Info
        Me.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearch.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(160, 48)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(232, 31)
        Me.txtSearch.TabIndex = 477
        Me.txtSearch.Text = ""
        '
        'lst_SelectItems
        '
        Me.lst_SelectItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lst_SelectItems.ItemHeight = 16
        Me.lst_SelectItems.Location = New System.Drawing.Point(412, 88)
        Me.lst_SelectItems.Name = "lst_SelectItems"
        Me.lst_SelectItems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lst_SelectItems.Size = New System.Drawing.Size(360, 180)
        Me.lst_SelectItems.TabIndex = 476
        '
        'lst_items
        '
        Me.lst_items.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lst_items.ItemHeight = 16
        Me.lst_items.Location = New System.Drawing.Point(48, 88)
        Me.lst_items.Name = "lst_items"
        Me.lst_items.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lst_items.Size = New System.Drawing.Size(344, 180)
        Me.lst_items.TabIndex = 475
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(48, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 25)
        Me.Label1.TabIndex = 478
        Me.Label1.Text = "Search Text :"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(360, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 25)
        Me.Label3.TabIndex = 479
        Me.Label3.Text = "SEARCH"
        '
        'frmSearch_Advanced
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.ClientSize = New System.Drawing.Size(808, 350)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.lst_SelectItems)
        Me.Controls.Add(Me.lst_items)
        Me.Controls.Add(Me.cmd_cancel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmd_okay)
        Me.Controls.Add(Me.cmd_clear)
        Me.Controls.Add(Me.grp_search)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSearch_Advanced"
        Me.ShowInTaskbar = False
        Me.Text = "Advanced Item Search"
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub lst_items_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lst_items.KeyDown
        If e.KeyCode = Keys.Delete Then
            While lst_items.SelectedItems.Count > 0
                lst_items.Items.Remove(lst_items.SelectedItem)
            End While
        ElseIf e.KeyCode = Keys.Enter Then
            Dim i As Integer
            Dim lstOBJ As New ListBox.SelectedObjectCollection(lst_items)
            lst_SelectItems.Items.AddRange(ArrayList.Adapter(lstOBJ).ToArray)
            While lst_items.SelectedItems.Count > 0
                lst_items.Items.Remove(lst_items.SelectedItem)
            End While
        End If
    End Sub

    Private Sub lst_SelectItems_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lst_SelectItems.KeyDown
        If e.KeyCode = Keys.Delete Then
            While lst_SelectItems.SelectedItems.Count > 0
                lst_SelectItems.Items.Remove(lst_SelectItems.SelectedItem)
            End While
        End If
    End Sub

    Private Sub frmSearch_Advanced_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Call Load_items()
        'txtSearch.Focus()
        Call cmd_clear_Click(sender, e)
    End Sub
    Private Sub Load_items()
        Dim i As Integer
        lst_items.Items.Clear()
        For i = 0 To chklistbox.Items.Count - 1
            lst_items.Items.Add(chklistbox.Items.Item(i))
        Next
    End Sub
    Private Sub frmSearch_Advanced_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F6 Then
            Call cmd_clear_Click(sender, e)
        ElseIf e.KeyCode = Keys.F7 Then
            Call cmd_okay_Click(sender, e)
        End If
    End Sub
    Private Sub cmd_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_clear.Click
        Me.Cursor = Cursors.WaitCursor
        Call Load_items()
        '        lst_SelectItems.Items.Clear()
        txtSearch.Clear()
        Me.Cursor = Cursors.Default
        txtSearch.Focus()
    End Sub
    Private Sub cmd_okay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_okay.Click
        Dim i As Integer
        chklistbox.Items.Clear()
        For i = 0 To lst_SelectItems.Items.Count - 1
            chklistbox.Items.Add(lst_SelectItems.Items.Item(i))
        Next
        Me.Close()
    End Sub
    Private Sub listSearch(ByVal init As Integer)
        Dim [Continue] As Boolean
        Dim i, j, intStringLength, intStringLength1 As Integer
        Dim Item() As String
        Try

            If Len(Trim(txtSearch.Text)) = 0 Then
                MsgBox("Search Text Can't Be Blank....", MsgBoxStyle.OKOnly, Application.ProductName)
                'grpSearch.Focus()
                Exit Sub
            End If

            [Continue] = False

            If lst_items.Items.Count > 2 Then
                'If Continue = False Then
                '    init = 0
                'Else
                '    init = i
                'End If
                For i = init To lst_items.Items.Count - 1
                    boolSearchResult = False
                    Item = Split(lst_items.Items.Item(i), "-->")
                    '------------ checking itemCode
                    intStringLength = Item(0).Length
                    For j = 0 To intStringLength - 1
                        If UCase(Mid(Trim(Item(0)), j + 1, Len(Trim(txtSearch.Text)))) = UCase(Trim(txtSearch.Text)) Then
                            'lst_items.SetSelected(i, True)
                            boolSearchResult = True
                            Exit For
                        End If
                    Next

                    '------------ checking itemName
                    'boolSearchResult = False
                    If Item.Length = 2 Then
                        intStringLength1 = Item(1).Length
                        For j = 0 To intStringLength1 - 1
                            If UCase(Mid(Trim(Item(1)), j + 1, Len(Trim(txtSearch.Text)))) = UCase(Trim(txtSearch.Text)) Then
                                'lst_items.SetSelected(i, True)
                                boolSearchResult = True
                                Exit For
                            End If
                        Next
                    End If

                    If boolSearchResult <> True Then
                        lst_items.Items.RemoveAt(i)
                        [Continue] = True
                        Exit For
                    End If
                Next

                If [Continue] Then
                    listSearch(i)
                End If
                'If boolSearchResult = False Then
                '    MsgBox("Reached End of List ...", MsgBoxStyle.OKOnly, Application.ProductName)
                '    txtSearch.Focus()
                '    Exit Sub
                'End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.Cursor = Cursors.WaitCursor
            Call listSearch(0)
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub grp_search_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grp_search.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call cmd_clear_Click(sender, e)
        End If
    End Sub
    Private Sub cmd_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cancel.Click
        Me.Close()
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub
End Class
