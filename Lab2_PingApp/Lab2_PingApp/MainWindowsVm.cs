using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Lab2_PingApp.PingControl;

namespace Lab2_PingApp
{
    class MainWindowVm : INotifyPropertyChanged
    {
        public MainWindowVm()
        {
            PingControlVm = new PingControlVM();
        }

        private PingControlVM _pingControlVm;
        public PingControlVM PingControlVm
        {
            get { return _pingControlVm; }
            set
            {
                _pingControlVm = value;
                OnPropertyChanged("PingControlVm");
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
