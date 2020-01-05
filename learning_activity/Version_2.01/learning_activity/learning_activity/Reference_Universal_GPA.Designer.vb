<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reference_Universal_GPA
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
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbProfilId = New System.Windows.Forms.ComboBox()
        Me.cmbTeachid = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbTeach = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.cmbYear = New System.Windows.Forms.ComboBox()
        Me.cmbProfil = New System.Windows.Forms.ComboBox()
        Me.cmbParal = New System.Windows.Forms.ComboBox()
        Me.cmbClass = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbYearString = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbTypeid = New System.Windows.Forms.ComboBox()
        Me.cmbSubjectId = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbSubject = New System.Windows.Forms.ComboBox()
        Me.btnchart = New System.Windows.Forms.Button()
        Me.cmbtype = New System.Windows.Forms.ComboBox()
        Me.Випуск = New System.Windows.Forms.Label()
        Me.cmbPodredba = New System.Windows.Forms.ComboBox()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.kod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvGodina = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvklas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvParalelka = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvprofil = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvPredmet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvteach = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvtype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvC2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvC3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvC4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvC5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvC6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnWordNewFIle = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnExselFIle = New System.Windows.Forms.Button()
        Me.btnExselNewFile = New System.Windows.Forms.Button()
        Me.prb1 = New System.Windows.Forms.ProgressBar()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbProfilId)
        Me.GroupBox2.Controls.Add(Me.cmbTeachid)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cmbTeach)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.ComboBox3)
        Me.GroupBox2.Controls.Add(Me.cmbYear)
        Me.GroupBox2.Controls.Add(Me.cmbProfil)
        Me.GroupBox2.Controls.Add(Me.cmbParal)
        Me.GroupBox2.Controls.Add(Me.cmbClass)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cmbYearString)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cmbTypeid)
        Me.GroupBox2.Controls.Add(Me.cmbSubjectId)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cmbSubject)
        Me.GroupBox2.Controls.Add(Me.btnchart)
        Me.GroupBox2.Controls.Add(Me.cmbtype)
        Me.GroupBox2.Controls.Add(Me.Випуск)
        Me.GroupBox2.Controls.Add(Me.cmbPodredba)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(292, 277)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Изчисляване на резултат"
        '
        'cmbProfilId
        '
        Me.cmbProfilId.FormattingEnabled = True
        Me.cmbProfilId.Items.AddRange(New Object() {"-1"})
        Me.cmbProfilId.Location = New System.Drawing.Point(283, 102)
        Me.cmbProfilId.Name = "cmbProfilId"
        Me.cmbProfilId.Size = New System.Drawing.Size(36, 21)
        Me.cmbProfilId.TabIndex = 28
        Me.cmbProfilId.Text = "-1"
        Me.cmbProfilId.Visible = False
        '
        'cmbTeachid
        '
        Me.cmbTeachid.FormattingEnabled = True
        Me.cmbTeachid.Items.AddRange(New Object() {"-1"})
        Me.cmbTeachid.Location = New System.Drawing.Point(283, 285)
        Me.cmbTeachid.Name = "cmbTeachid"
        Me.cmbTeachid.Size = New System.Drawing.Size(36, 21)
        Me.cmbTeachid.TabIndex = 28
        Me.cmbTeachid.Text = "-1"
        Me.cmbTeachid.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 158)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 13)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Вид оценка:"
        '
        'cmbTeach
        '
        Me.cmbTeach.FormattingEnabled = True
        Me.cmbTeach.Items.AddRange(New Object() {"Всички преподаватели"})
        Me.cmbTeach.Location = New System.Drawing.Point(98, 283)
        Me.cmbTeach.Name = "cmbTeach"
        Me.cmbTeach.Size = New System.Drawing.Size(179, 21)
        Me.cmbTeach.TabIndex = 27
        Me.cmbTeach.Text = "Всички преподаватели"
        Me.cmbTeach.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 210)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Сортирай по:"
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {"Без сортиране", "Клас", "Паралелка", "Профил", "Среден успех"})
        Me.ComboBox3.Location = New System.Drawing.Point(98, 207)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(179, 21)
        Me.ComboBox3.TabIndex = 24
        Me.ComboBox3.Text = "Без сортиране"
        '
        'cmbYear
        '
        Me.cmbYear.FormattingEnabled = True
        Me.cmbYear.Location = New System.Drawing.Point(283, 24)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.Size = New System.Drawing.Size(71, 21)
        Me.cmbYear.TabIndex = 23
        Me.cmbYear.Visible = False
        '
        'cmbProfil
        '
        Me.cmbProfil.FormattingEnabled = True
        Me.cmbProfil.Items.AddRange(New Object() {"Всички профили"})
        Me.cmbProfil.Location = New System.Drawing.Point(98, 102)
        Me.cmbProfil.Name = "cmbProfil"
        Me.cmbProfil.Size = New System.Drawing.Size(180, 21)
        Me.cmbProfil.TabIndex = 20
        Me.cmbProfil.Text = "Всички профили"
        '
        'cmbParal
        '
        Me.cmbParal.FormattingEnabled = True
        Me.cmbParal.Items.AddRange(New Object() {"Всички паралелки"})
        Me.cmbParal.Location = New System.Drawing.Point(98, 76)
        Me.cmbParal.Name = "cmbParal"
        Me.cmbParal.Size = New System.Drawing.Size(180, 21)
        Me.cmbParal.TabIndex = 19
        Me.cmbParal.Text = "Всички паралелки"
        '
        'cmbClass
        '
        Me.cmbClass.FormattingEnabled = True
        Me.cmbClass.Items.AddRange(New Object() {"Всички класове"})
        Me.cmbClass.Location = New System.Drawing.Point(98, 50)
        Me.cmbClass.Name = "cmbClass"
        Me.cmbClass.Size = New System.Drawing.Size(180, 21)
        Me.cmbClass.TabIndex = 20
        Me.cmbClass.Text = "Всички класове"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Паралелка:"
        '
        'cmbYearString
        '
        Me.cmbYearString.FormattingEnabled = True
        Me.cmbYearString.Location = New System.Drawing.Point(98, 24)
        Me.cmbYearString.Name = "cmbYearString"
        Me.cmbYearString.Size = New System.Drawing.Size(180, 21)
        Me.cmbYearString.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Профил:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Година:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Клас:"
        '
        'cmbTypeid
        '
        Me.cmbTypeid.FormattingEnabled = True
        Me.cmbTypeid.Items.AddRange(New Object() {"-1"})
        Me.cmbTypeid.Location = New System.Drawing.Point(283, 159)
        Me.cmbTypeid.Name = "cmbTypeid"
        Me.cmbTypeid.Size = New System.Drawing.Size(36, 21)
        Me.cmbTypeid.TabIndex = 15
        Me.cmbTypeid.Text = "-1"
        Me.cmbTypeid.Visible = False
        '
        'cmbSubjectId
        '
        Me.cmbSubjectId.FormattingEnabled = True
        Me.cmbSubjectId.Items.AddRange(New Object() {"-1"})
        Me.cmbSubjectId.Location = New System.Drawing.Point(283, 128)
        Me.cmbSubjectId.Name = "cmbSubjectId"
        Me.cmbSubjectId.Size = New System.Drawing.Size(36, 21)
        Me.cmbSubjectId.TabIndex = 15
        Me.cmbSubjectId.Text = "-1"
        Me.cmbSubjectId.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Предмет:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 285)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Преподавател:"
        Me.Label2.Visible = False
        '
        'cmbSubject
        '
        Me.cmbSubject.FormattingEnabled = True
        Me.cmbSubject.Items.AddRange(New Object() {"Всички предмети"})
        Me.cmbSubject.Location = New System.Drawing.Point(98, 128)
        Me.cmbSubject.Name = "cmbSubject"
        Me.cmbSubject.Size = New System.Drawing.Size(179, 21)
        Me.cmbSubject.TabIndex = 14
        Me.cmbSubject.Text = "Всички предмети"
        '
        'btnchart
        '
        Me.btnchart.Location = New System.Drawing.Point(121, 231)
        Me.btnchart.Name = "btnchart"
        Me.btnchart.Size = New System.Drawing.Size(122, 43)
        Me.btnchart.TabIndex = 8
        Me.btnchart.Text = "Изчисли резултa"
        Me.btnchart.UseVisualStyleBackColor = True
        '
        'cmbtype
        '
        Me.cmbtype.FormattingEnabled = True
        Me.cmbtype.Items.AddRange(New Object() {"Всички видове"})
        Me.cmbtype.Location = New System.Drawing.Point(98, 155)
        Me.cmbtype.Name = "cmbtype"
        Me.cmbtype.Size = New System.Drawing.Size(179, 21)
        Me.cmbtype.TabIndex = 14
        Me.cmbtype.Text = "Всички видове"
        '
        'Випуск
        '
        Me.Випуск.AutoSize = True
        Me.Випуск.Location = New System.Drawing.Point(10, 184)
        Me.Випуск.Name = "Випуск"
        Me.Випуск.Size = New System.Drawing.Size(68, 13)
        Me.Випуск.TabIndex = 12
        Me.Випуск.Text = "Подреди от:"
        '
        'cmbPodredba
        '
        Me.cmbPodredba.FormattingEnabled = True
        Me.cmbPodredba.Items.AddRange(New Object() {"Минимално към максималнно", "Максималнно към минимално"})
        Me.cmbPodredba.Location = New System.Drawing.Point(98, 181)
        Me.cmbPodredba.Name = "cmbPodredba"
        Me.cmbPodredba.Size = New System.Drawing.Size(179, 21)
        Me.cmbPodredba.TabIndex = 10
        Me.cmbPodredba.Text = "Минимално към максималнно"
        '
        'dgv1
        '
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.kod, Me.dgvGodina, Me.dgvklas, Me.dgvParalelka, Me.dgvprofil, Me.dgvPredmet, Me.dgvteach, Me.dgvtype, Me.dgvC2, Me.dgvC3, Me.dgvC4, Me.dgvC5, Me.dgvC6})
        Me.dgv1.Location = New System.Drawing.Point(310, 12)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.Size = New System.Drawing.Size(1032, 277)
        Me.dgv1.TabIndex = 34
        '
        'kod
        '
        Me.kod.HeaderText = "Код"
        Me.kod.Name = "kod"
        '
        'dgvGodina
        '
        Me.dgvGodina.HeaderText = "Година"
        Me.dgvGodina.Name = "dgvGodina"
        '
        'dgvklas
        '
        Me.dgvklas.HeaderText = "Клас"
        Me.dgvklas.Name = "dgvklas"
        '
        'dgvParalelka
        '
        Me.dgvParalelka.HeaderText = "Паралелка"
        Me.dgvParalelka.Name = "dgvParalelka"
        '
        'dgvprofil
        '
        Me.dgvprofil.HeaderText = "Профил"
        Me.dgvprofil.Name = "dgvprofil"
        '
        'dgvPredmet
        '
        Me.dgvPredmet.HeaderText = "Предмет"
        Me.dgvPredmet.Name = "dgvPredmet"
        '
        'dgvteach
        '
        Me.dgvteach.HeaderText = "Преподавател"
        Me.dgvteach.Name = "dgvteach"
        '
        'dgvtype
        '
        Me.dgvtype.HeaderText = "Вид оценка"
        Me.dgvtype.Name = "dgvtype"
        '
        'dgvC2
        '
        Me.dgvC2.HeaderText = "Брой двойки"
        Me.dgvC2.Name = "dgvC2"
        '
        'dgvC3
        '
        Me.dgvC3.HeaderText = "Брой тройки"
        Me.dgvC3.Name = "dgvC3"
        '
        'dgvC4
        '
        Me.dgvC4.HeaderText = "Брой четворки"
        Me.dgvC4.Name = "dgvC4"
        '
        'dgvC5
        '
        Me.dgvC5.HeaderText = "Брой петици"
        Me.dgvC5.Name = "dgvC5"
        '
        'dgvC6
        '
        Me.dgvC6.HeaderText = "Брой шестици"
        Me.dgvC6.Name = "dgvC6"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(608, 336)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(722, 92)
        Me.TextBox1.TabIndex = 35
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnWordNewFIle)
        Me.GroupBox3.Location = New System.Drawing.Point(389, 328)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(211, 102)
        Me.GroupBox3.TabIndex = 58
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Експортирай резултата в MS Word"
        '
        'btnWordNewFIle
        '
        Me.btnWordNewFIle.Location = New System.Drawing.Point(39, 37)
        Me.btnWordNewFIle.Name = "btnWordNewFIle"
        Me.btnWordNewFIle.Size = New System.Drawing.Size(122, 43)
        Me.btnWordNewFIle.TabIndex = 7
        Me.btnWordNewFIle.Text = "Нов файл"
        Me.btnWordNewFIle.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnExselFIle)
        Me.GroupBox1.Controls.Add(Me.btnExselNewFile)
        Me.GroupBox1.Location = New System.Drawing.Point(61, 328)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(322, 98)
        Me.GroupBox1.TabIndex = 57
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Експортирай резултата в MS Excel"
        '
        'btnExselFIle
        '
        Me.btnExselFIle.Location = New System.Drawing.Point(163, 37)
        Me.btnExselFIle.Name = "btnExselFIle"
        Me.btnExselFIle.Size = New System.Drawing.Size(122, 43)
        Me.btnExselFIle.TabIndex = 6
        Me.btnExselFIle.Text = "Съществуващ файл"
        Me.btnExselFIle.UseVisualStyleBackColor = True
        '
        'btnExselNewFile
        '
        Me.btnExselNewFile.Location = New System.Drawing.Point(15, 37)
        Me.btnExselNewFile.Name = "btnExselNewFile"
        Me.btnExselNewFile.Size = New System.Drawing.Size(122, 43)
        Me.btnExselNewFile.TabIndex = 7
        Me.btnExselNewFile.Text = "Нов файл"
        Me.btnExselNewFile.UseVisualStyleBackColor = True
        '
        'prb1
        '
        Me.prb1.Location = New System.Drawing.Point(6, 436)
        Me.prb1.Name = "prb1"
        Me.prb1.Size = New System.Drawing.Size(1336, 23)
        Me.prb1.TabIndex = 56
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(6, 471)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Size = New System.Drawing.Size(1336, 391)
        Me.Chart1.TabIndex = 61
        Me.Chart1.Text = "Chart1"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Reference_Universal_GPA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1354, 878)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.prb1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "Reference_Universal_GPA"
        Me.Text = "Универсална справка за среден успех през една година"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbYear As System.Windows.Forms.ComboBox
    Friend WithEvents cmbProfil As System.Windows.Forms.ComboBox
    Friend WithEvents cmbParal As System.Windows.Forms.ComboBox
    Friend WithEvents cmbClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbYearString As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbTypeid As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSubjectId As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbSubject As System.Windows.Forms.ComboBox
    Friend WithEvents btnchart As System.Windows.Forms.Button
    Friend WithEvents cmbtype As System.Windows.Forms.ComboBox
    Friend WithEvents Випуск As System.Windows.Forms.Label
    Friend WithEvents cmbPodredba As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTeachid As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbTeach As System.Windows.Forms.ComboBox
    Friend WithEvents cmbProfilId As System.Windows.Forms.ComboBox
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents kod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvGodina As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvklas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvParalelka As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvprofil As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvPredmet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvteach As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvtype As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvC2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvC3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvC4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvC5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvC6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnWordNewFIle As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExselFIle As System.Windows.Forms.Button
    Friend WithEvents btnExselNewFile As System.Windows.Forms.Button
    Friend WithEvents prb1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
