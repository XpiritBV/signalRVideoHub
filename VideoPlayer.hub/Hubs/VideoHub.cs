using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;
using VideoPlayer.hub.Model;

namespace VideoPlayer.hub.Hubs
{
    public class VideoHub : Hub
    {
        private Random rand = new Random();

        private readonly VideoStore videoStore;

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public VideoHub(VideoStore videoStore)
        {
            this.videoStore = videoStore;
        }

        public Task SetClient(string client)
        {
            return Groups
                .AddToGroupAsync(Context.ConnectionId, client.ToUpperInvariant());
        }

        public Task SwitchChannelXamarin()
        {
            return SwitchChannel("XAMARIN");
        }

        public Task SwitchChannelWeb()
        {
            return SwitchChannel("WEB");
        }

        public Task SwitchChannelWindows()
        {
            return SwitchChannel("WINDOWS");
        }

        public async Task SwitchChannel(string client)
        {
            var videos = await videoStore.GetVideos();

            var video1 = videos.ElementAt(rand.Next(videos.Count()));
            var video2 = videos.ElementAt(rand.Next(videos.Count()));

            await Clients.Groups(client.ToUpperInvariant())
                .SendAsync("switchChannel", video1.AbsoluteUri, video2.AbsoluteUri);
        }
    }
}
