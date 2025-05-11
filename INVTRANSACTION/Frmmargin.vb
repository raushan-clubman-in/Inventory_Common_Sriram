Public Class Frmmargin
    Public farPoint As AxFPUSpreadADO.AxfpSpread

    Private Sub Frmmargin_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.F12) Then
            farPoint.Row = Val(Label9.Text)
            farPoint.Col = 17
            farPoint.Text = Format(Val(TxtMargin.Text), "0.00")
            farPoint.Col = 18
            farPoint.Text = Format(Val(TxtTax.Text), "0.00")
            farPoint.Col = 19
            farPoint.Text = Format(Val(TxtTaxAmount.Text), "0.00")
            farPoint.Col = 20
            farPoint.Text = Format(Val(TxtTCS.Text), "0.00")

            farPoint.Col = 21
            farPoint.Text = Format(Val(TxtITTCSAmount.Text), "0.00")
            'farPoint.Col = 13
            'farPoint.Text = TxtTotAmount.Text
            'farPoint.SetActiveCell(10, farPoint.ActiveRow)
            Me.Close()
        End If
    End Sub
    Private Sub Frmmargin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()
        TxtMargin.Focus()

    End Sub

    Private Sub TxtMargin_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMargin.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            If (TxtMargin.Text = "") Then
                TxtMargin.Text = 0
            End If
            TxtTax.Focus()
        ElseIf (e.KeyCode = Keys.F12) Then
            farPoint.Row = Val(Label9.Text)
            farPoint.Col = 17
            farPoint.Text = Format(Val(TxtMargin.Text), "0.00")
            farPoint.Col = 18
            farPoint.Text = Format(Val(TxtTax.Text), "0.00")
            farPoint.Col = 19
            farPoint.Text = Format(Val(TxtTaxAmount.Text), "0.00")
            farPoint.Col = 20
            farPoint.Text = Format(Val(TxtTCS.Text), "0.00")

            farPoint.Col = 21
            farPoint.Text = Format(Val(TxtITTCSAmount.Text), "0.00")
            'farPoint.Col = 13
            'farPoint.Text = TxtTotAmount.Text
            'farPoint.SetActiveCell(10, farPoint.ActiveRow)
            Me.Close()
        End If

    End Sub

    Private Sub TxtTax_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtTax.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            If (TxtTax.Text = "") Then
                TxtTax.Text = 0
            End If
            If (TxtMargin.Text = "0") Then
                TxtTaxAmount.Text = (Val(TxtBase.Text) * Val(TxtTax.Text)) / 100
            Else
                TxtTaxAmount.Text = (Val(TxtTax.Text) * Val(TxtMargin.Text)) / 100
            End If

            TxtTCS.Focus()
        End If
    End Sub

    Private Sub TxtTCS_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtTCS.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            If (TxtTCS.Text = "") Then
                TxtTCS.Text = 0
            End If

            TxtITTCSAmount.Text = ((Val(TxtTaxAmount.Text) + Val(TxtBase.Text)) * Val(TxtTCS.Text)) / 100
            TxtTotAmount.Text = (Val(TxtTaxAmount.Text) + Val(TxtBase.Text) + Val(TxtITTCSAmount.Text))

            ButNext.Focus()
        End If
    End Sub

    Private Sub ButNext_Click(sender As Object, e As EventArgs) Handles ButNext.Click
        Dim QTY As Double
        farPoint.Row = Val(Label9.Text)
        farPoint.Col = 17
        farPoint.Text = TxtMargin.Text
        farPoint.Col = 18
        farPoint.Text = TxtTax.Text
        farPoint.Col = 19
        farPoint.Text = TxtTaxAmount.Text
        farPoint.Col = 12
        farPoint.Text = TxtTaxAmount.Text
        farPoint.Col = 20
        farPoint.Text = TxtTCS.Text

        farPoint.Col = 21
        farPoint.Text = TxtITTCSAmount.Text
        farPoint.Col = 13
        farPoint.Text = TxtTotAmount.Text

        farPoint.Col = 4

        QTY = Val(farPoint.Text)

        farPoint.Col = 5
        farPoint.Text = Val(TxtTotAmount.Text) / QTY

        farPoint.SetActiveCell(10, farPoint.ActiveRow)
        Me.Close()

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class