using Common.EventParam;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Port
{
    public class PortCla
    {

        private byte[] bytes = new byte[29] { 0x7C, 0x7C, 0x3E, 0x47, 0x45, 0x54, 0x20, 0x44, 0x45, 0x56, 0x49, 0x43, 0x45, 0x2E, 0x53, 0x45, 0x52, 0x49, 0x41, 0x4C, 0x2D, 0x4E, 0x55, 0x4D, 0x42, 0x45, 0x52, 0x0D, 0x0A };
        private SerialPort sp;
        private int length;
        private string strPro;
        public string date { get; set; }

        public event EventHandler<CustomEventArgs> CustoEvent;
        private string dveIDName { get; set; }
        /// <summary>
        /// 串口读码器初始化
        /// </summary>
        public PortCla(SerialPort sp, string strPro, int length)
        {
            this.sp = sp;
            this.strPro = strPro;
            this.length = length;
        }

        #region "port初始化,ReceivedBytesThreshold根据设置的字节首次触发DataReceived，后是大概1个字节触发一次，但不能保证"
        public void PortInit()
        {
            string[] strPortPro = this.strPro.Split(',');
            if (strPortPro.Length == 5)
            {
                PortPro portPro = new PortPro()
                {
                    PortName = strPortPro[0],
                    BaudRate = int.Parse(strPortPro[1]),
                    DataBits = int.Parse(strPortPro[2]),
                    StopBits = strPortPro[3],
                    Parity = strPortPro[4],
                    WriteTimeout = 1000,
                    ReadTimeout = 1000,
                    ReceivedBytesThreshold = 1
                };
                this.sp.PortName = portPro.PortName;
                this.sp.BaudRate = portPro.BaudRate;
                this.sp.DataBits = portPro.DataBits;
                StrToStopbite(portPro.StopBits);
                StrToParity(portPro.Parity);
                this.sp.WriteTimeout = portPro.WriteTimeout;
                this.sp.ReadTimeout = portPro.ReadTimeout;
                this.sp.ReceivedBytesThreshold = portPro.ReceivedBytesThreshold;
                this.sp.DataReceived += new SerialDataReceivedEventHandler(DataReceive_Method);

            }
            else
            {
                return;
            }

        }
        #endregion

        #region "portOpen"
        public void PortOpen()
        {
            try
            {
                PortInit();
                date = "";
                if (this.sp.IsOpen == false)
                {
                    this.sp.Open();
                }
                else
                {
                    this.sp.Close();
                    this.sp.Open();
                }
            }
            catch (Exception ex)
            {
                WriteLog.WriteTextLog(ex, "串口读码器:" + ex.Message, "");
            }
        }
        #endregion

        #region "portClose"
        public void PortClose()
        {
            if (this.sp.IsOpen)
            {
                this.sp.Close();
            }
            date = "";
        }
        #endregion

        private void DataReceive_Method(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {

                do
                {
                    int count = this.sp.BytesToRead;
                    if (count <= 0)
                    {
                        break;
                    }
                    byte[] g_RS232DataBuff = new byte[count];
                    this.sp.Read(g_RS232DataBuff, 0, count);

                    foreach (byte b in g_RS232DataBuff)
                    {
                        date += Convert.ToChar(b);
                    }
                    //comDate = Encoding.ASCII.GetString(g_RS232DataBuff);
                }
                while (this.sp.BytesToRead > 0);

                if (date.Substring(date.Length - 2, 2) == Environment.NewLine)
                {
                    CustomEventArgs obj = new CustomEventArgs() { data = date };
                    if (CustoEvent != null && !string.IsNullOrEmpty(obj.data))
                    {
                        WriteLog.WriteTextLog(null, string.Format("读码容为：{0},码长度为：{1}", date, date.Length), "");
                        date = "";
                        CustoEvent(this, obj);
                       
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public void PortSendByte(byte[] bytes)
        {
            if (bytes.Length == 0)
            {
                return;
            }
            this.sp.Write(bytes, 0, bytes.Length);
            Thread.Sleep(2000);
        }
        /// <summary>
        /// 判断当前读码器SN是否在配置范围内
        /// </summary>
        /// <returns></returns>
        public void GetSerialNum()
        {
            PortSendByte(bytes);
        }
        
        #region "port的状态"
        public int PortSatte()
        {
            int i = 0;
            if (sp != null)
            {
                if (this.sp.IsOpen)
                {
                    i = 1;//1表示串口已连接
                }
                else
                {
                    i = 0;
                }
            }
            return i;
        }
        #endregion

        #region "port停止位及校验位的换算"
        private void StrToStopbite(string str)
        {
            if (str == "None")
            {
                this.sp.StopBits = StopBits.None;
            }
            else if (str == "One")
            {
                this.sp.StopBits = StopBits.One;
            }
            else if (str == "OnePointFive")
            {
                this.sp.StopBits = StopBits.OnePointFive;
            }
            else if (str == "Two")
            {
                this.sp.StopBits = StopBits.Two;
            }
        }

        private void StrToParity(string str)
        {
            if (str == "Even")
            {
                this.sp.Parity = Parity.Even;
            }
            else if (str == "Mark")
            {
                this.sp.Parity = Parity.Mark;
            }
            else if (str == "None")
            {
                this.sp.Parity = Parity.None;
            }
            else if (str == "Odd")
            {
                this.sp.Parity = Parity.Odd;
            }
            else if (str == "Space")
            {
                this.sp.Parity = Parity.Space;
            }
        }
        #endregion





    }
}
