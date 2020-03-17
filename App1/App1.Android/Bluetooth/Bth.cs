using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Android.Bluetooth;
using App1.Droid.Bluetooth;
using Java.IO;
using Java.Util;
using Application = Xamarin.Forms.Application;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly: Xamarin.Forms.Dependency(typeof(Bth))]
namespace App1.Droid.Bluetooth
{
    class Bth:Interfaces.IBth
    {
        private CancellationTokenSource _ct { get; set; }

        BluetoothSocket bthSocket = null;
        public string MessageToSend { get; set; }


        public Bth()
        {
            _ct = new CancellationTokenSource();
        }

        public void Connect(string name)
        {
            
           // Task.Run(async () => ConnectDevice(name));
             Task.Run(async () => await ConnectDevice(name));

        }
        public void Disconnect()
        {
            if (_ct != null)
            {
                System.Diagnostics.Debug.WriteLine("Send a cancel to task!");
                _ct.Cancel();
            }
        }
        /*public async Task Message()
        {
            
            using (BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter)
            {
                BluetoothDevice device;
                device = (from bd in adapter?.BondedDevices where bd.Name == "HC-05" select bd).FirstOrDefault();
                if (MessageToSend != null) 
                {
                    try
                    {
                        BluetoothSocket btSocket;
                        using (btSocket = device.CreateRfcommSocketToServiceRecord(UUID.FromString("00001101-0000-1000-8000-00805f9b34fb"))) ;
                        {


                            if (!btSocket.IsConnected) btSocket.Connect();
                            if (btSocket.IsConnected)
                            {
                                System.Diagnostics.Debug.WriteLine("Connected!");
                                //OutputStream outputStream = btSocket.OutputStream;
                                byte[] buffer = Encoding.UTF8.GetBytes(MessageToSend);
                                await btSocket.OutputStream.WriteAsync(buffer, 0, buffer.Length);


                                /*while (_ct.IsCancellationRequested == false)
                                {
                                    if (MessageToSend != null)
                                    {
                                        var chars = MessageToSend.ToCharArray();
                                        var bytes = new List<byte>();
                                        foreach (var character in chars)
                                        {
                                            bytes.Add((byte)character);
                                        }



                                    }
                                }
                            }
                        }
                        btSocket.Close();
                        btSocket.Dispose();
                    }
                    catch (Exception exp)
                    {
                        throw exp;
                    }
                }
               
            }
        }*/
        public async Task Send(string message)
        {
           
             if (MessageToSend == null)
                MessageToSend = message;


            /* var chars = MessageToSend.ToCharArray();
             var bytes = new List<byte>();
             foreach (var character in chars)
             {
                 bytes.Add((byte)character);
             }

             bthSocket.OutputStream.WriteAsync(bytes.ToArray(), 0, bytes.Count);
             MessageToSend = null;*/
            byte[] buffer = Encoding.UTF8.GetBytes(MessageToSend);
            await bthSocket.OutputStream.WriteAsync(buffer, 0, buffer.Length);


        }

        
        private async Task ConnectDevice(string name)
        {
            BluetoothDevice device = null;
            BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
            BluetoothSocket bthSocket = null;
            while (_ct.IsCancellationRequested == false)
            {
                try
                {
                    Thread.Sleep(250);

                    adapter = BluetoothAdapter.DefaultAdapter;

                    if (adapter == null)
                        System.Diagnostics.Debug.WriteLine("No Bluetooth adapter found.");
                    else
                        System.Diagnostics.Debug.WriteLine("Adapter found!!");

                    if (!adapter.IsEnabled)
                        System.Diagnostics.Debug.WriteLine("Bluetooth adapter is not enabled.");
                    else
                        System.Diagnostics.Debug.WriteLine("Adapter enabled!");

                    System.Diagnostics.Debug.WriteLine("Try to connect to " + name);

                    foreach (var bd in adapter.BondedDevices)
                    {
                        System.Diagnostics.Debug.WriteLine("Paired devices found: " + bd.Name.ToUpper());
                        if (bd.Name.ToUpper().IndexOf(name.ToUpper()) >= 0)
                        {
                            System.Diagnostics.Debug.WriteLine("Found " + bd.Name + ". Try to connect with it!");
                            device = bd;
                            break;
                        }
                    }

                    if (device == null)
                        System.Diagnostics.Debug.WriteLine("Named device not found.");
                    else
                    {
                        UUID uuid = UUID.FromString("00001101-0000-1000-8000-00805f9b34fb");
                        bthSocket = device.CreateInsecureRfcommSocketToServiceRecord(uuid);
                        if (bthSocket != null)
                        {
                            await bthSocket.ConnectAsync();

                            if (bthSocket.IsConnected)
                            {
                                System.Diagnostics.Debug.WriteLine("Connected!");
                                while (_ct.IsCancellationRequested == false)
                                {
                                    if (MessageToSend != null)
                                    {
                                        var chars = MessageToSend.ToCharArray();
                                        var bytes = new List<byte>();
                                        foreach (var character in chars)
                                        {
                                            bytes.Add((byte)character);
                                        }

                                        await bthSocket.OutputStream.WriteAsync(bytes.ToArray(), 0, bytes.Count);
                                        MessageToSend = null;
                                    }
                                }
                            }
                        }
                    }
                }
                catch
                {
                }
                finally
                {
                    if (bthSocket != null)
                        bthSocket.Close();
                    device = null;
                    adapter = null;
                }
            }
        }


