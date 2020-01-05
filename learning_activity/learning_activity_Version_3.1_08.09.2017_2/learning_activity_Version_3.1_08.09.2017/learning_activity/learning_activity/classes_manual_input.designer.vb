<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class classes_manual_input
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
        Dim ПаралелкаLabel As System.Windows.Forms.Label
        Dim ПрофилLabel As System.Windows.Forms.Label
        Dim Брой_ученициLabel As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Учебна_годинаLabel As System.Windows.Forms.Label
        Dim НомерLabel1 As System.Windows.Forms.Label
        Dim Учебна_годинаLabel1 As System.Windows.Forms.Label
        Dim КласLabel1 As System.Windows.Forms.Label
        Dim ПаралелкаLabel1 As System.Windows.Forms.Label
        Dim ПрофилLabel1 As System.Windows.Forms.Label
        Dim Брой_ученициLabel1 As System.Windows.Forms.Label
        Dim Label9 As System.Windows.Forms.Label
        Dim Label11 As System.Windows.Forms.Label
        Dim Label10 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(classes_manual_input))
        Me.lblYearTo = New System.Windows.Forms.Label()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.iddgv1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.shoolYear_dgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Grade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.classas_dgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.profile_dgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Student_dgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbStudentsUp = New System.Windows.Forms.ComboBox()
        Me.cmbprofileUp = New System.Windows.Forms.ComboBox()
        Me.cmbClassUp = New System.Windows.Forms.ComboBox()
        Me.cmbGradeUp = New System.Windows.Forms.ComboBox()
        Me.cmbyearUp = New System.Windows.Forms.ComboBox()
        Me.lblIdUp = New System.Windows.Forms.Label()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.Learning_activityDataSet = New learning_activity.learning_activityDataSet()
        Me.ClassesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ClassesTableAdapter = New learning_activity.learning_activityDataSetTableAdapters.classesTableAdapter()
        Me.TableAdapterManager = New learning_activity.learning_activityDataSetTableAdapters.TableAdapterManager()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblstudentDel = New System.Windows.Forms.Label()
        Me.lblProfilDel = New System.Windows.Forms.Label()
        Me.lblClassesDel = New System.Windows.Forms.Label()
        Me.lblbGradeDel = New System.Windows.Forms.Label()
        Me.lblYearDel = New System.Windows.Forms.Label()
        Me.btndeletesubject = New System.Windows.Forms.Button()
        Me.lblIdDel = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbSR = New System.Windows.Forms.ComboBox()
        Me.btnRedakchia = New System.Windows.Forms.Button()
        Me.cmbParalR = New System.Windows.Forms.ComboBox()
        Me.lblidR = New System.Windows.Forms.Label()
        Me.cmbClassR = New System.Windows.Forms.ComboBox()
        Me.cmbYR = New System.Windows.Forms.ComboBox()
        Me.cmbPR = New System.Windows.Forms.ComboBox()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmbClassTo = New System.Windows.Forms.ComboBox()
        Me.cmbClassFrom = New System.Windows.Forms.ComboBox()
        Me.cmbYearFrom = New System.Windows.Forms.ComboBox()
        Me.btnPremin = New System.Windows.Forms.Button()
        НомерLabel = New System.Windows.Forms.Label()
        КласLabel = New System.Windows.Forms.Label()
        ПаралелкаLabel = New System.Windows.Forms.Label()
        ПрофилLabel = New System.Windows.Forms.Label()
        Брой_ученициLabel = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        Label7 = New System.Windows.Forms.Label()
        Учебна_годинаLabel = New System.Windows.Forms.Label()
        НомерLabel1 = New System.Windows.Forms.Label()
        Учебна_годинаLabel1 = New System.Windows.Forms.Label()
        КласLabel1 = New System.Windows.Forms.Label()
        ПаралелкаLabel1 = New System.Windows.Forms.Label()
        ПрофилLabel1 = New System.Windows.Forms.Label()
        Брой_ученициLabel1 = New System.Windows.Forms.Label()
        Label9 = New System.Windows.Forms.Label()
        Label11 = New System.Windows.Forms.Label()
        Label10 = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Label8 = New System.Windows.Forms.Label()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Learning_activityDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClassesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'НомерLabel
        '
        НомерLabel.AutoSize = True
        НомерLabel.Location = New System.Drawing.Point(23, 37)
        НомерLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        НомерLabel.Name = "НомерLabel"
        НомерLabel.Size = New System.Drawing.Size(37, 17)
        НомерLabel.TabIndex = 6
        НомерLabel.Text = "Код:"
        '
        'КласLabel
        '
        КласLabel.AutoSize = True
        КласLabel.Location = New System.Drawing.Point(23, 106)
        КласLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        КласLabel.Name = "КласLabel"
        КласLabel.Size = New System.Drawing.Size(44, 17)
        КласLabel.TabIndex = 10
        КласLabel.Text = "Клас:"
        '
        'ПаралелкаLabel
        '
        ПаралелкаLabel.AutoSize = True
        ПаралелкаLabel.Location = New System.Drawing.Point(23, 139)
        ПаралелкаLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        ПаралелкаLabel.Name = "ПаралелкаLabel"
        ПаралелкаLabel.Size = New System.Drawing.Size(85, 17)
        ПаралелкаLabel.TabIndex = 12
        ПаралелкаLabel.Text = "Паралелка:"
        '
        'ПрофилLabel
        '
        ПрофилLabel.AutoSize = True
        ПрофилLabel.Location = New System.Drawing.Point(23, 172)
        ПрофилLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        ПрофилLabel.Name = "ПрофилLabel"
        ПрофилLabel.Size = New System.Drawing.Size(65, 17)
        ПрофилLabel.TabIndex = 14
        ПрофилLabel.Text = "Профил:"
        '
        'Брой_ученициLabel
        '
        Брой_ученициLabel.AutoSize = True
        Брой_ученициLabel.Location = New System.Drawing.Point(23, 206)
        Брой_ученициLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Брой_ученициLabel.Name = "Брой_ученициLabel"
        Брой_ученициLabel.Size = New System.Drawing.Size(104, 17)
        Брой_ученициLabel.TabIndex = 16
        Брой_ученициLabel.Text = "Брой ученици:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(23, 37)
        Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(37, 17)
        Label2.TabIndex = 6
        Label2.Text = "Код:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(23, 73)
        Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(110, 17)
        Label3.TabIndex = 8
        Label3.Text = "Учебна година:"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(23, 106)
        Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(44, 17)
        Label4.TabIndex = 10
        Label4.Text = "Клас:"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(23, 139)
        Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(85, 17)
        Label5.TabIndex = 12
        Label5.Text = "Паралелка:"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(23, 172)
        Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(65, 17)
        Label6.TabIndex = 14
        Label6.Text = "Профил:"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Location = New System.Drawing.Point(23, 206)
        Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(104, 17)
        Label7.TabIndex = 16
        Label7.Text = "Брой ученици:"
        '
        'Учебна_годинаLabel
        '
        Учебна_годинаLabel.AutoSize = True
        Учебна_годинаLabel.Location = New System.Drawing.Point(23, 73)
        Учебна_годинаLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Учебна_годинаLabel.Name = "Учебна_годинаLabel"
        Учебна_годинаLabel.Size = New System.Drawing.Size(110, 17)
        Учебна_годинаLabel.TabIndex = 8
        Учебна_годинаLabel.Text = "Учебна година:"
        '
        'НомерLabel1
        '
        НомерLabel1.AutoSize = True
        НомерLabel1.Location = New System.Drawing.Point(28, 37)
        НомерLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        НомерLabel1.Name = "НомерLabel1"
        НомерLabel1.Size = New System.Drawing.Size(37, 17)
        НомерLabel1.TabIndex = 0
        НомерLabel1.Text = "Код:"
        '
        'Учебна_годинаLabel1
        '
        Учебна_годинаLabel1.AutoSize = True
        Учебна_годинаLabel1.Location = New System.Drawing.Point(28, 73)
        Учебна_годинаLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Учебна_годинаLabel1.Name = "Учебна_годинаLabel1"
        Учебна_годинаLabel1.Size = New System.Drawing.Size(110, 17)
        Учебна_годинаLabel1.TabIndex = 2
        Учебна_годинаLabel1.Text = "Учебна година:"
        '
        'КласLabel1
        '
        КласLabel1.AutoSize = True
        КласLabel1.Location = New System.Drawing.Point(28, 106)
        КласLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        КласLabel1.Name = "КласLabel1"
        КласLabel1.Size = New System.Drawing.Size(44, 17)
        КласLabel1.TabIndex = 4
        КласLabel1.Text = "Клас:"
        '
        'ПаралелкаLabel1
        '
        ПаралелкаLabel1.AutoSize = True
        ПаралелкаLabel1.Location = New System.Drawing.Point(28, 139)
        ПаралелкаLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        ПаралелкаLabel1.Name = "ПаралелкаLabel1"
        ПаралелкаLabel1.Size = New System.Drawing.Size(85, 17)
        ПаралелкаLabel1.TabIndex = 6
        ПаралелкаLabel1.Text = "Паралелка:"
        '
        'ПрофилLabel1
        '
        ПрофилLabel1.AutoSize = True
        ПрофилLabel1.Location = New System.Drawing.Point(28, 172)
        ПрофилLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        ПрофилLabel1.Name = "ПрофилLabel1"
        ПрофилLabel1.Size = New System.Drawing.Size(65, 17)
        ПрофилLabel1.TabIndex = 8
        ПрофилLabel1.Text = "Профил:"
        '
        'Брой_ученициLabel1
        '
        Брой_ученициLabel1.AutoSize = True
        Брой_ученициLabel1.Location = New System.Drawing.Point(28, 206)
        Брой_ученициLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Брой_ученициLabel1.Name = "Брой_ученициLabel1"
        Брой_ученициLabel1.Size = New System.Drawing.Size(104, 17)
        Брой_ученициLabel1.TabIndex = 10
        Брой_ученициLabel1.Text = "Брой ученици:"
        '
        'Label9
        '
        Label9.AutoSize = True
        Label9.Location = New System.Drawing.Point(13, 49)
        Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(216, 17)
        Label9.TabIndex = 8
        Label9.Text = "Класовете от учебната година:"
        '
        'Label11
        '
        Label11.AutoSize = True
        Label11.Location = New System.Drawing.Point(15, 140)
        Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label11.Name = "Label11"
        Label11.Size = New System.Drawing.Size(65, 17)
        Label11.TabIndex = 12
        Label11.Text = "До клас:"
        '
        'Label10
        '
        Label10.AutoSize = True
        Label10.Location = New System.Drawing.Point(15, 111)
        Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(64, 17)
        Label10.TabIndex = 10
        Label10.Text = "От клас:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(155, 73)
        Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(33, 17)
        Label1.TabIndex = 8
        Label1.Text = "към"
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.Location = New System.Drawing.Point(17, 73)
        Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(23, 17)
        Label8.TabIndex = 8
        Label8.Text = "от"
        '
        'lblYearTo
        '
        Me.lblYearTo.AutoSize = True
        Me.lblYearTo.Location = New System.Drawing.Point(192, 73)
        Me.lblYearTo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblYearTo.Name = "lblYearTo"
        Me.lblYearTo.Size = New System.Drawing.Size(60, 17)
        Me.lblYearTo.TabIndex = 8
        Me.lblYearTo.Text = "2011/12"
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.iddgv1, Me.shoolYear_dgv, Me.Grade, Me.classas_dgv, Me.profile_dgv, Me.Student_dgv})
        Me.dgv1.Location = New System.Drawing.Point(284, 343)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(916, 288)
        Me.dgv1.TabIndex = 3
        '
        'iddgv1
        '
        Me.iddgv1.HeaderText = "Код"
        Me.iddgv1.Name = "iddgv1"
        Me.iddgv1.ReadOnly = True
        '
        'shoolYear_dgv
        '
        Me.shoolYear_dgv.HeaderText = "Учебна година"
        Me.shoolYear_dgv.Name = "shoolYear_dgv"
        Me.shoolYear_dgv.ReadOnly = True
        '
        'Grade
        '
        Me.Grade.HeaderText = "Клас"
        Me.Grade.Name = "Grade"
        Me.Grade.ReadOnly = True
        '
        'classas_dgv
        '
        Me.classas_dgv.HeaderText = "Паралелка"
        Me.classas_dgv.Name = "classas_dgv"
        Me.classas_dgv.ReadOnly = True
        '
        'profile_dgv
        '
        Me.profile_dgv.HeaderText = "Профил"
        Me.profile_dgv.Name = "profile_dgv"
        Me.profile_dgv.ReadOnly = True
        '
        'Student_dgv
        '
        Me.Student_dgv.HeaderText = "Брой ученици"
        Me.Student_dgv.Name = "Student_dgv"
        Me.Student_dgv.ReadOnly = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbStudentsUp)
        Me.GroupBox1.Controls.Add(Me.cmbprofileUp)
        Me.GroupBox1.Controls.Add(Me.cmbClassUp)
        Me.GroupBox1.Controls.Add(Me.cmbGradeUp)
        Me.GroupBox1.Controls.Add(Me.cmbyearUp)
        Me.GroupBox1.Controls.Add(Me.lblIdUp)
        Me.GroupBox1.Controls.Add(НомерLabel)
        Me.GroupBox1.Controls.Add(Учебна_годинаLabel)
        Me.GroupBox1.Controls.Add(КласLabel)
        Me.GroupBox1.Controls.Add(ПаралелкаLabel)
        Me.GroupBox1.Controls.Add(ПрофилLabel)
        Me.GroupBox1.Controls.Add(Брой_ученициLabel)
        Me.GroupBox1.Controls.Add(Me.btnUpload)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 15)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(400, 320)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Добавяне на клас"
        '
        'cmbStudentsUp
        '
        Me.cmbStudentsUp.FormattingEnabled = True
        Me.cmbStudentsUp.Items.AddRange(New Object() {"5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32"})
        Me.cmbStudentsUp.Location = New System.Drawing.Point(189, 202)
        Me.cmbStudentsUp.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbStudentsUp.Name = "cmbStudentsUp"
        Me.cmbStudentsUp.Size = New System.Drawing.Size(188, 24)
        Me.cmbStudentsUp.TabIndex = 22
        Me.cmbStudentsUp.Text = "20"
        '
        'cmbprofileUp
        '
        Me.cmbprofileUp.FormattingEnabled = True
        Me.cmbprofileUp.Location = New System.Drawing.Point(189, 169)
        Me.cmbprofileUp.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbprofileUp.Name = "cmbprofileUp"
        Me.cmbprofileUp.Size = New System.Drawing.Size(188, 24)
        Me.cmbprofileUp.TabIndex = 21
        '
        'cmbClassUp
        '
        Me.cmbClassUp.FormattingEnabled = True
        Me.cmbClassUp.Items.AddRange(New Object() {"а", "б", "в", "г", "д", "е", "ж"})
        Me.cmbClassUp.Location = New System.Drawing.Point(189, 135)
        Me.cmbClassUp.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbClassUp.Name = "cmbClassUp"
        Me.cmbClassUp.Size = New System.Drawing.Size(188, 24)
        Me.cmbClassUp.TabIndex = 20
        Me.cmbClassUp.Text = "а"
        '
        'cmbGradeUp
        '
        Me.cmbGradeUp.FormattingEnabled = True
        Me.cmbGradeUp.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cmbGradeUp.Location = New System.Drawing.Point(189, 102)
        Me.cmbGradeUp.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbGradeUp.Name = "cmbGradeUp"
        Me.cmbGradeUp.Size = New System.Drawing.Size(188, 24)
        Me.cmbGradeUp.TabIndex = 19
        Me.cmbGradeUp.Text = "1"
        '
        'cmbyearUp
        '
        Me.cmbyearUp.FormattingEnabled = True
        Me.cmbyearUp.Items.AddRange(New Object() {"2010/11", "2011/12", "2012/13", "2013/14", "2014/15", "2015/16", "2016/17", "2017/18", "2018/19", "2019/20", "2020/21", "2021/22", "2022/23", "2023/24", "2024/25", "2025/26", "2026/27", "2027/28", "2028/29", "2029/30", "2030/31", "2031/32", "2032/33", "2033/34", "2034/35", "2035/36", "2036/37", "2037/38", "2038/39", "2039/40", "2040/41"})
        Me.cmbyearUp.Location = New System.Drawing.Point(189, 69)
        Me.cmbyearUp.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbyearUp.Name = "cmbyearUp"
        Me.cmbyearUp.Size = New System.Drawing.Size(188, 24)
        Me.cmbyearUp.TabIndex = 18
        Me.cmbyearUp.Text = "2010/11"
        '
        'lblIdUp
        '
        Me.lblIdUp.Location = New System.Drawing.Point(185, 37)
        Me.lblIdUp.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIdUp.Name = "lblIdUp"
        Me.lblIdUp.Size = New System.Drawing.Size(193, 28)
        Me.lblIdUp.TabIndex = 17
        '
        'btnUpload
        '
        Me.btnUpload.Location = New System.Drawing.Point(209, 246)
        Me.btnUpload.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(149, 54)
        Me.btnUpload.TabIndex = 6
        Me.btnUpload.Text = "Въведи класа"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'Learning_activityDataSet
        '
        Me.Learning_activityDataSet.DataSetName = "learning_activityDataSet"
        Me.Learning_activityDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ClassesBindingSource
        '
        Me.ClassesBindingSource.DataMember = "classes"
        Me.ClassesBindingSource.DataSource = Me.Learning_activityDataSet
        '
        'ClassesTableAdapter
        '
        Me.ClassesTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.absenceTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.classesTableAdapter = Me.ClassesTableAdapter
        Me.TableAdapterManager.profilesTableAdapter = Nothing
        Me.TableAdapterManager.purposeTableAdapter = Nothing
        Me.TableAdapterManager.subjectTableAdapter = Nothing
        Me.TableAdapterManager.teachersTableAdapter = Nothing
        Me.TableAdapterManager.teachingTableAdapter = Nothing
        Me.TableAdapterManager.typesTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = learning_activity.learning_activityDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblstudentDel)
        Me.GroupBox3.Controls.Add(Me.lblProfilDel)
        Me.GroupBox3.Controls.Add(Me.lblClassesDel)
        Me.GroupBox3.Controls.Add(Me.lblbGradeDel)
        Me.GroupBox3.Controls.Add(Me.lblYearDel)
        Me.GroupBox3.Controls.Add(Me.btndeletesubject)
        Me.GroupBox3.Controls.Add(Me.lblIdDel)
        Me.GroupBox3.Controls.Add(Label2)
        Me.GroupBox3.Controls.Add(Label3)
        Me.GroupBox3.Controls.Add(Label4)
        Me.GroupBox3.Controls.Add(Label5)
        Me.GroupBox3.Controls.Add(Label6)
        Me.GroupBox3.Controls.Add(Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(424, 15)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(384, 320)
        Me.GroupBox3.TabIndex = 21
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Изтриване на клас"
        '
        'lblstudentDel
        '
        Me.lblstudentDel.Location = New System.Drawing.Point(185, 199)
        Me.lblstudentDel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblstudentDel.Name = "lblstudentDel"
        Me.lblstudentDel.Size = New System.Drawing.Size(193, 28)
        Me.lblstudentDel.TabIndex = 28
        '
        'lblProfilDel
        '
        Me.lblProfilDel.Location = New System.Drawing.Point(185, 172)
        Me.lblProfilDel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProfilDel.Name = "lblProfilDel"
        Me.lblProfilDel.Size = New System.Drawing.Size(193, 28)
        Me.lblProfilDel.TabIndex = 27
        '
        'lblClassesDel
        '
        Me.lblClassesDel.Location = New System.Drawing.Point(185, 139)
        Me.lblClassesDel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblClassesDel.Name = "lblClassesDel"
        Me.lblClassesDel.Size = New System.Drawing.Size(193, 28)
        Me.lblClassesDel.TabIndex = 26
        '
        'lblbGradeDel
        '
        Me.lblbGradeDel.Location = New System.Drawing.Point(185, 106)
        Me.lblbGradeDel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblbGradeDel.Name = "lblbGradeDel"
        Me.lblbGradeDel.Size = New System.Drawing.Size(193, 28)
        Me.lblbGradeDel.TabIndex = 25
        '
        'lblYearDel
        '
        Me.lblYearDel.Location = New System.Drawing.Point(185, 65)
        Me.lblYearDel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblYearDel.Name = "lblYearDel"
        Me.lblYearDel.Size = New System.Drawing.Size(193, 28)
        Me.lblYearDel.TabIndex = 24
        '
        'btndeletesubject
        '
        Me.btndeletesubject.Location = New System.Drawing.Point(129, 246)
        Me.btndeletesubject.Margin = New System.Windows.Forms.Padding(4)
        Me.btndeletesubject.Name = "btndeletesubject"
        Me.btndeletesubject.Size = New System.Drawing.Size(149, 54)
        Me.btndeletesubject.TabIndex = 23
        Me.btndeletesubject.Text = "Изтрий класа"
        Me.btndeletesubject.UseVisualStyleBackColor = True
        '
        'lblIdDel
        '
        Me.lblIdDel.Location = New System.Drawing.Point(185, 37)
        Me.lblIdDel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIdDel.Name = "lblIdDel"
        Me.lblIdDel.Size = New System.Drawing.Size(193, 28)
        Me.lblIdDel.TabIndex = 17
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbSR)
        Me.GroupBox2.Controls.Add(Me.btnRedakchia)
        Me.GroupBox2.Controls.Add(НомерLabel1)
        Me.GroupBox2.Controls.Add(Me.cmbParalR)
        Me.GroupBox2.Controls.Add(Me.lblidR)
        Me.GroupBox2.Controls.Add(Me.cmbClassR)
        Me.GroupBox2.Controls.Add(Учебна_годинаLabel1)
        Me.GroupBox2.Controls.Add(Me.cmbYR)
        Me.GroupBox2.Controls.Add(КласLabel1)
        Me.GroupBox2.Controls.Add(ПаралелкаLabel1)
        Me.GroupBox2.Controls.Add(ПрофилLabel1)
        Me.GroupBox2.Controls.Add(Me.cmbPR)
        Me.GroupBox2.Controls.Add(Брой_ученициLabel1)
        Me.GroupBox2.Location = New System.Drawing.Point(816, 15)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(384, 320)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Редактиране на клас"
        '
        'cmbSR
        '
        Me.cmbSR.FormattingEnabled = True
        Me.cmbSR.Items.AddRange(New Object() {"5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32"})
        Me.cmbSR.Location = New System.Drawing.Point(149, 202)
        Me.cmbSR.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSR.Name = "cmbSR"
        Me.cmbSR.Size = New System.Drawing.Size(188, 24)
        Me.cmbSR.TabIndex = 22
        Me.cmbSR.Text = "20"
        '
        'btnRedakchia
        '
        Me.btnRedakchia.Location = New System.Drawing.Point(152, 246)
        Me.btnRedakchia.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRedakchia.Name = "btnRedakchia"
        Me.btnRedakchia.Size = New System.Drawing.Size(155, 54)
        Me.btnRedakchia.TabIndex = 12
        Me.btnRedakchia.Text = "Редактирай класа"
        Me.btnRedakchia.UseVisualStyleBackColor = True
        '
        'cmbParalR
        '
        Me.cmbParalR.FormattingEnabled = True
        Me.cmbParalR.Items.AddRange(New Object() {"а", "б", "в", "г", "д", "е", "ж"})
        Me.cmbParalR.Location = New System.Drawing.Point(149, 135)
        Me.cmbParalR.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbParalR.Name = "cmbParalR"
        Me.cmbParalR.Size = New System.Drawing.Size(188, 24)
        Me.cmbParalR.TabIndex = 20
        Me.cmbParalR.Text = "а"
        '
        'lblidR
        '
        Me.lblidR.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClassesBindingSource, "Номер", True))
        Me.lblidR.Location = New System.Drawing.Point(149, 37)
        Me.lblidR.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblidR.Name = "lblidR"
        Me.lblidR.Size = New System.Drawing.Size(189, 28)
        Me.lblidR.TabIndex = 1
        Me.lblidR.Text = "Label1"
        '
        'cmbClassR
        '
        Me.cmbClassR.FormattingEnabled = True
        Me.cmbClassR.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cmbClassR.Location = New System.Drawing.Point(149, 102)
        Me.cmbClassR.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbClassR.Name = "cmbClassR"
        Me.cmbClassR.Size = New System.Drawing.Size(188, 24)
        Me.cmbClassR.TabIndex = 19
        Me.cmbClassR.Text = "1"
        '
        'cmbYR
        '
        Me.cmbYR.FormattingEnabled = True
        Me.cmbYR.Items.AddRange(New Object() {"2010/11", "2011/12", "2012/13", "2013/14", "2014/15", "2015/16", "2016/17", "2017/18", "2018/19", "2019/20", "2020/21", "2021/22", "2022/23", "2023/24", "2024/25", "2025/26", "2026/27", "2027/28", "2028/29", "2029/30", "2030/31", "2031/32", "2032/33", "2033/34", "2034/35", "2035/36", "2036/37", "2037/38", "2038/39", "2039/40", "2040/41"})
        Me.cmbYR.Location = New System.Drawing.Point(149, 69)
        Me.cmbYR.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbYR.Name = "cmbYR"
        Me.cmbYR.Size = New System.Drawing.Size(188, 24)
        Me.cmbYR.TabIndex = 18
        Me.cmbYR.Text = "2010/11"
        '
        'cmbPR
        '
        Me.cmbPR.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClassesBindingSource, "Профил", True))
        Me.cmbPR.FormattingEnabled = True
        Me.cmbPR.Location = New System.Drawing.Point(149, 169)
        Me.cmbPR.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPR.Name = "cmbPR"
        Me.cmbPR.Size = New System.Drawing.Size(188, 24)
        Me.cmbPR.TabIndex = 9
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "helpHTML\HelpHTML.chm"
        Me.HelpProvider1.Tag = "F1"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmbClassTo)
        Me.GroupBox4.Controls.Add(Me.cmbClassFrom)
        Me.GroupBox4.Controls.Add(Me.cmbYearFrom)
        Me.GroupBox4.Controls.Add(Label8)
        Me.GroupBox4.Controls.Add(Label1)
        Me.GroupBox4.Controls.Add(Me.lblYearTo)
        Me.GroupBox4.Controls.Add(Label9)
        Me.GroupBox4.Controls.Add(Label10)
        Me.GroupBox4.Controls.Add(Label11)
        Me.GroupBox4.Controls.Add(Me.btnPremin)
        Me.GroupBox4.Location = New System.Drawing.Point(16, 374)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(260, 220)
        Me.GroupBox4.TabIndex = 19
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Преминаване на клаосвете към следваща година"
        '
        'cmbClassTo
        '
        Me.cmbClassTo.FormattingEnabled = True
        Me.cmbClassTo.Items.AddRange(New Object() {"2", "3", "4", "5", "6", "7", "8", "9", "10", "11"})
        Me.cmbClassTo.Location = New System.Drawing.Point(89, 137)
        Me.cmbClassTo.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbClassTo.Name = "cmbClassTo"
        Me.cmbClassTo.Size = New System.Drawing.Size(61, 24)
        Me.cmbClassTo.TabIndex = 20
        Me.cmbClassTo.Text = "11"
        '
        'cmbClassFrom
        '
        Me.cmbClassFrom.FormattingEnabled = True
        Me.cmbClassFrom.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cmbClassFrom.Location = New System.Drawing.Point(89, 107)
        Me.cmbClassFrom.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbClassFrom.Name = "cmbClassFrom"
        Me.cmbClassFrom.Size = New System.Drawing.Size(61, 24)
        Me.cmbClassFrom.TabIndex = 19
        Me.cmbClassFrom.Text = "1"
        '
        'cmbYearFrom
        '
        Me.cmbYearFrom.FormattingEnabled = True
        Me.cmbYearFrom.Items.AddRange(New Object() {"2010/11", "2011/12", "2012/13", "2013/14", "2014/15", "2015/16", "2016/17", "2017/18", "2018/19", "2019/20", "2020/21", "2021/22", "2022/23", "2023/24", "2024/25", "2025/26", "2026/27", "2027/28", "2028/29", "2029/30", "2030/31", "2031/32", "2032/33", "2033/34", "2034/35", "2035/36", "2036/37", "2037/38", "2038/39", "2039/40", "2040/41"})
        Me.cmbYearFrom.Location = New System.Drawing.Point(45, 69)
        Me.cmbYearFrom.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbYearFrom.Name = "cmbYearFrom"
        Me.cmbYearFrom.Size = New System.Drawing.Size(100, 24)
        Me.cmbYearFrom.TabIndex = 18
        Me.cmbYearFrom.Text = "2010/11"
        '
        'btnPremin
        '
        Me.btnPremin.Location = New System.Drawing.Point(27, 170)
        Me.btnPremin.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPremin.Name = "btnPremin"
        Me.btnPremin.Size = New System.Drawing.Size(225, 44)
        Me.btnPremin.TabIndex = 6
        Me.btnPremin.Text = "Преминаване на класовете от тази година"
        Me.btnPremin.UseVisualStyleBackColor = True
        '
        'classes_manual_input
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1213, 639)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgv1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider1.SetHelpKeyword(Me, "Класове")
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.HelpProvider1.SetHelpString(Me, "Класове")
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "classes_manual_input"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Въвеждане, изтриване и редактиране на класове"
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Learning_activityDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClassesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents Learning_activityDataSet As learning_activity.learning_activityDataSet
    Friend WithEvents ClassesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ClassesTableAdapter As learning_activity.learning_activityDataSetTableAdapters.classesTableAdapter
    Friend WithEvents TableAdapterManager As learning_activity.learning_activityDataSetTableAdapters.TableAdapterManager
    Friend WithEvents cmbStudentsUp As System.Windows.Forms.ComboBox
    Friend WithEvents cmbprofileUp As System.Windows.Forms.ComboBox
    Friend WithEvents cmbClassUp As System.Windows.Forms.ComboBox
    Friend WithEvents cmbGradeUp As System.Windows.Forms.ComboBox
    Friend WithEvents lblIdUp As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblstudentDel As System.Windows.Forms.Label
    Friend WithEvents lblProfilDel As System.Windows.Forms.Label
    Friend WithEvents lblClassesDel As System.Windows.Forms.Label
    Friend WithEvents lblbGradeDel As System.Windows.Forms.Label
    Friend WithEvents lblYearDel As System.Windows.Forms.Label
    Friend WithEvents btndeletesubject As System.Windows.Forms.Button
    Friend WithEvents lblIdDel As System.Windows.Forms.Label
    Friend WithEvents cmbyearUp As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblidR As System.Windows.Forms.Label
    Friend WithEvents cmbPR As System.Windows.Forms.ComboBox
    Friend WithEvents btnRedakchia As System.Windows.Forms.Button
    Friend WithEvents cmbSR As System.Windows.Forms.ComboBox
    Friend WithEvents cmbParalR As System.Windows.Forms.ComboBox
    Friend WithEvents cmbClassR As System.Windows.Forms.ComboBox
    Friend WithEvents cmbYR As System.Windows.Forms.ComboBox
    Private WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents iddgv1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents shoolYear_dgv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Grade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents classas_dgv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents profile_dgv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Student_dgv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbClassTo As System.Windows.Forms.ComboBox
    Friend WithEvents cmbClassFrom As System.Windows.Forms.ComboBox
    Friend WithEvents cmbYearFrom As System.Windows.Forms.ComboBox
    Friend WithEvents btnPremin As System.Windows.Forms.Button
    Private WithEvents lblYearTo As System.Windows.Forms.Label
End Class
