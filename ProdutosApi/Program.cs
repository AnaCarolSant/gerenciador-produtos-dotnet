using Microsoft.EntityFrameworkCore;
using ProdutosBusiness;
using ProdutosData;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o DbContext com a string de conexão do appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona os serviços do seu domínio
builder.Services.AddScoped<ProdutosService>();

// Configurações do Swagger/OpenAPI
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Middleware para ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Middleware de HTTPS e Controllers
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
