Imports System.Data.SQLite

Public Class PlayerLedger
    Public Property RegistrationID As Long ' actual integer primary key from registrations.id
    Public Property FullName As String

    Private Sub PlayerLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblFullname.Text = FullName
        lblDateToday.Text = DateTime.Now.ToString("yyyy-MM-dd")

        ' ✅ Setup DateTimePicker for time selection
        dtpTime.Format = DateTimePickerFormat.Custom
        dtpTime.CustomFormat = "hh:mm:ss tt"  ' 12-hour format + AM/PM
        dtpTime.ShowUpDown = True
        dtpTime.Value = DateTime.Now

        cbTransactionType.Items.Clear()
        cbTransactionType.Items.AddRange({"Buy-In", "Cash-Out"})
        cbTransactionType.SelectedIndex = 0

        cbPaymentMode.Items.Clear()
        cbPaymentMode.Items.AddRange({"Cash", "GCash", "Bank Transfer", "Credit Card"})
        cbPaymentMode.SelectedIndex = 0
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            If cbTransactionType.SelectedItem Is Nothing Then
                MessageBox.Show("Please select a transaction type.")
                Return
            End If

            If String.IsNullOrWhiteSpace(tbAmount.Text) Then
                MessageBox.Show("Please enter an amount.")
                Return
            End If

            Dim transactionType = cbTransactionType.SelectedItem.ToString
            Dim amount As Decimal

            If Not Decimal.TryParse(tbAmount.Text, amount) Then
                MessageBox.Show("Invalid amount entered.")
                Return
            End If

            Dim dbPath = "metrocarddavaodb.db"
            Using conn As New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")
                conn.Open()

                '' ✅ Save unified record
                'Dim sql As String = "INSERT INTO cashflows (registration_id, type, amount, payment_mode, date_today, time_today) 
                '                     VALUES (@regid, @type, @amount, @mode, @date, @time)"

                ' Insert into cashflows; registration_id is the physical integer id (FK)
                Dim sql As String = "INSERT INTO cashflows (registration_id, type, amount, payment_mode, date_today, time_today) VALUES (@regid, @type, @amount, @mode, @date, @time)"
                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@regid", RegistrationID)
                    cmd.Parameters.AddWithValue("@type", transactionType)
                    cmd.Parameters.AddWithValue("@amount", amount)
                    cmd.Parameters.AddWithValue("@mode", cbPaymentMode.Text)
                    cmd.Parameters.AddWithValue("@date", lblDateToday.Text)
                    cmd.Parameters.AddWithValue("@time", dtpTime.Value.ToString("hh:mm:ss tt"))
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show(transactionType & " saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error saving transaction: " & ex.Message)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel ' ✅ Notify parent that user canceled
        Me.Close() ' ✅ Close the dialog
    End Sub

End Class
