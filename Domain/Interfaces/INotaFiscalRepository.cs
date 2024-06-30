using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using teste_tecnico_api.Domain.Models;

namespace teste_tecnico_api.Domain.Interfaces
{
    public interface INotaFiscalRepository
    {

        Task AddNotaFiscalAsync(NotaFiscal notaFiscal);
        Task<NotaFiscal> GetNotaFiscalByIdAsync(string id);
        Task<IEnumerable<NotaFiscal>> GetAllNotasFiscaisAsync();
    }
}
