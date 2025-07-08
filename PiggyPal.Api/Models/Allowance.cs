using System;

namespace PiggyPal.Api.Models
{
    public enum AllowanceCadence
    {
        Weekly,
        Biweekly,
        Monthly
    }

    public class Allowance
    {
        public int Id { get; set; }
        public int KidId { get; set; }
        public Kid Kid { get; set; }
        public int HouseholdId { get; set; }
        public Household Household { get; set; }
        public decimal Amount { get; set; }
        public AllowanceCadence Cadence { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
} 