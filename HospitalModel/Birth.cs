using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalModel
{
    public class ChildBirth
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string NameOfChild { get; set; }
        [Display(Name = "Date")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Place of Birth")]
        public string PlaceOfBirth { get; set; }
        public string Gender { get; set; }
        [Display(Name = "Mother Name")]
        public string MotherName { get; set; }
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }
        public string ImageUrl { get; set; }



    }
}
