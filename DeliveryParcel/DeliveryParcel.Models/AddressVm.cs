using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DeliveryParcel.Models
{
    /// <summary>
    /// Модель представления адреса.
    /// </summary>
    public class AddressVm
    {
        /// <summary>
        /// Наименование города. Обязательное поле.
        /// </summary>
        [Required(ErrorMessage = "Обязательное поле.")]
        [Display(Name = "Город")]
        public string CityName { get; set; } = null!;

        /// <summary>
        /// Наименование улицы. Обязательное поле.
        /// </summary>
        [Required(ErrorMessage = "Обязательное поле.")]
        [Display(Name = "Улица")]
        public string Street { get; set; } = null!;

        /// <summary>
        /// Номер дома. Обязательное поле. Возмодный вариант ввода "69а"
        /// </summary>
        [Required(ErrorMessage = "Обязательное поле.")]
        [Display(Name = "Дом")]
        public string House { get; set; } = null!;

        /// <summary>
        /// Номер этажа. Обязательное поле. Не может быть меньше 1.
        /// </summary>
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Этаж")]
        [DefaultValue(1)]
        [Range(1, uint.MaxValue, ErrorMessage = "Значение должно быть не меньше нуля")]
        public uint Flat { get; set; }

        /// <summary>
        /// Номер квартиры. Опционально. Возможный вариант ввода "99г".
        /// </summary>
        [Display(Name = "Квартира")]
        public string? Appartament { get; set; }
    }
}
