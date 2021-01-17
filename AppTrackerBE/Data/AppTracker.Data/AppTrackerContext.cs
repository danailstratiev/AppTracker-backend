using AppTracker.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AppTracker.Data
{
    public class AppTrackerContext: DbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<TrackedItem> TrackedItems { get; set; }

        public DbSet<ApplicationLog> applicationLogs { get; set; }
    }
}
