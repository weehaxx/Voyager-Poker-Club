Public Class Ledger
    Public Property SelectedRegistrationID As Long
    Public Property SelectedRegistrationCode As String
    Public Property SelectedFullName As String

    Private Sub Ledger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Show player info on the form (if you have labels for them)
        tbMemeberID.Text = SelectedRegistrationCode
        tbPlayerName.Text = SelectedFullName

        ' Then load ledger data based on SelectedRegistrationID
        ' LoadLedger(SelectedRegistrationID)
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ' ✅ Close the parent Form (the popup that contains this Ledger UserControl)
        Dim parentForm As Form = Me.FindForm()
        If parentForm IsNot Nothing Then
            parentForm.Close()
        End If
    End Sub

End Class
