# Scheduler

## Basic implementation of Job scheduler using .net

## Technology
- .net 7

## Documentation

There are 3 types of jobs available:
1. Single Execution: For this job execution will be done only 1 time.
1. Repeate After Time: For this job exection will be repeated after each time span
    - In this type of exection multiple instaces can be running at a time.
    - This will not wait to finish execution of previous job
1. Repeate After Interval: For this job exection will be repeated after interval of time from previous exection.
    - In this type of exection always only 1 instance is running.
    - Here new job will execute after completion of previous job


## For demo check Scheduler.Demo

## For hosted services in web application check below link
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-6.0&tabs=visual-studio