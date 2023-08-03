using System.ComponentModel.DataAnnotations;

namespace Mel_TPI.Models
{
    public class Lesson
    {
        public int LessonID { get; set; }
        [Display(Name ="Teacher Name")]
        public int TeacherID { get; set; }
        [Display(Name = "Student Name")]
        public int StudentID { get; set; }
        public DateTime Date { get; set; }
        public string Level { get; set; }
        public string Type { get; set; }

        public Teacher Teacher { get; set; }
        public Student Student { get; set; } 
    }
}
