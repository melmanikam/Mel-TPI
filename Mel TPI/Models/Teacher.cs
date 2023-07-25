﻿namespace Mel_TPI.Models
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
    }
}
