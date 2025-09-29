<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ledger
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2HtmlLabel2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2HtmlLabel3 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        tbMemeberID = New Guna.UI2.WinForms.Guna2TextBox()
        tbPlayerName = New Guna.UI2.WinForms.Guna2TextBox()
        dgvLedger = New Guna.UI2.WinForms.Guna2DataGridView()
        btnBack = New Guna.UI2.WinForms.Guna2Button()
        btnLedgerPrint = New Guna.UI2.WinForms.Guna2Button()
        CType(dgvLedger, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Guna2HtmlLabel1
        ' 
        Guna2HtmlLabel1.BackColor = Color.Transparent
        Guna2HtmlLabel1.Font = New Font("Arial Rounded MT Bold", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Guna2HtmlLabel1.Location = New Point(25, 17)
        Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Guna2HtmlLabel1.Size = New Size(459, 40)
        Guna2HtmlLabel1.TabIndex = 1
        Guna2HtmlLabel1.Text = "PLAYER ACCOUNT LEDGER"
        ' 
        ' Guna2HtmlLabel2
        ' 
        Guna2HtmlLabel2.BackColor = Color.Transparent
        Guna2HtmlLabel2.Font = New Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Guna2HtmlLabel2.ForeColor = Color.Black
        Guna2HtmlLabel2.Location = New Point(27, 110)
        Guna2HtmlLabel2.Margin = New Padding(3, 4, 3, 4)
        Guna2HtmlLabel2.Name = "Guna2HtmlLabel2"
        Guna2HtmlLabel2.Size = New Size(152, 29)
        Guna2HtmlLabel2.TabIndex = 76
        Guna2HtmlLabel2.Text = "Player Name: "
        ' 
        ' Guna2HtmlLabel3
        ' 
        Guna2HtmlLabel3.BackColor = Color.Transparent
        Guna2HtmlLabel3.Font = New Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Guna2HtmlLabel3.ForeColor = Color.Black
        Guna2HtmlLabel3.Location = New Point(572, 110)
        Guna2HtmlLabel3.Margin = New Padding(3, 4, 3, 4)
        Guna2HtmlLabel3.Name = "Guna2HtmlLabel3"
        Guna2HtmlLabel3.Size = New Size(177, 29)
        Guna2HtmlLabel3.TabIndex = 77
        Guna2HtmlLabel3.Text = "Membership ID: "
        ' 
        ' tbMemeberID
        ' 
        tbMemeberID.CustomizableEdges = CustomizableEdges1
        tbMemeberID.DefaultText = ""
        tbMemeberID.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        tbMemeberID.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        tbMemeberID.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        tbMemeberID.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        tbMemeberID.Enabled = False
        tbMemeberID.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        tbMemeberID.Font = New Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        tbMemeberID.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        tbMemeberID.Location = New Point(755, 107)
        tbMemeberID.Margin = New Padding(3, 4, 3, 4)
        tbMemeberID.Name = "tbMemeberID"
        tbMemeberID.PlaceholderText = ""
        tbMemeberID.SelectedText = ""
        tbMemeberID.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        tbMemeberID.Size = New Size(322, 43)
        tbMemeberID.TabIndex = 79
        ' 
        ' tbPlayerName
        ' 
        tbPlayerName.CustomizableEdges = CustomizableEdges3
        tbPlayerName.DefaultText = ""
        tbPlayerName.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        tbPlayerName.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        tbPlayerName.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        tbPlayerName.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        tbPlayerName.Enabled = False
        tbPlayerName.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        tbPlayerName.Font = New Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        tbPlayerName.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        tbPlayerName.Location = New Point(183, 107)
        tbPlayerName.Margin = New Padding(3, 4, 3, 4)
        tbPlayerName.Name = "tbPlayerName"
        tbPlayerName.PlaceholderText = ""
        tbPlayerName.SelectedText = ""
        tbPlayerName.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        tbPlayerName.Size = New Size(274, 43)
        tbPlayerName.TabIndex = 80
        ' 
        ' dgvLedger
        ' 
        DataGridViewCellStyle1.BackColor = Color.White
        dgvLedger.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgvLedger.BorderStyle = BorderStyle.FixedSingle
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(100), CByte(88), CByte(255))
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle2.ForeColor = Color.White
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgvLedger.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvLedger.ColumnHeadersHeight = 4
        dgvLedger.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.White
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        DataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        dgvLedger.DefaultCellStyle = DataGridViewCellStyle3
        dgvLedger.GridColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgvLedger.Location = New Point(25, 160)
        dgvLedger.Name = "dgvLedger"
        dgvLedger.RowHeadersVisible = False
        dgvLedger.RowHeadersWidth = 51
        dgvLedger.Size = New Size(1064, 520)
        dgvLedger.TabIndex = 81
        dgvLedger.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White
        dgvLedger.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        dgvLedger.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty
        dgvLedger.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty
        dgvLedger.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty
        dgvLedger.ThemeStyle.BackColor = Color.White
        dgvLedger.ThemeStyle.GridColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgvLedger.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(CByte(100), CByte(88), CByte(255))
        dgvLedger.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None
        dgvLedger.ThemeStyle.HeaderStyle.Font = New Font("Segoe UI", 9F)
        dgvLedger.ThemeStyle.HeaderStyle.ForeColor = Color.White
        dgvLedger.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        dgvLedger.ThemeStyle.HeaderStyle.Height = 4
        dgvLedger.ThemeStyle.ReadOnly = False
        dgvLedger.ThemeStyle.RowsStyle.BackColor = Color.White
        dgvLedger.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvLedger.ThemeStyle.RowsStyle.Font = New Font("Segoe UI", 9F)
        dgvLedger.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        dgvLedger.ThemeStyle.RowsStyle.Height = 29
        dgvLedger.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgvLedger.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        ' 
        ' btnBack
        ' 
        btnBack.BackColor = Color.Transparent
        btnBack.CustomizableEdges = CustomizableEdges5
        btnBack.DisabledState.BorderColor = Color.DarkGray
        btnBack.DisabledState.CustomBorderColor = Color.DarkGray
        btnBack.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnBack.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnBack.FillColor = Color.Black
        btnBack.Font = New Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnBack.ForeColor = SystemColors.Window
        btnBack.Location = New Point(25, 685)
        btnBack.Name = "btnBack"
        btnBack.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        btnBack.Size = New Size(142, 37)
        btnBack.TabIndex = 82
        btnBack.Text = "Back"
        ' 
        ' btnLedgerPrint
        ' 
        btnLedgerPrint.CustomizableEdges = CustomizableEdges7
        btnLedgerPrint.DisabledState.BorderColor = Color.DarkGray
        btnLedgerPrint.DisabledState.CustomBorderColor = Color.DarkGray
        btnLedgerPrint.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnLedgerPrint.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnLedgerPrint.FillColor = Color.Black
        btnLedgerPrint.Font = New Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnLedgerPrint.ForeColor = Color.White
        btnLedgerPrint.Location = New Point(923, 685)
        btnLedgerPrint.Margin = New Padding(3, 4, 3, 4)
        btnLedgerPrint.Name = "btnLedgerPrint"
        btnLedgerPrint.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        btnLedgerPrint.Size = New Size(166, 37)
        btnLedgerPrint.TabIndex = 83
        btnLedgerPrint.Text = "Print Ledger"
        ' 
        ' Ledger
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(btnLedgerPrint)
        Controls.Add(btnBack)
        Controls.Add(dgvLedger)
        Controls.Add(tbPlayerName)
        Controls.Add(tbMemeberID)
        Controls.Add(Guna2HtmlLabel3)
        Controls.Add(Guna2HtmlLabel2)
        Controls.Add(Guna2HtmlLabel1)
        Name = "Ledger"
        Size = New Size(1107, 739)
        CType(dgvLedger, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel3 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents tbMemeberID As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents tbPlayerName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents dgvLedger As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents btnBack As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnLedgerPrint As Guna.UI2.WinForms.Guna2Button

End Class
