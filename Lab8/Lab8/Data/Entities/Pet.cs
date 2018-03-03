﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab8.Models;
using System.ComponentModel.DataAnnotations;

namespace Lab8.Data.Entities
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public DateTime NextCheckup { get; set; }
        [Required]
        public string VetName { get; set; }
        [Required]
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}