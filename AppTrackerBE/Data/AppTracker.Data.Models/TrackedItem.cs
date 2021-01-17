using AppTracker.Data.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace AppTracker.Data.Models
{
    public class TrackedItem: BaseDeletableModel<int>
    {
        public int CreatorId { get; set; }

        public ApplicationUser Creator { get; set; }

        public int ModifierId { get; set; }

        public ApplicationUser Modifier { get; set; }
        
        [Required]
        public Status Status { get; set; }

        [StringLength(20, MinimumLength = 2)]
        public string Version { get; set; }
    }
}
