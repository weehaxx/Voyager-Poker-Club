Imports System.Data.SQLite
Imports Guna.UI2.WinForms

Public Class CashFlow

    Private Sub CashFlow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvCashFlow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


        LoadCashflows()
    End Sub

    Private Sub LoadCashflows()
        Try
            Using conn = GetConnection()
                conn.Open()

                ' ✅ Only from cashflows table
                Dim query As String =
                    "SELECT " &
                    "registration_id AS 'PLAYER ID', " &
                    "time_today AS 'TIME', " &
                    "CASE WHEN type = 'Buy-In' THEN '₱' || amount ELSE '' END AS 'BUY-IN', " &
                    "CASE WHEN type = 'Buy-In' THEN payment_mode ELSE '' END AS 'MODE', " &
                    "CASE WHEN type = 'Cash-Out' THEN '₱' || amount ELSE '' END AS 'CASH-OUT', " &
                    "CASE WHEN type = 'Cash-Out' THEN payment_mode ELSE '' END AS 'MODE ' " &
                    "FROM cashflows " &
                    "ORDER BY date_today DESC, time_today ASC"

                Using cmd As New SQLiteCommand(query, conn)
                    Using adapter As New SQLiteDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

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
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading cashflows: " & ex.Message)
        End Try
    End Sub

End Class
