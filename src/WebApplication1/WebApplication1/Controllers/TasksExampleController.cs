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
            Task<string> task2 = _services.GetTaskTwo();
            Task<int> task3 = _services.GetTaskTree();

            tasks.Add(task1);
            tasks.Add(task2);
            tasks.Add(task3);

            await Task.WhenAll(tasks);

            var axu = task1.Result;
            var aux = task2.Result;
            var auxInt = task3.Result;

            response.Add(axu);
            response.Add(aux);
            response.Add(auxInt.ToString());

            //foreach (var task in tasks)
            //{
            //    var result = ((Task<string>)task).Result;
            //    response.Add(task.res);
            //}

            return Ok(response);
        }

        
        [HttpGet("synchronous")]
        public async Task<IActionResult> GetTasksExample2()
        {
            return Ok("");
        }
    }
}