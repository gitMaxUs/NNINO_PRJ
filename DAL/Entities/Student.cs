using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    //every time when change Entityes - add migration
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
      //  [Required]
        public string BirthDate { get; set; }
        //[Required]
        public string PhoneNumber { get; set; }
        public string PerentPhoneNumber { get; set; }
       // [Required]
        public string Adress { get; set; }


        public int? GroupId { get; set; } 
        public Group Group { get; set; }

        //public int PresetStudentId { get; set; }
        //public PresetStudent isPresentAtLesson { get; set; }
    }
}
