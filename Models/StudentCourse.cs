using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC4.Models
{
    //student "who" joins course "what"
    public class StudentCourse
    {
        //properties
        [ForeignKey("Student")]
        public int Std_id { get; set; }  //composite PK is set by overriding 
                                         //onModelCreating() in DBContext
        [ForeignKey("Course")]
        public int Crs_id { get; set; }
        public char grade { get; set; }


        //relations(Navigation properties)
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }

    }
}
