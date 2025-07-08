using System;

namespace PiggyPal.Api.Models
{
    public enum ChoreStatus
    {
        Pending,
        Submitted,
        Approved,
        Rejected
    }

    public class Chore
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public int? AssignedToKidId { get; set; }
        public Kid AssignedToKid { get; set; }
        public int HouseholdId { get; set; }
        public Household Household { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public ChoreStatus Status { get; set; }
        public string SubmittedPictureUrl { get; set; }
        public int? ApprovedByParentId { get; set; }
        public Parent ApprovedByParent { get; set; }
        public int? RewardId { get; set; }
        public Reward Reward { get; set; }
        public string Notes { get; set; }
    }
} 