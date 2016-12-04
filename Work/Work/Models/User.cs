using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Work.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string AboutMe { get; set; }
        public bool IsSportsman { get; set; }
        public List<EventUser> Events { get; set; }

        public string Login { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}