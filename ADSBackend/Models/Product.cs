using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ADSBackend.Models
{
    public class Product
    {
        int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        string Name { get; set; }
        [Display(Name = "Options")]
        string Options { get; set; }
        [Display(Name = "Addons")]
        string Addons { get; set; }
    }
}
