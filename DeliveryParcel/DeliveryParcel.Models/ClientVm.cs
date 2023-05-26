using System.ComponentModel.DataAnnotations;

namespace DeliveryParcel.Models
{
    /// <summary>
    /// Модель представления клиента.
    /// </summary>
    public class ClientVm
    {
        /// <summary>
        /// Имя. Обязательное поле.
        /// </summary>
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Фамилия. Обязательное поле.
        /// </summary>
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Отчество. Опционально.
        /// </summary>
        [Display(Name = "Отчество")]
        public string? MiddleName { get; set; }
    }
}
