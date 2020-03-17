using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace App1
{

    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");
        public MainPage()
        {
            InitializeComponent();
            if (File.Exists(_fileName))
            {
                //editor.Text = File.ReadAllText(_fileName);
            }

        }

        void OnSaveButtonClicked(Object sender, EventArgs e)
        {
            //File.WriteAllText(_fileName, editor.Text);
        }
        void OnDeleteButtonClicked(Object sender, EventArgs e)
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
            //editor.Text = string.Empty;

        }

        void OnHelloButtonClicked(Object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }

        void OnBTButtonClicked(Object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }

      /*   async void OnNextPageButtonClicked(Object sender, EventArgs e)
        {
                await Navigation.PushAsync(new Views.MainPages.LightsV());
        }*/
    }
}
