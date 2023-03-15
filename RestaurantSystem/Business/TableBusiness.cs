using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantSystem.Data;
using RestaurantSystem.Data.Model;

namespace RestaurantSystem.Business
{
    class TableBusiness
    {
        private RestaurantContext tableContext;

        public List<Table> GetAll()
        {
            using (tableContext = new RestaurantContext())
            {
                return tableContext.Tables.ToList();
            }
        }

        public Table Get(int id)
        {
            using (tableContext = new RestaurantContext())
            {
                return tableContext.Tables.Find(id);
            }
        }

        public void Add(Table table)
        {
            using (tableContext = new RestaurantContext())
            {
                tableContext.Tables.Add(table);
                tableContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (tableContext = new RestaurantContext())
            {
                var table = tableContext.Tables.Find(id);
                if (table != null)
                {
                    tableContext.Tables.Remove(table);
                    tableContext.SaveChanges();
                }
            }
        }

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
