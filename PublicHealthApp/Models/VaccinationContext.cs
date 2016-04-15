using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace PublicHealthApp.Models
{
    public class VaccinationContext : DbContext
    {
        //public VaccinationContext() : base("VaccineDB")
		public VaccinationContext(SQLiteConnection s) : base((DbConnection)s, true)
        { }

        public DbSet<Immunization> Immunization { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Vaccine> Vaccine { get; set; }
		public DbSet<State> State { get; set; }
        public DbSet<Code> Code { get; set; }

    }
}