using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetGroupBasedPermissions.Model
{
   public class BloodBank
    {
        public int ID { get; set; }

        //To add and view blood to the blood bank
        public string BloodGroup { get; set; }
        public int NoOfBags { get; set; }

        //blood Donor List...Action to edit and delete
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public DateTime LastDonationDate { get; set; }
    }
}
