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

        /// <summary>
        /// Execução de 60 Tasks de forma sincrona, 
        /// sendo 30 retornando int e 30 retronando string
        /// </summary>
        [HttpGet("example2")]
        public async Task<IActionResult> GetTasksExample2()
        {
            List<string> tasksString = new();
            List<int> tasksInt = new();
            List<string> response = new();

            for (int i = 0; i < 30; i++)
            {
                tasksString.Add(await _services.GetTaskOne());
                tasksInt.Add(await _services.GetTaskTwo());
            }

            foreach (var task in tasksString)
                response.Add(task);

            foreach (var task in tasksInt)
                response.Add($"Task<int> Service {task} Executed");

            return Ok(response);
        }
    }
}
