Imports System.Data
Imports System.IO
Imports System.Data.SqlClient

Public Class GClass4backgroundprocess

    Public sqlconnection, sqlconnection1 As String
    Public Myconn As New SqlConnection
    Dim MyTrans As SqlTransaction
    Dim Cmd As New SqlCommand
    Dim DataString As String
    Dim ssql, sqlstring As String

    Public Function Getconnection() As String
        Try
            sqlconnection = "Data Source=" & gserver & ";Persist Security Info=False;User ID=" & ggusername & ";pwd=" & ggpassword & ";Initial Catalog= " & gDatabase & ";"
            Return sqlconnection
        Catch ex As Exception
            'Exit Function
            Return ""
        End Try
    End Function



    Public Function FillTableFromDataSet(ByVal Dt As DataTable, ByVal TableName As String) As String

        Dim SqlConnection As New SqlConnection
        SqlConnection.ConnectionString = Getconnection()
        SqlConnection.Open()



        Using bulkCopy As SqlBulkCopy = _
            New SqlBulkCopy(SqlConnection)
            bulkCopy.DestinationTableName = TableName

            Try
                ' Write from the source to the destination.
                bulkCopy.WriteToServer(Dt)

            Catch ex As Exception
                MsgBox(ex.Message)
                'Console.WriteLine(ex.Message)
            Finally
                SqlConnection.Close()

            End Try
        End Using

        Return ""

    End Function



    Function getvalue(ByVal QryString As String)
        Dim objVariable As Object
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If

            Cmd.Connection = Myconn
            Cmd.CommandTimeout = 1000000000
            Cmd.CommandText = QryString
            Cmd.CommandType = CommandType.Text
            objVariable = Cmd.ExecuteScalar()
            Myconn.Close()
            Return objVariable
        Catch ex As Exception
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        Finally
            Myconn.Close()
        End Try
    End Function
    Function getdata(ByVal qry As String, ByVal qrytab As String)
        Dim datatb As New DataSet
        If Myconn.State <> ConnectionState.Open Then
            openConnection()
        End If
        Dim daa As New SqlDataAdapter(qry, Myconn)
        daa.SelectCommand.CommandTimeout = 1000000000
        daa.Fill(datatb, qrytab)
        Myconn.Close()
        Return datatb
    End Function
    Public Function getDataSet(ByVal strSQL As String, ByVal Tabname As String)
        'Dim dt As New DataTable
        Dim dt As New DataTable
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            gadapter = New SqlDataAdapter(strSQL, Myconn)
            gadapter.SelectCommand.CommandTimeout = 1000000000
            gadapter.Fill(dt)
            dt.TableName = Tabname
            If gdataset.Tables.Contains(Tabname) = True Then
                gdataset.Tables.Remove(Tabname)
            End If
            gdataset.Tables.Add(dt)
        Catch ex As Exception
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        Finally
            closeConnection()
        End Try
    End Function
    Public Function getCompanyinfo(ByVal strSQL As String, ByVal Tabname As String)
        Dim dt As New DataTable
        Try
            Call GetfrontConnection()
            ' Call openConnection()
            gadapter = New SqlDataAdapter(strSQL, Myconn)
            gadapter.SelectCommand.CommandTimeout = 1000000000
            gadapter.Fill(dt)
            dt.TableName = Tabname
            If gdataset.Tables.Contains(Tabname) = True Then
                gdataset.Tables.Remove(Tabname)
            End If
            gdataset.Tables.Add(dt)
        Catch ex As Exception
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        Finally
            closeConnection()
        End Try
    End Function

    Public Function MoreTrans(ByVal str() As String)
        Dim i As Integer

        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            MyTrans = Myconn.BeginTransaction()
            Cmd.CommandTimeout = 1000000000
            Cmd.Transaction = MyTrans
            Cmd.Connection = Myconn
            For i = 0 To str.Length - 1
                If str(i) Is Nothing = False Then
                    Cmd.CommandText = str(i)
                    Cmd.CommandType = CommandType.Text
                    Cmd.ExecuteNonQuery()
                End If
            Next i
            MyTrans.Commit()
            MessageBox.Show("Transaction Completed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Myconn.Close()
        Catch ex As Exception
            MyTrans.Rollback()
            Myconn.Close()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
    End Function
    'MANISH================
    Public Function MoreTrans2(ByVal str() As String) As Boolean
        Dim i As Integer
        Dim flg As Boolean = False
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            MyTrans = Myconn.BeginTransaction()
            Cmd.CommandTimeout = 1000000000
            Cmd.Transaction = MyTrans
            Cmd.Connection = Myconn
            For i = 0 To str.Length - 1
                If str(i) Is Nothing = False Then
                    Cmd.CommandText = str(i)
                    Cmd.CommandType = CommandType.Text
                    Cmd.ExecuteNonQuery()
                End If
            Next i
            MyTrans.Commit()
            ' MessageBox.Show("Transaction Completed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            flg = True
            Myconn.Close()
        Catch ex As Exception
            MyTrans.Rollback()
            Myconn.Close()
            flg = False
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
        Return flg
    End Function

    '==============MANISH

    Public Function MoreTrans_womsg(ByVal str() As String)
        Dim i As Integer
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            MyTrans = Myconn.BeginTransaction()
            Cmd.CommandTimeout = 1000000000
            Cmd.Transaction = MyTrans
            Cmd.Connection = Myconn
            For i = 0 To str.Length - 1
                If str(i) Is Nothing = False Then
                    Cmd.CommandText = str(i)
                    Cmd.CommandType = CommandType.Text
                    Cmd.ExecuteNonQuery()
                End If
            Next i
            MyTrans.Commit()
            Myconn.Close()
        Catch ex As Exception
            MyTrans.Rollback()
            Myconn.Close()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
    End Function

    Public Sub dataOperation(ByVal genum As Integer, ByVal ssql As String, Optional ByVal Tabname As String = "MyTable")
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            gtrans = Myconn.BeginTransaction
            Select Case genum
                '''****************************** $ Insert record into Database $ **************************'''
                Case 1
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.CommandTimeout = 1000000000
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    MessageBox.Show("Record Saved Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '''**************************** $ Update record into Database $ *************************'''
                Case 2
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.CommandTimeout = 1000000000
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    MessageBox.Show("Record Updated Successfully ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '''**************************** $ Freeze record into Database $ **************************'''
                Case 3
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.CommandTimeout = 1000000000
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    MessageBox.Show("Record Freezed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '''***************************** $ UnFreezed record into Database $ ************************'''
                Case 4
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.CommandTimeout = 1000000000
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    MessageBox.Show("Record Unfreezed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case 5
                    '****************************** $ Always Give Full Select Statement without Any Condition $ *******'''
                    gadapter = New SqlDataAdapter(ssql, Myconn)
                    gadapter.SelectCommand.CommandTimeout = 1000000000
                    If gdataset.Tables.Contains(Tabname) = True Then
                        gdataset.Tables.Remove(Tabname)
                    End If
                    gadapter.Fill(gdataset.Tables(Tabname))
                    gtrans.Commit()
                Case 6
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.CommandTimeout = 1000000000
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
            End Select
        Catch ex As Exception
            gtrans.Rollback()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Finally
            closeConnection()
        End Try
    End Sub
    Public Sub dataOperation1(ByVal genum As Integer, ByVal ssql As String, Optional ByVal Tabname As String = "MyTable")
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            gtrans = Myconn.BeginTransaction
            Select Case genum
                '''****************************** $ Insert record into Database $ **************************'''

                Case 6
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.CommandTimeout = 1000000000
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
            End Select
        Catch ex As Exception
            gtrans.Rollback()
            'MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Finally
            closeConnection()
        End Try
    End Sub
    Public Sub openConnection()
        Try
            If Trim(gserver & "") <> "" Then
                sqlconnection = "Data Source=" & gserver & ";Persist Security Info=False;User ID=" & ggusername & ";pwd=" & ggpassword & ";Initial Catalog= " & gDatabase & ";"
            Else
                sqlconnection = "Data Source= (local);Persist Security Info=False;User ID=" & ggusername & ";pwd=" & ggpassword & ";Initial Catalog= " & gDatabase & ";"
            End If
            Myconn.ConnectionString = sqlconnection

            Myconn.Open()
        Catch ex As Exception
            MessageBox.Show("!! Warning !!Your system is not connected with SERVER", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Public Sub GetfrontConnection()
        Try

            If Trim(gserver & "") <> "" Then
                sqlconnection1 = "Data Source=" & gserver & ";Persist Security Info=False;User ID=" & ggusername & ";pwd=" & ggpassword & ";Initial Catalog= MASTER;"
            Else
                sqlconnection1 = "Data Source= (local);Persist Security Info=False;User ID=" & ggusername & ";pwd=" & ggpassword & ";Initial Catalog= MASTER;"
            End If

            Myconn.ConnectionString = sqlconnection1
            Myconn.Open()
        Catch ex As Exception
            MessageBox.Show("!! Warning !!Your system is not connected with SERVER", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Public Sub closeConnection()
        Myconn.Close()
    End Sub
    Public Function GetValues(ByVal ssql As String) As DataTable
        Dim Dt As New DataTable
        Dim Sqladapter As New SqlDataAdapter(ssql, Myconn)
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            Sqladapter.SelectCommand.CommandTimeout = 1000000000
            Sqladapter.Fill(Dt)
            Return Dt
        Catch ex As Exception
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        Finally
            closeConnection()
        End Try
    End Function
    Public Function ExcuteStoreProcedure(ByVal qry As String)
        Dim i As Integer
        ' Myconn.ConnectionString = sqlconnection
        Try
            'Myconn.Open()
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            MyTrans = Myconn.BeginTransaction()
            Cmd.CommandTimeout = 1000000000
            Cmd.Transaction = MyTrans
            Cmd.Connection = Myconn
            Cmd.CommandText = qry
            Cmd.CommandType = CommandType.Text
            Cmd.ExecuteNonQuery()
            MyTrans.Commit()
            Myconn.Close()
        Catch ex As Exception
            MyTrans.Rollback()
            Myconn.Close()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Throw
        End Try
    End Function

    Public Function ExcuteStoreProcedure_Long(ByVal qry As String)
        Dim i As Integer
        ' Myconn.ConnectionString = sqlconnection
        Try
            'Myconn.Open()
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            MyTrans = Myconn.BeginTransaction()
            Cmd.CommandTimeout = 999999999
            Cmd.Transaction = MyTrans
            Cmd.Connection = Myconn
            Cmd.CommandText = qry
            Cmd.CommandType = CommandType.Text
            Cmd.ExecuteNonQuery()
            MyTrans.Commit()
            Myconn.Close()
        Catch ex As Exception
            MyTrans.Rollback()
            Myconn.Close()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Throw
        End Try
    End Function



    Public Function MoreTrans1(ByVal str() As String)
        Dim i As Integer
        Try
            Myconn.Open()
            MyTrans = Myconn.BeginTransaction()
            Cmd.CommandTimeout = 1000000000
            Cmd.Transaction = MyTrans
            Cmd.Connection = Myconn
            For i = 0 To str.Length - 1
                If str(i) Is Nothing = False Then
                    Cmd.CommandText = str(i)
                    Cmd.CommandType = CommandType.Text
                    Cmd.ExecuteNonQuery()
                End If
            Next i
            MyTrans.Commit()
            Myconn.Close()
        Catch ex As Exception
            MyTrans.Rollback()
            Myconn.Close()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
    End Function
    Public Function FileInfo(ByVal MyFilePath As String)
        If File.Exists(MyFilePath) Then

            Dim MyFile As New FileInfo(MyFilePath)
            Filepath = MyFilePath
            FileSize = MyFile.Length
            dtCreationDate = MyFile.CreationTime
            dtLastAccessTime = MyFile.LastAccessTime
            dtLastWriteTime = MyFile.LastWriteTime

            '            MsgBox(Filepath)
            '           MsgBox(FileSize)
            '          MsgBox(dtCreationDate)
            '         MsgBox(dtLastAccessTime)
            '        MsgBox(dtLastWriteTime)

        End If
    End Function

End Class
