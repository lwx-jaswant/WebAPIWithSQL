using Microsoft.EntityFrameworkCore;
using WebAPIWithSQL.Models;

namespace WebAPIWithSQL.DataBase_Classes
{
    public class TestAPIContext : DbContext
    {
        public TestAPIContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<tblUsers> Users { get; set; }
        public DbSet<tblEmployee> Employees { get; set; }
    }
}

