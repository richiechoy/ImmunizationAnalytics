using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PublicHealthApp.Models
{
    [Table("Patient")]
    public class Patient
    {
		[Key]
		public string Id { get; set; }
        public string Age { get; set; }
        public string State { get; set; }
        public int Year { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public string Poverty { get; set; }
        public string MotherMaritalStatus { get; set; }

    }
}