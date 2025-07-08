using System.ComponentModel.DataAnnotations.Schema;

namespace PiggyPal.Api.Models
{
    public class Parent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ProfilePictureUrl { get; set; }
        public int HouseholdId { get; set; }
        public Household Household { get; set; }
    }
} 