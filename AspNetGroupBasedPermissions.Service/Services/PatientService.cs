using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetGroupBasedPermissions.Model;
using AspNetGroupBasedPermissions.Repository.DBContext;

namespace AspNetGroupBasedPermissions.Service.Services
{
   public class PatientService
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        public List<ApplicationUser> GetAllPatiens()
        {
            var patient = new List<ApplicationUser>();
            var users = db.Users.ToList();
            foreach (var user in users)
            {
                foreach (var group in user.Groups)
                {
                    if (group.Group.Name == "Patients")
                    {
                        patient.Add(user);
                    }
                }
            }
            return patient;
        }
    }
}
