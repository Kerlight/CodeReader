using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Port
{
    public class PortPro
    {
        public string PortName { get; set; }
        public int BaudRate { get; set; }
        public int DataBits { get; set; }
        public string StopBits { get; set; }
        public string Parity { get; set; }
        public int WriteTimeout { get; set; }
        public int ReadTimeout { get; set; }
        public int ReceivedBytesThreshold { get; set; }
    }
}
