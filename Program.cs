using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

using teste_tecnico_api.Domain.Interfaces;
using teste_tecnico_api.Infrastructure.Repositories;
using teste_tecnico_api.Application.Services;
using teste_tecnico_api.Infrastructure.Configurations;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


// Configura��o de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Configura��o do MongoDbConfig
builder.Services.Configure<MongoDbConfig>(builder.Configuration.GetSection("MongoDbConfig"));

// Registrar IMongoClient
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var mongoDbConfig = sp.GetRequiredService<IOptions<MongoDbConfig>>().Value;
    var settings = MongoClientSettings.FromConnectionString(mongoDbConfig.ConnectionString);
    return new MongoClient(settings);
});

// Registrar IMongoDatabase
builder.Services.AddSingleton(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    var mongoDbConfig = sp.GetRequiredService<IOptions<MongoDbConfig>>().Value;
    return client.GetDatabase(mongoDbConfig.DatabaseName);
});

// Adicionando reposit�rios e servi�os
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();
builder.Services.AddScoped<INotaFiscalRepository, NotaFiscalRepository>();
builder.Services.AddScoped<INotaFiscalService, NotaFiscalService>();

// Adicionando servi�os de controladores
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
