using System;
using System.Collections.Generic;

#nullable disable

namespace James_thew_2.Models.DB_Models
{
    public partial class ContestEntry
    {
        public int EntryId { get; set; }
        public int? ContestId { get; set; }
        public int? UserId { get; set; }
        public int? RecipeId { get; set; }
        public int? TipId { get; set; }
        public DateTime? EntryDate { get; set; }

        public virtual Contest Contest { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual Tip Tip { get; set; }
        public virtual User User { get; set; }
    }
}
