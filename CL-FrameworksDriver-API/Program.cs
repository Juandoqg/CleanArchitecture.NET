using CL_ApplicationLayer;
using CL_InterfaceAdapters_Repository;
using CL_InterfaceAdapters_Data;
using Microsoft.EntityFrameworkCore;
using CL_InterfaceAdapters_Models;
using CL_EnterpriseLayer;
using CL_InterfaceAdapters_Presenters;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using CL_InterfaceAdapters_Mappers.DTO.Requests;
using CL_InterfaceAdapters_Mappers;
using CL_FrameworksDriver_API.Middlewares;
using CL_FrameworksDriver_API.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using CL_InterfaceAdapters_Adapters;
using CL_InterfaceAdapters_Adapters.DTOS;
using CL_FrameworksDrivers_ExternalService;
using System.Reflection.Metadata.Ecma335;



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
builder.Services.AddScoped<IRepository<Sale>, SaleRepository>();
builder.Services.AddScoped<IRepositorySearch<SaleModel, Sale>, SaleRepository>();

builder.Services.AddScoped<IPresenter<Beer,BeerViewModel> ,BeerPresenter>();
builder.Services.AddScoped<IPresenter<Beer, BeerDetailViewModel> ,BeerDetailPresenter>();

builder.Services.AddScoped<IMapper<BeerRequestDTO, Beer>, BeerMapper>();
builder.Services.AddScoped<IMapper<SaleRequestDTO, Sale>, SaleMapper>();

builder.Services.AddScoped<IExternalService<PostServiceDTO>, PostService>();
builder.Services.AddScoped<IExternalServiceAdapter<Post>, PostExternalServiceAdapter>();


builder.Services.AddScoped<GetBeerUseCase<Beer, BeerViewModel>>();
builder.Services.AddScoped<GetBeerUseCase<Beer,BeerDetailViewModel>>();
builder.Services.AddScoped<AddBeerUseCase<BeerRequestDTO>>();
builder.Services.AddScoped<GetPostUseCase>();
builder.Services.AddScoped<GenerateSaleUseCase<SaleRequestDTO>>();
builder.Services.AddScoped<GetSaleUseCase>();
builder.Services.AddScoped<GetSaleSearchUseCase<SaleModel>>();


//validadores
builder.Services.AddValidatorsFromAssemblyContaining<BeerValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();


builder.Services.AddHttpClient<IExternalService<PostServiceDTO>, PostService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["BaseUrlPosts"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();


app.MapGet("/beer", async(GetBeerUseCase<Beer, BeerViewModel> beerUseCase) =>
{
    return await beerUseCase.ExecuteAsync();
})
.WithName("beers")
.WithOpenApi();

app.MapPost("/beer", async (BeerRequestDTO beerRequest,
    AddBeerUseCase<BeerRequestDTO> beerUseCase
    ,IValidator<BeerRequestDTO> validator)
    =>
{
    var result = await validator.ValidateAsync(beerRequest);
    if(!result.IsValid)
    {
        return Results.ValidationProblem(result.ToDictionary());
    }    

    await beerUseCase.ExecuteAsync(beerRequest);
    return Results.Created();
})
.WithName("AddBeers")
.WithOpenApi();

app.MapGet("/BeerDetail", async (GetBeerUseCase<Beer, BeerDetailViewModel> beerUseCase) =>
{
    return await beerUseCase.ExecuteAsync();
})
    .WithName("beerDetail")
    .WithOpenApi();

app.MapGet("/posts", async (GetPostUseCase postUseCase) =>

{
    return await postUseCase.ExecuteAsync();
}
).WithName("posts")
.WithOpenApi();


app.MapPost("/sale" , async (SaleRequestDTO saleRequest,
    GenerateSaleUseCase<SaleRequestDTO> saleUseCase) =>
{
    await saleUseCase.ExecuteAsync(saleRequest);
    return Results.Created();

}
 ).WithName("generateSales")
 .WithOpenApi();

app.MapGet("/sale",async (GetSaleUseCase saleUseCase) =>
{
    return await saleUseCase.ExecuteAsync();
}
    
    
).WithName("getSales")
.WithOpenApi();

app.MapGet("/salesearch/{total}" , async (GetSaleSearchUseCase<SaleModel> saleuseCase,int total)=>
{
    return await saleuseCase.ExecuteAsync(s => s.Total > total);
}
).WithName("getSalesSearch")
.WithOpenApi();





app.Run();

