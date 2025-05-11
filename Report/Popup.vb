Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Text.RegularExpressions
Public Class Popup
    Dim gconnection As New GlobalClass
    Dim sqlstring As String


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GmoduleName = "Indent/Purchase Order Report"
        Dim GSWID As New PucReport
        ' GSWID.MdiParent = Me
        GSWID.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim rViewer As New Viewer
            Dim sqlstring As String
            Dim r As New Issue_indent
            sqlstring = "SELECT   DEPTNAME,DOCNO,ITEMCODE,ITEMNAME,closingstock as QTY FROM vw_issueindent WHERE closingstock<>0 "

            gconnection.getDataSet(sqlstring, "VW_PENDINDGINDENT_PO")
            If gdataset.Tables("VW_PENDINDGINDENT_PO").Rows.Count > 0 Then

                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "VW_INV_IDENTBILL"
                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text11")
                textobj1.Text = MyCompanyName
                Dim textobj2 As TextObject
                textobj2 = r.ReportDefinition.ReportObjects("Text10")
                textobj2.Text = gUsername

                rViewer.Show()
            End If

            'Else
            'gPrint = False
            'Call printoperation()
            ''End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : View Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim rViewer As New Viewer
            Dim sqlstring As String
            Dim r As New Issue_po
            sqlstring = "SELECT   Itemcode,Itemname,Uom ,QTY FROM Po_tobeRaised "

            gconnection.getDataSet(sqlstring, "Po_tobeRaised")
            If gdataset.Tables("Po_tobeRaised").Rows.Count > 0 Then

                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "Po_tobeRaised"
                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text11")
                textobj1.Text = MyCompanyName
                Dim textobj2 As TextObject
                textobj2 = r.ReportDefinition.ReportObjects("Text10")
                textobj2.Text = gUsername

                rViewer.Show()
            End If

            'Else
            'gPrint = False
            'Call printoperation()
            ''End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : View Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Popup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class