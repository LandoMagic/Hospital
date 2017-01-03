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
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
        public string Phone { set; get; }

        [Display(Name = "Blood Group")]
        public string BloodGroup { set; get; }
        public string Addresss { get; set; }

        [Display(Name = "Date Addded")]
        public DateTime? DateAddded { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }
        public virtual ICollection<ApplicationUserGroup> Groups { get; set; }

    }
}
