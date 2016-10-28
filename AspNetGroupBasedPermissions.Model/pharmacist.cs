using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetGroupBasedPermissions.Model
{
    public class Pharmacist
    {
        //The difference Pharmacist
        public string DoctorName { get; set; }
        public string Department { get; set; }
        public string Degree { get; set; }
        public string DoctorEmail { get; set; }

    }
}
