using System.Data.Entity.ModelConfiguration;
using Work.Models;

namespace Work.DataAccess.Mapping
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            ToTable("Roles"); // название таблицы в базе
            HasMany(x => x.Users); // один ко многим
            HasKey(x => x.Id); // первичный ключ
        }
    }
}