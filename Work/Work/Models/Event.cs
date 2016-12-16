using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Work.Models
{
    public class Event
    {
        public int Id { get; set; }
       [Display(Name = "Название")]
        public string Name { get; set; }
       [Display(Name = "Категория")]
        public string Category { get; set; } //Категория сложности. можно просто выпадающий список в представлении (там 6 категорий всего)
        public List<EventUser> EventUsers { get; set; }
       [Display(Name = "Старт")]
        public DateTime? DateStart { get; set; }
       [Display(Name = "Финиш")]
        public DateTime? DateFinish { get; set; }
       [Display(Name = "Место")]
        public string Location { get; set; } //место проведения
       [Display(Name = "Участников")]
        public int? CountUsers { get; set; }
    }
}