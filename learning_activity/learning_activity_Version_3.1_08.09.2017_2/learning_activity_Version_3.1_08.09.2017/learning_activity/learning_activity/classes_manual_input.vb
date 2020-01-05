Imports MySql.Data.MySqlClient
Public Class classes_manual_input
    Dim cnn As New MySqlConnection
    Dim cmd As MySqlCommand
    Dim brRows, idUp As Integer
    Dim yearstr As String
    Dim index As Integer
    Private Sub classes_manual_input_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Module1.idMax("classes", idUp)
        lblIdUp.Text = idUp

        If idUp > 0 Then
            brRows = 0
            Dim id As Integer
            Call Module1.hosts(cnn)
            cnn.Open()
            cmd = New MySqlCommand("Select* from  classes order by id", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            cnn.Close()
            If data.Rows.Count > 0 Then
                Do While brRows < data.Rows.Count

                    Dim year, grade, a, student As Integer
                    Dim yearstr, classes, profile As String
                    'вкарване на ред в с информация dgv1
                    id = data.Rows(brRows).Item("id")
                    year = data.Rows(brRows).Item("school_year")
                    grade = data.Rows(brRows).Item("grade")
                    classes = data.Rows(brRows).Item("class")
                    student = data.Rows(brRows).Item("students")
                    a = data.Rows(brRows).Item("profile")
                    cnn.Open()
                    cmd = New MySqlCommand("Select* from  profiles where id='" & a & "'", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre5 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt3 As DataTable = New DataTable
                    adaptre5.Fill(dt3)
                    cnn.Close()
                    profile = dt3.Rows(0).Item("name_profile")

                    yearstr = year & "/" & year Mod 100 + 1

                    dgv1.Rows.Add(id, yearstr, grade, classes, profile, student)
                    brRows = brRows + 1
                Loop
            End If
        End If


        Dim reader As MySqlDataReader
        cnn.Open()
        cmd = New MySqlCommand("Select * from profiles order by id", cnn)
        cmd.ExecuteNonQuery()
        reader = cmd.ExecuteReader
        Dim sname As String
        sname = ""
        While reader.Read
            sname = reader.GetString("name_profile")
            cmbprofileUp.Items.Add(sname)
            cmbPR.Items.Add(sname)
        End While
        cnn.Close()

        If sname <> "" Then
            cmbprofileUp.Text = cmbprofileUp.Items(0)
            cmbPR.Text = cmbPR.Items(0)
        Else
            cmbprofileUp.Text = ""
            cmbPR.Text = ""
        End If

        If dgv1.Rows.Count > 0 Then
            Dim selectrows As DataGridViewRow
            selectrows = dgv1.Rows(0)
            lblIdDel.Text = selectrows.Cells(0).Value.ToString()
            lblYearDel.Text = selectrows.Cells(1).Value.ToString()
            lblbGradeDel.Text = selectrows.Cells(2).Value.ToString()
            lblClassesDel.Text = selectrows.Cells(3).Value.ToString()
            lblProfilDel.Text = selectrows.Cells(4).Value.ToString()
            lblstudentDel.Text = selectrows.Cells(5).Value.ToString()

            lblidR.Text = selectrows.Cells(0).Value.ToString()
            cmbYR.Text = selectrows.Cells(1).Value.ToString()
            cmbClassR.Text = selectrows.Cells(2).Value.ToString()
            cmbParalR.Text = selectrows.Cells(3).Value.ToString()
            cmbPR.Text = selectrows.Cells(4).Value.ToString()
            cmbSR.Text = selectrows.Cells(5).Value.ToString()
        End If
    End Sub
    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click

        Dim classes, profil As String
        Dim year, grade, student, profilinte As Integer
        'Взимане на стойности от полетата
        year = 2010
        grade = cmbGradeUp.Text
        classes = cmbClassUp.Text
        student = cmbStudentsUp.Text
        yearstr = year & "/" & year Mod 100 + 1
        Do While yearstr <> cmbyearUp.Text
            year = year + 1
            yearstr = year & "/" & year Mod 100 + 1

        Loop

        ' намиране на избра профилиращ предмет
        profil = cmbprofileUp.Text
        Try
            cnn.Open()
            cnn.Close()
        Catch ex As Exception
            MsgBox("Грешка в базата данни! ! !")
            Application.Exit()
        End Try
        If profil <> "" Then
            cnn.Open()
            cmd = New MySqlCommand("Select* from  profiles where name_profile='" & profil & "'", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable
            adaptre1.Fill(dt)
            profilinte = dt.Rows(0).Item("id")

            ' Проверка за ввече въведен клас с тези характеристики
            cmd = New MySqlCommand("Select* from classes where school_year='" & year & "'and grade='" & grade & _
                                   "'and class='" & classes & "'", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre5 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre5.Fill(data)
            If data.Rows.Count < 1 Then
                Dim y As FirstWeekOfYear
                y = year
                'Въвеждане на предмета
                cmd = New MySqlCommand("insert into  classes (id,school_year,grade,class,profile,students) values (@id,@school_year,@grade,@class,@profile,@students);", cnn)
                cmd.Parameters.AddWithValue("@id", idUp)
                cmd.Parameters.AddWithValue("@school_year", year)
                cmd.Parameters.AddWithValue("@grade", grade)
                cmd.Parameters.AddWithValue("@class", classes)
                cmd.Parameters.AddWithValue("@profile", profilinte)
                cmd.Parameters.AddWithValue("@students", student)
                cmd.ExecuteNonQuery()
                'презарейдане на таблицата
                yearstr = year & "/" & year Mod 100 + 1
                dgv1.Rows.Add(idUp, yearstr, grade, classes, profil, student)

                'Номериране на следващ запис
                idUp = idUp + 1
                lblIdUp.Text = idUp

                If dgv1.Rows.Count = 1 Then
                    lblIdDel.Text = idUp
                    lblYearDel.Text = yearstr
                    lblbGradeDel.Text = grade
                    lblClassesDel.Text = classes
                    lblProfilDel.Text = profil
                    lblstudentDel.Text = student

                    lblidR.Text = idUp
                    cmbYR.Text = yearstr
                    cmbClassR.Text = grade
                    cmbParalR.Text = classes
                    cmbPR.Text = profil
                    cmbSR.Text = student
                End If

                cmbClassUp.Text = cmbClassUp.Items(0)
                cmbGradeUp.Text = cmbGradeUp.Items(0)
                cmbprofileUp.Text = cmbprofileUp.Items(0)
                cmbStudentsUp.Text = 20
                cmbyearUp.Text = cmbyearUp.Items(0)

                'Съобщение за успешно въведе предмет
                MsgBox("Успешно въведен клас! ! !", , "Въвеждане, изтриване и редактиране на класове")

            Else
                'Съобщение за клас, който е въведен
                MsgBox("Този клас вече е въведен! ! !", , "Въвеждане, изтриване и редактиране на класове")
            End If
            cnn.Close()
        Else
            MsgBox("Трябав да се върнете и да въведете профил! ! !", , "Въвеждане, изтриване и редактиране на класове")
        End If
    End Sub
    Private Sub btndeletesubject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndeletesubject.Click
        Try
            If MsgBox("Сигурни ли сте, че искате да го изтриите?", vbYesNo, "Въвеждане, изтриване и редактиране на класове") = vbYes Then
                Dim id As Integer
                id = lblIdDel.Text
                Try
                    cnn.Open()
                    cnn.Close()
                Catch ex As Exception
                    MsgBox("Грешка в базата данни! ! !")
                    Application.Exit()
                End Try
                'махане на  класа от базата
                cnn.Open()
                Dim index2 As Integer
                cmd = New MySqlCommand("Delete from  classes where id='" & id & "'", cnn)
                cmd.ExecuteNonQuery()
                MsgBox("Успешно изтрит клас! ! !", , "Въвеждане, изтриване и редактиране на класове")
                cnn.Close()
                'проверка за MAX ID
                Call Module1.idMax("classes", idUp)
                lblIdUp.Text = idUp

                dgv1.Rows.Remove(dgv1.Rows(index))

                If dgv1.Rows.Count = 0 Then
                    lblIdDel.Text = ""
                    lblYearDel.Text = ""
                    lblbGradeDel.Text = ""
                    lblClassesDel.Text = ""
                    lblProfilDel.Text = ""
                    lblstudentDel.Text = ""
                ElseIf dgv1.Rows.Count = 1 Then
                    index2 = 0
                ElseIf index = dgv1.Rows.Count Then
                    index2 = dgv1.Rows.Count - 1
                Else
                    index2 = index
                    Dim selectrows As DataGridViewRow
                    selectrows = dgv1.Rows(index2)
                    lblIdDel.Text = selectrows.Cells(0).Value.ToString()
                    lblYearDel.Text = selectrows.Cells(1).Value.ToString()
                    lblbGradeDel.Text = selectrows.Cells(2).Value.ToString()
                    lblClassesDel.Text = selectrows.Cells(3).Value.ToString()
                    lblProfilDel.Text = selectrows.Cells(4).Value.ToString()
                    lblstudentDel.Text = selectrows.Cells(5).Value.ToString()

                    lblidR.Text = selectrows.Cells(0).Value.ToString()
                    cmbYR.Text = selectrows.Cells(1).Value.ToString()
                    cmbClassR.Text = selectrows.Cells(2).Value.ToString()
                    cmbParalR.Text = selectrows.Cells(3).Value.ToString()
                    cmbPR.Text = selectrows.Cells(4).Value.ToString()
                    cmbSR.Text = selectrows.Cells(5).Value.ToString()
                End If
                index = index2
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub dgv1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellClick
        If e.RowIndex <> -1 Then
            index = e.RowIndex

            Dim selectrows As DataGridViewRow
            selectrows = dgv1.Rows(index)
            lblIdDel.Text = selectrows.Cells(0).Value.ToString()
            lblYearDel.Text = selectrows.Cells(1).Value.ToString()
            lblbGradeDel.Text = selectrows.Cells(2).Value.ToString()
            lblClassesDel.Text = selectrows.Cells(3).Value.ToString()
            lblProfilDel.Text = selectrows.Cells(4).Value.ToString()
            lblstudentDel.Text = selectrows.Cells(5).Value.ToString()

            lblidR.Text = selectrows.Cells(0).Value.ToString()
            cmbYR.Text = selectrows.Cells(1).Value.ToString()
            cmbClassR.Text = selectrows.Cells(2).Value.ToString()
            cmbParalR.Text = selectrows.Cells(3).Value.ToString()
            cmbPR.Text = selectrows.Cells(4).Value.ToString()
            cmbSR.Text = selectrows.Cells(5).Value.ToString()
        End If
    End Sub
    Private Sub lblIdDel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblIdDel.TextChanged
        If lblIdDel.Text <> "" Then
            btndeletesubject.Enabled = True
        Else
            btndeletesubject.Enabled = False
        End If
    End Sub
    Private Sub classes_manual_input_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        idUp = 0

        Do While idUp < dgv1.Rows.Count
            dgv1.Rows.Remove(dgv1.Rows(0))
        Loop

        Do While cmbprofileUp.Items.Count > 0
            cmbprofileUp.Items.RemoveAt(0)
            cmbPR.Items.RemoveAt(0)
        Loop

    End Sub
    Private Sub btnRedakchia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRedakchia.Click
        Dim id, y, c, profil, students As Integer
        Dim paralelka As String
        If cmbPR.Text <> "" Then
            id = lblidR.Text
            c = cmbClassR.Text
            paralelka = cmbParalR.Text
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            cmd = New MySqlCommand("Select* from  profiles where name_profile='" & cmbPR.Text & "'", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable
            adaptre1.Fill(dt)
            profil = dt.Rows(0).Item("id")
            students = cmbSR.Text

            y = 2010
            yearstr = y & "/" & y Mod 100 + 1
            Do While yearstr <> cmbYR.Text
                y = y + 1
                yearstr = y & "/" & y Mod 100 + 1
            Loop
            ' Проверка за ввече въведен клас с тези характеристики
            cmd = New MySqlCommand("Select* from classes where school_year='" & y & "'and grade='" & paralelka & _
                                   "'and class='" & c & "' and id<>'" & id & "'", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre5 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre5.Fill(data)
            If data.Rows.Count < 1 Then
                'Реадактиране на Класа
                cmd = New MySqlCommand("UPDATE classes SET school_year='" & y & "',grade='" & c & "',class='" & paralelka & "',profile='" & profil & "',students='" & students & "' WHERE classes.id='" & id & "';", cnn)
                cmd.ExecuteNonQuery()
                Dim selectrows1 As DataGridViewRow
                selectrows1 = dgv1.Rows(index)
                selectrows1.Cells(1).Value = yearstr
                selectrows1.Cells(2).Value = c
                selectrows1.Cells(3).Value = paralelka
                selectrows1.Cells(4).Value = cmbPR.Text
                selectrows1.Cells(5).Value = students
                MsgBox("Успешно редактиран клас! ! !", , "Въвеждане, изтриване и редактиране на клас")

            Else

                'Съобщение за клас, който е въведен
                MsgBox("Този клас вече е въведен! ! !", , "Въвеждане, изтриване и редактиране на класове")
            End If
            cnn.Close()
        Else
            MsgBox("Първо добавете клас! ! !", , "Въвеждане, изтриване и редактиране на клас")
        End If
    End Sub
    Private Sub cmbYR_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYR.Leave, cmbYR.DropDownClosed
        If cmbYR.SelectedIndex = -1 Then
            cmbYR.Text = lblYearDel.Text
            cmbYR.Focus()
        End If
    End Sub
    Private Sub cmbyearUp_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbyearUp.Leave, cmbyearUp.DropDownClosed
        If cmbyearUp.SelectedIndex = -1 Then
            cmbyearUp.Text = cmbyearUp.Items(0)
            cmbyearUp.Focus()
        End If
    End Sub
    Private Sub cmbGradeUp_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGradeUp.Leave, cmbGradeUp.DropDownClosed
        If cmbGradeUp.SelectedIndex = -1 Then
            cmbGradeUp.Text = cmbGradeUp.Items(0)
            cmbGradeUp.Focus()
        End If
    End Sub
    Private Sub cmbClassUp_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClassUp.Leave, cmbClassUp.DropDownClosed
        If cmbClassUp.SelectedIndex = -1 Then
            cmbClassUp.Text = cmbClassUp.Items(0)
            cmbClassUp.Focus()
        End If
    End Sub
    Private Sub cmbprofileUp_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbprofileUp.Leave, cmbprofileUp.DropDownClosed
        If cmbprofileUp.SelectedIndex = -1 Then
            cmbprofileUp.Text = cmbprofileUp.Items(0)
            cmbprofileUp.Focus()
        End If
    End Sub
    Private Sub cmbStudentsUp_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStudentsUp.Leave, cmbStudentsUp.DropDownClosed
        If cmbStudentsUp.SelectedIndex = -1 Then
            cmbStudentsUp.Text = cmbStudentsUp.Items(0)
            cmbStudentsUp.Focus()
        End If
    End Sub
    Private Sub cmbClassR_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClassR.Leave, cmbClassR.DropDownClosed
        If cmbClassR.SelectedIndex = -1 Then
            cmbClassR.Text = lblbGradeDel.Text
            cmbClassR.Focus()
        End If
    End Sub
    Private Sub cmbParalR_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbParalR.Leave, cmbParalR.DropDownStyleChanged
        If cmbParalR.SelectedIndex = -1 Then
            cmbParalR.Text = lblClassesDel.Text()
            cmbParalR.Focus()
        End If
    End Sub
    Private Sub cmbPR_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPR.Leave, cmbPR.DropDownStyleChanged
        If cmbPR.SelectedIndex = -1 Then
            cmbPR.Text = lblProfilDel.Text
            cmbPR.Focus()
        End If
    End Sub
    Private Sub cmbSR_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSR.Leave, cmbSR.DropDownStyleChanged
        If cmbSR.SelectedIndex = -1 Then
            cmbSR.Text = lblstudentDel.Text
            cmbSR.Focus()
        End If
    End Sub
    Private Sub ComboBox5_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYearFrom.Leave, cmbYearFrom.DropDownClosed
        If cmbYearFrom.SelectedIndex = -1 Then
            cmbYearFrom.Text = cmbYearFrom.Items(0)
            cmbYearFrom.Focus()
        Else
            cmbYearFrom.Text = cmbYearFrom.Items(cmbYearFrom.SelectedIndex)
            For i As Integer = 2010 To 2042
                If i & "/" & i Mod 100 + 1 = cmbYearFrom.Text Then
                    lblYearTo.Text = i + 1 & "/" & i Mod 100 + 2
                    Exit For
                End If
            Next
        End If
    End Sub
    Private Sub cmbClassFrom_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClassFrom.Leave, cmbClassFrom.DropDownClosed
        If cmbClassFrom.SelectedIndex = -1 Then
            cmbClassFrom.Text = cmbClassFrom.Items(0)
            cmbClassFrom.Focus()
        End If
    End Sub
    Private Sub cmbClassTo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClassTo.Leave
        If cmbClassTo.SelectedIndex = -1 Then
            cmbClassTo.Text = cmbClassTo.Items(0)
            cmbClassTo.Focus()
        End If
    End Sub

    Private Sub btnPremin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPremin.Click
        Dim year, classfrom, classto As Integer
        For i As Integer = 2010 To 2042
            If i & "/" & i Mod 100 + 1 = cmbYearFrom.Text Then
                year = i
                Exit For
            End If
        Next
        classfrom = cmbClassFrom.Text
        classto = cmbClassTo.Text
        If classfrom > classto Then
            MsgBox("Началният клас не може да е по-малък от крайния! ! !", , "Въвеждане, изтриване и редактиране на класове")
        Else
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()

            cmd = New MySqlCommand("Select* from  classes where school_year='" & year & "'", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable
            adaptre1.Fill(dt)
            If dt.Rows.Count > 0 Then
                year = year + 1
                Dim classint, profil, student As Integer
                Dim paral As String
                For i As Integer = 0 To dt.Rows.Count - 1
                    classint = dt.Rows(i).Item("grade")
                    profil = dt.Rows(i).Item("profile")
                    student = dt.Rows(i).Item("students")
                    paral = dt.Rows(i).Item("class")
                    If classint >= classfrom And classint <= classto Then
                        ' Проверка за ввече въведен клас с тези характеристики
                        classint = classint + 1
                        cmd = New MySqlCommand("Select* from classes where school_year='" & year & "'and grade='" & classint &
                                               "'and class='" & paral & "'", cnn)
                        cmd.ExecuteNonQuery()
                        Dim adaptre5 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                        Dim data As DataTable = New DataTable
                        adaptre5.Fill(data)
                        If data.Rows.Count < 1 Then
                            cmd = New MySqlCommand("insert into  classes (school_year,grade,class,profile,students) values (@school_year,@grade,@class,@profile,@students);", cnn)
                            cmd.Parameters.AddWithValue("@school_year", year)
                            cmd.Parameters.AddWithValue("@grade", classint)
                            cmd.Parameters.AddWithValue("@class", paral)
                            cmd.Parameters.AddWithValue("@profile", profil)
                            cmd.Parameters.AddWithValue("@students", student)
                            cmd.ExecuteNonQuery()
                            lblIdUp.Text = lblIdUp.Text + 1

                            cmd = New MySqlCommand("Select* from profiles where id='" & profil & "'", cnn)
                            cmd.ExecuteNonQuery()
                            adaptre5 = New MySqlDataAdapter(cmd)
                            Dim dat As DataTable = New DataTable
                            adaptre5.Fill(dat)
                            Dim profilname As String
                            profilname = dat.Rows(0).Item("name_profile")
                            dgv1.Rows.Add(lblIdUp.Text, year & "/" & year Mod 100 + 1, classint, paral, profilname, student)
                        Else
                            Dim student2 As Integer
                            Dim profile2 As String
                            student2 = data.Rows(0).Item("students")
                            profile2 = data.Rows(0).Item("profile")

                            If student <> student2 Or profil <> profile2 Then
                                Dim msgstr As String
                                msgstr = "Класът " & classint & " " & paral & " за годината " & year & "/" & year Mod 100 + 1 & " е бил въведен с профил " & profile2
                                msgstr = msgstr & " и брой ученици " & student2 & " ! ! ! " & vbNewLine
                                msgstr = msgstr & "Искатели да се презапише този клас?"
                                If MsgBox(msgstr, MsgBoxStyle.OkCancel, "Въвеждане, изтриване и редактиране на класове") = MsgBoxResult.Ok Then

                                    Dim id As Integer
                                    id = data.Rows(0).Item("id")
                                    'Реадактиране на Класа
                                    cmd = New MySqlCommand("UPDATE classes SET profile='" & profile2 & "',students='" & student2 & "' WHERE classes.id='" & id & "';", cnn)
                                    cmd.ExecuteNonQuery()
                                    Dim selectrows1 As DataGridViewRow
                                    Dim id2 As Integer
                                    For a As Integer = 0 To dgv1.Rows.Count
                                        selectrows1 = dgv1.Rows(a)
                                        id2 = selectrows1.Cells(0).Value
                                        If id = id2 Then
                                            index = a
                                            Exit For
                                        End If
                                    Next

                                    selectrows1 = dgv1.Rows(index)
                                    selectrows1.Cells(4).Value = profile2
                                    selectrows1.Cells(5).Value = student2
                                    MsgBox("Успешно редактиран клас! ! !", , "Въвеждане, изтриване и редактиране на клас")


                                End If
                            End If
                        End If

                    End If
                Next
                MsgBox("Класовете от въведената година преминаха към новата година коркно! ! ! ", , "Въвеждане, изтриване и редактиране на класове")
            Else
                MsgBox("Няма класове за въведената година! ! ! ", , "Въвеждане, изтриване и редактиране на класове")
            End If
            cnn.Close()
        End If

    End Sub
End Class