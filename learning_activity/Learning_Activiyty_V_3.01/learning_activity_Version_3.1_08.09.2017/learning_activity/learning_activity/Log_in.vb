Imports MySql.Data.MySqlClient
Public Class Log_in
    Dim flagloadbaza As Integer = 0
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cnn As MySqlConnection
        cnn = New MySqlConnection("server=localhost;user id='" & txtUser.Text & "'; password='" & txtPass.Text & "';charset=utf8")
        Dim flag As Integer = 0
        Try
            cnn.Open()
            cnn.Close()
            flag = 1
            Dim hostname As String = "server=localhost;user id='" & txtUser.Text & "'; password='" & txtPass.Text & "';database=learning_activity;charset=utf8"
            Call Module1.LogIN(hostname)
        Catch ex As Exception
            MsgBox("Нямате достъп до базата данни! ! !")
        End Try
        If flag = 1 Then
            flagloadbaza = 1
            txtPass.Enabled = False
            txtUser.Enabled = False
            Button1.Enabled = False
            Me.Height = 220
            Dim cmd As MySqlCommand
            'Call Module1.hosts(cnn)
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Трябва да стартирате wampserver! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            Dim dbname As String = "learning_activity"
            cmd = New MySqlCommand("Show databases like '" & dbname & "';", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            If data.Rows.Count = 0 Then
                cmd = New MySqlCommand("CREATE DATABASE " & dbname & ";", cnn)
                cmd.ExecuteNonQuery()
            End If
            prb1.Maximum = 29
            prb1.Value = 0
            cnn.Close()
            cnn = New MySqlConnection("server=localhost;user id=root; password=;database= " & dbname & ";charset=utf8")
            cnn.Open()
            Try
                cmd = New MySqlCommand("CREATE TABLE `absence` ( `id` int(10) UNSIGNED NOT NULL, `class` int(11) UNSIGNED NOT NULL, `count_excused` decimal(10,2) UNSIGNED NOT NULL, `count_unexcused` decimal(10,2) UNSIGNED NOT NULL, `time` enum('Първи срок','Годишни') NOT NULL ) ENGINE=InnoDB DEFAULT CHARSET=utf8", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 1
            Try
                cmd = New MySqlCommand("CREATE TABLE `classes` ( `id` int(10) UNSIGNED NOT NULL, `school_year` int(4) NOT NULL, `grade` tinyint(3) UNSIGNED NOT NULL, `class` char(1) NOT NULL, `profile` int(10) UNSIGNED NOT NULL, `students` tinyint(3) UNSIGNED NOT NULL ) ENGINE=InnoDB DEFAULT CHARSET=utf8", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 2
            Try
                cmd = New MySqlCommand("CREATE TABLE `profiles` ( `id` int(10) UNSIGNED ZEROFILL NOT NULL, `name_profile` varchar(30) CHARACTER SET utf8mb4 NOT NULL, `pp1` int(10) UNSIGNED NOT NULL, `pp2` int(10) UNSIGNED NOT NULL, `pp3` int(10) UNSIGNED NOT NULL, `pp4` int(10) UNSIGNED NOT NULL ) ENGINE=InnoDB DEFAULT CHARSET=utf8", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 3
            Try
                cmd = New MySqlCommand("CREATE TABLE `purpose` ( `id` int(10) UNSIGNED NOT NULL, `class` int(10) UNSIGNED NOT NULL, `subject` int(10) UNSIGNED NOT NULL, `type` int(10) UNSIGNED NOT NULL, `count_2` tinyint(3) UNSIGNED NOT NULL, `count_3` tinyint(3) UNSIGNED NOT NULL, `count_4` tinyint(3) UNSIGNED NOT NULL, `count_5` tinyint(3) UNSIGNED NOT NULL, `count_6` tinyint(3) UNSIGNED NOT NULL ) ENGINE=InnoDB DEFAULT CHARSET=utf8", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 4
            Try
                cmd = New MySqlCommand("CREATE TABLE `subject` ( `id` int(10) UNSIGNED NOT NULL, `name_subject` varchar(35) NOT NULL , `number` int(10) NOT NULL ) ENGINE=InnoDB DEFAULT CHARSET=utf8", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 5
            Try
                cmd = New MySqlCommand("CREATE TABLE `teachers` ( `id` int(10) UNSIGNED NOT NULL, `name_teacher` varchar(15) NOT NULL, `family_teacher` varchar(30) NOT NULL ) ENGINE=InnoDB DEFAULT CHARSET=utf8", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 6
            Try
                cmd = New MySqlCommand("CREATE TABLE `teaching` ( `id` int(10) UNSIGNED NOT NULL, `class` int(10) UNSIGNED NOT NULL, `subject` int(10) UNSIGNED NOT NULL, `teacher` int(10) UNSIGNED NOT NULL, `workload` mediumint(8) UNSIGNED NOT NULL ) ENGINE=InnoDB DEFAULT CHARSET=utf8", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 7
            Try
                cmd = New MySqlCommand("CREATE TABLE `types` ( `id` int(10) UNSIGNED NOT NULL, `name_type` varchar(25) NOT NULL ) ENGINE=InnoDB DEFAULT CHARSET=utf8", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 8
            Try
                cmd = New MySqlCommand("ALTER TABLE `absence` ADD PRIMARY KEY (`id`), ADD KEY `class` (`class`)", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 9
            Try
                cmd = New MySqlCommand("ALTER TABLE `classes` ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `id` (`id`), ADD KEY `profile` (`profile`)", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 10
            Try
                cmd = New MySqlCommand("ALTER TABLE `profiles` ADD PRIMARY KEY (`id`), ADD KEY `pp1` (`pp1`) USING BTREE, ADD KEY `pp2` (`pp2`) USING BTREE, ADD KEY `pp3` (`pp3`), ADD KEY `pp4` (`pp4`), ADD KEY `name_profile` (`name_profile`) USING BTREE", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 11
            Try
                cmd = New MySqlCommand("ALTER TABLE `purpose` ADD PRIMARY KEY (`id`), ADD KEY `class` (`class`), ADD KEY `subject` (`subject`), ADD KEY `type` (`type`)", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 12
            Try
                cmd = New MySqlCommand("ALTER TABLE `subject` ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `name_subject` (`name_subject`) USING BTREE", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 13
            Try
                cmd = New MySqlCommand("ALTER TABLE `teachers` ADD PRIMARY KEY (`id`), ADD KEY `family_teacher` (`family_teacher`)", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 14
            Try
                cmd = New MySqlCommand("ALTER TABLE `teaching` ADD PRIMARY KEY (`id`), ADD KEY `class` (`class`), ADD KEY `subject` (`subject`), ADD KEY `teacher` (`teacher`)", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 15
            Try
                cmd = New MySqlCommand("ALTER TABLE `types` ADD PRIMARY KEY (`id`)", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 16
            Try
                cmd = New MySqlCommand("ALTER TABLE `absence` MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 17
            Try
                cmd = New MySqlCommand("ALTER TABLE `classes` MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 18
            Try
                cmd = New MySqlCommand("ALTER TABLE `profiles` MODIFY `id` int(10) UNSIGNED ZEROFILL NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 19
            Try
                cmd = New MySqlCommand("ALTER TABLE `purpose` MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=156", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 20
            Try
                cmd = New MySqlCommand("ALTER TABLE `subject` MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 21
            Try
                cmd = New MySqlCommand("ALTER TABLE `teachers` MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 22
            Try
                cmd = New MySqlCommand("ALTER TABLE `teaching` MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 23
            Try
                cmd = New MySqlCommand("ALTER TABLE `types` MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 24
            Try
                cmd = New MySqlCommand("ALTER TABLE `absence` ADD CONSTRAINT `absence@x0_ibfk_1` FOREIGN KEY (`class`) REFERENCES `classes` (`id`) ON DELETE CASCADE ON UPDATE CASCADE", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 25
            Try
                cmd = New MySqlCommand("ALTER TABLE `classes` ADD CONSTRAINT `classes_ibfk_1` FOREIGN KEY (`profile`) REFERENCES `profiles` (`id`) ON DELETE CASCADE ON UPDATE CASCADE", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 26
            Try
                cmd = New MySqlCommand("ALTER TABLE `profiles` ADD CONSTRAINT `profiles_ibfk_1` FOREIGN KEY (`pp1`) REFERENCES `subject` (`id`) ON DELETE CASCADE ON UPDATE CASCADE, ADD CONSTRAINT `profiles_ibfk_2` FOREIGN KEY (`pp2`) REFERENCES `subject` (`id`) ON DELETE CASCADE ON UPDATE CASCADE, ADD CONSTRAINT `profiles_ibfk_3` FOREIGN KEY (`pp3`) REFERENCES `subject` (`id`) ON DELETE CASCADE ON UPDATE CASCADE, ADD CONSTRAINT `profiles_ibfk_4` FOREIGN KEY (`pp4`) REFERENCES `subject` (`id`) ON DELETE CASCADE ON UPDATE CASCADE", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 27
            Try
                cmd = New MySqlCommand("ALTER TABLE `purpose` ADD CONSTRAINT `purpose_ibfk_1` FOREIGN KEY (`class`) REFERENCES `classes` (`id`) ON DELETE CASCADE ON UPDATE CASCADE, ADD CONSTRAINT `purpose_ibfk_2` FOREIGN KEY (`subject`) REFERENCES `subject` (`id`) ON DELETE CASCADE ON UPDATE CASCADE, ADD CONSTRAINT `purpose_ibfk_3` FOREIGN KEY (`type`) REFERENCES `types` (`id`) ON DELETE CASCADE ON UPDATE CASCADE", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            prb1.Value = 28
            Try
                cmd = New MySqlCommand("ALTER TABLE `teaching` ADD CONSTRAINT `teaching_ibfk_1` FOREIGN KEY (`class`) REFERENCES `classes` (`id`) ON DELETE CASCADE ON UPDATE CASCADE, ADD CONSTRAINT `teaching_ibfk_2` FOREIGN KEY (`subject`) REFERENCES `subject` (`id`) ON DELETE CASCADE ON UPDATE CASCADE, ADD CONSTRAINT `teaching_ibfk_3` FOREIGN KEY (`teacher`) REFERENCES `teachers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE", cnn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            cnn.Close()
            prb1.Value = 29
            Me.Close()
        End If

    End Sub

    Private Sub Log_in_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If flagloadbaza = 0 Then
            Application.Exit()
        End If
    End Sub
End Class