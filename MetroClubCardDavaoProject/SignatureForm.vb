Public Class SignatureForm
    Public SignatureImage As Image

    Private drawing As Boolean = False
    Private lastPoint As Point
    Private bmp As Bitmap
    Private g As Graphics

    ' ✅ This will hold the image coming from Registration
    Public ExistingSignature As Image = Nothing

    Private Sub SignatureForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        bmp = New Bitmap(pbSignature.Width, pbSignature.Height)
        g = Graphics.FromImage(bmp)
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        ' ✅ If there is an existing signature, load it
        If ExistingSignature IsNot Nothing Then
            g.DrawImage(ExistingSignature, 0, 0, pbSignature.Width, pbSignature.Height)
        Else
            g.Clear(Color.White)
        End If

        pbSignature.Image = bmp
    End Sub

    Private Sub pbSignature_MouseDown(sender As Object, e As MouseEventArgs) Handles pbSignature.MouseDown
        drawing = True
        lastPoint = e.Location
    End Sub

    Private Sub pbSignature_MouseMove(sender As Object, e As MouseEventArgs) Handles pbSignature.MouseMove
        If drawing Then
            g.DrawLine(Pens.Black, lastPoint, e.Location)
            lastPoint = e.Location
            pbSignature.Invalidate()
        End If
    End Sub

    Private Sub pbSignature_MouseUp(sender As Object, e As MouseEventArgs) Handles pbSignature.MouseUp
        drawing = False
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        g.Clear(Color.White)
        pbSignature.Invalidate()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        SignatureImage = CType(pbSignature.Image.Clone(), Image)
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class
