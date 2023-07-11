using System;
using System.Collections.Generic;

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
        public string CategoryName { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
