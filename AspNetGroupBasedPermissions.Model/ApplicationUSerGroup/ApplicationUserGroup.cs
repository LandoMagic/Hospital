using System.ComponentModel.DataAnnotations;

namespace AspNetGroupBasedPermissions.Model.ApplicationUSerGroup
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