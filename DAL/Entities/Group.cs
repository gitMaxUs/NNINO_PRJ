using System.Collections.Generic;

namespace DAL.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
         
        public  ICollection<Student> Students { get; set; }
        public Group()
        {
            Students = new List<Student>();
        }
    }
}
