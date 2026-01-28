Imports System.Data.SQLite
Imports System.IO
Imports System.Drawing

Public Class EditInfo
    Public Property SelectedMemberID As Integer
    Public Property SelectedFullName As String

    Private isDirty As Boolean = False ' Track changes
    Private ReadOnly dbPath As String = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "voyagerpokerclub",
        "voyagerpokerclub.db"
    )

    ' Image placeholders
    Private frontIDImage As Image = Nothing
    Private backIDImage As Image = Nothing
    Private photoImage As Image = Nothing
    Private signatureImage As Image = Nothing

    Private Sub EditInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Ensure folder exists
            Dim dbFolder As String = Path.GetDirectoryName(dbPath)
            If Not Directory.Exists(dbFolder) Then Directory.CreateDirectory(dbFolder)
            If Not File.Exists(dbPath) Then
                MessageBox.Show("Database file not found at: " & dbPath, "Database Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            cbIDPresented.Items.Clear()
            cbIDPresented.Items.AddRange(New String() {
                "Philippine Passport", "Driver’s License", "SSS ID", "Postal ID",
                "Voter’s ID", "PRC ID", "National ID", "Company ID",
                "Senior Citizen ID", "Other..."
                })
            ' Load member data
            Using conn As New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")
                conn.Open()
                Dim query As String = "SELECT * FROM registrations WHERE id=@id"
                Using cmd As New SQLiteCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", SelectedMemberID)
                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Text fields
                            Dim currentID As String = reader("presentedid").ToString()
                            tbName.Text = reader("name").ToString()
                            dtpBirthday.Text = reader("birthday").ToString()
                            tbBirthPlace.Text = reader("birthplace").ToString()
                            tbPresentAddress.Text = reader("presentaddress").ToString()
                            tbPermanentAddress.Text = reader("permanentaddress").ToString()
                            tbNationality.Text = reader("nationality").ToString()
                            tbMobileNumber.Text = reader("mobilenumber").ToString()
                            tbSourceOfFund.Text = reader("sourceoffund").ToString()
                            tbWorkNature.Text = reader("worknature").ToString()
                            cbIDPresented.Text = reader("presentedid").ToString()
                            If cbIDPresented.Items.Contains(currentID) Then
                                cbIDPresented.SelectedItem = currentID ' highlight existing value
                            Else
                                ' If DB value is custom / not in the list, select Other... but still show text
                                cbIDPresented.SelectedItem = "Other..."
                                cbIDPresented.Text = currentID
                            End If
                            tbIdentificationNumber.Text = reader("identification_number").ToString()

                            ' Images
                            If Not IsDBNull(reader("front_id")) Then
                                Dim bytes = DirectCast(reader("front_id"), Byte())
                                Using ms As New MemoryStream(bytes)
                                    frontIDImage = Image.FromStream(ms)
                                    pbFrontID.Image = frontIDImage
                                    pbFrontID.SizeMode = PictureBoxSizeMode.StretchImage
                                End Using
                            End If

                            If Not IsDBNull(reader("back_id")) Then
                                Dim bytes = DirectCast(reader("back_id"), Byte())
                                Using ms As New MemoryStream(bytes)
                                    backIDImage = Image.FromStream(ms)
                                    pbBackID.Image = backIDImage
                                    pbBackID.SizeMode = PictureBoxSizeMode.StretchImage
                                End Using
                            End If

                            If Not IsDBNull(reader("signature")) Then
                                Dim bytes = DirectCast(reader("signature"), Byte())
                                Using ms As New MemoryStream(bytes)
                                    signatureImage = Image.FromStream(ms)
                                    pbSignaturePreview.Image = signatureImage
                                    pbSignaturePreview.SizeMode = PictureBoxSizeMode.StretchImage
                                End Using
                            End If
                        End If
                    End Using
                End Using
            End Using

            AddHandlerForAllInputs(Me)

        Catch ex As Exception
            MessageBox.Show("Error loading member info: " & ex.Message)
        End Try
    End Sub

    ' Track changes
    Private Sub Control_Changed(sender As Object, e As EventArgs)
        isDirty = True

    End Sub

    Private Sub AddHandlerForAllInputs(ctrl As Control)
        For Each c As Control In ctrl.Controls
            If TypeOf c Is TextBox Then AddHandler DirectCast(c, TextBox).TextChanged, AddressOf Control_Changed
            If TypeOf c Is ComboBox Then AddHandler DirectCast(c, ComboBox).SelectedIndexChanged, AddressOf Control_Changed
            If TypeOf c Is RadioButton Then AddHandler DirectCast(c, RadioButton).CheckedChanged, AddressOf Control_Changed
            If c.HasChildren Then AddHandlerForAllInputs(c)
        Next
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If isDirty AndAlso MessageBox.Show("You have unsaved changes. Cancel anyway?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
            Return
        End If

        CloseEditInfo() ' call your existing helper
    End Sub

    Private Sub CloseEditInfo()
        If TypeOf Me.Parent Is Form Then
            Me.FindForm().Close() ' if hosted directly in a Form
        Else
            Dim parentPanel As Control = Me.Parent
            Me.Parent.Controls.Remove(Me)
            Me.Dispose()
            If TypeOf parentPanel Is Panel Then parentPanel.Visible = False
        End If
    End Sub



    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' ✅ Confirmation before saving
        Dim result As DialogResult = MessageBox.Show(
        "Are you sure you want to save changes?",
        "Confirm Save",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    )

        If result = DialogResult.No Then Exit Sub

        Try
            Using conn As New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")
                conn.Open()

                Dim sql As String = "
                UPDATE registrations SET
                    name=@name, birthday=@birthday, birthplace=@birthplace,
                    presentaddress=@presentaddress, permanentaddress=@permanentaddress,
                    nationality=@nationality, mobilenumber=@mobilenumber,
                    sourceoffund=@sourceoffund, worknature=@worknature,
                    presentedid=@presentedid, identification_number=@identification_number,
                    front_id=@front_id, back_id=@back_id, signature=@signature
                WHERE id=@id"

                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@name", tbName.Text)
                    cmd.Parameters.AddWithValue("@birthday", dtpBirthday.Value.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@birthplace", tbBirthPlace.Text)
                    cmd.Parameters.AddWithValue("@presentaddress", tbPresentAddress.Text)
                    cmd.Parameters.AddWithValue("@permanentaddress", tbPermanentAddress.Text)
                    cmd.Parameters.AddWithValue("@nationality", tbNationality.Text)
                    cmd.Parameters.AddWithValue("@mobilenumber", tbMobileNumber.Text)
                    cmd.Parameters.AddWithValue("@sourceoffund", tbSourceOfFund.Text)
                    cmd.Parameters.AddWithValue("@worknature", tbWorkNature.Text)
                    cmd.Parameters.AddWithValue("@presentedid", cbIDPresented.Text)
                    cmd.Parameters.AddWithValue("@identification_number", tbIdentificationNumber.Text)

                    ' Images
                    cmd.Parameters.AddWithValue("@front_id", ImageToByte(pbFrontID.Image))
                    cmd.Parameters.AddWithValue("@back_id", ImageToByte(pbBackID.Image))
                    cmd.Parameters.AddWithValue("@signature", ImageToByte(pbSignaturePreview.Image))

                    cmd.Parameters.AddWithValue("@id", SelectedMemberID)

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("✅ Member updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            isDirty = False

            ' ✅ Close the UserControl after saving
            CloseEditInfo()

        Catch ex As Exception
            MessageBox.Show("Error saving member info: " & ex.Message)
        End Try
    End Sub


    ' Helper to convert image to byte array
    Private Function ImageToByte(img As Image) As Object
        If img Is Nothing Then Return DBNull.Value
        Using ms As New MemoryStream()
            ' Clone the image to avoid stream-lock issues
            Using clone As Image = New Bitmap(img)
                clone.Save(ms, Imaging.ImageFormat.Jpeg)
            End Using
            Return ms.ToArray()
        End Using
    End Function

    Private Sub btnUploadFrontID_Click(sender As Object, e As EventArgs) Handles btnUploadFrontID.Click
        Using ofd As New OpenFileDialog()
            ofd.Title = "Select an ID Image"
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            If ofd.ShowDialog() = DialogResult.OK Then
                pbFrontID.Image = Image.FromFile(ofd.FileName)
                pbFrontID.SizeMode = PictureBoxSizeMode.StretchImage

            End If
        End Using
    End Sub

    Private Sub btnUploadBackID_Click(sender As Object, e As EventArgs) Handles btnUploadBackID.Click
        Using ofd As New OpenFileDialog()
            ofd.Title = "Select an ID Image"
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            If ofd.ShowDialog() = DialogResult.OK Then
                pbBackID.Image = Image.FromFile(ofd.FileName)
                pbBackID.SizeMode = PictureBoxSizeMode.StretchImage

            End If
        End Using
    End Sub

    Private Sub btnAddSignature_Click(sender As Object, e As EventArgs) Handles btnAddSignature.Click
        Using sigForm As New SignatureForm()
            ' ✅ Pass existing signature from preview (if any)
            If pbSignaturePreview.Image IsNot Nothing Then
                sigForm.ExistingSignature = CType(pbSignaturePreview.Image.Clone(), Image)
            End If

            If sigForm.ShowDialog() = DialogResult.OK Then
                ' Update preview
                pbSignaturePreview.Image = CType(sigForm.SignatureImage.Clone(), Image)
                pbSignaturePreview.SizeMode = PictureBoxSizeMode.StretchImage

                ' ✅ Update the variable that will be saved to DB
                signatureImage = CType(sigForm.SignatureImage.Clone(), Image)
            End If
        End Using
    End Sub
End Class
