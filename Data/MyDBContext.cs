using MVC4.Models;
using Microsoft.EntityFrameworkCore;
namespace MVC4.Data
{
    public class MyDBContext:DbContext
    {
        //tables
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }

        //constructor
        public MyDBContext(DbContextOptions opt) : base(opt)
        {

        }

        //override onModelCreating() to set composite PK 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>().HasKey(o => new {o.Std_id,o.Crs_id});
            base.OnModelCreating(modelBuilder);
        }

        //override onModelCreating() to set composite PK 
        public DbSet<MVC4.Models.StudentCourse> StudentCourse { get; set; }
    }
}
