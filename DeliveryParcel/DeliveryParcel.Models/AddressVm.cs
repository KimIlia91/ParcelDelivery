using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DeliveryParcel.Models
{
    public class AddressVm
    {
        [Required(ErrorMessage = "Обязательное поле.")]
        [Display(Name = "Город")]
        public string CityName { get; set; } = null!;

        [Required(ErrorMessage = "Обязательное поле.")]
        [Display(Name = "Улица")]
        public string Street { get; set; } = null!;

        [Required(ErrorMessage = "Обязательное поле.")]
        [Display(Name = "Дом")]
        public string House { get; set; } = null!;

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Этаж")]
        [DefaultValue(1)]
        [Range(1, uint.MaxValue, ErrorMessage = "Значение должно быть не меньше нуля")]
        public uint Flat { get; set; }

        [Display(Name = "Квартира")]
        public string? Appartament { get; set; }
    }
}
