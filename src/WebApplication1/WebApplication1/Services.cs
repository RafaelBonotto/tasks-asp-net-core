namespace WebApplication1
{
    public class Services
    {
        public async Task<string> GetTaskOne()
            => "Task<string> Service 1 Executed";

        public async Task<int> GetTaskTwo()
            => 2;
    }
}