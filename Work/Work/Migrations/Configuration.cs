using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Work.Models;

namespace Work.Migrations
{
   

    internal sealed class Configuration : DbMigrationsConfiguration<Work.DataAccess.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Work.DataAccess.DBContext";
        }

        protected override void Seed(Work.DataAccess.DBContext context)
        {
            if (context.Roles.FirstOrDefault(x => x.Name == "admin") == null)
            {
                context.Roles.AddOrUpdate(x => x.Id,
                new Role { Id = 1, Name = "admin" },
                new Role { Id = 2, Name = "user" }
                );
            }
            if (context.Users.FirstOrDefault(x => x.Login == "admin") == null)
            {
                context.Users.AddOrUpdate(x => x.Id,
                   new Models.User { Id = 1, Login = "admin", Password = "123456", Birthday = new DateTime(1990, 11, 20), RoleId = 1 }
                   );
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
