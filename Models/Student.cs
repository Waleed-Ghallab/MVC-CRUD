using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC4.Models
{
    public class Student
    {
        //properties
        public int Id { get; set; }
        public string Name { get; set; }    
        public int age { get; set; }
        [ForeignKey("dept")]
        public int deptID { get; set; }



        //relations(Navigation properties)
        public virtual Department dept { get; set; } //one to many with department
        public virtual ICollection<StudentCourse> StudentCourses { get; set; } // many to one with studentcourse


        //constructor
        public Student()
        {
            StudentCourses = new HashSet<StudentCourse>();
        }

    }
}
