using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC4.Models
{
    public class Department
    {
        //properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]//don't set auto id 
        public int Id { get; set; }
        [Required,StringLength(10,MinimumLength =3)]
        public string Name { get; set; }



        //relations(Navigation properties)
        public virtual ICollection<Student> students { get; set; }
        public virtual ICollection<Course> courses { get; set; }



        //constructor
        public Department()
        {
            //new containers are set with every object from dept so can add 
            //both students and courses in this new dept
            courses = new HashSet<Course>();
            students = new HashSet<Student>();//hashset support uniquness &
                                              //faster than list in iteration
                                              //more efficient in dealing with objects
        }
    }
}
