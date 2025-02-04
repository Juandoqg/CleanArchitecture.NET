using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_EnterpriseLayer
{
    public class Concept
    {
        public int IdBeer { get; }
        public int Quantity { get; }

        public decimal UnitPrice { get; }

        public decimal Price { get; }

        public Concept(int quantity, int idBeer, decimal unitPrice)
        {
            IdBeer = quantity;
            Quantity = idBeer;
            UnitPrice = unitPrice;
            Price = GetTotalPrice();
        }

        private decimal GetTotalPrice()
         => Quantity* UnitPrice;
    }
}
