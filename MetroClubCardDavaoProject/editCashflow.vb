Imports System.Data.SQLite
Imports System.IO

Public Class editCashflow

    ' 🔑 Cashflow primary key
    Public Property CashflowID As Long

    ' Display-only
    Public Property PlayerID As String
    Public Property FullName As String
    Public Property TimeValue As String
    Public Property BuyIn As String
    Public Property BuyInMode As String
    Public Property CashOut As String
    Public Property CashOutMode As String
    Public Property CreatedBy As String

    Private ReadOnly dbPath As String = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "voyagerpokerclub",
        "voyagerpokerclub.db"
    )

    Private Sub editCashflow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblFullname.Text = FullName

        ' Date
        dtpDate.Format = DateTimePickerFormat.Custom
        dtpDate.CustomFormat = "dddd, MMMM dd, yyyy"

        ' Time
        dtpTime.Format = DateTimePickerFormat.Custom
        dtpTime.CustomFormat = "hh:mm:ss tt"
        dtpTime.ShowUpDown = True

        ' Transaction types
        cbTransactionType.Items.Clear()
        cbTransactionType.Items.AddRange({"Buy-In", "Cash-Out"})

        ' Payment modes
        cbPaymentMode.Items.Clear()
        cbPaymentMode.Items.AddRange({"Cash", "GCash", "Bank Transfer", "Credit Card"})

        LoadCashflowDetails()
    End Sub

    Private Sub LoadCashflowDetails()
        Using conn As New SQLiteConnection($"Data Source={dbPath};Version=3;")
            conn.Open()

            Dim sql As String = "
                SELECT type, amount, payment_mode, date_created, time_created, created_by
                FROM cashflows
                WHERE id = @id
            "

            Using cmd As New SQLiteCommand(sql, conn)
                cmd.Parameters.AddWithValue("@id", CashflowID)

                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        cbTransactionType.Text = reader("type").ToString()
                        tbAmount.Text = reader("amount").ToString()
                        cbPaymentMode.Text = reader("payment_mode").ToString()
                        dtpDate.Value = DateTime.Parse(reader("date_created").ToString())
                        dtpTime.Value = DateTime.Parse(reader("time_created").ToString())
                        tbCashierName.Text = reader("created_by").ToString()
                    End If
                End Using
            End Using
        End Using
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            ' Validation
            If String.IsNullOrWhiteSpace(tbAmount.Text) Then
                MessageBox.Show("Please enter an amount.")
                Return
            End If

            Dim amount As Decimal
            If Not Decimal.TryParse(tbAmount.Text, amount) Then
                MessageBox.Show("Invalid amount.")
                Return
            End If

            Dim confirm = MessageBox.Show(
                "Save changes to this transaction?",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )

            If confirm = DialogResult.No Then Return

            Using conn As New SQLiteConnection($"Data Source={dbPath};Version=3;")
                conn.Open()

                Dim sql As String = "
                    UPDATE cashflows SET
                        type=@type,
                        amount=@amount,
                        payment_mode=@mode,
                        date_created=@date,
                        time_created=@time,
                        created_by=@createdBy
                    WHERE id=@id
                "

                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@type", cbTransactionType.Text)
                    cmd.Parameters.AddWithValue("@amount", amount)
                    cmd.Parameters.AddWithValue("@mode", cbPaymentMode.Text)
                    cmd.Parameters.AddWithValue("@date", dtpDate.Value.ToString("dddd, MMMM dd, yyyy"))
                    cmd.Parameters.AddWithValue("@time", dtpTime.Value.ToString("hh:mm:ss tt"))
                    cmd.Parameters.AddWithValue("@createdBy", tbCashierName.Text.Trim())
                    cmd.Parameters.AddWithValue("@id", CashflowID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Transaction updated successfully!", "Success")
            Dim parentForm As Form = Me.FindForm()
            If parentForm IsNot Nothing Then
                parentForm.DialogResult = DialogResult.OK ' optional
                parentForm.Close()
            End If


        Catch ex As Exception
            MessageBox.Show("Error updating transaction: " & ex.Message)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim parentForm As Form = Me.FindForm()
        If parentForm IsNot Nothing Then
            parentForm.Close()
        End If
    End Sub
End Class

