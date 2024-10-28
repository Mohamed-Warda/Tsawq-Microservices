var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter(
    new DependencyContextAssemblyCatalog(assemblies: typeof(Program).Assembly)//todo lect54 questions
);
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("DataBase"));
}).UseLightweightSessions();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapCarter();
app.Run();