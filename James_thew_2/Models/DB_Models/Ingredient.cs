using System;
using System.Collections.Generic;

#nullable disable

namespace James_thew_2.Models.DB_Models
{
    public partial class Ingredient
    {
        public int IngredientId { get; set; }
        public int? RecipeId { get; set; }
        public string IngredientName { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
