using D10.Data.Entites;
using Microsoft.EntityFrameworkCore;

namespace D10.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) {}

        public virtual DbSet<Student>? Students { get; set; }
    }
}