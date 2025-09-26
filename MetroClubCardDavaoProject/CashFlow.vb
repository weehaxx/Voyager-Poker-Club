Imports System.Data.SQLite

Public Class CashFlow

    Private Sub CashFlow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCashflows()
    End Sub

    Private Sub LoadCashflows()
        Try
            Using conn = GetConnection()
                conn.Open()

                ' ✅ Join registrations with cashflows to show player info
                Dim query As String =
                    "SELECT " &
                    "r.registration_id AS 'PLAYER MEMBERSHIP ID', " &
                    "(r.firstname || ' ' || IFNULL(r.middlename || ' ', '') || r.lastname) AS 'FULL NAME', " &
                    "c.time_today AS 'TIME', " &
                    "CASE WHEN c.type = 'Buy-In' THEN '₱' || c.amount ELSE '' END AS 'BUY-IN', " &
                    "CASE WHEN c.type = 'Buy-In' THEN c.payment_mode ELSE '' END AS 'MODE', " &
                    "CASE WHEN c.type = 'Cash-Out' THEN '₱' || c.amount ELSE '' END AS 'CASH-OUT', " &
                    "CASE WHEN c.type = 'Cash-Out' THEN c.payment_mode ELSE '' END AS 'MODE ' " &
                    "FROM cashflows c " &
                    "INNER JOIN registrations r ON c.registration_id = r.id " &   ' ✅ join by foreign key
                    "ORDER BY c.date_today DESC, c.time_today ASC"

                Dim dt As New DataTable()
                Using cmd As New SQLiteCommand(query, conn)
                    Dim adapter As New SQLiteDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using

                dgvCashFlow.DataSource = dt

                ' ✅ Apply Guna2DataGridView styling
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
                    .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    .ReadOnly = True
                End With
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading cashflows: " & ex.Message)
        End Try
    End Sub

End Class
