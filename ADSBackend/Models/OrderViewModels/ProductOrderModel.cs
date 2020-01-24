using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSBackend.Models.OrderViewModels
{
    public class ProductOrderModel
    {
        public int Id { get; set; }
        public ProductModel Product { get; set; }

        public String Size { get; set; }
        public String Instructions { get; set; }

    }
}
