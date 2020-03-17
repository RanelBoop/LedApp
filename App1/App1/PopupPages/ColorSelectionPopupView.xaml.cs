using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;

using App1.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Internals;

namespace App1.PopupPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColorSelectionPopupView : PopupPage
    {
        ColorSelectionPopupViewModel ViewModel;

        public ColorSelectionPopupView()
        {
            InitializeComponent();
            BindingContext = ViewModel = new ColorSelectionPopupViewModel();
        }

        private async void Button_Pressed(object sender, EventArgs e)
        {
            if (ViewModel.SelectedColor == null)
            {
                await DisplayAlert("No color selected", "You must choose one color !", "OK");
                return;
            }
            //Send a message to notify the selected Color
            MessagingCenter.Send(ViewModel, "_categoryColor");
            //close this
            //await PopupNavigation.PopAsync(true);
            await PopupNavigation.PopAsync(true);
 

        }
    }
}