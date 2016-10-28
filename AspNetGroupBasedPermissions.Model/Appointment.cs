using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetGroupBasedPermissions.Model
{
   public class Appointment
    {

        public int Id { get; set; }
        
        public string Reason { get; set; }
        public string Description { get; set; }
        public DateTime? DateAdded { get; set; }
        public string CreatedBy { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser Patient { get; set; }
        public DateTime? Date { get; set; }
        



    }
}
