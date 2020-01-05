Imports MySql.Data.MySqlClient
Public Class type_manual_input
    'деклариране на глобални променливи
    Dim cnn As MySqlConnection = New MySqlConnection
    Dim cmd As MySqlCommand
    Dim id As Integer
    Private Sub type_manual_input_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Learning_activityDataSet.types' table. You can move, or remove it, as needed.
        Me.TypesTableAdapter.FillBy(Me.Learning_activityDataSet.types)
        ' задаване на индекс за добавяне на нов предмет
        Call Module1.idMax("types", id)
        Call Module1.hosts(cnn)
        lblid.Text = id
    End Sub
    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Dim name_t As String
        id = lblid.Text
        name_t = txttypeUp.Text
        'проверка за въведен "" в полето
        If name_t <> "" Then
            Call Module1.hosts(cnn)
            cnn.Open()
            'проверка да ли е въведен вида оценка преди
            cmd = New MySqlCommand("Select* from  types where name_type='" & name_t & "'", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            If data.Rows.Count < 1 Then
                'Въвеждане на вида оценка
                cmd = New MySqlCommand("insert into  types (id,name_type) values (@id,@name_type);", cnn)
                cmd.Parameters.AddWithValue("@id", id)
                cmd.Parameters.AddWithValue("@name_type", name_t)
                cmd.ExecuteNonQuery()
                ' Номериране на следващ запис
                id = id + 1
                lblid.Text = id
                txttypeUp.Text = ""

                'TODO: This line of code loads data into the 'Learning_activityDataSet.types' table. You can move, or remove it, as needed.
                Me.TypesTableAdapter.FillBy(Me.Learning_activityDataSet.types)

                'Съобщение за успешно въведе вид оценка
                MsgBox("Успешно въведен вид оценка! ! !", , "Въвеждане, изтриване и редактиране на видове оценки")
            Else
                'Съобщение за оценка, който е въведен
                MsgBox("Този вид оценка вече е въведен! ! !", , "Въвеждане, изтриване и редактиране на видове оценки")
            End If
            cnn.Close()
        Else
            'Съобщение за въд оценка, който не е въведен
            MsgBox("Въведете вид на оценката! ! !", , "Въвеждане, изтриване и редактиране на видове оценки")
        End If
    End Sub
    Private Sub btndeletesubject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndeletesubject.Click
        If MsgBox("Сигурни ли сте, че искате да го изтриите?", vbYesNo, "Въвеждане, изтриване и редактиране на видове оценки") = vbYes Then
            Dim name_subject2 As String
            Dim id2 As Integer
            id2 = lblIdDel.Text

            name_subject2 = lbltypeDel.Text
            'Викане на функция от модола, в която се пази връзката с сървара
            Call Module1.hosts(cnn)
            Dim cmd As MySqlCommand
            cnn.Open()
            'махане на предмета
            cmd = New MySqlCommand("Delete from  types where id='" & id2 & "'", cnn)
            cmd.ExecuteNonQuery()
            Me.TypesTableAdapter.FillBy(Me.Learning_activityDataSet.types)
            MsgBox("Успешно изтрит вид оценка! ! !", , "Въвеждане, изтриване и редактиране на видове оценки")
            cnn.Close()
            'проверка за MAX ID
            Call Module1.idMax("types", id)
            lblid.Text = id
        End If
    End Sub
    Private Sub lblIdDel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblIdDel.TextChanged
        If lblIdDel.Text <> "" Then
            btndeletesubject.Enabled = True
        Else
            btndeletesubject.Enabled = False
        End If
    End Sub
    Private Sub FillByToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.TypesTableAdapter.FillBy(Me.Learning_activityDataSet.types)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub btnR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnR.Click
        If txtTR.Text <> "" Then
            If lblikdR.Text <> """" Then
                Dim id As Integer
                Dim t As String
                t = txtTR.Text
                id = lblikdR.Text
                Try
                    cnn.Open()
                    cnn.Close()
                Catch ex As Exception
                    MsgBox("Грешка в базата данни! ! !")
                    Application.Exit()
                End Try
                cnn.Open()
                'проверка да ли е въведен учител преди
                cmd = New MySqlCommand("Select* from  types where name_type='" & t & "' and id<>'" & id & "'", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim data As DataTable = New DataTable
                adaptre.Fill(data)
                If data.Rows.Count < 1 Then
                    'Реадактиране на учителя
                    cmd = New MySqlCommand("UPDATE types SET name_type ='" & t & "'WHERE types.id ='" & id & "';", cnn)
                    cmd.ExecuteNonQuery()
                    ' Презареждане на datagreadveiw
                    Me.TypesTableAdapter.FillBy(Me.Learning_activityDataSet.types)
                    'Съобщение за успешно въведе предмет
                    MsgBox("Успешно редактиран вид на оценка! ! !", , "Въвеждане, изтриване и редактиране на видове оценки")
                Else
                    'Съобщение за учител, който е въведен
                    MsgBox("Този вид на оценка вече е въведен! ! !", , "Въвеждане, изтриване и редактиране на видове оценки")
                    TypesBindingSource.CancelEdit()
                End If
                cnn.Close()
            Else
                'Съобщение за въд оценка, който не е въведен
                MsgBox("Първо добавете вид на оценката! ! !", , "Въвеждане, изтриване и редактиране на видове оценки")
            End If
        Else
            'Съобщение за въд оценка, който не е въведен
            MsgBox("Въведете вид на оценката! ! !", , "Въвеждане, изтриване и редактиране на видове оценки")
        End If
    End Sub

End Class