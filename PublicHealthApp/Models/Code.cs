using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PublicHealthApp.Models
{
    [Table("Code")]
    public class Code
    {
		[Key,  Column(Order = 0)]
		public string Type { get; set; }
        [Key, Column(Order = 1)]
        public string Value { get; set; }
        public string Name { get; set; }

    }
}