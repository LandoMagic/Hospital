using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetGroupBasedPermissions.Model
{
    class InPatient
    {
        public string PatientName { set; get; }
        public string PatientNumber { }
        public string Phone { set; get; }
        public string Status { set; get; }
        public string BloodGroup { set; get; }

    }
}
