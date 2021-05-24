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
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CategoryName")
                        .HasColumnType("longtext");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("VegaITPraksa.Models.Client", b =>
                {
                    b.Property<Guid>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("ClientName")
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("ClientId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("VegaITPraksa.Models.Project", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Archived")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("CustomerClientId")
                        .HasColumnType("char(36)");

                    b.Property<int?>("LeadTeamMemberId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectDescription")
                        .HasColumnType("longtext");

                    b.Property<int>("ProjectStatus")
                        .HasColumnType("int");

                    b.HasKey("ProjectId");

                    b.HasIndex("CustomerClientId");

                    b.HasIndex("LeadTeamMemberId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("VegaITPraksa.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .HasColumnType("longtext");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
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

                    b.Property<int?>("TeamMemberRoleRoleId")
                        .HasColumnType("int");

                    b.Property<int>("TeamMemberStatus")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.HasKey("TeamMemberId");

                    b.HasIndex("TeamMemberRoleRoleId");

                    b.ToTable("team_member");
                });

            modelBuilder.Entity("VegaITPraksa.Models.TimeSheet", b =>
                {
                    b.Property<Guid>("TimeSheetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("char(36)");

                    b.Property<double>("Overtime")
                        .HasColumnType("double");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("char(36)");

                    b.Property<int?>("TeamMemberId")
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

            modelBuilder.Entity("VegaITPraksa.Models.Project", b =>
                {
                    b.HasOne("VegaITPraksa.Models.Client", "Customer")
                        .WithMany("Projects")
                        .HasForeignKey("CustomerClientId");

                    b.HasOne("VegaITPraksa.Models.TeamMember", "Lead")
                        .WithMany("Projects")
                        .HasForeignKey("LeadTeamMemberId");

                    b.Navigation("Customer");

                    b.Navigation("Lead");
                });

            modelBuilder.Entity("VegaITPraksa.Models.TeamMember", b =>
                {
                    b.HasOne("VegaITPraksa.Models.Role", "TeamMemberRole")
                        .WithMany("TeamMembers")
                        .HasForeignKey("TeamMemberRoleRoleId");

                    b.Navigation("TeamMemberRole");
                });

            modelBuilder.Entity("VegaITPraksa.Models.TimeSheet", b =>
                {
                    b.HasOne("VegaITPraksa.Models.Category", "Category")
                        .WithMany("TimeSheet")
                        .HasForeignKey("CategoryId");

                    b.HasOne("VegaITPraksa.Models.Client", "Client")
                        .WithMany("TimeSheet")
                        .HasForeignKey("ClientId");

                    b.HasOne("VegaITPraksa.Models.Project", "Project")
                        .WithMany("TimeSheet")
                        .HasForeignKey("ProjectId");

                    b.HasOne("VegaITPraksa.Models.TeamMember", null)
                        .WithMany("TimeSheets")
                        .HasForeignKey("TeamMemberId");

                    b.Navigation("Category");

                    b.Navigation("Client");

                    b.Navigation("Project");
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

            modelBuilder.Entity("VegaITPraksa.Models.Project", b =>
                {
                    b.Navigation("TimeSheet");
                });

            modelBuilder.Entity("VegaITPraksa.Models.Role", b =>
                {
                    b.Navigation("TeamMembers");
                });

            modelBuilder.Entity("VegaITPraksa.Models.TeamMember", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("TimeSheets");
                });
#pragma warning restore 612, 618
        }
    }
}
