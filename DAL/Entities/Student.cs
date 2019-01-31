using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    //every time when change Entityes - add migration
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        [Required]
        [MaxLength(12)]
        public string Surname { get; set; }

      //  [Required]
        public string BirthDate { get; set; }

        //[Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [MaxLength(15)]
        public string PerentPhoneNumber { get; set; }


        // [Required]
        [MaxLength(60)]
        public string Adress { get; set; }
        

        public int? GroupId { get; set; } 
        public Group Group { get; set; }

        //public int PresetStudentId { get; set; }
        //public PresetStudent isPresentAtLesson { get; set; }
    }
}
