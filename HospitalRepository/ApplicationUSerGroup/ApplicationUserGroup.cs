﻿using System.ComponentModel.DataAnnotations;
using AspNetGroupBasedPermissions.Repository.DBContext;

namespace AspNetGroupBasedPermissions.Repository
{
    public class ApplicationUserGroup
    {
        [Required]
        public virtual string UserId { get; set; }
        [Required]
        public virtual int GroupId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Group Group { get; set; }
    }
}