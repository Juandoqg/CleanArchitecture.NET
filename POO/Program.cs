using System.Runtime.CompilerServices;
using POO.Business;

Beer aguila = new Beer("poker" , 2000, -2 , 10000);

var delirium = new ExpiringBeer("deliruium" , 4,1000, new DateTime(2024,12,01) , 203);

Drink drink = new Wine(500);
Show(drink);
SendSome(aguila);

var service = new Service(100,10);

ISalable[] concepts = [aguila, delirium, service];
Console.WriteLine(getTotal(concepts));

void Show(Drink drink)
=> Console.WriteLine(drink.getCategory());
var elements = new Collection<int>(5);
elements.Add(100);
elements.Add(200);
elements.Add(300);
elements.Add(400);
elements.Add(500);

foreach (var element in elements.get())
{ 
    Console.WriteLine(element);
}

var names = new Collection<string>(2);
names.Add("JUAN");
names.Add("DAVID");


foreach (var name in names.get())
{
    Console.WriteLine(name);
}

Console.WriteLine(Beer.quantityObject);

Console.WriteLine(Operations.Add(10, 3));
Console.WriteLine(Operations.Mul(10, 3));

void SendSome(ISend some)
{
    Console.WriteLine("Antes");
    some.Send();
    Console.WriteLine("Despues");
}

decimal getTotal(ISalable[] concepts)
{ 
 decimal total = 0;
    foreach (var concept in concepts)
    {
        total += concept.getPrice();
    }
    return total;   

}
