Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class PaymentGateway
    Inherits System.Windows.Forms.Form
    Dim gconnection As New GlobalClass
    Friend WithEvents cmd_auth As System.Windows.Forms.Button
    Friend WithEvents cmd_export As System.Windows.Forms.Button
    Dim boolchk As Boolean

    Public Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        txt_mcode.Text = ""
        txt_amount.Text = ""
        txt_mname.Text = ""
        txt_paymentdate.Text = ""
        TXT_AUTOID.Text = ""
    End Sub

    Public Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
    Public Sub checkValidation()
        boolchk = False
        '''********** Check  Group desc Can't be blank *********************'''
        If Trim(txt_mcode.Text) = "" Then
            MessageBox.Show("Mcode can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_mcode.Focus()
            Exit Sub
        End If
        If Trim(txt_amount.Text) = "" Then
            MessageBox.Show("Amount can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_amount.Focus()
            Exit Sub
        End If
        If Trim(txt_mname.Text) = "" Then
            MessageBox.Show("Mname can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_amount.Focus()
            Exit Sub
        End If
        boolchk = True
    End Sub

    Private Sub Cmd_Add_Click(sender As Object, e As EventArgs) Handles Cmd_Add.Click
        Call checkValidation()
        If boolchk = False Then Exit Sub
        Dim strsql As String
        strsql = "UPDATE  TrakNpayTrans "
        strsql = strsql & " SET PG='N'"
        strsql = strsql & " WHERE AUTOID = '" & Trim(TXT_AUTOID.Text) & "' AND MCODE ='" & Trim(txt_mcode.Text) & "'"
        gconnection.dataOperation(2, strsql, "TrakNpayTrans")
        Me.Cmd_Clear_Click(sender, e)
        cmdGroupCode.Focus()
    End Sub
    Private Sub cmdGroupCode_Click(sender As Object, e As EventArgs) Handles cmdGroupCode.Click
        Try
            gSQLString = "SELECT AutoId,Mcode,Name,TransDate,TransStatus,refno, amount,transactionid,paymentchannel from Vw_paymentGateway"
            M_WhereCondition = " where cast(TransDate as date) between '" & Format(CDate(dtp_effectdate.Value), "yyyy-MM-dd") & "' and '" & Format(CDate(ToDate.Value), "yyyy-MM-dd") & "' "
            M_ORDERBY = " cast(TransDate as date) desc"
            Dim vform As New ListOperattion1
            vform.Field = "AutoId,Mcode,Name,TransDate,TransStatus,refno,amount,transactionid,paymentchannel"
            vform.vFormatstring = " AutoId  | Mcode     | Name          |  TransDate        |  TransStatus|  refno         |  amount |  transactionid   |  paymentchannel  "
            vform.vCaption = "Payment Gateway Help"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.KeyPos2 = 2
            vform.Keypos3 = 3
            vform.keypos4 = 4
            vform.Keypos5 = 5
            vform.Keypos6 = 6
            vform.Keypos7 = 7
            vform.Keypos8 = 8
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_mcode.Text = Trim(vform.keyfield1 & "")
                txt_mname.Text = Trim(vform.keyfield2 & "")
                txt_amount.Text = Trim(vform.keyfield6 & "")
                txt_paymentdate.Text = Trim(vform.keyfield3 & "")
                TXT_AUTOID.Text = Trim(vform.keyfield & "")
                End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(Err.Description & Err.Source & "Err in Operation", MsgBoxStyle.Information, "Customer Code Help Click")
        End Try
    End Sub
End Class