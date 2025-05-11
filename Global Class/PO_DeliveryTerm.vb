Public Class PO_DeliveryTerm

    Public pono As String
    Dim sqlstring, pono1, GROUPCODE() As String
    Dim gconnection As New GlobalClass


    Private Sub PO_DeliveryTerm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call FillDELIVERYTERM()
        If pono <> "" Then
            Call validateFillDELIVERYTERM()
        End If

    End Sub
    Private Sub FillDELIVERYTERM()
        Dim i As Integer
        ChkLst_Group.Items.Clear()
        sqlstring = " SELECT ISNULL(DELIVERYTERMCODE,0) AS DELIVERYTERMCODE,ISNULL(DELIVERYTERMDESC,'') AS DELIVERYTERMDESC FROM PO_DELIVERYTERMS  where isnull(freeze,'N')<>'Y' "
        gconnection.getDataSet(sqlstring, "SUBLEDGERMASTER")
        If gdataset.Tables("SUBLEDGERMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("SUBLEDGERMASTER").Rows.Count - 1
                With gdataset.Tables("SUBLEDGERMASTER").Rows(i)
                    ChkLst_Group.Items.Add(Trim(CStr(.Item("DELIVERYTERMCODE"))) & "-->" & Trim(CStr(.Item("DELIVERYTERMDESC"))))
                End With
            Next i
        End If
    End Sub
    Private Sub validateFillDELIVERYTERM()
        Dim i, m As Integer
        sqlstring = " SELECT ISNULL(PODELIVERYTERMS,0) AS DELIVERYTERMCODE,ISNULL(PODELIVERY,'') AS DELIVERYTERMDESC FROM PO_DELIVERYTERMS_DET where pono='" & pono & "'"
        gconnection.getDataSet(sqlstring, "PO_DELIVERYTERMS_DET")
        If gdataset.Tables("PO_DELIVERYTERMS_DET").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("PO_DELIVERYTERMS_DET").Rows.Count - 1
                With gdataset.Tables("SUBLEDGERMASTER").Rows(i)
                    For m = 0 To ChkLst_Group.Items.Count - 1
                        GROUPCODE = Split(ChkLst_Group.CheckedItems(m), "-->")
                        If Trim(GROUPCODE(0)) = Trim(CStr(.Item("DELIVERYTERMCODE"))) Then
                            ChkLst_Group.SetItemChecked(m, True)
                        Else
                            ChkLst_Group.SetItemChecked(m, False)
                        End If
                    Next
                End With
            Next
        End If
    End Sub
End Class