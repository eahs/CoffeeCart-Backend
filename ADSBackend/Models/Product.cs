using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ADSBackend.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Type")]
        public Type Type { get; set; }
        [Display(Name = "Options")]
        public List<Option> Options { get; set; }
    }

    public enum Type
    {
        Regular, Tea, Express
    }
}
