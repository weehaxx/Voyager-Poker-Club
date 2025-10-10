Imports System.Data.SQLite
Imports System.IO

Module DatabaseModule
    Private appDataPath As String = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "MetroCardClubDavao"
    )
    Private dbPath As String = Path.Combine(appDataPath, "metrocarddavaodb.db")
    Private conn As SQLiteConnection

    ' ✅ Initialize and create database if not exists
    Public Sub InitializeDatabase()
        Try
            ' Ensure AppData folder exists
            If Not Directory.Exists(appDataPath) Then
                Directory.CreateDirectory(appDataPath)
            End If

            ' Create the database file if it doesn't exist
            If Not File.Exists(dbPath) Then
                SQLiteConnection.CreateFile(dbPath)
            End If

            ' Open connection
            Using conn = New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")
                conn.Open()

                ' ✅ Enable Write-Ahead Logging (WAL) globally
                Using walCmd As New SQLiteCommand("PRAGMA journal_mode = WAL;", conn)
                    walCmd.ExecuteNonQuery()
                End Using

                ' ✅ Optional: improve speed for local app usage
                Using syncCmd As New SQLiteCommand("PRAGMA synchronous = NORMAL;", conn)
                    syncCmd.ExecuteNonQuery()
                End Using

                ' ✅ Optional: reduce locking issues
                Using cacheCmd As New SQLiteCommand("PRAGMA temp_store = MEMORY;", conn)
                    cacheCmd.ExecuteNonQuery()
                End Using

                ' ✅ Create USERS table if it doesn't exist
                Dim sql As String =
                "CREATE TABLE IF NOT EXISTS users (" &
                "id INTEGER PRIMARY KEY AUTOINCREMENT, " &
                "username TEXT NOT NULL, " &
                "password TEXT NOT NULL)"
                Using createCmd As New SQLiteCommand(sql, conn)
                    createCmd.ExecuteNonQuery()
                End Using

                ' ✅ Insert default test user (only if not already existing)
                sql = "INSERT INTO users (username, password) " &
                  "SELECT 'testuser', '12345' WHERE NOT EXISTS (SELECT 1 FROM users WHERE username='testuser')"
                Using insertCmd As New SQLiteCommand(sql, conn)
                    insertCmd.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error initializing database: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' ✅ Centralized SQLite connection (lazy-loaded)
    Public Function GetConnection() As SQLiteConnection
        If conn Is Nothing Then
            conn = New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")
        End If
        Return conn
    End Function

    ' ✅ Validate login credentials
    Public Function ValidateUser(username As String, password As String) As Boolean
        Try
            Using connection = New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")
                connection.Open()
                Dim query As String = "SELECT 1 FROM users WHERE username=@uname AND password=@pword"
                Using cmd As New SQLiteCommand(query, connection)
                    cmd.Parameters.AddWithValue("@uname", username)
                    cmd.Parameters.AddWithValue("@pword", password)
                    Using reader = cmd.ExecuteReader()
                        Return reader.HasRows
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error validating user: " & ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' ✅ Safe save for registration data
    Public Sub SaveRegistration(
        lastName As String, firstName As String, middleName As String, alternativeName As String,
        presentAddress As String, permanentAddress As String, birthday As Date, birthPlace As String,
        civilStatus As String, nationality As String, email As String, mobileNumber As String,
        employmentStatus As String, businessName As String, employerName As String, businessNature As String,
        workName As String, presentedId As String, polMember As String, relationshipPol As String,
        nameEmergency As String, relationshipEmergency As String, contactEmergency As String
    )
        Try
            ' Use centralized db path
            Using conn As New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")
                conn.Open()

                Dim sql As String =
                    "INSERT INTO registrations " &
                    "(lastname, firstname, middlename, alternativename, presentaddress, permanentaddress, birthday, birthplace, civilstatus, nationality, email, mobilenumber, employmentstatus, businessname, employername, businessnature, workname, presentedid, polmember, relationshippol, nameemergency, relationshipemergency, contactemergency) " &
                    "VALUES (@lastname, @firstname, @middlename, @alternativename, @presentaddress, @permanentaddress, @birthday, @birthplace, @civilstatus, @nationality, @email, @mobilenumber, @employmentstatus, @businessname, @employername, @businessnature, @workname, @presentedid, @polmember, @relationshippol, @nameemergency, @relationshipemergency, @contactemergency)"

                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@lastname", lastName)
                    cmd.Parameters.AddWithValue("@firstname", firstName)
                    cmd.Parameters.AddWithValue("@middlename", middleName)
                    cmd.Parameters.AddWithValue("@alternativename", alternativeName)
                    cmd.Parameters.AddWithValue("@presentaddress", presentAddress)
                    cmd.Parameters.AddWithValue("@permanentaddress", permanentAddress)
                    cmd.Parameters.AddWithValue("@birthday", birthday.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@birthplace", birthPlace)
                    cmd.Parameters.AddWithValue("@civilstatus", civilStatus)
                    cmd.Parameters.AddWithValue("@nationality", nationality)
                    cmd.Parameters.AddWithValue("@email", email)
                    cmd.Parameters.AddWithValue("@mobilenumber", mobileNumber)
                    cmd.Parameters.AddWithValue("@employmentstatus", employmentStatus)
                    cmd.Parameters.AddWithValue("@businessname", businessName)
                    cmd.Parameters.AddWithValue("@employername", employerName)
                    cmd.Parameters.AddWithValue("@businessnature", businessNature)
                    cmd.Parameters.AddWithValue("@workname", workName)
                    cmd.Parameters.AddWithValue("@presentedid", presentedId)
                    cmd.Parameters.AddWithValue("@polmember", polMember)
                    cmd.Parameters.AddWithValue("@relationshippol", relationshipPol)
                    cmd.Parameters.AddWithValue("@nameemergency", nameEmergency)
                    cmd.Parameters.AddWithValue("@relationshipemergency", relationshipEmergency)
                    cmd.Parameters.AddWithValue("@contactemergency", contactEmergency)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error saving registration: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Module
