using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_PingApp
{
    class Pings
    {
        public Pings(string address, int timeout, byte[] buffer, PingOptions options, int requestNum)
        {
            Address = address;
            Timeout = timeout;
            Buffer = buffer;
            Options = options;
            RequestNum = requestNum;
            RoundtripTimeList = new List<long>();
        }

        private string Address { get; set; }
        private int Timeout { get; set; }
        private byte[] Buffer { get; set; }
        private PingOptions Options { get; set; }
        private int RequestNum { get; set; }
        private List<long> RoundtripTimeList { get; set; }
        private int LostPackageNum { get; set; }

        public event Action<RequestItem> RequestCompleted;
        public void SendRequests()
        {

            var t = Task.Factory.StartNew(() =>
            {
                Ping pingSender = new Ping();
                for (int i = 0; i < RequestNum; i++)
                {
                    PingReply reply = pingSender.Send(Address, Timeout, Buffer, Options);
                    if (reply.Status == IPStatus.Success)
                    {
                        RoundtripTimeList.Add(reply.RoundtripTime);
                        var requestItem = new RequestItem(reply.Address.ToString(), reply.RoundtripTime);
                        //Вызываем событие, которое передает requestItem
                        RequestCompleted.Invoke(requestItem);
                    }
                    else
                    {
                        LostPackageNum++;
                        var requestItem = new RequestItem("Ping failed", -1);
                        RequestCompleted.Invoke(requestItem);
                    }
                }

            });
            //Тут событие, которое передает информацию о завершение 
        }

        public int GetNumOfLostPackage()
        {
            return LostPackageNum;
        }

        public float GetLossesInProcent()
        {
            return ((RequestNum - LostPackageNum) / RequestNum) * 100;
        }

        public double GetAverageRoundtripTime()
        {
            return RoundtripTimeList.Average();
        }

        public long GetMaxRoundtripTime()
        {
            return RoundtripTimeList.Max();
        }

        public long GetMinRoundtripTime()
        {
            return RoundtripTimeList.Min();
        }
    }
}
