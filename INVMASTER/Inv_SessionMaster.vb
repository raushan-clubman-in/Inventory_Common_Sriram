Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Public Class Inv_SessionMaster
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim gconnection As New GlobalClass
    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        Call clearform(Me)
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.Cmd_Freeze.Text = "Void[F8]"
        Cmd_Add.Text = "Add [F7]"
        txt_SESSIONCode.Text = ""
        txt_SESSIONDesc.Text = ""
        Me.Cmd_Add.Enabled = True
        Me.Cmd_Freeze.Enabled = True
        Cmd_Freeze.Enabled = True
        txt_SESSIONCode.Focus()
    End Sub
    Public Sub checkValidation()
        boolchk = False
        '''********** Check  Session Code Can't be blank *********************'''
        If Trim(txt_SESSIONCode.Text) = "" Then
            MessageBox.Show(" Session Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_SESSIONCode.Focus()
            Exit Sub
        End If
        '''********** Check  Session desc Can't be blank *********************'''
        If Trim(txt_SESSIONDesc.Text) = "" Then
            MessageBox.Show(" Session Desc. can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_SESSIONDesc.Focus()
            Exit Sub
        End If
        sqlstring = "select isnull(SESSIONCODE,'') as SESSIONCODE from INV_SESSIONMASTER where SESSIONCODE='" & Trim(txt_SESSIONCode.Text) & "'"
        gconnection.getDataSet(sqlstring, "inv1")
        If gdataset.Tables("inv1").Rows.Count > 0 Then
            MessageBox.Show(" Session Code already exists ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_SESSIONCode.Text = ""
            txt_SESSIONCode.Focus()
            Exit Sub
        End If
        boolchk = True
    End Sub
    Public Sub checkValidationU()
        boolchk = False
        '''********** Check  Session Code Can't be blank *********************'''
        If Trim(txt_SESSIONCode.Text) = "" Then
            MessageBox.Show(" Session Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_SESSIONCode.Focus()
            Exit Sub
        End If
        '''********** Check  Session desc Can't be blank *********************'''
        If Trim(txt_SESSIONDesc.Text) = "" Then
            MessageBox.Show(" Session Desc. can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_SESSIONDesc.Focus()
            Exit Sub
        End If

        boolchk = True
    End Sub

    Private Sub Cmd_Add_Click(sender As Object, e As EventArgs) Handles Cmd_Add.Click
        Dim strSQL As String
        If Cmd_Add.Text = "Add [F7]" Then
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            strSQL = " INSERT INTO INV_SESSIONMASTER (SESSIONCODE,SESSIONDESC,VOID,Adduser,ADDDATETIME)"
            strSQL = strSQL & "VALUES ( '" & Trim(txt_SESSIONCode.Text) & "','" & Replace(Trim(txt_SESSIONDesc.Text), "'", "") & "',"
            strSQL = strSQL & "'N','" & Trim(gUsername) & "','" & Format(Date.Now, "dd/MMM/yyyy") & "')"
            gconnection.dataOperation(1, strSQL, "INV_SESSIONMASTER")
            Me.Cmd_Clear_Click(sender, e)
        ElseIf Cmd_Add.Text = "Update[F7]" Then
            Call checkValidationU() '''--->Check Validation
            If boolchk = False Then Exit Sub
            If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Freezed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    boolchk = False
                    ' Exit Sub
                End If
            End If
            strSQL = "UPDATE  INV_SESSIONMASTER "
            strSQL = strSQL & " SET SESSIONDESC='" & Replace(Trim(txt_SESSIONDesc.Text), "'", "") & "',"
            strSQL = strSQL & "UPDATEUSER='" & Trim(gUsername) & "',UPDATETIME='" & Format(Now, "dd/MMM/yyyy") & "',Void='N'"
            strSQL = strSQL & " WHERE SESSIONCODE = '" & Trim(txt_SESSIONCode.Text) & "'"
            gconnection.dataOperation(2, strSQL, "INV_SESSIONMASTER")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
        End If
    End Sub
    Private Sub Cmd_Freeze_Click(sender As Object, e As EventArgs) Handles Cmd_Freeze.Click
        Call checkValidationU() ''-->Check Validation
        If boolchk = False Then Exit Sub
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "V" Then
            sqlstring = "UPDATE  INV_SESSIONMASTER "
            sqlstring = sqlstring & " SET Void= 'Y',voiduser='" & gUsername & " ', voiddate=getDate()"
            sqlstring = sqlstring & " WHERE SESSIONCODE = '" & Trim(txt_SESSIONCode.Text) & "'"
            gconnection.dataOperation(3, sqlstring, "INV_SESSIONMASTER")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
        ElseIf Mid(Me.Cmd_Freeze.Text, 1, 1) = "U" Then
            sqlstring = "UPDATE  INV_SESSIONMASTER "
            sqlstring = sqlstring & " SET Void= 'N',voiduser='" & gUsername & " ', voiddate=getDate()"
            sqlstring = sqlstring & " WHERE SESSIONCODE = '" & Trim(txt_SESSIONCode.Text) & "'"
            gconnection.dataOperation(4, sqlstring, "INV_SESSIONMASTER")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
        End If
    End Sub

    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
    Private Sub cmdSESSIONCode_Click(sender As Object, e As EventArgs) Handles cmdSESSIONCode.Click
        gSQLString = "SELECT ISNULL(SESSIONCODE,'') AS SESSIONCODE,ISNULL(SESSIONDESC,'') AS SESSIONDESC FROM INV_SESSIONMASTER"
        M_WhereCondition = "  "
        Dim vform As New ListOperattion1

        vform.Field = "SESSIONCODE,SESSIONDESC"
        vform.vFormatstring = "         SESSION CODE              |                  SESSION DESCRIPTION                                                                                              "
        vform.vCaption = "SESSION MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_SESSIONCode.Text = Trim(vform.keyfield & "")
            Call txt_SESSIONCode_Validated(txt_SESSIONCode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub txt_SESSIONCode_Validated(sender As Object, e As EventArgs) Handles txt_SESSIONCode.Validated
        If Trim(txt_SESSIONCode.Text) <> "" Then
            sqlstring = "SELECT isnull(SESSIONCODE,'') as SESSIONCODE,isnull(SESSIONDESC,'') as SESSIONDESC,isnull(VOID,'') as VOID,isnull(voiddate,'01/01/1900') as voiddate FROM INV_SESSIONMASTER WHERE SESSIONCODE='" & Trim(txt_SESSIONCode.Text) & "'"
            gconnection.getDataSet(sqlstring, "INV_SESSIONMASTER")
            If gdataset.Tables("INV_SESSIONMASTER").Rows.Count > 0 Then
                txt_SESSIONCode.Text = Trim(gdataset.Tables("INV_SESSIONMASTER").Rows(0).Item("SESSIONCODE"))
                txt_SESSIONDesc.Text = Trim(gdataset.Tables("INV_SESSIONMASTER").Rows(0).Item("SESSIONDESC"))
                txt_SESSIONDesc.Focus()
                If gdataset.Tables("INV_SESSIONMASTER").Rows(0).Item("VOID") = "Y" Then
                    Me.lbl_Freeze.Visible = True
                    Me.lbl_Freeze.Text = ""
                    Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("INV_SESSIONMASTER").Rows(0).Item("voiddate")), "dd/MMM/yyyy")
                    Me.Cmd_Freeze.Text = "Void[F8]"
                    Me.Cmd_Freeze.Enabled = True
                    Me.Cmd_Add.Enabled = False
                    Me.Cmd_Freeze.Enabled = False
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_Freeze.Text = "Void[F8]"
                    Me.Cmd_Add.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                End If
                Me.Cmd_Add.Text = "Update[F7]"
            Else
                Me.lbl_Freeze.Visible = False
                Me.lbl_Freeze.Text = "Record Freezed  On "
                Me.Cmd_Add.Text = "Add [F7]"

                txt_SESSIONDesc.Focus()
            End If

        Else
            txt_SESSIONCode.Text = ""
            txt_SESSIONDesc.Focus()
        End If
    End Sub

    Private Sub Inv_SessionMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txt_SESSIONCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_SESSIONCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If cmdSESSIONCode.Enabled = True Then
                If txt_SESSIONCode.Text = "" Then
                    search = Trim(txt_SESSIONCode.Text)
                    Call cmdSESSIONCode_Click(cmdSESSIONCode, e)
                End If

            End If

        End If
    End Sub

    Private Sub txt_SESSIONCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_SESSIONCode.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_SESSIONCode.Text) = "" Then
                Call cmdSESSIONCode_Click(cmdSESSIONCode, e)
            Else
                txt_SESSIONCode_Validated(txt_SESSIONCode, e)
            End If
        End If
    End Sub
End Class