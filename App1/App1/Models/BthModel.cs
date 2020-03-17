using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace App1.Models
{
    class BthModel
    {
        public ObservableCollection<string> ListOfDevices { get; set; } = new ObservableCollection<string>();
        public string SelectedBthDevice { get; set; } = " ";
        public string Message { get; set; } = "";
        public void GetPairedDevices()
        {

            try
            {
                ListOfDevices = DependencyService.Get<Interfaces.IBth>().PairedDevices();
            }

           catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Attention", ex.Message, "Ok");     
                //Console.WriteLine("Attention", ex.Message, "Ok");
            }
        }
      /*  public void GetUnPairedDevices()
        {
            try
            {
                ListOfDevices = DependencyService.Get<Interfaces.IBth>().UnPairedDevices();
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Attention", ex.Message, "Ok");
            }
        }*/
        /* public void OnReceive()
         {
             try
             {
                 ListOfDevices = DependencyService.Get<Interfaces.IBth>().OnReceive();
             }
             catch (Exception ex)
             {
                 Application.Current.MainPage.DisplayAlert("Attention", ex.Message, "Ok");
             }
         }*/
        /* public void UnPairedDevices()
         {
             try
             {
                 ListOfDevices = DependencyService.Get<Interfaces.IBth>().UnPairedDevices();
             }
             catch (Exception ex)
             {
                 Application.Current.MainPage.DisplayAlert("Attention", ex.Message, "Ok");
             }
         }*/

        public void Connect()
        {
            try
            {
                DependencyService.Get < Interfaces. IBth>().Connect(SelectedBthDevice);
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Attention", ex.Message, "Ok");
            }
        }
        public void Send()
        {
            try
            {
                DependencyService.Get<Interfaces.IBth>().Send(Message);
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Attention", ex.Message, "Ok");
            }
        }
        public void Disconnect()
        {
            try
            {
                DependencyService.Get<Interfaces.IBth>().Disconnect();
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Attention", ex.Message, "Ok");
            }
        }
    }
}
