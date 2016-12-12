using System;

namespace HospitalModel
{
    public class Immunization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreateBy { get; set; }
        public DateTime DateModified { get; set; }
        public string Detail { get; set; }
        public string ImageUrl { get; set; }

    }
}
