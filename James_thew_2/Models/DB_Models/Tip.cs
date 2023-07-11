using System;
using System.Collections.Generic;

#nullable disable

namespace James_thew_2.Models.DB_Models
{
    public partial class Tip
    {
        public Tip()
        {
            ContestEntries = new HashSet<ContestEntry>();
        }

        public int TipId { get; set; }
        public int? UserId { get; set; }
        public string TipText { get; set; }
        public bool? IsFree { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ContestEntry> ContestEntries { get; set; }
    }
}
