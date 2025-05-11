'Imports x = Microsoft.Office.Interop.Excel
Imports System.Linq
Imports x = Microsoft.Office.Interop.Excel


Public Class AUTHORISATION
    Dim DETAIL As Boolean
    Dim VCONN As New GlobalClass
    Public SSQL, KEYFIELD, Returnkeyvalue As String
    Dim frmt As Form
    Public COLUMNSEQ, COLUMNSEQ2, finallevel As Integer
    Dim LD As Boolean
    Dim DataGridViewCheckBoxColumn, strSqlString As String
    Dim ctrlname1 As Integer
    Dim MultitblYN As Char
    Dim MultiTblSql() As String
    Dim MulticolYN As Char
    Dim LEVEL1 As Integer
    Public AUTHDT As New DataGridView

    Dim gconnection As New GlobalClass
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dgData As DataGridView = DirectCast(DTAUTH, DataGridView)
     

        With SaveFileDialog1
            .Filter = "Excel|*.xlsx"
            .Title = "Save griddata in Excel"
            If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                'Dim o As New ExcelExporter
                Dim b = exportnew(dgData, .FileName)
                MsgBox("EXPORT COMPLETED SUCCESSFULY")
            End If
            .Dispose()
        End With
    End Sub

    Private Function exportnew(ByRef dgv As DataGridView, ByVal Path As String) As Boolean
        Dim i, j As Integer
        Dim default_location As String = Path & ".xls"
        'Creating dataset to export
        Dim dset As New DataSet
        'add table to dataset
        dset.Tables.Add()
        'add column to that table
        For i = 0 To dgv.ColumnCount - 1
            dset.Tables(0).Columns.Add(dgv.Columns(i).HeaderText)
        Next
        'add rows to the table
        Dim dr1 As DataRow
        For i = 0 To dgv.RowCount - 1
            dr1 = dset.Tables(0).NewRow
            For j = 0 To dgv.Columns.Count - 1
                dr1(j) = dgv.Rows(i).Cells(j).Value
            Next
            dset.Tables(0).Rows.Add(dr1)
        Next

        Dim xp As New x.Application
        Dim wBook As Microsoft.Office.Interop.Excel.Workbook
        Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

        xp.Visible = True
        xp.UserControl = True

        wBook = xp.Workbooks.Add(System.Reflection.Missing.Value)
        wSheet = wBook.Sheets("sheet1")
        xp.Range("A50:I50").EntireColumn.AutoFit()
        With wBook
            .Sheets("Sheet1").Select()
            .Sheets(1).Name = "NameYourSheet"
        End With

        Dim dt As System.Data.DataTable = dset.Tables(0)
        wSheet.Cells(1).value = Path
        ' Dim i As Integer
        Dim s As String
        Dim colcount = 0
        Dim ColNames As Generic.List(Of String) = (From col As DataGridViewColumn _
                                      In dgv.Columns.Cast(Of DataGridViewColumn)() _
                                      Where (col.Visible = True) _
                                      Order By col.DisplayIndex _
                                      Select col.Name).ToList
        'For Each s In ColNames
        '    colcount += 1
        '    wSheet.Cells(1, colcount) = dgv.Columns.Item(s).HeaderText
        'Next
        'For i = 0 To dgv.RowCount - 2
        '    For j = 0 To dgv.ColumnCount - 2
        '        If IsDBNull(dgv.Rows(i).Cells(j).Value) = False Or dgv.Rows(i).Cells(j).Value.ToString() <> Nothing Then
        '            ''  If dgv.Rows(i).Cells(j).Value.ToString() <> Nothing Then
        '            wSheet.Cells(i + 2, j + 1).value = dgv.Rows(i).Cells(j).Value.ToString()
        '        Else
        '            wSheet.Cells(i + 2, j + 1).value = ""
        '        End If

        '    Next j
        'Next i

        For Each s In ColNames
            If dgv.Columns.Item(s).HeaderText <> "SELECT" And dgv.Columns.Item(s).HeaderText <> "Reject" Then
                colcount += 1
                wSheet.Cells(1, colcount) = dgv.Columns.Item(s).HeaderText
            End If
        Next
        Dim n As Integer = 1
        For i = 0 To dgv.RowCount - 1
            If (dgv.Rows(i).Cells(0).Value) = True Then

                n = n + 1

                For j = 0 To dgv.ColumnCount - 2
                    If j > 1 Then
                        '  If IsDBNull(dgv.Rows(i).Cells(j).Value) = False Or dgv.Rows(i).Cells(j).Value.ToString() <> Nothing Then
                        wSheet.Cells(n, j - 1).value = dgv.Rows(i).Cells(j).Value.ToString()
                        '  Else
                        ' wSheet.Cells(i + 2, j + 1).value = ""
                        '  End If
                    End If
                Next j
            End If
        Next i

        wSheet.Columns.AutoFit()
        Dim blnFileOpen As Boolean = False
        Try
            Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(default_location)
            fileTemp.Close()
        Catch ex As Exception
            blnFileOpen = False
        End Try

        If System.IO.File.Exists(default_location) Then
            System.IO.File.Delete(default_location)
        End If

        wBook.SaveAs(default_location)
        xp.Workbooks.Open(default_location)
        xp.Visible = True
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim J, i As Integer
        Dim insert(0) As String
        J = 0
        For i = 0 To DTAUTH.Rows.Count - 1
            If DTAUTH.Rows(i).Cells(J).Value = True Then
                If MultitblYN <> "Y" Then
                    If MulticolYN = "Y" Then

                        strSqlString = SSQL & " "
                        If ctrlname1 = 2 Then
                            strSqlString = strSqlString & " MCA='C' , CheckerID='" & gUsername & "', CheckerDate=getdate()  where " & KEYFIELD & " ='" & DTAUTH.Rows(i).Cells(COLUMNSEQ).Value.ToString() & DTAUTH.Rows(i).Cells(COLUMNSEQ2).Value.ToString() & "'"
                            ReDim Preserve insert(insert.Length)
                            insert(insert.Length - 1) = strSqlString
                            If finallevel = ctrlname1 Then
                                strSqlString = SSQL & " AUTHORISED='Y' where " & KEYFIELD & " ='" & DTAUTH.Rows(i).Cells(COLUMNSEQ).Value.ToString() & DTAUTH.Rows(i).Cells(COLUMNSEQ2).Value.ToString() & "'"
                                ReDim Preserve insert(insert.Length)
                                insert(insert.Length - 1) = strSqlString
                                AuthYN = True
                            End If
                        End If

                        If ctrlname1 = 3 Then
                            strSqlString = strSqlString & " MCA='A', AuthorisID ='" & gUsername & "', AuthorisDate=getdate()  where " & KEYFIELD & " ='" & DTAUTH.Rows(i).Cells(COLUMNSEQ).Value.ToString() & DTAUTH.Rows(i).Cells(COLUMNSEQ2).Value.ToString() & "'"
                            ReDim Preserve insert(insert.Length)
                            insert(insert.Length - 1) = strSqlString
                            If finallevel = ctrlname1 Then
                                strSqlString = SSQL & " AUTHORISED='Y' where " & KEYFIELD & " ='" & DTAUTH.Rows(i).Cells(COLUMNSEQ).Value.ToString() & DTAUTH.Rows(i).Cells(COLUMNSEQ2).Value.ToString() & "'"
                                ReDim Preserve insert(insert.Length)
                                insert(insert.Length - 1) = strSqlString
                                AuthYN = True
                            End If
                        End If


                    Else
                        strSqlString = SSQL & " "
                        If ctrlname1 = 2 Then
                            strSqlString = strSqlString & " MCA='C' , CheckerID='" & gUsername & "', CheckerDate=getdate()  where " & KEYFIELD & " ='" & DTAUTH.Rows(i).Cells(COLUMNSEQ).Value.ToString() & "'"
                            ReDim Preserve insert(insert.Length)
                            insert(insert.Length - 1) = strSqlString
                            If finallevel = ctrlname1 Then
                                strSqlString = SSQL & " AUTHORISED='Y' where " & KEYFIELD & " ='" & DTAUTH.Rows(i).Cells(COLUMNSEQ).Value.ToString() & "'"
                                ReDim Preserve insert(insert.Length)
                                insert(insert.Length - 1) = strSqlString
                                AuthYN = True
                            End If
                        End If

                        If ctrlname1 = 3 Then
                            strSqlString = strSqlString & " MCA='A', AuthorisID ='" & gUsername & "', AuthorisDate=getdate()  where " & KEYFIELD & " ='" & DTAUTH.Rows(i).Cells(COLUMNSEQ).Value.ToString() & "'"
                            ReDim Preserve insert(insert.Length)
                            insert(insert.Length - 1) = strSqlString
                            If finallevel = ctrlname1 Then
                                strSqlString = SSQL & " AUTHORISED='Y' where " & KEYFIELD & " ='" & DTAUTH.Rows(i).Cells(COLUMNSEQ).Value.ToString() & "'"
                                ReDim Preserve insert(insert.Length)
                                insert(insert.Length - 1) = strSqlString
                                AuthYN = True
                            End If
                        End If
                    End If
                ElseIf MultitblYN = "Y" Then
                    For m As Integer = 0 To MultiTblSql.Length - 1
                        If MultiTblSql(m) <> Nothing Then
                            strSqlString = MultiTblSql(m) & " "
                            SSQL = MultiTblSql(m) & " "
                            If ctrlname1 = 2 Then
                                strSqlString = strSqlString & " MCA='C' , CheckerID='" & gUsername & "', CheckerDate=getdate()  where " & KEYFIELD & " ='" & DTAUTH.Rows(i).Cells(COLUMNSEQ).Value.ToString() & "'"
                                ReDim Preserve insert(insert.Length)
                                insert(insert.Length - 1) = strSqlString
                                If finallevel = ctrlname1 Then
                                    strSqlString = SSQL & " AUTHORISED='Y' where " & KEYFIELD & " ='" & DTAUTH.Rows(i).Cells(COLUMNSEQ).Value.ToString() & "'"
                                    ReDim Preserve insert(insert.Length)
                                    insert(insert.Length - 1) = strSqlString
                                    AuthYN = True

                                End If
                            End If

                            If ctrlname1 = 3 Then
                                strSqlString = strSqlString & " MCA='A', AuthorisID ='" & gUsername & "', AuthorisDate=getdate()  where " & KEYFIELD & " ='" & DTAUTH.Rows(i).Cells(COLUMNSEQ).Value.ToString() & "'"
                                ReDim Preserve insert(insert.Length)
                                insert(insert.Length - 1) = strSqlString
                                If finallevel = ctrlname1 Then
                                    strSqlString = SSQL & " AUTHORISED='Y' where " & KEYFIELD & " ='" & DTAUTH.Rows(i).Cells(COLUMNSEQ).Value.ToString() & "'"
                                    ReDim Preserve insert(insert.Length)
                                    insert(insert.Length - 1) = strSqlString
                                    AuthYN = True
                                End If
                            End If
                        End If
                    Next
                End If



            Else

            End If
        Next
        If insert.Length > 0 Then
            gconnection.MoreTrans(insert)
            If AuthYN = True Then
                AUTHDT = DTAUTH
            End If
        End If
        Me.Close()

    End Sub

    Private Sub AUTHORISATION_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim m, z, a, b As Integer
        If LEVEL1 = 2 Then
            Button2.Text = "CHECKED"
            m = DTAUTH.Columns.IndexOf(DTAUTH.Columns("MCA"))
            For z = 0 To DTAUTH.Rows.Count - 1

                If DTAUTH.Rows(z).Cells(m).Value = "C" Then
                    Dim val2 As DataGridViewCheckBoxCell = DTAUTH.Item(0, z)
                    val2.Value = True

                End If
            Next

        End If
        For a = 0 To DTAUTH.Rows.Count - 1
            ' b = DTAUTH.ColumnCount
            For b = 1 To DTAUTH.ColumnCount - 1
                If LEVEL1 <> 1 Then
                    If b <> 1 Then
                        DTAUTH.Rows(a).Cells(b).ReadOnly = True
                    End If
                Else
                    DTAUTH.Rows(a).Cells(b).ReadOnly = True
                End If

            Next
        Next
    End Sub

    Public Sub LOADGRID(ByVal DC As DataTable, ByVal DET As Boolean, ByVal FORMNM As Form, ByVal SQL As String, ByVal KEYFILD As String, ByVal auth As Integer, LEVEL As Integer, COLUMSEQ As Integer, Optional ByVal multiyn As Char = "N", Optional ByVal MultiTbl() As String = Nothing)
        LD = False
        DETAIL = DET
        SSQL = SQL
        KEYFIELD = KEYFILD
        COLUMNSEQ = COLUMSEQ + 2
        frmt = FORMNM
        finallevel = auth
        ctrlname1 = LEVEL
        MultitblYN = multiyn
        MultiTblSql = MultiTbl
        MulticolYN = "N"
        LEVEL1 = LEVEL
        DTAUTH.Refresh()
        Dim CHECKCOL As New DataGridViewCheckBoxColumn
        CHECKCOL.HeaderText = "SELECT"
        DTAUTH.Columns.Add(CHECKCOL)
        Button2.Visible = False

        If LEVEL <> 1 Then
            Dim btadd As New DataGridViewButtonColumn
            btadd.Name = "btReject"
            btadd.Text = "Reject"
            DTAUTH.Columns.Add(btadd)
            btadd.HeaderText = "Reject"
            btadd.Text = "Reject"
            btadd.Name = "btReject"
            btadd.UseColumnTextForButtonValue = True
            Button2.Visible = True
        Else
            COLUMNSEQ = COLUMNSEQ - 1
        End If


        DTAUTH.DataSource = DC
        If LEVEL = 2 Then
            Button2.Text = "CHECKED"
            'If DTAUTH.Rows.Count > 0 Then
            '    For M As Integer = 0 To DTAUTH.Rows.Count - 1
            '        If DTAUTH.Columns.Item("MCA").ToString() = "C" Then
            '            Dim a As Boolean
            '        End If
            '    Next

            'End If
        End If


    End Sub



    Public Sub LOADGRID(ByVal DC As DataTable, ByVal DET As Boolean, ByVal FORMNM As Form, ByVal SQL As String, ByVal KEYFILD As String, ByVal auth As Integer, ByVal LEVEL As Integer, ByVal COLUMSEQ As Integer, ByVal COLUMSEQ2 As Integer)
        LD = False
        DETAIL = DET
        SSQL = SQL
        KEYFIELD = KEYFILD
        COLUMNSEQ = COLUMSEQ + 2
        frmt = FORMNM
        finallevel = auth
        ctrlname1 = LEVEL
        MultitblYN = "N"
        'MultiTblSql = MultiTbl
        MulticolYN = "Y"
        COLUMNSEQ2 = COLUMSEQ2 + 2

        LEVEL1 = LEVEL

        DTAUTH.Refresh()
        Dim CHECKCOL As New DataGridViewCheckBoxColumn
        CHECKCOL.HeaderText = "SELECT"
        DTAUTH.Columns.Add(CHECKCOL)
        Button2.Visible = False

        If LEVEL <> 1 Then
            Dim btadd As New DataGridViewButtonColumn
            btadd.Name = "btReject"
            btadd.Text = "Reject"
            DTAUTH.Columns.Add(btadd)
            btadd.HeaderText = "Reject"
            btadd.Text = "Reject"
            btadd.Name = "btReject"
            btadd.UseColumnTextForButtonValue = True
            Button2.Visible = True
        Else
            COLUMNSEQ = COLUMNSEQ - 1
        End If


        DTAUTH.DataSource = DC




        If LEVEL = 2 Then
            Button2.Text = "CHECKED"
        End If


    End Sub



    Private Sub DTAUTH_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DTAUTH.CellContentClick

        Dim J As Integer
        Dim insert(0) As String
        J = DTAUTH.Columns.Count - 2

        Dim senderGrid = DirectCast(sender, DataGridView)

        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
           e.RowIndex >= 0 Then
            Dim Cinput As New InputBoxCustom
            'Dim Cinput As New Inpu

            Dim cmd As String

            Cinput.ShowDialog(Me)

            If Cinput.COMMENT = "" Then
                MessageBox.Show("Comments Can't Be Blank")
                Exit Sub
            Else
                cmd = Cinput.COMMENT
            End If

            strSqlString = SSQL & " "

            If ctrlname1 = 2 Then
                cmd = "Checker/User:" & gUsername & ": " & cmd


                If MulticolYN = "Y" Then
                    strSqlString = strSqlString & " MCA='M' , COMMENT='" & cmd & "', CheckerID='" & gUsername & "', CheckerDate=getdate()  where " & KEYFIELD & " ='" & DTAUTH.Rows(e.RowIndex).Cells(COLUMNSEQ).Value.ToString() & DTAUTH.Rows(e.RowIndex).Cells(COLUMNSEQ2).Value.ToString() & "'"
                Else
                    strSqlString = strSqlString & " MCA='M' , COMMENT='" & cmd & "', CheckerID='" & gUsername & "', CheckerDate=getdate()  where " & KEYFIELD & " ='" & DTAUTH.Rows(e.RowIndex).Cells(COLUMNSEQ).Value.ToString() & "'"
                End If
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = strSqlString
            End If

            If ctrlname1 = 3 Then
                cmd = "Authoriser/User:" & gUsername & ": " & cmd
                If MulticolYN = "Y" Then
                    strSqlString = strSqlString & " MCA='M', COMMENT='" & cmd & "', AuthorisID ='" & gUsername & "', AuthorisDate=getdate()  where " & KEYFIELD & " ='" & DTAUTH.Rows(e.RowIndex).Cells(COLUMNSEQ).Value.ToString() & DTAUTH.Rows(e.RowIndex).Cells(COLUMNSEQ2).Value.ToString() & "'"
                Else
                    strSqlString = strSqlString & " MCA='M', COMMENT='" & cmd & "', AuthorisID ='" & gUsername & "', AuthorisDate=getdate()  where " & KEYFIELD & " ='" & DTAUTH.Rows(e.RowIndex).Cells(COLUMNSEQ).Value.ToString() & "'"
                End If

                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = strSqlString
            End If
            gconnection.MoreTrans(insert)
            DTAUTH.Rows.RemoveAt(e.RowIndex)


        End If


    End Sub

    Private Sub DTAUTH_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DTAUTH.CellDoubleClick

        ''  Dim senderGrid = DirectCast(sender, DataGridView)

        Dim i As Integer = e.RowIndex

        If Not String.IsNullOrEmpty(DTAUTH.Rows(i).Cells(COLUMNSEQ).Value) And e.RowIndex >= 0 Then
            Returnkeyvalue = DTAUTH.Rows(e.RowIndex).Cells(COLUMNSEQ).Value.ToString()
            Me.Close()
        End If

    End Sub


End Class