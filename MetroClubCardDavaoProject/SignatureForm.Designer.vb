<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SignatureForm
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
        pbSignature = New Guna.UI2.WinForms.Guna2PictureBox()
        btnClear = New Guna.UI2.WinForms.Guna2Button()
        btnSubmit = New Guna.UI2.WinForms.Guna2Button()
        CType(pbSignature, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pbSignature
        ' 
        pbSignature.CustomizableEdges = CustomizableEdges1
        pbSignature.ImageRotate = 0F
        pbSignature.Location = New Point(12, 12)
        pbSignature.Name = "pbSignature"
        pbSignature.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        pbSignature.Size = New Size(776, 349)
        pbSignature.TabIndex = 0
        pbSignature.TabStop = False
        ' 
        ' btnClear
        ' 
        btnClear.CustomizableEdges = CustomizableEdges3
        btnClear.DisabledState.BorderColor = Color.DarkGray
        btnClear.DisabledState.CustomBorderColor = Color.DarkGray
        btnClear.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnClear.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnClear.FillColor = Color.Red
        btnClear.Font = New Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnClear.ForeColor = Color.White
        btnClear.Location = New Point(24, 382)
        btnClear.Name = "btnClear"
        btnClear.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        btnClear.Size = New Size(225, 56)
        btnClear.TabIndex = 1
        btnClear.Text = "CLEAR"
        ' 
        ' btnSubmit
        ' 
        btnSubmit.CustomizableEdges = CustomizableEdges5
        btnSubmit.DisabledState.BorderColor = Color.DarkGray
        btnSubmit.DisabledState.CustomBorderColor = Color.DarkGray
        btnSubmit.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnSubmit.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnSubmit.FillColor = Color.ForestGreen
        btnSubmit.Font = New Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnSubmit.ForeColor = Color.White
        btnSubmit.Location = New Point(534, 382)
        btnSubmit.Name = "btnSubmit"
        btnSubmit.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        btnSubmit.Size = New Size(225, 56)
        btnSubmit.TabIndex = 2
        btnSubmit.Text = "SUBMIT"
        ' 
        ' SignatureForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(btnSubmit)
        Controls.Add(btnClear)
        Controls.Add(pbSignature)
        Name = "SignatureForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "SIGNATURE"
        CType(pbSignature, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pbSignature As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents btnClear As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSubmit As Guna.UI2.WinForms.Guna2Button
End Class
