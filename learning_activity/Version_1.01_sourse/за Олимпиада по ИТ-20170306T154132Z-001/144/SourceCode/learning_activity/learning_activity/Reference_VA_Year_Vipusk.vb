'използване на MySQL Data
Imports MySql.Data.MySqlClient
Public Class Reference_VA_Year_Vipusk
    'деклариране на глобални променливи
    Dim cnn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim years, title1, title2, flagbtn As String
    Dim a, b, RRowsCount As Integer
    Private Sub Reference_VA_Year_Vipusk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Отваряне на връската със SURVER
        Call Module1.hosts(cnn)
        cnn.Open()
        Dim brRows, flag As Integer
        brRows = 0
        title1 = "Справка"
        title2 = "Съотношение на оценките по класове за 2 години: "

        cmd = New MySqlCommand("Select* from  classes order by school_year desc, grade asc", cnn)
        cmd.ExecuteNonQuery()
        Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
        Dim data As DataTable = New DataTable
        adaptre.Fill(data)
        'Проверка дaли в таблица purpose има записи
        If data.Rows.Count > 0 Then
            'ако има записи
            Dim classesPodr(data.Rows.Count, 2) As Integer
            Dim years, grade As Integer
            brRows = 0
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
            Next
            brRows = 0
            Dim yearot, yeardo As String
            Do While classesPodr(brRows, 1) <> 0
                grade = classesPodr(brRows, 1)
                years = classesPodr(brRows, 2)
                yearot = grade & " " & years & "/" & years Mod 100 + 1
                yeardo = years - 1 & "/" & years Mod 100
                cmbVipusk.Items.Add(yearot & " - " & yeardo)
                cmbClass.Items.Add(grade)
                cmbYear.Items.Add(years)
                brRows = brRows + 1
            Loop
            'задаване на текст на cmbtaта
            cmbVipusk.Text = cmbVipusk.Items(0)
            cmbClass.Text = cmbClass.Items(0)
            cmbYear.Text = cmbYear.Items(0)
            'търсене на оценките на випуска
            grade = cmbClass.Text
            years = cmbYear.Text
            cmd = New MySqlCommand("Select* from classes where grade='" & grade & "' and school_year='" & years & "'", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable
            adaptre1.Fill(dt)

            Dim brrows2 As Integer = 0
            brRows = 0
            Dim idclass, idtype, IntSubject, typeid As Integer
            Dim nType, strSubject As String
            'обхождане на оценките на випуска
            Do While dt.Rows.Count > brRows
                'проверка дали класа е от випуска
                idclass = dt.Rows(brRows).Item("id")
                cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "' order by type", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt1 As DataTable = New DataTable
                adaptre2.Fill(dt1)
                If dt1.Rows.Count > 0 Then
                    brrows2 = 0
                    Dim subflag, subjite, subid As Integer
                    'обхойдане на оценките от класете на виспуска
                    Do While brrows2 < dt1.Rows.Count
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
            'записване на стойности в dgv1
            years = cmbYear.Text
            grade = cmbClass.Text
            cmd = New MySqlCommand("Select* from  classes where school_year='" & years & "'and grade='" & grade & "' or school_year='" & years - 1 & "'", cnn)
            cmd.ExecuteNonQuery()
            Dim adap As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data1 As DataTable = New DataTable
            adap.Fill(data1)
            Dim c2, c3, c4, c5, c6, id, nomer As Integer
            Dim subject, classes As String
            For i As Integer = 0 To data1.Rows.Count - 1
                idclass = data1.Rows(i).Item("id")
                classes = data1.Rows(i).Item("class")
                years = data1.Rows(i).Item("school_year")
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

    Private Sub cmbVipusk_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbVipusk.Leave, cmbVipusk.DropDownClosed
        If cmbVipusk.Items.Count > 0 Then
            If (cmbVipusk.SelectedIndex = -1) Then
                cmbVipusk.Text = cmbVipusk.Items(0)
                cmbVipusk.Focus()

            Else

                'изтриване на старите сойности в dgv1
                Do While dgv1.RowCount > 0
                    dgv1.Rows.Remove(dgv1.Rows(0))
                Loop
                Do While cmbtype.Items.Count > 1
                    cmbtype.Items.Remove(cmbtype.Items(1))
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


                cmd = New MySqlCommand("Select* from  classes order by school_year desc, grade asc", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim data As DataTable = New DataTable
                adaptre.Fill(data)
                'Проверка дaли в таблица purpose има записи
                If data.Rows.Count > 0 Then
                    'ако има записи
                    Dim classesPodr(data.Rows.Count, 2) As Integer
                    Dim years, grade As Integer
                    brRows = 0
                    'минаване през всчики редове на таблица purpose
                    'търсене на оценките на випуска
                    cmbClass.Text = cmbClass.Items(cmbVipusk.SelectedIndex)
                    cmbYear.Text = cmbYear.Items(cmbVipusk.SelectedIndex)
                    grade = cmbClass.Text
                    years = cmbYear.Text
                    cmd = New MySqlCommand("Select* from classes where grade='" & grade & "' and school_year='" & years & "'", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt As DataTable = New DataTable
                    adaptre1.Fill(dt)

                    Dim brrows2 As Integer = 0
                    brRows = 0
                    Dim idclass, idtype, IntSubject, typeid As Integer
                    Dim nType, strSubject As String
                    'обхождане на оценките на випуска
                    Do While dt.Rows.Count > brRows
                        'проверка дали класа е от випуска
                        idclass = dt.Rows(brRows).Item("id")
                        cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "' order by type", cnn)
                        cmd.ExecuteNonQuery()
                        Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                        Dim dt1 As DataTable = New DataTable
                        adaptre2.Fill(dt1)
                        If dt1.Rows.Count > 0 Then
                            brrows2 = 0
                            Dim subflag, subjite, subid As Integer
                            'обхойдане на оценките от класете на виспуска
                            Do While brrows2 < dt1.Rows.Count
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
                    'записване на стойности в dgv1
                    years = cmbYear.Text
                    grade = cmbClass.Text
                    cmd = New MySqlCommand("Select* from  classes where school_year='" & years & "'and grade='" & grade & "' or school_year='" & years - 1 & "'", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adap As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim data1 As DataTable = New DataTable
                    adap.Fill(data1)
                    Dim c2, c3, c4, c5, c6, id, nomer As Integer
                    Dim subject, classes As String
                    For i As Integer = 0 To data1.Rows.Count - 1
                        idclass = data1.Rows(i).Item("id")
                        classes = data1.Rows(i).Item("class")
                        years = data1.Rows(i).Item("school_year")
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
            End If
        Else
            cmbVipusk.Text = ""
        End If
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
            cmbSubjectId.Text = cmbSubjectId.Items(cmbSubject.SelectedIndex)
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            Dim brRows, flag, subjid As Integer
            subjid = cmbSubjectId.Text
            brRows = 0
            cmd = New MySqlCommand("Select* from  classes order by school_year desc, grade asc", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            'Проверка дaли в таблица purpose има записи
            If data.Rows.Count > 0 Then
                'ако има записи
                Dim classesPodr(data.Rows.Count, 2) As Integer
                Dim years, grade As Integer
                brRows = 0
                'минаване през всчики редове на таблица purpose
                'търсене на оценките на випуска
                cmbClass.Text = cmbClass.Items(cmbVipusk.SelectedIndex)
                cmbYear.Text = cmbYear.Items(cmbVipusk.SelectedIndex)
                grade = cmbClass.Text
                years = cmbYear.Text
                cmd = New MySqlCommand("Select* from classes where grade='" & grade & "' and school_year='" & years & "'", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt As DataTable = New DataTable
                adaptre1.Fill(dt)

                Dim brrows2 As Integer = 0
                brRows = 0
                Dim idclass, idtype, typeid As Integer
                Dim nType As String
                'обхождане на оценките на випуска
                Do While dt.Rows.Count > brRows
                    'проверка дали класа е от випуска
                    idclass = dt.Rows(brRows).Item("id")
                    If cmbSubject.Text = cmbSubject.Items(0) Then
                        cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "' order by type", cnn)
                    Else
                        cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "' and subject='" & subjid & "' order by type", cnn)
                    End If

                    cmd.ExecuteNonQuery()
                    Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt1 As DataTable = New DataTable
                    adaptre2.Fill(dt1)
                    If dt1.Rows.Count > 0 Then
                        brrows2 = 0
                        'обхождане на оценките от класете на виспуска
                        Do While brrows2 < dt1.Rows.Count
                            idtype = dt1.Rows(brrows2).Item("type")
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
                'записване на стойности в dgv1
                years = cmbYear.Text
                grade = cmbClass.Text
                cmd = New MySqlCommand("Select* from  classes where grade='" & grade & "'and school_year='" & years & "' or school_year='" & years - 1 & "'", cnn)
                cmd.ExecuteNonQuery()
                Dim adap As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim data1 As DataTable = New DataTable
                adap.Fill(data1)
                Dim c2, c3, c4, c5, c6, id, nomer As Integer
                Dim subject, classes As String
                For i As Integer = 0 To data1.Rows.Count - 1
                    idclass = data1.Rows(i).Item("id")
                    classes = data1.Rows(i).Item("class")
                    years = data1.Rows(i).Item("school_year")
                    classes = grade & " " & classes & " " & years & "/" & years Mod 100 + 1
                    If subjid = -1 Then
                        cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "'", cnn)
                    Else
                        cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "' and subject='" & subjid & "'", cnn)
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

            End If
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
            cmbYear.Text = cmbYear.Items(cmbVipusk.SelectedIndex)
            cmbClass.Text = cmbClass.Items(cmbVipusk.SelectedIndex)
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            Dim brRows, subjid, typeid As Integer
            subjid = cmbSubjectId.Text
            typeid = cmbIdType.Text
            brRows = 0
            cmd = New MySqlCommand("Select* from  classes order by school_year desc, grade asc", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            'Проверка дaли в таблица purpose има записи
            If data.Rows.Count > 0 Then
                'ако има записи
                Dim classesPodr(data.Rows.Count, 2) As Integer
                Dim years, grade As Integer



                Dim brrows2 As Integer = 0
                brRows = 0
                Dim idclass As Integer
                Dim nType As String
                'записване на стойности в dgv1
                years = cmbYear.Text
                grade = cmbClass.Text
                cmd = New MySqlCommand("Select* from  classes where school_year='" & years & "'and grade='" & grade & "' or school_year='" & years - 1 & "'", cnn)
                cmd.ExecuteNonQuery()
                Dim adap As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim data1 As DataTable = New DataTable
                adap.Fill(data1)
                Dim c2, c3, c4, c5, c6, id, nomer As Integer
                Dim subject, classes As String
                For i As Integer = 0 To data1.Rows.Count - 1
                    idclass = data1.Rows(i).Item("id")
                    classes = data1.Rows(i).Item("class")
                    years = data1.Rows(i).Item("school_year")
                    classes = grade & " " & classes & " " & years & "/" & years Mod 100 + 1
                    If typeid = -1 Then
                        If subjid = -1 Then
                            cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "'", cnn)
                        Else
                            cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "' and subject='" & subjid & "'", cnn)
                        End If
                    Else
                        If subjid = -1 Then
                            cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "'and type='" & typeid & "'", cnn)
                        Else
                            cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "' and subject='" & subjid & "'and type='" & typeid & "'", cnn)
                        End If
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
            End If
            cnn.Close()
        End If
    End Sub

    Private Sub btnchart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnchart.Click
        If cmbYear.Text <> "" Then
            'проверка за стойностите в диаграмата и тяхното изтриване
            If flagbtn = 1 Then
                Chart1.Series.Remove(Chart1.Series.Item(0))
                Chart1.Titles.Remove(Chart1.Titles.Item(0))
                Chart1.Titles.Remove(Chart1.Titles.Item(0))
                Chart1.Series.Add("Otnoshenie")
                Chart1.Series(0).ChartType = 17

                Chart2.Series.Remove(Chart2.Series.Item(0))
                Chart2.Titles.Remove(Chart2.Titles.Item(0))
                Chart2.Titles.Remove(Chart2.Titles.Item(0))
                Chart2.Series.Add("Otnoshenie")
                Chart2.Series(0).ChartType = 17
            End If
            title2 = "Съотношение на оценките по брой за 2 години: "

            Dim r As DataTable = New DataTable
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            Dim y As String
            'викане на функция cmdmaxmin, която връща резултат datareader и проверка дали редовете в негя саповече от 0
            Call cmdmaxmin(r)
            If RRowsCount > 0 Then
                y = cmbYear.Text & "/" & cmbYear.Text Mod 100 + 1
                title2 = "Съотношение на оценките по брой за 2 години: "
                title2 = title2 & y & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
                Chart1.Titles.Add(title1)
                Chart1.Titles.Add(title2)


                y = cmbYear.Text - 1 & "/" & cmbYear.Text Mod 100
                title2 = "Съотношение на оценките по брой за 2 години: "
                title2 = title2 & y & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
                Chart2.Titles.Add(title1)
                Chart2.Titles.Add(title2)
                Dim y1, brrows As Integer
                Dim c2, c3, c4, c5, c6 As Integer
                Dim c22, c32, c42, c52, c62, year As Integer
                prb1.Value = 0
                prb1.Maximum = RRowsCount
                brrows = 0
                year = cmbYear.Text
                Do While brrows < r.Rows.Count
                    y1 = r.Rows(brrows).Item("school_year")
                    If r.Rows(brrows).Item("school_year") = year Then
                        c2 = c2 + r.Rows(brrows).Item("c2")
                        c3 = c3 + r.Rows(brrows).Item("c3")
                        c4 = c4 + r.Rows(brrows).Item("c4")
                        c5 = c5 + r.Rows(brrows).Item("c5")
                        c6 = c6 + r.Rows(brrows).Item("c6")
                    Else
                        c22 = c22 + r.Rows(brrows).Item("c2")
                        c32 = c32 + r.Rows(brrows).Item("c3")
                        c42 = c42 + r.Rows(brrows).Item("c4")
                        c52 = c52 + r.Rows(brrows).Item("c5")
                        c62 = c62 + r.Rows(brrows).Item("c6")
                    End If
                    brrows = brrows + 1
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
                If c22 > 0 Or c32 > 0 Or c42 > 0 Or c52 > 0 Or c62 > 0 Then
                    If c22 > 0 Then
                        Chart2.Series("Otnoshenie").Points.AddXY("Двойки брой- " & c22, c22)
                    End If
                    If c32 > 0 Then
                        Chart2.Series("Otnoshenie").Points.AddXY("Тройки брой- " & c32, c32)
                    End If
                    If c42 > 0 Then
                        Chart2.Series("Otnoshenie").Points.AddXY("Четворки брой- " & c42, c42)
                    End If
                    If c52 > 0 Then
                        Chart2.Series("Otnoshenie").Points.AddXY("Петици брой- " & c52, c52)
                    End If
                    If c62 > 0 Then
                        Chart2.Series("Otnoshenie").Points.AddXY("Шестици брой- " & c62, c62)
                    End If
                    Chart1.Width = 620
                    Chart2.Visible = True
                    Chart2.Series(0)("PieLabelStyle") = "Outside"
                Else
                    Chart1.Width = 1265
                    Chart2.Visible = False
                End If

                flagbtn = 1
                'оголемяване на формата
                Chart1.Visible = True
                Me.Height = 740
            Else
                MsgBox("За този випуск не са въведени оценки!!!", , "Справка")
                flagbtn = 0
            End If
            cnn.Close()

        Else
            MsgBox("Трябва да се върнете и да веведете оценки ! ! !", , "Справка")
        End If
    End Sub
    Private Sub cmdmaxmin(ByRef dt As DataTable)
        Dim scom As String
        scom = ""
        'задаванена на команда оттип String в променлива coms в зависимост от избрания начин на сортиране
        Call sminmax(scom)
        If scom <> "" Then
            cmd = New MySqlCommand(scom, cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            adaptre.Fill(dt)
            'progressBar Стойностите му се актоализират
            prb1.Maximum = dt.Rows.Count
            prb1.Value = 0
            'връщане на dataReader, който е със сойности от изпълнената команда
            RRowsCount = dt.Rows.Count
        End If
    End Sub
    Private Sub sminmax(ByRef r As String)
        'В зависимуст от избраните параметри се връща низ със комндата
        If cmbtype.Text <> cmbtype.Items(0) Then
            If cmbSubject.Text <> cmbSubject.Items(0) Then
                r = "SELECT classes.school_year, sum(count_2) as c2, sum(count_3) as c3, sum(count_4) as c4, sum(count_5) as c5, sum(count_6) as c6 " _
                                & "FROM classes  Inner join purpose" _
                                & " ON classes.id=purpose.class Where classes.grade='" & cmbClass.Text & "'and purpose.type='" & cmbIdType.Text & "'and purpose.subject='" & cmbSubjectId.Text _
                                & "'and school_year='" & cmbYear.Text & "'or school_year='" & cmbYear.Text - 1 _
                                & "' Group by classes.school_year;"
            Else
                r = "SELECT classes.school_year,  sum(count_2) as c2, sum(count_3) as c3, sum(count_4) as c4, sum(count_5) as c5, sum(count_6) as c6 " _
                                & "FROM classes Inner join purpose" _
                                & " ON classes.id=purpose.class Where classes.grade='" & cmbClass.Text & "'and purpose.type='" & cmbIdType.Text _
                                & "'and school_year='" & cmbYear.Text & "'or school_year='" & cmbYear.Text - 1 _
                                & "' Group by classes.school_year;"
            End If
        Else
            If cmbSubject.Text <> cmbSubject.Items(0) Then
                r = "SELECT classes.school_year, sum(count_2) as c2, sum(count_3) as c3, sum(count_4) as c4, sum(count_5) as c5, sum(count_6) as c6 " _
                                & "FROM classes Inner join purpose" _
                                & " ON classes.id=purpose.class Where classes.grade='" & cmbClass.Text _
                                & "'and purpose.subject='" & cmbSubjectId.Text _
                               & "'and school_year='" & cmbYear.Text & "'or school_year='" & cmbYear.Text - 1 & "' Group by classes.school_year having purpose.subject='" & cmbSubjectId.Text & "';"
            Else
                r = "SELECT classes.school_year,  sum(count_2) as c2, sum(count_3) as c3, sum(count_4) as c4, sum(count_5) as c5, sum(count_6) as c6 " _
                                & "FROM classes Inner join purpose" _
                                & " ON classes.id=purpose.class Where classes.grade='" & cmbClass.Text & "'and school_year='" & cmbYear.Text & "'or school_year='" & cmbYear.Text - 1 _
                                & "' Group by classes.school_year;"

            End If
        End If
    End Sub

    Private Sub btnExselNewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExselNewFile.Click
        If cmbYear.Text <> "" Then
            Dim y As String
            y = cmbYear.Text & "/" & cmbYear.Text Mod 100 + 1
            title2 = "Съотношение на оценките по брой за 2 години: "
            title2 = title2 & y & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
            Dim r As DataTable = New DataTable
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
                xlsheet = xlbook.Sheets("sheet1")
                xlsheet.Name = "Съотношение на оценките по брой"
                xldi = New Microsoft.Office.Interop.Excel.Chart
                Const xlCenter = -4108
                xlsheet.Range(xlsheet.Cells(1, 1), xlsheet.Cells(1, 5)).Merge()
                xlsheet.Range(xlsheet.Cells(1, 1), xlsheet.Cells(1, 2)).HorizontalAlignment = xlCenter
                xlsheet.Cells(1, 1) = title1

                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 2)).Merge()
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 2)).HorizontalAlignment = xlCenter
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 2)).WrapText = True

                xlsheet.Range(xlsheet.Cells(2, 4), xlsheet.Cells(2, 5)).Merge()
                xlsheet.Range(xlsheet.Cells(2, 4), xlsheet.Cells(2, 5)).HorizontalAlignment = xlCenter
                xlsheet.Range(xlsheet.Cells(2, 4), xlsheet.Cells(2, 5)).WrapText = True

                xlsheet.Range(xlsheet.Cells(2, 3), xlsheet.Cells(8, 3)).Merge()

                xlsheet.Cells(2, 1) = title2
                y = cmbYear.Text - 1 & "/" & cmbYear.Text Mod 100
                title2 = "Съотношение на оценките по брой за 2 години: "
                title2 = title2 & y & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
                xlsheet.Cells(2, 4) = title2

                xlsheet.Cells(3, 1) = "Oценка"
                xlsheet.Cells(3, 2) = "Брой"
                xlsheet.Cells(3, 4) = "Oценка"
                xlsheet.Cells(3, 5) = "Брой"

                xlsheet.Range(xlsheet.Cells(3, 1), xlsheet.Cells(3, 5)).HorizontalAlignment = xlCenter

                xlsheet.Range("A3").EntireColumn.ColumnWidth = 24
                xlsheet.Range("B3").EntireColumn.ColumnWidth = 30
                xlsheet.Range("C3").EntireColumn.ColumnWidth = 10
                xlsheet.Range("D3").EntireColumn.ColumnWidth = 24
                xlsheet.Range("E3").EntireColumn.ColumnWidth = 30

                xlsheet.Range("A2").EntireRow.RowHeight = 50

                Dim pat As String
                pat = SaveFileDialog1.FileName

                Dim chartPage, chartPage2 As Microsoft.Office.Interop.Excel.Chart
                Dim xlCharts, xlCharts2 As Microsoft.Office.Interop.Excel.ChartObjects
                Dim myChart, myChart2 As Microsoft.Office.Interop.Excel.ChartObject
                Dim chartRange, chartRange2 As Microsoft.Office.Interop.Excel.Range

                xlCharts = xlsheet.ChartObjects
                myChart = xlCharts.Add(5, 160, 280, 200)
                chartPage = myChart.Chart

                xlCharts2 = xlsheet.ChartObjects
                myChart2 = xlCharts2.Add(355, 160, 280, 200)
                chartPage2 = myChart2.Chart


                chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlPie
                chartPage2.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlPie
                'извикване на функция cmdmaxmi, която връща datareader и проверка тя дали е пълна
                cmdmaxmin(r)
                If RRowsCount > 0 Then
                    Dim c22, c32, c42, c52, c62, year, brrows As Integer
                    Dim c2, c3, c4, c5, c6 As Integer
                    brrows = 0
                    prb1.Value = 0
                    prb1.Maximum = RRowsCount
                    'четене на datareader, изчисляване на данните и тяхното записване в excel
                    year = cmbYear.Text
                    c22 = 0
                    c32 = 0
                    c42 = 0
                    c52 = 0
                    c62 = 0
                    Do While r.Rows.Count > brrows
                        If r.Rows(brrows).Item("school_year") = year Then
                            c2 = c2 + r.Rows(brrows).Item("c2")
                            c3 = c3 + r.Rows(brrows).Item("c3")
                            c4 = c4 + r.Rows(brrows).Item("c4")
                            c5 = c5 + r.Rows(brrows).Item("c5")
                            c6 = c6 + r.Rows(brrows).Item("c6")
                        Else
                            c22 = c22 + r.Rows(brrows).Item("c2")
                            c32 = c32 + r.Rows(brrows).Item("c3")
                            c42 = c42 + r.Rows(brrows).Item("c4")
                            c52 = c52 + r.Rows(brrows).Item("c5")
                            c62 = c62 + r.Rows(brrows).Item("c6")
                        End If
                        prb1.Value = prb1.Value + 1
                        brrows = brrows + 1
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
                    xlsheet.Cells(4, 4) = "Слаб"
                    xlsheet.Cells(4, 5) = c22
                    xlsheet.Cells(5, 4) = "Среден"
                    xlsheet.Cells(5, 5) = c32
                    xlsheet.Cells(6, 4) = "Добър"
                    xlsheet.Cells(6, 5) = c42
                    xlsheet.Cells(7, 4) = "Много добър"
                    xlsheet.Cells(7, 5) = c52
                    xlsheet.Cells(8, 4) = "Отличен"
                    xlsheet.Cells(8, 5) = c62

                    xlsheet.Range(xlsheet.Cells(3, 1), xlsheet.Cells(8, 5)).HorizontalAlignment = xlCenter
                    chartRange = xlsheet.Range("A4:B8")
                    chartPage.SetSourceData(Source:=chartRange)

                    chartRange2 = xlsheet.Range("D4:E8")
                    chartPage2.SetSourceData(Source:=chartRange2)

                    'Смаляване на формата
                    Me.Height = 380
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
            'викане на функция RazExcel в койято са записани разширенията на Excel
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
                    Dim y As String
                    ws.Name = "Съотношение на оценките по брой"
                    y = cmbYear.Text & "/" & cmbYear.Text Mod 100 + 1
                    title2 = "Съотношение на оценките по брой за 2 години: "
                    title2 = title2 & y & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
                    Dim r As DataTable = New DataTable
                    Dim xldi, xldi2 As Microsoft.Office.Interop.Excel.Chart
                    Dim chartRange, chartRange2 As Microsoft.Office.Interop.Excel.Range
                    xldi = New Microsoft.Office.Interop.Excel.Chart
                    xldi2 = New Microsoft.Office.Interop.Excel.Chart
                    Const xlCenter = -4108
                    ws.Range(ws.Cells(1, 1), ws.Cells(1, 5)).Merge()
                    ws.Range(ws.Cells(1, 1), ws.Cells(1, 2)).HorizontalAlignment = xlCenter
                    ws.Cells(1, 1) = title1
                    ws.Range(ws.Cells(2, 1), ws.Cells(2, 2)).Merge()
                    ws.Range(ws.Cells(2, 1), ws.Cells(2, 2)).HorizontalAlignment = xlCenter
                    ws.Range(ws.Cells(2, 1), ws.Cells(2, 2)).WrapText = True

                    ws.Range(ws.Cells(2, 4), ws.Cells(2, 5)).Merge()
                    ws.Range(ws.Cells(2, 4), ws.Cells(2, 5)).HorizontalAlignment = xlCenter
                    ws.Range(ws.Cells(2, 4), ws.Cells(2, 5)).WrapText = True
                    ws.Cells(2, 1) = title2
                    ws.Cells(3, 1) = "Oценка"
                    ws.Cells(3, 2) = "Брой"
                    ws.Cells(3, 4) = "Oценка"
                    ws.Cells(3, 5) = "Брой"
                    ws.Range(ws.Cells(3, 1), ws.Cells(3, 5)).HorizontalAlignment = xlCenter
                    ws.Range(ws.Cells(2, 3), ws.Cells(8, 3)).Merge()
                    ws.Range("A3").EntireColumn.ColumnWidth = 24
                    ws.Range("B3").EntireColumn.ColumnWidth = 30
                    ws.Range("C3").EntireColumn.ColumnWidth = 10
                    ws.Range("D3").EntireColumn.ColumnWidth = 24
                    ws.Range("E3").EntireColumn.ColumnWidth = 30
                    ws.Range("A2").EntireRow.RowHeight = 50
                    y = cmbYear.Text - 1 & "/" & cmbYear.Text Mod 100
                    title2 = "Съотношение на оценките по брой за 2 години: "
                    title2 = title2 & y & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
                    ws.Cells(2, 4) = title2

                    Dim chartPage, chartPage2 As Microsoft.Office.Interop.Excel.Chart
                    Dim xlCharts, xlCharts2 As Microsoft.Office.Interop.Excel.ChartObjects
                    Dim myChart, myChart2 As Microsoft.Office.Interop.Excel.ChartObject

                    xlCharts = ws.ChartObjects
                    myChart = xlCharts.Add(5, 160, 280, 200)
                    chartPage = myChart.Chart
                    chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlPie

                    xlCharts2 = ws.ChartObjects
                    myChart2 = xlCharts2.Add(355, 160, 280, 200)
                    chartPage2 = myChart2.Chart
                    chartPage2.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlPie

                    'извикване на функция cmdmaxmi, която връща datareader и проверка тя дали е пълна
                    cmdmaxmin(r)
                    If RRowsCount > 0 Then


                        Dim c2, c3, c4, c5, c6, brrows As Integer
                        Dim c22, c32, c42, c52, c62, year As Integer
                        brrows = 0
                        year = cmbYear.Text
                        ' четене на datareader, изчисляване на данните и тяхното записване в excel
                        Do While brrows < r.Rows.Count
                            If r.Rows(brrows).Item("school_year") = year Then
                                c2 = c2 + r.Rows(brrows).Item("c2")
                                c3 = c3 + r.Rows(brrows).Item("c3")
                                c4 = c4 + r.Rows(brrows).Item("c4")
                                c5 = c5 + r.Rows(brrows).Item("c5")
                                c6 = c6 + r.Rows(brrows).Item("c6")
                            Else
                                c22 = c22 + r.Rows(brrows).Item("c2")
                                c32 = c32 + r.Rows(brrows).Item("c3")
                                c42 = c42 + r.Rows(brrows).Item("c4")
                                c52 = c52 + r.Rows(brrows).Item("c5")
                                c62 = c62 + r.Rows(brrows).Item("c6")
                            End If

                            prb1.Value = prb1.Value + 1
                            brrows = brrows + 1
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

                        ws.Cells(4, 4) = "Слаб"
                        ws.Cells(4, 5) = c22
                        ws.Cells(5, 4) = "Среден"
                        ws.Cells(5, 5) = c32
                        ws.Cells(6, 4) = "Добър"
                        ws.Cells(6, 5) = c42
                        ws.Cells(7, 4) = "Много добър"
                        ws.Cells(7, 5) = c52
                        ws.Cells(8, 4) = "Отличен"
                        ws.Cells(8, 5) = c62

                        ws.Range(ws.Cells(3, 1), ws.Cells(8, 5)).HorizontalAlignment = xlCenter
                        chartRange = ws.Range("A4", "B8")
                        chartPage.SetSourceData(Source:=chartRange)

                        chartRange2 = ws.Range("D4", "E8")
                        chartPage2.SetSourceData(Source:=chartRange2)

                        ws.Copy(, masterWb.Sheets(masterWb.Sheets.Count))


                        ws = Nothing
                        xlWorkBook.Save()
                        xlWorkBook.Close()
                        xlWorkBook = Nothing
                        'Смаляване на формата
                        Me.Height = 380
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
                    MsgBox("Грешка ! ! !" & ex.Message)
                End Try

                cnn.Close()
            End If
        Else
            MsgBox("Трябва да се върнете и да веведете оценки ! ! !", , "Справка")
        End If
    End Sub

    Private Sub btnWordNewFIle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWordNewFIle.Click
        If cmbYear.Text <> "" Then
            Dim razWor As String
            'викане на функция RazWord в койято са записани разширенията на word
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
                Dim oPara1, oPara2 As Microsoft.Office.Interop.Word.Paragraph
                oWord = CreateObject("Word.Application")
                'задаване на текст, вкарваненатаблица и нейното форматиране
                oDoc = oWord.Documents.Add
                oPara1 = oDoc.Content.Paragraphs.Add
                oPara1.Range.Font.Size = 20
                oPara1.Range.Font.Bold = True
                oPara1.Range.Text = title1
                Dim y As String
                oPara1.Alignment = HorizontalAlignment.Right
                oPara1.Format.SpaceAfter = 24
                oPara1.Range.InsertParagraphAfter()
                oPara1.Range.Font.Size = 14
                oPara1.Range.Font.Bold = True
                y = cmbYear.Text & "/" & cmbYear.Text Mod 100 + 1
                title2 = "Съотношение на оценките по брой за 2 години: "
                title2 = title2 & y & " - " & cmbYear.Text - 1 & "/" & cmbYear.Text Mod 100 & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
                oPara2 = oDoc.Content.Paragraphs.Add
                oPara2.Range.Text = title2
                oPara2.Range.Font.Bold = False

                oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, 6, 3)
                y = cmbYear.Text - 1 & "/" & cmbYear.Text Mod 100
                'извикване на функция cmdmaxmi, която връща datareader и проверка тя дали е пълна 
                Dim r As DataTable = New DataTable
                cmdmaxmin(r)
                If RRowsCount > 0 Then

                    prb1.Value = 0
                    prb1.Maximum = RRowsCount
                    oTable.Cell(1, 1).Range.Text = "Оценка"
                    oTable.Cell(1, 2).Range.Text = cmbYear.Text & "/" & cmbYear.Text Mod 100 + 1
                    oTable.Cell(1, 3).Range.Text = cmbYear.Text & "/" & cmbYear.Text Mod 100 + 1
                    Dim c2, c3, c4, c5, c6 As Integer
                    Dim c22, c32, c42, c52, c62, brrows, year As Integer
                    'четене на datareader, изчисляване на данните и тяхното записване в excel

                    brrows = 0
                    year = cmbYear.Text
                    ' четене на datareader, изчисляване на данните и тяхното записване в excel
                    Do While brrows < r.Rows.Count
                        If r.Rows(brrows).Item("school_year") = year Then
                            c2 = c2 + r.Rows(brrows).Item("c2")
                            c3 = c3 + r.Rows(brrows).Item("c3")
                            c4 = c4 + r.Rows(brrows).Item("c4")
                            c5 = c5 + r.Rows(brrows).Item("c5")
                            c6 = c6 + r.Rows(brrows).Item("c6")
                        Else
                            c22 = c22 + r.Rows(brrows).Item("c2")
                            c32 = c32 + r.Rows(brrows).Item("c3")
                            c42 = c42 + r.Rows(brrows).Item("c4")
                            c52 = c52 + r.Rows(brrows).Item("c5")
                            c62 = c62 + r.Rows(brrows).Item("c6")
                        End If

                        prb1.Value = prb1.Value + 1
                        brrows = brrows + 1
                    Loop
                    oTable.Cell(2, 1).Range.Text = "Слаб"
                    oTable.Cell(3, 1).Range.Text = "Среден"
                    oTable.Cell(4, 1).Range.Text = "Добър"
                    oTable.Cell(5, 1).Range.Text = "Много добър"
                    oTable.Cell(6, 1).Range.Text = "Отличен"

                    oTable.Cell(2, 2).Range.Text = c2
                    oTable.Cell(3, 2).Range.Text = c3
                    oTable.Cell(4, 2).Range.Text = c4
                    oTable.Cell(5, 2).Range.Text = c5
                    oTable.Cell(6, 2).Range.Text = c6

                    oTable.Cell(2, 3).Range.Text = c22
                    oTable.Cell(3, 3).Range.Text = c32
                    oTable.Cell(4, 3).Range.Text = c42
                    oTable.Cell(5, 3).Range.Text = c52
                    oTable.Cell(6, 3).Range.Text = c62
                    'форматиране на таблицата
                    oTable.Range.Style = "Table Grid"
                    'смаляване на формата
                    Me.Height = 380
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

    Private Sub Reference_VA_Year_Vipusk_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Do While dgv1.RowCount > 0
            dgv1.Rows.Remove(dgv1.Rows(0))
        Loop
        Me.Height = 371
        'Проверка дали chart1 е празно
        Chart1.Series.Clear()
        Chart1.Legends.Clear()
        Chart1.Titles.Clear()
        Chart2.Series.Clear()
        Chart2.Legends.Clear()
        Chart2.Titles.Clear()
        Do While cmbYear.Items.Count > 0
            cmbVipusk.Items.Remove(cmbVipusk.Items(0))
            cmbYear.Items.Remove(cmbYear.Items(0))
        Loop

        Do While cmbtype.Items.Count > 1
            cmbtype.Items.Remove(cmbtype.Items(1))
            cmbIdType.Items.Remove(cmbIdType.Items(1))
        Loop

        Do While cmbSubject.Items.Count > 1
            cmbSubject.Items.Remove(cmbSubject.Items(1))
            cmbSubjectId.Items.Remove(cmbSubjectId.Items(1))
        Loop
    End Sub
End Class