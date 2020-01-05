Imports MySql.Data.MySqlClient
Public Class reference_absence_va_Vipusk
    'деклариране на глобални променливи
    Dim cnn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim years, title1, title2, flagbtn As String
    Dim a, b, RRowsCount As Integer
    Private Sub reference_absence_va_Vipusk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Отваряне на връската със SURVER
        Call Module1.hosts(cnn)
        cnn.Open()
        Dim brRows, flag As Integer
        brRows = 0
        title1 = "Справка"
        cmd = New MySqlCommand("Select* from  classes order by school_year desc, grade asc", cnn)
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
                yeardo = years & "/" & years Mod 100 + 1 & " " & grade
                cmbVipusk.Items.Add(yeardo)
                cmbClass.Items.Add(grade)
                cmbYear.Items.Add(years)
                brRows = brRows + 1
            Loop
            'задаване на текст на cmbtaта
            cmbVipusk.Text = cmbVipusk.Items(0)
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
    End Sub

    Private Sub cmbVipusk_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbVipusk.Leave, cmbVipusk.DropDownClosed
        If cmbVipusk.Items.Count > 0 Then
            If (cmbVipusk.SelectedIndex = -1) Then
                cmbVipusk.Text = cmbVipusk.Items(0)
                cmbVipusk.Focus()
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
                cmbClass.Text = cmbClass.Items(cmbVipusk.SelectedIndex)
                cmbYear.Text = cmbYear.Items(cmbVipusk.SelectedIndex)
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
        Else
            cmbVipusk.Text = ""
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
                            If cmbsrokid.Text = -1 Then
                                cmd = New MySqlCommand("Select* from  absence where class='" & idclass & "'", cnn)
                            Else
                                cmd = New MySqlCommand("Select* from  absence where class='" & idclass & "'and time='" & cmbsrok.Text & "'", cnn)
                            End If
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

    Private Sub btnchart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnchart.Click
        If dgv1.RowCount > 0 Then
            title1 = "Спавка"
            title2 = "Съотношение на отсъствията по класове за: " & cmbVipusk.Text & " година, пeриод: " & cmbsrok.Text
            If flagbtn = 1 Then
                Do While Chart1.Series.Count > 0
                    Chart1.Series.Remove(Chart1.Series.Item(0))
                Loop
                Chart1.Series.Add("Otnoshenie")
                Chart1.Series(0).ChartType = 17
                Chart1.Titles.Remove(Chart1.Titles.Item(0))
                Chart1.Titles.Remove(Chart1.Titles.Item(0))
            End If
            Chart1.Titles.Add(title1)
            Chart1.Titles.Add(title2)
            Try
                cnn.Open()
                cnn.Close()
            Catch ex As Exception
                MsgBox("Грешка в базата данни! ! !")
                Application.Exit()
            End Try
            cnn.Open()
            Dim ci, cni As Double
            Dim srok As String
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
                Dim brrows2 As Integer
                brrows2 = 0
                'записване на сойности в dgv1
                prb1.Value = 0
                prb1.Maximum = data.Rows.Count
                ci = 0
                cni = 0
                 Do While brrows2 < data.Rows.Count
                    ci = ci + data.Rows(brrows2).Item("count_excused")
                    cni = cni + data.Rows(brrows2).Item("count_unexcused")
                    brrows2 = brrows2 + 1
                    prb1.Value = prb1.Value + 1
                Loop
                flagbtn = 1

                Chart1.Series(0).Points.AddXY("Извинени " & ci, ci)
                Chart1.Series(0).Points.AddXY("Незвинени " & cni, cni)
                Chart1.Series(0)("PieLabelStyle") = "Outside"
                flagbtn = 1
            End If
            cnn.Close()
            Me.Height = 725
        Else
            MsgBox("Трябва да се върнете и да веведете отсъствия ! ! !", , "Справка")
        End If
    End Sub
    Public Sub strcob(ByRef s As String)
        Dim srok As String
        srok = cmbsrok.Text

        If srok = cmbsrok.Items(2) Then
            s = "SELECT classes.grade, classes.class, classes.school_year,sum(absence.count_excused) as count_excused, sum(absence.count_unexcused) as count_unexcused"
            s = s & " FROM classes Inner join absence ON classes.id=absence.class Where school_year='" & cmbYear.Text & "'and grade='" & cmbClass.Text & "' Group by absence.class;"
        Else
            s = "SELECT classes.grade, classes.class, classes.school_year,absence.count_excused, absence.count_unexcused"
            s = s & " FROM classes Inner join absence ON classes.id=absence.class Where school_year='" & cmbYear.Text & "'and grade='" & cmbClass.Text
            If srok = cmbsrok.Items(0) Then
                s = s & "' and time=1;"
            ElseIf srok = cmbsrok.Items(1) Then
                s = s & "' and time=2;"
            End If
        End If
        Return
    End Sub

    Private Sub reference_absence_va_Vipusk_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'изтриване на старите сойности в dgv1
        Do While dgv1.RowCount > 0
            dgv1.Rows.Remove(dgv1.Rows(0))
        Loop
        Me.Height = 365
        'Проверка дали chart1 е празно и  изтриване настъойностите му
        If flagbtn = 1 Then
            Do While Chart1.Series.Count > 0
                Chart1.Series.Remove(Chart1.Series.Item(0))
            Loop
            Chart1.Series.Add("Otnoshenie")
            Chart1.Series(0).ChartType = 17
            Chart1.Titles.Clear()
        End If

        Do While cmbYear.Items.Count > 0
            cmbVipusk.Items.Remove(cmbVipusk.Items(0))
            cmbYear.Items.Remove(cmbYear.Items(0))
            cmbClass.Items.Remove(cmbClass.Items(0))
        Loop

        prb1.Value = 0
    End Sub

    Private Sub btnExselNewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExselNewFile.Click
        If cmbYear.Text <> "" Then
            title1 = "Спавка"
            title2 = "Съотношение на отсъствията по класове за: " & cmbVipusk.Text & " година, пeриод: " & cmbsrok.Text
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
                xlsheet = xlbook.Sheets("sheet1")
                xlsheet.Name = "Съотношение на отсъствията"
                Const xlCenter = -4108
                'задаване на текст в клетки и форматиране на редове и колони
                xlsheet.Range(xlsheet.Cells(1, 1), xlsheet.Cells(1, 2)).Merge()
                xlsheet.Range(xlsheet.Cells(1, 1), xlsheet.Cells(1, 2)).HorizontalAlignment = xlCenter
                xlsheet.Cells(1, 1) = title1
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 2)).Merge()
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 2)).HorizontalAlignment = xlCenter
                xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, 2)).WrapText = True
                xlsheet.Cells(2, 1) = title2
                xlsheet.Cells(3, 1) = "Извинени"
                xlsheet.Cells(4, 1) = "Неизвинени"
                xlsheet.Range(xlsheet.Cells(3, 1), xlsheet.Cells(3, 3)).HorizontalAlignment = xlCenter
                xlsheet.Range("A3").EntireColumn.ColumnWidth = 20
                xlsheet.Range("B3").EntireColumn.ColumnWidth = 15
                xlsheet.Range("C3").EntireColumn.ColumnWidth = 15
                xlsheet.Range("A2").EntireRow.RowHeight = 45
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
                    myChart = xlCharts.Add(5, 100, 180, 150)
                    chartPage = myChart.Chart
                    chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlColumnClustered
                    Dim brrows2 As Integer
                    brrows2 = 0
                    Dim cni, ci As Double
                    Dim br As Integer = 4
                    'записване на сойности в dgv1
                    prb1.Value = 0
                    prb1.Maximum = data.Rows.Count
                    cni = 0
                    ci = 0
                    Do While brrows2 < data.Rows.Count
                        ci = ci + data.Rows(brrows2).Item("count_excused")
                        cni = cni + data.Rows(brrows2).Item("count_unexcused")

                        brrows2 = brrows2 + 1
                        prb1.Value = prb1.Value + 1
                    Loop
                    xlsheet.Cells(3, 2) = ci
                    xlsheet.Cells(4, 2) = cni
                    xlsheet.Range(xlsheet.Cells(3, 1), xlsheet.Cells(4, 2)).HorizontalAlignment = xlCenter
                    chartRange = xlsheet.Range("A3:B4")
                    chartPage.SetSourceData(Source:=chartRange)
                    chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlPie


                    ' Смаляване на формата
                    Me.Height = 365
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
                    ws.Name = "Съотношение на отсъствията"
                    title1 = "Спавка"
                    title2 = "Съотношение на отсъствията по класове за: " & cmbVipusk.Text & " година, пeриод: " & cmbsrok.Text
                    Dim xldi As Microsoft.Office.Interop.Excel.Chart
                    xldi = New Microsoft.Office.Interop.Excel.Chart
                    Const xlCenter = -4108
                    'задаване на текст в клетки и форматиране на редове и колони
                    ws.Range(ws.Cells(1, 1), ws.Cells(1, 2)).Merge()
                    ws.Range(ws.Cells(1, 1), ws.Cells(1, 2)).HorizontalAlignment = xlCenter
                    ws.Cells(1, 1) = title1
                    ws.Range(ws.Cells(2, 1), ws.Cells(2, 2)).Merge()
                    ws.Range(ws.Cells(2, 1), ws.Cells(2, 2)).HorizontalAlignment = xlCenter
                    ws.Range(ws.Cells(2, 1), ws.Cells(2, 2)).WrapText = True
                    ws.Cells(2, 1) = title2
                    ws.Cells(3, 1) = "Извинени"
                    ws.Cells(4, 1) = "Неизвинени"
                    ws.Range(ws.Cells(3, 1), ws.Cells(3, 3)).HorizontalAlignment = xlCenter
                    ws.Range("A3").EntireColumn.ColumnWidth = 20
                    ws.Range("B3").EntireColumn.ColumnWidth = 15
                    ws.Range("C3").EntireColumn.ColumnWidth = 15
                    ws.Range("A2").EntireRow.RowHeight = 45

                    Dim chartPage As Microsoft.Office.Interop.Excel.Chart
                    Dim xlCharts As Microsoft.Office.Interop.Excel.ChartObjects
                    Dim myChart As Microsoft.Office.Interop.Excel.ChartObject
                    Dim chartRange As Microsoft.Office.Interop.Excel.Range
                    xlCharts = ws.ChartObjects
                    myChart = xlCharts.Add(5, 100, 180, 150)
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
                    Dim brrows2 As Integer
                    brrows2 = 0
                    Dim cni, ci As Double
                    Dim br As Integer = 4
                    'записване на сойности в dgv1
                    prb1.Value = 0
                    prb1.Maximum = data.Rows.Count
                    Do While brrows2 < data.Rows.Count
                        ci = ci + data.Rows(brrows2).Item("count_excused")
                        cni = cni + data.Rows(brrows2).Item("count_unexcused")

                        brrows2 = brrows2 + 1
                        prb1.Value = prb1.Value + 1
                    Loop
                    ws.Cells(3, 2) = ci
                    ws.Cells(4, 2) = cni
                    ws.Range(ws.Cells(3, 1), ws.Cells(4, 2)).HorizontalAlignment = xlCenter
                    chartRange = ws.Range("A3:B4")
                    chartPage.SetSourceData(Source:=chartRange)
                    chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlPie
                    ws.Copy(, masterWb.Sheets(masterWb.Sheets.Count))
                    ws = Nothing
                    xlWorkBook.Save()
                    xlWorkBook.Close()
                    xlWorkBook = Nothing
                    'Смаляване на формата
                    Me.Height = 365
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
                title2 = "Съотношение на отсъствията по класове за: " & cmbVipusk.Text & " година, пeриод: " & cmbsrok.Text
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
                Dim brrows2 As Integer
                brrows2 = 0
                Dim cni, ci As Double
                Dim br As Integer = 0

                'записване на сойности в dgv1
                prb1.Value = 0
                prb1.Maximum = data.Rows.Count
                Do While brrows2 < data.Rows.Count
                    ci = ci + data.Rows(brrows2).Item("count_excused")
                    cni = cni + data.Rows(brrows2).Item("count_unexcused")

                    brrows2 = brrows2 + 1
                    prb1.Value = prb1.Value + 1
                Loop

                oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, 2, 2)
                oTable.Cell(1, 1).Range.Text = "Извинени"
                oTable.Cell(2, 1).Range.Text = "Неизвинени"
                oTable.Cell(1, 2).Range.Text = ci
                oTable.Cell(2, 2).Range.Text = cni
                Dim br3 As Integer = 0

                'форматиране на таблицата
                oTable.Range.Style = "Table Grid"
                'смаляване на формата
                Me.Height = 365
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
End Class