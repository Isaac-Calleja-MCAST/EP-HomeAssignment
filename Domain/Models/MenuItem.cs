using System;
using System.Collections.Generic;
using EP_HomeAssignment.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EP_HomeAssignment.Domain.Models
{
    public class MenuItem : IItemValidating
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Status { get; set; } = "Pending";

        // Foreign Key
        public int RestaurantId { get; set; }
        [ForeignKey("RestaurantId")]
        public virtual Restaurant Restaurant { get; set; }

        // Interface Implementation
        public string GetIdString() => "M-" + Id;

        public string GetCardPartial()
        {
            return "_MenuItemCard";
        }

        public List<string> GetValidators()
        {
            // Brief: Restaurant Owner approves MenuItems.
            // Note: If Restaurant is null (not loaded), return empty list to prevent crash.
            return Restaurant != null ? new List<string> { Restaurant.OwnerEmailAddress } : new List<string>();
        }
    }
}
