Imports System.Data.SQLite
Imports System.IO

Public Class Dashboard
    Dim conn As SQLiteConnection
    Dim dt As DataTable ' ✅ Keep DataTable global for filtering

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dbPath As String = "metrocarddavaodb.db"
        conn = New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")

        LoadRegistrations()
    End Sub

    Private Sub LoadRegistrations()
        Try
            conn.Open()
            Dim sql As String = "SELECT lastname, firstname, middlename, alternativename, presentaddress, permanentaddress, birthday, birthplace, civilstatus, nationality, email, mobilenumber, employmentstatus, businessname, employername, businessnature, workname, presentedid, polmember, relationshippol, nameemergency, relationshipemergency, contactemergency FROM registrations"
            Dim da As New SQLiteDataAdapter(sql, conn)
            dt = New DataTable()
            da.Fill(dt)
            dgvRegistrations.DataSource = dt

            ' ✅ Auto-resize columns to fit content and headers
            dgvRegistrations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgvRegistrations.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            dgvRegistrations.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)

            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading registrations: " & ex.Message)
        End Try
    End Sub

    ' 🔎 Live Search (filters all columns)
    Private Sub tbSearch_TextChanged(sender As Object, e As EventArgs) Handles tbSearch.TextChanged
        Try
            If dt IsNot Nothing Then
                Dim dv As New DataView(dt)
                Dim keyword As String = tbSearch.Text.Replace("'", "''")

                ' ✅ Convert numeric columns to string before filtering
                dv.RowFilter =
                    $"lastname LIKE '%{keyword}%' OR " &
                    $"firstname LIKE '%{keyword}%' OR " &
                    $"middlename LIKE '%{keyword}%' OR " &
                    $"alternativename LIKE '%{keyword}%' OR " &
                    $"presentaddress LIKE '%{keyword}%' OR " &
                    $"permanentaddress LIKE '%{keyword}%' OR " &
                    $"birthday LIKE '%{keyword}%' OR " &
                    $"birthplace LIKE '%{keyword}%' OR " &
                    $"civilstatus LIKE '%{keyword}%' OR " &
                    $"nationality LIKE '%{keyword}%' OR " &
                    $"email LIKE '%{keyword}%' OR " &
                    $"CONVERT(mobilenumber, 'System.String') LIKE '%{keyword}%' OR " &
                    $"employmentstatus LIKE '%{keyword}%' OR " &
                    $"businessname LIKE '%{keyword}%' OR " &
                    $"employername LIKE '%{keyword}%' OR " &
                    $"businessnature LIKE '%{keyword}%' OR " &
                    $"workname LIKE '%{keyword}%' OR " &
                    $"presentedid LIKE '%{keyword}%' OR " &
                    $"polmember LIKE '%{keyword}%' OR " &
                    $"relationshippol LIKE '%{keyword}%' OR " &
                    $"nameemergency LIKE '%{keyword}%' OR " &
                    $"relationshipemergency LIKE '%{keyword}%' OR " &
                    $"CONVERT(contactemergency, 'System.String') LIKE '%{keyword}%'"

                dgvRegistrations.DataSource = dv
            End If
        Catch ex As Exception
            MessageBox.Show("Error searching: " & ex.Message)
        End Try
    End Sub

End Class