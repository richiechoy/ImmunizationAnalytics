using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.SQLite;
using System.Data.SQLite.Linq;
using System.Linq;
using System.Reflection;
using System.Web;

namespace PublicHealthApp.Models
{
	public class SQLiteConfiguration : DbConfiguration
	{
		public SQLiteConfiguration()
		{
			SetProviderFactory("System.Data.SQLite", SQLiteFactory.Instance);
			SetProviderFactory("System.Data.SQLite.EF6", SQLiteProviderFactory.Instance);
			//SetProviderServices("System.Data.SQLite", (DbProviderServices)SQLiteProviderFactory.Instance.GetService(typeof(DbProviderServices)));
			//SetDefaultConnectionFactory(new SQLiteFactory()); 

			Type t = Type.GetType("System.Data.SQLite.EF6.SQLiteProviderServices, System.Data.SQLite.EF6");
			FieldInfo fi = t.GetField("Instance", BindingFlags.NonPublic | BindingFlags.Static);
			SetProviderServices("System.Data.SQLite", (DbProviderServices)fi.GetValue(null));



		}
	}
}