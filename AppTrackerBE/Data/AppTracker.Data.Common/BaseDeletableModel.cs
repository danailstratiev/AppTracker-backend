using System;

namespace AppTracker.Data.Common
{
    public abstract class BaseDeletableModel<TKey> : BaseModel<TKey>, IDeletableEntry
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
