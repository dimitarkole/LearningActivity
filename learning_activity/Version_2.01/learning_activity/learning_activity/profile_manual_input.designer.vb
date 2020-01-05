<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Profile_manual_input
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
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim IdLabel As System.Windows.Forms.Label
        Dim Name_profileLabel As System.Windows.Forms.Label
        Dim Pp4Label As System.Windows.Forms.Label
        Dim Pp1Label As System.Windows.Forms.Label
        Dim Pp3Label As System.Windows.Forms.Label
        Dim Pp2Label As System.Windows.Forms.Label
        Dim НомерLabel As System.Windows.Forms.Label
        Dim Име_на_профилаLabel As System.Windows.Forms.Label
        Dim Пърши_профилиращ_предметLabel As System.Windows.Forms.Label
        Dim Втори_профилиращ_предметLabel As System.Windows.Forms.Label
        Dim Трети_профилиращ_предметLabel As System.Windows.Forms.Label
        Dim Четвърти_профилиращ_предметLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Profile_manual_input))
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.iddgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.name_profiledgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pp1dgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pp2dgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pp3dgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pp4dgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btndeleteprofile = New System.Windows.Forms.Button()
        Me.lblIdDel = New System.Windows.Forms.Label()
        Me.lblNameDel = New System.Windows.Forms.Label()
        Me.lblpp1Del = New System.Windows.Forms.Label()
        Me.lblpp2Del = New System.Windows.Forms.Label()
        Me.lblpp3Del = New System.Windows.Forms.Label()
        Me.lblpp4Del = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.txtUpID = New System.Windows.Forms.Label()
        Me.txtUpPP4 = New System.Windows.Forms.ComboBox()
        Me.txtUpName = New System.Windows.Forms.TextBox()
        Me.txtUpPP3 = New System.Windows.Forms.ComboBox()
        Me.txtUpPP1 = New System.Windows.Forms.ComboBox()
        Me.Learning_activityDataSet = New learning_activity.learning_activityDataSet()
        Me.txtUpPP2 = New System.Windows.Forms.ComboBox()
        Me.ProfilesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SubjectBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProfilesTableAdapter = New learning_activity.learning_activityDataSetTableAdapters.profilesTableAdapter()
        Me.TableAdapterManager = New learning_activity.learning_activityDataSetTableAdapters.TableAdapterManager()
        Me.SubjectTableAdapter = New learning_activity.learning_activityDataSetTableAdapters.subjectTableAdapter()
        Me.btnRedakchia = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblidR = New System.Windows.Forms.Label()
        Me.txtNameR = New System.Windows.Forms.TextBox()
        Me.cmbpp4RId = New System.Windows.Forms.ComboBox()
        Me.cmbpp3RId = New System.Windows.Forms.ComboBox()
        Me.cmbpp2RId = New System.Windows.Forms.ComboBox()
        Me.cmbpp1RId = New System.Windows.Forms.ComboBox()
        Me.cmbpp1R = New System.Windows.Forms.ComboBox()
        Me.cmbpp2R = New System.Windows.Forms.ComboBox()
        Me.cmbpp3R = New System.Windows.Forms.ComboBox()
        Me.cmbpp4R = New System.Windows.Forms.ComboBox()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Label1 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        IdLabel = New System.Windows.Forms.Label()
        Name_profileLabel = New System.Windows.Forms.Label()
        Pp4Label = New System.Windows.Forms.Label()
        Pp1Label = New System.Windows.Forms.Label()
        Pp3Label = New System.Windows.Forms.Label()
        Pp2Label = New System.Windows.Forms.Label()
        НомерLabel = New System.Windows.Forms.Label()
        Име_на_профилаLabel = New System.Windows.Forms.Label()
        Пърши_профилиращ_предметLabel = New System.Windows.Forms.Label()
        Втори_профилиращ_предметLabel = New System.Windows.Forms.Label()
        Трети_профилиращ_предметLabel = New System.Windows.Forms.Label()
        Четвърти_профилиращ_предметLabel = New System.Windows.Forms.Label()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Learning_activityDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProfilesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SubjectBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(26, 26)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(29, 13)
        Label1.TabIndex = 18
        Label1.Text = "Код:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(26, 53)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(94, 13)
        Label2.TabIndex = 19
        Label2.Text = "Име на профила:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(26, 161)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(173, 13)
        Label3.TabIndex = 23
        Label3.Text = "Четвърти профилиращ предмет:"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(26, 80)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(157, 13)
        Label4.TabIndex = 20
        Label4.Text = "Първи профилиращ предмет:"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(26, 134)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(154, 13)
        Label5.TabIndex = 22
        Label5.Text = "Трети профилиращ предмет:"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(26, 107)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(154, 13)
        Label6.TabIndex = 21
        Label6.Text = "Втори профилиращ предмет:"
        '
        'IdLabel
        '
        IdLabel.AutoSize = True
        IdLabel.Location = New System.Drawing.Point(6, 26)
        IdLabel.Name = "IdLabel"
        IdLabel.Size = New System.Drawing.Size(29, 13)
        IdLabel.TabIndex = 4
        IdLabel.Text = "Код:"
        '
        'Name_profileLabel
        '
        Name_profileLabel.AutoSize = True
        Name_profileLabel.Location = New System.Drawing.Point(6, 53)
        Name_profileLabel.Name = "Name_profileLabel"
        Name_profileLabel.Size = New System.Drawing.Size(94, 13)
        Name_profileLabel.TabIndex = 6
        Name_profileLabel.Text = "Име на профила:"
        '
        'Pp4Label
        '
        Pp4Label.AutoSize = True
        Pp4Label.Location = New System.Drawing.Point(6, 161)
        Pp4Label.Name = "Pp4Label"
        Pp4Label.Size = New System.Drawing.Size(173, 13)
        Pp4Label.TabIndex = 14
        Pp4Label.Text = "Четвърти профилиращ предмет:"
        '
        'Pp1Label
        '
        Pp1Label.AutoSize = True
        Pp1Label.Location = New System.Drawing.Point(6, 80)
        Pp1Label.Name = "Pp1Label"
        Pp1Label.Size = New System.Drawing.Size(157, 13)
        Pp1Label.TabIndex = 8
        Pp1Label.Text = "Първи профилиращ предмет:"
        '
        'Pp3Label
        '
        Pp3Label.AutoSize = True
        Pp3Label.Location = New System.Drawing.Point(6, 134)
        Pp3Label.Name = "Pp3Label"
        Pp3Label.Size = New System.Drawing.Size(154, 13)
        Pp3Label.TabIndex = 12
        Pp3Label.Text = "Трети профилиращ предмет:"
        '
        'Pp2Label
        '
        Pp2Label.AutoSize = True
        Pp2Label.Location = New System.Drawing.Point(6, 107)
        Pp2Label.Name = "Pp2Label"
        Pp2Label.Size = New System.Drawing.Size(154, 13)
        Pp2Label.TabIndex = 10
        Pp2Label.Text = "Втори профилиращ предмет:"
        '
        'НомерLabel
        '
        НомерLabel.AutoSize = True
        НомерLabel.Location = New System.Drawing.Point(23, 26)
        НомерLabel.Name = "НомерLabel"
        НомерLabel.Size = New System.Drawing.Size(29, 13)
        НомерLabel.TabIndex = 12
        НомерLabel.Text = "Код:"
        '
        'Име_на_профилаLabel
        '
        Име_на_профилаLabel.AutoSize = True
        Име_на_профилаLabel.Location = New System.Drawing.Point(23, 55)
        Име_на_профилаLabel.Name = "Име_на_профилаLabel"
        Име_на_профилаLabel.Size = New System.Drawing.Size(94, 13)
        Име_на_профилаLabel.TabIndex = 14
        Име_на_профилаLabel.Text = "Име на профила:"
        '
        'Пърши_профилиращ_предметLabel
        '
        Пърши_профилиращ_предметLabel.AutoSize = True
        Пърши_профилиращ_предметLabel.Location = New System.Drawing.Point(23, 81)
        Пърши_профилиращ_предметLabel.Name = "Пърши_профилиращ_предметLabel"
        Пърши_профилиращ_предметLabel.Size = New System.Drawing.Size(157, 13)
        Пърши_профилиращ_предметLabel.TabIndex = 16
        Пърши_профилиращ_предметLabel.Text = "Първи профилиращ предмет:"
        '
        'Втори_профилиращ_предметLabel
        '
        Втори_профилиращ_предметLabel.AutoSize = True
        Втори_профилиращ_предметLabel.Location = New System.Drawing.Point(23, 108)
        Втори_профилиращ_предметLabel.Name = "Втори_профилиращ_предметLabel"
        Втори_профилиращ_предметLabel.Size = New System.Drawing.Size(154, 13)
        Втори_профилиращ_предметLabel.TabIndex = 18
        Втори_профилиращ_предметLabel.Text = "Втори профилиращ предмет:"
        '
        'Трети_профилиращ_предметLabel
        '
        Трети_профилиращ_предметLabel.AutoSize = True
        Трети_профилиращ_предметLabel.Location = New System.Drawing.Point(23, 135)
        Трети_профилиращ_предметLabel.Name = "Трети_профилиращ_предметLabel"
        Трети_профилиращ_предметLabel.Size = New System.Drawing.Size(154, 13)
        Трети_профилиращ_предметLabel.TabIndex = 20
        Трети_профилиращ_предметLabel.Text = "Трети профилиращ предмет:"
        '
        'Четвърти_профилиращ_предметLabel
        '
        Четвърти_профилиращ_предметLabel.AutoSize = True
        Четвърти_профилиращ_предметLabel.Location = New System.Drawing.Point(23, 162)
        Четвърти_профилиращ_предметLabel.Name = "Четвърти_профилиращ_предметLabel"
        Четвърти_профилиращ_предметLabel.Size = New System.Drawing.Size(173, 13)
        Четвърти_профилиращ_предметLabel.TabIndex = 22
        Четвърти_профилиращ_предметLabel.Text = "Четвърти профилиращ предмет:"
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.iddgv, Me.name_profiledgv, Me.pp1dgv, Me.pp2dgv, Me.pp3dgv, Me.pp4dgv})
        Me.dgv1.Location = New System.Drawing.Point(21, 259)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(1115, 253)
        Me.dgv1.TabIndex = 0
        '
        'iddgv
        '
        Me.iddgv.HeaderText = "Код"
        Me.iddgv.Name = "iddgv"
        Me.iddgv.ReadOnly = True
        '
        'name_profiledgv
        '
        Me.name_profiledgv.HeaderText = "Име на профила"
        Me.name_profiledgv.Name = "name_profiledgv"
        Me.name_profiledgv.ReadOnly = True
        Me.name_profiledgv.Width = 170
        '
        'pp1dgv
        '
        Me.pp1dgv.HeaderText = "Първи профилиращ предмет"
        Me.pp1dgv.Name = "pp1dgv"
        Me.pp1dgv.ReadOnly = True
        Me.pp1dgv.Width = 200
        '
        'pp2dgv
        '
        Me.pp2dgv.HeaderText = "Втори профилиращ предмет"
        Me.pp2dgv.Name = "pp2dgv"
        Me.pp2dgv.ReadOnly = True
        Me.pp2dgv.Width = 200
        '
        'pp3dgv
        '
        Me.pp3dgv.HeaderText = "Трети профилиращ предмет"
        Me.pp3dgv.Name = "pp3dgv"
        Me.pp3dgv.ReadOnly = True
        Me.pp3dgv.Width = 200
        '
        'pp4dgv
        '
        Me.pp4dgv.HeaderText = "Четвърти профилиращ предмет"
        Me.pp4dgv.Name = "pp4dgv"
        Me.pp4dgv.ReadOnly = True
        Me.pp4dgv.Width = 200
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btndeleteprofile)
        Me.GroupBox2.Controls.Add(Label1)
        Me.GroupBox2.Controls.Add(Label2)
        Me.GroupBox2.Controls.Add(Label3)
        Me.GroupBox2.Controls.Add(Label4)
        Me.GroupBox2.Controls.Add(Label5)
        Me.GroupBox2.Controls.Add(Label6)
        Me.GroupBox2.Controls.Add(Me.lblIdDel)
        Me.GroupBox2.Controls.Add(Me.lblNameDel)
        Me.GroupBox2.Controls.Add(Me.lblpp1Del)
        Me.GroupBox2.Controls.Add(Me.lblpp2Del)
        Me.GroupBox2.Controls.Add(Me.lblpp3Del)
        Me.GroupBox2.Controls.Add(Me.lblpp4Del)
        Me.GroupBox2.Location = New System.Drawing.Point(386, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(388, 241)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Изтриване на профил"
        '
        'btndeleteprofile
        '
        Me.btndeleteprofile.Enabled = False
        Me.btndeleteprofile.Location = New System.Drawing.Point(218, 189)
        Me.btndeleteprofile.Name = "btndeleteprofile"
        Me.btndeleteprofile.Size = New System.Drawing.Size(112, 44)
        Me.btndeleteprofile.TabIndex = 24
        Me.btndeleteprofile.Text = "Изтрий профил"
        Me.btndeleteprofile.UseVisualStyleBackColor = True
        '
        'lblIdDel
        '
        Me.lblIdDel.Location = New System.Drawing.Point(215, 26)
        Me.lblIdDel.Name = "lblIdDel"
        Me.lblIdDel.Size = New System.Drawing.Size(148, 23)
        Me.lblIdDel.TabIndex = 7
        '
        'lblNameDel
        '
        Me.lblNameDel.Location = New System.Drawing.Point(215, 58)
        Me.lblNameDel.Name = "lblNameDel"
        Me.lblNameDel.Size = New System.Drawing.Size(148, 23)
        Me.lblNameDel.TabIndex = 9
        '
        'lblpp1Del
        '
        Me.lblpp1Del.Location = New System.Drawing.Point(215, 84)
        Me.lblpp1Del.Name = "lblpp1Del"
        Me.lblpp1Del.Size = New System.Drawing.Size(148, 23)
        Me.lblpp1Del.TabIndex = 11
        '
        'lblpp2Del
        '
        Me.lblpp2Del.Location = New System.Drawing.Point(215, 111)
        Me.lblpp2Del.Name = "lblpp2Del"
        Me.lblpp2Del.Size = New System.Drawing.Size(148, 23)
        Me.lblpp2Del.TabIndex = 13
        '
        'lblpp3Del
        '
        Me.lblpp3Del.Location = New System.Drawing.Point(215, 134)
        Me.lblpp3Del.Name = "lblpp3Del"
        Me.lblpp3Del.Size = New System.Drawing.Size(148, 23)
        Me.lblpp3Del.TabIndex = 15
        '
        'lblpp4Del
        '
        Me.lblpp4Del.Location = New System.Drawing.Point(215, 161)
        Me.lblpp4Del.Name = "lblpp4Del"
        Me.lblpp4Del.Size = New System.Drawing.Size(148, 23)
        Me.lblpp4Del.TabIndex = 17
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnUpload)
        Me.GroupBox1.Controls.Add(IdLabel)
        Me.GroupBox1.Controls.Add(Me.txtUpID)
        Me.GroupBox1.Controls.Add(Me.txtUpPP4)
        Me.GroupBox1.Controls.Add(Name_profileLabel)
        Me.GroupBox1.Controls.Add(Pp4Label)
        Me.GroupBox1.Controls.Add(Me.txtUpName)
        Me.GroupBox1.Controls.Add(Me.txtUpPP3)
        Me.GroupBox1.Controls.Add(Pp1Label)
        Me.GroupBox1.Controls.Add(Pp3Label)
        Me.GroupBox1.Controls.Add(Me.txtUpPP1)
        Me.GroupBox1.Controls.Add(Me.txtUpPP2)
        Me.GroupBox1.Controls.Add(Pp2Label)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(368, 241)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Добавяне на профил"
        '
        'btnUpload
        '
        Me.btnUpload.Location = New System.Drawing.Point(214, 189)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(112, 44)
        Me.btnUpload.TabIndex = 6
        Me.btnUpload.Text = "Въведи профил"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'txtUpID
        '
        Me.txtUpID.Location = New System.Drawing.Point(187, 26)
        Me.txtUpID.Name = "txtUpID"
        Me.txtUpID.Size = New System.Drawing.Size(152, 23)
        Me.txtUpID.TabIndex = 5
        Me.txtUpID.Text = "Label1"
        '
        'txtUpPP4
        '
        Me.txtUpPP4.FormattingEnabled = True
        Me.txtUpPP4.Location = New System.Drawing.Point(187, 162)
        Me.txtUpPP4.Name = "txtUpPP4"
        Me.txtUpPP4.Size = New System.Drawing.Size(152, 21)
        Me.txtUpPP4.TabIndex = 15
        '
        'txtUpName
        '
        Me.txtUpName.Location = New System.Drawing.Point(187, 55)
        Me.txtUpName.MaxLength = 50
        Me.txtUpName.Name = "txtUpName"
        Me.txtUpName.Size = New System.Drawing.Size(152, 20)
        Me.txtUpName.TabIndex = 7
        '
        'txtUpPP3
        '
        Me.txtUpPP3.FormattingEnabled = True
        Me.txtUpPP3.Location = New System.Drawing.Point(187, 135)
        Me.txtUpPP3.Name = "txtUpPP3"
        Me.txtUpPP3.Size = New System.Drawing.Size(152, 21)
        Me.txtUpPP3.TabIndex = 13
        '
        'txtUpPP1
        '
        Me.txtUpPP1.DataBindings.Add(New System.Windows.Forms.Binding("Tag", Me.Learning_activityDataSet, "subject.Номер", True))
        Me.txtUpPP1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Learning_activityDataSet, "subject.Име на предмета", True))
        Me.txtUpPP1.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.Learning_activityDataSet, "subject.Номер", True))
        Me.txtUpPP1.DataBindings.Add(New System.Windows.Forms.Binding("SelectedItem", Me.Learning_activityDataSet, "subject.Име на предмета", True))
        Me.txtUpPP1.FormattingEnabled = True
        Me.txtUpPP1.Location = New System.Drawing.Point(187, 81)
        Me.txtUpPP1.Name = "txtUpPP1"
        Me.txtUpPP1.Size = New System.Drawing.Size(152, 21)
        Me.txtUpPP1.TabIndex = 9
        '
        'Learning_activityDataSet
        '
        Me.Learning_activityDataSet.DataSetName = "learning_activityDataSet"
        Me.Learning_activityDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtUpPP2
        '
        Me.txtUpPP2.FormattingEnabled = True
        Me.txtUpPP2.Location = New System.Drawing.Point(187, 108)
        Me.txtUpPP2.Name = "txtUpPP2"
        Me.txtUpPP2.Size = New System.Drawing.Size(152, 21)
        Me.txtUpPP2.TabIndex = 11
        '
        'ProfilesBindingSource
        '
        Me.ProfilesBindingSource.DataMember = "profiles"
        Me.ProfilesBindingSource.DataSource = Me.Learning_activityDataSet
        '
        'SubjectBindingSource
        '
        Me.SubjectBindingSource.DataMember = "subject"
        Me.SubjectBindingSource.DataSource = Me.Learning_activityDataSet
        '
        'ProfilesTableAdapter
        '
        Me.ProfilesTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.absenceTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.classesTableAdapter = Nothing
        Me.TableAdapterManager.profilesTableAdapter = Me.ProfilesTableAdapter
        Me.TableAdapterManager.purposeTableAdapter = Nothing
        Me.TableAdapterManager.subjectTableAdapter = Me.SubjectTableAdapter
        Me.TableAdapterManager.teachersTableAdapter = Nothing
        Me.TableAdapterManager.teachingTableAdapter = Nothing
        Me.TableAdapterManager.typesTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = learning_activity.learning_activityDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'SubjectTableAdapter
        '
        Me.SubjectTableAdapter.ClearBeforeFill = True
        '
        'btnRedakchia
        '
        Me.btnRedakchia.Location = New System.Drawing.Point(160, 189)
        Me.btnRedakchia.Name = "btnRedakchia"
        Me.btnRedakchia.Size = New System.Drawing.Size(141, 44)
        Me.btnRedakchia.TabIndex = 12
        Me.btnRedakchia.Text = "Редактирай профила"
        Me.btnRedakchia.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(НомерLabel)
        Me.GroupBox3.Controls.Add(Me.lblidR)
        Me.GroupBox3.Controls.Add(Име_на_профилаLabel)
        Me.GroupBox3.Controls.Add(Me.txtNameR)
        Me.GroupBox3.Controls.Add(Пърши_профилиращ_предметLabel)
        Me.GroupBox3.Controls.Add(Me.cmbpp4RId)
        Me.GroupBox3.Controls.Add(Me.cmbpp3RId)
        Me.GroupBox3.Controls.Add(Me.cmbpp2RId)
        Me.GroupBox3.Controls.Add(Me.cmbpp1RId)
        Me.GroupBox3.Controls.Add(Me.cmbpp1R)
        Me.GroupBox3.Controls.Add(Втори_профилиращ_предметLabel)
        Me.GroupBox3.Controls.Add(Me.cmbpp2R)
        Me.GroupBox3.Controls.Add(Трети_профилиращ_предметLabel)
        Me.GroupBox3.Controls.Add(Me.cmbpp3R)
        Me.GroupBox3.Controls.Add(Четвърти_профилиращ_предметLabel)
        Me.GroupBox3.Controls.Add(Me.cmbpp4R)
        Me.GroupBox3.Controls.Add(Me.btnRedakchia)
        Me.GroupBox3.Location = New System.Drawing.Point(790, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(377, 241)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Редактиране на профил"
        '
        'lblidR
        '
        Me.lblidR.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProfilesBindingSource, "Номер", True))
        Me.lblidR.Location = New System.Drawing.Point(202, 26)
        Me.lblidR.Name = "lblidR"
        Me.lblidR.Size = New System.Drawing.Size(163, 23)
        Me.lblidR.TabIndex = 13
        Me.lblidR.Text = "Label7"
        '
        'txtNameR
        '
        Me.txtNameR.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProfilesBindingSource, "Име на профила", True))
        Me.txtNameR.Location = New System.Drawing.Point(202, 52)
        Me.txtNameR.MaxLength = 50
        Me.txtNameR.Name = "txtNameR"
        Me.txtNameR.Size = New System.Drawing.Size(163, 20)
        Me.txtNameR.TabIndex = 15
        '
        'cmbpp4RId
        '
        Me.cmbpp4RId.FormattingEnabled = True
        Me.cmbpp4RId.Location = New System.Drawing.Point(371, 158)
        Me.cmbpp4RId.Name = "cmbpp4RId"
        Me.cmbpp4RId.Size = New System.Drawing.Size(43, 21)
        Me.cmbpp4RId.TabIndex = 17
        Me.cmbpp4RId.Visible = False
        '
        'cmbpp3RId
        '
        Me.cmbpp3RId.FormattingEnabled = True
        Me.cmbpp3RId.Location = New System.Drawing.Point(371, 132)
        Me.cmbpp3RId.Name = "cmbpp3RId"
        Me.cmbpp3RId.Size = New System.Drawing.Size(43, 21)
        Me.cmbpp3RId.TabIndex = 17
        Me.cmbpp3RId.Visible = False
        '
        'cmbpp2RId
        '
        Me.cmbpp2RId.FormattingEnabled = True
        Me.cmbpp2RId.Location = New System.Drawing.Point(371, 107)
        Me.cmbpp2RId.Name = "cmbpp2RId"
        Me.cmbpp2RId.Size = New System.Drawing.Size(43, 21)
        Me.cmbpp2RId.TabIndex = 17
        Me.cmbpp2RId.Visible = False
        '
        'cmbpp1RId
        '
        Me.cmbpp1RId.FormattingEnabled = True
        Me.cmbpp1RId.Location = New System.Drawing.Point(371, 78)
        Me.cmbpp1RId.Name = "cmbpp1RId"
        Me.cmbpp1RId.Size = New System.Drawing.Size(43, 21)
        Me.cmbpp1RId.TabIndex = 17
        Me.cmbpp1RId.Visible = False
        '
        'cmbpp1R
        '
        Me.cmbpp1R.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProfilesBindingSource, "Пърши профилиращ предмет", True))
        Me.cmbpp1R.FormattingEnabled = True
        Me.cmbpp1R.Location = New System.Drawing.Point(202, 78)
        Me.cmbpp1R.Name = "cmbpp1R"
        Me.cmbpp1R.Size = New System.Drawing.Size(163, 21)
        Me.cmbpp1R.TabIndex = 17
        '
        'cmbpp2R
        '
        Me.cmbpp2R.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProfilesBindingSource, "Втори профилиращ предмет", True))
        Me.cmbpp2R.FormattingEnabled = True
        Me.cmbpp2R.Location = New System.Drawing.Point(202, 105)
        Me.cmbpp2R.Name = "cmbpp2R"
        Me.cmbpp2R.Size = New System.Drawing.Size(163, 21)
        Me.cmbpp2R.TabIndex = 19
        '
        'cmbpp3R
        '
        Me.cmbpp3R.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProfilesBindingSource, "Трети профилиращ предмет", True))
        Me.cmbpp3R.FormattingEnabled = True
        Me.cmbpp3R.Location = New System.Drawing.Point(202, 132)
        Me.cmbpp3R.Name = "cmbpp3R"
        Me.cmbpp3R.Size = New System.Drawing.Size(163, 21)
        Me.cmbpp3R.TabIndex = 21
        '
        'cmbpp4R
        '
        Me.cmbpp4R.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProfilesBindingSource, "Четвърти профилиращ предмет", True))
        Me.cmbpp4R.FormattingEnabled = True
        Me.cmbpp4R.Location = New System.Drawing.Point(202, 159)
        Me.cmbpp4R.Name = "cmbpp4R"
        Me.cmbpp4R.Size = New System.Drawing.Size(163, 21)
        Me.cmbpp4R.TabIndex = 23
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "helpHTML\HelpHTML.chm"
        Me.HelpProvider1.Tag = "F1"
        '
        'Profile_manual_input
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1173, 520)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgv1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.HelpProvider1.SetHelpKeyword(Me, "Профили")
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.HelpProvider1.SetHelpString(Me, "Профили")
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Profile_manual_input"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Въвеждане, изтриване и редактиране на профили"
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Learning_activityDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProfilesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SubjectBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btndeleteprofile As System.Windows.Forms.Button
    Friend WithEvents lblIdDel As System.Windows.Forms.Label
    Friend WithEvents lblNameDel As System.Windows.Forms.Label
    Friend WithEvents lblpp1Del As System.Windows.Forms.Label
    Friend WithEvents lblpp2Del As System.Windows.Forms.Label
    Friend WithEvents lblpp3Del As System.Windows.Forms.Label
    Friend WithEvents lblpp4Del As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents txtUpID As System.Windows.Forms.Label
    Friend WithEvents txtUpPP4 As System.Windows.Forms.ComboBox
    Friend WithEvents txtUpName As System.Windows.Forms.TextBox
    Friend WithEvents txtUpPP3 As System.Windows.Forms.ComboBox
    Friend WithEvents txtUpPP1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtUpPP2 As System.Windows.Forms.ComboBox
    Friend WithEvents Learning_activityDataSet As learning_activity.learning_activityDataSet
    Friend WithEvents ProfilesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProfilesTableAdapter As learning_activity.learning_activityDataSetTableAdapters.profilesTableAdapter
    Friend WithEvents TableAdapterManager As learning_activity.learning_activityDataSetTableAdapters.TableAdapterManager
    Friend WithEvents SubjectTableAdapter As learning_activity.learning_activityDataSetTableAdapters.subjectTableAdapter
    Friend WithEvents SubjectBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btnRedakchia As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblidR As System.Windows.Forms.Label
    Friend WithEvents txtNameR As System.Windows.Forms.TextBox
    Friend WithEvents cmbpp1R As System.Windows.Forms.ComboBox
    Friend WithEvents cmbpp2R As System.Windows.Forms.ComboBox
    Friend WithEvents cmbpp3R As System.Windows.Forms.ComboBox
    Friend WithEvents cmbpp4R As System.Windows.Forms.ComboBox
    Friend WithEvents cmbpp4RId As System.Windows.Forms.ComboBox
    Friend WithEvents cmbpp3RId As System.Windows.Forms.ComboBox
    Friend WithEvents cmbpp2RId As System.Windows.Forms.ComboBox
    Friend WithEvents cmbpp1RId As System.Windows.Forms.ComboBox
    Private WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents iddgv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents name_profiledgv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pp1dgv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pp2dgv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pp3dgv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pp4dgv As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
