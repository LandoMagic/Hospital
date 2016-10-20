using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetGroupBasedPermissions.Model
{
   public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }       
        public string PatientNumber { set; get; }
        public string Phone { set; get; }       
        public string BloodGroup { set; get; }
        public string Addresss { get; set; }
        public DateTime? DateAddded { get; set; }
        public string ModifiedBy { get; set; }


    }
}
