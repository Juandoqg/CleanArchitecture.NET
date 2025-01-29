using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace POO.Business
{
    public class Beer : Drink, ISalable, ISend
    {
        private const string Category = "Cerveza";
        private decimal _alcohol;
        public string Name { get; set; }
        public decimal Price { get; set; }

        public static int quantityObject;

        public decimal Alcohol
        {
            get { return _alcohol; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _alcohol = value;
            }
        }
        public Beer(string name, decimal price, decimal alcohol, int quantity)
            : base (quantity)
        {
            Name = name;
            Price = price;
            Alcohol = alcohol;
            quantityObject++;
        }

        public virtual string getInfo()
        {
            return "Nombre " + Name + " Precio:" + Price + " Alcohol " + Alcohol;
        }
        public string getInfo(string message)
        {
            return  message + "Nombre " + Name + " Precio:" + Price + " Alcohol " + Alcohol;
        }

        public override string getCategory()
        {
            return Category;
        }
        public decimal getPrice()
            => Price;

        public void Send()
                => Console.WriteLine("Enviando " + getCategory());
    }
}
