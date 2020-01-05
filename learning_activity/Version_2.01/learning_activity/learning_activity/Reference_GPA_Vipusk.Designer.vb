<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reference_GPA_Vipusk
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Reference_GPA_Vipusk))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnWordNewFIle = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnExselFIle = New System.Windows.Forms.Button()
        Me.btnExselNewFile = New System.Windows.Forms.Button()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.prb1 = New System.Windows.Forms.ProgressBar()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.clmId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmClass = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmSubject = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmTupes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbYear = New System.Windows.Forms.ComboBox()
        Me.cmbClass = New System.Windows.Forms.ComboBox()
        Me.cmbYearString = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbIdType = New System.Windows.Forms.ComboBox()
        Me.cmbSubjectId = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbSubject = New System.Windows.Forms.ComboBox()
        Me.btnchart = New System.Windows.Forms.Button()
        Me.cmbtype = New System.Windows.Forms.ComboBox()
        Me.Випуск = New System.Windows.Forms.Label()
        Me.cmbPodredba = New System.Windows.Forms.ComboBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnWordNewFIle)
        Me.GroupBox3.Location = New System.Drawing.Point(737, 237)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(211, 98)
        Me.GroupBox3.TabIndex = 37
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
        Me.GroupBox1.Location = New System.Drawing.Point(239, 237)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(322, 98)
        Me.GroupBox1.TabIndex = 36
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
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.Location = New System.Drawing.Point(12, 383)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Size = New System.Drawing.Size(1264, 366)
        Me.Chart1.TabIndex = 35
        Me.Chart1.Text = "Chart1"
        '
        'prb1
        '
        Me.prb1.Location = New System.Drawing.Point(12, 350)
        Me.prb1.Name = "prb1"
        Me.prb1.Size = New System.Drawing.Size(1265, 23)
        Me.prb1.TabIndex = 34
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmId, Me.clmClass, Me.clmSubject, Me.clmTupes, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.dgv1.Location = New System.Drawing.Point(239, 12)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(1040, 215)
        Me.dgv1.TabIndex = 33
        '
        'clmId
        '
        Me.clmId.HeaderText = "Код"
        Me.clmId.Name = "clmId"
        Me.clmId.ReadOnly = True
        '
        'clmClass
        '
        Me.clmClass.HeaderText = "Клас"
        Me.clmClass.Name = "clmClass"
        Me.clmClass.ReadOnly = True
        '
        'clmSubject
        '
        Me.clmSubject.HeaderText = "Предмет"
        Me.clmSubject.Name = "clmSubject"
        Me.clmSubject.ReadOnly = True
        '
        'clmTupes
        '
        Me.clmTupes.HeaderText = "Вид оценка"
        Me.clmTupes.Name = "clmTupes"
        Me.clmTupes.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "Брой двойки"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Брой тройки"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Брой четворки"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Брой петици"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Брой шестици"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbYear)
        Me.GroupBox2.Controls.Add(Me.cmbClass)
        Me.GroupBox2.Controls.Add(Me.cmbYearString)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cmbIdType)
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
        Me.GroupBox2.Size = New System.Drawing.Size(213, 215)
        Me.GroupBox2.TabIndex = 32
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Изчисляване на резултат"
        '
        'cmbYear
        '
        Me.cmbYear.FormattingEnabled = True
        Me.cmbYear.Location = New System.Drawing.Point(212, 27)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.Size = New System.Drawing.Size(71, 21)
        Me.cmbYear.TabIndex = 23
        Me.cmbYear.Visible = False
        '
        'cmbClass
        '
        Me.cmbClass.FormattingEnabled = True
        Me.cmbClass.Location = New System.Drawing.Point(84, 51)
        Me.cmbClass.Name = "cmbClass"
        Me.cmbClass.Size = New System.Drawing.Size(122, 21)
        Me.cmbClass.TabIndex = 20
        '
        'cmbYearString
        '
        Me.cmbYearString.FormattingEnabled = True
        Me.cmbYearString.Location = New System.Drawing.Point(84, 24)
        Me.cmbYearString.Name = "cmbYearString"
        Me.cmbYearString.Size = New System.Drawing.Size(122, 21)
        Me.cmbYearString.TabIndex = 19
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
        Me.Label4.Location = New System.Drawing.Point(10, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Клас:"
        '
        'cmbIdType
        '
        Me.cmbIdType.FormattingEnabled = True
        Me.cmbIdType.Items.AddRange(New Object() {"-1"})
        Me.cmbIdType.Location = New System.Drawing.Point(208, 109)
        Me.cmbIdType.Name = "cmbIdType"
        Me.cmbIdType.Size = New System.Drawing.Size(36, 21)
        Me.cmbIdType.TabIndex = 15
        Me.cmbIdType.Text = "-1"
        Me.cmbIdType.Visible = False
        '
        'cmbSubjectId
        '
        Me.cmbSubjectId.FormattingEnabled = True
        Me.cmbSubjectId.Items.AddRange(New Object() {"-1"})
        Me.cmbSubjectId.Location = New System.Drawing.Point(208, 80)
        Me.cmbSubjectId.Name = "cmbSubjectId"
        Me.cmbSubjectId.Size = New System.Drawing.Size(36, 21)
        Me.cmbSubjectId.TabIndex = 15
        Me.cmbSubjectId.Text = "-1"
        Me.cmbSubjectId.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Предмет:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Вид оценка:"
        '
        'cmbSubject
        '
        Me.cmbSubject.FormattingEnabled = True
        Me.cmbSubject.Items.AddRange(New Object() {"Всички предмети"})
        Me.cmbSubject.Location = New System.Drawing.Point(84, 80)
        Me.cmbSubject.Name = "cmbSubject"
        Me.cmbSubject.Size = New System.Drawing.Size(121, 21)
        Me.cmbSubject.TabIndex = 14
        Me.cmbSubject.Text = "Всички предмети"
        '
        'btnchart
        '
        Me.btnchart.Location = New System.Drawing.Point(70, 165)
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
        Me.cmbtype.Location = New System.Drawing.Point(84, 109)
        Me.cmbtype.Name = "cmbtype"
        Me.cmbtype.Size = New System.Drawing.Size(121, 21)
        Me.cmbtype.TabIndex = 14
        Me.cmbtype.Text = "Всички видове"
        '
        'Випуск
        '
        Me.Випуск.AutoSize = True
        Me.Випуск.Location = New System.Drawing.Point(10, 141)
        Me.Випуск.Name = "Випуск"
        Me.Випуск.Size = New System.Drawing.Size(65, 13)
        Me.Випуск.TabIndex = 12
        Me.Випуск.Text = "Подреди от"
        '
        'cmbPodredba
        '
        Me.cmbPodredba.FormattingEnabled = True
        Me.cmbPodredba.Items.AddRange(New Object() {"Минимално към максималнно", "Максималнно към минимално"})
        Me.cmbPodredba.Location = New System.Drawing.Point(84, 138)
        Me.cmbPodredba.Name = "cmbPodredba"
        Me.cmbPodredba.Size = New System.Drawing.Size(121, 21)
        Me.cmbPodredba.TabIndex = 10
        Me.cmbPodredba.Text = "Минимално към максималнно"
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "helpHTML\HelpHTML.chm"
        Me.HelpProvider1.Tag = "F1"
        '
        'Reference_GPA_Vipusk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1289, 382)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.prb1)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider1.SetHelpKeyword(Me, "Среден успех по класове")
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.HelpProvider1.SetHelpString(Me, "Среден успех по класове")
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(10, 10)
        Me.MaximizeBox = False
        Me.Name = "Reference_GPA_Vipusk"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Среден успех по класове"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnWordNewFIle As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExselFIle As System.Windows.Forms.Button
    Friend WithEvents btnExselNewFile As System.Windows.Forms.Button
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents prb1 As System.Windows.Forms.ProgressBar
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbIdType As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSubjectId As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbSubject As System.Windows.Forms.ComboBox
    Friend WithEvents btnchart As System.Windows.Forms.Button
    Friend WithEvents cmbtype As System.Windows.Forms.ComboBox
    Friend WithEvents Випуск As System.Windows.Forms.Label
    Friend WithEvents cmbPodredba As System.Windows.Forms.ComboBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Private WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents clmId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmClass As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmSubject As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmTupes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmbClass As System.Windows.Forms.ComboBox
    Friend WithEvents cmbYearString As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbYear As System.Windows.Forms.ComboBox
End Class
