using Microsoft.AspNetCore.Mvc;

namespace LearnThreads.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QueueController(IQueueService queueService) : ControllerBase
    {

        [HttpPost("pause")]
        public async Task<IActionResult> Pause()
        {
            queueService.Stop();
            return Ok();
        }

        [HttpPost("start")]
        public async Task<IActionResult> Start()
        {
            queueService.Start();
            return Ok();
        }
    }
}
