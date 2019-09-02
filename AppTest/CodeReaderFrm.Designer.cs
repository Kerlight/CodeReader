namespace CodeReader
{
    partial class CodeReaderFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lab_tcpstatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_tcptext = new System.Windows.Forms.TextBox();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.btn_tcpcon = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lab_comstatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_comtext = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_comArgs = new System.Windows.Forms.TextBox();
            this.btn_comcon = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btn_GetTcpSN = new System.Windows.Forms.Button();
            this.btn_GetComSN = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lab_tcpstatus);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_tcptext);
            this.groupBox1.Controls.Add(this.txt_port);
            this.groupBox1.Controls.Add(this.txt_ip);
            this.groupBox1.Controls.Add(this.btn_GetTcpSN);
            this.groupBox1.Controls.Add(this.btn_tcpcon);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(533, 197);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "网口读码测试区";
            // 
            // lab_tcpstatus
            // 
            this.lab_tcpstatus.AutoSize = true;
            this.lab_tcpstatus.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_tcpstatus.ForeColor = System.Drawing.Color.Red;
            this.lab_tcpstatus.Location = new System.Drawing.Point(311, 26);
            this.lab_tcpstatus.Name = "lab_tcpstatus";
            this.lab_tcpstatus.Size = new System.Drawing.Size(44, 12);
            this.lab_tcpstatus.TabIndex = 3;
            this.lab_tcpstatus.Text = "未连接";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "状态：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP:";
            // 
            // txt_tcptext
            // 
            this.txt_tcptext.Location = new System.Drawing.Point(12, 61);
            this.txt_tcptext.Multiline = true;
            this.txt_tcptext.Name = "txt_tcptext";
            this.txt_tcptext.Size = new System.Drawing.Size(509, 121);
            this.txt_tcptext.TabIndex = 1;
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(216, 22);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(34, 21);
            this.txt_port.TabIndex = 1;
            this.txt_port.Text = "23";
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(60, 22);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(94, 21);
            this.txt_ip.TabIndex = 1;
            this.txt_ip.Text = "192.168.0.96";
            // 
            // btn_tcpcon
            // 
            this.btn_tcpcon.Location = new System.Drawing.Point(365, 21);
            this.btn_tcpcon.Name = "btn_tcpcon";
            this.btn_tcpcon.Size = new System.Drawing.Size(75, 23);
            this.btn_tcpcon.TabIndex = 0;
            this.btn_tcpcon.Text = "连接";
            this.btn_tcpcon.UseVisualStyleBackColor = true;
            this.btn_tcpcon.Click += new System.EventHandler(this.btn_tcpcon_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lab_comstatus);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_comtext);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txt_comArgs);
            this.groupBox2.Controls.Add(this.btn_GetComSN);
            this.groupBox2.Controls.Add(this.btn_comcon);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 197);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(533, 200);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "串口读码测试区";
            // 
            // lab_comstatus
            // 
            this.lab_comstatus.AutoSize = true;
            this.lab_comstatus.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_comstatus.ForeColor = System.Drawing.Color.Red;
            this.lab_comstatus.Location = new System.Drawing.Point(308, 42);
            this.lab_comstatus.Name = "lab_comstatus";
            this.lab_comstatus.Size = new System.Drawing.Size(44, 12);
            this.lab_comstatus.TabIndex = 3;
            this.lab_comstatus.Text = "未连接";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(261, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "状态：";
            // 
            // txt_comtext
            // 
            this.txt_comtext.Location = new System.Drawing.Point(12, 69);
            this.txt_comtext.Multiline = true;
            this.txt_comtext.Name = "txt_comtext";
            this.txt_comtext.Size = new System.Drawing.Size(509, 121);
            this.txt_comtext.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "串口连接参数:";
            // 
            // txt_comArgs
            // 
            this.txt_comArgs.Location = new System.Drawing.Point(109, 37);
            this.txt_comArgs.Name = "txt_comArgs";
            this.txt_comArgs.Size = new System.Drawing.Size(141, 21);
            this.txt_comArgs.TabIndex = 1;
            this.txt_comArgs.Text = "COM8,9600,8,One,None";
            // 
            // btn_comcon
            // 
            this.btn_comcon.Location = new System.Drawing.Point(365, 35);
            this.btn_comcon.Name = "btn_comcon";
            this.btn_comcon.Size = new System.Drawing.Size(75, 23);
            this.btn_comcon.TabIndex = 0;
            this.btn_comcon.Text = "连接";
            this.btn_comcon.UseVisualStyleBackColor = true;
            this.btn_comcon.Click += new System.EventHandler(this.btn_comcon_Click);
            // 
            // btn_GetTcpSN
            // 
            this.btn_GetTcpSN.Location = new System.Drawing.Point(446, 21);
            this.btn_GetTcpSN.Name = "btn_GetTcpSN";
            this.btn_GetTcpSN.Size = new System.Drawing.Size(75, 23);
            this.btn_GetTcpSN.TabIndex = 0;
            this.btn_GetTcpSN.Text = "获取SN码";
            this.btn_GetTcpSN.UseVisualStyleBackColor = true;
            this.btn_GetTcpSN.Click += new System.EventHandler(this.btn_GetTcpSN_Click);
            // 
            // btn_GetComSN
            // 
            this.btn_GetComSN.Location = new System.Drawing.Point(446, 35);
            this.btn_GetComSN.Name = "btn_GetComSN";
            this.btn_GetComSN.Size = new System.Drawing.Size(75, 23);
            this.btn_GetComSN.TabIndex = 0;
            this.btn_GetComSN.Text = "获取SN码";
            this.btn_GetComSN.UseVisualStyleBackColor = true;
            this.btn_GetComSN.Click += new System.EventHandler(this.btn_GetComSN_Click);
            // 
            // CodeReaderFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 397);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CodeReaderFrm";
            this.Text = "CodeReaderFrm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CodeReaderFrm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_tcptext;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.Button btn_tcpcon;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_comtext;
        private System.Windows.Forms.TextBox txt_comArgs;
        private System.Windows.Forms.Button btn_comcon;
        private System.Windows.Forms.Label label3;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label lab_tcpstatus;
        private System.Windows.Forms.Label lab_comstatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_GetTcpSN;
        private System.Windows.Forms.Button btn_GetComSN;
    }
}