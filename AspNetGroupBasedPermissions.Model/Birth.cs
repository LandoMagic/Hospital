using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalModel
{
    public class ChildBirth
    {
        [Key]
        public int Id { get; set; }
        public string NameOfChild { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Gender { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public string ImageUrl { get; set; }



    }
}
