using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace James_thew_2.Models.DB_Models
{
    public partial class Ingredient
    {
        public int IngredientId { get; set; }
        public int? RecipeId { get; set; }

        [Required(ErrorMessage = "Ingredient Name is Required")]
        [MaxLength(200,ErrorMessage ="Too Long")]
        public string IngredientName { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
