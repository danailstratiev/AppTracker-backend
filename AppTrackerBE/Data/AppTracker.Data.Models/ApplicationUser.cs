using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AppTracker.Data.Common;

namespace AppTracker.Data.Models
{
    public class ApplicationUser : BaseDeletableModel<int>
    {
        public ApplicationUser()
        {
            this.TrackedItems = new List<TrackedItem>();
            this.ApplicationLogs = new List<ApplicationLog>();
        }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [RegularExpression("^[a-z0-9_\\+-]+", ErrorMessage = "Invalid password format.")]
        public string Password { get; set; }

        public Role Role { get; set; }

        public ICollection<TrackedItem> TrackedItems { get; set; }

        public ICollection<ApplicationLog> ApplicationLogs { get; set; }
    }
}
