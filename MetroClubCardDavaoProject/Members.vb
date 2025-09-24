Imports System.Data.SQLite
Imports System.IO
Imports Guna.UI2.WinForms

Public Class Members
    Dim conn As SQLiteConnection
    Dim dt As DataTable ' ✅ Keep DataTable global for filtering

    Private Sub Members_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvRegistrations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Dim dbPath As String = "metrocarddavaodb.db"
        conn = New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")

        ' 🔒 Disable changing of radio buttons (view-only mode)
        rbSelfEmployed.AutoCheck = False
        rbEmployed.AutoCheck = False
        rbYes.AutoCheck = False
        rbNo.AutoCheck = False

        LoadRegistrations()
    End Sub

    Private Sub LoadRegistrations()
        Try
            conn.Open()

            ' Select all needed columns
            Dim sql As String =
                "SELECT id, lastname, firstname, middlename, alternativename, presentaddress, permanentaddress, birthday, birthplace, civilstatus, nationality, email, mobilenumber, employmentstatus, businessname, businessnature, employername, workname, polmember, relationshippol, nameemergency, relationshipemergency, contactemergency, photo " &
                "FROM registrations"

            Dim da As New SQLiteDataAdapter(sql, conn)
            dt = New DataTable()
            da.Fill(dt)

            ' ✅ Add computed column registration_id
            If Not dt.Columns.Contains("registration_id") Then
                dt.Columns.Add("registration_id", GetType(String))
            End If

            For Each row As DataRow In dt.Rows
                Dim rawId As Integer = Convert.ToInt32(row("id"))
                ' yyyyMMdd + id padded 4 digits
                Dim regId As String = DateTime.Now.ToString("yyyyMMdd") & rawId.ToString("D4")
                row("registration_id") = regId
            Next

            ' ✅ Bind only registration_id to DataGridView
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

    ' 🔎 Live Search (by firstname, lastname, middlename only)
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
            ' ✅ Prevent header/empty row crash
            If e.RowIndex < 0 OrElse e.RowIndex >= dgvRegistrations.Rows.Count Then Exit Sub

            Dim selectedRowView = TryCast(dgvRegistrations.Rows(e.RowIndex).DataBoundItem, DataRowView)
            If selectedRowView Is Nothing Then Exit Sub

            Dim selectedRow = selectedRowView.Row

            ' ✅ Fill textboxes immediately
            tbLastName.Text = selectedRow("lastname").ToString
            tbFIrstName.Text = selectedRow("firstname").ToString
            tbMiddleName.Text = selectedRow("middlename").ToString
            tbAlternativeName.Text = selectedRow("alternativename").ToString
            tbPresentAddress.Text = selectedRow("presentaddress").ToString
            tbPermanentAddress.Text = selectedRow("permanentaddress").ToString
            tbBirthday.Text = selectedRow("birthday").ToString
            tbBirthPlace.Text = selectedRow("birthplace").ToString
            tbCivilStatus.Text = selectedRow("civilstatus").ToString
            tbNationality.Text = selectedRow("nationality").ToString
            tbEmail.Text = selectedRow("email").ToString
            tbMobileNum.Text = selectedRow("mobilenumber").ToString

            ' ✅ Employment Status Handling
            Dim empStatus As String = selectedRow("employmentstatus").ToString()

            If empStatus = "Self-Employed" Then
                rbSelfEmployed.Checked = True
                rbEmployed.Checked = False

                tbBusinessName.Text = selectedRow("businessname").ToString
                tbBusinessNature.Text = selectedRow("businessnature").ToString

                tbEmployerName.Clear()
                tbWorkNature.Clear()
            ElseIf empStatus = "Employed" Then
                rbEmployed.Checked = True
                rbSelfEmployed.Checked = False

                tbEmployerName.Text = selectedRow("employername").ToString
                tbWorkNature.Text = selectedRow("workname").ToString

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

            ' ✅ Load Photo Immediately
            If Not IsDBNull(selectedRow("photo")) Then
                Dim photoData = DirectCast(selectedRow("photo"), Byte())
                Using ms As New MemoryStream(photoData)
                    Guna2PictureBox1.Image = Image.FromStream(ms)
                End Using
            Else
                Guna2PictureBox1.Image = Nothing
            End If

            ' ✅ POLITICAL MEMBER HANDLING
            Dim polMember As String = selectedRow("polmember").ToString()
            Dim relPol As String = selectedRow("relationshippol").ToString()

            If polMember = "Yes" Then
                rbYes.Checked = True
                rbNo.Checked = False
                tbRelationshipPol.Text = relPol
            Else
                rbNo.Checked = True
                rbYes.Checked = False
                tbRelationshipPol.Clear()
            End If

            ' ✅ EMERGENCY CONTACT INFO
            tbNameEmergency.Text = selectedRow("nameemergency").ToString()
            tbRelationShipEmergency.Text = selectedRow("relationshipemergency").ToString()
            tbContactEmergency.Text = selectedRow("contactemergency").ToString()
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        End Try
    End Sub

    Private Sub gbCashout_Click(sender As Object, e As EventArgs) Handles gbPlayersLedger.Click
        Try
            If dgvRegistrations.SelectedRows.Count > 0 Then
                Dim selectedRowView = TryCast(dgvRegistrations.SelectedRows(0).DataBoundItem, DataRowView)
                If selectedRowView Is Nothing Then
                    MessageBox.Show("Invalid row selected.")
                    Exit Sub
                End If

                Dim selectedRow = selectedRowView.Row
                Dim regID = selectedRow("registration_id").ToString()
                Dim fullName = $"{selectedRow("lastname")} {selectedRow("firstname")} {selectedRow("middlename")}"

                ' ✅ Show overlay *as owned form* so it stays behind the dialog
                Dim overlay As New OverlayForm(Me.FindForm())
                overlay.Owner = Me.FindForm
                overlay.Show()

                ' ✅ Show dialog WITHOUT being a child of the overlay
                Dim dialog As New PlayerLedger()
                dialog.RegistrationID = regID
                dialog.FullName = fullName

                ' ShowDialog with Members as the owner, not overlay
                If dialog.ShowDialog(Me) = DialogResult.OK Then
                    MessageBox.Show("Buy-In recorded.")
                End If

                overlay.Close()
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
