Imports MySql.Data.MySqlClient
Public Class purpose_manual_input
    Dim cnn As MySqlConnection
    Dim cmd As MySqlCommand
    Dim brRows, idup, index As Integer
    Private Sub evaluation_manual_input_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Module1.hosts(cnn)
        cnn.Open()
        cmd = New MySqlCommand("Select* from  purpose order by id", cnn)
        cmd.ExecuteNonQuery()
        Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
        Dim data As DataTable = New DataTable
        adaptre.Fill(data)
        cnn.Close()
        Dim id As Integer
        brRows = 0
        If data.Rows.Count > 0 Then
            Do While brRows < data.Rows.Count
                id = data.Rows(brRows).Item("id")
                Dim classes, classp, subject, type, count_2, count_3, count_4, count_5, count_6 As String
                Dim nomer, year, classn As Integer

                ' задаване на клас
                nomer = data.Rows(brRows).Item("class")
                cnn.Open()
                cmd = New MySqlCommand("Select* from  classes where id='" & nomer & "'", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt As DataTable = New DataTable
                adaptre1.Fill(dt)
                cnn.Close()
                year = dt.Rows(0).Item("school_year")
                classn = dt.Rows(0).Item("grade")
                classp = dt.Rows(0).Item("class")
                classes = year & "/" & year Mod 100 + 1 & " " & classn & " " & classp

                ' задаване на subject
                nomer = data.Rows(brRows).Item("subject")
                cnn.Open()
                cmd = New MySqlCommand("Select* from  subject where id='" & nomer & "'", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre5 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt3 As DataTable = New DataTable
                adaptre5.Fill(dt3)

                cnn.Close()
                subject = dt3.Rows(0).Item("name_subject")

                'задаване на types
                nomer = data.Rows(brRows).Item("type")
                cnn.Open()
                cmd = New MySqlCommand("Select* from  types where id='" & nomer & "'", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt2 As DataTable = New DataTable
                adaptre2.Fill(dt2)
                cnn.Close()
                type = dt2.Rows(0).Item("name_type")
                'задаване на бройя на двойки, тройки, четворки, петици, шестици
                count_2 = data.Rows(brRows).Item("count_2")
                count_3 = data.Rows(brRows).Item("count_3")
                count_4 = data.Rows(brRows).Item("count_4")
                count_5 = data.Rows(brRows).Item("count_5")
                count_6 = data.Rows(brRows).Item("count_6")

                'писане в dgv1
                dgv1.Rows.Add(id, classes, subject, type, count_2, count_3, count_4, count_5, count_6)
                brRows = brRows + 1
            Loop
        End If
        ' въвеждане на предмет в cmbsubject
        Dim reader As MySqlDataReader
        cnn.Open()
        cmd = New MySqlCommand("Select * from subject order by name_subject asc", cnn)
        cmd.ExecuteNonQuery()
        reader = cmd.ExecuteReader
        Dim sname As String
        sname = ""
        While reader.Read
            sname = reader.GetString("name_subject")
            cmbSubject.Items.Add(sname)
            cmbSR.Items.Add(sname)
            cmbSidR.Items.Add(reader.GetString("id"))
        End While
        cnn.Close()
        If sname <> "" Then
            cmbSubject.Text = cmbSubject.Items(0)
        Else
            cmbSubject.Text = ""
        End If
        ' въвеждане на клас в cmbClasses
        Dim reader1 As MySqlDataReader
        cnn.Open()
        cmd = New MySqlCommand("Select * from classes  order by school_year desc, grade asc, class asc", cnn)
        cmd.ExecuteNonQuery()
        reader1 = cmd.ExecuteReader
        Dim clas, grade, wclass, classID, year2 As String
        wclass = ""
        While reader1.Read
            year2 = reader1.GetString("school_year")
            clas = reader1.GetString("grade")
            grade = reader1.GetString("class")
            wclass = year2 & "/" & year2 Mod 100 + 1 & " " & clas & " " & grade
            cmbClass.Items.Add(wclass)
            cmbCR.Items.Add(wclass)
            classID = reader1.GetString("id")
            cmbClassId.Items.Add(classID)
            cmbCidR.Items.Add(classID)
        End While
        cnn.Close()

        If wclass <> "" Then
            cmbClass.Text = cmbClass.Items(0)
        Else
            cmbClass.Text = ""
        End If


        ' въвеждане на вид в cmbType
        Dim reader2 As MySqlDataReader
        cnn.Open()
        cmd = New MySqlCommand("Select * from types order by id", cnn)
        cmd.ExecuteNonQuery()
        reader2 = cmd.ExecuteReader
        Dim types As String
        types = ""
        While reader2.Read
            types = reader2.GetString("name_type")
            cmbTypes.Items.Add(types)
            cmbTR.Items.Add(types)
            cmbTidR.Items.Add(reader2.GetString("id"))
        End While
        cnn.Close()
        If types <> "" Then
            cmbTypes.Text = cmbTypes.Items(0)
        Else
            cmbTypes.Text = ""
        End If

        Call idMax("purpose", id)

        lblIdUp.Text = id

        If dgv1.Rows.Count > 0 Then
            Dim selectrows As DataGridViewRow
            selectrows = dgv1.Rows(0)

            lblIdDel.Text = selectrows.Cells(0).Value.ToString()
            lblClasDel.Text = selectrows.Cells(1).Value.ToString()
            lblSubjectDel.Text = selectrows.Cells(2).Value.ToString()
            lblTypeDel.Text = selectrows.Cells(3).Value.ToString()
            lblc2.Text = selectrows.Cells(4).Value.ToString()
            lblc3.Text = selectrows.Cells(5).Value.ToString()
            lblc4.Text = selectrows.Cells(6).Value.ToString()
            lblc5.Text = selectrows.Cells(7).Value.ToString()
            lblc6.Text = selectrows.Cells(8).Value.ToString()

            lblidR.Text = selectrows.Cells(0).Value.ToString()
            cmbCR.Text = selectrows.Cells(1).Value.ToString()
            cmbSR.Text = selectrows.Cells(2).Value.ToString()
            cmbTR.Text = selectrows.Cells(3).Value.ToString()
            cmb2R.Text = selectrows.Cells(4).Value.ToString()
            cmb3R.Text = selectrows.Cells(5).Value.ToString()
            cmb4R.Text = selectrows.Cells(6).Value.ToString()
            cmb5R.Text = selectrows.Cells(7).Value.ToString()
            cmb6R.Text = selectrows.Cells(8).Value.ToString()

            cmbTidR.Text = cmbTidR.Items(cmbTR.SelectedIndex)
            cmbSidR.Text = cmbSidR.Items(cmbSR.SelectedIndex)
            cmbCidR.Text = cmbCidR.Items(cmbCR.SelectedIndex)
        Else
            btndel.Enabled = False
        End If

    End Sub
    Private Sub evaluation_manual_input_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        dgv1.Rows.Clear()
        cmbCR.Items.Clear()
        cmbCidR.Items.Clear()
        cmbSR.Items.Clear()
        cmbSidR.Items.Clear()
        cmbTR.Items.Clear()
        cmbTidR.Items.Clear()
        Do While cmbSubject.Items.Count > 0
            cmbSubject.Items.RemoveAt(0)
        Loop

        Do While cmbClass.Items.Count > 0
            cmbClass.Items.RemoveAt(0)
            cmbClassId.Items.RemoveAt(0)
        Loop

        Do While cmbTypes.Items.Count > 0
            cmbTypes.Items.RemoveAt(0)
        Loop

    End Sub
    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Dim classest, classirtem, subjecttext, typeText As String
        Dim classid, subjectID, typeId, c2, c3, c4, c5, c6, studensid As Integer
        'Взимане на стойности от полетата
        idup = lblIdUp.Text

        classest = cmbClass.Text
        brRows = 0

        classirtem = cmbClass.Items(brRows)
        Do While classest <> classirtem
            brRows = brRows + 1
            classirtem = cmbClass.Items(brRows)
        Loop
        classid = cmbClassId.Items(brRows)
        cnn.Open()
        cmd = New MySqlCommand("Select* from  classes where id='" & classid & "'", cnn)
        cmd.ExecuteNonQuery()
        Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
        Dim dt As DataTable = New DataTable
        adaptre.Fill(dt)
        studensid = dt.Rows(0).Item("students")
        subjecttext = cmbSubject.Text
        cmd = New MySqlCommand("Select* from  subject where name_subject='" & subjecttext & "'", cnn)
        cmd.ExecuteNonQuery()
        Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
        Dim dt2 As DataTable = New DataTable
        adaptre2.Fill(dt2)
        subjectID = dt2.Rows(0).Item("id")
        typeText = cmbTypes.Text

        cmd = New MySqlCommand("Select* from  types where name_type='" & typeText & "'", cnn)
        cmd.ExecuteNonQuery()
        Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
        Dim dt1 As DataTable = New DataTable
        adaptre1.Fill(dt1)
        cnn.Close()
        typeId = dt1.Rows(0).Item("id")
        c2 = cmbC2.Text
        c3 = cmbC3.Text
        c4 = cmbC4.Text
        c5 = cmbC5.Text
        c6 = cmbC6.Text
        If classest <> "" Then
            If subjecttext <> "" Then
                If typeText <> "" Then
                    Dim c23456 As Integer
                    c23456 = c2 + c3 + c4 + c5 + c6
                    If c23456 <= studensid Then
                        cnn.Open()
                        cmd = New MySqlCommand("Select* from  purpose where class='" & classid & "'and subject='" & subjectID & "'and type='" & typeId & "'", cnn)
                        cmd.ExecuteNonQuery()
                        Dim adaptre5 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                        Dim dt5 As DataTable = New DataTable
                        adaptre5.Fill(dt5)
                        cnn.Close()

                        If dt5.Rows.Count < 1 Then
                            cnn.Open()
                            'Въвеждане на предмета
                            cmd = New MySqlCommand("insert into purpose (id,class,subject,type,count_2,count_3,count_4,count_5,count_6) values (@id,@class,@subject,@type,@count_2,@count_3,@count_4,@count_5,@count_6);", cnn)
                            cmd.Parameters.AddWithValue("@id", idup)
                            cmd.Parameters.AddWithValue("@class", classid)
                            cmd.Parameters.AddWithValue("@subject", subjectID)
                            cmd.Parameters.AddWithValue("@type", typeId)
                            cmd.Parameters.AddWithValue("@count_2", c2)
                            cmd.Parameters.AddWithValue("@count_3", c3)
                            cmd.Parameters.AddWithValue("@count_4", c4)
                            cmd.Parameters.AddWithValue("@count_5", c5)
                            cmd.Parameters.AddWithValue("@count_6", c6)

                            cmd.ExecuteNonQuery()
                            cnn.Close()
                            'писане в dgv1
                            dgv1.Rows.Add(idup, classest, subjecttext, typeText, c2, c3, c4, c5, c6)

                            idup = idup + 1
                            lblIdUp.Text = idup
                            'Съобщение за успешно въведени оценки
                            MsgBox("Успешно въведени оценки! ! !", , "Въвеждане, изтриване и редактиране на оценки")

                            If dgv1.Rows.Count = 1 Then
                                Dim selectrows As DataGridViewRow
                                selectrows = dgv1.Rows(0)

                                lblIdDel.Text = selectrows.Cells(0).Value.ToString()
                                lblClasDel.Text = selectrows.Cells(1).Value.ToString()
                                lblSubjectDel.Text = selectrows.Cells(2).Value.ToString()
                                lblTypeDel.Text = selectrows.Cells(3).Value.ToString()
                                lblc2.Text = selectrows.Cells(4).Value.ToString()
                                lblc3.Text = selectrows.Cells(5).Value.ToString()
                                lblc4.Text = selectrows.Cells(6).Value.ToString()
                                lblc5.Text = selectrows.Cells(7).Value.ToString()
                                lblc6.Text = selectrows.Cells(8).Value.ToString()

                                lblidR.Text = lblIdDel.Text
                                cmbCR.Text = lblClasDel.Text
                                cmbSR.Text = lblSubjectDel.Text
                                cmbTR.Text = lblTypeDel.Text
                                cmb2R.Text = lblc2.Text
                                cmb3R.Text = lblc3.Text
                                cmb4R.Text = lblc4.Text
                                cmb5R.Text = lblc5.Text
                                cmb6R.Text = lblc6.Text
                            End If

                            cmbC2.Text = cmbC2.Items(0)
                            cmbC3.Text = cmbC3.Items(0)
                            cmbC4.Text = cmbC4.Items(0)
                            cmbC5.Text = cmbC5.Items(0)
                            cmbC6.Text = cmbC6.Items(0)

                            cmbTypes.Text = cmbTypes.Items(0)
                            cmbSubject.Text = cmbSubject.Items(0)
                            ' cmbClass.Text = cmbClass.Items(0)
                        Else
                            MsgBox("Тези оценки на този клас по този предмет от този вид  са въведени преди! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                        End If
                    Else
                        MsgBox("Оценките са повече от учениците! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                    End If

                Else
                    MsgBox("Трябва да се върнете и да въведете видове оценки! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                End If
            Else
                MsgBox("Трябва да се върнете и да въведете предмет! ! !", , "Въвеждане, изтриване и редактиране на оценки")
            End If
        Else
            MsgBox("Трябва да се върнете и да въведете клас! ! !", , "Въвеждане, изтриване и редактиране на оценки")
        End If
    End Sub
    Private Sub dgv1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellClick
        If e.RowIndex <> -1 Then
            index = e.RowIndex
            If dgv1.Rows.Count > 0 Then
                Dim selectrows As DataGridViewRow
                selectrows = dgv1.Rows(index)
                lblIdDel.Text = selectrows.Cells(0).Value.ToString()
                lblClasDel.Text = selectrows.Cells(1).Value.ToString()
                lblSubjectDel.Text = selectrows.Cells(2).Value.ToString()
                lblTypeDel.Text = selectrows.Cells(3).Value.ToString()
                lblc2.Text = selectrows.Cells(4).Value.ToString()
                lblc3.Text = selectrows.Cells(5).Value.ToString()
                lblc4.Text = selectrows.Cells(6).Value.ToString()
                lblc5.Text = selectrows.Cells(7).Value.ToString()
                lblc6.Text = selectrows.Cells(8).Value.ToString()

                lblidR.Text = selectrows.Cells(0).Value.ToString()
                cmbCR.Text = selectrows.Cells(1).Value.ToString()
                cmbSR.Text = selectrows.Cells(2).Value.ToString()
                cmbTR.Text = selectrows.Cells(3).Value.ToString()
                cmb2R.Text = selectrows.Cells(4).Value.ToString()
                cmb3R.Text = selectrows.Cells(5).Value.ToString()
                cmb4R.Text = selectrows.Cells(6).Value.ToString()
                cmb5R.Text = selectrows.Cells(7).Value.ToString()
                cmb6R.Text = selectrows.Cells(8).Value.ToString()

                cmbTidR.Text = cmbTidR.Items(cmbTR.SelectedIndex)
                cmbSidR.Text = cmbSidR.Items(cmbSR.SelectedIndex)
                cmbCidR.Text = cmbCidR.Items(cmbCR.SelectedIndex)
            Else
                btndel.Enabled = False
            End If
        End If
    End Sub
    Private Sub btndel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndel.Click
        Try
            If MsgBox("Сигурни ли сте, че искате да го изтриите?", vbYesNo, "Въвеждане, изтриване и редактиране на оценки") = vbYes Then
                Dim id As Integer
                id = lblIdDel.Text
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
                cmd = New MySqlCommand("Delete from  purpose where id='" & id & "'", cnn)
                cmd.ExecuteNonQuery()
                MsgBox("Успешно изтрити оценки на клас! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                cnn.Close()
                'проверка за MAX ID
                Call Module1.idMax("purpose", id)
                lblIdUp.Text = id


                dgv1.Rows.Remove(dgv1.Rows(index))
                If dgv1.Rows.Count = 0 Then
                    lblIdDel.Text = ""
                    lblClasDel.Text = ""
                    lblSubjectDel.Text = ""
                    lblTypeDel.Text = ""
                    lblc2.Text = ""
                    lblc3.Text = ""
                    lblc4.Text = ""
                    lblc5.Text = ""
                    lblc6.Text = ""

                    lblidR.Text = ""
                    cmbCR.Text = ""
                    cmbSR.Text = ""
                    cmb2R.Text = ""
                    cmb3R.Text = ""
                    cmb4R.Text = ""
                    cmb5R.Text = ""
                    cmb6R.Text = ""
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
                    lblIdDel.Text = selectrows.Cells(0).Value.ToString()

                    lblClasDel.Text = selectrows.Cells(1).Value.ToString()
                    lblSubjectDel.Text = selectrows.Cells(2).Value.ToString()
                    lblTypeDel.Text = selectrows.Cells(3).Value.ToString()
                    lblc2.Text = selectrows.Cells(4).Value.ToString()
                    lblc3.Text = selectrows.Cells(5).Value.ToString()
                    lblc4.Text = selectrows.Cells(6).Value.ToString()
                    lblc5.Text = selectrows.Cells(7).Value.ToString()
                    lblc6.Text = selectrows.Cells(8).Value.ToString()

                    lblidR.Text = selectrows.Cells(0).Value.ToString()
                    cmbCR.Text = selectrows.Cells(1).Value.ToString()
                    cmbSR.Text = selectrows.Cells(2).Value.ToString()
                    cmbTR.Text = selectrows.Cells(3).Value.ToString()
                    cmb2R.Text = selectrows.Cells(4).Value.ToString()
                    cmb3R.Text = selectrows.Cells(5).Value.ToString()
                    cmb4R.Text = selectrows.Cells(6).Value.ToString()
                    cmb5R.Text = selectrows.Cells(7).Value.ToString()
                    cmb6R.Text = selectrows.Cells(8).Value.ToString()
                End If
                index = index2
            End If
        Catch ex As Exception
            MsgBox("ERROR - " & ex.Message)
        End Try


    End Sub
    Private Sub cmbClass_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClass.Leave, cmbClass.DropDownClosed
        If (cmbClass.SelectedIndex = -1) Then
            If cmbClass.Items.Count > 0 Then
                cmbClass.Text = cmbClass.Items(0)
                cmbClass.Focus()
            Else
                cmbClass.Text = ""
            End If

        End If
    End Sub
    Private Sub cmbSubject_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubject.Leave, cmbSubject.DropDownClosed
        If (cmbSubject.SelectedIndex = -1) Then
            If cmbSubject.Items.Count > 0 Then
                cmbSubject.Text = cmbSubject.Items(0)
                cmbSubject.Focus()
            Else
                cmbSubject.Text = ""
            End If
        End If
    End Sub
    Private Sub cmbTypes_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTypes.Leave, cmbTypes.DropDownClosed
        If (cmbTypes.SelectedIndex = -1) Then
            If cmbTypes.Items.Count > 0 Then
                cmbTypes.Text = cmbTypes.Items(0)
                cmbTypes.Focus()
            Else
                cmbTypes.Text = ""
            End If
        End If
    End Sub
    Private Sub cmbC2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbC2.Leave, cmbC2.DropDownClosed
        If (cmbC2.SelectedIndex = -1) Then
            cmbC2.Text = cmbC2.Items(0)
            cmbC2.Focus()
        End If
    End Sub
    Private Sub cmbC3_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbC3.Leave, cmbC3.DropDownClosed
        If (cmbC3.SelectedIndex = -1) Then
            cmbC3.Text = cmbC3.Items(0)
            cmbC3.Focus()
        End If
    End Sub
    Private Sub cmbC4_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbC4.Leave, cmbC4.DropDownClosed
        If (cmbC4.SelectedIndex = -1) Then
            cmbC4.Text = cmbC4.Items(0)
            cmbC4.Focus()
        End If
    End Sub
    Private Sub cmbC5_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbC5.Leave, cmbC5.DropDownClosed
        If (cmbC5.SelectedIndex = -1) Then
            cmbC5.Text = cmbC5.Items(0)
            cmbC5.Focus()
        End If
    End Sub
    Private Sub cmbC6_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbC6.Leave, cmbC6.DropDownClosed
        If (cmbC6.SelectedIndex = -1) Then
            cmbC6.Text = cmbC6.Items(0)
            cmbC6.Focus()
        End If
    End Sub
    Private Sub lblIdDel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblIdDel.TextChanged
        If lblIdDel.Text <> "" Then
            btndel.Enabled = True
            btnR.Enabled = True
        Else
            btnR.Enabled = False
            btndel.Enabled = False
        End If
    End Sub

    Private Sub btnR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnR.Click
        If cmbCR.Text <> "" Then
            Dim id, c, s, t, d, tr, ch, p, sh As Integer
            id = lblidR.Text
            c = cmbCidR.Text
            s = cmbSidR.Text
            t = cmbTidR.Text
            d = cmb2R.Text
            tr = cmb3R.Text
            ch = cmb4R.Text
            p = cmb5R.Text
            sh = cmb6R.Text

            'Реадактиране на учителя
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()


            cmd = New MySqlCommand("Select* from  purpose where class='" & c & "'and subject='" & s & "'and type='" & t & "' and id<>'" & id & "'", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre5 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim dt5 As DataTable = New DataTable
            adaptre5.Fill(dt5)
            cnn.Close()

            If dt5.Rows.Count < 1 Then
                cnn.Open()
                cmd = New MySqlCommand("UPDATE purpose SET class='" & c & "',subject='" & s & "',type='" & t & "',count_2='" & d & "',count_3='" & tr & "',count_4='" & ch & "',count_5='" & p _
                                       & "',count_6='" & sh & "' WHERE purpose.id='" & id & "';", cnn)
                cmd.ExecuteNonQuery()
                cnn.Close()
                'Съобщение за успешно въведе предмет
                MsgBox("Успешно редактирани оценки! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                Dim selectrows1 As DataGridViewRow
                selectrows1 = dgv1.Rows(index)
                selectrows1.Cells(1).Value = cmbCR.Text
                selectrows1.Cells(2).Value = cmbSR.Text
                selectrows1.Cells(3).Value = cmbTR.Text
                selectrows1.Cells(4).Value = d
                selectrows1.Cells(5).Value = tr
                selectrows1.Cells(6).Value = ch
                selectrows1.Cells(7).Value = p
                selectrows1.Cells(8).Value = sh
            Else
                MsgBox("Тези оценки на този клас по този предмет от този вид  са въведени преди! ! !", , "Въвеждане, изтриване и редактиране на оценки")
            End If
        Else
            MsgBox("Първо трябва да добавите оценки! ! !", , "Въвеждане, изтриване и редактиране на оценки")
        End If
    End Sub

    Private Sub cmbCR_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCR.Leave, cmbCR.DropDownClosed
        If cmbCR.Items.Count > 0 Then
            If (cmbClass.SelectedIndex = -1) Then
                cmbCR.Text = cmbCR.Items(0)
                cmbCR.Focus()
            Else
                cmbCidR.Text = cmbCidR.Items(cmbCR.SelectedIndex)
            End If
        Else
            cmbCR.Text = ""
        End If

    End Sub

    Private Sub cmbSR_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSR.Leave, cmbSR.DropDownClosed
        If cmbSR.Items.Count > 0 Then
            If (cmbSR.SelectedIndex = -1) Then
                cmbSR.Text = cmbSR.Items(0)
                cmbSR.Focus()
            Else
                cmbSidR.Text = cmbSidR.Items(cmbSR.SelectedIndex)
            End If
        Else
            cmbSR.Text = ""
        End If
    End Sub

    Private Sub cmbTR_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTR.Leave, cmbTR.DropDownClosed
        If cmbTR.Items.Count > 0 Then
            If (cmbTR.SelectedIndex = -1) Then
                cmbTR.Text = cmbTR.Items(0)
                cmbTR.Focus()
            Else
                cmbTidR.Text = cmbTidR.Items(cmbTR.SelectedIndex)
            End If
        Else
            cmbTR.Text = ""
        End If

    End Sub


    Private Sub cmb2R_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb2R.Leave, cmb2R.DropDownClosed
        If (cmb2R.SelectedIndex = -1) Then
            cmb2R.Text = cmb2R.Items(0)
            cmb2R.Focus()
        End If
    End Sub

    Private Sub cmb3R_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb3R.Leave, cmb3R.DropDownClosed
        If (cmb3R.SelectedIndex = -1) Then
            cmb3R.Text = cmb3R.Items(0)
            cmb3R.Focus()
        End If
    End Sub

    Private Sub cmb4R_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb4R.Leave, cmb4R.DropDownClosed
        If (cmb4R.SelectedIndex = -1) Then
            cmb4R.Text = cmb4R.Items(0)
            cmb4R.Focus()
        End If
    End Sub

    Private Sub cmb5R_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb5R.Leave, cmb5R.DropDownClosed
        If (cmb5R.SelectedIndex = -1) Then
            cmb5R.Text = cmb5R.Items(0)
            cmb5R.Focus()
        End If
    End Sub

    Private Sub cmb6R_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb6R.Leave, cmb6R.DropDownClosed
        If (cmb6R.SelectedIndex = -1) Then
            cmb6R.Text = cmb6R.Items(0)
            cmb6R.Focus()
        End If
    End Sub
End Class