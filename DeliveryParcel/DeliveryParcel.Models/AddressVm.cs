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
        [Display(Name = "Номер дома")]
        public string House { get; set; } = null!;

        [Display(Name = "Номер этажа")]
        public int Flat { get; set; }

        [Display(Name = "Номер квартиры")]
        public string? Appartament { get; set; }
    }
}
