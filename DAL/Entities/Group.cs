﻿using System.Collections.Generic;

namespace DAL.Entities
{
    public class Group
    {
        public Group()
        {
            Students = new List<Student>();
        } 

        public int Id { get; set; }

        public string GroupName { get; set; }

         
        public virtual ICollection<Student> Students { get; set; }       
    }
}
