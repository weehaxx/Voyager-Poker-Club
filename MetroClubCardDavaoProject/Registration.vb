Imports System.Data.SQLite


Public Class Registration
    Dim conn As SQLiteConnection
    Dim cmd As SQLiteCommand



    Private Sub Registration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dbPath As String = "metrocarddavaodb.db"
        conn = New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")

        ' Default: disable relationship input
        tbRelationshipPol.Enabled = False
    End Sub

    Private Sub ValidateForm()
        ' List all required fields here
        Dim requiredFieldsFilled As Boolean =
        Not String.IsNullOrWhiteSpace(tbLastName.Text) AndAlso
        Not String.IsNullOrWhiteSpace(tbFirstName.Text) AndAlso
        Not String.IsNullOrWhiteSpace(tbMiddleName.Text) AndAlso
        Not String.IsNullOrWhiteSpace(tbPresentAddress.Text) AndAlso
        Not String.IsNullOrWhiteSpace(tbPermanentAddress.Text) AndAlso
        Not String.IsNullOrWhiteSpace(tbBirthPlace.Text) AndAlso
        Not String.IsNullOrWhiteSpace(tbCivilStatus.Text) AndAlso
        Not String.IsNullOrWhiteSpace(tbNationality.Text) AndAlso
        Not String.IsNullOrWhiteSpace(tbEmail.Text) AndAlso
        Not String.IsNullOrWhiteSpace(tbMobileNumber.Text) AndAlso
        Not String.IsNullOrWhiteSpace(tbNameEmergency.Text) AndAlso
        Not String.IsNullOrWhiteSpace(tbRelationShipEmergency.Text) AndAlso
        Not String.IsNullOrWhiteSpace(tbContactEmergency.Text) AndAlso
        (tbYes.Checked OrElse tbNo.Checked)

        ' If "Yes" is checked, relationship must not be blank
        If tbYes.Checked Then
            requiredFieldsFilled = requiredFieldsFilled AndAlso Not String.IsNullOrWhiteSpace(tbRelationshipPol.Text)
        End If

        btnSave.Enabled = requiredFieldsFilled
    End Sub

    Private Sub AnyFieldChanged(sender As Object, e As EventArgs) _
    Handles tbLastName.TextChanged, tbFirstName.TextChanged, tbMiddleName.TextChanged,
            tbPresentAddress.TextChanged, tbPermanentAddress.TextChanged, tbBirthPlace.TextChanged,
            tbCivilStatus.TextChanged, tbNationality.TextChanged, tbEmail.TextChanged,
            tbMobileNumber.TextChanged, tbNameEmergency.TextChanged, tbRelationShipEmergency.TextChanged,
            tbContactEmergency.TextChanged, tbRelationshipPol.TextChanged,
            rbSelfEmployed.CheckedChanged, rbEmployed.CheckedChanged,
            tbYes.CheckedChanged, tbNo.CheckedChanged

        ValidateForm()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ' Clear all input fields
        tbLastName.Clear()
        tbFirstName.Clear()
        tbMiddleName.Clear()
        tbAlternativeName.Clear()
        tbPresentAddress.Clear()
        tbPermanentAddress.Clear()
        tbBirthPlace.Clear()
        tbCivilStatus.Clear()
        tbNationality.Clear()
        tbEmail.Clear()
        tbMobileNumber.Clear()
        tnBusinessName.Clear()
        tbEmployerName.Clear()
        tbBusinessNature.Clear()
        tnWorkName.Clear()
        tbPresentedID.Clear()
        tbRelationshipPol.Clear()
        tbNameEmergency.Clear()
        tbRelationShipEmergency.Clear()
        tbContactEmergency.Clear()
        rbSelfEmployed.Checked = False
        rbEmployed.Checked = False
        tbNo.Checked = False
        tbYes.Checked = False
        tbRelationshipPol.Enabled = False ' disable on clear
        dtpBirthday.Value = DateTime.Now
    End Sub

    ' 🔹 Enable Relationship field if Yes, disable if No
    Private Sub tbYes_CheckedChanged(sender As Object, e As EventArgs) Handles tbYes.CheckedChanged
        If tbYes.Checked Then
            tbRelationshipPol.Enabled = True
        End If
    End Sub

    Private Sub tbNo_CheckedChanged(sender As Object, e As EventArgs) Handles tbNo.CheckedChanged
        If tbNo.Checked Then
            tbRelationshipPol.Clear()
            tbRelationshipPol.Enabled = False
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            ' Validation for numeric fields
            If Not IsNumeric(tbMobileNumber.Text) OrElse String.IsNullOrWhiteSpace(tbMobileNumber.Text) Then
                MessageBox.Show("Please enter a valid numeric Mobile Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If Not IsNumeric(tbContactEmergency.Text) OrElse String.IsNullOrWhiteSpace(tbContactEmergency.Text) Then
                MessageBox.Show("Please enter a valid numeric Emergency Contact Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Step 1: Check if a user with the same Full Name exists
            If RegistrationExists(tbLastName.Text, tbFirstName.Text, tbMiddleName.Text) Then
                MessageBox.Show("A registration with the same name already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim employmentStatus As String = ""
            If rbSelfEmployed.Checked Then
                employmentStatus = "Self-Employed"
            ElseIf rbEmployed.Checked Then
                employmentStatus = "Employed"
            End If

            Dim polMember As String = ""
            If tbYes.Checked Then
                polMember = "Yes"
            ElseIf tbNo.Checked Then
                polMember = "No"
            End If

            ' Validation: If Yes is checked, Relationship is required
            If tbYes.Checked AndAlso String.IsNullOrWhiteSpace(tbRelationshipPol.Text) Then
                MessageBox.Show("Please enter the relationship for political family member.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            SaveRegistration(
            tbLastName.Text, tbFirstName.Text, tbMiddleName.Text, tbAlternativeName.Text,
            tbPresentAddress.Text, tbPermanentAddress.Text, dtpBirthday.Value, tbBirthPlace.Text,
            tbCivilStatus.Text, tbNationality.Text, tbEmail.Text, tbMobileNumber.Text,
            employmentStatus, tnBusinessName.Text, tbEmployerName.Text, tbBusinessNature.Text,
            tnWorkName.Text, tbPresentedID.Text, polMember, tbRelationshipPol.Text,
            tbNameEmergency.Text, tbRelationShipEmergency.Text, tbContactEmergency.Text
        )

            MessageBox.Show("Registration saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnClear_Click(Nothing, Nothing)

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 🔹 Allow only numbers for Mobile Number
    Private Sub tbMobileNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbMobileNumber.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' 🔹 Allow only numbers for Emergency Contact
    Private Sub tbContactEmergency_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbContactEmergency.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Public Function RegistrationExists(lastName As String, firstName As String, middleName As String) As Boolean
        Using conn As New SQLiteConnection("Data Source=metrocarddavaodb.db;Version=3;")
            conn.Open()
            Dim sql As String = "SELECT COUNT(*) FROM registrations WHERE lastname=@lastname AND firstname=@firstname AND middlename=@middlename"
            Using cmd As New SQLiteCommand(sql, conn)
                cmd.Parameters.AddWithValue("@lastname", lastName)
                cmd.Parameters.AddWithValue("@firstname", firstName)
                cmd.Parameters.AddWithValue("@middlename", middleName)
                Return Convert.ToInt32(cmd.ExecuteScalar()) > 0
            End Using
        End Using
    End Function

    Private Sub btnAddPhoto_Click(sender As Object, e As EventArgs) Handles btnAddPhoto.Click
        Using ofd As New OpenFileDialog()
            ofd.Title = "Select a Photo"
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            If ofd.ShowDialog() = DialogResult.OK Then
                Try
                    Dim img As Image = Image.FromFile(ofd.FileName)
                    pbCameraDisplay.Image = img
                Catch ex As Exception
                    MessageBox.Show("Unable to load image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub btnUploadID_Click(sender As Object, e As EventArgs) Handles btnUploadID.Click
        Using ofd As New OpenFileDialog()
            ofd.Title = "Select an ID Image"
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            If ofd.ShowDialog() = DialogResult.OK Then
                Try
                    Dim img As Image = Image.FromFile(ofd.FileName)
                    pbIDpresented.Image = img
                    pbIDpresented.SizeMode = PictureBoxSizeMode.StretchImage ' Ensure image fits the box
                Catch ex As Exception
                    MessageBox.Show("Unable to load image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

End Class
