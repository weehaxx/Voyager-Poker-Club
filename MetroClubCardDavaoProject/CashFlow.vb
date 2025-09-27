Imports System.Data.SQLite
Imports Guna.UI2.WinForms

Public Class CashFlow

    Private Sub CashFlow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StyleGrid()

        ' 🟢 Set DateTimePicker to today's date on load
        dtpDate.Value = Date.Today

        ' 🟢 Load only today's records on startup
        Dim formattedDate As String = dtpDate.Value.ToString("dddd, MMMM dd, yyyy")
        LoadCashflows(formattedDate)
    End Sub

    Protected Overrides Sub OnVisibleChanged(e As EventArgs)
        MyBase.OnVisibleChanged(e)
        If Me.Visible Then
            dtpDate.Value = Date.Today
            Dim formattedDate As String = dtpDate.Value.ToString("dddd, MMMM dd, yyyy")
            LoadCashflows(formattedDate)
        End If
    End Sub

    ' ✅ LoadCashflows: always filter by date (and optional search)
    Private Sub LoadCashflows(Optional selectedDate As String = "", Optional searchText As String = "")
        Try
            Using conn As New SQLiteConnection("Data Source=metrocarddavaodb.db;Version=3;")
                conn.Open()

                Dim query As String =
"SELECT " &
"r.registration_id AS 'PLAYER ID', " &
"c.time_today AS 'TIME', " &
"CASE WHEN c.type = 'Buy-In' THEN '₱' || c.amount ELSE '' END AS 'BUY-IN', " &
"CASE WHEN c.type = 'Buy-In' THEN c.payment_mode ELSE '' END AS 'MODE', " &
"CASE WHEN c.type = 'Cash-Out' THEN '₱' || c.amount ELSE '' END AS 'CASH-OUT', " &
"CASE WHEN c.type = 'Cash-Out' THEN c.payment_mode ELSE '' END AS 'MODE ' " &
"FROM cashflows c " &
"INNER JOIN registrations r ON c.registration_id = r.id " &
"WHERE 1=1 "

                ' ✅ Filter by date_today (always required)
                If Not String.IsNullOrEmpty(selectedDate) Then
                    query &= "AND c.date_today = @selectedDate "
                End If

                ' ✅ Filter by PLAYER ID (registration_id from registrations table)
                If Not String.IsNullOrWhiteSpace(searchText) Then
                    query &= "AND r.registration_id LIKE @searchText "
                End If

                query &= "ORDER BY c.date_today DESC, c.time_today ASC"

                Dim dt As New DataTable()
                Using cmd As New SQLiteCommand(query, conn)
                    If Not String.IsNullOrEmpty(selectedDate) Then
                        cmd.Parameters.AddWithValue("@selectedDate", selectedDate)
                    End If
                    If Not String.IsNullOrWhiteSpace(searchText) Then
                        cmd.Parameters.AddWithValue("@searchText", "%" & searchText & "%")
                    End If

                    Using adapter As New SQLiteDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using

                dgvCashFlow.DataSource = Nothing
                dgvCashFlow.DataSource = dt
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
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .DefaultCellStyle.Font = New Font("Segoe UI", 10)
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
        Dim formattedDate As String = dtpDate.Value.ToString("dddd, MMMM dd, yyyy")
        LoadCashflows(formattedDate, tbSearchMember.Text.Trim())
    End Sub

    Private Sub tbSearchMember_TextChanged(sender As Object, e As EventArgs) Handles tbSearchMember.TextChanged
        Dim formattedDate As String = dtpDate.Value.ToString("dddd, MMMM dd, yyyy")
        LoadCashflows(formattedDate, tbSearchMember.Text.Trim())
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        dtpDate.Value = Date.Today
        Dim formattedDate As String = dtpDate.Value.ToString("dddd, MMMM dd, yyyy")
        LoadCashflows(formattedDate, tbSearchMember.Text.Trim())
    End Sub

End Class
