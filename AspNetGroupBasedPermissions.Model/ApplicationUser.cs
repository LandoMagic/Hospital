using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HospitalModel.ApplicationUSerGroup;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HospitalModel
{
   
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
            : base()
        {
            this.Groups = new HashSet<ApplicationUserGroup>();
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
        public string Phone { set; get; }

        public string BloodGroup { set; get; }
        public string Addresss { get; set; }
        public DateTime? DateAddded { get; set; }
        public string ModifiedBy { get; set; }
        public virtual ICollection<ApplicationUserGroup> Groups { get; set; }

    }
}
