using Microsoft.EntityFrameworkCore;

namespace PiggyPal.Api.Models
{
    public class PiggyPalContext : DbContext
    {
        public PiggyPalContext(DbContextOptions<PiggyPalContext> options) : base(options) { }

        public DbSet<Household> Households { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Kid> Kids { get; set; }
        public DbSet<Chore> Chores { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<Allowance> Allowances { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Behavior> Behaviors { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Streak> Streaks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Chore <-> Reward one-to-one
            modelBuilder.Entity<Chore>()
                .HasOne(c => c.Reward)
                .WithOne(r => r.Chore)
                .HasForeignKey<Reward>(r => r.ChoreId);

            // Configure relationships and table names if needed
            base.OnModelCreating(modelBuilder);
        }

        public static void Seed(PiggyPalContext db)
        {
            if (!db.Households.Any())
            {
                var household = new Household { Name = "Smith Family", CreatedDate = DateTime.UtcNow };
                db.Households.Add(household);
                db.SaveChanges();

                var parent = new Parent { Name = "Jane Smith", Email = "jane@smith.com", HouseholdId = household.Id };
                db.Parents.Add(parent);
                var kid = new Kid { Name = "Tommy Smith", HouseholdId = household.Id };
                db.Kids.Add(kid);
                db.SaveChanges();

                var chore = new Chore { Description = "Make Bed", AssignedToKidId = kid.Id, HouseholdId = household.Id, AssignedDate = DateTime.UtcNow, Status = ChoreStatus.Pending };
                db.Chores.Add(chore);
                var behavior = new Behavior { Description = "Helped sibling", KidId = kid.Id, HouseholdId = household.Id, Date = DateTime.UtcNow, IsPositive = true };
                db.Behaviors.Add(behavior);
                var reward = new Reward { ChoreId = chore.Id, Type = RewardType.Money, Amount = 1.00M, Description = "$1 for making bed" };
                db.Rewards.Add(reward);
                db.SaveChanges();
            }
        }
    }
} 