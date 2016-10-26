using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetGroupBasedPermissions.Model
{
   public class Appointment
    {

        public int ID { get; set; }
        public int PatientId { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }
        public DateTime? DateAdded { get; set; }
        public string CreatedBy { get; set; }

        public DateTime? Date { get; set; }
        



    }
}
