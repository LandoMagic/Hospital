﻿namespace HospitalWeb.ViewModels
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatientNumber { set; get; }
        public string Phone { set; get; }
        public string BloodGroup { set; get; }
        public string Addresss { get; set; }
    }
}