using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WpfApplication1.Model;
using WpfApplication1.ViewModel.Utils;

namespace WpfApplication1
{
    public class AppDB : DbContext
    {
        public AppDB():base("TestDBContext")
        {
            Database.SetInitializer<AppDB>(new MigrateDatabaseToLatestVersion<AppDB,Configuration>());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        public List<string> Cities()
        {
           var cities= (from hs  in Hotels               
             select hs.city).Distinct().ToList();
            cities.Insert(0, "All");
            return cities;
        }

        public List<string> Cities(string cityname)
        {
          return  Cities().Where(s => s.Contains(cityname, StringComparison.OrdinalIgnoreCase)).ToList();            
        }
    }

    internal sealed class Configuration : DbMigrationsConfiguration<AppDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;//automaticall create db objects
            AutomaticMigrationDataLossAllowed = true;
        }

        /*protected override void Seed(AppDB context)
        {
            context.Users.AddOrUpdate(i => i.id,
                new User
                {
                    id = 1,
                    username = "test user",
                    password = "pin1",
                    Email = "test@email.com",
                    Phone = "12345678",
                    userrole = "",
                    enabled = 1
                }
           );

        }*/

    }


}
