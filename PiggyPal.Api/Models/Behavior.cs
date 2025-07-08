using System;

namespace PiggyPal.Api.Models
{
    public class Behavior
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int KidId { get; set; }
        public Kid Kid { get; set; }
        public int HouseholdId { get; set; }
        public Household Household { get; set; }
        public DateTime Date { get; set; }
        public int? RewardId { get; set; }
        public Reward Reward { get; set; }
        public bool IsPositive { get; set; } // true = positive, false = negative (consequence)
        public string Notes { get; set; }
    }
} 