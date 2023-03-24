using RestaurantSystem.Data.Model;
using System;
using Moq;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using RestaurantSystem.Display;
using RestaurantSystem.Business;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Data;
using System.Globalization;
using System.Net.Sockets;
using System.Reflection.Metadata;

namespace RestaurantSystem.Tests
{
    public class EmployeeTests
    {
        
        [TestCase]
        public void AddEmployeeInDatabase()
        {
            var data = new List<Employee>
            {
                new Employee("Filip", "Kostov", 29, "kostov@abv.bg", "0873921810", 3, 0, DateTime.ParseExact("20-11-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture))
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Employee>>();
            mockSet.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<RestaurantContext>();
            mockContext.Setup(c => c.Employees).Returns(mockSet.Object);

            var service = new EmployeeBusiness(mockContext.Object);
            data.ToList().ForEach(e => service.Add(e));

        }
    }
}
