using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public  class Teacher
    {
        [Key]
        [ForeignKey("Lesson")]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

       // public int? LessonId { get; set; }
        public Lesson Lesson { get; set; }
         
    }
}
