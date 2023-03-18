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
        /// Gets a List of all jobs
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
        /// Gets a job type by id
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
        /// Adds a job type by 
        /// 
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

        public void Delete(int id)
        {
            using (jobContext = new RestaurantContext())
            {
                var job = jobContext.Jobs.Find(id);
                if (job != null)
                {
                    jobContext.Jobs.Remove(job);
                    jobContext.SaveChanges();
                }
            }
        }

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
