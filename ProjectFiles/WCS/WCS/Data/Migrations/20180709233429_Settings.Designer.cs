﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WCS.Data;
using WCS.Models;

namespace WCS.Data.Migrations
{
    [DbContext(typeof(WcsContext))]
    [Migration("20180709233429_Settings")]
    partial class Settings
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WCS.Models.AwardCycle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CycleName");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("Recycled");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("AwardCycles");
                });

            modelBuilder.Entity("WCS.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("ConcurrentCourse");

                    b.Property<string>("CourseName")
                        .IsRequired();

                    b.Property<string>("CourseNumber")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("WCS.Models.Form", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Description");

                    b.Property<bool>("IncludeStudentRating");

                    b.Property<bool>("Recycled");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("WCS.Models.FormCriterion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FormId");

                    b.Property<int>("Order");

                    b.Property<bool>("Recycled");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.ToTable("FormCriteria");
                });

            modelBuilder.Entity("WCS.Models.FormField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FormId");

                    b.Property<string>("Options");

                    b.Property<int>("Order");

                    b.Property<bool>("Recycled");

                    b.Property<bool>("Required");

                    b.Property<string>("Title");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.ToTable("FormFields");
                });

            modelBuilder.Entity("WCS.Models.FormRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FormCriterionId");

                    b.Property<string>("JudgeId");

                    b.Property<int>("Rating");

                    b.Property<int>("StudentFormId");

                    b.HasKey("Id");

                    b.HasIndex("FormCriterionId");

                    b.HasIndex("JudgeId");

                    b.HasIndex("StudentFormId");

                    b.ToTable("FormRatings");
                });

            modelBuilder.Entity("WCS.Models.FormRequirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FormId");

                    b.Property<string>("Operator");

                    b.Property<string>("ProfileField");

                    b.Property<bool>("Recycled");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.ToTable("FormRequirements");
                });

            modelBuilder.Entity("WCS.Models.FormResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FormFieldId");

                    b.Property<string>("Response");

                    b.Property<int>("StudentFormId");

                    b.HasKey("Id");

                    b.HasIndex("FormFieldId");

                    b.HasIndex("StudentFormId");

                    b.ToTable("FormResponses");
                });

            modelBuilder.Entity("WCS.Models.Invite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailAddress")
                        .IsRequired();

                    b.Property<DateTime>("ExpirationDate");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("InviteCode");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Role")
                        .IsRequired();

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("Invites");
                });

            modelBuilder.Entity("WCS.Models.RecycledItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ItemDependency");

                    b.Property<int>("ItemId");

                    b.Property<string>("ItemName")
                        .IsRequired();

                    b.Property<int>("ItemType");

                    b.Property<string>("RecycledBy");

                    b.Property<DateTime>("RecycledDate");

                    b.HasKey("Id");

                    b.ToTable("RecycleBin");
                });

            modelBuilder.Entity("WCS.Models.Scholarship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Scholarships");
                });

            modelBuilder.Entity("WCS.Models.ScholarshipAward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AwardCycleId");

                    b.Property<int>("ScholarshipId");

                    b.Property<int>("StudentProfileId");

                    b.HasKey("Id");

                    b.HasIndex("AwardCycleId");

                    b.HasIndex("ScholarshipId");

                    b.HasIndex("StudentProfileId");

                    b.ToTable("ScholarshipAwards");
                });

            modelBuilder.Entity("WCS.Models.ScholarshipAwardMoney", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<int>("ScholarshipAwardId");

                    b.Property<int>("ScholarshipFundId");

                    b.HasKey("Id");

                    b.HasIndex("ScholarshipAwardId");

                    b.HasIndex("ScholarshipFundId");

                    b.ToTable("ScholarshipAwardMonies");
                });

            modelBuilder.Entity("WCS.Models.ScholarshipFund", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<int>("AwardCycleId");

                    b.Property<string>("Name");

                    b.Property<int>("ScholarshipId");

                    b.HasKey("Id");

                    b.HasIndex("AwardCycleId");

                    b.HasIndex("ScholarshipId");

                    b.ToTable("ScholarshipFunds");
                });

            modelBuilder.Entity("WCS.Models.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SettingName");

                    b.Property<string>("SettingValue");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("WCS.Models.StudentCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseId");

                    b.Property<int>("StudentId");

                    b.Property<int?>("StudentProfileId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentProfileId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("WCS.Models.StudentForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AwardCycleId");

                    b.Property<int>("FormId");

                    b.Property<int>("StudentProfileId");

                    b.HasKey("Id");

                    b.HasIndex("AwardCycleId");

                    b.HasIndex("FormId");

                    b.HasIndex("StudentProfileId");

                    b.ToTable("StudentForms");
                });

            modelBuilder.Entity("WCS.Models.StudentProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AchievementsHistory");

                    b.Property<int?>("ActScore");

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Address2");

                    b.Property<string>("AwardsHistory");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("ClubAndOrganizationHistory");

                    b.Property<string>("CsInterest");

                    b.Property<string>("CurrentAcademicLevel");

                    b.Property<string>("CurrentMajor");

                    b.Property<string>("CurrentScheduleStatus");

                    b.Property<string>("FirstName");

                    b.Property<string>("FirstWsuSemester");

                    b.Property<string>("FirstWsuYear");

                    b.Property<string>("FutureMajor");

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<string>("HighSchool");

                    b.Property<string>("LastName");

                    b.Property<string>("LastUniversity");

                    b.Property<float?>("MajorGPA")
                        .IsRequired();

                    b.Property<string>("MaritalStatus")
                        .IsRequired();

                    b.Property<float>("OverallGPA");

                    b.Property<string>("PassedApTests");

                    b.Property<string>("Prefix");

                    b.Property<string>("ScholarshipAidHistory");

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("UltimateDegreeGoal");

                    b.Property<string>("WNumber");

                    b.Property<string>("ZipCode")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("StudentProfiles");
                });

            modelBuilder.Entity("WCS.Models.StudentRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AwardCycleId");

                    b.Property<string>("JudgeId");

                    b.Property<int>("Rating");

                    b.Property<int>("StudentProfileId");

                    b.HasKey("Id");

                    b.HasIndex("AwardCycleId");

                    b.HasIndex("JudgeId");

                    b.HasIndex("StudentProfileId");

                    b.ToTable("StudentRatings");
                });

            modelBuilder.Entity("WCS.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<DateTime>("LastLogin");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("MiddleInitial");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int?>("StudentProfileId");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("StudentProfileId")
                        .IsUnique()
                        .HasFilter("[StudentProfileId] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WCS.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WCS.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WCS.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WCS.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WCS.Models.FormCriterion", b =>
                {
                    b.HasOne("WCS.Models.Form", "Form")
                        .WithMany("FormCriteria")
                        .HasForeignKey("FormId");
                });

            modelBuilder.Entity("WCS.Models.FormField", b =>
                {
                    b.HasOne("WCS.Models.Form", "Form")
                        .WithMany("FormFields")
                        .HasForeignKey("FormId");
                });

            modelBuilder.Entity("WCS.Models.FormRating", b =>
                {
                    b.HasOne("WCS.Models.FormCriterion", "FormCriterion")
                        .WithMany("FormRatings")
                        .HasForeignKey("FormCriterionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WCS.Models.User", "Judge")
                        .WithMany()
                        .HasForeignKey("JudgeId");

                    b.HasOne("WCS.Models.StudentForm", "StudentForm")
                        .WithMany("FormRatings")
                        .HasForeignKey("StudentFormId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WCS.Models.FormRequirement", b =>
                {
                    b.HasOne("WCS.Models.Form", "Form")
                        .WithMany("FormRequirements")
                        .HasForeignKey("FormId");
                });

            modelBuilder.Entity("WCS.Models.FormResponse", b =>
                {
                    b.HasOne("WCS.Models.FormField", "FormField")
                        .WithMany("FormResponses")
                        .HasForeignKey("FormFieldId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WCS.Models.StudentForm", "StudentForm")
                        .WithMany("StudentResponses")
                        .HasForeignKey("StudentFormId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WCS.Models.ScholarshipAward", b =>
                {
                    b.HasOne("WCS.Models.AwardCycle", "AwardCycle")
                        .WithMany("ScholarshipAwards")
                        .HasForeignKey("AwardCycleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WCS.Models.Scholarship", "Scholarship")
                        .WithMany("ScholarshipAwards")
                        .HasForeignKey("ScholarshipId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WCS.Models.StudentProfile", "StudentProfile")
                        .WithMany("ScholarshipAwards")
                        .HasForeignKey("StudentProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WCS.Models.ScholarshipAwardMoney", b =>
                {
                    b.HasOne("WCS.Models.ScholarshipAward", "ScholarshipAward")
                        .WithMany("AwardMonies")
                        .HasForeignKey("ScholarshipAwardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WCS.Models.ScholarshipFund", "ScholarshipFund")
                        .WithMany("AwardMonies")
                        .HasForeignKey("ScholarshipFundId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WCS.Models.ScholarshipFund", b =>
                {
                    b.HasOne("WCS.Models.AwardCycle", "AwardCycle")
                        .WithMany("ScholarshipFunds")
                        .HasForeignKey("AwardCycleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WCS.Models.Scholarship", "Scholarship")
                        .WithMany("ScholarshipFunds")
                        .HasForeignKey("ScholarshipId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WCS.Models.StudentCourse", b =>
                {
                    b.HasOne("WCS.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WCS.Models.StudentProfile")
                        .WithMany("PastCourses")
                        .HasForeignKey("StudentProfileId");
                });

            modelBuilder.Entity("WCS.Models.StudentForm", b =>
                {
                    b.HasOne("WCS.Models.AwardCycle", "AwardCycle")
                        .WithMany("StudentForms")
                        .HasForeignKey("AwardCycleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WCS.Models.Form", "Form")
                        .WithMany("StudentForms")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WCS.Models.StudentProfile", "StudentProfile")
                        .WithMany("StudentForms")
                        .HasForeignKey("StudentProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WCS.Models.StudentRating", b =>
                {
                    b.HasOne("WCS.Models.AwardCycle", "AwardCycle")
                        .WithMany()
                        .HasForeignKey("AwardCycleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WCS.Models.User", "Judge")
                        .WithMany()
                        .HasForeignKey("JudgeId");

                    b.HasOne("WCS.Models.StudentProfile", "StudentProfile")
                        .WithMany("StudentRatings")
                        .HasForeignKey("StudentProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WCS.Models.User", b =>
                {
                    b.HasOne("WCS.Models.StudentProfile")
                        .WithOne("Student")
                        .HasForeignKey("WCS.Models.User", "StudentProfileId");
                });
#pragma warning restore 612, 618
        }
    }
}
