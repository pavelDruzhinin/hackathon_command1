using System.Data.Entity.ModelConfiguration;
using Work.Models;

namespace Work.DataAccess.Mapping
{
    public class EventMap : EntityTypeConfiguration<Event>
    {
        public EventMap()
        {
            ToTable("Events"); // название таблицы в базе
            HasMany(x => x.EventUsers); // один ко многим
            HasKey(x => x.Id); // первичный ключ
        }
    }
}