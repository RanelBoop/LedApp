using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Extensions;
using App1.PopupPages;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;

namespace App1.Views.MainPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Carousel : CarouselPage
    {
        public Carousel()
        {
            InitializeComponent();
        }

   
    }
}