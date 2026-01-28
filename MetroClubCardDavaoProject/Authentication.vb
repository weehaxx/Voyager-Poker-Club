Public Class Authentication

    ' ✅ Events to notify parent
    Public Event AuthSuccess()
    Public Event AuthCancelled()

    Private Sub Authentication_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ✅ Hide password initially
        tbPassword.UseSystemPasswordChar = True
    End Sub

    Private Sub btnShowPass_Click(sender As Object, e As EventArgs) Handles btnShowPass.Click
        ' Toggle password visibility
        tbPassword.UseSystemPasswordChar = Not tbPassword.UseSystemPasswordChar
    End Sub

    Private Sub btnProceed_Click(sender As Object, e As EventArgs) Handles btnProceed.Click
        ' ✅ Check password
        If tbPassword.Text = "Voyager2026" Then
            RaiseEvent AuthSuccess()   ' 🔹 Signal success
        Else
            MessageBox.Show("Incorrect password.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error)
            tbPassword.Clear()
            tbPassword.Focus()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        RaiseEvent AuthCancelled()
    End Sub
End Class
