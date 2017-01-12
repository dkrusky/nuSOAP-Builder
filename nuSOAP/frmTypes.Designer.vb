<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTypes
    Inherits Telerik.WinControls.UI.RadForm

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
        Me.ToolWindow1 = New Telerik.WinControls.UI.Docking.ToolWindow()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit2 = New DevExpress.XtraEditors.TextEdit()
        Me.ComboBoxEdit1 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolWindow1
        '
        Me.ToolWindow1.Caption = Nothing
        Me.ToolWindow1.Location = New System.Drawing.Point(1, 26)
        Me.ToolWindow1.Name = "ToolWindow1"
        Me.ToolWindow1.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked
        Me.ToolWindow1.Size = New System.Drawing.Size(198, 382)
        Me.ToolWindow1.Text = "ToolWindow1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(32, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(32, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Field Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(237, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 19)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Type"
        '
        'TextEdit1
        '
        Me.TextEdit1.Location = New System.Drawing.Point(35, 44)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TextEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.TextEdit1.Properties.Mask.BeepOnError = True
        Me.TextEdit1.Properties.Mask.EditMask = "[A-Z][a-zA-Z]+"
        Me.TextEdit1.Properties.Mask.IgnoreMaskBlank = False
        Me.TextEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.TextEdit1.Properties.Mask.ShowPlaceHolders = False
        Me.TextEdit1.Size = New System.Drawing.Size(282, 22)
        Me.TextEdit1.TabIndex = 1
        '
        'TextEdit2
        '
        Me.TextEdit2.Location = New System.Drawing.Point(35, 99)
        Me.TextEdit2.Name = "TextEdit2"
        Me.TextEdit2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TextEdit2.Properties.Appearance.Options.UseBackColor = True
        Me.TextEdit2.Properties.Mask.BeepOnError = True
        Me.TextEdit2.Properties.Mask.EditMask = "[A-Z][a-zA-Z]+"
        Me.TextEdit2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.TextEdit2.Properties.Mask.ShowPlaceHolders = False
        Me.TextEdit2.Size = New System.Drawing.Size(188, 22)
        Me.TextEdit2.TabIndex = 2
        '
        'ComboBoxEdit1
        '
        Me.ComboBoxEdit1.Location = New System.Drawing.Point(240, 99)
        Me.ComboBoxEdit1.Name = "ComboBoxEdit1"
        Me.ComboBoxEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboBoxEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.ComboBoxEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEdit1.Properties.Sorted = True
        Me.ComboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ComboBoxEdit1.Size = New System.Drawing.Size(148, 22)
        Me.ComboBoxEdit1.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(419, 97)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(143, 26)
        Me.Button1.TabIndex = 7
        Me.Button1.TabStop = False
        Me.Button1.Text = "Add"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListView1.Location = New System.Drawing.Point(35, 151)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(527, 172)
        Me.ListView1.TabIndex = 8
        Me.ListView1.TabStop = False
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Name"
        Me.ColumnHeader1.Width = 170
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Type"
        Me.ColumnHeader2.Width = 170
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CheckBox1.Location = New System.Drawing.Point(35, 348)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(229, 23)
        Me.CheckBox1.TabIndex = 4
        Me.CheckBox1.Text = "Create an array type of this type"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(335, 344)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(227, 26)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Create"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'frmTypes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(598, 400)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ComboBoxEdit1)
        Me.Controls.Add(Me.TextEdit1)
        Me.Controls.Add(Me.TextEdit2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTypes"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Type"
        Me.ThemeName = "VisualStudio2012Light"
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolWindow1 As Telerik.WinControls.UI.Docking.ToolWindow
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ComboBoxEdit1 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
