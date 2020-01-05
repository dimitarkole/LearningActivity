Imports MySql.Data.MySqlClient
Public Class Form1
    'ДАННИ
    Private Sub РъчноToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles РъчноToolStripMenuItem.Click, УроциToolStripMenuItem.Click
        'предмет
        subject_manual_input.ShowDialog()
    End Sub
    Private Sub РъчноToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles РъчноToolStripMenuItem1.Click, УчителиToolStripMenuItem.Click
        'учители
        teachers_manual_input.ShowDialog()
    End Sub
    Private Sub РъчноToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles РъчноToolStripMenuItem2.Click, ПрофилиToolStripMenuItem.Click
        'профили
        Profile_manual_input.ShowDialog()
    End Sub
    Private Sub РъчноToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles РъчноToolStripMenuItem3.Click, КласовеToolStripMenuItem.Click
        'класове
        classes_manual_input.ShowDialog()
    End Sub
    Private Sub РъчноToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles РъчноToolStripMenuItem4.Click, ПреподавателиНаКласоветеToolStripMenuItem.Click
        'преподаватели не класовете
        teachering_manual_input.ShowDialog()
    End Sub
    Private Sub РъчноToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles РъчноToolStripMenuItem5.Click, ОценкиToolStripMenuItem.Click
        'видове оценки
        type_manual_input.ShowDialog()
    End Sub
    Private Sub РъчноToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles РъчноToolStripMenuItem6.Click, ОценкиToolStripMenuItem1.Click
        'оценки
        purpose_manual_input.ShowDialog()
    End Sub
    Private Sub РъчноToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles РъчноToolStripMenuItem7.Click, ОтсъствияToolStripMenuItem.Click
        'отсъсвия
        absence_manual_input.ShowDialog()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        '' Dim hostname As String = "server=localhost;user id=root; password=;database=learning_activity;charset=utf8"
        ''Call Module1.LogIN(hostname)
        Log_in.ShowDialog()
    End Sub


    'Спавки
    Private Sub СреденУспехПоПаралелкиToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles СреденУспехПоПаралелкиToolStripMenuItem.Click
        'Среден успех по паралелки
        reference_GPA_Clasess.ShowDialog()
    End Sub

    Private Sub СъотношениеНаОценкитеПоБройВсичкиПаралелкиToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles СъотношениеНаОценкитеПоБройВсичкиПаралелкиToolStripMenuItem.Click
        'Съотношение на оценките по брой (Всички паралелки)
        reference_VA_classes.ShowDialog()
    End Sub

    Private Sub ОтсъствияПоПаралелкиToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ОтсъствияПоПаралелкиToolStripMenuItem.Click
        'Отсъствия по паралелки
        reference_Absences_Classes.Show()
    End Sub

    Private Sub СъотношениеНаОтсъствиятаПоБройВсичкиПаралелкиToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles СъотношениеНаОтсъствиятаПоБройВсичкиПаралелкиToolStripMenuItem.Click
        'Съотношение на отсъствията по брой (Всички паралелки)
        reference_absence_Va_Classes.ShowDialog()
    End Sub

    Private Sub СреденУспехПоКласовеToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles СреденУспехПоКласовеToolStripMenuItem.Click
        'Среден успех по класове
        Reference_GPA_Vipusk.ShowDialog()
    End Sub

    Private Sub СъотношениеНаОценкитеПоБройПаралелкитеОтЕдинКласToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles СъотношениеНаОценкитеПоБройПаралелкитеОтЕдинКласToolStripMenuItem.Click
        'Съотношение на оценките по брой (Паралелките от един клас)
        Reference_VA_Vipusk.ShowDialog()
    End Sub

    Private Sub ОтсъствияПоКласовеToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ОтсъствияПоКласовеToolStripMenuItem.Click
        'Отсъствия по класове
        reference_absecnce_vipusk.ShowDialog()
    End Sub

    Private Sub СъотношениеНаОтсъствиятаПоБройПаралелкитеОтЕдинКласToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles СъотношениеНаОтсъствиятаПоБройПаралелкитеОтЕдинКласToolStripMenuItem.Click
        'Съотношение на отсъствията по брой (Паралелките от един клас)
        reference_absence_va_Vipusk.ShowDialog()
    End Sub

    Private Sub УспехПоПаралелкиЗа2ГодиниToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles УспехПоПаралелкиЗа2ГодиниToolStripMenuItem.Click
        'Успех по паралелки за 2 години
        Reference_Year_Classes.ShowDialog()
    End Sub

    Private Sub СъотношениеНаОценкитеПоБройЗа2ГодиниВсичкиПаралелкиToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles СъотношениеНаОценкитеПоБройЗа2ГодиниВсичкиПаралелкиToolStripMenuItem.Click
        ' Съотношение на оценките по брой за 2 години (Всички паралелки)
        Reference_Va_Year_Clases.ShowDialog()
    End Sub

    Private Sub УспехПоКласовеToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles УспехПоКласовеToolStripMenuItem.Click
        'Успех по класове за 2 години
        Reference_Years_Vipusk.ShowDialog()
    End Sub

    Private Sub СъотношениеНаОценкитеПоБройЗа2ГодиниПаралелкитеОтЕдинКласToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles СъотношениеНаОценкитеПоБройЗа2ГодиниПаралелкитеОтЕдинКласToolStripMenuItem.Click
        'Съотношение на оценките по брой за 2 години (Паралелките от един клас)
        Reference_VA_Year_Vipusk.ShowDialog()
    End Sub

    Private Sub ПаралелкитеПрезГодинитеToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ПаралелкитеПрезГодинитеToolStripMenuItem.Click
        'Паралелките през годините
        Reference_Classes_Over_Years.ShowDialog()
    End Sub

    Private Sub СъотношениеНаОценкитеПоБройПрезГодинитеВсичкиПаралелкиToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles СъотношениеНаОценкитеПоБройПрезГодинитеВсичкиПаралелкиToolStripMenuItem.Click
        'Съотношение на оценките по брой през годините (Всички паралелки)
        Reference_Va_Classes_Over_Years.ShowDialog()
    End Sub

    Private Sub КласоветеПрезГодинитеToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles КласоветеПрезГодинитеToolStripMenuItem.Click
        'Класовете през годините
        reference_Vipusk_Over_Years.ShowDialog()
    End Sub

    Private Sub СъотношениеНаОценкитеПоБройПрезГодинитеПаралелкитеОтЕдинКласToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles СъотношениеНаОценкитеПоБройПрезГодинитеПаралелкитеОтЕдинКласToolStripMenuItem.Click
        'Съотношение на оценките по брой през годините (Паралелките от един клас)
        Reference_Va_Year_Over_Vipusk.ShowDialog()

    End Sub





    Private Sub ЗаПрограматаToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ЗаПрограматаToolStripMenuItem.Click
        about.ShowDialog()
    End Sub

    Private Sub ПомощToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ПомощToolStripMenuItem1.Click
        Dim pat As String = "helpHTML\HelpHTML.chm"
        Process.Start(pat)
    End Sub

    Private Sub УниверсалниСправкиToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles УниверсалниСправкиToolStripMenuItem.Click
        'Универсална справка за среден успех през една година
        reference_universa_gpa.ShowDialog()
    End Sub
End Class
