Imports System.Data.SQLite
Imports System.IO

Public Class Registration
    Dim conn As SQLiteConnection
    Dim cmd As SQLiteCommand

    Private Sub Registration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dbPath As String = "metrocarddavaodb.db"
        conn = New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")
        tbRelationshipPol.Enabled = False
        btnSave.Enabled = False ' Start disabled
    End Sub

    ' Real-time validation of all fields
    Private Sub ValidateForm()
        Dim mobileValid As Boolean = IsNumeric(tbMobileNumber.Text) AndAlso tbMobileNumber.Text.Trim() <> ""
        Dim contactValid As Boolean = IsNumeric(tbContactEmergency.Text) AndAlso tbContactEmergency.Text.Trim() <> ""

        Dim allFieldsFilled As Boolean =
            Not String.IsNullOrWhiteSpace(tbLastName.Text) AndAlso
            Not String.IsNullOrWhiteSpace(tbFirstName.Text) AndAlso
            Not String.IsNullOrWhiteSpace(tbMiddleName.Text) AndAlso
            Not String.IsNullOrWhiteSpace(tbAlternativeName.Text) AndAlso
            Not String.IsNullOrWhiteSpace(tbPresentAddress.Text) AndAlso
            Not String.IsNullOrWhiteSpace(tbPermanentAddress.Text) AndAlso
            Not String.IsNullOrWhiteSpace(tbBirthPlace.Text) AndAlso
            Not String.IsNullOrWhiteSpace(tbCivilStatus.Text) AndAlso
            Not String.IsNullOrWhiteSpace(tbNationality.Text) AndAlso
            Not String.IsNullOrWhiteSpace(tbEmail.Text) AndAlso
            mobileValid AndAlso
            Not String.IsNullOrWhiteSpace(tnBusinessName.Text) AndAlso
            Not String.IsNullOrWhiteSpace(tbEmployerName.Text) AndAlso
            Not String.IsNullOrWhiteSpace(tbBusinessNature.Text) AndAlso
            Not String.IsNullOrWhiteSpace(tnWorkName.Text) AndAlso
            Not String.IsNullOrWhiteSpace(tbPresentedID.Text) AndAlso
            (rbSelfEmployed.Checked OrElse rbEmployed.Checked) AndAlso
            (tbYes.Checked OrElse tbNo.Checked) AndAlso
            (tbYes.Checked = False OrElse Not String.IsNullOrWhiteSpace(tbRelationshipPol.Text)) AndAlso
            Not String.IsNullOrWhiteSpace(tbNameEmergency.Text) AndAlso
            Not String.IsNullOrWhiteSpace(tbRelationShipEmergency.Text) AndAlso
            contactValid AndAlso
            pbCameraDisplay.Image IsNot Nothing AndAlso
            pbIDpresented.Image IsNot Nothing

        btnSave.Enabled = allFieldsFilled
    End Sub

    ' Trigger validation on all field changes
    Private Sub AnyFieldChanged(sender As Object, e As EventArgs) _
    Handles tbLastName.TextChanged, tbFirstName.TextChanged, tbMiddleName.TextChanged,
            tbAlternativeName.TextChanged, tbPresentAddress.TextChanged, tbPermanentAddress.TextChanged,
            tbBirthPlace.TextChanged, tbCivilStatus.TextChanged, tbNationality.TextChanged,
            tbEmail.TextChanged, tbMobileNumber.TextChanged, tnBusinessName.TextChanged,
            tbEmployerName.TextChanged, tbBusinessNature.TextChanged, tnWorkName.TextChanged,
            tbPresentedID.TextChanged, tbRelationshipPol.TextChanged, tbNameEmergency.TextChanged,
            tbRelationShipEmergency.TextChanged, tbContactEmergency.TextChanged,
            rbSelfEmployed.CheckedChanged, rbEmployed.CheckedChanged,
            tbYes.CheckedChanged, tbNo.CheckedChanged

        ValidateForm()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
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
        tbRelationshipPol.Enabled = False
        dtpBirthday.Value = DateTime.Now
        pbCameraDisplay.Image = Nothing
        pbIDpresented.Image = Nothing
        btnSave.Enabled = False
    End Sub

    Private Sub tbYes_CheckedChanged(sender As Object, e As EventArgs) Handles tbYes.CheckedChanged
        tbRelationshipPol.Enabled = tbYes.Checked
        ValidateForm()
    End Sub

    Private Sub tbNo_CheckedChanged(sender As Object, e As EventArgs) Handles tbNo.CheckedChanged
        If tbNo.Checked Then
            tbRelationshipPol.Clear()
            tbRelationshipPol.Enabled = False
        End If
        ValidateForm()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            ' Extra numeric validation
            If Not IsNumeric(tbMobileNumber.Text) OrElse String.IsNullOrWhiteSpace(tbMobileNumber.Text) Then
                MessageBox.Show("Please enter a valid numeric Mobile Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If Not IsNumeric(tbContactEmergency.Text) OrElse String.IsNullOrWhiteSpace(tbContactEmergency.Text) Then
                MessageBox.Show("Please enter a valid numeric Emergency Contact Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If RegistrationExists(tbLastName.Text, tbFirstName.Text, tbMiddleName.Text) Then
                MessageBox.Show("A registration with the same name already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim employmentStatus As String = If(rbSelfEmployed.Checked, "Self-Employed", If(rbEmployed.Checked, "Employed", ""))
            Dim polMember As String = If(tbYes.Checked, "Yes", If(tbNo.Checked, "No", ""))

            Dim photoBytes As Byte() = If(pbCameraDisplay.Image IsNot Nothing, ImageToByteArray(pbCameraDisplay.Image), Nothing)
            Dim idBytes As Byte() = If(pbIDpresented.Image IsNot Nothing, ImageToByteArray(pbIDpresented.Image), Nothing)

            SaveRegistration(
                tbLastName.Text, tbFirstName.Text, tbMiddleName.Text, tbAlternativeName.Text,
                tbPresentAddress.Text, tbPermanentAddress.Text, dtpBirthday.Value.ToString("yyyy-MM-dd"), tbBirthPlace.Text,
                tbCivilStatus.Text, tbNationality.Text, tbEmail.Text, tbMobileNumber.Text,
                employmentStatus, tnBusinessName.Text, tbEmployerName.Text, tbBusinessNature.Text,
                tnWorkName.Text, tbPresentedID.Text, polMember, tbRelationshipPol.Text,
                tbNameEmergency.Text, tbRelationShipEmergency.Text, tbContactEmergency.Text,
                idBytes, photoBytes
            )

            MessageBox.Show("Registration saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnClear_Click(Nothing, Nothing)

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tbMobileNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbMobileNumber.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub tbContactEmergency_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbContactEmergency.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then e.Handled = True
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
                pbCameraDisplay.Image = Image.FromFile(ofd.FileName)
                ValidateForm()
            End If
        End Using
    End Sub

    Private Sub btnUploadID_Click(sender As Object, e As EventArgs) Handles btnUploadID.Click
        Using ofd As New OpenFileDialog()
            ofd.Title = "Select an ID Image"
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            If ofd.ShowDialog() = DialogResult.OK Then
                pbIDpresented.Image = Image.FromFile(ofd.FileName)
                pbIDpresented.SizeMode = PictureBoxSizeMode.StretchImage
                ValidateForm()
            End If
        End Using
    End Sub

    Private Function ImageToByteArray(img As Image) As Byte()
        Using ms As New MemoryStream()
            img.Save(ms, img.RawFormat)
            Return ms.ToArray()
        End Using
    End Function

    Private Sub SaveRegistration(lastName As String, firstName As String, middleName As String,
                                 altName As String, presentAddr As String, permanentAddr As String,
                                 birthday As String, birthPlace As String, civilStatus As String,
                                 nationality As String, email As String, mobile As String,
                                 employment As String, businessName As String, employerName As String,
                                 businessNature As String, workName As String, presentedID As String,
                                 polMember As String, relationshipPol As String,
                                 nameEmergency As String, relationshipEmergency As String, contactEmergency As String,
                                 idImage As Byte(), photo As Byte())

        Using conn As New SQLiteConnection("Data Source=metrocarddavaodb.db;Version=3;")
            conn.Open()
            Dim sql As String = "INSERT INTO registrations (lastname, firstname, middlename, alternativename, presentaddress, permanentaddress, birthday, birthplace, civilstatus, nationality, email, mobilenumber, employmentstatus, businessname, employername, businessnature, workname, presentedid, polmember, relationshippol, nameemergency, relationshipemergency, contactemergency, idimage, photo) " &
                                "VALUES (@lastname,@firstname,@middlename,@alternativename,@presentaddress,@permanentaddress,@birthday,@birthplace,@civilstatus,@nationality,@email,@mobilenumber,@employmentstatus,@businessname,@employername,@businessnature,@workname,@presentedid,@polmember,@relationshippol,@nameemergency,@relationshipemergency,@contactemergency,@idimage,@photo)"
            Using cmd As New SQLiteCommand(sql, conn)
                cmd.Parameters.AddWithValue("@lastname", lastName)
                cmd.Parameters.AddWithValue("@firstname", firstName)
                cmd.Parameters.AddWithValue("@middlename", middleName)
                cmd.Parameters.AddWithValue("@alternativename", altName)
                cmd.Parameters.AddWithValue("@presentaddress", presentAddr)
                cmd.Parameters.AddWithValue("@permanentaddress", permanentAddr)
                cmd.Parameters.AddWithValue("@birthday", birthday)
                cmd.Parameters.AddWithValue("@birthplace", birthPlace)
                cmd.Parameters.AddWithValue("@civilstatus", civilStatus)
                cmd.Parameters.AddWithValue("@nationality", nationality)
                cmd.Parameters.AddWithValue("@email", email)
                cmd.Parameters.AddWithValue("@mobilenumber", mobile)
                cmd.Parameters.AddWithValue("@employmentstatus", employment)
                cmd.Parameters.AddWithValue("@businessname", businessName)
                cmd.Parameters.AddWithValue("@employername", employerName)
                cmd.Parameters.AddWithValue("@businessnature", businessNature)
                cmd.Parameters.AddWithValue("@workname", workName)
                cmd.Parameters.AddWithValue("@presentedid", presentedID)
                cmd.Parameters.AddWithValue("@polmember", polMember)
                cmd.Parameters.AddWithValue("@relationshippol", relationshipPol)
                cmd.Parameters.AddWithValue("@nameemergency", nameEmergency)
                cmd.Parameters.AddWithValue("@relationshipemergency", relationshipEmergency)
                cmd.Parameters.AddWithValue("@contactemergency", contactEmergency)
                cmd.Parameters.AddWithValue("@idimage", If(idImage IsNot Nothing, idImage, DBNull.Value))
                cmd.Parameters.AddWithValue("@photo", If(photo IsNot Nothing, photo, DBNull.Value))
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Class
