using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace James_thew_2.Models.DB_Models
{
    public partial class Step
    {
        public int StepId { get; set; }
        public int? RecipeId { get; set; }

        [Required(ErrorMessage ="Steps Number is Required")]
        public int? StepNumber { get; set; }

        [Required(ErrorMessage = "Steps Description is Required")]
        public string Description { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
