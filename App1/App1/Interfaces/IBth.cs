using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace App1.Interfaces
{
    public interface IBth
    {
        Task Send(string message);
        void Disconnect();
        void Connect(string name);
        ObservableCollection<string> PairedDevices();

        //List<string> OnReceive();
        //List<string> UnPairedDevices();
    }
}
