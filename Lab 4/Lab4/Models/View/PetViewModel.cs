using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab4.Models.View
{
    public class PetViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Pet's Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Pet's Age")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Next Checkup")]
        public DateTime NextCheckup { get; set; }

        [Required]
        [Display(Name = "Vet Name")]
        public string VetName { get; set; }

        public int UserId { get; set; }
    }
}