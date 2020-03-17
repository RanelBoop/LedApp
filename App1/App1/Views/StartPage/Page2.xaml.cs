using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage, INotifyPropertyChanged
    {
        private Models.BthModel ViewModel => _viewModel ?? (_viewModel = new Models.BthModel());
        private Models.BthModel _viewModel;
        //Models.BthModel bthModel;

        public Page2()
        {
            InitializeComponent();
            GetStartedBtn.IsVisible = false;
            GetStartedBtn.IsEnabled = false;

            //ViewModel.GetPairedDevices();

            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.GetPairedDevices();
            // Content = GetLayout();
            picker.ItemsSource = ViewModel.ListOfDevices;

        }

        void OnGetStartedBtnClicked(Object sender, EventArgs e)
        {
             Navigation.PushModalAsync(new Views.MainPages.Carousel (),true);
        }
        private void DeviceSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            // var deviceSelect = (Picker)sender;
            picker = (Picker)sender;
            //ViewModel.SelectedBthDevice = ViewModel.ListOfDevices[deviceSelect.SelectedIndex];

            ViewModel.SelectedBthDevice = ViewModel.ListOfDevices[picker.SelectedIndex];
            //bth.SelectedBthDevice = bth.ListOfDevices[picker.SelectedIndex];
        }

        private void OnPairButtonClicked(object sender, EventArgs e)
        {
            //try to connect to bt device

            //ViewModel.Connect();
            ViewModel.Connect();
            if (ViewModel.ListOfDevices!=null)
            {
                Status.TextColor =Color.Green;
                Status.Text = "connected";
                GetStartedBtn.IsVisible = true;
                GetStartedBtn.IsEnabled = true;
            }
        }
    }
}