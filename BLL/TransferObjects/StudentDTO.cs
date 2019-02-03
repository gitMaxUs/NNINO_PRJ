using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.TransferObjects
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string PerentPhoneNumber { get; set; }
        public string Email { get; set; }

        public int? AddressId { get; set; }
        public int? GroupId { get; set; }
       // public GroupDTO Group { get; set; }
    }
}
