
using System.ComponentModel.DataAnnotations;

namespace HospitalModel
{
    
    
    public  class BodyOut
    {
        public int Id { get; set; }

        [Display(Name = "Mother Name")]
        public string MotherName { get; set; }

        [Display(Name = "Father Name")]
        public string FatherName { get; set; }

        [Display(Name = "Place of Birth")]
        public string PlaceOfBirth { get; set; }

        public string Gender { get; set; }
        public string ImageUrl { get; set; }
    }
}
