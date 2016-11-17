﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetGroupBasedPermissions.Model
{
    public class ChildBirth
    {
        [Key]
        public int Id { get; set; }
        public string NameOfChild { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Gender { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }




    }
}