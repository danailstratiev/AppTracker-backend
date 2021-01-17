using AppTracker.Data.Common;
using System;

namespace AppTracker.Data.Models
{
    public class TrackedItem: BaseDeletableModel<int>
    {
        public int CreatorId { get; set; }

        public ApplicationUser Creator { get; set; }

        public int ModifierId { get; set; }

        public ApplicationUser Modifier { get; set; }

        public Status Status { get; set; }

        public string MyProperty { get; set; }
    }
}
