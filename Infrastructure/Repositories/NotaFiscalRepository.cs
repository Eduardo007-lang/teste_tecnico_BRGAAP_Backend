using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using teste_tecnico_api.Domain.Interfaces;
using teste_tecnico_api.Domain.Models;

namespace teste_tecnico_api.Infrastructure.Repositories
{
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private readonly IMongoCollection<NotaFiscal> _notasFiscaisCollection;

        public NotaFiscalRepository(IMongoDatabase database)
        {
            _notasFiscaisCollection = database.GetCollection<NotaFiscal>("invoice");
        }

        public async Task AddNotaFiscalAsync(NotaFiscal notaFiscal)
        {
            await _notasFiscaisCollection.InsertOneAsync(notaFiscal);
        }

        public async Task<NotaFiscal> GetNotaFiscalByIdAsync(string id)
        {
            return await _notasFiscaisCollection.Find(n => n.Id == MongoDB.Bson.ObjectId.Parse(id)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<NotaFiscal>> GetAllNotasFiscaisAsync()
        {
            return await _notasFiscaisCollection.Find(_ => true).ToListAsync();
        }
    }
}
