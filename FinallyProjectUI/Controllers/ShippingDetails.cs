﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FinallyProjectUI.Controllers
{
    public class ShippingDetails
    {
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen adres tanımını giriniz.")]
        public string AddressTitle { get; set; }
        [Required(ErrorMessage = "Lütfen bir adres giriniz.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Lütfen şehir giriniz.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Lütfen ilçe giriniz.")]
        public string District { get; set; }

        [Required(ErrorMessage = "Lütfen mahalle giriniz.")]
        public string Mahalle { get; set; }

        public string PostalCode { get; set; }
    }
}
