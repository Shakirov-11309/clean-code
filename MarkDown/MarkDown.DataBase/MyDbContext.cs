using MarkDown.DataBase.models;
using Microsoft.EntityFrameworkCore;

namespace MarkDown.DataBase
{
    public class MyDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
    }
}
