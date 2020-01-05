Imports MySql.Data.MySqlClient
Public Class Profile_manual_input
    Dim cnn As New MySqlConnection
    Dim cmd As MySqlCommand
    Dim idUP As Integer
    Dim brRows As Integer
    Dim index As Integer
    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        If txtUpPP1.Text <> "" Or txtUpPP2.Text <> "" Or txtUpPP3.Text <> "" Or txtUpPP4.Text <> "" Then
            Dim name, pp1, pp2, pp3, pp4 As String
            Dim brpp1, brpp2, brpp3, brpp4 As Integer
            name = txtUpName.Text
            If name <> "" Then
                ' намиране на избра първи профилиращ предмет
                pp1 = txtUpPP1.Text
                Try
                    cnn.Open()
                    cnn.Close()
                Catch ex As Exception
                    MsgBox("Грешка в базата данни! ! !")
                    Application.Exit()
                End Try
                cnn.Open()
                cmd = New MySqlCommand("Select* from  subject where name_subject='" & pp1 & "'", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt As DataTable = New DataTable
                adaptre1.Fill(dt)

                brpp1 = dt.Rows(0).Item("id")
                ' намиране на избра втори профилиращ предмет
                pp2 = txtUpPP2.Text

                cmd = New MySqlCommand("Select* from  subject where name_subject='" & pp2 & "'", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt1 As DataTable = New DataTable
                adaptre.Fill(dt1)

                brpp2 = dt1.Rows(0).Item("id")
                ' намиране на избра трети профилиращ предмет
                pp3 = txtUpPP3.Text


                cmd = New MySqlCommand("Select* from  subject where name_subject='" & pp3 & "'", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt2 As DataTable = New DataTable
                adaptre2.Fill(dt2)

                brpp3 = dt2.Rows(0).Item("id")
                ' намиране на избра четвърти профилиращ предмет

                pp4 = txtUpPP4.Text

                cmd = New MySqlCommand("Select* from  subject where name_subject='" & pp4 & "'", cnn)
                cmd.ExecuteNonQuery()

                Dim adaptre3 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt3 As DataTable = New DataTable
                adaptre3.Fill(dt3)
                cnn.Close()
                brpp4 = dt3.Rows(0).Item("id")
                cnn.Close()
                ' Проверка за различни профилиращи предмети
                If brpp1 <> brpp2 And brpp1 <> brpp3 And brpp1 <> brpp4 And brpp2 <> brpp3 And brpp2 <> brpp4 And brpp3 <> brpp4 Then
                    ' Проверка за ввече въведен профил с тези характеристики
                    Try
                        cnn.Open()
                        cnn.Close()
                    Catch ex As Exception
                        MsgBox("Грешка в базата данни! ! !")
                        Application.Exit()
                    End Try
                    cnn.Open()
                    cmd = New MySqlCommand("Select* from profiles where pp1='" & brpp1 & "'and pp2='" & brpp2 & "'and pp3='" & brpp3 & "'and pp4='" & brpp4 & "'", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre5 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim data As DataTable = New DataTable
                    adaptre5.Fill(data)
                    cnn.Close()

                    If data.Rows.Count = 0 Then
                        'Въвеждане на предмета в базата
                        cnn.Open()
                        Dim cmd2 As MySqlCommand
                        idUP = txtUpID.Text
                        Try
                            cmd2 = New MySqlCommand("insert into  profiles (name_profile,pp1,pp2,pp3,pp4) values (@name_profile,@pp1,@pp2,@pp3,@pp4);", cnn)
                            cmd2.Parameters.AddWithValue("@name_profile", name)
                            cmd2.Parameters.AddWithValue("@pp1", brpp1)
                            cmd2.Parameters.AddWithValue("@pp2", brpp2)
                            cmd2.Parameters.AddWithValue("@pp3", brpp3)
                            cmd2.Parameters.AddWithValue("@pp4", brpp4)

                            cmd2.ExecuteNonQuery()

                        Catch ex As Exception
                            MsgBox("ERROR- " & ex.Message)
                        End Try


                        ' Презареждане на datagreadveiw
                        cnn.Close()
                        dgv1.Rows.Add(idUP, name, pp1, pp2, pp3, pp4)

                        txtUpID.Text = txtUpID.Text + 1
                        If dgv1.Rows.Count = 1 Then
                            lblIdDel.Text = idUP
                            lblNameDel.Text = name
                            lblpp1Del.Text = pp1
                            lblpp2Del.Text = pp2
                            lblpp3Del.Text = pp3
                            lblpp4Del.Text = pp4

                            lblidR.Text = idUP
                            txtNameR.Text = name
                            cmbpp1R.Text = pp1
                            cmbpp2R.Text = pp2
                            cmbpp3R.Text = pp3
                            cmbpp4R.Text = pp4

                        End If

                        txtUpPP1.Text = txtUpPP1.Items(0)
                        txtUpPP2.Text = txtUpPP2.Items(1)
                        txtUpPP3.Text = txtUpPP3.Items(2)
                        txtUpPP4.Text = txtUpPP4.Items(3)

                        txtUpName.Text = ""
                        'Съобщение за успешно въведе предмет
                        MsgBox("Успешно въведен профил! ! !", , "Въвеждане, изтриване и редактиране на профили")
                    Else
                        MsgBox("Този профил е въведен преди! ! !", , "Въвеждане, изтриване и редактиране на профили")
                    End If
                Else
                    MsgBox("Профилиращите предмети трябва да са различни! ! !", , "Въвеждане, изтриване и редактиране на профили")
                End If

            Else
                MsgBox("Въведете име на профила! ! !", , "Въвеждане, изтриване и редактиране на профили")
            End If
        Else
            MsgBox("Трябава да се върнете и да въведете предмет! ! !", , "Въвеждане, изтриване и редактиране на профили")
        End If
    End Sub
    Private Sub profile_manual_input_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call Module1.idMax("profiles", idUP)
        txtUpID.Text = idUP
        If idUP > 0 Then
            Dim id As Integer
            brRows = 0
            Call Module1.hosts(cnn)
            cnn.Open()
            cmd = New MySqlCommand("Select* from  profiles order by id", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            cnn.Close()
            If data.Rows.Count > 0 Then
                Dim name_p, pp1, pp2, pp3, pp4 As String
                Dim ppp As Integer
                Do While brRows < data.Rows.Count
                    id = data.Rows(brRows).Item("id")
                    name_p = data.Rows(brRows).Item("name_profile")
                    ' задаване на име първи профилиращ предмет
                    ppp = data.Rows(brRows).Item("pp1")
                    cnn.Open()
                    cmd = New MySqlCommand("Select* from  subject where id='" & ppp & "'", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt As DataTable = New DataTable
                    adaptre2.Fill(dt)
                    cnn.Close()
                    pp1 = dt.Rows(0).Item("name_subject")
                    ' задаване на име втори профилиращ предмет
                    ppp = data.Rows(brRows).Item("pp2")
                    cnn.Open()
                    cmd = New MySqlCommand("Select* from  subject where id='" & ppp & "'", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre3 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt1 As DataTable = New DataTable
                    adaptre3.Fill(dt1)
                    cnn.Close()
                    pp2 = dt1.Rows(0).Item("name_subject")
                    ' задаване на име трети профилиращ предмет
                    ppp = data.Rows(brRows).Item("pp3")
                    cnn.Open()
                    cmd = New MySqlCommand("Select* from  subject where id='" & ppp & "'", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre4 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt2 As DataTable = New DataTable
                    adaptre4.Fill(dt2)
                    cnn.Close()
                    pp3 = dt2.Rows(0).Item("name_subject")
                    ' задаване на име четвърти профилиращ предмет
                    ppp = data.Rows(brRows).Item("pp4")
                    cnn.Open()
                    cmd = New MySqlCommand("Select* from  subject where id='" & ppp & "'", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre5 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt3 As DataTable = New DataTable
                    adaptre5.Fill(dt3)
                    cnn.Close()
                    pp4 = dt3.Rows(0).Item("name_subject")
                    dgv1.Rows.Add(id, name_p, pp1, pp2, pp3, pp4)
                    brRows = brRows + 1
                Loop

                Dim selectrows As DataGridViewRow
                selectrows = dgv1.Rows(0)

                lblIdDel.Text = selectrows.Cells(0).Value.ToString()
                lblNameDel.Text = selectrows.Cells(1).Value.ToString()
                lblpp1Del.Text = selectrows.Cells(2).Value.ToString()
                lblpp2Del.Text = selectrows.Cells(3).Value.ToString()
                lblpp3Del.Text = selectrows.Cells(4).Value.ToString()
                lblpp4Del.Text = selectrows.Cells(5).Value.ToString()
            End If
        End If
        Dim reader As MySqlDataReader
        cnn.Open()
        cmd = New MySqlCommand("Select * from subject order by number;", cnn)
        cmd.ExecuteNonQuery()
        reader = cmd.ExecuteReader
        Dim sname As String
        Dim id1 As Integer
        sname = ""
        While reader.Read
            sname = reader.GetString("name_subject")
            id1 = reader.GetString("id")
            txtUpPP1.Items.Add(sname)
            txtUpPP2.Items.Add(sname)
            txtUpPP3.Items.Add(sname)
            txtUpPP4.Items.Add(sname)

            cmbpp1R.Items.Add(sname)
            cmbpp2R.Items.Add(sname)
            cmbpp3R.Items.Add(sname)
            cmbpp4R.Items.Add(sname)

            cmbpp1RId.Items.Add(id1)
            cmbpp2RId.Items.Add(id1)
            cmbpp3RId.Items.Add(id1)
            cmbpp4RId.Items.Add(id1)

        End While
        cnn.Close()
        If sname <> "" Then
            txtUpPP1.Text = txtUpPP1.Items(0)
            txtUpPP2.Text = txtUpPP2.Items(1)
            txtUpPP3.Text = txtUpPP3.Items(2)
            txtUpPP4.Text = txtUpPP4.Items(3)
        End If
        Dim selectrows1 As DataGridViewRow
        selectrows1 = dgv1.Rows(0)
        lblidR.Text = selectrows1.Cells(0).Value.ToString()
        txtNameR.Text = selectrows1.Cells(1).Value.ToString()
        cmbpp1R.Text = selectrows1.Cells(2).Value.ToString()
        cmbpp2R.Text = selectrows1.Cells(3).Value.ToString()
        cmbpp3R.Text = selectrows1.Cells(4).Value.ToString()
        cmbpp4R.Text = selectrows1.Cells(5).Value.ToString()

        cmbpp1RId.Text = cmbpp1RId.Items(cmbpp1R.SelectedIndex)
        cmbpp2RId.Text = cmbpp2RId.Items(cmbpp2R.SelectedIndex)
        cmbpp3RId.Text = cmbpp3RId.Items(cmbpp3R.SelectedIndex)
        cmbpp4RId.Text = cmbpp4RId.Items(cmbpp4R.SelectedIndex)

    End Sub
    Private Sub dgv1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellClick
        If e.RowIndex <> -1 Then
            index = e.RowIndex
            Dim selectrows As DataGridViewRow
            selectrows = dgv1.Rows(index)
            lblIdDel.Text = selectrows.Cells(0).Value.ToString()
            lblNameDel.Text = selectrows.Cells(1).Value.ToString()
            lblpp1Del.Text = selectrows.Cells(2).Value.ToString()
            lblpp2Del.Text = selectrows.Cells(3).Value.ToString()
            lblpp3Del.Text = selectrows.Cells(4).Value.ToString()
            lblpp4Del.Text = selectrows.Cells(5).Value.ToString()

            lblidR.Text = selectrows.Cells(0).Value.ToString()
            txtNameR.Text = selectrows.Cells(1).Value.ToString()
            cmbpp1R.Text = selectrows.Cells(2).Value.ToString()
            cmbpp2R.Text = selectrows.Cells(3).Value.ToString()
            cmbpp3R.Text = selectrows.Cells(4).Value.ToString()
            cmbpp4R.Text = selectrows.Cells(5).Value.ToString()

            cmbpp1RId.Text = cmbpp1RId.Items(cmbpp1R.SelectedIndex)
            cmbpp2RId.Text = cmbpp2RId.Items(cmbpp2R.SelectedIndex)
            cmbpp3RId.Text = cmbpp3RId.Items(cmbpp3R.SelectedIndex)
            cmbpp4RId.Text = cmbpp4RId.Items(cmbpp4R.SelectedIndex)

        End If
    End Sub
    Private Sub btndeleteprofile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndeleteprofile.Click
        Try
            If MsgBox("Сигурни ли сте, че искате да го изтриите?", vbYesNo, "Въвеждане, изтриване и редактиране на профили") = vbYes Then
                Dim id As Integer
                Try
                    cnn.Open()
                    cnn.Close()
                Catch ex As Exception
                    MsgBox("Грешка в базата данни! ! !")
                    Application.Exit()
                End Try
                id = lblIdDel.Text
                'махане на предмета от базата
                cnn.Open()
                Dim index2 As Integer
                cmd = New MySqlCommand("Delete from  profiles where id='" & id & "'", cnn)
                cmd.ExecuteNonQuery()
                MsgBox("Успешно изтрит предмет! ! !", , "Въвеждане, изтриване и редактиране на профили")
                cnn.Close()
                'проверка за MAX ID
                Call Module1.idMax("profiles", id)
                txtUpID.Text = id
                dgv1.Rows.Remove(dgv1.Rows(index))
                If dgv1.Rows.Count = 0 Then
                    lblIdDel.Text = ""
                    lblNameDel.Text = ""
                    lblpp1Del.Text = ""
                    lblpp2Del.Text = ""
                    lblpp3Del.Text = ""
                    lblpp4Del.Text = ""

                    txtNameR.Text = ""
                    lblidR.Text = ""
                    cmbpp1R.Text = ""
                    cmbpp2R.Text = ""
                    cmbpp3R.Text = ""
                    cmbpp4R.Text = ""
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
                    lblNameDel.Text = selectrows.Cells(1).Value.ToString()
                    lblpp1Del.Text = selectrows.Cells(2).Value.ToString()
                    lblpp2Del.Text = selectrows.Cells(3).Value.ToString()
                    lblpp3Del.Text = selectrows.Cells(4).Value.ToString()
                    lblpp4Del.Text = selectrows.Cells(5).Value.ToString()

                    lblidR.Text = selectrows.Cells(0).Value.ToString()
                    txtNameR.Text = selectrows.Cells(1).Value.ToString()
                    cmbpp1R.Text = selectrows.Cells(2).Value.ToString()
                    cmbpp2R.Text = selectrows.Cells(3).Value.ToString()
                    cmbpp3R.Text = selectrows.Cells(4).Value.ToString()
                    cmbpp4R.Text = selectrows.Cells(5).Value.ToString()
                End If
                index = index2
            End If
        Catch ex As Exception
            MsgBox("ERROR - " & ex.Message)
        End Try


    End Sub
    Private Sub lblIdDel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblIdDel.TextChanged
        If lblIdDel.Text <> "" Then
            btndeleteprofile.Enabled = True
            btnRedakchia.Enabled = True
        Else
            btndeleteprofile.Enabled = False
            btnRedakchia.Enabled = False
        End If
    End Sub
    Private Sub Profile_manual_input_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        idUP = 0

        Do While idUP < dgv1.Rows.Count
            dgv1.Rows.Remove(dgv1.Rows(0))
        Loop

        Do While txtUpPP1.Items.Count > 0
            txtUpPP1.Items.RemoveAt(0)
            txtUpPP2.Items.RemoveAt(0)
            txtUpPP3.Items.RemoveAt(0)
            txtUpPP4.Items.RemoveAt(0)

            cmbpp1R.Items.RemoveAt(0)
            cmbpp2R.Items.RemoveAt(0)
            cmbpp3R.Items.RemoveAt(0)
            cmbpp4R.Items.RemoveAt(0)

        Loop

    End Sub
    Private Sub txtUpPP1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUpPP1.Leave, txtUpPP1.DropDownClosed, cmbpp1R.DropDownClosed
        If (txtUpPP1.SelectedIndex = -1) Then
            txtUpPP1.Text = txtUpPP1.Items(0)
            txtUpPP1.Focus()
        End If
    End Sub
    Private Sub txtUpPP2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUpPP2.Leave, txtUpPP2.DropDownClosed
        If (txtUpPP2.SelectedIndex = -1) Then
            txtUpPP2.Text = txtUpPP2.Items(1)
            txtUpPP2.Focus()
        End If
    End Sub
    Private Sub txtUpPP3_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUpPP3.Leave, txtUpPP3.DropDownClosed, cmbpp3R.DropDownClosed
        If (txtUpPP3.SelectedIndex = -1) Then
            txtUpPP3.Text = txtUpPP3.Items(2)
            txtUpPP3.Focus()
        End If
    End Sub
    Private Sub txtUpPP4_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUpPP4.Leave, txtUpPP4.DropDownClosed
        If (txtUpPP4.SelectedIndex = -1) Then
            txtUpPP4.Text = txtUpPP4.Items(3)
            txtUpPP4.Focus()
        End If
    End Sub
    Private Sub cmbpp1R_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbpp1R.Leave, cmbpp4RId.Leave, cmbpp3RId.Leave, cmbpp2RId.Leave, cmbpp1RId.Leave
        If (cmbpp1R.SelectedIndex = -1) Then
            cmbpp1R.Text = lblpp1Del.Text
            cmbpp1R.Focus()
        Else
            cmbpp1RId.Text = cmbpp1RId.Items(cmbpp1R.SelectedIndex)
        End If
    End Sub
    Private Sub cmbpp2R_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbpp2R.Leave, cmbpp2R.DropDownClosed
        If (cmbpp2R.SelectedIndex = -1) Then
            cmbpp2R.Text = lblpp2Del.Text
            cmbpp2R.Focus()
        Else
            cmbpp2RId.Text = cmbpp2RId.Items(cmbpp2R.SelectedIndex)
        End If
    End Sub
    Private Sub cmbpp3R_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbpp3R.Leave
        If (cmbpp3R.SelectedIndex = -1) Then
            cmbpp3R.Text = lblpp3Del.Text
            cmbpp3R.Focus()
        Else
            cmbpp3RId.Text = cmbpp3RId.Items(cmbpp3R.SelectedIndex)
        End If
    End Sub
    Private Sub cmbpp4R_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbpp4R.Leave, cmbpp4R.DropDownClosed
        If (cmbpp4R.SelectedIndex = -1) Then
            cmbpp4R.Text = lblpp4Del.Text
            cmbpp4R.Focus()
        Else
            cmbpp4RId.Text = cmbpp4RId.Items(cmbpp4R.SelectedIndex)
        End If
    End Sub
    Private Sub btnRedakchia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRedakchia.Click
        Dim id, np, pp1, pp2, pp3, pp4 As String
        id = lblidR.Text
        np = txtNameR.Text
        pp1 = cmbpp1RId.Text
        pp2 = cmbpp2RId.Text
        pp3 = cmbpp3RId.Text
        pp4 = cmbpp4RId.Text
        Try
            cnn.Open()
            cnn.Close()
        Catch ex As Exception
            MsgBox("Грешка в базата данни! ! !")
            Application.Exit()
        End Try
        cnn.Open()
        cmd = New MySqlCommand("Select* from profiles where pp1='" & pp1 & "'and pp2='" & pp2 & "'and pp3='" & pp3 & "'and pp4='" & pp4 & "' and id<>'" & id & "'", cnn)
        cmd.ExecuteNonQuery()
        Dim adaptre5 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
        Dim data As DataTable = New DataTable
        adaptre5.Fill(data)
        cnn.Close()

        If data.Rows.Count < 1 Then
            If np <> "" Then
                If id > 0 Then
                    If pp1 <> pp2 And pp1 <> pp3 And pp1 <> pp4 And pp2 <> pp3 And pp2 <> pp4 And pp3 <> pp4 Then
                        cnn.Open()
                        'Реадактиране на учителя
                        cmd = New MySqlCommand("UPDATE profiles SET name_profile='" & np & "',pp1 ='" & pp1 & "',pp2 ='" & pp2 & "',pp3='" & pp3 & "',pp4='" & pp4 & "' WHERE profiles.id ='" & id & "';", cnn)
                        cmd.ExecuteNonQuery()
                        ' Презареждане на datagreadveiw
                        Dim brr As Integer
                        brr = 0

                        Dim selectrows1 As DataGridViewRow
                        selectrows1 = dgv1.Rows(index)
                        selectrows1.Cells(1).Value = np
                        selectrows1.Cells(2).Value = cmbpp1R.Text
                        selectrows1.Cells(3).Value = cmbpp2R.Text
                        selectrows1.Cells(4).Value = cmbpp3R.Text
                        selectrows1.Cells(5).Value = cmbpp4R.Text
                        cnn.Close()
                        'Съобщение за успешно въведе предмет
                        MsgBox("Успешно редактиран профил! ! !", , "Въвеждане, изтриване и редактиране на профили")
                    Else
                        MsgBox("Профилиращите предмети трябва да са различни! ! !", , "Въвеждане, изтриване и редактиране на профили")
                    End If
                Else
                    'Съобщение за предмет, който не е въведен
                    MsgBox("Първо добавете профил! ! !", , "Въвеждане, изтриване и редактиране на профили")
                End If
            Else
                MsgBox("Въведете име на профила! ! !", , "Въвеждане, изтриване и редактиране на профили")
            End If
        Else
            MsgBox("Този профил е въведен преди! ! !", , "Въвеждане, изтриване и редактиране на профили")
        End If
    End Sub

 
End Class