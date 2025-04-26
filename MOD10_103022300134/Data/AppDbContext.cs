using Microsoft.EntityFrameworkCore;
using MOD10_103022300134.Models;

namespace MOD10_103022300134.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Mahasiswa> Mahasiswas { get; set; }
    }
}
