
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;
//Add services to the container
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    //Telling MediatR where to find the Command and Querys 
    config.RegisterServicesFromAssemblies(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
builder.Services.AddValidatorsFromAssembly(assembly);
//Register Marten ORM
builder.Services.AddMarten(options => {
    options.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

if (builder.Environment.IsDevelopment()) builder.Services.InitializeMartenWith<CatalogInitialData>();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

//Add Health Checks
builder.Services.AddHealthChecks().AddNpgSql(builder.Configuration.GetConnectionString("Database"));

//Build application
var app = builder.Build();

//Configure the HTTP request pipeline
app.MapCarter();
//Enabling global exception handler
app.UseExceptionHandler(options =>
{

});

app.UseHealthChecks("/health", new HealthCheckOptions { ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse});
app.Run();
