'използване на MySQL Data
Imports MySql.Data.MySqlClient
Public Class reference_universa_gpa
    'деклариране на глобални променливи
    Dim cnn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim years, title1, title2 As String
    Dim subjectflag As Integer = 0
    Dim typeflag As Integer = 0
    Dim a, b, RRowsCount As Integer
    Sub writeyear()
        Dim brRows As Integer
        cmd = New MySqlCommand("Select school_year from  classes Group by school_year order by school_year desc;", cnn)
        cmd.ExecuteNonQuery()
        Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
        Dim data As DataTable = New DataTable
        adaptre.Fill(data)
        'Проверка дaли в таблица purpose има записи
        If data.Rows.Count > 0 Then
            'ако има записи
            Dim years As Integer
            Dim yeardo As String
            brRows = 0
            'минаване през всчики редове на таблица
            For i As Integer = 1 To data.Rows.Count
                'Селактиране на номера на класа на ред
                years = data.Rows(i - 1).Item("school_year")
                yeardo = years & "/" & years Mod 100 + 1
                cmbYear.Items.Add(years)
                cmbYearString.Items.Add(yeardo)
            Next
            cmbYearString.Text = cmbYearString.Items(0)
            cmbYear.Text = cmbYear.Items(0)
        End If

    End Sub

    Sub writeClass()
        cmd = New MySqlCommand("Select grade from  classes where school_year='" & cmbYear.Text & "' Group by grade order by grade desc;", cnn)
        cmd.ExecuteNonQuery()
        Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
        Dim data As DataTable = New DataTable
        adaptre.Fill(data)
        'Проверка дaли в таблица purpose има запис
        If data.Rows.Count > 0 Then
            'ако и
            Dim grade As Integer
            'минаване през всчики редове на таблица purpose
            For i As Integer = 1 To data.Rows.Count
                'Селактиране на номера на класа на ред
                grade = data.Rows(i - 1).Item("grade")
                cmbClass.Items.Add(grade)
            Next
            cmbClass.Text = cmbClass.Items(0)
        End If
    End Sub

    Sub writeparal()
        Dim brRows As Integer
        Dim scmd As String = "Select class from  classes where school_year='" & cmbYear.Text
        If cmbClass.Text <> cmbClass.Items(0) Then
            scmd = scmd & "' and grade='" & cmbClass.Text
        End If
        scmd = scmd & "' Group by class order by class asc;"
        cmd = New MySqlCommand(scmd, cnn)
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
                cmbParal.Items.Add(paralelka)
            Next
            cmbParal.Text = cmbParal.Items(0)
        End If

    End Sub

    Sub writeprofile()
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
    End Sub

    Sub writeSubject()
        Dim scmd As String
        scmd = "Select subject.id, purpose.subject, subject.name_subject, number from classes Inner join purpose ON classes.id=purpose.class Inner join subject ON purpose.subject=subject.id  where "
        scmd = scmd & "school_year='" & cmbYear.Text & "' group by subject order by subject.number"
        cmd = New MySqlCommand(scmd, cnn)
        cmd.ExecuteNonQuery()
        Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
        Dim dt As DataTable = New DataTable
        adaptre1.Fill(dt)
        chlSubject.Items.Add("Всички предмети")
        If dt.Rows.Count > 0 Then
            For i As Integer = 1 To dt.Rows.Count
                chlSubject.Items.Add(dt.Rows(i - 1).Item("name_subject"))
            Next
            subjectflag = 1
            For i As Integer = 0 To chlSubject.Items.Count - 1
                chlSubject.SetItemChecked(i, True)
            Next
            subjectflag = 0
        End If
    End Sub

    Sub writetype()
        Dim scmd As String
        scmd = "Select types.id, purpose.type, types.name_type from classes Inner join purpose ON classes.id=purpose.class Inner join types ON purpose.type=types.id  "
        scmd = scmd & "where school_year='" & cmbYear.Text & "'"

        Dim adaptre1 As MySqlDataAdapter
        Dim dt As DataTable
        Dim words As String = " and ("
        For i As Integer = 1 To chlSubject.Items.Count - 1
            If chlSubject.GetItemChecked(i) = True Then
                cmd = New MySqlCommand("Select* from subject where name_subject='" & chlSubject.Items(i) & "'", cnn)
                cmd.ExecuteNonQuery()
                adaptre1 = New MySqlDataAdapter(cmd)
                dt = New DataTable
                adaptre1.Fill(dt)
                scmd = scmd & words & "subject='" & dt.Rows(0).Item("id") & "'"
                words = " or "
            End If
        Next
        If words = " or " Then
            scmd = scmd & ")"
        End If
        scmd = scmd & " group by type order by types.id;"

        cmd = New MySqlCommand(scmd, cnn)
        cmd.ExecuteNonQuery()
        dt = New DataTable
        adaptre1 = New MySqlDataAdapter(cmd)
        adaptre1.Fill(dt)
        chltype.Items.Add("Всички видове оценки")
        If dt.Rows.Count > 0 Then
            For i As Integer = 1 To dt.Rows.Count
                chltype.Items.Add(dt.Rows(i - 1).Item("name_type"))
            Next
            typeflag = 1
            For i As Integer = 0 To chltype.Items.Count - 1
                chltype.SetItemChecked(i, True)
            Next
            typeflag = 0
        End If
    End Sub

    Private Sub Reference_Universal_GPA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Отваряне на връската със SURVER

        cnn = New MySqlConnection("server=localhost;user id=root; password=;database=learning_activity;charset=utf8")
        cnn.Open()
        Dim brRows As Integer
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
            'задаване на текст на cmbtaта 
            Call writeyear()
            Call writeClass()
            Call writeparal()
            Call writeprofile()
            Call writeSubject()
            Call writetype()
            Call create_dgv()
        End If
        Me.Width = 1360
        Chart1.Width = 1335
        cnn.Close()
    End Sub

    Sub create_dgv()
        If cmbYear.Text <> "" And chlSubject.CheckedItems.Count > 0 And chltype.CheckedItems.Count > 0 Then
            dgv1.Rows.Clear()
            Dim scom As String
            Dim year, id As Integer
            Dim count_2, count_3, count_4, count_5, count_6 As String
            year = cmbYear.Text


            scom = "SELECT purpose.id, classes.grade, classes.class, classes.school_year, count_2, count_3, count_4, count_5, count_6, subject, type FROM classes Inner join purpose ON classes.id=purpose.class Where"
            Dim f As Integer = 0
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
            Dim words As String = "' and ("
            Dim adaptre1 As New MySqlDataAdapter
            Dim dt As New DataTable
            For i As Integer = 1 To chlSubject.Items.Count - 1
                If chlSubject.GetItemChecked(i) = True Then
                    cmd = New MySqlCommand("Select* from subject where name_subject='" & chlSubject.Items(i) & "'", cnn)
                    cmd.ExecuteNonQuery()
                    adaptre1 = New MySqlDataAdapter(cmd)
                    dt = New DataTable
                    adaptre1.Fill(dt)
                    scom = scom & words & "subject='" & dt.Rows(0).Item("id") & "'"
                    words = " or "
                End If
            Next
            If words = " or " Then
                words = ") and ("
            Else
                words = "' and ("
            End If


            For i As Integer = 1 To chltype.Items.Count - 1
                If chltype.GetItemChecked(i) = True Then
                    cmd = New MySqlCommand("Select* from types where name_type='" & chltype.Items(i) & "'", cnn)
                    cmd.ExecuteNonQuery()
                    adaptre1 = New MySqlDataAdapter(cmd)
                    dt = New DataTable
                    adaptre1.Fill(dt)
                    scom = scom & words & "type='" & dt.Rows(0).Item("id") & "'"
                    words = " or "
                End If
            Next
            If words = " or " Or words = ") and (" Then
                scom = scom & ")"
            Else
                scom = scom & "'"
            End If
            cmd = New MySqlCommand(scom, cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            If data.Rows.Count > 0 Then
                Dim paral, subjectstr, profilstr, typestr As String
                ' TextBox1.Text = scom
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
                    adaptre1 = New MySqlDataAdapter(cmd)
                    dt = New DataTable
                    adaptre1.Fill(dt)
                    subjectstr = dt.Rows(0).Item("name_subject")
                    '   If subjectstr = cmbSubject.Text Or cmbSubject.Text = cmbSubject.Items(0) Then
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

                        'задаване на тип
                        idobject = data.Rows(0).Item("type")
                        scom = "SELECT* from types where id='" & idobject & "';"
                        cmd = New MySqlCommand(scom, cnn)
                        cmd.ExecuteNonQuery()
                        adaptre1 = New MySqlDataAdapter(cmd)
                        dt = New DataTable
                        adaptre1.Fill(dt)
                        typestr = dt.Rows(0).Item("name_type")
                        'f typestr = cmbtype.Text Or cmbtype.Text = cmbtype.Items(0) Then
                        'задаване на оценки
                        count_2 = data.Rows(i - 1).Item("count_2")
                        count_3 = data.Rows(i - 1).Item("count_3")
                        count_4 = data.Rows(i - 1).Item("count_4")
                        count_5 = data.Rows(i - 1).Item("count_5")
                        count_6 = data.Rows(i - 1).Item("count_6")
                        dgv1.Rows.Add(id, yearstr, classint, paral, profilstr, subjectstr, typestr, count_2, count_3, count_4, count_5, count_6) ', 'classes, subject, type, count_2, count_3, count_4, count_5, count_6)

                        'End If
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
        Do While chlSubject.Items.Count > 0
            chlSubject.Items.Remove(chlSubject.Items(0))
        Loop
    End Sub

    Sub clearType()
        Do While chltype.Items.Count > 0
            chltype.Items.Remove(chltype.Items(0))
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
            Call clearType()
            dgv1.Rows.Clear()
            'Отваряне на връската със SURVER
            cnn.Open()
            cmd = New MySqlCommand("Select* from  classes where school_year='" & cmbYear.Text & "' order by grade desc, class desc;", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            'Проверка дaли в таблица purpose има записи
            If data.Rows.Count > 0 Then
                'задаване на текст на cmbtaта
                Call writeClass()
                Call writeparal()
                Call writeprofile()
                Call writeSubject()
                Call writetype()
                Call create_dgv()
            End If
            ' пълнене на dgv1

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
            Call clearType()
            dgv1.Rows.Clear()
            'Отваряне на връската със SURVER
            cnn.Open()
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
                Call writeparal()
                Call writeprofile()
                Call writeSubject()
                Call writetype()
                Call create_dgv()
            End If
            ' пълнене на dgv1

            cnn.Close()
        End If
    End Sub

    Private Sub cmbParal_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbParal.Leave, cmbParal.DropDownClosed
        If (cmbParal.SelectedIndex = -1) Then
            cmbParal.Text = cmbParal.Items(0)
            cmbParal.Focus()
        Else
            Call clearProfile()
            Call clearSubject()
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
                Call writeprofile()
                Call writeSubject()
                Call writetype()

                Call create_dgv()
            End If
            ' пълнене на dgv1
            cnn.Close()
        End If
    End Sub

    Private Sub cmbProfil_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProfil.Leave, cmbProfil.DropDownClosed
        If (cmbProfil.SelectedIndex = -1) Then
            cmbProfil.Text = cmbProfil.Items(0)
            cmbProfil.Focus()
        Else
            Call clearSubject()
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
                Call writeSubject()
                Call writetype()
                Call create_dgv()

            End If
            cnn.Close()
        End If
    End Sub

    Function createscmb(ByRef scmb As String)
        scmb = "SELECT "
        If cmbYear.Text <> "" Then
            Dim year As Integer
            year = cmbYear.Text
            If rbtnparal.Checked = True Then
                scmb = scmb & "classes.grade, classes.class"
            ElseIf rbtnClass.Checked = True Then
                scmb = scmb & "classes.class"
            Else
                scmb = scmb & "classes.profile"
            End If

            If rbtnsubject.Checked = True Then
                scmb = scmb & ", purpose.subject"
            Else
                scmb = scmb & ", purpose.type"
            End If
            scmb = scmb & ", (sum(count_2)*2+sum(count_3)*3+sum(count_4)*4 + sum(count_5)*5+sum(count_6)*6)/(sum(count_2)+sum(count_3)+sum(count_4)+sum(count_5)+sum(count_6))" _
                                              & "as sreden_uspeh FROM classes Inner join purpose ON classes.id=purpose.class Where"
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
            Dim words As String = "' and ("
            Dim adaptre1 As New MySqlDataAdapter
            Dim dt As New DataTable
            For i As Integer = 1 To chlSubject.Items.Count - 1
                If chlSubject.GetItemChecked(i) = True Then
                    cmd = New MySqlCommand("Select* from subject where name_subject='" & chlSubject.Items(i) & "'", cnn)
                    cmd.ExecuteNonQuery()
                    adaptre1 = New MySqlDataAdapter(cmd)
                    dt = New DataTable
                    adaptre1.Fill(dt)
                    scmb = scmb & words & "subject='" & dt.Rows(0).Item("id") & "'"
                    words = " or "
                End If
            Next
            If words = " or " Then
                words = ") and ("
            Else
                words = "' and ("
            End If
            For i As Integer = 1 To chltype.Items.Count - 1
                If chltype.GetItemChecked(i) = True Then
                    cmd = New MySqlCommand("Select* from types where name_type='" & chltype.Items(i) & "'", cnn)
                    cmd.ExecuteNonQuery()
                    adaptre1 = New MySqlDataAdapter(cmd)
                    dt = New DataTable
                    adaptre1.Fill(dt)
                    scmb = scmb & words & "type='" & dt.Rows(0).Item("id") & "'"
                    words = " or "
                End If
            Next
            If words = " or " Or words = ") and (" Then
                scmb = scmb & ")"
            Else
                scmb = scmb & "'"
            End If


            scmb = scmb & " Group by "            '   
            If rbtnparal.Checked = True Then
                scmb = scmb & "purpose.class, grade "
            ElseIf rbtnClass.Checked = True Then
                scmb = scmb & "class"
            Else
                scmb = scmb & "profile"
            End If

            If rbtnsubject.Checked = True Then
                scmb = scmb & ", subject"
            Else
                scmb = scmb & ", type"
            End If

            If rbtnparal.Checked = True Then
                scmb = scmb & " order by grade asc, class asc;"
            ElseIf rbtnClass.Checked = True Then
                scmb = scmb & " order by class asc;"
            Else
                scmb = scmb & " order by profile asc;"
            End If




            Return scmb

        Else
            MsgBox("По тези критерии няма оценки! ! !", , "Универсална спавка")
            Return ""
        End If
    End Function

    Private Sub btnExselNewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExselNewFile.Click
        If cmbYear.Text <> "" Then

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
            'rasEx = "Excel | *.xlsx"
            SaveFileDialog1.Filter = rasEx
            If SaveFileDialog1.ShowDialog = DialogResult.OK Then
                cnn.Open()
                Call createText(title2)
                Dim xlapp As Microsoft.Office.Interop.Excel.Application
                Dim xlbook As Microsoft.Office.Interop.Excel.Workbook
                Dim xlsheet As Microsoft.Office.Interop.Excel.Worksheet
                Dim misvalue As Object = System.Reflection.Missing.Value

                Dim xldi As Microsoft.Office.Interop.Excel.Chart

                xlapp = New Microsoft.Office.Interop.Excel.Application
                xlbook = xlapp.Workbooks.Add(misvalue)
                xlsheet = CType(xlbook.Sheets(1), Microsoft.Office.Interop.Excel.Worksheet)
                xlsheet.Name = "Универсална справка"
                xlsheet.Visible = True
                xldi = New Microsoft.Office.Interop.Excel.Chart

                Const xlCenter = -4108
                'задаване на текст в клетки и форматиране на редове и колони
                If rbtnparal.Checked = True Then
                    xlsheet.Cells(3, 1) = "Клас"
                ElseIf rbtnClass.Checked = True Then
                    xlsheet.Cells(3, 1) = "Паралелка"
                Else
                    xlsheet.Cells(3, 1) = "Профил"
                End If

                Dim sizeMerge As Integer = 2
                Dim sumCountAverageSize As Integer
                If rbtnsubject.Checked = True Then
                    For p As Integer = 1 To chlSubject.Items.Count - 1
                        If chlSubject.GetItemChecked(p) = True Then
                            xlsheet.Cells(3, sizeMerge) = chlSubject.Items(p)
                            sizeMerge = sizeMerge + 1
                        End If
                    Next
                    sumCountAverageSize = chlSubject.Items.Count
                Else
                    For p As Integer = 1 To chltype.Items.Count - 1
                        If chltype.GetItemChecked(p) = True Then
                            xlsheet.Cells(3, sizeMerge) = chltype.Items(p)
                            sizeMerge = sizeMerge + 1
                        End If
                    Next
                    sumCountAverageSize = chltype.Items.Count
                End If
                xlsheet.Cells(3, sizeMerge) = "Средно"
                xlsheet.Range(xlsheet.Cells(1, 1), xlsheet.Cells(1, sizeMerge)).Merge()
                xlsheet.Cells(1, 1) = title1
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, sizeMerge)).Merge()
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, sizeMerge)).WrapText = True
                xlsheet.Cells(2, 1) = title2
                xlsheet.Range(xlsheet.Cells(3, 1), xlsheet.Cells(3, sizeMerge)).WrapText = True
                xlsheet.Range("A2").EntireRow.RowHeight = 45
                Dim pat As String
                pat = SaveFileDialog1.FileName

                Dim chartPage As Microsoft.Office.Interop.Excel.Chart
                Dim xlCharts As Microsoft.Office.Interop.Excel.ChartObjects
                Dim myChart As Microsoft.Office.Interop.Excel.ChartObject
                Dim chartRange As Microsoft.Office.Interop.Excel.Range
                xlCharts = xlsheet.ChartObjects
                myChart = xlCharts.Add(sizeMerge * 50, 50, 600, 250)
                chartPage = myChart.Chart

                chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlColumnClustered
                'извикване на функция cmdmaxmi, която връща datareader и проверка тя дали е пълна 
                Dim scmb As String = ""

                Call createscmb(scmb)
                Dim ColName As String
                If scmb <> "" Then
                    cmd = New MySqlCommand(scmb, cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt As DataTable = New DataTable
                    adaptre1.Fill(dt)
                    Dim sumAverage, countAverage, average As Double
                    Dim sumcountAverage(2, sumCountAverageSize) As Double
                    Dim br As Integer
                    Dim colon As Integer = 1
                    If dt.Rows.Count > 0 Then
                        Dim class2 As String
                        Dim max As Double
                        br = 4
                        prb1.Maximum = dt.Rows.Count
                        Dim privateClass As String
                        sumAverage = 0
                        countAverage = 0
                        average = 0
                        For i As Integer = 0 To dt.Rows.Count - 1

                            If rbtnparal.Checked = True Then
                                class2 = dt.Rows(i).Item("grade") & " " & dt.Rows(i).Item("class")
                            ElseIf rbtnClass.Checked = True Then

                                class2 = dt.Rows(i).Item("class")
                            Else
                                class2 = dt.Rows(i).Item("profile")
                                Call searchProfile(class2, class2)
                            End If
                            max = dt.Rows(i).Item("sreden_uspeh")
                            prb1.Value = i + 1

                            Dim seriesInt, idRow As Integer
                            Dim seriesStr As String
                            If rbtnsubject.Checked = True Then
                                seriesInt = dt.Rows(i).Item("subject")
                                cmd = New MySqlCommand("Select* from subject where id='" & seriesInt & "'", cnn)
                                cmd.ExecuteNonQuery()
                                Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                                Dim dt2 As DataTable = New DataTable
                                adaptre2.Fill(dt2)
                                seriesStr = dt2.Rows(0).Item("name_subject")
                                For p As Integer = 0 To chlSubject.Items.Count - 1
                                    If chlSubject.Items(p) = seriesStr Then
                                        idRow = p
                                    End If
                                Next
                            Else
                                seriesInt = dt.Rows(i).Item("type")
                                cmd = New MySqlCommand("Select* from types where id='" & seriesInt & "'", cnn)
                                cmd.ExecuteNonQuery()
                                Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                                Dim dt2 As DataTable = New DataTable
                                adaptre2.Fill(dt2)
                                seriesStr = dt2.Rows(0).Item("name_type")
                                For p As Integer = 0 To chltype.Items.Count - 1
                                    If chltype.Items(p) = seriesStr Then
                                        idRow = p
                                    End If
                                Next
                            End If
                            sumcountAverage(0, idRow) = sumcountAverage(0, idRow) + max
                            sumcountAverage(1, idRow) = sumcountAverage(1, idRow) + 1
                            If i > 0 Then

                                If rbtnparal.Checked = True Then
                                    privateClass = dt.Rows(i - 1).Item("grade") & " " & dt.Rows(i - 1).Item("class")
                                ElseIf rbtnClass.Checked = True Then
                                    privateClass = dt.Rows(i - 1).Item("class")
                                Else
                                    privateClass = dt.Rows(i - 1).Item("profile")
                                    Call searchProfile(privateClass, privateClass)
                                End If
                                If privateClass <> class2 Then
                                    average = Math.Round(sumAverage / countAverage, 2)
                                    xlsheet.Cells(br, sizeMerge) = average
                                    br = br + 1
                                    sumAverage = max
                                    countAverage = 1
                                Else
                                    sumAverage = sumAverage + max
                                    countAverage = countAverage + 1
                                End If
                            Else
                                sumAverage = sumAverage + max
                                countAverage = countAverage + 1
                            End If
                            colon = 1
                            Dim valueCells As String = xlsheet.Cells(3, colon).value()
                            Do While seriesStr <> valueCells
                                colon = colon + 1
                                valueCells = xlsheet.Cells(3, colon).value()
                            Loop

                            xlsheet.Cells(br, 1) = class2
                            max = Math.Round(max, 2)
                            xlsheet.Cells(br, colon) = max
                            ColName = xlsheet.Cells(br, colon).Address
                            chartRange = xlsheet.Range("A3:" & ColName)
                            chartPage.SetSourceData(Source:=chartRange)
                        Next
                        average = Math.Round(sumAverage / countAverage, 2)
                        xlsheet.Cells(br, sizeMerge) = average

                        br = br + 1
                        xlsheet.Cells(br, 1) = "Средно"
                        colon = 2

                        If rbtnsubject.Checked = True Then
                            For i As Integer = 1 To chlSubject.Items.Count - 1
                                If chlSubject.GetItemChecked(i) = True Then
                                    xlsheet.Cells(br, colon) = Math.Round(sumcountAverage(0, i) / sumcountAverage(1, i), 2)
                                    colon = colon + 1
                                End If
                            Next
                        Else
                            For i As Integer = 1 To chltype.Items.Count - 1
                                If chltype.GetItemChecked(i) = True Then
                                    xlsheet.Cells(br, colon) = Math.Round(sumcountAverage(0, i) / sumcountAverage(1, i), 2)
                                    colon = colon + 1
                                End If
                            Next
                        End If
                        Dim rng As Microsoft.Office.Interop.Excel.Range
                        ColName = xlsheet.Cells(br, sizeMerge).Address
                        rng = xlsheet.Range("A1:" & ColName)
                        Call cellborder(rng)
                        xlsheet.Range(xlsheet.Cells(1, 1), xlsheet.Cells(br, sizeMerge)).HorizontalAlignment = xlCenter
                        chartRange = xlsheet.Range("A3:" & ColName)
                        chartPage.SetSourceData(Source:=chartRange)
                        chartPage.HasLegend = True
                        chartPage.PlotBy = Microsoft.Office.Interop.Excel.XlRowCol.xlColumns
                        chartPage.HasTitle = True
                        chartPage.ChartTitle.Text = "Универсалн спавка"
                        'Смаляване на формата
                        Me.Height = 419
                        xlsheet.SaveAs(pat)
                        xlbook.Close()
                        xlapp.Quit()
                        releaseObject(xlapp)
                        releaseObject(xlbook)
                        releaseObject(xlsheet)
                        'питане дали да се отвори файла 
                        Dim res As MsgBoxResult
                        prb1.Value = prb1.Maximum
                        res = MsgBox("Искате ли файлът да се отвори?", MsgBoxStyle.YesNo, "Универсална спавка")
                        If res = MsgBoxResult.Yes Then
                            Process.Start(pat)
                        End If
                    Else
                        MsgBox("По тези критерии няма оценки! ! !", , "Универсална спавка")
                        prb1.Value = 0
                        xlsheet.SaveAs(pat)
                        xlbook.Close()
                        xlapp.Quit()
                        releaseObject(xlapp)
                        releaseObject(xlbook)
                        releaseObject(xlsheet)
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
            'Call Module1.RazExcel(rasEx)
            rasEx = "Excel | *.xlsx"
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


                'задаване на текст в клетки и форматиране на редове и колони
                ws = xlWorkBook.Sheets.Add(, xlWorkBook.Sheets(xlWorkBook.Sheets.Count))
                ws.Name = "Универсална справка ср успех"
                Call createText(title2)
                Dim xldi As Microsoft.Office.Interop.Excel.Chart
                xldi = New Microsoft.Office.Interop.Excel.Chart
                Const xlCenter = -4108
                If rbtnparal.Checked = True Then
                    ws.Cells(3, 1) = "Клас"
                ElseIf rbtnClass.Checked = True Then
                    ws.Cells(3, 1) = "Паралелка"
                Else
                    ws.Cells(3, 1) = "Профил"
                End If
                Dim sizeMerge As Integer = 2
                Dim sumCountAverageSize As Integer
                If rbtnsubject.Checked = True Then
                    For p As Integer = 1 To chlSubject.Items.Count - 1
                        If chlSubject.GetItemChecked(p) = True Then
                            ws.Cells(3, sizeMerge) = chlSubject.Items(p)
                            sizeMerge = sizeMerge + 1
                        End If
                    Next
                    sumCountAverageSize = chlSubject.Items.Count
                Else
                    For p As Integer = 1 To chltype.Items.Count - 1
                        If chltype.GetItemChecked(p) = True Then
                            ws.Cells(3, sizeMerge) = chltype.Items(p)
                            sizeMerge = sizeMerge + 1
                        End If
                    Next
                    sumCountAverageSize = chltype.Items.Count
                End If
                ws.Cells(3, sizeMerge) = "Средно"
                ws.Range(ws.Cells(1, 1), ws.Cells(1, sizeMerge)).Merge()
                ws.Cells(1, 1) = title1
                ws.Range(ws.Cells(2, 1), ws.Cells(2, sizeMerge)).Merge()
                ws.Range(ws.Cells(2, 1), ws.Cells(2, sizeMerge)).WrapText = True
                ws.Cells(2, 1) = title2
                ws.Range(ws.Cells(3, 1), ws.Cells(3, sizeMerge)).WrapText = True
                ws.Range("A2").EntireRow.RowHeight = 45

                Dim chartPage As Microsoft.Office.Interop.Excel.Chart
                Dim xlCharts As Microsoft.Office.Interop.Excel.ChartObjects
                Dim myChart As Microsoft.Office.Interop.Excel.ChartObject
                Dim chartRange As Microsoft.Office.Interop.Excel.Range
                xlCharts = ws.ChartObjects
                myChart = xlCharts.Add(sizeMerge * 50, 50, 600, 250)
                chartPage = myChart.Chart

                chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlColumnClustered
                'извикване на функция cmdmaxmi, която връща datareader и проверка тя дали е пълна 
                Dim scmb As String = ""

                Call createscmb(scmb)
                Dim ColName As String
                If scmb <> "" Then
                    cmd = New MySqlCommand(scmb, cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt As DataTable = New DataTable
                    adaptre1.Fill(dt)
                    Dim sumAverage, countAverage, average As Double
                    Dim sumcountAverage(2, sumCountAverageSize) As Double
                    Dim br As Integer
                    Dim colon As Integer = 1
                    If dt.Rows.Count > 0 Then
                        Dim class2 As String
                        Dim max As Double
                        br = 4
                        prb1.Maximum = dt.Rows.Count
                        Dim privateClass As String
                        sumAverage = 0
                        countAverage = 0
                        average = 0
                        For i As Integer = 0 To dt.Rows.Count - 1
                            If rbtnparal.Checked = True Then
                                class2 = dt.Rows(i).Item("grade") & " " & dt.Rows(i).Item("class")
                            ElseIf rbtnClass.Checked = True Then

                                class2 = dt.Rows(i).Item("class")
                            Else
                                class2 = dt.Rows(i).Item("profile")
                                Call searchProfile(class2, class2)
                            End If
                            max = dt.Rows(i).Item("sreden_uspeh")
                            prb1.Value = i + 1
                            Dim seriesInt, idRow As Integer
                            Dim seriesStr As String
                            If rbtnsubject.Checked = True Then
                                seriesInt = dt.Rows(i).Item("subject")
                                cmd = New MySqlCommand("Select* from subject where id='" & seriesInt & "'", cnn)
                                cmd.ExecuteNonQuery()
                                Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                                Dim dt2 As DataTable = New DataTable
                                adaptre2.Fill(dt2)
                                seriesStr = dt2.Rows(0).Item("name_subject")
                                For p As Integer = 0 To chlSubject.Items.Count - 1
                                    If chlSubject.Items(p) = seriesStr Then
                                        idRow = p
                                    End If
                                Next
                            Else
                                seriesInt = dt.Rows(i).Item("type")
                                cmd = New MySqlCommand("Select* from types where id='" & seriesInt & "'", cnn)
                                cmd.ExecuteNonQuery()
                                Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                                Dim dt2 As DataTable = New DataTable
                                adaptre2.Fill(dt2)
                                seriesStr = dt2.Rows(0).Item("name_type")
                                For p As Integer = 0 To chltype.Items.Count - 1
                                    If chltype.Items(p) = seriesStr Then
                                        idRow = p
                                    End If
                                Next
                            End If
                            sumcountAverage(0, idRow) = sumcountAverage(0, idRow) + max
                            sumcountAverage(1, idRow) = sumcountAverage(1, idRow) + 1
                            If i > 0 Then
                                If rbtnparal.Checked = True Then
                                    privateClass = dt.Rows(i - 1).Item("grade") & " " & dt.Rows(i - 1).Item("class")
                                ElseIf rbtnClass.Checked = True Then
                                    privateClass = dt.Rows(i - 1).Item("class")
                                Else
                                    privateClass = dt.Rows(i - 1).Item("profile")
                                    Call searchProfile(privateClass, privateClass)
                                End If
                                If privateClass <> class2 Then
                                    average = Math.Round(sumAverage / countAverage, 2)
                                    ws.Cells(br, sizeMerge) = average
                                    br = br + 1
                                    sumAverage = max
                                    countAverage = 1
                                Else
                                    sumAverage = sumAverage + max
                                    countAverage = countAverage + 1
                                End If
                            Else
                                sumAverage = sumAverage + max
                                countAverage = countAverage + 1
                            End If
                            colon = 1
                            Dim valueCells As String = ws.Cells(3, colon).value()
                            Do While seriesStr <> valueCells
                                colon = colon + 1
                                valueCells = ws.Cells(3, colon).value()
                            Loop
                            ws.Cells(br, 1) = class2
                            max = Math.Round(max, 2)
                            ws.Cells(br, colon) = max
                            ColName = ws.Cells(br, colon).Address
                            chartRange = ws.Range("A3:" & ColName)
                            chartPage.SetSourceData(Source:=chartRange)
                        Next

                        average = Math.Round(sumAverage / countAverage, 2)
                        ws.Cells(br, sizeMerge) = average
                        br = br + 1
                        ws.Cells(br, 1) = "Средно"
                        colon = 2
                        If rbtnsubject.Checked = True Then
                            For i As Integer = 1 To chlSubject.Items.Count - 1
                                If chlSubject.GetItemChecked(i) = True Then
                                    ws.Cells(br, colon) = Math.Round(sumcountAverage(0, i) / sumcountAverage(1, i), 2)
                                    colon = colon + 1
                                End If
                            Next
                        Else
                            For i As Integer = 1 To chltype.Items.Count - 1
                                If chltype.GetItemChecked(i) = True Then
                                    ws.Cells(br, colon) = Math.Round(sumcountAverage(0, i) / sumcountAverage(1, i), 2)
                                    colon = colon + 1
                                End If
                            Next
                        End If


                        Dim rng As Microsoft.Office.Interop.Excel.Range
                        ColName = ws.Cells(br, sizeMerge).Address
                        rng = ws.Range("A1:" & ColName)
                        Call cellborder(rng)
                        ws.Range(ws.Cells(1, 1), ws.Cells(br, sizeMerge)).HorizontalAlignment = xlCenter
                        chartRange = ws.Range("A3:" & ColName)
                        chartPage.SetSourceData(Source:=chartRange)
                        chartPage.HasLegend = True
                        chartPage.PlotBy = Microsoft.Office.Interop.Excel.XlRowCol.xlColumns
                        chartPage.HasTitle = True
                        chartPage.ChartTitle.Text = "Универсална справка"
                        'Смаляване на формата
                        ws.Copy(, masterWb.Sheets(masterWb.Sheets.Count))
                        ws = Nothing
                        xlWorkBook.Save()
                        xlWorkBook.Close()
                        xlWorkBook = Nothing
                        'Смаляване на формата
                        Me.Height = 419
                        masterWb.SaveAs(pat)
                        masterWb.Close()
                        masterWb = Nothing
                        xlapp.Quit()
                        xlapp = Nothing
                        'питане дали да се отвори файла 
                        Dim res As MsgBoxResult
                        prb1.Value = prb1.Maximum
                        res = MsgBox("Искате ли файлът да се отвори?", MsgBoxStyle.YesNo, "Универсална спавка")
                        If res = MsgBoxResult.Yes Then
                            Process.Start(pat)
                        End If
                    Else

                        MsgBox("По тези критерии няма оценки! ! !", , "Универсална спавка")
                        prb1.Value = 0
                        ws.Copy(, masterWb.Sheets(masterWb.Sheets.Count))
                        ws = Nothing
                        xlWorkBook.Save()
                        xlWorkBook.Close()
                        xlWorkBook = Nothing
                        'Смаляване на формата
                        masterWb.SaveAs(pat)
                        masterWb.Close()
                        masterWb = Nothing
                        xlapp.Quit()
                        xlapp = Nothing
                    End If
                End If
                cnn.Close()
            End If
        Else
            MsgBox("Трябва да се върнете и да веведете оценки ! ! !", , "Универсална спавка")
        End If
    End Sub

    Private Sub btnWordNewFIle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWordNewFIle.Click
        If cmbYear.Text <> "" Then
            Dim razWor As String
            razWor = ""
            'викане на функция RazWord в койято са записани разширенията на word
            'Call Module1.RazWord(razWor)
            razWor = "Word | *.docx"
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
                Call createText(title2)
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
                        Dim sizeMerge As Integer = 2
                        If rbtnsubject.Checked = True Then
                            sizeMerge = chlSubject.CheckedItems.Count + 1
                        Else
                            sizeMerge = chltype.CheckedItems.Count + 1
                        End If
                        oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, 1, sizeMerge)
                        prb1.Maximum = dt.Rows.Count
                        Dim otd As String
                        Dim br As Integer
                        Dim max As Double
                        otd = ""
                        br = 2
                        If rbtnparal.Checked = True Then
                            oTable.Cell(1, 1).Range.Text = "Клас"
                        ElseIf rbtnClass.Checked = True Then
                            oTable.Cell(1, 1).Range.Text = "Паралелка"
                        Else
                            oTable.Cell(1, 1).Range.Text = "Профил"
                        End If
                        Dim sumCountAverageSize, column As Integer
                        column = 2
                        If rbtnsubject.Checked = True Then
                            For p As Integer = 1 To chlSubject.Items.Count - 1
                                If chlSubject.GetItemChecked(p) = True Then
                                    oTable.Cell(1, column).Range.Text = chlSubject.Items(p)
                                    column = column + 1
                                End If
                            Next
                            sumCountAverageSize = chlSubject.Items.Count
                        Else
                            For p As Integer = 1 To chltype.Items.Count - 1
                                If chltype.GetItemChecked(p) = True Then
                                    oTable.Cell(1, column).Range.Text = chltype.Items(p)
                                    column = column + 1
                                End If
                            Next
                            sumCountAverageSize = chltype.Items.Count
                        End If
                        oTable.Cell(1, sizeMerge).Range.Text = "Средно"
                        Dim class2 As String
                        Dim sumAverage, countAverage, average, colon As Double
                        Dim sumcountAverage(2, sumCountAverageSize) As Double
                        br = 4
                        prb1.Value = 0
                        prb1.Maximum = dt.Rows.Count
                        Dim privateClass As String
                        sumAverage = 0
                        countAverage = 0
                        average = 0
                        oTable.Rows.Add()
                        For i As Integer = 0 To dt.Rows.Count - 1
                            If rbtnparal.Checked = True Then
                                class2 = dt.Rows(i).Item("grade") & " " & dt.Rows(i).Item("class")
                            ElseIf rbtnClass.Checked = True Then
                                class2 = dt.Rows(i).Item("class")
                            Else
                                class2 = dt.Rows(i).Item("profile")
                                Call searchProfile(class2, class2)
                            End If
                            max = dt.Rows(i).Item("sreden_uspeh")
                            Dim seriesInt, idRow As Integer
                            Dim seriesStr As String
                            If rbtnsubject.Checked = True Then
                                seriesInt = dt.Rows(i).Item("subject")
                                cmd = New MySqlCommand("Select* from subject where id='" & seriesInt & "'", cnn)
                                cmd.ExecuteNonQuery()
                                Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                                Dim dt2 As DataTable = New DataTable
                                adaptre2.Fill(dt2)
                                seriesStr = dt2.Rows(0).Item("name_subject")
                                For p As Integer = 0 To chlSubject.Items.Count - 1
                                    If chlSubject.Items(p) = seriesStr Then
                                        idRow = p
                                    End If
                                Next
                            Else
                                seriesInt = dt.Rows(i).Item("type")
                                cmd = New MySqlCommand("Select* from types where id='" & seriesInt & "'", cnn)
                                cmd.ExecuteNonQuery()
                                Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                                Dim dt2 As DataTable = New DataTable
                                adaptre2.Fill(dt2)
                                seriesStr = dt2.Rows(0).Item("name_type")
                                For p As Integer = 0 To chltype.Items.Count - 1
                                    If chltype.Items(p) = seriesStr Then
                                        idRow = p
                                    End If
                                Next
                            End If
                            seriesStr = seriesStr & vbCr & ChrW(7)
                            sumcountAverage(0, idRow) = sumcountAverage(0, idRow) + max
                            sumcountAverage(1, idRow) = sumcountAverage(1, idRow) + 1
                            If i > 0 Then
                                If rbtnparal.Checked = True Then
                                    privateClass = dt.Rows(i - 1).Item("grade") & " " & dt.Rows(i - 1).Item("class")
                                ElseIf rbtnClass.Checked = True Then
                                    privateClass = dt.Rows(i - 1).Item("class")
                                Else
                                    privateClass = dt.Rows(i - 1).Item("profile")
                                    Call searchProfile(privateClass, privateClass)
                                End If
                                If privateClass <> class2 Then
                                    average = Math.Round(sumAverage / countAverage, 2)
                                    oTable.Cell(br, sizeMerge).Range.Text = average
                                    br = br + 1
                                    oTable.Rows.Add()
                                    sumAverage = max
                                    countAverage = 1
                                Else
                                    sumAverage = sumAverage + max
                                    countAverage = countAverage + 1
                                End If
                            Else
                                sumAverage = sumAverage + max
                                countAverage = countAverage + 1
                            End If
                            colon = 0
                            Dim valueCells As String = oTable.Cell(1, colon).Range.Text '"Средно" & vbCr & ChrW(7)
                            Do While seriesStr <> valueCells
                                colon = colon + 1
                                valueCells = oTable.Cell(1, colon).Range.Text
                            Loop

                            oTable.Cell(br, 1).Range.Text = class2
                            max = Math.Round(max, 2)
                            oTable.Cell(br, colon).Range.Text = max
                            prb1.Value = prb1.Value + 1
                        Next
                        'форматиране на таблицата
                        oTable.Rows.Item(1).Range.Font.Bold = True
                        oTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle
                        oTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle

                        'смаляване на формата
                        Me.Height = 434
                        oDoc.SaveAs2(pat)
                        cnn.Close()
                        oDoc.Close()
                        prb1.Value = prb1.Maximum
                        'питане дали да се отвори файла
                        Dim res As MsgBoxResult
                        res = MsgBox("Искате ли файлът да се отвори?", MsgBoxStyle.YesNo, "Универсална спавка")
                        If res = MsgBoxResult.Yes Then
                            Process.Start(pat)
                        End If
                    Else
                        MsgBox("По тези критерии няма оценки! ! !", , "Универсална спавка")
                        oDoc.SaveAs2(pat)
                        cnn.Close()
                        oDoc.Close()
                        prb1.Value = 0
                    End If
                End If


            End If
        Else
            MsgBox("Трябва да се върнете и да веведете оценки ! ! !", , "Универсална спавка")
        End If
    End Sub


    Sub cellborder(ByVal rng As Microsoft.Office.Interop.Excel.Range)
        With rng.Borders
            .LineStyle = Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalUp
            .Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin
        End With
    End Sub

    Private Sub reference_universa_gpa_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Call clearCalss()
        Call clearParal()
        Call clearProfile()
        Call clearSubject()
        Call clearType()
        dgv1.Rows.Clear()
        cmbYear.Items.Clear()
        cmbYearString.Items.Clear()
        Me.Height = 520
    End Sub

    Private Sub chlSubject_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles chlSubject.ItemCheck
        If subjectflag = 0 Then
            subjectflag = 1
            If chlSubject.GetItemChecked(e.Index) = True Then
                chlSubject.SetItemChecked(e.Index, False)
            Else
                chlSubject.SetItemChecked(e.Index, True)
            End If
            Dim flag As Integer = 0
            If e.Index = 0 Then
                If e.NewValue = 0 Then
                    For i As Integer = 0 To chlSubject.Items.Count - 1
                        chlSubject.SetItemChecked(i, False)
                    Next
                    Exit Sub
                Else
                    For i As Integer = 0 To chlSubject.Items.Count - 1
                        chlSubject.SetItemChecked(i, True)
                    Next
                End If
            Else

                Dim flags As Integer = 1
                For i As Integer = 1 To chlSubject.Items.Count - 1
                    If chlSubject.GetItemChecked(i) = False Then
                        flags = 0
                        Exit For
                    End If
                Next
                chlSubject.SetItemChecked(0, flags)


            End If
            dgv1.Rows.Clear()
            cnn.Open()
            cmd = New MySqlCommand("Select* from  classes order by school_year desc, grade desc, class desc;", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            'Проверка дaли в таблица purpose има записи
            If data.Rows.Count > 0 Then
                Call create_dgv()
            End If
            cnn.Close()
            subjectflag = 0
        End If
    End Sub

    Private Sub chltype_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chltype.ItemCheck
        If typeflag = 0 Then
            typeflag = 1
            If chltype.GetItemChecked(e.Index) = True Then
                chltype.SetItemChecked(e.Index, False)
            Else
                chltype.SetItemChecked(e.Index, True)
            End If
            Dim flag As Integer = 0
            If e.Index = 0 Then
                If e.NewValue = 0 Then

                    For i As Integer = 0 To chltype.Items.Count - 1
                        chltype.SetItemChecked(i, False)
                    Next
                    Exit Sub
                Else
                    For i As Integer = 0 To chltype.Items.Count - 1
                        chltype.SetItemChecked(i, True)
                    Next
                End If
            Else

                Dim flags As Integer = 1
                For i As Integer = 1 To chltype.Items.Count - 1
                    If chltype.GetItemChecked(i) = False Then
                        flags = 0
                        Exit For
                    End If
                Next
                chltype.SetItemChecked(0, flags)


            End If
            dgv1.Rows.Clear()
            cnn.Open()
            cmd = New MySqlCommand("Select* from  classes order by school_year desc, grade desc, class desc;", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            'Проверка дaли в таблица purpose има записи
            If data.Rows.Count > 0 Then
                Call create_dgv()
            End If
            cnn.Close()
            typeflag = 0
        End If
    End Sub
    Function createText(ByRef text As String)
        text = ""
        If cmbYear.Text <> "" Then
            text = "Среден успех по паралелки за година: "
            text = text & cmbYearString.Text & ", клас: " & cmbClass.Text & ", паралелка: " & cmbParal.Text
            text = text & ", профил: " & cmbProfil.Text & ", предмет: "
            Dim words As String = "' and ("
            Dim adaptre1 As New MySqlDataAdapter
            Dim dt As New DataTable
            For i As Integer = 1 To chlSubject.Items.Count - 1
                If chlSubject.GetItemChecked(i) = True Then
                    text = text & chlSubject.Items(i) & ", "
                End If
            Next
            text = text & ", вид оценка: "
            For i As Integer = 1 To chltype.Items.Count - 1
                If chltype.GetItemChecked(i) = True Then
                    text = text & chltype.Items(i) & ", "
                End If
            Next
            text = text & ", съпоставяне на: "
            If rbtnsubject.Checked = True Then
                text = text & "предмет"
            Else
                text = text & "вид оценка"
            End If
            text = text & ", групиране по: "
            If rbtnparal.Checked = True Then
                text = text & "паралелка"
            ElseIf rbtnClass.Checked = True Then
                text = text & "клас"
            Else
                text = text & "профил"
            End If
        End If
        Return text
    End Function

    Private Sub btnchart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnchart.Click
        If cmbYear.Text <> "" Then
            'проверка за стойностите в диаграмата и тяхното изтриване
            Chart1.Series.Clear()
            Chart1.Titles.Clear()
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            Dim scom As String = ""
            Call createscmb(scom)

            cmd = New MySqlCommand(scom, cnn)
            If scom <> "" Then
                Call createText(title2)
                Chart1.Titles.Add(title1)
                Chart1.Titles.Add(title2)
                cmd.ExecuteNonQuery()
                Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt As DataTable = New DataTable
                adaptre1.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Dim class2, otd As String
                    Dim max As Double
                    otd = ""
                    'обхождане на редовете един по един и добавяне на изчислените стойности в диаграмата

                    ' Dim row As Integer = 0
                    Chart1.Series.Clear()
                    Chart1.Legends.Clear()

                    Chart1.ChartAreas.Item(0).AxisX.CustomLabels.Clear()
                    prb1.Maximum = dt.Rows.Count
                    Dim sizeRow As Integer
                    If rbtnsubject.Checked = True Then
                        For i As Integer = 1 To chlSubject.Items.Count - 1
                            If chlSubject.GetItemChecked(i) = True Then
                                Chart1.Series.Add(chlSubject.Items(i))
                                Chart1.Legends.Add(chlSubject.Items(i))
                            End If
                        Next
                        sizeRow = chlSubject.Items.Count
                    Else
                        For i As Integer = 1 To chltype.Items.Count - 1
                            If chltype.GetItemChecked(i) = True Then
                                Chart1.Series.Add(chltype.Items(i))
                                Chart1.Legends.Add(chltype.Items(i))
                            End If
                        Next
                        sizeRow = chltype.Items.Count
                    End If
                    Chart1.Series.Add("Средно")
                    Chart1.Legends.Add("Средно")
                    Dim rowMassive(sizeRow) As Integer
                    For i As Integer = 0 To sizeRow
                        rowMassive(i) = 1
                    Next
                    Dim seriesInt, idRow, row As Integer
                    Dim countAll(sizeRow), sumAll(sizeRow), sum, count, average As Double
                    For i As Integer = 0 To dt.Rows.Count - 1
                        If rbtnparal.Checked = True Then
                            class2 = dt.Rows(i).Item("grade") & " " & dt.Rows(i).Item("class")
                        ElseIf rbtnClass.Checked = True Then
                            class2 = dt.Rows(i).Item("class")
                        Else
                            class2 = dt.Rows(i).Item("profile")
                            Call searchProfile(class2, class2)
                        End If


                        If i > 0 Then
                            Dim chekerClass As String
                            If rbtnparal.Checked = True Then
                                chekerClass = dt.Rows(i - 1).Item("grade") & " " & dt.Rows(i).Item("class")
                            ElseIf rbtnClass.Checked = True Then
                                chekerClass = dt.Rows(i - 1).Item("class")
                            Else
                                chekerClass = dt.Rows(i - 1).Item("profile")
                                Call searchProfile(chekerClass, chekerClass)
                            End If

                            If class2 <> chekerClass Then
                                average = Format(Math.Round(sum / count, 2), "0.00")
                                sum = 0
                                count = 0
                                Chart1.Series("Средно").Points.AddXY(row, average)
                                row = row + 1
                                Chart1.ChartAreas.Item(0).AxisX.CustomLabels.Add(row - 0.5, row + 0.5, class2)

                                For j As Integer = 0 To sizeRow
                                    rowMassive(j) = row
                                Next
                            End If
                        Else
                            Chart1.ChartAreas.Item(0).AxisX.CustomLabels.Add(0.5, 1.5, class2)
                        End If
                        max = dt.Rows(i).Item("sreden_uspeh")
                        sum = sum + max
                        count = count + 1
                        prb1.Value = i + 1
                        Dim seriesStr As String

                        If rbtnsubject.Checked = True Then
                            seriesInt = dt.Rows(i).Item("subject")
                            cmd = New MySqlCommand("Select* from subject where id='" & seriesInt & "'", cnn)
                            cmd.ExecuteNonQuery()
                            Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                            Dim dt2 As DataTable = New DataTable
                            adaptre2.Fill(dt2)
                            seriesStr = dt2.Rows(0).Item("name_subject")
                            For p As Integer = 0 To chlSubject.Items.Count - 1
                                If chlSubject.Items(p) = seriesStr Then
                                    idRow = p
                                End If
                            Next
                        Else
                            seriesInt = dt.Rows(i).Item("type")
                            cmd = New MySqlCommand("Select* from types where id='" & seriesInt & "'", cnn)
                            cmd.ExecuteNonQuery()
                            Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                            Dim dt2 As DataTable = New DataTable
                            adaptre2.Fill(dt2)
                            seriesStr = dt2.Rows(0).Item("name_type")
                            For p As Integer = 0 To chltype.Items.Count - 1
                                If chltype.Items(p) = seriesStr Then
                                    idRow = p
                                End If
                            Next
                        End If
                        row = rowMassive(idRow)
                        countAll(idRow) = countAll(idRow) + 1
                        sumAll(idRow) = sumAll(idRow) + max
                        rowMassive(idRow) = rowMassive(idRow) + 1
                        max = Format(Math.Round(max, 2), "0.00")
                        Chart1.Series(seriesStr).Points.AddXY(row, max)
                    Next
                    average = Format(Math.Round(sum / count, 2), "0.00")
                    Chart1.Series("Средно").Points.AddXY(row, average)
                    row = row + 1
                    For j As Integer = 0 To sizeRow
                        rowMassive(j) = row
                    Next

                    'оголемяване на формата
                    Dim flag As Integer
                    Chart1.ChartAreas.Item(0).AxisX.CustomLabels.Add(row - 0.5, row + 0.5, "Средно")
                    Dim nameSeries As String = ""

                    For i As Integer = 1 To sizeRow - 1
                        flag = 0
                        If rbtnsubject.Checked = True Then
                            If chlSubject.GetItemChecked(i) = True Then
                                nameSeries = chlSubject.Items(i)
                                flag = 1
                            End If
                        Else
                            If chltype.GetItemChecked(i) = True Then
                                flag = 1
                                nameSeries = chltype.Items(i)
                            End If
                        End If
                        If flag = 1 Then
                            row = rowMassive(i)
                            countAll(i) = countAll(i) + 1
                            sumAll(i) = sumAll(i) + max
                            rowMassive(i) = rowMassive(i) + 1
                            max = Format(Math.Round(max, 2), "0.00")

                            average = Format(Math.Round(sumAll(i) / countAll(i), 2), "0.00")
                            Chart1.Series(nameSeries).Points.AddXY(row, average)
                        End If
                    Next
                    Chart1.Visible = True
                    '  Dim legendscount As Integer = Chart1.Legends.Count / 5 + 1


                    Me.Height = 720
                Else
                    MsgBox("По тези критерии няма оценки! ! !", , "Универсална спавка")
                    prb1.Value = 0
                End If


            Else
                MsgBox("По тези критерии няма оценки! ! !", , "Универсална спавка")
            End If
            cnn.Close()
        Else
            MsgBox("По тези критерии няма оценки! ! !", , "Универсална спавка")
        End If
    End Sub
    Function searchProfile(ByVal id As Integer, ByRef profilString As String)
        cmd = New MySqlCommand("Select* from profiles where id='" & id & "'", cnn)
        cmd.ExecuteNonQuery()
        Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
        Dim dt As DataTable = New DataTable
        adaptre1.Fill(dt)
        profilString = dt.Rows(0).Item("name_profile")
        Return profilString
    End Function


End Class
