Imports System.Data.SQLite
Imports System.Globalization
Imports Guna.UI2.WinForms
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Public Class CashFlow

    Private Sub CashFlow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StyleGrid()

        ' 🟢 Set DateTimePicker to current casino date
        dtpDate.Value = GetCasinoDate()

        ' 🟢 Load records for the casino day
        LoadCashflows(dtpDate.Value)
    End Sub

    Protected Overrides Sub OnVisibleChanged(e As EventArgs)
        MyBase.OnVisibleChanged(e)
        If Me.Visible Then
            dtpDate.Value = GetCasinoDate()
            LoadCashflows(dtpDate.Value)
        End If
    End Sub

    ' ✅ Function to get the correct "casino date"
    Private Function GetCasinoDate() As Date
        Dim now As DateTime = DateTime.Now
        Dim sixAM As DateTime = now.Date.AddHours(6)

        ' If time is between midnight and 6AM, treat as yesterday's casino day
        If now < sixAM Then
            Return now.AddDays(-1).Date
        Else
            Return now.Date
        End If
    End Function

    Private Sub LoadCashflows(Optional baseDate As Date = Nothing, Optional searchText As String = "")
        Try
            If baseDate = Nothing Then baseDate = Date.Today

            Dim startDate As DateTime = baseDate.Date
            Dim endDate As DateTime = baseDate.Date.AddDays(1)

            Using conn As New SQLiteConnection("Data Source=metrocarddavaodb.db;Version=3;")
                conn.Open()

                Dim rawQuery As String =
