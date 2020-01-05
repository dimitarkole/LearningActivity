<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class reference_universa_gpa
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(reference_universa_gpa))
        Me.cmbProfilId = New System.Windows.Forms.ComboBox()
        Me.dgvC5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvC6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.chlSubject = New System.Windows.Forms.CheckedListBox()
        Me.dgvC4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvC3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvprofil = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvPredmet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvtype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvC2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cmbSortBy = New System.Windows.Forms.GroupBox()
        Me.rbtnProfile = New System.Windows.Forms.RadioButton()
        Me.rbtnClass = New System.Windows.Forms.RadioButton()
        Me.rbtnparal = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.rbtntype = New System.Windows.Forms.RadioButton()
        Me.rbtnsubject = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chltype = New System.Windows.Forms.CheckedListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbYearString = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbClass = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbYear = New System.Windows.Forms.ComboBox()
        Me.cmbParal = New System.Windows.Forms.ComboBox()
        Me.cmbProfil = New System.Windows.Forms.ComboBox()
        Me.dgvParalelka = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvklas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnchart = New System.Windows.Forms.Button()
        Me.kod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnExselNewFile = New System.Windows.Forms.Button()
        Me.btnWordNewFIle = New System.Windows.Forms.Button()
        Me.btnExselFIle = New System.Windows.Forms.Button()
        Me.prb1 = New System.Windows.Forms.ProgressBar()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dgvGodina = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.cmbSortBy.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbProfilId
        '
        Me.cmbProfilId.FormattingEnabled = True
        Me.cmbProfilId.Items.AddRange(New Object() {"-1"})
        Me.cmbProfilId.Location = New System.Drawing.Point(372, 108)
        Me.cmbProfilId.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbProfilId.Name = "cmbProfilId"
        Me.cmbProfilId.Size = New System.Drawing.Size(47, 24)
        Me.cmbProfilId.TabIndex = 28
        Me.cmbProfilId.Text = "-1"
        Me.cmbProfilId.Visible = False
        '
        'dgvC5
        '
        Me.dgvC5.HeaderText = "Брой петици"
        Me.dgvC5.Name = "dgvC5"
        Me.dgvC5.ReadOnly = True
        '
        'dgvC6
        '
        Me.dgvC6.HeaderText = "Брой шестици"
        Me.dgvC6.Name = "dgvC6"
        Me.dgvC6.ReadOnly = True
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.Location = New System.Drawing.Point(15, 471)
        Me.Chart1.Margin = New System.Windows.Forms.Padding(4)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(1693, 369)
        Me.Chart1.TabIndex = 74
        Me.Chart1.Text = "Chart1"
        '
        'chlSubject
        '
        Me.chlSubject.FormattingEnabled = True
        Me.chlSubject.Location = New System.Drawing.Point(125, 143)
        Me.chlSubject.Margin = New System.Windows.Forms.Padding(4)
        Me.chlSubject.Name = "chlSubject"
        Me.chlSubject.Size = New System.Drawing.Size(237, 72)
        Me.chlSubject.TabIndex = 66
        '
        'dgvC4
        '
        Me.dgvC4.HeaderText = "Брой четворки"
        Me.dgvC4.Name = "dgvC4"
        Me.dgvC4.ReadOnly = True
        '
        'dgvC3
        '
        Me.dgvC3.HeaderText = "Брой тройки"
        Me.dgvC3.Name = "dgvC3"
        Me.dgvC3.ReadOnly = True
        '
        'dgvprofil
        '
        Me.dgvprofil.HeaderText = "Профил"
        Me.dgvprofil.Name = "dgvprofil"
        Me.dgvprofil.ReadOnly = True
        '
        'dgvPredmet
        '
        Me.dgvPredmet.HeaderText = "Предмет"
        Me.dgvPredmet.Name = "dgvPredmet"
        Me.dgvPredmet.ReadOnly = True
        '
        'dgvtype
        '
        Me.dgvtype.HeaderText = "Вид оценка"
        Me.dgvtype.Name = "dgvtype"
        Me.dgvtype.ReadOnly = True
        '
        'dgvC2
        '
        Me.dgvC2.HeaderText = "Брой двойки"
        Me.dgvC2.Name = "dgvC2"
        Me.dgvC2.ReadOnly = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(5, 6)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(407, 288)
        Me.TabControl1.TabIndex = 75
        '
        'TabPage1
        '
        Me.TabPage1.AutoScroll = True
        Me.TabPage1.Controls.Add(Me.cmbSortBy)
        Me.TabPage1.Controls.Add(Me.GroupBox5)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.cmbProfilId)
        Me.TabPage1.Controls.Add(Me.chltype)
        Me.TabPage1.Controls.Add(Me.chlSubject)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.cmbYearString)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.cmbClass)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.cmbYear)
        Me.TabPage1.Controls.Add(Me.cmbParal)
        Me.TabPage1.Controls.Add(Me.cmbProfil)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Size = New System.Drawing.Size(399, 259)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Избор на критерии"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cmbSortBy
        '
        Me.cmbSortBy.Controls.Add(Me.rbtnProfile)
        Me.cmbSortBy.Controls.Add(Me.rbtnClass)
        Me.cmbSortBy.Controls.Add(Me.rbtnparal)
        Me.cmbSortBy.Location = New System.Drawing.Point(15, 386)
        Me.cmbSortBy.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSortBy.Name = "cmbSortBy"
        Me.cmbSortBy.Padding = New System.Windows.Forms.Padding(4)
        Me.cmbSortBy.Size = New System.Drawing.Size(349, 62)
        Me.cmbSortBy.TabIndex = 71
        Me.cmbSortBy.TabStop = False
        Me.cmbSortBy.Text = "Групиране по:"
        '
        'rbtnProfile
        '
        Me.rbtnProfile.AutoSize = True
        Me.rbtnProfile.Location = New System.Drawing.Point(247, 23)
        Me.rbtnProfile.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnProfile.Name = "rbtnProfile"
        Me.rbtnProfile.Size = New System.Drawing.Size(82, 21)
        Me.rbtnProfile.TabIndex = 0
        Me.rbtnProfile.TabStop = True
        Me.rbtnProfile.Text = "Профил"
        Me.rbtnProfile.UseVisualStyleBackColor = True
        '
        'rbtnClass
        '
        Me.rbtnClass.AutoSize = True
        Me.rbtnClass.Location = New System.Drawing.Point(148, 23)
        Me.rbtnClass.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnClass.Name = "rbtnClass"
        Me.rbtnClass.Size = New System.Drawing.Size(61, 21)
        Me.rbtnClass.TabIndex = 0
        Me.rbtnClass.TabStop = True
        Me.rbtnClass.Text = "Клас"
        Me.rbtnClass.UseVisualStyleBackColor = True
        '
        'rbtnparal
        '
        Me.rbtnparal.AutoSize = True
        Me.rbtnparal.Checked = True
        Me.rbtnparal.Location = New System.Drawing.Point(8, 23)
        Me.rbtnparal.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnparal.Name = "rbtnparal"
        Me.rbtnparal.Size = New System.Drawing.Size(102, 21)
        Me.rbtnparal.TabIndex = 0
        Me.rbtnparal.TabStop = True
        Me.rbtnparal.Text = "Паралелка"
        Me.rbtnparal.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.rbtntype)
        Me.GroupBox5.Controls.Add(Me.rbtnsubject)
        Me.GroupBox5.Location = New System.Drawing.Point(15, 318)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Size = New System.Drawing.Size(349, 62)
        Me.GroupBox5.TabIndex = 71
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Съпоставяне на:"
        '
        'rbtntype
        '
        Me.rbtntype.AutoSize = True
        Me.rbtntype.Location = New System.Drawing.Point(200, 23)
        Me.rbtntype.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtntype.Name = "rbtntype"
        Me.rbtntype.Size = New System.Drawing.Size(105, 21)
        Me.rbtntype.TabIndex = 0
        Me.rbtntype.TabStop = True
        Me.rbtntype.Text = "Вид оценка"
        Me.rbtntype.UseVisualStyleBackColor = True
        '
        'rbtnsubject
        '
        Me.rbtnsubject.AutoSize = True
        Me.rbtnsubject.Checked = True
        Me.rbtnsubject.Location = New System.Drawing.Point(61, 23)
        Me.rbtnsubject.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnsubject.Name = "rbtnsubject"
        Me.rbtnsubject.Size = New System.Drawing.Size(87, 21)
        Me.rbtnsubject.TabIndex = 0
        Me.rbtnsubject.TabStop = True
        Me.rbtnsubject.Text = "Предмет"
        Me.rbtnsubject.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 230)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 17)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Вид оценка:"
        '
        'chltype
        '
        Me.chltype.FormattingEnabled = True
        Me.chltype.Location = New System.Drawing.Point(125, 231)
        Me.chltype.Margin = New System.Windows.Forms.Padding(4)
        Me.chltype.Name = "chltype"
        Me.chltype.Size = New System.Drawing.Size(237, 72)
        Me.chltype.TabIndex = 66
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 17)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Година:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 48)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 17)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Клас:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 112)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 17)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Профил:"
        '
        'cmbYearString
        '
        Me.cmbYearString.FormattingEnabled = True
        Me.cmbYearString.Location = New System.Drawing.Point(125, 12)
        Me.cmbYearString.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbYearString.Name = "cmbYearString"
        Me.cmbYearString.Size = New System.Drawing.Size(239, 24)
        Me.cmbYearString.TabIndex = 19
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 80)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 17)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Паралелка:"
        '
        'cmbClass
        '
        Me.cmbClass.FormattingEnabled = True
        Me.cmbClass.Items.AddRange(New Object() {"Всички класове"})
        Me.cmbClass.Location = New System.Drawing.Point(125, 44)
        Me.cmbClass.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbClass.Name = "cmbClass"
        Me.cmbClass.Size = New System.Drawing.Size(239, 24)
        Me.cmbClass.TabIndex = 20
        Me.cmbClass.Text = "Всички класове"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 146)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 17)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Предмет:"
        '
        'cmbYear
        '
        Me.cmbYear.FormattingEnabled = True
        Me.cmbYear.Location = New System.Drawing.Point(372, 12)
        Me.cmbYear.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.Size = New System.Drawing.Size(93, 24)
        Me.cmbYear.TabIndex = 23
        Me.cmbYear.Visible = False
        '
        'cmbParal
        '
        Me.cmbParal.FormattingEnabled = True
        Me.cmbParal.Items.AddRange(New Object() {"Всички паралелки"})
        Me.cmbParal.Location = New System.Drawing.Point(125, 76)
        Me.cmbParal.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbParal.Name = "cmbParal"
        Me.cmbParal.Size = New System.Drawing.Size(239, 24)
        Me.cmbParal.TabIndex = 19
        Me.cmbParal.Text = "Всички паралелки"
        '
        'cmbProfil
        '
        Me.cmbProfil.FormattingEnabled = True
        Me.cmbProfil.Items.AddRange(New Object() {"Всички профили"})
        Me.cmbProfil.Location = New System.Drawing.Point(125, 108)
        Me.cmbProfil.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbProfil.Name = "cmbProfil"
        Me.cmbProfil.Size = New System.Drawing.Size(239, 24)
        Me.cmbProfil.TabIndex = 20
        Me.cmbProfil.Text = "Всички профили"
        '
        'dgvParalelka
        '
        Me.dgvParalelka.HeaderText = "Паралелка"
        Me.dgvParalelka.Name = "dgvParalelka"
        Me.dgvParalelka.ReadOnly = True
        '
        'dgvklas
        '
        Me.dgvklas.HeaderText = "Клас"
        Me.dgvklas.Name = "dgvklas"
        Me.dgvklas.ReadOnly = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnchart)
        Me.GroupBox4.Location = New System.Drawing.Point(131, 303)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(281, 126)
        Me.GroupBox4.TabIndex = 72
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Покажи резултата в програмата"
        '
        'btnchart
        '
        Me.btnchart.Location = New System.Drawing.Point(59, 46)
        Me.btnchart.Margin = New System.Windows.Forms.Padding(4)
        Me.btnchart.Name = "btnchart"
        Me.btnchart.Size = New System.Drawing.Size(163, 53)
        Me.btnchart.TabIndex = 8
        Me.btnchart.Text = "Изчисли резултa"
        Me.btnchart.UseVisualStyleBackColor = True
        '
        'kod
        '
        Me.kod.HeaderText = "Код"
        Me.kod.Name = "kod"
        Me.kod.ReadOnly = True
        '
        'btnExselNewFile
        '
        Me.btnExselNewFile.Location = New System.Drawing.Point(20, 46)
        Me.btnExselNewFile.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExselNewFile.Name = "btnExselNewFile"
        Me.btnExselNewFile.Size = New System.Drawing.Size(163, 53)
        Me.btnExselNewFile.TabIndex = 7
        Me.btnExselNewFile.Text = "Нов файл"
        Me.btnExselNewFile.UseVisualStyleBackColor = True
        '
        'btnWordNewFIle
        '
        Me.btnWordNewFIle.Location = New System.Drawing.Point(52, 46)
        Me.btnWordNewFIle.Margin = New System.Windows.Forms.Padding(4)
        Me.btnWordNewFIle.Name = "btnWordNewFIle"
        Me.btnWordNewFIle.Size = New System.Drawing.Size(163, 53)
        Me.btnWordNewFIle.TabIndex = 7
        Me.btnWordNewFIle.Text = "Нов файл"
        Me.btnWordNewFIle.UseVisualStyleBackColor = True
        '
        'btnExselFIle
        '
        Me.btnExselFIle.Location = New System.Drawing.Point(217, 46)
        Me.btnExselFIle.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExselFIle.Name = "btnExselFIle"
        Me.btnExselFIle.Size = New System.Drawing.Size(163, 53)
        Me.btnExselFIle.TabIndex = 6
        Me.btnExselFIle.Text = "Съществуващ файл"
        Me.btnExselFIle.UseVisualStyleBackColor = True
        '
        'prb1
        '
        Me.prb1.Location = New System.Drawing.Point(15, 436)
        Me.prb1.Margin = New System.Windows.Forms.Padding(4)
        Me.prb1.Name = "prb1"
        Me.prb1.Size = New System.Drawing.Size(1781, 28)
        Me.prb1.TabIndex = 70
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnWordNewFIle)
        Me.GroupBox3.Location = New System.Drawing.Point(1185, 303)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(281, 126)
        Me.GroupBox3.TabIndex = 73
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Експортирай резултата в MS Word"
        '
        'dgvGodina
        '
        Me.dgvGodina.HeaderText = "Година"
        Me.dgvGodina.Name = "dgvGodina"
        Me.dgvGodina.ReadOnly = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnExselFIle)
        Me.GroupBox1.Controls.Add(Me.btnExselNewFile)
        Me.GroupBox1.Location = New System.Drawing.Point(584, 303)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(429, 121)
        Me.GroupBox1.TabIndex = 71
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Експортирай резултата в MS Excel"
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.kod, Me.dgvGodina, Me.dgvklas, Me.dgvParalelka, Me.dgvprofil, Me.dgvPredmet, Me.dgvtype, Me.dgvC2, Me.dgvC3, Me.dgvC4, Me.dgvC5, Me.dgvC6})
        Me.dgv1.Location = New System.Drawing.Point(420, 6)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(1376, 289)
        Me.dgv1.TabIndex = 69
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "helpHTML\HelpHTML.chm"
        Me.HelpProvider1.Tag = "F1"
        '
        'reference_universa_gpa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1805, 473)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.prb1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgv1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.HelpProvider1.SetHelpKeyword(Me, "Универсална справка")
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.HelpProvider1.SetHelpString(Me, "Универсална справка")
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(10, 10)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "reference_universa_gpa"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Универсална справка за среден успех през една година"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.cmbSortBy.ResumeLayout(False)
        Me.cmbSortBy.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbProfilId As System.Windows.Forms.ComboBox
    Friend WithEvents dgvC5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvC6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents chlSubject As System.Windows.Forms.CheckedListBox
    Friend WithEvents dgvC4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvC3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvprofil As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvPredmet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvtype As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvC2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents cmbSortBy As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnProfile As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnClass As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnparal As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtntype As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnsubject As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chltype As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbYearString As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbYear As System.Windows.Forms.ComboBox
    Friend WithEvents cmbParal As System.Windows.Forms.ComboBox
    Friend WithEvents cmbProfil As System.Windows.Forms.ComboBox
    Friend WithEvents dgvParalelka As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvklas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnchart As System.Windows.Forms.Button
    Friend WithEvents kod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnExselNewFile As System.Windows.Forms.Button
    Friend WithEvents btnWordNewFIle As System.Windows.Forms.Button
    Friend WithEvents btnExselFIle As System.Windows.Forms.Button
    Friend WithEvents prb1 As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvGodina As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Private WithEvents HelpProvider1 As HelpProvider
End Class
