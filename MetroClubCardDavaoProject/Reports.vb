Public Class Reports
    Private Sub Reports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ✅ Guna2DateTimePicker setup for Month-Year selection
        dtpMonthYear.Format = DateTimePickerFormat.Custom
        dtpMonthYear.CustomFormat = "MMMM yyyy"
        dtpMonthYear.ShowUpDown = True
        dtpMonthYear.Value = New DateTime(Date.Today.Year, Date.Today.Month, 1)

        ' ✅ Setup DataGridView (dgvReports) to match the table
        SetupReportTable()
    End Sub

    Private Sub SetupReportTable()
        dgvReports.Columns.Clear()
        dgvReports.Rows.Clear()

        dgvReports.AllowUserToAddRows = False
        dgvReports.RowHeadersVisible = False
        dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        dgvReports.ColumnHeadersHeight = 40
        dgvReports.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvReports.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' ✅ Add main columns
        dgvReports.Columns.Add("PlayerName", "PLAYERS NAME / MEMBERSHIP ID")

        ' ✅ Add day columns 1–31
        For i As Integer = 1 To 31
            dgvReports.Columns.Add($"Day{i}", i.ToString())
        Next

        ' ✅ Add TOTAL column
        dgvReports.Columns.Add("Total", "TOTAL")

        ' ✅ Example data
        dgvReports.Rows.Add("JUAN DELA CRUZ")
        dgvReports.Rows.Add("MARIA FLORES")

        ' Example values (matching your screenshot)
        dgvReports.Rows(0).Cells(20).Value = "-20,000"
        dgvReports.Rows(0).Cells(23).Value = "10,000"
        dgvReports.Rows(0).Cells(32).Value = "-10,000"

        dgvReports.Rows(1).Cells(20).Value = "40,000"
        dgvReports.Rows(1).Cells(32).Value = "40,000"

        ' Make first column wider
        dgvReports.Columns(0).Width = 200
    End Sub

    Private Sub dtpMonthYear_ValueChanged(sender As Object, e As EventArgs) Handles dtpMonthYear.ValueChanged
        Dim selectedMonth As Integer = dtpMonthYear.Value.Month
        Dim selectedYear As Integer = dtpMonthYear.Value.Year

        ' You can refresh data here based on selected month/year
        Debug.WriteLine($"Selected: {selectedMonth}/{selectedYear}")
    End Sub
End Class
