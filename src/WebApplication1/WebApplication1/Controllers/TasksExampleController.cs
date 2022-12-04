using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class TasksExampleController : ControllerBase
    {
        private Services _services;

        public TasksExampleController(Services services)
            => _services = services;

        [HttpGet("asynchronous")]
        public async Task<IActionResult> GetTasksExample1()
        {
            List<Task> tasks = new ();    
            List<string> response = new ();

            Task task1 = _services.GetTaskOne();
            Task task2 = _services.GetTaskTwo();

            tasks.Add (task1);
            tasks.Add (task2);

            await Task.WhenAll(tasks);

            foreach (var task in tasks)
            {
                var result = ((Task<string>)task).Result;
                response.Add(result);
            }

            return Ok(tasks);
        }

        
        [HttpGet("synchronous")]
        public async Task<IActionResult> GetTasksExample2()
        {
            return Ok("");
        }
    }
}