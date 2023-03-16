using RestaurantSystem.Business;
using RestaurantSystem.Data;
using RestaurantSystem.Data.Model;
using System.Globalization;

namespace RestaurantSystem.Display
{
    public class DisplaySystem
    {
        public static EmployeeBusiness employeeBusiness = new EmployeeBusiness();
        private static JobBusiness jobBusiness = new JobBusiness();
        private static OrderBusiness orderBusiness = new OrderBusiness();
        private static TableBusiness tableBusiness = new TableBusiness();
        private static ProductBusiness productBusiness = new ProductBusiness();

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
                    case 3:
                        Console.Clear();
                        TableDisplayMenu();
                        break;
                    case 4:
                        Console.Clear();
                        OrderDisplayMenu();
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
            while (true)
            {
                Console.Clear();
                EmployeesDisplayData();
                int cmd = int.Parse(Console.ReadLine());
                switch (cmd)
                {
                    case 0:
                        return;
                        break;
                    case 1:
                        Console.Clear();
                        ListEmployees();
                        break;
                    case 2:
                        AddEmployee();
                        break;
                    case 3:
                        RemoveEmployee();
                        break;
                    case 4:
                        Console.Clear();
                        GetEmployee();
                        break;
                    case 5:
                        Console.Clear();
                        UpdateEmployee();
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
            Console.WriteLine("4. Get employee by Id");
            Console.WriteLine("5. Update employee");
            Console.WriteLine("0. Back");
            Console.WriteLine(new string('=', 30));
        }

        static void ListEmployees()
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine(new string('=', 12) + " Employee List " + new string('=', 13));
            Console.WriteLine(new string('=', 40));
            var employees = employeeBusiness.GetAll();
            foreach (var item in employees)
            {
                Console.WriteLine("{0}. {1} {2} {3} {4} {5} {6} {7} {8}", item.Id, item.FirstName, item.LastName, item.Age, item.Mail, item.Phone, item.Job.Name, item.ManagerId, item.HireDate.ToString("dd-MM-yyyy"));
            }
            Console.WriteLine(new string('=', 40));
            Console.ReadKey();
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
            Thread.Sleep(3000);
        }

        static void RemoveEmployee()
        {
            Employee employee = new Employee();
            Console.WriteLine("Enter employee ID you want to delete: ");
            int id = int.Parse(Console.ReadLine());
            employeeBusiness.Delete(id);
            Console.WriteLine("Employee deleted successfully!");
            Thread.Sleep(3000);
        }
        static void GetEmployee()
        {
            Console.WriteLine(new string('=', 41));
            Console.WriteLine(new string('=', 10) + " Get employee by id " + new string('=', 10));
            Console.WriteLine(new string('=', 41));
            Console.WriteLine("Enter Id to find job: ");
            int id = int.Parse(Console.ReadLine());
            Employee employee = employeeBusiness.Get(id);
            if (employee != null)
            {
                Console.WriteLine(new string('=', 20));
                Console.WriteLine("ID: " + employee.Id);
                Console.WriteLine("First name: " + employee.FirstName);
                Console.WriteLine("Last name: " + employee.LastName);
                Console.WriteLine("Age: " + employee.Age);
                Console.WriteLine("Mail Address: " + employee.Mail);
                Console.WriteLine("Phone number: " + employee.Phone);
                Console.WriteLine("Job ID: " + employee.JobId);
                Console.WriteLine("Manager ID: " + employee.ManagerId);
                Console.WriteLine("Hire date: " + employee.HireDate);
                Console.WriteLine(new string('=', 20));
            }
            Console.ReadKey();
        }

