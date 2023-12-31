﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Suaah.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Stars { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "You must choose a Country")]
        public int CountryId { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0,9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Invalid")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [ValidateNever]
        [DisplayName("Image")]
        public string? ImageUrl { get; set; }

        [Required]
        public string Description { get; set; }

        

        [ValidateNever]
        public Country? Country { get; set; }

        [ValidateNever]
        public ICollection<HotelRoom> HotelRooms { get; set; }       
    }
}
