﻿using System;
using System.ComponentModel.DataAnnotations;

namespace AppTracker.Data.Common
{
    public class BaseModel<TKey> : IAuditInfo
    {
        [Key]
        public TKey Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
