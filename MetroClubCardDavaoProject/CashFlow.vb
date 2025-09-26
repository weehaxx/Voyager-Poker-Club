Imports System.Data.SQLite
Imports Guna.UI2.WinForms

Public Class CashFlow

    Private Sub CashFlow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StyleGrid()
        LoadCashflows() ' Load all records initially
    End Sub

    Protected Overrides Sub OnVisibleChanged(e As EventArgs)
        MyBase.OnVisibleChanged(e)
        If Me.Visible Then
            LoadCashflows()
        End If
    End Sub

    ' ✅ Modified LoadCashflows: Optional filter by date
    ' ✅ Modified LoadCashflows: Optional filter by date AND optional search
    Private Sub LoadCashflows(Optional selectedDate As Date? = Nothing, Optional searchText As String = "")
        Try
            Using conn As New SQLiteConnection("Data Source=metrocarddavaodb.db;Version=3;")
                conn.Open()

                Dim query As String =
                "SELECT " &
                "registration_id AS 'PLAYER MEMBERSHIP ID', " &
                "time_today AS 'TIME', " &
                "CASE WHEN type = 'Buy-In' THEN '₱' || amount ELSE '' END AS 'BUY-IN', " &
                "CASE WHEN type = 'Buy-In' THEN payment_mode ELSE '' END AS 'MODE', " &
                "CASE WHEN type = 'Cash-Out' THEN '₱' || amount ELSE '' END AS 'CASH-OUT', " &
                "CASE WHEN type = 'Cash-Out' THEN payment_mode ELSE '' END AS 'MODE ' " &
                "FROM cashflows WHERE 1=1 "

                ' ✅ Date filter (if date selected)
                If selectedDate.HasValue Then
                    query &= "AND date_today = @selectedDate "
                End If

                ' ✅ Search filter (if text entered)
                If Not String.IsNullOrWhiteSpace(searchText) Then
                    query &= "AND registration_id LIKE @searchText "
                End If

                query &= "ORDER BY date_today DESC, time_today ASC"

                Dim dt As New DataTable()
                Using cmd As New SQLiteCommand(query, conn)

                    If selectedDate.HasValue Then
                        Dim formattedDate As String = selectedDate.Value.ToString("dddd, dd MMMM yyyy")
                        cmd.Parameters.AddWithValue("@selectedDate", formattedDate)
                    End If

                    If Not String.IsNullOrWhiteSpace(searchText) Then
                        ' Allow partial search, e.g. typing "16" shows all IDs starting with 16
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

    ' ✅ Reload data when date picker changes
    Private Sub dtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.ValueChanged
        LoadCashflows(dtpDate.Value)
    End Sub

    Private Sub tbSearchMember_TextChanged(sender As Object, e As EventArgs) Handles tbSearchMember.TextChanged
        LoadCashflows(dtpDate.Value, tbSearchMember.Text.Trim())
    End Sub

End Class
