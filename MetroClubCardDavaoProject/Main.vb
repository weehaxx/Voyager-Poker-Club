Public Class Main


    Private Sub btnRegistration_Click(sender As Object, e As EventArgs) Handles btnRegistration.Click
        ' Clear any existing controls inside Panel1
        btnDashboard.Checked = False
        btnRegistration.Checked = True
        btnReport.Checked = False
        Panel1.Controls.Clear()

        ' Create an instance of your Registration UserControl
        Dim registrationUC As New Registration()
        registrationUC.Dock = DockStyle.Fill ' Makes it fill the panel

        ' Add the user control to the panel
        Panel1.Controls.Add(registrationUC)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ' Create an instance of your Dashboard UserControl
        Dim memberUC As New Members()
        memberUC.Dock = DockStyle.Fill ' Makes it fill the panel

        ' Add the user control to the panel
        Panel1.Controls.Add(memberUC)
    End Sub
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        ' Ask user to confirm logout (optional)
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to log out?",
                                                 "Logout",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            ' Show the login form (Form1)
            Dim loginForm As New Form1()
            loginForm.Show()

            ' Close or hide the current Main form
            Me.Close()
        End If
    End Sub
    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        ' Clear any existing controls inside Panel1
        btnDashboard.Checked = True
        btnRegistration.Checked = False
        btnReport.Checked = False
        Panel1.Controls.Clear()

        ' Create an instance of your Dashboard UserControl
        Dim memberUC As New Members()
        memberUC.Dock = DockStyle.Fill ' Makes it fill the panel

        ' Add the user control to the panel
        Panel1.Controls.Add(memberUC)
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        btnDashboard.Checked = False
        btnRegistration.Checked = False
        btnReport.Checked = True
    End Sub

    Private Sub Guna2Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel1.Paint


    End Sub
End Class
