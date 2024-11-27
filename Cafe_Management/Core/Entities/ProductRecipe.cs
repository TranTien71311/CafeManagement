﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cafe_Management.Core.Entities
{
    [Table("ProductRecipe")]
    public class ProductRecipe
    {
        [Key]
        public int? Recipe_ID { get; set; }
        public int? Product_ID { get; set; }
        public int? Ingredient_ID { get; set; }
        public double? Quantity { get; set; }
        public int? Unit { get; set; }
    }
}
