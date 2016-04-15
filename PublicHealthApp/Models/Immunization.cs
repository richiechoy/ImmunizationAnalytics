using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PublicHealthApp.Models
{
    [Table("Immunization")]
    public class Immunization
    {
		[Key]
        public long rowid { get; set; }
        public string PatientId { get; set; }
        public string VaccineId { get; set; }
    }
}