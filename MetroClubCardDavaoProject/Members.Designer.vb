<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Members
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
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        dgvRegistrations = New Guna.UI2.WinForms.Guna2DataGridView()
        search = New Guna.UI2.WinForms.Guna2HtmlLabel()
        tbSearch = New Guna.UI2.WinForms.Guna2TextBox()
        CType(dgvRegistrations, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Guna2HtmlLabel1
        ' 
        Guna2HtmlLabel1.BackColor = Color.Transparent
        Guna2HtmlLabel1.Font = New Font("Arial Rounded MT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Guna2HtmlLabel1.ForeColor = Color.Black
        Guna2HtmlLabel1.Location = New Point(32, 16)
        Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Guna2HtmlLabel1.Size = New Size(347, 34)
        Guna2HtmlLabel1.TabIndex = 0
        Guna2HtmlLabel1.Text = "Metro Club Card Members"
        ' 
        ' dgvRegistrations
        ' 
        DataGridViewCellStyle4.BackColor = Color.White
        dgvRegistrations.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = Color.FromArgb(CByte(100), CByte(88), CByte(255))
        DataGridViewCellStyle5.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle5.ForeColor = Color.White
        DataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.True
        dgvRegistrations.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        dgvRegistrations.ColumnHeadersHeight = 4
        dgvRegistrations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = Color.White
        DataGridViewCellStyle6.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle6.ForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        DataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        DataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.False
        dgvRegistrations.DefaultCellStyle = DataGridViewCellStyle6
        dgvRegistrations.GridColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgvRegistrations.Location = New Point(32, 56)
        dgvRegistrations.Name = "dgvRegistrations"
        dgvRegistrations.RowHeadersVisible = False
        dgvRegistrations.Size = New Size(982, 551)
        dgvRegistrations.TabIndex = 1
        dgvRegistrations.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White
        dgvRegistrations.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        dgvRegistrations.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty
        dgvRegistrations.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty
        dgvRegistrations.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty
        dgvRegistrations.ThemeStyle.BackColor = Color.White
        dgvRegistrations.ThemeStyle.GridColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgvRegistrations.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(CByte(100), CByte(88), CByte(255))
        dgvRegistrations.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None
        dgvRegistrations.ThemeStyle.HeaderStyle.Font = New Font("Segoe UI", 9F)
        dgvRegistrations.ThemeStyle.HeaderStyle.ForeColor = Color.White
        dgvRegistrations.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        dgvRegistrations.ThemeStyle.HeaderStyle.Height = 4
        dgvRegistrations.ThemeStyle.ReadOnly = False
        dgvRegistrations.ThemeStyle.RowsStyle.BackColor = Color.White
        dgvRegistrations.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvRegistrations.ThemeStyle.RowsStyle.Font = New Font("Segoe UI", 9F)
        dgvRegistrations.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        dgvRegistrations.ThemeStyle.RowsStyle.Height = 25
        dgvRegistrations.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgvRegistrations.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        ' 
        ' search
        ' 
        search.BackColor = Color.Transparent
        search.Font = New Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        search.ForeColor = Color.Black
        search.Location = New Point(679, 26)
        search.Name = "search"
        search.Size = New Size(74, 24)
        search.TabIndex = 2
        search.Text = "Search:"
        ' 
        ' tbSearch
        ' 
        tbSearch.CustomizableEdges = CustomizableEdges3
        tbSearch.DefaultText = ""
        tbSearch.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        tbSearch.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        tbSearch.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        tbSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        tbSearch.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        tbSearch.Font = New Font("Segoe UI", 9F)
        tbSearch.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        tbSearch.Location = New Point(769, 16)
        tbSearch.Name = "tbSearch"
        tbSearch.PlaceholderText = ""
        tbSearch.SelectedText = ""
        tbSearch.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        tbSearch.Size = New Size(200, 36)
        tbSearch.TabIndex = 3
        ' 
        ' Members
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(tbSearch)
        Controls.Add(search)
        Controls.Add(dgvRegistrations)
        Controls.Add(Guna2HtmlLabel1)
        Name = "Members"
        Size = New Size(1041, 635)
        CType(dgvRegistrations, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents dgvRegistrations As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents search As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents tbSearch As Guna.UI2.WinForms.Guna2TextBox

End Class
