using System;
using System.Collections.Generic;

#nullable disable

namespace James_Thew.Models.db_models
{
    public partial class Announcement
    {
        public int AnnouncementId { get; set; }
        public int? UserId { get; set; }
        public string AnnouncementText { get; set; }
        public DateTime? AnnouncementDate { get; set; }

        public virtual User User { get; set; }
    }
}
