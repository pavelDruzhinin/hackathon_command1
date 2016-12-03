using System.Data.Entity.ModelConfiguration;
using Work.Models;

namespace Work.DataAccess.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("Users"); // название таблицы в базе
            HasMany(x => x.Events); // один ко многим
            HasKey(x => x.Id); // первичный ключ
        }
    }
}