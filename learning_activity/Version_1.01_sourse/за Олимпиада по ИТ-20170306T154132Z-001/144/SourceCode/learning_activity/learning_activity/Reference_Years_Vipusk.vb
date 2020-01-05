'използване на MySQL Data
Imports MySql.Data.MySqlClient
Public Class Reference_Years_Vipusk
    'деклариране на глобални променливи
    Dim cnn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim years, title1, title2, flagbtn As String
    Dim a, b, RRowsCount As Integer
    Private Sub Reference_Years_Clases_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Отваряне на връската със SURVER
        Call Module1.hosts(cnn)
        cnn.Open()
        Dim brRows, flag As Integer
        brRows = 0
        title1 = "Справка"
        title2 = "Випуските през годините: "

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
    Private Sub cmbVipusk_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbVipusk.DropDownClosed, cmbVipusk.Leave
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
                Chart1.Series.Clear()
                Chart1.Legends.Clear()
                Chart1.Titles.Clear()
            End If
            title2 = "Успех по класове за 2 години: "
            title2 = title2 & cmbVipusk.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
            Dim r As DataTable = New DataTable
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


                Chart1.Titles.Add(title1)
                Chart1.Titles.Add(title2)
                Dim classes, class22, class1, otd As String
                Dim grade, y1, brrows As Integer
                Dim max As Double
                otd = ""
                prb1.Value = 0
                prb1.Maximum = RRowsCount
                brrows = 0
                Dim row As Integer = 0
                Chart1.Series.Clear()
                Chart1.Series.Add(cmbYear.Text & "/" & cmbYear.Text Mod 100 + 1)
                Chart1.Series.Add(cmbYear.Text - 1 & "/" & cmbYear.Text Mod 100)
                Chart1.Legends.Clear()
                Chart1.Legends.Add(0)
                Chart1.ChartAreas.Item(0).AxisX.CustomLabels.Clear()
                Dim row1, row2 As Integer
                row1 = 0
                row2 = 0
                Do While brrows < r.Rows.Count
                    grade = r.Rows(brrows).Item("grade")
                    classes = r.Rows(brrows).Item("class")
                    max = r.Rows(brrows).Item("sreden_uspeh")
                    y1 = r.Rows(brrows).Item("school_year")
                    If y1 = cmbYear.Text Then
                        prb1.Value = prb1.Value + 1
                        ' оценка с думи
                        class1 = grade & " " & classes

                        Chart1.Series(0).Points.AddXY(row, max)
                        Chart1.ChartAreas.Item(0).AxisX.CustomLabels.Add(row - 0.5, row + 0.5, class1)
                        Chart1.Series(0).Points(row1).Label = Math.Round(max, 2)
                        row1 = row1 + 1
                        brrows = brrows + 1
                        If brrows < r.Rows.Count Then
                            grade = r.Rows(brrows).Item("grade")
                            class22 = r.Rows(brrows).Item("class")
                            If class22 = classes Then
                                max = r.Rows(brrows).Item("sreden_uspeh")
                                y1 = r.Rows(brrows).Item("school_year")
                                prb1.Value = prb1.Value + 1
                                ' оценка с думи
                                class1 = grade & " " & classes
                                Chart1.Series(1).Points.AddXY(row, max)
                                Chart1.Series(1).Points(row2).Label = Math.Round(max, 2)
                                row2 = row2 + 1
                                brrows = brrows + 1
                            End If
                        End If
                        row = row + 1
                    Else
                        brrows = brrows + 1
                        prb1.Value = prb1.Value + 1
                    End If

                Loop
                flagbtn = 1
                'оголемяване на формата
                Chart1.Visible = True
                Me.Height = 745
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
                r = "SELECT classes.grade, classes.class, classes.school_year, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                              & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes  Inner join purpose" _
                                              & " ON classes.id=purpose.class Where classes.grade='" & cmbClass.Text & "'and purpose.type='" & cmbIdType.Text & "'and purpose.subject='" & cmbSubjectId.Text _
                                              & "'and (school_year='" & cmbYear.Text & "'or school_year='" & cmbYear.Text - 1 _
                                              & "')Group by purpose.class order by classes.class;"

            Else
                r = "SELECT classes.grade, classes.class,classes.school_year,  (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                                            & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                                            & " ON classes.id=purpose.class Where classes.grade='" & cmbClass.Text & "'and purpose.type='" & cmbIdType.Text _
                                                            & "'and (school_year='" & cmbYear.Text & "'or school_year='" & cmbYear.Text - 1 _
                                                            & "') Group by purpose.class order by classes.class;"
            End If
        Else
            If cmbSubject.Text <> cmbSubject.Items(0) Then

                r = "SELECT classes.grade, classes.class, purpose.subject,classes.school_year, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                              & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                              & " ON classes.id=purpose.class Where classes.grade='" & cmbClass.Text _
                                              & "'and purpose.subject='" & cmbSubjectId.Text & _
                                              "'and (school_year='" & cmbYear.Text & "'or school_year='" & cmbYear.Text - 1 & "') Group by purpose.class having purpose.subject='" & cmbSubjectId.Text & "' order by classes.class;"


            Else
                r = "SELECT classes.grade, classes.class,classes.school_year,  (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                                            & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                                            & " ON classes.id=purpose.class Where classes.grade='" & cmbClass.Text & "'and (school_year='" & cmbYear.Text & "'or school_year='" & cmbYear.Text - 1 _
                                                            & "') Group by  purpose.class order by classes.class;"
            End If
        End If
    End Sub
    Private Sub btnExselNewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExselNewFile.Click
        If cmbYear.Text <> "" Then
            title2 = "Успех по класове за 2 години: "
            title2 = title2 & cmbVipusk.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
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

                xlapp = New Microsoft.Office.Interop.Excel.Application
                'задаване на текст в клетки и форматиране на редове и колони
                xlbook = xlapp.Workbooks.Add(misvalue)
                xlsheet = xlbook.Sheets("sheet1")
                xlsheet.Name = "Усп. по кла-ве за 2 год."
                xldi = New Microsoft.Office.Interop.Excel.Chart
                Const xlCenter = -4108
                xlsheet.Range(xlsheet.Cells(1, 1), xlsheet.Cells(1, 3)).Merge()
                xlsheet.Range(xlsheet.Cells(1, 1), xlsheet.Cells(1, 3)).HorizontalAlignment = xlCenter
                xlsheet.Cells(1, 1) = title1
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 3)).Merge()
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 3)).HorizontalAlignment = xlCenter
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 3)).WrapText = True
                xlsheet.Cells(2, 1) = title2
                xlsheet.Cells(3, 2) = cmbYear.Text & "/" & cmbYear.Text Mod 100 + 1
                xlsheet.Cells(3, 3) = cmbYear.Text - 1 & "/" & cmbYear.Text Mod 100
                xlsheet.Range(xlsheet.Cells(3, 1), xlsheet.Cells(3, 3)).HorizontalAlignment = xlCenter
                xlsheet.Range("A3").EntireColumn.ColumnWidth = 20
                xlsheet.Range("B3").EntireColumn.ColumnWidth = 30
                xlsheet.Range("C3").EntireColumn.ColumnWidth = 15
                xlsheet.Range("A2").EntireRow.RowHeight = 35
                Dim pat As String
                pat = SaveFileDialog1.FileName

                Chart1.Visible = True
                Dim chartPage As Microsoft.Office.Interop.Excel.Chart
                Dim xlCharts As Microsoft.Office.Interop.Excel.ChartObjects
                Dim myChart As Microsoft.Office.Interop.Excel.ChartObject
                Dim chartRange As Microsoft.Office.Interop.Excel.Range
                xlCharts = xlsheet.ChartObjects
                myChart = xlCharts.Add(370, 50, 600, 250)
                chartPage = myChart.Chart
                chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlColumnClustered
                'извикване на функция cmdmaxmi, която връща datareader и проверка тя дали е пълна 
                cmdmaxmin(r)
                If RRowsCount > 0 Then
                    Dim classes, class22, class1, otd As String
                    Dim grade, y1, brrows, br As Integer
                    Dim max As Double
                    otd = ""
                    prb1.Value = 0
                    br = 4

                    prb1.Maximum = RRowsCount
                    brrows = 0
                    Do While brrows < r.Rows.Count
                        grade = r.Rows(brrows).Item("grade")
                        classes = r.Rows(brrows).Item("class")
                        max = r.Rows(brrows).Item("sreden_uspeh")
                        y1 = r.Rows(brrows).Item("school_year")
                        If y1 = cmbYear.Text Then
                            prb1.Value = prb1.Value + 1
                            ' оценка с думи
                            class1 = grade & " " & classes
                            xlsheet.Cells(br, 1) = class1
                            xlsheet.Cells(br, 2) = max
                            xlsheet.Range(xlsheet.Cells(br, 1), xlsheet.Cells(br, 3)).HorizontalAlignment = xlCenter
                            chartRange = xlsheet.Range("A3:C" & br)
                            chartPage.SetSourceData(Source:=chartRange)
                            brrows = brrows + 1
                            If brrows < r.Rows.Count Then
                                grade = r.Rows(brrows).Item("grade")
                                class22 = r.Rows(brrows).Item("class")
                                If class22 = classes Then
                                    max = r.Rows(brrows).Item("sreden_uspeh")
                                    y1 = r.Rows(brrows).Item("school_year")
                                    prb1.Value = prb1.Value + 1
                                    class1 = grade & " " & classes
                                    xlsheet.Cells(br, 3) = max
                                    xlsheet.Range(xlsheet.Cells(br, 1), xlsheet.Cells(br, 3)).HorizontalAlignment = xlCenter
                                    chartRange = xlsheet.Range("A3:C" & br)
                                    chartPage.SetSourceData(Source:=chartRange)
                                    brrows = brrows + 1
                                End If
                            End If
                            br = br + 1
                        Else
                            brrows = brrows + 1
                            prb1.Value = prb1.Value + 1
                        End If

                    Loop
                    chartPage.HasTitle = True
                    chartPage.ChartTitle.Text = xlsheet.Range("A2").Value()
                    'Смаляване на формата
                    chartPage.PlotBy = Microsoft.Office.Interop.Excel.XlRowCol.xlColumns
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
                Else
                    MsgBox("За този випуск не са въведени оценки!!!", , "Справка")
                    flagbtn = 0
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

                'Try
                'задаване на текст в клетки и форматиране на редове и колони
                ws = xlWorkBook.Sheets.Add(, xlWorkBook.Sheets(xlWorkBook.Sheets.Count))
                ws.Name = "Усп. по кла-ве за 2 години"
                title2 = "Успех по класове за 2 години: "
                title2 = title2 & cmbVipusk.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text

                Dim r As DataTable = New DataTable
                Dim xldi As Microsoft.Office.Interop.Excel.Chart

                xldi = New Microsoft.Office.Interop.Excel.Chart

                Const xlCenter = -4108
                ws.Range(ws.Cells(1, 1), ws.Cells(1, 3)).Merge()
                ws.Range(ws.Cells(1, 1), ws.Cells(1, 3)).HorizontalAlignment = xlCenter
                ws.Cells(1, 1) = title1
                ws.Range(ws.Cells(2, 1), ws.Cells(2, 3)).Merge()
                ws.Range(ws.Cells(2, 1), ws.Cells(2, 3)).HorizontalAlignment = xlCenter
                ws.Range(ws.Cells(2, 1), ws.Cells(2, 3)).WrapText = True
                ws.Cells(2, 1) = title2
                ws.Cells(3, 2) = cmbYear.Text & "/" & cmbYear.Text Mod 100 + 1
                ws.Cells(3, 3) = cmbYear.Text - 1 & "/" & cmbYear.Text Mod 100
                ws.Range(ws.Cells(3, 1), ws.Cells(3, 3)).HorizontalAlignment = xlCenter
                ws.Range("A3").EntireColumn.ColumnWidth = 20
                ws.Range("B3").EntireColumn.ColumnWidth = 30
                ws.Range("C3").EntireColumn.ColumnWidth = 15

                ws.Range("A2").EntireRow.RowHeight = 35

                Dim bi, ci As String

                bi = "B" & 4
                ci = "B" & 4
                Dim chartPage As Microsoft.Office.Interop.Excel.Chart
                Dim xlCharts As Microsoft.Office.Interop.Excel.ChartObjects
                Dim myChart As Microsoft.Office.Interop.Excel.ChartObject
                Dim chartRange As Microsoft.Office.Interop.Excel.Range


                xlCharts = ws.ChartObjects
                myChart = xlCharts.Add(370, 50, 600, 250)
                chartPage = myChart.Chart

                chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlColumnClustered
                'извикване на функция cmdmaxmi, която връща datareader и проверка тя дали е пълна
                cmdmaxmin(r)
                If RRowsCount > 0 Then
                    Dim classes, class1, class22, otd As String
                    Dim grade, br, brrows, y1 As Integer
                    Dim max As Double
                    otd = ""
                    br = 4

                    ' четене на datareader, изчисляване на данните и тяхното записване в excel
                    brrows = 0

                    Do While brrows < r.Rows.Count
                        grade = r.Rows(brrows).Item("grade")
                        classes = r.Rows(brrows).Item("class")
                        max = r.Rows(brrows).Item("sreden_uspeh")
                        y1 = r.Rows(brrows).Item("school_year")
                        If y1 = cmbYear.Text Then
                            class1 = grade & " " & classes
                            ws.Cells(br, 1) = class1
                            ws.Cells(br, 2) = max
                            ws.Range(ws.Cells(br, 1), ws.Cells(br, 3)).HorizontalAlignment = xlCenter
                            chartRange = ws.Range("A3:C" & br)
                            chartPage.SetSourceData(Source:=chartRange)

                            brrows = brrows + 1
                            prb1.Value = prb1.Value + 1
                            If brrows < r.Rows.Count Then
                                grade = r.Rows(brrows).Item("grade")
                                class22 = r.Rows(brrows).Item("class")
                                If class22 = classes Then
                                    max = r.Rows(brrows).Item("sreden_uspeh")
                                    y1 = r.Rows(brrows).Item("school_year")
                                    prb1.Value = prb1.Value + 1
                                    class1 = grade & " " & classes
                                    ws.Cells(br, 3) = max

                                    ws.Range(ws.Cells(br, 1), ws.Cells(br, 3)).HorizontalAlignment = xlCenter
                                    chartRange = ws.Range("A3:C" & br)
                                    chartPage.SetSourceData(Source:=chartRange)

                                    brrows = brrows + 1

                                End If
                            End If
                            br = br + 1
                        Else
                            prb1.Value = prb1.Value + 1
                            brrows = brrows + 1
                        End If

                    Loop
                    chartPage.HasTitle = True
                    chartPage.ChartTitle.Text = ws.Range("A2").Value()
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
                    'питане дали да се отвори файла 
                    cnn.Close()
                    Dim res As MsgBoxResult
                    res = MsgBox("Искате ли файлът да се отвори?", MsgBoxStyle.YesNo, "Справка")
                    If res = MsgBoxResult.Yes Then
                        Process.Start(pat)
                    End If

                End If
                ' Catch ex As Exception
                'MsgBox("ERROR -  " & ex.Message)
                ' End Try

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

                title2 = "Успех по класове за 2 години: "
                title2 = title2 & cmbVipusk.Text & ", предмет: " & cmbSubject.Text & " , вид оценка: " & cmbtype.Text
                oPara2 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
                oPara2.Range.Text = title2
                oPara2.Format.SpaceAfter = 6
                oPara2.Range.InsertParagraphAfter()

                Dim r As DataTable = New DataTable

                'извикване на функция cmdmaxmi, която връща datareader и проверка тя дали е пълна 
                cmdmaxmin(r)
                If RRowsCount > 0 Then

                    Dim classes, class1, otd As String
                    Dim grade, br As Integer
                    Dim max As Double
                    otd = ""
                    br = 2
                    prb1.Value = 0
                    prb1.Maximum = RRowsCount

                    'четене на datareader, изчисляване на данните и тяхното записване в excel
                    Dim brrows, y1 As Integer
                    brrows = 0
                    br = 0
                    Dim m(r.Rows.Count, 3) As String
                    Dim class22 As String
                    Do While brrows < r.Rows.Count

                        grade = r.Rows(brrows).Item("grade")
                        classes = r.Rows(brrows).Item("class")
                        max = r.Rows(brrows).Item("sreden_uspeh")
                        y1 = r.Rows(brrows).Item("school_year")
                        If y1 = cmbYear.Text Then
                            class1 = grade & " " & classes
                            m(br, 1) = class1
                            m(br, 2) = max
                            brrows = brrows + 1
                            prb1.Value = prb1.Value + 1
                            If brrows < r.Rows.Count Then
                                grade = r.Rows(brrows).Item("grade")
                                class22 = r.Rows(brrows).Item("class")
                                If class22 = classes Then
                                    max = r.Rows(brrows).Item("sreden_uspeh")
                                    y1 = r.Rows(brrows).Item("school_year")
                                    prb1.Value = prb1.Value + 1
                                    class1 = grade & " " & classes
                                    m(br, 3) = max
                                    brrows = brrows + 1
                                Else
                                    m(br, 3) = ""
                                End If

                            End If
                            br = br + 1
                        Else
                            prb1.Value = prb1.Value + 1
                            brrows = brrows + 1
                        End If

                    Loop
                    Dim oTable As Microsoft.Office.Interop.Word.Table

                    oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, br + 1, 3)
                    oTable.Cell(1, 1).Range.Text = " "
                    oTable.Cell(1, 2).Range.Text = cmbYear.Text & "/" & cmbYear.Text Mod 100 + 1
                    oTable.Cell(1, 3).Range.Text = cmbYear.Text - 1 & "/" & cmbYear.Text Mod 100
                    For i As Integer = 1 To br
                        oTable.Cell(i + 1, 1).Range.Text = m(i - 1, 1)
                        oTable.Cell(i + 1, 2).Range.Text = m(i - 1, 2)
                        oTable.Cell(i + 1, 3).Range.Text = m(i - 1, 3)
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
        Else
            MsgBox("Трябва да се върнете и да веведете оценки ! ! !", , "Справка")
        End If
    End Sub
    Private Sub Reference_Years_Vipusk_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'изтриване на старите сойности в dgv1
        Do While dgv1.RowCount > 0
            dgv1.Rows.Remove(dgv1.Rows(0))
        Loop
        Me.Height = 374
        'Проверка дали chart1 е празно
        If Chart1.Series.Count > 0 Then
            Chart1.Series.Clear()
            Chart1.Legends.Clear()
            Chart1.Titles.Clear()
        End If
        Do While cmbVipusk.Items.Count > 0
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

        prb1.Value = 0
    End Sub

End Class
