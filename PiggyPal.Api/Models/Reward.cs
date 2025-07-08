namespace PiggyPal.Api.Models
{
    public enum RewardType
    {
        Money,
        Stars,
        Custom
    }

    public class Reward
    {
        public int Id { get; set; }
        public int ChoreId { get; set; }
        public Chore Chore { get; set; }
        public RewardType Type { get; set; }
        public decimal? Amount { get; set; }
        public string Description { get; set; }
    }
} 