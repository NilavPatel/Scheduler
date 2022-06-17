using Scheduler.Core;

namespace Scheduler.Demo.Jobs
{
    class SingleExecutionJob : Job
    {
        public override string GetName()
        {
            return this.GetType().Name;
        }

        public override void DoJob()
        {
            System.Console.WriteLine(String.Format("The Job \"{0}\" was executed.", this.GetName()));
        }

        public override int GetRepetitionIntervalTime()
        {
            throw new NotImplementedException();
        }

        public override JobRunType GetJobRunType()
        {
            return JobRunType.Single;
        }
    }
}