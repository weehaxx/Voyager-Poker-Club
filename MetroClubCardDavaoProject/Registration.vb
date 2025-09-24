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
            Not String.IsNullOrWhiteSpace(tbCivilStatus.Text) AndAlso
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
            pbIDpresented.Image IsNot Nothing

        If rbSelfEmployed.Checked Then
            allFieldsFilled = allFieldsFilled AndAlso
                Not String.IsNullOrWhiteSpace(tnBusinessName.Text) AndAlso
                Not String.IsNullOrWhiteSpace(tbBusinessNature.Text)
        ElseIf rbEmployed.Checked Then
            allFieldsFilled = allFieldsFilled AndAlso
                Not String.IsNullOrWhiteSpace(tbEmployerName.Text) AndAlso
                Not String.IsNullOrWhiteSpace(tnWorkName.Text)
        End If

        btnSave.Enabled = allFieldsFilled
    End Sub

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

    ' -------------------- EMPLOYMENT LOGIC --------------------
    Private Sub rbSelfEmployed_CheckedChanged(sender As Object, e As EventArgs) Handles rbSelfEmployed.CheckedChanged
        If rbSelfEmployed.Checked Then
            tnBusinessName.Enabled = True
            tbBusinessNature.Enabled = True
            tbEmployerName.Enabled = False
            tnWorkName.Enabled = False
            tbEmployerName.Clear()
            tnWorkName.Clear()
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
        End If
        ValidateForm()
    End Sub

    ' -------------------- POLITICALLY EXPOSED FAMILY --------------------
    Private Sub tbYes_CheckedChanged(sender As Object, e As EventArgs) Handles tbYes.CheckedChanged
        If tbYes.Checked Then
            tbRelationshipPol.Enabled = True
        End If
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

            Using conn As New SQLiteConnection("Data Source=metrocarddavaodb.db;Version=3;")
                conn.Open()

                ' First INSERT without registration_id
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
                    cmd.Parameters.AddWithValue("@civilstatus", tbCivilStatus.Text)
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
                    cmd.Parameters.AddWithValue("@presentedid", tbPresentedID.Text)
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

                    newId = CLng(cmd.ExecuteScalar()) ' Get auto id
                End Using

                ' Generate registration_id
                Dim regId As String = DateTime.Now.ToString("yyyyMMdd") & newId.ToString("D4")

                ' Update the row with registration_id
                Using updateCmd As New SQLiteCommand("UPDATE registrations SET registration_id=@regid WHERE id=@id", conn)
                    updateCmd.Parameters.AddWithValue("@regid", regId)
                    updateCmd.Parameters.AddWithValue("@id", newId)
                    updateCmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Registration saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' ✅ Clear all fields after saving
            btnClear_Click(Nothing, Nothing)

        Catch ex As Exception
            MessageBox.Show("Error saving data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' -------------------- CLEAR FORM --------------------
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

        tnBusinessName.Enabled = False
        tbBusinessNature.Enabled = False
        tbEmployerName.Enabled = False
        tnWorkName.Enabled = False
    End Sub

    ' -------------------- PHOTO UPLOAD --------------------
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
            MessageBox.Show("Photo captured! Webcam feed is frozen.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
End Class
