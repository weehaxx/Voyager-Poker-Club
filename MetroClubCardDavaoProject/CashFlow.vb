Imports System.Data.SQLite
Imports System.Globalization
Imports Guna.UI2.WinForms

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

            Dim startDate As DateTime = baseDate.Date ' 12:00 AM
            Dim endDate As DateTime = baseDate.Date.AddDays(1) ' next day 12:00 AM

            Using conn As New SQLiteConnection("Data Source=metrocarddavaodb.db;Version=3;")
                conn.Open()

                Dim rawQuery As String =
"SELECT r.registration_id, c.date_created, c.time_created, c.type, c.amount, c.payment_mode " &
"FROM cashflows c " &
"INNER JOIN registrations r ON c.registration_id = r.id"

                Dim rawTable As New DataTable()
                Using cmd As New SQLiteCommand(rawQuery, conn)
                    Using adapter As New SQLiteDataAdapter(cmd)
                        adapter.Fill(rawTable)
                    End Using
                End Using

                ' ✅ Build output table manually (like the report format)
                Dim finalTable As New DataTable()
                finalTable.Columns.Add("PLAYER ID")
                finalTable.Columns.Add("TIME")
                finalTable.Columns.Add("BUY-IN")
                finalTable.Columns.Add("MODE")
                finalTable.Columns.Add("CASH-OUT")
                finalTable.Columns.Add("MODE ")

                ' ✅ Filter + transform rows
                For Each row As DataRow In rawTable.Rows
                    Dim dateStr As String = row("date_created").ToString()
                    Dim timeStr As String = row("time_created").ToString()
                    Dim parsedDate As DateTime

                    ' Parse date + time safely
                    If DateTime.TryParseExact(dateStr & " " & timeStr,
                                          {"dddd, MMMM dd, yyyy hh:mm:ss tt", "dddd, MMMM dd, yyyy h:mm tt"},
                                          CultureInfo.InvariantCulture,
                                          DateTimeStyles.None,
                                          parsedDate) Then

                        If parsedDate >= startDate AndAlso parsedDate < endDate Then
                            If String.IsNullOrWhiteSpace(searchText) OrElse
                           row("registration_id").ToString().Contains(searchText) Then

                                Dim newRow = finalTable.NewRow()
                                newRow("PLAYER ID") = row("registration_id").ToString()
                                newRow("TIME") = parsedDate.ToString("h:mm tt") ' format like 11:30 AM

                                If row("type").ToString().Trim().ToLower() = "buy-in" Then
                                    newRow("BUY-IN") = "₱" & row("amount").ToString()
                                    newRow("MODE") = row("payment_mode").ToString()
                                ElseIf row("type").ToString().Trim().ToLower() = "cash-out" Then
                                    newRow("CASH-OUT") = "₱" & row("amount").ToString()
                                    newRow("MODE ") = row("payment_mode").ToString()
                                End If

                                finalTable.Rows.Add(newRow)
                            End If
                        End If
                    End If
                Next

                ' ✅ Sort by TIME column
                Dim view As DataView = finalTable.DefaultView
                view.Sort = "TIME ASC"
                dgvCashFlow.DataSource = view.ToTable()

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
        LoadCashflows(dtpDate.Value, tbSearchMember.Text.Trim())
    End Sub

    Private Sub tbSearchMember_TextChanged(sender As Object, e As EventArgs) Handles tbSearchMember.TextChanged
        LoadCashflows(dtpDate.Value, tbSearchMember.Text.Trim())
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        dtpDate.Value = GetCasinoDate()
        LoadCashflows(dtpDate.Value, tbSearchMember.Text.Trim())
    End Sub

End Class
