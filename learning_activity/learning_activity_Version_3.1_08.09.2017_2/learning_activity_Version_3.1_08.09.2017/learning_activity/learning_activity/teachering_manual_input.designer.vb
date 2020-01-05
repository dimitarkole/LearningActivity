<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class teachering_manual_input
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
        Dim НомерLabel As System.Windows.Forms.Label
        Dim КласLabel As System.Windows.Forms.Label
        Dim ПредметLabel As System.Windows.Forms.Label
        Dim УчителLabel As System.Windows.Forms.Label
        Dim ХонорарLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label9 As System.Windows.Forms.Label
        Dim Label10 As System.Windows.Forms.Label
        Dim Label11 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(teachering_manual_input))
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.iddgv1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.classdgv1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.subjectdgv1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.teacherdgv1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.workload = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbworkload = New System.Windows.Forms.ComboBox()
        Me.cmbteacherUp = New System.Windows.Forms.ComboBox()
        Me.cmbsubjectUp = New System.Windows.Forms.ComboBox()
        Me.cmbClasseUp = New System.Windows.Forms.ComboBox()
        Me.lblIdUp = New System.Windows.Forms.Label()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.Learning_activityDataSet = New learning_activity.learning_activityDataSet()
        Me.TeachingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TeachingTableAdapter = New learning_activity.learning_activityDataSetTableAdapters.teachingTableAdapter()
        Me.TableAdapterManager = New learning_activity.learning_activityDataSetTableAdapters.TableAdapterManager()
        Me.cmbClassIdUp = New System.Windows.Forms.ComboBox()
        Me.cmbTeacherIdUp = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblWorkWoadDEl = New System.Windows.Forms.Label()
        Me.lblTeachDel = New System.Windows.Forms.Label()
        Me.lblSubjectDel = New System.Windows.Forms.Label()
        Me.lblClassDell = New System.Windows.Forms.Label()
        Me.lblidDel = New System.Windows.Forms.Label()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblidR = New System.Windows.Forms.Label()
        Me.btnR = New System.Windows.Forms.Button()
        Me.cmbCIDR = New System.Windows.Forms.ComboBox()
        Me.cmbHR = New System.Windows.Forms.ComboBox()
        Me.CmbTR = New System.Windows.Forms.ComboBox()
        Me.cmbCR = New System.Windows.Forms.ComboBox()
        Me.cmbSubR = New System.Windows.Forms.ComboBox()
        Me.cmbTidR = New System.Windows.Forms.ComboBox()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.cmbSubIdR = New System.Windows.Forms.ComboBox()
        НомерLabel = New System.Windows.Forms.Label()
        КласLabel = New System.Windows.Forms.Label()
        ПредметLabel = New System.Windows.Forms.Label()
        УчителLabel = New System.Windows.Forms.Label()
        ХонорарLabel = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        Label7 = New System.Windows.Forms.Label()
        Label9 = New System.Windows.Forms.Label()
        Label10 = New System.Windows.Forms.Label()
        Label11 = New System.Windows.Forms.Label()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Learning_activityDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TeachingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'НомерLabel
        '
        НомерLabel.AutoSize = True
        НомерLabel.Location = New System.Drawing.Point(17, 30)
        НомерLabel.Name = "НомерLabel"
        НомерLabel.Size = New System.Drawing.Size(29, 13)
        НомерLabel.TabIndex = 6
        НомерLabel.Text = "Код:"
        '
        'КласLabel
        '
        КласLabel.AutoSize = True
        КласLabel.Location = New System.Drawing.Point(17, 58)
        КласLabel.Name = "КласLabel"
        КласLabel.Size = New System.Drawing.Size(35, 13)
        КласLabel.TabIndex = 10
        КласLabel.Text = "Клас:"
        '
        'ПредметLabel
        '
        ПредметLabel.AutoSize = True
        ПредметLabel.Location = New System.Drawing.Point(17, 86)
        ПредметLabel.Name = "ПредметLabel"
        ПредметLabel.Size = New System.Drawing.Size(55, 13)
        ПредметLabel.TabIndex = 25
        ПредметLabel.Text = "Предмет:"
        '
        'УчителLabel
        '
        УчителLabel.AutoSize = True
        УчителLabel.Location = New System.Drawing.Point(17, 114)
        УчителLabel.Name = "УчителLabel"
        УчителLabel.Size = New System.Drawing.Size(46, 13)
        УчителLabel.TabIndex = 27
        УчителLabel.Text = "Учител:"
        '
        'ХонорарLabel
        '
        ХонорарLabel.AutoSize = True
        ХонорарLabel.Location = New System.Drawing.Point(17, 142)
        ХонорарLabel.Name = "ХонорарLabel"
        ХонорарLabel.Size = New System.Drawing.Size(60, 13)
        ХонорарLabel.TabIndex = 29
        ХонорарLabel.Text = "Хорариум:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(17, 86)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(55, 13)
        Label1.TabIndex = 25
        Label1.Text = "Предмет:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(17, 114)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(46, 13)
        Label2.TabIndex = 27
        Label2.Text = "Учител:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(17, 142)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(60, 13)
        Label3.TabIndex = 29
        Label3.Text = "Хорариум:"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(17, 30)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(29, 13)
        Label5.TabIndex = 6
        Label5.Text = "Код:"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(17, 58)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(35, 13)
        Label6.TabIndex = 10
        Label6.Text = "Клас:"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(23, 58)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(35, 13)
        Label4.TabIndex = 10
        Label4.Text = "Клас:"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Location = New System.Drawing.Point(23, 30)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(29, 13)
        Label7.TabIndex = 6
        Label7.Text = "Код:"
        '
        'Label9
        '
        Label9.AutoSize = True
        Label9.Location = New System.Drawing.Point(23, 142)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(60, 13)
        Label9.TabIndex = 29
        Label9.Text = "Хорариум:"
        '
        'Label10
        '
        Label10.AutoSize = True
        Label10.Location = New System.Drawing.Point(23, 114)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(46, 13)
        Label10.TabIndex = 27
        Label10.Text = "Учител:"
        '
        'Label11
        '
        Label11.AutoSize = True
        Label11.Location = New System.Drawing.Point(23, 86)
        Label11.Name = "Label11"
        Label11.Size = New System.Drawing.Size(55, 13)
        Label11.TabIndex = 25
        Label11.Text = "Предмет:"
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.iddgv1, Me.classdgv1, Me.subjectdgv1, Me.teacherdgv1, Me.workload})
        Me.dgv1.Location = New System.Drawing.Point(12, 248)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(718, 195)
        Me.dgv1.TabIndex = 5
        '
        'iddgv1
        '
        Me.iddgv1.HeaderText = "Код"
        Me.iddgv1.Name = "iddgv1"
        Me.iddgv1.ReadOnly = True
        '
        'classdgv1
        '
        Me.classdgv1.HeaderText = "Клас"
        Me.classdgv1.Name = "classdgv1"
        Me.classdgv1.ReadOnly = True
        Me.classdgv1.Width = 120
        '
        'subjectdgv1
        '
        Me.subjectdgv1.HeaderText = "Предмет"
        Me.subjectdgv1.Name = "subjectdgv1"
        Me.subjectdgv1.ReadOnly = True
        Me.subjectdgv1.Width = 210
        '
        'teacherdgv1
        '
        Me.teacherdgv1.HeaderText = "Учител"
        Me.teacherdgv1.Name = "teacherdgv1"
        Me.teacherdgv1.ReadOnly = True
        Me.teacherdgv1.Width = 170
        '
        'workload
        '
        Me.workload.HeaderText = "Хорариум"
        Me.workload.Name = "workload"
        Me.workload.ReadOnly = True
        Me.workload.Width = 70
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(ПредметLabel)
        Me.GroupBox1.Controls.Add(УчителLabel)
        Me.GroupBox1.Controls.Add(ХонорарLabel)
        Me.GroupBox1.Controls.Add(Me.cmbworkload)
        Me.GroupBox1.Controls.Add(Me.cmbteacherUp)
        Me.GroupBox1.Controls.Add(Me.cmbsubjectUp)
        Me.GroupBox1.Controls.Add(Me.cmbClasseUp)
        Me.GroupBox1.Controls.Add(Me.lblIdUp)
        Me.GroupBox1.Controls.Add(НомерLabel)
        Me.GroupBox1.Controls.Add(КласLabel)
        Me.GroupBox1.Controls.Add(Me.btnUpload)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(235, 230)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Добавяне на преподавател на клас"
        '
        'cmbworkload
        '
        Me.cmbworkload.FormattingEnabled = True
        Me.cmbworkload.Items.AddRange(New Object() {"36", "54", "72", "108", "126", "144", "155", "648"})
        Me.cmbworkload.Location = New System.Drawing.Point(84, 136)
        Me.cmbworkload.Name = "cmbworkload"
        Me.cmbworkload.Size = New System.Drawing.Size(142, 21)
        Me.cmbworkload.TabIndex = 22
        Me.cmbworkload.Text = "36"
        '
        'cmbteacherUp
        '
        Me.cmbteacherUp.FormattingEnabled = True
        Me.cmbteacherUp.Location = New System.Drawing.Point(84, 110)
        Me.cmbteacherUp.Name = "cmbteacherUp"
        Me.cmbteacherUp.Size = New System.Drawing.Size(142, 21)
        Me.cmbteacherUp.TabIndex = 21
        '
        'cmbsubjectUp
        '
        Me.cmbsubjectUp.FormattingEnabled = True
        Me.cmbsubjectUp.Location = New System.Drawing.Point(84, 84)
        Me.cmbsubjectUp.Name = "cmbsubjectUp"
        Me.cmbsubjectUp.Size = New System.Drawing.Size(142, 21)
        Me.cmbsubjectUp.TabIndex = 20
        '
        'cmbClasseUp
        '
        Me.cmbClasseUp.IntegralHeight = False
        Me.cmbClasseUp.Location = New System.Drawing.Point(84, 58)
        Me.cmbClasseUp.Name = "cmbClasseUp"
        Me.cmbClasseUp.Size = New System.Drawing.Size(142, 21)
        Me.cmbClasseUp.TabIndex = 19
        '
        'lblIdUp
        '
        Me.lblIdUp.Location = New System.Drawing.Point(81, 30)
        Me.lblIdUp.Name = "lblIdUp"
        Me.lblIdUp.Size = New System.Drawing.Size(145, 23)
        Me.lblIdUp.TabIndex = 17
        '
        'btnUpload
        '
        Me.btnUpload.Location = New System.Drawing.Point(24, 173)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(169, 44)
        Me.btnUpload.TabIndex = 6
        Me.btnUpload.Text = "Въведи преподавател на клас"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'Learning_activityDataSet
        '
        Me.Learning_activityDataSet.DataSetName = "learning_activityDataSet"
        Me.Learning_activityDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TeachingBindingSource
        '
        Me.TeachingBindingSource.DataMember = "teaching"
        Me.TeachingBindingSource.DataSource = Me.Learning_activityDataSet
        '
        'TeachingTableAdapter
        '
        Me.TeachingTableAdapter.ClearBeforeFill = True
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
        Me.TableAdapterManager.teachingTableAdapter = Me.TeachingTableAdapter
        Me.TableAdapterManager.typesTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = learning_activity.learning_activityDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'cmbClassIdUp
        '
        Me.cmbClassIdUp.FormattingEnabled = True
        Me.cmbClassIdUp.Location = New System.Drawing.Point(12, 244)
        Me.cmbClassIdUp.Name = "cmbClassIdUp"
        Me.cmbClassIdUp.Size = New System.Drawing.Size(52, 21)
        Me.cmbClassIdUp.TabIndex = 21
        Me.cmbClassIdUp.Visible = False
        '
        'cmbTeacherIdUp
        '
        Me.cmbTeacherIdUp.FormattingEnabled = True
        Me.cmbTeacherIdUp.Location = New System.Drawing.Point(12, 271)
        Me.cmbTeacherIdUp.Name = "cmbTeacherIdUp"
        Me.cmbTeacherIdUp.Size = New System.Drawing.Size(52, 21)
        Me.cmbTeacherIdUp.TabIndex = 22
        Me.cmbTeacherIdUp.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblWorkWoadDEl)
        Me.GroupBox2.Controls.Add(Me.lblTeachDel)
        Me.GroupBox2.Controls.Add(Me.lblSubjectDel)
        Me.GroupBox2.Controls.Add(Me.lblClassDell)
        Me.GroupBox2.Controls.Add(Label1)
        Me.GroupBox2.Controls.Add(Label2)
        Me.GroupBox2.Controls.Add(Label3)
        Me.GroupBox2.Controls.Add(Me.lblidDel)
        Me.GroupBox2.Controls.Add(Label5)
        Me.GroupBox2.Controls.Add(Label6)
        Me.GroupBox2.Controls.Add(Me.btnDel)
        Me.GroupBox2.Location = New System.Drawing.Point(253, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(238, 230)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Изтриване на преподавател на клас"
        '
        'lblWorkWoadDEl
        '
        Me.lblWorkWoadDEl.Location = New System.Drawing.Point(82, 142)
        Me.lblWorkWoadDEl.Name = "lblWorkWoadDEl"
        Me.lblWorkWoadDEl.Size = New System.Drawing.Size(145, 23)
        Me.lblWorkWoadDEl.TabIndex = 33
        '
        'lblTeachDel
        '
        Me.lblTeachDel.Location = New System.Drawing.Point(82, 114)
        Me.lblTeachDel.Name = "lblTeachDel"
        Me.lblTeachDel.Size = New System.Drawing.Size(145, 23)
        Me.lblTeachDel.TabIndex = 32
        '
        'lblSubjectDel
        '
        Me.lblSubjectDel.Location = New System.Drawing.Point(82, 86)
        Me.lblSubjectDel.Name = "lblSubjectDel"
        Me.lblSubjectDel.Size = New System.Drawing.Size(145, 23)
        Me.lblSubjectDel.TabIndex = 31
        '
        'lblClassDell
        '
        Me.lblClassDell.Location = New System.Drawing.Point(82, 58)
        Me.lblClassDell.Name = "lblClassDell"
        Me.lblClassDell.Size = New System.Drawing.Size(145, 23)
        Me.lblClassDell.TabIndex = 30
        '
        'lblidDel
        '
        Me.lblidDel.Location = New System.Drawing.Point(82, 30)
        Me.lblidDel.Name = "lblidDel"
        Me.lblidDel.Size = New System.Drawing.Size(145, 23)
        Me.lblidDel.TabIndex = 17
        '
        'btnDel
        '
        Me.btnDel.Location = New System.Drawing.Point(20, 173)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(169, 44)
        Me.btnDel.TabIndex = 6
        Me.btnDel.Text = "Изтрий преподавател на клас"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Label11)
        Me.GroupBox3.Controls.Add(Me.lblidR)
        Me.GroupBox3.Controls.Add(Label10)
        Me.GroupBox3.Controls.Add(Me.btnR)
        Me.GroupBox3.Controls.Add(Me.cmbCIDR)
        Me.GroupBox3.Controls.Add(Label9)
        Me.GroupBox3.Controls.Add(Label4)
        Me.GroupBox3.Controls.Add(Me.cmbHR)
        Me.GroupBox3.Controls.Add(Label7)
        Me.GroupBox3.Controls.Add(Me.CmbTR)
        Me.GroupBox3.Controls.Add(Me.cmbCR)
        Me.GroupBox3.Controls.Add(Me.cmbSubR)
        Me.GroupBox3.Location = New System.Drawing.Point(497, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(238, 230)
        Me.GroupBox3.TabIndex = 23
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Редактиране на преподавател на клас"
        '
        'lblidR
        '
        Me.lblidR.Location = New System.Drawing.Point(87, 30)
        Me.lblidR.Name = "lblidR"
        Me.lblidR.Size = New System.Drawing.Size(145, 23)
        Me.lblidR.TabIndex = 17
        '
        'btnR
        '
        Me.btnR.Location = New System.Drawing.Point(30, 173)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(169, 44)
        Me.btnR.TabIndex = 6
        Me.btnR.Text = "Редактирай преподавателя на класа"
        Me.btnR.UseVisualStyleBackColor = True
        '
        'cmbCIDR
        '
        Me.cmbCIDR.FormattingEnabled = True
        Me.cmbCIDR.Location = New System.Drawing.Point(180, 205)
        Me.cmbCIDR.Name = "cmbCIDR"
        Me.cmbCIDR.Size = New System.Drawing.Size(52, 21)
        Me.cmbCIDR.TabIndex = 21
        Me.cmbCIDR.Visible = False
        '
        'cmbHR
        '
        Me.cmbHR.FormattingEnabled = True
        Me.cmbHR.Items.AddRange(New Object() {"36", "54", "72", "108", "126", "144", "155", "648"})
        Me.cmbHR.Location = New System.Drawing.Point(90, 136)
        Me.cmbHR.Name = "cmbHR"
        Me.cmbHR.Size = New System.Drawing.Size(142, 21)
        Me.cmbHR.TabIndex = 22
        Me.cmbHR.Text = "36"
        '
        'CmbTR
        '
        Me.CmbTR.FormattingEnabled = True
        Me.CmbTR.Location = New System.Drawing.Point(90, 110)
        Me.CmbTR.Name = "CmbTR"
        Me.CmbTR.Size = New System.Drawing.Size(142, 21)
        Me.CmbTR.TabIndex = 21
        '
        'cmbCR
        '
        Me.cmbCR.IntegralHeight = False
        Me.cmbCR.Location = New System.Drawing.Point(90, 58)
        Me.cmbCR.Name = "cmbCR"
        Me.cmbCR.Size = New System.Drawing.Size(142, 21)
        Me.cmbCR.TabIndex = 19
        '
        'cmbSubR
        '
        Me.cmbSubR.FormattingEnabled = True
        Me.cmbSubR.Location = New System.Drawing.Point(90, 84)
        Me.cmbSubR.Name = "cmbSubR"
        Me.cmbSubR.Size = New System.Drawing.Size(142, 21)
        Me.cmbSubR.TabIndex = 20
        '
        'cmbTidR
        '
        Me.cmbTidR.FormattingEnabled = True
        Me.cmbTidR.Location = New System.Drawing.Point(677, 271)
        Me.cmbTidR.Name = "cmbTidR"
        Me.cmbTidR.Size = New System.Drawing.Size(52, 21)
        Me.cmbTidR.TabIndex = 22
        Me.cmbTidR.Visible = False
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "helpHTML\HelpHTML.chm"
        Me.HelpProvider1.Tag = "F1"
        '
        'cmbSubIdR
        '
        Me.cmbSubIdR.FormattingEnabled = True
        Me.cmbSubIdR.Location = New System.Drawing.Point(678, 244)
        Me.cmbSubIdR.Name = "cmbSubIdR"
        Me.cmbSubIdR.Size = New System.Drawing.Size(52, 21)
        Me.cmbSubIdR.TabIndex = 21
        Me.cmbSubIdR.Visible = False
        '
        'teachering_manual_input
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(742, 450)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmbTidR)
        Me.Controls.Add(Me.cmbTeacherIdUp)
        Me.Controls.Add(Me.cmbClassIdUp)
        Me.Controls.Add(Me.cmbSubIdR)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgv1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider1.SetHelpKeyword(Me, "Преподаватели на класовете")
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.HelpProvider1.SetHelpString(Me, "Преподаватели на класовете")
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "teachering_manual_input"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Въвеждане, изтриване и редактиране на преподаватели на класовете"
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Learning_activityDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TeachingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbworkload As System.Windows.Forms.ComboBox
    Friend WithEvents cmbteacherUp As System.Windows.Forms.ComboBox
    Friend WithEvents cmbsubjectUp As System.Windows.Forms.ComboBox
    Friend WithEvents lblIdUp As System.Windows.Forms.Label
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents Learning_activityDataSet As learning_activity.learning_activityDataSet
    Friend WithEvents TeachingBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TeachingTableAdapter As learning_activity.learning_activityDataSetTableAdapters.teachingTableAdapter
    Friend WithEvents TableAdapterManager As learning_activity.learning_activityDataSetTableAdapters.TableAdapterManager
    Friend WithEvents cmbClassIdUp As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTeacherIdUp As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblidDel As System.Windows.Forms.Label
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents lblWorkWoadDEl As System.Windows.Forms.Label
    Friend WithEvents lblTeachDel As System.Windows.Forms.Label
    Friend WithEvents lblSubjectDel As System.Windows.Forms.Label
    Friend WithEvents lblClassDell As System.Windows.Forms.Label
    Friend WithEvents cmbClasseUp As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblidR As System.Windows.Forms.Label
    Friend WithEvents btnR As System.Windows.Forms.Button
    Friend WithEvents cmbHR As System.Windows.Forms.ComboBox
    Friend WithEvents CmbTR As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCR As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSubR As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCIDR As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTidR As System.Windows.Forms.ComboBox
    Private WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents cmbSubIdR As System.Windows.Forms.ComboBox
    Friend WithEvents iddgv1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents classdgv1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents subjectdgv1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents teacherdgv1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents workload As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
