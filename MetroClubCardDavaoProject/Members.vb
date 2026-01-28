Imports System.Data.SQLite
Imports System.Drawing
Imports System.IO
Imports Guna.UI2.WinForms

Public Class Members
    Dim conn As SQLiteConnection
    Dim dt As DataTable ' Keep DataTable global for filtering

    Private Function GetDatabasePath() As String
        Dim appDataPath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "voyagerpokerclub")
        If Not Directory.Exists(appDataPath) Then
            Directory.CreateDirectory(appDataPath)
        End If
        Return Path.Combine(appDataPath, "voyagerpokerclub.db")
    End Function

    Private Sub ClearMemberDetails()
        tbName.Clear()
        tbPresentAddress.Clear()
        tbPermanentAddress.Clear()
        tbBirthday.Clear()
        tbNationality.Clear()
        tbMobileNum.Clear()
        tbWorkNature.Clear()
        pbPhoto.Image = Nothing
        dgvRegistrations.ClearSelection()
        dgvRegistrations.CurrentCell = Nothing
    End Sub

    Private Sub Members_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvRegistrations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Dim dbPath As String = GetDatabasePath()
        conn = New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")
        LoadRegistrations()
        UpdateTotalMembers()
        tbSearch.Focus()
    End Sub

    Private Sub LoadRegistrations()
        dgvRegistrations.ClearSelection()
        dgvRegistrations.CurrentCell = Nothing

        Try
            conn.Open()
            Dim sql As String = "SELECT id, registration_id, name, birthday, birthplace, presentaddress, permanentaddress, nationality, mobilenumber, worknature, sourceoffund, presentedid, front_id, back_id, photo, signature FROM registrations"
            Dim da As New SQLiteDataAdapter(sql, conn)
            dt = New DataTable()
            da.Fill(dt)

            dgvRegistrations.DataSource = dt

            ' Hide all columns first
            For Each col As DataGridViewColumn In dgvRegistrations.Columns
                col.Visible = False
            Next

            ' Show only ID and Name
            dgvRegistrations.Columns("registration_id").Visible = True
            dgvRegistrations.Columns("name").Visible = True
            dgvRegistrations.Columns("registration_id").HeaderText = "ID"
            dgvRegistrations.Columns("name").HeaderText = "FULL NAME"

            dgvRegistrations.ClearSelection()
            dgvRegistrations.CurrentCell = Nothing
            dgvRegistrations.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvRegistrations.MultiSelect = False

            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading registrations: " & ex.Message)
        End Try
    End Sub

    Private Sub tbSearch_TextChanged(sender As Object, e As EventArgs) Handles tbSearch.TextChanged
        tbSearch.Select()
        Try
            If dt IsNot Nothing Then
                Dim dv As New DataView(dt)
                Dim keyword As String = tbSearch.Text.Replace("'", "''")
                dv.RowFilter = $"Convert(registration_id, 'System.String') LIKE '%{keyword}%' OR name LIKE '%{keyword}%'"
                dgvRegistrations.DataSource = dv
            End If
        Catch ex As Exception
            MessageBox.Show("Error searching: " & ex.Message)
        End Try
    End Sub

    Private Sub dgvRegistrations_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRegistrations.CellClick
        Try
            If e.RowIndex < 0 OrElse e.RowIndex >= dgvRegistrations.Rows.Count Then Exit Sub
            Dim selectedRowView = TryCast(dgvRegistrations.Rows(e.RowIndex).DataBoundItem, DataRowView)
            If selectedRowView Is Nothing Then Exit Sub
            Dim selectedRow = selectedRowView.Row

            ' Fill only the essential fields
            tbName.Text = If(IsDBNull(selectedRow("name")), "", selectedRow("name").ToString())
            tbBirthday.Text = If(IsDBNull(selectedRow("birthday")), "", selectedRow("birthday").ToString())
            tbBirthPlace.Text = If(IsDBNull(selectedRow("birthplace")), "", selectedRow("birthplace").ToString())
            tbPresentAddress.Text = If(IsDBNull(selectedRow("presentaddress")), "", selectedRow("presentaddress").ToString())
            tbPermanentAddress.Text = If(IsDBNull(selectedRow("permanentaddress")), "", selectedRow("permanentaddress").ToString())
            tbNationality.Text = If(IsDBNull(selectedRow("nationality")), "", selectedRow("nationality").ToString())
            tbMobileNum.Text = If(IsDBNull(selectedRow("mobilenumber")), "", selectedRow("mobilenumber").ToString())
            tbWorkNature.Text = If(IsDBNull(selectedRow("worknature")), "", selectedRow("worknature").ToString())
            tbSourceofFund.Text = If(IsDBNull(selectedRow("sourceoffund")), "", selectedRow("sourceoffund").ToString())

            ' Load Photo if exists
            If Not IsDBNull(selectedRow("photo")) Then
                Dim photoData = DirectCast(selectedRow("photo"), Byte())
                Using ms As New MemoryStream(photoData)
                    pbPhoto.Image = Image.FromStream(ms)
                End Using
            Else
                pbPhoto.Image = Nothing
            End If

            If Not IsDBNull(selectedRow("signature")) Then
                Dim sigData = DirectCast(selectedRow("signature"), Byte())
                Using ms As New MemoryStream(sigData)
                    pbSignature.Image = Image.FromStream(ms)
                    pbSignature.SizeMode = PictureBoxSizeMode.StretchImage
                End Using
            Else
                pbSignature.Image = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        End Try


    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If dgvRegistrations.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select a member to delete.", "No Selection",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim selectedRowView = TryCast(dgvRegistrations.SelectedRows(0).DataBoundItem, DataRowView)
            If selectedRowView Is Nothing Then Exit Sub

            Dim memberID As Integer = CInt(selectedRowView.Row("id"))

            If MessageBox.Show(
            "Are you sure you want to permanently delete this member?" &
            vbCrLf & "All of their transactions will also be deleted.",
            "Confirm Deletion",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning) = DialogResult.No Then Exit Sub

            Dim dbPath As String = GetDatabasePath()

            Using conn As New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")
                conn.Open()

                Using tran = conn.BeginTransaction()

                    ' 🔥 Delete ONLY this member's cashflows
                    Using cmd As New SQLiteCommand(
                    "DELETE FROM cashflows WHERE registration_id = @id", conn, tran)
                        cmd.Parameters.AddWithValue("@id", memberID)
                        cmd.ExecuteNonQuery()
                    End Using

                    ' 🔥 Delete the member
                    Using cmd As New SQLiteCommand(
                    "DELETE FROM registrations WHERE id = @id", conn, tran)
                        cmd.Parameters.AddWithValue("@id", memberID)
                        cmd.ExecuteNonQuery()
                    End Using

                    tran.Commit()
                End Using
            End Using

            LoadRegistrations()
            ClearMemberDetails()

            MessageBox.Show("Member and their transactions were deleted.",
                        "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error deleting member: " & ex.Message)
        End Try
    End Sub

    Private Sub UpdateTotalMembers()
        Try
            Dim dbPath As String = GetDatabasePath()
            Using conn As New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")
                conn.Open()
                Dim cmd As New SQLiteCommand("SELECT COUNT(*) FROM registrations", conn)
                lblTotalMembers.Text = cmd.ExecuteScalar().ToString()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error counting members: " & ex.Message)
        End Try
    End Sub


    Private Sub btnViewID_Click(sender As Object, e As EventArgs) Handles btnViewID.Click
        Try
            If dgvRegistrations.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select a member first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim selectedRowView = TryCast(dgvRegistrations.SelectedRows(0).DataBoundItem, DataRowView)
            If selectedRowView Is Nothing Then Exit Sub

            Dim selectedRow = selectedRowView.Row
            Dim memberID As Integer = selectedRow("id")

            Dim frontImage As Image = Nothing
            Dim backImage As Image = Nothing
            Dim idNumber As String = ""
            Dim idPresented As String = ""

            Dim dbPath As String = GetDatabasePath()
            Using conn As New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")
                conn.Open()

                Dim query As String = "SELECT front_id, back_id, identification_number, presentedid FROM registrations WHERE id=@id"
                Using cmd As New SQLiteCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", memberID)

                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then

                            If Not IsDBNull(reader("front_id")) Then
                                Dim frontBytes() As Byte = DirectCast(reader("front_id"), Byte())
                                Using ms As New MemoryStream(frontBytes)
                                    frontImage = Image.FromStream(ms)
                                End Using
                            End If

                            If Not IsDBNull(reader("back_id")) Then
                                Dim backBytes() As Byte = DirectCast(reader("back_id"), Byte())
                                Using ms As New MemoryStream(backBytes)
                                    backImage = Image.FromStream(ms)
                                End Using
                            End If

                            If Not IsDBNull(reader("identification_number")) Then
                                idNumber = reader("identification_number").ToString()
                            End If

                            If Not IsDBNull(reader("presentedid")) Then
                                idPresented = reader("presentedid").ToString()
                            End If

                        End If
                    End Using
                End Using
            End Using

            Dim overlay As New OverlayForm(Me.FindForm)
            overlay.Show()
            overlay.Refresh()

            Dim popup As New Form With {
            .FormBorderStyle = FormBorderStyle.None,
            .StartPosition = FormStartPosition.CenterScreen,
            .Size = New Size(1001, 564),
            .BackColor = Color.White,
            .TopMost = True
        }

            Dim viewIDControl As New ViewID()
            viewIDControl.Dock = DockStyle.Fill
            viewIDControl.FrontIDImage = frontImage
            viewIDControl.BackIDImage = backImage
            viewIDControl.IDNumber = idNumber
            viewIDControl.IDPresented = idPresented

            popup.Controls.Add(viewIDControl)
            popup.ShowDialog()

            overlay.Close()

        Catch ex As Exception
            MessageBox.Show("Error displaying ID: " & ex.Message)
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

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If dgvRegistrations.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select a member first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' ✅ Overlay
            Dim overlay As New OverlayForm(Me.FindForm)
            overlay.Show()
            overlay.Refresh()

            ' ✅ Authentication popup (145 x 47)
            Dim authForm As New Form With {
        .FormBorderStyle = FormBorderStyle.None,
        .StartPosition = FormStartPosition.CenterParent,
        .Size = New Size(461, 232),
        .BackColor = Color.White
    }

            Dim authControl As New Authentication()
            authControl.Dock = DockStyle.Fill

            ' ✅ Handle events
            AddHandler authControl.AuthSuccess,
        Sub()
            authForm.DialogResult = DialogResult.OK
            authForm.Close()
        End Sub

            AddHandler authControl.AuthCancelled,
        Sub()
            authForm.DialogResult = DialogResult.Cancel
            authForm.Close()
        End Sub

            authForm.Controls.Add(authControl)

            ' ✅ Show authentication dialog
            If authForm.ShowDialog() = DialogResult.OK Then
                ' 🔹 Only continue if authentication passed
                Dim selectedRowView = TryCast(dgvRegistrations.SelectedRows(0).DataBoundItem, DataRowView)
                If selectedRowView Is Nothing Then Exit Sub

                Dim selectedRow = selectedRowView.Row
                Dim memberID As Integer = selectedRow("id")
                Dim fullName As String = $"{selectedRow("name")}"

                ' ✅ Now show EditInfo
                Dim popup As New Form With {
            .FormBorderStyle = FormBorderStyle.None,
            .StartPosition = FormStartPosition.CenterParent,
            .Size = New Size(1351, 849),
            .BackColor = Color.White
        }

                Dim editControl As New editInfo()
                editControl.Dock = DockStyle.Fill
                editControl.SelectedMemberID = memberID
                editControl.SelectedFullName = fullName

                popup.Controls.Add(editControl)
                popup.ShowDialog()

                ' ✅ Refresh grid
                LoadRegistrations()
            End If

            overlay.Close()

        Catch ex As Exception
            MessageBox.Show("Error opening edit form: " & ex.Message)
        End Try
    End Sub

    Private Sub btnPrintMember_Click(sender As Object, e As EventArgs) Handles btnPrintMember.Click
        Try
            ' ✅ Check if a row is selected
            If dgvRegistrations.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select a member first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' ✅ Get selected data
            Dim selectedRowView = TryCast(dgvRegistrations.SelectedRows(0).DataBoundItem, DataRowView)
            If selectedRowView Is Nothing Then Exit Sub

            Dim selectedRow = selectedRowView.Row

            ' ✅ Format and convert name to ALL CAPS: LASTNAME, FIRSTNAME MIDDLENAME
            Dim memberName As String = $"{selectedRow("name")}".ToUpper()

            Dim registrationID As String = selectedRow("registration_id").ToString()

            ' ✅ Load photo from DB (or from grid if already loaded)
            Dim memberPhoto As Image = Nothing
            If Not IsDBNull(selectedRow("photo")) Then
                Dim photoData = DirectCast(selectedRow("photo"), Byte())
                Using ms As New MemoryStream(photoData)
                    memberPhoto = Image.FromStream(ms)
                End Using
            End If

            ' ✅ Show overlay
            Dim overlay As New OverlayForm(Me.FindForm)
            overlay.Show()
            overlay.Refresh()

            ' ✅ Create the UserControl first (so we can read its size)
            Dim idPrintingControl As New IDPrinting() With {
        .MemberName = memberName,
        .MemberID = registrationID,
        .MemberPhoto = memberPhoto
    }

            ' ✅ Force layout to ensure proper size is calculated
            idPrintingControl.PerformLayout()
            idPrintingControl.Refresh()

            ' ✅ Create popup form using the UserControl's preferred size
            Dim frm As New Form With {
        .Text = "ID Printing Preview",
        .StartPosition = FormStartPosition.CenterScreen,
        .FormBorderStyle = FormBorderStyle.FixedDialog,
        .MaximizeBox = False,
        .MinimizeBox = False,
        .ShowInTaskbar = False,
        .ClientSize = idPrintingControl.Size ' 👈 Match size of IDPrinting UserControl
    }

            ' ✅ Dock it and add control to form
            idPrintingControl.Dock = DockStyle.Fill
            frm.Controls.Add(idPrintingControl)

            ' ✅ Show modal dialog
            frm.ShowDialog()

            ' ✅ Close overlay
            overlay.Close()
            overlay.Dispose()

        Catch ex As Exception
            MessageBox.Show("Error opening ID Printing: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnViewAccount_Click(sender As Object, e As EventArgs) Handles btnViewAccount.Click
        Try
            ' ✅ Make sure a player is selected
            If dgvRegistrations.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select a player first before viewing the ledger.", "No Player Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim selectedRowView = TryCast(dgvRegistrations.SelectedRows(0).DataBoundItem, DataRowView)
            If selectedRowView Is Nothing Then
                MessageBox.Show("Invalid row selected.")
                Exit Sub
            End If

            Dim selectedRow = selectedRowView.Row
            Dim regID As Long = Convert.ToInt64(selectedRow("id"))
            Dim regCode As String = selectedRow("registration_id").ToString()
            Dim fullName As String = $"{selectedRow("name")}"

            ' ✅ Show overlay
            Dim overlay As New OverlayForm(Me.FindForm)
            overlay.Show()
            overlay.Refresh()

            ' ✅ Create popup window (size 1107x738)
            Dim popup As New Form With {
                .FormBorderStyle = FormBorderStyle.None,
                .StartPosition = FormStartPosition.CenterParent,
                .Size = New Size(1107, 738),
                .BackColor = Color.White
            }

            ' ✅ Add Ledger UserControl
            Dim ledgerControl As New Ledger()
            ledgerControl.Dock = DockStyle.Fill

            ' ✅ Pass player data to Ledger (you need Public Properties in Ledger for these)
            ledgerControl.SelectedRegistrationID = regID
            ledgerControl.SelectedRegistrationCode = regCode
            ledgerControl.SelectedFullName = fullName

            popup.Controls.Add(ledgerControl)

            ' ✅ Show popup
            popup.ShowDialog()
            overlay.Close()

        Catch ex As Exception
            MessageBox.Show("Error opening Ledger: " & ex.Message)
        End Try
    End Sub
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
            Dim regID = selectedRow("id") ' ⚠ Use actual DB id
            Dim fullName = $"{selectedRow("name")}"

            ' ✅ Show overlay with blur
            Dim overlay As New OverlayForm(Me.FindForm)
            overlay.Show()
            overlay.Refresh() ' Ensure it draws immediately

            ' Open PlayerLedger as modal
            Dim dialog As New PlayerLedger
            dialog.RegistrationID = Convert.ToInt64(regID)
            dialog.FullName = fullName

            If dialog.ShowDialog() = DialogResult.OK Then
                MessageBox.Show("Buy-In/Cash-Out recorded.")
            End If

            ' ✅ Close overlay after dialog closes
            overlay.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
End Class
