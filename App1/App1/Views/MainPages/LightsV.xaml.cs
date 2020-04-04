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
    public partial class LightsV : ContentView
    {
        private Models.BthModel bth;
        public LightsV()
        {
            bth = new Models.BthModel();
            InitializeComponent();
            
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)//needs to be made async
        {
            int value =(int)e.NewValue;
            rotatingLabel.Opacity = value * 0.0039;
            displayLabel.Text = String.Format($"Brightness Level is {value}");
            //value = (int)value;
          /*  if (value > 100)
                //bth.Message = value.ToString();
                bth.Message = "1";
            else bth.Message = "0";*/

            bth.Send();
           // bth.Connect();

        }
    }
}