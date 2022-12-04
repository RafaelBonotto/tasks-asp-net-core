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

            Task<string> task1 = _services.GetTaskOne();
            Task<string> task2 = _services.GetTaskOne();
            Task<string> task3 = _services.GetTaskOne();

            Task<int> task4 = _services.GetTaskTwo();
            Task<int> task5 = _services.GetTaskTwo();
            Task<int> task6 = _services.GetTaskTwo();

            tasks.Add(task1);
            tasks.Add(task2);
            tasks.Add(task3);
            tasks.Add(task4);
            tasks.Add(task5);
            tasks.Add(task6);

            await Task.WhenAll(tasks);

            response.Add(task1.Result);
            response.Add(task2.Result);
            response.Add(task3.Result);

            response.Add($"Task <int> Service {task4.Result} Executed"); 
            response.Add($"Task <int> Service {task5.Result} Executed"); 
            response.Add($"Task <int> Service {task6.Result} Executed"); 

            return Ok(response);
        }

        
        [HttpGet("synchronous")]
        public async Task<IActionResult> GetTasksExample2()
        {
            return Ok("");
        }
    }
}