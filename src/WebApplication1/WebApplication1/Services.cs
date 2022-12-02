namespace WebApplication1
{
    public class Services
    {
        public async Task<string> GetTaskOne()
            => "Task one Executed";

        public async Task<string> GetTaskTwo()
            => "Task two Executed";
    }
}