<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class type_manual_input
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
        Dim lbltype As System.Windows.Forms.Label
        Dim НомерLabel As System.Windows.Forms.Label
        Dim Вид_оценкаLabel As System.Windows.Forms.Label
        Dim НомерLabel1 As System.Windows.Forms.Label
        Dim Вид_оценкаLabel1 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(type_manual_input))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblIdDel = New System.Windows.Forms.Label()
        Me.TypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Learning_activityDataSet = New learning_activity.learning_activityDataSet()
        Me.lbltypeDel = New System.Windows.Forms.Label()
        Me.btndeletesubject = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txttypeUp = New System.Windows.Forms.TextBox()
        Me.lblid = New System.Windows.Forms.Label()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.TypesDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypesTableAdapter = New learning_activity.learning_activityDataSetTableAdapters.typesTableAdapter()
        Me.TableAdapterManager = New learning_activity.learning_activityDataSetTableAdapters.TableAdapterManager()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblikdR = New System.Windows.Forms.Label()
        Me.txtTR = New System.Windows.Forms.TextBox()
        Me.btnR = New System.Windows.Forms.Button()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        IdLabel = New System.Windows.Forms.Label()
        lbltype = New System.Windows.Forms.Label()
        НомерLabel = New System.Windows.Forms.Label()
        Вид_оценкаLabel = New System.Windows.Forms.Label()
        НомерLabel1 = New System.Windows.Forms.Label()
        Вид_оценкаLabel1 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Learning_activityDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TypesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'IdLabel
        '
        IdLabel.AutoSize = True
        IdLabel.Location = New System.Drawing.Point(26, 29)
        IdLabel.Name = "IdLabel"
        IdLabel.Size = New System.Drawing.Size(29, 13)
        IdLabel.TabIndex = 2
        IdLabel.Text = "Код:"
        '
        'lbltype
        '
        lbltype.AutoSize = True
        lbltype.Location = New System.Drawing.Point(26, 53)
        lbltype.Name = "lbltype"
        lbltype.Size = New System.Drawing.Size(68, 13)
        lbltype.TabIndex = 4
        lbltype.Text = "Вид оценка:"
        '
        'НомерLabel
        '
        НомерLabel.AutoSize = True
        НомерLabel.Location = New System.Drawing.Point(39, 33)
        НомерLabel.Name = "НомерLabel"
        НомерLabel.Size = New System.Drawing.Size(29, 13)
        НомерLabel.TabIndex = 6
        НомерLabel.Text = "Код:"
        '
        'Вид_оценкаLabel
        '
        Вид_оценкаLabel.AutoSize = True
        Вид_оценкаLabel.Location = New System.Drawing.Point(39, 56)
        Вид_оценкаLabel.Name = "Вид_оценкаLabel"
        Вид_оценкаLabel.Size = New System.Drawing.Size(68, 13)
        Вид_оценкаLabel.TabIndex = 8
        Вид_оценкаLabel.Text = "Вид оценка:"
        '
        'НомерLabel1
        '
        НомерLabel1.AutoSize = True
        НомерLabel1.Location = New System.Drawing.Point(6, 29)
        НомерLabel1.Name = "НомерLabel1"
        НомерLabel1.Size = New System.Drawing.Size(29, 13)
        НомерLabel1.TabIndex = 6
        НомерLabel1.Text = "Код:"
        '
        'Вид_оценкаLabel1
        '
        Вид_оценкаLabel1.AutoSize = True
        Вид_оценкаLabel1.Location = New System.Drawing.Point(6, 58)
        Вид_оценкаLabel1.Name = "Вид_оценкаLabel1"
        Вид_оценкаLabel1.Size = New System.Drawing.Size(68, 13)
        Вид_оценкаLabel1.TabIndex = 8
        Вид_оценкаLabel1.Text = "Вид оценка:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(НомерLabel)
        Me.GroupBox2.Controls.Add(Me.lblIdDel)
        Me.GroupBox2.Controls.Add(Вид_оценкаLabel)
        Me.GroupBox2.Controls.Add(Me.lbltypeDel)
        Me.GroupBox2.Controls.Add(Me.btndeletesubject)
        Me.GroupBox2.Location = New System.Drawing.Point(236, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(221, 136)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Премахванена на видове оценки"
        '
        'lblIdDel
        '
        Me.lblIdDel.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TypesBindingSource, "Номер", True))
        Me.lblIdDel.Location = New System.Drawing.Point(113, 33)
        Me.lblIdDel.Name = "lblIdDel"
        Me.lblIdDel.Size = New System.Drawing.Size(100, 23)
        Me.lblIdDel.TabIndex = 7
        Me.lblIdDel.Text = "Label1"
        '
        'TypesBindingSource
        '
        Me.TypesBindingSource.DataMember = "types"
        Me.TypesBindingSource.DataSource = Me.Learning_activityDataSet
        '
        'Learning_activityDataSet
        '
        Me.Learning_activityDataSet.DataSetName = "learning_activityDataSet"
        Me.Learning_activityDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lbltypeDel
        '
        Me.lbltypeDel.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TypesBindingSource, "Вид оценка", True))
        Me.lbltypeDel.Location = New System.Drawing.Point(113, 56)
        Me.lbltypeDel.Name = "lbltypeDel"
        Me.lbltypeDel.Size = New System.Drawing.Size(100, 23)
        Me.lbltypeDel.TabIndex = 9
        Me.lbltypeDel.Text = "Label1"
        '
        'btndeletesubject
        '
        Me.btndeletesubject.Location = New System.Drawing.Point(42, 82)
        Me.btndeletesubject.Name = "btndeletesubject"
        Me.btndeletesubject.Size = New System.Drawing.Size(142, 44)
        Me.btndeletesubject.TabIndex = 6
        Me.btndeletesubject.Text = "Изтрий вид оценка"
        Me.btndeletesubject.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txttypeUp)
        Me.GroupBox1.Controls.Add(lbltype)
        Me.GroupBox1.Controls.Add(Me.lblid)
        Me.GroupBox1.Controls.Add(IdLabel)
        Me.GroupBox1.Controls.Add(Me.btnUpload)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(215, 136)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Добавяне на видове оценки"
        '
        'txttypeUp
        '
        Me.txttypeUp.Location = New System.Drawing.Point(99, 52)
        Me.txttypeUp.MaxLength = 24
        Me.txttypeUp.Name = "txttypeUp"
        Me.txttypeUp.Size = New System.Drawing.Size(104, 20)
        Me.txttypeUp.TabIndex = 8
        '
        'lblid
        '
        Me.lblid.Location = New System.Drawing.Point(99, 25)
        Me.lblid.Name = "lblid"
        Me.lblid.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblid.Size = New System.Drawing.Size(104, 21)
        Me.lblid.TabIndex = 7
        Me.lblid.Text = "0"
        Me.lblid.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnUpload
        '
        Me.btnUpload.Location = New System.Drawing.Point(62, 78)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(141, 44)
        Me.btnUpload.TabIndex = 6
        Me.btnUpload.Text = "Въведи вид оценка"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'TypesDataGridView
        '
        Me.TypesDataGridView.AllowUserToAddRows = False
        Me.TypesDataGridView.AllowUserToDeleteRows = False
        Me.TypesDataGridView.AutoGenerateColumns = False
        Me.TypesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TypesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.TypesDataGridView.DataSource = Me.TypesBindingSource
        Me.TypesDataGridView.Location = New System.Drawing.Point(114, 154)
        Me.TypesDataGridView.Name = "TypesDataGridView"
        Me.TypesDataGridView.ReadOnly = True
        Me.TypesDataGridView.Size = New System.Drawing.Size(431, 259)
        Me.TypesDataGridView.TabIndex = 14
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
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Вид оценка"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Вид оценка"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 260
        '
        'TypesTableAdapter
        '
        Me.TypesTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.absenceTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.classesTableAdapter = Nothing
        Me.TableAdapterManager.profilesTableAdapter = Nothing
        Me.TableAdapterManager.purposeTableAdapter = Nothing
        Me.TableAdapterManager.subjectTableAdapter = Nothing
        Me.TableAdapterManager.teachersTableAdapter = Nothing
        Me.TableAdapterManager.teachingTableAdapter = Nothing
        Me.TableAdapterManager.typesTableAdapter = Me.TypesTableAdapter
        Me.TableAdapterManager.UpdateOrder = learning_activity.learning_activityDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(НомерLabel1)
        Me.GroupBox3.Controls.Add(Me.lblikdR)
        Me.GroupBox3.Controls.Add(Вид_оценкаLabel1)
        Me.GroupBox3.Controls.Add(Me.txtTR)
        Me.GroupBox3.Controls.Add(Me.btnR)
        Me.GroupBox3.Location = New System.Drawing.Point(463, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(215, 136)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Редактиране на видове оценки"
        '
        'lblikdR
        '
        Me.lblikdR.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TypesBindingSource, "Номер", True))
        Me.lblikdR.Location = New System.Drawing.Point(80, 29)
        Me.lblikdR.Name = "lblikdR"
        Me.lblikdR.Size = New System.Drawing.Size(100, 23)
        Me.lblikdR.TabIndex = 7
        Me.lblikdR.Text = "Label1"
        '
        'txtTR
        '
        Me.txtTR.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TypesBindingSource, "Вид оценка", True))
        Me.txtTR.Location = New System.Drawing.Point(80, 55)
        Me.txtTR.Name = "txtTR"
        Me.txtTR.Size = New System.Drawing.Size(100, 20)
        Me.txtTR.TabIndex = 9
        '
        'btnR
        '
        Me.btnR.Location = New System.Drawing.Point(54, 82)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(141, 44)
        Me.btnR.TabIndex = 6
        Me.btnR.Text = "Редактирай вид оценка"
        Me.btnR.UseVisualStyleBackColor = True
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "helpHTML\HelpHTML.chm"
        Me.HelpProvider1.Tag = "F1"
        '
        'type_manual_input
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(690, 425)
        Me.Controls.Add(Me.TypesDataGridView)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider1.SetHelpKeyword(Me, "Видове оценки")
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.HelpProvider1.SetHelpString(Me, "Видове оценки")
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "type_manual_input"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Въвеждане, изтриване и редактиране на видове оценки"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.TypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Learning_activityDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TypesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btndeletesubject As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents Learning_activityDataSet As learning_activity.learning_activityDataSet
    Friend WithEvents TypesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TypesTableAdapter As learning_activity.learning_activityDataSetTableAdapters.typesTableAdapter
    Friend WithEvents TableAdapterManager As learning_activity.learning_activityDataSetTableAdapters.TableAdapterManager
    Friend WithEvents txttypeUp As System.Windows.Forms.TextBox
    Friend WithEvents lblid As System.Windows.Forms.Label
    Friend WithEvents TypesDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents lblIdDel As System.Windows.Forms.Label
    Friend WithEvents lbltypeDel As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnR As System.Windows.Forms.Button
    Friend WithEvents lblikdR As System.Windows.Forms.Label
    Friend WithEvents txtTR As System.Windows.Forms.TextBox
    Private WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
