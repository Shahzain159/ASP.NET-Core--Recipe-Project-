using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace James_thew_2.Models.DB_Models
{
    public partial class Category
    {
        public Category()
        {
            Recipes = new HashSet<Recipe>();
        }
        
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Name is Empty")]
        [MinLength(5 , ErrorMessage ="Name is too short")]
        [MaxLength(25 , ErrorMessage ="Name is too Long")]
        public string CategoryName { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
