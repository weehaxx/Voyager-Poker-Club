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
        Guna2GradientPanel1 = New Guna.UI2.WinForms.Guna2GradientPanel()
        pbIDphoto = New Guna.UI2.WinForms.Guna2PictureBox()
        lblName = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2HtmlLabel2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2HtmlLabel3 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2HtmlLabel4 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        btnPrint = New Guna.UI2.WinForms.Guna2Button()
        lblMemberID = New Label()
        CType(pbIDphoto, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Guna2GradientPanel1
        ' 
        Guna2GradientPanel1.CustomizableEdges = CustomizableEdges1
        Guna2GradientPanel1.FillColor = Color.Red
        Guna2GradientPanel1.FillColor2 = Color.Black
        Guna2GradientPanel1.Location = New Point(3, 146)
        Guna2GradientPanel1.Name = "Guna2GradientPanel1"
        Guna2GradientPanel1.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        Guna2GradientPanel1.Size = New Size(765, 75)
        Guna2GradientPanel1.TabIndex = 0
        ' 
        ' pbIDphoto
        ' 
        pbIDphoto.CustomizableEdges = CustomizableEdges3
        pbIDphoto.ImageRotate = 0F
        pbIDphoto.Location = New Point(45, 17)
        pbIDphoto.Name = "pbIDphoto"
        pbIDphoto.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        pbIDphoto.Size = New Size(199, 204)
        pbIDphoto.SizeMode = PictureBoxSizeMode.StretchImage
        pbIDphoto.TabIndex = 1
        pbIDphoto.TabStop = False
        ' 
        ' lblName
        ' 
        lblName.BackColor = Color.Transparent
        lblName.Font = New Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblName.ForeColor = Color.White
        lblName.Location = New Point(275, 89)
        lblName.Name = "lblName"
        lblName.Size = New Size(85, 42)
        lblName.TabIndex = 2
        lblName.Text = "NAME"
        ' 
        ' Guna2HtmlLabel2
        ' 
        Guna2HtmlLabel2.BackColor = Color.Transparent
        Guna2HtmlLabel2.Font = New Font("Segoe UI", 18.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Guna2HtmlLabel2.ForeColor = Color.White
        Guna2HtmlLabel2.Location = New Point(243, 254)
        Guna2HtmlLabel2.Name = "Guna2HtmlLabel2"
        Guna2HtmlLabel2.Size = New Size(293, 34)
        Guna2HtmlLabel2.TabIndex = 4
        Guna2HtmlLabel2.Text = "Terms and condition apply."
        ' 
        ' Guna2HtmlLabel3
        ' 
        Guna2HtmlLabel3.BackColor = Color.Transparent
        Guna2HtmlLabel3.Font = New Font("Segoe UI", 18.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Guna2HtmlLabel3.ForeColor = Color.White
        Guna2HtmlLabel3.Location = New Point(257, 294)
        Guna2HtmlLabel3.Name = "Guna2HtmlLabel3"
        Guna2HtmlLabel3.Size = New Size(264, 34)
        Guna2HtmlLabel3.TabIndex = 5
        Guna2HtmlLabel3.Text = "www.metrocardclub.com"
        ' 
        ' Guna2HtmlLabel4
        ' 
        Guna2HtmlLabel4.BackColor = Color.Transparent
        Guna2HtmlLabel4.Font = New Font("Segoe UI", 18.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Guna2HtmlLabel4.ForeColor = Color.White
        Guna2HtmlLabel4.Location = New Point(189, 334)
        Guna2HtmlLabel4.Name = "Guna2HtmlLabel4"
        Guna2HtmlLabel4.Size = New Size(414, 34)
        Guna2HtmlLabel4.TabIndex = 6
        Guna2HtmlLabel4.Text = "Customer Service: (+63) 917-532-3063"
        ' 
        ' btnPrint
        ' 
        btnPrint.CustomizableEdges = CustomizableEdges5
        btnPrint.DisabledState.BorderColor = Color.DarkGray
        btnPrint.DisabledState.CustomBorderColor = Color.DarkGray
        btnPrint.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnPrint.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnPrint.Font = New Font("Segoe UI", 9.0F)
        btnPrint.ForeColor = Color.White
        btnPrint.Location = New Point(290, 391)
        btnPrint.Name = "btnPrint"
        btnPrint.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        btnPrint.Size = New Size(180, 45)
        btnPrint.TabIndex = 7
        btnPrint.Text = "print"
        ' 
        ' lblMemberID
        ' 
        lblMemberID.BackColor = Color.Transparent
        lblMemberID.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblMemberID.ForeColor = Color.White
        lblMemberID.Location = New Point(666, 17)
        lblMemberID.Name = "lblMemberID"
        lblMemberID.RightToLeft = RightToLeft.Yes
        lblMemberID.Size = New Size(65, 22)
        lblMemberID.TabIndex = 8
        lblMemberID.Text = "00000"
        lblMemberID.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' IDPrinting
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Black
        Controls.Add(pbIDphoto)
        Controls.Add(lblMemberID)
        Controls.Add(btnPrint)
        Controls.Add(Guna2HtmlLabel4)
        Controls.Add(Guna2HtmlLabel3)
        Controls.Add(Guna2HtmlLabel2)
        Controls.Add(lblName)
        Controls.Add(Guna2GradientPanel1)
        Name = "IDPrinting"
        Size = New Size(765, 457)
        CType(pbIDphoto, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Guna2GradientPanel1 As Guna.UI2.WinForms.Guna2GradientPanel
    Friend WithEvents pbIDphoto As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents lblName As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel3 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel4 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents btnPrint As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblMemberID As Label

End Class
