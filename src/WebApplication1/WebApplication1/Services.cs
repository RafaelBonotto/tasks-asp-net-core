namespace WebApplication1
{
    public class Services
    {
        public async Task<string> GetTaskOne()
            => "Task Service 1 Executed";

        public async Task<string> GetTaskTwo()
            => "Task Service 2 Executed";
    }
}