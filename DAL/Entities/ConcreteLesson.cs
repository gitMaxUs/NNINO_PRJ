using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ConcreteLesson
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }


        public int? LessonId { get; set; }
        public Lesson Lesson { get; set; }

        public int? teacherId { get; set; }
        public Teacher teacher { get; set; }
    }
}
