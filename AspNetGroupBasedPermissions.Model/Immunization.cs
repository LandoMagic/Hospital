using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetGroupBasedPermissions.Model
{
    public class Immunization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateBy { get; set; }
        public DateTime DateModified { get; set; }
        public string Detail { get; set; }

    }
}
