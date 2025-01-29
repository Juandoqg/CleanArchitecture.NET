using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Business
{
    public class ExpiringBeer : Beer
    {
        DateTime Expiration {  get; set; }
        public ExpiringBeer(string name, decimal price, decimal alcohol, DateTime expiration,
            int quantity)
            :base(name, price, alcohol, quantity) 
        {
            Expiration = expiration;
        
        
        }
        public override string getInfo()
        {
            return "Cerverza que caduca " + " Nombre " + Name + " Precio " + Price + " Fecha de caducaccion " + Expiration;
        }


    }
}
