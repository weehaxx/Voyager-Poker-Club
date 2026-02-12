Imports System.Data.SQLite
Imports System.IO

Module DatabaseModule
    Private appDataPath As String = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "voyagerpokerclub"
    )
    Private dbPath As String = Path.Combine(appDataPath, "voyagerpokerclub.db")
    Private conn As SQLiteConnection

    ' ✅ Initialize and create database if not exists
    Public Sub InitializeDatabase()
        Try
            If Not Directory.Exists(appDataPath) Then
                Directory.CreateDirectory(appDataPath)
            End If

            If Not File.Exists(dbPath) Then
                SQLiteConnection.CreateFile(dbPath)
            End If

            Using conn = New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")
                conn.Open()

                ' Enable WAL
                Using walCmd As New SQLiteCommand("PRAGMA journal_mode = WAL;", conn)
                    walCmd.ExecuteNonQuery()
                End Using

                Using syncCmd As New SQLiteCommand("PRAGMA synchronous = NORMAL;", conn)
                    syncCmd.ExecuteNonQuery()
                End Using

                Using fkCmd As New SQLiteCommand("PRAGMA foreign_keys = ON;", conn)
                    fkCmd.ExecuteNonQuery()
                End Using

                ' ================= USERS TABLE =================
                Dim sql As String =
            "CREATE TABLE IF NOT EXISTS users (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                username TEXT NOT NULL UNIQUE,
                password TEXT NOT NULL
            );"

                Using createCmd As New SQLiteCommand(sql, conn)
                    createCmd.ExecuteNonQuery()
                End Using

                ' Default admin
                sql = "
            INSERT INTO users (username, password)
            SELECT 'VoyagerAdmin', 'Voyager2026'
            WHERE NOT EXISTS (
                SELECT 1 FROM users WHERE username='VoyagerAdmin'
            );"

                Using insertCmd As New SQLiteCommand(sql, conn)
                    insertCmd.ExecuteNonQuery()
                End Using


                ' ================= REGISTRATIONS TABLE =================
                sql =
            "CREATE TABLE IF NOT EXISTS registrations (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                registration_id TEXT,
                name TEXT NOT NULL,
                birthday TEXT,
                birthplace TEXT,
                presentaddress TEXT,
                permanentaddress TEXT,
                nationality TEXT,
                mobilenumber TEXT,
                blinds TEXT,
                sourceoffund TEXT,
                worknature TEXT,
                presentedid TEXT,
                identification_number TEXT,
                front_id BLOB,
                back_id BLOB,
                photo BLOB,
                signature BLOB
            );"

                Using createRegCmd As New SQLiteCommand(sql, conn)
                    createRegCmd.ExecuteNonQuery()
                End Using


                ' ================= CASHFLOWS TABLE =================
                sql =
            "CREATE TABLE IF NOT EXISTS cashflows (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                registration_id INTEGER NOT NULL,
                type TEXT NOT NULL,
                amount DECIMAL(18,2) NOT NULL,
                payment_mode TEXT,
                date_created TEXT,
                time_created TEXT,
                session_date TEXT NOT NULL,
                created_by TEXT,
                created_at TEXT DEFAULT CURRENT_TIMESTAMP,

                FOREIGN KEY (registration_id)
                    REFERENCES registrations(id)
                    ON DELETE CASCADE
            );"

                Using createCashflowCmd As New SQLiteCommand(sql, conn)
                    createCashflowCmd.ExecuteNonQuery()
                End Using

            End Using

        Catch ex As Exception
            MessageBox.Show("Error initializing database: " & ex.Message,
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
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

    ' ✅ Save registration with FRONT ID, BACK ID, PHOTO + auto registration_id
    Public Function SaveRegistration(
       name As String,
        birthday As Date,
        birthplace As String,
        presentAddress As String,
        permanentAddress As String,
        nationality As String,
        mobileNumber As String,
        sourceOfFund As String,
        blinds As String,
        identification_number As String,
        workNature As String,
        presentedId As String,
        frontIdBytes As Byte(),
        backIdBytes As Byte(),
        photoBytes As Byte(),
        signature As Byte()
    ) As String

        Try
            Using conn As New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")
                conn.Open()

                ' ✅ WAL for safety
                Using walCmd As New SQLiteCommand("PRAGMA journal_mode = WAL;", conn)
                    walCmd.ExecuteNonQuery()
                End Using

                Using trans = conn.BeginTransaction()
                    Try
                        ' ✅ INSERT then return new row id
                        Dim sql As String = "
                    INSERT INTO registrations (
    name, birthday, birthplace, presentaddress, permanentaddress,
    nationality, mobilenumber, blinds,sourceoffund, worknature,
    presentedid, identification_number, front_id, back_id, photo, signature
) VALUES (
    @name, @birthday, @birthplace, @presentaddress, @permanentaddress,
    @nationality, @mobilenumber, @sourceoffund, @worknature,
    @presentedid, @identification_number, @front_id, @back_id, @photo, @signature
);

                        SELECT last_insert_rowid();
                    "

                        Dim newId As Long

                        Using cmd As New SQLiteCommand(sql, conn, trans)
                            cmd.Parameters.AddWithValue("@name", name)
                            cmd.Parameters.AddWithValue("@birthday", birthday.ToString("yyyy-MM-dd"))
                            cmd.Parameters.AddWithValue("@birthplace", birthplace)
                            cmd.Parameters.AddWithValue("@presentaddress", presentAddress)
                            cmd.Parameters.AddWithValue("@permanentaddress", permanentAddress)
                            cmd.Parameters.AddWithValue("@nationality", nationality)
                            cmd.Parameters.AddWithValue("@mobilenumber", mobileNumber)
                            cmd.Parameters.AddWithValue("@sourceoffund", sourceOfFund)
                            cmd.Parameters.AddWithValue("@worknature", workNature)
                            cmd.Parameters.AddWithValue("@blinds", blinds)
                            cmd.Parameters.AddWithValue("@presentedid", presentedId)
                            cmd.Parameters.AddWithValue("@identification_number", identification_number)
                            cmd.Parameters.AddWithValue("@front_id", frontIdBytes)
                            cmd.Parameters.AddWithValue("@back_id", backIdBytes)
                            cmd.Parameters.AddWithValue("@photo", photoBytes)
                            cmd.Parameters.Add("@signature", System.Data.DbType.Binary).Value =
                                If(signature IsNot Nothing, signature, DBNull.Value)
                            newId = CLng(cmd.ExecuteScalar())
                        End Using

                        ' ✅ Generate registration_id then update
                        Dim regId As String = DateTime.Now.ToString("yyyyMMdd") & newId.ToString()

                        Using updateCmd As New SQLiteCommand("UPDATE registrations SET registration_id=@r WHERE id=@i", conn, trans)
                            updateCmd.Parameters.AddWithValue("@r", regId)
                            updateCmd.Parameters.AddWithValue("@i", newId)
                            updateCmd.ExecuteNonQuery()
                        End Using

                        trans.Commit()

                        ' ✅ return generated registration id
                        Return regId

                    Catch ex As Exception
                        trans.Rollback()
                        Throw
                    End Try
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error saving registration: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
        End Try
    End Function

End Module
