using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Введите имя")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина не менее 4 символов")]
        public string name { get; set; }

        [Display(Name = "Введите фамилию")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина не менее 4 символов")]
        public string surname { get; set; }

        [Display(Name = "Введите адрес")]
        [StringLength(35)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длина не менее 4 символов")]
        public string adress { get; set; }

        [Display(Name = "Введите номер телефона")]
        [StringLength(20)]
        [Required(ErrorMessage = "Длина не менее 10 символов")]
        public string phone { get; set; }

        [Display(Name = "Введите email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина не менее 15 символов")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }

        public List<OrderDetail> orderDetails { get; set; }

    }
}
