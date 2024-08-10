using BuildingBlocks.Behaviors;
using BuildingBlocks.Exceptions.Handler;
using Carter;
using Discount.API.Data;
using Discount.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;
// Add services to the container.
builder.Services.AddDbContext<DiscountContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("Database"))
    );

builder.Services.AddCarter();
builder.Services.AddScoped<DiscountService>();
;
builder.Services.AddMediatR(config =>
{
    //Telling MediatR where to find the Command and Querys 
    config.RegisterServicesFromAssemblies(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

//Configure the HTTP request pipeline
app.MapCarter();
//Enabling global exception handler
app.UseExceptionHandler(options =>
{

});
// Configure the HTTP request pipeline.
//Adding the DiscountService to the request pipeline, so it will be available

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigration();
}

app.Run();
