using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace StocketInfo
{
    public class StocketInfo
    {
        public Socket socket { get; set; }

        public bool IsCoon { get; set; }

        public string IP { get; set; }
    }
}
