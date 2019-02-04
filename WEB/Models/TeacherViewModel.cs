using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class TeacherViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public string Position { get; set; }

        //  public int? LessonId { get; set; }

        //public int AddressId { get; set; }
    }
}