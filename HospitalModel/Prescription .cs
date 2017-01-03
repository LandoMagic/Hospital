﻿using System;

namespace HospitalModel
{
    public class Prescription
    {
        //Add Prescription 
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string PatientId { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public string Drug { get; set; }
        public string Details { get; set; }
        public int Refills { get; set; }
        public int NumberOfTablets { get; set; }



    }
}
