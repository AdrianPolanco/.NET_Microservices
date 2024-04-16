




var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;
//Add services to the container
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
//Telling MediatR where to find the Command and Querys 
config.RegisterServicesFromAssemblies(assembly);
config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});
builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddMarten(options => {
    options.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
var app = builder.Build();

//Configure the HTTP request pipeline
app.MapCarter();
//Enabling global exception handler
app.UseExceptionHandler(options =>
{

});
app.Run();