        static void UpdateEmployee()
        {
            Console.WriteLine("Enter employee ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Employee employee = employeeBusiness.Get(id);
            if (employee != null)
            {
                Console.WriteLine("Enter first name: ");
                employee.FirstName = Console.ReadLine();
                Console.WriteLine("Enter last name: ");
                employee.LastName = Console.ReadLine();
                Console.WriteLine("Enter age: ");
                employee.Age = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter mail address: ");
                employee.Mail = Console.ReadLine();
                Console.WriteLine("Enter phone number: ");
                employee.Phone = Console.ReadLine();
                Console.WriteLine("Enter job ID: ");
                employee.JobId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter manager ID: ");
                employee.ManagerId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter hire date: ");
                employee.HireDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                employeeBusiness.Update(employee);
                Console.WriteLine("Employee updated successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
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
            if (job != null)
            {
                Console.WriteLine(new string('=', 20));
                Console.WriteLine("ID: " + job.Id);
                Console.WriteLine("Name: " + job.Name);
                Console.WriteLine("Salary: " + job.Salary);
                Console.WriteLine(new string('=', 20));
            }
            Console.ReadKey();
        }

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

        static void OrderDisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                OrderDisplayData();
                int cmd = int.Parse(Console.ReadLine());
                switch (cmd)
                {
                    case 0:
                        return;
                        break;
                    case 1:
                        Console.Clear();
                        ListOrders();
                        break;
                    case 2:
                        AddOrder();
                        break;
                    case 3:
                        RemoveOrder();
                        break;
                    case 4:
                        Console.Clear();
                        GetOrder();
                        break;
                    case 5:
                        Console.Clear();
                        UpdateOrder();
                        break;
                    default:
                        Console.Clear();
                        JobsDisplayData();
                        break;
                }
            }
        }

        static void OrderDisplayData()
        {
            Console.WriteLine(new string('=', 30));
            Console.WriteLine(new string('=', 9) + " Order Menu " + new string('=', 9));
            Console.WriteLine(new string('=', 30));
            Console.WriteLine("1. List all orders");
            Console.WriteLine("2. Add order");
            Console.WriteLine("3. Remove order");
            Console.WriteLine("4. Get order by id");
            Console.WriteLine("5. Update order");
            Console.WriteLine("0. Back");
            Console.WriteLine(new string('=', 30));
        }

        static void ListOrders()
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine(new string('=', 12) + " Order List " + new string('=', 12));
            Console.WriteLine(new string('=', 40));
            var orders = orderBusiness.GetAll();
            Console.WriteLine("ID Name Salary");
            foreach (var item in orders)
            {
                Console.WriteLine("{0}. {1} {2} {3}", item.Id, item.TableId, item.ProductId, item.Quantity);
            }
            Console.WriteLine(new string('=', 40));
            Console.ReadKey();
        }

        static void AddOrder()
        {
            Order order = new Order();
            Console.WriteLine("Ënter table id: ");
            order.TableId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter product id: ");
            order.ProductId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter quantity: ");
            order.Quantity = int.Parse(Console.ReadLine());
            orderBusiness.Add(order);
            Console.WriteLine("Order added successfully!");
            Thread.Sleep(3000);
        }

        static void RemoveOrder()
        {
            Order order = new Order();
            Console.WriteLine("Enter order ID you want to delete: ");
            int id = int.Parse(Console.ReadLine());
            orderBusiness.Delete(id);
            Console.WriteLine("Order deleted successfully!");
            Thread.Sleep(3000);
        }

        static void GetOrder()
        {
            Console.WriteLine(new string('=', 41));
            Console.WriteLine(new string('=', 12) + " Get order by id " + new string('=', 11));
            Console.WriteLine(new string('=', 41));
            Console.WriteLine("Enter Id to find order: ");
            int id = int.Parse(Console.ReadLine());
            Order order = orderBusiness.Get(id);
            if (order != null)
            {
                Console.WriteLine(new string('=', 20));
                Console.WriteLine("ID: " + order.Id);
                Console.WriteLine("Table ID: " + order.TableId);
                Console.WriteLine("Product ID: " + order.ProductId);
                Console.WriteLine("Quantity: " + order.Quantity);
                Console.WriteLine(new string('=', 20));
            }
            Console.ReadKey();
        }

