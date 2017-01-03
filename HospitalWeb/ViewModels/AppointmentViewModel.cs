using System;
using HospitalModel;

namespace HospitalWeb.ViewModels
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }     
        public string Reason { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }      
        public string PatientViewmodelId { get; set; }

        public virtual ApplicationUser Patient { get; set; }
    }
}