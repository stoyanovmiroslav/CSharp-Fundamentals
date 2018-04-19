using System.Collections.Generic;

namespace _04.WorkForce
{
    public class JobList : List<Job>
    {
        public void AddJob(Job job)
        {
            this.Add(job);
            job.CompletedJob += OnJobComplete;
        }

        public void OnJobComplete(Job job)
        {
            this.Remove(job);
        }
    }
}