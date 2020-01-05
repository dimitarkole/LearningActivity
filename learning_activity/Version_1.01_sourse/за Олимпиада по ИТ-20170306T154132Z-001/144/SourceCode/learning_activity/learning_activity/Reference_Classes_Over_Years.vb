'използване на MySQL Data
Imports MySql.Data.MySqlClient
Public Class Reference_Classes_Over_Years
    'деклариране на глобални променливи
    Dim cnn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim years, title1, title2, flagbtn As String
    Dim a, b, RRowsCount As Integer
    Private Sub Reference_Classes_Over_Years_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        flagbtn = 0
        title1 = "Справка"
        title2 = "Успех по паралелки за 2 години: "

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
        Dim type As String
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
                    yearM(brm - 1) = years2
                    brm = brm + 1
                End If
                brRows = brRows + 1
            Loop
            Dim maxy As Integer
            maxy = yearM(0)
            For i As Integer = 1 To brm - 1
                If maxy < yearM(i) Then
                    maxy = yearM(i)
                End If
            Next
            yearM2(1) = maxy
            maxy = maxy - 1
            Dim maxy2 As Integer
            Dim y As String
            maxy2 = maxy
            For j As Integer = 2 To brm - 1
                For i As Integer = 1 To brm - 1
                    If maxy = yearM(i) Then
                        yearM2(j) = maxy
                        maxy = maxy - 1
                        i = brm - 1
                    End If
                Next
            Next
            For j As Integer = 1 To brm - 1
                y = yearM2(j) & "/" & yearM2(j) Mod 100 + 1 & " - " & yearM2(j) - 4 & "/" & yearM2(j) Mod 100 - 3
                cmbYear.Items.Add(y)
                cmbYearid.Items.Add(yearM2(j))
            Next
            cmbYear.Text = cmbYear.Items(0)
            cmbYearid.Text = cmbYearid.Items(0)

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
                If years = cmbYearid.Text Then
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
        If cmbYear.Items.Count > 0 Then
            Call createdgv1()
        End If

        cnn.Close()
    End Sub
    Sub createdgv1()
        Dim pk, y1, c, brrows2, id, nomerdgv1, year, classn As Integer
        Dim scom, classes, classp, subject, count_2, count_3, count_4, count_5, count_6, type, cmbt, cmbs As String
        Dim r As DataTable
        Dim adaptre As MySqlDataAdapter
        cmbs = cmbSubjectId.Text
        cmbt = cmbTypeid.Text

        For i As Integer = 1 To 12
            If i > 0 And i < 5 Then
                pk = 1
            ElseIf i > 4 And i < 8 Then
                pk = 5
            Else : pk = 8
            End If
            y1 = cmbYearid.Text
            c = i
            For j As Integer = i To pk Step -1

                scom = "SELECT purpose.id, classes.grade, classes.class, classes.school_year, count_2, count_3, count_4, count_5, count_6, subject, type FROM classes Inner join purpose"
                If cmbt = -1 Then
                    If cmbs = -1 Then
                        scom = scom & " ON classes.id=purpose.class Where classes.grade='" & c & "'and classes.school_year='" & y1 & " ' order by school_year desc, classes.class asc;"
                    Else
                        scom = scom & " ON classes.id=purpose.class Where purpose.subject='" & cmbs _
                                                      & "'and classes.grade='" & c & "'and classes.school_year='" & y1 & "' order by school_year desc, classes.class asc;"
                    End If
                Else
                    If cmbs = -1 Then
                        scom = scom & " ON classes.id=purpose.class Where purpose.type='" & cmbt _
                                                      & "'and classes.grade='" & c & "'and classes.school_year='" & y1 & "' order by school_year desc, classes.class asc;"
                    Else
                        scom = scom & " ON classes.id=purpose.class Where purpose.type='" & cmbt _
                                                      & "'and purpose.subject='" & cmbs & "classes.grade='" & c & "'and classes.school_year='" & y1 & "'  order by school_year desc, classes.class asc;"
                    End If
                End If
                'задаванена на команда от тип String в променлива coms в зависимост от избрания начин на сортиране
                r = New DataTable
                cmd = New MySqlCommand(scom, cnn)
                cmd.ExecuteNonQuery()
                adaptre = New MySqlDataAdapter(cmd)
                adaptre.Fill(r)
                If r.Rows.Count > 0 Then
                    brrows2 = 0
                    Do While brrows2 < r.Rows.Count
                        id = r.Rows(brrows2).Item("id")
                        year = r.Rows(brrows2).Item("school_year")
                        classn = r.Rows(brrows2).Item("grade")
                        classp = r.Rows(brrows2).Item("class")
                        classes = year & "/" & year Mod 100 + 1 & " " & classn & " " & classp
                        ' задаване на subject
                        nomerdgv1 = r.Rows(brrows2).Item("subject")
                        cmd = New MySqlCommand("Select* from  subject where id='" & nomerdgv1 & "'", cnn)
                        cmd.ExecuteNonQuery()
                        Dim adaptre5 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                        Dim dt3 As DataTable = New DataTable
                        adaptre5.Fill(dt3)
                        subject = dt3.Rows(0).Item("name_subject")
                        'задаване на types
                        nomerdgv1 = r.Rows(brrows2).Item("type")
                        cmd = New MySqlCommand("Select* from  types where id='" & nomerdgv1 & "'", cnn)
                        cmd.ExecuteNonQuery()
                        Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                        Dim dt2 As DataTable = New DataTable
                        adaptre2.Fill(dt2)
                        type = dt2.Rows(0).Item("name_type")
                        'задаване на бройя на двойки, тройки, четворки, петици, шестици
                        count_2 = r.Rows(brrows2).Item("count_2")
                        count_3 = r.Rows(brrows2).Item("count_3")
                        count_4 = r.Rows(brrows2).Item("count_4")
                        count_5 = r.Rows(brrows2).Item("count_5")
                        count_6 = r.Rows(brrows2).Item("count_6")
                        'писане в dgv1
                        dgv1.Rows.Add(id, classes, subject, type, count_2, count_3, count_4, count_5, count_6)
                        brrows2 = brrows2 + 1
                    Loop
                Else
                End If
                y1 = y1 - 1
                c = c - 1
            Next j
        Next i
    End Sub
    Private Sub cmbYear_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYear.Leave, cmbYear.DropDownClosed
        If cmbYear.Items.Count > 0 Then
            If (cmbYear.SelectedIndex = -1) Then
                cmbYear.Text = cmbYear.Items(0)
                cmbYear.Focus()
            Else
                Do While cmbSubject.Items.Count > 1
                    cmbSubject.Items.Remove(cmbSubject.Items(1))
                    cmbSubjectId.Items.Remove(cmbSubjectId.Items(1))
                Loop
                Do While cmbtype.Items.Count > 1
                    cmbtype.Items.Remove(cmbtype.Items(1))
                    cmbTypeid.Items.Remove(cmbTypeid.Items(1))
                Loop
                Do While dgv1.Rows.Count > 0
                    dgv1.Rows.Remove(dgv1.Rows(0))
                Loop
                cmbYearid.Text = cmbYearid.Items(cmbYear.SelectedIndex)
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

                        'проверк дали тази учебна годиня, която е на реда, е същата която е като текст на cmbyear 
                        If years = cmbYearid.Text Then
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
                If cmbYear.Items.Count > 0 Then
                    Call createdgv1()
                End If
                cnn.Close()
            End If
        Else
            cmbYear.Text = ""
        End If
    End Sub
    Private Sub cmbSubject_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubject.Leave, cmbSubject.DropDownClosed
        If (cmbSubject.SelectedIndex = -1) Then
            cmbSubject.Text = cmbSubject.Items(0)
            cmbSubject.Focus()
        Else
            cmbSubjectId.Text = cmbSubjectId.Items(cmbSubject.SelectedIndex)
            Do While cmbtype.Items.Count > 1
                cmbtype.Items.Remove(cmbtype.Items(1))
                cmbTypeid.Items.Remove(cmbTypeid.Items(1))
            Loop
            Do While dgv1.Rows.Count > 0
                dgv1.Rows.Remove(dgv1.Rows(0))
            Loop

            Dim brRows, nomer, flag, britem As Integer
            brRows = 0
            Call Module1.hosts(cnn)
            'Отваряне на връската със SURVER
            cnn.Open()
            If cmbSubjectId.Text = -1 Then
                cmd = New MySqlCommand("Select* from  purpose where school_year='" & cmbYearid.Text & "' order by id", cnn)
            Else
                cmd = New MySqlCommand("Select* from  purpose where school_year='" & cmbYearid.Text & "'and subject='" & cmbSubjectId.Text & "' order by id", cnn)
            End If

            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            'Проверка дли в таблица purpose има записи
            If data.Rows.Count > 0 Then
                brRows = 0
                'ако има записи
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
                    If years = cmbYearid.Text Then
                        'ако е се проверява предмета дали е въведен в cmbSubject и вида оценка в cmbtype
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
            If cmbYear.Items.Count > 0 Then
                Call createdgv1()
            End If
            cnn.Close()
        End If
    End Sub
    Private Sub cmbtype_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtype.Leave, cmbtype.DropDownClosed
        If (cmbtype.SelectedIndex = -1) Then
            cmbtype.Text = cmbtype.Items(0)
            cmbtype.Focus()
        Else
            cmbSubjectId.Text = cmbSubjectId.Items(cmbSubject.SelectedIndex)
            cmbTypeid.Text = cmbTypeid.Items(cmbtype.SelectedIndex)
            Do While dgv1.Rows.Count > 0
                dgv1.Rows.Remove(dgv1.Rows(0))
            Loop
            Dim brRows As Integer
            brRows = 0
            Call Module1.hosts(cnn)
            'Отваряне на връската със SURVER
            cnn.Open()
            If cmbTypeid.Text = -1 Then
                If cmbSubjectId.Text = -1 Then
                    cmd = New MySqlCommand("Select* from  purpose where school_year='" & cmbYearid.Text & "' order by id", cnn)
                Else
                    cmd = New MySqlCommand("Select* from  purpose where school_year='" & cmbYearid.Text & "'and subject='" & cmbSubjectId.Text & "' order by id", cnn)
                End If
            Else
                If cmbSubjectId.Text = -1 Then
                    cmd = New MySqlCommand("Select* from  purpose where school_year='" & cmbYearid.Text & "'and type='" & cmbTypeid.Text & "' order by id", cnn)
                Else
                    cmd = New MySqlCommand("Select* from  purpose where school_year='" & cmbYearid.Text & "'and subject='" & cmbSubjectId.Text & "'and type='" & cmbTypeid.Text & "' order by id", cnn)
                End If
            End If
            'проверка дали има записи в таблица purpose
            If cmbYear.Items.Count > 0 Then
                Call createdgv1()
            End If
            cnn.Close()
        End If
    End Sub

    Private Sub btnchart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnchart.Click
        If cmbYear.Text <> "" Then
           
            'проверка за стойностите в диаграмата и тяхното изтриване
            Chart1.Titles.Clear()
            Chart1.Series.Clear()
            Chart1.Series.Add(cmbYearid.Text & "/" & cmbYearid.Text Mod 100 + 1)
            Chart1.Series.Add(cmbYearid.Text - 1 & "/" & cmbYearid.Text Mod 100)
            Chart1.Series.Add(cmbYearid.Text - 2 & "/" & cmbYearid.Text Mod 100 - 1)
            Chart1.Series.Add(cmbYearid.Text - 3 & "/" & cmbYearid.Text Mod 100 - 2)
            Chart1.Series.Add(cmbYearid.Text - 4 & "/" & cmbYearid.Text Mod 100 - 3)
            Chart1.Legends.Clear()
            Chart1.Legends.Add(0)
            Chart1.ChartAreas.Item(0).AxisX.CustomLabels.Clear()
            title2 = "Паралелките през годините: "
            title2 = title2 & cmbYear.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            Chart1.Titles.Add(title2)
            Dim r As DataTable = New DataTable
            Dim grade As String
            Dim pk, c, y1, brrows, row1, row2, row3, row4, row5 As Integer
            Dim max As Double
            Dim scom, classes As String
            Dim type, subject As Integer
            type = cmbTypeid.Text
            subject = cmbSubjectId.Text
            Dim row As Integer = 0
            Dim y As Integer = cmbYearid.Text
            row1 = 0
            row2 = 0
            row3 = 0
            row4 = 0
            row5 = 0
            Me.Height = 780
            For i As Integer = 1 To 12
                If i > 0 And i < 5 Then
                    pk = 1
                ElseIf i > 4 And i < 8 Then
                    pk = 5
                Else : pk = 8
                End If
                y1 = cmbYearid.Text
                c = i
                For j As Integer = i To pk Step -1

                    If type = -1 Then
                        If subject = -1 Then
                            scom = "SELECT classes.grade, classes.class, classes.school_year, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                                          & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                                          & " ON classes.id=purpose.class Where classes.grade='" & c & "'and classes.school_year='" & y1 & " ' Group by  purpose.class order by " _
                                                          & " school_year desc, classes.class asc;"
                        Else
                            scom = "SELECT classes.grade, classes.class,classes.school_year, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                                          & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                                          & " ON classes.id=purpose.class Where purpose.subject='" & subject _
                                                          & "'and classes.grade='" & c & "'and classes.school_year='" & y1 & "' Group by  purpose.class order by " _
                                                          & " school_year desc, classes.class asc;"
                        End If
                    Else
                        If subject = -1 Then
                            scom = "SELECT classes.grade, classes.class, classes.school_year, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                                          & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                                          & " ON classes.id=purpose.class Where purpose.type='" & type _
                                                          & "'and classes.grade='" & c & "'and classes.school_year='" & y1 & "' Group by  purpose.class order by" _
                                                          & " school_year desc, classes.class asc;"
                        Else
                            scom = "SELECT classes.grade, classes.class, classes.school_year, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                                          & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                                          & " ON classes.id=purpose.class Where purpose.type='" & type _
                                                          & "'and purpose.subject='" & subject & "classes.grade='" & c & "'and classes.school_year='" & y1 & "' Group by  purpose.class order by " _
                                                          & " school_year desc, classes.class asc;"
                        End If
                    End If
                    'задаванена на команда от тип String в променлива coms в зависимост от избрания начин на сортиране
                    r = New DataTable
                    cmd = New MySqlCommand(scom, cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    adaptre.Fill(r)

                    If r.Rows.Count > 0 Then
                        brrows = 0
                        Dim max2 As Double
                        Do While brrows < r.Rows.Count
                            grade = r.Rows(brrows).Item("grade")
                            classes = r.Rows(brrows).Item("class")
                            max = r.Rows(brrows).Item("sreden_uspeh")
                            y1 = r.Rows(brrows).Item("school_year")
                            Dim iditemcuslabel As Integer = 0
                            Dim itemcus As String
                            Dim flag As Integer = 0

                            Do While iditemcuslabel < Chart1.ChartAreas.Item(0).AxisX.CustomLabels.Count
                                itemcus = Chart1.ChartAreas.Item(0).AxisX.CustomLabels(iditemcuslabel).Text
                                If itemcus = i & " " & classes Then
                                    flag = 1
                                    Exit Do
                                End If
                                iditemcuslabel = iditemcuslabel + 1
                            Loop
                            row = iditemcuslabel
                            If flag = 0 Then
                                Chart1.ChartAreas.Item(0).AxisX.CustomLabels.Add(row - 0.5, row + 0.5, i & " " & classes)
                                Chart1.Series(0).Points.AddXY(row, 0.004)
                                Chart1.Series(1).Points.AddXY(row, 0.004)
                                Chart1.Series(2).Points.AddXY(row, 0.004)
                                Chart1.Series(3).Points.AddXY(row, 0.004)
                                Chart1.Series(4).Points.AddXY(row, 0.004)
                            End If
                            max2 = Math.Round(max, 2)
                            Chart1.Series(y - y1).Points(row).SetValueY(max2)
                            Chart1.Series(y - y1).Points(row).Label = max2
                            brrows = brrows + 1
                            row = row + 1
                        Loop
                    Else
                    End If
                    y1 = y1 - 1
                    c = c - 1
                Next j
            Next i
            cnn.Close()
            If Chart1.Series.Count > 0 Then
                Me.Height = 750
            Else
                MsgBox("Трябва да се върнете и да веведете оценки ! ! !", , "Справка")
            End If
        Else
            MsgBox("Трябва да се върнете и да веведете оценки ! ! !", , "Справка")
        End If
    End Sub

    Private Sub btnExselNewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExselNewFile.Click
        If cmbYear.Text <> "" Then
            title2 = "Паралелките през годините: "
            title2 = title2 & cmbYear.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            Dim rasEx As String = ""
            'викане на функция RazExcel в койято са записани разширенията на Excel
            Call Module1.RazExcel(rasEx)
            SaveFileDialog1.Filter = rasEx
            If SaveFileDialog1.ShowDialog = DialogResult.OK Then
                Dim xlapp As Microsoft.Office.Interop.Excel.Application
                Dim xlbook As Microsoft.Office.Interop.Excel.Workbook
                Dim xlsheet As Microsoft.Office.Interop.Excel.Worksheet
                Dim misvalue As Object = System.Reflection.Missing.Value
                xlapp = New Microsoft.Office.Interop.Excel.Application
                xlbook = xlapp.Workbooks.Add(misvalue)
                xlsheet = xlbook.Sheets("sheet1")
                xlsheet.Name = "Паралелките през годините"
                Const xlCenter = -4108
                'задаване на текст в клетки и форматиране на редове и колони
                xlsheet.Range(xlsheet.Cells(1, 1), xlsheet.Cells(1, 6)).Merge()
                xlsheet.Range(xlsheet.Cells(1, 1), xlsheet.Cells(1, 6)).HorizontalAlignment = xlCenter
                xlsheet.Cells(1, 1) = title1
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 6)).Merge()
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 6)).HorizontalAlignment = xlCenter
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 6)).WrapText = True
                xlsheet.Cells(2, 1) = title2
                xlsheet.Cells(3, 1) = "Клас"
                Dim y As String
                y = cmbYearid.Text & "/" & cmbYearid.Text Mod 100 + 1
                xlsheet.Cells(3, 2) = y
                y = cmbYearid.Text - 1 & "/" & cmbYearid.Text Mod 100
                xlsheet.Cells(3, 3) = y
                y = cmbYearid.Text - 2 & "/" & cmbYearid.Text Mod 100 - 1
                xlsheet.Cells(3, 4) = y
                y = cmbYearid.Text - 3 & "/" & cmbYearid.Text Mod 100 - 2
                xlsheet.Cells(3, 5) = y
                y = cmbYearid.Text - 4 & "/" & cmbYearid.Text Mod 100 - 3
                xlsheet.Cells(3, 6) = y
                xlsheet.Range(xlsheet.Cells(3, 1), xlsheet.Cells(3, 6)).HorizontalAlignment = xlCenter
                xlsheet.Range("A3").EntireColumn.ColumnWidth = 20
                xlsheet.Range("B3").EntireColumn.ColumnWidth = 10
                xlsheet.Range("C3").EntireColumn.ColumnWidth = 10
                xlsheet.Range("D3").EntireColumn.ColumnWidth = 10
                xlsheet.Range("E3").EntireColumn.ColumnWidth = 10
                xlsheet.Range("F3").EntireColumn.ColumnWidth = 10
                xlsheet.Range("A2").EntireRow.RowHeight = 35
                Dim pat, bi, ci As String
                pat = SaveFileDialog1.FileName
                bi = "B" & 5
                ci = "B" & 5
                Dim chartPage As Microsoft.Office.Interop.Excel.Chart
                Dim xlCharts As Microsoft.Office.Interop.Excel.ChartObjects
                Dim myChart As Microsoft.Office.Interop.Excel.ChartObject
                Dim chartRange As Microsoft.Office.Interop.Excel.Range
                xlCharts = xlsheet.ChartObjects
                myChart = xlCharts.Add(400, 50, 600, 250)
                chartPage = myChart.Chart
                chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlColumnClustered
                Dim r As DataTable = New DataTable
                Dim c, y1, brrows, br2, type, subject As Integer
                Dim max As Double
                Dim otd, grade, scom, classes, class2, c1 As String
                type = cmbTypeid.Text
                subject = cmbSubjectId.Text
                Dim br As Integer = 4
                prb1.Value = 0
                prb1.Maximum = 11
                For i As Integer = 1 To 12
                    y1 = cmbYearid.Text
                    c = i
                    br2 = br
                    Dim scom1, cy, cy1, cy2, cy3, cy4, scom2 As String
                    scom1 = "SELECT classes.grade, classes.class, classes.school_year, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                & " ON classes.id=purpose.class Where "
                    cy = "classes.grade='" & c & "'and classes.school_year='" & y1
                    cy1 = "classes.grade='" & c - 1 & "'and classes.school_year='" & y1 - 1
                    cy2 = "classes.grade='" & c - 2 & "'and classes.school_year='" & y1 - 2
                    cy3 = "classes.grade='" & c - 3 & "'and classes.school_year='" & y1 - 3
                    cy4 = "classes.grade='" & c - 4 & "'and classes.school_year='" & y1 - 4
                    scom1 = scom1 & cy
                    If c = 2 Or c = 6 Or c = 9 Then
                        scom1 = scom1 & "' or " & cy1
                    ElseIf c = 3 Or c = 7 Or c = 10 Then
                        scom1 = scom1 & "' or " & cy1 & "' or " & cy2
                    ElseIf c = 4 Or c = 11 Then
                        scom1 = scom1 & "' or " & cy1 & "' or " & cy2 & "' or " & cy3

                    ElseIf c = 12 Then
                        scom1 = scom1 & "' or " & cy1 & "' or " & cy2 & "' or " & cy3 & "' or " & cy4
                    End If

                    scom2 = " classes.class asc,school_year desc;"
                    If type = -1 Then
                        If subject = -1 Then
                            scom = scom1 & " 'Group by  purpose.class order by " & scom2
                        Else
                            scom = scom1 & "' purpose.subject='" & subject & "' Group by  purpose.class order by " & scom2
                        End If
                    Else
                        If subject = -1 Then
                            scom = scom1 & "' purpose.type='" & type & "' Group by  purpose.class order by" & scom2
                        Else
                            scom = scom1 & "' purpose.type='" & type & "'and purpose.subject='" & subject & "' Group by  purpose.class order by " & scom2
                        End If
                    End If
                    'задаванена на команда оттип String в променлива coms в зависимост от избрания начин на сортиране
                    r = New DataTable
                    cmd = New MySqlCommand(scom, cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    adaptre.Fill(r)
                    y = cmbYearid.Text
                    If r.Rows.Count > 0 Then
                        brrows = 0
                        c1 = r.Rows(brrows).Item("class")
                        Do While brrows < r.Rows.Count
                            y1 = r.Rows(brrows).Item("school_year")
                            grade = r.Rows(brrows).Item("grade")
                            classes = r.Rows(brrows).Item("class")
                            max = r.Rows(brrows).Item("sreden_uspeh")
                            otd = ""
                            If c1 <> classes Then
                                c1 = classes
                                br = br + 1
                            End If
                            class2 = c & " " & classes
                            xlsheet.Cells(br, 1) = class2
                            If y1 = y Then
                                xlsheet.Cells(br, 2) = max
                            ElseIf y1 = y - 1 Then
                                xlsheet.Cells(br, 3) = max
                            ElseIf y1 = y - 2 Then
                                xlsheet.Cells(br, 4) = max
                            ElseIf y1 = y - 3 Then
                                xlsheet.Cells(br, 5) = max
                            ElseIf y1 = y - 4 Then
                                xlsheet.Cells(br, 6) = max
                            End If
                            xlsheet.Range(xlsheet.Cells(br, 1), xlsheet.Cells(br, 5)).HorizontalAlignment = xlCenter
                            chartRange = xlsheet.Range("A3:F" & br)
                            chartPage.SetSourceData(Source:=chartRange)
                            brrows = brrows + 1
                        Loop
                        br = br + 1
                    Else
                    End If
                    prb1.Value = i - 1
                Next i
                chartPage.HasTitle = True
                chartPage.ChartTitle.Text = xlsheet.Range("A2").Value()
                chartPage.PlotBy = Microsoft.Office.Interop.Excel.XlRowCol.xlColumns
                ' Смаляване на формата
                Me.Height = 365
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

    Private Sub btnExselFIle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExselFIle.Click
        If cmbYear.Text <> "" Then
            'викане на функция RazExcel в койято са записани разширенията на Excel
            Dim rasEx As String
            rasEx = ""
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

                Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
                xlWorkBook = xlapp.Workbooks.Add
                Dim ws As Microsoft.Office.Interop.Excel.Worksheet
                Try
                    'задаване на текст в клетки и форматиране на редове и колони
                    ws = xlWorkBook.Sheets.Add(, xlWorkBook.Sheets(xlWorkBook.Sheets.Count))
                    ws.Name = "Паралелките през годините"
                    title2 = "Паралелките през годините: "
                    title2 = title2 & cmbYear.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
                    Dim r As DataTable
                    Dim xldi As Microsoft.Office.Interop.Excel.Chart
                    xldi = New Microsoft.Office.Interop.Excel.Chart
                    Const xlCenter = -4108
                    'задаване на текст в клетки и форматиране на редове и колони
                    ws.Range(ws.Cells(1, 1), ws.Cells(1, 6)).Merge()
                    ws.Range(ws.Cells(1, 1), ws.Cells(1, 6)).HorizontalAlignment = xlCenter
                    ws.Cells(1, 1) = title1
                    ws.Range(ws.Cells(2, 1), ws.Cells(2, 6)).Merge()
                    ws.Range(ws.Cells(2, 1), ws.Cells(2, 6)).HorizontalAlignment = xlCenter
                    ws.Range(ws.Cells(2, 1), ws.Cells(2, 6)).WrapText = True
                    ws.Cells(2, 1) = title2
                    ws.Cells(3, 1) = "Клас"
                    Dim y As String
                    y = cmbYearid.Text & "/" & cmbYearid.Text Mod 100 + 1
                    ws.Cells(3, 2) = y
                    y = cmbYearid.Text - 1 & "/" & cmbYearid.Text Mod 100
                    ws.Cells(3, 3) = y
                    y = cmbYearid.Text - 2 & "/" & cmbYearid.Text Mod 100 - 1
                    ws.Cells(3, 4) = y
                    y = cmbYearid.Text - 3 & "/" & cmbYearid.Text Mod 100 - 2
                    ws.Cells(3, 5) = y
                    y = cmbYearid.Text - 4 & "/" & cmbYearid.Text Mod 100 - 3
                    ws.Cells(3, 6) = y
                    ws.Range(ws.Cells(3, 1), ws.Cells(3, 6)).HorizontalAlignment = xlCenter
                    ws.Range("A3").EntireColumn.ColumnWidth = 20
                    ws.Range("B3").EntireColumn.ColumnWidth = 10
                    ws.Range("C3").EntireColumn.ColumnWidth = 10
                    ws.Range("D3").EntireColumn.ColumnWidth = 10
                    ws.Range("E3").EntireColumn.ColumnWidth = 10
                    ws.Range("F3").EntireColumn.ColumnWidth = 10
                    ws.Range("A2").EntireRow.RowHeight = 35
                    Dim bi, ci As String
                    bi = "B" & 4
                    ci = "B" & 4
                    Dim chartPage As Microsoft.Office.Interop.Excel.Chart
                    Dim xlCharts As Microsoft.Office.Interop.Excel.ChartObjects
                    Dim myChart As Microsoft.Office.Interop.Excel.ChartObject
                    Dim chartRange As Microsoft.Office.Interop.Excel.Range
                    xlCharts = ws.ChartObjects
                    myChart = xlCharts.Add(400, 50, 600, 250)
                    chartPage = myChart.Chart
                    chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlColumnClustered
                    'извикване на функция cmdmaxmi, която връща datareader и проверка тя дали е пълна
                    Dim classes, class2, otd As String
                    Dim grade, br As Integer
                    Dim max As Double
                    otd = ""
                    br = 4
                    ' четене на datareader, изчисляване на данните и тяхното записване в excel
                    Dim c, y1, brrows, br2, type, subject As Integer
                    Dim scom, c1 As String
                    type = cmbTypeid.Text
                    subject = cmbSubjectId.Text
                    prb1.Value = 0
                    prb1.Maximum = 11
                    For i As Integer = 1 To 12
                        y1 = cmbYearid.Text
                        c = i
                        br2 = br
                        Dim scom1, cy, cy1, cy2, cy3, cy4, scom2 As String
                        scom1 = "SELECT classes.grade, classes.class, classes.school_year, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                    & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                    & " ON classes.id=purpose.class Where "
                        cy = "classes.grade='" & c & "'and classes.school_year='" & y1
                        cy1 = "classes.grade='" & c - 1 & "'and classes.school_year='" & y1 - 1
                        cy2 = "classes.grade='" & c - 2 & "'and classes.school_year='" & y1 - 2
                        cy3 = "classes.grade='" & c - 3 & "'and classes.school_year='" & y1 - 3
                        cy4 = "classes.grade='" & c - 4 & "'and classes.school_year='" & y1 - 4
                        scom1 = scom1 & cy
                        If c = 2 Or c = 6 Or c = 9 Then
                            scom1 = scom1 & "' or " & cy1
                        ElseIf c = 3 Or c = 7 Or c = 10 Then
                            scom1 = scom1 & "' or " & cy1 & "' or " & cy2
                        ElseIf c = 4 Or c = 11 Then
                            scom1 = scom1 & "' or " & cy1 & "' or " & cy2 & "' or " & cy3

                        ElseIf c = 12 Then
                            scom1 = scom1 & "' or " & cy1 & "' or " & cy2 & "' or " & cy3 & "' or " & cy4
                        End If

                        scom2 = " classes.class asc,school_year desc;"
                        If type = -1 Then
                            If subject = -1 Then
                                scom = scom1 & " 'Group by  purpose.class order by " & scom2
                            Else
                                scom = scom1 & "' purpose.subject='" & subject & "' Group by  purpose.class order by " & scom2
                            End If
                        Else
                            If subject = -1 Then
                                scom = scom1 & "' purpose.type='" & type & "' Group by  purpose.class order by" & scom2
                            Else
                                scom = scom1 & "' purpose.type='" & type & "'and purpose.subject='" & subject & "' Group by  purpose.class order by " & scom2
                            End If
                        End If
                        'задаванена на команда оттип String в променлива coms в зависимост от избрания начин на сортиране
                        r = New DataTable
                        cmd = New MySqlCommand(scom, cnn)
                        cmd.ExecuteNonQuery()
                        Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                        adaptre.Fill(r)
                        y = cmbYearid.Text
                        If r.Rows.Count > 0 Then
                            brrows = 0
                            c1 = r.Rows(brrows).Item("class")
                            Do While brrows < r.Rows.Count
                                y1 = r.Rows(brrows).Item("school_year")
                                grade = r.Rows(brrows).Item("grade")
                                classes = r.Rows(brrows).Item("class")
                                max = r.Rows(brrows).Item("sreden_uspeh")
                                otd = ""
                                If c1 <> classes Then
                                    c1 = classes
                                    br = br + 1
                                End If
                                class2 = c & " " & classes
                                ws.Cells(br, 1) = class2
                                If y1 = y Then
                                    ws.Cells(br, 2) = max
                                ElseIf y1 = y - 1 Then
                                    ws.Cells(br, 3) = max
                                ElseIf y1 = y - 2 Then
                                    ws.Cells(br, 4) = max
                                ElseIf y1 = y - 3 Then
                                    ws.Cells(br, 5) = max
                                ElseIf y1 = y - 4 Then
                                    ws.Cells(br, 6) = max
                                End If
                                ws.Range(ws.Cells(br, 1), ws.Cells(br, 5)).HorizontalAlignment = xlCenter
                                chartRange = ws.Range("A3:F" & br)
                                chartPage.SetSourceData(Source:=chartRange)
                                brrows = brrows + 1
                            Loop
                            br = br + 1
                        Else
                        End If
                        prb1.Value = i - 1
                    Next i
                    chartPage.HasTitle = True
                    chartPage.ChartTitle.Text = ws.Range("A2").Value()
                    chartPage.PlotBy = Microsoft.Office.Interop.Excel.XlRowCol.xlColumns
                    ws.Copy(, masterWb.Sheets(masterWb.Sheets.Count))
                    ws = Nothing
                    xlWorkBook.Save()
                    xlWorkBook.Close()
                    xlWorkBook = Nothing
                    'Смаляване на формата
                    Me.Height = 365
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
                Catch ex As Exception
                    MsgBox("ERROR- " & ex.Message)
                End Try

                cnn.Close()
            End If
        Else
            MsgBox("Трябва да се върнете и да веведете оценки ! ! !", , "Справка")
        End If
    End Sub

    Private Sub btnWordNewFIle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWordNewFIle.Click
        If cmbYear.Text <> "" Then
            'викане на функция RazWord в койято са записани разширенията на word
            Dim razWor As String
            razWor = ""
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
                oDoc = oWord.Documents.Add
                'задаване на текст, вкарваненатаблица и нейното форматиране
                oPara1 = oDoc.Content.Paragraphs.Add
                oPara1.Range.Font.Size = 20
                oPara1.Range.Font.Bold = True
                oPara1.Range.Text = title1
                oPara1.Alignment = HorizontalAlignment.Right
                oPara1.Format.SpaceAfter = 24
                oPara1.Range.InsertParagraphAfter()
                title2 = "Паралелките през годините: "
                title2 = title2 & cmbYear.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
                oPara2 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
                oPara2.Range.Text = title2
                oPara2.Format.SpaceAfter = 6
                oPara2.Range.InsertParagraphAfter()
                Dim r As DataTable
                Dim m(85, 5) As String

                Dim classes, otd As String
                Dim grade, br As Integer
                Dim max As Double
                otd = ""
                br = 0
                prb1.Value = 0
                Dim y As String
                prb1.Maximum = RRowsCount
                'четене на datareader, изчисляване на данните и тяхното записване в excel
                Dim c, y1, brrows, br2, type, subject As Integer
                Dim scom, c1, class2 As String
                type = cmbTypeid.Text
                subject = cmbSubjectId.Text
                prb1.Value = 0
                prb1.Maximum = 11
                For i As Integer = 1 To 12
                    y1 = cmbYearid.Text
                    c = i
                    br2 = br
                    Dim scom1, cy, cy1, cy2, cy3, cy4, scom2 As String
                    scom1 = "SELECT classes.grade, classes.class, classes.school_year, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                & " ON classes.id=purpose.class Where "
                    cy = "classes.grade='" & c & "'and classes.school_year='" & y1
                    cy1 = "classes.grade='" & c - 1 & "'and classes.school_year='" & y1 - 1
                    cy2 = "classes.grade='" & c - 2 & "'and classes.school_year='" & y1 - 2
                    cy3 = "classes.grade='" & c - 3 & "'and classes.school_year='" & y1 - 3
                    cy4 = "classes.grade='" & c - 4 & "'and classes.school_year='" & y1 - 4
                    scom1 = scom1 & cy
                    If c = 2 Or c = 6 Or c = 9 Then
                        scom1 = scom1 & "' or " & cy1
                    ElseIf c = 3 Or c = 7 Or c = 10 Then
                        scom1 = scom1 & "' or " & cy1 & "' or " & cy2
                    ElseIf c = 4 Or c = 11 Then
                        scom1 = scom1 & "' or " & cy1 & "' or " & cy2 & "' or " & cy3

                    ElseIf c = 12 Then
                        scom1 = scom1 & "' or " & cy1 & "' or " & cy2 & "' or " & cy3 & "' or " & cy4
                    End If

                    scom2 = " classes.class asc,school_year desc;"
                    If type = -1 Then
                        If subject = -1 Then
                            scom = scom1 & " 'Group by  purpose.class order by " & scom2
                        Else
                            scom = scom1 & "' purpose.subject='" & subject & "' Group by  purpose.class order by " & scom2
                        End If
                    Else
                        If subject = -1 Then
                            scom = scom1 & "' purpose.type='" & type & "' Group by  purpose.class order by" & scom2
                        Else
                            scom = scom1 & "' purpose.type='" & type & "'and purpose.subject='" & subject & "' Group by  purpose.class order by " & scom2
                        End If
                    End If
                    'задаванена на команда оттип String в променлива coms в зависимост от избрания начин на сортиране
                    r = New DataTable
                    cmd = New MySqlCommand(scom, cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    adaptre.Fill(r)
                    y = cmbYearid.Text
                    If r.Rows.Count > 0 Then
                        brrows = 0
                        c1 = r.Rows(brrows).Item("class")
                        Do While brrows < r.Rows.Count
                            y1 = r.Rows(brrows).Item("school_year")
                            grade = r.Rows(brrows).Item("grade")
                            classes = r.Rows(brrows).Item("class")
                            max = r.Rows(brrows).Item("sreden_uspeh")
                            otd = ""
                            If c1 <> classes Then
                                c1 = classes
                                br = br + 1
                            End If
                            class2 = c & " " & classes
                            m(br, 0) = class2
                            If y1 = y Then
                                m(br, 1) = max
                            ElseIf y1 = y - 1 Then
                                m(br, 2) = max
                            ElseIf y1 = y - 2 Then
                                m(br, 3) = max
                            ElseIf y1 = y - 3 Then
                                m(br, 4) = max
                            ElseIf y1 = y - 4 Then
                                m(br, 5) = max
                            End If
                         
                            brrows = brrows + 1
                        Loop
                        br = br + 1
                    Else
                    End If
                    prb1.Value = i - 1
                Next i
                oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, 1, 6)
                oTable.Cell(1, 1).Range.Text = "Клас"
                y = cmbYearid.Text & "/" & cmbYearid.Text Mod 100 + 1
                oTable.Cell(1, 2).Range.Text = y
                y = cmbYearid.Text - 1 & "/" & cmbYearid.Text Mod 100
                oTable.Cell(1, 3).Range.Text = y
                y = cmbYearid.Text - 2 & "/" & cmbYearid.Text Mod 100 - 1
                oTable.Cell(1, 4).Range.Text = y
                y = cmbYearid.Text - 3 & "/" & cmbYearid.Text Mod 100 - 2
                oTable.Cell(1, 5).Range.Text = y
                y = cmbYearid.Text - 4 & "/" & cmbYearid.Text Mod 100 - 3
                oTable.Cell(1, 6).Range.Text = y
                Dim br3 As Integer = 0
                Do While m(br3, 0) <> ""
                    oTable.Rows.Add()
                    oTable.Cell(br3 + 2, 1).Range.Text = m(br3, 0)
                    oTable.Cell(br3 + 2, 2).Range.Text = m(br3, 1)
                    oTable.Cell(br3 + 2, 3).Range.Text = m(br3, 2)
                    oTable.Cell(br3 + 2, 4).Range.Text = m(br3, 3)
                    oTable.Cell(br3 + 2, 5).Range.Text = m(br3, 4)
                    oTable.Cell(br3 + 2, 6).Range.Text = m(br3, 5)
                    br3 = br3 + 1
                Loop
                'форматиране на таблицата
                oTable.Rows.Item(1).Range.Font.Bold = True
                oTable.Range.Style = "Table Grid"
                'смаляване на формата
                Me.Height = 365
                oDoc.SaveAs2(pat)

                oDoc.Close()
                'питане дали да се отвори файла
                Dim res As MsgBoxResult
                res = MsgBox("Искате ли файлът да се отвори?", MsgBoxStyle.YesNo, "Справка")
                If res = MsgBoxResult.Yes Then
                    Process.Start(pat)
                End If

                cnn.Close()
            End If
        Else
            MsgBox("Трябва да се върнете и да веведете оценки ! ! !", , "Справка")
        End If
    End Sub

    Private Sub Reference_Classes_Over_Years_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'изтриване на старите сойности в dgv1
        Do While dgv1.RowCount > 0
            dgv1.Rows.Remove(dgv1.Rows(0))
        Loop
        Me.Height = 383
        'Проверка дали chart1 е празно и  изтриване настъойностите му
     
                Chart1.Series.Clear()
                Chart1.Legends.Clear()


        If Chart1.Titles.Count > 0 Then
            Chart1.Titles.Remove(Chart1.Titles.Item(0))
        End If
        Do While cmbYear.Items.Count > 0
            cmbYearid.Items.Remove(cmbYearid.Items(0))
            cmbYear.Items.Remove(cmbYear.Items(0))
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
End Class

