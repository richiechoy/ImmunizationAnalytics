using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Web;

namespace PublicHealthApp.Models
{
    public class DataModel
    {
		public static string DBpath = "Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "App_Data\\vaccineDB.sqlite" + "; Version=3";
        private static SQLiteConnection conn = new SQLiteConnection(DBpath);
        private static VaccinationContext db = new VaccinationContext(conn);
        private static SQLiteTransaction transaction;

        public static void beginTransaction()
        {
            db.Configuration.AutoDetectChangesEnabled = false;
            conn.Open();
            transaction = conn.BeginTransaction();
        }

        public static void commitTransaction()
        {
            db.Configuration.AutoDetectChangesEnabled = true;
            transaction.Commit();
            db.SaveChanges();
            conn.Close();
        }

        public static bool AddItem<T>(T entityToCreate) where T : class
        {
            db.Set<T>().Add(entityToCreate);
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                ((IObjectContextAdapter)db).ObjectContext.Refresh(RefreshMode.ClientWins, db.Vaccine);
                db.SaveChanges();
            }
            return false;
        }

        public static Object GetItem<T>(T entity, object key) where T : class
        {
            return db.Set<T>().Find(key);
        }
        
		public static void PrintAllImmunizations()
        {
			//using (var db = new VaccinationContext(new SQLiteConnection("Data Source=D:\\Users\\220038684\\Source\\Repos\\CS6440Project-DEV\\PublicHealthApp\\App_Data\\vaccineDB.sqlite; Version=3")))
            
                try
                {
                    var query = from b in db.Immunization
                                orderby b.rowid
                                select b;
                    Console.WriteLine("All Immunizations in the database:");
                    foreach (var item in query)
                    {
                        Console.WriteLine(item.ToString());
                    }

                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            

        }

		public static void CheckDBTables()
        {
			
                var q = db.Database.ExecuteSqlCommand("SELECT name FROM sqlite_master WHERE type='table'");
            
        }

		public static void CustomSQLCommand(string commandString)
		{
			
				var q = db.Database.ExecuteSqlCommand(commandString);
			
		}
        public static List<Vaccine> GetUniqueVaccines()
        {


            List<Vaccine> resultList = (from b in db.Vaccine
                                        orderby b.Name
                                        select (new { Id = b.Id, Name = b.Name })).
                         ToList().Select(b => new Vaccine { Id = b.Id, Name = b.Name }).ToList();

                return resultList;

            
        }

        public static List<State> GetUniqueStates()
        {

            
                List<State> resultList = (from b in db.State
                                          where b.AlphaCode != null
                                          orderby b.Name
                                          select (new { FipsCode = b.FipsCode, AlphaCode = b.AlphaCode, Name = b.Name }))
                                        .ToList()
                                .Select(b => new State { FipsCode = b.FipsCode, AlphaCode = b.AlphaCode, Name = b.Name })
                                .ToList();



                return resultList;

            
        }

        public static List<int> GetUniqueYears()
        {
            List<int> years = new List<int>();
            years.Add(2010);
            years.Add(2011);
            years.Add(2012);
            years.Add(2013);
            years.Add(2014);
            return years;

        }

        public static List<Code> GetUniqueCodeList(string codeType)
        {
            List<Code> codeList = (from c in db.Code
                                  where c.Type == codeType.ToUpper()
                                  orderby c.Name
                                   select (new { Type = c.Type, Value = c.Value, Name = c.Name }))
                                        .ToList()
                                .Select(b => new Code { Type = b.Type, Value = b.Value, Name = b.Name })
                                .ToList();


            return codeList;

        }


        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public static DataTable GetQueryResults(QueryFilter filter, String axis1 = "Year", string axis2 = "Vaccine")
        {
            
                //List<VaccineQueryResultSet> 
                var resultList = (from b in db.Immunization
                                  join p in db.Patient on b.PatientId equals p.Id
                                  where (b.VaccineId == filter.VaccineType || filter.VaccineType == "")
                                        && (p.State == filter.State || filter.State == "")
                                        && (p.Year == filter.Year || filter.Year == 0)
                                        && (p.Age == filter.Age || filter.Age == "")
                                          && (p.Race == filter.Race || filter.Race == "")
                                          && (p.Poverty == filter.PovertyStatus || filter.PovertyStatus == "")
                                          && (p.MotherMaritalStatus == filter.MaritalStatus || filter.MaritalStatus == "")
                                          && (p.Gender == filter.Gender || filter.Gender == "")
                                  group new { p } by new {  p.Year }
                                          into grp
                                  select new
                                  {
                                      filter.VaccineType,
                                      grp.Key.Year,
                                      ImmunizationCount = grp.Count()
                                  })
                             .ToList()
                                .Select(b => new VaccineQueryResultSet { VaccineId = b.VaccineType, Year = b.Year, ImmunizationCount = b.ImmunizationCount })
                                .ToList()
                                ;

                DataTable resultDt = ToDataTable(resultList);
                return resultDt;

            

        }

    }

    public class QueryFilter
    {
        public string Gender { get; set; }
        public string PovertyStatus { get; set; }
        public string MaritalStatus { get; set; }
        public string Race { get; set; }
        public string State { get; set; }
        public string Age { get; set; }
        public string VaccineType { get; set; }
        public int Year { get; set; }

        public QueryFilter()
        {
            Gender = "";
            PovertyStatus = "";
            MaritalStatus = "";
            Race = "";
            State = "";
            Age = "";
            VaccineType = "";
            Year = 0;
        }
    }



    public class VaccineQueryResultSet
    {
        public string VaccineId { get; set; }
        public int Year { get; set; }
        public int ImmunizationCount { get; set; }
    }
}