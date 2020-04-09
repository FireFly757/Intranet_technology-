using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab3_TracertApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window , INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            //routeList = new ObservableCollection<RouteListItem> { };
        }


        public void RequestButton_Click(object sender, RoutedEventArgs e)
        {
            //RouteList.Clear();
            listbox.Items.Clear();
            try
            {
                int maxTtl = Int32.Parse(MaxTtl.Text);
                int timeout = Int32.Parse(Timeout.Text);
                string address = Address.Text;
                Stopwatch stopwatch = new Stopwatch();
                int currentTtl = 0;
                const int bufferSize = 32;
                string data = "";
                for (int i = 0; i < bufferSize; i++)
                {
                    data += "a";
                }
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                Ping ping = new Ping();
                Task.Factory.StartNew(() =>
                {
                    for (int ttl = 1; ttl <= maxTtl; ttl++)
                    {
                        currentTtl++;
                        PingOptions options = new PingOptions(ttl, true);
                        PingReply reply = null;
                        stopwatch.Start();
                        try
                        {
                            reply = ping.Send(address, timeout, buffer, options);
                        }
                        catch
                        {
                            System.Windows.MessageBox.Show("Error sending request. Check the parameters are correct.", "Error",
                                                            System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                        }
                        if (reply.Status == IPStatus.TtlExpired)
                        {
                            var routeListItem = new RouteListItem(ttl, reply.RoundtripTime, reply.Address.ToString());
                            WriteToListBox($"[{ttl}]    Time: {stopwatch.ElapsedMilliseconds} ms    Route: {reply.Address} ");
                            AddItemToTable(routeListItem);
                            continue;
                        }
                        if (reply.Status == IPStatus.TimedOut)
                        {
                            //this would occour if it takes too long for the server to reply or if a server has the ICMP port closed (quite common for this).
                            WriteToListBox($"[{ttl}]  *    *    *");
                            var routeListItem = new RouteListItem(ttl, -1, "Timeout");
                            continue;
                        }
                        if (reply.Status == IPStatus.Success)
                        {
                            //the ICMP packet has reached the destination (the hostname)
                            WriteToListBox($"Successful trace route to {address}  Total Time: {stopwatch.ElapsedMilliseconds} ms");
                            stopwatch.Stop();
                        }
                        break;
                    }
                });
            }
            catch
            {
                System.Windows.MessageBox.Show("sError in input data", "Error",
                                                        System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        public void WriteToListBox(string text)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                listbox.Items.Add(text);
            }));
        }




        //Это для связи с таблицей, но что-то не пошло. Может когда-нибудь допилю 
        public void AddItemToTable(RouteListItem routeListItem)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                RouteList.Insert(0, routeListItem);
            }));
        }

        private ObservableCollection<RouteListItem> routeList;
        public ObservableCollection<RouteListItem> RouteList
        {
            get { return routeList; }
            set
            {
                routeList = value;
                OnPropertyChanged("RouteList");
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
