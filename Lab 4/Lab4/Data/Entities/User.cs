using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Lab4.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        [Display(Name = "DOB")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Display(Name = "Years in School")]
        public int YearsInSchool { get; set; }
        public ICollection<Pet> Pets { get; set; }
    }
}