using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetGroupBasedPermissions.Model
{
   public class Patient : ApplicationUser
    {
        public int Id { get; set; }
      

        //todo allow patient to extend from application user class create a froreign key for application user ID

    }
}
