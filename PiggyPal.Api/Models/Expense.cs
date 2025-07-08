using System;

namespace PiggyPal.Api.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public int KidId { get; set; }
        public Kid Kid { get; set; }
        public int HouseholdId { get; set; }
        public Household Household { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public DateTime Date { get; set; }
    }
} 