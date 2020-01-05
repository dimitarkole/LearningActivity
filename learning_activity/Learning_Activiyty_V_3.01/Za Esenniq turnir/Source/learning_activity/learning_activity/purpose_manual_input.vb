Imports MySql.Data.MySqlClient
Public Class purpose_manual_input
    Dim cnn As MySqlConnection
    Dim cmd As MySqlCommand
    Dim xlapp As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
    Dim appXL As Microsoft.Office.Interop.Excel.Application
    Dim wbXL As Microsoft.Office.Interop.Excel.Workbook
    Dim wbsXL As Microsoft.Office.Interop.Excel.Workbooks
    Dim shXL As Microsoft.Office.Interop.Excel.Worksheet
    Dim misvalue As Object = System.Reflection.Missing.Value
    Dim pass As String = ""
    Dim row As Integer = 1
    Dim brRows, idup, index As Integer
    Private Sub evaluation_manual_input_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pass = "LearActExcelFileDTK"
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
        cmd = New MySqlCommand("Select * from subject order by number", cnn)
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

        Try
            cnn.Open()
            cnn.Close()
        Catch ex As Exception
            MsgBox("Грешка в базата данни! ! !", , "Въвеждане, изтриване и редактиране на оценки")
            Application.Exit()
        End Try
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
                    MsgBox("Грешка в базата данни! ! !", , "Въвеждане, изтриване и редактиране на оценки")
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
            ' MsgBox("ERROR - " & ex.Message)
        End Try


    End Sub
    Private Sub cmbClass_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClass.Leave, cmbClass.DropDownClosed
        If (cmbClass.SelectedIndex = -1) Then
            cmbClass.Text = cmbClass.Items(0)
            cmbClass.Focus()
        End If
    End Sub
    Private Sub cmbSubject_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubject.Leave, cmbSubject.DropDownClosed
        If (cmbSubject.SelectedIndex = -1) Then
            cmbSubject.Text = cmbSubject.Items(0)
            cmbSubject.Focus()
        End If
    End Sub
    Private Sub cmbTypes_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTypes.Leave, cmbTypes.DropDownClosed
        If (cmbTypes.SelectedIndex = -1) Then
            cmbTypes.Text = cmbTypes.Items(0)
            cmbTypes.Focus()
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
                MsgBox("Грешка в базата данни! ! !", , "Въвеждане, изтриване и редактиране на оценки")
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
                cnn.Close()
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
        If (cmbClass.SelectedIndex = -1) Then
            cmbCR.Text = cmbCR.Items(0)
            cmbCR.Focus()
        Else
            cmbCidR.Text = cmbCidR.Items(cmbCR.SelectedIndex)
        End If
    End Sub

    Private Sub cmbSR_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSR.Leave, cmbSR.DropDownClosed
        If (cmbSR.SelectedIndex = -1) Then
            cmbSR.Text = cmbSR.Items(0)
            cmbSR.Focus()
        Else
            cmbSidR.Text = cmbSidR.Items(cmbSR.SelectedIndex)
        End If
    End Sub

    Private Sub cmbTR_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTR.Leave, cmbTR.DropDownClosed
        If (cmbTR.SelectedIndex = -1) Then
            cmbTR.Text = cmbTR.Items(0)
            cmbTR.Focus()
        Else
            cmbTidR.Text = cmbTidR.Items(cmbTR.SelectedIndex)
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

    Private Sub btnCreateExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateExcel.Click
        SaveFileDialog1.Filter = "Excel | *.xltx"
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            Dim pat As String = SaveFileDialog1.FileName
            appXL = New Microsoft.Office.Interop.Excel.Application
            wbsXL = appXL.Workbooks
            wbXL = xlapp.Workbooks.Add(misvalue)
            shXL = wbXL.ActiveSheet
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                Application.Exit()
            End Try
            cnn.Open()
            Call createExcelFile()
            shXL.SaveAs(pat, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLTemplate)
            wbXL.Close()
            xlapp.Quit()
            cnn.Close()
            releaseObject(xlapp)
            releaseObject(wbXL)
            releaseObject(shXL)
            shXL = Nothing
            Dim res As MsgBoxResult
            res = MsgBox("Искате ли файлът да се отвори?", MsgBoxStyle.YesNo, "Въвеждане, изтриване и редактиране на оценки")
            If res = MsgBoxResult.Yes Then
                Process.Start(pat)
            End If
        End If
    End Sub
    Sub createExcelFile()
        lblStatus.Text = "Добавяне на данни"
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = 10
        Const xlCenter = -4108
        shXL.Range(shXL.Cells(1, 1), shXL.Cells(1, 9)).Merge()
        Dim i As Integer = 1
        shXL.Cells(i, 1) = "Доклад"
        shXL.Range(shXL.Cells(1, 1), shXL.Cells(1, 2)).HorizontalAlignment = xlCenter
        Dim rng As Microsoft.Office.Interop.Excel.Range
        rng = shXL.Range("A1:I1")
        Call cellborder(rng)
        i = i + 2
        shXL.Cells(i, 2) = "Клас"
        shXL.Cells(i, 3) = "1"
        rng = shXL.Range("C" & i)
        ProgressBar1.Value = 1
        With rng.Validation
            .Delete()
            .Add(Type:=Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, AlertStyle:=Microsoft.Office.Interop.Excel.XlDVAlertStyle.xlValidAlertStop,
            Formula1:="1;2;3;4;5;6;7;8;9;10;11;12")
            .IgnoreBlank = True
            .InCellDropdown = True
            .InputTitle = ""
            .ErrorTitle = ""
            .InputMessage = ""
            .ErrorMessage = ""
            .ShowInput = True
            .ShowError = True
        End With
        rng = shXL.Range("D" & i)
        rng.Locked = False
        shXL.Cells(i, 4) = "а"
        ProgressBar1.Value = 2
        With rng.Validation
            .Delete()
            .Add(Type:=Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, AlertStyle:=Microsoft.Office.Interop.Excel.XlDVAlertStyle.xlValidAlertStop,
            Formula1:="а;б;в;г;д;е;ж")
            .IgnoreBlank = True
            .InCellDropdown = True
            .InputTitle = ""
            .ErrorTitle = ""
            .InputMessage = ""
            .ErrorMessage = ""
            .ShowInput = True
            .ShowError = True
        End With
        Dim yearstr As String = ""
        For j As Integer = 2010 To 2040
            yearstr = yearstr & j & "/" & j Mod 100 + 1 & ";"
        Next
        i = i + 1
        rng = shXL.Range("C" & i)
        With rng.Validation
            .Delete()
            .Add(Type:=Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, AlertStyle:=Microsoft.Office.Interop.Excel.XlDVAlertStyle.xlValidAlertStop,
            Formula1:=yearstr)
            .IgnoreBlank = True
            .InCellDropdown = True
            .InputTitle = ""
            .ErrorTitle = ""
            .InputMessage = ""
            .ErrorMessage = ""
            .ShowInput = True
            .ShowError = True
        End With
        ProgressBar1.Value = 3
        Dim cmdStrin As String
        shXL.Range("F1").EntireColumn.ColumnWidth = 15
        shXL.Cells(i, 2) = "Учебна година"
        shXL.Cells(i, 3) = "2010/11"
        i = i + 1
        shXL.Cells(i, 2) = "Ученици в класа"
        shXL.Cells(i, 3) = "20"
        Dim studstr As String = ""
        For j As Integer = 5 To 32
            studstr = studstr & j & ";"
        Next
        rng = shXL.Cells(i, 3)
        With rng.Validation
            .Delete()
            .Add(Type:=Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, AlertStyle:=Microsoft.Office.Interop.Excel.XlDVAlertStyle.xlValidAlertStop,
            Formula1:=studstr)
            .IgnoreBlank = True
            .InCellDropdown = True
            .InputTitle = ""
            .ErrorTitle = ""
            .InputMessage = ""
            .ErrorMessage = ""
            .ShowInput = True
            .ShowError = True
        End With
        i = i + 1
        ProgressBar1.Value = 4
        shXL.Cells(i, 2) = "Вид оценка"
        Dim type, type1 As String
        cmdStrin = "Select* from types order by name_type asc;"
        cmd = New MySqlCommand(cmdStrin, cnn)
        cmd.ExecuteNonQuery()
        Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
        Dim dt As DataTable = New DataTable
        adaptre.Fill(dt)
        type = ""
        type1 = ""
        For j As Integer = 0 To dt.Rows.Count - 1
            type = type & dt.Rows(j).Item("name_type") & ";"
            type1 = dt.Rows(1).Item("name_type")
        Next
        rng = shXL.Range("B" & i - 3 & ":D" & i)
        Call cellborder(rng)
        shXL.Cells(i, 3) = type1
        rng = shXL.Range("C" & i)
        With rng.Validation
            .Delete()
            .Add(Type:=Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, AlertStyle:=Microsoft.Office.Interop.Excel.XlDVAlertStyle.xlValidAlertStop,
            Formula1:=type)
            .IgnoreBlank = True
            .InCellDropdown = True
            .InputTitle = ""
            .ErrorTitle = ""
            .InputMessage = ""
            .ErrorMessage = ""
            .ShowInput = True
            .ShowError = True
        End With
        ProgressBar1.Value = 5
        shXL.Range("C2:C6").Locked = False
        shXL.Range("D2").Locked = False
        i = i + 3
        shXL.Range(shXL.Cells(i, 1), shXL.Cells(i + 1, 1)).Merge()
        shXL.Cells(i, 1) = "№"
        shXL.Range(shXL.Cells(i, 2), shXL.Cells(i + 1, 2)).Merge()
        shXL.Cells(i, 2) = "Учебен предмет"
        shXL.Range("B5").EntireColumn.ColumnWidth = 35
        shXL.Range("A1").EntireColumn.ColumnWidth = 3
        shXL.Range("H9").EntireColumn.ColumnWidth = 15
        shXL.Range("I9").EntireColumn.ColumnWidth = 15
        shXL.Range("C9").EntireColumn.ColumnWidth = 20
        shXL.Range(shXL.Cells(i, 3), shXL.Cells(i, 9)).Merge()
        shXL.Cells(i, 3) = "Брой на учениците с оценки"
        shXL.Range(shXL.Cells(i, 3), shXL.Cells(i, 9)).HorizontalAlignment = xlCenter
        i = i + 1
        ProgressBar1.Value = 6
        shXL.Cells(i, 3) = "Слаб"
        shXL.Cells(i, 4) = "Среден"
        shXL.Cells(i, 5) = "Добър"
        shXL.Cells(i, 6) = "Мн.добър"
        shXL.Cells(i, 7) = "Отличен"
        shXL.Cells(i, 8) = "Общо оценки"
        shXL.Cells(i, 9) = "Среден успех"
        i = i + 1
        cmdStrin = "Select* from subject order by number asc;"
        cmd = New MySqlCommand(cmdStrin, cnn)
        cmd.ExecuteNonQuery()
        adaptre = New MySqlDataAdapter(cmd)
        dt = New DataTable
        adaptre.Fill(dt)
        ProgressBar1.Value = 7
        If dt.Rows.Count > 0 Then
            Dim namesubject As String
            For j = 0 To dt.Rows.Count + 5
                namesubject = ""
                If j < dt.Rows.Count Then
                    namesubject = dt.Rows(j).Item("name_subject")
                End If
                shXL.Cells(i, 1) = j + 1
                shXL.Cells(i, 2) = namesubject
                shXL.Cells(i, 3) = 0
                shXL.Cells(i, 4) = 0
                shXL.Cells(i, 5) = 0
                shXL.Cells(i, 6) = 0
                shXL.Cells(i, 7) = 0
                rng = shXL.Range("C" & i & ":G" & i)
                With rng.Validation
                    .Delete()
                    .Add(Type:=Microsoft.Office.Interop.Excel.XlDVType.xlValidateWholeNumber, AlertStyle:=Microsoft.Office.Interop.Excel.XlDVAlertStyle.xlValidAlertStop, Formula1:="0", Formula2:="32")
                    .IgnoreBlank = True
                    .InCellDropdown = True
                    .InputTitle = ""
                    .ErrorTitle = ""
                    .InputMessage = ""
                    .ErrorMessage = ""
                    .ShowInput = True
                    .ShowError = True
                End With
                shXL.Cells(i, 8) = "=SUM(C" & i & ":G" & i & ")"
                rng = shXL.Range("H" & i)
                rng.FormatConditions.Delete()
                rng.FormatConditions.Add(Microsoft.Office.Interop.Excel.XlFormatConditionType.xlCellValue, Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlGreater, "=$C$5")
                With rng.FormatConditions(1).Interior
                    .Color = 13551615
                    .TintAndShade = 0
                End With
                With rng.FormatConditions(1).Font
                    .Color = -16383015
                    .TintAndShade = 0
                End With
                shXL.Cells(i, 9) = "=(C" & i & "*2+D" & i & "*3+E" & i & "*4+F" & i & "*5+G" & i & "*6)/H" & i
                i = i + 1
            Next
        End If
        ProgressBar1.Value = 8
        shXL.Range("C10:G" & i - 1).Locked = False
        rng = shXL.Range("A" & i - dt.Rows.Count - 8 & ":I" & i - 1)
        Call cellborder(rng)
        shXL.Range("B" & i - 6 & ":B" & i - 1).Locked = False
        shXL.Cells(i + 1, 2) = "Общо оценки"
        shXL.Cells(i + 1, 3) = "=SUM(C" & i - dt.Rows.Count - 6 & ":C" & i - 1 & ")"
        shXL.Cells(i + 1, 4) = "=SUM(D" & i - dt.Rows.Count - 6 & ":D" & i - 1 & ")"
        shXL.Cells(i + 1, 5) = "=SUM(E" & i - dt.Rows.Count - 6 & ":E" & i - 1 & ")"
        shXL.Cells(i + 1, 6) = "=SUM(F" & i - dt.Rows.Count - 6 & ":F" & i - 1 & ")"
        shXL.Cells(i + 1, 7) = "=SUM(G" & i - dt.Rows.Count - 6 & ":G" & i - 1 & ")"
        shXL.Cells(i + 1, 8) = "=SUM(C" & i + 1 & ":G" & i + 1 & ")"
        rng = shXL.Range("B" & i + 1 & ":I" & i + 1)
        Call cellborder(rng)
        i = i + 1
        shXL.Cells(i, 9) = "=(C" & i & "*2+D" & i & "*3+E" & i & "*4+F" & i & "*5+G" & i & "*6)/H" & i
        i = i + 3
        shXL.Cells(i, 2) = "Отсъствия:"
        i = i + 1
        shXL.Cells(i, 2) = "Срок:"
        shXL.Cells(i, 3) = "Първи срок"
        rng = shXL.Cells(i, 3)
        ProgressBar1.Value = 9
        With rng.Validation
            .Delete()
            .Add(Type:=Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, AlertStyle:=Microsoft.Office.Interop.Excel.XlDVAlertStyle.xlValidAlertStop,
            Formula1:="Първи срок;Годишни;Няма отсътвия")
            .IgnoreBlank = True
            .InCellDropdown = True
            .InputTitle = ""
            .ErrorTitle = ""
            .InputMessage = ""
            .ErrorMessage = ""
            .ShowInput = True
            .ShowError = True
        End With
        shXL.Cells(i + 1, 2) = "Извинени"
        shXL.Cells(i + 1, 3) = 0
        shXL.Cells(i + 2, 2) = "Неизвинени"
        shXL.Cells(i + 2, 3) = 0
        shXL.Range("C" & i & ":C" & i + 2).Locked = False
        shXL.Cells(i + 3, 2) = "Общо"
        shXL.Cells(i + 3, 3) = "=SUM(C" & i + 1 & ":C" & i + 2 & ")"
        rng = shXL.Range("B" & i - 1 & ":C" & i + 3)

        Call cellborder(rng)
        shXL.Protect(pass)
        ProgressBar1.Value = 10
        lblStatus.Text = "Готово"
    End Sub
    Sub cellborder(ByVal rng As Microsoft.Office.Interop.Excel.Range)
        With rng.Borders
            .LineStyle = Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalUp
            .Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin
        End With
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

    Private Sub btnUpLoadWithExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpLoadWithExcel.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Dim pat As String = OpenFileDialog1.FileName
            Dim f As Integer = 0
            Try
                appXL = CreateObject("excel.application")
                wbsXL = appXL.Workbooks
                wbXL = wbsXL.Open(pat, , , , 12121)
                shXL = wbXL.Sheets(1)
                appXL.Visible = True
                f = 1
            Catch ex As Exception
                MsgBox("Файлът е отворен! ! ! Моля затворете го! ! !", , "Въвеждане, изтриване и редактиране на оценки")
            End Try
            If f = 1 Then
                Try
                    cnn.Open()
                    cnn.Close()
                Catch ex As Exception
                    MsgBox("Грешка в базата данни! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                    Application.Exit()
                End Try
                cnn.Open()
                Dim flag As Integer
                Call checkExcelFile(flag)
                If flag = 0 Then
                    lblStatus.Text = "Добавяне на оценките в базата"
                    Call ExAddToDB(flag)
                    If flag = 0 Then

                        MsgBox("Оценките и отсътвията са добавени! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                    Else
                        MsgBox("Оценките и отсъствията не са записани в базата данни поради технически проблем! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                    End If

                Else
                    lblStatus.Text = "Няма статус"
                    MsgBox("Оценките и отсъствията не са записани в базата данни поради технически проблем! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                End If
                cnn.Close()
            End If

            wbXL.Close()
            wbsXL.Close()
            releaseObject(xlapp)
            releaseObject(wbXL)
            releaseObject(shXL)
            shXL = Nothing
            wbsXL = Nothing
            appXL = Nothing
        End If
    End Sub
    Function checkExcelFile(ByRef flag As Integer)
        lblStatus.Text = "Провека на файла"
        flag = 1
        Dim checker As String = ""
        Dim checker2 As String = ""
        Dim checkerint As Integer
        Try
            shXL.Unprotect(pass)
        Catch ex As Exception
        End Try
        Dim f As Integer = 1
        Dim cmdStrin As String
        Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
        Dim dt As DataTable = New DataTable
        row = 1
        checker = shXL.Cells(row, 1).value()
        Dim studenst As Integer
        ' If checker = "Доклад" Then
        row = row + 2
        checker = shXL.Cells(row, 2).value()
        If checker = "Клас" Then
            Try
                checkerint = shXL.Cells(row, 3).value()
            Catch ex As Exception
                MsgBox("Файлът не е по изискавнията! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                Return flag
                Exit Function
            End Try
            If checkerint > 0 And checkerint < 13 Then
                checker = shXL.Cells(row, 4).value()
                If checker = "а" Or checker = "б" Or checker = "в" Or checker = "г" Or checker = "д" Or checker = "е" Or checker = "ж" Then
                    row = row + 1
                    checker = shXL.Cells(row, 3).value()
                    For j As Integer = 2010 To 2040
                        checker2 = j & "/" & j Mod 100 + 1
                        If checker2 = checker Then
                            f = 0
                            Exit For
                        End If
                    Next
                    If f = 0 Then
                        f = 1
                        checker = shXL.Cells(row, 2).value()
                        If checker = "Учебна година" Then
                            row = row + 1
                            checker = shXL.Cells(row, 2).value()
                            If checker = "Ученици в класа" Then
                                Try
                                    checkerint = shXL.Cells(row, 3).value()
                                    studenst = checkerint
                                Catch ex As Exception
                                    MsgBox("Файлът не е по изискавнията! ! ! 2", , "Въвеждане, изтриване и редактиране на оценки")
                                    Return flag
                                    Exit Function
                                End Try
                                row = row + 1
                                checker = shXL.Cells(row, 2).value()

                                If checker = "Вид оценка" Then
                                    checker = shXL.Cells(row, 3).value()
                                    cmdStrin = "Select* from types where name_type='" & checker & "';"
                                    cmd = New MySqlCommand(cmdStrin, cnn)
                                    cmd.ExecuteNonQuery()
                                    adaptre = New MySqlDataAdapter(cmd)
                                    dt = New DataTable
                                    adaptre.Fill(dt)
                                    If dt.Rows.Count = 0 Then
                                        If MsgBox("Този вид оценка не е въведен! ! ! Искате ли да се добави?", MsgBoxStyle.OkCancel, "Въвеждане, изтриване и редактиране на оценки") = MsgBoxResult.Ok Then
                                            Dim idtype As Integer
                                            Call Module1.idMax("type", idtype)
                                            Dim cmdstr As String
                                            cmdstr = "Insert into subject (id,name_type) values (@id,@name_type);"
                                            cmd = New MySqlCommand(cmdstr, cnn)
                                            cmd.Parameters.AddWithValue("@id", idtype)
                                            cmd.Parameters.AddWithValue("@name_type", checker)
                                            cmd.ExecuteNonQuery()

                                        Else
                                            f = 1
                                            Return flag
                                            Exit Function
                                        End If

                                    End If
                                    f = 0
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
        ' End If
        If f = 0 Then
            f = 1
            row = row + 3
            checker = shXL.Cells(row, 1).value()
            If checker = "№" Then
                checker = shXL.Cells(row, 2).value()
                If checker = "Учебен предмет" Then
                    checker = shXL.Cells(row, 3).value()
                    If checker = "Брой на учениците с оценки" Then
                        row = row + 1
                        checker = shXL.Cells(row, 3).value()
                        If checker = "Слаб" Then
                            checker = shXL.Cells(row, 4).value()
                            If checker = "Среден" Then
                                checker = shXL.Cells(row, 5).value()
                                If checker = "Добър" Then
                                    checker = shXL.Cells(row, 6).value()
                                    If checker = "Мн.добър" Then
                                        checker = shXL.Cells(row, 7).value()
                                        If checker = "Отличен" Then
                                            checker = shXL.Cells(row, 8).value()
                                            If checker = "Общо оценки" Then
                                                checker = shXL.Cells(row, 9).value()
                                                If checker = "Среден успех" Then
                                                    f = 0
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Else
            MsgBox("Файлът не е по изискавнията! ! !", , "Въвеждане, изтриване и редактиране на оценки")
            Return flag
            Exit Function
        End If
        Dim fch As Boolean
        Dim PurposeMoreStudent As String = ""
        If f = 0 Then
            f = 1
            cmdStrin = "Select* from subject order by name_subject asc;"
            cmd = New MySqlCommand(cmdStrin, cnn)
            cmd.ExecuteNonQuery()
            adaptre = New MySqlDataAdapter(cmd)
            dt = New DataTable
            adaptre.Fill(dt)
            Dim checher3 As String = shXL.Cells(row + 1, 3).value()
            Do While checher3 <> ""
                row = row + 1
                fch = 0
                checher3 = shXL.Cells(row, 3).value()
                If checher3 = "" Then
                    Exit Do
                End If
                Try
                    checkerint = shXL.Cells(row, 3).value()
                Catch ex As Exception
                    MsgBox("Файлът не е по изискавнията! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                    Return flag
                    Exit Function
                End Try
                Try
                    checkerint = shXL.Cells(row, 4).value()
                Catch ex As Exception
                    MsgBox("Файлът не е по изискавнията! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                    Return flag
                    Exit Function
                End Try
                Try
                    checkerint = shXL.Cells(row, 5).value()
                Catch ex As Exception
                    MsgBox("Файлът не е по изискавнията! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                    Return flag
                    Exit Function
                End Try
                Try
                    checkerint = shXL.Cells(row, 6).value()
                Catch ex As Exception
                    MsgBox("Файлът не е по изискавнията! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                    Return flag
                    Exit Function
                End Try
                Try
                    checkerint = shXL.Cells(row, 7).value()
                Catch ex As Exception
                    MsgBox("Файлът не е по изискавнията! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                    Return flag
                    Exit Function
                End Try
                fch = 0
                Try
                    checkerint = shXL.Cells(row, 8).value()
                    If checkerint > studenst Then
                        If PurposeMoreStudent = "" Then
                            PurposeMoreStudent = row
                        Else
                            PurposeMoreStudent = PurposeMoreStudent & ", " & row
                        End If
                    End If
                    If checkerint > 0 Then
                        fch = 1
                    End If
                Catch ex As Exception
                    MsgBox("Файлът не е по изискавнията! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                    Return flag
                    Exit Function
                End Try
                If fch = 1 Then
                    Try
                        checkerint = shXL.Cells(row, 9).value()
                    Catch ex As Exception
                        MsgBox("Файлът не е по изискавнията! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                        Return flag
                        Exit Function
                    End Try
                End If
                f = 0
            Loop
            If PurposeMoreStudent = "" Then
                If f = 0 Then
                    row = row + 4
                    checker = shXL.Cells(row, 2).value()
                    If checker = "Отсъствия:" Then
                        row = row + 1
                        checker = shXL.Cells(row, 2).value()
                        If checker = "Срок:" Then
                            checker = shXL.Cells(row, 3).value()
                            If checker = "Годишни" Or checker = "Първи срок" Or checker = "Няма отсътвия" Then
                                row = row + 1
                                checker = shXL.Cells(row, 2).value()
                                Dim msgnekoreknaforma As String = ""
                                If checker = "Извинени" Then
                                    Try
                                        checkerint = shXL.Cells(row, 3).value()
                                    Catch ex As Exception
                                        MsgBox("Файлът не е по изискавнията! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                                        Return flag
                                        Exit Function
                                    End Try
                                    f = 0

                                    If (checkerint * 10) Mod 10 <> 0 And (checkerint * 100) Mod 100 <> 33 And (checkerint * 100) Mod 100 <> 66 And (checkerint * 100) Mod 100 <> 67 Then
                                        msgnekoreknaforma = "Извинените"
                                        f = 1
                                    End If
                                    row = row + 1
                                    checker = shXL.Cells(row, 2).value()
                                    If checker = "Неизвинени" Then
                                        Try
                                            checkerint = shXL.Cells(row, 3).value()
                                        Catch ex As Exception
                                            MsgBox("Файлът не е по изискавнията! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                                            Return flag
                                            Exit Function
                                        End Try
                                        f = 0
                                        If (checkerint * 10) Mod 10 <> 0 And (checkerint * 100) Mod 100 <> 33 And (checkerint * 100) Mod 100 <> 66 And (checkerint * 100) Mod 100 <> 67 Then
                                            If msgnekoreknaforma = "" Then
                                                msgnekoreknaforma = "Неизвинените"
                                            Else
                                                msgnekoreknaforma = "и неизвинените"
                                            End If
                                        End If
                                    End If
                                    If msgnekoreknaforma <> "" Then
                                        MsgBox(msgnekoreknaforma & " отсъствия не са в корекне форма! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                                        Return flag
                                        Exit Function
                                    Else
                                        flag = 0
                                    End If
                                Else
                                    MsgBox("Файлът не е по изискавнията! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                                    Return flag
                                    Exit Function
                                End If
                            Else
                                MsgBox("Файлът не е по изискавнията! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                                Return flag
                                Exit Function
                            End If
                        Else
                            MsgBox("Файлът не е по изискавнията! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                            Return flag
                            Exit Function
                        End If
                    Else
                        MsgBox("Файлът не е по изискавнията! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                        Return flag
                        Exit Function
                    End If
                End If
            Else
                MsgBox("На ред(овете) " & PurposeMoreStudent & " оценките са повече от учениците! ! ! Моля поправете го! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                MsgBox("Файлът не е по изискавнията! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                Return flag
                Exit Function
            End If
        Else
            MsgBox("Файлът не е по изискавнията! ! !", , "Въвеждане, изтриване и редактиране на оценки")
        End If
        Return flag
    End Function
    Function ExAddToDB(ByVal fla As Integer)
        fla = 0
        Dim classint, year, student As Integer
        Dim paral, yearex, type, cmdstr As String
        row = 3
        classint = shXL.Cells(row, 3).value()
        paral = shXL.Cells(row, 4).value()
        row = row + 1
        yearex = shXL.Cells(row, 3).value()
        year = 2010
        For i As Integer = 2010 To 2040
            If i & "/" & i Mod 100 + 1 = yearex Then
                year = i
            End If
        Next
        row = row + 1
        student = shXL.Cells(row, 3).value()
        row = row + 1
        type = shXL.Cells(row, 3).value()
        Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
        Dim dt As DataTable = New DataTable
        cmdstr = "Select* from types where name_type='" & type & "';"
        cmd = New MySqlCommand(cmdstr, cnn)
        cmd.ExecuteNonQuery()
        adaptre = New MySqlDataAdapter(cmd)
        dt = New DataTable
        adaptre.Fill(dt)
        Dim typeid As Integer = dt.Rows(0).Item("id")
        Dim classid As Integer
        cmdstr = "Select* from classes where school_year='" & year & "' and grade='" & classint & "' and class='" & paral & "';"
        cmd = New MySqlCommand(cmdstr, cnn)
        cmd.ExecuteNonQuery()
        adaptre = New MySqlDataAdapter(cmd)
        dt = New DataTable
        adaptre.Fill(dt)
        Dim idUp As Integer = 0
        Dim profileid As Integer
        Dim classstr As String = yearex & " " & classint & " " & paral
        If dt.Rows.Count = 0 Then
            If MsgBox("Този клас не е въведен! ! ! Искате ли да го въведете?", MsgBoxStyle.OkCancel, "Въвеждане, изтриване и редактиране на оценки") = MsgBoxResult.Ok Then
                Dim profil As String = ""
                cmdstr = "Select* from profiles order by id;"
                cmd = New MySqlCommand(cmdstr, cnn)
                cmd.ExecuteNonQuery()
                adaptre = New MySqlDataAdapter(cmd)
                dt = New DataTable
                adaptre.Fill(dt)
                If dt.Rows.Count > 0 Then
                    profileid = dt.Rows(0).Item("id")
                    profil = dt.Rows(0).Item("name_profile")
                    cmdstr = "Select* from classes order by id desc;"
                    cmd = New MySqlCommand(cmdstr, cnn)
                    cmd.ExecuteNonQuery()
                    adaptre = New MySqlDataAdapter(cmd)
                    dt = New DataTable
                    adaptre.Fill(dt)
                    idUp = dt.Rows(0).Item("id") + 1
                    'Въвеждане на класа
                    cmd = New MySqlCommand("Insert into  classes (id,school_year,grade,class,profile,students) values (@id,@school_year,@grade,@class,@profile,@students);", cnn)
                    cmd.Parameters.AddWithValue("@id", idUp)
                    cmd.Parameters.AddWithValue("@school_year", year)
                    cmd.Parameters.AddWithValue("@grade", classint)
                    cmd.Parameters.AddWithValue("@class", paral)
                    cmd.Parameters.AddWithValue("@profile", profileid)
                    cmd.Parameters.AddWithValue("@students", student)
                    cmd.ExecuteNonQuery()
                    MsgBox("Класа е записан с профил: " & profil & vbNewLine & "и брой ученици: " & student, , "Въвеждане, изтриване и редактиране на оценки")
                Else
                    fla = 1
                    MsgBox("Моля въведете профили! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                End If
            Else
                Return 1
                Exit Function
            End If
        Else
            Dim studentdb As Integer = dt.Rows(0).Item("students")
            If student <> studentdb Then
                Dim studentinpbox As Integer = -1
                Dim flag As Integer = 1
                Do While (flag <> 0)
                    Try
                        studentinpbox = InputBox("Броят на учениците в базата данни(" & studentdb & ") e различни от учениците в Excel(" & student & ")! ! !" & vbNewLine & "Моля въведете колко са! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                        If studentinpbox = -1 Then
                            Return 1
                            Exit Function
                        End If
                        If studentinpbox > 0 And studentinpbox < 32 Then
                            If student > studentinpbox Then
                                MsgBox("Броят на учениците от Exel е по-голям от този, който въведохте сега! ! ! Oпитайте пак?", , "Въвеждане, изтриване и редактиране на оценки")
                            Else
                                flag = 0
                            End If

                        Else
                            MsgBox("Броят на учениците не може да е отрицателно число и трябва да е по-малко от 32! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                        End If
                    Catch ex As Exception
                        MsgBox("Броят на учениците е число! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                    End Try
                Loop
                cmdstr = "UPDATE classes SETstudents='" & studentinpbox & "' WHERE = school_year='" & year & "' and grade='" & classint & "' and class='" & paral & "';"
            End If
        End If
        cmdstr = "Select* from classes classes where school_year='" & year & "' and grade='" & classint & "' and class='" & paral & "';"
        cmd = New MySqlCommand(cmdstr, cnn)
        cmd.ExecuteNonQuery()
        adaptre = New MySqlDataAdapter(cmd)
        dt = New DataTable
        adaptre.Fill(dt)

        classid = dt.Rows(0).Item("id")
        row = row + 5
        Dim subject, chek As String
        Dim c2, c3, c4, c5, c6, sum, subjectid As Integer
        chek = shXL.Cells(row, 3).value()
        Do While chek <> ""
            subject = shXL.Cells(row, 2).value()
            If subject <> "" Then
                cmdstr = "Select* from subject where name_subject='" & subject & "';"
                cmd = New MySqlCommand(cmdstr, cnn)
                cmd.ExecuteNonQuery()
                adaptre = New MySqlDataAdapter(cmd)
                dt = New DataTable
                adaptre.Fill(dt)
                Dim f As Integer = 0
                If dt.Rows.Count = 0 Then
                    If MsgBox("Предметът " & subject & " не е въведен! ! ! Да се въведе ли?", MsgBoxStyle.OkCancel, "Въвеждане, изтриване и редактиране на оценки") = vbOK Then
                        Dim number As Integer = 0
                        cmdstr = "Select max(number) as m from subject;"
                        cmd = New MySqlCommand(cmdstr, cnn)
                        cmd.ExecuteNonQuery()
                        adaptre = New MySqlDataAdapter(cmd)
                        dt = New DataTable
                        adaptre.Fill(dt)
                        If dt.Rows.Count > 0 Then
                            number = dt.Rows(0).Item("number") + 1
                        End If



                        cmdstr = "Insert into subject (id,name_subject,number) values (@id,@name_subject,@number);"
                        Dim idsubject As Integer
                        Call Module1.idMax("subject", idsubject)
                        cmd = New MySqlCommand(cmdstr, cnn)
                        cmd.Parameters.AddWithValue("@id", idsubject)
                        cmd.Parameters.AddWithValue("@name_subject", subject)
                        cmd.Parameters.AddWithValue("@number", number)
                        cmd.ExecuteNonQuery()
                    Else
                        f = 1
                        MsgBox("Оценките от ред " & row & " няма да бъдат въведени! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                    End If
                Else
                    subjectid = dt.Rows(0).Item("id")
                End If
                If f = 0 Then
                    c2 = shXL.Cells(row, 3).value()
                    c3 = shXL.Cells(row, 4).value()
                    c4 = shXL.Cells(row, 5).value()
                    c5 = shXL.Cells(row, 6).value()
                    c6 = shXL.Cells(row, 7).value()
                    sum = shXL.Cells(row, 8).value()
                    If sum <> 0 Then
                        cmdstr = "Select* from purpose where subject='" & subjectid & "' and type='" & typeid & "' and class='" & classid & "';"
                        cmd = New MySqlCommand(cmdstr, cnn)
                        cmd.ExecuteNonQuery()
                        adaptre = New MySqlDataAdapter(cmd)
                        dt = New DataTable
                        adaptre.Fill(dt)
                        If dt.Rows.Count > 0 Then
                            Dim c2db, c3db, c4db, c5db, c6db As Integer
                            c2db = dt.Rows(0).Item("count_2")
                            c3db = dt.Rows(0).Item("count_3")
                            c4db = dt.Rows(0).Item("count_4")
                            c5db = dt.Rows(0).Item("count_5")
                            c6db = dt.Rows(0).Item("count_6")
                            If c2 <> c2db Or c3 <> c3db Or c4 <> c4db Or c5 <> c5db Or c6 <> c6db Then
                                Dim msgtxt As String
                                msgtxt = "Оценките са били записани преди! ! !" & vbNewLine
                                msgtxt = msgtxt & "От файла те са " & c2 & " двойки " & c3 & " тройки " & c4 & " четворки " & c5 & " петици и " & c6 & " шестици," & vbNewLine
                                msgtxt = msgtxt & "a в базата данни те са " & c2db & " двойки " & c3db & " тройки " & c4db & " четворки " & c5db & " петици и " & c6db & " шестици ! ! !" & vbNewLine
                                msgtxt = msgtxt & "Искате ли да се презапишат?"
                                If MsgBox(msgtxt, MsgBoxStyle.OkCancel, "Въвеждане, изтриване и редактиране на оценки") = vbOK Then
                                    cmdstr = "UPDATE purpose SET count_2='" & c2 & "' ,count_3='" & c3 & "' ,count_4='" & c4 & "' ,count_5='" & c4 & "' ,count_6='" & c6 & "'"
                                    cmdstr = cmdstr & " WHERE type='" & typeid & "' and class='" & classid & "' and subject='" & subjectid & "';"
                                    cmd = New MySqlCommand(cmdstr, cnn)
                                    cmd.ExecuteNonQuery()
                                Else
                                    f = 1
                                    MsgBox("Оценките от ред " & row & " няма да бъдат въведени! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                                End If
                            End If
                        Else
                            cmdstr = "Insert into  purpose (class,subject,type,count_2,count_3,count_4,count_5,count_6) values (@class,@subject,@type,@count_2,@count_3,@count_4,@count_5,@count_6);"
                            cmd = New MySqlCommand(cmdstr, cnn)
                            cmd.Parameters.AddWithValue("@class", classid)
                            cmd.Parameters.AddWithValue("@subject", subjectid)
                            cmd.Parameters.AddWithValue("@type", typeid)
                            cmd.Parameters.AddWithValue("@count_2", c2)
                            cmd.Parameters.AddWithValue("@count_3", c3)
                            cmd.Parameters.AddWithValue("@count_4", c4)
                            cmd.Parameters.AddWithValue("@count_5", c5)
                            cmd.Parameters.AddWithValue("@count_6", c6)
                            cmd.ExecuteNonQuery()
                            dgv1.Rows.Add(lblIdUp.Text, classstr, subject, type, c2, c3, c4, c5, c6)
                            lblIdUp.Text = lblIdUp.Text + 1

                        End If
                    End If

                End If
            Else
                chek = shXL.Cells(row, 3).value()
                If chek = "" Then
                    Exit Do
                End If

            End If
            row = row + 1
        Loop
        row = row + 5
        Dim time As String
        time = shXL.Cells(row, 3).value()
        row = row + 1
        If time <> "Няма отсътвия" Then
            Dim ciz, cniz As Double
            ciz = shXL.Cells(row, 3).value()
            row = row + 1
            cniz = shXL.Cells(row, 3).value()
            cmdstr = "Select* from absence where class='" & classid & "' and time='" & time & "';"
            cmd = New MySqlCommand(cmdstr, cnn)
            cmd.ExecuteNonQuery()
            adaptre = New MySqlDataAdapter(cmd)
            dt = New DataTable
            adaptre.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim cizdb, cnizdb As Double
                cizdb = dt.Rows(0).Item("count_excused")
                cnizdb = dt.Rows(0).Item("count_unexcused")
                If ciz <> cizdb Or cniz <> cnizdb Then
                    Dim msgtxt As String
                    msgtxt = "Отсъствията са били записани преди! ! !" & vbNewLine
                    msgtxt = msgtxt & "От файла те са " & ciz & " извинени и " & cniz & " неизвинени" & vbNewLine
                    msgtxt = msgtxt & "a в базата данни те са " & cizdb & " извинени и " & cnizdb & " неизвинени" & vbNewLine
                    msgtxt = msgtxt & "Искате ли да се презапишат?"
                    If MsgBox(msgtxt, MsgBoxStyle.OkCancel, "Въвеждане, изтриване и редактиране на оценки") = vbOK Then
                        cmdstr = "UPDATE absence SET count_unexcused='" & ciz & "' ,count_excused='" & cniz & "'"
                        cmdstr = cmdstr & " WHERE class='" & classid & "' and time='" & time & "';"
                        cmd = New MySqlCommand(cmdstr, cnn)
                        cmd.ExecuteNonQuery()
                    Else
                        MsgBox("Отсътвията няма да бъдат въведени! ! !", , "Въвеждане, изтриване и редактиране на оценки")
                    End If
                End If
            Else
                cmdstr = "Insert into  absence (class,count_excused,count_unexcused,time) values (@class,@count_excused,@count_unexcused,@time);"
                cmd = New MySqlCommand(cmdstr, cnn)
                cmd.Parameters.AddWithValue("@class", classid)
                cmd.Parameters.AddWithValue("@count_excused", ciz)
                cmd.Parameters.AddWithValue("@count_unexcused", cniz)
                cmd.Parameters.AddWithValue("@time", time)
                cmd.ExecuteNonQuery()
            End If
        End If
        Return 0
    End Function
End Class