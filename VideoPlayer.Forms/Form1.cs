using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoHubClient;

namespace VideoPlayer.Forms
{
    public partial class Form1 : Form
    {
        HubClient client;

        public Form1()
        {
            InitializeComponent();

            client = new HubClient("Windows", (channel1, channel2) =>
            {
                stream1.URL = channel1;
                stream2.URL = channel2;
                return Task.CompletedTask;
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
            await client.Start();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await client.SwitchXamarin();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await client.SwitchWeb();
        }
    }
}
