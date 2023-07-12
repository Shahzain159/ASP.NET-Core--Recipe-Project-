using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace James_thew_2.Models.DB_Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            Comments = new HashSet<Comment>();
            ContestEntries = new HashSet<ContestEntry>();
            Feedbacks = new HashSet<Feedback>();
            Ingredients = new HashSet<Ingredient>();
            Steps = new HashSet<Step>();
        }

        public int RecipeId { get; set; }
        public int? UserId { get; set; }

        [Required(ErrorMessage ="Title is Required")]
        [Display(Name ="Recipe Title")]
        public string RecipeTitle { get; set; }
        [Required(ErrorMessage = "Recipe Main Image is Required")]
        [Display(Name = "Recipe Main Image")]
        public string RecipeImage { get; set; }
       
        public int? CategoryId { get; set; }
       
        [Display(Name = "Set Recipe Free or MemberShip Only")]
        public bool? IsFree { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ContestEntry> ContestEntries { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<Step> Steps { get; set; }
    }
}
