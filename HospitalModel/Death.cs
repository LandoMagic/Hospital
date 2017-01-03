
using System.ComponentModel.DataAnnotations;

namespace HospitalModel
{
    
    public  class Death
    {
        public int Id { get; set; }
        public string NameOfChild { get; set; }

        [Display(Name = "Date")]
        public System.DateTime DateOfDeath { get; set; }

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
