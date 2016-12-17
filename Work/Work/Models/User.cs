using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Work.Models
{

    public class User
    {

        public int Id { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Display(Name = "Пол")]
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата рождения")]
        public DateTime? Birthday { get; set; }
        [Display(Name = "Телефон")]
        public string Telephone { get; set; }
        [Display(Name = "Почта")]
        public string Email { get; set; }
        [Display(Name = "О себе")]
        public string AboutMe { get; set; }
        [Display(Name = "Спортсмен")]
        public bool IsSportsman { get; set; }
        public List<EventUser> Events { get; set; }
        [Required]
        [Display(Name = "Логин")]
        public string Login { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        // Роль пользователя
        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}