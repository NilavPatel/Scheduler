namespace Scheduler.Core
{
    // <summary>
    /// Job manager.
    /// </summary>
    public class JobManager
    {
        /// <summary>
        /// Execute all Jobs.
        /// </summary>
        public void ExecuteAllJobs()
        {
            try
            {
                // get all job implementations of this assembly.
                IEnumerable<Type> jobs = GetAllImplementedJobs(typeof(Job));
                // execute each job
                if (jobs != null && jobs.Count() > 0)
                {
                    foreach (Type job in jobs)
                    {
                        try
                        {
                            var jobObject = Activator.CreateInstance(job);
                            if (jobObject != null)
                            {
                                // instantiate job by reflection
                                var jobInstance = (Job)jobObject;
                                // create thread for this job execution method
                                var thread = new Thread(new ThreadStart(jobInstance.ExecuteJob));
                                // start thread executing the job
                                thread.Start();
                            }
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Returns all types in the current executing assembly implementing the interface or inheriting the type. 
        /// </summary>
        private IEnumerable<Type> GetAllImplementedJobs(Type desiredType)
        {
            return AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsSubclassOf(desiredType));

        }
    }
}