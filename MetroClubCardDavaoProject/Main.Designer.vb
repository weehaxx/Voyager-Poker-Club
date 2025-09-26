<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        PictureBox1 = New PictureBox()
        btnDashboard = New Guna.UI2.WinForms.Guna2Button()
        btnRegistration = New Guna.UI2.WinForms.Guna2Button()
        btnCashFlow = New Guna.UI2.WinForms.Guna2Button()
        btnLogout = New Guna.UI2.WinForms.Guna2Button()
        Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Panel1 = New Panel()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Guna2Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.CasinoLogo
        PictureBox1.Location = New Point(52, 13)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(110, 110)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' btnDashboard
        ' 
        btnDashboard.BackColor = Color.Transparent
        btnDashboard.BorderRadius = 20
        btnDashboard.Checked = True
        btnDashboard.CheckedState.FillColor = Color.Black
        btnDashboard.CheckedState.ForeColor = Color.White
        btnDashboard.CustomizableEdges = CustomizableEdges1
        btnDashboard.DisabledState.BorderColor = Color.DarkGray
        btnDashboard.DisabledState.CustomBorderColor = Color.DarkGray
        btnDashboard.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnDashboard.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnDashboard.FillColor = Color.White
        btnDashboard.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDashboard.ForeColor = Color.Black
        btnDashboard.HoverState.FillColor = Color.Black
        btnDashboard.HoverState.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDashboard.HoverState.ForeColor = Color.White
        btnDashboard.Location = New Point(12, 160)
        btnDashboard.Name = "btnDashboard"
        btnDashboard.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        btnDashboard.Size = New Size(195, 45)
        btnDashboard.TabIndex = 1
        btnDashboard.Text = "Members"
        ' 
        ' btnRegistration
        ' 
        btnRegistration.BackColor = Color.Transparent
        btnRegistration.BorderRadius = 20
        btnRegistration.CheckedState.FillColor = Color.Black
        btnRegistration.CheckedState.ForeColor = Color.White
        btnRegistration.CustomizableEdges = CustomizableEdges3
        btnRegistration.DisabledState.BorderColor = Color.DarkGray
        btnRegistration.DisabledState.CustomBorderColor = Color.DarkGray
        btnRegistration.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnRegistration.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnRegistration.FillColor = Color.White
        btnRegistration.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnRegistration.ForeColor = Color.Black
        btnRegistration.HoverState.FillColor = Color.Black
        btnRegistration.HoverState.ForeColor = Color.White
        btnRegistration.Location = New Point(12, 211)
        btnRegistration.Name = "btnRegistration"
        btnRegistration.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        btnRegistration.Size = New Size(195, 45)
        btnRegistration.TabIndex = 2
        btnRegistration.Text = "Registration"
        ' 
        ' btnCashFlow
        ' 
        btnCashFlow.BackColor = Color.Transparent
        btnCashFlow.BorderRadius = 20
        btnCashFlow.CustomizableEdges = CustomizableEdges5
        btnCashFlow.DisabledState.BorderColor = Color.DarkGray
        btnCashFlow.DisabledState.CustomBorderColor = Color.DarkGray
        btnCashFlow.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnCashFlow.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnCashFlow.FillColor = Color.White
        btnCashFlow.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnCashFlow.ForeColor = Color.Black
        btnCashFlow.HoverState.FillColor = Color.Black
        btnCashFlow.HoverState.ForeColor = Color.White
        btnCashFlow.Location = New Point(12, 262)
        btnCashFlow.Name = "btnCashFlow"
        btnCashFlow.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        btnCashFlow.Size = New Size(195, 45)
        btnCashFlow.TabIndex = 3
        btnCashFlow.Text = "Cash Flow"
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.Transparent
        btnLogout.BorderRadius = 20
        btnLogout.CustomizableEdges = CustomizableEdges7
        btnLogout.DisabledState.BorderColor = Color.DarkGray
        btnLogout.DisabledState.CustomBorderColor = Color.DarkGray
        btnLogout.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnLogout.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnLogout.FillColor = Color.White
        btnLogout.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnLogout.ForeColor = Color.Black
        btnLogout.Location = New Point(12, 782)
        btnLogout.Name = "btnLogout"
        btnLogout.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        btnLogout.Size = New Size(195, 45)
        btnLogout.TabIndex = 3
        btnLogout.Text = "Logout"
        ' 
        ' Guna2Panel1
        ' 
        Guna2Panel1.Controls.Add(btnLogout)
        Guna2Panel1.Controls.Add(btnCashFlow)
        Guna2Panel1.Controls.Add(btnRegistration)
        Guna2Panel1.Controls.Add(btnDashboard)
        Guna2Panel1.Controls.Add(PictureBox1)
        Guna2Panel1.CustomizableEdges = CustomizableEdges9
        Guna2Panel1.FillColor = Color.White
        Guna2Panel1.Location = New Point(0, -1)
        Guna2Panel1.Name = "Guna2Panel1"
        Guna2Panel1.ShadowDecoration.CustomizableEdges = CustomizableEdges10
        Guna2Panel1.Size = New Size(221, 847)
        Guna2Panel1.TabIndex = 0
        ' 
        ' Panel1
        ' 
        Panel1.Location = New Point(227, -1)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1190, 847)
        Panel1.TabIndex = 1
        ' 
        ' Main
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1416, 844)
        Controls.Add(Panel1)
        Controls.Add(Guna2Panel1)
        Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ForeColor = Color.Transparent
        FormBorderStyle = FormBorderStyle.None
        Name = "Main"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Main"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Guna2Panel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnDashboard As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnRegistration As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnCashFlow As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnLogout As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Panel1 As Panel
End Class
