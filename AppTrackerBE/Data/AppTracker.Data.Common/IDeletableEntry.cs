using System;

namespace AppTracker.Data.Common
{
    public interface IDeletableEntry
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
