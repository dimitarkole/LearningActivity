<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class reference_VA_classes
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
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(reference_VA_classes))
        Me.prb1 = New System.Windows.Forms.ProgressBar()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnWordNewFIle = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnExselFIle = New System.Windows.Forms.Button()
        Me.btnExselNewFile = New System.Windows.Forms.Button()
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbSubject = New System.Windows.Forms.ComboBox()
        Me.cmbtype = New System.Windows.Forms.ComboBox()
        Me.cmbTypeid = New System.Windows.Forms.ComboBox()
        Me.cmbSubjectId = New System.Windows.Forms.ComboBox()
        Me.cmbyearid = New System.Windows.Forms.ComboBox()
        Me.cmbyear = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnchart = New System.Windows.Forms.Button()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'prb1
        '
        Me.prb1.Location = New System.Drawing.Point(16, 384)
        Me.prb1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.prb1.Name = "prb1"
        Me.prb1.Size = New System.Drawing.Size(1693, 28)
        Me.prb1.TabIndex = 30
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnWordNewFIle)
        Me.GroupBox3.Location = New System.Drawing.Point(1151, 252)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(280, 121)
        Me.GroupBox3.TabIndex = 28
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Експортирай резултата в MS Word"
        '
        'btnWordNewFIle
        '
        Me.btnWordNewFIle.Location = New System.Drawing.Point(43, 46)
        Me.btnWordNewFIle.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnWordNewFIle.Name = "btnWordNewFIle"
        Me.btnWordNewFIle.Size = New System.Drawing.Size(163, 53)
        Me.btnWordNewFIle.TabIndex = 7
        Me.btnWordNewFIle.Text = "Нов файл"
        Me.btnWordNewFIle.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnExselFIle)
        Me.GroupBox1.Controls.Add(Me.btnExselNewFile)
        Me.GroupBox1.Location = New System.Drawing.Point(533, 252)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(429, 121)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Експортирай резултата в MS Excel"
        '
        'btnExselFIle
        '
        Me.btnExselFIle.Location = New System.Drawing.Point(217, 46)
        Me.btnExselFIle.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExselFIle.Name = "btnExselFIle"
        Me.btnExselFIle.Size = New System.Drawing.Size(163, 53)
        Me.btnExselFIle.TabIndex = 6
        Me.btnExselFIle.Text = "Съществуващ файл"
        Me.btnExselFIle.UseVisualStyleBackColor = True
        '
        'btnExselNewFile
        '
        Me.btnExselNewFile.Location = New System.Drawing.Point(20, 46)
        Me.btnExselNewFile.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExselNewFile.Name = "btnExselNewFile"
        Me.btnExselNewFile.Size = New System.Drawing.Size(163, 53)
        Me.btnExselNewFile.TabIndex = 7
        Me.btnExselNewFile.Text = "Нов файл"
        Me.btnExselNewFile.UseVisualStyleBackColor = True
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmId, Me.clmClass, Me.clmSubject, Me.clmTupes, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.dgv1.Location = New System.Drawing.Point(353, 15)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(1349, 230)
        Me.dgv1.TabIndex = 27
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
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cmbSubject)
        Me.GroupBox2.Controls.Add(Me.cmbtype)
        Me.GroupBox2.Controls.Add(Me.cmbTypeid)
        Me.GroupBox2.Controls.Add(Me.cmbSubjectId)
        Me.GroupBox2.Controls.Add(Me.cmbyearid)
        Me.GroupBox2.Controls.Add(Me.cmbyear)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 15)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(329, 230)
        Me.GroupBox2.TabIndex = 26
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Избор на критерии"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(51, 62)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 17)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Предмет:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(51, 96)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 17)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Вид оценка:"
        '
        'cmbSubject
        '
        Me.cmbSubject.FormattingEnabled = True
        Me.cmbSubject.Items.AddRange(New Object() {"Всички предмети"})
        Me.cmbSubject.Location = New System.Drawing.Point(152, 58)
        Me.cmbSubject.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbSubject.Name = "cmbSubject"
        Me.cmbSubject.Size = New System.Drawing.Size(160, 24)
        Me.cmbSubject.TabIndex = 14
        Me.cmbSubject.Text = "Всички предмети"
        '
        'cmbtype
        '
        Me.cmbtype.FormattingEnabled = True
        Me.cmbtype.Items.AddRange(New Object() {"Всички видове"})
        Me.cmbtype.Location = New System.Drawing.Point(152, 92)
        Me.cmbtype.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbtype.Name = "cmbtype"
        Me.cmbtype.Size = New System.Drawing.Size(160, 24)
        Me.cmbtype.TabIndex = 14
        Me.cmbtype.Text = "Всички видове"
        '
        'cmbTypeid
        '
        Me.cmbTypeid.FormattingEnabled = True
        Me.cmbTypeid.Items.AddRange(New Object() {"-1"})
        Me.cmbTypeid.Location = New System.Drawing.Point(321, 95)
        Me.cmbTypeid.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbTypeid.Name = "cmbTypeid"
        Me.cmbTypeid.Size = New System.Drawing.Size(156, 24)
        Me.cmbTypeid.TabIndex = 9
        Me.cmbTypeid.Text = "-1"
        Me.cmbTypeid.Visible = False
        '
        'cmbSubjectId
        '
        Me.cmbSubjectId.FormattingEnabled = True
        Me.cmbSubjectId.Items.AddRange(New Object() {"-1"})
        Me.cmbSubjectId.Location = New System.Drawing.Point(321, 62)
        Me.cmbSubjectId.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbSubjectId.Name = "cmbSubjectId"
        Me.cmbSubjectId.Size = New System.Drawing.Size(156, 24)
        Me.cmbSubjectId.TabIndex = 9
        Me.cmbSubjectId.Text = "-1"
        Me.cmbSubjectId.Visible = False
        '
        'cmbyearid
        '
        Me.cmbyearid.FormattingEnabled = True
        Me.cmbyearid.Location = New System.Drawing.Point(321, 23)
        Me.cmbyearid.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbyearid.Name = "cmbyearid"
        Me.cmbyearid.Size = New System.Drawing.Size(156, 24)
        Me.cmbyearid.TabIndex = 9
        Me.cmbyearid.Visible = False
        '
        'cmbyear
        '
        Me.cmbyear.FormattingEnabled = True
        Me.cmbyear.Location = New System.Drawing.Point(152, 23)
        Me.cmbyear.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbyear.Name = "cmbyear"
        Me.cmbyear.Size = New System.Drawing.Size(160, 24)
        Me.cmbyear.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 27)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 17)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "За година:"
        '
        'btnchart
        '
        Me.btnchart.Location = New System.Drawing.Point(55, 47)
        Me.btnchart.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnchart.Name = "btnchart"
        Me.btnchart.Size = New System.Drawing.Size(163, 53)
        Me.btnchart.TabIndex = 8
        Me.btnchart.Text = "Изчисли резултa"
        Me.btnchart.UseVisualStyleBackColor = True
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(16, 420)
        Me.Chart1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series1.Legend = "Legend1"
        Series1.Name = "Otnoshenie"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(1693, 443)
        Me.Chart1.TabIndex = 25
        Me.Chart1.Text = "Chart1"
        Me.Chart1.Visible = False
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "helpHTML\HelpHTML.chm"
        Me.HelpProvider1.Tag = "F1"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnchart)
        Me.GroupBox4.Location = New System.Drawing.Point(64, 251)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(281, 126)
        Me.GroupBox4.TabIndex = 59
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Покажи резултата в програмата"
        '
        'reference_VA_classes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1719, 421)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.prb1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Chart1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider1.SetHelpKeyword(Me, "Съотношение на оценките по брой (Всички паралелки)")
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.HelpProvider1.SetHelpString(Me, "Съотношение на оценките по брой (Всички паралелки)")
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(10, 10)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.Name = "reference_VA_classes"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Съотношение на оценките по брой (Всички паралелки)"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents prb1 As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnWordNewFIle As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExselFIle As System.Windows.Forms.Button
    Friend WithEvents btnExselNewFile As System.Windows.Forms.Button
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnchart As System.Windows.Forms.Button
    Friend WithEvents cmbSubject As System.Windows.Forms.ComboBox
    Friend WithEvents cmbtype As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTypeid As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSubjectId As System.Windows.Forms.ComboBox
    Friend WithEvents cmbyearid As System.Windows.Forms.ComboBox
    Friend WithEvents cmbyear As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
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
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
End Class
