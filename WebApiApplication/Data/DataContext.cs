
using Microsoft.EntityFrameworkCore;
using WebApiApplication.Models;


namespace WebApiApplication.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions options) :base(options)
        {
            
        }

        public void nthing() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Department>(entity => entity.HasKey(e => e.DepartmentId).HasName("DepartmentId"));
            modelBuilder.HasDefaultSchema("Departments").Entity<Department>().HasKey(d => d.DepartmentId);
        }

        public DbSet<Department> Departments { get; set; }

       
    }
}
