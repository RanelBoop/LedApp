using App1.PopupPages;
using App1.Models;
using Rg.Plugins.Popup.Extensions;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace App1.Views.MainPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColorPickerView : ContentView
    {
        private ColorPickerViewModel colorViewModel;
        private Models.BthModel bth;
        private Converters.StringToColorConverter colorConverter;
        public ColorPickerView()
        {
            InitializeComponent();
            bth = new Models.BthModel();
            colorConverter = new Converters.StringToColorConverter();
            BindingContext = colorViewModel = new ColorPickerViewModel();
  
        }

        private async void ShowColorsPopup(object sender, EventArgs e)
        {
            
            await Navigation.PushPopupAsync(new ColorSelectionPopupView());
        }

        private void Frame_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //bth.Message = colorViewModel.CategoryBackgroundColor;//sends the hex value

            //bth.Send() is sent when SELECT button is pressed.see in PopUpPages->ColorSelectionView
        }

        /*  void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
          {
              double value = e.NewValue;
              rotatingLabel.Opacity = value*0.01;
              displayLabel.Text = String.Format($"Brightness Level is{value}");
          }*/
    }
}