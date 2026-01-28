<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewID
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
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        pbFrontID = New PictureBox()
        btnClose = New Guna.UI2.WinForms.Guna2Button()
        pbBackID = New PictureBox()
        Label7 = New Label()
        tbIdentificationNumber = New Guna.UI2.WinForms.Guna2TextBox()
        CType(pbFrontID, ComponentModel.ISupportInitialize).BeginInit()
        CType(pbBackID, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pbFrontID
        ' 
        pbFrontID.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pbFrontID.Location = New Point(31, 94)
        pbFrontID.Name = "pbFrontID"
        pbFrontID.Size = New Size(438, 392)
        pbFrontID.SizeMode = PictureBoxSizeMode.StretchImage
        pbFrontID.TabIndex = 0
        pbFrontID.TabStop = False
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnClose.BackColor = Color.Transparent
        btnClose.CustomizableEdges = CustomizableEdges5
        btnClose.DisabledState.BorderColor = Color.DarkGray
        btnClose.DisabledState.CustomBorderColor = Color.DarkGray
        btnClose.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnClose.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnClose.FillColor = Color.Red
        btnClose.Font = New Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnClose.ForeColor = SystemColors.Window
        btnClose.Location = New Point(835, 512)
        btnClose.Name = "btnClose"
        btnClose.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        btnClose.Size = New Size(142, 37)
        btnClose.TabIndex = 83
        btnClose.Text = "Close"
        ' 
        ' pbBackID
        ' 
        pbBackID.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pbBackID.Location = New Point(539, 94)
        pbBackID.Name = "pbBackID"
        pbBackID.Size = New Size(438, 392)
        pbBackID.SizeMode = PictureBoxSizeMode.StretchImage
        pbBackID.TabIndex = 84
        pbBackID.TabStop = False
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.Black
        Label7.Location = New Point(31, 36)
        Label7.Name = "Label7"
        Label7.Size = New Size(227, 46)
        Label7.TabIndex = 85
        Label7.Text = "Identification Number:" & vbCrLf & " "
        ' 
        ' tbIdentificationNumber
        ' 
        tbIdentificationNumber.AutoValidate = AutoValidate.Disable
        tbIdentificationNumber.CustomizableEdges = CustomizableEdges7
        tbIdentificationNumber.DefaultText = ""
        tbIdentificationNumber.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        tbIdentificationNumber.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        tbIdentificationNumber.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        tbIdentificationNumber.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        tbIdentificationNumber.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        tbIdentificationNumber.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        tbIdentificationNumber.ForeColor = Color.Black
        tbIdentificationNumber.HideSelection = False
        tbIdentificationNumber.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        tbIdentificationNumber.Location = New Point(256, 24)
        tbIdentificationNumber.Margin = New Padding(5, 7, 5, 7)
        tbIdentificationNumber.Name = "tbIdentificationNumber"
        tbIdentificationNumber.PlaceholderText = ""
        tbIdentificationNumber.ReadOnly = True
        tbIdentificationNumber.SelectedText = ""
        tbIdentificationNumber.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        tbIdentificationNumber.Size = New Size(381, 48)
        tbIdentificationNumber.TabIndex = 86
        ' 
        ' ViewID
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(tbIdentificationNumber)
        Controls.Add(Label7)
        Controls.Add(pbBackID)
        Controls.Add(btnClose)
        Controls.Add(pbFrontID)
        Name = "ViewID"
        Size = New Size(1001, 564)
        CType(pbFrontID, ComponentModel.ISupportInitialize).EndInit()
        CType(pbBackID, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents pbFrontID As PictureBox
    Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pbBackID As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents tbIdentificationNumber As Guna.UI2.WinForms.Guna2TextBox

End Class
