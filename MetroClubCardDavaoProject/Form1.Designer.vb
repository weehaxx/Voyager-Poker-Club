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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        tbUsername = New Guna.UI2.WinForms.Guna2TextBox()
        PictureBox1 = New PictureBox()
        tbPassword = New Guna.UI2.WinForms.Guna2TextBox()
        btnLogin = New Guna.UI2.WinForms.Guna2Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' tbUsername
        ' 
        tbUsername.BorderColor = Color.Black
        tbUsername.CustomizableEdges = CustomizableEdges1
        tbUsername.DefaultText = ""
        tbUsername.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        tbUsername.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        tbUsername.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        tbUsername.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        tbUsername.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        tbUsername.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        tbUsername.ForeColor = Color.Black
        tbUsername.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        tbUsername.IconLeft = My.Resources.Resources.user
        tbUsername.IconLeftOffset = New Point(10, 0)
        tbUsername.IconLeftSize = New Size(30, 30)
        tbUsername.Location = New Point(92, 235)
        tbUsername.Margin = New Padding(8, 8, 8, 8)
        tbUsername.Name = "tbUsername"
        tbUsername.PlaceholderForeColor = Color.DarkGray
        tbUsername.PlaceholderText = "Username"
        tbUsername.ScrollBars = ScrollBars.Both
        tbUsername.SelectedText = ""
        tbUsername.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        tbUsername.Size = New Size(261, 49)
        tbUsername.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        tbUsername.TabIndex = 0
        tbUsername.TextOffset = New Point(10, 0)
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.CasinoLogo
        PictureBox1.Location = New Point(118, 36)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(219, 188)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 2
        PictureBox1.TabStop = False
        ' 
        ' tbPassword
        ' 
        tbPassword.BorderColor = Color.Black
        tbPassword.CustomizableEdges = CustomizableEdges3
        tbPassword.DefaultText = ""
        tbPassword.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        tbPassword.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        tbPassword.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        tbPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        tbPassword.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        tbPassword.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        tbPassword.ForeColor = Color.Black
        tbPassword.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        tbPassword.IconLeft = My.Resources.Resources.lock
        tbPassword.IconLeftOffset = New Point(10, 0)
        tbPassword.IconLeftSize = New Size(30, 30)
        tbPassword.Location = New Point(92, 288)
        tbPassword.Margin = New Padding(5, 7, 5, 7)
        tbPassword.Name = "tbPassword"
        tbPassword.PasswordChar = "*"c
        tbPassword.PlaceholderForeColor = Color.DarkGray
        tbPassword.PlaceholderText = "Password"
        tbPassword.SelectedText = ""
        tbPassword.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        tbPassword.Size = New Size(261, 47)
        tbPassword.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        tbPassword.TabIndex = 1
        tbPassword.TextOffset = New Point(10, 0)
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.Transparent
        btnLogin.CustomizableEdges = CustomizableEdges5
        btnLogin.DisabledState.BorderColor = Color.DarkGray
        btnLogin.DisabledState.CustomBorderColor = Color.DarkGray
        btnLogin.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnLogin.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnLogin.FillColor = Color.Black
        btnLogin.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(92, 373)
        btnLogin.Name = "btnLogin"
        btnLogin.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        btnLogin.Size = New Size(261, 35)
        btnLogin.TabIndex = 2
        btnLogin.Text = "LOGIN"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(438, 455)
        Controls.Add(btnLogin)
        Controls.Add(tbPassword)
        Controls.Add(PictureBox1)
        Controls.Add(tbUsername)
        ForeColor = Color.Black
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents tbUsername As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents tbPassword As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnLogin As Guna.UI2.WinForms.Guna2Button

End Class
