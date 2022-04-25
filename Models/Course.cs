using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC4.Models
{
    public class Course
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        //constructor
        public Course()
        {
            Departments = new HashSet<Department>();
            StudentCourses=new HashSet<StudentCourse>();
        }

        //relations(Navigation properties)

        //many to many without attributes
        public virtual ICollection<Department> Departments { get; set; } 

        //many to many with attributes "new table created with both keys
        //of student and course"
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
        
        
    }
}
