using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_PingApp
{
    class RequestItem
    {
        public string IpAddress { get; set; }
        public int RoadtripTime { get; set; }

        public RequestItem(string ipAddress, int roadtripTime)
        {
            IpAddress = ipAddress;
            RoadtripTime = roadtripTime;
        }
    }
}
