using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace VideoHubClient
{
    public class HubClient
    {
        private readonly HubConnection hubConnection;
        private readonly string clientType;

        public HubClient(string clientType, Func<string, string, Task> func)
        {
            if (func == null) throw new ArgumentNullException(nameof(func));
            this.clientType = clientType ?? throw new ArgumentNullException(nameof(clientType));

            hubConnection = new HubConnectionBuilder()
                .WithUrl(Constants.signalrHub)
                .WithAutomaticReconnect(new[] { TimeSpan.FromSeconds(4), TimeSpan.FromSeconds(10) })
                .Build();

            hubConnection.On<string, string>("switchChannel", func);
        }

        public async Task Start()
        {
            await hubConnection.StartAsync();
            await hubConnection.InvokeAsync("SetClient", clientType);
        }

        public Task SwitchXamarin()
        {
            if (hubConnection.State == HubConnectionState.Connected)
            {
                return hubConnection.InvokeAsync("SwitchChannelXamarin");
            }
            return Task.CompletedTask;
        }

        public Task SwitchWindows()
        {
            if (hubConnection.State == HubConnectionState.Connected)
            {
                return hubConnection.InvokeAsync("SwitchChannelWindows");
            }
            return Task.CompletedTask;
        }

        public Task SwitchWeb()
        {
            if (hubConnection.State == HubConnectionState.Connected)
            {
                return hubConnection.InvokeAsync("SwitchChannelWeb");
            }
            return Task.CompletedTask;
        }
    }
}
