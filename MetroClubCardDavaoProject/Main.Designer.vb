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
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        btnRegistration = New Guna.UI2.WinForms.Guna2Button()
        btnDashboard = New Guna.UI2.WinForms.Guna2Button()
        PictureBox1 = New PictureBox()
        Guna2Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Guna2Panel1
        ' 
        Guna2Panel1.Controls.Add(btnRegistration)
        Guna2Panel1.Controls.Add(btnDashboard)
        Guna2Panel1.Controls.Add(PictureBox1)
        Guna2Panel1.CustomizableEdges = CustomizableEdges5
        Guna2Panel1.FillColor = Color.White
        Guna2Panel1.Location = New Point(0, -1)
        Guna2Panel1.Name = "Guna2Panel1"
        Guna2Panel1.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        Guna2Panel1.Size = New Size(255, 635)
        Guna2Panel1.TabIndex = 0
        ' 
        ' btnRegistration
        ' 
        btnRegistration.BorderColor = Color.Transparent
        btnRegistration.CustomizableEdges = CustomizableEdges1
        btnRegistration.DisabledState.BorderColor = Color.DarkGray
        btnRegistration.DisabledState.CustomBorderColor = Color.DarkGray
        btnRegistration.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnRegistration.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnRegistration.FillColor = Color.WhiteSmoke
        btnRegistration.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnRegistration.ForeColor = Color.Black
        btnRegistration.Location = New Point(0, 177)
        btnRegistration.Name = "btnRegistration"
        btnRegistration.PressedColor = Color.DarkGray
        btnRegistration.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        btnRegistration.Size = New Size(255, 45)
        btnRegistration.TabIndex = 2
        btnRegistration.Text = "REGISTRATION"
        ' 
        ' btnDashboard
        ' 
        btnDashboard.BorderColor = Color.Transparent
        btnDashboard.CustomizableEdges = CustomizableEdges3
        btnDashboard.DisabledState.BorderColor = Color.DarkGray
        btnDashboard.DisabledState.CustomBorderColor = Color.DarkGray
        btnDashboard.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnDashboard.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnDashboard.FillColor = Color.WhiteSmoke
        btnDashboard.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDashboard.ForeColor = Color.Black
        btnDashboard.Location = New Point(0, 132)
        btnDashboard.Name = "btnDashboard"
        btnDashboard.PressedColor = Color.DarkGray
        btnDashboard.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        btnDashboard.Size = New Size(255, 45)
        btnDashboard.TabIndex = 1
        btnDashboard.Text = "DASHBOARD"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.CasinoLogo
        PictureBox1.Location = New Point(71, 3)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(110, 110)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Main
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1077, 634)
        Controls.Add(Guna2Panel1)
        ForeColor = Color.Transparent
        FormBorderStyle = FormBorderStyle.None
        Name = "Main"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Main"
        Guna2Panel1.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnRegistration As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDashboard As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
