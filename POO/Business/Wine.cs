using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace POO.Business
{
    public class Wine : Drink 
    {
        private const string Category = "Vino";
        public Wine(int quantity):base (quantity) { }

        public override string getCategory()
        {
            return Category;
        }
    }
}
