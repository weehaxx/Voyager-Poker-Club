<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        tbUsername = New Guna.UI2.WinForms.Guna2TextBox()
        Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        PictureBox1 = New PictureBox()
        Guna2HtmlLabel2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        tbPassword = New Guna.UI2.WinForms.Guna2TextBox()
        btnLogin = New Guna.UI2.WinForms.Guna2Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' tbUsername
        ' 
        tbUsername.CustomizableEdges = CustomizableEdges1
        tbUsername.DefaultText = ""
        tbUsername.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        tbUsername.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        tbUsername.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        tbUsername.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        tbUsername.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        tbUsername.Font = New Font("Segoe UI", 9F)
        tbUsername.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        tbUsername.Location = New Point(264, 231)
        tbUsername.Name = "tbUsername"
        tbUsername.PlaceholderText = ""
        tbUsername.SelectedText = ""
        tbUsername.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        tbUsername.Size = New Size(210, 36)
        tbUsername.TabIndex = 0
        ' 
        ' Guna2HtmlLabel1
        ' 
        Guna2HtmlLabel1.BackColor = Color.Transparent
        Guna2HtmlLabel1.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(178))
        Guna2HtmlLabel1.Location = New Point(132, 241)
        Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Guna2HtmlLabel1.Size = New Size(92, 18)
        Guna2HtmlLabel1.TabIndex = 1
        Guna2HtmlLabel1.Text = "USERNAME:"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.CasinoLogo
        PictureBox1.Location = New Point(201, 12)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(261, 197)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 2
        PictureBox1.TabStop = False
        ' 
        ' Guna2HtmlLabel2
        ' 
        Guna2HtmlLabel2.BackColor = Color.Transparent
        Guna2HtmlLabel2.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(178))
        Guna2HtmlLabel2.Location = New Point(132, 295)
        Guna2HtmlLabel2.Name = "Guna2HtmlLabel2"
        Guna2HtmlLabel2.Size = New Size(94, 18)
        Guna2HtmlLabel2.TabIndex = 3
        Guna2HtmlLabel2.Text = "PASSWORD:"
        ' 
        ' tbPassword
        ' 
        tbPassword.CustomizableEdges = CustomizableEdges3
        tbPassword.DefaultText = ""
        tbPassword.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        tbPassword.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        tbPassword.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        tbPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        tbPassword.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        tbPassword.Font = New Font("Segoe UI", 9F)
        tbPassword.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        tbPassword.Location = New Point(264, 285)
        tbPassword.Name = "tbPassword"
        tbPassword.PasswordChar = "*"c
        tbPassword.PlaceholderText = ""
        tbPassword.SelectedText = ""
        tbPassword.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        tbPassword.Size = New Size(210, 36)
        tbPassword.TabIndex = 1
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.Transparent
        btnLogin.CustomizableEdges = CustomizableEdges5
        btnLogin.DisabledState.BorderColor = Color.DarkGray
        btnLogin.DisabledState.CustomBorderColor = Color.DarkGray
        btnLogin.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnLogin.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnLogin.FillColor = Color.DarkGray
        btnLogin.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(178))
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(231, 352)
        btnLogin.Name = "btnLogin"
        btnLogin.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        btnLogin.Size = New Size(180, 45)
        btnLogin.TabIndex = 2
        btnLogin.Text = "LOGIN"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(665, 446)
        Controls.Add(btnLogin)
        Controls.Add(tbPassword)
        Controls.Add(Guna2HtmlLabel2)
        Controls.Add(PictureBox1)
        Controls.Add(Guna2HtmlLabel1)
        Controls.Add(tbUsername)
        FormBorderStyle = FormBorderStyle.None
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form1"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents tbUsername As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Guna2HtmlLabel2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents tbPassword As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnLogin As Guna.UI2.WinForms.Guna2Button

End Class
