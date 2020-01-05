Imports MySql.Data.MySqlClient
Public Class absence_manual_input
    Dim cnn As New MySqlConnection
    Dim cmd As MySqlCommand
    Dim brRows, idup, index, id As Integer
    Private Sub absence_manual_input_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        brRows = 0
        Call Module1.hosts(cnn)
        Try
            cnn.Open()
            cnn.Close()
        Catch ex As Exception
            MsgBox("Грешка в базата данни! ! !")
            Application.Exit()
        End Try
        cnn.Open()
        cmd = New MySqlCommand("Select* from  absence order by id", cnn)
        cmd.ExecuteNonQuery()
        Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
        Dim data As DataTable = New DataTable
        adaptre.Fill(data)
        cnn.Close()
        Dim classes, classp, srok As String
        Dim nomer, year, classn, ce, ci As Double
        If data.Rows.Count > 0 Then
            Do While brRows < data.Rows.Count
                ' задаване на параметри за клас предмет
                nomer = data.Rows(brRows).Item("class")
                Try
                    cnn.Open()
                    cnn.Close()
                Catch ex As Exception
                    MsgBox("Грешка в базата данни! ! !")
                    Application.Exit()
                End Try
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
                ce = data.Rows(brRows).Item("count_excused")
                ci = data.Rows(brRows).Item(3)
                id = data.Rows(brRows).Item("id")
                srok = data.Rows(brRows).Item("time")

                dgv1.Rows.Add(id, classes, ce, ci, srok)
                brRows = brRows + 1
            Loop
        End If
        ' въвеждане на клас в cmbClasses
        Dim reader1 As MySqlDataReader
        Try
            cnn.Open()
            cnn.Close()
        Catch ex As Exception
            MsgBox("Грешка в базата данни! ! !")
            Application.Exit()
        End Try
        cnn.Open()
        cmd = New MySqlCommand("Select * from classes  order by school_year desc, grade asc, class asc;", cnn)
        ' ascending 
        cmd.ExecuteNonQuery()
        reader1 = cmd.ExecuteReader
        Dim clas, grade, wclass, classID, year2 As String
        wclass = ""
        While reader1.Read
            year2 = reader1.GetString("school_year")
            clas = reader1.GetString("grade")
            grade = reader1.GetString("class")
            wclass = year2 & "/" & year2 Mod 100 + 1 & " " & clas & " " & grade

            cmbClassItemUp.Items.Add(wclass)
            cmbCR.Items.Add(wclass)
            classID = reader1.GetString("id")
            cmbClassIdup.Items.Add(classID)
            cmbCIdR.Items.Add(classID)
        End While
        cnn.Close()
        If wclass <> "" Then
            cmbClassItemUp.Text = cmbClassItemUp.Items(0)
            cmbCR.Text = cmbCR.Items(0)
        End If
        Call Module1.idMax("absence", id)
        lblIdUp.Text = id
        If dgv1.RowCount > 0 Then
            Dim selectrows As DataGridViewRow
            selectrows = dgv1.Rows(0)
            lblIdDel.Text = selectrows.Cells(0).Value.ToString()
            LblClassDel.Text = selectrows.Cells(1).Value.ToString()
            lblCIzvDel.Text = selectrows.Cells(2).Value.ToString()
            lblCNeizDel.Text = selectrows.Cells(3).Value.ToString()
            lblSrokDel.Text = selectrows.Cells(4).Value.ToString()

            lblidR.Text = selectrows.Cells(0).Value.ToString()
            cmbCR.Text = selectrows.Cells(1).Value.ToString()
            Dim ch As Decimal
            Dim c2, r2 As Integer

            ch = selectrows.Cells(2).Value.ToString()
            r2 = (ch * 10) Mod 10
            If r2 = 0 Then
                c2 = ch
                cmbIRR.Text = "0"
            ElseIf r2 = 3 Then
                cmbIRR.Text = "33"
                c2 = ch - 0.33
            Else
                c2 = ch - 0.66
                cmbIRR.Text = "66"
            End If
            cmbICR.Text = c2
            ch = selectrows.Cells(3).Value.ToString()
            r2 = (ch * 10) Mod 10
            If r2 = 0 Then
                c2 = ch
                cmbNRR.Text = "0"
            ElseIf r2 = 3 Then
                cmbNRR.Text = "33"
                c2 = ch - 0.33
            Else
                c2 = ch - 0.66
                cmbNRR.Text = "66"
            End If
            cmbNcR.Text = c2
            cmbSR.Text = selectrows.Cells(4).Value.ToString()
        End If
    End Sub
    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Try
            cnn.Open()
            cnn.Close()
        Catch ex As Exception
            MsgBox("Грешка в базата данни! ! !")
            Application.Exit()
        End Try
        Dim clasid, br As Integer
        Dim count_izv, count_neizvin, clastext, clasitem, srok As String
        If cmbClassItemUp.Text <> "" Then
            clastext = cmbClassItemUp.Text
            br = 0
            clasitem = cmbClassItemUp.Items(br)
            Do While clasitem <> clastext
                clasitem = cmbClassItemUp.Items(br)
                br = br + 1
            Loop
            If br = 0 Then
                clasid = cmbClassIdup.Items(br)
            Else
                clasid = cmbClassIdup.Items(br - 1)
            End If
            cmbClassIdup.Text = clasid
            If cmb1.Text <> "0" Then
                count_izv = NumericUpDown1.Text & "." & cmb1.Text
            Else
                count_izv = NumericUpDown1.Text
            End If
            If cmb2.Text <> "0" Then
                count_neizvin = NumericUpDown2.Text & "." & cmb2.Text
            Else
                count_neizvin = NumericUpDown2.Text
            End If
            srok = cmbSrok.Text
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            'проверка да ли е въведен предмета преди
            cmd = New MySqlCommand("Select* from  absence where class='" & clasid & "' and time='" & srok & "'", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            If data.Rows.Count < 1 Then
                cmd = New MySqlCommand("insert into absence(id,class,count_excused,count_unexcused,time) values (@id,@class,@count_excused,@count_unexcused,@time);", cnn)
                cmd.Parameters.AddWithValue("@id", id)
                cmd.Parameters.AddWithValue("@class", clasid)
                cmd.Parameters.AddWithValue("@count_excused", count_izv)
                cmd.Parameters.AddWithValue("@count_unexcused", count_neizvin)
                cmd.Parameters.AddWithValue("@time", srok)
                cmd.ExecuteNonQuery()
                Dim ci, cni As Double
                ci = NumericUpDown1.Text & "," & cmb1.Text
                cni = NumericUpDown2.Text & "," & cmb2.Text
                dgv1.Rows.Add(id, clastext, ci, cni, srok)
                'Съобщение успешно извършен запис
                MsgBox("Успешно веведени отсъствия! ! !", , "Въвеждане, изтриване и редактиране на отсъствия")
                id = id + 1
                lblIdUp.Text = id
                If dgv1.Rows.Count = 1 Then

                    lblIdDel.Text = idup
                    LblClassDel.Text = clastext
                    lblCIzvDel.Text = count_izv
                    lblCNeizDel.Text = count_neizvin
                    lblSrokDel.Text = srok

                    lblidR.Text = idup
                    cmbCR.Text = clastext
                    cmbICR.Text = NumericUpDown1.Text
                    cmbIRR.Text = cmb1.Text
                    cmbNcR.Text = NumericUpDown2.Text
                    cmbNRR.Text = cmb2.Text
                    cmbSR.Text = srok
                End If
                cmbClassItemUp.Text = cmbClassItemUp.Items(0)
                NumericUpDown1.Text = 0
                NumericUpDown2.Text = 0
                cmb2.Text = cmb2.Items(0)
                cmb1.Text = cmb1.Items(0)

                cmbSrok.Text = cmbSrok.Items(0)
            Else
                'Съобщение завече въведен запис
                MsgBox("Тези отсъствия за този срок на този клас са били въведени! ! !", , "Въвеждане, изтриване и редактиране на отсъствия")

            End If
            cnn.Close()
        Else
            MsgBox("Трябва да въведете неизвинени отсъствия! ! !", , "Въвеждане, изтриване и редактиране на отсъствия")
        End If
    End Sub
    Private Sub cmbClassItemUp_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClassItemUp.Leave, cmbClassItemUp.DropDownClosed
        If (cmbClassItemUp.SelectedIndex = -1) Then
            cmbClassItemUp.Text = cmbClassItemUp.Items(0)
            cmbClassItemUp.Focus()
        Else
            cmbCIdR.Text = cmbCIdR.Items(cmbClassItemUp.SelectedIndex)
        End If

    End Sub
    Private Sub absence_manual_input_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'изчистване на dgv
        idup = 0
        Do While idup < dgv1.Rows.Count
            dgv1.Rows.Remove(dgv1.Rows(0))
        Loop

        'заноляване на cmb
        Do While cmbClassIdup.Items.Count > 0
            cmbClassItemUp.Items.RemoveAt(0)
            cmbClassIdup.Items.RemoveAt(0)
            cmbCR.Items.RemoveAt(0)
            cmbCIdR.Items.RemoveAt(0)
        Loop

    End Sub
    Private Sub dgv1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellClick
        If e.RowIndex <> -1 Then
            index = e.RowIndex
            Dim selectrows As DataGridViewRow
            selectrows = dgv1.Rows(index)
            lblIdDel.Text = selectrows.Cells(0).Value.ToString()
            LblClassDel.Text = selectrows.Cells(1).Value.ToString()
            lblCIzvDel.Text = selectrows.Cells(2).Value.ToString()
            lblCNeizDel.Text = selectrows.Cells(3).Value.ToString()
            lblSrokDel.Text = selectrows.Cells(4).Value.ToString()
            lblidR.Text = selectrows.Cells(0).Value.ToString()
            cmbCR.Text = selectrows.Cells(1).Value.ToString()
            Dim ch As Double
            Dim c2, r2 As Integer
            ch = lblCIzvDel.Text
            r2 = (ch * 10) Mod 10
            If r2 = 0 Then
                c2 = ch
                cmbIRR.Text = "0"
            ElseIf r2 = 3 Then
                cmbIRR.Text = "33"
                c2 = ch - 0.33
            Else
                c2 = ch - 0.66
                cmbIRR.Text = "66"
            End If

            cmbICR.Text = c2
            ch = lblCNeizDel.Text
            r2 = (ch * 10) Mod 10
            If r2 = 0 Then
                c2 = ch
                cmbNRR.Text = "0"
            ElseIf r2 = 3 Then
                cmbNRR.Text = "33"
                c2 = ch - 0.33
            Else
                c2 = ch - 0.66
                cmbNRR.Text = "66"
            End If
            cmbNcR.Text = c2
            cmbSR.Text = selectrows.Cells(4).Value.ToString()
        End If
    End Sub
    Private Sub btnDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDEL.Click
        Try
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            If MsgBox("Сигурни ли сте, че искате да го изтриите?", vbYesNo, "Въвеждане, изтриване и редактиране на отсъствия") = vbYes Then
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
                cmd = New MySqlCommand("Delete from absence  where id='" & id & "'", cnn)
                cmd.ExecuteNonQuery()
                MsgBox("Успешно изтрити отсъствия на клас! ! !", , "Въвеждане, изтриване и редактиране на отсъствия")
                cnn.Close()
                'проверка за MAX ID
                Call Module1.idMax("absence", id)
                lblIdUp.Text = id
                dgv1.Rows.Remove(dgv1.Rows(index))
                If dgv1.Rows.Count = 0 Then
                    lblIdDel.Text = ""
                    lblIdDel.Text = ""
                    LblClassDel.Text = ""
                    lblCIzvDel.Text = ""
                    lblCNeizDel.Text = ""
                    lblSrokDel.Text = ""

                    lblidR.Text = ""
                    cmbCR.Text = ""
                    cmbIRR.Text = ""
                    cmbICR.Text = ""
                    cmbNRR.Text = ""
                    cmbNcR.Text = ""
                    cmbSR.Text = ""

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
                    LblClassDel.Text = selectrows.Cells(1).Value.ToString()
                    lblCIzvDel.Text = selectrows.Cells(2).Value.ToString()
                    lblCNeizDel.Text = selectrows.Cells(3).Value.ToString()
                    lblSrokDel.Text = selectrows.Cells(4).Value.ToString()

                    lblidR.Text = selectrows.Cells(0).Value.ToString()
                    cmbCR.Text = selectrows.Cells(1).Value.ToString()
                    Dim ch As Decimal
                    Dim c2, r2 As Integer
                    ch = selectrows.Cells(2).Value.ToString()
                    r2 = (ch * 10) Mod 10
                    If r2 = 0 Then
                        c2 = ch
                        cmbIRR.Text = "0"
                    ElseIf r2 = 3 Then
                        cmbIRR.Text = "33"
                        c2 = ch - 0.33
                    Else
                        c2 = ch - 0.66
                        cmbIRR.Text = "66"
                    End If
                    cmbICR.Text = c2
                    ch = selectrows.Cells(3).Value.ToString()
                    r2 = (ch * 10) Mod 10
                    If r2 = 0 Then
                        c2 = ch
                        cmbNRR.Text = "0"
                    ElseIf r2 = 3 Then
                        cmbNRR.Text = "33"
                        c2 = ch - 0.33
                    Else
                        c2 = ch - 0.66
                        cmbNRR.Text = "66"
                    End If
                    cmbNcR.Text = c2
                    cmbSR.Text = selectrows.Cells(4).Value.ToString()
                End If
                index = index2
            End If
        Catch ex As Exception
            MsgBox("ERROR - " & ex.Message)
        End Try
    End Sub
    Private Sub cmbSrok_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSrok.Leave, cmbSrok.DropDownClosed
        If (cmbSrok.SelectedIndex = -1) Then
            cmbSrok.Text = cmbSrok.Items(0)
            cmbSrok.Focus()
        End If
    End Sub
    Private Sub lblIdDel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblIdDel.TextChanged
        If lblIdDel.Text <> "" Then
            btnDEL.Enabled = True
            btnR.Enabled = True
        Else
            btnR.Enabled = False
            btnDEL.Enabled = False
        End If
    End Sub
    Private Sub ComboBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb1.Leave
        If (cmb1.SelectedIndex = -1) Then
            cmb1.Text = cmb1.Items(0)
            cmb1.Focus()
        End If
    End Sub
    Private Sub ComboBox2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb2.Leave, cmb2.DropDownClosed
        If (cmb2.SelectedIndex = -1) Then
            cmb2.Text = cmb2.Items(0)
            cmb2.Focus()
        End If
    End Sub
    Private Sub cmbCR_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCR.Leave, cmbCR.DropDownClosed
        If (cmbCR.SelectedIndex = -1) Then
            cmbCR.Text = LblClassDel.Text
            cmbCR.Focus()
        Else
            cmbCIdR.Text = cmbCIdR.Items(cmbCR.SelectedIndex)
        End If
    End Sub
    Private Sub cmbIRR_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIRR.Leave, cmbIRR.DropDownClosed
        If (cmbIRR.SelectedIndex = -1) Then
            cmbIRR.Text = (lblCIzvDel.Text * 100) Mod 100
            cmbCR.Focus()
        End If
    End Sub
    Private Sub cmbNRR_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNRR.Leave, cmbNRR.DropDownClosed
        If (cmbNRR.SelectedIndex = -1) Then
            cmbNRR.Text = (lblCNeizDel.Text * 100) Mod 100
            cmbNRR.Focus()
        End If
    End Sub
    Private Sub cmbSR_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSR.Leave, cmbSR.DropDownClosed
        If (cmbSR.SelectedIndex = -1) Then
            cmbSR.Text = lblSrokDel.Text
            cmbSR.Focus()
        End If
    End Sub
    Private Sub btnR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnR.Click
        If cmbCR.Text <> "" Then
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            Dim id, c As Integer
            Dim izv, neizv, srok As String
            id = lblidR.Text
            cmbCIdR.Text = cmbCIdR.Items(cmbCR.SelectedIndex)
            c = cmbCIdR.Text
            izv = cmbICR.Text & "." & cmbIRR.Text
            neizv = cmbNcR.Text & "." & cmbNRR.Text
            srok = cmbSR.Text
            cnn.Open()
            'проверка да ли е въведен предмета преди
            cmd = New MySqlCommand("Select* from  absence where class='" & c & "' and time='" & srok & "' and id<>'" & id & "'", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            If data.Rows.Count < 1 Then
                cmd = New MySqlCommand("UPDATE absence SET class ='" & c & "',count_excused='" & izv & "',count_unexcused='" & neizv & "',time='" & srok & "' WHERE absence.id='" & id & "';", cnn)
                cmd.ExecuteNonQuery()
                Dim selectrows1 As DataGridViewRow
                selectrows1 = dgv1.Rows(index)
                selectrows1.Cells(1).Value = cmbCR.Text
                selectrows1.Cells(2).Value = izv
                selectrows1.Cells(3).Value = neizv
                selectrows1.Cells(4).Value = srok
                MsgBox("Успешно редактирани отсъствия! ! !", , "Въвеждане, изтриване и редактиране на отсъствия")
                cnn.Close()
            Else
                'Съобщение завече въведен запис
                MsgBox("Тези отсъствия за този срок на този клас са били въведени! ! !", , "Въвеждане, изтриване и редактиране на отсъствия")
            End If
        Else
            MsgBox("Трябва да се добавят отсъствия! ! !", , "Въвеждане, изтриване и редактиране на отсъствия")
        End If
    End Sub
End Class