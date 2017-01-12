<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFunctions
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
        Me.components = New System.ComponentModel.Container()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboBoxEdit1 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit2 = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ComboBoxEdit2 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextEdit3 = New DevExpress.XtraEditors.TextEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.RadRadioButton1 = New Telerik.WinControls.UI.RadRadioButton()
        Me.RadRadioButton2 = New Telerik.WinControls.UI.RadRadioButton()
        Me.TextEdit4 = New DevExpress.XtraEditors.TextEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RadRadioButton3 = New Telerik.WinControls.UI.RadRadioButton()
        Me.RadCheckBox1 = New Telerik.WinControls.UI.RadCheckBox()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ComboBoxEdit3 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.RadCheckBox2 = New Telerik.WinControls.UI.RadCheckBox()
        Me.FastColoredTextBox1 = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.RadRadioButton4 = New Telerik.WinControls.UI.RadRadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.VisualStudio2012LightTheme1 = New Telerik.WinControls.Themes.VisualStudio2012LightTheme()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.ComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadRadioButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadRadioButton2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadRadioButton3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadCheckBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadCheckBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FastColoredTextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.RadRadioButton4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListView1.Location = New System.Drawing.Point(35, 223)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(527, 197)
        Me.ListView1.TabIndex = 19
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
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(404, 152)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(158, 26)
        Me.Button1.TabIndex = 18
        Me.Button1.TabStop = False
        Me.Button1.Text = "Add"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'ComboBoxEdit1
        '
        Me.ComboBoxEdit1.Location = New System.Drawing.Point(240, 154)
        Me.ComboBoxEdit1.Name = "ComboBoxEdit1"
        Me.ComboBoxEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboBoxEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.ComboBoxEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEdit1.Properties.Sorted = True
        Me.ComboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ComboBoxEdit1.Size = New System.Drawing.Size(148, 22)
        Me.ComboBoxEdit1.TabIndex = 5
        '
        'TextEdit1
        '
        Me.TextEdit1.Location = New System.Drawing.Point(35, 45)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TextEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.TextEdit1.Properties.Mask.BeepOnError = True
        Me.TextEdit1.Properties.Mask.EditMask = "[A-Z][a-zA-Z]+"
        Me.TextEdit1.Properties.Mask.IgnoreMaskBlank = False
        Me.TextEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.TextEdit1.Properties.Mask.ShowPlaceHolders = False
        Me.TextEdit1.Size = New System.Drawing.Size(203, 22)
        Me.TextEdit1.TabIndex = 1
        '
        'TextEdit2
        '
        Me.TextEdit2.Location = New System.Drawing.Point(35, 154)
        Me.TextEdit2.Name = "TextEdit2"
        Me.TextEdit2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TextEdit2.Properties.Appearance.Options.UseBackColor = True
        Me.TextEdit2.Properties.Mask.BeepOnError = True
        Me.TextEdit2.Properties.Mask.EditMask = "[A-Z][a-zA-Z]+"
        Me.TextEdit2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.TextEdit2.Properties.Mask.ShowPlaceHolders = False
        Me.TextEdit2.Size = New System.Drawing.Size(188, 22)
        Me.TextEdit2.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(237, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 19)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(32, 134)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 19)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Field Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(32, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 19)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Name"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(337, 433)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(224, 27)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Create"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CheckBox1.Location = New System.Drawing.Point(35, 436)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(280, 23)
        Me.CheckBox1.TabIndex = 6
        Me.CheckBox1.Text = "Create method for this function in WSDL"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ComboBoxEdit2
        '
        Me.ComboBoxEdit2.Location = New System.Drawing.Point(263, 44)
        Me.ComboBoxEdit2.Name = "ComboBoxEdit2"
        Me.ComboBoxEdit2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboBoxEdit2.Properties.Appearance.Options.UseBackColor = True
        Me.ComboBoxEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEdit2.Properties.Sorted = True
        Me.ComboBoxEdit2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ComboBoxEdit2.Size = New System.Drawing.Size(189, 22)
        Me.ComboBoxEdit2.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(260, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 19)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Returns"
        '
        'TextEdit3
        '
        Me.TextEdit3.Location = New System.Drawing.Point(35, 99)
        Me.TextEdit3.Name = "TextEdit3"
        Me.TextEdit3.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TextEdit3.Properties.Appearance.Options.UseBackColor = True
        Me.TextEdit3.Properties.Mask.BeepOnError = True
        Me.TextEdit3.Properties.Mask.EditMask = "[A-Z][a-zA-Z ,.!&%#@=\[\](){}|':;]+"
        Me.TextEdit3.Properties.Mask.IgnoreMaskBlank = False
        Me.TextEdit3.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.TextEdit3.Properties.Mask.ShowPlaceHolders = False
        Me.TextEdit3.Size = New System.Drawing.Size(528, 22)
        Me.TextEdit3.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(33, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 19)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Description"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.Location = New System.Drawing.Point(37, 33)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(148, 23)
        Me.CheckBox2.TabIndex = 27
        Me.CheckBox2.Text = "Add database code"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'RadRadioButton1
        '
        Me.RadRadioButton1.Location = New System.Drawing.Point(37, 64)
        Me.RadRadioButton1.Name = "RadRadioButton1"
        Me.RadRadioButton1.Size = New System.Drawing.Size(56, 22)
        Me.RadRadioButton1.TabIndex = 28
        Me.RadRadioButton1.Text = "Insert"
        '
        'RadRadioButton2
        '
        Me.RadRadioButton2.Location = New System.Drawing.Point(37, 92)
        Me.RadRadioButton2.Name = "RadRadioButton2"
        Me.RadRadioButton2.Size = New System.Drawing.Size(61, 22)
        Me.RadRadioButton2.TabIndex = 29
        Me.RadRadioButton2.Text = "Delete"
        '
        'TextEdit4
        '
        Me.TextEdit4.Location = New System.Drawing.Point(90, 195)
        Me.TextEdit4.Name = "TextEdit4"
        Me.TextEdit4.Properties.Mask.BeepOnError = True
        Me.TextEdit4.Properties.Mask.EditMask = "[a-zA-Z0-9_-]+"
        Me.TextEdit4.Properties.Mask.IgnoreMaskBlank = False
        Me.TextEdit4.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.TextEdit4.Properties.Mask.ShowPlaceHolders = False
        Me.TextEdit4.Size = New System.Drawing.Size(112, 22)
        Me.TextEdit4.TabIndex = 30
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(40, 198)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 19)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Table"
        '
        'RadRadioButton3
        '
        Me.RadRadioButton3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.RadRadioButton3.Location = New System.Drawing.Point(37, 120)
        Me.RadRadioButton3.Name = "RadRadioButton3"
        Me.RadRadioButton3.Size = New System.Drawing.Size(58, 22)
        Me.RadRadioButton3.TabIndex = 32
        Me.RadRadioButton3.TabStop = True
        Me.RadRadioButton3.Text = "Select"
        Me.RadRadioButton3.ToggleState = Telerik.WinControls.Enumerations.ToggleState.[On]
        '
        'RadCheckBox1
        '
        Me.RadCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.RadCheckBox1.Location = New System.Drawing.Point(150, 103)
        Me.RadCheckBox1.Name = "RadCheckBox1"
        Me.RadCheckBox1.Size = New System.Drawing.Size(52, 22)
        Me.RadCheckBox1.TabIndex = 33
        Me.RadCheckBox1.Text = "Limit"
        Me.RadCheckBox1.ToggleState = Telerik.WinControls.Enumerations.ToggleState.[On]
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(219, 104)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(50, 22)
        Me.NumericUpDown1.TabIndex = 34
        Me.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(33, 229)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 19)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Unique"
        '
        'ComboBoxEdit3
        '
        Me.ComboBoxEdit3.Location = New System.Drawing.Point(90, 226)
        Me.ComboBoxEdit3.Name = "ComboBoxEdit3"
        Me.ComboBoxEdit3.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEdit3.Properties.Sorted = True
        Me.ComboBoxEdit3.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ComboBoxEdit3.Size = New System.Drawing.Size(148, 22)
        Me.ComboBoxEdit3.TabIndex = 36
        '
        'RadCheckBox2
        '
        Me.RadCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.RadCheckBox2.Enabled = False
        Me.RadCheckBox2.Location = New System.Drawing.Point(150, 64)
        Me.RadCheckBox2.Name = "RadCheckBox2"
        Me.RadCheckBox2.Size = New System.Drawing.Size(145, 22)
        Me.RadCheckBox2.TabIndex = 37
        Me.RadCheckBox2.Text = "Only changed fields"
        Me.RadCheckBox2.ToggleState = Telerik.WinControls.Enumerations.ToggleState.[On]
        '
        'FastColoredTextBox1
        '
        Me.FastColoredTextBox1.AutoCompleteBracketsList = New Char() {Global.Microsoft.VisualBasic.ChrW(40), Global.Microsoft.VisualBasic.ChrW(41), Global.Microsoft.VisualBasic.ChrW(123), Global.Microsoft.VisualBasic.ChrW(125), Global.Microsoft.VisualBasic.ChrW(91), Global.Microsoft.VisualBasic.ChrW(93), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(39), Global.Microsoft.VisualBasic.ChrW(39)}
        Me.FastColoredTextBox1.AutoScrollMinSize = New System.Drawing.Size(0, 18)
        Me.FastColoredTextBox1.BackBrush = Nothing
        Me.FastColoredTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FastColoredTextBox1.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2
        Me.FastColoredTextBox1.CharHeight = 18
        Me.FastColoredTextBox1.CharWidth = 10
        Me.FastColoredTextBox1.CommentPrefix = "#"
        Me.FastColoredTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FastColoredTextBox1.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.FastColoredTextBox1.IsReplaceMode = False
        Me.FastColoredTextBox1.Language = FastColoredTextBoxNS.Language.PHP
        Me.FastColoredTextBox1.LeftBracket = Global.Microsoft.VisualBasic.ChrW(40)
        Me.FastColoredTextBox1.LeftBracket2 = Global.Microsoft.VisualBasic.ChrW(123)
        Me.FastColoredTextBox1.Location = New System.Drawing.Point(22, 299)
        Me.FastColoredTextBox1.Name = "FastColoredTextBox1"
        Me.FastColoredTextBox1.Paddings = New System.Windows.Forms.Padding(0)
        Me.FastColoredTextBox1.RightBracket = Global.Microsoft.VisualBasic.ChrW(41)
        Me.FastColoredTextBox1.RightBracket2 = Global.Microsoft.VisualBasic.ChrW(125)
        Me.FastColoredTextBox1.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FastColoredTextBox1.ShowFoldingLines = True
        Me.FastColoredTextBox1.Size = New System.Drawing.Size(318, 127)
        Me.FastColoredTextBox1.TabIndex = 38
        Me.FastColoredTextBox1.WordWrap = True
        Me.FastColoredTextBox1.Zoom = 100
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RadGroupBox1.Controls.Add(Me.RadRadioButton4)
        Me.RadGroupBox1.Controls.Add(Me.Label6)
        Me.RadGroupBox1.Controls.Add(Me.CheckBox2)
        Me.RadGroupBox1.Controls.Add(Me.FastColoredTextBox1)
        Me.RadGroupBox1.Controls.Add(Me.RadRadioButton1)
        Me.RadGroupBox1.Controls.Add(Me.RadCheckBox2)
        Me.RadGroupBox1.Controls.Add(Me.RadRadioButton2)
        Me.RadGroupBox1.Controls.Add(Me.ComboBoxEdit3)
        Me.RadGroupBox1.Controls.Add(Me.TextEdit4)
        Me.RadGroupBox1.Controls.Add(Me.Label8)
        Me.RadGroupBox1.Controls.Add(Me.Label7)
        Me.RadGroupBox1.Controls.Add(Me.NumericUpDown1)
        Me.RadGroupBox1.Controls.Add(Me.RadRadioButton3)
        Me.RadGroupBox1.Controls.Add(Me.RadCheckBox1)
        Me.RadGroupBox1.HeaderText = "Database"
        Me.RadGroupBox1.Location = New System.Drawing.Point(595, 12)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(358, 448)
        Me.RadGroupBox1.TabIndex = 39
        Me.RadGroupBox1.Text = "Database"
        Me.RadGroupBox1.ThemeName = "TelerikMetroBlue"
        '
        'RadRadioButton4
        '
        Me.RadRadioButton4.Location = New System.Drawing.Point(38, 147)
        Me.RadRadioButton4.Name = "RadRadioButton4"
        Me.RadRadioButton4.Size = New System.Drawing.Size(67, 22)
        Me.RadRadioButton4.TabIndex = 40
        Me.RadRadioButton4.Text = "Update"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 279)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 19)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "Generated SQL"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(33, 200)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 19)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "Parameter List"
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.NumericUpDown2.Location = New System.Drawing.Point(469, 44)
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(91, 22)
        Me.NumericUpDown2.TabIndex = 42
        Me.NumericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(472, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 19)
        Me.Label10.TabIndex = 43
        Me.Label10.Text = "Auth Level"
        '
        'frmFunctions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(983, 487)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.NumericUpDown2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextEdit3)
        Me.Controls.Add(Me.ComboBoxEdit2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextEdit1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.ComboBoxEdit1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextEdit2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFunctions"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Function / Method"
        Me.ThemeName = "VisualStudio2012Light"
        CType(Me.ComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadRadioButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadRadioButton2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadRadioButton3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadCheckBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadCheckBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FastColoredTextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.RadRadioButton4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ComboBoxEdit1 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBoxEdit2 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextEdit3 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents RadRadioButton1 As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents RadRadioButton2 As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents TextEdit4 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents RadRadioButton3 As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents RadCheckBox1 As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxEdit3 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents RadCheckBox2 As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents FastColoredTextBox1 As FastColoredTextBoxNS.FastColoredTextBox
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents VisualStudio2012LightTheme1 As Telerik.WinControls.Themes.VisualStudio2012LightTheme
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents RadRadioButton4 As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
