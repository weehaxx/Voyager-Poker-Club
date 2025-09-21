Imports System.Data.SQLite

Module DatabaseModule
    Private dbPath As String = "metrocarddavaodb.db"
    Private conn As SQLiteConnection

    Public Sub InitializeDatabase()
        If Not IO.File.Exists(dbPath) Then
            SQLiteConnection.CreateFile(dbPath)
            Using conn = New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")
                conn.Open()
                Dim sql As String =
                    "CREATE TABLE users (" &
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, " &
                    "username TEXT NOT NULL, " &
                    "password TEXT NOT NULL)"
                Using createCmd As New SQLiteCommand(sql, conn)
                    createCmd.ExecuteNonQuery()
                End Using

                sql = "INSERT INTO users (username, password) VALUES ('testuser', '12345')"
                Using createCmd As New SQLiteCommand(sql, conn)
                    createCmd.ExecuteNonQuery()
                End Using
            End Using
        End If
    End Sub

    Public Function GetConnection() As SQLiteConnection
        If conn Is Nothing Then
            conn = New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")
        End If
        Return conn
    End Function

    Public Function ValidateUser(username As String, password As String) As Boolean
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
    End Function

    Public Sub SaveRegistration(
        lastName As String, firstName As String, middleName As String, alternativeName As String,
        presentAddress As String, permanentAddress As String, birthday As Date, birthPlace As String,
        civilStatus As String, nationality As String, email As String, mobileNumber As String,
        employmentStatus As String, businessName As String, employerName As String, businessNature As String,
        workName As String, presentedId As String, polMember As String, relationshipPol As String,
        nameEmergency As String, relationshipEmergency As String, contactEmergency As String
    )
        Using conn As New SQLiteConnection("Data Source=metrocarddavaodb.db;Version=3;")
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
    End Sub
End Module
