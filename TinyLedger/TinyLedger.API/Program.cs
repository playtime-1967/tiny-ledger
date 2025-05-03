using TinyLedger.Application;

var builder = WebApplication.CreateBuilder(args);

// Service registeration
builder.Services.AddControllers();
builder.Services.AddSingleton<AccountService>();

//HTTP pipeline.
var app = builder.Build();
app.MapControllers();
app.Run();
