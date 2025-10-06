Imports System.Data.SQLite
Imports System.IO
Imports AForge.Video
Imports AForge.Video.DirectShow

Public Class Registration
    Dim conn As SQLiteConnection
    Dim cmd As SQLiteCommand

    ' Webcam variables
    Private videoDevices As FilterInfoCollection
    Private videoSource As VideoCaptureDevice
    Private isCaptured As Boolean = False ' ✅ track if capture was pressed

    Private Sub Registration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dbPath As String = "metrocarddavaodb.db"
        conn = New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")
        tbRelationshipPol.Enabled = False
        btnSave.Enabled = False ' Start disabled

        ' Disable job fields initially
        tnBusinessName.Enabled = False
        tbBusinessNature.Enabled = False
        tbEmployerName.Enabled = False
        tnWorkName.Enabled = False

        ' Load webcams into ComboBox
        Try
            videoDevices = New FilterInfoCollection(FilterCategory.VideoInputDevice)
            cbCamera.Items.Clear()
            For Each cam As FilterInfo In videoDevices
                cbCamera.Items.Add(cam.Name)
            Next
            If cbCamera.Items.Count > 0 Then
                cbCamera.SelectedIndex = 0
            Else
                cbCamera.Items.Add("No Camera Found")
                cbCamera.SelectedIndex = 0
                btnWebcam.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading cameras: " & ex.Message)
        End Try

        ' Load ID options into ComboBox
        cbIDPresented.Items.Clear()
        cbIDPresented.Items.AddRange(New String() {
            "Philippine Passport",
            "Driver’s License",
            "SSS ID",
            "Postal ID",
            "Voter’s ID",
            "PRC ID",
            "National ID",
            "Company ID",
            "Senior Citizen ID"
        })
        cbIDPresented.SelectedIndex = -1 ' none selected

        cbCivilStatus.Items.Clear()
        cbCivilStatus.Items.AddRange(New String() {
            "Single",
            "Married",
            "Widowed",
            "Divorced",
            "Separated",
            "Annulled"
        })
        cbCivilStatus.SelectedIndex = -1 ' none selected

    End Sub

    ' -------------------- VALIDATION --------------------
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
            Not String.IsNullOrWhiteSpace(cbCivilStatus.Text) AndAlso
            Not String.IsNullOrWhiteSpace(tbNationality.Text) AndAlso
            Not String.IsNullOrWhiteSpace(tbEmail.Text) AndAlso
            mobileValid AndAlso
            (rbSelfEmployed.Checked OrElse rbEmployed.Checked) AndAlso
            (tbYes.Checked OrElse tbNo.Checked) AndAlso
            (tbYes.Checked = False OrElse Not String.IsNullOrWhiteSpace(tbRelationshipPol.Text)) AndAlso
            Not String.IsNullOrWhiteSpace(tbNameEmergency.Text) AndAlso
            Not String.IsNullOrWhiteSpace(tbRelationShipEmergency.Text) AndAlso
            contactValid AndAlso
            pbCameraDisplay.Image IsNot Nothing AndAlso
            pbIDpresented.Image IsNot Nothing AndAlso
            cbIDPresented.SelectedIndex <> -1

        If rbSelfEmployed.Checked Then
            allFieldsFilled = allFieldsFilled AndAlso
                Not String.IsNullOrWhiteSpace(tnBusinessName.Text) AndAlso
                Not String.IsNullOrWhiteSpace(tbBusinessNature.Text)
        ElseIf rbEmployed.Checked Then
            allFieldsFilled = allFieldsFilled AndAlso
                Not String.IsNullOrWhiteSpace(tbEmployerName.Text) AndAlso
                Not String.IsNullOrWhiteSpace(tnWorkName.Text)
        End If

        If tbMobileNumber.Text.Length <> 11 Then allFieldsFilled = False
        If tbContactEmergency.Text.Length <> 11 Then allFieldsFilled = False

        btnSave.Enabled = allFieldsFilled
    End Sub

    Private Sub AnyFieldChanged(sender As Object, e As EventArgs) _
        Handles tbLastName.TextChanged, tbFirstName.TextChanged, tbMiddleName.TextChanged, tbAlternativeName.TextChanged, tbPresentAddress.TextChanged, tbPermanentAddress.TextChanged, tbBirthPlace.TextChanged, tbNationality.TextChanged, tbEmail.TextChanged, tbMobileNumber.TextChanged, tnBusinessName.TextChanged, tbEmployerName.TextChanged, tbBusinessNature.TextChanged, tnWorkName.TextChanged, tbRelationshipPol.TextChanged, tbNameEmergency.TextChanged, tbRelationShipEmergency.TextChanged, tbContactEmergency.TextChanged, rbSelfEmployed.CheckedChanged, rbEmployed.CheckedChanged, tbYes.CheckedChanged, tbNo.CheckedChanged, cbIDPresented.SelectedIndexChanged

        ValidateForm()
    End Sub

    ' -------------------- EMPLOYMENT LOGIC --------------------
    Private Sub rbSelfEmployed_CheckedChanged(sender As Object, e As EventArgs) Handles rbSelfEmployed.CheckedChanged
        If rbSelfEmployed.Checked Then
            tnBusinessName.Enabled = True
            tbBusinessNature.Enabled = True
            tbEmployerName.Enabled = False
            tnWorkName.Enabled = False
            tbEmployerName.Clear()
            tnWorkName.Clear()
        Else
            tnBusinessName.Clear()
            tbBusinessNature.Clear()
            tnBusinessName.Enabled = False
            tbBusinessNature.Enabled = False
        End If
        ValidateForm()
    End Sub

    Private Sub rbEmployed_CheckedChanged(sender As Object, e As EventArgs) Handles rbEmployed.CheckedChanged
        If rbEmployed.Checked Then
            tbEmployerName.Enabled = True
            tnWorkName.Enabled = True
            tnBusinessName.Enabled = False
            tbBusinessNature.Enabled = False
            tnBusinessName.Clear()
            tbBusinessNature.Clear()
        Else
            tbEmployerName.Clear()
            tnWorkName.Clear()
            tbEmployerName.Enabled = False
            tnWorkName.Enabled = False
        End If
        ValidateForm()
    End Sub

    ' -------------------- POLITICALLY EXPOSED FAMILY --------------------
    Private Sub tbYes_CheckedChanged(sender As Object, e As EventArgs) Handles tbYes.CheckedChanged
        If tbYes.Checked Then tbRelationshipPol.Enabled = True
        ValidateForm()
    End Sub

    Private Sub tbNo_CheckedChanged(sender As Object, e As EventArgs) Handles tbNo.CheckedChanged
        If tbNo.Checked Then
            tbRelationshipPol.Enabled = False
            tbRelationshipPol.Clear()
        End If
        ValidateForm()
    End Sub

    ' -------------------- SAVE --------------------
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim newId As Long
            Dim regId As String = ""
            Dim fullName As String = ""

            Using conn As New SQLiteConnection("Data Source=metrocarddavaodb.db;Version=3;")
                conn.Open()

                Dim query As String =
                    "INSERT INTO registrations " &
                    "(lastname, firstname, middlename, alternativename, presentaddress, permanentaddress, birthday, birthplace, civilstatus, nationality, email, mobilenumber, employmentstatus, businessname, employername, businessnature, workname, presentedid, polmember, relationshippol, nameemergency, relationshipemergency, contactemergency, idimage, photo) " &
                    "VALUES (@lastname, @firstname, @middlename, @alternativename, @presentaddress, @permanentaddress, @birthday, @birthplace, @civilstatus, @nationality, @email, @mobilenumber, @employmentstatus, @businessname, @employername, @businessnature, @workname, @presentedid, @polmember, @relationshippol, @nameemergency, @relationshipemergency, @contactemergency, @idimage, @photo); " &
                    "SELECT last_insert_rowid();"

                Using cmd As New SQLiteCommand(query, conn)
                    ' Text fields
                    cmd.Parameters.AddWithValue("@lastname", tbLastName.Text)
                    cmd.Parameters.AddWithValue("@firstname", tbFirstName.Text)
                    cmd.Parameters.AddWithValue("@middlename", tbMiddleName.Text)
                    cmd.Parameters.AddWithValue("@alternativename", tbAlternativeName.Text)
                    cmd.Parameters.AddWithValue("@presentaddress", tbPresentAddress.Text)
                    cmd.Parameters.AddWithValue("@permanentaddress", tbPermanentAddress.Text)
                    cmd.Parameters.AddWithValue("@birthday", dtpBirthday.Value.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@birthplace", tbBirthPlace.Text)
                    cmd.Parameters.AddWithValue("@civilstatus", cbCivilStatus.Text)
                    cmd.Parameters.AddWithValue("@nationality", tbNationality.Text)
                    cmd.Parameters.AddWithValue("@email", tbEmail.Text)
                    cmd.Parameters.AddWithValue("@mobilenumber", tbMobileNumber.Text)

                    ' Employment
                    If rbSelfEmployed.Checked Then
                        cmd.Parameters.AddWithValue("@employmentstatus", "Self-Employed")
                    ElseIf rbEmployed.Checked Then
                        cmd.Parameters.AddWithValue("@employmentstatus", "Employed")
                    Else
                        cmd.Parameters.AddWithValue("@employmentstatus", "")
                    End If
                    cmd.Parameters.AddWithValue("@businessname", tnBusinessName.Text)
                    cmd.Parameters.AddWithValue("@employername", tbEmployerName.Text)
                    cmd.Parameters.AddWithValue("@businessnature", tbBusinessNature.Text)
                    cmd.Parameters.AddWithValue("@workname", tnWorkName.Text)

                    ' ID & Police
                    cmd.Parameters.AddWithValue("@presentedid", cbIDPresented.Text)
                    cmd.Parameters.AddWithValue("@polmember", If(tbYes.Checked, "Yes", "No"))
                    cmd.Parameters.AddWithValue("@relationshippol", tbRelationshipPol.Text)

                    ' Emergency
                    cmd.Parameters.AddWithValue("@nameemergency", tbNameEmergency.Text)
                    cmd.Parameters.AddWithValue("@relationshipemergency", tbRelationShipEmergency.Text)
                    cmd.Parameters.AddWithValue("@contactemergency", tbContactEmergency.Text)

                    ' Images
                    Dim idImageBytes() As Byte = Nothing
                    If pbIDpresented.Image IsNot Nothing Then
                        Using ms As New MemoryStream()
                            pbIDpresented.Image.Save(ms, Imaging.ImageFormat.Jpeg)
                            idImageBytes = ms.ToArray()
                        End Using
                    End If
                    cmd.Parameters.AddWithValue("@idimage", idImageBytes)

                    Dim photoBytes() As Byte = Nothing
                    If pbCameraDisplay.Image IsNot Nothing Then
                        Using ms As New MemoryStream()
                            pbCameraDisplay.Image.Save(ms, Imaging.ImageFormat.Jpeg)
                            photoBytes = ms.ToArray()
                        End Using
                    End If
                    cmd.Parameters.AddWithValue("@photo", photoBytes)

                    newId = CLng(cmd.ExecuteScalar())
                End Using

                regId = DateTime.Now.ToString("yyyyMMdd") & newId.ToString()

                Using updateCmd As New SQLiteCommand("UPDATE registrations SET registration_id=@regid WHERE id=@id", conn)
                    updateCmd.Parameters.AddWithValue("@regid", regId)
                    updateCmd.Parameters.AddWithValue("@id", newId)
                    updateCmd.ExecuteNonQuery()
                End Using

                fullName = tbLastName.Text & ", " & tbFirstName.Text & " " & tbMiddleName.Text
            End Using

            MessageBox.Show("NEW MEMBER REGISTERED!" & vbCrLf &
                            "REGISTRATION ID: " & regId & vbCrLf &
                            "FULL NAME: " & fullName.ToUpper(),
                            "REGISTRATION SUCCESSFUL",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)

            btnClear_Click(Nothing, Nothing)

        Catch ex As Exception
            MessageBox.Show("Error saving data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ' ✅ Clear all textboxes
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                DirectCast(ctrl, TextBox).Clear()
            End If
        Next

        ' ✅ Reset combo boxes
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is ComboBox Then
                DirectCast(ctrl, ComboBox).SelectedIndex = -1
            End If
        Next

        ' ✅ Clear image preview (if you have a PictureBox for photo)
        If pbCameraDisplay IsNot Nothing Then
            pbCameraDisplay = Nothing
        End If
    End Sub
    Private Sub btnAddPhoto_Click(sender As Object, e As EventArgs) Handles btnAddPhoto.Click
        Using ofd As New OpenFileDialog
            ofd.Title = "Select a Photo"
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            If ofd.ShowDialog = DialogResult.OK Then
                pbCameraDisplay.Image = Image.FromFile(ofd.FileName)
                pbCameraDisplay.SizeMode = PictureBoxSizeMode.StretchImage
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

    ' -------------------- WEBCAM --------------------
    Private Sub StartWebcam()
        Try
            If cbCamera.SelectedIndex < 0 OrElse videoDevices.Count = 0 Then
                MessageBox.Show("No webcam selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            videoSource = New VideoCaptureDevice(videoDevices(cbCamera.SelectedIndex).MonikerString)
            AddHandler videoSource.NewFrame, AddressOf VideoSource_NewFrame
            videoSource.Start()
            isCaptured = False
        Catch ex As Exception
            MessageBox.Show("Error starting webcam: " & ex.Message)
        End Try
    End Sub

    Private Sub StopWebcam()
        Try
            If videoSource IsNot Nothing AndAlso videoSource.IsRunning Then
                RemoveHandler videoSource.NewFrame, AddressOf VideoSource_NewFrame
                videoSource.SignalToStop()
                videoSource.WaitForStop()
                videoSource = Nothing
            End If
        Catch
        End Try
    End Sub

    Private Sub VideoSource_NewFrame(sender As Object, eventArgs As NewFrameEventArgs)
        If isCaptured Then Return
        Dim bmp As Bitmap = CType(eventArgs.Frame.Clone(), Bitmap)
        If pbCameraDisplay.InvokeRequired Then
            pbCameraDisplay.BeginInvoke(New MethodInvoker(Sub()
                                                              If pbCameraDisplay.Image IsNot Nothing Then
                                                                  pbCameraDisplay.Image.Dispose()
                                                              End If
                                                              pbCameraDisplay.Image = bmp
                                                              pbCameraDisplay.SizeMode = PictureBoxSizeMode.StretchImage
                                                          End Sub))
        Else
            If pbCameraDisplay.Image IsNot Nothing Then
                pbCameraDisplay.Image.Dispose()
            End If
            pbCameraDisplay.Image = bmp
            pbCameraDisplay.SizeMode = PictureBoxSizeMode.StretchImage
        End If
    End Sub

    Private Sub btnCapture_Click(sender As Object, e As EventArgs) Handles btnCapture.Click
        If pbCameraDisplay.Image IsNot Nothing Then
            isCaptured = True
            MessageBox.Show("Photo captured!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ValidateForm()
        End If
    End Sub

    Private Sub btnWebcam_Click(sender As Object, e As EventArgs) Handles btnWebcam.Click
        If videoSource Is Nothing OrElse Not videoSource.IsRunning Then
            StartWebcam()
            btnWebcam.Text = "STOP WEBCAM"
        Else
            StopWebcam()
            btnWebcam.Text = "USE WEBCAM"
        End If
    End Sub

    Private Sub Registration_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Not Me.Visible Then
            StopWebcam()
        End If
    End Sub

    Private Sub cbCamera_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCamera.SelectedIndexChanged
        If videoSource IsNot Nothing AndAlso videoSource.IsRunning Then
            StopWebcam()
            StartWebcam()
        End If
    End Sub

    Private Sub cbCivilStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCivilStatus.SelectedIndexChanged

    End Sub

    Private Sub tbMobileNumber_TextChanged(sender As Object, e As EventArgs) Handles tbMobileNumber.TextChanged
        If tbMobileNumber.Text.Length > 11 Then
            tbMobileNumber.Text = tbMobileNumber.Text.Substring(0, 11)
            tbMobileNumber.SelectionStart = tbMobileNumber.Text.Length
        End If
    End Sub

    Private Sub tbContactEmergency_TextChanged(sender As Object, e As EventArgs) Handles tbContactEmergency.TextChanged
        If tbContactEmergency.Text.Length > 11 Then
            tbContactEmergency.Text = tbContactEmergency.Text.Substring(0, 11)
            tbContactEmergency.SelectionStart = tbContactEmergency.Text.Length
        End If
    End Sub
End Class
