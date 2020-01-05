'използване на MySQL Data
Imports MySql.Data.MySqlClient
Public Class reference_GPA_Clasess
    'деклариране на глобални променливи
    Dim cnn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim years, title1, title2, flagbtn As String
    Dim a, b, RRowsCount As Integer
    Private Sub reference_GPA_Clasess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        flagbtn = 0
        title1 = "Справка"
        title2 = "Среден успех по паралелки за година "

        Dim brRows, nomer, flag, britem As Integer
        brRows = 0
        Call Module1.hosts(cnn)
        'Отваряне на връската със SURVER
        cnn.Open()
        cmd = New MySqlCommand("Select* from  purpose order by id", cnn)
        cmd.ExecuteNonQuery()
        Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
        Dim data As DataTable = New DataTable
        adaptre.Fill(data)
        'Проверка дли в таблица purpose има записи
        If data.Rows.Count > 0 Then
            Dim yearM(data.Rows.Count), yearM2(data.Rows.Count) As Integer
            Dim brm As Integer
            brm = 1
            For i As Integer = 0 To data.Rows.Count
                yearM(i) = 0
                yearM2(i) = 0
            Next
            'минаване през всчики редове на таблица purpose
            Do While brRows < data.Rows.Count

                'Селактиране на номера на класа на ред
                nomer = data.Rows(brRows).Item("class")
                cmd = New MySqlCommand("Select* from  classes where id='" & nomer & "' order by school_year desc;", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt As DataTable = New DataTable
                adaptre1.Fill(dt)
                'задаване на учебна година
                years = dt.Rows(0).Item("school_year")

                flag = 0
                britem = 0
                'проверка дали учебната година е вписана в cmbyear 
                Dim years2 As Integer
                years2 = years

                Do While britem <= brm
                    If years = yearM(britem) Then
                        flag = 1
                    End If
                    britem = britem + 1
                Loop

                If flag = 0 Then
                    yearM(brm) = years2
                    brm = brm + 1
                End If
                brRows = brRows + 1
            Loop
           
            For j As Integer = 1 To brm - 1
                cmbyear.Items.Add(yearM(j) & "/" & yearM(j) Mod 100 + 1)
                cmbyearid.Items.Add(yearM(j))
            Next
            cmbyearid.Text = cmbyearid.Items(0)
            cmbyear.Text = cmbyear.Items(0)

            brRows = 0
            'ако има записи
            Dim IntSubject, subid, subflag, subjite As Integer
            Dim strSubject As String
            'минаване през всчики редове на таблица purpose
            Do While brRows < data.Rows.Count
                'Селактиране на номера на класа на ред
                nomer = data.Rows(brRows).Item("class")
                cmd = New MySqlCommand("Select* from  classes where id='" & nomer & "' order by school_year desc;", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt As DataTable = New DataTable
                adaptre1.Fill(dt)
                'задаване на учебна година
                years = dt.Rows(0).Item("school_year")

                'проверк дали тази учебна годиня, която е на реда, е същата която е като текс на cmbyear 
                If years = cmbyearid.Text Then
                    'ако е се проверява предмета дали е въведен в cmbSubject и вида оценка в cmbtype
                    IntSubject = data.Rows(brRows).Item("subject")

                    cmd = New MySqlCommand("Select* from  subject where id='" & IntSubject & "'", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre0 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt30 As DataTable = New DataTable
                    adaptre0.Fill(dt30)

                    strSubject = dt30.Rows(0).Item("name_subject")
                    subid = dt30.Rows(0).Item("id")
                    subflag = 0
                    subjite = 1
                    Do While subjite <> cmbSubject.Items.Count
                        If cmbSubject.Items(subjite) = strSubject Then
                            subflag = 1
                        End If
                        subjite = subjite + 1

                    Loop

                    If subflag = 0 Then
                        cmbSubject.Items.Add(strSubject)
                        cmbSubjectId.Items.Add(subid)
                    End If

                    nomer = data.Rows(brRows).Item("type")
                    cmd = New MySqlCommand("Select* from  types where id='" & nomer & "'", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt2 As DataTable = New DataTable
                    adaptre2.Fill(dt2)
                    Dim type As String
                    type = dt2.Rows(0).Item("name_type")
                    flag = 0
                    britem = 0

                    Do While britem < cmbtype.Items.Count
                        If type = cmbtype.Items(britem) Then
                            flag = 1
                        End If
                        britem = britem + 1
                    Loop
                    If flag = 0 Then
                        cmbtype.Items.Add(type)
                        cmbTypeid.Items.Add(dt2.Rows(0).Item("id"))
                    End If

                    If type <> "" Then
                        cmbtype.Text = cmbtype.Items(0)
                    End If
                End If
                brRows = brRows + 1
            Loop

        End If

        'проверка дали има записи в таблица purpose
        cmd = New MySqlCommand("Select* from  purpose", cnn)
        cmd.ExecuteNonQuery()
        Dim adaptre30 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
        Dim data30 As DataTable = New DataTable
        adaptre30.Fill(data30)
        Dim id As Integer

        If data30.Rows.Count > 0 Then
            Dim classes, classp, subject, type, count_2, count_3, count_4, count_5, count_6 As String
            Dim nomerdgv1, year, classn, brrows2 As Integer
            Dim yearsting As String
            brrows2 = 0
            'записване на сойности в dgv1
            Do While brrows2 < data30.Rows.Count

                id = data30.Rows(brrows2).Item("id")
                ' задаване на клас
                nomerdgv1 = data30.Rows(brrows2).Item("class")

                cmd = New MySqlCommand("Select* from  classes where id='" & nomerdgv1 & "' order by id", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt As DataTable = New DataTable
                adaptre1.Fill(dt)
                year = dt.Rows(0).Item("school_year")
                classn = dt.Rows(0).Item("grade")
                classp = dt.Rows(0).Item("class")
                classes = year & "/" & year Mod 100 + 1 & " " & classn & " " & classp
                yearsting = year & "/" & year Mod 100 + 1

                If yearsting = cmbyear.Text Then
                    ' задаване на subject
                    nomerdgv1 = data30.Rows(brrows2).Item("subject")
                    cmd = New MySqlCommand("Select* from  subject where id='" & nomerdgv1 & "'", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre5 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt3 As DataTable = New DataTable
                    adaptre5.Fill(dt3)
                    subject = dt3.Rows(0).Item("name_subject")
                    'задаване на types
                    nomerdgv1 = data30.Rows(brrows2).Item("type")
                    cmd = New MySqlCommand("Select* from  types where id='" & nomerdgv1 & "'", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt2 As DataTable = New DataTable
                    adaptre2.Fill(dt2)
                    type = dt2.Rows(0).Item("name_type")

                    'задаване на бройя на двойки, тройки, четворки, петици, шестици

                    count_2 = data30.Rows(brrows2).Item("count_2")
                    count_3 = data30.Rows(brrows2).Item("count_3")
                    count_4 = data30.Rows(brrows2).Item("count_4")
                    count_5 = data30.Rows(brrows2).Item("count_5")
                    count_6 = data30.Rows(brrows2).Item("count_6")

                    'писане в dgv1
                    dgv1.Rows.Add(id, classes, subject, type, count_2, count_3, count_4, count_5, count_6)

                End If

                brrows2 = brrows2 + 1
            Loop
        End If
        cnn.Close()
    End Sub
    Private Sub cmbyear_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbyear.Leave, cmbyearid.Leave, cmbyear.DropDownClosed
        If (cmbyear.SelectedIndex = -1) Then
            'Проверка за въвеждане на символи от клавиатурата
            cmbyear.Text = cmbyear.Items(0)
            cmbyear.Focus()
        Else
            'изтриване на старите сойности в cmbtype
            Do While cmbtype.Items.Count > 1
                cmbtype.Items.Remove(cmbtype.Items(1))
                cmbTypeid.Items.Remove(cmbTypeid.Items(1))
            Loop

            Do While cmbSubject.Items.Count > 1
                cmbSubject.Items.Remove(cmbSubject.Items(1))
                cmbSubjectId.Items.Remove(cmbSubjectId.Items(1))
            Loop
            cmbyearid.Text = cmbyearid.Items(cmbyear.SelectedIndex)
            'Променяне айтамите в Видове оценки
            Dim brRows, nomer, flag, britem As Integer
            brRows = 0
            'Селектирана на таблица purporse от базата
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            cmd = New MySqlCommand("Select* from  purpose order by id", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)

            If data.Rows.Count > 0 Then
                'aко има редове те се обхождата един поп един
                Dim IntSubject, subid, subflag, subjite As Integer
                Dim strSubject, types As String
                types = ""
                'обхождане на редовете на таблицата
                Do While brRows < data.Rows.Count
                    'запазване на номера на класа и търсенето му в таблица clasеss
                    nomer = data.Rows(brRows).Item("class")
                    cmd = New MySqlCommand("Select* from  classes where id='" & nomer & "'", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt As DataTable = New DataTable
                    adaptre1.Fill(dt)
                    'Взимане на годината записана в таблицата clasess
                    years = dt.Rows(0).Item("school_year")
                    flag = 0
                    britem = 0
                    years = years & "/" & years Mod 100 + 1
                    If years = cmbyear.Text Then
                        'aко годината от таблицта е същатакато избраната година в cmbclasess се записват нови стойности за Предмети вид оценка
                        IntSubject = data.Rows(brRows).Item("subject")

                        cmd = New MySqlCommand("Select* from  subject where id='" & IntSubject & "'", cnn)
                        cmd.ExecuteNonQuery()
                        Dim adaptre0 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                        Dim dt30 As DataTable = New DataTable
                        adaptre0.Fill(dt30)

                        strSubject = dt30.Rows(0).Item("name_subject")
                        subid = dt30.Rows(0).Item("id")
                        subflag = 0
                        subjite = 1
                        Do While subjite <> cmbSubject.Items.Count
                            If cmbSubject.Items(subjite) = strSubject Then
                                subflag = 1
                            End If
                            subjite = subjite + 1

                        Loop


                        If subflag = 0 Then
                            cmbSubject.Items.Add(strSubject)
                            cmbSubjectId.Items.Add(subid)
                        End If


                        nomer = data.Rows(brRows).Item("type")
                        cmd = New MySqlCommand("Select* from  types where id='" & nomer & "'", cnn)
                        cmd.ExecuteNonQuery()
                        Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                        Dim dt2 As DataTable = New DataTable
                        adaptre2.Fill(dt2)

                        types = dt2.Rows(0).Item("name_type")
                        flag = 0
                        britem = 0

                        Do While britem < cmbtype.Items.Count
                            If types = cmbtype.Items(britem) Then
                                flag = 1
                            End If
                            britem = britem + 1
                        Loop
                        If flag = 0 Then
                            cmbtype.Items.Add(types)
                            cmbTypeid.Items.Add(dt2.Rows(0).Item("id"))
                        End If


                    End If
                    brRows = brRows + 1
                Loop
                cmbtype.Text = cmbtype.Items(0)
                cmbTypeid.Text = cmbTypeid.Items(0)
                cmbSubject.Text = cmbSubject.Items(0)
                cmbSubjectId.Text = cmbSubjectId.Items(0)

                'изтриване на старите сойности в dgv1
                Do While dgv1.RowCount > 0
                    dgv1.Rows.Remove(dgv1.Rows(0))
                Loop
                'записване на сойности в dgv1
                cmd = New MySqlCommand("Select* from  purpose", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre30 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim data30 As DataTable = New DataTable
                adaptre30.Fill(data30)
                Dim id As Integer

                If data30.Rows.Count > 0 Then
                    Dim classes, classp, subject, type, count_2, count_3, count_4, count_5, count_6 As String
                    Dim nomerdgv1, year, classn, brrows2 As Integer
                    Dim yearsting As String
                    brrows2 = 0

                    Do While brrows2 < data30.Rows.Count

                        id = data30.Rows(brrows2).Item("id")
                        ' задаване на клас
                        nomerdgv1 = data30.Rows(brrows2).Item("class")
                        cmd = New MySqlCommand("Select* from  classes where id='" & nomerdgv1 & "' order by id", cnn)
                        cmd.ExecuteNonQuery()
                        Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                        Dim dt As DataTable = New DataTable
                        adaptre1.Fill(dt)
                        year = dt.Rows(0).Item("school_year")
                        classn = dt.Rows(0).Item("grade")
                        classp = dt.Rows(0).Item("class")
                        classes = year & "/" & year Mod 100 + 1 & " " & classn & " " & classp
                        yearsting = year & "/" & year Mod 100 + 1

                        If yearsting = cmbyear.Text Then
                            ' задаване на subject
                            nomerdgv1 = data30.Rows(brrows2).Item("subject")

                            cmd = New MySqlCommand("Select* from  subject where id='" & nomerdgv1 & "'", cnn)
                            cmd.ExecuteNonQuery()
                            Dim adaptre5 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                            Dim dt3 As DataTable = New DataTable
                            adaptre5.Fill(dt3)
                            subject = dt3.Rows(0).Item("name_subject")

                            'задаване на types

                            nomerdgv1 = data30.Rows(brrows2).Item("type")
                            cmd = New MySqlCommand("Select* from  types where id='" & nomerdgv1 & "'", cnn)
                            cmd.ExecuteNonQuery()
                            Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                            Dim dt2 As DataTable = New DataTable
                            adaptre2.Fill(dt2)
                            type = dt2.Rows(0).Item("name_type")

                            'задаване на бройя на двойки, тройки, четворки, петици, шестици

                            count_2 = data30.Rows(brrows2).Item("count_2")
                            count_3 = data30.Rows(brrows2).Item("count_3")
                            count_4 = data30.Rows(brrows2).Item("count_4")
                            count_5 = data30.Rows(brrows2).Item("count_5")
                            count_6 = data30.Rows(brrows2).Item("count_6")

                            'писане в dgv1
                            dgv1.Rows.Add(id, classes, subject, type, count_2, count_3, count_4, count_5, count_6)

                        End If

                        brrows2 = brrows2 + 1
                    Loop
                End If
                cnn.Close()
            End If
        End If

    End Sub
    Private Sub reference_GPA_Clasess_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'изтриване на старите сойности в dgv1
        Do While dgv1.RowCount > 0
            dgv1.Rows.Remove(dgv1.Rows(0))
        Loop
        Me.Height = 371
        'Проверка дали chart1 е празно и  изтриване настъойностите му
        If flagbtn = 1 Then

            Do While Chart1.Series.Count > 0
                Chart1.Series.Remove(Chart1.Series.Item(0))
                'Chart1.Legends.Remove(Chart1.Legends.Item(0))
            Loop
            Chart1.Titles.Remove(Chart1.Titles.Item(0))
            Chart1.Titles.Remove(Chart1.Titles.Item(0))

            title2 = "Среден успех на класовете за "
        End If
        Do While cmbyear.Items.Count > 0
            cmbyearid.Items.Remove(cmbyearid.Items(0))
            cmbyear.Items.Remove(cmbyear.Items(0))
        Loop

        Do While cmbtype.Items.Count > 1
            cmbtype.Items.Remove(cmbtype.Items(1))
            cmbTypeid.Items.Remove(cmbTypeid.Items(1))
        Loop

        Do While cmbSubject.Items.Count > 1
            cmbSubject.Items.Remove(cmbSubject.Items(1))
            cmbSubjectId.Items.Remove(cmbSubjectId.Items(1))
        Loop
        prb1.Value = 0
    End Sub
    Private Sub cmbtype_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtype.Leave, cmbtype.DropDownClosed
        Dim flag1 As Integer = 0

        If (cmbtype.SelectedIndex = -1) Then
            'Проверка за въвеждане на символи от клавиатурата
            cmbtype.Text = cmbtype.Items(0)
            cmbtype.Focus()
            flag1 = 1
        Else

            'изтриване на старите сойности в dgv1
            Do While dgv1.RowCount > 0
                dgv1.Rows.Remove(dgv1.Rows(0))
            Loop
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            cmbTypeid.Text = cmbTypeid.Items(cmbtype.SelectedIndex)
            Dim idtype, subjid As Integer
            idtype = cmbTypeid.Text
            subjid = cmbSubjectId.Text
            'задаване стойности в dgv1
            If idtype = -1 Then
                If subjid = -1 Then
                    cmd = New MySqlCommand("Select* from  purpose", cnn)
                Else
                    cmd = New MySqlCommand("Select* from  purpose  where subject='" & subjid & "'", cnn)
                End If
            Else
                If subjid = -1 Then
                    cmd = New MySqlCommand("Select* from  purpose  where type='" & idtype & "'", cnn)
                Else
                    cmd = New MySqlCommand("Select* from  purpose  where type='" & idtype & "'and subject='" & subjid & "'", cnn)
                End If
            End If


            cmd.ExecuteNonQuery()
            Dim adaptre30 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data30 As DataTable = New DataTable
            adaptre30.Fill(data30)
            Dim id As Integer
            'изтриване на старите сойности в dgv1
            If data30.Rows.Count > 0 Then
                Dim classes, classp, subject, type, count_2, count_3, count_4, count_5, count_6 As String
                Dim nomerdgv1, year, classn, brrows2 As Integer
                Dim yearsting As String
                brrows2 = 0

                Do While brrows2 < data30.Rows.Count

                    id = data30.Rows(brrows2).Item("id")
                    ' задаване на клас
                    nomerdgv1 = data30.Rows(brrows2).Item("class")

                    cmd = New MySqlCommand("Select* from  classes where id='" & nomerdgv1 & "' order by id", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt As DataTable = New DataTable
                    adaptre1.Fill(dt)

                    year = dt.Rows(0).Item("school_year")
                    classn = dt.Rows(0).Item("grade")
                    classp = dt.Rows(0).Item("class")
                    classes = year & "/" & year Mod 100 + 1 & " " & classn & " " & classp
                    yearsting = year & "/" & year Mod 100 + 1

                    If yearsting = cmbyear.Text Then
                        ' задаване на subject
                        nomerdgv1 = data30.Rows(brrows2).Item("subject")
                        cmd = New MySqlCommand("Select* from  subject where id='" & nomerdgv1 & "'", cnn)
                        cmd.ExecuteNonQuery()
                        Dim adaptre5 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                        Dim dt3 As DataTable = New DataTable
                        adaptre5.Fill(dt3)
                        subject = dt3.Rows(0).Item("name_subject")

                        'задаване на types
                        nomerdgv1 = data30.Rows(brrows2).Item("type")

                        cmd = New MySqlCommand("Select* from  types where id='" & nomerdgv1 & "'", cnn)
                        cmd.ExecuteNonQuery()
                        Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                        Dim dt2 As DataTable = New DataTable
                        adaptre2.Fill(dt2)
                        type = dt2.Rows(0).Item("name_type")

                        'задаване на бройя на двойки, тройки, четворки, петици, шестици
                        count_2 = data30.Rows(brrows2).Item("count_2")
                        count_3 = data30.Rows(brrows2).Item("count_3")
                        count_4 = data30.Rows(brrows2).Item("count_4")
                        count_5 = data30.Rows(brrows2).Item("count_5")
                        count_6 = data30.Rows(brrows2).Item("count_6")

                        'писане в dgv1
                        dgv1.Rows.Add(id, classes, subject, type, count_2, count_3, count_4, count_5, count_6)

                    End If

                    brrows2 = brrows2 + 1
                Loop
            End If
            cnn.Close()
        End If
    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
    Private Sub cmdmaxmin(ByRef r As MySqlDataReader)
        Dim coms As String
        coms = ""
        'задаванена на команда оттип String в променлива coms в зависимост от избрания начин на сортиране
        If cmbPodredba.Text = cmbPodredba.Items(0) Then
            Call minmax(coms)
        Else
            Call maxmin(coms)
        End If
        cmd = New MySqlCommand(coms, cnn)
        cmd.ExecuteNonQuery()
        Dim adaptre0 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
        Dim dt0 As DataTable = New DataTable
        adaptre0.Fill(dt0)
        'progressBar Стойностите му се актоализират
        prb1.Maximum = dt0.Rows.Count
        prb1.Value = 0
        'връщане на dataReader, който е със сойности от изпълнената команда 
        r = cmd.ExecuteReader
        RRowsCount = dt0.Rows.Count
    End Sub
    Private Sub minmax(ByRef r As String)
        Dim type, subject As Integer
        type = cmbTypeid.Text
        subject = cmbSubjectId.Text
        'В зависимуст от избраните параметри се връща низ със комндата
        If type = -1 Then
            If subject = -1 Then
                r = "SELECT classes.grade, classes.class, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                              & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                              & " ON classes.id=purpose.class Where school_year='" & cmbyearid.Text & "' Group by  purpose.class order by sreden_uspeh;"
            Else
                r = "SELECT classes.grade, classes.class, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                              & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                              & " ON classes.id=purpose.class Where school_year='" & cmbyearid.Text & "'and purpose.subject='" & subject _
                                              & "' Group by  purpose.class order by sreden_uspeh;"
            End If
        Else
            If subject = -1 Then
                r = "SELECT classes.grade, classes.class, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                              & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                              & " ON classes.id=purpose.class Where school_year='" & cmbyearid.Text & "'and purpose.type='" & type _
                                              & "' Group by  purpose.class order by sreden_uspeh;"
            Else
                r = "SELECT classes.grade, classes.class, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                              & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                              & " ON classes.id=purpose.class Where school_year='" & cmbyearid.Text & "'and purpose.type='" & type _
                                             & "'and purpose.subject='" & subject & "' Group by  purpose.class order by sreden_uspeh;"
            End If
        End If
    End Sub
    Private Sub maxmin(ByRef r As String)
        Dim type, subject As Integer
        type = cmbTypeid.Text
        subject = cmbSubjectId.Text
        'В зависимуст от избраните параметри се връща низ със комндата
        If type = -1 Then
            If subject = -1 Then
                r = "SELECT classes.grade, classes.class, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                              & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                              & " ON classes.id=purpose.class Where school_year='" & cmbyearid.Text & "' Group by  purpose.class order by sreden_uspeh desc;"
            Else
                r = "SELECT classes.grade, classes.class, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                              & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                              & " ON classes.id=purpose.class Where school_year='" & cmbyearid.Text & "'and purpose.subject='" & subject & "' Group by  purpose.class order by sreden_uspeh desc;"
            End If
        Else
            If subject = -1 Then
                r = "SELECT classes.grade, classes.class, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                              & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                              & " ON classes.id=purpose.class Where school_year='" & cmbyearid.Text & "'and purpose.type='" & type & "' Group by  purpose.class order by sreden_uspeh desc;"
            Else
                r = "SELECT classes.grade, classes.class, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                              & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                              & " ON classes.id=purpose.class Where school_year='" & cmbyearid.Text & "'and purpose.type='" & type _
                                             & "'and purpose.subject='" & subject & "' Group by  purpose.class order by sreden_uspeh desc;"
            End If
        End If

    End Sub
    Private Sub btnchart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnchart.Click
        If cmbyear.Text <> "" Then
            'проверка за стойностите в диаграмата и тяхното изтриване
            If flagbtn = 1 Then
                Chart1.Series.Clear()
                Chart1.Titles.Clear()
                title2 = "Среден успех по паралелки за година: "
            End If

            title2 = title2 & cmbyear.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
            Chart1.Titles.Add(title1)
            Chart1.Titles.Add(title2)


            Dim r As MySqlDataReader
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            'викане на функция cmdmaxmin, която връща резултат datareader и проверка дали редовете в негя саповече от 0
            cmdmaxmin(r)
            If RRowsCount > 0 Then
                Dim classes, class2, class1, otd As String
                Dim grade As Integer
                Dim max As Double
                otd = ""
                'обхойдане на редовете един по един и добавяне на изчислените стойности в диаграмата
                Dim row As Integer = 0
                Chart1.Series.Clear()
                Chart1.Series.Add(0)
                Chart1.ChartAreas.Item(0).AxisX.CustomLabels.Clear()
                Dim sum, count As Double
                Do While r.Read
                    grade = r.GetString("grade")
                    classes = r.GetString("class")
                    max = r.GetString("sreden_uspeh")

                    prb1.Value = prb1.Value + 1
                    max = Format(Math.Round(max, 2), "0.00")
                    ' оценка с думи
                    If max < 3 Then
                        otd = " - Слаб"
                    ElseIf max >= 3 And max < 3.5 Then
                        otd = " - Среден"
                    ElseIf max >= 3.5 And max < 4.5 Then
                        otd = " - Добър"
                    ElseIf max >= 4.5 And max < 5.5 Then
                        otd = " - Много добър"
                    ElseIf max >= 5.5 And max < 6 Then
                        otd = " - Отличен"
                    End If
                    sum = sum + max
                    count = count + 1
                    class2 = grade & " " & classes & otd
                    class1 = grade & " " & classes
                    Chart1.Series(0).Points.AddXY(row, max)
                    Chart1.ChartAreas.Item(0).AxisX.CustomLabels.Add(row - 0.5, row + 0.5, class2)
                    Chart1.Series(0).Points(row).Label = Format(Math.Round(max, 2), "0.00")
                    row = row + 1
                Loop
                sum = Format(Math.Round(sum / count, 2), "0.00")
                Chart1.Series(0).Points.AddXY(row, sum)
                Chart1.ChartAreas.Item(0).AxisX.CustomLabels.Add(row - 0.5, row + 0.5, "Средно")
                Chart1.Series(0).Points(row).Label = Format(Math.Round(sum, 2), "0.00")
                flagbtn = 1
                cnn.Close()
                'оголемяване на формата

                Chart1.Visible = True
                Me.Height = 750
            End If
        Else
            MsgBox("Трябва да се върнете и да веведете оценки ! ! !", , "Справка")
        End If
    End Sub
    Sub cellborder(ByVal rng As Microsoft.Office.Interop.Excel.Range)
        With rng.Borders
            .LineStyle = Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalUp
            .Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin
        End With
    End Sub
    Private Sub btnExselNewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExselNewFile.Click
        If cmbyear.Text <> "" Then
            title2 = "Среден успех по паралелки за година: "
            title2 = title2 & cmbyear.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
            Dim r As MySqlDataReader
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try


            Dim rasEx As String
            rasEx = ""
            'викане на функция RazExcel в койято са записани разширенията на Excel
            Call Module1.RazExcel(rasEx)
            SaveFileDialog2.Filter = rasEx
            If SaveFileDialog2.ShowDialog = DialogResult.OK Then
                cnn.Open()
                Dim xlapp As Microsoft.Office.Interop.Excel.Application
                Dim xlbook As Microsoft.Office.Interop.Excel.Workbook
                Dim xlsheet As Microsoft.Office.Interop.Excel.Worksheet
                Dim misvalue As Object = System.Reflection.Missing.Value
                Dim xldi As Microsoft.Office.Interop.Excel.Chart
                xlapp = New Microsoft.Office.Interop.Excel.Application
                xlbook = xlapp.Workbooks.Add(misvalue)
                xlsheet = CType(xlbook.Sheets(1), Microsoft.Office.Interop.Excel.Worksheet)
                xlsheet.Name = "Среден успех по паралелки"
                xldi = New Microsoft.Office.Interop.Excel.Chart

                Const xlCenter = -4108
                'задаване на текст в клетки и форматиране на редове и колони
                xlsheet.Range(xlsheet.Cells(1, 1), xlsheet.Cells(1, 2)).Merge()
                xlsheet.Range(xlsheet.Cells(1, 1), xlsheet.Cells(1, 2)).HorizontalAlignment = xlCenter
                xlsheet.Cells(1, 1) = title1
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 2)).Merge()
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 2)).HorizontalAlignment = xlCenter
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 2)).WrapText = True
                xlsheet.Cells(2, 1) = title2
                xlsheet.Cells(3, 1) = "Клас и оценка с думи"
                xlsheet.Cells(3, 2) = "Средно аритметично"
                xlsheet.Range(xlsheet.Cells(3, 1), xlsheet.Cells(3, 2)).HorizontalAlignment = xlCenter
                xlsheet.Range("A3").EntireColumn.ColumnWidth = 20
                xlsheet.Range("B3").EntireColumn.ColumnWidth = 30
                xlsheet.Range("A2").EntireRow.RowHeight = 45
                Dim pat, bi, ci As String
                pat = SaveFileDialog2.FileName
                bi = "B" & 4
                ci = "B" & 4
                Chart1.Visible = True
                Dim chartPage As Microsoft.Office.Interop.Excel.Chart
                Dim xlCharts As Microsoft.Office.Interop.Excel.ChartObjects
                Dim myChart As Microsoft.Office.Interop.Excel.ChartObject
                Dim chartRange As Microsoft.Office.Interop.Excel.Range

                xlCharts = xlsheet.ChartObjects
                myChart = xlCharts.Add(300, 50, 600, 250)
                chartPage = myChart.Chart

                chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlColumnClustered
                'извикване на функция cmdmaxmi, която връща datareader и проверка тя дали е пълна 
                cmdmaxmin(r)
                If RRowsCount > 0 Then
                    Dim classes, class2, otd As String
                    Dim grade, br As Integer
                    Dim max As Double
                    otd = ""
                    br = 4
                    'четене на datareader, изчисляване на данните и тяхното записване в excel
                    Dim sum, count As Double
                    Do While r.Read
                        grade = r.GetString("grade")
                        classes = r.GetString("class")
                        max = r.GetString("sreden_uspeh")
                        prb1.Value = prb1.Value + 1
                        max = Format(Math.Round(max, 2), "0.00")
                        ' оценка с думи
                        If max < 3 Then
                            otd = " - Слаб"
                        ElseIf max >= 3 And max < 3.5 Then
                            otd = " - Среден"
                        ElseIf max >= 3.5 And max < 4.5 Then
                            otd = " - Добър"
                        ElseIf max >= 4.5 And max < 5.5 Then
                            otd = " - Много добър"
                        ElseIf max >= 5.5 And max < 6 Then
                            otd = " - Отличен"
                        End If
                        sum = sum + max
                        count = count + 1
                        class2 = grade & " " & classes & otd
                        xlsheet.Cells(br, 1) = class2
                        xlsheet.Cells(br, 2) = max


                        xlsheet.Range(xlsheet.Cells(br, 1), xlsheet.Cells(br, 2)).HorizontalAlignment = xlCenter
                        chartRange = xlsheet.Range("A4:B" & br)
                        chartPage.SetSourceData(Source:=chartRange)
                        br = br + 1
                    Loop
                    sum = Format(Math.Round(sum / count, 2), "0.00")
                    xlsheet.Cells(br, 1) = "Средно"
                    xlsheet.Cells(br, 2) = sum
                    xlsheet.Range(xlsheet.Cells(br, 1), xlsheet.Cells(br, 2)).HorizontalAlignment = xlCenter
                    chartRange = xlsheet.Range("A4:B" & br)
                    chartPage.SetSourceData(Source:=chartRange)
                    Dim rng As Microsoft.Office.Interop.Excel.Range
                    rng = xlsheet.Range("A1:B" & br)
                    Call cellborder(rng)
                    chartPage.HasLegend = False
                    chartPage.PlotBy = Microsoft.Office.Interop.Excel.XlRowCol.xlColumns
                    chartPage.HasTitle = True
                    chartPage.ChartTitle.Text = xlsheet.Range("A2").Value()
                    chartPage.ApplyDataLabels(Microsoft.Office.Interop.Excel.XlDataLabelsType.xlDataLabelsShowLabel, _
                  False, True, False, False, False, True, False, False, False)
                    chartPage.ShowDataLabelsOverMaximum = True
                    'Смаляване на формата
                    Me.Height = 370
                    xlsheet.SaveAs(pat)
                    xlbook.Close()
                    xlapp.Quit()

                    releaseObject(xlapp)
                    releaseObject(xlbook)
                    releaseObject(xlsheet)
                    'питане дали да се отвори файла 
                    Dim res As MsgBoxResult
                    res = MsgBox("Искате ли файлът да се отвори?", MsgBoxStyle.YesNo, "Справка")
                    If res = MsgBoxResult.Yes Then
                        Process.Start(pat)
                    End If
                End If
                cnn.Close()
            End If
        Else
            MsgBox("Трябва да се върнете и да веведете оценки ! ! !", , "Справка")
        End If
    End Sub
    Private Sub btnExselFIle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExselFIle.Click
        If cmbyear.Text <> "" Then
            Dim rasEx As String
            rasEx = ""
            'викане на функция RazExcel в койято са записани разширенията на Excel
            Call Module1.RazExcel(rasEx)

            OpenFileDialog2.Filter = rasEx
            If OpenFileDialog2.ShowDialog = DialogResult.OK Then
                Try
                    cnn.Open()
                    cnn.Close()
                Catch ex As Exception
                    MsgBox("Грешка в базата данни! ! !")
                    Application.Exit()
                End Try
                cnn.Open()
                Dim pat As String = OpenFileDialog2.FileName
                Dim xlapp As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
                Dim masterWb As Microsoft.Office.Interop.Excel.Workbook
                masterWb = xlapp.Workbooks.Open(pat)

                Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
                xlWorkBook = xlapp.Workbooks.Add
                Dim ws As Microsoft.Office.Interop.Excel.Worksheet

                Try
                    'задаване на текст в клетки и форматиране на редове и колони
                    ws = xlWorkBook.Sheets.Add(, xlWorkBook.Sheets(xlWorkBook.Sheets.Count))
                    ws.Name = "Среден успех по паралелки"
                    title2 = "Среден успех по паралелки за година: "
                    title2 = title2 & cmbyear.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
                    Dim r As MySqlDataReader
                    Dim xldi As Microsoft.Office.Interop.Excel.Chart
                    xldi = New Microsoft.Office.Interop.Excel.Chart
                    Const xlCenter = -4108
                    ws.Range(ws.Cells(1, 1), ws.Cells(1, 2)).Merge()
                    ws.Range(ws.Cells(1, 1), ws.Cells(1, 2)).HorizontalAlignment = xlCenter
                    ws.Cells(1, 1) = title1
                    ws.Range(ws.Cells(2, 1), ws.Cells(2, 2)).Merge()
                    ws.Range(ws.Cells(2, 1), ws.Cells(2, 2)).HorizontalAlignment = xlCenter
                    ws.Range(ws.Cells(2, 1), ws.Cells(2, 2)).WrapText = True
                    ws.Cells(2, 1) = title2
                    ws.Cells(3, 1) = "Клас и оценка с думи"
                    ws.Cells(3, 2) = "Средно аритметично"
                    ws.Range(ws.Cells(3, 1), ws.Cells(3, 2)).HorizontalAlignment = xlCenter
                    ws.Range("A3").EntireColumn.ColumnWidth = 20
                    ws.Range("B3").EntireColumn.ColumnWidth = 30
                    ws.Range("A2").EntireRow.RowHeight = 45

                    Dim chartPage As Microsoft.Office.Interop.Excel.Chart
                    Dim xlCharts As Microsoft.Office.Interop.Excel.ChartObjects
                    Dim myChart As Microsoft.Office.Interop.Excel.ChartObject
                    Dim chartRange As Microsoft.Office.Interop.Excel.Range


                    xlCharts = ws.ChartObjects
                    myChart = xlCharts.Add(300, 50, 600, 250)
                    chartPage = myChart.Chart

                    chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlColumnClustered
                    'извикване на функция cmdmaxmi, която връща datareader и проверка тя дали е пълна 
                    cmdmaxmin(r)

                    If RRowsCount > 0 Then
                        Dim classes, class2, class1, otd As String
                        Dim grade, br As Integer
                        Dim max As Double
                        otd = ""
                        br = 4
                        'четене на datareader, изчисляване на данните и тяхното записване в excel.

                        Dim sum, count As Double
                        Do While r.Read
                            grade = r.GetString("grade")
                            classes = r.GetString("class")
                            max = r.GetString("sreden_uspeh")
                            prb1.Value = prb1.Value + 1
                            max = Format(Math.Round(max, 2), "0.00")
                            '  оценка с думи
                            If max < 3 Then
                                otd = " - Слаб"
                            ElseIf max >= 3 And max < 3.5 Then
                                otd = " - Среден"
                            ElseIf max >= 3.5 And max < 4.5 Then
                                otd = " - Добър"
                            ElseIf max >= 4.5 And max < 5.5 Then
                                otd = " - Много добър"
                            ElseIf max >= 5.5 And max < 6 Then
                                otd = " - Отличен"
                            End If

                            class2 = grade & " " & classes & otd
                            class1 = grade & " " & classes
                            sum = sum + max
                            count = count + 1
                            ws.Cells(br, 1) = class2
                            ws.Cells(br, 2) = max
                            ws.Range(ws.Cells(br, 1), ws.Cells(br, 2)).HorizontalAlignment = xlCenter
                            chartRange = ws.Range("A2:B" & br)

                            chartPage.SetSourceData(Source:=chartRange)
                            br = br + 1
                        Loop
                        sum = Format(Math.Round(sum / count, 2), "0.00")
                        ws.Cells(br, 1) = "Средно"
                        ws.Cells(br, 2) = sum
                        ws.Range(ws.Cells(br, 1), ws.Cells(br, 2)).HorizontalAlignment = xlCenter
                        chartRange = ws.Range("A4:B" & br)
                        chartPage.SetSourceData(Source:=chartRange)
                        Dim rng As Microsoft.Office.Interop.Excel.Range
                        rng = ws.Range("A1:B" & br)
                        Call cellborder(rng)
                        chartPage.HasTitle = True
                        chartPage.ChartTitle.Text = ws.Range("A2").Value()
                        chartPage.HasLegend = False
                        chartPage.PlotBy = Microsoft.Office.Interop.Excel.XlRowCol.xlColumns

                        chartPage.ApplyDataLabels(Microsoft.Office.Interop.Excel.XlDataLabelsType.xlDataLabelsShowLabel,
                  False, True, False, False, False, True, False, False, False)
                        chartPage.ShowDataLabelsOverMaximum = True
                        ws.Copy(, masterWb.Sheets(masterWb.Sheets.Count))
                        ws = Nothing
                        xlWorkBook.Save()
                        xlWorkBook.Close()
                        xlWorkBook = Nothing
                        'Смаляване на формата
                        Me.Height = 370
                        masterWb.SaveAs(pat)
                        masterWb.Close()
                        masterWb = Nothing
                        xlapp.Quit()
                        xlapp = Nothing


                        'питане дали да се отвори файла 
                        Dim res As MsgBoxResult
                        res = MsgBox("Искате ли файлът да се отвори?", MsgBoxStyle.YesNo, "Справка")
                        If res = MsgBoxResult.Yes Then
                            Process.Start(pat)
                        End If
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)

                End Try
                cnn.Close()
            End If
        Else
            MsgBox("Трябва да се върнете и да веведете оценки ! ! !", , "Справка")
        End If
    End Sub
    Private Sub btnWordNewFIle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWordNewFIle.Click
        If cmbyear.Text <> "" Then
            Dim razWor As String
            razWor = ""
            'викане на функция RazWord в койято са записани разширенията на word
            Call Module1.RazWord(razWor)

            SaveFileDialog2.Filter = razWor
            If SaveFileDialog2.ShowDialog = DialogResult.OK Then
                Try
                    cnn.Open()
                    cnn.Close()
                Catch ex As Exception
                    MsgBox("Грешка в базата данни! ! !")
                    Application.Exit()
                End Try
                cnn.Open()

                Dim pat As String
                pat = SaveFileDialog2.FileName

                Dim oWord As Microsoft.Office.Interop.Word.Application
                Dim oDoc As Microsoft.Office.Interop.Word.Document
                Dim oTable As Microsoft.Office.Interop.Word.Table
                Dim oPara1 As Microsoft.Office.Interop.Word.Paragraph, oPara2 As Microsoft.Office.Interop.Word.Paragraph

                oWord = CreateObject("Word.Application")
                'задаване на текст, вкарваненатаблица и нейното форматиране
                oDoc = oWord.Documents.Add
                oPara1 = oDoc.Content.Paragraphs.Add
                oPara1.Range.Font.Size = 20
                oPara1.Range.Font.Bold = True
                oPara1.Range.Text = title1

                oPara1.Alignment = HorizontalAlignment.Right
                oPara1.Format.SpaceAfter = 24

                oPara1.Range.InsertParagraphAfter()
                title2 = "Среден успех по паралелки за година: "
                title2 = title2 & cmbyear.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text

                oPara2 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
                oPara2.Range.Text = title2
                oPara2.Format.SpaceAfter = 6
                oPara2.Range.InsertParagraphAfter()

                Dim r As MySqlDataReader
                'извикване на функция cmdmaxmi, която връща datareader и проверка тя дали е пълна 
                cmdmaxmin(r)

                If RRowsCount > 0 Then
                    oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, RRowsCount + 1, 2)
                    Dim sum, count As Double
                    Dim classes, class1, otd As String
                    Dim grade, br As Integer
                    Dim max As Double
                    otd = ""
                    br = 2
                    prb1.Value = 0
                    prb1.Maximum = RRowsCount

                    oTable.Cell(1, 1).Range.Text = "Клас"
                    oTable.Cell(1, 2).Range.Text = "Средно аритметично"
                    'четене на datareader, изчисляване на данните и тяхното записване в excel
                    Do While r.Read
                        grade = r.GetString("grade")
                        classes = r.GetString("class")
                        max = r.GetString("sreden_uspeh")
                        max = Format(Math.Round(max, 2), "0.00")
                        prb1.Value = prb1.Value + 1
                        '  оценка с думи
                        sum = sum + max
                        count = count + 1
                        If max < 3 Then
                            otd = " - Слаб"
                        ElseIf max >= 3 And max < 3.5 Then
                            otd = " - Среден"
                        ElseIf max >= 3.5 And max < 4.5 Then
                            otd = " - Добър"
                        ElseIf max >= 4.5 And max < 5.5 Then
                            otd = " - Много добър"
                        ElseIf max >= 5.5 And max < 6 Then
                            otd = " - Отличен"
                        End If
                        class1 = grade & " " & classes
                        oTable.Cell(br, 1).Range.Text = class1
                        oTable.Cell(br, 2).Range.Text = max

                        br = br + 1
                    Loop
                    sum = Format(Math.Round(sum / count, 2), "0.00")
                    oTable.Cell(br, 1).Range.Text = "Средно"
                    oTable.Cell(br, 2).Range.Text = sum
                    'форматиране на таблицата
                    oTable.Rows.Item(1).Range.Font.Bold = True
                    oTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle
                    oTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle

                    'смаляване на формата
                    Me.Height = 370
                    oDoc.SaveAs2(pat)
                    cnn.Close()
                    oDoc.Close()
                    'питане дали да се отвори файла
                    Dim res As MsgBoxResult
                    res = MsgBox("Искате ли файлът да се отвори?", MsgBoxStyle.YesNo, "Справка")
                    If res = MsgBoxResult.Yes Then
                        Process.Start(pat)
                    End If
                End If
            End If
        Else
            MsgBox("Трябва да се върнете и да веведете оценки ! ! !", , "Справка")
        End If
    End Sub
    Private Sub cmbSubject_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubject.Leave, cmbSubject.DropDownClosed
        If (cmbSubject.SelectedIndex = -1) Then
            'Проверка за въвеждане на символи от клавиатурата
            cmbSubject.Text = cmbSubject.Items(0)
            cmbSubject.Focus()
        Else
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            'изтриване на старите сойности в cmbtype

            Do While cmbtype.Items.Count > 1
                cmbtype.Items.Remove(cmbtype.Items(1))
                cmbTypeid.Items.Remove(cmbTypeid.Items(1))
            Loop
            'Променяне айтамите в Видове оценки
            Dim brRows, nomer, flag, britem As Integer
            brRows = 0

            Dim subjid As Integer
            cmbSubjectId.Text = cmbSubjectId.Items(cmbSubject.SelectedIndex)
            subjid = cmbSubjectId.Text
            'задаване на команда в заисимост от избраните парамтри
            If subjid <> -1 Then
                cmd = New MySqlCommand("Select* from  purpose where subject='" & subjid & "'order by id", cnn)
            Else
                cmd = New MySqlCommand("Select* from  purpose order by id", cnn)

            End If

            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            'изпълняване на командата
            If data.Rows.Count > 0 Then
                Dim types As String
                types = ""
                'обхождане на редовете в командата
                Do While brRows < data.Rows.Count
                    'взиамане на номера на класа и неговото търсене в таблица classes
                    nomer = data.Rows(brRows).Item("class")
                    cmd = New MySqlCommand("Select* from  classes where id='" & nomer & "'", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt As DataTable = New DataTable
                    adaptre1.Fill(dt)
                    'взиамане на годината на класа в оттаблица classes
                    years = dt.Rows(0).Item("school_year")
                    flag = 0
                    years = years & "/" & years Mod 100 + 1
                    'Проверка за взетата годината дали е еднаква с избраната година
                    If years = cmbyear.Text Then
                        'Добавяне на стойности в cmbSubject и cmbType
                        nomer = data.Rows(brRows).Item("id")
                        cmd = New MySqlCommand("Select* from  purpose where class='" & nomer & "'and subject='" & subjid & "'", cnn)
                        cmd.ExecuteNonQuery()
                        Dim adapt As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                        Dim d As DataTable = New DataTable
                        adaptre1.Fill(d)

                        If d.Rows.Count > 0 Then
                            nomer = data.Rows(brRows).Item("type")

                            cmd = New MySqlCommand("Select* from  types where id='" & nomer & "'", cnn)
                            cmd.ExecuteNonQuery()
                            Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                            Dim dt2 As DataTable = New DataTable
                            adaptre2.Fill(dt2)

                            types = dt2.Rows(0).Item("name_type")
                            flag = 0
                            britem = 1

                            Do While britem < cmbtype.Items.Count

                                If types = cmbtype.Items(britem) Then

                                    flag = 1
                                    britem = cmbtype.Items.Count
                                End If
                                britem = britem + 1
                            Loop
                            If flag = 0 Then

                                cmbtype.Items.Add(types)
                                cmbTypeid.Items.Add(dt2.Rows(0).Item("id"))
                            End If

                        End If
                    End If
                    brRows = brRows + 1
                Loop
                If types <> "" Then
                    cmbtype.Text = cmbtype.Items(0)
                    cmbTypeid.Text = cmbTypeid.Items(0)
                End If
            End If

            'изтриване на старите сойности в dgv1
            Do While dgv1.RowCount > 0
                dgv1.Rows.Remove(dgv1.Rows(0))
            Loop

            'записване на сойности в dgv1
            If cmbSubjectId.Text = -1 Then
                cmd = New MySqlCommand("Select* from  purpose", cnn)
            Else
                cmd = New MySqlCommand("Select* from  purpose where subject='" & subjid & "'", cnn)
            End If

            cmd.ExecuteNonQuery()
            Dim adaptre30 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data30 As DataTable = New DataTable
            adaptre30.Fill(data30)
            Dim id As Integer

            If data30.Rows.Count > 0 Then
                Dim classes, classp, subject, type, count_2, count_3, count_4, count_5, count_6 As String
                Dim nomerdgv1, year, classn, brrows2 As Integer
                Dim yearsting As String
                brrows2 = 0

                Do While brrows2 < data30.Rows.Count

                    id = data30.Rows(brrows2).Item("id")
                    ' задаване на клас
                    nomerdgv1 = data30.Rows(brrows2).Item("class")
                    cmd = New MySqlCommand("Select* from  classes where id='" & nomerdgv1 & "' order by id", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt As DataTable = New DataTable
                    adaptre1.Fill(dt)
                    year = dt.Rows(0).Item("school_year")
                    classn = dt.Rows(0).Item("grade")
                    classp = dt.Rows(0).Item("class")
                    classes = year & "/" & year Mod 100 + 1 & " " & classn & " " & classp
                    yearsting = year & "/" & year Mod 100 + 1

                    If yearsting = cmbyear.Text Then
                        ' задаване на subject
                        nomerdgv1 = data30.Rows(brrows2).Item("subject")
                        cmd = New MySqlCommand("Select* from  subject where id='" & nomerdgv1 & "'", cnn)
                        cmd.ExecuteNonQuery()
                        Dim adaptre5 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                        Dim dt3 As DataTable = New DataTable
                        adaptre5.Fill(dt3)
                        subject = dt3.Rows(0).Item("name_subject")

                        'задаване на types

                        nomerdgv1 = data30.Rows(brrows2).Item("type")
                        cmd = New MySqlCommand("Select* from  types where id='" & nomerdgv1 & "'", cnn)
                        cmd.ExecuteNonQuery()
                        Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                        Dim dt2 As DataTable = New DataTable
                        adaptre2.Fill(dt2)
                        type = dt2.Rows(0).Item("name_type")

                        'задаване на бройя на двойки, тройки, четворки, петици, шестици

                        count_2 = data30.Rows(brrows2).Item("count_2")
                        count_3 = data30.Rows(brrows2).Item("count_3")
                        count_4 = data30.Rows(brrows2).Item("count_4")
                        count_5 = data30.Rows(brrows2).Item("count_5")
                        count_6 = data30.Rows(brrows2).Item("count_6")

                        'писане в dgv1
                        dgv1.Rows.Add(id, classes, subject, type, count_2, count_3, count_4, count_5, count_6)

                    End If

                    brrows2 = brrows2 + 1
                Loop
            End If
            cnn.Close()
        End If

    End Sub
    Private Sub cmbPodredba_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPodredba.Leave, cmbPodredba.DropDownClosed
        If (cmbPodredba.SelectedIndex = -1) Then
            'Проверка за въвеждане на символи от клавиатурата
            cmbPodredba.Text = cmbPodredba.Items(0)
            cmbPodredba.Focus()
        End If
    End Sub


End Class