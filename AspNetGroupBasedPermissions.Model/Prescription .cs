﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetGroupBasedPermissions.Model
{
    public class Prescription
    {
        //Add Prescription 
        public int Rx { get; set; }
        public string Doctor { get; set; }
        public string Patient { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public string Drug { get; set; }
        public string Details { get; set; }
        public int Refills { get; set; }
        public int NumberOfTablets { get; set; }



    }
}