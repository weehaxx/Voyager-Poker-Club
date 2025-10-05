<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Authentication
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
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        btnProceed = New Guna.UI2.WinForms.Guna2Button()
        btnCancel = New Guna.UI2.WinForms.Guna2Button()
        PictureBox1 = New PictureBox()
        tbPassword = New Guna.UI2.WinForms.Guna2TextBox()
        btnShowPass = New Guna.UI2.WinForms.Guna2Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnProceed
        ' 
        btnProceed.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnProceed.BackColor = Color.Transparent
        btnProceed.CustomizableEdges = CustomizableEdges1
        btnProceed.DisabledState.BorderColor = Color.DarkGray
        btnProceed.DisabledState.CustomBorderColor = Color.DarkGray
        btnProceed.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnProceed.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnProceed.FillColor = Color.Black
        btnProceed.Font = New Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnProceed.ForeColor = Color.White
        btnProceed.Location = New Point(318, 176)
        btnProceed.Name = "btnProceed"
        btnProceed.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        btnProceed.Size = New Size(127, 35)
        btnProceed.TabIndex = 3
        btnProceed.Text = "PROCEED"
        ' 
        ' btnCancel
        ' 
        btnCancel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnCancel.BackColor = Color.Transparent
        btnCancel.CustomizableEdges = CustomizableEdges3
        btnCancel.DisabledState.BorderColor = Color.DarkGray
        btnCancel.DisabledState.CustomBorderColor = Color.DarkGray
        btnCancel.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnCancel.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnCancel.FillColor = Color.Red
        btnCancel.Font = New Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnCancel.ForeColor = Color.White
        btnCancel.Location = New Point(20, 176)
        btnCancel.Name = "btnCancel"
        btnCancel.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        btnCancel.Size = New Size(127, 35)
        btnCancel.TabIndex = 4
        btnCancel.Text = "CANCEL"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.Top
        PictureBox1.Image = My.Resources.Resources.CasinoLogo
        PictureBox1.Location = New Point(172, 2)
        PictureBox1.Margin = New Padding(3, 2, 3, 2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(108, 84)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 5
        PictureBox1.TabStop = False
        ' 
        ' tbPassword
        ' 
        tbPassword.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        tbPassword.BackColor = Color.Transparent
        tbPassword.BorderColor = Color.Black
        tbPassword.CustomizableEdges = CustomizableEdges5
        tbPassword.DefaultText = ""
        tbPassword.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        tbPassword.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        tbPassword.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        tbPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        tbPassword.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        tbPassword.Font = New Font("Segoe UI", 9F)
        tbPassword.ForeColor = Color.Black
        tbPassword.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        tbPassword.IconLeft = My.Resources.Resources.admin_lock
        tbPassword.IconLeftOffset = New Point(10, 0)
        tbPassword.IconLeftSize = New Size(30, 30)
        tbPassword.Location = New Point(97, 110)
        tbPassword.Margin = New Padding(3, 4, 3, 4)
        tbPassword.Name = "tbPassword"
        tbPassword.PlaceholderForeColor = Color.DarkGray
        tbPassword.PlaceholderText = "Enter admin password"
        tbPassword.ScrollBars = ScrollBars.Both
        tbPassword.SelectedText = ""
        tbPassword.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        tbPassword.Size = New Size(237, 36)
        tbPassword.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        tbPassword.TabIndex = 6
        tbPassword.TextOffset = New Point(10, 0)
        ' 
        ' btnShowPass
        ' 
        btnShowPass.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        btnShowPass.CustomizableEdges = CustomizableEdges7
        btnShowPass.DisabledState.BorderColor = Color.DarkGray
        btnShowPass.DisabledState.CustomBorderColor = Color.DarkGray
        btnShowPass.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnShowPass.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnShowPass.FillColor = Color.White
        btnShowPass.Font = New Font("Segoe UI", 9F)
        btnShowPass.ForeColor = Color.White
        btnShowPass.Image = My.Resources.Resources.eye
        btnShowPass.Location = New Point(330, 110)
        btnShowPass.Margin = New Padding(3, 2, 3, 2)
        btnShowPass.Name = "btnShowPass"
        btnShowPass.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        btnShowPass.Size = New Size(47, 36)
        btnShowPass.TabIndex = 7
        ' 
        ' Authentication
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        Controls.Add(btnShowPass)
        Controls.Add(tbPassword)
        Controls.Add(PictureBox1)
        Controls.Add(btnCancel)
        Controls.Add(btnProceed)
        Margin = New Padding(3, 2, 3, 2)
        Name = "Authentication"
        Size = New Size(461, 232)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents btnProceed As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnCancel As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents tbPassword As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnShowPass As Guna.UI2.WinForms.Guna2Button

End Class
