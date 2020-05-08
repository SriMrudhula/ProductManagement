using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using ProductManagementDBEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TST_ProductManagement
{
     public class Sqlite
    {
        public ProductDBContext CreateSqliteConnection()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var option = new DbContextOptionsBuilder<ProductDBContext>().UseSqlite(connection).Options;
            var context = new ProductDBContext(option);
            if (context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
            return context;
        }
    }
}
