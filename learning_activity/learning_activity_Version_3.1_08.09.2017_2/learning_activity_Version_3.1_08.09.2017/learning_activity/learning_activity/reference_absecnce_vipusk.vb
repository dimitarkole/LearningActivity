Imports MySql.Data.MySqlClient
Public Class reference_absecnce_vipusk
    'деклариране на глобални променливи
    Dim cnn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim years, title1, title2, flagbtn As String
    Dim a, b, RRowsCount As Integer
    Private Sub reference_absecnce_vipusk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Отваряне на връската със SURVER
        Call Module1.hosts(cnn)
        cnn.Open()
        Dim brRows, flag As Integer
        brRows = 0
        title1 = "Справка"
        cmd = New MySqlCommand("Select* from  classes order by school_year desc, grade desc", cnn)
        cmd.ExecuteNonQuery()
        Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
        Dim data As DataTable = New DataTable
        adaptre.Fill(data)
        'Проверка дaли в таблица purpose има записи
        If data.Rows.Count > 0 Then
            'ако има записи
            Dim classesPodr(data.Rows.Count, 2) As Integer
            Dim years, grade As Integer
            brRows = 0
            For i As Integer = 1 To data.Rows.Count
                classesPodr(i - 1, 1) = 0
                classesPodr(i - 1, 2) = 0
            Next
            'минаване през всчики редове на таблица purpose
            For i As Integer = 1 To data.Rows.Count
                'Селактиране на номера на класа на ред
                grade = data.Rows(i - 1).Item("grade")
                years = data.Rows(i - 1).Item("school_year")
                flag = 0
                For j As Integer = 0 To data.Rows.Count
                    If classesPodr(j, 1) = grade And classesPodr(j, 2) = years Then
                        flag = 1
                        j = data.Rows.Count - 1
                    End If
                Next

                If flag = 0 Then
                    classesPodr(brRows, 1) = grade
                    classesPodr(brRows, 2) = years
                    brRows = brRows + 1
                End If
            Next
            brRows = 0
            Dim yeardo As String
            Do While classesPodr(brRows, 1) <> 0
                grade = classesPodr(brRows, 1)
                years = classesPodr(brRows, 2)
                yeardo = years & "/" & years Mod 100 + 1
                Dim fdouble As Integer = 0
                For i As Integer = 0 To cmbYear.Items.Count - 1
                    If cmbYear.Items(i) = years Then
                        fdouble = 1
                        Exit For
                    End If
                Next

                If fdouble = 0 Then
                    cmbYear.Items.Add(years)
                End If

                fdouble = 0
                For i As Integer = 0 To cmbYearString.Items.Count - 1
                    If cmbYearString.Items(i) = yeardo Then
                        fdouble = 1
                        Exit For
                    End If
                Next
                If fdouble = 0 Then
                    cmbYearString.Items.Add(yeardo)
                End If

                fdouble = 0
                For i As Integer = 0 To cmbClass.Items.Count - 1
                    If cmbClass.Items(i) = grade Then
                        fdouble = 1
                        Exit For
                    End If
                Next
                If fdouble = 0 Then
                    cmbClass.Items.Add(grade)
                End If
                brRows = brRows + 1
            Loop
            'задаване на текст на cmbtaта
            cmbYearString.Text = cmbYearString.Items(0)
            cmbClass.Text = cmbClass.Items(0)
            cmbYear.Text = cmbYear.Items(0)
            'търсене на оценките на випуска
            grade = cmbClass.Text
            years = cmbYear.Text
            Dim scom As String
            Dim brrows2 As Integer = 0
            brRows = 0
            Dim idclass As Integer
            'обхождане на оценките на випуска
            'записване на стойности в dgv1

            scom = "Select* from  classes where school_year='" & years & "' and grade='" & grade & "'"

            cmd = New MySqlCommand(scom, cnn)
            cmd.ExecuteNonQuery()
            Dim adap As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data1 As DataTable = New DataTable
            adap.Fill(data1)
            Dim ci, cni As Double
            Dim id As Integer
            Dim classes, time As String

            For i As Integer = 0 To data1.Rows.Count - 1
                idclass = data1.Rows(i).Item("id")
                classes = data1.Rows(i).Item("class")
                grade = data1.Rows(i).Item("grade")
                classes = grade & " " & classes

                cmd = New MySqlCommand("Select* from  absence where class='" & idclass & "'and time=1", cnn)
                cmd.ExecuteNonQuery()
                Dim adap2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim data2 As DataTable = New DataTable
                adap2.Fill(data2)
                For j As Integer = 0 To data2.Rows.Count - 1
                    ci = data2.Rows(j).Item("count_excused")
                    cni = data2.Rows(j).Item("count_unexcused")
                    id = data2.Rows(j).Item("id")
                    time = data2.Rows(j).Item("time")
                    'писане в dgv1
                    dgv1.Rows.Add(id, classes, ci, cni, time)
                Next

            Next
        End If
        cnn.Close()
    End Sub

    Private Sub cmbVipusk_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (cmbYearString.SelectedIndex = -1) Then
            cmbYearString.Text = cmbYearString.Items(0)
            cmbYearString.Focus()
        Else
            'изтриване на старите сойности в dgv1
            Do While dgv1.RowCount > 0
                dgv1.Rows.Remove(dgv1.Rows(0))
            Loop
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            'Проверка дaли в таблица purpose има записи
            Dim years, grade As Integer
            'задаване на текст на cmbtaта
            cmbClass.Text = cmbClass.Items(cmbYearString.SelectedIndex)
            cmbYear.Text = cmbYear.Items(cmbYearString.SelectedIndex)
            cmbsrok.Text = cmbsrok.Items(0)
            'търсене на оценките на випуска
            grade = cmbClass.Text
            years = cmbYear.Text
            Dim scom As String
            Dim idclass As Integer
            'обхождане на оценките на випуска
            'записване на стойности в dgv1
            scom = "Select* from  classes where school_year='" & years & "' and grade='" & grade & "'"
            cmd = New MySqlCommand(scom, cnn)
            cmd.ExecuteNonQuery()
            Dim adap As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data1 As DataTable = New DataTable
            adap.Fill(data1)
            If data1.Rows.Count > 0 Then
                Dim ci, cni As Double
                Dim id As Integer
                Dim classes, time As String
                For i As Integer = 0 To data1.Rows.Count - 1
                    idclass = data1.Rows(i).Item("id")
                    classes = data1.Rows(i).Item("class")
                    grade = data1.Rows(i).Item("grade")
                    years = data1.Rows(i).Item("school_year")
                    classes = grade & " " & classes

                    cmd = New MySqlCommand("Select* from  absence where class='" & idclass & "'and time=1", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adap2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim data2 As DataTable = New DataTable
                    adap2.Fill(data2)
                    For j As Integer = 0 To data2.Rows.Count - 1
                        ci = data2.Rows(j).Item("count_excused")
                        cni = data2.Rows(j).Item("count_unexcused")
                        id = data2.Rows(j).Item("id")
                        time = data2.Rows(j).Item("time")
                        'писане в dgv1
                        dgv1.Rows.Add(id, classes, ci, cni, time)
                    Next

                Next
            End If
            cnn.Close()
        End If
    End Sub

    Private Sub cmbsrok_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsrok.Leave, cmbsrok.DropDownClosed
        If (cmbsrok.SelectedIndex = -1) Then
            cmbsrok.Text = cmbsrok.Items(0)
            cmbsrok.Focus()
        Else
            'изтриване на старите сойности в dgv1
            Do While dgv1.RowCount > 0
                dgv1.Rows.Remove(dgv1.Rows(0))
            Loop
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            'Проверка дaли в таблица purpose има записи
            Dim years, grade As Integer
            'задаване на текст на cmbtaта
            cmbsrokid.Text = cmbsrokid.Items(cmbsrok.SelectedIndex)
            'търсене на оценките на випуска
            grade = cmbClass.Text
            years = cmbYear.Text
            Dim scom As String
            Dim idclass As Integer
            'обхождане на оценките на випуска
            'записване на стойности в dgv1
            scom = "Select* from  classes where school_year='" & years & "' and grade='" & grade & "'"
            cmd = New MySqlCommand(scom, cnn)
            cmd.ExecuteNonQuery()
            Dim adap As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data1 As DataTable = New DataTable
            adap.Fill(data1)
            If data1.Rows.Count > 0 Then
                Dim ci, cni As Double
                Dim id As Integer
                Dim classes, time As String
                For i As Integer = 0 To data1.Rows.Count - 1
                    idclass = data1.Rows(i).Item("id")
                    classes = data1.Rows(i).Item("class")
                    grade = data1.Rows(i).Item("grade")
                    years = data1.Rows(i).Item("school_year")
                    classes = grade & " " & classes
                    If cmbsrokid.Text = "-1" Then

                        If years = cmbYear.Text Then
                            cmd = New MySqlCommand("Select* from  absence where class='" & idclass & "'", cnn)
                            cmd.ExecuteNonQuery()
                            Dim adap2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                            Dim data2 As DataTable = New DataTable
                            adap2.Fill(data2)
                            For j As Integer = 0 To data2.Rows.Count - 1
                                ci = data2.Rows(j).Item("count_excused")
                                cni = data2.Rows(j).Item("count_unexcused")
                                id = data2.Rows(j).Item("id")
                                time = data2.Rows(j).Item("time")
                                'писане в dgv1
                                dgv1.Rows.Add(id, classes, ci, cni, time)
                            Next
                        End If
                    Else
                        If years = cmbYear.Text Then
                            
                            cmd = New MySqlCommand("Select* from  absence where class='" & idclass & "'and time='" & cmbsrok.Text & "'", cnn)


                            cmd.ExecuteNonQuery()
                            Dim adap2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                            Dim data2 As DataTable = New DataTable
                            adap2.Fill(data2)
                            For j As Integer = 0 To data2.Rows.Count - 1
                                ci = data2.Rows(j).Item("count_excused")
                                cni = data2.Rows(j).Item("count_unexcused")
                                id = data2.Rows(j).Item("id")
                                time = data2.Rows(j).Item("time")
                                If time = cmbsrok.Text Then
                                    'писане в dgv1
                                    dgv1.Rows.Add(id, classes, ci, cni, time)
                                End If

                            Next
                        End If
                    End If


                Next
            End If
            cnn.Close()
        End If
    End Sub

    Private Sub btnchart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If dgv1.RowCount > 0 Then
            Chart1.Series.Clear()
            Chart1.ChartAreas.Item(0).AxisX.CustomLabels.Clear()
            title1 = "Спавка"
            title2 = "Отсъствия по класове за: " & cmbYearString.Text & "година, " & cmbClass.Text & " клас, пeриод: " & cmbsrok.Text
            Chart1.Series.Clear()
            Chart1.Legends.Clear()
            Chart1.Titles.Clear()
            Chart1.Titles.Add(title1)
            Chart1.Titles.Add(title2)
            Chart1.Series.Add("Извинени")
            Chart1.Series.Add("Неизвинени")
            Chart1.Series.Add("Средно извинени на човек от клас")
            Chart1.Series.Add("Средно неизвинени на човек от клас")
            Chart1.Legends.Add("Извинени")
            Chart1.Legends.Add("Неизвинени")
            Chart1.Legends.Add("Средно извинени на човек от клас")
            Chart1.Legends.Add("Средно неизвинени на човек от клас")
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            Dim ci, cni As Double
            Dim classes, srok As String
            Chart1.Visible = True
            srok = cmbsrok.Text
            Dim scmd As String = ""
            Call strcob(scmd)
            'TextBox1.Text = scmd
            cmd = New MySqlCommand(scmd, cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            Dim studenst As Integer
            Dim cistd, cnistd As Double
            'Проверка дли в таблица purpose има записи
            If data.Rows.Count > 0 Then


                Dim classp As String
                Dim year, classn, brrows2, row As Integer
                brrows2 = 0
                'записване на сойности в dgv1
                prb1.Value = 0
                prb1.Maximum = data.Rows.Count
                row = 0
                Dim sum, sumci, sumcni As Double
                Dim s As String
                Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim data1 As DataTable = New DataTable
                Do While brrows2 < data.Rows.Count
                    year = data.Rows(brrows2).Item("school_year")
                    classn = data.Rows(brrows2).Item("grade")
                    classp = data.Rows(brrows2).Item("class")
                    classes = classn & " " & classp
                    ci = data.Rows(brrows2).Item("count_excused")
                    cni = data.Rows(brrows2).Item("count_unexcused")
                    sum = sum + 1
                    sumci = sumci + ci
                    sumcni = sumcni + cni
                    ci = Format(Math.Round(ci, 2), "0.00")
                    cni = Format(Math.Round(cni, 2), "0.00")

                    Chart1.Series(0).Points.AddXY(row, ci)
                    Chart1.Series(1).Points.AddXY(row, cni)
                    Chart1.ChartAreas.Item(0).AxisX.CustomLabels.Add(row - 0.5, row + 0.5, classes)
                    Chart1.Series(0).Points(row).SetValueY(ci)
                    Chart1.Series(0).Points(row).Label = ci
                    Chart1.Series(1).Points(row).SetValueY(cni)
                    Chart1.Series(1).Points(row).Label = cni

                    s = "SELECT students  FROM classes where school_year='" & year & "' and grade='" & classn & "' and class='" & classp & "';"
                    cmd = New MySqlCommand(s, cnn)
                    cmd.ExecuteNonQuery()
                    adaptre1 = New MySqlDataAdapter(cmd)
                    data1 = New DataTable
                    adaptre1.Fill(data1)
                    studenst = data1.Rows(0).Item("students")
                    cistd = Format(Math.Round(ci / studenst, 2), "0.00")
                    cnistd = Format(Math.Round(cni / studenst, 2), "0.00")
                    Chart1.Series(2).Points.AddXY(row, cistd)
                    Chart1.Series(3).Points.AddXY(row, cnistd)
                    Chart1.Series(2).Points(row).SetValueY(cistd)
                    Chart1.Series(2).Points(row).Label = cistd
                    Chart1.Series(3).Points(row).SetValueY(cnistd)
                    Chart1.Series(3).Points(row).Label = cnistd
                    row = row + 1
                    brrows2 = brrows2 + 1
                    prb1.Value = prb1.Value + 1
                Loop
                flagbtn = 1
                Dim avaregeci, avaregecni As Double
                avaregeci = Format(Math.Round(sumci / sum, 2), "0.00")
                avaregecni = Format(Math.Round(sumcni / sum, 2), "0.00")
                Chart1.Series(0).Points.AddXY(row, avaregeci)
                Chart1.Series(1).Points.AddXY(row, avaregecni)
                Chart1.ChartAreas.Item(0).AxisX.CustomLabels.Add(row - 0.5, row + 0.5, "Средно")
                Chart1.Series(0).Points(row).SetValueY(avaregeci)
                Chart1.Series(0).Points(row).Label = avaregeci
                Chart1.Series(1).Points(row).SetValueY(avaregecni)
                Chart1.Series(1).Points(row).Label = avaregecni
                s = "SELECT sum(students) as students FROM classes where school_year='" & year & "' and grade='" & classn & "' Group by school_year;"
                cmd = New MySqlCommand(s, cnn)
                cmd.ExecuteNonQuery()
                adaptre1 = New MySqlDataAdapter(cmd)
                data1 = New DataTable
                adaptre1.Fill(data1)
                studenst = data1.Rows(0).Item("students")
                row = row - 1
                cistd = Format(Math.Round(sumci / studenst, 2), "0.00")
                cnistd = Format(Math.Round(sumcni / studenst, 2), "0.00")
                row = row + 1
                Chart1.Series(2).Points.AddXY(row, cistd)
                Chart1.Series(3).Points.AddXY(row, cnistd)
                Chart1.Series(2).Points(row).SetValueY(cistd)
                Chart1.Series(2).Points(row).Label = cistd
                Chart1.Series(3).Points(row).SetValueY(cnistd)
                Chart1.Series(3).Points(row).Label = cnistd
                Me.Height = 735
            Else
                MsgBox("За този випуск няма въведени данни!!!")
            End If
            cnn.Close()

        Else
            MsgBox("Трябва да се върнете и да веведете отсъствия ! ! !", , "Справка")
        End If
    End Sub
    Public Sub strcob(ByRef s As String)
        Dim srok As String
        srok = cmbsrok.Text

        If srok = cmbsrok.Items(0) Or srok = cmbsrok.Items(2) Then
            s = "SELECT classes.grade, classes.class, classes.school_year,"
            s = s & " absence.count_excused, absence.count_unexcused"
            s = s & " FROM classes Inner join absence ON classes.id=absence.class Where school_year='" & cmbYear.Text & "'and grade='" & cmbClass.Text
            If srok = cmbsrok.Items(0) Then
                s = s & "' and time=1"
            Else
                s = s & "' and time=2"
            End If
        Else

            ' 
            s = "SELECT classes.grade, classes.class, classes.school_year,"

            s = s & " max(absence.count_excused)- min(absence.count_excused) as count_excused, max(absence.count_unexcused)- min(absence.count_unexcused) as count_unexcused FROM classes Inner join absence ON classes.id=absence.class"
            s = s & " Where school_year='" & cmbYear.Text & "'and grade='" & cmbClass.Text & "' Group by absence.class"

        End If
        s = s & " order by grade asc, class asc;"
        Return
    End Sub

    Private Sub btnExselNewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExselNewFile.Click
        If cmbYear.Text <> "" Then
            title1 = "Спавка"
            title2 = "Отсъствия по класове за: " & cmbYear.Text & " " & cmbClass.Text & " година, пeриод: " & cmbsrok.Text
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try

            Dim rasEx As String
            rasEx = ""
            'викане на функция RazExcel в койято са записани разширенията на Excel
            Call Module1.RazExcel(rasEx)
            SaveFileDialog1.Filter = rasEx
            If SaveFileDialog1.ShowDialog = DialogResult.OK Then
                cnn.Open()
                Dim xlapp As Microsoft.Office.Interop.Excel.Application
                Dim xlbook As Microsoft.Office.Interop.Excel.Workbook
                Dim xlsheet As Microsoft.Office.Interop.Excel.Worksheet
                Dim misvalue As Object = System.Reflection.Missing.Value
                xlapp = New Microsoft.Office.Interop.Excel.Application
                xlbook = xlapp.Workbooks.Add(misvalue)
                xlsheet = CType(xlbook.Sheets(1), Microsoft.Office.Interop.Excel.Worksheet)
                xlsheet.Name = "Отсъствия по класове"
                Const xlCenter = -4108
                'задаване на текст в клетки и форматиране на редове и колони
                xlsheet.Range(xlsheet.Cells(1, 1), xlsheet.Cells(1, 5)).Merge()
                xlsheet.Range(xlsheet.Cells(1, 1), xlsheet.Cells(1, 6)).HorizontalAlignment = xlCenter
                xlsheet.Cells(1, 1) = title1
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 5)).Merge()
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 6)).HorizontalAlignment = xlCenter
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 6)).WrapText = True
                xlsheet.Cells(2, 1) = title2
                xlsheet.Cells(3, 1) = "Клас"
                xlsheet.Cells(3, 2) = "Извинени"
                xlsheet.Cells(3, 3) = "Неизвинени"
                xlsheet.Cells(3, 4) = "Средно извинени на човек от клас"
                xlsheet.Cells(3, 5) = "Средно неизвинени на човек от клас"
                xlsheet.Range(xlsheet.Cells(3, 1), xlsheet.Cells(3, 3)).HorizontalAlignment = xlCenter
                xlsheet.Range("A3").EntireColumn.ColumnWidth = 20
                xlsheet.Range("B3").EntireColumn.ColumnWidth = 15
                xlsheet.Range("C3").EntireColumn.ColumnWidth = 15
                xlsheet.Range("D3").EntireColumn.ColumnWidth = 20
                xlsheet.Range("E3").EntireColumn.ColumnWidth = 20
                xlsheet.Range(xlsheet.Cells(3, 1), xlsheet.Cells(3, 6)).WrapText = True
                xlsheet.Range("A3").EntireRow.RowHeight = 30
                xlsheet.Range("A2").EntireRow.RowHeight = 20
                Dim pat As String
                pat = SaveFileDialog1.FileName

                Dim scmd As String = ""
                Call strcob(scmd)
                cmd = New MySqlCommand(scmd, cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim data As DataTable = New DataTable
                adaptre.Fill(data)
                Dim s As String
                Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim data1 As DataTable = New DataTable
                'Проверка дли в таблица purpose има записи
                If data.Rows.Count > 0 Then
                    Dim chartPage As Microsoft.Office.Interop.Excel.Chart
                    Dim xlCharts As Microsoft.Office.Interop.Excel.ChartObjects
                    Dim myChart As Microsoft.Office.Interop.Excel.ChartObject
                    Dim chartRange As Microsoft.Office.Interop.Excel.Range
                    xlCharts = xlsheet.ChartObjects
                    myChart = xlCharts.Add(500, 50, 600, 250)
                    chartPage = myChart.Chart
                    chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlColumnClustered
                    Dim classp, classes As String
                    Dim year, classn, brrows2 As Integer
                    brrows2 = 0
                    Dim cni, ci As Double
                    Dim br As Integer = 4
                    'записване на сойности в dgv1
                    prb1.Value = 0
                    prb1.Maximum = data.Rows.Count
                    Dim sumci, sumcni, sum As Double
                    sum = 0
                    sumci = 0
                    sumcni = 0
                    Dim studenst As Integer
                    Dim cistd, cnistd As Double
                    Do While brrows2 < data.Rows.Count
                        year = data.Rows(brrows2).Item("school_year")
                        classn = data.Rows(brrows2).Item("grade")
                        classp = data.Rows(brrows2).Item("class")
                        classes = classn & " " & classp
                        ci = data.Rows(brrows2).Item("count_excused")
                        cni = data.Rows(brrows2).Item("count_unexcused")
                        sum = sum + 1
                        sumci = sumci + ci
                        sumcni = sumcni + cni
                        ci = Format(Math.Round(ci, 2), "0.00")
                        cni = Format(Math.Round(cni, 2), "0.00")

                        xlsheet.Cells(br, 1) = classes
                        xlsheet.Cells(br, 2) = ci
                        xlsheet.Cells(br, 3) = cni
                        s = "SELECT students  FROM classes where school_year='" & year & "' and grade='" & classn & "' and class='" & classp & "';"
                        cmd = New MySqlCommand(s, cnn)
                        cmd.ExecuteNonQuery()
                        adaptre1 = New MySqlDataAdapter(cmd)
                        data1 = New DataTable
                        adaptre1.Fill(data1)
                        studenst = data1.Rows(0).Item("students")
                        cistd = Format(Math.Round(ci / studenst, 2), "0.00")
                        cnistd = Format(Math.Round(cni / studenst, 2), "0.00")
                        xlsheet.Cells(br, 4) = cistd
                        xlsheet.Cells(br, 5) = cnistd

                        xlsheet.Range(xlsheet.Cells(brrows2 + 1, 1), xlsheet.Cells(br, 5)).HorizontalAlignment = xlCenter
                        chartRange = xlsheet.Range("A3:E" & br)
                        chartPage.SetSourceData(Source:=chartRange)
                        brrows2 = brrows2 + 1
                        prb1.Value = prb1.Value + 1
                        br = br + 1
                    Loop
                    Dim avaregeci, avaregecni As Double
                    avaregeci = Format(Math.Round(sumci / sum, 2), "0.00")
                    avaregecni = Format(Math.Round(sumcni / sum, 2), "0.00")

                    xlsheet.Cells(br, 1) = "Средно"
                    xlsheet.Cells(br, 2) = avaregeci
                    xlsheet.Cells(br, 3) = avaregecni
                    s = "SELECT sum(students) as students FROM classes where school_year='" & year & "' and grade='" & classn & "' Group by school_year;"
                    cmd = New MySqlCommand(s, cnn)
                    cmd.ExecuteNonQuery()
                    adaptre1 = New MySqlDataAdapter(cmd)
                    data1 = New DataTable
                    adaptre1.Fill(data1)
                    studenst = data1.Rows(0).Item("students")
                    cistd = Format(Math.Round(sumci / studenst, 2), "0.00")
                    cnistd = Format(Math.Round(sumcni / studenst, 2), "0.00")
                    xlsheet.Cells(br, 4) = cistd
                    xlsheet.Cells(br, 5) = cnistd
                    xlsheet.Range(xlsheet.Cells(brrows2 + 1, 1), xlsheet.Cells(br, 5)).HorizontalAlignment = xlCenter
                    chartRange = xlsheet.Range("A3:E" & br)
                    chartPage.SetSourceData(Source:=chartRange)
                    chartPage.HasTitle = True
                    chartPage.ChartTitle.Text = xlsheet.Range("A2").Value()
                    chartPage.PlotBy = Microsoft.Office.Interop.Excel.XlRowCol.xlColumns
                    chartPage.ApplyDataLabels(Microsoft.Office.Interop.Excel.XlDataLabelsType.xlDataLabelsShowLabel, _
                        False, True, False, False, False, True, False, False, False)
                    chartPage.ShowDataLabelsOverMaximum = True
                    Dim rng As Microsoft.Office.Interop.Excel.Range
                    rng = xlsheet.Range("A1:E" & br)
                    Call cellborder(rng)
                    ' Смаляване на формата
                    Me.Height = 370
                    xlsheet.SaveAs(pat)
                    xlbook.Close()
                    xlapp.Quit()
                    releaseObject(xlapp)
                    releaseObject(xlbook)
                    releaseObject(xlsheet)
                    'питане дали да се отвори файла 
                    Dim res As MsgBoxResult
                    res = MsgBox("Искате ли файлът да се отвори?", MsgBoxStyle.YesNo, "Справка")
                    If res = MsgBoxResult.Yes Then
                        Process.Start(pat)
                    End If
                Else
                    MsgBox("За този випуск няма въведени данни! ! !")
                End If
                cnn.Close()
            End If
        Else
            MsgBox("Трябва да се върнете и да веведете отсъствия! ! !", , "Справка")
        End If
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

    Private Sub btnExselFIle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExselFIle.Click
        If cmbYear.Text <> "" Then
            'викане на функция RazExcel в койято са записани разширенията на Excel
            Dim rasEx As String
            rasEx = ""
            Call Module1.RazExcel(rasEx)
            OpenFileDialog1.Filter = rasEx
            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                Try
                    cnn.Open()
                    cnn.Close()
                Catch ex As Exception
                    MsgBox("Грешка в базата данни! ! !")
                    Application.Exit()
                End Try
                cnn.Open()
                Dim pat As String = OpenFileDialog1.FileName
                Dim xlapp As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
                Dim masterWb As Microsoft.Office.Interop.Excel.Workbook
                masterWb = xlapp.Workbooks.Open(pat)

                Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
                xlWorkBook = xlapp.Workbooks.Add
                Dim ws As Microsoft.Office.Interop.Excel.Worksheet
                Try
                    'задаване на текст в клетки и форматиране на редове и колони
                    ws = xlWorkBook.Sheets.Add(, xlWorkBook.Sheets(xlWorkBook.Sheets.Count))
                    ws.Name = "Отсъствия по класове"
                    title1 = "Спавка"
                    title2 = "Отсъствия по класове за: " & cmbYear.Text & " " & cmbClass.Text & " година, пeриод: " & cmbsrok.Text
                    Dim xldi As Microsoft.Office.Interop.Excel.Chart
                    xldi = New Microsoft.Office.Interop.Excel.Chart
                    Const xlCenter = -4108
                    'задаване на текст в клетки и форматиране на редове и колони
                    ws.Range(ws.Cells(1, 1), ws.Cells(1, 5)).Merge()
                    ws.Range(ws.Cells(1, 1), ws.Cells(1, 6)).HorizontalAlignment = xlCenter
                    ws.Cells(1, 1) = title1
                    ws.Range(ws.Cells(2, 1), ws.Cells(2, 5)).Merge()
                    ws.Range(ws.Cells(2, 1), ws.Cells(2, 6)).HorizontalAlignment = xlCenter
                    ws.Range(ws.Cells(2, 1), ws.Cells(2, 6)).WrapText = True
                    ws.Cells(2, 1) = title2
                    ws.Cells(3, 1) = "Клас"
                    ws.Cells(3, 2) = "Извинени"
                    ws.Cells(3, 3) = "Неизвинени"
                    ws.Cells(3, 4) = "Средно извинени на човек от клас"
                    ws.Cells(3, 5) = "Средно неизвинени на човек от клас"
                    ws.Range(ws.Cells(3, 1), ws.Cells(3, 3)).HorizontalAlignment = xlCenter
                    ws.Range("A3").EntireColumn.ColumnWidth = 20
                    ws.Range("B3").EntireColumn.ColumnWidth = 15
                    ws.Range("C3").EntireColumn.ColumnWidth = 15
                    ws.Range("D3").EntireColumn.ColumnWidth = 20
                    ws.Range("E3").EntireColumn.ColumnWidth = 20
                    ws.Range(ws.Cells(3, 1), ws.Cells(3, 6)).WrapText = True
                    ws.Range("A3").EntireRow.RowHeight = 30
                    ws.Range("A2").EntireRow.RowHeight = 20

                    Dim chartPage As Microsoft.Office.Interop.Excel.Chart
                    Dim xlCharts As Microsoft.Office.Interop.Excel.ChartObjects
                    Dim myChart As Microsoft.Office.Interop.Excel.ChartObject
                    Dim chartRange As Microsoft.Office.Interop.Excel.Range
                    xlCharts = ws.ChartObjects
                    myChart = xlCharts.Add(500, 50, 600, 250)
                    chartPage = myChart.Chart
                    chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlColumnClustered
                    'извикване на функция cmdmaxmi, която връща datareader и проверка тя дали е пълна
                    Dim studenst As Integer
                    Dim cistd, cnistd As Double
                    Dim scmd As String = ""
                    Call strcob(scmd)
                    cmd = New MySqlCommand(scmd, cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim data As DataTable = New DataTable
                    adaptre.Fill(data)
                    Dim classp, classes As String
                    Dim year, classn, brrows2 As Integer
                    brrows2 = 0
                    Dim cni, ci As Double
                    Dim br As Integer = 4
                    'записване на сойности в dgv1
                    prb1.Value = 0
                    prb1.Maximum = data.Rows.Count
                    Dim sumci, sum, sumcni As Double
                    Dim s As String
                    Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim data1 As DataTable = New DataTable
                    Do While brrows2 < data.Rows.Count
                        year = data.Rows(brrows2).Item("school_year")
                        classn = data.Rows(brrows2).Item("grade")
                        classp = data.Rows(brrows2).Item("class")
                        classes = classn & " " & classp
                        ci = data.Rows(brrows2).Item("count_excused")
                        cni = data.Rows(brrows2).Item("count_unexcused")
                        ws.Cells(br, 1) = classes
                        ws.Cells(br, 2) = ci
                        ws.Cells(br, 3) = cni
                        sum = sum + 1
                        sumci = sumci + ci
                        sumcni = sumcni + cni
                        ci = Format(Math.Round(ci, 2), "0.00")
                        cni = Format(Math.Round(cni, 2), "0.00")
                        s = "SELECT students  FROM classes where school_year='" & year & "' and grade='" & classn & "' and class='" & classp & "';"
                        cmd = New MySqlCommand(s, cnn)
                        cmd.ExecuteNonQuery()
                        adaptre1 = New MySqlDataAdapter(cmd)
                        data1 = New DataTable
                        adaptre1.Fill(data1)
                        studenst = data1.Rows(0).Item("students")
                        cistd = Format(Math.Round(ci / studenst, 2), "0.00")
                        cnistd = Format(Math.Round(cni / studenst, 2), "0.00")
                        ws.Cells(br, 4) = cistd
                        ws.Cells(br, 5) = cnistd
                        ws.Range(ws.Cells(brrows2 + 1, 1), ws.Cells(br, 5)).HorizontalAlignment = xlCenter
                        chartRange = ws.Range("A3:E" & br)
                        chartPage.SetSourceData(Source:=chartRange)
                        brrows2 = brrows2 + 1
                        prb1.Value = prb1.Value + 1
                        br = br + 1
                    Loop
                    Dim avaregeci, avaregecni As Double
                    avaregeci = Format(Math.Round(sumci / sum, 2), "0.00")
                    avaregecni = Format(Math.Round(sumcni / sum, 2), "0.00")
                    ws.Cells(br, 1) = "Средно"
                    ws.Cells(br, 2) = avaregeci
                    ws.Cells(br, 3) = avaregecni
                    s = "SELECT sum(students) as students FROM classes where school_year='" & year & "' and grade='" & classn & "' Group by school_year;"
                    cmd = New MySqlCommand(s, cnn)
                    cmd.ExecuteNonQuery()
                    adaptre1 = New MySqlDataAdapter(cmd)
                    data1 = New DataTable
                    adaptre1.Fill(data1)
                    studenst = data1.Rows(0).Item("students")
                    cistd = Format(Math.Round(sumci / studenst, 2), "0.00")
                    cnistd = Format(Math.Round(sumcni / studenst, 2), "0.00")
                    ws.Cells(br, 4) = cistd
                    ws.Cells(br, 5) = cnistd
                    ws.Range(ws.Cells(brrows2 + 1, 1), ws.Cells(br, 5)).HorizontalAlignment = xlCenter
                    chartRange = ws.Range("A3:E" & br)
                    chartPage.SetSourceData(Source:=chartRange)
                    chartPage.HasTitle = True
                    chartPage.ChartTitle.Text = ws.Range("A2").Value()
                    chartPage.PlotBy = Microsoft.Office.Interop.Excel.XlRowCol.xlColumns


                    chartPage.ApplyDataLabels(Microsoft.Office.Interop.Excel.XlDataLabelsType.xlDataLabelsShowLabel, _
                        False, True, False, False, False, True, False, False, False)
                    chartPage.ShowDataLabelsOverMaximum = True
                    Dim rng As Microsoft.Office.Interop.Excel.Range
                    rng = ws.Range("A1:E" & br)
                    Call cellborder(rng)
                    chartPage.PlotBy = Microsoft.Office.Interop.Excel.XlRowCol.xlColumns
                    ws.Copy(, masterWb.Sheets(masterWb.Sheets.Count))
                    ws = Nothing
                    xlWorkBook.Save()
                    xlWorkBook.Close()
                    xlWorkBook = Nothing
                    'Смаляване на формата
                    Me.Height = 370
                    masterWb.SaveAs(pat)
                    masterWb.Close()
                    masterWb = Nothing
                    xlapp.Quit()
                    xlapp = Nothing
                    'питане дали да се отвори файла 

                    Dim res As MsgBoxResult
                    res = MsgBox("Искате ли файлът да се отвори?", MsgBoxStyle.YesNo, "Справка")
                    If res = MsgBoxResult.Yes Then
                        Process.Start(pat)
                    End If
                Catch ex As Exception
                    MsgBox("ERROR- " & ex.Message)
                End Try

                cnn.Close()
            End If
        Else
            MsgBox("Трябва да се върнете и да веведете отсъствия! ! !", , "Справка")
        End If
    End Sub

    Private Sub btnWordNewFIle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWordNewFIle.Click
        If cmbYear.Text <> "" Then
            'викане на функция RazWord в койято са записани разширенията на word
            Dim razWor As String
            razWor = ""
            Call Module1.RazWord(razWor)

            SaveFileDialog1.Filter = razWor
            If SaveFileDialog1.ShowDialog = DialogResult.OK Then
                Try
                    cnn.Open()
                    cnn.Close()
                Catch ex As Exception
                    MsgBox("Грешка в базата данни! ! !")
                    Application.Exit()
                End Try
                cnn.Open()
                Dim pat As String
                pat = SaveFileDialog1.FileName

                Dim oWord As Microsoft.Office.Interop.Word.Application
                Dim oDoc As Microsoft.Office.Interop.Word.Document
                Dim oTable As Microsoft.Office.Interop.Word.Table
                Dim oPara1 As Microsoft.Office.Interop.Word.Paragraph, oPara2 As Microsoft.Office.Interop.Word.Paragraph

                oWord = CreateObject("Word.Application")
                oDoc = oWord.Documents.Add
                'задаване на текст, вкарваненатаблица и нейното форматиране
                oPara1 = oDoc.Content.Paragraphs.Add
                oPara1.Range.Font.Size = 20
                oPara1.Range.Font.Bold = True
                oPara1.Range.Text = title1
                oPara1.Alignment = HorizontalAlignment.Right
                oPara1.Format.SpaceAfter = 24
                oPara1.Range.InsertParagraphAfter()
                title1 = "Спавка"
                title2 = "Отсъствия по класове за: " & cmbYear.Text & " " & cmbClass.Text & " година, пeриод: " & cmbsrok.Text
                oPara2 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
                oPara2.Range.Text = title2
                oPara2.Format.SpaceAfter = 6
                oPara2.Range.InsertParagraphAfter()

                'четене на datareader, изчисляване на данните и тяхното записване в excel
                Dim scmd As String = ""
                Call strcob(scmd)
                cmd = New MySqlCommand(scmd, cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim data As DataTable = New DataTable
                adaptre.Fill(data)
                Dim classp, classes, m(data.Rows.Count + 1, 4) As String
                Dim year, classn, brrows2 As Integer
                brrows2 = 0
                Dim cni, ci As Double
                Dim br As Integer = 0

                'записване на сойности в dgv1
                prb1.Value = 0
                prb1.Maximum = data.Rows.Count
                Dim sumci, sum, sumcni As Double
                Dim s As String
                Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim data1 As DataTable = New DataTable
                Dim avaregeci, avaregecni, studenst As Double
                Dim cistd, cnistd As Double
                Do While brrows2 < data.Rows.Count
                    year = data.Rows(brrows2).Item("school_year")
                    classn = data.Rows(brrows2).Item("grade")
                    classp = data.Rows(brrows2).Item("class")
                    classes = classn & " " & classp
                    ci = data.Rows(brrows2).Item("count_excused")
                    cni = data.Rows(brrows2).Item("count_unexcused")
                    sum = sum + 1
                    sumci = sumci + ci
                    sumcni = sumcni + cni
                    ci = Format(Math.Round(ci, 2), "0.00")
                    cni = Format(Math.Round(cni, 2), "0.00")
                    m(br, 0) = classes
                    m(br, 1) = ci
                    m(br, 2) = cni
                    ci = Format(Math.Round(ci, 2), "0.00")
                    cni = Format(Math.Round(cni, 2), "0.00")
                    s = "SELECT students  FROM classes where school_year='" & year & "' and grade='" & classn & "' and class='" & classp & "';"
                    cmd = New MySqlCommand(s, cnn)
                    cmd.ExecuteNonQuery()
                    adaptre1 = New MySqlDataAdapter(cmd)
                    data1 = New DataTable
                    adaptre1.Fill(data1)
                    studenst = data1.Rows(0).Item("students")
                    cistd = Format(Math.Round(ci / studenst, 2), "0.00")
                    cnistd = Format(Math.Round(cni / studenst, 2), "0.00")
                    m(br, 3) = cistd
                    m(br, 4) = cnistd
                    brrows2 = brrows2 + 1
                    prb1.Value = prb1.Value + 1
                    br = br + 1
                Loop

                avaregeci = Format(Math.Round(sumci / sum, 2), "0.00")
                avaregecni = Format(Math.Round(sumcni / sum, 2), "0.00")
                m(br, 0) = "Средно"
                m(br, 1) = avaregeci
                m(br, 2) = avaregecni
                oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, 1, 5)
                oTable.Cell(1, 1).Range.Text = "Клас"
                oTable.Cell(1, 2).Range.Text = "Извинени"
                oTable.Cell(1, 3).Range.Text = "Неизвинени"
                oTable.Cell(1, 4).Range.Text = "Средно извинени на човек от клас"
                oTable.Cell(1, 5).Range.Text = "Средно неизвинени на човек от клас"


                s = "SELECT sum(students) as students FROM classes where school_year='" & year & "' and grade='" & classn & "' Group by school_year;"
                cmd = New MySqlCommand(s, cnn)
                cmd.ExecuteNonQuery()
                adaptre1 = New MySqlDataAdapter(cmd)
                data1 = New DataTable
                adaptre1.Fill(data1)
                studenst = data1.Rows(0).Item("students")
                cistd = Format(Math.Round(sumci / studenst, 2), "0.00")
                cnistd = Format(Math.Round(sumcni / studenst, 2), "0.00")
                m(br, 3) = cistd
                m(br, 4) = cnistd
                Dim br3 As Integer = 0
                Do While m(br3, 0) <> ""
                    oTable.Rows.Add()
                    oTable.Cell(br3 + 2, 1).Range.Text = m(br3, 0)
                    oTable.Cell(br3 + 2, 2).Range.Text = m(br3, 1)
                    oTable.Cell(br3 + 2, 3).Range.Text = m(br3, 2)
                    oTable.Cell(br3 + 2, 4).Range.Text = m(br3, 3)
                    oTable.Cell(br3 + 2, 5).Range.Text = m(br3, 4)
                    br3 = br3 + 1
                Loop
                'форматиране на таблицата
                oTable.Rows.Item(1).Range.Font.Bold = True
                oTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle
                oTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle
                'смаляване на формата
                Me.Height = 370
                oDoc.SaveAs2(pat)
                oDoc.Close()
                'питане дали да се отвори файла
                Dim res As MsgBoxResult
                res = MsgBox("Искате ли файлът да се отвори?", MsgBoxStyle.YesNo, "Справка")
                If res = MsgBoxResult.Yes Then
                    Process.Start(pat)
                End If
                cnn.Close()
            End If
        Else
            MsgBox("Трябва да се върнете и да веведете отсъствия! ! !", , "Справка")
        End If
    End Sub

    Private Sub reference_absecnce_vipusk_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'изтриване на старите сойности в dgv1
        dgv1.Rows.Clear()
        Me.Height = 370
        'Проверка дали chart1 е празно и  изтриване настъойностите му
        Chart1.Series.Clear()
        Chart1.Legends.Clear()
        Chart1.Titles.Clear()
        cmbYearString.Items.Clear()
        cmbYear.Items.Clear()
        cmbClass.Items.Clear()
        prb1.Value = 0
    End Sub

    Private Sub cmbYear_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYear.Leave, cmbYearString.Leave, cmbYearString.DropDownClosed
        If (cmbYearString.SelectedIndex = -1) Then
            cmbYearString.Text = cmbYearString.Items(0)
            cmbYearString.Focus()
        Else
            cmbYear.Text = cmbYear.Items(cmbYearString.SelectedIndex)
            'изтриване на старите сойности в dgv1
            Do While dgv1.RowCount > 0
                dgv1.Rows.Remove(dgv1.Rows(0))
            Loop
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            'Проверка дaли в таблица purpose има записи
            Dim years, grade As Integer
            'задаване на текст на cmbtaта
            cmbClass.Items.Clear()
            Dim scom As String
            years = cmbYear.Text
            scom = "Select* from  classes where school_year='" & years & "' order by grade desc;"
            cmd = New MySqlCommand(scom, cnn)
            cmd.ExecuteNonQuery()
            Dim adap As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data1 As DataTable = New DataTable
            adap.Fill(data1)
            Dim fdouble As Integer = 0
            For i As Integer = 0 To data1.Rows.Count - 1
                fdouble = 0
                For j As Integer = 0 To cmbClass.Items.Count - 1
                    If cmbClass.Items(j) = data1.Rows(i).Item("grade") Then
                        fdouble = 1
                        Exit For
                    End If
                Next
                If fdouble = 0 Then
                    cmbClass.Items.Add(data1.Rows(i).Item("grade"))
                End If
            Next
            cmbClass.Text = cmbClass.Items(0)
            cmbsrok.Text = cmbsrok.Items(0)
            'търсене на оценките на випуска
            grade = cmbClass.Text
            years = cmbYear.Text

            Dim idclass As Integer
            'обхождане на оценките на випуска
            'записване на стойности в dgv1
            scom = "Select* from  classes where school_year='" & years & "' and grade='" & grade & "';"
            cmd = New MySqlCommand(scom, cnn)
            cmd.ExecuteNonQuery()
            adap = New MySqlDataAdapter(cmd)
            data1 = New DataTable
            adap.Fill(data1)
            If data1.Rows.Count > 0 Then
                Dim ci, cni As Double
                Dim id As Integer
                Dim classes, time As String
                For i As Integer = 0 To data1.Rows.Count - 1
                    idclass = data1.Rows(i).Item("id")
                    classes = data1.Rows(i).Item("class")
                    grade = data1.Rows(i).Item("grade")
                    years = data1.Rows(i).Item("school_year")
                    classes = grade & " " & classes

                    cmd = New MySqlCommand("Select* from  absence where class='" & idclass & "'and time=1", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adap2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim data2 As DataTable = New DataTable
                    adap2.Fill(data2)
                    For j As Integer = 0 To data2.Rows.Count - 1
                        ci = data2.Rows(j).Item("count_excused")
                        cni = data2.Rows(j).Item("count_unexcused")
                        id = data2.Rows(j).Item("id")
                        time = data2.Rows(j).Item("time")
                        'писане в dgv1
                        dgv1.Rows.Add(id, classes, ci, cni, time)
                    Next

                Next
            End If
            cnn.Close()
        End If
    End Sub

    Private Sub cmbClass_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClass.Leave
        If (cmbClass.SelectedIndex = -1) Then
            cmbClass.Text = cmbYear.Items(0)
            cmbClass.Focus()
        Else
            cmbYear.Text = cmbYear.Items(cmbYearString.SelectedIndex)
            'изтриване на старите сойности в dgv1
            Do While dgv1.RowCount > 0
                dgv1.Rows.Remove(dgv1.Rows(0))
            Loop
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            'Проверка дaли в таблица purpose има записи
            Dim years, grade As Integer
            'задаване на текст на cmbtaта
            Dim scom As String
            years = cmbYear.Text
            Dim adap As MySqlDataAdapter = New MySqlDataAdapter()
            Dim data1 As DataTable = New DataTable
            cmbsrok.Text = cmbsrok.Items(0)
            'търсене на оценките на випуска
            grade = cmbClass.Text
            years = cmbYear.Text
            Dim idclass As Integer
            'обхождане на оценките на випуска
            'записване на стойности в dgv1
            scom = "Select* from  classes where school_year='" & years & "' and grade='" & grade & "';"
            cmd = New MySqlCommand(scom, cnn)
            cmd.ExecuteNonQuery()
            adap = New MySqlDataAdapter(cmd)
            data1 = New DataTable
            adap.Fill(data1)
            If data1.Rows.Count > 0 Then
                Dim ci, cni As Double
                Dim id As Integer
                Dim classes, time As String
                For i As Integer = 0 To data1.Rows.Count - 1
                    idclass = data1.Rows(i).Item("id")
                    classes = data1.Rows(i).Item("class")
                    grade = data1.Rows(i).Item("grade")
                    years = data1.Rows(i).Item("school_year")
                    classes = grade & " " & classes

                    cmd = New MySqlCommand("Select* from  absence where class='" & idclass & "'and time=1", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adap2 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim data2 As DataTable = New DataTable
                    adap2.Fill(data2)
                    For j As Integer = 0 To data2.Rows.Count - 1
                        ci = data2.Rows(j).Item("count_excused")
                        cni = data2.Rows(j).Item("count_unexcused")
                        id = data2.Rows(j).Item("id")
                        time = data2.Rows(j).Item("time")
                        'писане в dgv1
                        dgv1.Rows.Add(id, classes, ci, cni, time)
                    Next

                Next
            End If
            cnn.Close()
        End If
    End Sub


End Class


