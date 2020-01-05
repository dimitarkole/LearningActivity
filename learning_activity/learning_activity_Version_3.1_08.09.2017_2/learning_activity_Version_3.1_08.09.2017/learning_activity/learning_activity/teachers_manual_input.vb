'импортиране на Mysql data
Imports MySql.Data.MySqlClient
Public Class teachers_manual_input
    'деклариране на глобални променливи
    Dim cnn As MySqlConnection = New MySqlConnection
    Dim cmd As MySqlCommand
    Dim id As Integer
    Dim name_t, family_t As String
    Private Sub teachers_manual_input_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Module1.hosts(cnn)
        ' задаване на информация в DataGridView
        Me.TeachersTableAdapter.FillBy(Me.Learning_activityDataSet.teachers)
        ' задаване на индекс за добавяне на нов предмет
        Call Module1.idMax("teachers", id)
        lblIdAdd.Text = id

    End Sub
    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        name_t = txtnameUcitel.Text
        family_t = txtfamiliUcitel.Text
        If name_t <> "" And family_t <> "" Then
            Dim cmd As MySqlCommand
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            'проверка да ли е въведен учител преди
            cmd = New MySqlCommand("Select* from  teachers where name_teacher='" & name_t & "' and family_teacher='" & family_t & "'", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            If data.Rows.Count < 1 Then

                'Въвеждане на учител
                cmd = New MySqlCommand("insert into  teachers (id,name_teacher,family_teacher) values (@id,@name_teacher,@family_teacher);", cnn)
                cmd.Parameters.AddWithValue("@id", lblIdAdd.Text)
                cmd.Parameters.AddWithValue("@name_teacher", name_t)
                cmd.Parameters.AddWithValue("@family_teacher", family_t)
                cmd.ExecuteNonQuery()
                ' Номериране на следващ запис
                id = id + 1
                lblIdAdd.Text = id
                txtfamiliUcitel.Text = ""
                txtnameUcitel.Text = ""

                ' Презареждане на datagreadveiw
                Me.TeachersTableAdapter.FillBy(Me.Learning_activityDataSet.teachers)
                'Съобщение за успешно въведе учител
                MsgBox("Успешно въведен учител! ! !", , "Въвеждане, изтриване и редактиране на учители")
            Else
                'Съобщение за учител, който е въведен
                MsgBox("Този учител вече е въведен! ! !", , "Въвеждане, изтриване и редактиране на учители")
            End If
        Else
            'Съобщение за данни, които не са въведени
            MsgBox("Въведете данни! ! !", , "Въвеждане, изтриване и редактиране на учители")
        End If
    End Sub
    Private Sub btndeletesubject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndeletesubject.Click
        If MsgBox("Сигурни ли сте, че искате да го изтриите?", vbYesNo, "Въвеждане и изтриване на учители") = vbYes Then
            Dim id2 As Integer
            id2 = lblIdDel.Text

            'Викане на функция от модола, в която се пази връзката с сървара
            Call Module1.hosts(cnn)
            Dim cmd As MySqlCommand
            cnn.Open()
            'махане на предмета
            cmd = New MySqlCommand("Delete from  teachers where id='" & id2 & "'", cnn)
            cmd.ExecuteNonQuery()
            ' Презареждане на datagreadveiw
            Me.TeachersTableAdapter.FillBy(Me.Learning_activityDataSet.teachers)
            cnn.Close()
            MsgBox("Успешно изтрит учител! ! !", , "Въвеждане, изтриване и редактиране на учители")
            'проверка за MAX ID
            Call Module1.idMax("teachers", id)
            lblIdAdd.Text = id
        End If

    End Sub
    Private Sub lblIdDel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblIdDel.TextChanged

        Dim idDel As String
        idDel = lblIdDel.Text

        If idDel <> "" Then
            btndeletesubject.Enabled = True
        Else
            btndeletesubject.Enabled = False
        End If
    End Sub
    Private Sub FillByToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.TeachersTableAdapter.FillBy(Me.Learning_activityDataSet.teachers)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub btnRedakchia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRedakchia.Click
        Dim nameTeach, familyTeach As String
        id = НомерLabel1.Text
        nameTeach = Име_на_учителяTextBox.Text
        familyTeach = Фамилия_на_учителяTextBox.Text

        'проверка за "" в полето
        If nameTeach <> "" Or familyTeach <> "" Then
            If id > 0 Then
                Dim cmd As MySqlCommand
                Call Module1.hosts(cnn)
                cnn.Open()
                'проверка да ли е въведен учител преди
                cmd = New MySqlCommand("Select* from  teachers where name_teacher='" & nameTeach & "' and family_teacher='" & familyTeach & "' and id<>'" & id & "'", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim data As DataTable = New DataTable
                adaptre.Fill(data)
                If data.Rows.Count < 1 Then
                    'Реадактиране на учителя
                    cmd = New MySqlCommand("UPDATE teachers SET name_teacher='" & nameTeach & "',family_teacher='" & familyTeach & "' WHERE teachers.id ='" & id & "';", cnn)
                    cmd.ExecuteNonQuery()
                    ' Презареждане на datagreadveiw
                    Me.TeachersTableAdapter.FillBy(Me.Learning_activityDataSet.teachers)
                    'Съобщение за успешно въведе предмет
                    MsgBox("Успешно редактиран учител! ! !", , "Въвеждане, изтриване и редактиране на учители")
                Else
                    'Съобщение за учител, който е въведен
                    MsgBox("Този учител вече е въведен! ! !", , "Въвеждане, изтриване и редактиране на учители")
                    TeachersBindingSource.CancelEdit()
                End If

                cnn.Close()
            Else
                'Съобщение за предмет, който не е въведен
                MsgBox("Първо добавете учители! ! !", , "Въвеждане, изтриване и редактиране на учители")
            End If
        Else
            MsgBox("Въведете име и фамилия на редактирания учител! ! !", , "Въвеждане, изтриване и редактиране на учители")
        End If
    End Sub
End Class