﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PublicHealthApp.Models
{
    [Table("Vaccine")]
    public class Vaccine
    {
		[Key]
		public string Id { get; set; }
        public string Name { get; set; }
        
    }
}