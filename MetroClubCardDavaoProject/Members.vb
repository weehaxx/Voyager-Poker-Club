Imports System.Data.SQLite
Imports System.IO
Imports Guna.UI2.WinForms

Public Class Members
    Dim conn As SQLiteConnection
    Dim dt As DataTable ' Keep DataTable global for filtering

    Private Sub Members_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvRegistrations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Dim dbPath As String = "metrocarddavaodb.db"
        conn = New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")

        ' Disable changing of radio buttons (view-only mode)
        rbSelfEmployed.AutoCheck = False
        rbEmployed.AutoCheck = False
        rbYes.AutoCheck = False
        rbNo.AutoCheck = False

        LoadRegistrations()
    End Sub

    Private Sub LoadRegistrations()
        Try
            conn.Open()

            ' Select all needed columns (we will compute registration_id for display)
            Dim sql As String =
                "SELECT id, lastname, firstname, middlename, alternativename, presentaddress, permanentaddress, birthday, birthplace, civilstatus, nationality, email, mobilenumber, employmentstatus, businessname, businessnature, employername, workname, polmember, relationshippol, nameemergency, relationshipemergency, contactemergency, photo " &
                "FROM registrations"

            Dim da As New SQLiteDataAdapter(sql, conn)
            dt = New DataTable()
            da.Fill(dt)

            ' Add computed column registration_id if missing
            If Not dt.Columns.Contains("registration_id") Then
                dt.Columns.Add("registration_id", GetType(String))
            End If

            For Each row As DataRow In dt.Rows
                Dim rawId As Integer = Convert.ToInt32(row("id"))
                ' Build yyyyMMdd + id padded 4 digits (display only)
                Dim regId As String = DateTime.Now.ToString("yyyyMMdd") & rawId.ToString("D4")
                row("registration_id") = regId
            Next

            ' Bind full DataTable but show only registration_id column in the grid
            dgvRegistrations.DataSource = dt
            For Each col As DataGridViewColumn In dgvRegistrations.Columns
                If col.Name <> "registration_id" Then
                    col.Visible = False
                End If
            Next

            dgvRegistrations.Columns("registration_id").HeaderText = "Registration ID"

            dgvRegistrations.Refresh()
            dgvRegistrations.AutoResizeColumns()
            dgvRegistrations.AutoResizeColumnHeadersHeight()

            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading registrations: " & ex.Message)
        End Try
    End Sub

    ' Live Search by firstname/lastname/middlename only
    Private Sub tbSearch_TextChanged(sender As Object, e As EventArgs) Handles tbSearch.TextChanged
        Try
            If dt IsNot Nothing Then
                Dim dv As New DataView(dt)
                Dim keyword As String = tbSearch.Text.Replace("'", "''")

                dv.RowFilter =
                    $"lastname LIKE '%{keyword}%' OR " &
                    $"firstname LIKE '%{keyword}%' OR " &
                    $"middlename LIKE '%{keyword}%'"

                dgvRegistrations.DataSource = dv
            End If
        Catch ex As Exception
            MessageBox.Show("Error searching: " & ex.Message)
        End Try
    End Sub

    Private Sub dgvRegistrations_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRegistrations.CellClick
        Try
            ' Prevent header/empty-row crash
            If e.RowIndex < 0 OrElse e.RowIndex >= dgvRegistrations.Rows.Count Then Exit Sub

            Dim selectedRowView = TryCast(dgvRegistrations.Rows(e.RowIndex).DataBoundItem, DataRowView)
            If selectedRowView Is Nothing Then Exit Sub

            Dim selectedRow = selectedRowView.Row

            ' Fill detail fields (these columns are present in the DataTable even if hidden in grid)
            tbLastName.Text = If(IsDBNull(selectedRow("lastname")), "", selectedRow("lastname").ToString())
            tbFIrstName.Text = If(IsDBNull(selectedRow("firstname")), "", selectedRow("firstname").ToString())
            tbMiddleName.Text = If(IsDBNull(selectedRow("middlename")), "", selectedRow("middlename").ToString())
            tbAlternativeName.Text = If(IsDBNull(selectedRow("alternativename")), "", selectedRow("alternativename").ToString())
            tbPresentAddress.Text = If(IsDBNull(selectedRow("presentaddress")), "", selectedRow("presentaddress").ToString())
            tbPermanentAddress.Text = If(IsDBNull(selectedRow("permanentaddress")), "", selectedRow("permanentaddress").ToString())
            tbBirthday.Text = If(IsDBNull(selectedRow("birthday")), "", selectedRow("birthday").ToString())
            tbBirthPlace.Text = If(IsDBNull(selectedRow("birthplace")), "", selectedRow("birthplace").ToString())
            tbCivilStatus.Text = If(IsDBNull(selectedRow("civilstatus")), "", selectedRow("civilstatus").ToString())
            tbNationality.Text = If(IsDBNull(selectedRow("nationality")), "", selectedRow("nationality").ToString())
            tbEmail.Text = If(IsDBNull(selectedRow("email")), "", selectedRow("email").ToString())
            tbMobileNum.Text = If(IsDBNull(selectedRow("mobilenumber")), "", selectedRow("mobilenumber").ToString())

            ' Employment Status Handling
            Dim empStatus As String = If(IsDBNull(selectedRow("employmentstatus")), "", selectedRow("employmentstatus").ToString())

            If empStatus = "Self-Employed" Then
                rbSelfEmployed.Checked = True
                rbEmployed.Checked = False

                tbBusinessName.Text = If(IsDBNull(selectedRow("businessname")), "", selectedRow("businessname").ToString())
                tbBusinessNature.Text = If(IsDBNull(selectedRow("businessnature")), "", selectedRow("businessnature").ToString())

                tbEmployerName.Clear()
                tbWorkNature.Clear()
            ElseIf empStatus = "Employed" Then
                rbEmployed.Checked = True
                rbSelfEmployed.Checked = False

                tbEmployerName.Text = If(IsDBNull(selectedRow("employername")), "", selectedRow("employername").ToString())
                tbWorkNature.Text = If(IsDBNull(selectedRow("workname")), "", selectedRow("workname").ToString())

                tbBusinessName.Clear()
                tbBusinessNature.Clear()
            Else
                rbSelfEmployed.Checked = False
                rbEmployed.Checked = False
                tbBusinessName.Clear()
                tbBusinessNature.Clear()
                tbEmployerName.Clear()
                tbWorkNature.Clear()
            End If

            ' Load Photo if exists
            If Not IsDBNull(selectedRow("photo")) Then
                Dim photoData = DirectCast(selectedRow("photo"), Byte())
                Using ms As New MemoryStream(photoData)
                    Guna2PictureBox1.Image = Image.FromStream(ms)
                End Using
            Else
                Guna2PictureBox1.Image = Nothing
            End If

            ' POLITICAL MEMBER HANDLING
            Dim polMember As String = If(IsDBNull(selectedRow("polmember")), "", selectedRow("polmember").ToString())
            Dim relPol As String = If(IsDBNull(selectedRow("relationshippol")), "", selectedRow("relationshippol").ToString())

            If polMember = "Yes" Then
                rbYes.Checked = True
                rbNo.Checked = False
                tbRelationshipPol.Text = relPol
            Else
                rbNo.Checked = True
                rbYes.Checked = False
                tbRelationshipPol.Clear()
            End If

            ' EMERGENCY CONTACT INFO
            tbNameEmergency.Text = If(IsDBNull(selectedRow("nameemergency")), "", selectedRow("nameemergency").ToString())
            tbRelationShipEmergency.Text = If(IsDBNull(selectedRow("relationshipemergency")), "", selectedRow("relationshipemergency").ToString())
            tbContactEmergency.Text = If(IsDBNull(selectedRow("contactemergency")), "", selectedRow("contactemergency").ToString())
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        End Try
    End Sub

    ' Single Players Ledger (Buy-In / Cash-Out) button
    Private Sub gbCashout_Click(sender As Object, e As EventArgs) Handles gbPlayersLedger.Click
        Try
            ' ✅ Check if user has selected a player
            If dgvRegistrations.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select a player first before opening the ledger.", "No Player Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim selectedRowView = TryCast(dgvRegistrations.SelectedRows(0).DataBoundItem, DataRowView)
            If selectedRowView Is Nothing Then
                MessageBox.Show("Invalid row selected.")
                Exit Sub
            End If

            Dim selectedRow = selectedRowView.Row

            Dim regID = selectedRow("registration_id").ToString()
            Dim fullName = $"{selectedRow("lastname")} {selectedRow("firstname")} {selectedRow("middlename")}"

            ' Open BuyInDialog
            Dim dialog As New PlayerLedger
            dialog.RegistrationID = regID
            dialog.FullName = fullName

            If dialog.ShowDialog = DialogResult.OK Then
                MessageBox.Show("Buy-In recorded.")
            End If


            Else
            MessageBox.Show("Please select a member first.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub



    Public Class OverlayForm
        Inherits Form

        Public Sub New(owner As Form)
            Me.FormBorderStyle = FormBorderStyle.None
            Me.BackColor = Color.Black
            Me.Opacity = 0.5 ' Dim effect (50%)
            Me.ShowInTaskbar = False
            Me.StartPosition = FormStartPosition.Manual
            Me.Bounds = owner.Bounds
            Me.TopMost = False ' ✅ Make sure dialog can appear on top
        End Sub
    End Class

End Class
