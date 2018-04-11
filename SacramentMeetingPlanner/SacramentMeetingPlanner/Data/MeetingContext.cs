using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SacramentMeetingPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace SacramentMeetingPlanner.Data
{
    public class MeetingContext : DbContext
    {
            public MeetingContext(DbContextOptions<MeetingContext> options) : base(options)
        {
        }

        public DbSet<SacramentMeetingPlan> sacramentMeetingPlans { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SacramentMeetingPlan>().ToTable("SacramentMeetingPlan");
            

        }
    }
}
    
