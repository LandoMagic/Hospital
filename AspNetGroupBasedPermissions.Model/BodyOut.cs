﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AspNetGroupBasedPermissions.Model
{
    public class BodyOut
    {
        [Key]
        public int Id { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
      


    }
}