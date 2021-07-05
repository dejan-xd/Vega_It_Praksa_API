using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VegaITPraksa.Models;

namespace VegaITPraksa.Data
{
    public class DataContext : DbContext
    {
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TeamMemberProject> TeamMemberProjects { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TeamMemberProject>().HasKey(i => new { i.TeamMemberId, i.ProjectId });
        }
    }
}
