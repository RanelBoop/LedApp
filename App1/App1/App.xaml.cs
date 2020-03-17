using Xamarin.Forms;


namespace App1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Page2());

            CarouselPage carrousele = new CarouselPage();
            carrousele.Children.Add(new MainPage());
            carrousele.Children.Add(new Page2());

           // carrousele.Children.Add(new Views.MainPages.Lights());
           // carrousele.Children.Add(new Views.MainPages.Fan());

            MainPage = carrousele;
            
            
            //CarouselPage bodCar = new CarouselPage();
           // bodCar.Children.Add(new Views.MainPages.Fan());
            //odCar.Children.Add(new Views.MainPages.Lights());
           // Views.MainPages.Carousel  = bodCar;


        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes

            //var _receiver = new Models.BthModel();
          //  _receiver=RegisterReceiver(_receiver, new IntentFilter(BluetoothDevice.ActionFound));
        }
        protected void OnPause()
        {
            //  mainActivity.UnRegisterReceiver(bluetoothDeviceReceiver);
            
        }
    }
}
