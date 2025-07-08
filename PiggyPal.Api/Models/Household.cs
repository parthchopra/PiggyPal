using System;
using System.Collections.Generic;

namespace PiggyPal.Api.Models
{
    public class Household
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<Parent> Parents { get; set; }
        public ICollection<Kid> Kids { get; set; }
        public ICollection<Chore> Chores { get; set; }
        public ICollection<Allowance> Allowances { get; set; }
        public ICollection<Expense> Expenses { get; set; }
        public ICollection<Goal> Goals { get; set; }
        public ICollection<Behavior> Behaviors { get; set; }
        public ICollection<Badge> Badges { get; set; }
        public ICollection<Streak> Streaks { get; set; }
    }
} 