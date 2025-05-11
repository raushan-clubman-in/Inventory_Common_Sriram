Public Class TRANSCONV_CHECK
    Dim gconnection As New GlobalClass

    Private Sub TRANSCONV_CHECK_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub LOADGRID(ByVal DC As DataTable)

        DTGRDHDR.DataSource = DC
    End Sub

    Private Sub CMD_eXIT_Click(sender As Object, e As EventArgs) Handles CMD_eXIT.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim SQLSTRING As String
        Dim insert(0) As String
        For K As Integer = 0 To DTGRDHDR.RowCount - 1

            If Format(Val(DTGRDHDR.Rows(K).Cells(2).Value), "0.000000") <> 0.0 Then
                SQLSTRING = "INSERT INTO INVENTORY_TRANSCONVERSION (BASEUOM ,TRANSUOM , CONVVALUE,freeze,ADDUSER ,ADDDATETIME ) VALUES ( "


                SQLSTRING = SQLSTRING & "'" & DTGRDHDR.Rows(K).Cells(0).Value & "',"
                SQLSTRING = SQLSTRING & "'" & DTGRDHDR.Rows(K).Cells(1).Value & "',"
                SQLSTRING = SQLSTRING & "" & Format(Val(DTGRDHDR.Rows(K).Cells(2).Value), "0.000000") & ","
                SQLSTRING = SQLSTRING & "'N',"
                SQLSTRING = SQLSTRING & "'" & gUsername & "',"
                SQLSTRING = SQLSTRING & "GETDATE())"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = SQLSTRING

                If (DTGRDHDR.Rows(K).Cells(0).Value = DTGRDHDR.Rows(K).Cells(1).Value) Then
                Else

                    SQLSTRING = "INSERT INTO INVENTORY_TRANSCONVERSION (BASEUOM ,TRANSUOM , CONVVALUE,freeze,ADDUSER ,ADDDATETIME ) VALUES ( "
                    SQLSTRING = SQLSTRING & "'" & DTGRDHDR.Rows(K).Cells(1).Value & "',"
                    SQLSTRING = SQLSTRING & "'" & DTGRDHDR.Rows(K).Cells(0).Value & "',"
                    SQLSTRING = SQLSTRING & "" & Format(Val(1 / Format(Val(DTGRDHDR.Rows(K).Cells(2).Value), "0.000000")), "0.000000") & ","
                    SQLSTRING = SQLSTRING & "'N',"
                    SQLSTRING = SQLSTRING & "'" & gUsername & "',"
                    SQLSTRING = SQLSTRING & "GETDATE())"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = SQLSTRING

                End If
            Else

            End If

        Next

        gconnection.MoreTrans(insert)
        Dim dt As New DataTable
        Dim sql1 As String
        Dim baseuom As String
        dt.Columns.Add("BaseUom", GetType(String))
        dt.Columns.Add("TransUom", GetType(String))
        dt.Columns.Add("ConvValue", GetType(Double))

        sql1 = "SELECT DISTINCT  ITEMCODE FROM VW_UOMCON "
        gconnection.getDataSet(SQL1, "ITEMLIST")
        If gdataset.Tables("ITEMLIST").Rows.Count > 0 Then
            For it As Integer = 0 To gdataset.Tables("ITEMLIST").Rows.Count - 1
                SQL1 = "sELECT ITEMCODE,TRANUOM FROM VW_UOMCON where itemcode='" + gdataset.Tables("ITEMLIST").Rows(it).Item("ITEMCODE") + "'"
                gconnection.getDataSet(SQL1, "vw_uomcon")
                If gdataset.Tables("vw_uomcon").Rows.Count > 0 Then
                    For k As Integer = 0 To gdataset.Tables("vw_uomcon").Rows.Count - 1
                        baseuom = gdataset.Tables("vw_uomcon").Rows(k).Item("TRANUOM")
                        For m As Integer = k To gdataset.Tables("vw_uomcon").Rows.Count - 1
                            SQL1 = "select baseuom,transuom,convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + baseuom + "' and transuom='" + gdataset.Tables("vw_uomcon").Rows(m).Item("TRANUOM") + "'"
                            gconnection.getDataSet(SQL1, "INVENTORY_TRANSCONVERSION")
                            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                            Else
                                dt.Rows.Add(baseuom, gdataset.Tables("vw_uomcon").Rows(m).Item("TRANUOM"), 0)
                            End If
                        Next


                    Next

                End If
            Next
        End If

        Dim dView As New DataView(dt)
        Dim arrColumns As String() = {"BaseUom", "TransUom", "ConvValue"}
        dt = dView.ToTable(True, arrColumns)


        If dt.Rows.Count > 0 Then
            DTGRDHDR.DataSource = dt
        End If

    End Sub
End Class