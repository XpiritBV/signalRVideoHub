using Microsoft.AspNetCore.SignalR.Client;
using Octane.Xamarin.Forms.VideoPlayer;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using VideoHubClient;
using Xamarin.Forms;

namespace VideoPlayer
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        HubClient client;

        public MainPage()
        {
            InitializeComponent();
            btnWeb.IsEnabled = false;
            btnWin.IsEnabled = false;

            client = new HubClient("Xamarin", (channel1, channel2) =>
            {
                stream1.Source = VideoSource.FromUri(channel1);
                stream2.Source = VideoSource.FromUri(channel2);
                return Task.CompletedTask;
            });

            StartSignalR().ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    DisplayAlert("Error!", t.Exception.Message, "OK");
                }
            });
        }

        private async Task StartSignalR()
        {
            await client.Start();
            btnWeb.IsEnabled = true;
            btnWin.IsEnabled = true;
        }

        private async void Button_Clicked_Windows(object sender, EventArgs e)
        {
            await client.SwitchWindows();
        }

        private async void Button_Clicked_Web(object sender, EventArgs e)
        {
            await client.SwitchWeb();
        }
    }
}
