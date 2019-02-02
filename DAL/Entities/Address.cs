﻿using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }
    }
}
