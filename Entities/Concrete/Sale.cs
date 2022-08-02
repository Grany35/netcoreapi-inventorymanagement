using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Sale
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
