using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public  class Lesson
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string LessonName { get; set; }

       // [ForeignKey("Teacher")]
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public ICollection<ConcreteLesson> ConcreteLesson { get; set; }
    }
}
