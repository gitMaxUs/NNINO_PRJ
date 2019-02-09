using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    class HeadStudent
    {
        [Key]
        [ForeignKey("Lesson")]
        public int Id { get; set; }

        public string Position { get { return "Староста"; } }

        [MaxLength(10)]
        public string Name { get; set; }

        [MaxLength(12)]
        public string Surname { get; set; }

        public string Email { get; set; }
               
    }

}
