using Scheduler.Core;

namespace Scheduler.Demo
{
    public class Program
    {
        static public void Main(String[] args)
        {
            var jobManager = new JobManager();
            jobManager.ExecuteAllJobs();

            System.Console.ReadLine();
        }
    }
}