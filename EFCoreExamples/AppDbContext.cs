using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using netConsoleTest.Models;

namespace netConsoleTest.EFCoreExamples
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "netConsole",
                UserID = "sa",
                Password = "Asdffdsa4580"
            };
            optionsBuilder.UseSqlServer(_sqlConnectionStringBuilder.ConnectionString);
        }
            public DbSet<BlogDataModel> Blog {set ; get;}

    }
}