        public ObservableCollection<string> PairedDevices()
        {
            BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
            adapter.StartDiscovery();
            ObservableCollection<string> devices = new ObservableCollection<string>();
            
            foreach (var bd in adapter.BondedDevices)
                devices.Add(bd.Name);

            return devices;
        }



        /* public string OnReceive(Context context,Intent intent)
         {
             var action = intent.Action;
             if(action != BluetoothDevice.ActionFound)
             {
                 BluetoothDevice newDevice = (BluetoothDevice)intent.GetParcelableExtra(BluetoothDevice.ExtraDevice);
             }
             var device = (BluetoothDevice)intent.GetParcelableExtra(BluetoothDevice.ExtraDevice);

             if (device.BondState != Bond.Bonded)
             {
                 return device.Name;
             }
             return null;
         }
          public List<string> UnPairedDevices()
         {
             BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
             if (adapter.IsDiscovering) adapter.CancelDiscovery();
             adapter.StartDiscovery();

             BluetoothReceiver btReceiver = new BluetoothReceiver();

             List<string> devices = new List<string>();

             foreach (BluetoothDevice device in btReceiver.devices)
             {
                 devices.Add(device.Name);
             }return devices;

             Context context = btReceiver.context;
             Intent intent = btReceiver.intent;


             var rec = btReceiver.OnReceive(context , intent);
             List<string> devices = new List<string>();
             if (btReceiver.action != BluetoothDevice.ActionFound)
             {
                 return null;
             }
             var device = (BluetoothDevice)intent.GetParcelableExtra(BluetoothDevice.ExtraDevice);
              if (device.BondState != Bond.Bonded)
              {
                  devices.Add(device.Name);

              }

             btReceiver.OnReceive();///fix parameters
             devices= btReceiver.devices;

             foreach (var device in btReceiver.devices)
             {
                 devices.Add(device);
             }
             return devices;
             */


        /*  public List<string> UnpairedDevices(Intent intent,Context context)
          {
              BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
              List<string> devices = new List<string>();
              var action = intent.Action;

              if (!adapter.IsEnabled)
              {
                  Intent enableBtIntent = new Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE);
              }



              IntentFilter filter = new IntentFilter(BluetoothDevice.ACTION_FOUND);
              registerReceiver(mReceiver, filter);
          }

          }*/
    }
}