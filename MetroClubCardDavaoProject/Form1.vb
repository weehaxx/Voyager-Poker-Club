Imports System.Data.SQLite   ' ✅ Use SQLite instead of MySQL

Public Class Form1
    Dim conn As SQLiteConnection
    Dim cmd As SQLiteCommand
    Dim reader As SQLiteDataReader

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ✅ Use the SQLite database file you created in SQLiteStudio
        Dim dbPath As String = "metrocarddavaodb.db"

        ' 🔹 If database file doesn’t exist, create it + users table
        If Not IO.File.Exists(dbPath) Then
            SQLiteConnection.CreateFile(dbPath)
            Using conn = New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")
                conn.Open()
                Dim sql As String =
                    "CREATE TABLE users (" &
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, " &
                    "username TEXT NOT NULL, " &
                    "password TEXT NOT NULL)"
                Dim createCmd As New SQLiteCommand(sql, conn)
                createCmd.ExecuteNonQuery()

                ' 🔹 Add a sample user
                sql = "INSERT INTO users (username, password) VALUES ('testuser', '12345')"
                createCmd = New SQLiteCommand(sql, conn)
                createCmd.ExecuteNonQuery()
            End Using
        End If

        conn = New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            ' 🔹 First, check static admin credentials
            If tbUsername.Text = "metrocarddavaoadmin" AndAlso tbPassword.Text = "metrocarddavao12345" Then
                MessageBox.Show("Admin Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim f2 As New Form2()
                f2.Show()
                Me.Hide()
                Exit Sub
            End If

            ' 🔹 If not static admin, check SQLite database
            conn.Open()
            Dim query As String = "SELECT * FROM users WHERE username=@uname AND password=@pword"
            cmd = New SQLiteCommand(query, conn)
            cmd.Parameters.AddWithValue("@uname", tbUsername.Text)
            cmd.Parameters.AddWithValue("@pword", tbPassword.Text)

            reader = cmd.ExecuteReader()

            If reader.HasRows Then
                MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim f2 As New Form2()
                Main.Show()
                Me.Hide()
            Else
                MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            reader.Close()
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

    End Sub
End Class

