using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ADSBackend.Models
{
    public class Order
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public String OrdererName { get; set; }
        [Required]
        public string RoomNumber { get; set; }
        public string ProductName { get; set; }
        public string Options { get; set; }
        public string Addons { get; set; }

    }
}
