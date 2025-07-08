using System;

namespace PiggyPal.Api.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public int KidId { get; set; }
        public Kid Kid { get; set; }
        public int HouseholdId { get; set; }
        public Household Household { get; set; }
        public string Description { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public string PictureUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
} 