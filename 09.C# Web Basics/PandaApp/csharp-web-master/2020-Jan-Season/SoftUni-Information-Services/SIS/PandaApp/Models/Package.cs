using PandaApp.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PandaApp.Models
{
    public class Package
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Description { get; set; }

        public double Weight { get; set; }

        public string ShippingAddress { get; set; }

        public Status Status { get; set; }

        public DateTime EstimatedDeliveryTime { get; set; }

        [Required]
        public string RecipientId { get; set; }
        public User Recipient { get; set; }
    }
}