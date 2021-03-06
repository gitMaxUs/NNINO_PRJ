﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public  class Lesson
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string LessonName { get; set; }


        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public virtual ICollection<ConcreteLesson> ConcreteLesson { get; set; }
    }
}
