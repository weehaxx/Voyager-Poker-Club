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
        Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        dgvCashFlow = New Guna.UI2.WinForms.Guna2DataGridView()
        Guna2DateTimePicker1 = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Guna2HtmlLabel7 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2TextBox1 = New Guna.UI2.WinForms.Guna2TextBox()
        CType(dgvCashFlow, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Guna2HtmlLabel1
        ' 
        Guna2HtmlLabel1.BackColor = Color.Transparent
        Guna2HtmlLabel1.Font = New Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Guna2HtmlLabel1.Location = New Point(410, 15)
        Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Guna2HtmlLabel1.Size = New Size(378, 48)
        Guna2HtmlLabel1.TabIndex = 0
        Guna2HtmlLabel1.Text = "DAILY CASH FLOW" & vbCrLf & vbCrLf
        ' 
        ' dgvCashFlow
        ' 
        DataGridViewCellStyle1.BackColor = Color.White
        dgvCashFlow.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgvCashFlow.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(100), CByte(88), CByte(255))
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle2.ForeColor = Color.White
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgvCashFlow.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvCashFlow.ColumnHeadersHeight = 4
        dgvCashFlow.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.White
        DataGridViewCellStyle3.Font = New Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        DataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        dgvCashFlow.DefaultCellStyle = DataGridViewCellStyle3
        dgvCashFlow.GridColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgvCashFlow.Location = New Point(42, 138)
        dgvCashFlow.Name = "dgvCashFlow"
        dgvCashFlow.ReadOnly = True
        dgvCashFlow.RowHeadersVisible = False
        dgvCashFlow.RowHeadersWidth = 51
        dgvCashFlow.Size = New Size(1114, 654)
        dgvCashFlow.TabIndex = 70
        dgvCashFlow.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White
        dgvCashFlow.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        dgvCashFlow.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty
        dgvCashFlow.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty
        dgvCashFlow.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty
        dgvCashFlow.ThemeStyle.BackColor = Color.White
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
        ' Guna2DateTimePicker1
        ' 
        Guna2DateTimePicker1.Checked = True
        Guna2DateTimePicker1.CustomizableEdges = CustomizableEdges1
        Guna2DateTimePicker1.Font = New Font("Segoe UI", 9F)
        Guna2DateTimePicker1.ForeColor = Color.Black
        Guna2DateTimePicker1.Format = DateTimePickerFormat.Long
        Guna2DateTimePicker1.Location = New Point(42, 76)
        Guna2DateTimePicker1.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Guna2DateTimePicker1.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Guna2DateTimePicker1.Name = "Guna2DateTimePicker1"
        Guna2DateTimePicker1.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        Guna2DateTimePicker1.Size = New Size(250, 45)
        Guna2DateTimePicker1.TabIndex = 71
        Guna2DateTimePicker1.Value = New Date(2025, 9, 25, 0, 58, 37, 566)
        ' 
        ' Guna2HtmlLabel7
        ' 
        Guna2HtmlLabel7.BackColor = Color.Transparent
        Guna2HtmlLabel7.Font = New Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Guna2HtmlLabel7.ForeColor = Color.Black
        Guna2HtmlLabel7.Location = New Point(708, 98)
        Guna2HtmlLabel7.Margin = New Padding(3, 4, 3, 4)
        Guna2HtmlLabel7.Name = "Guna2HtmlLabel7"
        Guna2HtmlLabel7.Size = New Size(150, 23)
        Guna2HtmlLabel7.TabIndex = 72
        Guna2HtmlLabel7.Text = "Search Member: "
        ' 
        ' Guna2TextBox1
        ' 
        Guna2TextBox1.CustomizableEdges = CustomizableEdges3
        Guna2TextBox1.DefaultText = ""
        Guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        Guna2TextBox1.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        Guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        Guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        Guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        Guna2TextBox1.Font = New Font("Segoe UI", 9F)
        Guna2TextBox1.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        Guna2TextBox1.Location = New Point(870, 86)
        Guna2TextBox1.Margin = New Padding(3, 4, 3, 4)
        Guna2TextBox1.Name = "Guna2TextBox1"
        Guna2TextBox1.PlaceholderText = ""
        Guna2TextBox1.SelectedText = ""
        Guna2TextBox1.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        Guna2TextBox1.Size = New Size(286, 45)
        Guna2TextBox1.TabIndex = 73
        ' 
        ' CashFlow
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Guna2TextBox1)
        Controls.Add(Guna2HtmlLabel7)
        Controls.Add(Guna2DateTimePicker1)
        Controls.Add(dgvCashFlow)
        Controls.Add(Guna2HtmlLabel1)
        Name = "CashFlow"
        Size = New Size(1190, 847)
        CType(dgvCashFlow, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents dgvCashFlow As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents Guna2DateTimePicker1 As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Guna2HtmlLabel7 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2TextBox1 As Guna.UI2.WinForms.Guna2TextBox

End Class
