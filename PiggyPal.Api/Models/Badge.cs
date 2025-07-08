using System;

namespace PiggyPal.Api.Models
{
    public class Badge
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public int KidId { get; set; }
        public Kid Kid { get; set; }
        public DateTime DateAwarded { get; set; }
        public int HouseholdId { get; set; }
        public Household Household { get; set; }
    }
} 