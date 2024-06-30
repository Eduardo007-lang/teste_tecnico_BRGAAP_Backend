using MongoDB.Driver;
using teste_tecnico_api.Domain.Models;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
        _database = client.GetDatabase("MongoDbConfig:BRGAAP");
    }

    public IMongoCollection<Cliente> Clientes => _database.GetCollection<Cliente>("Clientes");
    public IMongoCollection<Fornecedor> Fornecedores => _database.GetCollection<Fornecedor>("Fornecedores");
    public IMongoCollection<NotaFiscal> NotasFiscais => _database.GetCollection<NotaFiscal>("NotasFiscais");
}
