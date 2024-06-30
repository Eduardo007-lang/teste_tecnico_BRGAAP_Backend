using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using teste_tecnico_api.Domain.Interfaces;
using teste_tecnico_api.Domain.Models;

namespace teste_tecnico_api.Infrastructure.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly IMongoCollection<Fornecedor> _fornecedoresCollection;
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _database;

        public FornecedorRepository(IMongoClient mongoClient, IMongoDatabase database)
        {
            _mongoClient = mongoClient;
            _database = database;
            _fornecedoresCollection = database.GetCollection<Fornecedor>("supplier");
        }

        public async Task AddFornecedorAsync(Fornecedor fornecedor)
        {
           
                await _fornecedoresCollection.InsertOneAsync(fornecedor);
          
        }

        public async Task<Fornecedor> GetFornecedorByIdAsync(string id)
        {
            return await _fornecedoresCollection.Find(f => f.Id == MongoDB.Bson.ObjectId.Parse(id)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Fornecedor>> GetAllFornecedoresAsync()
        {
            return await _fornecedoresCollection.Find(_ => true).ToListAsync();
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
