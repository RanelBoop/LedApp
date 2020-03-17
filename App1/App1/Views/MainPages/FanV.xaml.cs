using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views.MainPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FanV : ContentView
    {
        private Models.BthModel ViewModel => _viewModel ?? (_viewModel = new Models.BthModel());
        private Models.BthModel _viewModel;
        public FanV()
        {
            InitializeComponent();
        }
        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            double value = e.NewValue;
            //send VIa Bluetooth
            displayLabel.Text = String.Format($"Fan Speed is {value}");
            //value=value.ToString
            ViewModel.Message = value.ToString();
            
        }
    }
}