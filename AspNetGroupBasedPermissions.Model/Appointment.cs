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
        public string Patient { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }
        public DateTime Appointment_Date { get; set; }
        



    }
}
