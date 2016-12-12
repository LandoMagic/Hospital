using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalModel
{
   public class Death
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string NameOfChild { get; set; }
        public DateTime DateOfDeath { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Gender { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public string ImageUrl { get; set; }

    }
}
