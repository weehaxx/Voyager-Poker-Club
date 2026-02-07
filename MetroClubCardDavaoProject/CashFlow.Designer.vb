<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CashFlow
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        dgvCashFlow = New Guna.UI2.WinForms.Guna2DataGridView()
        dtpDate = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Guna2HtmlLabel7 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        tbSearchMember = New Guna.UI2.WinForms.Guna2TextBox()
        Guna2HtmlLabel2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        btnRefresh = New Guna.UI2.WinForms.Guna2Button()
        btnPrintPDF = New Guna.UI2.WinForms.Guna2Button()
        Panel1 = New Panel()
        CType(dgvCashFlow, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Guna2HtmlLabel1
        ' 
        Guna2HtmlLabel1.BackColor = Color.Transparent
        Guna2HtmlLabel1.Font = New Font("Arial Rounded MT Bold", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Guna2HtmlLabel1.ForeColor = Color.Black
        Guna2HtmlLabel1.Location = New Point(18, 12)
        Guna2HtmlLabel1.Margin = New Padding(3, 2, 3, 2)
        Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Guna2HtmlLabel1.Size = New Size(247, 32)
        Guna2HtmlLabel1.TabIndex = 0
        Guna2HtmlLabel1.Text = "DAILY CASH FLOW" & vbCrLf & vbCrLf
        ' 
        ' dgvCashFlow
        ' 
        DataGridViewCellStyle1.BackColor = Color.White
        dgvCashFlow.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgvCashFlow.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgvCashFlow.BackgroundColor = Color.WhiteSmoke
        dgvCashFlow.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(100), CByte(88), CByte(255))
        DataGridViewCellStyle2.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = Color.White
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgvCashFlow.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvCashFlow.ColumnHeadersHeight = 4
        dgvCashFlow.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.White
        DataGridViewCellStyle3.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        DataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        dgvCashFlow.DefaultCellStyle = DataGridViewCellStyle3
        dgvCashFlow.Dock = DockStyle.Fill
        dgvCashFlow.GridColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgvCashFlow.Location = New Point(0, 0)
        dgvCashFlow.Margin = New Padding(3, 2, 3, 2)
        dgvCashFlow.Name = "dgvCashFlow"
        dgvCashFlow.ReadOnly = True
        dgvCashFlow.RowHeadersVisible = False
        dgvCashFlow.RowHeadersWidth = 51
        dgvCashFlow.RowTemplate.Height = 29
        dgvCashFlow.Size = New Size(1006, 470)
        dgvCashFlow.TabIndex = 70
        dgvCashFlow.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White
        dgvCashFlow.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        dgvCashFlow.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty
        dgvCashFlow.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty
        dgvCashFlow.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty
        dgvCashFlow.ThemeStyle.BackColor = Color.WhiteSmoke
        dgvCashFlow.ThemeStyle.GridColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgvCashFlow.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(CByte(100), CByte(88), CByte(255))
        dgvCashFlow.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None
        dgvCashFlow.ThemeStyle.HeaderStyle.Font = New Font("Segoe UI", 9F)
        dgvCashFlow.ThemeStyle.HeaderStyle.ForeColor = Color.White
        dgvCashFlow.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        dgvCashFlow.ThemeStyle.HeaderStyle.Height = 4
        dgvCashFlow.ThemeStyle.ReadOnly = True
        dgvCashFlow.ThemeStyle.RowsStyle.BackColor = Color.White
        dgvCashFlow.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvCashFlow.ThemeStyle.RowsStyle.Font = New Font("Segoe UI", 9F)
        dgvCashFlow.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        dgvCashFlow.ThemeStyle.RowsStyle.Height = 29
        dgvCashFlow.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgvCashFlow.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        ' 
        ' dtpDate
        ' 
        dtpDate.BackColor = Color.Transparent
        dtpDate.Checked = True
        dtpDate.CustomizableEdges = CustomizableEdges1
        dtpDate.FillColor = Color.Gainsboro
        dtpDate.Font = New Font("Segoe UI", 9F)
        dtpDate.ForeColor = Color.Black
        dtpDate.Format = DateTimePickerFormat.Long
        dtpDate.Location = New Point(78, 63)
        dtpDate.Margin = New Padding(3, 2, 3, 2)
        dtpDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        dtpDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        dtpDate.Name = "dtpDate"
        dtpDate.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        dtpDate.Size = New Size(219, 34)
        dtpDate.TabIndex = 71
        dtpDate.Value = New Date(2025, 9, 25, 0, 58, 37, 566)
        ' 
        ' Guna2HtmlLabel7
        ' 
        Guna2HtmlLabel7.BackColor = Color.Transparent
        Guna2HtmlLabel7.Font = New Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Guna2HtmlLabel7.ForeColor = Color.Black
        Guna2HtmlLabel7.Location = New Point(377, 67)
        Guna2HtmlLabel7.Name = "Guna2HtmlLabel7"
        Guna2HtmlLabel7.Size = New Size(150, 23)
        Guna2HtmlLabel7.TabIndex = 72
        Guna2HtmlLabel7.Text = "Search Member: "
        ' 
        ' tbSearchMember
        ' 
        tbSearchMember.CustomizableEdges = CustomizableEdges3
        tbSearchMember.DefaultText = ""
        tbSearchMember.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        tbSearchMember.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        tbSearchMember.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        tbSearchMember.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        tbSearchMember.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        tbSearchMember.Font = New Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        tbSearchMember.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        tbSearchMember.Location = New Point(533, 62)
        tbSearchMember.Name = "tbSearchMember"
        tbSearchMember.PlaceholderText = "Enter Player/Member ID"
        tbSearchMember.SelectedText = ""
        tbSearchMember.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        tbSearchMember.Size = New Size(211, 34)
        tbSearchMember.TabIndex = 73
        ' 
        ' Guna2HtmlLabel2
        ' 
        Guna2HtmlLabel2.BackColor = Color.Transparent
        Guna2HtmlLabel2.Font = New Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Guna2HtmlLabel2.ForeColor = Color.Black
        Guna2HtmlLabel2.Location = New Point(18, 67)
        Guna2HtmlLabel2.Name = "Guna2HtmlLabel2"
        Guna2HtmlLabel2.Size = New Size(50, 23)
        Guna2HtmlLabel2.TabIndex = 75
        Guna2HtmlLabel2.Text = "Date: "
        ' 
        ' btnRefresh
        ' 
        btnRefresh.CustomizableEdges = CustomizableEdges5
        btnRefresh.DisabledState.BorderColor = Color.DarkGray
        btnRefresh.DisabledState.CustomBorderColor = Color.DarkGray
        btnRefresh.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnRefresh.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnRefresh.FillColor = Color.White
        btnRefresh.Font = New Font("Segoe UI", 9F)
        btnRefresh.ForeColor = Color.White
        btnRefresh.Image = My.Resources.Resources.refresh1
        btnRefresh.ImageSize = New Size(30, 30)
        btnRefresh.Location = New Point(302, 63)
        btnRefresh.Margin = New Padding(3, 2, 3, 2)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        btnRefresh.Size = New Size(43, 34)
        btnRefresh.TabIndex = 76
        ' 
        ' btnPrintPDF
        ' 
        btnPrintPDF.CustomizableEdges = CustomizableEdges7
        btnPrintPDF.DisabledState.BorderColor = Color.DarkGray
        btnPrintPDF.DisabledState.CustomBorderColor = Color.DarkGray
        btnPrintPDF.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnPrintPDF.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnPrintPDF.FillColor = Color.Black
        btnPrintPDF.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnPrintPDF.ForeColor = Color.White
        btnPrintPDF.Location = New Point(770, 63)
        btnPrintPDF.Name = "btnPrintPDF"
        btnPrintPDF.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        btnPrintPDF.Size = New Size(169, 34)
        btnPrintPDF.TabIndex = 77
        btnPrintPDF.Text = "PRINT"
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.Controls.Add(dgvCashFlow)
        Panel1.Location = New Point(18, 102)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1006, 470)
        Panel1.TabIndex = 78
        ' 
        ' CashFlow
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        Controls.Add(Panel1)
        Controls.Add(btnPrintPDF)
        Controls.Add(btnRefresh)
        Controls.Add(Guna2HtmlLabel2)
        Controls.Add(tbSearchMember)
        Controls.Add(Guna2HtmlLabel7)
        Controls.Add(dtpDate)
        Controls.Add(Guna2HtmlLabel1)
        Margin = New Padding(3, 2, 3, 2)
        Name = "CashFlow"
        Size = New Size(1041, 635)
        CType(dgvCashFlow, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents dgvCashFlow As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents dtpDate As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Guna2HtmlLabel7 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents tbSearchMember As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents btnRefresh As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnPrintPDF As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Panel1 As Panel

End Class
