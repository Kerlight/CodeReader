using Common.EventParam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Common
{
    public class TcpClientCla
    {
        public event EventHandler<CustomEventArgs> CustoEvent;
        private byte[] bytes = new byte[29] { 0x7C, 0x7C, 0x3E, 0x47, 0x45, 0x54, 0x20, 0x44, 0x45, 0x56, 0x49, 0x43, 0x45, 0x2E, 0x53, 0x45, 0x52, 0x49, 0x41, 0x4C, 0x2D, 0x4E, 0x55, 0x4D, 0x42, 0x45, 0x52, 0x0D, 0x0A };
        private TcpClient client;
        private int length;
        private string _strPro;
        private string date { get; set; }

        private string dveIDName { get; set; }
        /// <summary>
        /// 网口读码器初始化
        /// </summary>
        /// <param name="client"></param>
        /// <param name="length"></param>
        /// <param name="context"></param>
        public TcpClientCla(TcpClient client, int length)
        {
            this.client = client;
            this.client.KeepAliveTime = 10000;
            this.length = length;
            this.date="";
            this.dveIDName="";
        }

        public void TcpClientOpen(string Ip,ushort port )
        {
            try
            {
                this.client.OnPrepareConnect += new TcpClientEvent.OnPrepareConnectEventHandler(OnPrepareConnect);
                this.client.OnConnect += new TcpClientEvent.OnConnectEventHandler(OnConnect);
                this.client.OnSend += new TcpClientEvent.OnSendEventHandler(OnSend);
                this.client.OnReceive += new TcpClientEvent.OnReceiveEventHandler(OnReceive);
                this.client.OnClose += new TcpClientEvent.OnCloseEventHandler(OnClose);
                if (this.client.Connetion(Ip, port, false) == false)
                {
                    throw new Exception("读码器启动失败，请关闭软件后检查配置及硬件");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString(), "武汉镭立提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void TcpClientClose()
        {
            try
            {
                this.client.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "武汉镭立提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void TcpClientSend(string send, ref string sendSuccess)
        {
            try
            {
                if (send.Length == 0)
                {
                    return;
                }

                byte[] bytes = Encoding.Default.GetBytes(send);
                IntPtr connId = client.ConnectionId;

                // 发送
                if (client.Send(bytes, bytes.Length))
                {
                    sendSuccess = send + "信号已输出";
                }
                else
                {
                    sendSuccess = send + "信号未输出";
                }
            }
            catch (Exception ex)
            {
                //AddMsg(string.Format("$ Send Fail -->  msg ({0})", ex.Message));
                WriteLog.WriteTextLog(ex, "TCP发送失败", null);
            }
        }

        public void TcpClientSendByte(byte[] bytes)
        {
            try
            {
                if (bytes.Length == 0)
                {
                    return;
                }
                // 发送
                if (client.Send(bytes, bytes.Length))
                {
                    Thread.Sleep(100);
                    WriteLog.WriteTextLog(null, "读取ID号成功", null);
                }
                else
                {
                    WriteLog.WriteTextLog(null, "读取ID号失败", null);
                }
            }
            catch (Exception ex)
            {
                //AddMsg(string.Format("$ Send Fail -->  msg ({0})", ex.Message));
                WriteLog.WriteTextLog(ex, "TCP发送失败", null);
            }
        }
        private HandleResult OnPrepareConnect(TcpClient sender, uint socket)
        {
            return HandleResult.Ok;
        }

        private HandleResult OnConnect(TcpClient sender)
        {
            // 已连接 到达一次
            // 如果是异步联接,更新界面状态
            //this.Invoke(new ConnectUpdateUiDelegate(ConnectUpdateUi));
            //AddMsg(string.Format(" > [{0},OnConnect]", sender.ConnectionId));           
            //更新界面状态
            return HandleResult.Ok;
        }
        private HandleResult OnSend(TcpClient sender, byte[] bytes)
        {
            // 客户端发数据了
            //AddMsg(string.Format(" > [{0},OnSend] -> ({1} bytes)", sender.ConnectionId, bytes.Length));

            return HandleResult.Ok;
        }
        private HandleResult OnClose(TcpClient sender, SocketOperation enOperation, int errorCode)
        {
            //if (errorCode == 0)
            //    // 连接关闭了
            //    AddMsg(string.Format(" > [{0},OnClose]", sender.ConnectionId));
            //else
            //    // 出错了
            //    AddMsg(string.Format(" > [{0},OnError] -> OP:{1},CODE:{2}", sender.ConnectionId, enOperation, errorCode));
            // 通知界面,只处理了连接错误,也没进行是不是连接错误的判断,所以有错误就会设置界面
            // 生产环境请自己控制

            return HandleResult.Ok;
        }

        private HandleResult OnReceive(TcpClient sender, byte[] bytes)
        {
            date = Encoding.Default.GetString(bytes);
            if (date.Substring(date.Length - 2, 2) == "\r\n")
            {
                CustomEventArgs obj = new CustomEventArgs();
                obj.data = date;

                if (CustoEvent != null && !string.IsNullOrEmpty(obj.data))
                {
                    date = "";
                    CustoEvent(this, obj);
                }
            }
            //CustomEventArgs obj = new CustomEventArgs();
            //obj.data = date;

            //if (CustoEvent != null && !string.IsNullOrEmpty(obj.data))
            //{
            //    date = "";
            //    CustoEvent(this, obj);
            //}
            return HandleResult.Ok;
        }

        /// <summary>
        /// 判断TCP连接状态
        /// </summary>
        /// <returns></returns>
        public int TcpState()
        {
            int i = 0;
            if (this.client != null)
            {
                if (this.client.IsStarted)
                {
                    i = 1;
                }
                else
                {
                    i = 0;
                }
            }
            return i;
        }

        /// <summary>
        /// 获取当前读码器的sn码
        /// </summary>
        public void GetSerialNum()
        {
            TcpClientSendByte(bytes);
        }
        
        private Dictionary<int, string> dic = new Dictionary<int, string>()
        {
            {1,"12312321312321"}
        };
        
    }
    
}
