using CL_ApplicationLayer;
using CL_InterfaceAdapters_Repository;
using CL_InterfaceAdapters_Data;
using Microsoft.EntityFrameworkCore;
using CL_InterfaceAdapters_Models;
using CL_EnterpriseLayer;
using CL_InterfaceAdapters_Presenters;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependencias
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);
builder.Services.AddScoped<IRepository<Beer>,Repository>();
builder.Services.AddScoped<IPresenter<Beer,BeerViewModel> ,BeerPresenter>();
builder.Services.AddScoped<GetBeerUseCase<Beer, BeerViewModel>>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapGet("/beer", async(GetBeerUseCase<Beer, BeerViewModel> beerUseCase) =>
{
    return await beerUseCase.ExecuteAsync();
})
.WithName("beers")
.WithOpenApi();

app.Run();

