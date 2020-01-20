using Microsoft.AspNetCore.SignalR.Client;
using Octane.Xamarin.Forms.VideoPlayer;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VideoPlayer
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        HubConnection connection;
        public MainPage()
        {
            InitializeComponent();            

            connection = new HubConnectionBuilder()
                .WithUrl(Constants.signalrHub)
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                StartSignalR();
            };

            connection.On<string, string>("switchChannel", (channel1, channel2) =>
            {
                stream1.Source = VideoSource.FromUri(channel1);
                stream2.Source = VideoSource.FromUri(channel2);
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
             await connection.StartAsync();
             await connection.InvokeAsync("SetClient", "Xamarin");
        }

        private async void Button_Clicked_Windows(object sender, EventArgs e)
        {
            await connection.InvokeAsync("SwitchChannelWindows");
        }

        private async void Button_Clicked_Web(object sender, EventArgs e)
        {
            await connection.InvokeAsync("SwitchChannelWeb");
        }
    }
}
