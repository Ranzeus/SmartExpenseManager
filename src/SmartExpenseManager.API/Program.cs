var builder = WebApplication.CreateBuilder(args);

// Controllers (API layer)
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Future: Application & Infrastructure DI
// builder.Services.AddApplication();
// builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTP only (WSL friendly)
app.UseRouting();

app.MapControllers();

app.Run();
