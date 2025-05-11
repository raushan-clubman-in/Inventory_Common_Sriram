Imports System.Data.SqlClient
Public Class Inv_LocationMaster
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim gconnection As New GlobalClass
    Private Sub Inv_LocationMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bindchecklist()
        autogenerate()
        dtpfromdate.Value = Format(CDate("01/apr/" & gFinancalyearStart), "dd/MMM/yyyy")
        dtptodate.Value = Format(Now, "dd/MMM/yyyy")
        Cmd_Clear_Click(sender, e)
        dtpfromdate.Focus()
    End Sub
    Private Sub bindchecklist()
        UserCheckList.Items.Clear()
        sqlstring = "  SELECT DISTINCT USERNAME,CATEGORY FROM UserAdmin where Maingroup='Inventory'"
        sqlstring = sqlstring & "    union "
        sqlstring = sqlstring & "  SELECT DISTINCT USERNAME,CATEGORY FROM UserAdmin where category='S'"
        gconnection.getDataSet(sqlstring, "UserAdmin")
        If (gdataset.Tables("UserAdmin").Rows.Count > 0) Then
            For i As Integer = 0 To gdataset.Tables("UserAdmin").Rows.Count - 1
                UserCheckList.Items.Add(gdataset.Tables("UserAdmin").Rows(i).Item("USERNAME"))
            Next
        End If
    End Sub
    Public Sub checkValidationU()
        boolchk = False
        If Trim(txt_Rowid.Text) = "" Then
            MessageBox.Show(" Row id  can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_Rowid.Focus()
            Exit Sub
        End If
        boolchk = True
    End Sub
    Private Sub autogenerate()
        Dim Sqlstring As String
        Try
            gcommand = New SqlCommand
            Sqlstring = "SELECT isnull(MAX(Cast(docno As int)),0) FROM DIRECTGRN where docno not like  '%[^0-9]%' "
            gconnection.openConnection()
            gcommand.CommandText = Sqlstring
            gcommand.CommandType = CommandType.Text
            gcommand.Connection = gconnection.Myconn
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then
                If gdreader(0) Is System.DBNull.Value Then
                    txt_Rowid.Text = "001"
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                Else
                    txt_Rowid.Text = Format(gdreader(0) + 1, "000")
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If
            Else
                txt_Rowid.Text = "001"
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            End If
        Catch ex As Exception
            Exit Sub
        Finally
            gdreader.Close()
            gcommand.Dispose()
            gconnection.closeConnection()
        End Try
    End Sub
    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        Call clearform(Me)
        Cmd_Add.Text = "Add [F7]"
        Cmd_Add.Enabled = True
        autogenerate()
        UserCheckList.Items.Clear()
        bindchecklist()
        Me.Cmd_Add.Enabled = True
        dtpfromdate.Focus()
    End Sub
    Private Sub Cmd_Add_Click(sender As Object, e As EventArgs) Handles Cmd_Add.Click
        Dim strSQL As String
        Dim insert(0) As String
        If Cmd_Add.Text = "Add [F7]" Then
            Call checkValidationU() '''--->Check Validation
            If boolchk = False Then Exit Sub
            Checkdaterangevalidate(Format(dtpfromdate.Value, "dd/MM/yyyy"), Format(dtptodate.Value, "dd/MMM/yyyy"))
            If chkdatevalidate = False Then Exit Sub
            For i As Integer = 0 To UserCheckList.CheckedItems.Count - 1
                strSQL = " INSERT INTO DIRECTGRN (Docno,FromDate,ToDate,Users,Adduser,adddatetime)"
                strSQL = strSQL & "VALUES ( '" & Trim(txt_Rowid.Text) & "','" & Format(CDate(dtpfromdate.Value), "dd-MMM-yyyy") & "','" & Format(CDate(dtptodate.Value), "dd-MMM-yyyy") & "','" & UserCheckList.CheckedItems(i) & "' "
                strSQL = strSQL & ",'" & Trim(gUsername) & "','" & Format(Date.Now, "dd/MMM/yyyy") & "')"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = strSQL
            Next
            gconnection.MoreTrans(insert)
            Me.Cmd_Clear_Click(sender, e)
        End If
    End Sub
    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
    Private Sub Inv_LocationMaster_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(Cmd_Clear, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F7 And Cmd_Add.Visible = True Then
            Call Cmd_Add_Click(Cmd_Add, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call Cmd_Exit_Click(Cmd_Exit, e)
            Exit Sub
        End If
    End Sub
    Private Sub cmdLocationCode_Click(sender As Object, e As EventArgs) Handles cmd_rowidhelp.Click
        gSQLString = "SELECT distinct ISNULL(DOCNO,'') AS DOCNO,FROMDATE,TODATE FROM DIRECTGRN"
        M_WhereCondition = "  "
        Dim vform As New ListOperattion1

        vform.Field = "DOCNO,FROMDATE,TODATE"
        vform.vFormatstring = "  DOC NO.       |     FROM DATE     |     TO DATE       "
        vform.vCaption = "DOCUMENT NO HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_Rowid.Text = Trim(vform.keyfield & "")
            sqlstring = "SELECT ISNULL(DOCNO,'') AS DOCNO,FROMDATE,TODATE FROM DIRECTGRN"
            gconnection.getDataSet(sqlstring, "DIRECTGRN")
            If (gdataset.Tables("DIRECTGRN").Rows.Count > 0) Then
                dtpfromdate.Text = gdataset.Tables("DIRECTGRN").Rows(0).Item("FROMDATE")
                dtptodate.Text = gdataset.Tables("DIRECTGRN").Rows(0).Item("TODATE")
            End If
            UserCheckList.Items.Clear()
            bindchecklist()
            sqlstring = "select Users from DIRECTGRN where DOCNO='" & Trim(txt_Rowid.Text) & "'"
            gconnection.getDataSet(sqlstring, "DIRECTGRN")
            Dim TYPE As String
            Dim Usercode As String
            If (gdataset.Tables("DIRECTGRN").Rows.Count > 0) Then
                For k As Integer = 0 To gdataset.Tables("DIRECTGRN").Rows.Count - 1
                    Usercode = Trim(gdataset.Tables("DIRECTGRN").Rows(k).Item("Users"))
                    For m As Integer = 0 To UserCheckList.Items.Count - 1
                        TYPE = UserCheckList.Items(m)
                        If TYPE = Usercode Then
                            UserCheckList.SetItemChecked(m, True)
                        End If
                    Next m
                Next k
            End If
        End If
        Cmd_Add.Enabled = False
        vform.Close()
        vform = Nothing
    End Sub
End Class