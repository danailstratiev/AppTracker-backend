using AppTracker.Data.Common;

namespace AppTracker.Data.Models
{
    public class ApplicationLog: BaseDeletableModel<int>
    {
        public int CreatorId { get; set; }

        public ApplicationUser Creator { get; set; }
    }
}
