using BusinessComponent;
using Microsoft.Extensions.DependencyInjection;
using RepositoryComponent;

var container = new ServiceCollection()
                     .AddSingleton<IRepository, BeerRepository>()
                     .AddTransient<BeerManager>()
                     .BuildServiceProvider();


var beerManager = container.GetService<BeerManager>();
beerManager.Add("aguila");
beerManager.Add("aguila2");
Console.WriteLine(beerManager.Get());


public class DefaultRepository : IRepository
{
    public void Add(string name)
    { }
    public string Get()
     => "algo";
}