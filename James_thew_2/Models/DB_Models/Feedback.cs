﻿using System;
using System.Collections.Generic;

#nullable disable

namespace James_thew_2.Models.DB_Models
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public int? UserId { get; set; }
        public int? RecipeId { get; set; }
        public string FeedbackText { get; set; }
        public DateTime? FeedbackDate { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual User User { get; set; }
    }
}
