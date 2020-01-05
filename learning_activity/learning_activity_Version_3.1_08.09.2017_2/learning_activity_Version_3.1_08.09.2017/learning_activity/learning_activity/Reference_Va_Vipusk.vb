'използване на MySQL Data
Imports MySql.Data.MySqlClient
Public Class Reference_VA_Vipusk
    'деклариране на глобални променливи
    Dim cnn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim years, title1, title2, flagbtn As String
    Dim a, b, RRowsCount As Integer
    Private Sub Reference_VA_Vipusk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Module1.hosts(cnn)
        cnn.Open()
        'Отваряне на връската със SURVER
        Dim brRows, flag As Integer
        brRows = 0
        title1 = "Справка"
        title2 = "Среден успех по класове за випуск "
        cmd = New MySqlCommand("Select* from  classes order by school_year desc, grade desc", cnn)
        cmd.ExecuteNonQuery()
        Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
        Dim data As DataTable = New DataTable
        adaptre.Fill(data)
        'Проверка дали има въведени класове
        If data.Rows.Count > 0 Then
            Dim classesPodr(data.Rows.Count, 2) As Integer
            Dim years, grade As Integer
            brRows = 0
            'обхойдане на таблицата с резултата за класовете и тяхното добавяне в cmbVipusk, cmbClass и cmbYear
            For i As Integer = 1 To data.Rows.Count
                grade = data.Rows(i - 1).Item("grade")
                years = data.Rows(i - 1).Item("school_year")
                flag = 0
                For j As Integer = 0 To data.Rows.Count
                    If classesPodr(j, 1) = grade And classesPodr(j, 2) = years Then
                        flag = 1
                        j = data.Rows.Count - 1
                    End If
                Next

                If flag = 0 Then
                    classesPodr(brRows, 1) = grade
                    classesPodr(brRows, 2) = years
                    brRows = brRows + 1

                End If
            Next
            brRows = 0
            Dim yeardo As String
            Do While classesPodr(brRows, 1) <> 0
                grade = classesPodr(brRows, 1)
                years = classesPodr(brRows, 2)
                yeardo = years & "/" & years Mod 100 + 1
                Dim fdouble As Integer = 0
                For i As Integer = 0 To cmbYear.Items.Count - 1
                    If cmbYear.Items(i) = years Then
                        fdouble = 1
                        Exit For
                    End If
                Next

                If fdouble = 0 Then
                    cmbYear.Items.Add(years)
                End If

                fdouble = 0
                For i As Integer = 0 To cmbYearString.Items.Count - 1
                    If cmbYearString.Items(i) = yeardo Then
                        fdouble = 1
                        Exit For
                    End If
                Next
                If fdouble = 0 Then
                    cmbYearString.Items.Add(yeardo)
                End If

                fdouble = 0
                For i As Integer = 0 To cmbClass.Items.Count - 1
                    If cmbClass.Items(i) = grade Then
                        fdouble = 1
                        Exit For
                    End If
                Next
                If fdouble = 0 Then
                    cmbClass.Items.Add(grade)
                End If
                brRows = brRows + 1
            Loop
            'задаване на текст в cmbVipusk, cmbClass и cmbYear
            cmbYearString.Text = cmbYearString.Items(0)
            cmbClass.Text = cmbClass.Items(0)
            cmbYear.Text = cmbYear.Items(0)

            grade = cmbClass.Text
            years = cmbYear.Text
            'взимане на Номера на клас, който е избран
            cmd = New MySqlCommand("Select* from  classes where grade='" & grade & "' and school_year='" & years & "'", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable
            adaptre1.Fill(dt)

            Dim brrows2 As Integer = 0
            brRows = 0
            Dim idclass, idtype, IntSubject, typeid As Integer
            Dim nType, strSubject As String
            cmbSubject.Text = cmbSubject.Items(0)
            Do While dt.Rows.Count > brRows
                idclass = dt.Rows(brRows).Item("id")
                'селектиране на оценките в таблица purpose, където class е номера на класа
                cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "' order by type", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt1 As DataTable = New DataTable
                adaptre2.Fill(dt1)
                If dt1.Rows.Count > 0 Then
                    brrows2 = 0
                    Dim subflag, subjite, subid As Integer
                    Do While brrows2 < dt1.Rows.Count
                        'добавяне на резултатите в cmbType и cmbsubject ако не са били добавени
                        idtype = dt1.Rows(brrows2).Item("type")
                        IntSubject = dt1.Rows(brrows2).Item("subject")
                        cmd = New MySqlCommand("Select* from  subject where id='" & IntSubject & "'", cnn)
                        cmd.ExecuteNonQuery()
                        Dim adaptre30 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                        Dim dt30 As DataTable = New DataTable
                        adaptre30.Fill(dt30)

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
                        cmd = New MySqlCommand("Select* from  types where id='" & idtype & "'", cnn)
                        cmd.ExecuteNonQuery()
                        Dim adaptre3 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                        Dim dt3 As DataTable = New DataTable
                        adaptre3.Fill(dt3)

                        flag = 0
                        nType = dt3.Rows(0).Item("name_type")
                        typeid = dt3.Rows(0).Item("id")
                        For j As Integer = 0 To cmbtype.Items.Count - 1
                            If cmbtype.Items(j) = nType Then
                                flag = 1
                                j = cmbtype.Items.Count

                            End If
                        Next
                        If flag = 0 Then
                            cmbtype.Items.Add(nType)
                            cmbIdType.Items.Add(typeid)
                        End If



                        brrows2 = brrows2 + 1
                    Loop
                End If
                brRows = brRows + 1
            Loop

            'Добавяне на редове в datagridview
            years = cmbYear.Text
            grade = cmbClass.Text
            cmd = New MySqlCommand("Select* from  classes where school_year='" & years & "'and grade='" & grade & "'", cnn)
            cmd.ExecuteNonQuery()
            Dim adap As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data1 As DataTable = New DataTable
            adap.Fill(data1)
            Dim c2, c3, c4, c5, c6, id, nomer As Integer
            Dim subject, classes As String
            For i As Integer = 0 To data1.Rows.Count - 1
                idclass = data1.Rows(i).Item("id")
                classes = data1.Rows(i).Item("class")
                classes = grade & " " & classes & " " & years & "/" & years Mod 100 + 1
                cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "'", cnn)
                cmd.ExecuteNonQuery()
                Dim adap2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim data2 As DataTable = New DataTable
                adap2.Fill(data2)
                For j As Integer = 0 To data2.Rows.Count - 1
                    c2 = data2.Rows(j).Item("count_2")
                    c3 = data2.Rows(j).Item("count_3")
                    c4 = data2.Rows(j).Item("count_4")
                    c5 = data2.Rows(j).Item("count_5")
                    c6 = data2.Rows(j).Item("count_6")
                    id = data2.Rows(j).Item("id")
                    'задаване на type оценка
                    nomer = data2.Rows(j).Item("type")
                    cmd = New MySqlCommand("Select* from  types where id='" & nomer & "'", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt2 As DataTable = New DataTable
                    adaptre2.Fill(dt2)
                    nType = dt2.Rows(0).Item("name_type")
                    ' задаване на subject
                    nomer = data2.Rows(j).Item("subject")
                    cmd = New MySqlCommand("Select* from  subject where id='" & nomer & "'", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre5 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt3 As DataTable = New DataTable
                    adaptre5.Fill(dt3)
                    subject = dt3.Rows(0).Item("name_subject")
                    'писане в dgv1
                    dgv1.Rows.Add(id, classes, subject, nType, c2, c3, c4, c5, c6)
                Next

            Next
        End If
        cnn.Close()
    End Sub
    Private Sub cmbSubject_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubject.Leave, cmbSubject.DropDownClosed
        If (cmbSubject.SelectedIndex = -1) Then
            cmbSubject.Text = cmbSubject.Items(0)
            cmbSubject.Focus()
        Else
            'изтриване на старите сойности в dgv1
            Do While dgv1.RowCount > 0
                dgv1.Rows.Remove(dgv1.Rows(0))
            Loop

            Do While cmbtype.Items.Count > 1
                cmbtype.Items.Remove(cmbtype.Items(1))
            Loop
            'задаввне на ид  cmbSubjctId
            cmbSubjectId.Text = cmbSubjectId.Items(cmbSubject.SelectedIndex)
            Dim subjid As Integer
            subjid = cmbSubjectId.Text
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            Dim brRows, flag As Integer
            brRows = 0
            Dim grade As Integer

            grade = cmbClass.Text
            years = cmbYear.Text
            'търсене на избрания випуска
            cmd = New MySqlCommand("Select* from  classes where grade='" & grade & "' and school_year='" & years & "'", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable
            adaptre1.Fill(dt)
            Dim brrows2 As Integer = 0
            brRows = 0
            Dim idclass, idtype As Integer
            Dim nType As String
            Do While dt.Rows.Count > brRows
                idclass = dt.Rows(brRows).Item("id")
                'търсене на оценките на класовете от випуска
                If subjid = -1 Then
                    cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "' order by type", cnn)
                Else
                    cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "'and subject='" & subjid & "' order by type", cnn)
                End If
                cmd.ExecuteNonQuery()
                Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt1 As DataTable = New DataTable
                adaptre2.Fill(dt1)
                If dt1.Rows.Count > 0 Then
                    brrows2 = 0
                    Do While brrows2 < dt1.Rows.Count
                        'проверка дали  вида оценка е записан в cmbType
                        idtype = dt1.Rows(brrows2).Item("type")
                        cmd = New MySqlCommand("Select* from  types where id='" & idtype & "'", cnn)
                        cmd.ExecuteNonQuery()
                        Dim adaptre3 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                        Dim dt3 As DataTable = New DataTable
                        adaptre3.Fill(dt3)
                        flag = 0
                        nType = dt3.Rows(0).Item("name_type")
                        For j As Integer = 0 To cmbtype.Items.Count - 1
                            If cmbtype.Items(j) = nType Then
                                flag = 1
                                j = cmbtype.Items.Count
                            End If
                        Next
                        If flag = 0 Then
                            cmbtype.Items.Add(nType)
                        End If
                        brrows2 = brrows2 + 1
                    Loop
                    cmbtype.Text = cmbtype.Items(0)
                End If
                brRows = brRows + 1
            Loop
            'записване на новите стоности в dgv1
            years = cmbYear.Text
            grade = cmbClass.Text
            cmd = New MySqlCommand("Select* from  classes where school_year='" & years & "'and grade='" & grade & "'", cnn)
            cmd.ExecuteNonQuery()
            Dim adap As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data1 As DataTable = New DataTable
            adap.Fill(data1)
            Dim c2, c3, c4, c5, c6, id, nomer As Integer
            Dim subject, classes As String
            For i As Integer = 0 To data1.Rows.Count - 1
                idclass = data1.Rows(i).Item("id")
                classes = data1.Rows(i).Item("class")
                classes = grade & " " & classes & " " & years & "/" & years Mod 100 + 1
                If subjid = -1 Then
                    cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "'", cnn)
                Else
                    cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "'and subject='" & subjid & "'", cnn)
                End If
                cmd.ExecuteNonQuery()
                Dim adap2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim data2 As DataTable = New DataTable
                adap2.Fill(data2)
                For j As Integer = 0 To data2.Rows.Count - 1
                    c2 = data2.Rows(j).Item("count_2")
                    c3 = data2.Rows(j).Item("count_3")
                    c4 = data2.Rows(j).Item("count_4")
                    c5 = data2.Rows(j).Item("count_5")
                    c6 = data2.Rows(j).Item("count_6")
                    id = data2.Rows(j).Item("id")

                    'задаване на type оценка
                    nomer = data2.Rows(j).Item("type")
                    cmd = New MySqlCommand("Select* from  types where id='" & nomer & "'", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt2 As DataTable = New DataTable
                    adaptre2.Fill(dt2)
                    nType = dt2.Rows(0).Item("name_type")
                    ' задаване на subject
                    nomer = data2.Rows(j).Item("subject")
                    cmd = New MySqlCommand("Select* from  subject where id='" & nomer & "'", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre5 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt3 As DataTable = New DataTable
                    adaptre5.Fill(dt3)
                    subject = dt3.Rows(0).Item("name_subject")
                    'писане в dgv1
                    dgv1.Rows.Add(id, classes, subject, nType, c2, c3, c4, c5, c6)
                Next
            Next
            cnn.Close()
        End If

    End Sub
    Private Sub cmbtype_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtype.Leave, cmbtype.DropDownClosed
        If (cmbtype.SelectedIndex = -1) Then
            cmbtype.Text = cmbtype.Items(0)
            cmbtype.Focus()

        Else
            'изтриване на старите сойности в dgv1
            Do While dgv1.RowCount > 0
                dgv1.Rows.Remove(dgv1.Rows(0))
            Loop
            'задаввне на ид
            cmbSubjectId.Text = cmbSubjectId.Items(cmbSubject.SelectedIndex)
            cmbIdType.Text = cmbIdType.Items(cmbtype.SelectedIndex)
            '   cmbYear.Text = cmbYear.Items(cmbVipusk.SelectedIndex)
            '  cmbClass.Text = cmbClass.Items(cmbVipusk.SelectedIndex)
            Dim subjid, typeid As Integer
            subjid = cmbSubjectId.Text
            typeid = cmbIdType.Text
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            Dim brRows, grade, idclass As Integer
            brRows = 0
            grade = cmbClass.Text
            years = cmbYear.Text
            Dim brrows2 As Integer = 0
            brRows = 0
            Dim nType As String
            years = cmbYear.Text
            grade = cmbClass.Text
            'селектирене на класовете от випуска
            cmd = New MySqlCommand("Select* from  classes where school_year='" & years & "'and grade='" & grade & "'", cnn)
            cmd.ExecuteNonQuery()
            Dim adap As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data1 As DataTable = New DataTable
            adap.Fill(data1)
            Dim c2, c3, c4, c5, c6, id, nomer As Integer
            Dim subject, classes As String
            'обхождане на класовете от випуска
            For i As Integer = 0 To data1.Rows.Count - 1

                idclass = data1.Rows(i).Item("id")
                classes = data1.Rows(i).Item("class")
                classes = grade & " " & classes & " " & years & "/" & years Mod 100 + 1
                If typeid = -1 Then
                    If subjid = -1 Then
                        cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "'", cnn)
                    Else
                        cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "'and subject='" & subjid & "'", cnn)
                    End If
                Else
                    If subjid = -1 Then
                        cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "'and type='" & typeid & "'", cnn)
                    Else
                        cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "'and subject='" & subjid & "'and type='" & typeid & "'", cnn)
                    End If
                End If
                cmd.ExecuteNonQuery()
                Dim adap2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim data2 As DataTable = New DataTable
                adap2.Fill(data2)
                'обхождане на оценките от класовете от випуска и записването им в dgv1
                For j As Integer = 0 To data2.Rows.Count - 1
                    c2 = data2.Rows(j).Item("count_2")
                    c3 = data2.Rows(j).Item("count_3")
                    c4 = data2.Rows(j).Item("count_4")
                    c5 = data2.Rows(j).Item("count_5")
                    c6 = data2.Rows(j).Item("count_6")
                    id = data2.Rows(j).Item("id")
                    'задаване на type оценка
                    nomer = data2.Rows(j).Item("type")
                    cmd = New MySqlCommand("Select* from  types where id='" & nomer & "'", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt2 As DataTable = New DataTable
                    adaptre2.Fill(dt2)
                    nType = dt2.Rows(0).Item("name_type")
                    ' задаване на subject
                    nomer = data2.Rows(j).Item("subject")
                    cmd = New MySqlCommand("Select* from  subject where id='" & nomer & "'", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre5 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt3 As DataTable = New DataTable
                    adaptre5.Fill(dt3)
                    subject = dt3.Rows(0).Item("name_subject")
                    'писане в dgv1
                    dgv1.Rows.Add(id, classes, subject, nType, c2, c3, c4, c5, c6)
                Next
            Next
            cnn.Close()
        End If
    End Sub
    Private Sub cmdmaxmin(ByRef r As MySqlDataReader)
        'проверка дали на този клас са въвейдани оценки по зададен вид оценки

        Dim scom As String
        scom = ""
        'задаванена на команда оттип String в променлива coms в зависимост от избрания начин на сортиране
        Call sminmax(scom)
        If scom <> "" Then
            cmd = New MySqlCommand(scom, cnn)
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
        End If
    End Sub
    Private Sub sminmax(ByRef r As String)
        'В зависимуст от избраните параметри се връща низ със комндата
        Dim flag As Integer

        If cmbtype.Text = cmbtype.Items(0) Then
            If cmbSubject.Text = cmbSubject.Items(0) Then
                r = "SELECT classes.grade, classes.class, sum(count_2) as c2, sum(count_3) as c3, sum(count_4) as c4, sum(count_5) as c5, sum(count_6) as c6 " _
                                                             & " FROM classes Inner join purpose" _
                                                             & " ON classes.id=purpose.class Where school_year='" & cmbYear.Text & "'and classes.grade='" & cmbClass.Text _
                                                             & "' Group by  purpose.class ;"

                flag = 1

            Else


                r = "SELECT classes.grade, classes.class, sum(count_2) as c2,sum(count_3) as c3,sum(count_4) as c4, sum(count_5) as c5, sum(count_6) as c6" _
                                                              & " FROM classes Inner join purpose" _
                                                              & " ON classes.id=purpose.class Where school_year='" & cmbYear.Text & "'and classes.grade='" & cmbClass.Text _
                                                              & "'and purpose.subject='" & cmbSubjectId.Text & "' Group by  purpose.class;"
                flag = 2
            End If
        Else

            If cmbSubject.Text = cmbSubject.Items(0) Then
                r = "SELECT classes.grade, classes.class, sum(count_2) as c2,sum(count_3) as c3,sum(count_4) as c4, sum(count_5) as c5, sum(count_6) as c6" _
                                                             & " FROM classes Inner join purpose" _
                                                             & " ON classes.id=purpose.class Where school_year='" & cmbYear.Text & "'and classes.grade='" & cmbClass.Text & "'and purpose.type='" & cmbIdType.Text _
                                                             & "' Group by  purpose.class;"
                flag = 3

            Else
                r = "SELECT classes.grade, classes.class, sum(count_2) as c2,sum(count_3) as c3,sum(count_4) as c4, sum(count_5) as c5, sum(count_6) as c6" _
                                                              & " FROM classes Inner join purpose" _
                                                              & " ON classes.id=purpose.class Where school_year='" & cmbYear.Text & "'and classes.grade='" & cmbClass.Text _
                                                              & "'and purpose.type='" & cmbIdType.Text & "'and purpose.subject='" & cmbSubjectId.Text _
                                                              & "' Group by  purpose.class;"

                flag = 4
            End If

        End If
    End Sub
    Private Sub btnchart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnchart.Click
        If cmbYear.Text <> "" Then
            'проверка за стойностите в диаграмата и тяхното изтриване
            If flagbtn = 1 Then

                Chart1.Series.Clear()
                Chart1.Titles.Clear()
                Chart1.Titles.Clear()

                Chart1.Series.Add("Otnoshenie")
                Chart1.Series(0).ChartType = 17
            End If
            title2 = "Съотношение на оценките по брой за випуск: "
            title2 = title2 & cmbYearString.Text & " " & cmbClass.Text & ", предмет: " & cmbSubject.Text & ", за вид оценка: " & cmbtype.Text
            Chart1.Titles.Add(title1)
            Chart1.Titles.Add(title2)
            'викане на функция cmdmaxmin, която връща резултат datareader и проверка дали редовете в негя саповече от 0
            Dim r As MySqlDataReader
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            cmdmaxmin(r)
            If RRowsCount > 0 Then
                Dim c2, c3, c4, c5, c6 As Integer
                'обхождане на редовете един по един и добавяне на изчислените стойности в диаграмата
                Do While r.Read
                    c2 = c2 + r.GetString("c2")
                    c3 = c3 + r.GetString("c3")
                    c4 = c4 + r.GetString("c4")
                    c5 = c5 + r.GetString("c5")
                    c6 = c6 + r.GetString("c6")

                    prb1.Value = prb1.Value + 1
                Loop
                If c2 > 0 Then
                    Chart1.Series("Otnoshenie").Points.AddXY("Двойки брой- " & c2, c2)
                End If
                If c3 > 0 Then
                    Chart1.Series("Otnoshenie").Points.AddXY("Тройки брой- " & c3, c3)
                End If
                If c4 > 0 Then
                    Chart1.Series("Otnoshenie").Points.AddXY("Четворки брой- " & c4, c4)
                End If
                If c5 > 0 Then
                    Chart1.Series("Otnoshenie").Points.AddXY("Петици брой- " & c5, c5)
                End If
                If c6 > 0 Then
                    Chart1.Series("Otnoshenie").Points.AddXY("Шестици брой- " & c6, c6)
                End If
                Chart1.Series(0)("PieLabelStyle") = "Outside"

                flagbtn = 1

                Chart1.Visible = True
                'оголемяване на формата
                Me.Height = 735
            End If
            cnn.Close()
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
        If cmbYear.Text <> "" Then

            title2 = "Съотношение на оценките по брой за випуск: "
            title2 = title2 & cmbYearString.Text & " " & cmbClass.Text & ", предмет: " & cmbSubject.Text & ", за вид оценка: " & cmbtype.Text
            Dim r As MySqlDataReader
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            'викане на функция RazExcel в койято са записани разширенията на Excel
            Dim rasEx As String
            rasEx = ""
            Call Module1.RazExcel(rasEx)
            SaveFileDialog1.Filter = rasEx

            If SaveFileDialog1.ShowDialog = DialogResult.OK Then

                Dim xlapp As Microsoft.Office.Interop.Excel.Application
                Dim xlbook As Microsoft.Office.Interop.Excel.Workbook
                Dim xlsheet As Microsoft.Office.Interop.Excel.Worksheet
                Dim misvalue As Object = System.Reflection.Missing.Value

                Dim xldi As Microsoft.Office.Interop.Excel.Chart
                'задаване на текст в клетки и форматиране на редове и колониz
                xlapp = New Microsoft.Office.Interop.Excel.Application
                xlbook = xlapp.Workbooks.Add(misvalue)
                xlsheet = CType(xlbook.Sheets(1), Microsoft.Office.Interop.Excel.Worksheet)
                xlsheet.Name = "Съотношение на оценките по брой"
                xldi = New Microsoft.Office.Interop.Excel.Chart
                Const xlCenter = -4108
                xlsheet.Range(xlsheet.Cells(1, 1), xlsheet.Cells(1, 2)).Merge()
                xlsheet.Range(xlsheet.Cells(1, 1), xlsheet.Cells(1, 2)).HorizontalAlignment = xlCenter
                xlsheet.Cells(1, 1) = title1
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 2)).Merge()
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 2)).HorizontalAlignment = xlCenter
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 2)).WrapText = True
                xlsheet.Cells(2, 1) = title2
                xlsheet.Cells(3, 1) = "Oценка"
                xlsheet.Cells(3, 2) = "Брой"
                xlsheet.Range(xlsheet.Cells(3, 1), xlsheet.Cells(3, 2)).HorizontalAlignment = xlCenter
                xlsheet.Range("A3").EntireColumn.ColumnWidth = 24
                xlsheet.Range("B3").EntireColumn.ColumnWidth = 30
                xlsheet.Range("A2").EntireRow.RowHeight = 35
                Dim pat As String
                pat = SaveFileDialog1.FileName
                Dim chartPage As Microsoft.Office.Interop.Excel.Chart
                Dim xlCharts As Microsoft.Office.Interop.Excel.ChartObjects
                Dim myChart As Microsoft.Office.Interop.Excel.ChartObject
                Dim chartRange As Microsoft.Office.Interop.Excel.Range

                xlCharts = xlsheet.ChartObjects
                myChart = xlCharts.Add(5, 145, 280, 200)
                chartPage = myChart.Chart

                chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlPie
                'извикване на функция cmdmaxmi, която връща datareader и проверка тя дали е пълна
                cmdmaxmin(r)
                If RRowsCount > 0 Then
                    Dim c2, c3, c4, c5, c6 As Integer
                    'четене на datareader, изчисляване на данните и тяхното записване в excel
                    Do While r.Read
                        c2 = c2 + r.GetString("c2")
                        c3 = c3 + r.GetString("c3")
                        c4 = c4 + r.GetString("c4")
                        c5 = c5 + r.GetString("c5")
                        c6 = c6 + r.GetString("c6")

                        prb1.Value = prb1.Value + 1
                    Loop

                    xlsheet.Cells(4, 1) = "Слаб"
                    xlsheet.Cells(4, 2) = c2
                    xlsheet.Cells(5, 1) = "Среден"
                    xlsheet.Cells(5, 2) = c3
                    xlsheet.Cells(6, 1) = "Добър"
                    xlsheet.Cells(6, 2) = c4
                    xlsheet.Cells(7, 1) = "Много добър"
                    xlsheet.Cells(7, 2) = c5
                    xlsheet.Cells(8, 1) = "Отличен"
                    xlsheet.Cells(8, 2) = c6

                    xlsheet.Range(xlsheet.Cells(3, 1), xlsheet.Cells(8, 3)).HorizontalAlignment = xlCenter
                    chartRange = xlsheet.Range("A4:B8")
                    chartPage.SetSourceData(Source:=chartRange)
                    Dim rng As Microsoft.Office.Interop.Excel.Range
                    rng = xlsheet.Range("A1:B8")
                    Call cellborder(rng)
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
        If cmbYear.Text <> "" Then
            Dim rasEx As String
            rasEx = ""
            'викане на функция RazExcel в койято са записани разширенията на Excel
            Call Module1.RazExcel(rasEx)

            OpenFileDialog1.Filter = rasEx
            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                Try
                    cnn.Open()
                    cnn.Close()
                Catch ex As Exception
                    MsgBox("Грешка в базата данни! ! !")
                    Application.Exit()
                End Try
                cnn.Open()
                Dim pat As String = OpenFileDialog1.FileName
                Dim xlapp As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
                Dim masterWb As Microsoft.Office.Interop.Excel.Workbook
                masterWb = xlapp.Workbooks.Open(pat)
                'задаване на текст в клетки и форматиране на редове и колони
                Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
                xlWorkBook = xlapp.Workbooks.Add
                Dim ws As Microsoft.Office.Interop.Excel.Worksheet

                Try
                    ws = xlWorkBook.Sheets.Add(, xlWorkBook.Sheets(xlWorkBook.Sheets.Count))

                    ws.Name = "Съотношение на оценките по брой"
                    title2 = "Съотношение на оценките по брой за випуск: "
                    title2 = title2 & cmbYearString.Text & " " & cmbClass.Text & ", предмет: " & cmbSubject.Text & ", за вид оценка: " & cmbtype.Text
                    Dim r As MySqlDataReader
                    Dim xldi As Microsoft.Office.Interop.Excel.Chart
                    Dim chartRange As Microsoft.Office.Interop.Excel.Range
                    xldi = New Microsoft.Office.Interop.Excel.Chart

                    Const xlCenter = -4108


                    ws.Range(ws.Cells(1, 1), ws.Cells(1, 2)).Merge()
                    ws.Range(ws.Cells(1, 1), ws.Cells(1, 2)).HorizontalAlignment = xlCenter
                    ws.Cells(1, 1) = title1

                    ws.Range(ws.Cells(2, 1), ws.Cells(2, 2)).Merge()
                    ws.Range(ws.Cells(2, 1), ws.Cells(2, 2)).HorizontalAlignment = xlCenter
                    ws.Range(ws.Cells(2, 1), ws.Cells(2, 2)).WrapText = True

                    ws.Cells(2, 1) = title2
                    ws.Cells(3, 1) = "Oценка"
                    ws.Cells(3, 2) = "Брой"
                    ws.Range(ws.Cells(3, 1), ws.Cells(3, 3)).HorizontalAlignment = xlCenter

                    ws.Range("A3").EntireColumn.ColumnWidth = 24
                    ws.Range("B3").EntireColumn.ColumnWidth = 30
                    ws.Range("A2").EntireRow.RowHeight = 35

                    Dim chartPage As Microsoft.Office.Interop.Excel.Chart
                    Dim xlCharts As Microsoft.Office.Interop.Excel.ChartObjects
                    Dim myChart As Microsoft.Office.Interop.Excel.ChartObject

                    xlCharts = ws.ChartObjects
                    myChart = xlCharts.Add(5, 145, 280, 200)
                    chartPage = myChart.Chart
                    chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlPie
                    'извикване на функция cmdmaxmi, която връща datareader и проверка тя дали е пълна
                    cmdmaxmin(r)
                    If RRowsCount > 0 Then
                        Dim c2, c3, c4, c5, c6 As Integer
                        ' четене на datareader, изчисляване на данните и тяхното записване в excel
                        Do While r.Read
                            c2 = c2 + r.GetString("c2")
                            c3 = c3 + r.GetString("c3")
                            c4 = c4 + r.GetString("c4")
                            c5 = c5 + r.GetString("c5")
                            c6 = c6 + r.GetString("c6")
                            prb1.Value = prb1.Value + 1
                        Loop
                        ws.Cells(4, 1) = "Слаб"
                        ws.Cells(4, 2) = c2
                        ws.Cells(5, 1) = "Среден"
                        ws.Cells(5, 2) = c3
                        ws.Cells(6, 1) = "Добър"
                        ws.Cells(6, 2) = c4
                        ws.Cells(7, 1) = "Много добър"
                        ws.Cells(7, 2) = c5
                        ws.Cells(8, 1) = "Отличен"
                        ws.Cells(8, 2) = c6
                        chartRange = ws.Range("A4:B8")
                        chartPage.SetSourceData(Source:=chartRange)
                        chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlPie
                        ws.Range(ws.Cells(3, 1), ws.Cells(8, 3)).HorizontalAlignment = xlCenter
                        Dim rng As Microsoft.Office.Interop.Excel.Range
                        rng = ws.Range("A1:B8")
                        Call cellborder(rng)
                        chartPage.ApplyDataLabels(Microsoft.Office.Interop.Excel.XlDataLabelsType.xlDataLabelsShowLabel, _
    False, True, False, False, False, True, False, False, False)
                        chartPage.ShowDataLabelsOverMaximum = True
                        '  chartPage.PlotBy = Microsoft.Office.Interop.Excel.XlRowCol.xlRows
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
                    MsgBox("Грешка ! ! !")
                End Try

                cnn.Close()
            End If
        Else
            MsgBox("Трябва да се върнете и да веведете оценки ! ! !", , "Справка")
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
    Private Sub btnWordNewFIle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnWordNewFIle.Click
        If cmbYear.Text <> "" Then
            Dim razWor As String
            razWor = ""
            'викане на функция RazWord в койято са записани разширенията на word
            Call Module1.RazWord(razWor)

            SaveFileDialog1.Filter = razWor
            If SaveFileDialog1.ShowDialog = DialogResult.OK Then
                Try
                    cnn.Open()
                    cnn.Close()
                Catch ex As Exception
                    MsgBox("Грешка в базата данни! ! !")
                    Application.Exit()
                End Try
                cnn.Open()

                Dim pat As String
                pat = SaveFileDialog1.FileName

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
                title2 = "Съотношение на оценките по класове за випуск: "
                title2 = title2 & cmbYearString.Text & " " & cmbClass.Text & ", предмет: " & cmbSubject.Text & ", за вид оценка: " & cmbtype.Text
                oPara2 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
                oPara2.Range.Text = title2
                oPara2.Format.SpaceAfter = 6
                oPara2.Range.InsertParagraphAfter()
                'извикване на функция cmdmaxmi, която връща datareader и проверка тя дали е пълна 
                Dim r As MySqlDataReader
                cmdmaxmin(r)


                If RRowsCount > 0 Then
                    oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, 6, 2)
                    prb1.Value = 0
                    prb1.Maximum = RRowsCount
                    oTable.Cell(1, 1).Range.Text = "Оценка"
                    oTable.Cell(1, 2).Range.Text = "Брой"
                    'четене на datareader, изчисляване на данните и тяхното записване в excel
                    Dim c2, c3, c4, c5, c6 As Integer
                    Do While r.Read
                        c2 = c2 + r.GetString("c2")
                        c3 = c3 + r.GetString("c3")
                        c4 = c4 + r.GetString("c4")
                        c5 = c5 + r.GetString("c5")
                        c6 = c6 + r.GetString("c6")
                        prb1.Value = prb1.Value + 1
                    Loop
                    oTable.Cell(2, 1).Range.Text = "Слаб"
                    oTable.Cell(2, 2).Range.Text = c2
                    oTable.Cell(3, 1).Range.Text = "Среден"
                    oTable.Cell(3, 2).Range.Text = c3
                    oTable.Cell(4, 1).Range.Text = "Добър"
                    oTable.Cell(4, 2).Range.Text = c4
                    oTable.Cell(5, 1).Range.Text = "Много добър"
                    oTable.Cell(5, 2).Range.Text = c5
                    oTable.Cell(6, 1).Range.Text = "Отличен"
                    oTable.Cell(6, 2).Range.Text = c6
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

    Private Sub Reference_VA_Vipusk_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'изтриване на старите сойности в dgv1
        Do While dgv1.RowCount > 0
            dgv1.Rows.Remove(dgv1.Rows(0))
        Loop
        Me.Height = 368
        'Проверка дали chart1 е празно
        If flagbtn = 1 Then
            Chart1.Series.Clear()
            Chart1.Legends.Clear()
            Chart1.Titles.Clear()
            title2 = "Среден успех на класовете за "

        End If

        cmbYearString.Items.Clear()
        cmbYear.Items.Clear()
        cmbtype.Items.Clear()
        cmbIdType.Items.Clear()
        cmbIdType.Items.Add("-1")
        cmbtype.Items.Add("Всички видове")
     
        Do While cmbSubject.Items.Count > 1
            cmbSubject.Items.Remove(cmbSubject.Items(1))
            cmbSubjectId.Items.Remove(cmbSubjectId.Items(1))
        Loop
        prb1.Value = 0
    End Sub

    Private Sub cmbYearString_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYearString.Leave
        If (cmbYearString.SelectedIndex = -1) Then
            cmbYearString.Text = cmbYearString.Items(0)
            cmbYearString.Focus()

        Else
            cmbYear.Text = cmbYear.Items(cmbYearString.SelectedIndex)
            'изтриване на старите сойности в dgv1
            dgv1.Rows.Clear()
            'изтриване на старите сойности в cmbtype и cmbSubject
            Do While cmbtype.Items.Count > 1
                cmbtype.Items.Remove(cmbtype.Items(1))
                'cmbIdType.Items.Remove(cmbIdType.Items(1))
            Loop
            Do While cmbSubject.Items.Count > 1
                cmbSubject.Items.Remove(cmbSubject.Items(1))
                cmbSubjectId.Items.Remove(cmbSubjectId.Items(1))
            Loop
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            Dim brRows, flag As Integer
            brRows = 0
            cmbClass.Items.Clear()
            cmd = New MySqlCommand("Select* from  classes where school_year='" & cmbYear.Text & "' order by grade desc", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            'Проверка дали има въведени класове
            Dim grade As Integer
            If data.Rows.Count > 0 Then
                Dim classesPodr(data.Rows.Count, 2) As Integer
                Dim years As Integer
                brRows = 0
                'обхойдане на таблицата с резултата за класовете и тяхното добавяне в cmbVipusk, cmbClass и cmbYear
                For i As Integer = 1 To data.Rows.Count
                    grade = data.Rows(i - 1).Item("grade")
                    years = data.Rows(i - 1).Item("school_year")
                    flag = 0
                    For j As Integer = 0 To data.Rows.Count
                        If classesPodr(j, 1) = grade And classesPodr(j, 2) = years Then
                            flag = 1
                            j = data.Rows.Count - 1
                        End If
                    Next

                    If flag = 0 Then
                        classesPodr(brRows, 1) = grade
                        classesPodr(brRows, 2) = years
                        brRows = brRows + 1

                    End If
                Next
                brRows = 0
                Do While classesPodr(brRows, 1) <> 0
                    grade = classesPodr(brRows, 1)
                    Dim fdouble As Integer = 0
                    fdouble = 0
                    For i As Integer = 0 To cmbClass.Items.Count - 1
                        If cmbClass.Items(i) = grade Then
                            fdouble = 1
                            Exit For
                        End If
                    Next
                    If fdouble = 0 Then
                        cmbClass.Items.Add(grade)
                    End If
                    brRows = brRows + 1
                Loop
            End If
            'задаване на текст на cmbYear и cmbClass според избрания випуск
            ''  cmbYear.Text = cmbYear.Items(cmbVipusk.SelectedIndex)
            cmbClass.Text = cmbClass.Items(0)
            grade = cmbClass.Text
            years = cmbYear.Text
            'търсене на випуска в таблица classes
            cmd = New MySqlCommand("Select* from  classes where grade='" & grade & "' and school_year='" & years & "'", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable
            adaptre1.Fill(dt)

            Dim brrows2 As Integer = 0
            brRows = 0
            Dim idclass, idtype, IntSubject As Integer
            Dim nType, strSubject As String
            Do While dt.Rows.Count > brRows
                idclass = dt.Rows(brRows).Item("id")
                'Търсене на оценките на випуска според номера на класа
                cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "' order by type", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt1 As DataTable = New DataTable
                adaptre2.Fill(dt1)

                If dt1.Rows.Count > 0 Then
                    brrows2 = 0
                    Dim subflag, subjite, subid As Integer
                    Do While brrows2 < dt1.Rows.Count
                        'добавяне на пердмети вид оценка ако не са били добавени
                        idtype = dt1.Rows(brrows2).Item("type")

                        IntSubject = dt1.Rows(brrows2).Item("subject")
                        cmd = New MySqlCommand("Select* from  subject where id='" & IntSubject & "'", cnn)
                        cmd.ExecuteNonQuery()
                        Dim adaptre30 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                        Dim dt30 As DataTable = New DataTable
                        adaptre30.Fill(dt30)

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

                        cmd = New MySqlCommand("Select* from  types where id='" & idtype & "'", cnn)
                        cmd.ExecuteNonQuery()
                        Dim adaptre3 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                        Dim dt3 As DataTable = New DataTable
                        adaptre3.Fill(dt3)

                        flag = 0
                        nType = dt3.Rows(0).Item("name_type")
                        For j As Integer = 0 To cmbtype.Items.Count - 1
                            If cmbtype.Items(j) = nType Then
                                flag = 1
                                j = cmbtype.Items.Count

                            End If
                        Next
                        If flag = 0 Then
                            cmbtype.Items.Add(nType)
                        End If
                        brrows2 = brrows2 + 1
                    Loop
                    cmbSubject.Text = cmbSubject.Items(0)
                End If
                brRows = brRows + 1
            Loop
            'Добавяне в datagridview редове  
            years = cmbYear.Text
            grade = cmbClass.Text
            cmd = New MySqlCommand("Select* from  classes where school_year='" & years & "'and grade='" & grade & "'", cnn)
            cmd.ExecuteNonQuery()
            Dim adap As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data1 As DataTable = New DataTable
            adap.Fill(data1)

            Dim c2, c3, c4, c5, c6, id, nomer As Integer
            Dim subject, classes As String
            For i As Integer = 0 To data1.Rows.Count - 1
                idclass = data1.Rows(i).Item("id")
                classes = data1.Rows(i).Item("class")
                classes = grade & " " & classes & " " & years & "/" & years Mod 100 + 1
                cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "'", cnn)
                cmd.ExecuteNonQuery()
                Dim adap2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim data2 As DataTable = New DataTable
                adap2.Fill(data2)
                For j As Integer = 0 To data2.Rows.Count - 1
                    c2 = data2.Rows(j).Item("count_2")
                    c3 = data2.Rows(j).Item("count_3")
                    c4 = data2.Rows(j).Item("count_4")
                    c5 = data2.Rows(j).Item("count_5")
                    c6 = data2.Rows(j).Item("count_6")
                    id = data2.Rows(j).Item("id")
                    'задаване на type оценка
                    nomer = data2.Rows(j).Item("type")
                    cmd = New MySqlCommand("Select* from  types where id='" & nomer & "'", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt2 As DataTable = New DataTable
                    adaptre2.Fill(dt2)

                    nType = dt2.Rows(0).Item("name_type")

                    ' задаване на subject
                    nomer = data2.Rows(j).Item("subject")

                    cmd = New MySqlCommand("Select* from  subject where id='" & nomer & "'", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre5 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt3 As DataTable = New DataTable
                    adaptre5.Fill(dt3)

                    subject = dt3.Rows(0).Item("name_subject")
                    'писане в dgv1
                    dgv1.Rows.Add(id, classes, subject, nType, c2, c3, c4, c5, c6)
                Next
            Next
            cnn.Close()
        End If
    End Sub

    Private Sub cmbClass_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClass.Leave
        If (cmbYearString.SelectedIndex = -1) Then
            cmbYearString.Text = cmbYearString.Items(0)
            cmbYearString.Focus()

        Else
            cmbYear.Text = cmbYear.Items(cmbYearString.SelectedIndex)
            'изтриване на старите сойности в dgv1
            dgv1.Rows.Clear()
            'изтриване на старите сойности в cmbtype и cmbSubject
            Do While cmbtype.Items.Count > 1
                cmbtype.Items.Remove(cmbtype.Items(1))
                'cmbIdType.Items.Remove(cmbIdType.Items(1))
            Loop
            Do While cmbSubject.Items.Count > 1
                cmbSubject.Items.Remove(cmbSubject.Items(1))
                cmbSubjectId.Items.Remove(cmbSubjectId.Items(1))
            Loop
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            Dim brRows, flag As Integer
            brRows = 0
            'Проверка дали има въведени класове
            Dim grade As Integer
            'задаване на текст на cmbYear и cmbClass според избрания випуск
            ''  cmbYear.Text = cmbYear.Items(cmbVipusk.SelectedIndex)
            grade = cmbClass.Text
            years = cmbYear.Text
            'търсене на випуска в таблица classes
            cmd = New MySqlCommand("Select* from  classes where grade='" & grade & "' and school_year='" & years & "'", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable
            adaptre1.Fill(dt)

            Dim brrows2 As Integer = 0
            brRows = 0
            Dim idclass, idtype, IntSubject As Integer
            Dim nType, strSubject As String
            Do While dt.Rows.Count > brRows
                idclass = dt.Rows(brRows).Item("id")
                'Търсене на оценките на випуска според номера на класа
                cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "' order by type", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt1 As DataTable = New DataTable
                adaptre2.Fill(dt1)

                If dt1.Rows.Count > 0 Then
                    brrows2 = 0
                    Dim subflag, subjite, subid As Integer
                    Do While brrows2 < dt1.Rows.Count
                        'добавяне на пердмети вид оценка ако не са били добавени
                        idtype = dt1.Rows(brrows2).Item("type")

                        IntSubject = dt1.Rows(brrows2).Item("subject")
                        cmd = New MySqlCommand("Select* from  subject where id='" & IntSubject & "'", cnn)
                        cmd.ExecuteNonQuery()
                        Dim adaptre30 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                        Dim dt30 As DataTable = New DataTable
                        adaptre30.Fill(dt30)

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

                        cmd = New MySqlCommand("Select* from  types where id='" & idtype & "'", cnn)
                        cmd.ExecuteNonQuery()
                        Dim adaptre3 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                        Dim dt3 As DataTable = New DataTable
                        adaptre3.Fill(dt3)

                        flag = 0
                        nType = dt3.Rows(0).Item("name_type")
                        For j As Integer = 0 To cmbtype.Items.Count - 1
                            If cmbtype.Items(j) = nType Then
                                flag = 1
                                j = cmbtype.Items.Count

                            End If
                        Next
                        If flag = 0 Then
                            cmbtype.Items.Add(nType)
                        End If
                        brrows2 = brrows2 + 1
                    Loop
                    cmbSubject.Text = cmbSubject.Items(0)
                End If
                brRows = brRows + 1
            Loop
            'Добавяне в datagridview редове  
            years = cmbYear.Text
            grade = cmbClass.Text
            cmd = New MySqlCommand("Select* from  classes where school_year='" & years & "'and grade='" & grade & "'", cnn)
            cmd.ExecuteNonQuery()
            Dim adap As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data1 As DataTable = New DataTable
            adap.Fill(data1)

            Dim c2, c3, c4, c5, c6, id, nomer As Integer
            Dim subject, classes As String
            For i As Integer = 0 To data1.Rows.Count - 1
                idclass = data1.Rows(i).Item("id")
                classes = data1.Rows(i).Item("class")
                classes = grade & " " & classes & " " & years & "/" & years Mod 100 + 1
                cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "'", cnn)
                cmd.ExecuteNonQuery()
                Dim adap2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim data2 As DataTable = New DataTable
                adap2.Fill(data2)
                For j As Integer = 0 To data2.Rows.Count - 1
                    c2 = data2.Rows(j).Item("count_2")
                    c3 = data2.Rows(j).Item("count_3")
                    c4 = data2.Rows(j).Item("count_4")
                    c5 = data2.Rows(j).Item("count_5")
                    c6 = data2.Rows(j).Item("count_6")
                    id = data2.Rows(j).Item("id")
                    'задаване на type оценка
                    nomer = data2.Rows(j).Item("type")
                    cmd = New MySqlCommand("Select* from  types where id='" & nomer & "'", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt2 As DataTable = New DataTable
                    adaptre2.Fill(dt2)
                    nType = dt2.Rows(0).Item("name_type")
                    ' задаване на subject
                    nomer = data2.Rows(j).Item("subject")
                    cmd = New MySqlCommand("Select* from  subject where id='" & nomer & "'", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre5 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt3 As DataTable = New DataTable
                    adaptre5.Fill(dt3)
                    subject = dt3.Rows(0).Item("name_subject")
                    'писане в dgv1
                    dgv1.Rows.Add(id, classes, subject, nType, c2, c3, c4, c5, c6)
                Next
            Next
            cnn.Close()
        End If
    End Sub
End Class