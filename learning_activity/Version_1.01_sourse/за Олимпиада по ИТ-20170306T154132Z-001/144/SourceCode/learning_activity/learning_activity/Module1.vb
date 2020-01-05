Imports MySql.Data.MySqlClient
Module Module1
    Dim hostname As String
    Function LogIN(ByVal host As String)
        hostname = host
        Return hostname
    End Function
    Function hosts(ByRef a As MySqlConnection)
        'Connection String за връзка със сървъра    
        a = New MySqlConnection(hostname)
        Try
            a.Open()
            a.Close()
        Catch ex As Exception
            MsgBox("Грешка в базата данни! ! !")
            Application.Exit()
        End Try
        Return a
    End Function
    Function idMax(ByVal database As String, ByRef idM As Integer)
        idM = 0
        Try
            'максимално ID в таблица ( Database )
            Dim cnn As New MySqlConnection
            Call Module1.hosts(cnn)
            Dim reader As MySqlDataReader
            cnn.Open()
            Dim cmd As New MySqlCommand
            cmd = New MySqlCommand("Select max(id) as m from " & database, cnn)
            reader = cmd.ExecuteReader
            Dim rid As Integer
            reader.Read()
            If Not reader.IsDBNull(0) Then
                rid = reader.GetString("m")
            Else
                rid = 0
            End If

            cnn.Close()
            idM = rid + 1

        Catch ex As Exception
            MsgBox("ERROR -  " & ex.Message)
        End Try
        Return idM

    End Function
    Function RazExcel(ByRef razEx As String)
        razEx = "Excel | *.xlsx"
        Return razEx
    End Function
    Function RazWord(ByRef razWo As String)
        razWo = "Word | *.docx"
        Return razWo
    End Function

End Module