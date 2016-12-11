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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата рождения")]
        public DateTime Birthday { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string AboutMe { get; set; }
        public bool IsSportsman { get; set; }
        public List<EventUser> Events { get; set; }
        [Required]
        public string Login { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        // Роль пользователя
        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}