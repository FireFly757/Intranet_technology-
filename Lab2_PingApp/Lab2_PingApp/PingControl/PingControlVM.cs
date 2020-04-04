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
            requests = new ObservableCollection<RequestItem> { };
        }

        private void SendRequest(object obj)
        {
            
            string who = Address;
            string data = "";
            for(int i=0; i<BufferSize; i++)
            {
                data += "a";
            }
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = Timeout;
            PingOptions options = new PingOptions(TimeToLife, IsFragmentation);
            int numOfRequsts = RequestsNumber;

            Pings pings = new Pings(numOfRequsts);
            pings.RequestCompleted += RequestCompleted;
            requests.Clear();
            pings.SendRequests(address, timeout, buffer, options);
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

        private int bufferSize;
        public int BufferSize
        {
            get { return bufferSize; }
            set
            {
                bufferSize = value;
                OnPropertyChanged("BufferSize");
            }
        }

        private int requestsNumber;
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

        private int timeToLife;
        public int TimeToLife
        {
            get { return timeToLife; }
            set
            {
                timeToLife = value;
                OnPropertyChanged("TimeToLife");
            }
        }

        private int timeout;
        public int Timeout
        {
            get { return timeout; }
            set
            {
                timeout = value;
                OnPropertyChanged("Timeout");
            }
        }
        
        //Не нашел, как использовать эту настройку. Но пусть будет, раз есть в условиях лабы)
        private int typeOfService;
        public int TypeOfService
        {
            get { return typeOfService; }
            set
            {
                typeOfService = value;
                OnPropertyChanged("TypeOfService");
            }
        }


        private string statisticMessage;
        public string StatisticMessage
        {

            get { return statisticMessage; }
            set
            {
                statisticMessage = value;
                OnPropertyChanged("StatisticMessage");
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
