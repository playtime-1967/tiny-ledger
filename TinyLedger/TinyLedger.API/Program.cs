using TinyLedger.Domain;
using TMM.API.Filters;

var builder = WebApplication.CreateBuilder(args);

// Service registeration
builder.Services.AddControllers().AddMvcOptions(options => options.Filters.AddService<ExceptionHandler>());
builder.Services.AddSingleton<AccountService>();
builder.Services.AddSingleton<ExceptionHandler>();

//HTTP pipeline.
var app = builder.Build();
app.MapControllers();
app.Run();
