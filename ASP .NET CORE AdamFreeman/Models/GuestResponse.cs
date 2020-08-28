using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_.NET_CORE_AdamFreeman.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Имя обязательно")]
        [MaxLength(8,ErrorMessage = "Имя не должно превышать 8 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Почта обязательна")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Телефон обязателен")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Укажите будете ли вы участвовать")]
        public bool? WillAttend { get; set; }

    }
}
