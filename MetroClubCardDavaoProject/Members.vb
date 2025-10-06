Imports System.Data.SQLite
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Drawing.Text
Imports System.IO
Imports Guna.UI2.WinForms
Imports Zen.Barcode
Imports MessagingToolkit.Barcode



Public Class Members
    Dim conn As SQLiteConnection
    Dim dt As DataTable ' Keep DataTable global for filtering

    'Public Sub GenerateBackID(memberID As Integer)
    '    Dim lastname As String = ""
    '    Dim firstname As String = ""
    '    Dim middlename As String = ""
    '    Dim registrationID As String = ""
    '    Dim memberPhoto As Image = Nothing

    '    ' 1️⃣ Retrieve data from DB
    '    Using conn As New SQLiteConnection("Data Source=metrocarddavaodb.db;Version=3;")
    '        conn.Open()
    '        Dim sql As String = "SELECT lastname, firstname, middlename, registration_id, photo FROM registrations WHERE id=@id"
    '        Using cmd As New SQLiteCommand(sql, conn)
    '            cmd.Parameters.AddWithValue("@id", memberID)
    '            Using reader = cmd.ExecuteReader()
    '                If reader.Read() Then
    '                    lastname = reader("lastname").ToString().Trim().ToUpper()
    '                    firstname = reader("firstname").ToString().Trim().ToUpper()
    '                    middlename = reader("middlename").ToString().Trim().ToUpper()
    '                    registrationID = reader("registration_id").ToString()

    '                    If Not IsDBNull(reader("photo")) Then
    '                        Dim photoData As Byte() = DirectCast(reader("photo"), Byte())
    '                        Using ms As New MemoryStream(photoData)
    '                            memberPhoto = Image.FromStream(ms)
    '                        End Using
    '                    End If
    '                End If
    '            End Using
    '        End Using
    '    End Using

    '    ' 2️⃣ Create blank C80 back layout (1016 x 638 px at 300 dpi)
    '    Dim width As Integer = 1016
    '    Dim height As Integer = 638
    '    Dim background As New Bitmap(width, height)
    '    background.SetResolution(300, 300)

    '    Using g As Graphics = Graphics.FromImage(background)
    '        g.SmoothingMode = SmoothingMode.AntiAlias
    '        g.InterpolationMode = InterpolationMode.HighQualityBicubic
    '        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias

    '        ' 🖤 Black background
    '        g.Clear(Color.Black)

    '        ' 🟠 Orange strip near top (behind name)
    '        Dim orangeBrush As New SolidBrush(Color.FromArgb(220, 83, 44))
    '        Dim stripRect As New Rectangle(0, 180, width, 100)
    '        g.FillRectangle(orangeBrush, stripRect)

    '        ' 🖼 Photo (Top-left)
    '        If memberPhoto IsNot Nothing Then
    '            Dim photoRect As New Rectangle(60, 160, 200, 200)
    '            g.DrawImage(memberPhoto, photoRect)
    '            g.DrawRectangle(New Pen(Color.White, 3), photoRect)
    '        End If

    '        ' ✍ Full Name (Top-right on orange strip)
    '        Dim fullName As String = $"{lastname}, {firstname} {middlename}".Trim()
    '        Dim fontName As New Font("Arial", 28, FontStyle.Bold)
    '        Dim whiteBrush As New SolidBrush(Color.White)
    '        g.DrawString(fullName, fontName, whiteBrush, 300, 200)

    '        ' 📄 Registration ID (Top-right corner)
    '        Dim fontSmall As New Font("Arial", 14, FontStyle.Regular)
    '        Dim regSize = g.MeasureString(registrationID, fontSmall)
    '        g.DrawString(registrationID, fontSmall, whiteBrush, width - regSize.Width - 20, 20)

    '        ' 🌐 Website + Terms (Bottom-left)
    '        Dim fontBottom As New Font("Arial", 16, FontStyle.Regular)
    '        g.DrawString("Terms and conditions apply.", fontBottom, whiteBrush, 60, height - 120)
    '        g.DrawString("www.metrocardclub.com", fontBottom, whiteBrush, 60, height - 90)
    '        g.DrawString("Customer Service: (+63) 917-532-3063", fontBottom, whiteBrush, 60, height - 60)

    '        ' 🧾 Barcode (Bottom-center on white strip)
    '        Dim barcodeDraw = BarcodeDrawFactory.Code128WithChecksum
    '        Dim barcodeImg As Image = barcodeDraw.Draw(registrationID, 50)
    '        Dim barcodeX As Integer = (width - barcodeImg.Width) \ 2
    '        Dim barcodeY As Integer = height - barcodeImg.Height - 10
    '        Dim whiteStripRect As New Rectangle(barcodeX - 10, barcodeY - 5, barcodeImg.Width + 20, barcodeImg.Height + 10)
    '        g.FillRectangle(Brushes.White, whiteStripRect)
    '        g.DrawImage(barcodeImg, barcodeX, barcodeY)
    '    End Using

    '    ' 3️⃣ Let user choose where to save the image
    '    Using sfd As New SaveFileDialog()
    '        sfd.Title = "Save Back ID Image"
    '        sfd.Filter = "PNG Image|*.png"
    '        sfd.FileName = $"ID_Back_{registrationID}.png"

    '        If sfd.ShowDialog() = DialogResult.OK Then
    '            background.Save(sfd.FileName, ImageFormat.Png)
    '            MessageBox.Show($"✅ Back ID saved to: {sfd.FileName}", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        End If
    '    End Using
    'End Sub
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
        dgvRegistrations.ClearSelection()
        dgvRegistrations.CurrentCell = Nothing

        Try
            conn.Open()

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
                Dim regId As String = DateTime.Now.ToString("yyyyMMdd") & rawId.ToString()
                row("registration_id") = regId
            Next

            dgvRegistrations.DataSource = dt

            ' Hide unwanted columns
            For Each col As DataGridViewColumn In dgvRegistrations.Columns
                If col.Name <> "registration_id" Then
                    col.Visible = False
                End If
            Next

            dgvRegistrations.Columns("registration_id").HeaderText = "PLAYER/MEMBERSHIP ID"

            dgvRegistrations.Refresh()
            dgvRegistrations.AutoResizeColumns()
            dgvRegistrations.AutoResizeColumnHeadersHeight()

            ' ✅ Clear auto selection
            dgvRegistrations.ClearSelection()
            dgvRegistrations.CurrentCell = Nothing
            dgvRegistrations.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvRegistrations.MultiSelect = False

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
            Dim regID = selectedRow("id") ' ⚠ Use actual DB id
            Dim fullName = $"{selectedRow("lastname")} {selectedRow("firstname")} {selectedRow("middlename")}"

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
            Dim fullName As String = $"{selectedRow("firstname")} {selectedRow("middlename")} {selectedRow("lastname")}"

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

    Private Sub btnViewID_Click(sender As Object, e As EventArgs) Handles btnViewID.Click
        Try
            ' ✅ Ensure a member is selected
            If dgvRegistrations.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select a member first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim selectedRowView = TryCast(dgvRegistrations.SelectedRows(0).DataBoundItem, DataRowView)
            If selectedRowView Is Nothing Then Exit Sub

            Dim selectedRow = selectedRowView.Row
            Dim memberID As Integer = selectedRow("id")
            Dim memberName As String = $"{selectedRow("lastname")} {selectedRow("firstname")} {selectedRow("middlename")}"
            Dim registrationID As String = selectedRow("registration_id").ToString()

            ' ✅ Get idimage from DB
            Dim idImage As Image = Nothing
            Using conn As New SQLiteConnection("Data Source=metrocarddavaodb.db;Version=3;")
                conn.Open()

                Dim query As String = "SELECT idimage FROM registrations WHERE id=@id"
                Using cmd As New SQLiteCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", memberID)
                    Dim result = cmd.ExecuteScalar()

                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        Dim photoData As Byte() = DirectCast(result, Byte())
                        Using ms As New MemoryStream(photoData)
                            idImage = Image.FromStream(ms)
                        End Using
                    End If
                End Using
            End Using

            ' ✅ Show overlay
            Dim overlay As New OverlayForm(Me.FindForm)
            overlay.Show()
            overlay.Refresh()

            ' ✅ Popup Form (1001 x 564)
            Dim popup As New Form With {
                .FormBorderStyle = FormBorderStyle.None,
                .StartPosition = FormStartPosition.CenterScreen,
                .Size = New Size(1001, 564),
                .BackColor = Color.White,
                .TopMost = True
            }

            ' ✅ Load ViewID user control
            Dim viewIDControl As New ViewID()
            viewIDControl.Dock = DockStyle.Fill
            viewIDControl.IDImage = idImage

            popup.Controls.Add(viewIDControl)
            popup.ShowDialog()

            overlay.Close()

        Catch ex As Exception
            MessageBox.Show("Error displaying ID: " & ex.Message)
        End Try
    End Sub

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
                Dim fullName As String = $"{selectedRow("lastname")} {selectedRow("firstname")} {selectedRow("middlename")}"

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


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            ' ✅ Ensure a member is selected
            If dgvRegistrations.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select a member to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' ✅ Show overlay
            Dim overlay As New OverlayForm(Me.FindForm)
            overlay.Show()
            overlay.Refresh()

            ' ✅ Authentication popup (145 x 47)
            Dim authForm As New Form With {
            .FormBorderStyle = FormBorderStyle.None,
            .StartPosition = FormStartPosition.CenterParent,
            .Size = New Size(527, 310),
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
            If authForm.ShowDialog() <> DialogResult.OK Then
                overlay.Close()
                MessageBox.Show("Deletion cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            ' ✅ Confirm deletion after password success
            If MessageBox.Show("Are you sure you want to permanently delete this member?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                overlay.Close()
                Exit Sub
            End If

            ' ✅ Get selected member ID
            Dim selectedRowView = TryCast(dgvRegistrations.SelectedRows(0).DataBoundItem, DataRowView)
            If selectedRowView Is Nothing Then
                overlay.Close()
                Exit Sub
            End If

            Dim memberID As Integer = selectedRowView.Row("id")

            ' ✅ Delete from database
            Using conn As New SQLiteConnection("Data Source=metrocarddavaodb.db;Version=3;")
                conn.Open()
                Dim cmd As New SQLiteCommand("DELETE FROM registrations WHERE id=@id", conn)
                cmd.Parameters.AddWithValue("@id", memberID)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Member deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' ✅ Refresh list
            LoadRegistrations()

            overlay.Close()

        Catch ex As Exception
            MessageBox.Show("Error deleting member: " & ex.Message)
        End Try
    End Sub


    Private Sub dgvRegistrations_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRegistrations.CellContentClick

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
            Dim memberName As String = $"{selectedRow("lastname")}, {selectedRow("firstname")} {selectedRow("middlename")}".ToUpper()

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

            ' ✅ Create popup
            Dim frm As New Form With {
                .Text = "ID Printing Preview",
                .StartPosition = FormStartPosition.CenterScreen,
                .FormBorderStyle = FormBorderStyle.FixedDialog,
                .MaximizeBox = False,
                .MinimizeBox = False,
                .Size = New Size(800, 500),
                .ShowInTaskbar = False
            }

            ' ✅ Create UserControl and assign values
            Dim idPrintingControl As New IDPrinting() With {
                .Dock = DockStyle.Fill,
                .MemberName = memberName,
                .MemberID = registrationID,
                .MemberPhoto = memberPhoto
            }

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






End Class
