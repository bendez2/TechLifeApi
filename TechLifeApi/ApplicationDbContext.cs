using Microsoft.EntityFrameworkCore;
using TechLifeApi.Models;

namespace TechLifeApi
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Initiator> Initiator { get; set; }
        public DbSet<Priority> Priority { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<TypeRequest> TypeRequest { get; set; }

        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySQL("Server=178.46.167.209;Port=7079;database=TestForJob;User Id=admin;Password=Shader;charset=utf8");

        }
    }
}
