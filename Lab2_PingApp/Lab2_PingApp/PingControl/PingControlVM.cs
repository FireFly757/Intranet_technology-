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
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Windows;

namespace Lab2_PingApp.PingControl
{
    class PingControlVM : INotifyPropertyChanged
    {
        public PingControlVM()
        {
            sendRequestCommand = new RelayCommand(SendRequest);
            requests = new ObservableCollection<RequestItem> { };
        }

        private void SendRequest(object obj)
        {
            if ((string)obj == "")
                throw new ArgumentException("Ping needs a host or IP Address.");

            string who = Address;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "";
            for(int i=0; i<BufferSize; i++)
            {
                data += "a";
            }
            byte[] buffer = Encoding.ASCII.GetBytes(data);

            // Wait 12 seconds for a reply.
            int timeout = 12000;

            // Set options for transmission:
            // The data can go through 64 gateways or routers
            // before it is destroyed, and the data packet
            // cannot be fragmented.
            PingOptions options = new PingOptions(62, true);

            Console.WriteLine("Time to live: {0}", options.Ttl);
            Console.WriteLine("Don't fragment: {0}", options.DontFragment);

            Pings pings = new Pings(who, timeout, buffer, options, 4);
            pings.RequestCompleted += RequestCompleted;
            pings.SendRequests();
            //Thread pingThread = new Thread(new ThreadStart(pings.SendRequests));
            //pingThread.Start();
        }

        private void RequestCompleted(RequestItem requestItem)
        {
            try
            {
                requests.Insert(0, requestItem);
            }
            catch
            {
                MessageBox.Show("Ошибка при заполнение таблицы");
            }
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

        private int requestsNumber = 0;
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


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
