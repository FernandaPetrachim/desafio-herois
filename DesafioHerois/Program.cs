using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Data;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços necessários
builder.Services.AddControllers();

// Configura o DbContext para usar um banco de dados em memória
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("HeroiDb"));

// Adiciona o Swagger para documentação da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SuperHero API",
        Version = "v1",
        Description = "Uma API para gerenciamento de heróis com superpoderes."
    });
});

var app = builder.Build();

// Middleware de desenvolvimento: habilita Swagger e SwaggerUI apenas em ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "SuperHero API v1");
        options.RoutePrefix = string.Empty; // Define o Swagger na raiz, por exemplo, https://localhost:5001
    });
}

app.UseHttpsRedirection();

// Configura a autorização (se necessário)
app.UseAuthorization();

// Mapeia os controladores
app.MapControllers();

// Executa a aplicação
app.Run();

