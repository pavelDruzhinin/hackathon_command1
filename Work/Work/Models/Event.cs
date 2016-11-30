using System.Collections.Generic;

namespace Work.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int CountUsers { get; set; }
        public List<EventUser> Users { get; set; }
    }
}