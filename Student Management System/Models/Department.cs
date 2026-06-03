using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Department Name is required")]
        [Display(Name= "Department Name")]
        public string Name { set; get; }

        public List<Student>? Student { set; get; }
    }
}
