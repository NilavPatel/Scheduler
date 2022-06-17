namespace Scheduler.Core
{
    public enum JobRunType
    {
        // Single Execition
        Single = 0,
        // Repeate exection after every specific time, doesn't matter if previous job execition is completed or not
        RepeatAfterTime = 1,
        // Repeate exection after specific interval between previous and next job exection
        RepeatAfterInterval = 2
    }
}