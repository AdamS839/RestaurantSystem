using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantSystemASPNET.Data;
using RestaurantSystemASPNET.Data.Model;

namespace RestaurantSystemASPNET.Business
{
    public class TableBusiness
    {
        private RestaurantContext tableContext;

        /// <summary>
        /// Returns a list of all tables
        /// </summary>
        /// <returns></returns>
        public List<Table> GetAll()
        {
            using (tableContext = new RestaurantContext())
            {
                return tableContext.Tables.ToList();
            }
        }

        /// <summary>
        /// Finds the table with the specified id and returns it
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Table Get(int id)
        {
            using (tableContext = new RestaurantContext())
            {
                return tableContext.Tables.Find(id);
            }
        }

        /// <summary>
        /// Adds a table
        /// </summary>
        /// <param name="table"></param>
        public void Add(Table table)
        {
            using (tableContext = new RestaurantContext())
            {
                tableContext.Tables.Add(table);
                tableContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the table with specified id if the job exists, if not - no action is taken
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (tableContext = new RestaurantContext())
            {
                var table = tableContext.Tables.Find(id);
                if (table != null)
                {
                    tableContext.Tables.Remove(table);
                    tableContext.SaveChanges();
                    Console.WriteLine("Table deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Table not found!");
                }
            }
        }

        /// <summary>
        /// Retrieves existing table by searching the id, updates the properties and finally save the changes to the database
        /// </summary>
        /// <param name="table"></param>
        public void Update(Table table)
        {
            using (tableContext = new RestaurantContext())
            {
                var item = tableContext.Tables.Find(table.Id);
                if (item != null)
                {
                    tableContext.Entry(item).CurrentValues.SetValues(table);
                    tableContext.SaveChanges();
                }
            }
        }
    }
}
