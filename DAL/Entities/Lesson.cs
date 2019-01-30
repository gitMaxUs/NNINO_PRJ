using System.Collections.Generic;

namespace DAL.Entities
{
    public  class Lesson
    {
        public int Id { get; set; }
        public string LessonName { get; set; }
        //  public string ThemeOfLesson { get; set; }

       // public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public ICollection<ConcreteLesson> ConcreteLesson { get; set; }
    }
}
