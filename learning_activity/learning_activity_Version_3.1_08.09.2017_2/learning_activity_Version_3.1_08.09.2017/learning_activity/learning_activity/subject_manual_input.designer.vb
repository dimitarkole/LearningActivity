<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class subject_manual_input
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
        Me.components = New System.ComponentModel.Container()
        Dim IdLabel2 As System.Windows.Forms.Label
        Dim Name_subjectLabel1 As System.Windows.Forms.Label
        Dim Name_subjectLabel As System.Windows.Forms.Label
        Dim IdLabel As System.Windows.Forms.Label
        Dim НомерLabel As System.Windows.Forms.Label
        Dim Име_на_предметаLabel As System.Windows.Forms.Label
        Dim NumberLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim NumberLabel1 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(subject_manual_input))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.NumberLabel2 = New System.Windows.Forms.Label()
        Me.SubjectBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Learning_activityDataSet = New learning_activity.learning_activityDataSet()
        Me.Name_subjectLabel2 = New System.Windows.Forms.Label()
        Me.lbliddel = New System.Windows.Forms.Label()
        Me.btndeletesubject = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.Name_subjectTextBox = New System.Windows.Forms.TextBox()
        Me.lblid = New System.Windows.Forms.Label()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.nudrUP = New System.Windows.Forms.NumericUpDown()
        Me.НомерLabel1 = New System.Windows.Forms.Label()
        Me.Име_на_предметаTextBox = New System.Windows.Forms.TextBox()
        Me.btnRedakchia = New System.Windows.Forms.Button()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.SubjectDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Номер = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubjectTableAdapter = New learning_activity.learning_activityDataSetTableAdapters.subjectTableAdapter()
        Me.TableAdapterManager = New learning_activity.learning_activityDataSetTableAdapters.TableAdapterManager()
        IdLabel2 = New System.Windows.Forms.Label()
        Name_subjectLabel1 = New System.Windows.Forms.Label()
        Name_subjectLabel = New System.Windows.Forms.Label()
        IdLabel = New System.Windows.Forms.Label()
        НомерLabel = New System.Windows.Forms.Label()
        Име_на_предметаLabel = New System.Windows.Forms.Label()
        NumberLabel = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        NumberLabel1 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        CType(Me.SubjectBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Learning_activityDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.nudrUP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SubjectDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IdLabel2
        '
        IdLabel2.AutoSize = True
        IdLabel2.Location = New System.Drawing.Point(6, 25)
        IdLabel2.Name = "IdLabel2"
        IdLabel2.Size = New System.Drawing.Size(29, 13)
        IdLabel2.TabIndex = 6
        IdLabel2.Text = "Код:"
        '
        'Name_subjectLabel1
        '
        Name_subjectLabel1.AutoSize = True
        Name_subjectLabel1.Location = New System.Drawing.Point(6, 53)
        Name_subjectLabel1.Name = "Name_subjectLabel1"
        Name_subjectLabel1.Size = New System.Drawing.Size(93, 13)
        Name_subjectLabel1.TabIndex = 8
        Name_subjectLabel1.Text = "Име на предмет:"
        '
        'Name_subjectLabel
        '
        Name_subjectLabel.AutoSize = True
        Name_subjectLabel.Location = New System.Drawing.Point(6, 52)
        Name_subjectLabel.Name = "Name_subjectLabel"
        Name_subjectLabel.Size = New System.Drawing.Size(93, 13)
        Name_subjectLabel.TabIndex = 4
        Name_subjectLabel.Text = "Име на предмет:"
        '
        'IdLabel
        '
        IdLabel.AutoSize = True
        IdLabel.Location = New System.Drawing.Point(6, 28)
        IdLabel.Name = "IdLabel"
        IdLabel.Size = New System.Drawing.Size(29, 13)
        IdLabel.TabIndex = 2
        IdLabel.Text = "Код:"
        '
        'НомерLabel
        '
        НомерLabel.AutoSize = True
        НомерLabel.Location = New System.Drawing.Point(6, 25)
        НомерLabel.Name = "НомерLabel"
        НомерLabel.Size = New System.Drawing.Size(29, 13)
        НомерLabel.TabIndex = 6
        НомерLabel.Text = "Код:"
        '
        'Име_на_предметаLabel
        '
        Име_на_предметаLabel.AutoSize = True
        Име_на_предметаLabel.Location = New System.Drawing.Point(6, 54)
        Име_на_предметаLabel.Name = "Име_на_предметаLabel"
        Име_на_предметаLabel.Size = New System.Drawing.Size(99, 13)
        Име_на_предметаLabel.TabIndex = 8
        Име_на_предметаLabel.Text = "Име на предмета:"
        '
        'NumberLabel
        '
        NumberLabel.AutoSize = True
        NumberLabel.Location = New System.Drawing.Point(6, 81)
        NumberLabel.Name = "NumberLabel"
        NumberLabel.Size = New System.Drawing.Size(72, 13)
        NumberLabel.TabIndex = 12
        NumberLabel.Text = "Номер в УП:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(6, 81)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(72, 13)
        Label1.TabIndex = 12
        Label1.Text = "Номер в УП:"
        '
        'NumberLabel1
        '
        NumberLabel1.AutoSize = True
        NumberLabel1.Location = New System.Drawing.Point(6, 81)
        NumberLabel1.Name = "NumberLabel1"
        NumberLabel1.Size = New System.Drawing.Size(72, 13)
        NumberLabel1.TabIndex = 15
        NumberLabel1.Text = "Номер в УП:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(NumberLabel1)
        Me.GroupBox2.Controls.Add(Me.NumberLabel2)
        Me.GroupBox2.Controls.Add(Me.Name_subjectLabel2)
        Me.GroupBox2.Controls.Add(Me.lbliddel)
        Me.GroupBox2.Controls.Add(IdLabel2)
        Me.GroupBox2.Controls.Add(Name_subjectLabel1)
        Me.GroupBox2.Controls.Add(Me.btndeletesubject)
        Me.GroupBox2.Location = New System.Drawing.Point(263, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(207, 171)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Премахване на предмет"
        '
        'NumberLabel2
        '
        Me.NumberLabel2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SubjectBindingSource, "number", True))
        Me.NumberLabel2.Location = New System.Drawing.Point(108, 81)
        Me.NumberLabel2.Name = "NumberLabel2"
        Me.NumberLabel2.Size = New System.Drawing.Size(100, 18)
        Me.NumberLabel2.TabIndex = 16
        Me.NumberLabel2.Text = "Label2"
        '
        'SubjectBindingSource
        '
        Me.SubjectBindingSource.DataMember = "subject"
        Me.SubjectBindingSource.DataSource = Me.Learning_activityDataSet
        '
        'Learning_activityDataSet
        '
        Me.Learning_activityDataSet.DataSetName = "learning_activityDataSet"
        Me.Learning_activityDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Name_subjectLabel2
        '
        Me.Name_subjectLabel2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SubjectBindingSource, "Име на предмета", True))
        Me.Name_subjectLabel2.Location = New System.Drawing.Point(108, 53)
        Me.Name_subjectLabel2.Name = "Name_subjectLabel2"
        Me.Name_subjectLabel2.Size = New System.Drawing.Size(67, 23)
        Me.Name_subjectLabel2.TabIndex = 15
        Me.Name_subjectLabel2.Text = "Label1"
        '
        'lbliddel
        '
        Me.lbliddel.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SubjectBindingSource, "Номер", True))
        Me.lbliddel.Location = New System.Drawing.Point(108, 25)
        Me.lbliddel.Name = "lbliddel"
        Me.lbliddel.Size = New System.Drawing.Size(67, 28)
        Me.lbliddel.TabIndex = 13
        Me.lbliddel.Text = "Label1"
        '
        'btndeletesubject
        '
        Me.btndeletesubject.Location = New System.Drawing.Point(46, 107)
        Me.btndeletesubject.Name = "btndeletesubject"
        Me.btndeletesubject.Size = New System.Drawing.Size(112, 44)
        Me.btndeletesubject.TabIndex = 6
        Me.btndeletesubject.Text = "Изтрий предмет"
        Me.btndeletesubject.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.NumericUpDown2)
        Me.GroupBox1.Controls.Add(NumberLabel)
        Me.GroupBox1.Controls.Add(Me.Name_subjectTextBox)
        Me.GroupBox1.Controls.Add(Name_subjectLabel)
        Me.GroupBox1.Controls.Add(Me.lblid)
        Me.GroupBox1.Controls.Add(IdLabel)
        Me.GroupBox1.Controls.Add(Me.btnUpload)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(244, 157)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Добавяне на предмет"
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(115, 81)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(104, 20)
        Me.NumericUpDown2.TabIndex = 14
        '
        'Name_subjectTextBox
        '
        Me.Name_subjectTextBox.Location = New System.Drawing.Point(115, 51)
        Me.Name_subjectTextBox.MaxLength = 35
        Me.Name_subjectTextBox.Name = "Name_subjectTextBox"
        Me.Name_subjectTextBox.Size = New System.Drawing.Size(104, 20)
        Me.Name_subjectTextBox.TabIndex = 8
        '
        'lblid
        '
        Me.lblid.Location = New System.Drawing.Point(101, 24)
        Me.lblid.Name = "lblid"
        Me.lblid.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblid.Size = New System.Drawing.Size(121, 21)
        Me.lblid.TabIndex = 7
        Me.lblid.Text = "0"
        Me.lblid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnUpload
        '
        Me.btnUpload.Location = New System.Drawing.Point(57, 105)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(112, 44)
        Me.btnUpload.TabIndex = 6
        Me.btnUpload.Text = "Въведи предмет"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Label1)
        Me.GroupBox3.Controls.Add(Me.nudrUP)
        Me.GroupBox3.Controls.Add(НомерLabel)
        Me.GroupBox3.Controls.Add(Me.НомерLabel1)
        Me.GroupBox3.Controls.Add(Име_на_предметаLabel)
        Me.GroupBox3.Controls.Add(Me.Име_на_предметаTextBox)
        Me.GroupBox3.Controls.Add(Me.btnRedakchia)
        Me.GroupBox3.Location = New System.Drawing.Point(476, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(223, 157)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Редактиране на предмет"
        '
        'nudrUP
        '
        Me.nudrUP.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.SubjectBindingSource, "number", True))
        Me.nudrUP.Location = New System.Drawing.Point(111, 79)
        Me.nudrUP.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nudrUP.Name = "nudrUP"
        Me.nudrUP.Size = New System.Drawing.Size(100, 20)
        Me.nudrUP.TabIndex = 13
        '
        'НомерLabel1
        '
        Me.НомерLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SubjectBindingSource, "Номер", True))
        Me.НомерLabel1.Location = New System.Drawing.Point(111, 25)
        Me.НомерLabel1.Name = "НомерLabel1"
        Me.НомерLabel1.Size = New System.Drawing.Size(100, 23)
        Me.НомерLabel1.TabIndex = 7
        Me.НомерLabel1.Text = "Label1"
        '
        'Име_на_предметаTextBox
        '
        Me.Име_на_предметаTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SubjectBindingSource, "Име на предмета", True))
        Me.Име_на_предметаTextBox.Location = New System.Drawing.Point(111, 51)
        Me.Име_на_предметаTextBox.Name = "Име_на_предметаTextBox"
        Me.Име_на_предметаTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Име_на_предметаTextBox.TabIndex = 9
        '
        'btnRedakchia
        '
        Me.btnRedakchia.Location = New System.Drawing.Point(63, 105)
        Me.btnRedakchia.Name = "btnRedakchia"
        Me.btnRedakchia.Size = New System.Drawing.Size(128, 44)
        Me.btnRedakchia.TabIndex = 6
        Me.btnRedakchia.Text = "Редактирай предмет"
        Me.btnRedakchia.UseVisualStyleBackColor = True
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "helpHTML\HelpHTML.chm"
        Me.HelpProvider1.Tag = "F1"
        '
        'SubjectDataGridView
        '
        Me.SubjectDataGridView.AllowUserToAddRows = False
        Me.SubjectDataGridView.AllowUserToDeleteRows = False
        Me.SubjectDataGridView.AutoGenerateColumns = False
        Me.SubjectDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SubjectDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.Номер})
        Me.SubjectDataGridView.DataSource = Me.SubjectBindingSource
        Me.SubjectDataGridView.Location = New System.Drawing.Point(72, 175)
        Me.SubjectDataGridView.Name = "SubjectDataGridView"
        Me.SubjectDataGridView.ReadOnly = True
        Me.SubjectDataGridView.Size = New System.Drawing.Size(542, 220)
        Me.SubjectDataGridView.TabIndex = 12
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Номер"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Код"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Име на предмета"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Име на предмета"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 250
        '
        'Номер
        '
        Me.Номер.DataPropertyName = "number"
        Me.Номер.HeaderText = "Номер в УП"
        Me.Номер.Name = "Номер"
        Me.Номер.ReadOnly = True
        '
        'SubjectTableAdapter
        '
        Me.SubjectTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.absenceTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.classesTableAdapter = Nothing
        Me.TableAdapterManager.profilesTableAdapter = Nothing
        Me.TableAdapterManager.purposeTableAdapter = Nothing
        Me.TableAdapterManager.subjectTableAdapter = Me.SubjectTableAdapter
        Me.TableAdapterManager.teachersTableAdapter = Nothing
        Me.TableAdapterManager.teachingTableAdapter = Nothing
        Me.TableAdapterManager.typesTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = learning_activity.learning_activityDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'subject_manual_input
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(712, 407)
        Me.Controls.Add(Me.SubjectDataGridView)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.HelpProvider1.SetHelpKeyword(Me, "Предмети")
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.HelpProvider1.SetHelpString(Me, "Предмети")
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "subject_manual_input"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Въвеждане, изтриване и редактиране на предмети"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.SubjectBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Learning_activityDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.nudrUP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SubjectDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btndeletesubject As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Name_subjectTextBox As System.Windows.Forms.TextBox
    Friend WithEvents lblid As System.Windows.Forms.Label
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents Learning_activityDataSet As learning_activity.learning_activityDataSet
    Friend WithEvents SubjectBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SubjectTableAdapter As learning_activity.learning_activityDataSetTableAdapters.subjectTableAdapter
    Friend WithEvents TableAdapterManager As learning_activity.learning_activityDataSetTableAdapters.TableAdapterManager
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Name_subjectLabel2 As System.Windows.Forms.Label
    Friend WithEvents lbliddel As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents НомерLabel1 As System.Windows.Forms.Label
    Friend WithEvents Име_на_предметаTextBox As System.Windows.Forms.TextBox
    Friend WithEvents btnRedakchia As System.Windows.Forms.Button
    Private WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents SubjectDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents NumberLabel2 As System.Windows.Forms.Label
    Friend WithEvents nudrUP As System.Windows.Forms.NumericUpDown
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Номер As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
End Class
