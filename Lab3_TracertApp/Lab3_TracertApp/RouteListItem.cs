using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_TracertApp
{
    public class RouteListItem
    {
        public int CurrentTtl { get; set; }
        public string IpAddress { get; set; }
        public long Time { get; set; }

        public RouteListItem(int currentTtl, long time, string ipAddress)
        {
            CurrentTtl = currentTtl;
            Time = time;
            IpAddress = ipAddress;
        }
       
    }
}
