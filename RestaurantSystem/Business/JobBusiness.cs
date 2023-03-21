using System;
using System.Collections.Generic;
using System.Text;
using RestaurantSystem.Data;
using RestaurantSystem.Data.Model;
using System.Linq;

namespace RestaurantSystem.Business
{
    class JobBusiness
    {
        private RestaurantContext jobContext;

        /// <summary>
        /// Returns a list of all jobs
        /// </summary>
        /// <returns></returns>
        public List<Job> GetAll()
        {
            using (jobContext = new RestaurantContext())
            {
                return jobContext.Jobs.ToList();
            }
        }

        /// <summary>
        /// Finds the job with the specified id and returns it
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Job Get(int id)
        {
            using (jobContext = new RestaurantContext())
            {
                return jobContext.Jobs.Find(id);
            }
        }

        /// <summary>
        /// Adds a job
        /// </summary>
        /// <param name="job"></param>
        public void Add(Job job)
        {
            using (jobContext = new RestaurantContext())
            {
                jobContext.Jobs.Add(job);
                jobContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the job with specified id if the job exists, if not - no action is taken
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (jobContext = new RestaurantContext())
            {
                var job = jobContext.Jobs.Find(id);
                if (job != null)
                {
                    jobContext.Jobs.Remove(job);
                    jobContext.SaveChanges();
                    Console.WriteLine("Job deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Job not found!");
                }
            }
        }

        /// <summary>
        /// Retrieves existing job by searching the id, updates the properties and finally save the changes to the database
        /// </summary>
        /// <param name="job"></param>
        public void Update(Job job)
        {
            using (jobContext = new RestaurantContext())
            {
                var item = jobContext.Jobs.Find(job.Id);
                if (item != null)
                {
                    jobContext.Entry(item).CurrentValues.SetValues(job);
                    jobContext.SaveChanges();
                }
            }
        }

    }
}
