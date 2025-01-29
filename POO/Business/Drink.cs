using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace POO.Business
{
    public abstract class Drink
    {
        public int Quantity { get; set; }

        public Drink(int quantity)
        {
            this.Quantity = quantity;
        }

        public string getQuantity()
        {
            return Quantity + " ml";
        }

        public abstract string getCategory();

    }
}
