using System.Collections.Generic;
using EP_HomeAssignment.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EP_HomeAssignment.Domain.Models
{
    public class Restaurant : IItemValidating
    {
        [Key]
        public int Id { get; set; } // Identity Int
        public string Name { get; set; }
        public string OwnerEmailAddress { get; set; }
        public string Status { get; set; } = "Pending";

        // Navigation Property for relational DB
        public virtual ICollection<MenuItem> MenuItems { get; set; }

        // Interface Implementation
        public string GetIdString() => "R-" + Id;

        public string GetCardPartial()
        {
            return "_RestaurantCard"; // Name of the partial view file
        }

        public List<string> GetValidators()
        {
            // Brief: Site Admin approves restaurants.
            // In the demo this would be injected, but hardcoding "admin@myasp.net" is acceptable for the assignment scope.
            return new List<string> { "admin@myasp.net" };
        }
    }
}