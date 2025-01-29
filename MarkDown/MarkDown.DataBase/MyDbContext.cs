using MarkDown.DataBase.models;
using Microsoft.EntityFrameworkCore;

namespace MarkDown.DataBase
{
    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> dbContextOptions) : base(dbContextOptions) 
        {
        }

        public DbSet<Users> Users { get; set; }

        public DbSet<Documents> Documents { get; set; }
    }
}
