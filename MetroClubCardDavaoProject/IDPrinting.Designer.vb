<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class IDPrinting
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
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
        btnPrint = New Guna.UI2.WinForms.Guna2Button()
        lblMemberID = New Label()
        pbBarcode = New PictureBox()
        CType(pbIDphoto, ComponentModel.ISupportInitialize).BeginInit()
        CType(pbBarcode, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Guna2GradientPanel1
        ' 
        Guna2GradientPanel1.CustomizableEdges = CustomizableEdges1
        Guna2GradientPanel1.FillColor = Color.Red
        Guna2GradientPanel1.FillColor2 = Color.Red
        Guna2GradientPanel1.Location = New Point(3, 164)
        Guna2GradientPanel1.Name = "Guna2GradientPanel1"
        Guna2GradientPanel1.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        Guna2GradientPanel1.Size = New Size(779, 30)
        Guna2GradientPanel1.TabIndex = 0
        ' 
        ' pbIDphoto
        ' 
        pbIDphoto.CustomizableEdges = CustomizableEdges3
        pbIDphoto.ImageRotate = 0F
        pbIDphoto.Location = New Point(44, 93)
        pbIDphoto.Margin = New Padding(3, 2, 3, 2)
        pbIDphoto.Name = "pbIDphoto"
        pbIDphoto.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        pbIDphoto.Size = New Size(180, 154)
        pbIDphoto.SizeMode = PictureBoxSizeMode.StretchImage
        pbIDphoto.TabIndex = 1
        pbIDphoto.TabStop = False
        ' 
        ' lblName
        ' 
        lblName.BackColor = Color.Transparent
        lblName.Font = New Font("Arial Narrow", 22.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblName.ForeColor = Color.Black
        lblName.Location = New Point(244, 116)
        lblName.Name = "lblName"
        lblName.Size = New Size(73, 37)
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
        btnPrint.FillColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        btnPrint.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnPrint.ForeColor = Color.White
        btnPrint.Location = New Point(296, 403)
        btnPrint.Margin = New Padding(3, 2, 3, 2)
        btnPrint.Name = "btnPrint"
        btnPrint.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        btnPrint.Size = New Size(158, 24)
        btnPrint.TabIndex = 7
        btnPrint.Text = "PRINT"
        ' 
        ' lblMemberID
        ' 
        lblMemberID.AutoSize = True
        lblMemberID.BackColor = Color.Transparent
        lblMemberID.Font = New Font("Arial", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblMemberID.ForeColor = Color.Black
        lblMemberID.ImageAlign = ContentAlignment.MiddleRight
        lblMemberID.Location = New Point(701, 28)
        lblMemberID.Name = "lblMemberID"
        lblMemberID.RightToLeft = RightToLeft.Yes
        lblMemberID.Size = New Size(21, 22)
        lblMemberID.TabIndex = 8
        lblMemberID.Text = "0"
        lblMemberID.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pbBarcode
        ' 
        pbBarcode.BackColor = Color.White
        pbBarcode.Location = New Point(44, 314)
        pbBarcode.Margin = New Padding(3, 2, 3, 2)
        pbBarcode.Name = "pbBarcode"
        pbBarcode.Size = New Size(679, 85)
        pbBarcode.SizeMode = PictureBoxSizeMode.Zoom
        pbBarcode.TabIndex = 9
        pbBarcode.TabStop = False
        ' 
        ' IDPrinting
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        Controls.Add(pbBarcode)
        Controls.Add(pbIDphoto)
        Controls.Add(lblMemberID)
        Controls.Add(btnPrint)
        Controls.Add(lblName)
        Controls.Add(Guna2GradientPanel1)
        Margin = New Padding(3, 2, 3, 2)
        Name = "IDPrinting"
        Size = New Size(765, 457)
        CType(pbIDphoto, ComponentModel.ISupportInitialize).EndInit()
        CType(pbBarcode, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Guna2GradientPanel1 As Guna.UI2.WinForms.Guna2GradientPanel
    Friend WithEvents pbIDphoto As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents lblName As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents btnPrint As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblMemberID As Label
    Friend WithEvents pbBarcode As PictureBox

End Class
