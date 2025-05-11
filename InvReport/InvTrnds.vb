Partial Class InvTrnds
    Partial Public Class stocksummaryDataTable
        Private Sub stocksummaryDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.pegsqtyColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class
End Class

Namespace InvTrndsTableAdapters
    
    Partial Public Class VW_PURCHASEREGISTERTableAdapter
    End Class
End Namespace
