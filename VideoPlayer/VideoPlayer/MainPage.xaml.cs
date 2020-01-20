using Microsoft.AspNetCore.SignalR.Client;
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
            btnWeb.IsEnabled = false;
            btnWin.IsEnabled = false;

            connection = new HubConnectionBuilder()
                .WithUrl(Constants.signalrHub)
                .Build();

            connection.Closed += async (error) =>
            {
                btnWeb.IsEnabled = false;
                btnWin.IsEnabled = false;
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await StartSignalR();
            };

            connection.On<string, string>("switchChannel", (channel1, channel2) =>
            {
                stream1.Source = channel1;
                stream2.Source = channel2;
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
            btnWeb.IsEnabled = true;
            btnWin.IsEnabled = true;
        }

        private async void Button_Clicked_Windows(object sender, EventArgs e)
        {
            if (connection.State == HubConnectionState.Connected)
            {
                await connection.InvokeAsync("SwitchChannelWindows");
            }
        }

        private async void Button_Clicked_Web(object sender, EventArgs e)
        {
            if (connection.State == HubConnectionState.Connected)
            {
                await connection.InvokeAsync("SwitchChannelWeb");
            }
        }
    }
}
