﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VegaITPraksa.Data;

namespace VegaITPraksa.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("VegaITPraksa.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .HasColumnType("longtext");

                    b.HasKey("CategoryId");

                    b.ToTable("category");
                });

            modelBuilder.Entity("VegaITPraksa.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("ClientName")
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("ClientId");

                    b.HasIndex("CountryId");

                    b.ToTable("client");
                });

            modelBuilder.Entity("VegaITPraksa.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CountryName")
                        .HasColumnType("longtext");

                    b.HasKey("CountryId");

                    b.ToTable("country");
                });

            modelBuilder.Entity("VegaITPraksa.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("ProjectName")
                        .HasColumnType("longtext");

                    b.Property<int>("ProjectStatus")
                        .HasColumnType("int");

                    b.Property<int>("TeamLeadId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId");

                    b.HasIndex("ClientId");

                    b.HasIndex("TeamLeadId");

                    b.ToTable("project");
                });

            modelBuilder.Entity("VegaITPraksa.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .HasColumnType("longtext");

                    b.HasKey("RoleId");

                    b.ToTable("role");
                });

            modelBuilder.Entity("VegaITPraksa.Models.TeamMember", b =>
                {
                    b.Property<int>("TeamMemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<double>("HoursPerWeek")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("TeamMemberStatus")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.HasKey("TeamMemberId");

                    b.HasIndex("RoleId");

                    b.ToTable("team_member");
                });

            modelBuilder.Entity("VegaITPraksa.Models.TeamMemberProject", b =>
                {
                    b.Property<int>("TeamMemberId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("TeamMemberId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("team_member/project");
                });

            modelBuilder.Entity("VegaITPraksa.Models.TimeSheet", b =>
                {
                    b.Property<int>("TimeSheetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<double>("Overtime")
                        .HasColumnType("double");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("TeamMemberId")
                        .HasColumnType("int");

                    b.Property<double>("Time")
                        .HasColumnType("double");

                    b.Property<DateTime>("TimeSheetDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("TimeSheetDescription")
                        .HasColumnType("longtext");

                    b.HasKey("TimeSheetId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TeamMemberId");

                    b.ToTable("time_sheet");
                });

            modelBuilder.Entity("VegaITPraksa.Models.Client", b =>
                {
                    b.HasOne("VegaITPraksa.Models.Country", "ClientCountry")
                        .WithMany("Clients")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientCountry");
                });

            modelBuilder.Entity("VegaITPraksa.Models.Project", b =>
                {
                    b.HasOne("VegaITPraksa.Models.Client", "Client")
                        .WithMany("Projects")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VegaITPraksa.Models.TeamMember", "TeamLead")
                        .WithMany()
                        .HasForeignKey("TeamLeadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("TeamLead");
                });

            modelBuilder.Entity("VegaITPraksa.Models.TeamMember", b =>
                {
                    b.HasOne("VegaITPraksa.Models.Role", "TeamMemberRole")
                        .WithMany("TeamMembers")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TeamMemberRole");
                });

            modelBuilder.Entity("VegaITPraksa.Models.TeamMemberProject", b =>
                {
                    b.HasOne("VegaITPraksa.Models.Project", "Project")
                        .WithMany("TeamMemberProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VegaITPraksa.Models.TeamMember", "TeamMember")
                        .WithMany("TeamMemberProjects")
                        .HasForeignKey("TeamMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("TeamMember");
                });

            modelBuilder.Entity("VegaITPraksa.Models.TimeSheet", b =>
                {
                    b.HasOne("VegaITPraksa.Models.Category", "Category")
                        .WithMany("TimeSheet")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VegaITPraksa.Models.Client", "Client")
                        .WithMany("TimeSheet")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VegaITPraksa.Models.Project", "Project")
                        .WithMany("TimeSheet")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VegaITPraksa.Models.TeamMember", "TeamMember")
                        .WithMany("TimeSheets")
                        .HasForeignKey("TeamMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Client");

                    b.Navigation("Project");

                    b.Navigation("TeamMember");
                });

            modelBuilder.Entity("VegaITPraksa.Models.Category", b =>
                {
                    b.Navigation("TimeSheet");
                });

            modelBuilder.Entity("VegaITPraksa.Models.Client", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("TimeSheet");
                });

            modelBuilder.Entity("VegaITPraksa.Models.Country", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("VegaITPraksa.Models.Project", b =>
                {
                    b.Navigation("TeamMemberProjects");

                    b.Navigation("TimeSheet");
                });

            modelBuilder.Entity("VegaITPraksa.Models.Role", b =>
                {
                    b.Navigation("TeamMembers");
                });

            modelBuilder.Entity("VegaITPraksa.Models.TeamMember", b =>
                {
                    b.Navigation("TeamMemberProjects");

                    b.Navigation("TimeSheets");
                });
#pragma warning restore 612, 618
        }
    }
}
