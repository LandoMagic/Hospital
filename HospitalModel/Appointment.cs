using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalModel
{
   public class Appointment
    {

        public int Id { get; set; }
        
        public string Reason { get; set; }
        public string Description { get; set; }

        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        public string ApplicationUserId { get; set; }       
        public DateTime? Date { get; set; }
        



    }
}
