'използване на MySQL Data
Imports MySql.Data.MySqlClient
Public Class Reference_Year_Classes
    'деклариране на глобални променливи
    Dim cnn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim years, title1, title2, flagbtn As String
    Dim a, b, RRowsCount As Integer
    Private Sub Reference_Year_Classes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                y = yearM2(j) & "/" & yearM2(j) Mod 100 + 1 & " - " & yearM2(j) - 1 & "/" & yearM2(j) Mod 100
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
        cmbYearid.Text = cmbYearid.Items(cmbYear.SelectedIndex)
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

                If year = cmbYearid.Text Or year = cmbYearid.Text - 1 Then
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
    Private Sub cmbYear_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYear.Leave, cmbYear.DropDownClosed
        If (cmbYear.SelectedIndex = -1) Then
            cmbYear.Text = cmbYear.Items(0)
            cmbYear.Focus()
        Else
            cmbYearid.Text = cmbYearid.Items(cmbYear.SelectedIndex)
            Do While cmbtype.Items.Count > 1
                cmbtype.Items.Remove(cmbtype.Items(1))
                cmbTypeid.Items.Remove(cmbTypeid.Items(1))
            Loop

            Do While cmbSubject.Items.Count > 1
                cmbSubject.Items.Remove(cmbSubject.Items(1))
                cmbSubjectId.Items.Remove(cmbSubjectId.Items(1))
            Loop
            Do While dgv1.Rows.Count > 0
                dgv1.Rows.Remove(dgv1.Rows(0))
            Loop

            Dim brRows, nomer, flag, britem As Integer
            brRows = 0
            'Отваряне на връската със SURVER
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
            'Проверка дли в таблица purpose има записи
            If data.Rows.Count > 0 Then
                Dim yearM(data.Rows.Count), yearM2(data.Rows.Count) As Integer
                Dim brm As Integer
                brm = 1
                For i As Integer = 0 To data.Rows.Count
                    yearM(i) = 0
                    yearM2(i) = 0
                Next

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

                            cmbSubject.Text = cmbSubject.Items(0)
                            cmbSubjectId.Text = cmbSubjectId.Items(0)


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
            Dim id, yid As Integer
            cmbYearid.Text = cmbYearid.Items(cmbYear.SelectedIndex)
            yid = cmbYearid.Text
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
                    If year = yid Or year = yid - 1 Then
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
            Dim brm, sid As Integer
            sid = cmbSubjectId.Text
            'Отваряне на връската със SURVER
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            If sid = -1 Then
                cmd = New MySqlCommand("Select* from  purpose order by id", cnn)
            Else
                cmd = New MySqlCommand("Select* from  purpose where subject='" & sid & "'order by id", cnn)
            End If
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)

            'Проверка дли в таблица purpose има записи
            If data.Rows.Count > 0 Then


                brm = 1
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
            If sid = -1 Then
                cmd = New MySqlCommand("Select* from  purpose", cnn)
            Else
                cmd = New MySqlCommand("Select* from  purpose where subject='" & sid & "'", cnn)
            End If

            cmd.ExecuteNonQuery()
            Dim adaptre30 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data30 As DataTable = New DataTable
            adaptre30.Fill(data30)
            Dim id As Integer
            cmbYearid.Text = cmbYearid.Items(cmbYear.SelectedIndex)
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
                    If year = cmbYearid.Text Or year = cmbYearid.Text - 1 Then
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
            Dim sid, tid As Integer
            sid = cmbSubjectId.Text
            tid = cmbTypeid.Text
            'Отваряне на връската със SURVER
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            If tid = -1 Then
                If sid = -1 Then
                    cmd = New MySqlCommand("Select* from  purpose order by id", cnn)
                Else
                    cmd = New MySqlCommand("Select* from  purpose where subject='" & sid & "'order by id", cnn)
                End If
            Else
                If sid = -1 Then
                    cmd = New MySqlCommand("Select* from  purpose where type='" & tid & "'order by id", cnn)
                Else
                    cmd = New MySqlCommand("Select* from  purpose where subject='" & sid & "'and type='" & tid & "'order by id", cnn)
                End If
            End If
            cmd.ExecuteNonQuery()
            Dim adaptre30 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data30 As DataTable = New DataTable
            adaptre30.Fill(data30)
            Dim id As Integer
            cmbYearid.Text = cmbYearid.Items(cmbYear.SelectedIndex)
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
                    If year = cmbYearid.Text Or year = cmbYearid.Text - 1 Then
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

    Private Sub btnchart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnchart.Click
        If cmbYear.Text <> "" Then
            'проверка за стойностите в диаграмата и тяхното изтриване
            If flagbtn = 1 Then
                Chart1.Series.Clear()
                Chart1.Titles.Clear()
            End If
            title2 = "Успех по паралелки за 2 години: "
            title2 = title2 & cmbYear.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
            Chart1.Titles.Add(title1)
            Chart1.Titles.Add(title2)
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
            cmdmaxmin(r)
            Dim classes, class22, class1 As String
            Dim grade, brrows As Integer
            Dim y1 As String
            Dim max As Double
            prb1.Value = 0
            prb1.Maximum = RRowsCount
            If RRowsCount > 0 Then
                Dim row As Integer = 0
                Chart1.Series.Clear()
                Chart1.Series.Add(cmbYearid.Text & "/" & cmbYearid.Text Mod 100 + 1)
                Chart1.Series.Add(cmbYearid.Text - 1 & "/" & cmbYearid.Text Mod 100)
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
                    If y1 = cmbYearid.Text Then
                        prb1.Value = prb1.Value + 1
                        ' оценка с думи
                        class1 = grade & " " & classes
                        Chart1.Series(0).Points.AddXY(row, max)
                        Chart1.ChartAreas.Item(0).AxisX.CustomLabels.Add(row - 0.5, row + 0.5, class1)
                        brrows = brrows + 1
                        Chart1.Series(0).Points(row1).Label = Math.Round(max, 2)
                        row1 = row1 + 1
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
                                brrows = brrows + 1
                                Chart1.Series(1).Points(row2).Label = Math.Round(max, 2)
                                row2 = row2 + 1
                            End If
                        End If
                        row = row + 1
                    Else
                        brrows = brrows + 1
                        prb1.Value = prb1.Value + 1
                    End If
                Loop
                flagbtn = 1
                cnn.Close()
                'оголемяване на формата
                Chart1.Visible = True
                Me.Height = 735
            End If
        Else
            MsgBox("Трябва да се върнете и да веведете оценки ! ! !", , "Справка")
        End If
    End Sub
    Private Sub cmdmaxmin(ByRef dt As DataTable)
        'проверка дали на този клас са въвейдани оценки по зададен вид оценки
        Dim scom As String
        dt = New DataTable
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
        Dim type, subject As Integer
        type = cmbTypeid.Text
        subject = cmbSubjectId.Text
        'В зависимуст от избраните параметри се връща низ със комндата

        If type = -1 Then
            If subject = -1 Then
                r = "SELECT classes.grade, classes.class, classes.school_year, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                              & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                              & " ON classes.id=purpose.class Where school_year='" & cmbYearid.Text & "'or school_year='" & cmbYearid.Text - 1 _
                                              & "' Group by  purpose.class order by classes.grade asc, classes.class asc, school_year desc;"

            Else
                r = "SELECT classes.grade, classes.class, classes.school_year, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                              & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                              & " ON classes.id=purpose.class Where purpose.subject='" & subject _
                                              & "' and (school_year='" & cmbYearid.Text & "'or school_year='" & cmbYearid.Text - 1 & "') Group by  purpose.class order by classes.grade asc, classes.class asc, school_year desc;"

            End If
        Else
            If subject = -1 Then
                r = "SELECT classes.grade, classes.class, classes.school_year, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                              & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                              & " ON classes.id=purpose.class Where purpose.type='" & type & "'and (school_year='" & cmbYearid.Text & "'or school_year='" & cmbYearid.Text - 1 _
                                              & "') Group by  purpose.class order by classes.grade asc, classes.class asc, school_year desc;"

            Else
                r = "SELECT classes.grade, classes.class, classes.school_year, (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)" _
                                              & "/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6)) as sreden_uspeh FROM classes Inner join purpose" _
                                              & " ON classes.id=purpose.class Where purpose.type='" & type _
                                             & "'and purpose.subject='" & subject & "' and  (school_year='" & cmbYearid.Text & "'or school_year='" & cmbYearid.Text - 1 _
                                             & "') Group by  purpose.class order by classes.grade asc, classes.class asc, school_year desc;"

            End If
        End If

    End Sub

    Private Sub btnExselNewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExselNewFile.Click
        If cmbYear.Text <> "" Then
            title2 = "Успех по паралелки за 2 години: "
            title2 = title2 & cmbYear.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text
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
                xlsheet.Name = "Успех за 2 последователни год"
                xldi = New Microsoft.Office.Interop.Excel.Chart
                Const xlCenter = -4108
                xlsheet.Range(xlsheet.Cells(1, 1), xlsheet.Cells(1, 3)).Merge()
                xlsheet.Range(xlsheet.Cells(1, 1), xlsheet.Cells(1, 3)).HorizontalAlignment = xlCenter
                xlsheet.Cells(1, 1) = title1
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 3)).Merge()
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 3)).HorizontalAlignment = xlCenter
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 3)).WrapText = True
                xlsheet.Cells(2, 1) = title2
                xlsheet.Cells(3, 2) = cmbYearid.Text & "/" & cmbYearid.Text Mod 100 + 1
                xlsheet.Cells(3, 3) = cmbYearid.Text - 1 & "/" & cmbYearid.Text Mod 100
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
                        If y1 = cmbYearid.Text Then
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
                    Me.Height = 366
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
                    MsgBox("За тези паралелки не са въведени оценки!!!", , "Справка")
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
                ws.Name = "Успех за 2 последователни год"
                title2 = "Успех по паралелки за 2 години: "
                title2 = title2 & cmbYear.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text

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
                ws.Cells(3, 2) = cmbYearid.Text & "/" & cmbYearid.Text Mod 100 + 1
                ws.Cells(3, 3) = cmbYearid.Text - 1 & "/" & cmbYearid.Text Mod 100
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
                        If y1 = cmbYearid.Text Then
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
                    Me.Height = 366
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

                title2 = "Успех по паралелки за 2 години: "
                title2 = title2 & cmbYear.Text & ", предмет: " & cmbSubject.Text & ", вид оценка: " & cmbtype.Text

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
                        If y1 = cmbYearid.Text Then
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
                    oTable.Cell(1, 1).Range.Text = "Клас"
                    oTable.Cell(1, 2).Range.Text = cmbYearid.Text & "/" & cmbYearid.Text Mod 100 + 1
                    oTable.Cell(1, 3).Range.Text = cmbYearid.Text - 1 & "/" & cmbYearid.Text Mod 100
                    For i As Integer = 1 To br
                        oTable.Cell(i + 1, 1).Range.Text = m(i - 1, 1)
                        oTable.Cell(i + 1, 2).Range.Text = m(i - 1, 2)
                        oTable.Cell(i + 1, 3).Range.Text = m(i - 1, 3)
                    Next
                    'форматиране на таблицата
                    oTable.Rows.Item(1).Range.Font.Bold = True
                    oTable.Range.Style = "Table Grid"
                    'смаляване на формата
                    Me.Height = 366
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

    Private Sub Reference_Year_Classes_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Do While dgv1.RowCount > 0
            dgv1.Rows.Remove(dgv1.Rows(0))
        Loop
        Me.Height = 366
        'Проверка дали chart1 е празно
        If Chart1.Series.Count > 0 Then
            Chart1.Series.Clear()
            Chart1.Titles.Clear()

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