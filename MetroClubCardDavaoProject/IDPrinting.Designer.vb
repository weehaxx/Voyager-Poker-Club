<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IDPrinting
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
        Guna2GradientPanel1 = New Guna.UI2.WinForms.Guna2GradientPanel()
        pbIDphoto = New Guna.UI2.WinForms.Guna2PictureBox()
        lblName = New Guna.UI2.WinForms.Guna2HtmlLabel()
        btnPrint = New Guna.UI2.WinForms.Guna2Button()
        lblMemberID = New Label()
        Guna2CustomGradientPanel1 = New Guna.UI2.WinForms.Guna2CustomGradientPanel()
        CType(pbIDphoto, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Guna2GradientPanel1
        ' 
        Guna2GradientPanel1.CustomizableEdges = CustomizableEdges1
        Guna2GradientPanel1.FillColor = Color.Red
        Guna2GradientPanel1.FillColor2 = Color.Black
        Guna2GradientPanel1.Location = New Point(3, 195)
        Guna2GradientPanel1.Margin = New Padding(3, 4, 3, 4)
        Guna2GradientPanel1.Name = "Guna2GradientPanel1"
        Guna2GradientPanel1.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        Guna2GradientPanel1.Size = New Size(874, 100)
        Guna2GradientPanel1.TabIndex = 0
        ' 
        ' pbIDphoto
        ' 
        pbIDphoto.CustomizableEdges = CustomizableEdges3
        pbIDphoto.ImageRotate = 0F
        pbIDphoto.Location = New Point(51, 59)
        pbIDphoto.Margin = New Padding(3, 4, 3, 4)
        pbIDphoto.Name = "pbIDphoto"
        pbIDphoto.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        pbIDphoto.Size = New Size(227, 236)
        pbIDphoto.SizeMode = PictureBoxSizeMode.StretchImage
        pbIDphoto.TabIndex = 1
        pbIDphoto.TabStop = False
        ' 
        ' lblName
        ' 
        lblName.BackColor = Color.Transparent
        lblName.Font = New Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblName.ForeColor = Color.White
        lblName.Location = New Point(314, 119)
        lblName.Margin = New Padding(3, 4, 3, 4)
        lblName.Name = "lblName"
        lblName.Size = New Size(103, 50)
        lblName.TabIndex = 2
        lblName.Text = "NAME"
        ' 
        ' btnPrint
        ' 
        btnPrint.CustomizableEdges = CustomizableEdges5
        btnPrint.DisabledState.BorderColor = Color.DarkGray
        btnPrint.DisabledState.CustomBorderColor = Color.DarkGray
        btnPrint.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnPrint.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnPrint.Font = New Font("Segoe UI", 9F)
        btnPrint.ForeColor = Color.White
        btnPrint.Location = New Point(331, 521)
        btnPrint.Margin = New Padding(3, 4, 3, 4)
        btnPrint.Name = "btnPrint"
        btnPrint.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        btnPrint.Size = New Size(206, 60)
        btnPrint.TabIndex = 7
        btnPrint.Text = "print"
        ' 
        ' lblMemberID
        ' 
        lblMemberID.BackColor = Color.Transparent
        lblMemberID.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblMemberID.ForeColor = Color.White
        lblMemberID.Location = New Point(761, 23)
        lblMemberID.Name = "lblMemberID"
        lblMemberID.RightToLeft = RightToLeft.Yes
        lblMemberID.Size = New Size(74, 29)
        lblMemberID.TabIndex = 8
        lblMemberID.Text = "00000"
        lblMemberID.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Guna2CustomGradientPanel1
        ' 
        Guna2CustomGradientPanel1.CustomizableEdges = CustomizableEdges7
        Guna2CustomGradientPanel1.Location = New Point(159, 371)
        Guna2CustomGradientPanel1.Name = "Guna2CustomGradientPanel1"
        Guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        Guna2CustomGradientPanel1.Size = New Size(588, 94)
        Guna2CustomGradientPanel1.TabIndex = 9
        ' 
        ' IDPrinting
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Black
        Controls.Add(Guna2CustomGradientPanel1)
        Controls.Add(pbIDphoto)
        Controls.Add(lblMemberID)
        Controls.Add(btnPrint)
        Controls.Add(lblName)
        Controls.Add(Guna2GradientPanel1)
        Margin = New Padding(3, 4, 3, 4)
        Name = "IDPrinting"
        Size = New Size(874, 609)
        CType(pbIDphoto, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Guna2GradientPanel1 As Guna.UI2.WinForms.Guna2GradientPanel
    Friend WithEvents pbIDphoto As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents lblName As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents btnPrint As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblMemberID As Label
    Friend WithEvents Guna2CustomGradientPanel1 As Guna.UI2.WinForms.Guna2CustomGradientPanel

End Class
