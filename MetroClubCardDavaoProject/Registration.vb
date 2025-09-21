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
            ' 🔹 Validation for numeric fields
            If Not IsNumeric(tbMobileNumber.Text) OrElse String.IsNullOrWhiteSpace(tbMobileNumber.Text) Then
                MessageBox.Show("Please enter a valid numeric Mobile Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If Not IsNumeric(tbContactEmergency.Text) OrElse String.IsNullOrWhiteSpace(tbContactEmergency.Text) Then
                MessageBox.Show("Please enter a valid numeric Emergency Contact Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            conn.Open()

            ' 🔹 Step 1: Check if a user with the same Full Name exists
            Dim checkSql As String = "SELECT COUNT(*) FROM registrations WHERE lastname=@lastname AND firstname=@firstname AND middlename=@middlename"
            cmd = New SQLiteCommand(checkSql, conn)
            cmd.Parameters.AddWithValue("@lastname", tbLastName.Text)
            cmd.Parameters.AddWithValue("@firstname", tbFirstName.Text)
            cmd.Parameters.AddWithValue("@middlename", tbMiddleName.Text)

            Dim exists As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            If exists > 0 Then
                MessageBox.Show("A registration with the same name already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                conn.Close()
                Exit Sub
            End If

            ' 🔹 Step 2: Insert if no duplicate
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

            ' 🔹 Validation: If Yes is checked, Relationship is required
            If tbYes.Checked AndAlso String.IsNullOrWhiteSpace(tbRelationshipPol.Text) Then
                MessageBox.Show("Please enter the relationship for political family member.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                conn.Close()
                Exit Sub
            End If

            Dim sql As String =
                "INSERT INTO registrations " &
                "(lastname, firstname, middlename, alternativename, presentaddress, permanentaddress, birthday, birthplace, civilstatus, nationality, email, mobilenumber, employmentstatus, businessname, employername, businessnature, workname, presentedid, polmember, relationshippol, nameemergency, relationshipemergency, contactemergency) " &
                "VALUES (@lastname, @firstname, @middlename, @alternativename, @presentaddress, @permanentaddress, @birthday, @birthplace, @civilstatus, @nationality, @email, @mobilenumber, @employmentstatus, @businessname, @employername, @businessnature, @workname, @presentedid, @polmember, @relationshippol, @nameemergency, @relationshipemergency, @contactemergency)"

            cmd = New SQLiteCommand(sql, conn)
            cmd.Parameters.AddWithValue("@lastname", tbLastName.Text)
            cmd.Parameters.AddWithValue("@firstname", tbFirstName.Text)
            cmd.Parameters.AddWithValue("@middlename", tbMiddleName.Text)
            cmd.Parameters.AddWithValue("@alternativename", tbAlternativeName.Text)
            cmd.Parameters.AddWithValue("@presentaddress", tbPresentAddress.Text)
            cmd.Parameters.AddWithValue("@permanentaddress", tbPermanentAddress.Text)
            cmd.Parameters.AddWithValue("@birthday", dtpBirthday.Value.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@birthplace", tbBirthPlace.Text)
            cmd.Parameters.AddWithValue("@civilstatus", tbCivilStatus.Text)
            cmd.Parameters.AddWithValue("@nationality", tbNationality.Text)
            cmd.Parameters.AddWithValue("@email", tbEmail.Text)
            cmd.Parameters.AddWithValue("@mobilenumber", tbMobileNumber.Text)
            cmd.Parameters.AddWithValue("@employmentstatus", employmentStatus)
            cmd.Parameters.AddWithValue("@businessname", tnBusinessName.Text)
            cmd.Parameters.AddWithValue("@employername", tbEmployerName.Text)
            cmd.Parameters.AddWithValue("@businessnature", tbBusinessNature.Text)
            cmd.Parameters.AddWithValue("@workname", tnWorkName.Text)
            cmd.Parameters.AddWithValue("@presentedid", tbPresentedID.Text)
            cmd.Parameters.AddWithValue("@polmember", polMember)
            cmd.Parameters.AddWithValue("@relationshippol", tbRelationshipPol.Text)
            cmd.Parameters.AddWithValue("@nameemergency", tbNameEmergency.Text)
            cmd.Parameters.AddWithValue("@relationshipemergency", tbRelationShipEmergency.Text)
            cmd.Parameters.AddWithValue("@contactemergency", tbContactEmergency.Text)

            cmd.ExecuteNonQuery()
            conn.Close()

            MessageBox.Show("Registration saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' 🔹 Clear inputs after save
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
End Class
