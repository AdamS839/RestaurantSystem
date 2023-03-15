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

        public List<Job> GetAll()
        {
            using (jobContext = new RestaurantContext())
            {
                return jobContext.Jobs.ToList();
            }
        }

        public Job Get(int id)
        {
            using (jobContext = new RestaurantContext())
            {
                return jobContext.Jobs.Find(id);
            }
        }

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