        static void UpdateOrder()
        {
            Console.WriteLine("Enter order ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Order order = orderBusiness.Get(id);
            if (order != null)
            {
                Console.WriteLine("Enter table ID: ");
                order.TableId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter product ID: ");
                order.ProductId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter quantity: ");
                orderBusiness.Update(order);
                Console.WriteLine("Order updated successfully.");
            }
            else
            {
                Console.WriteLine("Order not found.");
            }
            Thread.Sleep(4000);
        }

        static void TableDisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                TableDisplayData();
                int cmd = int.Parse(Console.ReadLine());
                switch (cmd)
                {
                    case 0:
                        return;
                        break;
                    case 1:
                        Console.Clear();
                        ListTables();
                        break;
                    case 2:
                        AddTable();
                        break;
                    case 3:
                        RemoveTable();
                        break;
                    case 4:
                        Console.Clear();
                        GetTable();
                        break;
                    case 5:
                        Console.Clear();
                        UpdateTable();
                        break;
                    default:
                        Console.Clear();
                        TableDisplayData();
                        break;
                }
            }
        }

        static void TableDisplayData()
        {
            Console.WriteLine(new string('=', 30));
            Console.WriteLine(new string('=', 9) + " Table Menu " + new string('=', 9));
            Console.WriteLine(new string('=', 30));
            Console.WriteLine("1. List all tables");
            Console.WriteLine("2. Add table");
            Console.WriteLine("3. Remove table");
            Console.WriteLine("4. Get table by id");
            Console.WriteLine("5. Update table");
            Console.WriteLine("0. Back");
            Console.WriteLine(new string('=', 30));
        }

