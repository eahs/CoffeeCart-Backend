using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ADSBackend.Models.OrderModels
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Product Type")]
        public ProductType Type { get; set; }

        [Required]
        [Display(Name = "Price")]
        public string Price { get; set; }

    }

    public enum ProductType
    {
        Beverage,
        Pastry
    }
}
