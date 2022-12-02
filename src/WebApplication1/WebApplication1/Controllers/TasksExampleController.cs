using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class TasksExampleController : ControllerBase
    {
        [HttpGet("asynchronous")]
        public async Task<IActionResult> GetTasksExample1()
        {
            return Ok("");
        }

        
        [HttpGet("synchronous")]
        public async Task<IActionResult> GetTasksExample2()
        {
            return Ok("");
        }
    }
}