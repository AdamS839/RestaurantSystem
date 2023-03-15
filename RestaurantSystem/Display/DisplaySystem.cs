using RestaurantSystem.Business;
using RestaurantSystem.Data.Model;
using System.Globalization;

namespace RestaurantSystem.Display
{
    public class DisplaySystem
    {
        public static EmployeeBusiness employeeBusiness = new EmployeeBusiness();
        private static JobBusiness jobBusiness = new JobBusiness();

        public DisplaySystem()
        {
            Input();
        }

        private void Input()
        {
            while (true)
            {
                Console.Clear();
                DefaultDisplayMenu();
                int cmd = int.Parse(Console.ReadLine());
                switch (cmd)
                {
                    case 1:
                        Console.Clear();
                        EmployeesDisplayMenu();
                        break;
                    case 2:
                        Console.Clear();
                        JobsDisplayMenu();
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        static void DefaultDisplayMenu()
        {
            Console.WriteLine(new string('=', 50));
            Console.WriteLine(new string('=', 13) + " Restaurant System Menu " + new string('=', 13));
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("1. Employees");
            Console.WriteLine("2. Jobs");
            Console.WriteLine("3. Tables");
            Console.WriteLine("4. Orders");
            Console.WriteLine("5. Products");
            Console.WriteLine("9. Exit");
            Console.WriteLine(new string('=', 50));
        }

        static void EmployeesDisplayMenu()
        {
            Console.Clear();
            EmployeesDisplayData();
            while (true)
            {
                int cmd = int.Parse(Console.ReadLine());
                switch (cmd)
                {
                    case 0:
                        return;
                        break;
                    case 2:
                        AddEmployee();
                        return;
                        break;
                    default:
                        Console.Clear();
                        EmployeesDisplayData();
                        break;
                }
            }
        }

        static void EmployeesDisplayData()
        {
            Console.WriteLine(new string('=', 30));
            Console.WriteLine(new string('=', 7) + " Employees Menu " + new string('=', 7));
            Console.WriteLine(new string('=', 30));
            Console.WriteLine("1. List all employees");
            Console.WriteLine("2. Add employee");
            Console.WriteLine("3. Remove employee");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Get employee by Id");
            Console.WriteLine("0. Back");
            Console.WriteLine(new string('=', 30));
        }

        static void AddEmployee()
        {
            Employee employee = new Employee();
            Console.WriteLine("Enter first name: ");
            employee.FirstName = Console.ReadLine();
            Console.WriteLine("Enter last name: ");
            employee.LastName = Console.ReadLine();
            Console.WriteLine("Enter age: ");
            employee.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter email address: ");
            employee.Mail = Console.ReadLine();
            Console.WriteLine("Enter phone number: ");
            employee.Phone = Console.ReadLine();
            Console.WriteLine("Enter job id: ");
            employee.JobId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter manager id: ");
            employee.ManagerId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter hire date: ");
            employee.HireDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            employeeBusiness.Add(employee);
            Console.WriteLine("Successfully added employee.");
        }

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
                    default:
                        Console.Clear();
                        JobsDisplayData();
                        break;
                }
            }
        }


        static void JobsDisplayData()
        {
            Console.WriteLine(new string('=', 30));
            Console.WriteLine(new string('=', 10) + " Jobs Menu " + new string('=', 9));
            Console.WriteLine(new string('=', 30));
            Console.WriteLine("1. List all jobs");
            Console.WriteLine("2. Add job");
            Console.WriteLine("3. Remove job");
            Console.WriteLine("4. Get job by id");
            Console.WriteLine("5. Update");
            Console.WriteLine("0. Back");
            Console.WriteLine(new string('=', 30));
        }

        static void ListJobs()
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine(new string('=', 15) + " Job List " + new string('=', 15));
            Console.WriteLine(new string('=', 40));
            var jobs = jobBusiness.GetAll();
            foreach (var item in jobs)
            {
                Console.WriteLine("{0}. {1} {2}", item.Id, item.Name, item.Salary);
            }
            Console.WriteLine(new string('=', 40));
            Console.ReadKey();
        }

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

        static void RemoveJob()
        {
            Job job = new Job();
            Console.WriteLine("Enter job ID you want to delete: ");
            int id = int.Parse(Console.ReadLine());
            jobBusiness.Delete(id);
            Console.WriteLine("Job deleted successfully!");
            Thread.Sleep(3000);
        }

        static void GetJob()
        {
            Console.WriteLine(new string('=', 41));
            Console.WriteLine(new string('=', 13) + " Get job by id " + new string('=', 13));
            Console.WriteLine(new string('=', 41));
            Console.WriteLine("Enter Id to find job: ");
            int id = int.Parse(Console.ReadLine());
            Job job = jobBusiness.Get(id);
            if(job != null)
            {
                Console.WriteLine(new string('=', 20));
                Console.WriteLine("ID: " + job.Id);
                Console.WriteLine("Name: " + job.Name);
                Console.WriteLine("Salary: " + job.Salary);
                Console.WriteLine(new string('=', 20));
            }
            Console.ReadKey();
        }

    }
}
