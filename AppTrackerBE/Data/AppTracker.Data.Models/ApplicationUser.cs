using System;
using System.Collections.Generic;
using AppTracker.Data.Common;

namespace AppTracker.Data.Models
{
    public class ApplicationUser : BaseDeletableModel<int>
    {
        public ApplicationUser()
        {
           
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

        public ICollection<TrackedItem> TrackedItems { get; set; }
    }
}
