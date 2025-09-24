<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlayerLedger
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges9 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges10 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges11 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges12 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        lblDateToday = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Guna2HtmlLabel2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2HtmlLabel3 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        lblFullname = New Guna.UI2.WinForms.Guna2TextBox()
        dtpTime = New DateTimePicker()
        Guna2HtmlLabel4 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        tbAmount = New Guna.UI2.WinForms.Guna2TextBox()
        Guna2HtmlLabel5 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2HtmlLabel6 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        cbPaymentMode = New Guna.UI2.WinForms.Guna2ComboBox()
        btnSubmit = New Guna.UI2.WinForms.Guna2Button()
        Guna2HtmlLabel7 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        cbTransactionType = New Guna.UI2.WinForms.Guna2ComboBox()
        SuspendLayout()
        ' 
        ' Guna2HtmlLabel1
        ' 
        Guna2HtmlLabel1.BackColor = Color.Transparent
        Guna2HtmlLabel1.Font = New Font("Segoe UI Semibold", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Guna2HtmlLabel1.Location = New Point(12, 12)
        Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Guna2HtmlLabel1.Size = New Size(269, 61)
        Guna2HtmlLabel1.TabIndex = 0
        Guna2HtmlLabel1.Text = "Player Ledger"
        ' 
        ' lblDateToday
        ' 
        lblDateToday.Checked = True
        lblDateToday.CustomizableEdges = CustomizableEdges1
        lblDateToday.Font = New Font("Segoe UI", 9F)
        lblDateToday.Format = DateTimePickerFormat.Long
        lblDateToday.Location = New Point(455, 28)
        lblDateToday.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        lblDateToday.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        lblDateToday.Name = "lblDateToday"
        lblDateToday.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        lblDateToday.Size = New Size(250, 45)
        lblDateToday.TabIndex = 1
        lblDateToday.Value = New Date(2025, 9, 24, 20, 36, 5, 624)
        ' 
        ' Guna2HtmlLabel2
        ' 
        Guna2HtmlLabel2.BackColor = Color.Transparent
        Guna2HtmlLabel2.Location = New Point(12, 79)
        Guna2HtmlLabel2.Name = "Guna2HtmlLabel2"
        Guna2HtmlLabel2.Size = New Size(90, 22)
        Guna2HtmlLabel2.TabIndex = 2
        Guna2HtmlLabel2.Text = "Player Name:"
        ' 
        ' Guna2HtmlLabel3
        ' 
        Guna2HtmlLabel3.BackColor = Color.Transparent
        Guna2HtmlLabel3.Font = New Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Guna2HtmlLabel3.Location = New Point(366, 28)
        Guna2HtmlLabel3.Name = "Guna2HtmlLabel3"
        Guna2HtmlLabel3.Size = New Size(82, 47)
        Guna2HtmlLabel3.TabIndex = 3
        Guna2HtmlLabel3.Text = "Date:"
        ' 
        ' lblFullname
        ' 
        lblFullname.CustomizableEdges = CustomizableEdges3
        lblFullname.DefaultText = ""
        lblFullname.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        lblFullname.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        lblFullname.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        lblFullname.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        lblFullname.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        lblFullname.Font = New Font("Segoe UI", 9F)
        lblFullname.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        lblFullname.Location = New Point(12, 108)
        lblFullname.Margin = New Padding(3, 4, 3, 4)
        lblFullname.Name = "lblFullname"
        lblFullname.PlaceholderText = ""
        lblFullname.SelectedText = ""
        lblFullname.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        lblFullname.Size = New Size(243, 31)
        lblFullname.TabIndex = 4
        ' 
        ' dtpTime
        ' 
        dtpTime.CustomFormat = "HH:mm:ss"
        dtpTime.Location = New Point(12, 168)
        dtpTime.Name = "dtpTime"
        dtpTime.ShowUpDown = True
        dtpTime.Size = New Size(250, 27)
        dtpTime.TabIndex = 5
        ' 
        ' Guna2HtmlLabel4
        ' 
        Guna2HtmlLabel4.BackColor = Color.Transparent
        Guna2HtmlLabel4.Location = New Point(12, 146)
        Guna2HtmlLabel4.Name = "Guna2HtmlLabel4"
        Guna2HtmlLabel4.Size = New Size(39, 22)
        Guna2HtmlLabel4.TabIndex = 6
        Guna2HtmlLabel4.Text = "Time:"
        ' 
        ' tbAmount
        ' 
        tbAmount.CustomizableEdges = CustomizableEdges5
        tbAmount.DefaultText = ""
        tbAmount.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        tbAmount.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        tbAmount.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        tbAmount.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        tbAmount.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        tbAmount.Font = New Font("Segoe UI", 9F)
        tbAmount.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        tbAmount.Location = New Point(343, 146)
        tbAmount.Margin = New Padding(3, 4, 3, 4)
        tbAmount.Name = "tbAmount"
        tbAmount.PlaceholderText = ""
        tbAmount.SelectedText = ""
        tbAmount.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        tbAmount.Size = New Size(230, 30)
        tbAmount.TabIndex = 7
        ' 
        ' Guna2HtmlLabel5
        ' 
        Guna2HtmlLabel5.BackColor = Color.Transparent
        Guna2HtmlLabel5.Location = New Point(343, 117)
        Guna2HtmlLabel5.Name = "Guna2HtmlLabel5"
        Guna2HtmlLabel5.Size = New Size(105, 22)
        Guna2HtmlLabel5.TabIndex = 8
        Guna2HtmlLabel5.Text = "Buy-In Amount:"
        ' 
        ' Guna2HtmlLabel6
        ' 
        Guna2HtmlLabel6.BackColor = Color.Transparent
        Guna2HtmlLabel6.Location = New Point(343, 184)
        Guna2HtmlLabel6.Name = "Guna2HtmlLabel6"
        Guna2HtmlLabel6.Size = New Size(124, 22)
        Guna2HtmlLabel6.TabIndex = 9
        Guna2HtmlLabel6.Text = "Mode of Payment:"
        ' 
        ' cbPaymentMode
        ' 
        cbPaymentMode.BackColor = Color.Transparent
        cbPaymentMode.CustomizableEdges = CustomizableEdges7
        cbPaymentMode.DrawMode = DrawMode.OwnerDrawFixed
        cbPaymentMode.DropDownStyle = ComboBoxStyle.DropDownList
        cbPaymentMode.FocusedColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        cbPaymentMode.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        cbPaymentMode.Font = New Font("Segoe UI", 10F)
        cbPaymentMode.ForeColor = Color.FromArgb(CByte(68), CByte(88), CByte(112))
        cbPaymentMode.ItemHeight = 30
        cbPaymentMode.Location = New Point(343, 212)
        cbPaymentMode.Name = "cbPaymentMode"
        cbPaymentMode.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        cbPaymentMode.Size = New Size(167, 36)
        cbPaymentMode.TabIndex = 10
        ' 
        ' btnSubmit
        ' 
        btnSubmit.CustomizableEdges = CustomizableEdges9
        btnSubmit.DisabledState.BorderColor = Color.DarkGray
        btnSubmit.DisabledState.CustomBorderColor = Color.DarkGray
        btnSubmit.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnSubmit.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnSubmit.Font = New Font("Segoe UI", 9F)
        btnSubmit.ForeColor = Color.White
        btnSubmit.Location = New Point(163, 332)
        btnSubmit.Name = "btnSubmit"
        btnSubmit.ShadowDecoration.CustomizableEdges = CustomizableEdges10
        btnSubmit.Size = New Size(386, 56)
        btnSubmit.TabIndex = 11
        btnSubmit.Text = "Submit"
        ' 
        ' Guna2HtmlLabel7
        ' 
        Guna2HtmlLabel7.BackColor = Color.Transparent
        Guna2HtmlLabel7.Location = New Point(12, 212)
        Guna2HtmlLabel7.Name = "Guna2HtmlLabel7"
        Guna2HtmlLabel7.Size = New Size(118, 22)
        Guna2HtmlLabel7.TabIndex = 12
        Guna2HtmlLabel7.Text = "Transaction Type:"
        ' 
        ' cbTransactionType
        ' 
        cbTransactionType.BackColor = Color.Transparent
        cbTransactionType.CustomizableEdges = CustomizableEdges11
        cbTransactionType.DrawMode = DrawMode.OwnerDrawFixed
        cbTransactionType.DropDownStyle = ComboBoxStyle.DropDownList
        cbTransactionType.FocusedColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        cbTransactionType.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        cbTransactionType.Font = New Font("Segoe UI", 10F)
        cbTransactionType.ForeColor = Color.FromArgb(CByte(68), CByte(88), CByte(112))
        cbTransactionType.ItemHeight = 30
        cbTransactionType.Location = New Point(12, 240)
        cbTransactionType.Name = "cbTransactionType"
        cbTransactionType.ShadowDecoration.CustomizableEdges = CustomizableEdges12
        cbTransactionType.Size = New Size(167, 36)
        cbTransactionType.TabIndex = 13
        ' 
        ' BuyInDialog
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(725, 432)
        Controls.Add(cbTransactionType)
        Controls.Add(Guna2HtmlLabel7)
        Controls.Add(btnSubmit)
        Controls.Add(cbPaymentMode)
        Controls.Add(Guna2HtmlLabel6)
        Controls.Add(Guna2HtmlLabel5)
        Controls.Add(tbAmount)
        Controls.Add(Guna2HtmlLabel4)
        Controls.Add(dtpTime)
        Controls.Add(lblFullname)
        Controls.Add(Guna2HtmlLabel3)
        Controls.Add(Guna2HtmlLabel2)
        Controls.Add(lblDateToday)
        Controls.Add(Guna2HtmlLabel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "BuyInDialog"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form2"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents lblDateToday As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Guna2HtmlLabel2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel3 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents lblFullname As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents dtpTime As DateTimePicker
    Friend WithEvents Guna2HtmlLabel4 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents tbAmount As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel5 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel6 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents cbPaymentMode As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents btnSubmit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2HtmlLabel7 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents cbTransactionType As Guna.UI2.WinForms.Guna2ComboBox
End Class
