using System.Collections.Generic;

namespace WEB.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
         

        public string Name { get; set; }
        public string Surname { get; set; }
       // public string BirthDate { get; set; }
       // public string PhoneNumber { get; set; }
       // public string PerentPhoneNumber { get; set; } 
        public string Email { get; set; }
        public bool IsPresent { get; set; }

        public IEnumerable<PresetStudentVIewModel> PresentStudents { get; set; }

        public GroupViewModel Group { get; set; }
    }
}