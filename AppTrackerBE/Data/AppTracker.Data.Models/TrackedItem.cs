﻿using AppTracker.Data.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace AppTracker.Data.Models
{
    public class TrackedItem: BaseDeletableModel<int>
    {
        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string Name { get; set; }

        public int ModifierId { get; set; }

        public ApplicationUser Modifier { get; set; }
        
        [Required]
        public Status Status { get; set; }

        [StringLength(20, MinimumLength = 2)]
        public string Version { get; set; }
    }
}
