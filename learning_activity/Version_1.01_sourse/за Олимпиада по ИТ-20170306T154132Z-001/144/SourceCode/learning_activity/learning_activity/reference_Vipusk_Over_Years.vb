'използване на MySQL Data
Imports MySql.Data.MySqlClient
Public Class reference_Vipusk_Over_Years
    'деклариране на глобални променливи
    Dim cnn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim years, title1, title2, flagbtn As String
    Dim a, b, RRowsCount As Integer
    Private Sub reference_Vipusk_Over_Years_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Dim doc As Integer
            Dim yearot, yeardo As String
            Do While classesPodr(brRows, 1) <> 0
                grade = classesPodr(brRows, 1)
                years = classesPodr(brRows, 2)
                yearot = grade & " " & years & "/" & years Mod 100 + 1
                If grade = 1 Or grade = 5 Or grade = 8 Then
                    doc = 0
                ElseIf grade = 2 Or grade = 6 Or grade = 9 Then
                    doc = 1
                ElseIf grade = 3 Or grade = 7 Or grade = 10 Then
                    doc = 2
                ElseIf grade = 4 Or grade = 11 Then
                    doc = 3
                ElseIf grade = 12 Then
                    doc = 4
                End If
                yeardo = years - doc & "/" & years Mod 100 - doc + 1
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
            Dim scom As String
            scom = "Select* from classes where grade='" & grade & "' and school_year='" & years & "'"
            
            cmd = New MySqlCommand(scom, cnn)
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
            Dim cs1, cs2, cs3, cs4 As String
            scom = "Select* from  classes where school_year='" & years & "' and grade='" & grade & "'"
            cs1 = " or school_year='" & years - 1 & "' and grade='" & grade - 1 & "'"
            cs2 = " or school_year='" & years - 2 & "' and grade='" & grade - 2 & "'"
            cs3 = " or school_year='" & years - 3 & "' and grade='" & grade - 3 & "'"
            cs4 = " or school_year='" & years - 4 & "' and grade='" & grade - 4 & "'"

            If grade = 2 Or grade = 6 Or grade = 9 Then
                scom = scom & cs1
            ElseIf grade = 3 Or grade = 7 Or grade = 10 Then
                scom = scom & cs1 & cs2
            ElseIf grade = 4 Or grade = 11 Then
                scom = scom & cs1 & cs2 & cs3
            ElseIf grade = 12 Then
                scom = scom & cs1 & cs2 & cs3 & cs4
            End If
            cmd = New MySqlCommand(scom, cnn)
            cmd.ExecuteNonQuery()
            Dim adap As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data1 As DataTable = New DataTable
            adap.Fill(data1)
            Dim c2, c3, c4, c5, c6, id, nomer As Integer
            Dim subject, classes As String
            For i As Integer = 0 To data1.Rows.Count - 1
                idclass = data1.Rows(i).Item("id")
                classes = data1.Rows(i).Item("class")
                grade = data1.Rows(i).Item("grade")
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
                cmbClass.Text = cmbClass.Items(cmbVipusk.SelectedIndex)
                cmbYear.Text = cmbYear.Items(cmbVipusk.SelectedIndex)
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
                Dim scom As String
                Dim years, grade As Integer
                grade = cmbClass.Text
                years = cmbYear.Text
                scom = "Select* from classes where grade='" & grade & "' and school_year='" & years & "'"
                cmd = New MySqlCommand(scom, cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim data As DataTable = New DataTable
                adaptre.Fill(data)
                'Проверка дaли в таблица purpose има записи
                If data.Rows.Count > 0 Then
                    'ако има записи
                    Dim classesPodr(data.Rows.Count, 2) As Integer
                    'минаване през всчики редове на таблица purpose
                    brRows = 2
                    'търсене на оценките на випуска
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
                    Dim cs1, cs2, cs3, cs4 As String
                    scom = "Select* from  classes where school_year='" & years & "' and grade='" & grade & "'"
                    cs1 = " or school_year='" & years - 1 & "' and grade='" & grade - 1 & "'"
                    cs2 = " or school_year='" & years - 2 & "' and grade='" & grade - 2 & "'"
                    cs3 = " or school_year='" & years - 3 & "' and grade='" & grade - 3 & "'"
                    cs4 = " or school_year='" & years - 4 & "' and grade='" & grade - 4 & "'"

                    If grade = 2 Or grade = 6 Or grade = 9 Then
                        scom = scom & cs1
                    ElseIf grade = 3 Or grade = 7 Or grade = 10 Then
                        scom = scom & cs1 & cs2
                    ElseIf grade = 4 Or grade = 11 Then
                        scom = scom & cs1 & cs2 & cs3
                    ElseIf grade = 12 Then
                        scom = scom & cs1 & cs2 & cs3 & cs4
                    End If
                    cmd = New MySqlCommand(scom, cnn)
                    cmd.ExecuteNonQuery()
                    Dim adap As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim data1 As DataTable = New DataTable
                    adap.Fill(data1)
                    Dim c2, c3, c4, c5, c6, id, nomer As Integer
                    Dim subject, classes As String
                    For i As Integer = 0 To data1.Rows.Count - 1
                        idclass = data1.Rows(i).Item("id")
                        classes = data1.Rows(i).Item("class")
                        grade = data1.Rows(i).Item("grade")
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
            Dim brRows, flag As Integer
            brRows = 0
            Dim scom As String
            Dim years, grade As Integer
            grade = cmbClass.Text
            years = cmbYear.Text
            scom = "Select* from classes where grade='" & grade & "' and school_year='" & years & "'"
            cmd = New MySqlCommand(scom, cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            'Проверка дaли в таблица purpose има записи
            If data.Rows.Count > 0 Then
                'ако има записи
                Dim classesPodr(data.Rows.Count, 2) As Integer
                'минаване през всчики редове на таблица purpose
                brRows = 2
                'търсене на оценките на випуска
                cmd.ExecuteNonQuery()
                Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt As DataTable = New DataTable
                adaptre1.Fill(dt)
                Dim brrows2 As Integer = 0
                brRows = 0
                Dim idclass, idtype, typeid As Integer
                Dim nType As String
                'обхождане на оценките на випуска
                Dim s As Integer
                s = cmbSubjectId.Text
                Do While dt.Rows.Count > brRows
                    'проверка дали класа е от випуска
                    idclass = dt.Rows(brRows).Item("id")
                    If s = -1 Then
                        cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "' order by type", cnn)
                    Else
                        cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "' and subject='" & s & "' order by type", cnn)
                    End If

                    cmd.ExecuteNonQuery()
                    Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt1 As DataTable = New DataTable
                    adaptre2.Fill(dt1)
                    If dt1.Rows.Count > 0 Then
                        brrows2 = 0
                        'обхойдане на оценките от класете на виспуска
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
                Dim cs1, cs2, cs3, cs4 As String
                scom = "Select* from  classes where school_year='" & years & "' and grade='" & grade & "'"
                cs1 = " or school_year='" & years - 1 & "' and grade='" & grade - 1 & "'"
                cs2 = " or school_year='" & years - 2 & "' and grade='" & grade - 2 & "'"
                cs3 = " or school_year='" & years - 3 & "' and grade='" & grade - 3 & "'"
                cs4 = " or school_year='" & years - 4 & "' and grade='" & grade - 4 & "'"

                If grade = 2 Or grade = 6 Or grade = 9 Then
                    scom = scom & cs1
                ElseIf grade = 3 Or grade = 7 Or grade = 10 Then
                    scom = scom & cs1 & cs2
                ElseIf grade = 4 Or grade = 11 Then
                    scom = scom & cs1 & cs2 & cs3
                ElseIf grade = 12 Then
                    scom = scom & cs1 & cs2 & cs3 & cs4
                End If
                cmd = New MySqlCommand(scom, cnn)
                cmd.ExecuteNonQuery()
                Dim adap As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim data1 As DataTable = New DataTable
                adap.Fill(data1)
                Dim c2, c3, c4, c5, c6, id, nomer As Integer
                Dim subject, classes As String
                For i As Integer = 0 To data1.Rows.Count - 1
                    idclass = data1.Rows(i).Item("id")
                    classes = data1.Rows(i).Item("class")
                    grade = data1.Rows(i).Item("grade")
                    years = data1.Rows(i).Item("school_year")
                    classes = grade & " " & classes & " " & years & "/" & years Mod 100 + 1
                    If s = -1 Then
                        cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "'", cnn)
                    Else
                        cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "' and subject='" & s & "'", cnn)
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
            cmbIdType.Text = cmbIdType.Items(cmbtype.SelectedIndex)
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            Dim brRows As Integer
            brRows = 0
            Dim scom As String
            Dim years, grade As Integer
            grade = cmbClass.Text
            years = cmbYear.Text
            scom = "Select* from classes where grade='" & grade & "' and school_year='" & years & "'"
            cmd = New MySqlCommand(scom, cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            'Проверка дaли в таблица purpose има записи
            If data.Rows.Count > 0 Then
                'ако има записи
                Dim classesPodr(data.Rows.Count, 2) As Integer
                'минаване през всчики редове на таблица purpose
                brRows = 2
                Dim s, t As Integer
                s = cmbSubjectId.Text
                t = cmbIdType.Text
                'търсене на оценките на випуска
                cmd.ExecuteNonQuery()
                Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt As DataTable = New DataTable
                adaptre1.Fill(dt)
                Dim brrows2 As Integer = 0
                brRows = 0
                Dim idclass As Integer
                Dim nType As String
                'записване на стойности в dgv1
                years = cmbYear.Text
                grade = cmbClass.Text
                Dim cs1, cs2, cs3, cs4 As String
                scom = "Select* from  classes where school_year='" & years & "' and grade='" & grade & "'"
                cs1 = " or school_year='" & years - 1 & "' and grade='" & grade - 1 & "'"
                cs2 = " or school_year='" & years - 2 & "' and grade='" & grade - 2 & "'"
                cs3 = " or school_year='" & years - 3 & "' and grade='" & grade - 3 & "'"
                cs4 = " or school_year='" & years - 4 & "' and grade='" & grade - 4 & "'"
                If t = -1 Then
                    If s = -1 Then
                        cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "'", cnn)
                    Else
                        cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "' and subject='" & s & "'", cnn)
                    End If
                Else
                    If s = -1 Then
                        cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "' and type='" & t & "'", cnn)
                    Else
                        cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "' and subject='" & s & "' and type='" & t & "'", cnn)
                    End If
                End If
                cmd = New MySqlCommand(scom, cnn)
                cmd.ExecuteNonQuery()
                Dim adap As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim data1 As DataTable = New DataTable
                adap.Fill(data1)
                Dim c2, c3, c4, c5, c6, id, nomer As Integer
                Dim subject, classes As String
                For i As Integer = 0 To data1.Rows.Count - 1
                    idclass = data1.Rows(i).Item("id")
                    classes = data1.Rows(i).Item("class")
                    grade = data1.Rows(i).Item("grade")
                    years = data1.Rows(i).Item("school_year")
                    classes = grade & " " & classes & " " & years & "/" & years Mod 100 + 1

                    If s = -1 Then
                        cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "'", cnn)
                    Else
                        cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "' and subject='" & s & "'", cnn)
                    End If

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
    End Sub

    Private Sub btnchart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnchart.Click
        If cmbYear.Text <> "" Then
            'проверка за стойностите в диаграмата и тяхното изтриване
            Chart1.Titles.Clear()
            Chart1.Series.Clear()
            Chart1.Series.Add(cmbYear.Text & "/" & cmbYear.Text Mod 100 + 1)
            Chart1.Series.Add(cmbYear.Text - 1 & "/" & cmbYear.Text Mod 100)
            Chart1.Series.Add(cmbYear.Text - 2 & "/" & cmbYear.Text Mod 100 - 1)
            Chart1.Series.Add(cmbYear.Text - 3 & "/" & cmbYear.Text Mod 100 - 2)
            Chart1.Series.Add(cmbYear.Text - 4 & "/" & cmbYear.Text Mod 100 - 3)
            Chart1.ChartAreas.Item(0).AxisX.CustomLabels.Clear()
            Chart1.Legends.Clear()
            Chart1.Legends.Add(0)
            Chart1.ChartAreas.Item(0).AxisX.CustomLabels.Clear()
            title2 = "Класовете през годините: "
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
                Dim row As Integer = 0
                title2 = title2 & cmbVipusk.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
                Chart1.Titles.Add(title1)
                Chart1.Titles.Add(title2)
                Dim class1, p, otd As String
                Dim grade, y1, brrows, g As Integer
                Dim classes As Char
              
                Dim max As Double
                otd = ""
                prb1.Value = 0
                prb1.Maximum = RRowsCount
                brrows = 0
                Dim max2 As Double
                Do While brrows < r.Rows.Count

                    grade = r.Rows(brrows).Item("grade")
                    classes = r.Rows(brrows).Item("class")
                    p = classes
                    g = grade
                    class1 = grade & " " & classes
                    Dim y As Integer = cmbYear.Text
                    Do While p = classes Or brrows < r.Rows.Count
                        If brrows < r.Rows.Count Then
                            classes = r.Rows(brrows).Item("class")
                            If classes <> p Then
                                Exit Do
                            End If
                            max = r.Rows(brrows).Item("sreden_uspeh")
                            y1 = r.Rows(brrows).Item("school_year")
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
                            y1 = r.Rows(brrows).Item("school_year")

                            Dim iditemcuslabel As Integer = 0
                            Dim itemcus As String
                            Dim flag As Integer = 0 '''''''''''''''
                            Do While iditemcuslabel < Chart1.ChartAreas.Item(0).AxisX.CustomLabels.Count
                                itemcus = Chart1.ChartAreas.Item(0).AxisX.CustomLabels(iditemcuslabel).Text
                                If itemcus = grade & " " & classes Then
                                    flag = 1
                                    Exit Do
                                End If
                                iditemcuslabel = iditemcuslabel + 1
                            Loop
                            row = iditemcuslabel
                            If flag = 0 Then
                                Chart1.ChartAreas.Item(0).AxisX.CustomLabels.Add(row - 0.5, row + 0.5, grade & " " & classes)
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
                        Else
                            Exit Do
                        End If
                    Loop
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
        dt = New DataTable
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
        Dim scom, c0, c1, c2, c3, c4, c As String
        Dim ci As Integer
        ci = cmbClass.Text
        scom = "SELECT classes.grade, classes.class, classes.school_year, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                         & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes  Inner join purpose ON classes.id=purpose.class Where "
        c0 = "classes.grade='" & ci & "' and school_year='" & cmbYear.Text
        c1 = "' or classes.grade='" & ci - 1 & "' and school_year='" & cmbYear.Text - 1
        c2 = "' or classes.grade='" & ci - 2 & "' and school_year='" & cmbYear.Text - 2
        c3 = "' or classes.grade='" & ci - 3 & "' and school_year='" & cmbYear.Text - 3
        c4 = "' or classes.grade='" & ci - 4 & "' and school_year='" & cmbYear.Text - 4
        c = ""
        If ci = 1 Or ci = 5 Or ci = 8 Then
            c = c0
        ElseIf ci = 2 Or ci = 6 Or ci = 9 Then
            c = c0 & c1
        ElseIf ci = 3 Or ci = 7 Or ci = 10 Then
            c = c0 & c1 & c2
        ElseIf ci = 4 Or ci = 11 Then
            c = c0 & c1 & c2 & c3
        ElseIf ci = 12 Then
            c = c0 & c1 & c2 & c3 & c4
        End If
        If cmbtype.Text <> cmbtype.Items(0) Then
            If cmbSubject.Text <> cmbSubject.Items(0) Then
                r = scom & "purpose.type='" & cmbIdType.Text & "' and purpose.subject='" & cmbSubjectId.Text & "' and" & c _
                                              & "' Group by purpose.class order by classes.class asc, classes.grade desc;"
            Else
                r = scom & "purpose.type='" & cmbIdType.Text & "' and" & c _
                  & "' Group by purpose.class order by classes.class asc, classes.grade desc;"
            End If
        Else
            If cmbSubject.Text <> cmbSubject.Items(0) Then
                r = scom & " purpose.subject='" & cmbSubjectId.Text & "' and " & c & _
                     "' Group by purpose.class order by classes.class asc, classes.grade desc;"
            Else
                r = scom & c & "' Group by  purpose.class order by classes.class asc, classes.grade desc;"
            End If
        End If
    End Sub

    Private Sub btnExselNewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExselNewFile.Click
        If cmbYear.Text <> "" Then

            title2 = "Класовете през годините: "
            title2 = title2 & cmbYear.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            Dim rasEx As String
            rasEx = ""
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
                xlsheet.Name = "Класовете през годините"
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
                y = cmbYear.Text & "/" & cmbYear.Text Mod 100 + 1
                xlsheet.Cells(3, 2) = y
                y = cmbYear.Text - 1 & "/" & cmbYear.Text Mod 100
                xlsheet.Cells(3, 3) = y
                y = cmbYear.Text - 2 & "/" & cmbYear.Text Mod 100 - 1
                xlsheet.Cells(3, 4) = y
                y = cmbYear.Text - 3 & "/" & cmbYear.Text Mod 100 - 2
                xlsheet.Cells(3, 5) = y
                y = cmbYear.Text - 4 & "/" & cmbYear.Text Mod 100 - 3
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
                myChart = xlCharts.Add(5, 170, 600, 250)
                chartPage = myChart.Chart
                chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlColumnClustered
                Dim r As DataTable = New DataTable
                Dim y1, brrows, type, subject, y2 As Integer
                Dim max As Double
                Dim grade, classes, class2 As String
                type = cmbIdType.Text
                subject = cmbSubjectId.Text
                Dim br As Integer = 4 
                Call cmdmaxmin(r)
                If RRowsCount > 0 Then
                    y2 = cmbYear.Text
                    title2 = title2 & cmbVipusk.Text & ", предмет " & cmbSubject.Text & " и вид оценка " & cmbtype.Text
                    Dim p As String
                    Dim g As Integer
                    prb1.Value = 0
                    prb1.Maximum = RRowsCount
                    Do While brrows < r.Rows.Count
                        grade = r.Rows(brrows).Item("grade")
                        classes = r.Rows(brrows).Item("class")
                        p = classes
                        g = grade
                        class2 = grade & " " & p
                        xlsheet.Cells(br, 1) = class2

                        Do While p = classes Or brrows < r.Rows.Count
                            If brrows < r.Rows.Count Then
                                classes = r.Rows(brrows).Item("class")
                                If classes <> p Then
                                    Exit Do
                                End If
                                max = r.Rows(brrows).Item("sreden_uspeh")
                                y1 = r.Rows(brrows).Item("school_year")
                                prb1.Value = prb1.Value + 1
                                If y1 = y2 Then
                                    xlsheet.Cells(br, 2) = max
                                ElseIf y1 = y2 - 1 Then
                                    xlsheet.Cells(br, 3) = max
                                ElseIf y1 = y2 - 2 Then
                                    xlsheet.Cells(br, 4) = max
                                ElseIf y1 = y2 - 3 Then
                                    xlsheet.Cells(br, 5) = max
                                ElseIf y1 = y2 - 4 Then
                                    xlsheet.Cells(br, 6) = max
                                End If
                                xlsheet.Range(xlsheet.Cells(br, 1), xlsheet.Cells(br, 5)).HorizontalAlignment = xlCenter
                                chartRange = xlsheet.Range("A3:F" & br)
                                chartPage.SetSourceData(Source:=chartRange)
                                brrows = brrows + 1
                            Else
                                Exit Do
                            End If
                        Loop
                        br = br + 1
                    Loop
                     
                End If
                chartPage.HasTitle = True
                chartPage.ChartTitle.Text = xlsheet.Range("A2").Value()
                chartPage.PlotBy = Microsoft.Office.Interop.Excel.XlRowCol.xlColumns
                ' Смаляване на формата
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
                    ws.Name = "Класовете през годините"
                    title2 = "Класовете през годините: "
                    title2 = title2 & cmbYear.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
                    Dim r As DataTable = New DataTable
                    Dim xldi As Microsoft.Office.Interop.Excel.Chart
                    xldi = New Microsoft.Office.Interop.Excel.Chart
                    Const xlCenter = -4108
                    ws.Visible = True
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
                    y = cmbYear.Text & "/" & cmbYear.Text Mod 100 + 1
                    ws.Cells(3, 2) = y
                    y = cmbYear.Text - 1 & "/" & cmbYear.Text Mod 100
                    ws.Cells(3, 3) = y
                    y = cmbYear.Text - 2 & "/" & cmbYear.Text Mod 100 - 1
                    ws.Cells(3, 4) = y
                    y = cmbYear.Text - 3 & "/" & cmbYear.Text Mod 100 - 2
                    ws.Cells(3, 5) = y
                    y = cmbYear.Text - 4 & "/" & cmbYear.Text Mod 100 - 3
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
                    myChart = xlCharts.Add(5, 170, 600, 250)
                    chartPage = myChart.Chart
                    chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlColumnClustered
                    'извикване на функция cmdmaxmi, която връща datareader и проверка тя дали е пълна
                    Dim classes, class2, otd As String
                    Dim grade, br, y1, brrows, type, subject As Integer
                    Dim max As Double
                    otd = ""
                    br = 4
                    brrows = 0
                    ' четене на datareader, изчисляване на данните и тяхното записване в excel
                    type = cmbIdType.Text
                    subject = cmbSubjectId.Text
                    Dim y2 As Integer
                    Call cmdmaxmin(r)
                    If RRowsCount > 0 Then
                        y2 = cmbYear.Text
                        title2 = title2 & cmbVipusk.Text & ", предмет " & cmbSubject.Text & " и вид оценка " & cmbtype.Text
                        Dim p As String
                        Dim g As Integer
                        prb1.Value = 0
                        prb1.Maximum = RRowsCount
                        Do While brrows < r.Rows.Count
                            grade = r.Rows(brrows).Item("grade")
                            classes = r.Rows(brrows).Item("class")
                            p = classes
                            g = grade
                            class2 = grade & " " & p
                            ws.Cells(br, 1) = class2
                            Do While p = classes Or brrows < r.Rows.Count

                                If brrows < r.Rows.Count Then
                                    classes = r.Rows(brrows).Item("class")
                                    If classes <> p Then
                                        Exit Do
                                    End If
                                    max = r.Rows(brrows).Item("sreden_uspeh")
                                    y1 = r.Rows(brrows).Item("school_year")
                                    prb1.Value = prb1.Value + 1
                                    If y1 = y2 Then
                                        ws.Cells(br, 2) = max
                                    ElseIf y1 = y2 - 1 Then
                                        ws.Cells(br, 3) = max
                                    ElseIf y1 = y2 - 2 Then
                                        ws.Cells(br, 4) = max
                                    ElseIf y1 = y2 - 3 Then
                                        ws.Cells(br, 5) = max
                                    ElseIf y1 = y2 - 4 Then
                                        ws.Cells(br, 6) = max
                                    End If
                                    ws.Range(ws.Cells(br, 1), ws.Cells(br, 5)).HorizontalAlignment = xlCenter
                                    chartRange = ws.Range("A3:F" & br)
                                    chartPage.SetSourceData(Source:=chartRange)
                                    brrows = brrows + 1
                                Else
                                    Exit Do
                                End If
                            Loop
                            br = br + 1
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

                        Dim res As MsgBoxResult
                        res = MsgBox("Искате ли файлът да се отвори?", MsgBoxStyle.YesNo, "Справка")
                        If res = MsgBoxResult.Yes Then
                            Process.Start(pat)
                        End If
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
                title2 = "Класовете през годините: "
                title2 = title2 & cmbYear.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
                oPara2 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
                oPara2.Range.Text = title2
                oPara2.Format.SpaceAfter = 6
                oPara2.Range.InsertParagraphAfter()
                Dim r As DataTable = New DataTable
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
                Dim y1, brrows, type, subject, y2 As Integer
                Dim class2 As String
                type = cmbIdType.Text
                subject = cmbSubjectId.Text
                Call cmdmaxmin(r)
                If RRowsCount > 0 Then
                    y2 = cmbYear.Text
                    title2 = title2 & cmbVipusk.Text & ", предмет " & cmbSubject.Text & " и вид оценка " & cmbtype.Text
                    Dim p As String
                    Dim g As Integer
                    prb1.Value = 0
                    prb1.Maximum = RRowsCount
                    Do While brrows < r.Rows.Count
                        grade = r.Rows(brrows).Item("grade")
                        classes = r.Rows(brrows).Item("class")
                        p = classes
                        g = grade
                        class2 = grade & " " & p
                        m(br, 0) = class2
                        Do While p = classes Or brrows < r.Rows.Count

                            If brrows < r.Rows.Count Then
                                classes = r.Rows(brrows).Item("class")
                                If classes <> p Then
                                    Exit Do
                                End If
                                max = r.Rows(brrows).Item("sreden_uspeh")
                                y1 = r.Rows(brrows).Item("school_year")
                                prb1.Value = prb1.Value + 1
                                If y1 = y2 Then
                                    m(br, 1) = max
                                ElseIf y1 = y2 - 1 Then
                                    m(br, 2) = max
                                ElseIf y1 = y2 - 2 Then
                                    m(br, 3) = max
                                ElseIf y1 = y2 - 3 Then
                                    m(br, 4) = max
                                ElseIf y1 = y2 - 4 Then
                                    m(br, 5) = max
                                End If
                                brrows = brrows + 1
                            Else
                                Exit Do
                            End If
                        Loop
                        br = br + 1
                    Loop

                    oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, 1, 6)
                    oTable.Cell(1, 1).Range.Text = "Клас"
                    y = cmbYear.Text & "/" & cmbYear.Text Mod 100 + 1
                    oTable.Cell(1, 2).Range.Text = y
                    y = cmbYear.Text - 1 & "/" & cmbYear.Text Mod 100
                    oTable.Cell(1, 3).Range.Text = y
                    y = cmbYear.Text - 2 & "/" & cmbYear.Text Mod 100 - 1
                    oTable.Cell(1, 4).Range.Text = y
                    y = cmbYear.Text - 3 & "/" & cmbYear.Text Mod 100 - 2
                    oTable.Cell(1, 5).Range.Text = y
                    y = cmbYear.Text - 4 & "/" & cmbYear.Text Mod 100 - 3
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
                    Me.Height = 370
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

            End If
        Else
            MsgBox("Трябва да се върнете и да веведете оценки ! ! !", , "Справка")
        End If
    End Sub

    Private Sub reference_Vipusk_Over_Years_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Do While dgv1.RowCount > 0
            dgv1.Rows.Remove(dgv1.Rows(0))
        Loop
        Me.Height = 370
        'Проверка дали chart1 е празно

        Chart1.Series.Clear()
        Chart1.Legends.Clear()
        Chart1.Titles.Clear()

        title2 = "Успех по паралелки за 2 години: "
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