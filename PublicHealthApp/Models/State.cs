using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PublicHealthApp.Models
{
    [Table("State")]
    public class State
    {
		[Key]
        public string FipsCode { get; set; }
        public string AlphaCode { get; set; }
        public string Name { get; set; }
    }
}