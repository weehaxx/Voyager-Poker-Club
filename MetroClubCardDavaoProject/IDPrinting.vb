Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports IronBarCode ' ✅ Make sure you installed: BarCode by IronSoftware

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

        ' ✅ Show photo if exists
        If MemberPhoto IsNot Nothing Then
            pbIDphoto.Image = MemberPhoto
        Else
            pbIDphoto.Image = Nothing
        End If

        ' ✅ Generate barcode based on MemberID
        GenerateBarcode(MemberID)
    End Sub

    ' 🔹 Automatically adjust alignment of the ID label
    Private Sub lblID_TextChanged(sender As Object, e As EventArgs) Handles lblMemberID.TextChanged
        AdjustIDLabel()
    End Sub

    Private Sub AdjustIDLabel()
        If lblMemberID Is Nothing OrElse lblMemberID.Parent Is Nothing Then Return

        Dim parentWidth As Integer = lblMemberID.Parent.ClientSize.Width
        Using g As Graphics = lblMemberID.CreateGraphics()
            Dim textSize As SizeF = g.MeasureString(lblMemberID.Text, lblMemberID.Font)
            lblMemberID.Width = CInt(textSize.Width)
            lblMemberID.Left = parentWidth - lblMemberID.Width - 40 ' adjust margin
        End Using
    End Sub

    ' 🔹 Generate barcode image and display it in pbBarcode
    Private Sub GenerateBarcode(value As String)
        Try
            ' Generate a Code128 barcode
            Dim barcode = BarcodeWriter.CreateBarcode(value, BarcodeWriterEncoding.Code128)

            ' Adjust look
            barcode.SetMargins(2)
            barcode.ResizeTo(pbBarcode.Width, pbBarcode.Height)

            ' Display result
            pbBarcode.Image = barcode.ToBitmap()
        Catch ex As Exception
            MessageBox.Show("Error generating barcode: " & ex.Message, "Barcode Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 🔹 Print form to PDF (C80 size)
    Private Sub PrintToC80PDF()
        Try
            btnPrint.Visible = False
            Me.Refresh()

            Dim bmp As New Bitmap(Me.Width, Me.Height)
            Using g As Graphics = Graphics.FromImage(bmp)
                Dim screenPoint As Point = Me.PointToScreen(Point.Empty)
                g.CopyFromScreen(screenPoint.X, screenPoint.Y, 0, 0, Me.Size)
            End Using

            btnPrint.Visible = True

            ' Define C80 card size (in points)
            Dim cardWidth As Single = 85.6F * 2.83465F
            Dim cardHeight As Single = 54.0F * 2.83465F

            Using sfd As New SaveFileDialog()
                sfd.Filter = "PDF Files|*.pdf"
                sfd.FileName = "IDCard.pdf"

                If sfd.ShowDialog() <> DialogResult.OK Then Exit Sub

                Using fs As New FileStream(sfd.FileName, FileMode.Create)
                    Dim doc As New Document(New Rectangle(cardWidth, cardHeight), 0, 0, 0, 0)
                    Dim writer = PdfWriter.GetInstance(doc, fs)
                    doc.Open()

                    Using ms As New MemoryStream()
                        bmp.Save(ms, Imaging.ImageFormat.Png)
                        Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(ms.ToArray())

                        ' Scale image to fill card
                        Dim scaleX As Single = cardWidth / img.Width
                        Dim scaleY As Single = cardHeight / img.Height
                        Dim scale As Single = Math.Max(scaleX, scaleY)
                        img.ScalePercent(scale * 100)

                        Dim offsetX As Single = (cardWidth - img.ScaledWidth) / 2
                        Dim offsetY As Single = (cardHeight - img.ScaledHeight) / 2
                        img.SetAbsolutePosition(offsetX, offsetY)
                        doc.Add(img)
                    End Using

                    doc.Close()
                    writer.Close()
                End Using
            End Using

            MessageBox.Show("✅ ID successfully saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.FindForm().Close()
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
