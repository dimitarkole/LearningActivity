'използване на MySQL Data
Imports MySql.Data.MySqlClient
Public Class Reference_Va_Year_Clases
    'деклариране на глобални променливи
    Dim cnn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim years, title1, title2, flagbtn As String
    Dim a, b, RRowsCount As Integer
    Private Sub Reference_Va_Year_Clases_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        flagbtn = 0
        title1 = "Справка"
        title2 = "Съотношение на оценките по брой за 2 години: "

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
                    cmbSubject.Text = cmbSubject.Items(0)
                    cmbSubjectId.Text = cmbSubjectId.Items(0)
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


                    cmbtype.Text = cmbtype.Items(0)
                    cmbTypeid.Text = cmbTypeid.Items(0)
                End If
                brRows = brRows + 1
            Loop

        End If
        If cmbYear.Items.Count > 0 Then
            Call createdgv1()
        End If
        cnn.Close()
    End Sub

    Private Sub cmbVipusk_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYear.Leave, cmbYear.DropDownClosed
        If cmbYear.Items.Count > 0 Then
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
          
            'Отваряне на връската със SURVER
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            If cmbYear.Items.Count > 0 Then
                Call createdgv1()
            End If
            cnn.Close()
        End If
    End Sub
    Sub createdgv1()
        Dim brRows As Integer
        brRows = 0
        Dim sid, tid As Integer
        sid = cmbSubjectId.Text
        tid = cmbTypeid.Text
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
    End Sub
    Private Sub Reference_Va_Year_Clases_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Do While dgv1.RowCount > 0
            dgv1.Rows.Remove(dgv1.Rows(0))
        Loop
        Me.Height = 364
        'Проверка дали chart1 е празно
        Chart1.Series.Clear()
        Chart1.Legends.Clear()
        Chart1.Titles.Clear()
        Chart2.Titles.Clear()
        Chart2.Series.Clear()
        Chart2.Legends.Clear()
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
                r = "SELECT classes.grade, classes.class, classes.school_year, sum(count_2) as c2, sum(count_3) as c3, sum(count_4) as c4, sum(count_5) as c5, sum(count_6) as c6 " _
                                              & "FROM classes Inner join purpose" _
                                              & " ON classes.id=purpose.class Where school_year='" & cmbYearid.Text & "'or school_year='" & cmbYearid.Text - 1 _
                                              & "' Group by  purpose.class order by classes.grade asc, classes.class asc, school_year desc;"

            Else
                r = "SELECT classes.grade, classes.class, classes.school_year,sum(count_2) as c2, sum(count_3) as c3, sum(count_4) as c4, sum(count_5) as c5, sum(count_6) as c6 " _
                                              & "FROM classes Inner join purpose" _
                                              & " ON classes.id=purpose.class Where purpose.subject='" & subject _
                                              & "' and (school_year='" & cmbYearid.Text & "'or school_year='" & cmbYearid.Text - 1 & "') Group by  purpose.class order by classes.grade asc, classes.class asc, school_year desc;"

            End If
        Else
            If subject = -1 Then
                r = "SELECT classes.grade, classes.class, classes.school_year, sum(count_2) as c2, sum(count_3) as c3, sum(count_4) as c4, sum(count_5) as c5, sum(count_6) as c6)" _
                                              & "FROM classes Inner join purpose" _
                                              & " ON classes.id=purpose.class Where purpose.type='" & type & "'and (school_year='" & cmbYearid.Text & "'or school_year='" & cmbYearid.Text - 1 _
                                              & "') Group by  purpose.class order by classes.grade asc, classes.class asc, school_year desc;"

            Else
                r = "SELECT classes.grade, classes.class, classes.school_year,sum(count_2) as c2, sum(count_3) as c3, sum(count_4) as c4, sum(count_5) as c5, sum(count_6) as c6" _
                                              & "FROM classes Inner join purpose" _
                                              & " ON classes.id=purpose.class Where purpose.type='" & type _
                                             & "'and purpose.subject='" & subject & "' and  (school_year='" & cmbYearid.Text & "'or school_year='" & cmbYearid.Text - 1 _
                                             & "') Group by  purpose.class order by classes.grade asc, classes.class asc, school_year desc;"

            End If
        End If

    End Sub

    Private Sub btnchart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnchart.Click
        If cmbYear.Text <> "" Then
            'проверка за стойностите в диаграмата и тяхното изтриване

            Chart1.Series.Clear()
            Chart1.Titles.Clear()
            Chart1.Series.Add("Otnoshenie")
            Chart1.Series(0).ChartType = 17
            Chart2.Series.Clear()
            Chart2.Titles.Clear()
            Chart2.Series.Add("Otnoshenie")
            Chart2.Series(0).ChartType = 17

            Dim y As String
            y = cmbYearid.Text & "/" & cmbYearid.Text Mod 100 + 1
            title2 = "Съотношение на оценките по брой зa:  "
            title2 = title2 & y & " година, предмет: " & cmbSubject.Text & ", за вид оценка: " & cmbtype.Text
            Chart1.Titles.Add(title1)
            Chart1.Titles.Add(title2)
            y = cmbYearid.Text - 1 & "/" & cmbYearid.Text Mod 100
            title2 = "Съотношение на оценките по брой зa:  "
            title2 = title2 & y & " година, предмет: " & cmbSubject.Text & ", за вид оценка: " & cmbtype.Text
            Chart2.Titles.Add(title1)
            Chart2.Titles.Add(title2)
            'викане на функция cmdmaxmin, която връща резултат datareader и проверка дали редовете в негя саповече от 0
            Dim r As DataTable = New DataTable
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
                prb1.Value = 0
                prb1.Maximum = RRowsCount
                Dim c2, c3, c4, c5, c6, brrows As Integer
                Dim c22, c32, c42, c52, c62, year As Integer
                'обхождане на редовете един по един и добавяне на изчислените стойности в диаграмата
                brrows = 0
                year = cmbYearid.Text
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
                    Chart1.Width = 629
                    Chart2.Visible = True
                    Chart2.Series(0)("PieLabelStyle") = "Outside"
                Else
                    Chart1.Width = 1265
                    Chart2.Visible = False
                End If
                'оголемяване на формата
                flagbtn = 1
                cnn.Close()
                Chart1.Visible = True
                Me.Height = 735
            End If
        Else
            MsgBox("Трябва да се върнете и да веведете оценки ! ! !", , "Справка")
        End If
    End Sub

    Private Sub btnExselNewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExselNewFile.Click
        If cmbYear.Text <> "" Then
            Dim y As String
            y = cmbYearid.Text & "/" & cmbYearid.Text Mod 100 + 1
            title2 = "Съотношение на оценките по брой зa:  "
            title2 = title2 & y & " година, предмет: " & cmbSubject.Text & ", за вид оценка: " & cmbtype.Text
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
                y = cmbYearid.Text - 1 & "/" & cmbYearid.Text Mod 100
                title2 = "Съотношение на оценките по брой зa:  "
                title2 = title2 & y & " година, предмет: " & cmbSubject.Text & ", за вид оценка: " & cmbtype.Text
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
                    year = cmbYearid.Text
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
                    Me.Height = 364
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
                    y = cmbYearid.Text & "/" & cmbYearid.Text Mod 100 + 1
                    title2 = "Съотношение на оценките по брой зa:  "
                    title2 = title2 & y & " година, предмет: " & cmbSubject.Text & ", за вид оценка: " & cmbtype.Text

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


                    y = cmbYearid.Text - 1 & "/" & cmbYearid.Text Mod 100
                    title2 = "Съотношение на оценките по брой зa:  "
                    title2 = title2 & y & " година, предмет: " & cmbSubject.Text & ", за вид оценка: " & cmbtype.Text
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
                        year = cmbYearid.Text
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
                        Me.Height = 364
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
                oPara2 = oDoc.Content.Paragraphs.Add
                oPara2.Range.Font.Size = 14
                y = cmbYearid.Text & "/" & cmbYearid.Text Mod 100 + 1
                oPara1.Range.Text = "Съотношение на оценките по брой зa:  " & y & " - " & cmbYearid.Text - 1 & "/" & cmbYearid.Text Mod 100 & " година, предмет: " & cmbSubject.Text & ", за вид оценка: " & cmbtype.Text

                oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, 6, 3)
                'извикване на функция cmdmaxmi, която връща datareader и проверка тя дали е пълна 
                Dim r As DataTable = New DataTable
                cmdmaxmin(r)
                If RRowsCount > 0 Then

                    prb1.Value = 0
                    prb1.Maximum = RRowsCount
                    oTable.Cell(1, 1).Range.Text = "Оценка"
                    oTable.Cell(1, 2).Range.Text = "Брой " & y
                    oTable.Cell(1, 3).Range.Text = "Брой " & cmbYearid.Text - 1 & "/" & cmbYearid.Text Mod 100
                    Dim c2, c3, c4, c5, c6 As Integer
                    Dim c22, c32, c42, c52, c62, brrows, year As Integer
                    'четене на datareader, изчисляване на данните и тяхното записване в excel

                    brrows = 0
                    year = cmbYearid.Text
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
                    oTable.Cell(2, 2).Range.Text = c2
                    oTable.Cell(3, 1).Range.Text = "Среден"
                    oTable.Cell(3, 2).Range.Text = c3
                    oTable.Cell(4, 1).Range.Text = "Добър"
                    oTable.Cell(4, 2).Range.Text = c4
                    oTable.Cell(5, 1).Range.Text = "Много добър"
                    oTable.Cell(5, 2).Range.Text = c5
                    oTable.Cell(6, 1).Range.Text = "Отличен"
                    oTable.Cell(6, 2).Range.Text = c6

                    oTable.Cell(2, 3).Range.Text = c22
                    oTable.Cell(3, 3).Range.Text = c32
                    oTable.Cell(4, 3).Range.Text = c42
                    oTable.Cell(5, 3).Range.Text = c52
                    oTable.Cell(6, 3).Range.Text = c62
                    'форматиране на таблицата
                    oTable.Range.Style = "Table Grid"
                    'смаляване на формата
                    Me.Height = 364
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
End Class