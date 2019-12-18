using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSBackend.Models.OrderViewModels
{
    public class ProductOrder
    {
        public int Id { get; set; }
        public Product Product { get; set; }

        public String Size { get; set; }
        public String Instructions { get; set; }

    }
}
