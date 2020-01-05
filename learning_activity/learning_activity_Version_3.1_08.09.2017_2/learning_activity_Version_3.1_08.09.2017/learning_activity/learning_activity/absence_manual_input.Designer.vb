<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class absence_manual_input
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
        Dim КласLabel As System.Windows.Forms.Label
        Dim Брой_извинени_отсъствияLabel As System.Windows.Forms.Label
        Dim Брой_неизвинени_отсъствияLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim Label9 As System.Windows.Forms.Label
        Dim Label10 As System.Windows.Forms.Label
        Dim Label11 As System.Windows.Forms.Label
        Dim Label12 As System.Windows.Forms.Label
        Dim Label14 As System.Windows.Forms.Label
        Dim Label15 As System.Windows.Forms.Label
        Dim Label16 As System.Windows.Forms.Label
        Dim Label17 As System.Windows.Forms.Label
        Dim HelpProvider1 As System.Windows.Forms.HelpProvider
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(absence_manual_input))
        Me.AbsenceBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Learning_activityDataSet = New learning_activity.learning_activityDataSet()
        Me.AbsenceTableAdapter = New learning_activity.learning_activityDataSetTableAdapters.absenceTableAdapter()
        Me.TableAdapterManager = New learning_activity.learning_activityDataSetTableAdapters.TableAdapterManager()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmb2 = New System.Windows.Forms.ComboBox()
        Me.cmb1 = New System.Windows.Forms.ComboBox()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.cmbSrok = New System.Windows.Forms.ComboBox()
        Me.cmbClassItemUp = New System.Windows.Forms.ComboBox()
        Me.lblIdUp = New System.Windows.Forms.Label()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.cmbClassIdup = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblSrokDel = New System.Windows.Forms.Label()
        Me.lblCNeizDel = New System.Windows.Forms.Label()
        Me.lblCIzvDel = New System.Windows.Forms.Label()
        Me.LblClassDel = New System.Windows.Forms.Label()
        Me.lblIdDel = New System.Windows.Forms.Label()
        Me.btnDEL = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmbNRR = New System.Windows.Forms.ComboBox()
        Me.cmbIRR = New System.Windows.Forms.ComboBox()
        Me.cmbNcR = New System.Windows.Forms.NumericUpDown()
        Me.cmbICR = New System.Windows.Forms.NumericUpDown()
        Me.cmbSR = New System.Windows.Forms.ComboBox()
        Me.cmbCR = New System.Windows.Forms.ComboBox()
        Me.lblidR = New System.Windows.Forms.Label()
        Me.btnR = New System.Windows.Forms.Button()
        Me.cmbCIdR = New System.Windows.Forms.ComboBox()
        КласLabel = New System.Windows.Forms.Label()
        Брой_извинени_отсъствияLabel = New System.Windows.Forms.Label()
        Брой_неизвинени_отсъствияLabel = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        Label7 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label8 = New System.Windows.Forms.Label()
        Label9 = New System.Windows.Forms.Label()
        Label10 = New System.Windows.Forms.Label()
        Label11 = New System.Windows.Forms.Label()
        Label12 = New System.Windows.Forms.Label()
        Label14 = New System.Windows.Forms.Label()
        Label15 = New System.Windows.Forms.Label()
        Label16 = New System.Windows.Forms.Label()
        Label17 = New System.Windows.Forms.Label()
        HelpProvider1 = New System.Windows.Forms.HelpProvider()
        CType(Me.AbsenceBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Learning_activityDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.cmbNcR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbICR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'КласLabel
        '
        КласLabel.AutoSize = True
        КласLabel.Location = New System.Drawing.Point(15, 56)
        КласLabel.Name = "КласLabel"
        КласLabel.Size = New System.Drawing.Size(35, 13)
        КласLabel.TabIndex = 21
        КласLabel.Text = "Клас:"
        '
        'Брой_извинени_отсъствияLabel
        '
        Брой_извинени_отсъствияLabel.AutoSize = True
        Брой_извинени_отсъствияLabel.Location = New System.Drawing.Point(15, 82)
        Брой_извинени_отсъствияLabel.Name = "Брой_извинени_отсъствияLabel"
        Брой_извинени_отсъствияLabel.Size = New System.Drawing.Size(142, 13)
        Брой_извинени_отсъствияLabel.TabIndex = 23
        Брой_извинени_отсъствияLabel.Text = "Брой извинени отсъствия:"
        '
        'Брой_неизвинени_отсъствияLabel
        '
        Брой_неизвинени_отсъствияLabel.AutoSize = True
        Брой_неизвинени_отсъствияLabel.Location = New System.Drawing.Point(15, 108)
        Брой_неизвинени_отсъствияLabel.Name = "Брой_неизвинени_отсъствияLabel"
        Брой_неизвинени_отсъствияLabel.Size = New System.Drawing.Size(154, 13)
        Брой_неизвинени_отсъствияLabel.TabIndex = 25
        Брой_неизвинени_отсъствияLabel.Text = "Брой неизвинени отсъствия:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(15, 131)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(35, 13)
        Label1.TabIndex = 25
        Label1.Text = "Срок:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(15, 30)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(29, 13)
        Label3.TabIndex = 19
        Label3.Text = "Код:"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(15, 56)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(35, 13)
        Label4.TabIndex = 21
        Label4.Text = "Клас:"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(15, 82)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(142, 13)
        Label5.TabIndex = 23
        Label5.Text = "Брой извинени отсъствия:"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(15, 131)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(35, 13)
        Label6.TabIndex = 25
        Label6.Text = "Срок:"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Location = New System.Drawing.Point(15, 108)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(154, 13)
        Label7.TabIndex = 25
        Label7.Text = "Брой неизвинени отсъствия:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(15, 30)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(29, 13)
        Label2.TabIndex = 29
        Label2.Text = "Код:"
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Label8.Location = New System.Drawing.Point(256, 80)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(12, 17)
        Label8.TabIndex = 29
        Label8.Text = "."
        Label8.Visible = False
        '
        'Label9
        '
        Label9.AutoSize = True
        Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Label9.Location = New System.Drawing.Point(256, 101)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(12, 17)
        Label9.TabIndex = 29
        Label9.Text = "."
        '
        'Label10
        '
        Label10.AutoSize = True
        Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Label10.Location = New System.Drawing.Point(256, 101)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(12, 17)
        Label10.TabIndex = 29
        Label10.Text = "."
        '
        'Label11
        '
        Label11.AutoSize = True
        Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Label11.Location = New System.Drawing.Point(256, 80)
        Label11.Name = "Label11"
        Label11.Size = New System.Drawing.Size(12, 17)
        Label11.TabIndex = 29
        Label11.Text = "."
        Label11.Visible = False
        '
        'Label12
        '
        Label12.AutoSize = True
        Label12.Location = New System.Drawing.Point(15, 30)
        Label12.Name = "Label12"
        Label12.Size = New System.Drawing.Size(29, 13)
        Label12.TabIndex = 29
        Label12.Text = "Код:"
        '
        'Label14
        '
        Label14.AutoSize = True
        Label14.Location = New System.Drawing.Point(15, 56)
        Label14.Name = "Label14"
        Label14.Size = New System.Drawing.Size(35, 13)
        Label14.TabIndex = 21
        Label14.Text = "Клас:"
        '
        'Label15
        '
        Label15.AutoSize = True
        Label15.Location = New System.Drawing.Point(15, 82)
        Label15.Name = "Label15"
        Label15.Size = New System.Drawing.Size(142, 13)
        Label15.TabIndex = 23
        Label15.Text = "Брой извинени отсъствия:"
        '
        'Label16
        '
        Label16.AutoSize = True
        Label16.Location = New System.Drawing.Point(15, 131)
        Label16.Name = "Label16"
        Label16.Size = New System.Drawing.Size(35, 13)
        Label16.TabIndex = 25
        Label16.Text = "Срок:"
        '
        'Label17
        '
        Label17.AutoSize = True
        Label17.Location = New System.Drawing.Point(15, 108)
        Label17.Name = "Label17"
        Label17.Size = New System.Drawing.Size(154, 13)
        Label17.TabIndex = 25
        Label17.Text = "Брой неизвинени отсъствия:"
        '
        'HelpProvider1
        '
        HelpProvider1.HelpNamespace = "helpHTML\HelpHTML.chm"
        HelpProvider1.Tag = "F1"
        '
        'AbsenceBindingSource
        '
        Me.AbsenceBindingSource.DataMember = "absence"
        Me.AbsenceBindingSource.DataSource = Me.Learning_activityDataSet
        '
        'Learning_activityDataSet
        '
        Me.Learning_activityDataSet.DataSetName = "learning_activityDataSet"
        Me.Learning_activityDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        Me.TableAdapterManager.purposeTableAdapter = Nothing
        Me.TableAdapterManager.subjectTableAdapter = Nothing
        Me.TableAdapterManager.teachersTableAdapter = Nothing
        Me.TableAdapterManager.teachingTableAdapter = Nothing
        Me.TableAdapterManager.typesTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = learning_activity.learning_activityDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column1, Me.Column3, Me.Column4, Me.Column5})
        Me.dgv1.Location = New System.Drawing.Point(163, 224)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(750, 220)
        Me.dgv1.TabIndex = 2
        '
        'Column2
        '
        Me.Column2.HeaderText = "Код"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "Клас"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 150
        '
        'Column3
        '
        Me.Column3.HeaderText = "Брой извинени отсъствия"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 150
        '
        'Column4
        '
        Me.Column4.HeaderText = "Брой неизвинени отсъствия"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 150
        '
        'Column5
        '
        Me.Column5.HeaderText = "Срок"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmb2)
        Me.GroupBox1.Controls.Add(Me.cmb1)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown2)
        Me.GroupBox1.Controls.Add(Label9)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox1.Controls.Add(Label8)
        Me.GroupBox1.Controls.Add(Label2)
        Me.GroupBox1.Controls.Add(Me.cmbSrok)
        Me.GroupBox1.Controls.Add(Me.cmbClassItemUp)
        Me.GroupBox1.Controls.Add(Me.lblIdUp)
        Me.GroupBox1.Controls.Add(КласLabel)
        Me.GroupBox1.Controls.Add(Me.btnUpload)
        Me.GroupBox1.Controls.Add(Брой_извинени_отсъствияLabel)
        Me.GroupBox1.Controls.Add(Label1)
        Me.GroupBox1.Controls.Add(Брой_неизвинени_отсъствияLabel)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(335, 206)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Добавяне на отсъсвия"
        '
        'cmb2
        '
        Me.cmb2.FormattingEnabled = True
        Me.cmb2.Items.AddRange(New Object() {"0", "33", "66"})
        Me.cmb2.Location = New System.Drawing.Point(269, 99)
        Me.cmb2.Name = "cmb2"
        Me.cmb2.Size = New System.Drawing.Size(61, 21)
        Me.cmb2.TabIndex = 31
        Me.cmb2.Text = "0"
        '
        'cmb1
        '
        Me.cmb1.Enabled = False
        Me.cmb1.FormattingEnabled = True
        Me.cmb1.Items.AddRange(New Object() {"0", "33", "66"})
        Me.cmb1.Location = New System.Drawing.Point(269, 78)
        Me.cmb1.Name = "cmb1"
        Me.cmb1.Size = New System.Drawing.Size(61, 21)
        Me.cmb1.TabIndex = 31
        Me.cmb1.Text = "0"
        Me.cmb1.Visible = False
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(183, 100)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(70, 20)
        Me.NumericUpDown2.TabIndex = 30
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(183, 77)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(146, 20)
        Me.NumericUpDown1.TabIndex = 30
        '
        'cmbSrok
        '
        Me.cmbSrok.FormattingEnabled = True
        Me.cmbSrok.Items.AddRange(New Object() {"Първи срок", "Годишни"})
        Me.cmbSrok.Location = New System.Drawing.Point(183, 128)
        Me.cmbSrok.Name = "cmbSrok"
        Me.cmbSrok.Size = New System.Drawing.Size(147, 21)
        Me.cmbSrok.TabIndex = 28
        Me.cmbSrok.Text = "Първи срок"
        '
        'cmbClassItemUp
        '
        Me.cmbClassItemUp.FormattingEnabled = True
        Me.cmbClassItemUp.Location = New System.Drawing.Point(183, 53)
        Me.cmbClassItemUp.Name = "cmbClassItemUp"
        Me.cmbClassItemUp.Size = New System.Drawing.Size(147, 21)
        Me.cmbClassItemUp.TabIndex = 27
        '
        'lblIdUp
        '
        Me.lblIdUp.Location = New System.Drawing.Point(180, 30)
        Me.lblIdUp.Name = "lblIdUp"
        Me.lblIdUp.Size = New System.Drawing.Size(124, 23)
        Me.lblIdUp.TabIndex = 26
        Me.lblIdUp.Text = "Label1"
        '
        'btnUpload
        '
        Me.btnUpload.Location = New System.Drawing.Point(183, 155)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(112, 44)
        Me.btnUpload.TabIndex = 6
        Me.btnUpload.Text = "Въведи отсъствия"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'cmbClassIdup
        '
        Me.cmbClassIdup.FormattingEnabled = True
        Me.cmbClassIdup.Location = New System.Drawing.Point(12, 224)
        Me.cmbClassIdup.Name = "cmbClassIdup"
        Me.cmbClassIdup.Size = New System.Drawing.Size(59, 21)
        Me.cmbClassIdup.TabIndex = 27
        Me.cmbClassIdup.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblSrokDel)
        Me.GroupBox2.Controls.Add(Me.lblCNeizDel)
        Me.GroupBox2.Controls.Add(Me.lblCIzvDel)
        Me.GroupBox2.Controls.Add(Me.LblClassDel)
        Me.GroupBox2.Controls.Add(Me.lblIdDel)
        Me.GroupBox2.Controls.Add(Label3)
        Me.GroupBox2.Controls.Add(Label4)
        Me.GroupBox2.Controls.Add(Me.btnDEL)
        Me.GroupBox2.Controls.Add(Label5)
        Me.GroupBox2.Controls.Add(Label6)
        Me.GroupBox2.Controls.Add(Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(353, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(322, 206)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Изтриване на отсъсвия"
        '
        'lblSrokDel
        '
        Me.lblSrokDel.Location = New System.Drawing.Point(180, 131)
        Me.lblSrokDel.Name = "lblSrokDel"
        Me.lblSrokDel.Size = New System.Drawing.Size(124, 23)
        Me.lblSrokDel.TabIndex = 26
        '
        'lblCNeizDel
        '
        Me.lblCNeizDel.Location = New System.Drawing.Point(180, 108)
        Me.lblCNeizDel.Name = "lblCNeizDel"
        Me.lblCNeizDel.Size = New System.Drawing.Size(124, 23)
        Me.lblCNeizDel.TabIndex = 26
        '
        'lblCIzvDel
        '
        Me.lblCIzvDel.Location = New System.Drawing.Point(180, 82)
        Me.lblCIzvDel.Name = "lblCIzvDel"
        Me.lblCIzvDel.Size = New System.Drawing.Size(124, 23)
        Me.lblCIzvDel.TabIndex = 26
        '
        'LblClassDel
        '
        Me.LblClassDel.Location = New System.Drawing.Point(180, 56)
        Me.LblClassDel.Name = "LblClassDel"
        Me.LblClassDel.Size = New System.Drawing.Size(124, 23)
        Me.LblClassDel.TabIndex = 26
        '
        'lblIdDel
        '
        Me.lblIdDel.Location = New System.Drawing.Point(180, 30)
        Me.lblIdDel.Name = "lblIdDel"
        Me.lblIdDel.Size = New System.Drawing.Size(124, 23)
        Me.lblIdDel.TabIndex = 26
        '
        'btnDEL
        '
        Me.btnDEL.Enabled = False
        Me.btnDEL.Location = New System.Drawing.Point(161, 155)
        Me.btnDEL.Name = "btnDEL"
        Me.btnDEL.Size = New System.Drawing.Size(112, 44)
        Me.btnDEL.TabIndex = 6
        Me.btnDEL.Text = "Изтрий отсъствия"
        Me.btnDEL.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmbNRR)
        Me.GroupBox3.Controls.Add(Me.cmbIRR)
        Me.GroupBox3.Controls.Add(Me.cmbNcR)
        Me.GroupBox3.Controls.Add(Label10)
        Me.GroupBox3.Controls.Add(Me.cmbICR)
        Me.GroupBox3.Controls.Add(Label11)
        Me.GroupBox3.Controls.Add(Label12)
        Me.GroupBox3.Controls.Add(Me.cmbSR)
        Me.GroupBox3.Controls.Add(Me.cmbCR)
        Me.GroupBox3.Controls.Add(Me.lblidR)
        Me.GroupBox3.Controls.Add(Label14)
        Me.GroupBox3.Controls.Add(Me.btnR)
        Me.GroupBox3.Controls.Add(Label15)
        Me.GroupBox3.Controls.Add(Label16)
        Me.GroupBox3.Controls.Add(Label17)
        Me.GroupBox3.Location = New System.Drawing.Point(681, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(335, 206)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Редактиране на отсъсвия"
        '
        'cmbNRR
        '
        Me.cmbNRR.FormattingEnabled = True
        Me.cmbNRR.Items.AddRange(New Object() {"0", "33", "66"})
        Me.cmbNRR.Location = New System.Drawing.Point(269, 99)
        Me.cmbNRR.Name = "cmbNRR"
        Me.cmbNRR.Size = New System.Drawing.Size(61, 21)
        Me.cmbNRR.TabIndex = 31
        Me.cmbNRR.Text = "0"
        '
        'cmbIRR
        '
        Me.cmbIRR.FormattingEnabled = True
        Me.cmbIRR.Items.AddRange(New Object() {"0", "33", "66"})
        Me.cmbIRR.Location = New System.Drawing.Point(269, 78)
        Me.cmbIRR.Name = "cmbIRR"
        Me.cmbIRR.Size = New System.Drawing.Size(61, 21)
        Me.cmbIRR.TabIndex = 31
        Me.cmbIRR.Text = "0"
        Me.cmbIRR.Visible = False
        '
        'cmbNcR
        '
        Me.cmbNcR.Location = New System.Drawing.Point(183, 100)
        Me.cmbNcR.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.cmbNcR.Name = "cmbNcR"
        Me.cmbNcR.Size = New System.Drawing.Size(70, 20)
        Me.cmbNcR.TabIndex = 30
        '
        'cmbICR
        '
        Me.cmbICR.Location = New System.Drawing.Point(183, 77)
        Me.cmbICR.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.cmbICR.Name = "cmbICR"
        Me.cmbICR.Size = New System.Drawing.Size(146, 20)
        Me.cmbICR.TabIndex = 30
        '
        'cmbSR
        '
        Me.cmbSR.FormattingEnabled = True
        Me.cmbSR.Items.AddRange(New Object() {"Първи срок", "Годишни"})
        Me.cmbSR.Location = New System.Drawing.Point(183, 128)
        Me.cmbSR.Name = "cmbSR"
        Me.cmbSR.Size = New System.Drawing.Size(147, 21)
        Me.cmbSR.TabIndex = 28
        Me.cmbSR.Text = "Първи срок"
        '
        'cmbCR
        '
        Me.cmbCR.FormattingEnabled = True
        Me.cmbCR.Location = New System.Drawing.Point(183, 53)
        Me.cmbCR.Name = "cmbCR"
        Me.cmbCR.Size = New System.Drawing.Size(147, 21)
        Me.cmbCR.TabIndex = 27
        '
        'lblidR
        '
        Me.lblidR.Location = New System.Drawing.Point(180, 30)
        Me.lblidR.Name = "lblidR"
        Me.lblidR.Size = New System.Drawing.Size(124, 23)
        Me.lblidR.TabIndex = 26
        Me.lblidR.Text = "Label1"
        '
        'btnR
        '
        Me.btnR.Location = New System.Drawing.Point(160, 155)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(135, 44)
        Me.btnR.TabIndex = 6
        Me.btnR.Text = "Редактирай отсъствия"
        Me.btnR.UseVisualStyleBackColor = True
        '
        'cmbCIdR
        '
        Me.cmbCIdR.FormattingEnabled = True
        Me.cmbCIdR.Location = New System.Drawing.Point(952, 224)
        Me.cmbCIdR.Name = "cmbCIdR"
        Me.cmbCIdR.Size = New System.Drawing.Size(59, 21)
        Me.cmbCIdR.TabIndex = 27
        Me.cmbCIdR.Visible = False
        '
        'absence_manual_input
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1025, 448)
        Me.Controls.Add(Me.cmbCIdR)
        Me.Controls.Add(Me.cmbClassIdup)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgv1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        HelpProvider1.SetHelpKeyword(Me, "Отсъствия")
        HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        HelpProvider1.SetHelpString(Me, "Отсъствия")
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "absence_manual_input"
        HelpProvider1.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Въвеждане, изтриване и редактиране на отсъствия"
        CType(Me.AbsenceBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Learning_activityDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.cmbNcR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbICR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Learning_activityDataSet As learning_activity.learning_activityDataSet
    Friend WithEvents AbsenceBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AbsenceTableAdapter As learning_activity.learning_activityDataSetTableAdapters.absenceTableAdapter
    Friend WithEvents TableAdapterManager As learning_activity.learning_activityDataSetTableAdapters.TableAdapterManager
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbClassItemUp As System.Windows.Forms.ComboBox
    Friend WithEvents lblIdUp As System.Windows.Forms.Label
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents cmbClassIdup As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSrok As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblSrokDel As System.Windows.Forms.Label
    Friend WithEvents lblCNeizDel As System.Windows.Forms.Label
    Friend WithEvents lblCIzvDel As System.Windows.Forms.Label
    Friend WithEvents LblClassDel As System.Windows.Forms.Label
    Friend WithEvents lblIdDel As System.Windows.Forms.Label
    Friend WithEvents btnDEL As System.Windows.Forms.Button
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmb1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb2 As System.Windows.Forms.ComboBox
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbNRR As System.Windows.Forms.ComboBox
    Friend WithEvents cmbIRR As System.Windows.Forms.ComboBox
    Friend WithEvents cmbNcR As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmbICR As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmbSR As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCR As System.Windows.Forms.ComboBox
    Friend WithEvents lblidR As System.Windows.Forms.Label
    Friend WithEvents btnR As System.Windows.Forms.Button
    Friend WithEvents cmbCIdR As System.Windows.Forms.ComboBox
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
