Public Class ViewID
    Public Property FrontIDImage As Image
    Public Property BackIDImage As Image
    Public Property IDNumber As String

    Private Sub ViewID_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Display images and ID
        If FrontIDImage IsNot Nothing Then
            pbFrontID.Image = FrontIDImage
            pbFrontID.SizeMode = PictureBoxSizeMode.StretchImage
        End If

        If BackIDImage IsNot Nothing Then
            pbBackID.Image = BackIDImage
            pbBackID.SizeMode = PictureBoxSizeMode.StretchImage
        End If

        ' Display identification number
        tbIdentificationNumber.Text = IDNumber
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.FindForm.Close()
    End Sub
End Class
