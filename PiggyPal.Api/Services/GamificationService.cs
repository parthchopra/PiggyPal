using System;
using System.Linq;
using System.Threading.Tasks;
using PiggyPal.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace PiggyPal.Api.Services
{
    public class GamificationService
    {
        private readonly PiggyPalContext _db;
        public GamificationService(PiggyPalContext db) => _db = db;

        public async Task AwardBadgesForChore(int kidId)
        {
            var completedChores = await _db.Chores.CountAsync(c => c.AssignedToKidId == kidId && c.Status == ChoreStatus.Approved);
            if (completedChores == 1 && !await _db.Badges.AnyAsync(b => b.KidId == kidId && b.Name == "First Chore Completed"))
            {
                _db.Badges.Add(new Badge
                {
                    Name = "First Chore Completed",
                    Description = "Completed your first chore!",
                    IconUrl = "",
                    KidId = kidId,
                    DateAwarded = DateTime.UtcNow,
                    HouseholdId = _db.Kids.Find(kidId).HouseholdId
                });
                await _db.SaveChangesAsync();
            }
            if (completedChores == 7 && !await _db.Badges.AnyAsync(b => b.KidId == kidId && b.Name == "7 Chores Completed"))
            {
                _db.Badges.Add(new Badge
                {
                    Name = "7 Chores Completed",
                    Description = "Completed 7 chores!",
                    IconUrl = "",
                    KidId = kidId,
                    DateAwarded = DateTime.UtcNow,
                    HouseholdId = _db.Kids.Find(kidId).HouseholdId
                });
                await _db.SaveChangesAsync();
            }
        }

        public async Task AwardBadgesForBehavior(int kidId)
        {
            var behaviors = await _db.Behaviors.CountAsync(b => b.KidId == kidId && b.IsPositive);
            if (behaviors == 10 && !await _db.Badges.AnyAsync(b => b.KidId == kidId && b.Name == "10 Good Behaviors"))
            {
                _db.Badges.Add(new Badge
                {
                    Name = "10 Good Behaviors",
                    Description = "Logged 10 positive behaviors!",
                    IconUrl = "",
                    KidId = kidId,
                    DateAwarded = DateTime.UtcNow,
                    HouseholdId = _db.Kids.Find(kidId).HouseholdId
                });
                await _db.SaveChangesAsync();
            }
        }

        public async Task UpdateStreaks(int kidId)
        {
            var today = DateTime.UtcNow.Date;
            var yesterday = today.AddDays(-1);
            var lastChore = await _db.Chores.Where(c => c.AssignedToKidId == kidId && c.Status == ChoreStatus.Approved)
                .OrderByDescending(c => c.CompletedDate).FirstOrDefaultAsync();
            if (lastChore == null || lastChore.CompletedDate == null) return;
            var lastStreak = await _db.Streaks.Where(s => s.KidId == kidId && s.Type == "Chore").OrderByDescending(s => s.StartDate).FirstOrDefaultAsync();
            if (lastStreak != null && lastStreak.EndDate == null)
            {
                if (lastChore.CompletedDate.Value.Date == yesterday)
                {
                    lastStreak.Length++;
                    await _db.SaveChangesAsync();
                }
                else if (lastChore.CompletedDate.Value.Date == today)
                {
                    // Already counted today
                }
                else
                {
                    lastStreak.EndDate = lastChore.CompletedDate.Value.Date;
                    await _db.SaveChangesAsync();
                    // Start new streak
                    _db.Streaks.Add(new Streak
                    {
                        KidId = kidId,
                        HouseholdId = _db.Kids.Find(kidId).HouseholdId,
                        Type = "Chore",
                        StartDate = lastChore.CompletedDate.Value.Date,
                        Length = 1
                    });
                    await _db.SaveChangesAsync();
                }
            }
            else
            {
                // Start first streak
                _db.Streaks.Add(new Streak
                {
                    KidId = kidId,
                    HouseholdId = _db.Kids.Find(kidId).HouseholdId,
                    Type = "Chore",
                    StartDate = lastChore.CompletedDate.Value.Date,
                    Length = 1
                });
                await _db.SaveChangesAsync();
            }
            // Award badge for 7-day streak
            var maxStreak = await _db.Streaks.Where(s => s.KidId == kidId && s.Type == "Chore").MaxAsync(s => (int?)s.Length) ?? 0;
            if (maxStreak == 7 && !await _db.Badges.AnyAsync(b => b.KidId == kidId && b.Name == "7-Day Streak"))
            {
                _db.Badges.Add(new Badge
                {
                    Name = "7-Day Streak",
                    Description = "Completed chores 7 days in a row!",
                    IconUrl = "",
                    KidId = kidId,
                    DateAwarded = DateTime.UtcNow,
                    HouseholdId = _db.Kids.Find(kidId).HouseholdId
                });
                await _db.SaveChangesAsync();
            }
        }
    }
} 