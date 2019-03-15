Public Class cankao
    '以下均未使用
    Private Sub ButReadSV_Click(sender As Object, e As EventArgs)
        SendOrderReadSV()
    End Sub

    Private Sub ButClear_Click(sender As Object, e As EventArgs)
        TxtbufferShow.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Set_Camand("#4", "0001")
        SetSuccess()
        Button_start.Text = Hex(Asc("#"))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Set_Camand("#4", "0000")
        SetSuccess()
        Button_start.Text = Hex(Asc("#"))
    End Sub

    Public Sub SaveToExcel()
        Dim workbook As HSSFWorkbook = New HSSFWorkbook()
        Dim fs = New FileStream("C:\test.xls", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)

        'fs = File.OpenWrite("C:\test.xls") '建立一個Excel檔
        Dim sheet As HSSFSheet = workbook.CreateSheet(" Sheet1") ' 新增試算表 Sheet名稱
        Dim row As HSSFRow = sheet.CreateRow(0) '定義標題
        row.CreateCell(0).SetCellValue("標題1")
        row.CreateCell(1).SetCellValue("標題2")

        Dim i As Integer
        For i = 1 To 10
            Dim row_body As HSSFRow = sheet.CreateRow(i)
            Dim TP0 As String = "內容1"
            row_body.CreateCell(0).SetCellValue(TP0)
            Dim TP1 As String = "內容2"
            row_body.CreateCell(1).SetCellValue(TP1)
        Next
        sheet.AutoSizeColumn(1) '自動列寬
        workbook.Write(fs) '把該workbook寫到檔案裡
        fs.Close() '释放对象

        row = Nothing '释放对象
        sheet = Nothing '释放对象
        workbook = Nothing '释放对象
        System.Diagnostics.Process.Start("C:\test.xls") '打開excel檔案
    End Sub
    Public Sub SaveToExcelForXlsx()
        Dim workbook As XSSFWorkbook = New XSSFWorkbook()
        Dim fs = New FileStream("C:\test.xlsx", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)

        'fs = File.OpenWrite("C:\test.xls") '建立一個Excel檔
        Dim sheet As XSSFSheet = workbook.CreateSheet(" Sheet1") ' 新增試算表 Sheet名稱
        Dim row As XSSFRow = sheet.CreateRow(0) '定義標題
        row.CreateCell(0).SetCellValue("標題1")
        row.CreateCell(1).SetCellValue("標題2")

        Dim i As Integer
        For i = 1 To 10
            Dim row_body As XSSFRow = sheet.CreateRow(i)
            Dim TP0 As String = "內容1"
            row_body.CreateCell(0).SetCellValue(TP0)
            Dim TP1 As String = "內容2"
            row_body.CreateCell(1).SetCellValue(TP1)
        Next
        sheet.AutoSizeColumn(1) '自動列寬
        workbook.Write(fs) '把該workbook寫到檔案裡
        fs.Close() '释放对象

        row = Nothing '释放对象
        sheet = Nothing '释放对象
        workbook = Nothing '释放对象
        System.Diagnostics.Process.Start("C:\test.xlsx") '打開excel檔案
    End Sub

    '以下均为参考
    Private Sub A2() '方法2-導到Excel
        Dim workbook As HSSFWorkbook = New HSSFWorkbook()
        Dim cell As HSSFCell
        Dim font As HSSFFont = workbook.CreateFont
        Dim cs As HSSFCellStyle = workbook.CreateCellStyle
        font.FontHeightInPoints = 12 '設定字體大小
        font.FontName = "宋体" '設定字體
        cs.SetFont(font)

        Dim mystyle1 As HSSFCellStyle = workbook.CreateCellStyle
        mystyle1.DataFormat = HSSFDataFormat.GetBuiltinFormat("@") '設定格式1
        Dim mystyle2 As HSSFCellStyle = workbook.CreateCellStyle
        mystyle2.DataFormat = HSSFDataFormat.GetBuiltinFormat("0") '設定格式2
        Dim mystyle3 As HSSFCellStyle = workbook.CreateCellStyle
        mystyle3.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00") '設定格式3
        Dim TP0 As String
        Dim TP1 As Double
        Dim fs = New FileStream("C:\test2.xls", FileMode.Create) '準備建立一個Excel檔
        Dim sheet As HSSFSheet = workbook.CreateSheet("Sheet1") '== 新增試算表 Sheet名稱

        Dim row As HSSFRow = sheet.CreateRow(0) '定義標題
        row.CreateCell(0).SetCellValue("標題1")
        row.CreateCell(1).SetCellValue("標題2")
        row.CreateCell(2).SetCellValue("標題3")
        For i = 1 To 10
            TP0 = "測試1"
            cell = sheet.CreateRow(i).CreateCell(0) '注意-和第二列不同CreateRow
            cell.CellStyle = mystyle1 '使用格式1
            cell.SetCellValue(TP0) '填入值
            TP0 = 1000.123456
            cell = sheet.GetRow(i).CreateCell(1) '注意-和第一列不同GetRow
            cell.CellStyle = mystyle2 '使用格式2
            cell.CellStyle = cs '字體及大小
            cell.SetCellValue(TP1) '填入值
            TP0 = 1000.123456
            cell = sheet.GetRow(i).CreateCell(2)
            cell.CellStyle = mystyle3 '使用格式3
            cell.SetCellValue(TP1) '填入值
        Next
        For i = 0 To 2
            sheet.AutoSizeColumn(i) '自動列寬
        Next
        workbook.Write(fs) '把該workbook寫到檔案裡
        fs.Close() '释放对象
        sheet = Nothing '释放对象
        workbook = Nothing '释放对象
        System.Diagnostics.Process.Start("C:\test2.xls") '打開excel檔案
    End Sub
    Public Function GetRequestsDataFromExcel(ByVal fullFilePath As String) As DataTable
        Try
            Dim sh = GetFileStream(fullFilePath)
            Dim dtExcelTable = New DataTable()
            dtExcelTable.Rows.Clear()
            dtExcelTable.Columns.Clear()
            Dim headerRow = sh.GetRow(0)
            Dim colCount As Integer = headerRow.LastCellNum

            For c = 0 To colCount - 1
                dtExcelTable.Columns.Add(headerRow.GetCell(c).ToString())
            Next

            Dim i = 1
            Dim currentRow = sh.GetRow(i)

            While currentRow IsNot Nothing
                Dim dr = dtExcelTable.NewRow()

                For j = 0 To currentRow.Cells.Count - 1
                    Dim cell = currentRow.GetCell(j)

                    If cell IsNot Nothing Then
                        Select Case cell.CellType
                            Case CellType.Numeric
                                dr(j) = If(DateUtil.IsCellDateFormatted(cell), cell.DateCellValue.ToString(CultureInfo.InvariantCulture), cell.NumericCellValue.ToString(CultureInfo.InvariantCulture))
                            Case CellType.String
                                dr(j) = cell.StringCellValue
                            Case CellType.Blank
                                dr(j) = String.Empty
                        End Select
                    End If
                Next

                dtExcelTable.Rows.Add(dr)
                i += 1
                currentRow = sh.GetRow(i)
            End While

            Return dtExcelTable
        Catch e As Exception
            Throw
        End Try
    End Function


    Private Sub A3() '方法3-打开模板文件填入值
        Dim fs = New FileStream("C:\test2.xls", FileMode.Open, FileAccess.Read) '打開一個現有的Excel檔
        Dim workbook As HSSFWorkbook = New HSSFWorkbook(fs)
        Dim cell As HSSFCell
        Dim TP0 As String
        Dim sheet As HSSFSheet = workbook.GetSheet("Sheet1") '== 打開試算表 Sheet名稱
        TP0 = "填入測試"
        cell = sheet.CreateRow(11).CreateCell(0)
        cell.SetCellValue(TP0) '填入值
        sheet.ForceFormulaRecalculation = True
        Dim fs1 = New FileStream("C:\test3.xls", FileMode.Create) '另存一個Excel檔
        workbook.Write(fs1) '把該workbook寫到檔案裡
        fs.Close() '释放L对象
        fs1.Close() '释放L对象
        sheet = Nothing '释放L对象
        workbook = Nothing '释放对象
        System.Diagnostics.Process.Start("C:\test3.xls") '打開excel檔案
    End Sub


    '方法4 将DataGridView由Excel導出
    Private Sub A4()
        Dim i, n As Integer
        n = ImportExcel("C:\test4.xls").Rows.Count '筆數
        For i = 1 To n
            'DataGridView1.Item(0, i - 1).Value = ImportExcel("C:\test4.xls").Rows(i - 1).Item(0)
        Next
    End Sub

    Public Function ImportExcel(ByVal strSource As String) As DataTable
        Dim hssfWorkbook As IWorkbook
        Dim sheet As ISheet
        Dim rows As System.Collections.IEnumerator
        Dim dt As DataTable
        Dim icount As Int32
        Dim row As IRow
        Dim dr As DataRow
        Dim cell As ICell
        'hssfWorkbook = WorkbookFactory.Create(FileToStream(strSource)) '讀取Excel文檔
        sheet = hssfWorkbook.GetSheetAt(0) '读取当前表数据
        rows = sheet.GetRowEnumerator() '取得表数据值
        icount = 0
        dt = New DataTable()
        While rows.MoveNext()
            icount = icount + 1
            row = rows.Current
            dr = dt.NewRow
            For i As Int32 = 0 To row.LastCellNum
                cell = row.GetCell(i)
                If cell Is Nothing Then
                    'dr(i) = DBNull.Value
                Else
                    If icount = 1 Then
                        dt.Columns.Add(cell.ToString)
                    End If
                    dr(i) = cell.ToString
                End If
            Next
            dt.Rows.Add(dr)
        End While
        dt.Rows.RemoveAt(0)
        Return dt
    End Function

    Public Sub Main1()


        Dim filepath As String = "C:\test.xls"
        Dim hssfwb As HSSFWorkbook

        Using file As FileStream = New FileStream(filepath, FileMode.Open, FileAccess.Read)
            hssfwb = New HSSFWorkbook(file)
        End Using

        Dim sheet As ISheet = hssfwb.GetSheetAt(0)

        For row As Integer = 0 To sheet.LastRowNum

            If sheet.GetRow(row) IsNot Nothing Then
                sheet.GetRow(row).GetCell(0).SetCellValue("foo")
                Console.WriteLine("Row {0} = {1}", row, sheet.GetRow(row).GetCell(0).StringCellValue)
            End If
        Next

        Using file As FileStream = New FileStream(filepath, FileMode.Open, FileAccess.Write)
            hssfwb.Write(file)
        End Using

        Console.ReadLine()
    End Sub
End Class