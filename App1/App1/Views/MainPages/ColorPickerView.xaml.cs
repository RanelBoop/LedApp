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
        private ColorPickerViewModel viewModel;

        public ColorPickerView()
        {
            InitializeComponent();
            BindingContext = viewModel = new ColorPickerViewModel();
  
        }

        private async void ShowColorsPopup(object sender, EventArgs e)
        {
            
            await Navigation.PushPopupAsync(new ColorSelectionPopupView());
        }

      /*  void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            double value = e.NewValue;
            rotatingLabel.Opacity = value*0.01;
            displayLabel.Text = String.Format($"Brightness Level is{value}");
        }*/
    }
}