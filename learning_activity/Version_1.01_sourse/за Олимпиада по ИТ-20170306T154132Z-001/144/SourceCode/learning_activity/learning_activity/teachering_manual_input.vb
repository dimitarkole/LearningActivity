Imports MySql.Data.MySqlClient
Public Class teachering_manual_input
    Dim cnn As New MySqlConnection
    Dim cmd As MySqlCommand
    Dim brRows, idup, index As Integer
    Private Sub teachering_manual_input_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim id As Integer
        Call Module1.hosts(cnn)
        cnn.Open()
        cmd = New MySqlCommand("Select* from teachers order by id", cnn)
        cmd.ExecuteNonQuery()
        Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
        Dim data As DataTable = New DataTable
        adaptre.Fill(data)
        Dim classes, classp, subject, tname, tfamily, horarium As String
        Dim nomer, year, classn As Integer
        If data.Rows.Count > 0 Then
            brRows = 0
            Do While brRows < data.Rows.Count
                tname = data.Rows(brRows).Item("name_teacher")
                tfamily = data.Rows(brRows).Item("family_teacher")
                cmbteacherUp.Items.Add(tname & " " & tfamily)
                CmbTR.Items.Add(tname & " " & tfamily)
                cmbTidR.Items.Add(data.Rows(brRows).Item("id"))
                cmbTeacherIdUp.Items.Add(data.Rows(brRows).Item("id"))
                brRows = brRows + 1
            Loop
            cmbteacherUp.Text = cmbteacherUp.Items(0)
        End If
        cmd = New MySqlCommand("Select* from subject order by id", cnn)
        cmd.ExecuteNonQuery()
        adaptre = New MySqlDataAdapter(cmd)
        data = New DataTable
        adaptre.Fill(data)
        If data.Rows.Count > 0 Then
            brRows = 0
            Do While brRows < data.Rows.Count
                subject = data.Rows(brRows).Item("name_subject")
                cmbsubjectUp.Items.Add(subject)
                cmbSubR.Items.Add(subject)
                cmbSubIdR.Items.Add(data.Rows(brRows).Item("id"))
                brRows = brRows + 1
            Loop
            cmbsubjectUp.Text = cmbsubjectUp.Items(0)
        End If
        cmd = New MySqlCommand("Select* from classes order by school_year desc, grade asc, class asc;", cnn)
        cmd.ExecuteNonQuery()
        adaptre = New MySqlDataAdapter(cmd)
        data = New DataTable
        adaptre.Fill(data)
        If data.Rows.Count > 0 Then
            brRows = 0
            Do While brRows < data.Rows.Count
                year = data.Rows(brRows).Item("school_year")
                classn = data.Rows(brRows).Item("grade")
                classp = data.Rows(brRows).Item("class")
                classes = year & "/" & year Mod 100 + 1 & " " & classn & " " & classp
                cmbClasseUp.Items.Add(classes)
                cmbCR.Items.Add(classes)
                cmbCIDR.Items.Add(data.Rows(brRows).Item("id"))
                cmbClassIdUp.Items.Add(data.Rows(brRows).Item("id"))
                brRows = brRows + 1
            Loop
            cmbClasseUp.Text = cmbClasseUp.Items(0)
            cmbClassIdUp.Text = cmbClassIdUp.Items(0)
        End If
        cmd = New MySqlCommand("Select* from  teaching order by id", cnn)
        cmd.ExecuteNonQuery()
        adaptre = New MySqlDataAdapter(cmd)
        data = New DataTable
        adaptre.Fill(data)
        If data.Rows.Count > 0 Then
            brRows = 0
            Do While brRows < data.Rows.Count
                id = data.Rows(brRows).Item("id")
                ' задаване на параметри за клас предмет
                nomer = data.Rows(brRows).Item("class")
                cmd = New MySqlCommand("Select* from  classes where id='" & nomer & "'", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt As DataTable = New DataTable
                adaptre1.Fill(dt)
                year = dt.Rows(0).Item("school_year")
                classn = dt.Rows(0).Item("grade")
                classp = dt.Rows(0).Item("class")
                classes = year & "/" & year Mod 100 + 1 & " " & classn & " " & classp
                ' задаване на име предмет
                nomer = data.Rows(brRows).Item("subject")
                cmd = New MySqlCommand("Select* from  subject where id='" & nomer & "'", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre5 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt3 As DataTable = New DataTable
                adaptre5.Fill(dt3)
                subject = dt3.Rows(0).Item("name_subject")
                ' задаване на име и фамилия на учителя
                nomer = data.Rows(brRows).Item("teacher")
                cmd = New MySqlCommand("Select* from teachers where id='" & nomer & "'", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt2 As DataTable = New DataTable
                adaptre2.Fill(dt2)
                tname = dt2.Rows(0).Item("name_teacher")
                tfamily = dt2.Rows(0).Item("family_teacher")
                horarium = data.Rows(brRows).Item("workload")
                dgv1.Rows.Add(id, classes, subject, tname & " " & tfamily, horarium)
                brRows = brRows + 1
            Loop
        End If
        Call Module1.idMax("teaching", idup)
        lblIdUp.Text = idup
        If dgv1.RowCount > 0 Then
            Dim selectrows As DataGridViewRow
            selectrows = dgv1.Rows(0)
            lblidDel.Text = selectrows.Cells(0).Value.ToString()
            lblClassDell.Text = selectrows.Cells(1).Value.ToString()
            lblSubjectDel.Text = selectrows.Cells(2).Value.ToString()
            lblTeachDel.Text = selectrows.Cells(3).Value.ToString()
            lblWorkWoadDEl.Text = selectrows.Cells(4).Value.ToString()

            lblidR.Text = selectrows.Cells(0).Value.ToString()
            cmbCR.Text = selectrows.Cells(1).Value.ToString()
            cmbSubR.Text = selectrows.Cells(2).Value.ToString()
            CmbTR.Text = selectrows.Cells(3).Value.ToString()
            cmbHR.Text = selectrows.Cells(4).Value.ToString()
        Else
            btnDel.Enabled = False
            btnR.Enabled = False
        End If
        'End If
    End Sub
    Private Sub teachering_manual_input_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'заноляване на cmb
        Do While cmbClasseUp.Items.Count > 0
            cmbClasseUp.Items.RemoveAt(0)
            cmbClassIdUp.Items.RemoveAt(0)
            cmbCR.Items.RemoveAt(0)
            cmbCIDR.Items.RemoveAt(0)
        Loop

        Do While cmbsubjectUp.Items.Count > 0
            cmbsubjectUp.Items.RemoveAt(0)
            cmbSubR.Items.RemoveAt(0)
        Loop
        Do While cmbteacherUp.Items.Count > 0
            cmbteacherUp.Items.RemoveAt(0)
            cmbTeacherIdUp.Items.RemoveAt(0)
            CmbTR.Items.RemoveAt(0)
            cmbTidR.Items.RemoveAt(0)
        Loop
        'изчистване на dgv
        idup = 0
        Do While idup < dgv1.Rows.Count
            dgv1.Rows.Remove(dgv1.Rows(0))
        Loop

    End Sub
    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        If cmbsubjectUp.Text <> "" Then
            If cmbClasseUp.Text <> "" Then
                If cmbTeacherIdUp.Text <> "'" Then
                    'проверка да ли е въведен предмета преди
                    Dim id, horar, clasid, br, subjectid, teacherid As Integer
                    Dim clastext, clasitem, subjecttext, teachitem, teachtext As String
                    id = lblIdUp.Text
                    horar = cmbworkload.Text
                    clastext = cmbClasseUp.Text
                    br = 0
                    clasitem = cmbClasseUp.Items(br)
                    Do While clasitem <> clastext
                        clasitem = cmbClasseUp.Items(br)
                        br = br + 1
                    Loop
                    If br = 0 Then
                        clasid = cmbClassIdUp.Items(br)
                    Else
                        clasid = cmbClassIdUp.Items(br - 1)
                    End If
                    cmbClassIdUp.Text = clasid
                    Call Module1.hosts(cnn)
                    subjecttext = cmbsubjectUp.Text
                    cnn.Open()

                    cmd = New MySqlCommand("Select * from subject where name_subject='" & subjecttext & "'", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt As DataTable = New DataTable
                    adaptre1.Fill(dt)
                    subjectid = dt.Rows(0).Item("id")
                    teachtext = cmbteacherUp.Items(0)
                    br = 0
                    teachitem = cmbteacherUp.Items(br)
                    Do While teachitem <> teachtext
                        teachitem = cmbteacherUp.Items(br)
                        br = br + 1
                    Loop
                    If br = 0 Then
                        teacherid = cmbTeacherIdUp.Items(br)
                    Else
                        teacherid = cmbTeacherIdUp.Items(br - 1)
                    End If
                    cmbTeacherIdUp.Text = teacherid

                    cmd = New MySqlCommand("Select* from  teaching where class='" & clasid & "' and subject='" & subjectid & "' and teacher='" & teacherid & "'", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim data As DataTable = New DataTable
                    adaptre.Fill(data)
                    If data.Rows.Count < 1 Then
                        idup = lblIdUp.Text
                        Dim cmd2 As MySqlCommand
                        cmd2 = New MySqlCommand("insert into teaching (id,class,subject,teacher,workload) values (@id,@class,@subject,@teacher,@workload);", cnn)
                        cmd2.Parameters.AddWithValue("@id", idup)
                        cmd2.Parameters.AddWithValue("@class", clasid)
                        cmd2.Parameters.AddWithValue("@subject", subjectid)
                        cmd2.Parameters.AddWithValue("@teacher", teacherid)
                        cmd2.Parameters.AddWithValue("@workload", horar)
                        cmd2.ExecuteNonQuery()
                        cnn.Close()
                        Call Module1.idMax("teaching", idup)
                        lblIdUp.Text = idup
                        dgv1.Rows.Add(id, clastext, subjecttext, teachtext, horar)
                        If dgv1.Rows.Count = 1 Then
                            lblidDel.Text = idup
                            lblClassDell.Text = clastext
                            lblSubjectDel.Text = subjecttext
                            lblTeachDel.Text = teachtext
                            lblWorkWoadDEl.Text = horar

                            lblidR.Text = idup
                            cmbCR.Text = clastext
                            cmbSubR.Text = subjecttext
                            CmbTR.Text = teachtext
                            cmbHR.Text = horar

                            btnR.Enabled = True
                            btnDel.Enabled = True
                        End If
                        ' cmbClasseUp.Text = cmbClasseUp.Items(0)
                        cmbsubjectUp.Text = cmbsubjectUp.Items(0)
                        cmbteacherUp.Text = cmbteacherUp.Items(0)
                        cmbworkload.Text = cmbworkload.Items(0)
                        'Съобщение за учител, който е въведен
                        MsgBox("Успeшно веведен преподавател на клас! ! !", , "Въвеждане, изтриване и редактиране на преподаватели на класовете")


                    Else
                        MsgBox("Този клас по този предмет си има преподавател! ! !", , "Въвеждане, изтриване и редактиране на преподаватели на класовете")
                    End If
                Else
                    MsgBox("Трябва да се върнете и да въведете учител! ! !", , "Въвеждане, изтриване и редактиране на преподаватели на класовете")
                End If
            Else
                MsgBox("Трябва да се върнете и да въведете клас! ! !", , "Въвеждане, изтриване и редактиране на преподаватели на класовете")
            End If
        Else
            MsgBox("Трябва да се върнете и да въведете предмет! ! !", , "Въвеждане, изтриване и редактиране на преподаватели на класовете")
        End If
    End Sub
    Private Sub dgv1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellClick
        If e.RowIndex <> -1 Then
            index = e.RowIndex

            Dim selectrows As DataGridViewRow
            selectrows = dgv1.Rows(index)
            lblidDel.Text = selectrows.Cells(0).Value.ToString()
            lblClassDell.Text = selectrows.Cells(1).Value.ToString()
            lblSubjectDel.Text = selectrows.Cells(2).Value.ToString()
            lblTeachDel.Text = selectrows.Cells(3).Value.ToString()
            lblWorkWoadDEl.Text = selectrows.Cells(4).Value.ToString()

            lblidR.Text = selectrows.Cells(0).Value.ToString()
            cmbCR.Text = selectrows.Cells(1).Value.ToString()
            cmbSubR.Text = selectrows.Cells(2).Value.ToString()
            CmbTR.Text = selectrows.Cells(3).Value.ToString()
            cmbHR.Text = selectrows.Cells(4).Value.ToString()
        End If
    End Sub
    Private Sub lblidDel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblidDel.TextChanged
        If lblidDel.Text <> "" Then
            btnDel.Enabled = True
            btnR.Enabled = True
        Else
            btnDel.Enabled = False
            btnR.Enabled = False
        End If
    End Sub
    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        Try
            If MsgBox("Сигурни ли сте, че искате да го изтриите?", vbYesNo, "Въвеждане, изтриване и редактиранe на преподаватели на класовете") = vbYes Then
                Dim id As Integer
                id = lblidDel.Text
                'махане на предмета от базата
                Try
                    cnn.Open()
                    cnn.Close()
                Catch ex As Exception
                    MsgBox("Грешка в базата данни! ! !")
                    Application.Exit()
                End Try
                cnn.Open()
                Dim index2 As Integer
                cmd = New MySqlCommand("Delete from teaching  where id='" & id & "'", cnn)
                cmd.ExecuteNonQuery()
                MsgBox("Успешно изтрит преподавател на клас! ! !", , "Въвеждане, изтриване и редактиране на преподаватели на класовете")
                cnn.Close()
                'проверка за MAX ID
                Call Module1.idMax("teaching", id)
                lblIdUp.Text = id

                dgv1.Rows.Remove(dgv1.Rows(index))

                If dgv1.Rows.Count = 0 Then
                    lblidDel.Text = ""
                    lblSubjectDel.Text = ""
                    lblClassDell.Text = ""
                    lblTeachDel.Text = ""
                    lblWorkWoadDEl.Text = ""

                    lblidR.Text = ""
                    cmbCR.Text = ""
                    cmbSubR.Text = ""
                    CmbTR.Text = ""
                    cmbHR.Text = ""
                Else

                    If dgv1.Rows.Count = 1 Then
                        index2 = 0
                    ElseIf index = dgv1.Rows.Count Then
                        index2 = dgv1.Rows.Count - 1
                    Else
                        index2 = index
                    End If
                    Dim selectrows As DataGridViewRow
                    selectrows = dgv1.Rows(index2)
                    lblidDel.Text = selectrows.Cells(0).Value.ToString()
                    lblSubjectDel.Text = selectrows.Cells(1).Value.ToString()
                    lblClassDell.Text = selectrows.Cells(2).Value.ToString()
                    lblTeachDel.Text = selectrows.Cells(3).Value.ToString()
                    lblWorkWoadDEl.Text = selectrows.Cells(4).Value.ToString()

                    lblidR.Text = selectrows.Cells(0).Value.ToString()
                    cmbCR.Text = selectrows.Cells(1).Value.ToString()
                    cmbSubR.Text = selectrows.Cells(2).Value.ToString()
                    CmbTR.Text = selectrows.Cells(3).Value.ToString()
                    cmbHR.Text = selectrows.Cells(4).Value.ToString()
                End If
                index = index2
            End If
        Catch ex As Exception
            MsgBox("ERROR - " & ex.Message)
        End Try
    End Sub
    Private Sub cmbClasseUp_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClasseUp.Leave, cmbClasseUp.DropDownClosed
        If cmbClasseUp.Items.Count > 0 Then
            If (cmbClasseUp.SelectedIndex = -1) Then
                cmbClasseUp.Text = cmbClasseUp.Items(0)
                cmbClasseUp.Focus()
            End If
        Else
            cmbClasseUp.Text = ""
        End If

    End Sub
    Private Sub cmbsubjectUp_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsubjectUp.Leave, cmbsubjectUp.DropDownClosed
        If cmbsubjectUp.Items.Count > 0 Then
            If (cmbsubjectUp.SelectedIndex = -1) Then
                cmbsubjectUp.Text = cmbsubjectUp.Items(0)
                cmbsubjectUp.Focus()
            End If
        Else
            cmbsubjectUp.Text = ""
        End If

    End Sub
    Private Sub cmbteacherUp_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbteacherUp.Leave, cmbteacherUp.DropDownClosed
        If cmbTeacherIdUp.Items.Count > 0 Then
            If (cmbteacherUp.SelectedIndex = -1) Then
                cmbteacherUp.Text = cmbteacherUp.Items(0)
                cmbteacherUp.Focus()
            End If
        Else
            cmbteacherUp.Text = ""
        End If
    End Sub
    Private Sub cmbworkload_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbworkload.Leave, cmbworkload.DropDownClosed
        If (cmbworkload.SelectedIndex = -1) Then
            cmbworkload.Text = cmbworkload.Items(0)
            cmbworkload.Focus()
        Else
            cmbworkload.Text = ""
        End If
    End Sub
    Private Sub cmbCR_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCR.Leave, cmbCR.DropDownClosed
        If cmbCR.Items.Count > 0 Then
            If (cmbCR.SelectedIndex = -1) Then
                cmbCR.Text = cmbCR.Items(0)
                cmbCR.Focus()
            End If
        Else
            cmbCR.Text = ""
        End If
    End Sub
    Private Sub cmbSubR_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubR.Leave, cmbSubR.DropDownClosed
        If cmbSubR.Items.Count > 0 Then
            If (cmbSubR.SelectedIndex = -1) Then
                cmbSubR.Text = cmbSubR.Items(0)
                cmbSubR.Focus()
            End If
        Else
            cmbSubR.Text = ""
        End If
    End Sub
    Private Sub CmbTR_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTR.Leave, CmbTR.DropDownClosed
        If CmbTR.Items.Count > 0 Then
            If (CmbTR.SelectedIndex = -1) Then
                CmbTR.Text = CmbTR.Items(0)
                CmbTR.Focus()
            End If
        Else
            CmbTR.Text = ""
        End If
    End Sub
    Private Sub cmbHR_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbHR.Leave, cmbHR.DropDownClosed
        If (cmbHR.SelectedIndex = -1) Then
            cmbHR.Text = cmbHR.Items(0)
            cmbHR.Focus()
        End If
    End Sub
    Private Sub cmbR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnR.Click
        If cmbSubR.Text <> "" And cmbCR.Text <> "" And CmbTR.Text <> "" Then
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            cmbTidR.Text = cmbTidR.Items(CmbTR.SelectedIndex)
            cmbCIDR.Text = cmbCIDR.Items(cmbCR.SelectedIndex)
            Dim id, sid, t, h As Integer
            Dim c, s As String
            id = lblidR.Text
            c = cmbCIDR.Text
            s = cmbSubR.Text
            cmd = New MySqlCommand("Select * from subject where name_subject='" & s & "'", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable
            adaptre1.Fill(dt)
            sid = dt.Rows(0).Item("id")
            t = cmbTidR.Text
            h = cmbHR.Text
            cmd = New MySqlCommand("Select* from  teaching where class='" & c & "' and subject='" & s & "' and teacher='" & t & "' and workload='" & h & "' and id<>'" & id & "'", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            If data.Rows.Count < 1 Then
                cmd = New MySqlCommand("UPDATE teaching SET class='" & c & "',subject='" & sid & "',teacher='" & t & "',workload='" & h & "' WHERE teaching.id='" & id & "';", cnn)
                cmd.ExecuteNonQuery()

                Dim selectrows1 As DataGridViewRow
                selectrows1 = dgv1.Rows(index)
                selectrows1.Cells(1).Value = cmbCR.Text
                selectrows1.Cells(2).Value = cmbSubR.Text
                selectrows1.Cells(3).Value = CmbTR.Text
                selectrows1.Cells(4).Value = h
                MsgBox("Успешно редактиран преподавател на клас! ! !", , "Въвеждане, изтриване и редактиране на преподаватели на класовете")
                cnn.Close()
            Else
                MsgBox("Този клас по този предмет си има преподавател! ! !", , "Въвеждане, изтриване и редактиране на преподаватели на класовете")
            End If
        Else
            MsgBox("Трябва да се въведете преподавател на класовете! ! !", , "Въвеждане, изтриване и редактиране на преподаватели на класовете")
        End If
    End Sub
End Class