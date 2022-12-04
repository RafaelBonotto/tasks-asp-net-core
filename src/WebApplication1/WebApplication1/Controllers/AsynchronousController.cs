using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class AsynchronousController : ControllerBase
    {
        private Services _services;

        public AsynchronousController(Services services)
            => _services = services;

        /// <summary>
        /// Execução de 6 Tasks de forma assincrona
        /// </summary>
        [HttpGet("asynchronous-example1")]
        public async Task<IActionResult> GetTasksExample1()
        {
            List<Task> tasks = new();
            List<string> response = new();

            Task<string> task1 = _services.GetTaskOne();
            Task<string> task2 = _services.GetTaskOne();
            Task<string> task3 = _services.GetTaskOne();

            Task<int> task4 = _services.GetTaskTwo();
            Task<int> task5 = _services.GetTaskTwo();
            Task<int> task6 = _services.GetTaskTwo();

            tasks.AddRange(new List<Task>{task1, task2, task3, task4, task5, task6});
            await Task.WhenAll(tasks);

            response.Add(task1.Result);
            response.Add(task2.Result);
            response.Add(task3.Result);

            response.Add($"Task<int> Service {task4.Result} Executed");
            response.Add($"Task<int> Service {task5.Result} Executed");
            response.Add($"Task<int> Service {task6.Result} Executed");

            return Ok(response);
        }

        /// <summary>
        /// Execução de 60 Tasks de forma assincrona, 
        /// sendo 30 retornando int e 30 retronando string, 
        /// porém todas executadas em paralelo
        /// </summary>
        [HttpGet("asynchronous-example2")]
        public async Task<IActionResult> GetTasksExample2()
        {
            List<Task<string>> tasksString = new();
            List<Task<int>> tasksInt = new();
            List<Task> tasks = new();
            List<string> response = new();


            for (int i = 0; i < 30; i++)
            {
                tasksString.Add(_services.GetTaskOne());
                tasksInt.Add(_services.GetTaskTwo());
            }

            tasks.AddRange(tasksString);
            tasks.AddRange(tasksInt);
            await Task.WhenAll(tasks);

            foreach (var task in tasksString)
                response.Add(task.Result);

            foreach (var task in tasksInt)
                response.Add($"Task<int> Service {task.Result} Executed"); 

            return Ok(response);
        }
    }
}