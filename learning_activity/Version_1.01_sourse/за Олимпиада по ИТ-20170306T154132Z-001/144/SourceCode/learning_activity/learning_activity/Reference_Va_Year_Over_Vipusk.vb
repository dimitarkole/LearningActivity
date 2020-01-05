'използване на MySQL Data
Imports MySql.Data.MySqlClient
Public Class Reference_Va_Year_Over_Vipusk
    'деклариране на глобални променливи
    Dim cnn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim years, title1, title2, flagbtn As String
    Dim a, b, RRowsCount As Integer
    Private Sub Reference_Va_Classes_Over_Vipusk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Отваряне на връската със SURVER
        Call Module1.hosts(cnn)
        cnn.Open()
        Dim brRows, flag As Integer
        brRows = 0
        title1 = "Справка"
        title2 = "Съотношение на оценките по класове през годините: "

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
            cmbtype.Text = cmbtype.Items(0)
            cmbIdType.Text = cmbIdType.Items(0)
            cmbSubject.Text = cmbSubject.Items(0)
            cmbSubjectId.Text = cmbSubjectId.Items(0)
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
                Try
                    cnn.Open()
                    cnn.Close()
                Catch ex As Exception
                    MsgBox("Грешка в базата данни! ! !")
                    Application.Exit()
                End Try
                cmbClass.Text = cmbClass.Items(cmbVipusk.SelectedIndex)
                cmbYear.Text = cmbYear.Items(cmbVipusk.SelectedIndex)
                dgv1.Rows.Clear()

                Do While cmbIdType.Items.Count > 1
                    cmbtype.Items.Remove(cmbtype.Items(1))
                    cmbIdType.Items.Remove(cmbIdType.Items(1))

                Loop
                Do While cmbSubject.Items.Count > 1
                    cmbSubject.Items.Remove(cmbSubject.Items(1))
                    cmbSubjectId.Items.Remove(cmbSubjectId.Items(1))
                Loop

                cnn.Open()
                Dim brRows, flag As Integer
                cmd = New MySqlCommand("Select* from  classes where school_year='" & cmbYear.Text & "' and grade='" & cmbClass.Text & "'", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim data As DataTable = New DataTable
                adaptre.Fill(data)
                Dim classesPodr(data.Rows.Count, 2) As Integer
                Dim years, grade As Integer
                'Проверка дaли в таблица purpose има записи
                If data.Rows.Count > 0 Then
                    'ако има записи
                    brRows = 0
                    'минаване през всчики редове на таблица purpose
                    'търсене на оценките на випуска
                    grade = cmbClass.Text
                    years = cmbYear.Text
                    Dim brrows2 As Integer = 0
                    brRows = 0
                    Dim idclass, idtype, IntSubject, typeid As Integer
                    Dim nType, strSubject As String
                    'обхождане на оценките на випуска
                    Do While data.Rows.Count > brRows
                        'проверка дали класа е от випуска
                        idclass = data.Rows(brRows).Item("id")
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
                    cmbtype.Text = cmbtype.Items(0)
                    cmbIdType.Text = cmbIdType.Items(0)
                    cmbSubject.Text = cmbSubject.Items(0)
                    cmbSubjectId.Text = cmbSubjectId.Items(0)
                    Call createdgv1()
                End If
                cnn.Close()
                cnn.Close()
            End If
        Else
            cmbVipusk.Text = ""
        End If
    End Sub

    Private Sub cmbtype_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtype.Leave, cmbtype.DropDownClosed
        If (cmbtype.SelectedIndex = -1) Then
            cmbtype.Text = cmbtype.Items(0)
            cmbtype.Focus()
        Else
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            'изтриване на старите сойности в dgv1
            cmbIdType.Text = cmbIdType.Items(cmbtype.SelectedIndex)
            dgv1.Rows.Clear()
            cnn.Open()
            Call createdgv1()
            cnn.Close()
        End If
    End Sub

    Private Sub cmbSubject_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubject.Leave, cmbSubject.DropDownClosed
        If (cmbSubject.SelectedIndex = -1) Then
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



            cmbSubjectId.Text = cmbSubjectId.Items(cmbSubject.SelectedIndex)
            dgv1.Rows.Clear()
            Do While cmbIdType.Items.Count > 1
                cmbtype.Items.Remove(cmbtype.Items(1))
                cmbIdType.Items.Remove(cmbIdType.Items(1))
            Loop
            cnn.Open()
            Dim brRows, flag As Integer
            cmd = New MySqlCommand("Select* from  classes where school_year='" & cmbYear.Text & "' and grade='" & cmbClass.Text & "'", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            Dim classesPodr(data.Rows.Count, 2) As Integer
            Dim years, grade As Integer
            'Проверка дaли в таблица purpose има записи
            If data.Rows.Count > 0 Then
                'ако има записи
                brRows = 0
                'минаване през всчики редове на таблица purpose
                'търсене на оценките на випуска
                grade = cmbClass.Text
                years = cmbYear.Text
                Dim brrows2 As Integer = 0
                brRows = 0
                Dim idclass, idtype, typeid, subjectid As Integer
                Dim nType As String
                subjectid = cmbSubjectId.Text
                'обхождане на оценките на випуска
                Do While data.Rows.Count > brRows
                    'проверка дали класа е от випуска
                    idclass = data.Rows(brRows).Item("id")
                    If cmbSubjectId.Text = -1 Then
                        cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "'", cnn)
                    Else
                        cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "' and subject='" & subjectid & "'", cnn)
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
                Call createdgv1()
            End If
            cnn.Close()
        End If
    End Sub
    Sub createdgv1()
        Dim brRows As Integer
        Dim years, grade As Integer
        grade = cmbClass.Text
        years = cmbYear.Text
        Dim scom As String
        Dim brrows2 As Integer = 0
        brRows = 0
        Dim idclass, subjectid, typeid As Integer
        Dim nType As String
        typeid = cmbIdType.Text
        subjectid = cmbSubjectId.Text
        'обхождане на оценките на випуска
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
            If typeid = -1 Then
                If cmbSubjectId.Text = -1 Then
                    cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "'", cnn)
                Else
                    cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "' and subject='" & subjectid & "'", cnn)
                End If
            Else
                If cmbSubjectId.Text = -1 Then
                    cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "' and type='" & typeid & "'", cnn)
                Else
                    cmd = New MySqlCommand("Select* from  purpose where class='" & idclass & "' and subject='" & subjectid & "' and type='" & typeid & "'", cnn)
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
    End Sub
          
    Private Sub chartDataDel()
        If Chart1.Titles.Count > 0 Then
            Chart1.Titles.Remove(Chart1.Titles.Item(0))
            Chart2.Titles.Remove(Chart2.Titles.Item(0))
            Chart3.Titles.Remove(Chart3.Titles.Item(0))
            Chart4.Titles.Remove(Chart4.Titles.Item(0))
            Chart5.Titles.Remove(Chart5.Titles.Item(0))
        End If
        If Chart1.Series.Count > 0 Then
            Chart1.Series.Remove(Chart1.Series.Item(0))
            Do While Chart1.Series.Count > 0
                Chart1.Legends.Remove(Chart1.Legends.Item(0))
            Loop
        End If
        If Chart2.Series.Count > 0 Then
            Chart2.Series.Remove(Chart2.Series.Item(0))
            Do While Chart2.Series.Count > 0
                Chart2.Legends.Remove(Chart2.Legends.Item(0))
            Loop
        End If
        If Chart3.Series.Count > 0 Then
            Chart3.Series.Remove(Chart3.Series.Item(0))
            Do While Chart3.Series.Count > 0
                Chart3.Legends.Remove(Chart3.Legends.Item(0))
            Loop
        End If
        If Chart4.Series.Count > 0 Then
            Chart4.Series.Remove(Chart4.Series.Item(0))
            Do While Chart4.Series.Count > 0
                Chart4.Legends.Remove(Chart4.Legends.Item(0))
            Loop
        End If
        If Chart5.Series.Count > 0 Then
            Chart5.Series.Remove(Chart5.Series.Item(0))
            Do While Chart5.Series.Count > 0
                Chart5.Legends.Remove(Chart5.Legends.Item(0))
            Loop
        End If
    End Sub
    Private Sub btnchart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnchart.Click
        If cmbYear.Text <> "" Then
            Chart1.Visible = True
            Chart2.Visible = True
            Chart3.Visible = True
            Chart4.Visible = True
            Chart5.Visible = True
            'проверка за стойностите в диаграмата и тяхното изтриване
            Call chartDataDel()
            title2 = "Съотношение на оценките по брой през годините за: "
            title2 = title2 & cmbVipusk.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
            Label5.Text = title2
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            Dim y As String
            y = cmbYear.Text & "/" & cmbYear.Text Mod 100 + 1
            Chart1.Titles.Add(y)
            y = cmbYear.Text - 1 & "/" & cmbYear.Text Mod 100
            Chart2.Titles.Add(y)
            y = cmbYear.Text - 2 & "/" & cmbYear.Text Mod 100 - 1
            Chart3.Titles.Add(y)
            y = cmbYear.Text - 3 & "/" & cmbYear.Text Mod 100 - 2
            Chart4.Titles.Add(y)
            y = cmbYear.Text - 4 & "/" & cmbYear.Text Mod 100 - 3
            Chart5.Titles.Add(y)
            Dim r As DataTable = New DataTable
            Dim otd As String
            Dim pk, c, y1, brrows As Integer
            Dim scom, y11 As String
            Dim type, subject As Integer
            type = cmbIdType.Text
            subject = cmbSubjectId.Text
            Dim c2(5), c3(5), c4(5), c5(5), c6(5), c22, c32, c42, c52, c62 As Integer
            For p As Integer = 0 To 5
                c2(p) = 0
                c3(p) = 0
                c4(p) = 0
                c5(p) = 0
                c6(p) = 0
            Next

            Dim i As Integer
            i = cmbClass.Text
            If i > 0 And i < 5 Then
                pk = 1
            ElseIf i > 4 And i < 8 Then
                pk = 5
            Else : pk = 8
            End If
            y1 = cmbYear.Text
            c = i
            Dim s As String
            s = "SELECT classes.school_year, sum(count_2) as c2, sum(count_3) as c3 ,sum(count_4) as c4, sum(count_5) as c5,sum(count_6) as c6"
            s = s & " FROM classes Inner join purpose ON classes.id=purpose.class Where"
            prb1.Value = 0
            prb1.Maximum = pk - 1
            For j As Integer = i To pk Step -1

                If type = -1 Then
                    If subject = -1 Then
                        scom = s & " classes.grade='" & c & "'and classes.school_year='" & y1 & " ' Group by classes.school_year;"
                    Else
                        scom = s & " purpose.subject='" & subject _
                                                      & "'and classes.grade='" & c & "'and classes.school_year='" & y1 & "' Group by classes.school_year; "
                    End If
                Else
                    If subject = -1 Then
                        scom = s & " purpose.type='" & type _
                                                      & "'and classes.grade='" & c & "'and classes.school_year='" & y1 & "' Group by classes.school_year; "
                    Else
                        scom = s & " purpose.type='" & type _
                                                      & "'and purpose.subject='" & subject & "classes.grade='" & c & "'and classes.school_year='" & y1 & "' Group by classes.school_year;"
                    End If
                End If
                'задаванена на команда оттип String в променлива coms в зависимост от избрания начин на сортиране
                r = New DataTable
                cmd = New MySqlCommand(scom, cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                adaptre.Fill(r)

                If r.Rows.Count > 0 Then
                    brrows = 0
                    c22 = r.Rows(brrows).Item("c2")
                    c32 = r.Rows(brrows).Item("c3")
                    c42 = r.Rows(brrows).Item("c4")
                    c52 = r.Rows(brrows).Item("c5")
                    c62 = r.Rows(brrows).Item("c6")
                    otd = ""
                    ' оценка с думи
                    y11 = y1 & "/" & y1 Mod 100 + 1

                    If y11 = Chart1.Titles(0).Text Then
                        brrows = 0
                    ElseIf y11 = Chart2.Titles(0).Text Then
                        brrows = 1
                    ElseIf y11 = Chart3.Titles(0).Text Then
                        brrows = 2
                    ElseIf y11 = Chart4.Titles(0).Text Then
                        brrows = 3
                    ElseIf y11 = Chart5.Titles(0).Text Then
                        brrows = 4
                    End If
                    c2(brrows) = c2(brrows) + c22
                    c3(brrows) = c3(brrows) + c32
                    c4(brrows) = c4(brrows) + c42
                    c5(brrows) = c5(brrows) + c52
                    c6(brrows) = c6(brrows) + c62
                Else
                    Exit For
                End If
                y1 = y1 - 1
                c = c - 1
                prb1.Value = prb1.Value + 1
            Next j
            prb1.Value = pk - 1

            Chart1.Series.Add("o")
            Chart1.Series("o").ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart2.Series.Add("o")
            Chart2.Series("o").ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart3.Series.Add("o")
            Chart3.Series("o").ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart4.Series.Add("o")
            Chart4.Series("o").ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart5.Series.Add("o")
            Chart5.Series("o").ChartType = DataVisualization.Charting.SeriesChartType.Pie
            'chart1
            If c2(0) > 0 Then
                Chart1.Series("o").Points.AddXY("Двойки брой- " & c2(0), c2(0))
            End If
            If c3(0) > 0 Then
                Chart1.Series("o").Points.AddXY("Тройки брой- " & c3(0), c3(0))
            End If
            If c4(0) > 0 Then
                Chart1.Series("o").Points.AddXY("Четворки брой- " & c4(0), c4(0))
            End If
            If c5(0) > 0 Then
                Chart1.Series("o").Points.AddXY("Петици брой- " & c5(0), c5(0))
            End If
            If c6(0) > 0 Then
                Chart1.Series("o").Points.AddXY("Шестици брой- " & c6(0), c6(0))
            End If
            'chart2
            If c2(1) > 0 Then
                Chart2.Series("o").Points.AddXY("Двойки брой- " & c2(1), c2(1))
            End If
            If c3(1) > 0 Then
                Chart2.Series("o").Points.AddXY("Тройки брой- " & c3(1), c3(1))
            End If
            If c4(2) > 0 Then
                Chart2.Series("o").Points.AddXY("Четворки брой- " & c4(1), c4(1))
            End If
            If c5(1) > 0 Then
                Chart2.Series("o").Points.AddXY("Петици брой- " & c5(1), c5(1))
            End If
            If c6(1) > 0 Then
                Chart2.Series("o").Points.AddXY("Шестици брой- " & c6(1), c6(1))
            End If
            'chart3
            If c2(2) > 0 Then
                Chart3.Series("o").Points.AddXY("Двойки брой- " & c2(2), c2(2))
            End If
            If c3(2) > 0 Then
                Chart3.Series("o").Points.AddXY("Тройки брой- " & c3(2), c3(2))
            End If
            If c4(2) > 0 Then
                Chart3.Series("o").Points.AddXY("Четворки брой- " & c4(2), c4(2))
            End If
            If c5(2) > 0 Then
                Chart3.Series("o").Points.AddXY("Петици брой- " & c5(2), c5(2))
            End If
            If c6(2) > 0 Then
                Chart3.Series("o").Points.AddXY("Шестици брой- " & c6(2), c6(2))
            End If
            'chart4
            If c2(3) > 0 Then
                Chart4.Series("o").Points.AddXY("Двойки брой- " & c2(3), c2(3))
            End If
            If c3(3) > 0 Then
                Chart4.Series("o").Points.AddXY("Тройки брой- " & c3(3), c3(3))
            End If
            If c4(3) > 0 Then
                Chart4.Series("o").Points.AddXY("Четворки брой- " & c4(3), c4(3))
            End If
            If c5(3) > 0 Then
                Chart4.Series("o").Points.AddXY("Петици брой- " & c5(3), c5(3))
            End If
            If c6(3) > 0 Then
                Chart4.Series("o").Points.AddXY("Шестици брой- " & c6(3), c6(3))
            End If

            'chart5
            If c2(4) > 0 Then
                Chart5.Series("o").Points.AddXY("Двойки брой- " & c2(4), c2(4))
            End If
            If c3(4) > 0 Then
                Chart5.Series("o").Points.AddXY("Тройки брой- " & c3(4), c3(4))
            End If
            If c4(4) > 0 Then
                Chart5.Series("o").Points.AddXY("Четворки брой- " & c4(4), c4(4))
            End If
            If c5(4) > 0 Then
                Chart5.Series("o").Points.AddXY("Петици брой- " & c5(4), c5(4))
            End If
            If c6(4) > 0 Then
                Chart5.Series("o").Points.AddXY("Шестици брой- " & c6(4), c6(4))
            End If
            Chart1.Series(0)("PieLabelStyle") = "Outside"

            Chart2.Series(0)("PieLabelStyle") = "Outside"
            Chart3.Series(0)("PieLabelStyle") = "Outside"
            Chart4.Series(0)("PieLabelStyle") = "Outside"
            Chart5.Series(0)("PieLabelStyle") = "Outside"
            cnn.Close()
            Me.Height = 730
        Else
            MsgBox("Трябва да се върнете и да веведете оценки ! ! !", , "Справка")
        End If
    End Sub
    Private Sub btnExselNewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExselNewFile.Click
        If cmbYear.Text <> "" Then
            title2 = "Съотношение на оценките по брой през годините за: "
            title2 = title2 & cmbVipusk.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
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
                'задаване на текст в клетки и форматиране на редове и колони
                xlapp = New Microsoft.Office.Interop.Excel.Application
                xlbook = xlapp.Workbooks.Add(misvalue)
                xlsheet = xlbook.Sheets("sheet1")
                xlsheet.Name = "Съотношение на оценките по брой"
                xldi = New Microsoft.Office.Interop.Excel.Chart
                Const xlCenter = -4108
                xlsheet.Range(xlsheet.Cells(1, 1), xlsheet.Cells(1, 14)).Merge()
                xlsheet.Range(xlsheet.Cells(1, 1), xlsheet.Cells(1, 14)).HorizontalAlignment = xlCenter
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 6)).WrapText = True
                xlsheet.Cells(1, 1) = title1 & vbNewLine & title2
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 2)).Merge()
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 2)).HorizontalAlignment = xlCenter
                xlsheet.Range(xlsheet.Cells(2, 3), xlsheet.Cells(8, 3)).Merge()
                xlsheet.Range(xlsheet.Cells(2, 6), xlsheet.Cells(8, 6)).Merge()
                xlsheet.Range(xlsheet.Cells(2, 9), xlsheet.Cells(8, 9)).Merge()
                xlsheet.Range(xlsheet.Cells(2, 12), xlsheet.Cells(8, 12)).Merge()
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 2)).Merge()
                xlsheet.Range(xlsheet.Cells(2, 4), xlsheet.Cells(2, 5)).Merge()
                xlsheet.Range(xlsheet.Cells(2, 7), xlsheet.Cells(2, 8)).Merge()
                xlsheet.Range(xlsheet.Cells(2, 10), xlsheet.Cells(2, 11)).Merge()
                xlsheet.Range(xlsheet.Cells(2, 13), xlsheet.Cells(2, 14)).Merge()
                Dim y As Integer
                y = cmbYear.Text
                Dim ys As String
                xlsheet.Cells(3, 1) = "Oценка"
                xlsheet.Cells(4, 1) = "Слаб"
                xlsheet.Cells(5, 1) = "Среден"
                xlsheet.Cells(6, 1) = "Добър"
                xlsheet.Cells(7, 1) = "Много добър"
                xlsheet.Cells(8, 1) = "Отличен"
                xlsheet.Cells(3, 2) = "Брой"
                xlsheet.Cells(3, 5) = "Брой"
                xlsheet.Cells(3, 4) = "Oценка"
                xlsheet.Cells(4, 4) = "Слаб"
                xlsheet.Cells(5, 4) = "Среден"
                xlsheet.Cells(6, 4) = "Добър"
                xlsheet.Cells(7, 4) = "Много добър"
                xlsheet.Cells(8, 4) = "Отличен"
                xlsheet.Cells(3, 8) = "Брой"
                xlsheet.Cells(3, 7) = "Oценка"
                xlsheet.Cells(4, 7) = "Слаб"
                xlsheet.Cells(5, 7) = "Среден"
                xlsheet.Cells(6, 7) = "Добър"
                xlsheet.Cells(7, 7) = "Много добър"
                xlsheet.Cells(8, 7) = "Отличен"
                xlsheet.Cells(3, 10) = "Oценка"
                xlsheet.Cells(3, 11) = "Брой"
                xlsheet.Cells(4, 10) = "Слаб"
                xlsheet.Cells(5, 10) = "Среден"
                xlsheet.Cells(6, 10) = "Добър"
                xlsheet.Cells(7, 10) = "Много добър"
                xlsheet.Cells(8, 10) = "Отличен"
                xlsheet.Cells(3, 14) = "Брой"
                xlsheet.Cells(3, 13) = "Oценка"
                xlsheet.Cells(4, 13) = "Слаб"
                xlsheet.Cells(5, 13) = "Среден"
                xlsheet.Cells(6, 13) = "Добър"
                xlsheet.Cells(7, 13) = "Много добър"
                xlsheet.Cells(8, 13) = "Отличен"

                ys = y & "/" & y Mod 100 + 1
                xlsheet.Cells(2, 1) = ys
                ys = y - 1 & "/" & y Mod 100
                xlsheet.Cells(2, 4) = ys
                ys = y - 2 & "/" & y Mod 100 - 1
                xlsheet.Cells(2, 7) = ys
                ys = y - 3 & "/" & y Mod 100 - 2
                xlsheet.Cells(2, 10) = ys
                ys = y - 4 & "/" & y Mod 100 - 3
                xlsheet.Cells(2, 13) = ys

                xlsheet.Range(xlsheet.Cells(3, 1), xlsheet.Cells(3, 2)).HorizontalAlignment = xlCenter
                xlsheet.Range("A1").EntireRow.RowHeight = 30
                xlsheet.Range("A3").EntireColumn.ColumnWidth = 15
                xlsheet.Range("B3").EntireColumn.ColumnWidth = 15
                xlsheet.Range("A2").EntireRow.RowHeight = 20
                xlsheet.Range("D3").EntireColumn.ColumnWidth = 15
                xlsheet.Range("E3").EntireColumn.ColumnWidth = 15
                xlsheet.Range("H3").EntireColumn.ColumnWidth = 15
                xlsheet.Range("G3").EntireColumn.ColumnWidth = 15
                xlsheet.Range("J3").EntireColumn.ColumnWidth = 15
                xlsheet.Range("K3").EntireColumn.ColumnWidth = 15
                xlsheet.Range("M3").EntireColumn.ColumnWidth = 15
                xlsheet.Range("N3").EntireColumn.ColumnWidth = 15
                Dim pat As String
                pat = SaveFileDialog1.FileName
                Dim chartPage, cp1, cp2, cp3, cp4 As Microsoft.Office.Interop.Excel.Chart
                Dim xlCharts As Microsoft.Office.Interop.Excel.ChartObjects
                Dim myChart, mc1, mc2, mc3, mc4 As Microsoft.Office.Interop.Excel.ChartObject
                Dim chartRange As Microsoft.Office.Interop.Excel.Range
                xlCharts = xlsheet.ChartObjects
                myChart = xlCharts.Add(4, 158, 160, 160)
                mc1 = xlCharts.Add(215, 158, 160, 160)
                mc2 = xlCharts.Add(428, 158, 160, 160)
                mc3 = xlCharts.Add(642, 158, 160, 160)
                mc4 = xlCharts.Add(855, 158, 160, 160)
                chartPage = myChart.Chart
                cp1 = mc1.Chart
                cp2 = mc2.Chart
                cp3 = mc3.Chart
                cp4 = mc4.Chart
                chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlPie
                cp1.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlPie
                cp2.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlPie
                cp3.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlPie
                cp4.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlPie
                'извикване на функция cmdmaxmi, която връща datareader и проверка тя дали е пълна 
                Dim c2(5), c3(5), c4(5), c5(5), c6(5), c22, c32, c42, c52, c62 As Integer
                For j As Integer = 0 To 5
                    c2(j) = 0
                    c3(j) = 0
                    c4(j) = 0
                    c5(j) = 0
                    c6(j) = 0
                Next
                Dim r As DataTable = New DataTable
                Dim otd As String
                Dim pk, c, y1, brrows As Integer
                Dim scom, y11 As String
                Dim type, subject As Integer
                type = cmbIdType.Text
                subject = cmbSubjectId.Text

                Dim i As Integer
                i = cmbClass.Text

                If i > 0 And i < 5 Then
                    pk = 1
                ElseIf i > 4 And i < 8 Then
                    pk = 5
                Else : pk = 8
                End If
                prb1.Value = 0
                prb1.Maximum = pk - 1
                y1 = cmbYear.Text
                c = i
                Dim s As String
                s = "SELECT classes.school_year, sum(count_2) as c2, sum(count_3) as c3 ,sum(count_4) as c4, sum(count_5) as c5,sum(count_6) as c6"
                s = s & " FROM classes Inner join purpose ON classes.id=purpose.class Where"

                For j As Integer = i To pk Step -1
                    If type = -1 Then
                        If subject = -1 Then
                            scom = s & " classes.grade='" & c & "'and classes.school_year='" & y1 & " ' Group by classes.school_year;"
                        Else
                            scom = s & " purpose.subject='" & subject _
                                                          & "'and classes.grade='" & c & "'and classes.school_year='" & y1 & "' Group by classes.school_year; "
                        End If
                    Else
                        If subject = -1 Then
                            scom = s & " purpose.type='" & type _
                                                          & "'and classes.grade='" & c & "'and classes.school_year='" & y1 & "' Group by classes.school_year; "
                        Else
                            scom = s & " purpose.type='" & type _
                                                          & "'and purpose.subject='" & subject & "classes.grade='" & c & "'and classes.school_year='" & y1 & "' Group by classes.school_year;"
                        End If
                    End If
                    'задаванена на команда оттип String в променлива coms в зависимост от избрания начин на сортиране
                    r = New DataTable
                    cmd = New MySqlCommand(scom, cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    adaptre.Fill(r)

                    If r.Rows.Count > 0 Then
                        brrows = 0
                        c22 = r.Rows(brrows).Item("c2")
                        c32 = r.Rows(brrows).Item("c3")
                        c42 = r.Rows(brrows).Item("c4")
                        c52 = r.Rows(brrows).Item("c5")
                        c62 = r.Rows(brrows).Item("c6")
                        otd = ""
                        ' оценка с думи
                        y11 = cmbYear.Text
                        y = r.Rows(brrows).Item("school_year")
                        If y11 = y Then
                            brrows = 0
                        ElseIf y11 = y + 1 Then
                            brrows = 1
                        ElseIf y11 = y + 2 Then
                            brrows = 2
                        ElseIf y11 = y + 3 Then
                            brrows = 3
                        ElseIf y11 = y + 4 Then
                            brrows = 4
                        End If
                        c2(brrows) = c2(brrows) + c22
                        c3(brrows) = c3(brrows) + c32
                        c4(brrows) = c4(brrows) + c42
                        c5(brrows) = c5(brrows) + c52
                        c6(brrows) = c6(brrows) + c62
                    Else
                        Exit For
                    End If
                    y1 = y1 - 1
                    c = c - 1
                    prb1.Value = prb1.Value + 1
                Next j
                prb1.Value = pk - 1
                Dim col As Integer
                For j As Integer = 0 To 4
                    If j = 0 Then
                        col = 2
                    ElseIf j = 1 Then
                        col = 5
                    ElseIf j = 2 Then
                        col = 8
                    ElseIf j = 3 Then
                        col = 11
                    ElseIf j = 4 Then
                        col = 14
                    End If
                    xlsheet.Cells(4, col) = c2(j)
                    xlsheet.Cells(5, col) = c3(j)
                    xlsheet.Cells(6, col) = c4(j)
                    xlsheet.Cells(7, col) = c5(j)
                    xlsheet.Cells(8, col) = c6(j)
                Next
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(8, 14)).HorizontalAlignment = xlCenter
                chartRange = xlsheet.Range("A4:B8")
                chartPage.SetSourceData(Source:=chartRange)
                chartRange = xlsheet.Range("D4:F8")
                cp1.SetSourceData(Source:=chartRange)
                chartRange = xlsheet.Range("G4:H8")
                cp2.SetSourceData(Source:=chartRange)
                chartRange = xlsheet.Range("J4:K8")
                cp3.SetSourceData(Source:=chartRange)
                chartRange = xlsheet.Range("M4:N8")
                cp4.SetSourceData(Source:=chartRange)
                'Смаляване на формата
                Me.Height = 375
                xlsheet.SaveAs(pat)
                xlbook.Close()
                xlapp.Quit()

                releaseObject(xlapp)
                releaseObject(xlbook)
                releaseObject(xlsheet)

                Dim res As MsgBoxResult
                'питане дали да се отвори файла 
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
                Dim oPara1, oPara2 As Microsoft.Office.Interop.Word.Paragraph

                oWord = CreateObject("Word.Application")
                oDoc = oWord.Documents.Add
                'oDoc.PageSetup.Orientation = Microsoft.Office.Interop.Word.WdOrientation.wdOrientLandscape
                'задаване на текст, вкарваненатаблица и нейното форматиране
                oPara1 = oDoc.Content.Paragraphs.Add
                oPara1.Range.Font.Size = 20
                oPara1.Range.Font.Bold = True
                oPara1.Range.Text = title1
                oPara1.Alignment = HorizontalAlignment.Right
                oPara1.Format.SpaceAfter = 24
                oPara1.Range.InsertParagraphAfter()
                title2 = "Съотношение на оценките по брой през годините за: "
                title2 = title2 & cmbVipusk.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
                oPara2 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
                oPara2.Range.Text = title2
                oPara2.Format.SpaceAfter = 6
                oPara2.Range.InsertParagraphAfter()
                Dim r As DataTable
                Dim m(6, 5) As String

                Dim otd As String
                Dim br As Integer
                otd = ""
                br = 0
                prb1.Value = 0
                Dim y As String
                prb1.Maximum = RRowsCount
                'четене на datareader, изчисляване на данните и тяхното записване в excel
                Dim c, y1, brrows, type, subject As Integer
                Dim scom As String
                type = cmbIdType.Text
                subject = cmbSubjectId.Text
                prb1.Value = 0
                Dim c2(5), c3(5), c4(5), c5(5), c6(5), c22, c32, c42, c52, c62 As Integer
                For j As Integer = 0 To 5
                    c2(j) = 0
                    c3(j) = 0
                    c4(j) = 0
                    c5(j) = 0
                    c6(j) = 0
                Next
                Dim pk As Integer
                Dim y11 As String
                type = cmbIdType.Text
                subject = cmbSubjectId.Text
                prb1.Value = 0
                prb1.Maximum = 11
                Dim i As Integer
                i = cmbClass.Text
                If i > 0 And i < 5 Then
                    pk = 1
                ElseIf i > 4 And i < 8 Then
                    pk = 5
                Else : pk = 8
                End If
                prb1.Maximum = pk - 1
                y1 = cmbYear.Text
                c = i
                Dim s As String
                s = "SELECT classes.school_year, sum(count_2) as c2, sum(count_3) as c3 ,sum(count_4) as c4, sum(count_5) as c5,sum(count_6) as c6"
                s = s & " FROM classes Inner join purpose ON classes.id=purpose.class Where"
                For j As Integer = i To pk Step -1
                    If type = -1 Then
                        If subject = -1 Then
                            scom = s & " classes.grade='" & c & "'and classes.school_year='" & y1 & " ' Group by classes.school_year;"
                        Else
                            scom = s & " purpose.subject='" & subject _
                                                          & "'and classes.grade='" & c & "'and classes.school_year='" & y1 & "' Group by classes.school_year; "
                        End If
                    Else
                        If subject = -1 Then
                            scom = s & " purpose.type='" & type _
                                                          & "'and classes.grade='" & c & "'and classes.school_year='" & y1 & "' Group by classes.school_year; "
                        Else
                            scom = s & " purpose.type='" & type _
                                                          & "'and purpose.subject='" & subject & "classes.grade='" & c & "'and classes.school_year='" & y1 & "' Group by classes.school_year;"
                        End If
                    End If
                    'задаванена на команда оттип String в променлива coms в зависимост от избрания начин на сортиране
                    r = New DataTable
                    cmd = New MySqlCommand(scom, cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    adaptre.Fill(r)
                    If r.Rows.Count > 0 Then
                        brrows = 0
                        c22 = r.Rows(brrows).Item("c2")
                        c32 = r.Rows(brrows).Item("c3")
                        c42 = r.Rows(brrows).Item("c4")
                        c52 = r.Rows(brrows).Item("c5")
                        c62 = r.Rows(brrows).Item("c6")
                        otd = ""
                        ' оценка с думи
                        y11 = cmbYear.Text
                        y = r.Rows(brrows).Item("school_year")
                        If y11 = y Then
                            brrows = 0
                        ElseIf y11 = y + 1 Then
                            brrows = 1
                        ElseIf y11 = y + 2 Then
                            brrows = 2
                        ElseIf y11 = y + 3 Then
                            brrows = 3
                        ElseIf y11 = y + 4 Then
                            brrows = 4
                        End If
                        c2(brrows) = c2(brrows) + c22
                        c3(brrows) = c3(brrows) + c32
                        c4(brrows) = c4(brrows) + c42
                        c5(brrows) = c5(brrows) + c52
                        c6(brrows) = c6(brrows) + c62
                    Else
                        Exit For
                    End If
                    y1 = y1 - 1
                    c = c - 1
                    prb1.Value = prb1.Value + 1
                Next j
                prb1.Value = pk - 1
              oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, 6, 6)
                oTable.Cell(1, 1).Range.Text = "Оценка"
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
                oTable.Cell(2, 1).Range.Text = "Слаб"
                oTable.Cell(3, 1).Range.Text = "Среден"
                oTable.Cell(4, 1).Range.Text = "Добър"
                oTable.Cell(5, 1).Range.Text = "Много добър"
                oTable.Cell(6, 1).Range.Text = "Отлечен"
                'Dim br3 As Integer = 0

                oTable.Cell(2, 2).Range.Text = c2(0)
                oTable.Cell(3, 2).Range.Text = c3(0)
                oTable.Cell(4, 2).Range.Text = c4(0)
                oTable.Cell(5, 2).Range.Text = c5(0)
                oTable.Cell(6, 2).Range.Text = c6(0)
                oTable.Cell(2, 3).Range.Text = c2(1)
                oTable.Cell(3, 3).Range.Text = c3(1)
                oTable.Cell(4, 3).Range.Text = c4(1)
                oTable.Cell(5, 3).Range.Text = c5(1)
                oTable.Cell(6, 3).Range.Text = c6(1)
                oTable.Cell(2, 4).Range.Text = c2(2)
                oTable.Cell(3, 4).Range.Text = c3(2)
                oTable.Cell(4, 4).Range.Text = c4(2)
                oTable.Cell(5, 4).Range.Text = c5(2)
                oTable.Cell(6, 4).Range.Text = c6(2)
                oTable.Cell(2, 5).Range.Text = c2(3)
                oTable.Cell(3, 5).Range.Text = c3(3)
                oTable.Cell(4, 5).Range.Text = c4(3)
                oTable.Cell(5, 5).Range.Text = c5(3)
                oTable.Cell(6, 5).Range.Text = c6(3)
                oTable.Cell(2, 6).Range.Text = c2(4)
                oTable.Cell(3, 6).Range.Text = c3(4)
                oTable.Cell(4, 6).Range.Text = c4(4)
                oTable.Cell(5, 6).Range.Text = c5(4)
                oTable.Cell(6, 6).Range.Text = c6(4)

                'форматиране на таблицата
                oTable.Rows.Item(1).Range.Font.Bold = True
                oTable.Range.Style = "Table Grid"
                'смаляване на формата
                Me.Height = 375
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

    Private Sub Reference_Va_Year_Over_Vipusk_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'изтриване на старите сойности в dgv1
        Do While dgv1.RowCount > 0
            dgv1.Rows.Remove(dgv1.Rows(0))
        Loop
        Me.Height = 377
        'Проверка дали chart1 е празно и  изтриване на стойностите im
        Call chartDataDel()
        Do While cmbYear.Items.Count > 0
            cmbVipusk.Items.Remove(cmbVipusk.Items(0))
            cmbClass.Items.Remove(cmbClass.Items(0))
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
                    ws.Name = "Съотношение на оценките по брой"
                    title2 = "Съотношение на оценките по брой през годините за: "
                    title2 = title2 & cmbVipusk.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
                    Dim r As DataTable
                    Dim xldi As Microsoft.Office.Interop.Excel.Chart
                    xldi = New Microsoft.Office.Interop.Excel.Chart
                    Const xlCenter = -4108
                    ws.Range(ws.Cells(1, 1), ws.Cells(1, 14)).Merge()
                    ws.Range(ws.Cells(1, 1), ws.Cells(1, 14)).HorizontalAlignment = xlCenter
                    ws.Range(ws.Cells(2, 1), ws.Cells(2, 6)).WrapText = True
                    ws.Cells(1, 1) = title1 & vbNewLine & title2
                    ws.Range(ws.Cells(2, 1), ws.Cells(2, 2)).Merge()
                    ws.Range(ws.Cells(2, 1), ws.Cells(2, 2)).HorizontalAlignment = xlCenter
                    ws.Range(ws.Cells(2, 3), ws.Cells(8, 3)).Merge()
                    ws.Range(ws.Cells(2, 6), ws.Cells(8, 6)).Merge()
                    ws.Range(ws.Cells(2, 9), ws.Cells(8, 9)).Merge()
                    ws.Range(ws.Cells(2, 12), ws.Cells(8, 12)).Merge()
                    ws.Range(ws.Cells(2, 1), ws.Cells(2, 2)).Merge()
                    ws.Range(ws.Cells(2, 4), ws.Cells(2, 5)).Merge()
                    ws.Range(ws.Cells(2, 7), ws.Cells(2, 8)).Merge()
                    ws.Range(ws.Cells(2, 10), ws.Cells(2, 11)).Merge()
                    ws.Range(ws.Cells(2, 13), ws.Cells(2, 14)).Merge()
                    Dim y As Integer
                    y = cmbYear.Text
                    ws.Cells(3, 1) = "Oценка"
                    ws.Cells(4, 1) = "Слаб"
                    ws.Cells(5, 1) = "Среден"
                    ws.Cells(6, 1) = "Добър"
                    ws.Cells(7, 1) = "Много добър"
                    ws.Cells(8, 1) = "Отличен"
                    ws.Cells(3, 2) = "Брой"
                    ws.Cells(3, 5) = "Брой"
                    ws.Cells(3, 4) = "Oценка"
                    ws.Cells(4, 4) = "Слаб"
                    ws.Cells(5, 4) = "Среден"
                    ws.Cells(6, 4) = "Добър"
                    ws.Cells(7, 4) = "Много добър"
                    ws.Cells(8, 4) = "Отличен"
                    ws.Cells(3, 8) = "Брой"
                    ws.Cells(3, 7) = "Oценка"
                    ws.Cells(4, 7) = "Слаб"
                    ws.Cells(5, 7) = "Среден"
                    ws.Cells(6, 7) = "Добър"
                    ws.Cells(7, 7) = "Много добър"
                    ws.Cells(8, 7) = "Отличен"
                    ws.Cells(3, 10) = "Oценка"
                    ws.Cells(3, 11) = "Брой"
                    ws.Cells(4, 10) = "Слаб"
                    ws.Cells(5, 10) = "Среден"
                    ws.Cells(6, 10) = "Добър"
                    ws.Cells(7, 10) = "Много добър"
                    ws.Cells(8, 10) = "Отличен"
                    ws.Cells(3, 14) = "Брой"
                    ws.Cells(3, 13) = "Oценка"
                    ws.Cells(4, 13) = "Слаб"
                    ws.Cells(5, 13) = "Среден"
                    ws.Cells(6, 13) = "Добър"
                    ws.Cells(7, 13) = "Много добър"
                    ws.Cells(8, 13) = "Отличен"
                    Dim ys As String
                    ys = y & "/" & y Mod 100 + 1
                    ws.Cells(2, 1) = ys
                    ys = y - 1 & "/" & y Mod 100
                    ws.Cells(2, 4) = ys
                    ys = y - 2 & "/" & y Mod 100 - 1
                    ws.Cells(2, 7) = ys
                    ys = y - 3 & "/" & y Mod 100 - 2
                    ws.Cells(2, 10) = ys
                    ys = y - 4 & "/" & y Mod 100 - 3
                    ws.Cells(2, 13) = ys

                    ws.Range(ws.Cells(3, 1), ws.Cells(3, 2)).HorizontalAlignment = xlCenter
                    ws.Range("A1").EntireRow.RowHeight = 30
                    ws.Range("A3").EntireColumn.ColumnWidth = 15
                    ws.Range("B3").EntireColumn.ColumnWidth = 15
                    ws.Range("A2").EntireRow.RowHeight = 20
                    ws.Range("D3").EntireColumn.ColumnWidth = 15
                    ws.Range("E3").EntireColumn.ColumnWidth = 15
                    ws.Range("H3").EntireColumn.ColumnWidth = 15
                    ws.Range("G3").EntireColumn.ColumnWidth = 15
                    ws.Range("J3").EntireColumn.ColumnWidth = 15
                    ws.Range("K3").EntireColumn.ColumnWidth = 15
                    ws.Range("M3").EntireColumn.ColumnWidth = 15
                    ws.Range("N3").EntireColumn.ColumnWidth = 15
                    Dim bi, ci As String
                    bi = "B" & 4
                    ci = "B" & 4
                    Dim chartPage, cp1, cp2, cp3, cp4 As Microsoft.Office.Interop.Excel.Chart
                    Dim xlCharts As Microsoft.Office.Interop.Excel.ChartObjects
                    Dim myChart, mc1, mc2, mc3, mc4 As Microsoft.Office.Interop.Excel.ChartObject
                    Dim chartRange As Microsoft.Office.Interop.Excel.Range
                    xlCharts = ws.ChartObjects
                    myChart = xlCharts.Add(4, 158, 160, 160)
                    mc1 = xlCharts.Add(215, 158, 160, 160)
                    mc2 = xlCharts.Add(428, 158, 160, 160)
                    mc3 = xlCharts.Add(642, 158, 160, 160)
                    mc4 = xlCharts.Add(855, 158, 160, 160)
                    chartPage = myChart.Chart
                    cp1 = mc1.Chart
                    cp2 = mc2.Chart
                    cp3 = mc3.Chart
                    cp4 = mc4.Chart
                    chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlPie
                    cp1.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlPie
                    cp2.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlPie
                    cp3.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlPie
                    cp4.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlPie
                    'извикване на функция cmdmaxmi, която връща datareader и проверка тя дали е пълна
                    Dim otd As String

                    otd = ""

                    ' четене на datareader, изчисляване на данните и тяхното записване в excel
                    Dim c, y1, brrows, br, type, subject As Integer
                    br = 4
                    Dim scom As String
                    type = cmbIdType.Text
                    subject = cmbSubjectId.Text
                    prb1.Value = 0
                    prb1.Maximum = 11

                    Dim c2(5), c3(5), c4(5), c5(5), c6(5), c22, c32, c42, c52, c62 As Integer
                    For j As Integer = 0 To 5
                        c2(j) = 0
                        c3(j) = 0
                        c4(j) = 0
                        c5(j) = 0
                        c6(j) = 0
                    Next
                    Dim pk, i As Integer
                    Dim y11 As String
                    type = cmbIdType.Text
                    subject = cmbSubjectId.Text
                    i = cmbClass.Text
                    prb1.Value = 0


                    If i > 0 And i < 5 Then
                        pk = 1
                    ElseIf i > 4 And i < 8 Then
                        pk = 5
                    Else : pk = 8
                    End If
                    y1 = cmbYear.Text
                    c = i
                    Dim s As String
                    prb1.Maximum = pk - 1
                    s = "SELECT classes.school_year, sum(count_2) as c2, sum(count_3) as c3 ,sum(count_4) as c4, sum(count_5) as c5,sum(count_6) as c6"
                    s = s & " FROM classes Inner join purpose ON classes.id=purpose.class Where"
                    For j As Integer = i To pk Step -1
                        If type = -1 Then
                            If subject = -1 Then
                                scom = s & " classes.grade='" & c & "'and classes.school_year='" & y1 & " ' Group by classes.school_year;"
                            Else
                                scom = s & " purpose.subject='" & subject _
                                                              & "'and classes.grade='" & c & "'and classes.school_year='" & y1 & "' Group by classes.school_year; "
                            End If
                        Else
                            If subject = -1 Then
                                scom = s & " purpose.type='" & type _
                                                              & "'and classes.grade='" & c & "'and classes.school_year='" & y1 & "' Group by classes.school_year; "
                            Else
                                scom = s & " purpose.type='" & type _
                                                              & "'and purpose.subject='" & subject & "classes.grade='" & c & "'and classes.school_year='" & y1 & "' Group by classes.school_year;"
                            End If
                        End If
                        'задаванена на команда оттип String в променлива coms в зависимост от избрания начин на сортиране
                        r = New DataTable
                        cmd = New MySqlCommand(scom, cnn)
                        cmd.ExecuteNonQuery()
                        Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                        adaptre.Fill(r)

                        If r.Rows.Count > 0 Then
                            brrows = 0
                            c22 = r.Rows(brrows).Item("c2")
                            c32 = r.Rows(brrows).Item("c3")
                            c42 = r.Rows(brrows).Item("c4")
                            c52 = r.Rows(brrows).Item("c5")
                            c62 = r.Rows(brrows).Item("c6")
                            otd = ""
                            ' оценка с думи
                            y11 = cmbYear.Text
                            y = r.Rows(brrows).Item("school_year")
                            If y11 = y Then
                                brrows = 0
                            ElseIf y11 = y + 1 Then
                                brrows = 1
                            ElseIf y11 = y + 2 Then
                                brrows = 2
                            ElseIf y11 = y + 3 Then
                                brrows = 3
                            ElseIf y11 = y + 4 Then
                                brrows = 4
                            End If
                            c2(brrows) = c2(brrows) + c22
                            c3(brrows) = c3(brrows) + c32
                            c4(brrows) = c4(brrows) + c42
                            c5(brrows) = c5(brrows) + c52
                            c6(brrows) = c6(brrows) + c62
                        Else
                            Exit For
                        End If
                        y1 = y1 - 1
                        c = c - 1
                        prb1.Value = prb1.Value + 1
                    Next j
                    prb1.Value = pk - 1
                    Dim col As Integer
                    For j As Integer = 0 To 4
                        If j = 0 Then
                            col = 2
                        ElseIf j = 1 Then
                            col = 5
                        ElseIf j = 2 Then
                            col = 8
                        ElseIf j = 3 Then
                            col = 11
                        ElseIf j = 4 Then
                            col = 14
                        End If
                        ws.Cells(4, col) = c2(j)
                        ws.Cells(5, col) = c3(j)
                        ws.Cells(6, col) = c4(j)
                        ws.Cells(7, col) = c5(j)
                        ws.Cells(8, col) = c6(j)
                    Next
                    ws.Range(ws.Cells(2, 1), ws.Cells(8, 14)).HorizontalAlignment = xlCenter
                    chartRange = ws.Range("A4:B8")
                    chartPage.SetSourceData(Source:=chartRange)
                    chartRange = ws.Range("D4:F8")
                    cp1.SetSourceData(Source:=chartRange)
                    chartRange = ws.Range("G4:H8")
                    cp2.SetSourceData(Source:=chartRange)
                    chartRange = ws.Range("J4:K8")
                    cp3.SetSourceData(Source:=chartRange)
                    chartRange = ws.Range("M4:N8")
                    cp4.SetSourceData(Source:=chartRange)

                    ' chartPage.PlotBy = Microsoft.Office.Interop.Excel.XlRowCol.xlRows
                    ws.Copy(, masterWb.Sheets(masterWb.Sheets.Count))
                    ws = Nothing
                    xlWorkBook.Save()
                    xlWorkBook.Close()
                    xlWorkBook = Nothing
                    'Смаляване на формата
                    Me.Height = 375
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

 
End Class