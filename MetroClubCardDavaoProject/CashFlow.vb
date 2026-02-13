Imports System.Data.SQLite
Imports System.Globalization
Imports Guna.UI2.WinForms
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports VoyagerPokerClub.Members

Public Class CashFlow

    ' ✅ Safe AppData DB Path (consistent with DatabaseModule)
    Private ReadOnly appDataPath As String = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "voyagerpokerclub"
    )
    Private ReadOnly dbPath As String = Path.Combine(appDataPath, "voyagerpokerclub.db")

    Private Sub CashFlow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            StyleGrid()
            dtpDate.Value = GetCasinoDate()
            LoadCashflows(dtpDate.Value)
        Catch ex As Exception
            MessageBox.Show("Error initializing CashFlow form: " & ex.Message)
        End Try
    End Sub

    Protected Overrides Sub OnVisibleChanged(e As EventArgs)
        MyBase.OnVisibleChanged(e)
        If Me.Visible Then
            dtpDate.Value = GetCasinoDate()
            LoadCashflows(dtpDate.Value)
        End If
    End Sub

    ' ✅ Casino Date (resets at 6AM)
    Private Function GetCasinoDate() As Date
        Dim now As DateTime = DateTime.Now
        Dim sixAM As DateTime = now.Date.AddHours(6)
        If now < sixAM Then
            Return now.AddDays(-1).Date
        Else
            Return now.Date
        End If
    End Function

    Private Sub LoadCashflows(Optional baseDate As Date = Nothing, Optional searchText As String = "")
        Try
            If Not File.Exists(dbPath) Then
                MessageBox.Show("Database file not found in AppData. Please initialize or restart the system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If baseDate = Nothing Then baseDate = Date.Today

            Using conn As New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")
                conn.Open()

                ' 🔹 Filter by session_date and optional search text
                Dim rawQuery As String =
"SELECT  c.id AS cashflow_id, r.registration_id, r.name, 
         c.session_date, c.date_created, c.time_created, c.type, c.amount, 
         c.payment_mode, c.created_by
 FROM cashflows c
 INNER JOIN registrations r ON c.registration_id = r.id
 WHERE c.session_date = @sessionDate"

                ' Add search filter if any
                If Not String.IsNullOrWhiteSpace(searchText) Then
                    rawQuery &= " AND (r.registration_id LIKE @search OR r.name LIKE @search)"
                End If

                Dim rawTable As New DataTable()
                Using cmd As New SQLiteCommand(rawQuery, conn)
                    cmd.Parameters.AddWithValue("@sessionDate", baseDate.ToString("dddd, MMMM dd, yyyy"))
                    If Not String.IsNullOrWhiteSpace(searchText) Then
                        cmd.Parameters.AddWithValue("@search", "%" & searchText & "%")
                    End If

                    Using adapter As New SQLiteDataAdapter(cmd)
                        adapter.Fill(rawTable)
                    End Using
                End Using

                ' 🔹 Prepare DataTable for DataGridView
                Dim finalTable As New DataTable()
                finalTable.Columns.Add("CASHFLOW_ID", GetType(Long))
                finalTable.Columns.Add("PLAYER ID")
                finalTable.Columns.Add("FULL NAME")
                finalTable.Columns.Add("SESSION DATE")
                finalTable.Columns.Add("DATE CREATED")
                finalTable.Columns.Add("TIME")
                finalTable.Columns.Add("BUY-IN")
                finalTable.Columns.Add("MODE")
                finalTable.Columns.Add("CASH-OUT")
                finalTable.Columns.Add("MODE ")
                finalTable.Columns.Add("CREATED BY")
                finalTable.Columns.Add("CASHIER'S SIGNATURE")
                finalTable.Columns.Add("REMARKS")

                For Each row As DataRow In rawTable.Rows
                    Dim newRow = finalTable.NewRow()
                    newRow("CASHFLOW_ID") = CLng(row("cashflow_id"))
                    newRow("PLAYER ID") = row("registration_id").ToString()
                    newRow("FULL NAME") = row("name").ToString().Trim()
                    newRow("SESSION DATE") = Convert.ToDateTime(row("session_date")).ToString("dddd, MMMM dd, yyyy")
                    newRow("DATE CREATED") = Convert.ToDateTime(row("date_created")).ToString("dddd, MMMM dd, yyyy")
                    newRow("TIME") = row("time_created").ToString()

                    If row("type").ToString().Trim().ToLower() = "buy-in" Then
                        newRow("BUY-IN") = "₱" & row("amount").ToString()
                        newRow("MODE") = row("payment_mode").ToString()
                    ElseIf row("type").ToString().Trim().ToLower() = "cash-out" Then
                        newRow("CASH-OUT") = "₱" & row("amount").ToString()
                        newRow("MODE ") = row("payment_mode").ToString()
                    End If

                    newRow("CREATED BY") = row("created_by").ToString()
                    newRow("CASHIER'S SIGNATURE") = ""
                    newRow("REMARKS") = ""

                    finalTable.Rows.Add(newRow)
                Next

                ' Sort and bind
                Dim view As DataView = finalTable.DefaultView
                view.Sort = "TIME ASC"
                dgvCashFlow.DataSource = view.ToTable()

                ' Optional: set column widths here...
            End Using

            ' 🔹 Update totals based on session_date
            UpdateTotals(baseDate)

        Catch ex As Exception
            MessageBox.Show("Error loading cashflows: " & ex.Message)
        End Try
    End Sub


    Private Sub StyleGrid()
        With dgvCashFlow
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
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

    ' ✅ PRINT TO PDF
    Private Sub btnPrintPDF_Click(sender As Object, e As EventArgs) Handles btnPrintPDF.Click
        Try
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "PDF Files|*.pdf"
            saveDialog.Title = "Save CashFlow Report"
            saveDialog.FileName = "CashFlow_" & dtpDate.Value.ToString("yyyyMMdd") & ".pdf"

            If saveDialog.ShowDialog() = DialogResult.OK Then
                Dim doc As New Document(PageSize.A4.Rotate(), 40, 40, 40, 40)
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

                ' ✅ Custom column widths for PDF
                Dim widths(dgvCashFlow.Columns.Count - 1) As Single
                For i As Integer = 0 To dgvCashFlow.Columns.Count - 1
                    Select Case dgvCashFlow.Columns(i).HeaderText
                        Case "PLAYER ID" : widths(i) = 2.2F
                        Case "FULL NAME" : widths(i) = 3.5F
                        Case "BUY-IN", "CASH-OUT" : widths(i) = 2.2F
                        Case "MODE", "MODE " : widths(i) = 1.8F
                        Case "CREATED BY" : widths(i) = 2.5F
                        Case "CASHIER'S SIGNATURE" : widths(i) = 3.5F
                        Case "REMARKS" : widths(i) = 1.5F
                        Case Else : widths(i) = 1.5F
                    End Select
                Next
                pdfTable.SetWidths(widths)

                ' ✅ Table headers
                For Each col As DataGridViewColumn In dgvCashFlow.Columns
                    Dim cell As New PdfPCell(New Phrase(col.HeaderText, headerFont))
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfTable.AddCell(cell)
                Next

                ' ✅ Table rows
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

    Private Sub dgvCashFlow_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCashFlow.CellClick
        If e.RowIndex < 0 Then Exit Sub

        Dim row As DataGridViewRow = dgvCashFlow.Rows(e.RowIndex)

        If row.IsNewRow Then Exit Sub
        If row.Cells("CASHFLOW_ID").Value Is DBNull.Value Then Exit Sub

        Dim cashflowId As Long = CLng(row.Cells("CASHFLOW_ID").Value)

        Dim overlay As New OverlayForm(Me.FindForm())
        overlay.Show()
        overlay.Refresh()

        Dim popup As New Form With {
            .FormBorderStyle = FormBorderStyle.None,
            .StartPosition = FormStartPosition.CenterScreen,
            .Size = New Size(637, 460),
            .BackColor = Color.White,
            .TopMost = True
        }

        Dim editCtrl As New editCashflow() With {
            .Dock = DockStyle.Fill,
            .CashflowID = cashflowId,
            .PlayerID = row.Cells("PLAYER ID").Value.ToString(),
            .FullName = row.Cells("FULL NAME").Value.ToString(),
            .CreatedBy = row.Cells("CREATED BY").Value.ToString()
        }

        popup.Controls.Add(editCtrl)

        Dim result As DialogResult = popup.ShowDialog()
        overlay.Close()

        ' 🔄 REFRESH GRID AFTER SAVE
        If result = DialogResult.OK Then
            LoadCashflows(dtpDate.Value, tbSearchMember.Text.Trim())
        End If

    End Sub

    Private Sub OpenEditCashflow(row As DataGridViewRow, cashflowId As Long)

        Dim overlay As New OverlayForm(Me.FindForm())
        overlay.Show()
        overlay.Refresh()

        Dim popup As New Form With {
        .FormBorderStyle = FormBorderStyle.None,
        .StartPosition = FormStartPosition.CenterScreen,
        .Size = New Size(637, 460),
        .BackColor = Color.White,
        .TopMost = True
    }

        Dim editCtrl As New editCashflow() With {
        .Dock = DockStyle.Fill,
        .CashflowID = cashflowId,
        .PlayerID = row.Cells("PLAYER ID").Value.ToString(),
        .FullName = row.Cells("FULL NAME").Value.ToString(),
        .CreatedBy = row.Cells("CREATED BY").Value.ToString()
    }

        popup.Controls.Add(editCtrl)
        popup.ShowDialog()

        Dim result As DialogResult = popup.ShowDialog()

        overlay.Close()

        ' ✅ REFRESH IF EDIT WAS SAVED
        If result = DialogResult.OK Then
            LoadCashflows(dtpDate.Value, tbSearchMember.Text.Trim())
        End If
        overlay.Close()

    End Sub

    Private Sub UpdateTotals(sessionDate As Date)
        Try
            If Not File.Exists(dbPath) Then Exit Sub

            Using conn As New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")
                conn.Open()

                Dim query As String =
    "SELECT type, SUM(amount) AS totalAmount
 FROM cashflows
 WHERE session_date = @sessionDate
 GROUP BY type"

                Using cmd As New SQLiteCommand(query, conn)
                    cmd.Parameters.AddWithValue("@sessionDate", sessionDate.ToString("dddd, MMMM dd, yyyy"))
                    cmd.Parameters.AddWithValue("@sessionDate", sessionDate.ToString("dddd, MMMM dd, yyyy"))

                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        Dim totalCashIn As Decimal = 0
                        Dim totalCashOut As Decimal = 0

                        While reader.Read()
                            Dim type As String = reader("type").ToString().ToLower()
                            Dim amount As Decimal = Convert.ToDecimal(reader("totalAmount"))

                            If type = "buy-in" Then
                                totalCashIn = amount
                            ElseIf type = "cash-out" Then
                                totalCashOut = amount
                            End If
                        End While

                        lblCashIn.Text = "₱" & totalCashIn.ToString("N2")
                        lblCashOut.Text = "₱" & totalCashOut.ToString("N2")
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error calculating totals: " & ex.Message)
        End Try
    End Sub

End Class
