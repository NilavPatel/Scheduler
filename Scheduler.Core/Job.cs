namespace Scheduler.Core
{
    /// <summary>
    /// Classes which extend this abstract class are Jobs which will be
    /// started as soon as the application starts. These Jobs are executed
    /// asynchronously from the any Application.
    /// </summary>
    public abstract class Job
    {
        /// <summary>
        /// Execute the Job itself
        /// </summary>
        public void ExecuteJob()
        {
            if (GetJobRunType() == JobRunType.Single)
            {
                // since there is no repetetion, simply execute the job
                DoJob();
            }
            else
            {
                // execute the job after repeatable time, doesn't matter previous job is completed or not
                // Multiple execution of job possible
                if (GetJobRunType() == JobRunType.RepeatAfterTime)
                {
                    var timeSpan = TimeSpan.FromMilliseconds(GetRepetitionIntervalTime());
                    var timer = new Timer((state) => { DoJob(); }, null, TimeSpan.Zero, timeSpan);
                }
                else
                {
                    // execute the job after repeatable interval, next job will run after specific interval of previous job completion
                    while (true)
                    {
                        DoJob();
                        Thread.Sleep(GetRepetitionIntervalTime());
                    }
                }
            }
        }

        /// <summary>
        /// If this method is overriden, on can get within the job
        /// parameters set just before the job is started. In this
        /// situation the application is running and the use may have
        /// access to resources which he/she has not during the thread
        /// execution. For instance, in a web application, the user has
        /// no access to the application context, when the thread is running.
        /// Note that this method must not be overriden. It is optional.
        /// </summary>
        /// <returns>Parameters to be used in the job.</returns>
        public virtual Object? GetParameters()
        {
            return null;
        }

        /// <summary>
        /// Get the Job´s Name. This name uniquely identifies the Job.
        /// </summary>
        /// <returns>Job´s name.</returns>
        public abstract String GetName();

        /// <summary>
        /// The job to be executed.
        /// </summary>
        public abstract void DoJob();

        /// <summary>
        /// The amount of time, in milliseconds, which the Job has to wait until it is started
        /// over. This method is only useful if JobRunType is RepeatAfterTime or RepeatAfterInterval, otherwise
        /// its implementation is ignored.
        /// </summary>
        /// <returns>Interval time between this job executions.</returns>
        public abstract int GetRepetitionIntervalTime();

        /// <summary>
        /// Set job run type to run job on every time or after delay of previous execution
        /// </summary>
        /// <returns>Job run type.</returns>
        public abstract JobRunType GetJobRunType();
    }
}