using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KGTest.Models
{
    public class Order
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле номер заказа обязательно для заполнения")]
        public string Number { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public DateTime? UnloadDate { get; set; }

        [Required(ErrorMessage = "Поле менеджер заказа обязательно для заполнения")]
        public string Manager { get; set; }

        public string Comment { get; set; }
    }
}