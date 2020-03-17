using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Android.Content;
using Android.Bluetooth;

using Rg.Plugins.Popup;


namespace App1.Droid
{
    [Activity(Label = "App1", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        Bluetooth.BluetoothReceiver receiver;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
           Popup.Init(this, savedInstanceState);
            DLToolkit.Forms.Controls.FlowListView.Init();
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());


            //IntentFilter filter = new IntentFilter(BluetoothDevice.ActionFound);
            //registerReceiver(BluetoothReceiver, filter);
            //BroadcastReceiver bluetoothreceiver = new Bluetooth.BluetoothReceiver();
            receiver = new Bluetooth.BluetoothReceiver();

            //registerReceiver(BluetoothReceiver, new IntentFilter(BluetoothDevice.ActionBondStateChanged));

            //RegisterReceiver(bluetoothreceiver, new IntentFilter(BluetoothDevice.ActionBondStateChanged));
            //RegisterReceiver(bluetoothreceiver, new IntentFilter(BluetoothDevice.ActionFound));

            //RegisterReceiver(_receiver, new IntentFilter(BluetoothDevice.ActionFound));


            BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
            if (!adapter.IsEnabled)
            {
                Intent enableBtIntent = new Intent(BluetoothAdapter.ActionRequestEnable);
                StartActivityForResult(enableBtIntent,2 );//const int RequestEnableBt = 2;
            }

            //RegisterReceiver(receiver, new IntentFilter(BluetoothDevice.ActionFound));
            RegisterReceiver(receiver, new IntentFilter(BluetoothDevice.ActionFound));//action found
            adapter.StartDiscovery();
            
            //Intent intent = new Intent(); 



        }
        protected override void OnResume()
        {
            base.OnResume();
            StartScanning();
            RegisterReceiver(receiver, new IntentFilter(BluetoothDevice.ActionFound));
        }
        protected override void OnPause()
        {
            UnregisterReceiver(receiver);
            base.OnPause();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        private static void StartScanning()
        {
            if (!Bluetooth.BluetoothReceiver.Adapter.IsDiscovering) Bluetooth.BluetoothReceiver.Adapter.StartDiscovery();
        }



    }
}