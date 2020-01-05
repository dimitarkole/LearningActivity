<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class reference_absecnce_vipusk
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(reference_absecnce_vipusk))
        Me.prb1 = New System.Windows.Forms.ProgressBar()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnWordNewFIle = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnExselFIle = New System.Windows.Forms.Button()
        Me.btnExselNewFile = New System.Windows.Forms.Button()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.clmId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmClass = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmCI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmCNI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbYear = New System.Windows.Forms.ComboBox()
        Me.cmbClass = New System.Windows.Forms.ComboBox()
        Me.cmbVipusk = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnchart = New System.Windows.Forms.Button()
        Me.cmbsrok = New System.Windows.Forms.ComboBox()
        Me.cmbsrokid = New System.Windows.Forms.ComboBox()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'prb1
        '
        Me.prb1.Location = New System.Drawing.Point(7, 309)
        Me.prb1.Name = "prb1"
        Me.prb1.Size = New System.Drawing.Size(1270, 23)
        Me.prb1.TabIndex = 33
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnWordNewFIle)
        Me.GroupBox3.Location = New System.Drawing.Point(687, 205)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(210, 98)
        Me.GroupBox3.TabIndex = 31
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Експортирай резултата в MS Word"
        '
        'btnWordNewFIle
        '
        Me.btnWordNewFIle.Location = New System.Drawing.Point(32, 37)
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
        Me.GroupBox1.Location = New System.Drawing.Point(265, 205)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(322, 98)
        Me.GroupBox1.TabIndex = 32
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
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmId, Me.clmClass, Me.clmCI, Me.clmCNI, Me.Column1})
        Me.dgv1.Location = New System.Drawing.Point(267, 12)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(1006, 187)
        Me.dgv1.TabIndex = 30
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
        Me.clmClass.Width = 150
        '
        'clmCI
        '
        Me.clmCI.HeaderText = "Извинени"
        Me.clmCI.Name = "clmCI"
        Me.clmCI.ReadOnly = True
        Me.clmCI.Width = 150
        '
        'clmCNI
        '
        Me.clmCNI.HeaderText = "Неизвинени"
        Me.clmCNI.Name = "clmCNI"
        Me.clmCNI.ReadOnly = True
        Me.clmCNI.Width = 150
        '
        'Column1
        '
        Me.Column1.HeaderText = "Срок"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 120
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbYear)
        Me.GroupBox2.Controls.Add(Me.cmbClass)
        Me.GroupBox2.Controls.Add(Me.cmbVipusk)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.btnchart)
        Me.GroupBox2.Controls.Add(Me.cmbsrok)
        Me.GroupBox2.Controls.Add(Me.cmbsrokid)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(249, 187)
        Me.GroupBox2.TabIndex = 29
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Изчисляване на резултат"
        '
        'cmbYear
        '
        Me.cmbYear.FormattingEnabled = True
        Me.cmbYear.Location = New System.Drawing.Point(285, 25)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.Size = New System.Drawing.Size(34, 21)
        Me.cmbYear.TabIndex = 17
        Me.cmbYear.Visible = False
        '
        'cmbClass
        '
        Me.cmbClass.FormattingEnabled = True
        Me.cmbClass.Location = New System.Drawing.Point(245, 22)
        Me.cmbClass.Name = "cmbClass"
        Me.cmbClass.Size = New System.Drawing.Size(34, 21)
        Me.cmbClass.TabIndex = 16
        Me.cmbClass.Visible = False
        '
        'cmbVipusk
        '
        Me.cmbVipusk.FormattingEnabled = True
        Me.cmbVipusk.Location = New System.Drawing.Point(113, 22)
        Me.cmbVipusk.Name = "cmbVipusk"
        Me.cmbVipusk.Size = New System.Drawing.Size(122, 21)
        Me.cmbVipusk.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Випуск:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(47, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Период:"
        '
        'btnchart
        '
        Me.btnchart.Location = New System.Drawing.Point(113, 111)
        Me.btnchart.Name = "btnchart"
        Me.btnchart.Size = New System.Drawing.Size(122, 43)
        Me.btnchart.TabIndex = 8
        Me.btnchart.Text = "Изчисли резултa"
        Me.btnchart.UseVisualStyleBackColor = True
        '
        'cmbsrok
        '
        Me.cmbsrok.FormattingEnabled = True
        Me.cmbsrok.Items.AddRange(New Object() {"Първи срок", "Втори срок", "За годината"})
        Me.cmbsrok.Location = New System.Drawing.Point(114, 46)
        Me.cmbsrok.Name = "cmbsrok"
        Me.cmbsrok.Size = New System.Drawing.Size(121, 21)
        Me.cmbsrok.TabIndex = 14
        Me.cmbsrok.Text = "Първи срок"
        '
        'cmbsrokid
        '
        Me.cmbsrokid.FormattingEnabled = True
        Me.cmbsrokid.Items.AddRange(New Object() {"1", "2", "-1"})
        Me.cmbsrokid.Location = New System.Drawing.Point(245, 46)
        Me.cmbsrokid.Name = "cmbsrokid"
        Me.cmbsrokid.Size = New System.Drawing.Size(34, 21)
        Me.cmbsrokid.TabIndex = 9
        Me.cmbsrokid.Text = "0"
        Me.cmbsrokid.Visible = False
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.Location = New System.Drawing.Point(7, 343)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Size = New System.Drawing.Size(1265, 360)
        Me.Chart1.TabIndex = 34
        Me.Chart1.Text = "Chart1"
        Me.Chart1.Visible = False
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "helpHTML\HelpHTML.chm"
        Me.HelpProvider1.Tag = "F1"
        '
        'reference_absecnce_vipusk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1293, 342)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.prb1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider1.SetHelpKeyword(Me, "Отсъствия по класове")
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.HelpProvider1.SetHelpString(Me, "Отсъствия по класове")
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(10, 10)
        Me.MaximizeBox = False
        Me.Name = "reference_absecnce_vipusk"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Отсъствия по класове"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnchart As System.Windows.Forms.Button
    Friend WithEvents cmbsrok As System.Windows.Forms.ComboBox
    Friend WithEvents cmbsrokid As System.Windows.Forms.ComboBox
    Friend WithEvents cmbYear As System.Windows.Forms.ComboBox
    Friend WithEvents cmbClass As System.Windows.Forms.ComboBox
    Friend WithEvents cmbVipusk As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents clmId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmClass As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmCI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmCNI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
End Class
