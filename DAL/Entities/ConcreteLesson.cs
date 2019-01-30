using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ConcreteLesson
    {
        public int Id { get; set; }
        public string Them { get; set; }

        public int? LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
