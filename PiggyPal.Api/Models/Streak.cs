using System;

namespace PiggyPal.Api.Models
{
    public class Streak
    {
        public int Id { get; set; }
        public int KidId { get; set; }
        public Kid Kid { get; set; }
        public int HouseholdId { get; set; }
        public Household Household { get; set; }
        public string Type { get; set; } // e.g., "Chore", "Behavior"
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Length { get; set; } // in days
    }
} 