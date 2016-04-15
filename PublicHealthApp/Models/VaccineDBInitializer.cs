using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PublicHealthApp.Models
{
    public class VaccineDBInitializer : DropCreateDatabaseAlways<VaccinationContext>
    {
        protected override void Seed(VaccinationContext context)
        {
            GetVaccinations().ForEach(c => context.Vaccinations.Add(c));
        }

        private static List<Vaccination> GetVaccinations()
        {
            var vaccinations = new List<Vaccination> {
                new Vaccination
                {
                    name = "v1", 
                    date = "10/26/2015",
                },
                new Vaccination
                {
                    name = "v2", 
                    date = "10/26/2015",
                },
            };

            return vaccinations;
        }

    }
}