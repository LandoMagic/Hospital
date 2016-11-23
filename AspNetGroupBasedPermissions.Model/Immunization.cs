using System;

namespace HospitalModel
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
