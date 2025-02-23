var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
});
var app = builder.Build();
app.MapCarter();
app.Run();