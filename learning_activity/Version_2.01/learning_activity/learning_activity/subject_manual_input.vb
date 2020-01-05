'импортиране на Mysql data
Imports MySql.Data.MySqlClient
Public Class subject_manual_input
    'деклариране на глобални променливи
    Dim cnn As MySqlConnection = New MySqlConnection
    Dim cmd As MySqlCommand
    Dim id As Integer
    Private Sub subject_manual_input_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' задаване на информация в DataGridView
        Me.SubjectTableAdapter.FillBy(Me.Learning_activityDataSet.subject)
        ' задаване на индекс за добавяне на нов предмет
        Call Module1.idMax("subject", id)
        lblid.Text = id
    End Sub
    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Dim name_subject As String
        id = lblid.Text
        name_subject = Name_subjectTextBox.Text
        'проверка за "" в полето
        If name_subject <> "" Then
            Call Module1.hosts(cnn)
            cnn.Open()
            'проверка да ли е въведен предмета преди
            cmd = New MySqlCommand("Select* from  subject where name_subject='" & name_subject & "'", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            If data.Rows.Count < 1 Then
                'Въвеждане на предмета
                cmd = New MySqlCommand("insert into  subject (id,name_subject) values (@id,@name_subject);", cnn)
                cmd.Parameters.AddWithValue("@id", id)
                cmd.Parameters.AddWithValue("@name_subject", name_subject)
                cmd.ExecuteNonQuery()
                ' Номериране на следващ запис
                id = id + 1
                lblid.Text = id
                Name_subjectTextBox.Text = ""
                ' Презареждане на datagreadveiw
                Me.SubjectTableAdapter.FillBy(Me.Learning_activityDataSet.subject)
                'Съобщение за успешно въведе предмет
                MsgBox("Успешно въведен предмет! ! !", , "Въвеждане, изтриване и редактиране на предмети")
            Else
                'Съобщение за предмет, който е въведен
                MsgBox("Този предмет вече е въведен! ! !", , "Въвеждане, изтриване и редактиране на предмети")
            End If
            cnn.Close()
        Else
            'Съобщение за предмет, който не е въведен
            MsgBox("Въведете предмет! ! !", , "Въвеждане, изтриване и редактиране на предмети")
        End If

    End Sub
    Private Sub btndeletesubject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndeletesubject.Click
        If MsgBox("Сигурни ли сте, че искате да го изтриите?", vbYesNo, "Въвеждане и изтриване на предмети") = vbYes Then
            Dim name_subject2 As String
            Dim id2 As Integer
            id2 = lbliddel.Text

            name_subject2 = Name_subjectLabel2.Text
            'Викане на функция от модола, в която се пази връзката с сървара
            Call Module1.hosts(cnn)
            Dim cmd As MySqlCommand
            cnn.Open()
            'махане на предмета
            cmd = New MySqlCommand("Delete from  subject where id='" & id2 & "'", cnn)
            cmd.ExecuteNonQuery()
            Me.SubjectTableAdapter.FillBy(Me.Learning_activityDataSet.subject)
            MsgBox("Успешно изтрит предмет! ! !", , "Въвеждане, изтриване и редактиране на предмети")
            cnn.Close()
            'проверка за MAX ID
            Call Module1.idMax("subject", id)
            lblid.Text = id

        End If
    End Sub

    Private Sub FillByToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.SubjectTableAdapter.FillBy(Me.Learning_activityDataSet.subject)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub idLeble_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbliddel.TextChanged
        If lbliddel.Text <> "" Then
            btndeletesubject.Enabled = True
        Else
            btndeletesubject.Enabled = False
        End If
    End Sub
    Private Sub FillByToolStripButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.SubjectTableAdapter.FillBy(Me.Learning_activityDataSet.subject)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub btnRedakchia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRedakchia.Click
        Dim name_subject As String
        id = НомерLabel1.Text
        name_subject = Име_на_предметаTextBox.Text
        'проверка за "" в полето
        If name_subject <> "" Then
            If id > 0 Then
                Call Module1.hosts(cnn)
                cnn.Open()
                'проверка да ли е въведен предмета преди
                cmd = New MySqlCommand("Select* from  subject where name_subject='" & name_subject & "' and id<>'" & id & "'", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim data As DataTable = New DataTable
                adaptre.Fill(data)
                If data.Rows.Count < 1 Then
                    ''Реадактиране на предмета
                    cmd = New MySqlCommand("UPDATE subject SET name_subject = '" & Име_на_предметаTextBox.Text & "' WHERE subject.id= '" & НомерLabel1.Text & "';", cnn)
                    cmd.Parameters.AddWithValue("@name_subject", name_subject)
                    cmd.ExecuteNonQuery()
                    ' Презареждане на datagreadveiw
                    Me.SubjectTableAdapter.FillBy(Me.Learning_activityDataSet.subject)
                    'Съобщение за успешно въведе предмет
                    MsgBox("Успешно редактиран предмет! ! !", , "Въвеждане, изтриване и редактиране на предмети")
                Else
                    'Съобщение за предмет, който е въведен
                    MsgBox("Този предмет вече е въведен! ! !", , "Въвеждане, изтриване и редактиране на предмети")
                    SubjectBindingSource.CancelEdit()
                End If
                cnn.Close()
            Else
                'Съобщение за предмет, който не е въведен
                MsgBox("Първо добавете предмет! ! !", , "Въвеждане, изтриване и редактиране на предмети")
            End If
        Else
            MsgBox("Въведете име на редактирания предмет! ! !", , "Въвеждане, изтриване и редактиране на предмети")

        End If
    End Sub

    Private Sub Име_на_предметаTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Име_на_предметаTextBox.TextChanged

    End Sub
End Class