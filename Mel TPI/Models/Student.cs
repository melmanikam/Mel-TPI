using System.ComponentModel.DataAnnotations;

namespace Mel_TPI.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        [Display(Name = "First Name")]       // this code here is used for specifying how a property should be displayed in the front end of the website 
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
       
        public ICollection<Lesson> Lessons { get; set; }
    }
}

