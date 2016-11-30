using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Work.Models;

namespace Work.DataAccess
{
    public class DBInitialization : CreateDatabaseIfNotExists<DBContext>
    {
        protected override void Seed(DBContext db)
        {
            db.Events.Add(new Event { Name = "Event" });
            base.Seed(db);
        }
    }
}