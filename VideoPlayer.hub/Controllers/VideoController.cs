using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideoPlayer.hub.Model;

namespace VideoPlayer.hub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly VideoStore store;

        public VideoController(VideoStore store)
        {
            this.store = store;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var videos = await store.GetVideos();

            return Ok(videos);
        }
    }
}