using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductCategoryId { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public int Stock { get; set; }
        public string Location { get; set; }
        public string? BarcodeNumber { get; set; }
    }
}
