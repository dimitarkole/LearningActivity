<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class teachers_manual_input
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
        Dim IdLabel As System.Windows.Forms.Label
        Dim Name_teacherLabel As System.Windows.Forms.Label
        Dim Family_teacherLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim НомерLabel As System.Windows.Forms.Label
        Dim Име_на_учителяLabel As System.Windows.Forms.Label
        Dim Фамилия_на_учителяLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(teachers_manual_input))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblFamily_teacherDel = New System.Windows.Forms.Label()
        Me.TeachersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Learning_activityDataSet = New learning_activity.learning_activityDataSet()
        Me.lblName_teacherDel = New System.Windows.Forms.Label()
        Me.lblIdDel = New System.Windows.Forms.Label()
        Me.btndeletesubject = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblIdAdd = New System.Windows.Forms.Label()
        Me.txtfamiliUcitel = New System.Windows.Forms.TextBox()
        Me.txtnameUcitel = New System.Windows.Forms.TextBox()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.TeachersTableAdapter = New learning_activity.learning_activityDataSetTableAdapters.teachersTableAdapter()
        Me.TableAdapterManager = New learning_activity.learning_activityDataSetTableAdapters.TableAdapterManager()
        Me.TeachersDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.НомерLabel1 = New System.Windows.Forms.Label()
        Me.Име_на_учителяTextBox = New System.Windows.Forms.TextBox()
        Me.Фамилия_на_учителяTextBox = New System.Windows.Forms.TextBox()
        Me.btnRedakchia = New System.Windows.Forms.Button()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        IdLabel = New System.Windows.Forms.Label()
        Name_teacherLabel = New System.Windows.Forms.Label()
        Family_teacherLabel = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        НомерLabel = New System.Windows.Forms.Label()
        Име_на_учителяLabel = New System.Windows.Forms.Label()
        Фамилия_на_учителяLabel = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TeachersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Learning_activityDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TeachersDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'IdLabel
        '
        IdLabel.AutoSize = True
        IdLabel.Location = New System.Drawing.Point(6, 26)
        IdLabel.Name = "IdLabel"
        IdLabel.Size = New System.Drawing.Size(29, 13)
        IdLabel.TabIndex = 6
        IdLabel.Text = "Код:"
        '
        'Name_teacherLabel
        '
        Name_teacherLabel.AutoSize = True
        Name_teacherLabel.Location = New System.Drawing.Point(6, 49)
        Name_teacherLabel.Name = "Name_teacherLabel"
        Name_teacherLabel.Size = New System.Drawing.Size(83, 13)
        Name_teacherLabel.TabIndex = 8
        Name_teacherLabel.Text = "Име на учител:"
        '
        'Family_teacherLabel
        '
        Family_teacherLabel.AutoSize = True
        Family_teacherLabel.Location = New System.Drawing.Point(6, 69)
        Family_teacherLabel.Name = "Family_teacherLabel"
        Family_teacherLabel.Size = New System.Drawing.Size(110, 13)
        Family_teacherLabel.TabIndex = 10
        Family_teacherLabel.Text = "Фамилия на учител:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(6, 26)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(29, 13)
        Label1.TabIndex = 11
        Label1.Text = "Код:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(6, 52)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(83, 13)
        Label2.TabIndex = 12
        Label2.Text = "Име на учител:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(6, 75)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(110, 13)
        Label3.TabIndex = 13
        Label3.Text = "Фамилия на учител:"
        '
        'НомерLabel
        '
        НомерLabel.AutoSize = True
        НомерLabel.Location = New System.Drawing.Point(15, 26)
        НомерLabel.Name = "НомерLabel"
        НомерLabel.Size = New System.Drawing.Size(29, 13)
        НомерLabel.TabIndex = 6
        НомерLabel.Text = "Код:"
        '
        'Име_на_учителяLabel
        '
        Име_на_учителяLabel.AutoSize = True
        Име_на_учителяLabel.Location = New System.Drawing.Point(15, 55)
        Име_на_учителяLabel.Name = "Име_на_учителяLabel"
        Име_на_учителяLabel.Size = New System.Drawing.Size(89, 13)
        Име_на_учителяLabel.TabIndex = 8
        Име_на_учителяLabel.Text = "Име на учителя:"
        '
        'Фамилия_на_учителяLabel
        '
        Фамилия_на_учителяLabel.AutoSize = True
        Фамилия_на_учителяLabel.Location = New System.Drawing.Point(15, 81)
        Фамилия_на_учителяLabel.Name = "Фамилия_на_учителяLabel"
        Фамилия_на_учителяLabel.Size = New System.Drawing.Size(116, 13)
        Фамилия_на_учителяLabel.TabIndex = 10
        Фамилия_на_учителяLabel.Text = "Фамилия на учителя:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblFamily_teacherDel)
        Me.GroupBox2.Controls.Add(Me.lblName_teacherDel)
        Me.GroupBox2.Controls.Add(Me.lblIdDel)
        Me.GroupBox2.Controls.Add(IdLabel)
        Me.GroupBox2.Controls.Add(Name_teacherLabel)
        Me.GroupBox2.Controls.Add(Family_teacherLabel)
        Me.GroupBox2.Controls.Add(Me.btndeletesubject)
        Me.GroupBox2.Location = New System.Drawing.Point(257, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(263, 158)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Премахване на учител"
        '
        'lblFamily_teacherDel
        '
        Me.lblFamily_teacherDel.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TeachersBindingSource, "Фамилия на учителя", True))
        Me.lblFamily_teacherDel.Location = New System.Drawing.Point(132, 69)
        Me.lblFamily_teacherDel.Name = "lblFamily_teacherDel"
        Me.lblFamily_teacherDel.Size = New System.Drawing.Size(100, 23)
        Me.lblFamily_teacherDel.TabIndex = 20
        '
        'TeachersBindingSource
        '
        Me.TeachersBindingSource.DataMember = "teachers"
        Me.TeachersBindingSource.DataSource = Me.Learning_activityDataSet
        '
        'Learning_activityDataSet
        '
        Me.Learning_activityDataSet.DataSetName = "learning_activityDataSet"
        Me.Learning_activityDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lblName_teacherDel
        '
        Me.lblName_teacherDel.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TeachersBindingSource, "Име на учителя", True))
        Me.lblName_teacherDel.Location = New System.Drawing.Point(132, 49)
        Me.lblName_teacherDel.Name = "lblName_teacherDel"
        Me.lblName_teacherDel.Size = New System.Drawing.Size(100, 23)
        Me.lblName_teacherDel.TabIndex = 18
        '
        'lblIdDel
        '
        Me.lblIdDel.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TeachersBindingSource, "Номер", True))
        Me.lblIdDel.Location = New System.Drawing.Point(132, 26)
        Me.lblIdDel.Name = "lblIdDel"
        Me.lblIdDel.Size = New System.Drawing.Size(100, 23)
        Me.lblIdDel.TabIndex = 16
        '
        'btndeletesubject
        '
        Me.btndeletesubject.Enabled = False
        Me.btndeletesubject.Location = New System.Drawing.Point(83, 98)
        Me.btndeletesubject.Name = "btndeletesubject"
        Me.btndeletesubject.Size = New System.Drawing.Size(112, 44)
        Me.btndeletesubject.TabIndex = 6
        Me.btndeletesubject.Text = "Изтрий учител"
        Me.btndeletesubject.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblIdAdd)
        Me.GroupBox1.Controls.Add(Me.txtfamiliUcitel)
        Me.GroupBox1.Controls.Add(Me.txtnameUcitel)
        Me.GroupBox1.Controls.Add(Label1)
        Me.GroupBox1.Controls.Add(Label2)
        Me.GroupBox1.Controls.Add(Label3)
        Me.GroupBox1.Controls.Add(Me.btnUpload)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(239, 158)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Добавяне на учител"
        '
        'lblIdAdd
        '
        Me.lblIdAdd.Location = New System.Drawing.Point(128, 21)
        Me.lblIdAdd.Name = "lblIdAdd"
        Me.lblIdAdd.Size = New System.Drawing.Size(103, 23)
        Me.lblIdAdd.TabIndex = 17
        Me.lblIdAdd.Text = "0"
        Me.lblIdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtfamiliUcitel
        '
        Me.txtfamiliUcitel.Location = New System.Drawing.Point(131, 72)
        Me.txtfamiliUcitel.MaxLength = 30
        Me.txtfamiliUcitel.Name = "txtfamiliUcitel"
        Me.txtfamiliUcitel.Size = New System.Drawing.Size(100, 20)
        Me.txtfamiliUcitel.TabIndex = 16
        '
        'txtnameUcitel
        '
        Me.txtnameUcitel.Location = New System.Drawing.Point(131, 49)
        Me.txtnameUcitel.MaxLength = 15
        Me.txtnameUcitel.Name = "txtnameUcitel"
        Me.txtnameUcitel.Size = New System.Drawing.Size(100, 20)
        Me.txtnameUcitel.TabIndex = 15
        '
        'btnUpload
        '
        Me.btnUpload.Location = New System.Drawing.Point(81, 98)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(112, 44)
        Me.btnUpload.TabIndex = 6
        Me.btnUpload.Text = "Въведи учител"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'TeachersTableAdapter
        '
        Me.TeachersTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.absenceTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.classesTableAdapter = Nothing
        Me.TableAdapterManager.profilesTableAdapter = Nothing
        Me.TableAdapterManager.purposeTableAdapter = Nothing
        Me.TableAdapterManager.subjectTableAdapter = Nothing
        Me.TableAdapterManager.teachersTableAdapter = Me.TeachersTableAdapter
        Me.TableAdapterManager.teachingTableAdapter = Nothing
        Me.TableAdapterManager.typesTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = learning_activity.learning_activityDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'TeachersDataGridView
        '
        Me.TeachersDataGridView.AllowUserToAddRows = False
        Me.TeachersDataGridView.AllowUserToDeleteRows = False
        Me.TeachersDataGridView.AutoGenerateColumns = False
        Me.TeachersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TeachersDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
        Me.TeachersDataGridView.DataSource = Me.TeachersBindingSource
        Me.TeachersDataGridView.Location = New System.Drawing.Point(93, 176)
        Me.TeachersDataGridView.Name = "TeachersDataGridView"
        Me.TeachersDataGridView.ReadOnly = True
        Me.TeachersDataGridView.Size = New System.Drawing.Size(623, 220)
        Me.TeachersDataGridView.TabIndex = 14
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Номер"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Код"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Име на учителя"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Име на учителя"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 160
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Фамилия на учителя"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Фамилия на учителя"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 300
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(НомерLabel)
        Me.GroupBox3.Controls.Add(Me.НомерLabel1)
        Me.GroupBox3.Controls.Add(Име_на_учителяLabel)
        Me.GroupBox3.Controls.Add(Me.Име_на_учителяTextBox)
        Me.GroupBox3.Controls.Add(Фамилия_на_учителяLabel)
        Me.GroupBox3.Controls.Add(Me.Фамилия_на_учителяTextBox)
        Me.GroupBox3.Controls.Add(Me.btnRedakchia)
        Me.GroupBox3.Location = New System.Drawing.Point(526, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(263, 158)
        Me.GroupBox3.TabIndex = 15
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Редактиране на учител"
        '
        'НомерLabel1
        '
        Me.НомерLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TeachersBindingSource, "Номер", True))
        Me.НомерLabel1.Location = New System.Drawing.Point(137, 26)
        Me.НомерLabel1.Name = "НомерLabel1"
        Me.НомерLabel1.Size = New System.Drawing.Size(100, 23)
        Me.НомерLabel1.TabIndex = 7
        Me.НомерLabel1.Text = "Label4"
        '
        'Име_на_учителяTextBox
        '
        Me.Име_на_учителяTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TeachersBindingSource, "Име на учителя", True))
        Me.Име_на_учителяTextBox.Location = New System.Drawing.Point(137, 52)
        Me.Име_на_учителяTextBox.Name = "Име_на_учителяTextBox"
        Me.Име_на_учителяTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Име_на_учителяTextBox.TabIndex = 9
        '
        'Фамилия_на_учителяTextBox
        '
        Me.Фамилия_на_учителяTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TeachersBindingSource, "Фамилия на учителя", True))
        Me.Фамилия_на_учителяTextBox.Location = New System.Drawing.Point(137, 78)
        Me.Фамилия_на_учителяTextBox.Name = "Фамилия_на_учителяTextBox"
        Me.Фамилия_на_учителяTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Фамилия_на_учителяTextBox.TabIndex = 11
        '
        'btnRedakchia
        '
        Me.btnRedakchia.Location = New System.Drawing.Point(74, 98)
        Me.btnRedakchia.Name = "btnRedakchia"
        Me.btnRedakchia.Size = New System.Drawing.Size(116, 44)
        Me.btnRedakchia.TabIndex = 6
        Me.btnRedakchia.Text = "Редактирай учител"
        Me.btnRedakchia.UseVisualStyleBackColor = True
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "helpHTML\HelpHTML.chm"
        Me.HelpProvider1.Tag = "F1"
        '
        'teachers_manual_input
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 404)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.TeachersDataGridView)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.HelpProvider1.SetHelpKeyword(Me, "Учители")
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.HelpProvider1.SetHelpString(Me, "Учители")
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "teachers_manual_input"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Въвеждане, изтриване и редактиране на учители"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.TeachersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Learning_activityDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TeachersDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btndeletesubject As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblIdAdd As System.Windows.Forms.Label
    Friend WithEvents txtfamiliUcitel As System.Windows.Forms.TextBox
    Friend WithEvents txtnameUcitel As System.Windows.Forms.TextBox
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents Learning_activityDataSet As learning_activity.learning_activityDataSet
    Friend WithEvents TeachersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TeachersTableAdapter As learning_activity.learning_activityDataSetTableAdapters.teachersTableAdapter
    Friend WithEvents TableAdapterManager As learning_activity.learning_activityDataSetTableAdapters.TableAdapterManager
    Friend WithEvents lblFamily_teacherDel As System.Windows.Forms.Label
    Friend WithEvents lblName_teacherDel As System.Windows.Forms.Label
    Friend WithEvents lblIdDel As System.Windows.Forms.Label
    Friend WithEvents TeachersDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnRedakchia As System.Windows.Forms.Button
    Friend WithEvents НомерLabel1 As System.Windows.Forms.Label
    Friend WithEvents Име_на_учителяTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Фамилия_на_учителяTextBox As System.Windows.Forms.TextBox
    Private WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
