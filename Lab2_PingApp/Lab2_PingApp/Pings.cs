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
        public Pings(int requestNum)
        {
            
            RequestNum = requestNum;
            RoundtripTimeList = new List<long>();
        }

    
        private int RequestNum { get; set; }
        private List<long> RoundtripTimeList { get; set; }
        private int LostPackageNum { get; set; }

        public event Action<RequestItem> RequestCompleted;
        public async void SendRequests(string address, int timeout, byte[] buffer, PingOptions options)
        {

            await Task.Factory.StartNew(() =>
            {
                try
                {
                    Ping pingSender = new Ping();
                    for (int i = 0; i < RequestNum; i++)
                    {
                        PingReply reply = pingSender.Send(address, timeout, buffer, options);
                        if (reply.Status == IPStatus.Success)
                        {
                            RoundtripTimeList.Add(reply.RoundtripTime);
                            var requestItem = new RequestItem(reply.Address.ToString(), reply.RoundtripTime);
                            RequestCompleted.Invoke(requestItem);
                        }
                        else
                        {
                            LostPackageNum++;
                            var requestItem = new RequestItem("Ping failed", -1);
                            RequestCompleted.Invoke(requestItem);
                        }
                    }


                }
                catch (System.Net.NetworkInformation.PingException)
                {
                    System.Windows.MessageBox.Show("Error sending request. Check the parameters are correct.", "Error",
                                                    System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }
                catch(System.ArgumentNullException)
                {
                    System.Windows.MessageBox.Show("Not all parameters are entered for the request", "Error",
                                                    System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }
                catch
                {
                    System.Windows.MessageBox.Show("Some error sending request", "Error",
                                                    System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }

            });
            //Тут событие, которое передает информацию о завершение 
            //И передает статискику  
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
