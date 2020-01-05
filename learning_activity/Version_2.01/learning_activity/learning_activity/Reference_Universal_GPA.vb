'използване на MySQL Data
Imports MySql.Data.MySqlClient
Public Class Reference_Universal_GPA
    'деклариране на глобални променливи
    Dim cnn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim years, title1, title2, flagbtn As String
    Dim a, b, RRowsCount As Integer
    Private Sub Reference_Universal_GPA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Отваряне на връската със SURVER
        Call Module1.hosts(cnn)
        cnn.Open()
        Dim brRows, flag As Integer
        brRows = 0
        title1 = "Справка"
        title2 = "Випуските през годините: "

        cmd = New MySqlCommand("Select* from  classes order by school_year desc, grade desc, class desc;", cnn)
        cmd.ExecuteNonQuery()
        Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
        Dim data As DataTable = New DataTable
        adaptre.Fill(data)
        'Проверка дaли в таблица purpose има записи
        If data.Rows.Count > 0 Then
            'ако има записи
            Dim classesPodr(data.Rows.Count, 2) As Integer
            Dim years, grade, brparal As Integer
            Dim paral(10), paralelka As String
            brRows = 0
            brparal = 0
            'минаване през всчики редове на таблица purpose
            For i As Integer = 1 To data.Rows.Count
                'Селактиране на номера на класа на ред
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
                paralelka = data.Rows(i - 1).Item("class")
                flag = 0
                For j As Integer = 0 To 10
                    If paral(j) = paralelka Then
                        flag = 1
                        Exit For
                    End If
                Next
                If flag = 0 Then
                    paral(brparal) = paralelka
                    brparal = brparal + 1
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
                    cmbYearString.Items.Add(yeardo)
                End If

                fdouble = 0
                For i As Integer = 1 To cmbClass.Items.Count - 1
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
            brRows = 0
            Do While brRows < brparal

                paralelka = paral(brRows)
                Dim fdouble As Integer = 0
                For i As Integer = 0 To cmbParal.Items.Count - 1
                    If cmbParal.Items(i) = paralelka Then
                        fdouble = 1
                        Exit For
                    End If
                Next
                If fdouble = 0 Then
                    cmbParal.Items.Add(paralelka)
                End If
                brRows = brRows + 1
            Loop
            'задаване на текст на cmbtaта
            cmbYearString.Text = cmbYearString.Items(0)
            cmbClass.Text = cmbClass.Items(0)
            cmbYear.Text = cmbYear.Items(0)
            cmd = New MySqlCommand("Select* from profiles order by id;", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable
            adaptre1.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 1 To dt.Rows.Count
                    cmbProfilId.Items.Add(dt.Rows(i - 1).Item("id"))
                    cmbProfil.Items.Add(dt.Rows(i - 1).Item("name_profile"))
                Next
            End If
            'задаване на текст на cmbtaта
            cmbProfil.Text = cmbProfil.Items(0)
            cmbProfilId.Text = cmbProfilId.Items(0)
            cmd = New MySqlCommand("Select* from subject order by name_subject asc;", cnn)
            cmd.ExecuteNonQuery()
            adaptre1 = New MySqlDataAdapter(cmd)
            dt = New DataTable
            adaptre1.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 1 To dt.Rows.Count
                    cmbSubjectId.Items.Add(dt.Rows(i - 1).Item("id"))
                    cmbSubject.Items.Add(dt.Rows(i - 1).Item("name_subject"))
                Next
            End If
            'задаване на текст на cmbtaта
            cmbProfil.Text = cmbProfil.Items(0)
            cmbProfilId.Text = cmbProfilId.Items(0)
            cmd = New MySqlCommand("Select* from teachers;", cnn)
            cmd.ExecuteNonQuery()
            adaptre1 = New MySqlDataAdapter(cmd)
            dt = New DataTable
            adaptre1.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 1 To dt.Rows.Count
                    cmbTeachid.Items.Add(dt.Rows(i - 1).Item("id"))
                    cmbTeach.Items.Add(dt.Rows(i - 1).Item("name_teacher") & " " & dt.Rows(i - 1).Item("family_teacher"))
                Next
            End If
            'задаване на текст на cmbtaта
            cmbTeach.Text = cmbTeach.Items(0)
            cmbTeachid.Text = cmbTeachid.Items(0)

            cmd = New MySqlCommand("Select* from purpose;", cnn)

            cmd.ExecuteNonQuery()
            adaptre1 = New MySqlDataAdapter(cmd)
            dt = New DataTable
            adaptre1.Fill(dt)


            For i As Integer = 1 To dt.Rows.Count
                cmd = New MySqlCommand("Select* from types where id=" & dt.Rows(i - 1).Item("type") & ";", cnn)
                cmd.ExecuteNonQuery()
                adaptre = New MySqlDataAdapter(cmd)
                data = New DataTable
                adaptre.Fill(data)
                Dim f As Integer

                If dt.Rows.Count > 0 Then
                    Call searchtype(data.Rows(0).Item("name_type"), f)
                    If f = 0 Then
                        cmbTypeid.Items.Add(data.Rows(0).Item("id"))
                        cmbtype.Items.Add(data.Rows(0).Item("name_type"))
                    End If
                End If
            Next
        End If
        ' пълнене на dgv1
        Call create_dgv()
        cnn.Close()
    End Sub

    Function searchtype(ByVal typestr As String, ByRef flag As Integer)
        flag = 0
        For i As Integer = 0 To cmbtype.Items.Count - 1
            If cmbtype.Items(i) = typestr Then
                flag = 1
                Exit For
            End If
        Next
        Return flag
    End Function

    Sub create_dgv()
        If cmbYear.Text <> "" Then
            Dim scom As String
            Dim year, id As Integer
            Dim count_2, count_3, count_4, count_5, count_6, cmbt, cmbs As String
            cmbs = cmbSubjectId.Text
            cmbt = cmbTypeid.Text
            year = cmbYear.Text
            scom = "SELECT purpose.id, classes.grade, classes.class, classes.school_year, count_2, count_3, count_4, count_5, count_6, subject, type FROM classes Inner join purpose ON classes.id=purpose.class Where"
            Dim f As Integer = 0
            If cmbt <> -1 Then
                scom = scom & " purpose.type='" & cmbt
                f = 1
            End If
            If cmbs <> -1 Then
                If f = 1 Then
                    scom = scom & "' and"
                End If
                scom = scom & " purpose.subject='" & cmbs
                f = 1
            End If
            If f = 1 Then
                scom = scom & "' and"
            End If
            scom = scom & " classes.school_year='" & year
            If cmbClass.Text <> cmbClass.Items(0) Then
                scom = scom & "' and classes.grade='" & cmbClass.Text
            End If
            If cmbParal.Text <> cmbParal.Items(0) Then
                scom = scom & "' and classes.class='" & cmbParal.Text
            End If
            If cmbProfil.Text <> cmbProfil.Items(0) Then
                scom = scom & "' and classes.profile='" & cmbProfilId.Text
            End If
            If cmbSubject.Text <> cmbSubject.Items(0) Then
                scom = scom & "' and purpose.subject='" & cmbSubjectId.Text
            End If
            '!!!!!
            scom = scom & "'  order by school_year desc, classes.grade asc,classes.class asc;"
            '!!!!!
            '!!!!!
            TextBox1.Text = scom
            cmd = New MySqlCommand(scom, cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            If data.Rows.Count > 0 Then
                Dim paral, subjectstr, profilstr, teacher, typestr As String
                TextBox1.Text = scom
                Dim yearstr As String = year & "/" & year Mod 100 + 1
                Dim idobject, classint, idclass, subjectid As Short
                For i As Integer = 1 To data.Rows.Count
                    'задаване на код, клас и паралелка
                    id = data.Rows(i - 1).Item("id")
                    classint = data.Rows(i - 1).Item("grade")
                    paral = data.Rows(i - 1).Item("class")
                    'задаване на предмет
                    idobject = data.Rows(i - 1).Item("subject")
                    scom = "SELECT* from subject where id='" & idobject & "';"
                    cmd = New MySqlCommand(scom, cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt As DataTable = New DataTable
                    adaptre1.Fill(dt)
                    subjectstr = dt.Rows(0).Item("name_subject")
                    If subjectstr = cmbSubject.Text Or cmbSubject.Text = cmbSubject.Items(0) Then
                        subjectid = data.Rows(i - 1).Item("subject")
                        'задаване на профил
                        scom = "SELECT* from classes where school_year='" & year & "' and grade='" & classint & "' and class='" & paral & "';"
                        cmd = New MySqlCommand(scom, cnn)
                        cmd.ExecuteNonQuery()
                        adaptre1 = New MySqlDataAdapter(cmd)
                        dt = New DataTable
                        adaptre1.Fill(dt)
                        idobject = dt.Rows(0).Item("profile")
                        idclass = dt.Rows(0).Item("id")
                        scom = "SELECT* from profiles where id='" & idobject & "';"
                        cmd = New MySqlCommand(scom, cnn)
                        cmd.ExecuteNonQuery()
                        adaptre1 = New MySqlDataAdapter(cmd)
                        dt = New DataTable
                        adaptre1.Fill(dt)
                        profilstr = dt.Rows(0).Item("name_profile")
                        If cmbProfil.Text = profilstr Or cmbProfil.Text = cmbProfil.Items(0) Then

                            'задаване на учител
                            scom = "SELECT* from teaching where subject='" & subjectid & "' and class='" & idclass & "';"
                            cmd = New MySqlCommand(scom, cnn)
                            cmd.ExecuteNonQuery()
                            adaptre1 = New MySqlDataAdapter(cmd)
                            dt = New DataTable
                            adaptre1.Fill(dt)
                            If dt.Rows.Count > 0 Then
                                idobject = dt.Rows(0).Item("teacher")
                                scom = "SELECT* from teachers where id='" & idobject & "';"
                                cmd = New MySqlCommand(scom, cnn)
                                cmd.ExecuteNonQuery()
                                adaptre1 = New MySqlDataAdapter(cmd)
                                dt = New DataTable
                                adaptre1.Fill(dt)
                                teacher = dt.Rows(0).Item("name_teacher") & " " & dt.Rows(0).Item("family_teacher")
                            Else
                                teacher = "Не е въведен"
                            End If

                            If teacher = cmbTeach.Text Or cmbTeach.Text = cmbTeach.Items(0) Then
                                'задаване на тип
                                idobject = data.Rows(0).Item("type")
                                scom = "SELECT* from types where id='" & idobject & "';"
                                cmd = New MySqlCommand(scom, cnn)
                                cmd.ExecuteNonQuery()
                                adaptre1 = New MySqlDataAdapter(cmd)
                                dt = New DataTable
                                adaptre1.Fill(dt)
                                typestr = dt.Rows(0).Item("name_type")
                                If typestr = cmbtype.Text Or cmbtype.Text = cmbtype.Items(0) Then
                                    'задаване на оценки
                                    count_2 = data.Rows(i - 1).Item("count_2")
                                    count_3 = data.Rows(i - 1).Item("count_3")
                                    count_4 = data.Rows(i - 1).Item("count_4")
                                    count_5 = data.Rows(i - 1).Item("count_5")
                                    count_6 = data.Rows(i - 1).Item("count_6")
                                    dgv1.Rows.Add(id, yearstr, classint, paral, profilstr, subjectstr, teacher, typestr, count_2, count_3, count_4, count_5, count_6) ', 'classes, subject, type, count_2, count_3, count_4, count_5, count_6)

                                End If
                            End If
                        End If
                    End If


                Next
            Else
                MsgBox("По тези критерии няма оценки! ! !", , "Универсална спавка")
            End If

        End If
    End Sub

    Sub clearCalss()

        Do While cmbClass.Items.Count > 1
            cmbClass.Items.Remove(cmbClass.Items(1))
        Loop
    End Sub

    Sub clearParal()
        Do While cmbParal.Items.Count > 1
            cmbParal.Items.Remove(cmbParal.Items(1))
        Loop
    End Sub

    Sub clearProfile()
        Do While cmbProfil.Items.Count > 1
            cmbProfil.Items.Remove(cmbProfil.Items(1))
            cmbProfilId.Items.Remove(cmbProfilId.Items(1))
        Loop
    End Sub

    Sub clearSubject()
        Do While cmbSubject.Items.Count > 1
            cmbSubject.Items.Remove(cmbSubject.Items(1))
            cmbSubjectId.Items.Remove(cmbSubjectId.Items(1))
        Loop
    End Sub

    Sub clearteach()
        Do While cmbTeach.Items.Count > 1
            cmbTeach.Items.Remove(cmbTeach.Items(1))
            cmbTeachid.Items.Remove(cmbTeachid.Items(1))
        Loop
    End Sub

    Sub clearType()
        Do While cmbtype.Items.Count > 1
            cmbtype.Items.Remove(cmbtype.Items(1))
            cmbTypeid.Items.Remove(cmbTypeid.Items(1))
        Loop
    End Sub

    Private Sub cmbYearString_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYearString.Leave, cmbYearString.DropDownClosed
        If (cmbYearString.SelectedIndex = -1) Then
            cmbYearString.Text = cmbYearString.Items(0)
            cmbYearString.Focus()
        Else
            cmbYear.Text = cmbYear.Items(cmbYearString.SelectedIndex)
            Call clearCalss()
            Call clearParal()
            Call clearProfile()
            Call clearSubject()
            Call clearteach()
            Call clearType()
            dgv1.Rows.Clear()
            'Отваряне на връската със SURVER
            cnn.Open()
            Dim brRows, flag As Integer
            brRows = 0
            title1 = "Справка"
            title2 = "Випуските през годините: "
            cmd = New MySqlCommand("Select* from  classes where school_year='" & cmbYear.Text & "' order by grade desc, class desc;", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            'Проверка дaли в таблица purpose има записи
            If data.Rows.Count > 0 Then
                'ако има записи
                Dim classesPodr(data.Rows.Count, 2) As Integer
                Dim years, grade, brparal As Integer
                Dim paral(10), paralelka As String
                brRows = 0
                brparal = 0
                'минаване през всчики редове на таблица purpose
                For i As Integer = 1 To data.Rows.Count
                    'Селактиране на номера на класа на ред
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
                    paralelka = data.Rows(i - 1).Item("class")
                    flag = 0
                    For j As Integer = 0 To 10
                        If paral(j) = paralelka Then
                            flag = 1
                            Exit For
                        End If
                    Next
                    If flag = 0 Then
                        paral(brparal) = paralelka
                        brparal = brparal + 1
                    End If
                Next
                brRows = 0
                Do While classesPodr(brRows, 1) <> 0
                    grade = classesPodr(brRows, 1)
                    years = classesPodr(brRows, 2)

                    Dim fdouble As Integer = 0
                    For i As Integer = 1 To cmbClass.Items.Count - 1
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
                brRows = 0
                Do While brRows < brparal

                    paralelka = paral(brRows)
                    Dim fdouble As Integer = 0
                    For i As Integer = 0 To cmbParal.Items.Count - 1
                        If cmbParal.Items(i) = paralelka Then
                            fdouble = 1
                            Exit For
                        End If
                    Next
                    If fdouble = 0 Then
                        cmbParal.Items.Add(paralelka)
                    End If
                    brRows = brRows + 1
                Loop
                'задаване на текст на cmbtaта
                cmbClass.Text = cmbClass.Items(0)
                cmd = New MySqlCommand("Select* from profiles order by id;", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt As DataTable = New DataTable
                adaptre1.Fill(dt)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 1 To dt.Rows.Count
                        cmbProfilId.Items.Add(dt.Rows(i - 1).Item("id"))
                        cmbProfil.Items.Add(dt.Rows(i - 1).Item("name_profile"))
                    Next
                End If
                'задаване на текст на cmbtaта
                cmbProfil.Text = cmbProfil.Items(0)
                cmbProfilId.Text = cmbProfilId.Items(0)
                cmd = New MySqlCommand("Select* from subject order by name_subject asc;", cnn)
                cmd.ExecuteNonQuery()
                adaptre1 = New MySqlDataAdapter(cmd)
                dt = New DataTable
                adaptre1.Fill(dt)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 1 To dt.Rows.Count
                        cmbSubjectId.Items.Add(dt.Rows(i - 1).Item("id"))
                        cmbSubject.Items.Add(dt.Rows(i - 1).Item("name_subject"))
                    Next
                End If
                'задаване на текст на cmbtaта
                cmbProfil.Text = cmbProfil.Items(0)
                cmbProfilId.Text = cmbProfilId.Items(0)
                cmd = New MySqlCommand("Select* from teachers;", cnn)
                cmd.ExecuteNonQuery()
                adaptre1 = New MySqlDataAdapter(cmd)
                dt = New DataTable
                adaptre1.Fill(dt)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 1 To dt.Rows.Count
                        cmbTeachid.Items.Add(dt.Rows(i - 1).Item("id"))
                        cmbTeach.Items.Add(dt.Rows(i - 1).Item("name_teacher") & " " & dt.Rows(i - 1).Item("family_teacher"))
                    Next
                End If
                'задаване на текст на cmbtaта
                cmbTeach.Text = cmbTeach.Items(0)
                cmbTeachid.Text = cmbTeachid.Items(0)

                cmd = New MySqlCommand("Select* from purpose;", cnn)

                cmd.ExecuteNonQuery()
                adaptre1 = New MySqlDataAdapter(cmd)
                dt = New DataTable
                adaptre1.Fill(dt)


                For i As Integer = 1 To dt.Rows.Count
                    cmd = New MySqlCommand("Select* from types where id=" & dt.Rows(i - 1).Item("type") & ";", cnn)
                    cmd.ExecuteNonQuery()
                    adaptre = New MySqlDataAdapter(cmd)
                    data = New DataTable
                    adaptre.Fill(data)
                    Dim f As Integer

                    If dt.Rows.Count > 0 Then
                        Call searchtype(data.Rows(0).Item("name_type"), f)
                        If f = 0 Then
                            cmbTypeid.Items.Add(data.Rows(0).Item("id"))
                            cmbtype.Items.Add(data.Rows(0).Item("name_type"))
                        End If
                    End If
                Next
            End If
            ' пълнене на dgv1
            Call create_dgv()
            cnn.Close()
        End If
    End Sub

    Private Sub cmbClass_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClass.Leave, cmbClass.DropDownClosed
        If (cmbClass.SelectedIndex = -1) Then
            cmbClass.Text = cmbClass.Items(0)
            cmbClass.Focus()
        Else
            Call clearParal()
            Call clearProfile()
            Call clearSubject()
            Call clearteach()
            Call clearType()
            dgv1.Rows.Clear()
            'Отваряне на връската със SURVER
            cnn.Open()
            Dim brRows, flag As Integer
            brRows = 0
            title1 = "Справка"
            title2 = "Випуските през годините: "
            Dim scmb As String
            scmb = "Select* from  classes where school_year='" & cmbYear.Text
            If cmbClass.Text <> cmbClass.Items(0) Then
                scmb = scmb & "' and grade='" & cmbClass.Text
            End If
            scmb = scmb & "' order by class desc;"
            cmd = New MySqlCommand(scmb, cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            'Проверка дaли в таблица purpose има записи
            If data.Rows.Count > 0 Then
                'ако има записи
                Dim classesPodr(data.Rows.Count, 2) As Integer
                Dim brparal As Integer
                Dim paral(10), paralelka As String
                brRows = 0
                brparal = 0
                'минаване през всчики редове на таблица purpose
                For i As Integer = 1 To data.Rows.Count
                    'Селактиране на номера на класа на ред
                    paralelka = data.Rows(i - 1).Item("class")
                    flag = 0
                    For j As Integer = 0 To 10
                        If paral(j) = paralelka Then
                            flag = 1
                            Exit For
                        End If
                    Next
                    If flag = 0 Then
                        paral(brparal) = paralelka
                        brparal = brparal + 1
                    End If
                Next
                brRows = 0
                Do While brRows < brparal
                    paralelka = paral(brRows)
                    Dim fdouble As Integer = 0
                    For i As Integer = 0 To cmbParal.Items.Count - 1
                        If cmbParal.Items(i) = paralelka Then
                            fdouble = 1
                            Exit For
                        End If
                    Next
                    If fdouble = 0 Then
                        cmbParal.Items.Add(paralelka)
                    End If
                    brRows = brRows + 1
                Loop
                'задаване на текст на cmbtaта
                cmd = New MySqlCommand("Select* from profiles order by id;", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt As DataTable = New DataTable
                adaptre1.Fill(dt)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 1 To dt.Rows.Count
                        cmbProfilId.Items.Add(dt.Rows(i - 1).Item("id"))
                        cmbProfil.Items.Add(dt.Rows(i - 1).Item("name_profile"))
                    Next
                End If
                'задаване на текст на cmbtaта
                cmbProfil.Text = cmbProfil.Items(0)
                cmbProfilId.Text = cmbProfilId.Items(0)
                cmd = New MySqlCommand("Select* from subject order by name_subject asc;", cnn)
                cmd.ExecuteNonQuery()
                adaptre1 = New MySqlDataAdapter(cmd)
                dt = New DataTable
                adaptre1.Fill(dt)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 1 To dt.Rows.Count
                        cmbSubjectId.Items.Add(dt.Rows(i - 1).Item("id"))
                        cmbSubject.Items.Add(dt.Rows(i - 1).Item("name_subject"))
                    Next
                End If
                'задаване на текст на cmbtaта
                cmbProfil.Text = cmbProfil.Items(0)
                cmbProfilId.Text = cmbProfilId.Items(0)
                cmd = New MySqlCommand("Select* from teachers;", cnn)
                cmd.ExecuteNonQuery()
                adaptre1 = New MySqlDataAdapter(cmd)
                dt = New DataTable
                adaptre1.Fill(dt)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 1 To dt.Rows.Count
                        cmbTeachid.Items.Add(dt.Rows(i - 1).Item("id"))
                        cmbTeach.Items.Add(dt.Rows(i - 1).Item("name_teacher") & " " & dt.Rows(i - 1).Item("family_teacher"))
                    Next
                End If
                'задаване на текст на cmbtaта
                cmbTeach.Text = cmbTeach.Items(0)
                cmbTeachid.Text = cmbTeachid.Items(0)

                cmd = New MySqlCommand("Select* from purpose;", cnn)

                cmd.ExecuteNonQuery()
                adaptre1 = New MySqlDataAdapter(cmd)
                dt = New DataTable
                adaptre1.Fill(dt)


                For i As Integer = 1 To dt.Rows.Count
                    cmd = New MySqlCommand("Select* from types where id=" & dt.Rows(i - 1).Item("type") & ";", cnn)
                    cmd.ExecuteNonQuery()
                    adaptre = New MySqlDataAdapter(cmd)
                    data = New DataTable
                    adaptre.Fill(data)
                    Dim f As Integer

                    If dt.Rows.Count > 0 Then
                        Call searchtype(data.Rows(0).Item("name_type"), f)
                        If f = 0 Then
                            cmbTypeid.Items.Add(data.Rows(0).Item("id"))
                            cmbtype.Items.Add(data.Rows(0).Item("name_type"))
                        End If
                    End If
                Next
            End If
            ' пълнене на dgv1
            Call create_dgv()
            cnn.Close()
        End If
    End Sub

    Private Sub cmbParal_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbParal.Leave, cmbParal.DropDown
        If (cmbParal.SelectedIndex = -1) Then
            cmbParal.Text = cmbParal.Items(0)
            cmbParal.Focus()
        Else
            Call clearProfile()
            Call clearSubject()
            Call clearteach()
            Call clearType()
            dgv1.Rows.Clear()
            'Отваряне на връската със SURVER
            cnn.Open()
            Dim brRows As Integer
            brRows = 0
            title1 = "Справка"
            title2 = "Випуските през годините: "
            Dim scmb As String

            scmb = "Select* from  classes where school_year='" & cmbYear.Text
            If cmbClass.Text <> cmbClass.Items(0) Then
                scmb = scmb & "' and grade='" & cmbClass.Text
            End If
            If cmbParal.Text <> cmbParal.Items(0) Then
                scmb = scmb & "' and class='" & cmbParal.Text
            End If
            scmb = scmb & "' order by class desc;"
            cmd = New MySqlCommand(scmb, cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            'Проверка дaли в таблица purpose има записи
            If data.Rows.Count > 0 Then
                'ако има записи
                Dim classesPodr(data.Rows.Count, 2) As Integer
                brRows = 0

                'задаване на текст на cmbtaта
                cmd = New MySqlCommand("Select* from profiles order by id;", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt As DataTable = New DataTable
                adaptre1.Fill(dt)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 1 To dt.Rows.Count
                        cmbProfilId.Items.Add(dt.Rows(i - 1).Item("id"))
                        cmbProfil.Items.Add(dt.Rows(i - 1).Item("name_profile"))
                    Next
                End If
                'задаване на текст на cmbtaта
                cmbProfil.Text = cmbProfil.Items(0)
                cmbProfilId.Text = cmbProfilId.Items(0)
                cmd = New MySqlCommand("Select* from subject order by name_subject asc;", cnn)
                cmd.ExecuteNonQuery()
                adaptre1 = New MySqlDataAdapter(cmd)
                dt = New DataTable
                adaptre1.Fill(dt)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 1 To dt.Rows.Count
                        cmbSubjectId.Items.Add(dt.Rows(i - 1).Item("id"))
                        cmbSubject.Items.Add(dt.Rows(i - 1).Item("name_subject"))
                    Next
                End If
                'задаване на текст на cmbtaта
                cmbProfil.Text = cmbProfil.Items(0)
                cmbProfilId.Text = cmbProfilId.Items(0)
                cmd = New MySqlCommand("Select* from teachers;", cnn)
                cmd.ExecuteNonQuery()
                adaptre1 = New MySqlDataAdapter(cmd)
                dt = New DataTable
                adaptre1.Fill(dt)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 1 To dt.Rows.Count
                        cmbTeachid.Items.Add(dt.Rows(i - 1).Item("id"))
                        cmbTeach.Items.Add(dt.Rows(i - 1).Item("name_teacher") & " " & dt.Rows(i - 1).Item("family_teacher"))
                    Next
                End If
                'задаване на текст на cmbtaта
                cmbTeach.Text = cmbTeach.Items(0)
                cmbTeachid.Text = cmbTeachid.Items(0)

                cmd = New MySqlCommand("Select* from purpose;", cnn)

                cmd.ExecuteNonQuery()
                adaptre1 = New MySqlDataAdapter(cmd)
                dt = New DataTable
                adaptre1.Fill(dt)
                For i As Integer = 1 To dt.Rows.Count
                    cmd = New MySqlCommand("Select* from types where id=" & dt.Rows(i - 1).Item("type") & ";", cnn)
                    cmd.ExecuteNonQuery()
                    adaptre = New MySqlDataAdapter(cmd)
                    data = New DataTable
                    adaptre.Fill(data)
                    Dim f As Integer

                    If dt.Rows.Count > 0 Then
                        Call searchtype(data.Rows(0).Item("name_type"), f)
                        If f = 0 Then
                            cmbTypeid.Items.Add(data.Rows(0).Item("id"))
                            cmbtype.Items.Add(data.Rows(0).Item("name_type"))
                        End If
                    End If
                Next
            End If
            ' пълнене на dgv1
            Call create_dgv()
            cnn.Close()
        End If
    End Sub

    Private Sub cmbProfil_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProfil.Leave, cmbProfil.DropDown
        If (cmbProfil.SelectedIndex = -1) Then
            cmbProfil.Text = cmbProfil.Items(0)
            cmbProfil.Focus()
        Else
            Call clearSubject()
            Call clearteach()
            Call clearType()
            dgv1.Rows.Clear()
            'Отваряне на връската със SURVER
            cnn.Open()
            Dim brRows As Integer
            brRows = 0
            title1 = "Справка"
            title2 = "Випуските през годините: "
            Dim scmb As String
            cmbProfilId.Text = cmbProfilId.Items(cmbProfil.SelectedIndex)
            scmb = "Select* from  classes where school_year='" & cmbYear.Text
            If cmbClass.Text <> cmbClass.Items(0) Then
                scmb = scmb & "' and grade='" & cmbClass.Text
            End If
            If cmbParal.Text <> cmbParal.Items(0) Then
                scmb = scmb & "' and class='" & cmbParal.Text
            End If
            If cmbProfil.Text <> cmbProfil.Items(0) Then
                scmb = scmb & "' and profile='" & cmbProfilId.Text
            End If
            scmb = scmb & "' order by class desc;"
            cmd = New MySqlCommand(scmb, cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            'Проверка дaли в таблица purpose има записи
            If data.Rows.Count > 0 Then
                'ако има записи
                Dim classesPodr(data.Rows.Count, 2) As Integer
                brRows = 0
                Dim adaptre1 As MySqlDataAdapter
                Dim dt As DataTable = New DataTable

                cmd = New MySqlCommand("Select* from subject order by name_subject asc;", cnn)
                cmd.ExecuteNonQuery()
                adaptre1 = New MySqlDataAdapter(cmd)
                dt = New DataTable
                adaptre1.Fill(dt)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 1 To dt.Rows.Count
                        cmbSubjectId.Items.Add(dt.Rows(i - 1).Item("id"))
                        cmbSubject.Items.Add(dt.Rows(i - 1).Item("name_subject"))
                    Next
                End If
                'задаване на текст на cmbtaта
                cmd = New MySqlCommand("Select* from teachers;", cnn)
                cmd.ExecuteNonQuery()
                adaptre1 = New MySqlDataAdapter(cmd)
                dt = New DataTable
                adaptre1.Fill(dt)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 1 To dt.Rows.Count
                        cmbTeachid.Items.Add(dt.Rows(i - 1).Item("id"))
                        cmbTeach.Items.Add(dt.Rows(i - 1).Item("name_teacher") & " " & dt.Rows(i - 1).Item("family_teacher"))
                    Next
                End If
                'задаване на текст на cmbtaта
                cmbTeach.Text = cmbTeach.Items(0)
                cmbTeachid.Text = cmbTeachid.Items(0)

                cmd = New MySqlCommand("Select* from purpose;", cnn)

                cmd.ExecuteNonQuery()
                adaptre1 = New MySqlDataAdapter(cmd)
                dt = New DataTable
                adaptre1.Fill(dt)
                For i As Integer = 1 To dt.Rows.Count
                    cmd = New MySqlCommand("Select* from types where id=" & dt.Rows(i - 1).Item("type") & ";", cnn)
                    cmd.ExecuteNonQuery()
                    adaptre = New MySqlDataAdapter(cmd)
                    data = New DataTable
                    adaptre.Fill(data)
                    Dim f As Integer

                    If dt.Rows.Count > 0 Then
                        Call searchtype(data.Rows(0).Item("name_type"), f)
                        If f = 0 Then
                            cmbTypeid.Items.Add(data.Rows(0).Item("id"))
                            cmbtype.Items.Add(data.Rows(0).Item("name_type"))
                        End If
                    End If
                Next
            End If
            ' пълнене на dgv1
            Call create_dgv()
            cnn.Close()
        End If
    End Sub

    Private Sub cmbSubject_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubject.Leave, cmbSubject.DropDown
        If (cmbSubject.SelectedIndex = -1) Then
            cmbSubject.Text = cmbSubject.Items(0)
            cmbSubject.Focus()
        Else
            dgv1.Rows.Clear()
            'Отваряне на връската със SURVER
            cnn.Open()
            Dim brRows As Integer
            brRows = 0
            title1 = "Справка"
            title2 = "Випуските през годините: "
            Dim scmb As String
            cmbSubjectId.Text = cmbSubjectId.Items(cmbSubject.SelectedIndex)
            scmb = "Select* from  classes where school_year='" & cmbYear.Text
            If cmbClass.Text <> cmbClass.Items(0) Then
                scmb = scmb & "' and grade='" & cmbClass.Text
            End If
            If cmbParal.Text <> cmbParal.Items(0) Then
                scmb = scmb & "' and class='" & cmbParal.Text
            End If
            If cmbProfil.Text <> cmbProfil.Items(0) Then
                scmb = scmb & "' and profile='" & cmbProfilId.Text
            End If
            scmb = scmb & "' order by class desc;"
            cmd = New MySqlCommand(scmb, cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            'Проверка дaли в таблица purpose има записи
            If data.Rows.Count > 0 Then
                cmbTeach.Text = cmbTeach.Items(0)
                cmbTeachid.Text = cmbTeachid.Items(0)
                cmbTypeid.Text = cmbTypeid.Items(0)
                cmbtype.Text = cmbtype.Items(0)
            End If
            ' пълнене на dgv1
            Call create_dgv()
            cnn.Close()
        End If
    End Sub

    Private Sub cmbTeach_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTeach.Leave, cmbTeach.DropDown
        If (cmbTeach.SelectedIndex = -1) Then
            cmbTeach.Text = cmbTeach.Items(0)
            cmbTeach.Focus()
        Else
            dgv1.Rows.Clear()
            'Отваряне на връската със SURVER
            cnn.Open()
            cmbTeachid.Text = cmbTeachid.Items(cmbTeach.SelectedIndex)
            cmbTypeid.Text = cmbTypeid.Items(0)
            cmbtype.Text = cmbtype.Items(0)
            ' пълнене на dgv1
            Call create_dgv()
            cnn.Close()
        End If
    End Sub

    Private Sub cmbtype_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtype.Leave, cmbtype.DropDown
        If (cmbtype.SelectedIndex = -1) Then
            cmbtype.Text = cmbtype.Items(0)
            cmbtype.Focus()
        Else
            dgv1.Rows.Clear()
            'Отваряне на връската със SURVER
            cnn.Open()
            cmbTypeid.Text = cmbTypeid.Items(cmbtype.SelectedIndex)
            ' пълнене на dgv1
            Call create_dgv()
            cnn.Close()
        End If
    End Sub

    Private Sub btnchart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnchart.Click
        If cmbYear.Text <> "" Then
            'проверка за стойностите в диаграмата и тяхното изтриване
            If flagbtn = 1 Then
                Chart1.Series.Clear()
                Chart1.Titles.Clear()
            End If
            title2 = "Среден успех по паралелки за година: "
            title2 = title2 & cmbYearString.Text & ", клас: " & cmbClass.Text & ", паралелка: " & cmbParal.Text
            title2 = title2 & ", профил: " & cmbProfil.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text

            Chart1.Titles.Add(title1)
            Chart1.Titles.Add(title2)

            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try

            Dim scom As String = ""
            Call createscmb(scom)

            cnn.Open()

            cmd = New MySqlCommand(scom, cnn)
            If scom <> "" Then
                cmd.ExecuteNonQuery()
                Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt As DataTable = New DataTable
                adaptre1.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Dim classes, class2, class1, otd As String
                    Dim grade As Integer
                    Dim max As Double
                    otd = ""
                    'обхойдане на редовете един по един и добавяне на изчислените стойности в диаграмата
                    Dim row As Integer = 0
                    Chart1.Series.Clear()
                    Chart1.Series.Add(0)
                    Chart1.ChartAreas.Item(0).AxisX.CustomLabels.Clear()
                    prb1.Maximum = dt.Rows.Count
                    For i As Integer = 0 To dt.Rows.Count - 1
                        grade = dt.Rows(i).Item("grade")
                        classes = dt.Rows(i).Item("class")
                        max = dt.Rows(i).Item("sreden_uspeh")
                        prb1.Value = i + 1

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
                        Chart1.Series(0).Points.AddXY(row, max)
                        Chart1.ChartAreas.Item(0).AxisX.CustomLabels.Add(row - 0.5, row + 0.5, class2)
                        Chart1.Series(0).Points(row).Label = Format(Math.Round(max, 2), "0.00")
                        row = row + 1


                    Next


                    flagbtn = 1
                    cnn.Close()
                    'оголемяване на формата

                    Chart1.Visible = True
                    Me.Height = 916
                End If


            Else
                MsgBox("По тези критерии няма оценки! ! !", , "Универсална спавка")
            End If
        Else
            MsgBox("По тези критерии няма оценки! ! !", , "Универсална спавка")
        End If
    End Sub

    Function createscmb(ByRef scmb As String)
        scmb = ""
        If cmbYear.Text <> "" Then
            Dim year As Integer
            Dim cmbt, cmbs As String
            cmbs = cmbSubjectId.Text
            cmbt = cmbTypeid.Text
            year = cmbYear.Text


            scmb = "SELECT classes.id, classes.grade, classes.class, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                              & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose ON classes.id=purpose.class Where"
            Dim f As Integer = 0
            If cmbt <> -1 Then
                scmb = scmb & " purpose.type='" & cmbt
                f = 1
            End If
            If cmbs <> -1 Then
                If f = 1 Then
                    scmb = scmb & "' and"
                End If
                scmb = scmb & " purpose.subject='" & cmbs
                f = 1
            End If
            If f = 1 Then
                scmb = scmb & "' and"
            End If
            scmb = scmb & " classes.school_year='" & year
            If cmbClass.Text <> cmbClass.Items(0) Then
                scmb = scmb & "' and classes.grade='" & cmbClass.Text
            End If
            If cmbParal.Text <> cmbParal.Items(0) Then
                scmb = scmb & "' and classes.class='" & cmbParal.Text
            End If
            If cmbProfil.Text <> cmbProfil.Items(0) Then
                scmb = scmb & "' and classes.profile='" & cmbProfilId.Text
            End If
            If cmbSubject.Text <> cmbSubject.Items(0) Then
                scmb = scmb & "' and purpose.subject='" & cmbSubjectId.Text
            End If
            '!!!!!
            scmb = scmb & "' Group by  purpose.class order by sreden_uspeh desc;"
            '!!!!!
            '!!!!!
            TextBox1.Text = scmb


            Return scmb

        Else
            MsgBox("По тези критерии няма оценки! ! !", , "Универсална спавка")
            Return ""
        End If
    End Function

    Private Sub btnExselNewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExselNewFile.Click
        If cmbYear.Text <> "" Then
            title2 = "Среден успех по паралелки за година: "
            title2 = title2 & cmbYearString.Text & ", клас: " & cmbClass.Text & ", паралелка: " & cmbParal.Text
            title2 = title2 & ", профил: " & cmbProfil.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text

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
            SaveFileDialog1.Filter = rasEx
            If SaveFileDialog1.ShowDialog = DialogResult.OK Then
                cnn.Open()
                Dim xlapp As Microsoft.Office.Interop.Excel.Application
                Dim xlbook As Microsoft.Office.Interop.Excel.Workbook
                Dim xlsheet As Microsoft.Office.Interop.Excel.Worksheet
                Dim misvalue As Object = System.Reflection.Missing.Value

                Dim xldi As Microsoft.Office.Interop.Excel.Chart

                xlapp = New Microsoft.Office.Interop.Excel.Application
                xlbook = xlapp.Workbooks.Add(misvalue)
                xlsheet = xlbook.Sheets("sheet1")
                xlsheet.Name = "Универсална справка"

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
                pat = SaveFileDialog1.FileName
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
                Dim scmb As String = ""

                Call createscmb(scmb)
                If scmb <> "" Then
                    cmd = New MySqlCommand(scmb, cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt As DataTable = New DataTable
                    adaptre1.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        Dim classes, class2, otd As String
                        Dim grade, br As Integer
                        Dim max As Double
                        otd = ""
                        br = 4
                        'четене на datareader, изчисляване на данните и тяхното записване в excel
                        For i As Integer = 0 To dt.Rows.Count - 1
                            grade = dt.Rows(i).Item("grade")
                            classes = dt.Rows(i).Item("class")
                            max = dt.Rows(i).Item("sreden_uspeh")
                            prb1.Value = i + 1

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

                            xlsheet.Cells(br, 1) = class2
                            xlsheet.Cells(br, 2) = max
                            xlsheet.Range(xlsheet.Cells(br, 1), xlsheet.Cells(br, 2)).HorizontalAlignment = xlCenter
                            chartRange = xlsheet.Range("A4:B" & br)
                            chartPage.SetSourceData(Source:=chartRange)
                            br = br + 1
                        Next

                        chartPage.HasLegend = False
                        chartPage.PlotBy = Microsoft.Office.Interop.Excel.XlRowCol.xlColumns
                        chartPage.HasTitle = True
                        chartPage.ChartTitle.Text = title2
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

                End If
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

                Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
                xlWorkBook = xlapp.Workbooks.Add
                Dim ws As Microsoft.Office.Interop.Excel.Worksheet

                Try
                    'задаване на текст в клетки и форматиране на редове и колони
                    ws = xlWorkBook.Sheets.Add(, xlWorkBook.Sheets(xlWorkBook.Sheets.Count))
                    ws.Name = "Универсална справка ср успех"
                    title2 = "Среден успех по паралелки за година: "
                    title2 = title2 & cmbYearString.Text & ", клас: " & cmbClass.Text & ", паралелка: " & cmbParal.Text
                    title2 = title2 & ", профил: " & cmbProfil.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
                    ' Dim r As MySqlDataReader
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
                    ''   cmdmaxmin(r)
                    Dim scmb As String = ""
                    Call createscmb(scmb)
                    If scmb <> "" Then
                        cmd = New MySqlCommand(scmb, cnn)
                        cmd.ExecuteNonQuery()
                        Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                        Dim dt As DataTable = New DataTable
                        adaptre1.Fill(dt)
                        If dt.Rows.Count > 0 Then
                            Dim classes, class2, class1, otd As String
                            Dim grade, br As Integer
                            Dim max As Double
                            otd = ""
                            br = 4
                            For i As Integer = 0 To dt.Rows.Count - 1
                                grade = dt.Rows(i).Item("grade")
                                classes = dt.Rows(i).Item("class")
                                max = dt.Rows(i).Item("sreden_uspeh")
                                prb1.Value = prb1.Value + 1
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

                                ws.Cells(br, 1) = class2
                                ws.Cells(br, 2) = max
                                ws.Range(ws.Cells(br, 1), ws.Cells(br, 2)).HorizontalAlignment = xlCenter
                                chartRange = ws.Range("A2:B" & br)

                                chartPage.SetSourceData(Source:=chartRange)
                                br = br + 1
                            Next
                        End If
                    End If
                    chartPage.HasTitle = True
                    chartPage.ChartTitle.Text = ws.Range("A2").Value()
                    chartPage.HasLegend = False
                    chartPage.PlotBy = Microsoft.Office.Interop.Excel.XlRowCol.xlColumns
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

                    cnn.Close()
                    'питане дали да се отвори файла 
                    Dim res As MsgBoxResult
                    res = MsgBox("Искате ли файлът да се отвори?", MsgBoxStyle.YesNo, "Справка")
                    If res = MsgBoxResult.Yes Then
                        Process.Start(pat)
                    End If

                Catch ex As Exception
                End Try

            End If
        Else
            MsgBox("Трябва да се върнете и да веведете оценки ! ! !", , "Справка")
        End If
    End Sub

    Private Sub btnWordNewFIle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWordNewFIle.Click
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
                title2 = "Среден успех по паралелки за година: "
                title2 = title2 & cmbYearString.Text & ", клас: " & cmbClass.Text & ", паралелка: " & cmbParal.Text
                title2 = title2 & ", профил: " & cmbProfil.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
                oPara2 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
                oPara2.Range.Text = title2
                oPara2.Format.SpaceAfter = 6
                oPara2.Range.InsertParagraphAfter()

                Dim scmb As String = ""
                Call createscmb(scmb)
                If scmb <> "" Then
                    cmd = New MySqlCommand(scmb, cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt As DataTable = New DataTable
                    adaptre1.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, dt.Rows.Count, 2)

                        Dim classes, class1, otd As String
                        Dim grade, br As Integer
                        Dim max As Double
                        otd = ""
                        br = 2
                        prb1.Value = 0
                        prb1.Maximum = dt.Rows.Count

                        oTable.Cell(1, 1).Range.Text = "Средно аритметично"
                        oTable.Cell(1, 2).Range.Text = "Клас"
                        'четене на datareader, изчисляване на данните и тяхното записване в excel
                        For i As Integer = 0 To dt.Rows.Count - 1
                            grade = dt.Rows(i).Item("grade")
                            classes = dt.Rows(i).Item("class")
                            max = dt.Rows(i).Item("sreden_uspeh")
                            prb1.Value = prb1.Value + 1
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
                            class1 = grade & " " & classes
                            oTable.Cell(br, 1).Range.Text = max
                            oTable.Cell(br, 2).Range.Text = class1

                            br = br + 1
                        Next
                        'форматиране на таблицата
                        oTable.Rows.Item(1).Range.Font.Bold = True
                        oTable.Range.Style = "Table Grid"
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

            End If
        Else
            MsgBox("Трябва да се върнете и да веведете оценки ! ! !", , "Справка")
        End If
    End Sub
End Class
