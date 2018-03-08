using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab8.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab8.Data.Entities
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime NextCheckup { get; set; }

        public string VetName { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}