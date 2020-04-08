using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Threading;
using System.Net.NetworkInformation;
using System.Windows;

namespace Lab2_PingApp.PingControl
{
    class PingControlVM : INotifyPropertyChanged
    {
        public PingControlVM()
        {
            sendRequestCommand = new RelayCommand(SendRequest);
            stopSendingRequestsCommand = new RelayCommand(StopSendingRequests);
            requests = new ObservableCollection<RequestItem> { };
            pingRequests = new Pings();
            PingRequests.RequestCompleted += RequestCompleted;
            PingRequests.AllRequestsCompleted += AllRequestsCompleted;
        }

        private void SendRequest(object obj)
        {
            string data = "";
            for(int i=0; i < BufferSize; i++)
            {
                data += "a";
            }
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            PingOptions options = new PingOptions(TimeToLife, IsFragmentation);
            requests.Clear();
            if(IsManualStopSending)
            {
                PingRequests.IsToContinueSending = true;
                PingRequests.SendRequestsUntilStopping(Address, Timeout, buffer, options);
            }
            else
            {
                PingRequests.SetRequestNumber(RequestsNumber);
                PingRequests.SendRequests(Address, Timeout, buffer, options);
            }
        }

        public void RequestCompleted(RequestItem requestItem)
        {
            try
            {
                Application.Current.Dispatcher?.Invoke(() =>
                {
                    Requests.Insert(0, requestItem);
                });
            }
            catch
            {
                System.Windows.MessageBox.Show("Error filling table", "Error",
                                                System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        public void AllRequestsCompleted()
        {
            SentPackages = PingRequests.GetRequestNumber();
            LostPackages = PingRequests.GetNumOfLostPackage();
            LostInPercent = Math.Round(PingRequests.GetLossesInPercent(), 2);
            ReceivedPackages = RequestsNumber - LostPackages;
            MinTime = PingRequests.GetMinRoundtripTime();
            MaxTime = PingRequests.GetMaxRoundtripTime();
            AverageTime = Math.Round(PingRequests.GetAverageRoundtripTime(), 2);
            PingRequests.Clear();
        }

        private void StopSendingRequests(object obj)
        {
            PingRequests.IsToContinueSending = false;
        }

        private String address;
        public String Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        private int bufferSize = 32;
        public int BufferSize
        {
            get { return bufferSize; }
            set
            {
                bufferSize = value;
                OnPropertyChanged("BufferSize");
            }
        }

        private int requestsNumber = 4;
        public int RequestsNumber
        {
            get { return requestsNumber; }
            set
            {
                requestsNumber = value;
                OnPropertyChanged("RequestsNumber");
            }
        }

        private bool isFragmentation = true;
        public bool IsFragmentation
        {
            get { return isFragmentation; }
            set
            {
                isFragmentation = value;
                OnPropertyChanged("IsFragmentation");
            }
        }

        private bool isManualStopSending;
        public bool IsManualStopSending
        {
            get { return isManualStopSending; }
            set
            {
                isManualStopSending = value;
                OnPropertyChanged("IsManualStopSending");
            }
        }


        private int timeToLife = 56;
        public int TimeToLife
        {
            get { return timeToLife; }
            set
            {
                timeToLife = value;
                OnPropertyChanged("TimeToLife");
            }
        }

        private int timeout = 5;
        public int Timeout
        {
            get { return timeout; }
            set
            {
                timeout = value;
                OnPropertyChanged("Timeout");
            }
        }
        
        
        private int typeOfService = 1;
        public int TypeOfService
        {
            get { return typeOfService; }
            set
            {
                typeOfService = value;
                OnPropertyChanged("TypeOfService");
            }
        }


        //Поля для статистики 

        private long minTime;
        public long MinTime
        {
            get { return minTime; }
            set
            {
                minTime = value;
                OnPropertyChanged("MinTime");
            }
            
        }

        private long maxTime;
        public long MaxTime
        {
            get { return maxTime; }
            set
            {
                maxTime = value;
                OnPropertyChanged("MaxTime");
            }

        }

        private double averageTime;
        public double AverageTime
        {
            get { return averageTime; }
            set
            {
                averageTime = value;
                OnPropertyChanged("AverageTime");
            }

        }

        //Добавил для того, чтобы в статистике был 0 в начале 
        private int sentPackages;
        public int SentPackages
        {

            get { return sentPackages; }
            set
            {
                sentPackages = value;
                OnPropertyChanged("SentPackages");
            }
        }

        private int receivedPackages;
        public int ReceivedPackages
        {

            get { return receivedPackages; }
            set
            {
                receivedPackages = value;
                OnPropertyChanged("ReceivedPackages");
            }
        }

        private int lostPackages;
        public int LostPackages
        {

            get { return lostPackages; }
            set
            {
                lostPackages = value;
                OnPropertyChanged("LostPackages");
            }
        }


        private double lostInPercent;
        public double LostInPercent
        {

            get { return lostInPercent; }
            set
            {
                lostInPercent = value;
                OnPropertyChanged("LostInPercent");
            }
        }
        private ObservableCollection<RequestItem> requests;
        public ObservableCollection<RequestItem> Requests
        {
            get { return requests; }
            set
            {
                requests = value;
                OnPropertyChanged("Requests");
            }
        }

        private Pings pingRequests;
        public Pings PingRequests
        {
            get { return pingRequests; }
            set
            {
                pingRequests = value;
                OnPropertyChanged("PingRequests");
            }
        }

        private ICommand sendRequestCommand;
        public ICommand SendRequestCommand
        {
            get { return sendRequestCommand; }
            set
            {
                sendRequestCommand = value;
                OnPropertyChanged("SendRequestCommand");
            }
        }

        private ICommand stopSendingRequestsCommand;
        public ICommand StopSendingRequestsCommand
        {
            get { return stopSendingRequestsCommand; }
            set
            {
                stopSendingRequestsCommand = value;
                OnPropertyChanged("StopSendingRequestsCommand");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
