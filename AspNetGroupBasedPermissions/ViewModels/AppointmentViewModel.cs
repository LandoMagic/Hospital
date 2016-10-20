using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetGroupBasedPermissions.ViewModels
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }     
        public string Reason { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public virtual PatientViewModel PatientViewmodel { get; set; }
    }
}