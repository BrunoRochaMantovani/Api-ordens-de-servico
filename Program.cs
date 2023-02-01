

using API_ORDEM_SERVICO.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();
app.MapControllers();
app.MapControllers();
app.Run();
