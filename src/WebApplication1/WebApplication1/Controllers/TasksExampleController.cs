using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class TasksExampleController : ControllerBase
    {
        
        [HttpGet("asynchronous")]
        public async Task<IActionResult> GetTasks()
        {
            return Ok("");
        }
    }
}