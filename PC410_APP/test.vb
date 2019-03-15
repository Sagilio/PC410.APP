Public Class test
    Private Sub test_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Imports System
        Imports System.IO.Ports
        Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form1
        'Inherits System.Windows.Forms.Form
        Dim buffer As String
        Dim strPVD As String     'PV值
        Dim strSVD As String     'SV值
        Dim num As Short     '绘制图像专用
        Dim addr1 As String     '地址第一位数
        Dim addr2 As String     '地址第二位数
        Delegate Sub CallBack(ByVal strCallBack As String)  '定义委托
        Dim callback1 As New CallBack(AddressOf ShowString)
        Dim count_time As Double = 0
        '为读取仪器当前信息需要定义布尔变量
        Dim bln_PVandSV As Boolean = False '程序值或测量值，主要由于绘图
        Dim bln_OP As Boolean = False '输出功率
        Dim bln_ch As Boolean = False '当前程序编号
        Dim bln_SE As Boolean = False '当前运行的程序段号
        Sub ShowString(ByVal ComData As String)  '显示结果(定义一个实例)
            If bln_PVandSV = True Then
                If PV_or_SV = 1 Then
                    Me.TxtbufferShow.AppendText("测量值 " & vbTab & ComData & vbCrLf)
                    SeriesPV.Points.AddXY(count_time, ComData)
                    My.Computer.FileSystem.WriteAllText(dat_filepath, Now & vbTab, True)
                    My.Computer.FileSystem.WriteAllText(dat_filepath, ComData & vbTab, True)
                Else
                    Me.TxtbufferShow.AppendText("运行目标值：" & vbTab & ComData & vbCrLf)
                    seriesSV.Points.AddXY(count_time, ComData)

                End If
            End If
            bln_PVandSV = False
            If bln_ch = True Then
                Me.TxtbufferShow.AppendText("程序编号：" & vbTab & ComData & vbCrLf)
            End If
            bln_ch = False
            If bln_OP = True Then
                Me.TxtbufferShow.AppendText("当前功率：" & vbTab & ComData & vbCrLf)
            End If
            bln_OP = False
            If bln_SE = True Then
                Me.TxtbufferShow.AppendText("当前运行程序段号：" & vbTab & ComData & vbCrLf)
            End If
            bln_SE = False
        End Sub
        Sub DisPlayComData(ByVal strTemp As String)   '判断是否为跨线程
            If Me.TxtbufferShow.InvokeRequired Then
                Me.Invoke(callback1, New Object() {strTemp})
            Else
                Me.TxtbufferShow.AppendText(Now & strTemp & vbCrLf)
            End If
        End Sub
        '打开窗体时，判断串口是否打开，如果处于打开状态就立即 关闭
        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
            '使按钮控件不能用
            Me.Button_parameter_set.Enabled = False
            Me.ButComAddress.Enabled = False
            Me.set_progess_number.Enabled = False
            Me.ButSetSC.Enabled = False
            strPVD = ""
            strSVD = ""
            num = 0
            '获得计算机已经安装的串口，并将串口加载到combox项目，以供选择用。
            Dim portNames() As String = SerialPort.GetPortNames()
            If portNames.Length < 1 Then
                MsgBox（"无可用串口"）
            Else
                For i As Integer = 0 To portNames.Length - 1
                    ComboBoxName.Items.Add(portNames(i).ToString)
                Next
            End If

            Chart1.ChartAreas.Clear()
            Chart1.Series.Clear()
            Chart1.ChartAreas.Add(ChartAreas1)
            Chart1.Series.Add(SeriesPV)
            Chart1.Series.Add(seriesSV)
            Chart1.ChartAreas(0).AxisX.Title = "时间(s)"
            Chart1.ChartAreas(0).AxisY.Title = "温度(℃)"
            SeriesPV.ChartType = SeriesChartType.Line
            SeriesPV.LegendText = "PV"
            SeriesPV.Color = Color.Black
            seriesSV.ChartType = SeriesChartType.Line
            seriesSV.LegendText = "SV"
            '设置可选择程序编号的值，最小为1最大为9，该仪器仅支持9段每段程序可支持16个点。

            NumericUpDown_progress_Number.Maximum = 9
            NumericUpDown_progress_Number.Minimum = 1

        End Sub
        '选择串口号
        Private Sub ComboBoxName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxName.SelectedIndexChanged
            SerialPort1.PortName = ComboBoxName.Text
        End Sub
        '选择波特率值 
        Private Sub ComboBoxBR_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxBR.SelectedIndexChanged
            SerialPort1.BaudRate = Val(ComboBoxBR.Text)
        End Sub
        '选择数据位
        Private Sub ComboBoxDB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxDB.SelectedIndexChanged
            SerialPort1.DataBits = Val(ComboBoxDB.Text)
        End Sub
        '选择校验位
        Private Sub ComboBoxPr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxPr.SelectedIndexChanged
            Select Case ComboBoxPr.Text
                Case "None"
                    SerialPort1.Parity = IO.Ports.Parity.None
                    Exit Select
                Case "Even"
                    SerialPort1.Parity = IO.Ports.Parity.Even
                    Exit Select
                Case "Odd"
                    SerialPort1.Parity = IO.Ports.Parity.Odd
                    Exit Select
                Case "Mark"
                    SerialPort1.Parity = IO.Ports.Parity.Mark
                    Exit Select
                Case "Space"
                    SerialPort1.Parity = IO.Ports.Parity.Space
                    Exit Select
            End Select
        End Sub
        '选择停止位
        Private Sub ComboBoxSP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxSP.SelectedIndexChanged
            Select Case ComboBoxSP.Text
                Case "1"
                    SerialPort1.StopBits = IO.Ports.StopBits.One
                    Exit Select
                Case "1.5"
                    SerialPort1.StopBits = IO.Ports.StopBits.OnePointFive
                    Exit Select
                Case "2"
                    SerialPort1.StopBits = IO.Ports.StopBits.Two
            End Select
        End Sub

        Private Sub ComboBoxQC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxQC.SelectedIndexChanged
            Select Case ComboBoxQC.Text
                Case "None"
                    SerialPort1.Handshake = IO.Ports.Handshake.None
                    Exit Select
                Case "RTS"
                    SerialPort1.Handshake = IO.Ports.Handshake.RequestToSend
                    Exit Select
                Case "XOn/XOff"
                    SerialPort1.Handshake = IO.Ports.Handshake.XOnXOff
                    Exit Select
                Case "RTSXOn/XOff"
                    SerialPort1.Handshake = IO.Ports.Handshake.RequestToSendXOnXOff
            End Select
        End Sub

        Private Sub ButOpen_Click(sender As Object, e As EventArgs) Handles ButOpen.Click
            SerialPort1.ReceivedBytesThreshold = 10
            SerialPort1.Encoding = System.Text.Encoding.Default
            SerialPort1.Open()

            Me.Button_parameter_set.Enabled = True
            Me.ButComAddress.Enabled = True
            Me.set_progess_number.Enabled = True
            Me.ButSetSC.Enabled = True

            If SerialPort1.IsOpen = True Then
                LabelPort.Text = "串口已打开"
                LabelPort.ForeColor = Color.Green
            Else
                LabelPort.Text = "串口已关闭"
                LabelPort.ForeColor = Color.Red
                SerialPort1.Open()
            End If

        End Sub

        Private Sub ButClose_Click(sender As Object, e As EventArgs) Handles ButClose.Click

            If SerialPort1.IsOpen = True Then
                LabelPort.Text = "串口已打开"
                LabelPort.ForeColor = Color.Green
                SerialPort1.Close()
            Else
                LabelPort.Text = "串口已关闭"
                LabelPort.ForeColor = Color.Red
            End If
        End Sub
        Dim INi_num As Integer
        Dim PV_or_SV As Integer '=1 PV  如果=0 SV
        Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
            INi_num += 1
            bln_PVandSV = True
            PV_or_SV = INi_num Mod 2
            If PV_or_SV = 1 Then
                SendOrderReadPV()
            Else
                SendOrderReadSV()
            End If
            SerialPort1.DiscardOutBuffer()
            SerialPort1.DiscardInBuffer()
            count_time += Timer1.Interval / 1000 '计时，以秒为单位
        End Sub
        '接收仪器应答命令帧
        Private Sub SerialPort1_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
            Dim i As Integer
            Dim ByteToRead As Integer
            Dim Inbyte() As Byte
            ByteToRead = SerialPort1.BytesToRead
            buffer = ""
            ReDim Inbyte(ByteToRead)
            SerialPort1.Read(Inbyte, 0, ByteToRead)   '读取接收缓冲区内的命令帧
            For i = LBound(Inbyte) To UBound(Inbyte)
                buffer = buffer & Chr("&H" & Hex(Inbyte(i)))
            Next i
            Dim datastring As String = Nothing
            For j As Integer = 1 To buffer.Length - 2
                If IsNumeric(Mid(buffer, j, 1)) = True Then
                    datastring = datastring & Mid(buffer, j, 1)
                End If

            Next

            buffer = ""
            DisPlayComData(datastring)   '文本框显示接收到的命令帧

            datastring = ""
        End Sub

        Private Sub ButSendPV_Click(sender As Object, e As EventArgs) Handles ButSendPV.Click
            seriesSV.Points.Clear()
            bln_PVandSV = True  '程序值或测量值，主要由于绘图
            bln_OP = False '输出功率
            bln_ch = False '当前程序编号
            bln_SE = False '当前运行的程序段号
            If dat_filepath = Nothing Then
                MsgBox("请设置保存文件的位置！")
            Else
                Timer1.Start()
            End If

        End Sub

        Private Sub ButStopPV_Click(sender As Object, e As EventArgs) Handles ButStopPV.Click
            bln_PVandSV = False  '程序值或测量值，主要由于绘图
            bln_OP = False '输出功率
            bln_ch = False '当前程序编号
            bln_SE = False '当前运行的程序段号
            Timer1.Stop()

        End Sub

        Private Sub ButReadSV_Click(sender As Object, e As EventArgs)
            SendOrderReadSV()
        End Sub

        Private Sub ButComAddress_Click(sender As Object, e As EventArgs) Handles ButComAddress.Click
            Dim t1, t2 As Char
            t1 = Mid(TxtAddress.Text, 1, 1)
            t2 = Mid(TxtAddress.Text, 2, 1)
            addr1 = Hex(Asc(Val(t1)))
            addr2 = Hex(Asc(Val(t2)))

            '下面开始读取仪器的基本状态值 
            bln_PVandSV = True
            PV_or_SV = 1
            SendOrderReadPV()
            System.Threading.Thread.Sleep(300)
            SerialPort1.DiscardOutBuffer()
            SerialPort1.DiscardInBuffer()
            PV_or_SV = 0
            SendOrderReadSV()
            System.Threading.Thread.Sleep(300)

            SerialPort1.DiscardOutBuffer()
            SerialPort1.DiscardInBuffer()
            bln_ch = True
            SendOrderReadch()
            System.Threading.Thread.Sleep(300)

            SerialPort1.DiscardOutBuffer()
            SerialPort1.DiscardInBuffer()

            bln_OP = True
            SendOrderReadOP()
            System.Threading.Thread.Sleep(300)

            SerialPort1.DiscardOutBuffer()
            SerialPort1.DiscardInBuffer()
            bln_SE = True
            SendOrderReadSE()
            System.Threading.Thread.Sleep(300)

            SerialPort1.DiscardOutBuffer()
            SerialPort1.DiscardInBuffer()
        End Sub
        Private Sub ButSetSC_Click(sender As Object, e As EventArgs) Handles ButSetSC.Click
            If Timer1.Enabled = True Then
                MsgBox("请停止读取PV值！")
            Else
                Timer1.Interval = Val(TxtSendCycle.Text)
            End If
        End Sub
        '发送读取PV命令
        Private Sub SendOrderReadPV()
            Dim OrderPV(8) As Byte
            OrderPV(0) = Val("&H" & "04")
            OrderPV(1) = Val("&H" & addr1)
            OrderPV(2) = Val("&H" & addr1)
            OrderPV(3) = Val("&H" & addr2)
            OrderPV(4) = Val("&H" & addr2)
            OrderPV(5) = Val("&H" & "50")
            OrderPV(6) = Val("&H" & "56")
            OrderPV(7) = Val("&H" & "05")
            SerialPort1.Write(OrderPV, 0, 8) '请求PV值命令(16进制)
        End Sub
        '读取SP数据
        Private Sub SendOrderReadSV()
            Dim OrderSV(8) As Byte
            OrderSV(0) = Val("&H" & "04")
            OrderSV(1) = Val("&H" & addr1)
            OrderSV(2) = Val("&H" & addr1)
            OrderSV(3) = Val("&H" & addr2)
            OrderSV(4) = Val("&H" & addr2)
            OrderSV(5) = Val("&H" & "53")
            OrderSV(6) = Val("&H" & "50")
            OrderSV(7) = Val("&H" & "05")
            SerialPort1.Write(OrderSV, 0, 8)   '读取SV值命令（16进制）
        End Sub
        '读取输出功率值
        Private Sub SendOrderReadOP()
            Dim OrderSV(8) As Byte
            OrderSV(0) = Val("&H" & "04")
            OrderSV(1) = Val("&H" & addr1)
            OrderSV(2) = Val("&H" & addr1)
            OrderSV(3) = Val("&H" & addr2)
            OrderSV(4) = Val("&H" & addr2)
            OrderSV(5) = Val("&H" & "4F")
            OrderSV(6) = Val("&H" & "50")
            OrderSV(7) = Val("&H" & "05")
            SerialPort1.Write(OrderSV, 0, 8)   '读取SV值命令（16进制）
        End Sub
        '读取程序编号
        Private Sub SendOrderReadch()
            Dim OrderSV(8) As Byte
            OrderSV(0) = Val("&H" & "04")
            OrderSV(1) = Val("&H" & addr1)
            OrderSV(2) = Val("&H" & addr1)
            OrderSV(3) = Val("&H" & addr2)
            OrderSV(4) = Val("&H" & addr2)
            OrderSV(5) = Val("&H" & "63")
            OrderSV(6) = Val("&H" & "68")
            OrderSV(7) = Val("&H" & "05")
            SerialPort1.Write(OrderSV, 0, 8)   '读取SV值命令（16进制）
        End Sub
        '读取当前运行程序段号
        Private Sub SendOrderReadSE()
            Dim OrderSV(8) As Byte
            OrderSV(0) = Val("&H" & "04")
            OrderSV(1) = Val("&H" & addr1)
            OrderSV(2) = Val("&H" & addr1)
            OrderSV(3) = Val("&H" & addr2)
            OrderSV(4) = Val("&H" & addr2)
            OrderSV(5) = Val("&H" & "53")
            OrderSV(6) = Val("&H" & "45")
            OrderSV(7) = Val("&H" & "05")
            SerialPort1.Write(OrderSV, 0, 8)   '读取SV值命令（16进制）
        End Sub
        Private Sub Set_Camand(ByVal Comand_code As String, ByVal Setvalue As String)
            Dim comand_1 As String = Nothing
            Dim comand_2 As String = Nothing
            Dim set_data(6) As String
            If Len(Comand_code) = 2 Then '保证命令代码有效，有效值为2位ASCII
                '如果命令有效，提取字符并转为十六进制数
                comand_1 = Hex(Asc(Mid(Comand_code, 1, 1))) '提取命令值并转成可以用的十六进制数据
                comand_2 = Hex(Asc(Mid(Comand_code, 2, 1)))
            Else
                MsgBox("输入命令有误，请查正！")
            End If
            '判断输入的数据位，数据最长为7位。
            If IsNumeric(Setvalue) = True Then
                If Len(Setvalue) < 8 Then
                    Setvalue = Setvalue.ToString.PadLeft(7, “0"c) '如果数据不足七位，以零补齐七位
                    For i As Integer = 0 To Setvalue.Length - 1
                        set_data(i) = Hex(Asc(Mid(Setvalue, 1 + i, 1)))
                    Next
                End If
                Dim OrderSet(17) As Byte
                Dim BCC, BCCTemp As String

                OrderSet(0) = Val("&H" & "04") '命令的开始位（EOT）
                OrderSet(1) = Val("&H" & addr1) '命令的地位开始位（十六进制）
                OrderSet(2) = Val("&H" & addr1) '命令的地位开始位（十六进制）
                OrderSet(3) = Val("&H" & addr2) '命令的地位第二位（十六进制）
                OrderSet(4) = Val("&H" & addr2) '命令的地位第二位（十六进制）
                OrderSet(5) = Val("&H" & "02") '命令的间隔位（STX）
                OrderSet(6) = Val("&H" & comand_1) '命令符
                OrderSet(7) = Val("&H" & comand_2) '命令符
                OrderSet(8) = Val("&H" & set_data(0)) '参数位1
                OrderSet(9) = Val("&H" & set_data(1)) '参数位2
                OrderSet(10) = Val("&H" & set_data(2)) '参数位3
                OrderSet(11) = Val("&H" & set_data(3)) '参数位4
                OrderSet(12) = Val("&H" & set_data(4)) '参数位5
                OrderSet(13) = Val("&H" & set_data(5)) '参数位6
                OrderSet(14) = Val("&H" & set_data(6)) '参数位7
                OrderSet(15) = Val("&H" & "03") '停止位（ETX)
                '计算命令的校验位
                BCCTemp = Convert.ToByte(comand_1, 16) Xor Convert.ToByte(comand_2, 16) Xor Convert.ToByte(set_data(0), 16) Xor Convert.ToByte(set_data(1), 16) Xor Convert.ToByte(set_data(2), 16) Xor Convert.ToByte(set_data(3), 16) Xor Convert.ToByte(set_data(4), 16) Xor Convert.ToByte(set_data(5), 16) Xor Convert.ToByte(set_data(6), 16) Xor Convert.ToByte("03", 16)  '计算BCC的值
                BCC = Hex(BCCTemp)
                OrderSet(16) = Val("&H" & BCC) '命令校验位
                '发送修改SV值的命令(16进制)
                SerialPort1.Write(OrderSet, 0, 17)
            Else
                MsgBox("输入参数不正确，请重新输入！")
            End If

        End Sub
        '判断返回值是否正确的，如果命令参数已经在仪器上修改成功，则返回6否则返回15
        Private Sub SetSuccess()
            Dim strRx As String
            If SerialPort1.BytesToRead > 0 Then
                strRx = SerialPort1.ReadExisting.ToString    '读取来自串口的接收缓冲区的全部数据
                If Hex(Asc(strRx)) = "6" Then
                    TxtbufferShow.AppendText("命令参数已经修改成功！" & vbCrLf)
                End If
                If Hex(Asc(strRx)) = "15" Then
                    TxtbufferShow.AppendText("命令参数修改出现问题，请重新修改！" & vbCrLf)
                    MsgBox("命令参数修改出现问题，请重新修改！", MsgBoxStyle.Critical, "警告"）
                End If
                SerialPort1.DiscardInBuffer()    '丢弃来自串口的接收缓冲区的数据
            Else
                Exit Sub
            End If

        End Sub
        Dim SeriesPV As New Series
        Dim seriesSV As New Series
        Dim ChartAreas1 As New ChartArea
        Private Sub Set_progess_number_Click(sender As Object, e As EventArgs) Handles set_progess_number.Click
            Set_Camand("ch", NumericUpDown_progress_Number.Value)
        End Sub
        Dim dot_int As Integer = 0
        Dim ini_temperature As Integer = 30    '主要用于保存上一步产生的温度值，使于设置曲线的生成
        Dim total_time As Integer = 0 '主要用于保存总时间

        Dim r(9) As Integer
        Dim l(9) As Integer
        Dim t(9) As Integer
        Private Sub Button_parameter_set_Click(sender As Object, e As EventArgs) Handles Button_parameter_set.Click
            seriesSV.Points.Clear()
            SeriesPV.Points.Clear()
            If dot_int < 10 Then
                dot_int += 1
                '设置程序控温的参数点，升温速率、达到的温度值及该温度下保温时间
                Label19.Text = "当前程序点位于：" & dot_int
                Set_Camand("r" & dot_int, TextBox_rate.Text)
                r(dot_int - 1) = TextBox_rate.Text
                SetSuccess()
                TxtbufferShow.AppendText("当前升温速度：" & TextBox_rate.Text & vbCrLf)
                System.Threading.Thread.Sleep(100)
                Set_Camand("l" & dot_int, TextBox_temperature.Text)
                TxtbufferShow.AppendText("当前速度：" & TextBox_temperature.Text & vbCrLf)
                l(dot_int - 1) = TextBox_temperature.Text
                SetSuccess()
                System.Threading.Thread.Sleep(100)
                Set_Camand("t" & dot_int, TextBox_keepwarm.Text)
                t(dot_int - 1) = TextBox_keepwarm.Text
                TxtbufferShow.AppendText("当前保温时长：" & TextBox_keepwarm.Text & vbCrLf)
                SetSuccess()
                '此处需要设置自动停止，使温曲线达到该处自动停止。
                dot_int += 1
                System.Threading.Thread.Sleep(100)
                Set_Camand("r" & dot_int, "-0.01") '停止（END）命令
                TxtbufferShow.AppendText("已经设置自动停止！" & vbCrLf)
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
                Me.Button_parameter_set.Enabled = False
                MsgBox("超出仪器限度！")
            End If
        End Sub
        Private Sub Button_hold_Click(sender As Object, e As EventArgs) Handles Button_hold.Click
            Set_Camand("#3", "0002")
            SetSuccess()
        End Sub
        Private Sub Button_idle_Click(sender As Object, e As EventArgs) Handles Button_idle.Click
            Set_Camand("#3", "0000")
            SetSuccess()
        End Sub
        Private Sub Button_start_Click(sender As Object, e As EventArgs) Handles Button_start.Click
            Set_Camand("#3", "0001")
            SetSuccess()
        End Sub

        Dim dat_filepath As String = Nothing
        Private Sub Button_save__Click(sender As Object, e As EventArgs) Handles Button_save_.Click
            SaveFileDialog1.Filter = "txt files(txt)|*.txt|dat file|*.dat"
            SaveFileDialog1.RestoreDirectory = True
            Dim result As DialogResult = SaveFileDialog1.ShowDialog
            If result = DialogResult.OK Then
                dat_filepath = SaveFileDialog1.FileName.ToString
                TxtbufferShow.AppendText("当前数据文件保存位置：" & dat_filepath)
                My.Computer.FileSystem.WriteAllText(dat_filepath, "时间" & vbTab & "PV" & vbTab & "SV" & vbCrLf, True)
            End If
        End Sub

        Dim com_filepath As String = Nothing
        Private Sub Button_save_com_Click(sender As Object, e As EventArgs) Handles Button_save_com.Click
            SaveFileDialog1.Filter = "txt files(txt)|*.txt|dat file|*.dat"
            SaveFileDialog1.RestoreDirectory = True
            Dim result As DialogResult = SaveFileDialog1.ShowDialog
            If result = DialogResult.OK Then
                com_filepath = SaveFileDialog1.FileName.ToString
                TxtbufferShow.AppendText("串口属性保存位置：" & dat_filepath)
                My.Computer.FileSystem.WriteAllText(com_filepath, ComboBoxName.Text & vbTab & ComboBoxBR.Text & vbTab & ComboBoxDB.Text & vbTab & ComboBoxPr.Text & vbTab & ComboBoxSP.Text & vbTab & ComboBoxQC.Text, True)
            End If
        End Sub

        Private Sub Button_load_com_Click(sender As Object, e As EventArgs) Handles Button_load_com.Click
            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                com_filepath = OpenFileDialog1.FileName.ToString
                Dim fileContents As String
                fileContents = My.Computer.FileSystem.ReadAllText(com_filepath)
                Dim com_set() As String = Split(fileContents, vbTab)
                If com_set.Length > 4 Then
                    ComboBoxName.Text = com_set(0)
                    If IsNumeric(com_set(1)) = True Then
                        ComboBoxBR.Text = com_set(1)
                    Else
                        MsgBox("文件读取错误！")
                    End If
                    If IsNumeric(com_set(2）) = True Then
                        ComboBoxDB.Text = com_set(2)
                    Else
                        MsgBox("文件读取错误！")
                    End If
                    ComboBoxPr.Text = com_set(3)
                    ComboBoxSP.Text = com_set(4)
                    ComboBoxQC.Text = com_set(5)
                End If
            End If
        End Sub
        '保存控温曲线
        Private Sub Button_save_curvse_Click(sender As Object, e As EventArgs) Handles Button_save_curvse.Click
            SaveFileDialog1.Filter = "txt files(txt)|*.txt|dat file|*.dat"
            SaveFileDialog1.RestoreDirectory = True
            Dim result As DialogResult = SaveFileDialog1.ShowDialog
            If result = DialogResult.OK Then
                com_filepath = SaveFileDialog1.FileName.ToString
                TxtbufferShow.AppendText("控温曲线保存位置：" & dat_filepath)
                For i As Integer = 0 To dot_int - 1
                    My.Computer.FileSystem.WriteAllText(com_filepath, r(i) & vbTab & l(i) & vbTab & t(i) & vbCrLf, True)
                Next
            End If
        End Sub
        '加载曲线设置
        Private Sub Button_load_curvse_Click(sender As Object, e As EventArgs) Handles Button_load_curvse.Click
            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                com_filepath = OpenFileDialog1.FileName.ToString
                Dim fileContents As String
                fileContents = My.Computer.FileSystem.ReadAllText(com_filepath)
                If fileContents.Length > 3 Then
                    Dim curvse_line() As String = Split(fileContents, vbCrLf)
                    For i As Integer = 0 To curvse_line.Length - 1
                        Dim curvse_parameter() As String = Split(curvse_line(i), vbTab)
                        If curvse_parameter.Length = 3 Then
                            '读取数据对传递到串口中，
                        End If
                    Next
                Else
                    MsgBox("文件数据有问题，请查正再进行读取！")
                End If

            End If
        End Sub
    End Class