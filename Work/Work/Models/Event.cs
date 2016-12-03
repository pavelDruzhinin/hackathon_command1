using System;
using System.Collections.Generic;

namespace Work.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; } //Категория сложности. можно просто выпадающий список в представлении (там 6 категорий всего)
        public List<EventUser> Users { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
        public string Location { get; set; } //место проведения
        public int CountUsers { get; set; }
    }
}