﻿using System.ComponentModel.DataAnnotations;

namespace DeliveryParcel.Models
{
    public class ParcelVm
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Минимальный вес должен быть хотя бы 0.1 кг.")]
        [Display(Name = "Вес посылки")]
        public decimal Wieght { get; set; }
    }
}
