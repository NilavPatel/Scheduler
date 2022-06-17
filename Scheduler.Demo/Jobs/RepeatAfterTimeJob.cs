using Scheduler.Core;

namespace Scheduler.Demo.Jobs
{
    class RepeatAfterTimeJob : Job
    {
        private int counter = 0;

        public override string GetName()
        {
            return this.GetType().Name;
        }

        public override void DoJob()
        {
            var currentCounter = counter;
            System.Console.WriteLine(String.Format("This is the execution number \"{0}\" of the Job \"{1}\".", currentCounter.ToString(), this.GetName()));
            counter++;
            Thread.Sleep(5000);
            System.Console.WriteLine(String.Format("Complete execution number \"{0}\" of the Job \"{1}\".", currentCounter.ToString(), this.GetName()));
        }

        public override int GetRepetitionIntervalTime()
        {
            return 1000;
        }

        public override JobRunType GetJobRunType()
        {
            return JobRunType.RepeatAfterTime;
        }
    }
}