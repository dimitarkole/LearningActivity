'използване на MySQL Data
Imports MySql.Data.MySqlClient
Public Class Reference_GPA_Vipusk
    'деклариране на глобални променливи
    Dim cnn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim years, title1, title2, flagbtn As String
    Dim a, b, RRowsCount As Integer
    Private Sub Reference_GPA_Vipusk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    Private Sub cmbVipusk_Leave_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYearString.Leave, cmbYearString.DropDownClosed
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
    Private Sub cmbSubject_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubject.Leave, cmbSubject.DropDownClosed
        If (cmbSubject.SelectedIndex = -1) Then
            cmbSubject.Text = cmbSubject.Items(0)
            cmbSubject.Focus()

        Else

            'изтриване на старите сойности в dgv1 и cmbtype
            Do While dgv1.RowCount > 0
                dgv1.Rows.Remove(dgv1.Rows(0))
            Loop

            Do While cmbtype.Items.Count > 1
                cmbtype.Items.Remove(cmbtype.Items(1))
            Loop
            'задаване на текст на cmbYear и cmbClass според избрания випуск и cmbSubjectId според избран предмет
            cmbSubjectId.Text = cmbSubjectId.Items(cmbSubject.SelectedIndex)
            ' cmbYear.Text = cmbYear.Items(cmbVipusk.SelectedIndex)
            '   cmbClass.Text = cmbClass.Items(cmbVipusk.SelectedIndex)

            Dim subjid As Integer
            subjid = cmbSubjectId.Text
            Dim grade As Integer
            grade = cmbClass.Text
            years = cmbYear.Text
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            'търсене на номерата на класовете, които са в този випуск 
            cmd = New MySqlCommand("Select* from  classes where grade='" & grade & "' and school_year='" & years & "'", cnn)
            Dim brRows, flag As Integer
            brRows = 0

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
                'търсене по номера на предмета и предмета в таблицата с оценки  
                If subjid = -1 Then
                    cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "' order by type", cnn)
                Else
                    cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "' and subject='" & subjid & "' order by type", cnn)
                End If
                cmd.ExecuteNonQuery()
                Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt1 As DataTable = New DataTable
                adaptre2.Fill(dt1)
                'добавяне на видове оценки в cmbtype ако не са били въведени
                If dt1.Rows.Count > 0 Then
                    brrows2 = 0
                    Do While brrows2 < dt1.Rows.Count
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

            years = cmbYear.Text
            grade = cmbClass.Text

            'Добавяне в datagridview редове 
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
            'задаване на текст според избраните възможности
            cmbSubjectId.Text = cmbSubjectId.Items(cmbSubject.SelectedIndex)
            cmbIdType.Text = cmbIdType.Items(cmbtype.SelectedIndex)
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
            ' cmbYear.Text = cmbYear.Items(cmbVipusk.SelectedIndex)
            'cmbClass.Text = cmbClass.Items(cmbVipusk.SelectedIndex)

            grade = cmbClass.Text
            years = cmbYear.Text

            Dim brrows2 As Integer = 0
            brRows = 0
            Dim nType As String
            years = cmbYear.Text
            grade = cmbClass.Text
            'търсене на номерата на класовете, които са в този випуск 
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
                'Добавяне в datagridview редове 
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
    Private Sub btnchart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnchart.Click
        If cmbYear.Text <> "" Then
            'проверка за стойностите в диаграмата и тяхното изтриване
            Chart1.Series.Clear()
            Chart1.Legends.Clear()
            Chart1.Titles.Clear()
            Chart1.Titles.Clear()
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
            Call cmdmaxmin(r)
            If RRowsCount > 0 Then
                title2 = "Среден успех по класове за випуск: "
                title2 = title2 & cmbYearString.Text & " " & cmbClass.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
                Chart1.Titles.Add(title1)
                Chart1.Titles.Add(title2)
                Dim classes, class2, class1, otd As String
                Dim grade As Integer
                Dim max As Double
                otd = ""
                Chart1.Series.Clear()
                Chart1.Series.Add(0)
                Chart1.ChartAreas.Item(0).AxisX.CustomLabels.Clear()
                Dim row As Integer = 0
                'обхождане на редовете един по един и добавяне на изчислените стойности в диаграмата
                Do While r.Read
                    grade = r.GetString("grade")
                    classes = r.GetString("class")
                    max = r.GetString("sreden_uspeh")
                    prb1.Value = prb1.Value + 1
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
                    class2 = grade & " " & classes & otd
                    class1 = grade & " " & classes

                    Chart1.Series(0).Points.AddXY(row, max)
                    Chart1.ChartAreas.Item(0).AxisX.CustomLabels.Add(row - 0.5, row + 0.5, class2)
                    Chart1.Series(0).Points(row).Label = Math.Round(max, 2)
                    row = row + 1
                Loop
                flagbtn = 1
                'оголемяване на формата
                Chart1.Visible = True
                Me.Height = 780
            Else
                MsgBox("За този випуск няма оценки! ! !")
            End If
            cnn.Close()

        Else
            MsgBox("Трябва да се върнете и да веведете оценки ! ! !", , "Справка")
        End If
    End Sub
    Private Sub cmdmaxmin(ByRef r As MySqlDataReader)
        Dim scom As String
        scom = ""
        'задаванена на команда оттип String в променлива coms в зависимост от избрания начин на сортиране
        If cmbPodredba.Text = cmbPodredba.Items(1) Then
            Call sminmax(scom)
        Else
            Call smaxmin(scom)
        End If
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
        If cmbtype.Text <> cmbtype.Items(0) Then
            If cmbSubject.Text <> cmbSubject.Items(0) Then
                r = "SELECT classes.grade, classes.class, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                              & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                              & " ON classes.id=purpose.class Where school_year='" & cmbYear.Text & "'and classes.grade='" & cmbClass.Text _
                                              & "'and purpose.type='" & cmbIdType.Text & "'and purpose.subject='" & cmbSubjectId.Text _
                                              & "' Group by  purpose.class order by sreden_uspeh;"

            Else
                r = "SELECT classes.grade, classes.class, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                                            & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                                            & " ON classes.id=purpose.class Where school_year='" & cmbYear.Text & "'and classes.grade='" & cmbClass.Text & "'and purpose.type='" & cmbIdType.Text _
                                                            & "' Group by  purpose.class order by sreden_uspeh;"
            End If
        Else
            If cmbSubject.Text <> cmbSubject.Items(0) Then

                r = "SELECT classes.grade, classes.class, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                              & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                              & " ON classes.id=purpose.class Where school_year='" & cmbYear.Text & "'and classes.grade='" & cmbClass.Text _
                                              & "'and purpose.subject='" & cmbSubjectId.Text & "' Group by  purpose.class order by sreden_uspeh;"

            Else
                r = "SELECT classes.grade, classes.class, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                                            & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                                            & " ON classes.id=purpose.class Where school_year='" & cmbYear.Text & "'and classes.grade='" & cmbClass.Text _
                                                            & "' Group by  purpose.class order by sreden_uspeh;"
            End If
        End If

    End Sub
    Private Sub smaxmin(ByRef r As String)
        'В зависимуст от избраните параметри се връща низ със комндата
        If cmbtype.Text <> cmbtype.Items(0) Then
            If cmbSubject.Text <> cmbSubject.Items(0) Then
                r = "SELECT classes.grade, classes.class, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                              & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                              & " ON classes.id=purpose.class Where school_year='" & cmbYear.Text & "'and classes.grade='" & cmbClass.Text _
                                              & "'and purpose.type='" & cmbIdType.Text & "'and purpose.subject='" & cmbSubjectId.Text _
                                              & "' Group by  purpose.class order by sreden_uspeh desc;"

            Else
                r = "SELECT classes.grade, classes.class, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                                            & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                                            & " ON classes.id=purpose.class Where school_year='" & cmbYear.Text & "'and classes.grade='" & cmbClass.Text & "'and purpose.type='" & cmbIdType.Text _
                                                            & "' Group by  purpose.class order by sreden_uspeh desc;"
            End If
        Else
            If cmbSubject.Text <> cmbSubject.Items(0) Then

                r = "SELECT classes.grade, classes.class, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                              & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                              & " ON classes.id=purpose.class Where school_year='" & cmbYear.Text & "'and classes.grade='" & cmbClass.Text _
                                              & "'and purpose.subject='" & cmbSubjectId.Text & "' Group by  purpose.class order by sreden_uspeh desc;"

            Else
                r = "SELECT classes.grade, classes.class, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                                            & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                                            & " ON classes.id=purpose.class Where school_year='" & cmbYear.Text & "'and classes.grade='" & cmbClass.Text _
                                                            & "' Group by  purpose.class order by sreden_uspeh desc;"
            End If
        End If

    End Sub
    Private Sub btnExselNewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExselNewFile.Click
        If cmbYear.Text <> "" Then

            title2 = "Среден успех по класове за випуск: "
            title2 = title2 & cmbYearString.Text & " " & cmbClass.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text

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
                xlapp = New Microsoft.Office.Interop.Excel.Application
                'задаване на текст в клетки и форматиране на редове и колони
                xlbook = xlapp.Workbooks.Add(misvalue)
                xlsheet = xlbook.Sheets("sheet1")
                xlsheet.Name = "Среден успех по класове"
                xldi = New Microsoft.Office.Interop.Excel.Chart
                Const xlCenter = -4108
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
                xlsheet.Range("A2").EntireRow.RowHeight = 35
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
                myChart = xlCharts.Add(280, 50, 600, 250)
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
                    Do While r.Read
                        grade = r.GetString("grade")
                        classes = r.GetString("class")
                        max = r.GetString("sreden_uspeh")
                        prb1.Value = prb1.Value + 1
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

                        class2 = grade & " " & classes & otd
                        xlsheet.Cells(br, 1) = class2
                        xlsheet.Cells(br, 2) = max
                        xlsheet.Range(xlsheet.Cells(br, 1), xlsheet.Cells(br, 2)).HorizontalAlignment = xlCenter
                        chartRange = xlsheet.Range("A4:B" & br)
                        chartPage.SetSourceData(Source:=chartRange)
                        br = br + 1
                    Loop
                    chartPage.HasTitle = True
                    chartPage.ChartTitle.Text = xlsheet.Range("A2").Value()
                    'Смаляване на формата
                    chartPage.HasLegend = False
                    chartPage.PlotBy = Microsoft.Office.Interop.Excel.XlRowCol.xlColumns
                    Me.Height = 410
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
                Else
                    MsgBox("За този випуск няма оценки! ! !")
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
                    ws.Name = "Среден успех по класове"
                    title2 = "Среден успех по класове за випуск: "
                    title2 = title2 & cmbYearString.Text & " " & cmbClass.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
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
                    ws.Range("A2").EntireRow.RowHeight = 35
                    Dim bi, ci As String
                    bi = "B" & 4
                    ci = "B" & 4
                    Dim chartPage As Microsoft.Office.Interop.Excel.Chart
                    Dim xlCharts As Microsoft.Office.Interop.Excel.ChartObjects
                    Dim myChart As Microsoft.Office.Interop.Excel.ChartObject
                    Dim chartRange As Microsoft.Office.Interop.Excel.Range
                    xlCharts = ws.ChartObjects
                    myChart = xlCharts.Add(280, 50, 600, 250)
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
                        ' четене на datareader, изчисляване на данните и тяхното записване в excel
                        Do While r.Read
                            grade = r.GetString("grade")
                            classes = r.GetString("class")
                            max = r.GetString("sreden_uspeh")
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
                            chartRange = ws.Range("A4:B" & br)
                            chartPage.SetSourceData(Source:=chartRange)
                            br = br + 1
                        Loop
                        chartPage.HasLegend = False
                        chartPage.HasTitle = True
                        chartPage.ChartTitle.Text = ws.Range("A2").Value()
                        chartPage.PlotBy = Microsoft.Office.Interop.Excel.XlRowCol.xlColumns
                        ws.Copy(, masterWb.Sheets(masterWb.Sheets.Count))
                        ws = Nothing
                        xlWorkBook.Save()
                        xlWorkBook.Close()
                        xlWorkBook = Nothing
                        'Смаляване на формата
                        Me.Height = 410
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
                    Else
                        MsgBox("За този випуск няма оценки! ! !")
                    End If
                Catch
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
                title2 = "Среден успех по класове за випуск: "
                title2 = title2 & cmbYearString.Text & " " & cmbClass.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
                oPara2 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
                oPara2.Range.Text = title2
                oPara2.Format.SpaceAfter = 6
                oPara2.Range.InsertParagraphAfter()
                Dim r As MySqlDataReader
                'извикване на функция cmdmaxmi, която връща datareader и проверка тя дали е пълна 
                cmdmaxmin(r)
                If RRowsCount > 0 Then
                    oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, RRowsCount + 1, 2)
                    Dim classes, class1, otd As String
                    Dim grade, br As Integer
                    Dim max As Double
                    otd = ""
                    br = 2
                    prb1.Value = 0
                    prb1.Maximum = RRowsCount

                    oTable.Cell(1, 1).Range.Text = "Средно аритметично"
                    oTable.Cell(1, 2).Range.Text = "Клас"
                    'четене на datareader, изчисляване на данните и тяхното записване в excel
                    Do While r.Read
                        grade = r.GetString("grade")
                        classes = r.GetString("class")
                        max = r.GetString("sreden_uspeh")
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
                    Loop
                    'форматиране на таблицата
                    oTable.Rows.Item(1).Range.Font.Bold = True
                    oTable.Range.Style = "Table Grid"
                    'смаляване на формата
                    Me.Height = 410
                    oDoc.SaveAs2(pat)
                    oDoc.Close()
                    'питане дали да се отвори файла
                    Dim res As MsgBoxResult
                    res = MsgBox("Искате ли файлът да се отвори?", MsgBoxStyle.YesNo, "Справка")
                    If res = MsgBoxResult.Yes Then
                        Process.Start(pat)
                    End If
                Else
                    MsgBox("За този випуск няма оценки! ! !")
                End If
                cnn.Close()
            End If
        Else
            MsgBox("Трябва да се върнете и да веведете оценки ! ! !", , "Справка")
        End If
    End Sub
    Private Sub cmbPodredba_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPodredba.Leave, cmbPodredba.DropDownClosed
        If (cmbSubject.SelectedIndex = -1) Then
            'Проверка за въвеждане на символи от клавиатурата
            cmbSubject.Text = cmbSubject.Items(0)
            cmbSubject.Focus()
        End If
    End Sub
    Private Sub Reference_GPA_Vipusk_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'изтриване на старите сойности в dgv1
        Do While dgv1.RowCount > 0
            dgv1.Rows.Remove(dgv1.Rows(0))
        Loop
        Me.Height = 410
        'Проверка дали chart1 е празно и  изтриване настъойностите му
        Chart1.Series.Clear()
        Chart1.Titles.Clear()
        title2 = "Среден успех на класовете за "
        cmbYearString.Items.Clear()
        cmbClass.Items.Clear()
        cmbYear.Items.Clear()
        Do While cmbtype.Items.Count > 1
            cmbtype.Items.Remove(cmbtype.Items(1))
            ' cmbIdType.Items.Remove(cmbIdType.Items(1))
        Loop

        Do While cmbSubject.Items.Count > 1
            cmbSubject.Items.Remove(cmbSubject.Items(1))
            cmbSubjectId.Items.Remove(cmbSubjectId.Items(1))
        Loop
        prb1.Value = 0
    End Sub

    Private Sub cmbClass_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClass.Leave, cmbClass.DropDownClosed
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