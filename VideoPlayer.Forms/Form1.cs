using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoPlayer.Forms
{
    public partial class Form1 : Form
    {

        HubConnection connection;
        public Form1()
        {
            InitializeComponent();
            connection = new HubConnectionBuilder()
            .WithUrl(Constants.signalrHub)
            .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await StartSignalR();
            };

            connection.On<string, string>("switchChannel", (channel1, channel2) =>
            {
                stream1.URL = channel1;
                stream2.URL = channel2;
            });

            try
            {
                StartSignalR().Wait(6000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private async Task StartSignalR()
        {
            await connection.StartAsync();
            await connection.InvokeAsync("SetClient", "Windows");
        }




        private async void button1_Click(object sender, EventArgs e)
        {
            await connection.InvokeAsync("SwitchChannelXamarin");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await connection.InvokeAsync("SwitchChannelWeb");
        }


    }
}
