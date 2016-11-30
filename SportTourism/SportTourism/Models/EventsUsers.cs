using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportTourism.Models
{
    public class EventsUsers
    {
        // связь один ко многим
        public Users User { get; set; }
        public Events Event { get; set; }

        // поля для хранения Id (будут использованы как составной ключ)
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}