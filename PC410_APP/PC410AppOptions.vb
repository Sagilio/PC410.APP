Imports System.Windows.Forms.DataVisualization.Charting

Public Class PC410AppOptions
    '设置通信地址使用
    Public bln_OP As Boolean = False '输出功率
    Public bln_CH As Boolean = False '当前程序编号
    Public bln_SE As Boolean = False '当前运行的程序段号
    Public NowSaveTextType As String
    Public NowSaveImageType As String
    Public NowButComAdress As String
    Public NowProgessNumber As String
    Public NowTxtSendCycle As String
    Public NowProgessNumberPoint As String
    Public AutoBufferClear As Boolean
    Public Sub _ini_PC410AppOptions()
        AutoBufferClear = True

        NowButComAdress = "53"
        NowProgessNumber = "1"
        NowTxtSendCycle = " 500毫秒"
        NowProgessNumberPoint = "1"
    End Sub

    Private Sub PC410AppOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '设置可选择程序编号的值，最小为1最大为9，该仪器仅支持9段每段程序可支持16个点。
        NumericUpDown_progress_Number.Maximum = 9
        NumericUpDown_progress_Number.Minimum = 1
        If Main.Timer1.Enabled = False Then
            TxtSendCycle.Enabled = False
        End If
    End Sub
    Private Sub Form_Unload(Cancel As Integer)
        Cancel = 1
        Hide()
    End Sub
    Private Sub Set_progess_number_Click(sender As Object, e As EventArgs) Handles set_progess_number.Click
        Set_Camand("ch", NumericUpDown_progress_Number.Value)
        NowProgessNumber = NumericUpDown_progress_Number.Value

        Main.LoadNowState()
    End Sub
    '设置温度曲线
    Dim SeriesPV As New Series
    Dim seriesSV As New Series
    Dim dot_int As Integer = 0
    Dim ChartAreas1 As New ChartArea
    Dim ini_temperature As Integer = 30    '主要用于保存上一步产生的温度值，使于设置曲线的生成
    Dim total_time As Integer = 0                 '主要用于保存总时间
    Private Sub TabPage_PrOptions_Apply_Click(sender As Object, e As EventArgs) Handles TabPage_PrOptions_Apply.Click
        seriesSV.Points.Clear()
        SeriesPV.Points.Clear()
        If dot_int <= 10 Then
            dot_int += 1
            '设置程序控温的参数点，升温速率、达到的温度值及该温度下保温时间
            Main.LabelProgessPoint.Text = "当前程序段号：" & dot_int
            Set_Camand("r" & dot_int, TextBox_rate.Text)
            If Main.GetparameterIsTrue = False Then
                dot_int -= 1
                Exit Sub
            End If
            SetSuccess()
            Main.TxtbufferShow.AppendText("当前升温速度：" & TextBox_rate.Text & vbCrLf)
            System.Threading.Thread.Sleep(100)
            Set_Camand("l" & dot_int, TextBox_temperature.Text)
            If Main.GetparameterIsTrue = False Then
                dot_int -= 1
                Exit Sub
            End If
            Main.TxtbufferShow.AppendText("当前速度：" & TextBox_temperature.Text & vbCrLf)
            SetSuccess()
            System.Threading.Thread.Sleep(100)
            Set_Camand("t" & dot_int, TextBox_keepwarm.Text)
            If Main.GetparameterIsTrue = False Then
                dot_int -= 1
                Exit Sub
            End If
            Main.TxtbufferShow.AppendText("当前保温时长：" & TextBox_keepwarm.Text & vbCrLf)
            SetSuccess()

            NowProgessNumberPoint = dot_int + 1

            '此处需要设置自动停止，使温曲线达到该处自动停止。
            dot_int += 1
            Set_Camand("r" & dot_int, "-0.01") '停止（END）命令
            Main.TxtbufferShow.AppendText("已经设置自动停止！" & vbCrLf)
            dot_int -= 1

            '对设置曲线进行绘制
            seriesSV.Points.AddXY(total_time, ini_temperature) '绘制第一个点
            Dim time_rate As Double = (TextBox_temperature.Text - ini_temperature) / TextBox_rate.Text
            total_time = total_time + Math.Abs(time_rate)
            ini_temperature = TextBox_temperature.Text
            seriesSV.Points.AddXY(total_time, ini_temperature) '绘制第二个点，为升温后的点
            total_time = total_time + TextBox_keepwarm.Text
            seriesSV.Points.AddXY(total_time, ini_temperature) '绘制第三个点，为保温后的点
        Else
            TabPage_PrOptions_Apply.Enabled = False
            MsgBox("超出仪器限度！")
        End If

        Main.LoadNowState()
    End Sub
    '发送命令
    Dim addr1 As String     '地址第一位数
    Dim addr2 As String     '地址第二位数

    Private Sub TabPage_ButOptions_Apply_Click(sender As Object, e As EventArgs) Handles TabPage_ButOptions_Apply.Click
        Main.SerialPort1.BaudRate = Val(ComboBoxBR.Text)
        Main.SerialPort1.DataBits = Val(ComboBoxDB.Text)
        Select Case ComboBoxPr.Text
            Case "None"
                Main.SerialPort1.Parity = IO.Ports.Parity.None
                Exit Select
            Case "Even"
                Main.SerialPort1.Parity = IO.Ports.Parity.Even
                Exit Select
            Case "Odd"
                Main.SerialPort1.Parity = IO.Ports.Parity.Odd
                Exit Select
            Case "Mark"
                Main.SerialPort1.Parity = IO.Ports.Parity.Mark
                Exit Select
            Case "Space"
                Main.SerialPort1.Parity = IO.Ports.Parity.Space
                Exit Select
        End Select
        Select Case ComboBoxSP.Text
            Case "1"
                Main.SerialPort1.StopBits = IO.Ports.StopBits.One
                Exit Select
            Case "1.5"
                Main.SerialPort1.StopBits = IO.Ports.StopBits.OnePointFive
                Exit Select
            Case "2"
                Main.SerialPort1.StopBits = IO.Ports.StopBits.Two
        End Select
        Select Case ComboBoxQC.Text
            Case "None"
                Main.SerialPort1.Handshake = IO.Ports.Handshake.None
                Exit Select
            Case "RTS"
                Main.SerialPort1.Handshake = IO.Ports.Handshake.RequestToSend
                Exit Select
            Case "XOn/XOff"
                Main.SerialPort1.Handshake = IO.Ports.Handshake.XOnXOff
                Exit Select
            Case "RTSXOn/XOff"
                Main.SerialPort1.Handshake = IO.Ports.Handshake.RequestToSendXOnXOff
        End Select
        Main.TxtbufferShow.AppendText("串口参数修改完成 !" & vbCrLf)

        If Main.Timer1.Enabled = True Then
            MsgBox("请停止读取PV值！")
        Else
            Main.Timer1.Interval = Val(TxtSendCycle.Text) * 2
        End If

    End Sub

    Private Sub TabPage_ButOptions_OK_Click(sender As Object, e As EventArgs) Handles TabPage_ButOptions_OK.Click
        TabPage_ButOptions_Apply_Click(sender, e)
        Hide()
    End Sub

    Private Sub TabPage_Options_Cancel_Click(sender As Object, e As EventArgs) _
    Handles TabPage_ButOptions_Cancel.Click, TabPage_DataOptions_Cancel.Click, TabPage_PrOptions_Cancel.Click, TabPage_ComOptions_Cancel.Click
        Hide()
    End Sub

    Private Sub TabPage_PrOptions_OK_Click(sender As Object, e As EventArgs) Handles TabPage_PrOptions_OK.Click
        Hide()
    End Sub

    Private Sub TabPage_DataOptions_Apply_Click(sender As Object, e As EventArgs) Handles TabPage_DataOptions_Apply.Click
        If CheckBox_bln_OP.Checked = True Then
            bln_OP = True
        End If
        If CheckBox_bln_CH.Checked = True Then
            bln_CH = True
        End If
        If CheckBox_bln_SE.Checked = True Then
            bln_SE = True
        End If

        PC410AppSaveModule.SaveFolder = DataSaveFolder.Text _
             & "\" & Format(Now, "yyyy年MM月dd日 ") & Format(Now, "hh_mm_ss") & " 实验数据."
        PC410AppSaveModule._ini_SaveFolder = DataSaveFolder.Text & "\" & "_ini_."

        If RadioButton_png.Checked = True Then
            NowSaveImageType = PC410AppSaveModule.SaveImageType(0)
        ElseIf RadioButton_jpg.Checked = True Then
            NowSaveImageType = PC410AppSaveModule.SaveImageType(1)
        ElseIf RadioButton_bmp.Checked = True Then
            NowSaveImageType = PC410AppSaveModule.SaveImageType(2)
        Else
            NowSaveImageType = PC410AppSaveModule.SaveImageType(3)
        End If
        If RadioButton_txt.Checked = True Then
            NowSaveTextType = PC410AppSaveModule.SaveTextType(0)
        ElseIf RadioButton_xls.Checked = True Then
            NowSaveTextType = PC410AppSaveModule.SaveTextType(1)
        ElseIf RadioButton_xlsx.Checked = True Then
            NowSaveTextType = PC410AppSaveModule.SaveTextType(2)
        Else
            NowSaveTextType = PC410AppSaveModule.SaveTextType(3)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim SaveFolder As String
        FolderSaveBrowserDialog.Description = "请选择用来保存数据的文件夹："
        FolderSaveBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop
        FolderSaveBrowserDialog.ShowNewFolderButton = True

        If FolderSaveBrowserDialog.ShowDialog() = DialogResult.OK Then
            SaveFolder = FolderSaveBrowserDialog.SelectedPath
            DataSaveFolder.Text = SaveFolder

        End If
    End Sub

    Private Sub TabPage_DataOptions_OK_Click(sender As Object, e As EventArgs) Handles TabPage_DataOptions_OK.Click
        TabPage_DataOptions_Apply_Click(sender, e)
        Hide()
    End Sub

    Private Sub ButComAddress_Click(sender As Object, e As EventArgs)
        SetButComAddress(TxtAddress.Text)
        NowButComAdress = TxtAddress.Text
        Main.TxtbufferShow.AppendText("已手动设置通讯地址为：" & NowButComAdress & vbCrLf)

        Main.LoadNowState()
    End Sub

    Private Sub TabPage_ComOptions_Apply_Click(sender As Object, e As EventArgs) Handles TabPage_ComOptions_Apply.Click
        '设置发送周期
        If Main.Timer1.Enabled = True Then
            Main.Timer1.Interval = Val(TxtSendCycle.Text) * 2
        End If

        Main.LoadNowState()
    End Sub

    Private Sub TabPage_ButOptions_Raw_Click(sender As Object, e As EventArgs) Handles TabPage_ButOptions_Raw.Click
        ComboBoxBR.Text = 9600
        ComboBoxDB.Text = 7
        ComboBoxPr.Text = "Even"
        ComboBoxSP.Text = 1
        ComboBoxQC.Text = "None"
    End Sub

    Private Sub TabPage_ComOptions_OK_Click(sender As Object, e As EventArgs) Handles TabPage_ComOptions_OK.Click
        TabPage_ComOptions_Apply_Click(sender, e)
        Hide()
    End Sub
End Class