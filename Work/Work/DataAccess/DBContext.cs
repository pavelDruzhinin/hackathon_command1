using System.Data.Entity;
using Work.DataAccess.Mapping;
using Work.Models;

namespace Work.DataAccess
{
    public class DBContext : DbContext
    {
        public DBContext() : base("Connect") { }
       
                public DbSet<Event> Events { get; set; }
                public DbSet<EventUser> EventsUsers { get; set; }
                public DbSet<User> Users { get; set; }
                
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EventMap());
            modelBuilder.Configurations.Add(new EventUserMap());
            modelBuilder.Configurations.Add(new UserMap());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}