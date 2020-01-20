using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VideoPlayer.hub.Model
{
    public class VideoStore
    {
        private Movies movies;

        public async Task<IEnumerable<Uri>> GetVideos()
        {
            if (movies == null)
            {
                using var stream = new FileStream("VideoUrls.json", FileMode.Open);
                using var reader = new StreamReader(stream);

                movies = JsonConvert.DeserializeObject<Movies>(await reader.ReadToEndAsync());
            }

            return movies.Categories.SelectMany(c => c.Videos.Select(v => v.Sources.First()));
        }
    }
}
