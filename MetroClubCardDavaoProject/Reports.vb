Imports System.Data.SQLite
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Public Class Reports
    Private conn As SQLiteConnection

    Private Sub Reports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Setup DB connection
        Dim dbPath As String = "metrocarddavaodb.db"
        conn = New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")

        ' ✅ DateTimePicker setup (Month-Year only)
        dtpMonthYear.Format = DateTimePickerFormat.Custom
        dtpMonthYear.CustomFormat = "MMMM yyyy"
        dtpMonthYear.ShowUpDown = True
        dtpMonthYear.Value = New DateTime(Date.Today.Year, Date.Today.Month, 1)

        ' Initial load
        LoadMonthlyReport()
    End Sub

    Private Sub LoadMonthlyReport()
        Try
            conn.Open()

            Dim selectedMonth As Integer = dtpMonthYear.Value.Month
            Dim selectedYear As Integer = dtpMonthYear.Value.Year
            Dim daysInMonth As Integer = DateTime.DaysInMonth(selectedYear, selectedMonth)

            ' 🔹 Setup DataGridView
            dgvReports.Columns.Clear()
            dgvReports.Rows.Clear()
            dgvReports.AllowUserToAddRows = False
            dgvReports.RowHeadersVisible = False
            dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgvReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            dgvReports.ColumnHeadersHeight = 40
            dgvReports.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvReports.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvReports.Font = New System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Regular)
            dgvReports.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightGray

            ' 🔹 First column: Membership ID + Fullname
            dgvReports.Columns.Add("PlayerName", "MEMBERSHIP ID / FULLNAME")
            dgvReports.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvReports.Columns(0).Width = 280

            ' 🔹 Day columns
            For i As Integer = 1 To daysInMonth
                dgvReports.Columns.Add($"Day{i}", i.ToString())
                dgvReports.Columns($"Day{i}").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            ' 🔹 Total column
            dgvReports.Columns.Add("Total", "TOTAL")
            dgvReports.Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' 🔹 Query all transactions
            Dim sql As String = "
                SELECT r.id AS ID,
                       r.registration_id AS MembershipCode,
                       r.firstname, r.middlename, r.lastname,
                       c.date_created,
                       c.type,
                       c.amount
                FROM registrations r
                LEFT JOIN cashflows c ON r.id = c.registration_id
                WHERE c.date_created IS NOT NULL
                ORDER BY r.lastname, r.firstname
            "

            Dim cmd As New SQLiteCommand(sql, conn)
            Dim reader As SQLiteDataReader = cmd.ExecuteReader()

            ' 🔹 Build dictionary
            Dim playerData As New Dictionary(Of Long, (FullName As String, Membership As String, Days As Decimal()))

            While reader.Read()
                Dim regID As Long = CLng(reader("ID"))
                Dim membershipCode As String = reader("MembershipCode").ToString()
                Dim fullname As String = $"{reader("firstname")} {reader("middlename")} {reader("lastname")}".Replace("  ", " ").Trim()

                ' Create array if new player
                If Not playerData.ContainsKey(regID) Then
                    playerData(regID) = (fullname, membershipCode, New Decimal(daysInMonth - 1) {})
                End If

                ' Parse date_created
                Dim dateStr As String = reader("date_created").ToString()
                Dim txDate As Date
                If Date.TryParse(dateStr, txDate) Then
                    If txDate.Year = selectedYear AndAlso txDate.Month = selectedMonth Then
                        Dim dayIndex As Integer = txDate.Day - 1
                        Dim amount As Decimal = Convert.ToDecimal(reader("amount"))
                        Dim txType As String = reader("type").ToString()

                        ' Buy-In = negative, Cash-Out = positive
                        If txType = "Buy-In" Then
                            playerData(regID).Days(dayIndex) -= amount
                        ElseIf txType = "Cash-Out" Then
                            playerData(regID).Days(dayIndex) += amount
                        End If
                    End If
                End If
            End While
            reader.Close()

            ' 🔹 Add rows to dgvReports
            For Each kvp In playerData
                Dim fullname As String = kvp.Value.FullName
                Dim membershipCode As String = kvp.Value.Membership
                Dim days() As Decimal = kvp.Value.Days

                Dim rowIndex As Integer = dgvReports.Rows.Add()
                dgvReports.Rows(rowIndex).Cells(0).Value = $"{membershipCode} - {fullname}"

                Dim total As Decimal = 0
                For i As Integer = 0 To daysInMonth - 1
                    Dim val As Decimal = days(i)
                    If val <> 0 Then
                        dgvReports.Rows(rowIndex).Cells(i + 1).Value = val.ToString("N0")
                        ' 🔴 Only red for negative, black for positive
                        dgvReports.Rows(rowIndex).Cells(i + 1).Style.ForeColor = If(val < 0, Color.Red, Color.Black)
                        total += val
                    End If
                Next
                dgvReports.Rows(rowIndex).Cells(daysInMonth + 1).Value = total.ToString("N0")
                dgvReports.Rows(rowIndex).Cells(daysInMonth + 1).Style.ForeColor = If(total < 0, Color.Red, Color.Black)
            Next

        Catch ex As Exception
            MessageBox.Show("Error loading monthly report: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' ✅ Reload on date change
    Private Sub dtpMonthYear_ValueChanged(sender As Object, e As EventArgs) Handles dtpMonthYear.ValueChanged
        LoadMonthlyReport()
    End Sub

    Private Sub dtpMonthYear_CloseUp(sender As Object, e As EventArgs) Handles dtpMonthYear.CloseUp
        LoadMonthlyReport()
    End Sub

    Private Sub btnPrintMonthly_Click(sender As Object, e As EventArgs) Handles btnPrintMonthly.Click
        Try
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "PDF Files|*.pdf"
            saveDialog.Title = "Save Monthly Report"
            saveDialog.FileName = $"MonthlyReport_{dtpMonthYear.Value.ToString("MMMM_yyyy")}.pdf"

            If saveDialog.ShowDialog() = DialogResult.OK Then
                Dim doc As New Document(PageSize.A4.Rotate(), 20, 20, 20, 20) ' Landscape
                PdfWriter.GetInstance(doc, New FileStream(saveDialog.FileName, FileMode.Create))
                doc.Open()

                ' 🔹 Title
                Dim titleFont As iTextSharp.text.Font = FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD)
                Dim para As New Paragraph($"Monthly Report - {dtpMonthYear.Value.ToString("MMMM yyyy")}", titleFont)
                para.Alignment = Element.ALIGN_CENTER
                para.SpacingAfter = 20
                doc.Add(para)

                ' 🔹 Table
                Dim pdfTable As New PdfPTable(dgvReports.Columns.Count)
                pdfTable.WidthPercentage = 100
                pdfTable.HeaderRows = 1

                ' 🔹 Column widths
                Dim widths(dgvReports.Columns.Count - 1) As Single
                widths(0) = 200 ' Name column
                For i As Integer = 1 To dgvReports.Columns.Count - 2
                    widths(i) = 40 ' Days wider
                Next
                widths(dgvReports.Columns.Count - 1) = 70 ' Total column
                pdfTable.SetWidths(widths)

                ' Column headers
                For Each col As DataGridViewColumn In dgvReports.Columns
                    Dim cell As New PdfPCell(New Phrase(col.HeaderText, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)))
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY
                    pdfTable.AddCell(cell)
                Next

                ' Rows
                For Each row As DataGridViewRow In dgvReports.Rows
                    For colIndex As Integer = 0 To dgvReports.Columns.Count - 1
                        Dim text As String = If(row.Cells(colIndex).Value IsNot Nothing, row.Cells(colIndex).Value.ToString(), "")
                        Dim font As iTextSharp.text.Font = FontFactory.GetFont("Arial", 8)

                        ' 🔴 Only negative red, positive stays black
                        If colIndex > 0 Then
                            Dim val As Decimal
                            If Decimal.TryParse(text.Replace(",", ""), val) Then
                                If val < 0 Then
                                    font.Color = BaseColor.RED
                                End If
                            End If
                        End If

                        Dim pdfCell As New PdfPCell(New Phrase(text, font))
                        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
                        pdfTable.AddCell(pdfCell)
                    Next
                Next

                doc.Add(pdfTable)
                doc.Close()

                MessageBox.Show("Monthly Report exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error exporting report: " & ex.Message)
        End Try
    End Sub
End Class
