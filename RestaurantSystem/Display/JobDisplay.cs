using RestaurantSystem.Business;
using RestaurantSystem.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Display
{
    public class JobDisplay
    {
        private static JobBusiness jobBusiness = new JobBusiness();

        /// <summary>
        /// Calling the main display method for jobs
        /// </summary>
        public JobDisplay()
        {
            jobBusiness = new JobBusiness();
            JobsDisplayMenu();
        }

        /// <summary>
        ///  Main display menu for jobs, calling each method
        /// </summary>
        static void JobsDisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                JobsDisplayData();
                int cmd = int.Parse(Console.ReadLine());
                switch (cmd)
                {
                    case 0:
                        return;
                        break;
                    case 1:
                        Console.Clear();
                        ListJobs();
                        break;
                    case 2:
                        AddJob();
                        break;
                    case 3:
                        RemoveJob();
                        break;
                    case 4:
                        Console.Clear();
                        GetJob();
                        break;
                    case 5:
                        Console.Clear();
                        UpdateJob();
                        break;
                    default:
                        Console.Clear();
                        JobsDisplayData();
                        break;
                }
            }
        }

        /// <summary>
        /// Display data menu for jobs
        /// </summary>
        static void JobsDisplayData()
        {
            Console.WriteLine(new string('=', 30));
            Console.WriteLine(new string('=', 10) + " Jobs Menu " + new string('=', 9));
            Console.WriteLine(new string('=', 30));
            Console.WriteLine("1. List all jobs");
            Console.WriteLine("2. Add job");
            Console.WriteLine("3. Remove job");
            Console.WriteLine("4. Get job by id");
            Console.WriteLine("5. Update job");
            Console.WriteLine("0. Back");
            Console.WriteLine(new string('=', 30));
        }

        /// <summary>
        /// Lists all jobs added
        /// </summary>
        static void ListJobs()
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine(new string('=', 15) + " Job List " + new string('=', 15));
            Console.WriteLine(new string('=', 40));
            var jobs = jobBusiness.GetAll();
            Console.WriteLine("ID Name Salary");
            foreach (var item in jobs)
            {
                Console.WriteLine("{0}. {1} {2}", item.Id, item.Name, item.Salary);
            }
            Console.WriteLine(new string('=', 40));
            Console.ReadKey();
        }

        /// <summary>
        /// Adds job
        /// </summary>
        static void AddJob()
        {
            Job job = new Job();
            Console.WriteLine("Ënter job name: ");
            job.Name = Console.ReadLine();
            Console.WriteLine("Enter salary: ");
            job.Salary = decimal.Parse(Console.ReadLine());
            jobBusiness.Add(job);
            Console.WriteLine("Job added successfully.");
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Removes job by id
        /// </summary>
        static void RemoveJob()
        {
            Job job = new Job();
            Console.WriteLine("Enter job ID you want to delete: ");
            int id = int.Parse(Console.ReadLine());
            jobBusiness.Delete(id);
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Finds the job id and if the job exists, the information about the job is displayed
        /// </summary>
        static void GetJob()
        {
            Console.WriteLine(new string('=', 41));
            Console.WriteLine(new string('=', 13) + " Get job by id " + new string('=', 13));
            Console.WriteLine(new string('=', 41));
            Console.WriteLine("Enter Id to find job: ");
            int id = int.Parse(Console.ReadLine());
            Job job = jobBusiness.Get(id);
            if (job != null)
            {
                Console.WriteLine(new string('=', 20));
                Console.WriteLine("ID: " + job.Id);
                Console.WriteLine("Name: " + job.Name);
                Console.WriteLine("Salary: " + job.Salary);
                Console.WriteLine(new string('=', 20));
            }
            else
            {
                Console.WriteLine("Job not found!");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Updates the information about a job
        /// </summary>
        static void UpdateJob()
        {
            Console.WriteLine("Enter job ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Job job = jobBusiness.Get(id);
            if (job != null)
            {
                Console.WriteLine("Enter job name: ");
                job.Name = Console.ReadLine();
                Console.WriteLine("Enter salary: ");
                job.Salary = decimal.Parse(Console.ReadLine());
                jobBusiness.Update(job);
                Console.WriteLine("Job updated successfully.");
            }
            else
            {
                Console.WriteLine("Job not found.");
            }
            Thread.Sleep(4000);
        }

    }
}