"SELECT r.registration_id, r.firstname, r.middlename, r.lastname, c.date_created, c.time_created, c.type, c.amount, c.payment_mode " &
"FROM cashflows c " &
"INNER JOIN registrations r ON c.registration_id = r.id"

                Dim rawTable As New DataTable()
                Using cmd As New SQLiteCommand(rawQuery, conn)
                    Using adapter As New SQLiteDataAdapter(cmd)
                        adapter.Fill(rawTable)
                    End Using
                End Using

                Dim finalTable As New DataTable()
                finalTable.Columns.Add("PLAYER ID")
                finalTable.Columns.Add("FULL NAME")
                finalTable.Columns.Add("TIME")
                finalTable.Columns.Add("BUY-IN")
                finalTable.Columns.Add("MODE")
                finalTable.Columns.Add("CASH-OUT")
                finalTable.Columns.Add("MODE ")
                ' 🟢 Static columns
                finalTable.Columns.Add("CASHIER'S SIGNATURE")
                finalTable.Columns.Add("REMARKS")

                For Each row As DataRow In rawTable.Rows
                    Dim dateStr As String = row("date_created").ToString()
                    Dim timeStr As String = row("time_created").ToString()
                    Dim parsedDate As DateTime

                    If DateTime.TryParseExact(dateStr & " " & timeStr,
                                          {"dddd, MMMM dd, yyyy hh:mm:ss tt", "dddd, MMMM dd, yyyy h:mm tt"},
                                          CultureInfo.InvariantCulture,
                                          DateTimeStyles.None,
                                          parsedDate) Then

                        If parsedDate >= startDate AndAlso parsedDate < endDate Then
                            Dim fullName As String = row("firstname").ToString().Trim() &
                                                     If(String.IsNullOrWhiteSpace(row("middlename").ToString()), " ", " " & row("middlename").ToString().Trim() & " ") &
                                                     row("lastname").ToString().Trim()

                            If String.IsNullOrWhiteSpace(searchText) OrElse
                               row("registration_id").ToString().Contains(searchText) OrElse
                               row("firstname").ToString().ToLower().Contains(searchText.ToLower()) OrElse
                               row("middlename").ToString().ToLower().Contains(searchText.ToLower()) OrElse
                               row("lastname").ToString().ToLower().Contains(searchText.ToLower()) Then

                                Dim newRow = finalTable.NewRow()
                                newRow("PLAYER ID") = row("registration_id").ToString()
                                newRow("FULL NAME") = fullName.Trim()
                                newRow("TIME") = parsedDate.ToString("h:mm tt")

                                If row("type").ToString().Trim().ToLower() = "buy-in" Then
                                    newRow("BUY-IN") = "₱" & row("amount").ToString()
                                    newRow("MODE") = row("payment_mode").ToString()
                                ElseIf row("type").ToString().Trim().ToLower() = "cash-out" Then
                                    newRow("CASH-OUT") = "₱" & row("amount").ToString()
                                    newRow("MODE ") = row("payment_mode").ToString()
                                End If

                                newRow("CASHIER'S SIGNATURE") = ""
                                newRow("REMARKS") = ""

                                finalTable.Rows.Add(newRow)
                            End If
                        End If
                    End If
                Next

                Dim view As DataView = finalTable.DefaultView
                view.Sort = "TIME ASC"
                dgvCashFlow.DataSource = view.ToTable()

                ' 🟢 Make CASHIER'S SIGNATURE column wider in DataGridView
                If dgvCashFlow.Columns.Contains("CASHIER'S SIGNATURE") Then
                    dgvCashFlow.Columns("CASHIER'S SIGNATURE").Width = 250
                End If

            End Using

        Catch ex As ObjectDisposedException
            Debug.WriteLine("CashFlow control disposed before reload. Skipping refresh.")
        Catch ex As Exception
            MessageBox.Show("Error loading cashflows: " & ex.Message)
        End Try
    End Sub

    Private Sub StyleGrid()
        With dgvCashFlow
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .ColumnHeadersHeight = 40
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Drawing.Font("Segoe UI", 10, Drawing.FontStyle.Bold)
            .DefaultCellStyle.Font = New Drawing.Font("Segoe UI", 10)
            .DefaultCellStyle.ForeColor = Color.Black
            .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            .DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
    End Sub

    Private Sub dgvCashFlow_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCashFlow.CellContentClick
        ' Optional: handle row clicks
    End Sub

    Private Sub dtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.ValueChanged
        LoadCashflows(dtpDate.Value, tbSearchMember.Text.Trim())
    End Sub

    Private Sub tbSearchMember_TextChanged(sender As Object, e As EventArgs) Handles tbSearchMember.TextChanged
        LoadCashflows(dtpDate.Value, tbSearchMember.Text.Trim())
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        dtpDate.Value = GetCasinoDate()
        LoadCashflows(dtpDate.Value, tbSearchMember.Text.Trim())
    End Sub

    ' 🟢 PRINT TO PDF
    Private Sub btnPrintPDF_Click(sender As Object, e As EventArgs) Handles btnPrintPDF.Click
        Try
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "PDF Files|*.pdf"
            saveDialog.Title = "Save CashFlow Report"
            saveDialog.FileName = "CashFlow_" & dtpDate.Value.ToString("yyyyMMdd") & ".pdf"

            If saveDialog.ShowDialog() = DialogResult.OK Then
                Dim doc As New Document(PageSize.A4.Rotate(), 40, 40, 40, 40) ' Landscape
                PdfWriter.GetInstance(doc, New FileStream(saveDialog.FileName, FileMode.Create))
                doc.Open()

                Dim titleFont As iTextSharp.text.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14)
                Dim headerFont As iTextSharp.text.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)
                Dim cellFont As iTextSharp.text.Font = FontFactory.GetFont(FontFactory.HELVETICA, 9)

                Dim title As New Paragraph("CashFlow Report - " & dtpDate.Value.ToString("MMMM dd, yyyy"), titleFont)
                title.Alignment = Element.ALIGN_CENTER
                doc.Add(title)
                doc.Add(New Paragraph(" "))

                Dim pdfTable As New PdfPTable(dgvCashFlow.Columns.Count)
                pdfTable.WidthPercentage = 100

                ' 🟢 Set relative widths (signature column wider)
                Dim widths(dgvCashFlow.Columns.Count - 1) As Single
                For i As Integer = 0 To dgvCashFlow.Columns.Count - 1
                    If dgvCashFlow.Columns(i).HeaderText = "CASHIER'S SIGNATURE" Then
                        widths(i) = 3.5F ' wider
                    Else
                        widths(i) = 1.5F
                    End If
                Next
                pdfTable.SetWidths(widths)

                For Each col As DataGridViewColumn In dgvCashFlow.Columns
                    Dim cell As New PdfPCell(New Phrase(col.HeaderText, headerFont))
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfTable.AddCell(cell)
                Next

                For Each row As DataGridViewRow In dgvCashFlow.Rows
                    If Not row.IsNewRow Then
                        For Each cell As DataGridViewCell In row.Cells
                            pdfTable.AddCell(New Phrase(If(cell.Value, "").ToString(), cellFont))
                        Next
                    End If
                Next

                doc.Add(pdfTable)
                doc.Close()

                MessageBox.Show("PDF exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error exporting PDF: " & ex.Message)
        End Try
    End Sub

End Class
