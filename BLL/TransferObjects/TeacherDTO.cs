﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BL.TransferObjects
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public LessonDTO Lesson { get; set; }
    }
}
