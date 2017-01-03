using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalModel
{
    public class Immunization
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Create By")]
        public string CreateBy { get; set; }

        [Display(Name = "Date Modified")]
        public DateTime DateModified { get; set; }
        public string Detail { get; set; }
        public string ImageUrl { get; set; }

    }
}
