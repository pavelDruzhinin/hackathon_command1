using System.Data.Entity.ModelConfiguration;
using Work.Models;
using System;

namespace Work.DataAccess.Mapping
{
    public class EventUserMap : EntityTypeConfiguration<EventUser>
    {
        public EventUserMap()
        {
            ToTable("EventsUsers"); // название таблицы в базе
            HasRequired(x => x.Event); // один к одному
            HasRequired(x => x.User); // один к одному
            HasKey(x => new {x.EventId, x.UserId}); // соcтавной ключ
        }
    }
}