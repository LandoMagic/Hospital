using System;

namespace HospitalModel
{
   public class Appointment
    {

        public int Id { get; set; }
        
        public string Reason { get; set; }
        public string Description { get; set; }
        public DateTime? DateAdded { get; set; }
        public string CreatedBy { get; set; }
        public string ApplicationUserId { get; set; }       
        public DateTime? Date { get; set; }
        



    }
}