        static void ListTables()
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine(new string('=', 12) + " Table List " + new string('=', 12));
            Console.WriteLine(new string('=', 40));
            var tables = tableBusiness.GetAll();
            Console.WriteLine("ID Name Salary");
            foreach (var item in tables)
            {
                Console.WriteLine("{0}. {1} {2} {3}", item.Id, item.TableForm, item.Reserved, item.EmployeeId);
            }
            Console.WriteLine(new string('=', 40));
            Console.ReadKey();
        }

        static void AddTable()
        {
            Table table = new Table();
            Console.WriteLine("Ënter table form: ");
            table.TableForm = Console.ReadLine();
            Console.WriteLine("Enter reservation: ");
            table.Reserved = Console.ReadLine();
            Console.WriteLine("Enter waiter ID: ");
            table.EmployeeId = int.Parse(Console.ReadLine());
            tableBusiness.Add(table);
            Console.WriteLine("Table added successfully!");
            Thread.Sleep(3000);
        }

        static void RemoveTable()
        {
            Table table = new Table();
            Console.WriteLine("Enter table ID you want to delete: ");
            int id = int.Parse(Console.ReadLine());
            tableBusiness.Delete(id);
            Console.WriteLine("Table deleted successfully!");
            Thread.Sleep(3000);
        }

        static void GetTable()
        {
            Console.WriteLine(new string('=', 41));
            Console.WriteLine(new string('=', 12) + " Get table by id " + new string('=', 11));
            Console.WriteLine(new string('=', 41));
            Console.WriteLine("Enter Id to find table: ");
            int id = int.Parse(Console.ReadLine());
            Table table = tableBusiness.Get(id);
            if (table != null)
            {
                Console.WriteLine(new string('=', 20));
                Console.WriteLine("ID: " + table.Id);
                Console.WriteLine("Table form: " + table.TableForm);
                Console.WriteLine("Reserved: " + table.Reserved);
                Console.WriteLine("Waiter ID: " + table.EmployeeId);
                Console.WriteLine(new string('=', 20));
            }
            Console.ReadKey();
        }

        static void UpdateTable()
        {
            Console.WriteLine("Enter table ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Table table = tableBusiness.Get(id);
            if (table != null)
            {
                Console.WriteLine("Enter table form: ");
                table.TableForm = Console.ReadLine();
                Console.WriteLine("Enter reservation: ");
                table.Reserved = Console.ReadLine();
                Console.WriteLine("Enter waiter ID: ");
                table.EmployeeId = int.Parse(Console.ReadLine());
                tableBusiness.Update(table);
                Console.WriteLine("Table updated successfully!");
            }
            else
            {
                Console.WriteLine("Table not found.");
            }
            Thread.Sleep(4000);
        }

        static void ProductDisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                ProductDisplayData();
                int cmd = int.Parse(Console.ReadLine());
                switch (cmd)
                {
                    case 0:
                        return;
                        break;
                    case 1:
                        Console.Clear();
                        ListProducts();
                        break;
                    case 2:
                        AddProduct();
                        break;
                    case 3:
                        RemoveProduct();
                        break;
                    case 4:
                        Console.Clear();
                        GetProduct();
                        break;
                    case 5:
                        Console.Clear();
                        UpdateProduct();
                        break;
                    default:
                        Console.Clear();
                        ProductDisplayData();
                        break;
                }
            }
        }

        static void ProductDisplayData()
        {
            Console.WriteLine(new string('=', 30));
            Console.WriteLine(new string('=', 9) + " Product Menu " + new string('=', 9));
            Console.WriteLine(new string('=', 30));
            Console.WriteLine("1. List all products");
            Console.WriteLine("2. Add product");
            Console.WriteLine("3. Remove product");
            Console.WriteLine("4. Get product by id");
            Console.WriteLine("5. Update product");
            Console.WriteLine("0. Back");
            Console.WriteLine(new string('=', 30));
        }

        static void ListProducts()
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine(new string('=', 12) + " Product List " + new string('=', 12));
            Console.WriteLine(new string('=', 40));
            var products = productBusiness.GetAll();
            Console.WriteLine("ID Name Price");
            foreach (var item in products)
            {
                Console.WriteLine("{0}. {1} {2} ", item.Id, item.Name, item.Price);
            }
            Console.WriteLine(new string('=', 40));
            Console.ReadKey();
        }

        static void AddProduct()
        {
            Product product = new Product();
            Console.WriteLine("Enter product name: ");
            product.Name = Console.ReadLine();
            Console.WriteLine("Enter price: ");
            product.Price = decimal.Parse(Console.ReadLine());
            productBusiness.Add(product);
            Console.WriteLine("Product added successfully!");
            Thread.Sleep(3000);
        }

        static void RemoveProduct()
        {
            Product product = new Product();
            Console.WriteLine("Enter product ID you want to delete: ");
            int id = int.Parse(Console.ReadLine());
            productBusiness.Delete(id);
            Console.WriteLine("Product deleted successfully!");
            Thread.Sleep(3000);
        }

        static void GetProduct()
        {
            Console.WriteLine(new string('=', 41));
            Console.WriteLine(new string('=', 11) + " Get product by id " + new string('=', 11));
            Console.WriteLine(new string('=', 41));
            Console.WriteLine("Enter Id to find product: ");
            int id = int.Parse(Console.ReadLine());
            Product product = productBusiness.Get(id);
            if (product != null)
            {
                Console.WriteLine(new string('=', 20));
                Console.WriteLine("ID: " + product.Id);
                Console.WriteLine("Name: " + product.Name);
                Console.WriteLine("Price: " + product.Price);
                Console.WriteLine(new string('=', 20));
            }
            Console.ReadKey();
        }

        static void UpdateProduct()
        {
            Console.WriteLine("Enter product ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Product product = productBusiness.Get(id);
            if (product != null)
            {
                Console.WriteLine("Enter name: ");
                product.Name = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                product.Price = decimal.Parse(Console.ReadLine());
                productBusiness.Update(product);
                Console.WriteLine("Product updated successfully!");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
            Thread.Sleep(4000);
        }

    }
}
