Public Class Main

    Private Sub btnRegistration_Click(sender As Object, e As EventArgs) Handles btnRegistration.Click
        ' Clear any existing controls inside Panel1
        Panel1.Controls.Clear()

        ' Create an instance of your Registration UserControl
        Dim registrationUC As New Registration()
        registrationUC.Dock = DockStyle.Fill ' Makes it fill the panel

        ' Add the user control to the panel
        Panel1.Controls.Add(registrationUC)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ' You can leave this empty unless you need custom painting
    End Sub

End Class
