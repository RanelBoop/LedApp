using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Bluetooth;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;




namespace App1.Droid.Bluetooth
{
    [BroadcastReceiver(Name = "com.companyname.app1.Bluetooth.BluetoothReceiver", Enabled = true, Exported = true)]
    [IntentFilter(new[] { BluetoothDevice.ActionFound })]
    
    public class BluetoothReceiver : BroadcastReceiver
    {
        public List<string> devices = new List<string>();
        public static BluetoothAdapter Adapter => BluetoothAdapter.DefaultAdapter;
        bool found = false;
        //public string action;
        //public Context context;
        //public Intent intent;

        public override void  OnReceive(Context context, Intent intent)
        {
            
            //throw new NotImplementedException();
            var action = intent.Action;
            Console.WriteLine("action is: " +action);
            //BluetoothDevice device = (BluetoothDevice)intent.GetParcelableExtra("android.bluetooth.device.extra.DEVICE");

            if (BluetoothDevice.ActionFound.Equals(action))
            {
                //device was found
                //getting device info form intent

                //BluetoothDevice device = (BluetoothDevice)intent.GetParcelableExtra("android.bluetooth.device.extra.DEVICE");
                BluetoothDevice device = (BluetoothDevice)intent.GetParcelableExtra(BluetoothDevice.ExtraDevice);
                System.Diagnostics.Debug.WriteLine($"Bluetooth adapter found.{device.Name}");
                Console.WriteLine(device.Address);
                Console.WriteLine(device.Name);
                found = true;


                if (device.BondState != Bond.Bonded)
                {
                    devices.Add(device.Name);
                    //Console.WriteLine("Value of extra device:" + device);
                    Console.WriteLine($"Found device with name: {device.Name} and MAC address: {device.Address}");
                }
            }

        }

    }
}