﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PiggyPal.Api.Models;

#nullable disable

namespace PiggyPal.Api.Migrations
{
    [DbContext(typeof(PiggyPalContext))]
    partial class PiggyPalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.7");

            modelBuilder.Entity("PiggyPal.Api.Models.Allowance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<int>("Cadence")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("HouseholdId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("KidId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HouseholdId");

                    b.HasIndex("KidId");

                    b.ToTable("Allowances");
                });

            modelBuilder.Entity("PiggyPal.Api.Models.Badge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAwarded")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("HouseholdId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IconUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("KidId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HouseholdId");

                    b.HasIndex("KidId");

                    b.ToTable("Badges");
                });

            modelBuilder.Entity("PiggyPal.Api.Models.Behavior", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("HouseholdId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPositive")
                        .HasColumnType("INTEGER");

                    b.Property<int>("KidId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("RewardId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("HouseholdId");

                    b.HasIndex("KidId");

                    b.HasIndex("RewardId");

                    b.ToTable("Behaviors");
                });

            modelBuilder.Entity("PiggyPal.Api.Models.Chore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ApprovedByParentId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AssignedDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("AssignedToKidId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CompletedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("HouseholdId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("RewardId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SubmittedPictureUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ApprovedByParentId");

                    b.HasIndex("AssignedToKidId");

                    b.HasIndex("HouseholdId");

                    b.ToTable("Chores");
                });

            modelBuilder.Entity("PiggyPal.Api.Models.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("HouseholdId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("KidId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HouseholdId");

                    b.HasIndex("KidId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("PiggyPal.Api.Models.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CompletedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("CurrentAmount")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("HouseholdId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("KidId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TargetAmount")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HouseholdId");

                    b.HasIndex("KidId");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("PiggyPal.Api.Models.Household", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Households");
                });

            modelBuilder.Entity("PiggyPal.Api.Models.Kid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("HouseholdId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProfilePictureUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HouseholdId");

                    b.ToTable("Kids");
                });

            modelBuilder.Entity("PiggyPal.Api.Models.Parent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("HouseholdId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProfilePictureUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HouseholdId");

                    b.ToTable("Parents");
                });

            modelBuilder.Entity("PiggyPal.Api.Models.Reward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<int>("ChoreId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ChoreId")
                        .IsUnique();

                    b.ToTable("Rewards");
                });

            modelBuilder.Entity("PiggyPal.Api.Models.Streak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("HouseholdId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("KidId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Length")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HouseholdId");

                    b.HasIndex("KidId");

                    b.ToTable("Streaks");
                });

            modelBuilder.Entity("PiggyPal.Api.Models.Allowance", b =>
                {
                    b.HasOne("PiggyPal.Api.Models.Household", "Household")
                        .WithMany("Allowances")
                        .HasForeignKey("HouseholdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PiggyPal.Api.Models.Kid", "Kid")
                        .WithMany("Allowances")
                        .HasForeignKey("KidId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Household");

                    b.Navigation("Kid");
                });

            modelBuilder.Entity("PiggyPal.Api.Models.Badge", b =>
                {
                    b.HasOne("PiggyPal.Api.Models.Household", "Household")
                        .WithMany("Badges")
                        .HasForeignKey("HouseholdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PiggyPal.Api.Models.Kid", "Kid")
                        .WithMany("Badges")
                        .HasForeignKey("KidId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Household");

                    b.Navigation("Kid");
                });

            modelBuilder.Entity("PiggyPal.Api.Models.Behavior", b =>
                {
                    b.HasOne("PiggyPal.Api.Models.Household", "Household")
                        .WithMany("Behaviors")
                        .HasForeignKey("HouseholdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PiggyPal.Api.Models.Kid", "Kid")
                        .WithMany("Behaviors")
                        .HasForeignKey("KidId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PiggyPal.Api.Models.Reward", "Reward")
                        .WithMany()
                        .HasForeignKey("RewardId");

                    b.Navigation("Household");

                    b.Navigation("Kid");

                    b.Navigation("Reward");
                });

            modelBuilder.Entity("PiggyPal.Api.Models.Chore", b =>
                {
                    b.HasOne("PiggyPal.Api.Models.Parent", "ApprovedByParent")
                        .WithMany()
                        .HasForeignKey("ApprovedByParentId");

                    b.HasOne("PiggyPal.Api.Models.Kid", "AssignedToKid")
                        .WithMany("Chores")
                        .HasForeignKey("AssignedToKidId");

                    b.HasOne("PiggyPal.Api.Models.Household", "Household")
                        .WithMany("Chores")
                        .HasForeignKey("HouseholdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApprovedByParent");

                    b.Navigation("AssignedToKid");

                    b.Navigation("Household");
                });

            modelBuilder.Entity("PiggyPal.Api.Models.Expense", b =>
                {
                    b.HasOne("PiggyPal.Api.Models.Household", "Household")
                        .WithMany("Expenses")
                        .HasForeignKey("HouseholdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PiggyPal.Api.Models.Kid", "Kid")
                        .WithMany("Expenses")
                        .HasForeignKey("KidId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Household");

                    b.Navigation("Kid");
                });

            modelBuilder.Entity("PiggyPal.Api.Models.Goal", b =>
                {
                    b.HasOne("PiggyPal.Api.Models.Household", "Household")
                        .WithMany("Goals")
                        .HasForeignKey("HouseholdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PiggyPal.Api.Models.Kid", "Kid")
                        .WithMany("Goals")
                        .HasForeignKey("KidId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Household");

                    b.Navigation("Kid");
                });

            modelBuilder.Entity("PiggyPal.Api.Models.Kid", b =>
                {
                    b.HasOne("PiggyPal.Api.Models.Household", "Household")
                        .WithMany("Kids")
                        .HasForeignKey("HouseholdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Household");
                });

            modelBuilder.Entity("PiggyPal.Api.Models.Parent", b =>
                {
                    b.HasOne("PiggyPal.Api.Models.Household", "Household")
                        .WithMany("Parents")
                        .HasForeignKey("HouseholdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Household");
                });

            modelBuilder.Entity("PiggyPal.Api.Models.Reward", b =>
                {
                    b.HasOne("PiggyPal.Api.Models.Chore", "Chore")
                        .WithOne("Reward")
                        .HasForeignKey("PiggyPal.Api.Models.Reward", "ChoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chore");
                });

            modelBuilder.Entity("PiggyPal.Api.Models.Streak", b =>
                {
                    b.HasOne("PiggyPal.Api.Models.Household", "Household")
                        .WithMany("Streaks")
                        .HasForeignKey("HouseholdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PiggyPal.Api.Models.Kid", "Kid")
                        .WithMany("Streaks")
                        .HasForeignKey("KidId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Household");

                    b.Navigation("Kid");
                });

            modelBuilder.Entity("PiggyPal.Api.Models.Chore", b =>
                {
                    b.Navigation("Reward")
                        .IsRequired();
                });

            modelBuilder.Entity("PiggyPal.Api.Models.Household", b =>
                {
                    b.Navigation("Allowances");

                    b.Navigation("Badges");

                    b.Navigation("Behaviors");

                    b.Navigation("Chores");

                    b.Navigation("Expenses");

                    b.Navigation("Goals");

                    b.Navigation("Kids");

                    b.Navigation("Parents");

                    b.Navigation("Streaks");
                });

            modelBuilder.Entity("PiggyPal.Api.Models.Kid", b =>
                {
                    b.Navigation("Allowances");

                    b.Navigation("Badges");

                    b.Navigation("Behaviors");

                    b.Navigation("Chores");

                    b.Navigation("Expenses");

                    b.Navigation("Goals");

                    b.Navigation("Streaks");
                });
#pragma warning restore 612, 618
        }
    }
}
