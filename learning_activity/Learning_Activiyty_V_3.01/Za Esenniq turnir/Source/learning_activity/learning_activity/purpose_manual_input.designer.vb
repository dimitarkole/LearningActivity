<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class purpose_manual_input
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
        Dim ВидовеLabel As System.Windows.Forms.Label
        Dim Брой_двойкиLabel As System.Windows.Forms.Label
        Dim Брой_тройкиLabel As System.Windows.Forms.Label
        Dim Брой_четворкиLabel As System.Windows.Forms.Label
        Dim Брой_петициLabel As System.Windows.Forms.Label
        Dim Брой_шестициLabel As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim Label9 As System.Windows.Forms.Label
        Dim Label10 As System.Windows.Forms.Label
        Dim Label11 As System.Windows.Forms.Label
        Dim Label12 As System.Windows.Forms.Label
        Dim Label13 As System.Windows.Forms.Label
        Dim Label14 As System.Windows.Forms.Label
        Dim Label15 As System.Windows.Forms.Label
        Dim Label16 As System.Windows.Forms.Label
        Dim Label17 As System.Windows.Forms.Label
        Dim Label18 As System.Windows.Forms.Label
        Dim Label19 As System.Windows.Forms.Label
        Dim HelpProvider1 As System.Windows.Forms.HelpProvider
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(purpose_manual_input))
        Me.Learning_activityDataSet = New learning_activity.learning_activityDataSet()
        Me.AbsenceBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AbsenceTableAdapter = New learning_activity.learning_activityDataSetTableAdapters.absenceTableAdapter()
        Me.TableAdapterManager = New learning_activity.learning_activityDataSetTableAdapters.TableAdapterManager()
        Me.PurposeTableAdapter = New learning_activity.learning_activityDataSetTableAdapters.purposeTableAdapter()
        Me.PurposeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbC6 = New System.Windows.Forms.ComboBox()
        Me.cmbClassId = New System.Windows.Forms.ComboBox()
        Me.cmbC5 = New System.Windows.Forms.ComboBox()
        Me.cmbC4 = New System.Windows.Forms.ComboBox()
        Me.cmbC3 = New System.Windows.Forms.ComboBox()
        Me.cmbC2 = New System.Windows.Forms.ComboBox()
        Me.cmbTypes = New System.Windows.Forms.ComboBox()
        Me.cmbSubject = New System.Windows.Forms.ComboBox()
        Me.cmbClass = New System.Windows.Forms.ComboBox()
        Me.lblIdUp = New System.Windows.Forms.Label()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.TypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TypesTableAdapter = New learning_activity.learning_activityDataSetTableAdapters.typesTableAdapter()
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
        Me.btndel = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblc6 = New System.Windows.Forms.Label()
        Me.lblc5 = New System.Windows.Forms.Label()
        Me.lblc4 = New System.Windows.Forms.Label()
        Me.lblc3 = New System.Windows.Forms.Label()
        Me.lblc2 = New System.Windows.Forms.Label()
        Me.lblTypeDel = New System.Windows.Forms.Label()
        Me.lblSubjectDel = New System.Windows.Forms.Label()
        Me.lblClasDel = New System.Windows.Forms.Label()
        Me.lblIdDel = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbTidR = New System.Windows.Forms.ComboBox()
        Me.cmbCidR = New System.Windows.Forms.ComboBox()
        Me.cmbSidR = New System.Windows.Forms.ComboBox()
        Me.cmb6R = New System.Windows.Forms.ComboBox()
        Me.cmb5R = New System.Windows.Forms.ComboBox()
        Me.cmb4R = New System.Windows.Forms.ComboBox()
        Me.cmb3R = New System.Windows.Forms.ComboBox()
        Me.cmb2R = New System.Windows.Forms.ComboBox()
        Me.cmbTR = New System.Windows.Forms.ComboBox()
        Me.cmbSR = New System.Windows.Forms.ComboBox()
        Me.cmbCR = New System.Windows.Forms.ComboBox()
        Me.lblidR = New System.Windows.Forms.Label()
        Me.btnR = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnUpLoadWithExcel = New System.Windows.Forms.Button()
        Me.btnCreateExcel = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        НомерLabel = New System.Windows.Forms.Label()
        КласLabel = New System.Windows.Forms.Label()
        ПредметLabel = New System.Windows.Forms.Label()
        ВидовеLabel = New System.Windows.Forms.Label()
        Брой_двойкиLabel = New System.Windows.Forms.Label()
        Брой_тройкиLabel = New System.Windows.Forms.Label()
        Брой_четворкиLabel = New System.Windows.Forms.Label()
        Брой_петициLabel = New System.Windows.Forms.Label()
        Брой_шестициLabel = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        Label7 = New System.Windows.Forms.Label()
        Label8 = New System.Windows.Forms.Label()
        Label9 = New System.Windows.Forms.Label()
        Label10 = New System.Windows.Forms.Label()
        Label11 = New System.Windows.Forms.Label()
        Label12 = New System.Windows.Forms.Label()
        Label13 = New System.Windows.Forms.Label()
        Label14 = New System.Windows.Forms.Label()
        Label15 = New System.Windows.Forms.Label()
        Label16 = New System.Windows.Forms.Label()
        Label17 = New System.Windows.Forms.Label()
        Label18 = New System.Windows.Forms.Label()
        Label19 = New System.Windows.Forms.Label()
        HelpProvider1 = New System.Windows.Forms.HelpProvider()
        CType(Me.Learning_activityDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AbsenceBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurposeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'НомерLabel
        '
        НомерLabel.AutoSize = True
        НомерLabel.Location = New System.Drawing.Point(15, 28)
        НомерLabel.Name = "НомерLabel"
        НомерLabel.Size = New System.Drawing.Size(29, 13)
        НомерLabel.TabIndex = 6
        НомерLabel.Text = "Код:"
        '
        'КласLabel
        '
        КласLabel.AutoSize = True
        КласLabel.Location = New System.Drawing.Point(15, 57)
        КласLabel.Name = "КласLabel"
        КласLabel.Size = New System.Drawing.Size(35, 13)
        КласLabel.TabIndex = 8
        КласLabel.Text = "Клас:"
        '
        'ПредметLabel
        '
        ПредметLabel.AutoSize = True
        ПредметLabel.Location = New System.Drawing.Point(15, 84)
        ПредметLabel.Name = "ПредметLabel"
        ПредметLabel.Size = New System.Drawing.Size(55, 13)
        ПредметLabel.TabIndex = 10
        ПредметLabel.Text = "Предмет:"
        '
        'ВидовеLabel
        '
        ВидовеLabel.AutoSize = True
        ВидовеLabel.Location = New System.Drawing.Point(15, 110)
        ВидовеLabel.Name = "ВидовеLabel"
        ВидовеLabel.Size = New System.Drawing.Size(86, 13)
        ВидовеLabel.TabIndex = 12
        ВидовеLabel.Text = "Видове оценки:"
        '
        'Брой_двойкиLabel
        '
        Брой_двойкиLabel.AutoSize = True
        Брой_двойкиLabel.Location = New System.Drawing.Point(15, 136)
        Брой_двойкиLabel.Name = "Брой_двойкиLabel"
        Брой_двойкиLabel.Size = New System.Drawing.Size(74, 13)
        Брой_двойкиLabel.TabIndex = 14
        Брой_двойкиLabel.Text = "Брой двойки:"
        '
        'Брой_тройкиLabel
        '
        Брой_тройкиLabel.AutoSize = True
        Брой_тройкиLabel.Location = New System.Drawing.Point(15, 162)
        Брой_тройкиLabel.Name = "Брой_тройкиLabel"
        Брой_тройкиLabel.Size = New System.Drawing.Size(73, 13)
        Брой_тройкиLabel.TabIndex = 16
        Брой_тройкиLabel.Text = "Брой тройки:"
        '
        'Брой_четворкиLabel
        '
        Брой_четворкиLabel.AutoSize = True
        Брой_четворкиLabel.Location = New System.Drawing.Point(15, 188)
        Брой_четворкиLabel.Name = "Брой_четворкиLabel"
        Брой_четворкиLabel.Size = New System.Drawing.Size(84, 13)
        Брой_четворкиLabel.TabIndex = 18
        Брой_четворкиLabel.Text = "Брой четворки:"
        '
        'Брой_петициLabel
        '
        Брой_петициLabel.AutoSize = True
        Брой_петициLabel.Location = New System.Drawing.Point(15, 214)
        Брой_петициLabel.Name = "Брой_петициLabel"
        Брой_петициLabel.Size = New System.Drawing.Size(73, 13)
        Брой_петициLabel.TabIndex = 20
        Брой_петициLabel.Text = "Брой петици:"
        '
        'Брой_шестициLabel
        '
        Брой_шестициLabel.AutoSize = True
        Брой_шестициLabel.Location = New System.Drawing.Point(15, 240)
        Брой_шестициLabel.Name = "Брой_шестициLabel"
        Брой_шестициLabel.Size = New System.Drawing.Size(81, 13)
        Брой_шестициLabel.TabIndex = 22
        Брой_шестициLabel.Text = "Брой шестици:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(30, 28)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(29, 13)
        Label2.TabIndex = 25
        Label2.Text = "Код:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(30, 57)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(35, 13)
        Label3.TabIndex = 26
        Label3.Text = "Клас:"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(30, 84)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(55, 13)
        Label4.TabIndex = 27
        Label4.Text = "Предмет:"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(30, 110)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(89, 13)
        Label5.TabIndex = 28
        Label5.Text = "Видове  оценки:"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(30, 136)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(74, 13)
        Label6.TabIndex = 29
        Label6.Text = "Брой двойки:"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Location = New System.Drawing.Point(30, 162)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(73, 13)
        Label7.TabIndex = 30
        Label7.Text = "Брой тройки:"
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.Location = New System.Drawing.Point(30, 188)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(84, 13)
        Label8.TabIndex = 31
        Label8.Text = "Брой четворки:"
        '
        'Label9
        '
        Label9.AutoSize = True
        Label9.Location = New System.Drawing.Point(30, 214)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(73, 13)
        Label9.TabIndex = 32
        Label9.Text = "Брой петици:"
        '
        'Label10
        '
        Label10.AutoSize = True
        Label10.Location = New System.Drawing.Point(30, 240)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(81, 13)
        Label10.TabIndex = 33
        Label10.Text = "Брой шестици:"
        '
        'Label11
        '
        Label11.AutoSize = True
        Label11.Location = New System.Drawing.Point(15, 28)
        Label11.Name = "Label11"
        Label11.Size = New System.Drawing.Size(29, 13)
        Label11.TabIndex = 6
        Label11.Text = "Код:"
        '
        'Label12
        '
        Label12.AutoSize = True
        Label12.Location = New System.Drawing.Point(15, 57)
        Label12.Name = "Label12"
        Label12.Size = New System.Drawing.Size(35, 13)
        Label12.TabIndex = 8
        Label12.Text = "Клас:"
        '
        'Label13
        '
        Label13.AutoSize = True
        Label13.Location = New System.Drawing.Point(15, 84)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(55, 13)
        Label13.TabIndex = 10
        Label13.Text = "Предмет:"
        '
        'Label14
        '
        Label14.AutoSize = True
        Label14.Location = New System.Drawing.Point(15, 110)
        Label14.Name = "Label14"
        Label14.Size = New System.Drawing.Size(86, 13)
        Label14.TabIndex = 12
        Label14.Text = "Видове оценки:"
        '
        'Label15
        '
        Label15.AutoSize = True
        Label15.Location = New System.Drawing.Point(15, 136)
        Label15.Name = "Label15"
        Label15.Size = New System.Drawing.Size(74, 13)
        Label15.TabIndex = 14
        Label15.Text = "Брой двойки:"
        '
        'Label16
        '
        Label16.AutoSize = True
        Label16.Location = New System.Drawing.Point(15, 162)
        Label16.Name = "Label16"
        Label16.Size = New System.Drawing.Size(73, 13)
        Label16.TabIndex = 16
        Label16.Text = "Брой тройки:"
        '
        'Label17
        '
        Label17.AutoSize = True
        Label17.Location = New System.Drawing.Point(15, 188)
        Label17.Name = "Label17"
        Label17.Size = New System.Drawing.Size(84, 13)
        Label17.TabIndex = 18
        Label17.Text = "Брой четворки:"
        '
        'Label18
        '
        Label18.AutoSize = True
        Label18.Location = New System.Drawing.Point(15, 214)
        Label18.Name = "Label18"
        Label18.Size = New System.Drawing.Size(73, 13)
        Label18.TabIndex = 20
        Label18.Text = "Брой петици:"
        '
        'Label19
        '
        Label19.AutoSize = True
        Label19.Location = New System.Drawing.Point(15, 240)
        Label19.Name = "Label19"
        Label19.Size = New System.Drawing.Size(81, 13)
        Label19.TabIndex = 22
        Label19.Text = "Брой шестици:"
        '
        'HelpProvider1
        '
        HelpProvider1.HelpNamespace = "helpHTML\HelpHTML.chm"
        HelpProvider1.Tag = "F1"
        '
        'Learning_activityDataSet
        '
        Me.Learning_activityDataSet.DataSetName = "learning_activityDataSet"
        Me.Learning_activityDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AbsenceBindingSource
        '
        Me.AbsenceBindingSource.DataMember = "absence"
        Me.AbsenceBindingSource.DataSource = Me.Learning_activityDataSet
        '
        'AbsenceTableAdapter
        '
        Me.AbsenceTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.absenceTableAdapter = Me.AbsenceTableAdapter
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.classesTableAdapter = Nothing
        Me.TableAdapterManager.profilesTableAdapter = Nothing
        Me.TableAdapterManager.purposeTableAdapter = Me.PurposeTableAdapter
        Me.TableAdapterManager.subjectTableAdapter = Nothing
        Me.TableAdapterManager.teachersTableAdapter = Nothing
        Me.TableAdapterManager.teachingTableAdapter = Nothing
        Me.TableAdapterManager.typesTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = learning_activity.learning_activityDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'PurposeTableAdapter
        '
        Me.PurposeTableAdapter.ClearBeforeFill = True
        '
        'PurposeBindingSource
        '
        Me.PurposeBindingSource.DataMember = "purpose"
        Me.PurposeBindingSource.DataSource = Me.Learning_activityDataSet
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbC6)
        Me.GroupBox1.Controls.Add(Me.cmbClassId)
        Me.GroupBox1.Controls.Add(Me.cmbC5)
        Me.GroupBox1.Controls.Add(Me.cmbC4)
        Me.GroupBox1.Controls.Add(Me.cmbC3)
        Me.GroupBox1.Controls.Add(Me.cmbC2)
        Me.GroupBox1.Controls.Add(Me.cmbTypes)
        Me.GroupBox1.Controls.Add(Me.cmbSubject)
        Me.GroupBox1.Controls.Add(Me.cmbClass)
        Me.GroupBox1.Controls.Add(Me.lblIdUp)
        Me.GroupBox1.Controls.Add(НомерLabel)
        Me.GroupBox1.Controls.Add(КласLabel)
        Me.GroupBox1.Controls.Add(ПредметLabel)
        Me.GroupBox1.Controls.Add(ВидовеLabel)
        Me.GroupBox1.Controls.Add(Брой_двойкиLabel)
        Me.GroupBox1.Controls.Add(Брой_тройкиLabel)
        Me.GroupBox1.Controls.Add(Брой_четворкиLabel)
        Me.GroupBox1.Controls.Add(Брой_петициLabel)
        Me.GroupBox1.Controls.Add(Брой_шестициLabel)
        Me.GroupBox1.Controls.Add(Me.btnUpload)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(301, 317)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Добавяне на оценки"
        '
        'cmbC6
        '
        Me.cmbC6.FormattingEnabled = True
        Me.cmbC6.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32"})
        Me.cmbC6.Location = New System.Drawing.Point(127, 232)
        Me.cmbC6.Name = "cmbC6"
        Me.cmbC6.Size = New System.Drawing.Size(168, 21)
        Me.cmbC6.TabIndex = 24
        Me.cmbC6.Text = "0"
        '
        'cmbClassId
        '
        Me.cmbClassId.FormattingEnabled = True
        Me.cmbClassId.Location = New System.Drawing.Point(46, 280)
        Me.cmbClassId.Name = "cmbClassId"
        Me.cmbClassId.Size = New System.Drawing.Size(50, 21)
        Me.cmbClassId.TabIndex = 25
        Me.cmbClassId.Visible = False
        '
        'cmbC5
        '
        Me.cmbC5.FormattingEnabled = True
        Me.cmbC5.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32"})
        Me.cmbC5.Location = New System.Drawing.Point(127, 207)
        Me.cmbC5.Name = "cmbC5"
        Me.cmbC5.Size = New System.Drawing.Size(168, 21)
        Me.cmbC5.TabIndex = 24
        Me.cmbC5.Text = "0"
        '
        'cmbC4
        '
        Me.cmbC4.FormattingEnabled = True
        Me.cmbC4.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32"})
        Me.cmbC4.Location = New System.Drawing.Point(127, 182)
        Me.cmbC4.Name = "cmbC4"
        Me.cmbC4.Size = New System.Drawing.Size(168, 21)
        Me.cmbC4.TabIndex = 24
        Me.cmbC4.Text = "0"
        '
        'cmbC3
        '
        Me.cmbC3.FormattingEnabled = True
        Me.cmbC3.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32"})
        Me.cmbC3.Location = New System.Drawing.Point(127, 157)
        Me.cmbC3.Name = "cmbC3"
        Me.cmbC3.Size = New System.Drawing.Size(168, 21)
        Me.cmbC3.TabIndex = 24
        Me.cmbC3.Text = "0"
        '
        'cmbC2
        '
        Me.cmbC2.FormattingEnabled = True
        Me.cmbC2.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32"})
        Me.cmbC2.Location = New System.Drawing.Point(127, 133)
        Me.cmbC2.Name = "cmbC2"
        Me.cmbC2.Size = New System.Drawing.Size(168, 21)
        Me.cmbC2.TabIndex = 24
        Me.cmbC2.Text = "0"
        '
        'cmbTypes
        '
        Me.cmbTypes.FormattingEnabled = True
        Me.cmbTypes.Location = New System.Drawing.Point(127, 107)
        Me.cmbTypes.Name = "cmbTypes"
        Me.cmbTypes.Size = New System.Drawing.Size(168, 21)
        Me.cmbTypes.TabIndex = 24
        '
        'cmbSubject
        '
        Me.cmbSubject.FormattingEnabled = True
        Me.cmbSubject.Location = New System.Drawing.Point(127, 82)
        Me.cmbSubject.Name = "cmbSubject"
        Me.cmbSubject.Size = New System.Drawing.Size(168, 21)
        Me.cmbSubject.TabIndex = 24
        '
        'cmbClass
        '
        Me.cmbClass.FormattingEnabled = True
        Me.cmbClass.Location = New System.Drawing.Point(127, 57)
        Me.cmbClass.Name = "cmbClass"
        Me.cmbClass.Size = New System.Drawing.Size(168, 21)
        Me.cmbClass.TabIndex = 24
        '
        'lblIdUp
        '
        Me.lblIdUp.Location = New System.Drawing.Point(124, 28)
        Me.lblIdUp.Name = "lblIdUp"
        Me.lblIdUp.Size = New System.Drawing.Size(171, 23)
        Me.lblIdUp.TabIndex = 23
        Me.lblIdUp.Text = "Label1"
        '
        'btnUpload
        '
        Me.btnUpload.Location = New System.Drawing.Point(149, 267)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(112, 44)
        Me.btnUpload.TabIndex = 6
        Me.btnUpload.Text = "Въведи оценките"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'TypesBindingSource
        '
        Me.TypesBindingSource.DataMember = "types"
        Me.TypesBindingSource.DataSource = Me.Learning_activityDataSet
        '
        'TypesTableAdapter
        '
        Me.TypesTableAdapter.ClearBeforeFill = True
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmId, Me.clmClass, Me.clmSubject, Me.clmTupes, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.dgv1.Location = New System.Drawing.Point(9, 441)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(970, 213)
        Me.dgv1.TabIndex = 21
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
        'btndel
        '
        Me.btndel.Location = New System.Drawing.Point(165, 267)
        Me.btndel.Name = "btndel"
        Me.btndel.Size = New System.Drawing.Size(112, 44)
        Me.btndel.TabIndex = 23
        Me.btndel.Text = "Изтрий оценките"
        Me.btndel.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblc6)
        Me.GroupBox3.Controls.Add(Me.lblc5)
        Me.GroupBox3.Controls.Add(Me.lblc4)
        Me.GroupBox3.Controls.Add(Me.lblc3)
        Me.GroupBox3.Controls.Add(Me.lblc2)
        Me.GroupBox3.Controls.Add(Me.lblTypeDel)
        Me.GroupBox3.Controls.Add(Me.lblSubjectDel)
        Me.GroupBox3.Controls.Add(Me.lblClasDel)
        Me.GroupBox3.Controls.Add(Me.lblIdDel)
        Me.GroupBox3.Controls.Add(Label2)
        Me.GroupBox3.Controls.Add(Label3)
        Me.GroupBox3.Controls.Add(Label4)
        Me.GroupBox3.Controls.Add(Label5)
        Me.GroupBox3.Controls.Add(Label6)
        Me.GroupBox3.Controls.Add(Label7)
        Me.GroupBox3.Controls.Add(Label8)
        Me.GroupBox3.Controls.Add(Label9)
        Me.GroupBox3.Controls.Add(Label10)
        Me.GroupBox3.Controls.Add(Me.btndel)
        Me.GroupBox3.Location = New System.Drawing.Point(334, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(322, 317)
        Me.GroupBox3.TabIndex = 26
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Изтриване на оценки"
        '
        'lblc6
        '
        Me.lblc6.Location = New System.Drawing.Point(136, 235)
        Me.lblc6.Name = "lblc6"
        Me.lblc6.Size = New System.Drawing.Size(171, 23)
        Me.lblc6.TabIndex = 42
        '
        'lblc5
        '
        Me.lblc5.Location = New System.Drawing.Point(136, 210)
        Me.lblc5.Name = "lblc5"
        Me.lblc5.Size = New System.Drawing.Size(171, 23)
        Me.lblc5.TabIndex = 41
        '
        'lblc4
        '
        Me.lblc4.Location = New System.Drawing.Point(136, 185)
        Me.lblc4.Name = "lblc4"
        Me.lblc4.Size = New System.Drawing.Size(171, 23)
        Me.lblc4.TabIndex = 40
        '
        'lblc3
        '
        Me.lblc3.Location = New System.Drawing.Point(136, 162)
        Me.lblc3.Name = "lblc3"
        Me.lblc3.Size = New System.Drawing.Size(171, 23)
        Me.lblc3.TabIndex = 39
        '
        'lblc2
        '
        Me.lblc2.Location = New System.Drawing.Point(136, 136)
        Me.lblc2.Name = "lblc2"
        Me.lblc2.Size = New System.Drawing.Size(171, 23)
        Me.lblc2.TabIndex = 38
        '
        'lblTypeDel
        '
        Me.lblTypeDel.Location = New System.Drawing.Point(136, 110)
        Me.lblTypeDel.Name = "lblTypeDel"
        Me.lblTypeDel.Size = New System.Drawing.Size(171, 23)
        Me.lblTypeDel.TabIndex = 37
        '
        'lblSubjectDel
        '
        Me.lblSubjectDel.Location = New System.Drawing.Point(136, 84)
        Me.lblSubjectDel.Name = "lblSubjectDel"
        Me.lblSubjectDel.Size = New System.Drawing.Size(171, 23)
        Me.lblSubjectDel.TabIndex = 36
        '
        'lblClasDel
        '
        Me.lblClasDel.Location = New System.Drawing.Point(136, 57)
        Me.lblClasDel.Name = "lblClasDel"
        Me.lblClasDel.Size = New System.Drawing.Size(171, 23)
        Me.lblClasDel.TabIndex = 35
        '
        'lblIdDel
        '
        Me.lblIdDel.Location = New System.Drawing.Point(136, 28)
        Me.lblIdDel.Name = "lblIdDel"
        Me.lblIdDel.Size = New System.Drawing.Size(171, 23)
        Me.lblIdDel.TabIndex = 34
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbTidR)
        Me.GroupBox2.Controls.Add(Me.cmbCidR)
        Me.GroupBox2.Controls.Add(Me.cmbSidR)
        Me.GroupBox2.Controls.Add(Me.cmb6R)
        Me.GroupBox2.Controls.Add(Me.cmb5R)
        Me.GroupBox2.Controls.Add(Me.cmb4R)
        Me.GroupBox2.Controls.Add(Me.cmb3R)
        Me.GroupBox2.Controls.Add(Me.cmb2R)
        Me.GroupBox2.Controls.Add(Me.cmbTR)
        Me.GroupBox2.Controls.Add(Me.cmbSR)
        Me.GroupBox2.Controls.Add(Me.cmbCR)
        Me.GroupBox2.Controls.Add(Me.lblidR)
        Me.GroupBox2.Controls.Add(Label11)
        Me.GroupBox2.Controls.Add(Label12)
        Me.GroupBox2.Controls.Add(Label13)
        Me.GroupBox2.Controls.Add(Label14)
        Me.GroupBox2.Controls.Add(Label15)
        Me.GroupBox2.Controls.Add(Label16)
        Me.GroupBox2.Controls.Add(Label17)
        Me.GroupBox2.Controls.Add(Label18)
        Me.GroupBox2.Controls.Add(Label19)
        Me.GroupBox2.Controls.Add(Me.btnR)
        Me.GroupBox2.Location = New System.Drawing.Point(678, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(301, 317)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Редактиране на оценки"
        '
        'cmbTidR
        '
        Me.cmbTidR.FormattingEnabled = True
        Me.cmbTidR.Location = New System.Drawing.Point(84, 108)
        Me.cmbTidR.Name = "cmbTidR"
        Me.cmbTidR.Size = New System.Drawing.Size(37, 21)
        Me.cmbTidR.TabIndex = 27
        Me.cmbTidR.Visible = False
        '
        'cmbCidR
        '
        Me.cmbCidR.FormattingEnabled = True
        Me.cmbCidR.Location = New System.Drawing.Point(84, 54)
        Me.cmbCidR.Name = "cmbCidR"
        Me.cmbCidR.Size = New System.Drawing.Size(37, 21)
        Me.cmbCidR.TabIndex = 27
        Me.cmbCidR.Visible = False
        '
        'cmbSidR
        '
        Me.cmbSidR.FormattingEnabled = True
        Me.cmbSidR.Location = New System.Drawing.Point(84, 81)
        Me.cmbSidR.Name = "cmbSidR"
        Me.cmbSidR.Size = New System.Drawing.Size(37, 21)
        Me.cmbSidR.TabIndex = 27
        Me.cmbSidR.Visible = False
        '
        'cmb6R
        '
        Me.cmb6R.FormattingEnabled = True
        Me.cmb6R.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32"})
        Me.cmb6R.Location = New System.Drawing.Point(127, 232)
        Me.cmb6R.Name = "cmb6R"
        Me.cmb6R.Size = New System.Drawing.Size(168, 21)
        Me.cmb6R.TabIndex = 24
        Me.cmb6R.Text = "0"
        '
        'cmb5R
        '
        Me.cmb5R.FormattingEnabled = True
        Me.cmb5R.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32"})
        Me.cmb5R.Location = New System.Drawing.Point(127, 207)
        Me.cmb5R.Name = "cmb5R"
        Me.cmb5R.Size = New System.Drawing.Size(168, 21)
        Me.cmb5R.TabIndex = 24
        Me.cmb5R.Text = "0"
        '
        'cmb4R
        '
        Me.cmb4R.FormattingEnabled = True
        Me.cmb4R.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32"})
        Me.cmb4R.Location = New System.Drawing.Point(127, 182)
        Me.cmb4R.Name = "cmb4R"
        Me.cmb4R.Size = New System.Drawing.Size(168, 21)
        Me.cmb4R.TabIndex = 24
        Me.cmb4R.Text = "0"
        '
        'cmb3R
        '
        Me.cmb3R.FormattingEnabled = True
        Me.cmb3R.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32"})
        Me.cmb3R.Location = New System.Drawing.Point(127, 157)
        Me.cmb3R.Name = "cmb3R"
        Me.cmb3R.Size = New System.Drawing.Size(168, 21)
        Me.cmb3R.TabIndex = 24
        Me.cmb3R.Text = "0"
        '
        'cmb2R
        '
        Me.cmb2R.FormattingEnabled = True
        Me.cmb2R.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32"})
        Me.cmb2R.Location = New System.Drawing.Point(127, 133)
        Me.cmb2R.Name = "cmb2R"
        Me.cmb2R.Size = New System.Drawing.Size(168, 21)
        Me.cmb2R.TabIndex = 24
        Me.cmb2R.Text = "0"
        '
        'cmbTR
        '
        Me.cmbTR.FormattingEnabled = True
        Me.cmbTR.Location = New System.Drawing.Point(127, 107)
        Me.cmbTR.Name = "cmbTR"
        Me.cmbTR.Size = New System.Drawing.Size(168, 21)
        Me.cmbTR.TabIndex = 24
        '
        'cmbSR
        '
        Me.cmbSR.FormattingEnabled = True
        Me.cmbSR.Location = New System.Drawing.Point(127, 82)
        Me.cmbSR.Name = "cmbSR"
        Me.cmbSR.Size = New System.Drawing.Size(168, 21)
        Me.cmbSR.TabIndex = 24
        '
        'cmbCR
        '
        Me.cmbCR.FormattingEnabled = True
        Me.cmbCR.Location = New System.Drawing.Point(127, 57)
        Me.cmbCR.Name = "cmbCR"
        Me.cmbCR.Size = New System.Drawing.Size(168, 21)
        Me.cmbCR.TabIndex = 24
        '
        'lblidR
        '
        Me.lblidR.Location = New System.Drawing.Point(127, 28)
        Me.lblidR.Name = "lblidR"
        Me.lblidR.Size = New System.Drawing.Size(168, 23)
        Me.lblidR.TabIndex = 23
        '
        'btnR
        '
        Me.btnR.Location = New System.Drawing.Point(127, 267)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(134, 44)
        Me.btnR.TabIndex = 6
        Me.btnR.Text = "Редактирай оценките"
        Me.btnR.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblStatus)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.btnUpLoadWithExcel)
        Me.GroupBox4.Controls.Add(Me.btnCreateExcel)
        Me.GroupBox4.Location = New System.Drawing.Point(275, 335)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(447, 91)
        Me.GroupBox4.TabIndex = 20
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Добавяне на оценки от Excel"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(344, 44)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(69, 13)
        Me.lblStatus.TabIndex = 7
        Me.lblStatus.Text = "няма статус"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(299, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Статус:"
        '
        'btnUpLoadWithExcel
        '
        Me.btnUpLoadWithExcel.Location = New System.Drawing.Point(124, 28)
        Me.btnUpLoadWithExcel.Name = "btnUpLoadWithExcel"
        Me.btnUpLoadWithExcel.Size = New System.Drawing.Size(168, 44)
        Me.btnUpLoadWithExcel.TabIndex = 6
        Me.btnUpLoadWithExcel.Text = "Добавяне на оценки от фаил"
        Me.btnUpLoadWithExcel.UseVisualStyleBackColor = True
        '
        'btnCreateExcel
        '
        Me.btnCreateExcel.Location = New System.Drawing.Point(6, 28)
        Me.btnCreateExcel.Name = "btnCreateExcel"
        Me.btnCreateExcel.Size = New System.Drawing.Size(112, 44)
        Me.btnCreateExcel.TabIndex = 6
        Me.btnCreateExcel.Text = "Създай шаблон"
        Me.btnCreateExcel.UseVisualStyleBackColor = True
        '
        'purpose_manual_input
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(991, 663)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        HelpProvider1.SetHelpKeyword(Me, "Oценки")
        HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        HelpProvider1.SetHelpString(Me, "Oценки")
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "purpose_manual_input"
        HelpProvider1.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Въвеждане, изтриване и редактиране на оценки"
        CType(Me.Learning_activityDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AbsenceBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurposeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Learning_activityDataSet As learning_activity.learning_activityDataSet
    Friend WithEvents AbsenceBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AbsenceTableAdapter As learning_activity.learning_activityDataSetTableAdapters.absenceTableAdapter
    Friend WithEvents TableAdapterManager As learning_activity.learning_activityDataSetTableAdapters.TableAdapterManager
    Friend WithEvents PurposeTableAdapter As learning_activity.learning_activityDataSetTableAdapters.purposeTableAdapter
    Friend WithEvents PurposeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbC6 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbC5 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbC4 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbC3 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbC2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTypes As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSubject As System.Windows.Forms.ComboBox
    Friend WithEvents cmbClass As System.Windows.Forms.ComboBox
    Friend WithEvents lblIdUp As System.Windows.Forms.Label
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents TypesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TypesTableAdapter As learning_activity.learning_activityDataSetTableAdapters.typesTableAdapter
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents cmbClassId As System.Windows.Forms.ComboBox
    Friend WithEvents btndel As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblSubjectDel As System.Windows.Forms.Label
    Friend WithEvents lblClasDel As System.Windows.Forms.Label
    Friend WithEvents lblIdDel As System.Windows.Forms.Label
    Friend WithEvents lblc6 As System.Windows.Forms.Label
    Friend WithEvents lblc5 As System.Windows.Forms.Label
    Friend WithEvents lblc4 As System.Windows.Forms.Label
    Friend WithEvents lblc3 As System.Windows.Forms.Label
    Friend WithEvents lblc2 As System.Windows.Forms.Label
    Friend WithEvents lblTypeDel As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmb6R As System.Windows.Forms.ComboBox
    Friend WithEvents cmb5R As System.Windows.Forms.ComboBox
    Friend WithEvents cmb4R As System.Windows.Forms.ComboBox
    Friend WithEvents cmb3R As System.Windows.Forms.ComboBox
    Friend WithEvents cmb2R As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTR As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSR As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCR As System.Windows.Forms.ComboBox
    Friend WithEvents lblidR As System.Windows.Forms.Label
    Friend WithEvents btnR As System.Windows.Forms.Button
    Friend WithEvents cmbTidR As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSidR As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCidR As System.Windows.Forms.ComboBox
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
    Friend WithEvents btnCreateExcel As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnUpLoadWithExcel As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents lblStatus As Label
    Friend WithEvents Label1 As Label
End Class
