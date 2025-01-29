using CRUD_SQL_SERVER.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_SQL_SERVER.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {

        }
        // inisialisasi tabel db
        public DbSet<Employee> Employees { get; set; }
          
    }
}
