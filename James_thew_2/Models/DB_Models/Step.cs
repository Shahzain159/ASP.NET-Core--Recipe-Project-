using System;
using System.Collections.Generic;

#nullable disable

namespace James_thew_2.Models.DB_Models
{
    public partial class Step
    {
        public int StepId { get; set; }
        public int? RecipeId { get; set; }
        public int? StepNumber { get; set; }
        public string Description { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
