Imports System.Data.SQLite

Public Class PlayerLedger
    Public Property RegistrationID As Integer
    Public Property FullName As String

    Private Sub BuyInDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ✅ Player info
        lblFullname.Text = FullName
        lblDateToday.Text = DateTime.Now.ToString("yyyy-MM-dd") ' Always today's date

        ' ✅ Setup DateTimePicker for time selection
        dtpTime.Format = DateTimePickerFormat.Custom
        dtpTime.CustomFormat = "HH:mm:ss"
        dtpTime.ShowUpDown = True
        dtpTime.Value = DateTime.Now ' default to current time

        ' ✅ Transaction Type dropdown
        cbTransactionType.Items.Clear()
        cbTransactionType.Items.AddRange({"Buy-In", "Cash-Out"})
        cbTransactionType.SelectedIndex = 0

        ' ✅ Payment Mode dropdown
        cbPaymentMode.Items.Clear()
        cbPaymentMode.Items.AddRange({"Cash", "GCash", "Bank Transfer", "Credit Card"})
        cbPaymentMode.SelectedIndex = 0
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            ' Validation
            If cbTransactionType.SelectedItem Is Nothing Then
                MessageBox.Show("Please select a transaction type.")
                Return
            End If

            If String.IsNullOrWhiteSpace(tbAmount.Text) Then
                MessageBox.Show("Please enter an amount.")
                Return
            End If

            Dim transactionType As String = cbTransactionType.SelectedItem.ToString()
            Dim amount As Decimal = Decimal.Parse(tbAmount.Text)

            Dim dbPath As String = "metrocarddavaodb.db"
            Using conn As New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")
                conn.Open()

                ' ✅ Save unified record
                Dim sql As String = "INSERT INTO cashflows (registration_id, type, amount, payment_mode, date_today, time_today) 
                                     VALUES (@regid, @type, @amount, @mode, @date, @time)"

                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@regid", RegistrationID)
                    cmd.Parameters.AddWithValue("@type", transactionType) ' BuyIn or CashOut
                    cmd.Parameters.AddWithValue("@amount", amount)
                    cmd.Parameters.AddWithValue("@mode", cbPaymentMode.Text)
                    cmd.Parameters.AddWithValue("@date", lblDateToday.Text) ' always today's date
                    cmd.Parameters.AddWithValue("@time", dtpTime.Value.ToString("HH:mm:ss")) ' chosen time
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
End Class
