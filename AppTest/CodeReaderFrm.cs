using Common;
using Common.EventParam;
using Common.Port;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeReader
{
    public partial class CodeReaderFrm : Form
    {
        public TcpClientCla selTcp = null;
        TcpClient tcpClient = new TcpClient();
        private byte[] bytes = new byte[29] { 0x7C, 0x7C, 0x3E, 0x47, 0x45, 0x54, 0x20, 0x44, 0x45, 0x56, 0x49, 0x43, 0x45, 0x2E, 0x53, 0x45, 0x52, 0x49, 0x41, 0x4C, 0x2D, 0x4E, 0x55, 0x4D, 0x42, 0x45, 0x52, 0x0D, 0x0A };
        public PortCla selCom = null;
        public CodeReaderFrm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 更新textEdit 文本框值及前景色
        /// </summary>
        /// <param name="lab"></param>
        /// <param name="text"></param>
        /// <param name="colr"></param>
        private void SetLabelStatus(Label lab, string text, Color colr)
        {
            Action<string> action = (string x) =>
            {
                lab.Text = text;
                lab.ForeColor = colr;
            };
            lab.BeginInvoke(action, new object[] { text });
        }

        /// <summary>
        /// 网口连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_tcpcon_Click(object sender, EventArgs e)
        {
            if (btn_tcpcon.Text == "连接")
            {
                CancellationTokenSource ctsTcp = new CancellationTokenSource();
                Task<CustomMessage> tasktcp = Task.Factory.StartNew((cs) =>
                {
                    CustomMessage cm = new CustomMessage() { success = false, message = "" };
                    selTcp = new TcpClientCla(tcpClient, 36);
                    selTcp.CustoEvent += selTcp_CustoEvent;
                    selTcp.TcpClientOpen(txt_ip.Text.Trim(), ushort.Parse(txt_port.Text.Trim()));
                    if (selTcp.TcpState() == 1)
                    {
                        cm.success = true;
                    }
                    else
                    {
                        cm.message = "读码器连接失败";
                    }
                    if (ctsTcp.IsCancellationRequested)
                    {
                        cm.message = "标签读码：读码器连接超时";
                        return cm;
                    }
                    return cm;
                }, ctsTcp);
                if (!tasktcp.Wait(3000))
                {
                    ctsTcp.Cancel();
                    SetLabelStatus(lab_tcpstatus, "未连接", Color.Red);
                    MessageBox.Show("读码器连接超时，请关闭软件后检查配置及硬件", "武汉镭立提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!tasktcp.Result.success)
                {
                    SetLabelStatus(lab_tcpstatus, "未连接", Color.Red);
                    MessageBox.Show(tasktcp.Result.message, "武汉镭立提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    btn_tcpcon.Invoke(new Action(() => { btn_tcpcon.Text = "断开"; }));
                    SetLabelStatus(lab_tcpstatus, "已连接", Color.Green);
                }
            }
            else
            {
                selTcp.CustoEvent -= selTcp_CustoEvent;
                selTcp.TcpClientClose();
                selTcp = null;
                SetLabelStatus(lab_tcpstatus, "未连接", Color.Red);
                btn_tcpcon.Invoke(new Action(() => { btn_tcpcon.Text = "连接"; }));
            }
        }

        /// <summary>
        /// 网口读码接收事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void selTcp_CustoEvent(object sender, CustomEventArgs e)
        {
            txt_tcptext.BeginInvoke(new Action<string>((string x) => { txt_tcptext.Text = x; }), new object[] { e.data.Trim() });
        }

        /// <summary>
        /// 串口读码接收事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void selCom_CustoEvent(object sender, CustomEventArgs e)
        {
            txt_comtext.BeginInvoke(new Action<string>((string x) => { txt_comtext.Text =  x; }), new object[] { e.data.Trim() });
        }

        private void btn_comcon_Click(object sender, EventArgs e)
        {
            if (btn_comcon.Text == "连接")
            {
                //初始化串口读码器连接
                CancellationTokenSource ctscom = new CancellationTokenSource();
                Task<CustomMessage> taskcom = Task.Factory.StartNew((ct) =>
                {
                    CustomMessage cm = new CustomMessage() { success = false, message = "" };
                    selCom = new PortCla(serialPort1, txt_comArgs.Text.Trim(), 36);
                    selCom.CustoEvent += selCom_CustoEvent;
                    selCom.PortOpen();
                    if (selCom.PortSatte() == 1)
                    {
                        cm.success = true;
                    }
                    else
                    {
                        cm.message = "读码器连接失败";
                    }
                    if (ctscom.IsCancellationRequested)
                    {
                        cm.message = "读码器连接超时";
                        return cm;
                    }
                    return cm;
                }, ctscom);
                if (!taskcom.Wait(3000))
                {
                    ctscom.Cancel();
                    SetLabelStatus(lab_comstatus, "未连接", Color.Red);
                    MessageBox.Show("读码器连接超时，请关闭软件后检查配置及硬件", "武汉镭立提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!taskcom.Result.success)
                {
                    SetLabelStatus(lab_comstatus, "未连接", Color.Red);
                    MessageBox.Show(taskcom.Result.message, "武汉镭立提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    btn_comcon.Invoke(new Action(() => { btn_comcon.Text = "断开"; }));
                    SetLabelStatus(lab_comstatus, "已连接", Color.Green);
                }
            }
            else
            {
                selCom.CustoEvent -= selCom_CustoEvent;
                selCom.PortClose();
                selCom = null;
                SetLabelStatus(lab_comstatus, "未连接", Color.Red);
                btn_comcon.Invoke(new Action(() => { btn_comcon.Text = "连接"; }));
            }
        }

        private void CodeReaderFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (selCom != null)
            {
                selCom.CustoEvent -= selCom_CustoEvent;
                selCom.PortClose();
            }
            if (selTcp != null)
            {
                selTcp.CustoEvent -= selTcp_CustoEvent;
                selTcp.TcpClientClose();
            }
        }

        private void btn_GetTcpSN_Click(object sender, EventArgs e)
        {
            if (selTcp != null)
            {
                if (selTcp.TcpState() == 1)
                {
                    selTcp.GetSerialNum();
                }
                else
                {
                    btn_tcpcon_Click(null, null);
                    MessageBox.Show("连接已断开", "武汉镭立提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("请先连接读码器", "武汉镭立提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_GetComSN_Click(object sender, EventArgs e)
        {
            if (selCom != null)
            {
                if (selCom.PortSatte() == 1)
                {
                    selCom.GetSerialNum();
                }
                else
                {

                    btn_comcon_Click(null, null);
                    MessageBox.Show("连接已断开", "武汉镭立提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("请先连接读码器", "武汉镭立提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

    public class CustomMessage
    {
        public bool success { get; set; }
        public string message { get; set; }
    }
}
