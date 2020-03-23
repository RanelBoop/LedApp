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
            _viewModel = new Models.BthModel();
        }
        /* void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
         {
             double value = e.NewValue;
             //send VIa Bluetooth
             displayLabel.Text = String.Format($"Fan Speed is {value}");
             //value=value.ToString
             ViewModel.Message = value.ToString();

         }*/
        async void OnToggled(object sender, ToggledEventArgs e)
        {
            // Perform an action after examining e.Value
            if (e.Value)
            {
                ModeValue.Text = "Spectrum Cycling";
                if (breathingImage.Opacity > 0)
                {
                    while (breathingImage.Opacity != 0)
                    {
                        breathingImage.Opacity-=0.1;
                        await Task.Delay(50);
                    }


                    while (spectrumImage.Opacity != 1)
                    {
                        spectrumImage.Opacity += .1;
                        await Task.Delay(50);
                    }

                    
                }
              //  _viewModel.Message = "Spectrum Cycling";
              //  _viewModel.Send();
            }
            else 
            {
                ModeValue.Text = "Breathing";
                while (spectrumImage.Opacity != 0) 
                { 
                    spectrumImage.Opacity-=.1;
                    await Task.Delay(50);
                }
                while(breathingImage.Opacity!=1)
                {
                    breathingImage.Opacity+=.1;
                    await Task.Delay(50);
                }
               // _viewModel.Message = "Breathing";
              //  _viewModel.Send();
            } 
        }
    }
}