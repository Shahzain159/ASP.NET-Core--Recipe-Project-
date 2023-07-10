using System;
using System.Collections.Generic;

#nullable disable

namespace James_Thew.Models.db_models
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
        public string RecipeTitle { get; set; }
        public string RecipeImage { get; set; }
        public int? CategoryId { get; set; }
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
