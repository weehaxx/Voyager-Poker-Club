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


End Class

