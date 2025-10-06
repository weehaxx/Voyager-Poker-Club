Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports Org.BouncyCastle.Asn1.Ocsp

Public Class IDPrinting
    ' 🔹 Public properties to receive data
    Public Property MemberName As String
    Public Property MemberID As String
    Public Property MemberPhoto As System.Drawing.Image


    Private Sub IDPrinting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Display the received data
        AdjustIDLabel()

        lblName.Text = MemberName
        lblMemberID.Text = MemberID

        If MemberPhoto IsNot Nothing Then
            pbIDphoto.Image = MemberPhoto ' ✅ assuming lblIDphoto is a PictureBox
        Else
            pbIDphoto.Image = Nothing
        End If

    End Sub

    Private Sub lblID_TextChanged(sender As Object, e As EventArgs) Handles lblMemberID.TextChanged
        AdjustIDLabel()
    End Sub




    Private Sub AdjustIDLabel()
        ' ✅ Make sure label and parent exist
        If lblMemberID Is Nothing OrElse lblMemberID.Parent Is Nothing Then
            Return
        End If

        ' Get the width of the parent container
        Dim parentWidth As Integer = lblMemberID.Parent.ClientSize.Width

        ' Measure how wide the text is
        Using g As Graphics = lblMemberID.CreateGraphics()
            Dim textSize As SizeF = g.MeasureString(lblMemberID.Text, lblMemberID.Font)

            ' Set the label width to fit the text completely
            lblMemberID.Width = CInt(textSize.Width)

            ' Move it left so the right edge stays aligned
            lblMemberID.Left = parentWidth - lblMemberID.Width - 40 ' Adjust margin as needed
        End Using
    End Sub

    Private Sub PrintToC80PDF()
        Try
            ' Hide the print button temporarily
            btnPrint.Visible = False
            Me.Refresh()

            ' Capture the visible form (including Guna controls)
            Dim bmp As New Bitmap(Me.Width, Me.Height)
            Using g As Graphics = Graphics.FromImage(bmp)
                Dim screenPoint As Point = Me.PointToScreen(Point.Empty)
                g.CopyFromScreen(screenPoint.X, screenPoint.Y, 0, 0, Me.Size)
            End Using

            btnPrint.Visible = True

            ' Define C80 card size in points (1 mm = 2.83465 points)
            Dim cardWidth As Single = 85.6F * 2.83465F
            Dim cardHeight As Single = 54.0F * 2.83465F

            ' Ask user where to save
            Using sfd As New SaveFileDialog()
                sfd.Filter = "PDF Files|*.pdf"
                sfd.FileName = "IDCard.pdf"

                If sfd.ShowDialog() <> DialogResult.OK Then Exit Sub

                Using fs As New FileStream(sfd.FileName, FileMode.Create)
                    Dim doc As New iTextSharp.text.Document(New iTextSharp.text.Rectangle(cardWidth, cardHeight), 0, 0, 0, 0)
                    Dim writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, fs)
                    doc.Open()

                    ' Convert captured image
                    Using ms As New MemoryStream()
                        bmp.Save(ms, Imaging.ImageFormat.Png)
                        Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(ms.ToArray())

                        ' Scale to completely fill the card (no white borders)
                        Dim scaleX As Single = cardWidth / img.Width
                        Dim scaleY As Single = cardHeight / img.Height
                        Dim scale As Single = Math.Max(scaleX, scaleY)

                        img.ScalePercent(scale * 100)

                        ' Center the image and clip overflow
                        Dim offsetX As Single = (cardWidth - img.ScaledWidth) / 2
                        Dim offsetY As Single = (cardHeight - img.ScaledHeight) / 2

                        img.SetAbsolutePosition(offsetX, offsetY)
                        doc.Add(img)
                    End Using

                    doc.Close()
                    writer.Close()
                End Using
            End Using

            ' ✅ Show message then close form
            MessageBox.Show("✅ ID successfully saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.FindForm().Close() ' 🔹 Close the dialog automatically

        Catch ex As Exception
            MessageBox.Show("Error printing ID: " & ex.Message)
        End Try
    End Sub




    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        PrintToC80PDF()
    End Sub

    Private Sub lblMemberID_Click(sender As Object, e As EventArgs) Handles lblMemberID.Click

    End Sub
End Class
