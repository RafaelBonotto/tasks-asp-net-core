using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1;

namespace TasksExamples.Controllers
{
    [Route("tasks-synchronous")]
    [ApiController]
    public class SynchronousController : ControllerBase
    {
        private Services _services;

        public SynchronousController(Services services)
            => _services = services;

        [HttpGet("example1")]
        public async Task<IActionResult> GetTasksExample1()
        {
            List<string> response = new();

            response.Add(await _services.GetTaskOne());
            response.Add(await _services.GetTaskOne());
            response.Add(await _services.GetTaskOne());

            response.Add($"Task<int> Service {await _services.GetTaskTwo()} Executed");
            response.Add($"Task<int> Service {await _services.GetTaskTwo()} Executed");
            response.Add($"Task<int> Service {await _services.GetTaskTwo()} Executed");

            return Ok(response);
        }
    }
}
