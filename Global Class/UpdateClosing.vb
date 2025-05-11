Public Class UpdateClosing
    Dim gconnection As New GlobalClass
    Public Function Updatebackdate(ByVal ttype As String, ByVal trndate As DateTime, ByVal itemcode As String, ByVal seqno As Double, ByVal storecode As String, ByVal updatestock As Double, ByVal updatevalue As Double) As Boolean
        Dim sqlstring As String
        Dim AUTOID As Integer = 0
        Dim closingqty As Double
        Dim closingvalue As Double
        Dim Rate As Double
        sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,autoid from closingqty where itemcode='" + itemcode + "' and storecode='" + storecode + "'and trndate<='" + Format(CDate(trndate), "dd/MMM/yyyy") + "' order by trns_seq desc"
        gconnection.getDataSet(sqlstring, "closingqty")
        If (gdataset.Tables("closingqty").Rows.Count > 0) Then
            AUTOID = Val(gdataset.Tables("closingqty").Rows(0).Item("AUTOID"))
            closingqty = gdataset.Tables("closingqty").Rows(0).Item("closingstock")
            closingvalue = gdataset.Tables("closingqty").Rows(0).Item("closingvalue")
        End If

        sqlstring = "update closingqty set openningstock= openningstock +" + Format(Val(updatestock), "0.000") + " ,"
        sqlstring = sqlstring & "  openningvalue="
        sqlstring = sqlstring & "  CASE WHEN openningstock=0"
        sqlstring = sqlstring & "  THEN"
        sqlstring = sqlstring & "    Else"

        sqlstring = sqlstring & "  openningstock*" + Format(Val(Rate), "0.000") + ""
        sqlstring = sqlstring & "    End"
        sqlstring = sqlstring & " ,closingstock= closingstock +" + Format(Val(updatestock), "0.000") + " ,"
        sqlstring = sqlstring & "  closingvalue="
        sqlstring = sqlstring & "  CASE WHEN closingstock=0"
        sqlstring = sqlstring & "  THEN "
        sqlstring = sqlstring & "  0 "
        sqlstring = sqlstring & "  Else"
        sqlstring = sqlstring & "     closingstock *" + Format(Val(Rate), "0.000") + ""
        sqlstring = sqlstring & "       End"

        sqlstring = sqlstring & "  where trndate>'" & Format(CDate(trndate), "dd/MMM/yyyy") & "'"
        sqlstring = sqlstring & "   and trns_seq>" & seqno & " and itemcode='" + itemcode + "'"
      

        sqlstring = "UPDATE closingqty SET  closingvalue=closingstock*(" + Format(Val(Rate), "0.000") + "),openningvalue=openningstock *" + Format(Val((Rate)), "0.000") + ""

        sqlstring = sqlstring & "   where trns_seq>" & seqno & ""




        sqlstring = "UPDATE closingqty SET openningstock=openningstock+(" + Format(Val(updatestock), "0.000") + "), closingstock= closingstock +" + Format(Val(updatestock), "0.000") + " "
        sqlstring = sqlstring & " where trns_seq>" & seqno & " and itemcode='" + itemcode + "'"

        sqlstring = sqlstring & "   and storecode='" + storecode + "'"
       

     
    End Function
End Class
