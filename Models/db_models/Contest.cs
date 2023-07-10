using System;
using System.Collections.Generic;

#nullable disable

namespace James_Thew.Models.db_models
{
    public partial class Contest
    {
        public Contest()
        {
            ContestEntries = new HashSet<ContestEntry>();
        }

        public int ContestId { get; set; }
        public int? UserId { get; set; }
        public string ContestTitle { get; set; }
        public string ContestDescription { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ContestEntry> ContestEntries { get; set; }
    }
}
