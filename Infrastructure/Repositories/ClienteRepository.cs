using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using teste_tecnico_api.Domain.Interfaces;
using teste_tecnico_api.Domain.Models;

namespace teste_tecnico_api.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IMongoCollection<Cliente> _clientesCollection;
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _database;

        public ClienteRepository(IMongoClient mongoClient, IMongoDatabase database)
        {
            _mongoClient = mongoClient;
            _database = database;
            _clientesCollection = database.GetCollection<Cliente>("client");
        }

        public async Task AddClienteAsync(Cliente cliente)
        {
        
                await _clientesCollection.InsertOneAsync(cliente);
         
        }

        public async Task<Cliente> GetClienteByIdAsync(string id)
        {
            return await _clientesCollection.Find(c => c.Id == MongoDB.Bson.ObjectId.Parse(id)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            return await _clientesCollection.Find(_ => true).ToListAsync();
        }

        public IClientSessionHandle StartSession()
        {
            return _mongoClient.StartSession();
        }

        public async Task CommitTransactionAsync(IClientSessionHandle session)
        {
            await session.CommitTransactionAsync();
        }

        public async Task AbortTransactionAsync(IClientSessionHandle session)
        {
            await session.AbortTransactionAsync();
        }
    }
}
