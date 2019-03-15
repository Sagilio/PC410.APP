Imports NPOI.HSSF.UserModel
Imports NPOI.XSSF.UserModel
Imports System.IO
Imports NPOI.SS.UserModel
Imports System.Windows.Forms.DataVisualization.Charting

Module PC410AppSaveModule
    Public SaveFolder As String
    Public SaveImageType(3) As String
    Public SaveTextType(3) As String
    Public _ini_SaveFolder As String

    Public Sub _int_SaveModule()
        PC410AppOptions.DataSaveFolder.Text = Application.StartupPath
        PC410AppOptions.NowSaveImageType = "png"
        PC410AppOptions.NowSaveTextType = "txt"
        SaveFolder = PC410AppOptions.DataSaveFolder.Text _
             & "\" & Format(Now, "yyyy年MM月dd日 ") & Format(Now, "hh_mm_ss") & " 实验数据."
        _ini_SaveFolder = PC410AppOptions.DataSaveFolder.Text & "\" & "_ini_."

        SaveImageType(0) = "png"
        SaveImageType(1) = "jpeg"
        SaveImageType(2) = "bmp"
        SaveImageType(3) = "tiff"

        SaveTextType(0) = "txt"
        SaveTextType(1) = "xls"
        SaveTextType(2) = "xlsx"
        SaveTextType(3) = "xml"

    End Sub

    Public Sub CreateFolder(ByVal SaveType As String)

        Select Case SaveType

            Case SaveImageType(0)
                Main.ChartPicture.SaveImage(SaveFolder & SaveImageType(0), ChartImageFormat.Png)
            Case SaveImageType(1)
                Main.ChartPicture.SaveImage(SaveFolder & SaveImageType(1), ChartImageFormat.Jpeg)
            Case SaveImageType(2)
                Main.ChartPicture.SaveImage(SaveFolder & SaveImageType(2), ChartImageFormat.Bmp)
            Case SaveImageType(3)
                Main.ChartPicture.SaveImage(SaveFolder & SaveImageType(3), ChartImageFormat.Tiff)

            Case SaveTextType(0)

                Dim fs = New FileStream(SaveFolder & SaveTextType(0),
                             FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)
                My.Computer.FileSystem.WriteAllText(SaveFolder & SaveTextType(0), "时间" & vbTab & "PV" & vbTab & "SV" & vbCrLf, True)

        End Select

    End Sub
    Public Function _ini_CreateExcelFolder(ByVal SaveType As String) As Stream
        Dim fs As Stream = Nothing
        Select Case SaveType
            Case SaveTextType(1)
                fs = New FileStream(_ini_SaveFolder & SaveTextType(1),
                             FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)
            Case SaveTextType(2)
                fs = New FileStream(_ini_SaveFolder & SaveTextType(2),
                             FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)
            Case SaveTextType(3)
                fs = New FileStream(_ini_SaveFolder & SaveTextType(3),
                             FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)
        End Select
        Return fs
    End Function

    Public Function CreateExcelFolder(ByVal SaveType As String) As Stream
        Dim fs As Stream = Nothing
        Select Case SaveType
            Case SaveTextType(1)
                fs = New FileStream(SaveFolder & SaveTextType(1),
                             FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)
            Case SaveTextType(2)
                fs = New FileStream(SaveFolder & SaveTextType(2),
                             FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)
            Case SaveTextType(3)
                fs = New FileStream(SaveFolder & SaveTextType(3),
                             FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)
        End Select
        Return fs
    End Function

    Public Sub WriteTextTxt(ByVal Content1 As String, ByVal Content2 As String)
        My.Computer.FileSystem.WriteAllText(SaveFolder & SaveTextType(0), Content1 & Content2, True)
    End Sub

    Public Sub _ini_WriteTextExcel(ByVal SaveType As String)
        Select Case SaveType
            Case SaveTextType(1)
                Dim WorkBook As HSSFWorkbook = New HSSFWorkbook()
                Dim _ini_fs = _ini_CreateExcelFolder(SaveTextType(1))

                Dim sheet As HSSFSheet = WorkBook.CreateSheet("Sheet1")
                Dim row As HSSFRow = sheet.CreateRow(0)
                row.CreateCell(0).SetCellValue("时间")
                row.CreateCell(1).SetCellValue("PV")
                row.CreateCell(2).SetCellValue("SV")

                WorkBook.Write(_ini_fs)
                _ini_fs.Close()

                row = Nothing
                sheet = Nothing
                WorkBook = Nothing

            Case SaveTextType(2)
                Dim WorkBook As XSSFWorkbook = New XSSFWorkbook()
                Dim _ini_fs = CreateExcelFolder(SaveTextType(2))

                Dim sheet As XSSFSheet = WorkBook.CreateSheet("Sheet1")
                Dim row As XSSFRow = sheet.CreateRow(0)
                row.CreateCell(0).SetCellValue("时间")
                row.CreateCell(1).SetCellValue("PV")
                row.CreateCell(2).SetCellValue("SV")

                sheet.AutoSizeColumn(1)
                WorkBook.Write(_ini_fs)
                _ini_fs.Close()

                row = Nothing
                sheet = Nothing
                WorkBook = Nothing
            Case SaveTextType(3)
        End Select
    End Sub

    Public Sub WriteTextExcel(ByVal SaveType As String, ByVal Content As String,
                              ByVal RowNumber As Integer, ByVal CellNumber As Integer)
        Select Case SaveType
            Case SaveTextType(1)
                Dim _ini_fs = New FileStream(_ini_SaveFolder & SaveTextType(1), FileMode.Open, FileAccess.Read)
                Dim WorkBook As HSSFWorkbook = New HSSFWorkbook(_ini_fs)
                Dim sheet As HSSFSheet = WorkBook.GetSheet("Sheet1")
                Dim cell As HSSFCell = sheet.CreateRow(RowNumber).CreateCell(CellNumber)

                cell = sheet.CreateRow(RowNumber).CreateCell(CellNumber)
                cell.SetCellValue(Content)

                sheet.ForceFormulaRecalculation = True

                Dim fs = CreateExcelFolder(SaveTextType(1))
                WorkBook.Write(fs)
                _ini_fs.Close()

                sheet = Nothing
                WorkBook = Nothing

            Case SaveTextType(2)
                Dim _ini_fs = New FileStream(_ini_SaveFolder & SaveTextType(1), FileMode.Open, FileAccess.Read)
                Dim WorkBook As XSSFWorkbook = New XSSFWorkbook(_ini_fs)
                Dim sheet As XSSFSheet = WorkBook.GetSheet("Sheet1")
                Dim cell As XSSFCell = sheet.CreateRow(RowNumber).CreateCell(CellNumber)

                cell = sheet.CreateRow(RowNumber).CreateCell(CellNumber)
                cell.SetCellValue(Content)

                sheet.ForceFormulaRecalculation = True

                Dim fs = CreateExcelFolder(SaveTextType(1))
                WorkBook.Write(fs)
                _ini_fs.Close()

                sheet = Nothing
                WorkBook = Nothing

            Case SaveTextType(3)

        End Select
    End Sub

    Public Function GetFileStream(ByVal fullFilePath As String) As ISheet
        Dim fileExtension = Path.GetExtension(fullFilePath)
        Dim sheetName As String
        Dim sheet As ISheet = Nothing

        Select Case fileExtension
            Case ".xlsx"

                Using fs = New FileStream(fullFilePath, FileMode.Open, FileAccess.Read)
                    Dim wb = New XSSFWorkbook(fs)
                    sheetName = wb.GetSheetAt(0).SheetName
                    sheet = CType(wb.GetSheet(sheetName), XSSFSheet)
                End Using

            Case ".xls"

                Using fs = New FileStream(fullFilePath, FileMode.Open, FileAccess.Read)
                    Dim wb = New HSSFWorkbook(fs)
                    sheetName = wb.GetSheetAt(0).SheetName
                    sheet = CType(wb.GetSheet(sheetName), HSSFSheet)
                End Using
        End Select

        Return sheet
    End Function
End Module
