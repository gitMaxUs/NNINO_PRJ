using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public  class Teacher
    {
        [Key]
        [ForeignKey("Lesson")]
        public int Id { get; set; }

        [MaxLength(10)]
        public string Name { get; set; }

        [MaxLength(12)]
        public string Surname { get; set; }

        public string Email { get; set; }

        public int? LessonId { get; set; }
        public Lesson Lesson { get; set; }          
    }
}
