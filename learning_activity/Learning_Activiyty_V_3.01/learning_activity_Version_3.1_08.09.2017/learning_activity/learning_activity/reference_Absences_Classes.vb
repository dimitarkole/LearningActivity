Imports MySql.Data.MySqlClient
Public Class reference_Absences_Classes
    'деклариране на глобални променливи
    Dim cnn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim years, title1, title2, flagbtn As String
    Dim a, b, RRowsCount As Integer
    Private Sub reference_Absences_Classes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        flagbtn = 0
        title1 = "Справка"
        title2 = "Отсъствия по паралелки: "
        Dim brRows, nomer, flag, britem As Integer
        brRows = 0
        Call Module1.hosts(cnn)
        'Отваряне на връската със SURVER
        cnn.Open()
        cmd = New MySqlCommand("Select* from  absence order by id", cnn)
        cmd.ExecuteNonQuery()
        Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
        Dim data As DataTable = New DataTable
        adaptre.Fill(data)
        'Проверка дли в таблица purpose има записи
        If data.Rows.Count > 0 Then
            Dim yearM(data.Rows.Count), yearM2(data.Rows.Count) As Integer
            Dim brm As Integer
            brm = 1
            For i As Integer = 0 To data.Rows.Count
                yearM(i) = 0
                yearM2(i) = 0
            Next
            'минаване през всчики редове на таблица purpose
            Do While brRows < data.Rows.Count

                'Селактиране на номера на класа на ред
                nomer = data.Rows(brRows).Item("class")
                cmd = New MySqlCommand("Select* from  classes where id='" & nomer & "' order by school_year desc;", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt As DataTable = New DataTable
                adaptre1.Fill(dt)
                'задаване на учебна година
                years = dt.Rows(0).Item("school_year")
                flag = 0
                britem = 0

                'проверка дали учебната година е вписана в cmbyear 
                Do While britem <= brm
                    If years = yearM(britem) Then
                        flag = 1
                        Exit Do

                    End If
                    britem = britem + 1
                Loop
                If flag = 0 Then
                    yearM(brm - 1) = years
                    brm = brm + 1
                End If
                brRows = brRows + 1
            Loop
            For j As Integer = 0 To brm - 2
                cmbyear.Items.Add(yearM(j) & "/" & yearM(j) Mod 100 + 1)
                cmbyearid.Items.Add(yearM(j))
            Next
            cmbyear.Text = cmbyear.Items(0)
            cmbYearid.Text = cmbYearid.Items(0)
            Dim id As Integer
            cmbyearid.Text = cmbyearid.Items(cmbyear.SelectedIndex)
            Dim classes, classp, srok As String
            Dim nomerdgv1, year, classn, brrows2, ci, cni As Integer
            Dim yearsting As String
            brrows2 = 0
            'записване на сойности в dgv1
            Dim f As Integer
            Do While brrows2 < data.Rows.Count
                id = data.Rows(brrows2).Item("id")
                ' задаване на клас
                nomerdgv1 = data.Rows(brrows2).Item("class")
                cmd = New MySqlCommand("Select* from  classes where id='" & nomerdgv1 & "' order by id", cnn)
                cmd.ExecuteNonQuery()
                Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim dt As DataTable = New DataTable
                adaptre1.Fill(dt)
                year = dt.Rows(0).Item("school_year")
                classn = dt.Rows(0).Item("grade")
                classp = dt.Rows(0).Item("class")
                classes = year & "/" & year Mod 100 + 1 & " " & classn & " " & classp
                yearsting = year & "/" & year Mod 100 + 1
                f = 0
                srok = data.Rows(brrows2).Item("time")
                If (yearsting = cmbyear.Text) And (srok = cmbsrok.Items(0)) Then
                    ci = data.Rows(brrows2).Item("count_excused")
                    cni = data.Rows(brrows2).Item("count_unexcused")

                    'писане в dgv1
                    dgv1.Rows.Add(id, classes, ci, cni, srok)
                End If

                brrows2 = brrows2 + 1
            Loop
        End If
        cnn.Close()
    End Sub
    Private Sub cmbyear_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbyear.Leave, cmbyear.DropDownClosed
        If (cmbyear.SelectedIndex = -1) Then
            'Проверка за въвеждане на символи от клавиатурата
            cmbyear.Text = cmbyear.Items(0)
            cmbyear.Focus()
        Else
            'Отваряне на връската със SURVER
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            'изтриване на старите сойности в dgv1
            Do While dgv1.RowCount > 0
                dgv1.Rows.Remove(dgv1.Rows(0))
            Loop
            cmd = New MySqlCommand("Select* from  absence order by id", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            'Проверка дли в таблица purpose има записи
            If data.Rows.Count > 0 Then
                Dim id As Integer
                cmbyearid.Text = cmbyearid.Items(cmbyear.SelectedIndex)
                Dim classes, classp, srok As String
                Dim nomerdgv1, year, classn, brrows2, ci, cni As Integer
                Dim yearsting As String
                brrows2 = 0
                cmbsrok.Text = cmbsrok.Items(0)
                'записване на сойности в dgv1
                Dim f As Integer
                Do While brrows2 < data.Rows.Count
                    id = data.Rows(brrows2).Item("id")
                    ' задаване на клас
                    nomerdgv1 = data.Rows(brrows2).Item("class")
                    cmd = New MySqlCommand("Select* from  classes where id='" & nomerdgv1 & "' order by id", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt As DataTable = New DataTable
                    adaptre1.Fill(dt)
                    year = dt.Rows(0).Item("school_year")
                    classn = dt.Rows(0).Item("grade")
                    classp = dt.Rows(0).Item("class")
                    classes = year & "/" & year Mod 100 + 1 & " " & classn & " " & classp
                    yearsting = year & "/" & year Mod 100 + 1
                    f = 0
                    srok = data.Rows(brrows2).Item("time")
                    If (yearsting = cmbyear.Text) And (srok = cmbsrok.Items(0)) Then
                        ci = data.Rows(brrows2).Item("count_excused")
                        cni = data.Rows(brrows2).Item("count_unexcused")

                        'писане в dgv1
                        dgv1.Rows.Add(id, classes, ci, cni, srok)
                    End If

                    brrows2 = brrows2 + 1
                Loop
            End If
            cnn.Close()
        End If

    End Sub
    Private Sub cmbsrok_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsrok.Leave, cmbsrok.DropDownClosed
        If (cmbsrok.SelectedIndex = -1) Then
            'Проверка за въвеждане на символи от клавиатурата
            cmbsrok.Text = cmbsrok.Items(0)
            cmbsrok.Focus()
        Else
            'Отваряне на връската със SURVER
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            'изтриване на старите сойности в dgv1
            Do While dgv1.RowCount > 0
                dgv1.Rows.Remove(dgv1.Rows(0))
            Loop
            cmd = New MySqlCommand("Select* from  absence order by id", cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            'Проверка дли в таблица purpose има записи
            If data.Rows.Count > 0 Then
                Dim id As Integer
                cmbsrokid.Text = cmbsrokid.Items(cmbsrok.SelectedIndex)
                Dim classes, classp, srok As String
                Dim nomerdgv1, year, classn, brrows2, ci, cni As Integer
                Dim yearsting As String
                brrows2 = 0
                'записване на сойности в dgv1
                Dim f As Integer
                Do While brrows2 < data.Rows.Count
                    id = data.Rows(brrows2).Item("id")
                    ' задаване на клас
                    nomerdgv1 = data.Rows(brrows2).Item("class")
                    cmd = New MySqlCommand("Select* from  classes where id='" & nomerdgv1 & "' order by id", cnn)
                    cmd.ExecuteNonQuery()
                    Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt As DataTable = New DataTable
                    adaptre1.Fill(dt)
                    year = dt.Rows(0).Item("school_year")
                    classn = dt.Rows(0).Item("grade")
                    classp = dt.Rows(0).Item("class")
                    classes = year & "/" & year Mod 100 + 1 & " " & classn & " " & classp
                    yearsting = year & "/" & year Mod 100 + 1
                    f = 0
                    srok = data.Rows(brrows2).Item("time")
                    If cmbsrokid.Text = -1 Then
                        If yearsting = cmbyear.Text Then
                            ci = data.Rows(brrows2).Item("count_excused")
                            cni = data.Rows(brrows2).Item("count_unexcused")
                            'писане в dgv1
                            dgv1.Rows.Add(id, classes, ci, cni, srok)
                        End If
                    ElseIf (yearsting = cmbyear.Text) And (srok = cmbsrok.Text) Then
                        ci = data.Rows(brrows2).Item("count_excused")
                        cni = data.Rows(brrows2).Item("count_unexcused")
                        'писане в dgv1
                        dgv1.Rows.Add(id, classes, ci, cni, srok)


                    End If

                    brrows2 = brrows2 + 1
                Loop
            End If
            cnn.Close()
        End If
    End Sub

    Private Sub btnchart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnchart.Click
        If dgv1.RowCount > 0 Then
            title1 = "Спавка"
            title2 = "Отсъствия по паралелки за: " & cmbyear.Text & " година, пeриод: " & cmbsrok.Text
            Chart1.ChartAreas.Item(0).AxisX.CustomLabels.Clear()
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
            cmd = New MySqlCommand(scmd, cnn)
            cmd.ExecuteNonQuery()
            Dim adaptre As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable = New DataTable
            adaptre.Fill(data)
            'Проверка дли в таблица purpose има записи
            If data.Rows.Count > 0 Then
                Dim classp, s As String
                Dim year, classn, brrows2 As Integer
                brrows2 = 0
                Dim adaptre1 As MySqlDataAdapter
                Dim data1 As DataTable
                Dim studenst As Integer
                Dim cistd, cnistd As Double
                'записване на сойности в dgv1
                prb1.Value = 0
                prb1.Maximum = data.Rows.Count
                Dim row As Integer = 0
                Dim sum, sumci, sumcni As Double
                Do While brrows2 < data.Rows.Count
                    year = data.Rows(brrows2).Item("school_year")
                    classn = data.Rows(brrows2).Item("grade")
                    classp = data.Rows(brrows2).Item("class")
                    classes = classn & " " & classp
                    ci = data.Rows(brrows2).Item("count_excused")
                    cni = data.Rows(brrows2).Item("count_unexcused")
                   
                    ci = Format(Math.Round(ci, 2), "0.00")
                    cni = Format(Math.Round(cni, 2), "0.00")
                    sum = sum + 1
                    sumci = sumci + ci
                    sumcni = sumcni + cni

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
                sumci = Format(Math.Round(sumci / sum, 2), "0.00")
                sumcni = Format(Math.Round(sumcni / sum, 2), "0.00")
                Chart1.Series(0).Points.AddXY(row, sumci)
                Chart1.Series(1).Points.AddXY(row, sumcni)
                Chart1.ChartAreas.Item(0).AxisX.CustomLabels.Add(row - 0.5, row + 0.5, "Средно")
                Chart1.Series(0).Points(row).SetValueY(sumci)
                Chart1.Series(0).Points(row).Label = sumci
                Chart1.Series(1).Points(row).SetValueY(sumcni)
                Chart1.Series(1).Points(row).Label = sumcni
                s = "SELECT sum(students) as students FROM classes where school_year='" & year & "' Group by school_year;"
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
                flagbtn = 1
            Else
                MsgBox("За този випуск няма въведени данни! ! !")
            End If
            cnn.Close()

        Else
            MsgBox("Трябва да се върнете и да веведете отсъствия! ! !", , "Справка")
        End If
    End Sub
    Public Sub strcob(ByRef s As String)
        Dim srok As String
        srok = cmbsrok.Text

        If srok = cmbsrok.Items(0) Or srok = cmbsrok.Items(2) Then
            s = "SELECT classes.grade, classes.class, classes.school_year,absence.count_excused, absence.count_unexcused"
            s = s & " FROM classes Inner join absence ON classes.id=absence.class Where school_year='" & cmbyearid.Text
            If srok = cmbsrok.Items(0) Then
                s = s & "' and time=1"
            ElseIf srok = cmbsrok.Items(2) Then
                s = s & "' and time=2"
            End If
        Else
            s = "SELECT classes.grade, classes.class, classes.school_year,"
            s = s & " max(absence.count_excused)- min(absence.count_excused) as count_excused, max(absence.count_unexcused)- min(absence.count_unexcused) as count_unexcused FROM classes Inner join absence ON classes.id=absence.class"
            s = s & " Where school_year='" & cmbyear.Text & "' Group by absence.class"
        End If


        s = s & " order by grade asc, class asc;"
        Return
    End Sub
    Sub cellborder(ByVal rng As Microsoft.Office.Interop.Excel.Range)
        With rng.Borders
            .LineStyle = Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalUp
            .Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin
        End With
    End Sub
    Private Sub btnExselNewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExselNewFile.Click
        If cmbyear.Text <> "" Then
            title1 = "Спавка"
            title2 = "Отсъствия по паралелки за: " & cmbyear.Text & " година, пeриод: " & cmbsrok.Text
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            Dim rasEx As String
            rasEx = ""
            'викане на функция RazExcel в койято са записани разширенията на Excel
            Call Module1.RazExcel(rasEx)
            SaveFileDialog1.Filter = rasEx
            If SaveFileDialog1.ShowDialog = DialogResult.OK Then
                Dim xlapp As Microsoft.Office.Interop.Excel.Application
                Dim xlbook As Microsoft.Office.Interop.Excel.Workbook
                Dim xlsheet As Microsoft.Office.Interop.Excel.Worksheet
                Dim misvalue As Object = System.Reflection.Missing.Value
                xlapp = New Microsoft.Office.Interop.Excel.Application
                xlbook = xlapp.Workbooks.Add(misvalue)
                xlsheet = CType(xlbook.Sheets(1), Microsoft.Office.Interop.Excel.Worksheet)
                xlsheet.Name = "Отсъствия по паралелки"
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
                'Проверка дли в таблица purpose има записи
                If data.Rows.Count > 0 Then
                    Dim chartPage As Microsoft.Office.Interop.Excel.Chart
                    Dim xlCharts As Microsoft.Office.Interop.Excel.ChartObjects
                    Dim myChart As Microsoft.Office.Interop.Excel.ChartObject
                    Dim chartRange As Microsoft.Office.Interop.Excel.Range
                    xlCharts = xlsheet.ChartObjects
                    myChart = xlCharts.Add(300, 50, 600, 250)
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
                    Dim sum, sumci, sumcni As Double
                    Dim studenst As Integer
                    Dim cistd, cnistd As Double
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
                        ci = Format(Math.Round(ci, 2), "0.00")
                        cni = Format(Math.Round(cni, 2), "0.00")
                        sum = sum + 1
                        sumci = sumci + ci
                        sumcni = sumcni + cni
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
                    s = "SELECT sum(students) as students FROM classes where school_year='" & year & "' Group by school_year;"
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
                    chartPage.ApplyDataLabels(Microsoft.Office.Interop.Excel.XlDataLabelsType.xlDataLabelsShowLabel,
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
        If cmbyear.Text <> "" Then
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
                    ws.Name = "Отсъствия по паралелки"
                    title1 = "Спавка"
                    title2 = "Отсъствия по паралелки за: " & cmbyear.Text & " година, пeриод: " & cmbsrok.Text
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
                    myChart = xlCharts.Add(300, 50, 600, 250)
                    chartPage = myChart.Chart
                    chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlColumnClustered
                    'извикване на функция cmdmaxmi, която връща datareader и проверка тя дали е пълна

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
                    Dim sum, sumci, sumcni As Double
                    Dim s As String
                    Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim data1 As DataTable = New DataTable
                    Dim studenst As Integer
                    Dim cistd, cnistd As Double
                    Do While brrows2 < data.Rows.Count
                        year = data.Rows(brrows2).Item("school_year")
                        classn = data.Rows(brrows2).Item("grade")
                        classp = data.Rows(brrows2).Item("class")
                        classes = classn & " " & classp
                        ci = data.Rows(brrows2).Item("count_excused")
                        cni = data.Rows(brrows2).Item("count_unexcused")
                        ci = Format(Math.Round(ci, 2), "0.00")
                        cni = Format(Math.Round(cni, 2), "0.00")
                        sum = sum + 1
                        sumci = sumci + ci
                        sumcni = sumcni + cni
                        ws.Cells(br, 1) = classes
                        ws.Cells(br, 2) = ci
                        ws.Cells(br, 3) = cni
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
                    s = "SELECT sum(students) as students FROM classes where school_year='" & year & "' Group by school_year;"
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


                    chartPage.ApplyDataLabels(Microsoft.Office.Interop.Excel.XlDataLabelsType.xlDataLabelsShowLabel,
                        False, True, False, False, False, True, False, False, False)
                    chartPage.ShowDataLabelsOverMaximum = True
                    Dim rng As Microsoft.Office.Interop.Excel.Range
                    rng = ws.Range("A1:E" & br)
                    Call cellborder(rng)
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
        If cmbyear.Text <> "" Then
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
                title2 = "Отсъствия по паралелки за: " & cmbyear.Text & " година, пeриод: " & cmbsrok.Text
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
                Dim sum, sumci, sumcni As Double
                Dim s As String
                Dim adaptre1 As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                Dim data1 As DataTable = New DataTable
                Dim avaregeci, avaregecni, studenst As Double
                Dim cistd, cnistd As Double
                Do While brrows2 < data.Rows.Count
                    year = data.Rows(brrows2).Item("school_year")
                    classn = data.Rows(brrows2).Item("grade")
                    classp = data.Rows(brrows2).Item("class")
                    ci = data.Rows(brrows2).Item("count_excused")
                    cni = data.Rows(brrows2).Item("count_unexcused")
                    ci = Format(Math.Round(ci, 2), "0.00")
                    cni = Format(Math.Round(cni, 2), "0.00")
                    classes = classn & " " & classp

                    sum = sum + 1
                    sumci = sumci + ci
                    sumcni = sumcni + cni
                    m(br, 0) = classes
                    m(br, 1) = ci
                    m(br, 2) = cni
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
                oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, 1, 5)
                oTable.Cell(1, 1).Range.Text = "Клас"
                oTable.Cell(1, 2).Range.Text = "Извинени"
                oTable.Cell(1, 3).Range.Text = "Неизвинени"
                oTable.Cell(1, 4).Range.Text = "Средно извинени на човек от клас"
                oTable.Cell(1, 5).Range.Text = "Средно неизвинени на човек от клас"

                avaregeci = Format(Math.Round(sumci / sum, 2), "0.00")
                avaregecni = Format(Math.Round(sumcni / sum, 2), "0.00")
                m(br, 0) = "Средно"
                m(br, 1) = avaregeci
                m(br, 2) = avaregecni
                s = "SELECT sum(students) as students FROM classes where school_year='" & year & "' Group by school_year;"
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

    Private Sub reference_Absences_Classes_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'изтриване на старите сойности в dgv1
        Do While dgv1.RowCount > 0
            dgv1.Rows.Remove(dgv1.Rows(0))
        Loop
        Me.Height = 380
        'Проверка дали chart1 е празно и  изтриване настъойностите му
        If Chart1.Series.Count > 0 Then
            Chart1.Series.Clear()
            Chart1.Legends.Clear()
            Chart1.Titles.Remove(Chart1.Titles.Item(0))
            Chart1.Titles.Remove(Chart1.Titles.Item(0))
        End If

        Do While cmbyear.Items.Count > 0
            cmbyearid.Items.Remove(cmbyearid.Items(0))
            cmbyear.Items.Remove(cmbyear.Items(0))
        Loop

        prb1.Value = 0
    End Sub
End Class