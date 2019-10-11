using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ADSBackend.Models.OrderViewModels
{
    public class OrderModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Orderer Name")]
        public String OrdererName { get; set; }
        [Required]
        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Order")]
        public DateTime DateOrdered { get; set; }

        [Required]
        [Display(Name = "Order")]
        public ProductModel ProductOrdered { get; set; }

        [Display(Name = "Size")]
        public string Size { get; set; }

        [Display(Name = "Instructions")]
        public string Instructions { get; set; }
        
    }
}
